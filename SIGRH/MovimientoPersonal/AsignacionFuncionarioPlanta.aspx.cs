using System;
using System.Collections.Generic;
using System.Data;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;

public partial class MovimientoPersonal_Asignacion_Funcionario_Planta : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_mp_asignacion asignacion = null;
    private cls_historico historico = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa glosa = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            llenarArbolInicial();
            obtenerTipoMov();
            string codFun = Request.QueryString["id"].ToString();
            CargarAsignaciones(Convert.ToInt32(codFun));
            //ddl_asignacion.SelectedIndex = 0;
            informacionFuncionario(codFun);
            listaFiltradoTipoDoc();
 
        }
    }

    private void listaFiltradoTipoDoc()
    {
        try
        {
            _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
            var detalle_catalogo = _catalogo.ObtenerTablaCombo().Tables[0];

            DataTable lista_catalogo = new DataTable();
            lista_catalogo.Columns.Add("cat_id");
            lista_catalogo.Columns.Add("cat_descripcion");
            DataRow dr = null;

            int[] ids = { 816, 821, 1914 };

            for (int i = 0; i < ids.Length; i++)
            {
                for (int j = 0; j < detalle_catalogo.Rows.Count; j++)
                {
                    if (ids[i] == Convert.ToInt32(validarCampo(detalle_catalogo.Rows[j]["cat_id"])))
                    {
                        dr = lista_catalogo.NewRow();
                        dr["cat_id"] = validarCampo(detalle_catalogo.Rows[j]["cat_id"]);
                        dr["cat_descripcion"] = validarCampo(detalle_catalogo.Rows[j]["cat_descripcion"]);
                        lista_catalogo.Rows.Add(dr);
                        break;
                    }
                }
            }

            ddl_tipo_documento.Items.Clear();
            ddl_tipo_documento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_documento.DataValueField = "cat_id";
            ddl_tipo_documento.DataTextField = "cat_descripcion";
            ddl_tipo_documento.DataSource = lista_catalogo;
            ddl_tipo_documento.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_buscar_item_Click(object sender, EventArgs e)
    {
        sc = "$('#modalBuscarItems').modal('show');";
        SetScript(sc);
    }
    protected void llenarArbolInicial()
    {
        //string gestionFiltrar = obtenerGestion();
        try
        {
            cargo = new cls_mp_cargo();
            cargo.eo_id = 0;
            cargo.gestion_selec = Session["pr_id"].ToString();
            var nivelOrg = cargo.ObtenerNivelOrgEjecutivo();

            foreach (DataRow level1DataRow in nivelOrg.Tables[0].Rows)
            {
                string eo_id = level1DataRow["eo_id"].ToString();
                if (eo_id != "")
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Value = level1DataRow["eo_id"].ToString();

                    treeNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0 desc-treeview'>" + level1DataRow["eo_descripcion"].ToString() + "</h6></div></div>";
                    tv_nivelOrg.Nodes.Add(treeNode);
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
   
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_cancelar_buscar_Click(object sender, EventArgs e)
    {
        Limpiar();
        tv_nivelOrg.Nodes.Clear();
        llenarArbolInicial();
        sc = "$('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_guardar').css('display', 'none'); $('#block_intercambio').css('display', 'none'); $('#block_datos_fun').css('display', 'none');";
        SetScript(sc);
    }

    protected void Limpiar ()
    {
        txt_descripcion_add.Text = string.Empty;
        ddl_tipo_documento.SelectedValue = "0";
    
        ddl_tipoMovimiento.SelectedValue = "0";
        aux_validar_item.Value = "0";
        txt_digite_item.Text = string.Empty;
        ltl_nombre_fun_inter.Text = string.Empty;
        ltl_ci_inter.Text = string.Empty;
    }

    protected void tv_nivelOrg_SelectedNodeChanged(object sender, EventArgs e)
    {
        int eo_id = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);
        //string gestionFiltrar = obtenerGestion();
        cargo = new cls_mp_cargo();
        cargo.ep_cod_estp = eo_id;
        cargo.gestion_selec = Session["pr_id"].ToString();
        var nivelOrg = cargo.ObtenerNivelOrganizacional();
        var nivelOrgItems = cargo.ObtenerNivelOrganizacionalItemsMasAcefalia();
        var detalleItem = cargo.ObtenerDetalleItemPlanta();

        foreach (DataRow lvlNDataRow in nivelOrg.Tables[0].Rows)
        {
            TreeNode childNode = new TreeNode();
            childNode.Value = lvlNDataRow["eo_id"].ToString();
            childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0 desc-treeview'>" + lvlNDataRow["eo_descripcion"].ToString() + "</h6></div></div>";

            TreeNode parentNode = tv_nivelOrg.SelectedNode;
            validarNodo(parentNode, childNode);

        }

        foreach (DataRow lvlNDataRow in nivelOrgItems.Tables[0].Rows)
        {
            TreeNode childNode = new TreeNode();
            if (lvlNDataRow["per_num_doc"] != null && lvlNDataRow["per_num_doc"].ToString() != "")
            {
                childNode.Value = lvlNDataRow["ca_num_item"].ToString();
                childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-child-treeview mr-2'><i class='fas fa-user'></i></div></div><div>" + lvlNDataRow["ca_ti_item"].ToString() + " - " + lvlNDataRow["ca_num_item"].ToString() + " CI: " + lvlNDataRow["per_num_doc"].ToString() + " " + lvlNDataRow["nombreFun"].ToString() + "</div></div>";
                TreeNode parentNode = tv_nivelOrg.SelectedNode;
                validarNodo(parentNode, childNode);
            }
            else
            {
                if (lvlNDataRow["ca_estado"] != null && lvlNDataRow["ca_estado"].ToString() != "" && lvlNDataRow["ca_estado"].ToString() == "L")
                {
                    childNode.Value = lvlNDataRow["ca_num_item"].ToString();
                    childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-child2-treeview mr-2'><i class='fas fa-user'></i></div></div><div>" + lvlNDataRow["ca_ti_item"].ToString() + " - " + lvlNDataRow["ca_num_item"].ToString() + " ACEFALIA" + "</div></div>";
                    TreeNode parentNode = tv_nivelOrg.SelectedNode;
                    validarNodo(parentNode, childNode);
                }
            }
        }

        if (detalleItem.Tables[0].Rows.Count > 0)
        {
            aux_validar_item.Value = "1";
            aux_as_id_intercambio.Value = (detalleItem.Tables[0].Rows[0]["as_id"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["as_id"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["as_id"].ToString().Trim() : "";

            if (detalleItem.Tables[0].Rows[0]["es_descripcion"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["es_descripcion"].ToString().Trim() != "")
            {
                string haberBasicoItem = (detalleItem.Tables[0].Rows[0]["haber_basico"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["haber_basico"].ToString().Trim() != "") ? haberBasicoItem = detalleItem.Tables[0].Rows[0]["haber_basico"].ToString().Trim() : "";
                aux_ca_basico_calculado_nuevo.Value = haberBasicoItem;
                decimal haberBasico2 = Convert.ToDecimal(haberBasicoItem);
                haberBasico2 = Math.Round(haberBasico2, 2);
                ltl_cargo_asig.Text = (detalleItem.Tables[0].Rows[0]["es_descripcion"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["es_descripcion"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["es_descripcion"].ToString().Trim() : "";
                ltl_hb_asig.Text = haberBasico2 + "";
           
            }
            if (detalleItem.Tables[0].Rows[0]["eo_descripcion"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["eo_descripcion"].ToString().Trim() != "") { ltl_unidad_asig.Text = detalleItem.Tables[0].Rows[0]["eo_descripcion"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["pu_descripcion"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["pu_descripcion"].ToString().Trim() != "") { ltl_puesto_asig.Text = detalleItem.Tables[0].Rows[0]["pu_descripcion"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["es_escalafon"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["es_escalafon"].ToString().Trim() != "")
            {
                string clase = (detalleItem.Tables[0].Rows[0]["ns_clase"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ns_clase"].ToString().Trim() != "") ? clase = detalleItem.Tables[0].Rows[0]["ns_clase"].ToString().Trim() : "";
                string nSalarial = (detalleItem.Tables[0].Rows[0]["ns_nivel"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ns_nivel"].ToString().Trim() != "") ? nSalarial = detalleItem.Tables[0].Rows[0]["ns_nivel"].ToString().Trim() : "";

                ltl_cod_esc_asig.Text = detalleItem.Tables[0].Rows[0]["es_escalafon"].ToString().Trim();
                ltl_clase_asig.Text = clase;
                ltl_nivel_salarial_asig.Text = nSalarial;

            }
            if (detalleItem.Tables[0].Rows[0]["ca_ti_item"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_ti_item"].ToString().Trim() != "")
            {
                string nroItem = (detalleItem.Tables[0].Rows[0]["ca_num_item"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_num_item"].ToString().Trim() != "") ? nroItem = detalleItem.Tables[0].Rows[0]["ca_num_item"].ToString().Trim() : "";
                ltl_item_asig.Text = detalleItem.Tables[0].Rows[0]["ca_ti_item"].ToString().Trim() + " - " + nroItem;
            }
            //VARIABLES PARA CARGO NUEVO
            if (detalleItem.Tables[0].Rows[0]["ca_id"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_id"].ToString().Trim() != "") { aux_ca_id.Value = detalleItem.Tables[0].Rows[0]["ca_id"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["ca_es_id"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_es_id"].ToString().Trim() != "") { aux_ca_es_id.Value = detalleItem.Tables[0].Rows[0]["ca_es_id"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["ca_eo_id"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_eo_id"].ToString().Trim() != "") { aux_ca_eo_id.Value = detalleItem.Tables[0].Rows[0]["ca_eo_id"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["ca_ti_item"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_ti_item"].ToString().Trim() != "") { aux_ca_ti_item.Value = detalleItem.Tables[0].Rows[0]["ca_ti_item"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["ca_num_item"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_num_item"].ToString().Trim() != "") { aux_ca_num_item.Value = detalleItem.Tables[0].Rows[0]["ca_num_item"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["ca_aplica_incremento"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_aplica_incremento"].ToString().Trim() != "") { aux_ca_aplica_incremento.Value = detalleItem.Tables[0].Rows[0]["ca_aplica_incremento"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["ca_tipo_jornada"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_tipo_jornada"].ToString().Trim() != "") { aux_ca_tipo_jornada.Value = detalleItem.Tables[0].Rows[0]["ca_tipo_jornada"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["ca_basico_calculado"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_basico_calculado"].ToString().Trim() != "") { aux_ca_basico_calculado.Value = detalleItem.Tables[0].Rows[0]["ca_basico_calculado"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["ca_tipo_calculo"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_tipo_calculo"].ToString().Trim() != "") { aux_ca_tipo_calculo.Value = detalleItem.Tables[0].Rows[0]["ca_tipo_calculo"].ToString().Trim(); }
            if (detalleItem.Tables[0].Rows[0]["ca_pr_id"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["ca_pr_id"].ToString().Trim() != "") { aux_ca_pr_id.Value = detalleItem.Tables[0].Rows[0]["ca_pr_id"].ToString().Trim(); }
            //DATOS DEL FUNCIONARIO
            string nombreFun = (detalleItem.Tables[0].Rows[0]["per_nombres"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["per_nombres"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["per_nombres"].ToString().Trim() : ""; 
            string apMaterno = (detalleItem.Tables[0].Rows[0]["per_ap_materno"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["per_ap_materno"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["per_ap_materno"].ToString().Trim() : "";
            string apPaterno = (detalleItem.Tables[0].Rows[0]["per_ap_paterno"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["per_ap_paterno"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["per_ap_paterno"].ToString().Trim() + " " + apMaterno : "";
            ltl_nombre_fun_inter.Text = nombreFun + " " + apPaterno + " " + apMaterno;
            ltl_cod_fun_inter.Text = (detalleItem.Tables[0].Rows[0]["as_per_id"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["as_per_id"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["as_per_id"].ToString().Trim() : "";

            string exp = (detalleItem.Tables[0].Rows[0]["cat_abreviacion"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["cat_abreviacion"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["cat_abreviacion"].ToString().Trim() : "";
            ltl_ci_inter.Text = (detalleItem.Tables[0].Rows[0]["per_num_doc"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() + " " + exp : "";

            string estado_int = (detalleItem.Tables[0].Rows[0]["as_estado"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["as_estado"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["as_estado"].ToString().Trim() : "";
            if (estado_int == "V")
            {
                btn_estado_int.Text = "Vigente";
                btn_estado_int.CssClass = "btn btn-sm btn-info float-right";
            }
            else
            {
                btn_estado_int.Text = "Acefalia";
                btn_estado_int.CssClass = "btn btn-sm btn-secondary float-right";
            }

            string imagen_int = (detalleItem.Tables[0].Rows[0]["fp_foto"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["fp_foto"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["fp_foto"].ToString().Trim() : "";
            string sexo_int = (detalleItem.Tables[0].Rows[0]["per_sexo"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["per_sexo"].ToString().Trim() != "") ? detalleItem.Tables[0].Rows[0]["per_sexo"].ToString().Trim() : "";

            if (imagen_int != "")
            {
                imgFun_int.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleItem.Tables[0].Rows[0]["fp_foto"]);
            }
            else
            {
                if (sexo_int == "")
                {
                    imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
                }
                else
                {
                    if (sexo_int == "M")
                    {
                        imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
                    }
                    else
                    {
                        imgFun_int.ImageUrl = "../Content/img/theme/user4.jpg";
                    }
                }

            }

            if (detalleItem.Tables[0].Rows[0]["per_num_doc"] != DBNull.Value && detalleItem.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() != "")
            {
                aux_verifica_acefalia.Value = "1";

                sc = "$('#block_intercambio').css('display', 'block'); $('#block_datos_fun_inter').css('display', 'block'); $('#block_guardar').css('display', 'none');";
                SetScript(sc);
            }
            else
            {
                aux_verifica_acefalia.Value = "0";
                sc = "$('#block_intercambio').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none'); $('#block_guardar').css('display', 'block');";
                SetScript(sc);
            }
        }
        else
        {
            aux_validar_item.Value = "0";
        }

        tv_nivelOrg.SelectedNode.Expand();
        ViewState["selectednode"] = tv_nivelOrg.SelectedNode.ValuePath;
        sc = "$('#modalBuscarItems').modal('show');";
        SetScript(sc);
    }

    private void validarNodo(TreeNode parentNode, TreeNode childNode)
    {
        if (parentNode.ChildNodes.Count > 0)
        {
            bool sw = false;
            foreach (TreeNode childNodesParent in parentNode.ChildNodes)
            {
                if (childNodesParent.Value != childNode.Value)
                {
                    sw = true;
                }
                else
                {
                    sw = false;
                    break;
                }
            }
            if (sw)
            {
                tv_nivelOrg.SelectedNode.ChildNodes.Add(childNode);
            }
        }
        else
        {
            tv_nivelOrg.SelectedNode.ChildNodes.Add(childNode);
        }
    }

    private void obtenerTipoMov()
    {
        cargo = new cls_mp_cargo();
        cargo.p_cat_id = 1875;
        var tipoMovPadre = cargo.obtenerTipoMovPadre();
        if (tipoMovPadre.Tables[0].Rows.Count > 0)
        {
            if (tipoMovPadre.Tables[0].Rows[0]["cat_id"] != DBNull.Value && tipoMovPadre.Tables[0].Rows[0]["cat_id"].ToString().Trim() != "") { aux_cat_id.Value = tipoMovPadre.Tables[0].Rows[0]["cat_id"].ToString().Trim(); }
            if (tipoMovPadre.Tables[0].Rows[0]["cat_abreviacion"] != DBNull.Value && tipoMovPadre.Tables[0].Rows[0]["cat_abreviacion"].ToString().Trim() != "") { aux_cat_abreviacion.Value = tipoMovPadre.Tables[0].Rows[0]["cat_abreviacion"].ToString().Trim(); }
        }
        obtenerTipoMovHijo(aux_cat_id.Value);
    }

    private void obtenerTipoMovHijo(string cat_id)
    {
        try
        {
            cargo = new cls_mp_cargo();
            cargo.p_cat_id_superior = Convert.ToInt32(cat_id);

            ddl_tipoMovimiento.Items.Clear();
            ddl_tipoMovimiento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipoMovimiento.DataValueField = "cat_abreviacion";
            ddl_tipoMovimiento.DataTextField = "cat_descripcion";
            ddl_tipoMovimiento.DataSource = cargo.obtenerFiltradoTipoMov();
            ddl_tipoMovimiento.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_seleccionar_item_Click(object sender, EventArgs e)
    {
        string per_id = Request.QueryString["id"].ToString();
        if (aux_ca_num_item_actual.Value != tv_nivelOrg.SelectedValue)
        {
            if (aux_validar_item.Value == "1")
            {
                sc = "$.notify({ icon: 'fa fa-check', message: 'Ítem seleccionado correctamente'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); $('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_datos_fun').css('display', 'block'); $('#block_datos_fun_inter').css('display', 'block');";
                SetScript(sc);

                //COMBO AUTOMATICO
                double ca_basico_calculado_nuevo = Convert.ToDouble(aux_ca_basico_calculado_nuevo.Value);
                double ca_basico_calculado_actual = Convert.ToDouble(aux_ca_basico_calculado_actual.Value);
                if (aux_verifica_acefalia.Value == "0")
                {
                    sc = "$('#block_datos_fun_inter').css('display', 'none');";
                    SetScript(sc);
                    if (ca_basico_calculado_nuevo == ca_basico_calculado_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "2";
                    }
                    if (ca_basico_calculado_nuevo > ca_basico_calculado_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "4";
                    }
                    if (ca_basico_calculado_nuevo < ca_basico_calculado_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "5";
                    }
                }
                else
                {
                    sc = "$('#block_datos_fun_inter').css('display', 'block');";
                    SetScript(sc);
                    if (ca_basico_calculado_nuevo < ca_basico_calculado_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "1";
                    }
                    if (ca_basico_calculado_nuevo == ca_basico_calculado_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "2";
                    }
                    if (ca_basico_calculado_nuevo > ca_basico_calculado_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "3";
                    }
                }

            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-info', message: 'Debe seleccionar un ítem'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_guardar').css('display', 'none');";
                SetScript(sc);
            }
        }
        else
        {
            Limpiar();
            sc = "$.notify({ icon: 'fa fa-info', message: 'No puede realizar esta acción'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_guardar').css('display', 'none'); $('#block_intercambio').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none');";
            SetScript(sc);
        }
    }

    private void informacionFuncionario(string id = "")
    {
        string fu_num_ident = id;
        //string gestion_selec = obtenerGestion();
        cls_mp_cargo cargoo = new cls_mp_cargo();
        cargoo.fu_num_ident = fu_num_ident;
        cargoo.gestion_selec = Session["pr_id"].ToString();
        cargoo.as_ca_id = Convert.ToInt32(ddl_asignacion.SelectedValue);
        cargoo.obtenerDatosFuncionarioConAsignaciones(id);
        string haberBasico = cargoo.haber_basico.ToString().Trim();
        decimal haberBasico2 = Convert.ToDecimal(haberBasico);
        haberBasico2 = Math.Round(haberBasico2, 2);
        aux_per_id.Value = cargoo.as_per_id.ToString().Trim();
  
        ltl_cargo.Text = cargoo.es_descripcion.ToString().Trim();
        ltl_hb.Text = haberBasico2 + "";
        ltl_item.Text = cargoo.ca_ti_item_actual.ToString().Trim() + " - " + cargoo.ca_num_item_actual.ToString().Trim();
        ltl_puesto.Text = cargoo.pu_nombre_puesto.ToString().Trim();
        ltl_cod_esc.Text = cargoo.es_escalafon.ToString().Trim();
        ltl_clase.Text = cargoo.ns_clase.ToString().Trim();
        ltl_nivel_salarial.Text = cargoo.ns_nivel.ToString().Trim();
        ltl_ubicacion.Text = cargoo.ep_descripcion.ToString().Trim();
        ltl_fecha_asig.Text = cargoo.as_fecha_asignacion.ToString().Trim();
        ltl_fecha_baja.Text = cargoo.as_fecha_baja.ToString().Trim();
        switch (cargoo.ca_tipo_jornada_actual.ToString().Trim())
        {
            case "TC":
        ltl_jornada.Text = "TIEMPO COMPLETO";
                break;
            case "MT":
                ltl_jornada.Text = "MEDIO TIEMPO";
                break;
            default:
                ltl_jornada.Text = "HORAS";
                break;
        }

        aux_ca_id_actual.Value = cargoo.ca_id_actual.ToString().Trim();
        aux_ca_es_id_actual.Value = cargoo.ca_es_id_actual.ToString().Trim();
        aux_ca_eo_id_actual.Value = cargoo.ca_eo_id_actual.ToString().Trim();
        aux_ca_ti_item_actual.Value = cargoo.ca_ti_item_actual.ToString().Trim();
        aux_ca_num_item_actual.Value = cargoo.ca_num_item_actual.ToString().Trim();
        aux_ca_aplica_incremento_actual.Value = cargoo.ca_aplica_incremento_actual.ToString().Trim();
        aux_ca_tipo_jornada_actual.Value = cargoo.ca_tipo_jornada_actual.ToString().Trim();
        aux_ca_basico_calculado_actual.Value = cargoo.ca_basico_calculado_actual.ToString().Trim();
        aux_ca_tipo_calculo_actual.Value = cargoo.ca_tipo_calculo_actual.ToString().Trim();
        aux_ca_pr_id_actual.Value = cargoo.ca_pr_id_actual.ToString().Trim();
        aux_as_id_actual.Value = cargoo.as_id_actual.ToString().Trim();

        //encabezado nuevo
        string fu_nombres = (cargoo.fu_nombres != null) ? cargoo.fu_nombres.ToString().Trim() : "";
        string fu_paterno = (cargoo.fu_paterno != null) ? cargoo.fu_paterno.ToString().Trim() : "";
        string fu_materno = (cargoo.fu_materno != null) ? cargoo.fu_materno.ToString().Trim() : "";
        ltl_nombre_fun.Text = fu_nombres + " " + fu_paterno + " " + fu_materno;
        ltl_ci.Text = cargoo.fu_num_ident.ToString() + " " + cargoo.fu_tipo_ident.ToString().Trim();
        ltl_cod_fun.Text = cargoo.as_per_id.ToString();

        if (cargoo.as_estado.Trim() == "V")
        {
            btn_estado.Text = "Vigente";
            btn_estado.CssClass = "btn btn-sm btn-info float-right";
        }
        else
        {
            btn_estado.Text = "Pasivo";
            btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
        }
        if (cargoo.imagen != null && cargoo.imagen != "")
        {
            imgFun.ImageUrl = cargoo.imagen;
        }
        else
        {
            if (cargoo.fu_sexo.Trim() == "M")
            {
                imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
            }
            else
            {
                imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
            }
        }
    }

    private void procesarHistorico(int as_id = 0)
    {
        asignacion = new cls_mp_asignacion();
        asignacion.as_id = as_id;
        var detallePrecontratado = asignacion.ObtenerRegistro();
        string json = JsonConvert.SerializeObject(detallePrecontratado.Tables[0]);
        AdicionarHistorico("M", "tbl_mp_asignacion", "as_id", Convert.ToString(as_id), json);
    }

    private void actualizarAsignacionX(int as_id = 0)
    {
        string fechaBaja = ltl_fecha_baja.Text;
        string hora = DateTime.Now.ToString("HH:mm:ss");
        cargo.as_fecha_fin_actual = fechaBaja + " " + hora;
        cargo.as_id_actual = as_id;
        cargo.ActualizarAsignacion();
    }

    private void GuardarAsignacionNueva()
    {
        string perId = Session["per_id"].ToString();
        //string gestionFiltrar = obtenerGestion();
        string hora = DateTime.Now.ToString("HH:mm:ss");
        cargo.as_per_id = Convert.ToInt32(aux_per_id.Value);
        cargo.as_ca_id = Convert.ToInt32(aux_ca_id.Value);
        cargo.as_fecha_inicio = txt_fechaAsig.Text.ToString().Trim() + " " + hora;
        cargo.as_fecha_fin = "";
        cargo.as_estado = "V";
        cargo.as_tipo_reg = aux_cat_abreviacion.Value;
        cargo.as_tipo_mov = ddl_tipoMovimiento.SelectedValue;
        cargo.as_tipo_baja = null;
        cargo.as_usuario_creacion = Convert.ToInt32(perId);
        cargo.as_pr_id = Session["pr_id"].ToString();
        cargo.AdicionarPromocion();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Asignación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_guardar').css('display', 'none'); $('#block_intercambio').css('display', 'none'); }});";
        SetScript(sc);
    }

    private void GuardarAsignacionIntercambio(DataSet asignacion, int per_id = 0)
    {
        string perId = Session["per_id"].ToString();
        //string gestionFiltrar = obtenerGestion();
        string hora = DateTime.Now.ToString("HH:mm:ss");
        cargo.as_per_id = per_id;
        cargo.as_ca_id = (asignacion.Tables[0].Rows[0]["as_ca_id"] != DBNull.Value && asignacion.Tables[0].Rows[0]["as_ca_id"].ToString().Trim() != "") ? Convert.ToInt32(asignacion.Tables[0].Rows[0]["as_ca_id"].ToString().Trim()) : 0;
        cargo.as_fecha_inicio = txt_fechaAsig.Text.ToString().Trim() + " " + hora;
        cargo.as_fecha_fin = "";
        cargo.as_estado = "V";
        cargo.as_tipo_reg = aux_cat_abreviacion.Value;
        cargo.as_tipo_mov = ddl_tipoMovimiento.SelectedValue;
        cargo.as_tipo_baja = null;
        cargo.as_usuario_creacion = Convert.ToInt32(perId);
        cargo.as_pr_id = Session["pr_id"].ToString();
        cargo.AdicionarPromocion();
    }

    private void guardarGlosaAsignacion(int gl_valor_pk = 0, string gl_nombre_pk = "", string gl_tabla = "")
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;

        glosa = new cls_glosa();
        glosa.gl_valor_pk = gl_valor_pk + "";
        glosa.gl_nombre_pk = gl_nombre_pk;
        glosa.gl_tabla = gl_tabla;
        glosa.gl_tipo_mov = 813;
        glosa.gl_fecha_doc = Convert.ToDateTime(fechaMov);
        glosa.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        glosa.gl_numero_doc = (txt_num_doc.Text.Trim() != "") ? txt_num_doc.Text.Trim() : null;
        glosa.gl_glosa = txt_descripcion_add.Text.Trim().ToUpper();
        glosa.gl_estado = "V";
        glosa.gl_usuario = Convert.ToInt32(Session["us_id"].ToString());
        glosa.Adicionar();
        restablecerGlosa();
    }

    private int obtenerIdAsignacion()
    {
        cargo = new cls_mp_cargo();
        cargo.as_per_id = Convert.ToInt32(aux_per_id.Value);
        cargo.as_ca_id = Convert.ToInt32(aux_ca_id.Value);
        var asignacion = cargo.ObtenerAsignacion();

        int idAsignacionNuevo = 0;
        if (asignacion.Tables[0].Rows[0]["as_id"] != DBNull.Value && asignacion.Tables[0].Rows[0]["as_id"].ToString().Trim() != "")
        {
            idAsignacionNuevo = Convert.ToInt32(asignacion.Tables[0].Rows[0]["as_id"]);
        }
        return idAsignacionNuevo;
    }

    protected void txt_fechaAsig_TextChanged(object sender, EventArgs e)
    {
        string fechaAsig = txt_fechaAsig.Text;

        if (fechaAsig != null && fechaAsig != "")
        {
            DateTime cDate = Convert.ToDateTime(fechaAsig);
            cDate = cDate.AddDays(-1);
            string diaAntes = cDate.ToString("dd/MM/yyyy");
            ltl_fecha_baja.Text = diaAntes;
        }
        SetScript("");
    }

    protected void btn_guardar_item_Click(object sender, EventArgs e)
    {
        aux_valida_acefalo_inter.Value = "1";
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('show');";
        SetScript(sc);
    }

    protected void chk_tiene_item_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_tiene_item.Checked)
        {
            Limpiar();
            sc = "$('#block_digite_item').css('display', 'block'); $('#block_buscar_item').css('display', 'none'); $('#block_guardar').css('display', 'none'); $('#block_intercambio').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none'); $('#block_datos_fun').css('display', 'none');";
            SetScript(sc);
        }
        else
        {
            Limpiar();
            sc = "$('#block_buscar_item').css('display', 'block'); $('#block_digite_item').css('display', 'none'); $('#block_guardar').css('display', 'none'); $('#block_intercambio').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none'); $('#block_datos_fun').css('display', 'none');";
            SetScript(sc);
            tv_nivelOrg.Nodes.Clear();
            llenarArbolInicial();
        }
    }

    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        //string gestionFiltrar = obtenerGestion();
        if (txt_digite_item.Text != "")
        {
            if (aux_ca_num_item_actual.Value != txt_digite_item.Text)
            {
                int numItem = Convert.ToInt32(txt_digite_item.Text);
                cargo = new cls_mp_cargo();
                cargo.ca_num_item = numItem;
                cargo.gestion_selec = Session["pr_id"].ToString();
                var datosItem = cargo.ObtenerBusquedaItem();

                if (datosItem.Tables[0].Rows.Count > 0)
                {
                    if (datosItem.Tables[0].Rows[0]["ca_id"] != DBNull.Value && datosItem.Tables[0].Rows[0]["ca_id"].ToString().Trim() != "") { aux_ca_id.Value = datosItem.Tables[0].Rows[0]["ca_id"].ToString().Trim(); }
                    string haberBasicoItem = (datosItem.Tables[0].Rows[0]["ca_basico_calculado"] != DBNull.Value && datosItem.Tables[0].Rows[0]["ca_basico_calculado"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["ca_basico_calculado"].ToString().Trim() : "";
                    aux_ca_basico_calculado_nuevo.Value = haberBasicoItem;
                    decimal haberBasico2 = Convert.ToDecimal(haberBasicoItem);
                    haberBasico2 = Math.Round(haberBasico2, 2);
                    ltl_cargo_asig.Text = (datosItem.Tables[0].Rows[0]["es_descripcion"] != DBNull.Value && datosItem.Tables[0].Rows[0]["es_descripcion"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["es_descripcion"].ToString().Trim() : "";
                    ltl_hb_asig.Text = haberBasico2 + "";
                    string clase = (datosItem.Tables[0].Rows[0]["ns_clase"] != DBNull.Value && datosItem.Tables[0].Rows[0]["ns_clase"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["ns_clase"].ToString().Trim() : "";
                    string nSalarial = (datosItem.Tables[0].Rows[0]["ns_nivel"] != DBNull.Value && datosItem.Tables[0].Rows[0]["ns_nivel"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["ns_nivel"].ToString().Trim() : "";
                    ltl_cod_esc_asig.Text = (datosItem.Tables[0].Rows[0]["es_escalafon"] != DBNull.Value && datosItem.Tables[0].Rows[0]["es_escalafon"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["es_escalafon"].ToString().Trim() : "";
                    ltl_clase_asig.Text = clase;
                    ltl_nivel_salarial_asig.Text = nSalarial;

                    string nroItem = (datosItem.Tables[0].Rows[0]["ca_num_item"] != DBNull.Value && datosItem.Tables[0].Rows[0]["ca_num_item"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["ca_num_item"].ToString().Trim() : "";
                    ltl_item_asig.Text = (datosItem.Tables[0].Rows[0]["ca_ti_item"] != DBNull.Value && datosItem.Tables[0].Rows[0]["ca_ti_item"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["ca_ti_item"].ToString().Trim() + " - " + nroItem : "";
                    ltl_puesto_asig.Text = (datosItem.Tables[0].Rows[0]["pu_descripcion"] != DBNull.Value && datosItem.Tables[0].Rows[0]["pu_descripcion"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["pu_descripcion"].ToString().Trim() : "";
                    ltl_unidad_asig.Text = (datosItem.Tables[0].Rows[0]["eo_descripcion"] != DBNull.Value && datosItem.Tables[0].Rows[0]["eo_descripcion"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["eo_descripcion"].ToString().Trim() : "";
                    aux_ca_pr_id.Value = (datosItem.Tables[0].Rows[0]["ca_pr_id"] != DBNull.Value && datosItem.Tables[0].Rows[0]["ca_pr_id"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["ca_pr_id"].ToString().Trim() : "";
                    string paterno = (datosItem.Tables[0].Rows[0]["per_ap_paterno"] != DBNull.Value && datosItem.Tables[0].Rows[0]["per_ap_paterno"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["per_ap_paterno"].ToString().Trim() : "";
                    string materno = (datosItem.Tables[0].Rows[0]["per_ap_materno"] != DBNull.Value && datosItem.Tables[0].Rows[0]["per_ap_materno"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["per_ap_materno"].ToString().Trim() : "";
                    ltl_nombre_fun_inter.Text = (datosItem.Tables[0].Rows[0]["per_nombres"] != DBNull.Value && datosItem.Tables[0].Rows[0]["per_nombres"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["per_nombres"].ToString().Trim() + " " + paterno + " " + materno : "";
                    string exp = (datosItem.Tables[0].Rows[0]["cat_abreviacion"] != DBNull.Value && datosItem.Tables[0].Rows[0]["cat_abreviacion"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["cat_abreviacion"].ToString().Trim() : "";
                    ltl_ci_inter.Text = (datosItem.Tables[0].Rows[0]["per_num_doc"] != DBNull.Value && datosItem.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() + " " + exp : "";
                    ltl_cod_fun_inter.Text = (datosItem.Tables[0].Rows[0]["as_per_id"] != DBNull.Value && datosItem.Tables[0].Rows[0]["as_per_id"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["as_per_id"].ToString().Trim() : "";
                    aux_as_id_intercambio.Value = (datosItem.Tables[0].Rows[0]["as_id"] != DBNull.Value && datosItem.Tables[0].Rows[0]["as_id"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["as_id"].ToString().Trim() : "";

                    string estado_int = (datosItem.Tables[0].Rows[0]["as_estado"] != DBNull.Value && datosItem.Tables[0].Rows[0]["as_estado"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["as_estado"].ToString().Trim() : "";
                    if (estado_int == "V")
                    {
                        btn_estado_int.Text = "Vigente";
                        btn_estado_int.CssClass = "btn btn-sm btn-info float-right";
                    }
                    else
                    {
                        btn_estado_int.Text = "Acefalia";
                        btn_estado_int.CssClass = "btn btn-sm btn-secondary float-right";
                    }

                    string imagen_int = (datosItem.Tables[0].Rows[0]["fp_foto"] != DBNull.Value && datosItem.Tables[0].Rows[0]["fp_foto"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["fp_foto"].ToString().Trim() : "";
                    string sexo_int = (datosItem.Tables[0].Rows[0]["per_sexo"] != DBNull.Value && datosItem.Tables[0].Rows[0]["per_sexo"].ToString().Trim() != "") ? datosItem.Tables[0].Rows[0]["per_sexo"].ToString().Trim() : "";

                    if (imagen_int != "")
                    {
                        imgFun_int.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])datosItem.Tables[0].Rows[0]["fp_foto"]);
                    }
                    else
                    {
                        if (sexo_int == "")
                        {
                            imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
                        }
                        else
                        {
                            if (sexo_int == "M")
                            {
                                imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
                            }
                            else
                            {
                                imgFun_int.ImageUrl = "../Content/img/theme/user4.jpg";
                            }
                        }

                    }

                    if (datosItem.Tables[0].Rows[0]["per_num_doc"] != DBNull.Value && datosItem.Tables[0].Rows[0]["per_num_doc"].ToString().Trim() != "")
                    {
                        aux_verifica_acefalia.Value = "1";
                        sc = "$('#block_intercambio').css('display', 'block'); $('#block_datos_fun_inter').css('display', 'block'); $('#block_guardar').css('display', 'none');";
                        SetScript(sc);
                    }
                    else
                    {
                        aux_verifica_acefalia.Value = "0";
                        sc = "$('#block_intercambio').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none'); $('#block_guardar').css('display', 'block');";
                        SetScript(sc);
                    }

                    //COMBO AUTOMATICO
                    double ca_basico_calculado_nuevo = Convert.ToDouble(aux_ca_basico_calculado_nuevo.Value);
                    double ca_basico_calculado_actual = Convert.ToDouble(aux_ca_basico_calculado_actual.Value);

                    if (aux_verifica_acefalia.Value == "0")
                    {
                        if (ca_basico_calculado_nuevo == ca_basico_calculado_actual)
                        {
                            ddl_tipoMovimiento.SelectedValue = "2";
                        }
                        if (ca_basico_calculado_nuevo > ca_basico_calculado_actual)
                        {
                            ddl_tipoMovimiento.SelectedValue = "4";
                        }
                        if (ca_basico_calculado_nuevo < ca_basico_calculado_actual)
                        {
                            ddl_tipoMovimiento.SelectedValue = "5";
                        }
                    }
                    else
                    {
                        if (ca_basico_calculado_nuevo < ca_basico_calculado_actual)
                        {
                            ddl_tipoMovimiento.SelectedValue = "1";
                        }
                        if (ca_basico_calculado_nuevo == ca_basico_calculado_actual)
                        {
                            ddl_tipoMovimiento.SelectedValue = "2";
                        }
                        if (ca_basico_calculado_nuevo > ca_basico_calculado_actual)
                        {
                            ddl_tipoMovimiento.SelectedValue = "3";
                        }
                    }

                    sc = "$.notify({ icon: 'fa fa-check', message: 'Ítem seleccionado correctamente'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_datos_fun').css('display', 'block');";
                    SetScript(sc);
                    txt_digite_item.Text = string.Empty;
                }
                else
                {
                    Limpiar();
                    sc = "$.notify({ icon: 'fa fa-times', message: 'El número de ítem no es valido'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_intercambio').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none'); $('#block_guardar').css('display', 'none'); $('#block_datos_fun').css('display', 'none'); ";
                    SetScript(sc);
                }
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-times', message: 'El número de ítem no es valido'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_intercambio').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none'); $('#block_datos_fun').css('display', 'none');";
                SetScript(sc);
            }
            
        }
        else
        {
            Limpiar();
            sc = "$.notify({ icon: 'fa fa-times', message: 'Por favor inserte un número de ítem'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_intercambio').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none'); $('#block_datos_fun').css('display', 'none');";
            SetScript(sc);
        }
    }

    protected void btn_intercambio_Click(object sender, EventArgs e)
    {
        aux_valida_acefalo_inter.Value = "0";
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('show');";
        SetScript(sc);
    }

    private void AdicionarHistorico(string abm = "", string tabla = "", string nom_pk = "", string val_pk = "", string campos = "")
    {
        historico = new cls_historico
        {
            his_tipo_abm = abm,
            his_nom_tabla = tabla,
            his_nom_pk = nom_pk,
            his_valor_pk = val_pk,
            his_campos = campos,
            his_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString())
        };
        historico.Adicionar();
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        string id = Request.QueryString["id"].ToString();
        if (aux_valida_acefalo_inter.Value == "1")
        {
            cargo = new cls_mp_cargo();

            double ca_basico_calculado_nuevo = Convert.ToDouble(aux_ca_basico_calculado_nuevo.Value);
            double ca_basico_calculado_actual = Convert.ToDouble(aux_ca_basico_calculado_actual.Value);
            switch (ddl_tipoMovimiento.SelectedValue)
            {
                case "1":

                    break;
                case "2":
                    if (ca_basico_calculado_nuevo == ca_basico_calculado_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "2";
                        int as_id_actual = Convert.ToInt32(aux_as_id_actual.Value);
                        cargo.as_id_actual = as_id_actual;
                        string fechaBaja = ltl_fecha_baja.Text;
                        string hora = DateTime.Now.ToString("HH:mm:ss");
                        cargo.as_fecha_fin_actual = fechaBaja + " " + hora;
                        procesarHistorico(as_id_actual);
                        if (cargo.ActualizarAsignacion())
                        {
                            GuardarAsignacionNueva();
                            guardarGlosaAsignacion(as_id_actual, "as_id", "tbl_mp_asignacion");
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-check', message: 'Ocurrio un error al cambiar la asignación'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                            SetScript(sc);
                        }
                        cargo.ca_id_actual = Convert.ToInt32(aux_ca_id_actual.Value);
                        cargo.ca_estado_actual = "L";
                        if (cargo.ActualizarCargoActual())
                        {
                            cargo.ca_id = Convert.ToInt32(aux_ca_id.Value);
                            cargo.ca_estado = "O";
                            if (!cargo.ActualizarCargoNuevo())
                            {
                                sc = "$.notify({ icon: 'fa fa-check', message: 'Ocurrio un error al cambiar de cargo'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                                SetScript(sc);
                            }
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-check', message: 'Ocurrio un error al cambiar de cargo'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                            SetScript(sc);
                        }
                        tv_nivelOrg.Nodes.Clear();
                        Limpiar();
                        informacionFuncionario(id);
                        llenarArbolInicial();
                        sc = "$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_datos_fun').css('display', 'none');  ";
                        SetScript(sc);
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-check', message: 'El ítem seleccionado debe ser igual a su escala'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });  $('#EditarItem').modal('hide');  $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
                        SetScript(sc);
                    }
                    break;
                case "3":

                    break;
                case "4":
                    if (ca_basico_calculado_nuevo > ca_basico_calculado_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "4";
                        int as_id_actual = Convert.ToInt32(aux_as_id_actual.Value);
                        cargo.as_id_actual = as_id_actual;
                        string fechaBaja = ltl_fecha_baja.Text;
                        string hora = DateTime.Now.ToString("HH:mm:ss");
                        cargo.as_fecha_fin_actual = fechaBaja + " " + hora;
                        procesarHistorico(as_id_actual);
                        if (cargo.ActualizarAsignacion())
                        {
                            GuardarAsignacionNueva();
                            guardarGlosaAsignacion(as_id_actual, "as_id", "tbl_mp_asignacion");
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-check', message: 'Ocurrio un error al cambiar la asignación'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                            SetScript(sc);
                        }
                        cargo.ca_id_actual = Convert.ToInt32(aux_ca_id_actual.Value);
                        cargo.ca_estado_actual = "L";
                        if (cargo.ActualizarCargoActual())
                        {
                            cargo.ca_id = Convert.ToInt32(aux_ca_id.Value);
                            cargo.ca_estado = "O";
                            if (!cargo.ActualizarCargoNuevo())
                            {
                                sc = "$.notify({ icon: 'fa fa-check', message: 'Ocurrio un error al cambiar de cargo'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                                SetScript(sc);
                            }
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-check', message: 'Ocurrio un error al cambiar de cargo'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                            SetScript(sc);
                        }
                        tv_nivelOrg.Nodes.Clear();
                        Limpiar();

                        informacionFuncionario(id);
                        llenarArbolInicial();
                        sc = "$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_datos_fun').css('display', 'none');  ";
                        SetScript(sc);
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-check', message: 'El ítem seleccionado debe ser mayor a su escala'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });  $('#EditarItem').modal('hide');  $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
                        SetScript(sc);
                    }
                    break;
                case "5":
                    if (ca_basico_calculado_nuevo < ca_basico_calculado_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "5";
                        int as_id_actual = Convert.ToInt32(aux_as_id_actual.Value);
                        cargo.as_id_actual = as_id_actual;
                        string fechaBaja = ltl_fecha_baja.Text;
                        string hora = DateTime.Now.ToString("HH:mm:ss");
                        cargo.as_fecha_fin_actual = fechaBaja + " " + hora;
                        procesarHistorico(as_id_actual);
                        if (cargo.ActualizarAsignacion())
                        {
                            GuardarAsignacionNueva();
                            guardarGlosaAsignacion(as_id_actual, "as_id", "tbl_mp_asignacion");
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-check', message: 'Ocurrio un error al cambiar la asignación'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                            SetScript(sc);
                        }
                        cargo.ca_id_actual = Convert.ToInt32(aux_ca_id_actual.Value);
                        cargo.ca_estado_actual = "L";
                        if (cargo.ActualizarCargoActual())
                        {
                            cargo.ca_id = Convert.ToInt32(aux_ca_id.Value);
                            cargo.ca_estado = "O";
                            if (!cargo.ActualizarCargoNuevo())
                            {
                                sc = "$.notify({ icon: 'fa fa-check', message: 'Ocurrio un error al cambiar de cargo'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                                SetScript(sc);
                            }
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-check', message: 'Ocurrio un error al cambiar de cargo'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                            SetScript(sc);
                        }
                        tv_nivelOrg.Nodes.Clear();
                        Limpiar();
                        informacionFuncionario(id);
                        llenarArbolInicial();
                        sc = "$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_datos_fun').css('display', 'none');  ";
                        SetScript(sc);
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-check', message: 'El ítem seleccionado debe ser menor a su escala'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });  $('#EditarItem').modal('hide');  $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
                        SetScript(sc);
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            if (aux_as_id_actual.Value != null && aux_as_id_actual.Value != "" && aux_as_id_intercambio.Value != null && aux_as_id_intercambio.Value != "")
            {
                cargo = new cls_mp_cargo();
                int as_id_actual = Convert.ToInt32(aux_as_id_actual.Value);
                cargo.as_id_actual = as_id_actual;
                var as_fun_actual = cargo.ObtenerAsignacionX();
                int as_id_intercambio = Convert.ToInt32(aux_as_id_intercambio.Value);
                cargo.as_id_actual = as_id_intercambio;
                var as_fun_intercambio = cargo.ObtenerAsignacionX();
                int per_id_actual = (as_fun_actual.Tables[0].Rows[0]["as_per_id"] != DBNull.Value && as_fun_actual.Tables[0].Rows[0]["as_per_id"].ToString().Trim() != "") ? Convert.ToInt32(as_fun_actual.Tables[0].Rows[0]["as_per_id"].ToString().Trim()) : 0;
                int per_id_intercambio = (as_fun_intercambio.Tables[0].Rows[0]["as_per_id"] != DBNull.Value && as_fun_intercambio.Tables[0].Rows[0]["as_per_id"].ToString().Trim() != "") ? Convert.ToInt32(as_fun_intercambio.Tables[0].Rows[0]["as_per_id"].ToString().Trim()) : 0;
                aux_per_id.Value = Convert.ToString(per_id_actual);
                aux_ca_id.Value = (as_fun_intercambio.Tables[0].Rows[0]["as_ca_id"] != DBNull.Value && as_fun_intercambio.Tables[0].Rows[0]["as_ca_id"].ToString().Trim() != "") ? as_fun_intercambio.Tables[0].Rows[0]["as_ca_id"].ToString().Trim() : "";

                procesarHistorico(as_id_actual);
                procesarHistorico(as_id_intercambio);

                actualizarAsignacionX(as_id_actual);
                actualizarAsignacionX(as_id_intercambio);
                GuardarAsignacionIntercambio(as_fun_actual, per_id_intercambio);
                GuardarAsignacionIntercambio(as_fun_intercambio, per_id_actual);
                guardarGlosaAsignacion(as_id_actual, "as_id", "tbl_mp_asignacion");
                Limpiar();
                informacionFuncionario(id);
                tv_nivelOrg.Nodes.Clear();
                llenarArbolInicial();
                sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Asignación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_guardar').css('display', 'none'); $('#block_intercambio').css('display', 'none'); $('#block_datos_fun').css('display', 'none');  $('#block_datos_fun_inter').css('display', 'none'); $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-times', message: 'Ocurrio un error'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });  $('#EditarItem').modal('hide');  $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
                SetScript(sc);
            }
        }
        txt_fechaAsig.Text = string.Empty;
    }

    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('hide');";
        SetScript(sc);
    }

    protected void ddl_tipo_documento_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_num_doc.Text = "";
        d_num_doc.Visible = false;
        d_tipo_doc.Attributes.Add("class", "col-md-6");
        d_fecha_doc.Attributes.Add("class", "col-md-6");

        switch (ddl_tipo_documento.SelectedValue)
        {
            case "818":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control");
                break;

            case "816":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control numero");
                break;
            case "819":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control");
                break;
            case "821":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control");
                break;
            default:
                break;
        }
        SetScript("");
    }

    private void restablecerGlosa()
    {
        ddl_tipo_documento.SelectedValue = "0";
        txt_num_doc.Text = "";
        txt_fechaMov.Text = "";
        txt_descripcion_add.Text = "";
        d_num_doc.Visible = false;
        d_tipo_doc.Attributes.Add("class", "col-md-6");
        d_fecha_doc.Attributes.Add("class", "col-md-6");
    }

    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }
    private void CargarAsignaciones(int per_id)
    {
        cls_cp_sanciones sanciones = new cls_cp_sanciones();
        ddl_asignacion.Items.Clear();
        ddl_asignacion.DataSource = sanciones.ListarAsignacionesParaSancion(Convert.ToInt32(per_id));
        ddl_asignacion.DataTextField = "cargo_compuesto";
        ddl_asignacion.DataValueField = "as_ca_id";
        ddl_asignacion.DataBind();
    }
    protected void ddl_asignacion_edit_SelectedIndexChanged(object sender, EventArgs e)
    {
        string codFun = Request.QueryString["id"].ToString();
        informacionFuncionario(codFun);
    }
}