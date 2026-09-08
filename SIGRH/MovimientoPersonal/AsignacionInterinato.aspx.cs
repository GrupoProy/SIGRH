using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
public partial class MovimientoPersonal_AsignacionInterinato : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_mp_asignacion_com_int asignacion_interinato = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa glosa = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            llenarArbolInicial();
            string codFun = Request.QueryString["id"].ToString();
            informacionFuncionario(codFun);
            listaFiltradoTipoDoc();

            obtenerListaFiltradoTipoAsig();
            ddl_tipoMovimiento.Enabled = false;

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

            int[] ids = { 816, 818, 819, 821 };

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

    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('hide');";
        SetScript(sc);
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
    private string obtenerGestion()
    {
        cargo = new cls_mp_cargo();
        string anio = DateTime.Now.ToString("yyyy");
        //cargo.gestion = anio;
        cargo.gestion = "2019";
        var gestionActual = cargo.ObtenerGestion();

        string gestionFiltrar = "";
        if (gestionActual.Tables[0].Rows[0]["pr_id"] != DBNull.Value && gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim() != "")
        {
            gestionFiltrar = gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim();
        }
        return gestionFiltrar;
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
        sc = "$('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_guardar').css('display', 'none');";
        SetScript(sc);
    }

    protected void Limpiar()
    {
        txt_descripcion_add.Text = string.Empty;
        ddl_tipo_documento.SelectedValue = "0";
        //txt_cargo_asig.Text = string.Empty;
        //txt_nivel_asig.Text = string.Empty;
        //txt_item_asig.Text = string.Empty;
        //txt_unidadOrg_asig.Text = string.Empty;
        txt_digite_item.Text = string.Empty;
        //ddl_tipoMovimiento.SelectedValue = "0";
        //ddl_tipo_asig.SelectedValue = "0";
        aux_validar_item.Value = string.Empty;
    }
    protected void tv_nivelOrg_SelectedNodeChanged(object sender, EventArgs e)
    {
        int eo_id = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);
        //string gestionFiltrar = obtenerGestion();
        cargo = new cls_mp_cargo();
        cargo.ep_cod_estp = eo_id;
        cargo.eo_id = eo_id;
        cargo.gestion_selec = Session["pr_id"].ToString(); ;
        var nivelOrg = cargo.ObtenerNivelOrganizacional();
        var nivelOrgItems = cargo.ObtenerNivelOrganizacionalItemsMasAcefalia();
        var detalleItem = cargo.ObtenerDetalleItemEjecutivo();

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
        }
        else
        {
            aux_validar_item.Value = "0";
        }

        tv_nivelOrg.SelectedNode.Expand();
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

    private void obtenerListaFiltradoTipoAsig()
    {
        try
        {
            cargo = new cls_mp_cargo();

            ddl_tipo_asig.Items.Clear();
            ddl_tipo_asig.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_asig.DataValueField = "id_cat";
            ddl_tipo_asig.DataTextField = "cat_descripcion";
            ddl_tipo_asig.DataSource = cargo.obtenerFiltradoTipoAsignacion();
            ddl_tipo_asig.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void obtenerListaFiltradoTipoMov(string id_cat)
    {
        try
        {
            cargo = new cls_mp_cargo();
            cargo.p_cat_id_superior = Convert.ToInt32(id_cat);

            ddl_tipoMovimiento.Items.Clear();
            ddl_tipoMovimiento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipoMovimiento.DataValueField = "cat_abreviacion";
            ddl_tipoMovimiento.DataTextField = "cat_descripcion";
            ddl_tipoMovimiento.DataSource = cargo.obtenerFiltradoTipoMovInterinato();
            ddl_tipoMovimiento.DataBind();
            ddl_tipoMovimiento.Enabled = true;
            SetScript("");
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_seleccionar_item_Click(object sender, EventArgs e)
    {
        string id_cat = (ddl_tipo_asig.SelectedValue);
        string[] words = id_cat.Split('-');
        string id_tipo_asig = words[1];

        if (id_tipo_asig == "I")
        {
            if (aux_validar_item.Value == "1")
            {
                aux_validar_item.Value = string.Empty;
                llenarCamposInterinato();
                sc = "$.notify({ icon: 'fa fa-check', message: 'Ítem seleccionado correctamente'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); $('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_guardar').css('display', 'block'); $('#block_datos_fun').css('display', 'block'); ";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-info', message: 'Debe seleccionar un ítem'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_fun').css('display', 'none');";
                SetScript(sc);
            }
        }
        else
        {
            if (aux_validar_item.Value == "0")
            {
                aux_validar_item.Value = string.Empty;
                llenarCampos();
                sc = "$.notify({ icon: 'fa fa-check', message: 'Unidad Organizacional correctamente'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); $('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_guardar').css('display', 'block'); $('#block_datos_fun').css('display', 'block');";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-info', message: 'Debe seleccionar una Unidad Organizacional'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_fun').css('display', 'none');";
                SetScript(sc);
            }
        }
    }
    protected void llenarCamposInterinato()
    {
        int eo_id = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);
        cargo = new cls_mp_cargo();
        cargo.ep_cod_estp = eo_id;
        cargo.gestion_selec = Session["pr_id"].ToString(); 
        var detalleItem = cargo.ObtenerDetalleItemEjecutivo();

        if (detalleItem.Tables[0].Rows.Count > 0)
        {
            var detalle_item_x = detalleItem.Tables[0].Rows[0];
            string ci_asig_int = validarCampo(detalle_item_x["per_num_doc"]);
            ci_asig_int = ci_asig_int + " " + validarCampo(detalle_item_x["cat_abreviacion"]);

            if (ci_asig_int != "")
            {
                if (detalle_item_x["es_descripcion"] != DBNull.Value && detalle_item_x["es_descripcion"].ToString().Trim() != "")
                {
                    string haberBasicoItem = validarCampo(detalle_item_x["haber_basico"]);
                    aux_ca_basico_calculado_nuevo.Value = haberBasicoItem;
                    decimal haberBasico2 = Convert.ToDecimal(haberBasicoItem);
                    haberBasico2 = Math.Round(haberBasico2, 2);
                    ltl_cargo_asig.Text = validarCampo(detalle_item_x["es_descripcion"]);
                    ltl_hb_asig.Text = haberBasico2 + "";

                }
                ltl_unidad_asig.Text = validarCampo(detalle_item_x["eo_descripcion"]);
                if (validarCampo(detalle_item_x["es_escalafon"]) != "")
                {
                    string clase = validarCampo(detalle_item_x["ns_clase"]);
                    string nSalarial = validarCampo(detalle_item_x["ns_nivel"]);
                    ltl_cod_esc_asig.Text = detalle_item_x["es_escalafon"].ToString().Trim();
                    ltl_clase_asig.Text = clase;
                    ltl_nivel_salarial_asig.Text = nSalarial;

                }
                if (detalle_item_x["ca_ti_item"] != DBNull.Value && detalle_item_x["ca_ti_item"].ToString().Trim() != "")
                {
                    string nroItem = validarCampo(detalle_item_x["ca_num_item"]);
                    ltl_item_asig.Text = validarCampo(detalle_item_x["ca_ti_item"]);
                }
                string apellidos_asig_int = validarCampo(detalle_item_x["per_ap_paterno"]);
                apellidos_asig_int = apellidos_asig_int + " " + validarCampo(detalle_item_x["per_ap_materno"]);
                string nom_asig_int = validarCampo(detalle_item_x["per_nombres"]);
                string cod_fun_int = validarCampo(detalle_item_x["per_id"]);
                ltl_nombre_fun_inter.Text = nom_asig_int + " " + apellidos_asig_int;
                ltl_ci_inter.Text = ci_asig_int;
                ltl_cod_fun_inter.Text = cod_fun_int;

                sc = "$('#block_datos_fun_inter').css('display', 'block');  $('#block_guardar').css('display', 'block'); $('#block_datos_fun').css('display', 'block');";
                SetScript(sc);
                //VARIABLES PARA CARGO NUEVO
                aux_ca_id.Value = validarCampo(detalle_item_x["ca_id"]);
                aux_ca_es_id.Value = validarCampo(detalle_item_x["ca_es_id"]);
                aux_ca_eo_id.Value = validarCampo(detalle_item_x["ca_eo_id"]);
                aux_ca_ti_item.Value = validarCampo(detalle_item_x["ca_ti_item"]);
                aux_ca_num_item.Value = validarCampo(detalle_item_x["ca_num_item"]);
                aux_ca_aplica_incremento.Value = validarCampo(detalle_item_x["ca_aplica_incremento"]);
                aux_ca_tipo_jornada.Value = validarCampo(detalle_item_x["ca_tipo_jornada"]);
                aux_ca_basico_calculado.Value = validarCampo(detalle_item_x["ca_basico_calculado"]);
                aux_ca_tipo_calculo.Value = validarCampo(detalle_item_x["ca_tipo_calculo"]);
                aux_ca_pr_id.Value = validarCampo(detalle_item_x["ca_pr_id"]);
                aux_per_id_ci.Value = validarCampo(detalle_item_x["per_id"]);
            }
            else
            {
                if (validarCampo(detalle_item_x["es_descripcion"]) != "")
                {
                    string haberBasicoItem = validarCampo(detalle_item_x["haber_basico"]);
                    aux_ca_basico_calculado_nuevo.Value = haberBasicoItem;
                    decimal haberBasico2 = Convert.ToDecimal(haberBasicoItem);
                    haberBasico2 = Math.Round(haberBasico2, 2);
                    ltl_cargo_asig.Text = validarCampo(detalle_item_x["es_descripcion"]);
                    ltl_hb_asig.Text = haberBasico2 + "";
                }
                ltl_unidad_asig.Text = validarCampo(detalle_item_x["eo_descripcion"]);
                if (validarCampo(detalle_item_x["es_escalafon"]) != "")
                {
                    string clase = validarCampo(detalle_item_x["ns_clase"]);
                    string nSalarial = validarCampo(detalle_item_x["ns_nivel"]);
                    ltl_cod_esc_asig.Text = validarCampo(detalle_item_x["es_escalafon"]);
                    ltl_clase_asig.Text = clase;
                    ltl_nivel_salarial_asig.Text = nSalarial;

                }
                if (validarCampo(detalle_item_x["ca_ti_item"]) != "")
                {
                    string nroItem = validarCampo(detalle_item_x["ca_num_item"]);
                    ltl_item_asig.Text = validarCampo(detalle_item_x["ca_ti_item"]) + " - " + nroItem;
                }
                aux_per_id_ci.Value = string.Empty;
                sc = " $('#block_guardar').css('display', 'block'); $('#block_datos_fun').css('display', 'block');";
                SetScript(sc);

                //VARIABLES PARA CARGO NUEVO
                aux_ca_id.Value = validarCampo(detalle_item_x["ca_id"]);
                aux_ca_es_id.Value = validarCampo(detalle_item_x["ca_es_id"]);
                aux_ca_eo_id.Value = validarCampo(detalle_item_x["ca_eo_id"]);
                aux_ca_ti_item.Value = validarCampo(detalle_item_x["ca_ti_item"]);
                aux_ca_num_item.Value = validarCampo(detalle_item_x["ca_num_item"]);
                aux_ca_aplica_incremento.Value = validarCampo(detalle_item_x["ca_aplica_incremento"]);
                aux_ca_tipo_jornada.Value = validarCampo(detalle_item_x["ca_tipo_jornada"]);
                aux_ca_basico_calculado.Value = validarCampo(detalle_item_x["ca_basico_calculado"]);
                aux_ca_tipo_calculo.Value = validarCampo(detalle_item_x["ca_tipo_calculo"]);
                aux_ca_pr_id.Value = validarCampo(detalle_item_x["ca_pr_id"]);
                aux_per_id_ci.Value = validarCampo(detalle_item_x["per_id"]);
            }
            string estado_int = validarCampo(detalle_item_x["as_estado"]);
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
            string imagen_int = validarCampo(detalle_item_x["fp_foto"]);
            string sexo_int = validarCampo(detalle_item_x["per_sexo"]);

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
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-times', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_guardar').css('display', 'none'); $('#block_datos_fun').css('display', 'none');";
            SetScript(sc);
        }
    }
    protected void llenarCampos()
    {
        //txt_cargo_asig.Text = txt_cargo.Text;
        //txt_nivel_asig.Text = txt_nivel.Text;
        //txt_item_asig.Text = txt_item.Text;
        ltl_cargo_asig.Text = ltl_cargo.Text;
        ltl_hb_asig.Text = ltl_hb.Text;
        ltl_cod_esc_asig.Text = ltl_cod_esc.Text;
        ltl_clase_asig.Text = ltl_clase.Text;
        ltl_nivel_salarial_asig.Text = ltl_nivel_salarial.Text;
        ltl_item_asig.Text = ltl_item.Text;

        cargo = new cls_mp_cargo();
        int uo_selec = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);
        cargo.eo_id = uo_selec;
        var uo = cargo.obtenerNombreUO();
        ltl_unidad_asig.Text = uo.Tables[0].Rows[0]["eo_descripcion"].ToString();
        aux_ca_eo_id.Value = uo.Tables[0].Rows[0]["eo_id"].ToString();
        sc = "$('#block_datos_fun_inter').css('display', 'none');";
    }
    private void informacionFuncionario(string id = "")
    {
        string fu_num_ident = id;
        //string gestion_selec = obtenerGestion();
        cargo.fu_num_ident = fu_num_ident;
        cargo.gestion_selec = Session["pr_id"].ToString(); ;
        cargo.obtenerDatosFuncionario(id);
        string haberBasico = cargo.haber_basico.ToString().Trim();
        decimal haberBasico2 = Convert.ToDecimal(haberBasico);
        haberBasico2 = Math.Round(haberBasico2, 2);
        aux_per_id.Value = cargo.as_per_id.ToString().Trim();


        ltl_cargo.Text = cargo.es_descripcion.ToString().Trim();
        ltl_hb.Text = haberBasico2 + "";
        ltl_item.Text = cargo.ca_ti_item_actual.ToString().Trim() + " - " + cargo.ca_num_item_actual.ToString().Trim();
        ltl_cod_esc.Text = cargo.es_escalafon.ToString().Trim();
        ltl_clase.Text = cargo.ns_clase.ToString().Trim();
        ltl_nivel_salarial.Text = cargo.ns_nivel.ToString().Trim();
        ltl_ubicacion.Text = cargo.ep_descripcion.ToString().Trim();
        ltl_fecha_asig.Text = cargo.as_fecha_asignacion.ToString().Trim();
        ltl_fecha_baja.Text = cargo.as_fecha_baja.ToString().Trim();

        aux_ca_id_actual.Value = cargo.ca_id_actual.ToString().Trim();
        aux_ca_es_id_actual.Value = cargo.ca_es_id_actual.ToString().Trim();
        aux_ca_eo_id_actual.Value = cargo.ca_eo_id_actual.ToString().Trim();
        aux_ca_ti_item_actual.Value = cargo.ca_ti_item_actual.ToString().Trim();
        aux_ti_item_gral.Value = cargo.tipo_item;
        aux_ca_num_item_actual.Value = cargo.ca_num_item_actual.ToString().Trim();
        aux_ca_aplica_incremento_actual.Value = cargo.ca_aplica_incremento_actual.ToString().Trim();
        aux_ca_tipo_jornada_actual.Value = cargo.ca_tipo_jornada_actual.ToString().Trim();
        aux_ca_basico_calculado_actual.Value = cargo.ca_basico_calculado_actual.ToString().Trim();
        aux_ca_tipo_calculo_actual.Value = cargo.ca_tipo_calculo_actual.ToString().Trim();
        aux_ca_pr_id_actual.Value = cargo.ca_pr_id_actual;
        aux_as_id_actual.Value = cargo.as_id_actual.ToString().Trim();

        //encabezado nuevo
        string fu_nombres = (cargo.fu_nombres != null) ? cargo.fu_nombres.ToString().Trim() : "";
        string fu_paterno = (cargo.fu_paterno != null) ? cargo.fu_paterno.ToString().Trim() : "";
        string fu_materno = (cargo.fu_materno != null) ? cargo.fu_materno.ToString().Trim() : "";
        ltl_nombre_fun.Text = fu_nombres + " " + fu_paterno + " " + fu_materno;
        ltl_ci.Text = cargo.fu_num_ident.ToString() + " " + cargo.fu_tipo_ident.ToString().Trim();
        ltl_cod_fun.Text = cargo.as_per_id.ToString();

        if (cargo.as_estado == "V")
        {
            btn_estado.Text = "Vigente";
            btn_estado.CssClass = "btn btn-sm btn-info float-right";
        }
        else
        {
            btn_estado.Text = "Pasivo";
            btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
        }
        if (cargo.imagen != null && cargo.imagen != "")
        {
            imgFun.ImageUrl = cargo.imagen;
        }
        else
        {
            if (cargo.fu_sexo == "M")
            {
                imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
            }
            else
            {
                imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
            }
        }
    }

    protected void btn_guardar_item_Click(object sender, EventArgs e)
    {
        DateTime startDate = Convert.ToDateTime(txt_fechaAsig.Text);
        DateTime endDate = Convert.ToDateTime(txt_fechaBajaAsig.Text);
        double diferencia = (endDate - startDate).TotalDays + 1;
        if (diferencia > 0)
        {
            string anio = DateTime.Now.ToString("yyyy");
            string anio_startDate = startDate.ToString("yyyy");
            string anio_endDate = endDate.ToString("yyyy");

            if (anio_startDate == anio && anio_endDate == anio)
            {
                string id_cat = (ddl_tipo_asig.SelectedValue);
                string[] words = id_cat.Split('-');
                string id_abrev = words[1];

                if (id_abrev == "C")
                {
                    if (diferencia > 90)
                    {
                        //sc = "$.notify({ icon: 'ni ni-settings-gear-65', message: 'Advertencia: La comisión sobrepaso los 90 días.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                        sc = "Swal.fire({icon: 'info', title: 'La comisión sobrepasa los 90 días', showConfirmButton: true, allowOutsideClick: false});";
                        SetScript(sc);
                    }
                }
                if (id_abrev == "I" && aux_ti_item_gral.Value == "C")
                {
                    sc = "Swal.fire({icon: 'info', title: 'El funcionario es de contrato debe presentar informe legal.', showConfirmButton: true, allowOutsideClick: false});";
                    SetScript(sc);
                }
                sc = "$('#modalGlosa').modal('show');";
                SetScript(sc);
            }
            else
            {
                //sc = "$.notify({ icon: 'ni ni-settings-gear-65', message: 'El rango de fechas debe ser de la gestión actual.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
                string msg = "La Comisión/Interinato será asignado en la gestión " + anio_startDate + " - " + anio_endDate;
                msg = (aux_ti_item_gral.Value == "C") ? msg + " , el funcionario es de contrato debe presentar informe legal" : msg;
                sc = "Swal.fire({icon: 'info', title: '" + msg + "', showConfirmButton: true, allowOutsideClick: false}); $('#modalGlosa').modal('show');";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'ni ni-settings-gear-65', message: 'El rango de fechas ingresado no es válido.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

        //sc = "$('#modalGlosa').modal('show');";
        //SetScript(sc);
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        sc = " $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
        SetScript(sc);
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        cargo = new cls_mp_cargo();

        string id_cat = (ddl_tipo_asig.SelectedValue);
        string[] words = id_cat.Split('-');
        string id_abrev = words[1];

        string per_id = Request.QueryString["id"].ToString();

        asignacion_interinato = new cls_mp_asignacion_com_int();

        if (id_abrev == "I")
        {
            if (aux_per_id_ci.Value != "")
            {
                asignacion_interinato.ci_per_id = Convert.ToInt32(per_id);
                asignacion_interinato.ci_ca_id = Convert.ToInt32(aux_ca_id.Value);
                asignacion_interinato.ci_fecha_inicio = txt_fechaAsig.Text + " 00:00:00.000";
                asignacion_interinato.ci_fecha_fin = txt_fechaBajaAsig.Text + " 00:00:00.000";
                asignacion_interinato.ci_estado = "V";
                asignacion_interinato.ci_tipo_mov = ddl_tipoMovimiento.SelectedValue;
                asignacion_interinato.ci_tipo_reg = id_abrev;
                asignacion_interinato.ci_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
                asignacion_interinato.ci_tipo_mov_baja = null;
                asignacion_interinato.ci_ca_id_ant = Convert.ToInt32(aux_ca_id_actual.Value);
                asignacion_interinato.ci_ca_id_n = Convert.ToInt32(aux_ca_id.Value);
                asignacion_interinato.ci_es_id_n = Convert.ToInt32(aux_ca_es_id.Value);
                asignacion_interinato.ci_eo_id_n = Convert.ToInt32(aux_ca_eo_id.Value);
                asignacion_interinato.ci_per_id_interinato = Convert.ToInt32(aux_per_id_ci.Value);
                asignacion_interinato.ci_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());
                asignacion_interinato.Adicionar();

                int idAsignacion = obtenerIdAsignacion();
                guardarGlosa(idAsignacion, "ci_id", "tbl_mp_asignacion_com_int");
                Session["texto_notificacion"] = "¡Asignación Exitosa!";
                Response.Redirect("BuscadorFuncionario");
            }
            else
            {
                asignacion_interinato.ci_per_id = Convert.ToInt32(per_id);
                asignacion_interinato.ci_ca_id = Convert.ToInt32(aux_ca_id.Value);
                asignacion_interinato.ci_fecha_inicio = txt_fechaAsig.Text + " 00:00:00.000";
                asignacion_interinato.ci_fecha_fin = txt_fechaBajaAsig.Text + " 00:00:00.000";
                asignacion_interinato.ci_estado = "V";
                asignacion_interinato.ci_tipo_mov = ddl_tipoMovimiento.SelectedValue;
                asignacion_interinato.ci_tipo_reg = id_abrev;
                asignacion_interinato.ci_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
                asignacion_interinato.ci_tipo_mov_baja = null;
                asignacion_interinato.ci_ca_id_ant = Convert.ToInt32(aux_ca_id_actual.Value);
                asignacion_interinato.ci_ca_id_n = Convert.ToInt32(aux_ca_id.Value);
                asignacion_interinato.ci_es_id_n = Convert.ToInt32(aux_ca_es_id.Value);
                asignacion_interinato.ci_eo_id_n = Convert.ToInt32(aux_ca_eo_id.Value);
                asignacion_interinato.ci_per_id_interinato = 0;
                asignacion_interinato.ci_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());
                asignacion_interinato.Adicionar();

                int idAsignacion = obtenerIdAsignacion();
                guardarGlosa(idAsignacion, "ci_id", "tbl_mp_asignacion_com_int");
                Session["texto_notificacion"] = "¡Asignación Exitosa!";
                Response.Redirect("BuscadorFuncionario");
            }
        }
        else
        {
            asignacion_interinato.ci_per_id = Convert.ToInt32(per_id);
            asignacion_interinato.ci_ca_id = Convert.ToInt32(aux_ca_id_actual.Value);
            asignacion_interinato.ci_fecha_inicio = txt_fechaAsig.Text + " 00:00:00.000";
            asignacion_interinato.ci_fecha_fin = txt_fechaBajaAsig.Text + " 00:00:00.000";
            asignacion_interinato.ci_estado = "V";
            asignacion_interinato.ci_tipo_mov = ddl_tipoMovimiento.SelectedValue;
            asignacion_interinato.ci_tipo_reg = id_abrev;
            asignacion_interinato.ci_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            asignacion_interinato.ci_tipo_mov_baja = null;
            asignacion_interinato.ci_ca_id_ant = Convert.ToInt32(aux_ca_id_actual.Value);
            asignacion_interinato.ci_ca_id_n = 0;
            asignacion_interinato.ci_es_id_n = Convert.ToInt32(aux_ca_es_id_actual.Value);
            asignacion_interinato.ci_eo_id_n = Convert.ToInt32(aux_ca_eo_id.Value);
            asignacion_interinato.ci_per_id_interinato = 0;
            asignacion_interinato.ci_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());
            asignacion_interinato.Adicionar();

            int idAsignacion = obtenerIdAsignacion();
            guardarGlosa(idAsignacion, "ci_id", "tbl_mp_asignacion_com_int");
            Session["texto_notificacion"] = "¡Asignación Exitosa!";
            Response.Redirect("BuscadorFuncionario");
        }

    }
    private void GuardarAsignacionNueva()
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        cargo.as_per_id = Convert.ToInt32(aux_per_id.Value);
        cargo.as_ca_id = Convert.ToInt32(aux_ca_id.Value);
        cargo.as_fecha_inicio = txt_fechaAsig.Text.ToString().Trim() + " " + hora;
        cargo.as_fecha_fin = "";
        cargo.as_estado = "V";
        cargo.as_tipo_reg = aux_cat_abreviacion.Value;
        cargo.as_tipo_mov = ddl_tipoMovimiento.SelectedValue;
        cargo.as_tipo_baja = null;
        cargo.AdicionarPromocion();
        sc = "$.notify({ icon: 'fa fa-check', message: 'Asignación exitosa'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_guardar').css('display', 'none');";
        SetScript(sc);
    }
    private void guardarGlosa(int gl_valor_pk = 0, string gl_nombre_pk = "", string gl_tabla = "")
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
        string id_cat = (ddl_tipo_asig.SelectedValue);
        string[] words = id_cat.Split('-');
        string id_abrev = words[1];

        string per_id = Request.QueryString["id"].ToString();
        asignacion_interinato = new cls_mp_asignacion_com_int();
        asignacion_interinato.ci_per_id = Convert.ToInt32(per_id);
        asignacion_interinato.ci_ca_id = (id_abrev == "I") ? Convert.ToInt32(aux_ca_id.Value) : Convert.ToInt32(aux_ca_id_actual.Value);
        var asignacion = asignacion_interinato.ObtenerRegistro();

        int idAsignacionNuevo = 0;
        if (asignacion.Tables[0].Rows[0]["ci_id"] != DBNull.Value && asignacion.Tables[0].Rows[0]["ci_id"].ToString().Trim() != "")
        {
            idAsignacionNuevo = Convert.ToInt32(asignacion.Tables[0].Rows[0]["ci_id"]);
        }
        return idAsignacionNuevo;
    }

    protected void ddl_tipo_asig_SelectedIndexChanged(object sender, EventArgs e)
    {
        string id_cat = (ddl_tipo_asig.SelectedValue);
        string[] words = id_cat.Split('-');
        string id_tipo_mov = words[0];
        string id_abrev = words[1];

        obtenerListaFiltradoTipoMov(id_tipo_mov);
        if (id_abrev == "I")
        {
            sc = "$('#block_datos_int').css('display', 'block'); $('#block_datos_fun').css('display', 'none'); $('#block_tiene_item').css('display', 'block'); $('#block_digite_item').css('display', 'none'); $('#block_guardar').css('display', 'none');";
            SetScript(sc);
        }
        else
        {
            imgFun_int.ImageUrl = "../Content/img/theme/estructura6.jpg";
            btn_estado_int.Text = ddl_tipo_asig.SelectedItem.Text;
            chk_tiene_item.Checked = false;
            sc = "$('#block_datos_int').css('display', 'none'); $('#block_datos_fun').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none'); $('#block_buscar_item').css('display', 'block'); $('#block_tiene_item').css('display', 'none'); $('#block_digite_item').css('display', 'none'); $('#block_guardar').css('display', 'none');";
            SetScript(sc);
        }
        Limpiar();
    }
    protected void chk_tiene_item_CheckedChanged(object sender, EventArgs e)
    {
        if (chk_tiene_item.Checked)
        {
            Limpiar();
            sc = "$('#block_digite_item').css('display', 'block'); $('#block_buscar_item').css('display', 'none'); $('#block_guardar').css('display', 'none');";
            SetScript(sc);
        }
        else
        {
            Limpiar();
            sc = "$('#block_buscar_item').css('display', 'block'); $('#block_digite_item').css('display', 'none'); $('#block_intercambio').css('display', 'none'); $('#block_datos_fun_inter').css('display', 'none'); $('#block_guardar').css('display', 'none');";
            SetScript(sc);
        }
    }

    protected void btn_buscar_Click(object sender, EventArgs e)
    {
        cargo = new cls_mp_cargo();
        cargo.ep_cod_estp = (txt_digite_item.Text != "") ? Convert.ToInt32(txt_digite_item.Text) : 0;
        cargo.gestion_selec = Session["pr_id"].ToString(); ;
        var detalleItem = cargo.ObtenerDetalleItemEjecutivo();

        if (detalleItem.Tables[0].Rows.Count > 0)
        {
            var detalle_item_x = detalleItem.Tables[0].Rows[0];
            string ci_asig_int = validarCampo(detalle_item_x["per_num_doc"]);
            ci_asig_int = ci_asig_int + " " + validarCampo(detalle_item_x["cat_abreviacion"]);

            if (ci_asig_int != "")
            {
                if (detalle_item_x["es_descripcion"] != DBNull.Value && detalle_item_x["es_descripcion"].ToString().Trim() != "")
                {
                    string haberBasicoItem = validarCampo(detalle_item_x["haber_basico"]);
                    aux_ca_basico_calculado_nuevo.Value = haberBasicoItem;
                    decimal haberBasico2 = Convert.ToDecimal(haberBasicoItem);
                    haberBasico2 = Math.Round(haberBasico2, 2);
                    ltl_cargo_asig.Text = validarCampo(detalle_item_x["es_descripcion"]);
                    ltl_hb_asig.Text = haberBasico2 + "";

                }
                ltl_unidad_asig.Text = validarCampo(detalle_item_x["eo_descripcion"]);
                if (validarCampo(detalle_item_x["es_escalafon"]) != "")
                {
                    string clase = validarCampo(detalle_item_x["ns_clase"]);
                    string nSalarial = validarCampo(detalle_item_x["ns_nivel"]);
                    ltl_cod_esc_asig.Text = detalle_item_x["es_escalafon"].ToString().Trim();
                    ltl_clase_asig.Text = clase;
                    ltl_nivel_salarial_asig.Text = nSalarial;

                }
                if (detalle_item_x["ca_ti_item"] != DBNull.Value && detalle_item_x["ca_ti_item"].ToString().Trim() != "")
                {
                    string nroItem = validarCampo(detalle_item_x["ca_num_item"]);
                    ltl_item_asig.Text = validarCampo(detalle_item_x["ca_ti_item"]);
                }
                string apellidos_asig_int = validarCampo(detalle_item_x["per_ap_paterno"]);
                apellidos_asig_int = apellidos_asig_int + " " + validarCampo(detalle_item_x["per_ap_materno"]);
                string nom_asig_int = validarCampo(detalle_item_x["per_nombres"]);
                string cod_fun_int = validarCampo(detalle_item_x["per_id"]);
                ltl_nombre_fun_inter.Text = nom_asig_int + " " + apellidos_asig_int;
                ltl_ci_inter.Text = ci_asig_int;
                ltl_cod_fun_inter.Text = cod_fun_int;

                sc = "$('#block_datos_fun_inter').css('display', 'block');  $('#block_guardar').css('display', 'block'); $('#block_datos_fun').css('display', 'block');";
                SetScript(sc);
                //VARIABLES PARA CARGO NUEVO
                aux_ca_id.Value = validarCampo(detalle_item_x["ca_id"]);
                aux_ca_es_id.Value = validarCampo(detalle_item_x["ca_es_id"]);
                aux_ca_eo_id.Value = validarCampo(detalle_item_x["ca_eo_id"]);
                aux_ca_ti_item.Value = validarCampo(detalle_item_x["ca_ti_item"]);
                aux_ca_num_item.Value = validarCampo(detalle_item_x["ca_num_item"]);
                aux_ca_aplica_incremento.Value = validarCampo(detalle_item_x["ca_aplica_incremento"]);
                aux_ca_tipo_jornada.Value = validarCampo(detalle_item_x["ca_tipo_jornada"]);
                aux_ca_basico_calculado.Value = validarCampo(detalle_item_x["ca_basico_calculado"]);
                aux_ca_tipo_calculo.Value = validarCampo(detalle_item_x["ca_tipo_calculo"]);
                aux_ca_pr_id.Value = validarCampo(detalle_item_x["ca_pr_id"]);
                aux_per_id_ci.Value = validarCampo(detalle_item_x["per_id"]);
            }
            else
            {
                if (validarCampo(detalle_item_x["es_descripcion"]) != "")
                {
                    string haberBasicoItem = validarCampo(detalle_item_x["haber_basico"]);
                    aux_ca_basico_calculado_nuevo.Value = haberBasicoItem;
                    decimal haberBasico2 = Convert.ToDecimal(haberBasicoItem);
                    haberBasico2 = Math.Round(haberBasico2, 2);
                    ltl_cargo_asig.Text = validarCampo(detalle_item_x["es_descripcion"]);
                    ltl_hb_asig.Text = haberBasico2 + "";
                }
                ltl_unidad_asig.Text = validarCampo(detalle_item_x["eo_descripcion"]);
                if (validarCampo(detalle_item_x["es_escalafon"]) != "")
                {
                    string clase = validarCampo(detalle_item_x["ns_clase"]);
                    string nSalarial = validarCampo(detalle_item_x["ns_nivel"]);
                    ltl_cod_esc_asig.Text = validarCampo(detalle_item_x["es_escalafon"]);
                    ltl_clase_asig.Text = clase;
                    ltl_nivel_salarial_asig.Text = nSalarial;

                }
                if (validarCampo(detalle_item_x["ca_ti_item"]) != "")
                {
                    string nroItem = validarCampo(detalle_item_x["ca_num_item"]);
                    ltl_item_asig.Text = validarCampo(detalle_item_x["ca_ti_item"]) + " - " + nroItem;
                }
                aux_per_id_ci.Value = string.Empty;
                sc = " $('#block_guardar').css('display', 'block'); $('#block_datos_fun').css('display', 'block');";
                SetScript(sc);

                //VARIABLES PARA CARGO NUEVO
                aux_ca_id.Value = validarCampo(detalle_item_x["ca_id"]);
                aux_ca_es_id.Value = validarCampo(detalle_item_x["ca_es_id"]);
                aux_ca_eo_id.Value = validarCampo(detalle_item_x["ca_eo_id"]);
                aux_ca_ti_item.Value = validarCampo(detalle_item_x["ca_ti_item"]);
                aux_ca_num_item.Value = validarCampo(detalle_item_x["ca_num_item"]);
                aux_ca_aplica_incremento.Value = validarCampo(detalle_item_x["ca_aplica_incremento"]);
                aux_ca_tipo_jornada.Value = validarCampo(detalle_item_x["ca_tipo_jornada"]);
                aux_ca_basico_calculado.Value = validarCampo(detalle_item_x["ca_basico_calculado"]);
                aux_ca_tipo_calculo.Value = validarCampo(detalle_item_x["ca_tipo_calculo"]);
                aux_ca_pr_id.Value = validarCampo(detalle_item_x["ca_pr_id"]);
                aux_per_id_ci.Value = validarCampo(detalle_item_x["per_id"]);
            }
            string estado_int = validarCampo(detalle_item_x["as_estado"]);
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
            string imagen_int = validarCampo(detalle_item_x["fp_foto"]);
            string sexo_int = validarCampo(detalle_item_x["per_sexo"]);

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
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-times', message: 'El ítem buscado no existe'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_guardar').css('display', 'none'); $('#block_datos_fun').css('display', 'none');";
            SetScript(sc);
        }
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
}