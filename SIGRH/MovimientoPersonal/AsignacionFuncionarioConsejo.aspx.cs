using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Newtonsoft.Json;

public partial class MovimientoPersonal_Asignacion_Funcionario_Consejo : System.Web.UI.Page
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
            listaFiltradoTipoDoc();
            listaFiltradoCargo();
            obtenerTipoMov();
            string codFun = Request.QueryString["id"].ToString();
            informacionFuncionario(codFun);
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

            int[] ids = { 816, 818 };

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
            var nivelOrg = cargo.ObtenerNivelOrgConcejo();

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
        cargo.gestion = anio;
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
        string id = Request.QueryString["id"].ToString();
        aux_ca_eo_id.Value = aux_ca_eo_id_actual.Value;
        tv_nivelOrg.Nodes.Clear();
        llenarArbolInicial();
        Limpiar();
        informacionFuncionario(id);
        sc = "$('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_guardar').css('display', 'none');";
        SetScript(sc);
    }

    protected void Limpiar()
    {
        txt_descripcion_add.Text = string.Empty;
        ddl_tipo_documento.SelectedValue = "0";
        ddl_tipoMovimiento.SelectedValue = "0";
    }

    protected void tv_nivelOrg_SelectedNodeChanged(object sender, EventArgs e)
    {
        int eo_id = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);
        aux_ca_eo_id.Value = tv_nivelOrg.SelectedNode.Value;
        //string gestionFiltrar = obtenerGestion();
        cargo = new cls_mp_cargo();
        cargo.ep_cod_estp = eo_id;
        cargo.gestion_selec = Session["pr_id"].ToString();
        var nivelOrg = cargo.ObtenerNivelOrganizacional();

        foreach (DataRow lvlNDataRow in nivelOrg.Tables[0].Rows)
        {
            aux_validar_item.Value = "1";
            TreeNode childNode = new TreeNode();
            childNode.Value = lvlNDataRow["eo_id"].ToString();

            childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0 desc-treeview'>" + lvlNDataRow["eo_descripcion"].ToString() + "</h6></div></div>";

            TreeNode parentNode = tv_nivelOrg.SelectedNode;
            validarNodo(parentNode, childNode);
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

    private void obtenerTipoMov()
    {
        cargo = new cls_mp_cargo();
        cargo.p_cat_id = 1876;
        var tipoMovPadre = cargo.obtenerTipoMovPadre();
        if (tipoMovPadre.Tables[0].Rows.Count > 0)
        {
            var detalle_tipoMovPadre = tipoMovPadre.Tables[0].Rows[0];
            aux_cat_id.Value = validarCampo(detalle_tipoMovPadre["cat_id"]);
            aux_cat_abreviacion.Value = validarCampo(detalle_tipoMovPadre["cat_abreviacion"]);
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
        if (aux_validar_item.Value == "1")
        {
            cargo = new cls_mp_cargo();
            int uo_selec = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);
            cargo.eo_id = uo_selec;
            var uo = cargo.obtenerNombreUO();
            ltl_unidad_asig.Text = uo.Tables[0].Rows[0]["eo_descripcion"].ToString();
            sc = "$.notify({ icon: 'fa fa-check', message: 'Unidad seleccionada correctamente'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); $('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_guardar').css('display', 'block'); ";
            SetScript(sc);

            //COMBO AUTOMATICO 
            double ca_basico_calculado_actual = Convert.ToDouble(aux_ca_basico_calculado_actual.Value);
            double ca_basico_calculado = Convert.ToDouble(aux_ca_basico_calculado.Value);
            int ca_eo_id_actual = Convert.ToInt32(aux_ca_eo_id_actual.Value);
            int ca_eo_id = Convert.ToInt32(aux_ca_eo_id.Value);
            if (ca_basico_calculado < ca_basico_calculado_actual && ca_eo_id == ca_eo_id_actual)
            {
                ddl_tipoMovimiento.SelectedValue = "A";
            }
            else
            {
                if (ca_basico_calculado > ca_basico_calculado_actual && ca_eo_id == ca_eo_id_actual)
                {
                    ddl_tipoMovimiento.SelectedValue = "B";
                }
                else
                {
                    if (aux_ca_es_id.Value == aux_ca_es_id_actual.Value && ca_eo_id != ca_eo_id_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "C";
                    }
                    else
                    {
                        if (ca_basico_calculado < ca_basico_calculado_actual && ca_eo_id != ca_eo_id_actual)
                        {
                            ddl_tipoMovimiento.SelectedValue = "D";
                        }
                        else
                        {
                            if (ca_basico_calculado > ca_basico_calculado_actual && ca_eo_id != ca_eo_id_actual)
                            {
                                ddl_tipoMovimiento.SelectedValue = "E";
                            }
                            else
                            {
                                if (ca_basico_calculado == ca_basico_calculado_actual && ca_eo_id == ca_eo_id_actual)
                                {
                                    ddl_tipoMovimiento.SelectedValue = "F";
                                }
                                else
                                {
                                    if (ca_basico_calculado == ca_basico_calculado_actual && ca_eo_id != ca_eo_id_actual)
                                    {
                                        ddl_tipoMovimiento.SelectedValue = "G";
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message: 'Debe seleccionar un ítem'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#modalBuscarItems').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_guardar').css('display', 'none');";
            SetScript(sc);
        }
    }

    private void informacionFuncionario(string id = "")
    {
        string fu_num_ident = id;
        //string gestion_selec = obtenerGestion();
        cargo.fu_num_ident = fu_num_ident;
        cargo.gestion_selec = Session["pr_id"].ToString();
        cargo.obtenerDatosFuncionarioConsejo(id);
        string haberBasico = cargo.haber_basico.ToString().Trim();
        decimal haberBasico2 = Convert.ToDecimal(haberBasico);
        haberBasico2 = Math.Round(haberBasico2, 2);
        aux_per_id.Value = cargo.as_per_id.ToString().Trim();
        ltl_cargo.Text = cargo.es_descripcion.ToString().Trim();
        ltl_hb.Text = haberBasico2 + "";
        ltl_cod_esc.Text = cargo.es_escalafon.ToString().Trim();
        ltl_clase.Text = cargo.ns_clase.ToString().Trim();
        ltl_nivel_salarial.Text = cargo.ns_nivel.ToString().Trim();
        ltl_item.Text = cargo.ca_ti_item_actual.ToString().Trim() + " - " + cargo.ca_num_item_actual.ToString().Trim();
        ltl_fecha_asig.Text = cargo.as_fecha_asignacion.ToString().Trim();
        ltl_fecha_baja.Text = cargo.as_fecha_baja.ToString().Trim();
        ltl_ubicacion.Text = cargo.ep_descripcion.ToString().Trim();
        aux_ca_id_actual.Value = cargo.ca_id_actual.ToString().Trim();
        aux_ca_es_id_actual.Value = cargo.ca_es_id_actual.ToString().Trim();
        aux_ca_eo_id_actual.Value = cargo.ca_eo_id_actual.ToString().Trim();
        aux_ca_eo_id.Value = cargo.ca_eo_id_actual.ToString().Trim();
        aux_ca_ti_item_actual.Value = cargo.ca_ti_item_actual.ToString().Trim();
        aux_ca_num_item_actual.Value = cargo.ca_num_item_actual.ToString().Trim();
        aux_ca_aplica_incremento_actual.Value = cargo.ca_aplica_incremento_actual.ToString().Trim();
        aux_ca_tipo_jornada_actual.Value = cargo.ca_tipo_jornada_actual.ToString().Trim();
        aux_ca_basico_calculado_actual.Value = cargo.ca_basico_calculado_actual.ToString().Trim();
        aux_ca_basico_calculado.Value = cargo.ca_basico_calculado_actual.ToString().Trim();
        aux_ca_tipo_calculo_actual.Value = cargo.ca_tipo_calculo_actual.ToString().Trim();
        aux_ca_pr_id_actual.Value = cargo.ca_pr_id_actual.ToString().Trim();
        aux_as_id_actual.Value = cargo.as_id_actual.ToString().Trim();

        //encabezado nuevo
        string fu_nombres = (cargo.fu_nombres != null) ? cargo.fu_nombres.ToString().Trim() : "";
        string fu_paterno = (cargo.fu_paterno != null) ? cargo.fu_paterno.ToString().Trim() : "";
        string fu_materno = (cargo.fu_materno != null) ? cargo.fu_materno.ToString().Trim() : "";
        ltl_nombre_fun.Text = fu_nombres + " " + fu_paterno + " " + fu_materno;
        ltl_ci.Text = cargo.fu_num_ident.ToString() + " " + cargo.fu_tipo_ident.ToString().Trim();
        ltl_cod_fun.Text = cargo.as_per_id.ToString();

        if (cargo.as_estado.Trim() == "V")
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
            if (cargo.fu_sexo.Trim() == "M")
            {
                imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
            }
            else
            {
                imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
            }
        }

        //datos asignación nueva
        ltl_item_asig.Text = cargo.ca_ti_item_actual.ToString().Trim() + " - " + cargo.ca_num_item_actual.ToString().Trim();
        ddl_cargo.SelectedValue = cargo.ca_es_id_actual.ToString().Trim();
        ltl_unidad_asig.Text = cargo.ep_descripcion.ToString().Trim();
        ltl_cod_esc_asig.Text = cargo.es_escalafon.ToString().Trim();
        ltl_clase_asig.Text = cargo.ns_clase.ToString().Trim();
        ltl_nivel_salarial_asig.Text = cargo.ns_nivel.ToString().Trim();
    }

    protected void btn_guardar_item_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('show');";
        SetScript(sc);
    }
        
    private void GuardarAsignacionNueva(int genera_ca_id = 0)
    {
        string perId = Session["per_id"].ToString();
        string hora = DateTime.Now.ToString("HH:mm:ss");
        cargo.as_per_id = Convert.ToInt32(aux_per_id.Value);
        cargo.as_ca_id = genera_ca_id;
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
        cargo.gl_numero_doc = txt_num_doc.Text;
        glosa.gl_estado = "V";
        glosa.gl_usuario = Convert.ToInt32(Session["us_id"].ToString());
        glosa.Adicionar();
        restablecerGlosa();
    }

    private int obtenerIdAsignacion(int ca_id = 0)
    {
        cargo = new cls_mp_cargo();
        cargo.as_per_id = Convert.ToInt32(aux_per_id.Value);
        cargo.as_ca_id = ca_id;
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

    private void listaFiltradoCargo()
    {
        try
        {
            cargo = new cls_mp_cargo();
            //string gestion = obtenerGestion();
            cargo.gestion_selec = Session["pr_id"].ToString();

            ddl_cargo.Items.Clear();
            ddl_cargo.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_cargo.DataValueField = "es_id";
            ddl_cargo.DataTextField = "desc_hb";
            ddl_cargo.DataSource = cargo.ObtenerFiltradoCargoHB();
            ddl_cargo.DataBind();
            ddl_cargo.Enabled = true;

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void ddl_cargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargo = new cls_mp_cargo();
        int es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
        cargo.ca_es_id = es_id;
        var ns = cargo.ObtenerNivelSalarial();
        if (ns.Tables[0].Rows.Count > 0)
        {
            ltl_cod_esc_asig.Text = ns.Tables[0].Rows[0]["es_escalafon"].ToString();
            ltl_clase_asig.Text = ns.Tables[0].Rows[0]["ns_clase"].ToString();
            ltl_nivel_salarial_asig.Text = ns.Tables[0].Rows[0]["ns_nivel"].ToString();
            aux_ca_basico_calculado.Value = ns.Tables[0].Rows[0]["haber_basico"].ToString();
        }
        aux_ca_es_id.Value = ddl_cargo.SelectedValue;
        double ca_basico_calculado_actual = Convert.ToDouble(aux_ca_basico_calculado_actual.Value);
        double ca_basico_calculado = Convert.ToDouble(aux_ca_basico_calculado.Value);
        int ca_eo_id_actual = Convert.ToInt32(aux_ca_eo_id_actual.Value);
        int ca_eo_id = Convert.ToInt32(aux_ca_eo_id.Value);

        bool habilitarBoton = true;
        if (ca_basico_calculado < ca_basico_calculado_actual && ca_eo_id == ca_eo_id_actual)
        {
            ddl_tipoMovimiento.SelectedValue = "A";
        }
        else
        {
            if (ca_basico_calculado > ca_basico_calculado_actual && ca_eo_id == ca_eo_id_actual)
            {
                ddl_tipoMovimiento.SelectedValue = "B";
            }
            else
            {
                if (aux_ca_es_id.Value == aux_ca_es_id_actual.Value && ca_eo_id != ca_eo_id_actual)
                {
                    ddl_tipoMovimiento.SelectedValue = "C";
                }
                else
                {
                    if (ca_basico_calculado < ca_basico_calculado_actual && ca_eo_id != ca_eo_id_actual)
                    {
                        ddl_tipoMovimiento.SelectedValue = "D";
                    }
                    else
                    {
                        if (ca_basico_calculado > ca_basico_calculado_actual && ca_eo_id != ca_eo_id_actual)
                        {
                            ddl_tipoMovimiento.SelectedValue = "E";
                        }
                        else
                        {
                            if (ca_basico_calculado == ca_basico_calculado_actual && ca_eo_id == ca_eo_id_actual)
                            {
                                ddl_tipoMovimiento.SelectedValue = "F";
                                if (aux_ca_es_id_actual.Value == ddl_cargo.SelectedValue)
                                {
                                    ddl_tipoMovimiento.SelectedValue = "0";
                                    aux_ca_basico_calculado.Value = aux_ca_basico_calculado_actual.Value;
                                    habilitarBoton = false;
                                }
                            }
                            else
                            {
                                if (ca_basico_calculado == ca_basico_calculado_actual && ca_eo_id != ca_eo_id_actual)
                                {
                                    ddl_tipoMovimiento.SelectedValue = "G";
                                }
                            }
                        }
                    }
                }
            }
        }
        if (habilitarBoton)
        {
            sc = "$('#block_guardar').css('display', 'block');";
            SetScript(sc);
        }
        else
        {
            sc = "$('#block_guardar').css('display', 'none');";
            SetScript(sc);
        }
    }

    private string generarIdCargo()
    {
        cargo = new cls_mp_cargo();
        var pe_cargo = cargo.ObtenerIdCargo();
        string ca_id = "";
        if (pe_cargo.Tables[0].Rows.Count > 0)
        {
            if (pe_cargo.Tables[0].Rows[0]["ca_id"] != DBNull.Value && pe_cargo.Tables[0].Rows[0]["ca_id"].ToString().Trim() != "")
            {
                ca_id = pe_cargo.Tables[0].Rows[0]["ca_id"].ToString().Trim();
            }
        }
        return ca_id;
    }

    protected void btn_estado_Click(object sender, EventArgs e)
    {
        SetScript("");
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

    private void procesarHistorico(int as_id = 0)
    {
        asignacion = new cls_mp_asignacion();
        asignacion.as_id = as_id;
        var detalleMovimiento = asignacion.ObtenerRegistro();
        string json = JsonConvert.SerializeObject(detalleMovimiento.Tables[0]);
        AdicionarHistorico("M", "tbl_mp_asignacion", "as_id", Convert.ToString(as_id), json);
    }

    private void procesarHistoricoC(int ca_id = 0)
    {
        cargo = new cls_mp_cargo();
        cargo.ca_id = ca_id;
        var detalleMovimiento = cargo.ObtenerRegistro();
        string json = JsonConvert.SerializeObject(detalleMovimiento.Tables[0]);
        AdicionarHistorico("M", "tbl_mp_cargo", "ca_id", Convert.ToString(ca_id), json);
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
        int ca_id_actual = Convert.ToInt32(aux_ca_id_actual.Value);
        procesarHistoricoC(ca_id_actual);
        int as_id_actual = Convert.ToInt32(aux_as_id_actual.Value);
        procesarHistorico(as_id_actual);

        cargo = new cls_mp_cargo();
        //string gestion_selec = obtenerGestion();
        string id = Request.QueryString["id"].ToString();
        string ca_id = generarIdCargo();
        int genera_ca_id = Convert.ToInt32(ca_id);
        genera_ca_id = genera_ca_id + 1;
        cargo.ca_id = genera_ca_id;
        cargo.ca_es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
        cargo.ca_eo_id = Convert.ToInt32(aux_ca_eo_id.Value);
        cargo.ca_ti_item = aux_ca_ti_item_actual.Value;
        cargo.ca_num_item = Convert.ToInt32(aux_ca_num_item_actual.Value);
        cargo.ca_estado = "O";
        cargo.ca_aplica_incremento = null;
        cargo.ca_tipo_jornada = aux_ca_tipo_jornada_actual.Value;
        double ca_basico_calculado = Convert.ToDouble(aux_ca_basico_calculado.Value);
        cargo.ca_basico_calculado = Convert.ToString(ca_basico_calculado);
        cargo.ca_tipo_calculo = 0;
        cargo.ca_pr_id = Session["pr_id"].ToString();
        cargo.ca_id_anterior = ca_id_actual;
        if (cargo.ActualizarItem())
        {
            cargo.AdicionarCargoPlanta();
            string fechaBaja = ltl_fecha_baja.Text;
            string hora = DateTime.Now.ToString("HH:mm:ss");
            cargo.as_fecha_fin_actual = fechaBaja + " " + hora;
            cargo.as_id_actual = as_id_actual;
            if (cargo.ActualizarAsignacion())
            {
                GuardarAsignacionNueva(genera_ca_id);
                guardarGlosa(genera_ca_id, "ca_id", "tbl_mp_cargo");
            }
        }
        tv_nivelOrg.Nodes.Clear();
        Limpiar();
        txt_fechaAsig.Text = "";
        informacionFuncionario(id);
        llenarArbolInicial();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
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
}