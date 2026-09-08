using Newtonsoft.Json;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;

using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;

public partial class MovimientoPersonal_frmAsignacion : System.Web.UI.Page
{
    private cls_historico _historico = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa _glosa = null;
    private cls_persona _persona = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_mp_cargo _cargo = null;
    //private cls_mp_cargo_puesto _cargo_puesto = null;
    private cls_situacion_persona _situacion = null;
    private cls_mp_incompatibilidad_fun _incompatibilidad = null;
    private string sc = "";
    private cls_mp_cargo cargo = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                Txt_per_id_b.Focus();
            }
        }
        else { Response.Redirect("../Index"); }
    }
    private void CargarAsignaciones(int per_id)
    {
        cls_cp_sanciones sanciones = new cls_cp_sanciones();
        ddl_asignacion.Items.Clear();
        ddl_asignacion.DataSource = sanciones.ListarAsignacionesParaSancion(Convert.ToInt32(per_id));
        ddl_asignacion.DataTextField = "cargo_compuesto";
        ddl_asignacion.DataValueField = "as_ca_id";
        ddl_asignacion.DataBind();

        ddl_asignacion_edit.Items.Clear();
        ddl_asignacion_edit.DataSource = sanciones.ListarAsignacionesParaSancion(Convert.ToInt32(per_id));
        ddl_asignacion_edit.DataTextField = "cargo_compuesto";
        ddl_asignacion_edit.DataValueField = "as_ca_id";
        ddl_asignacion_edit.DataBind();
    }
    // Carga La Información Del Funcionario
    private void CargaDatosFuncionario(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", per_id, ddl_asignacion.SelectedValue, "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (var_datos_as_c.Rows.Count > 0)
        {
            Lt_per_id.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_id"]);
            Lt_per_nombres.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_nombres"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_num_doc"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["cat_abreviacion"]);
            Lt_ca_num_item.Text = ValidarCampo(var_datos_as_c.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["ca_num_item"]);
            Lt_ca_basico_calculado.Text = Convert.ToDouble(ValidarCampo(var_datos_as_c.Rows[0]["ca_basico_calculado"])).ToString("N");
            Lt_es_escalafon.Text = ValidarCampo(var_datos_as_c.Rows[0]["es_escalafon"]);
            Lt_ns_clase.Text = ValidarCampo(var_datos_as_c.Rows[0]["ns_clase"]);
            Lt_ns_nivel.Text = ValidarCampo(var_datos_as_c.Rows[0]["ns_nivel"]);
            Lt_as_fecha_inicio.Text = Convert.ToDateTime(ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_inicio"])).ToString("dd/MM/yyyy");
            Lt_as_fecha_fin.Text = (ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_fin"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_fin"])).ToString("dd/MM/yyyy");
            Lt_es_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["es_descripcion"]);
            Lt_p_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["p_descripcion"]);
            Lt_eo_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["eo_descripcion"]);
            Lt_eo_prog.Text = ValidarCampo(var_datos_as_c.Rows[0]["eo_prog"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_sprog"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_proy"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_obract"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_unidad"]);
            Lt_cp_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["cp_descripcion"]);
            Lt_cp_da.Text = ValidarCampo(var_datos_as_c.Rows[0]["cp_da"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_ue"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_programa"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_proyecto"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_actividad"]);

            if (ValidarCampo(var_datos_as_c.Rows[0]["as_estado"]).Equals("V"))
            {
                Lbl_as_estado.Text = "Vigente";
                Lbl_as_estado.CssClass = "btn btn-sm btn-info float-right";
            }
            else
            {
                Lbl_as_estado.Text = "Pasivo";
                Lbl_as_estado.CssClass = "btn btn-sm btn-secondary float-right";
            }

            if (ValidarCampo(var_datos_as_c.Rows[0]["fp_foto"]) != "") { Img_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])var_datos_as_c.Rows[0]["fp_foto"]); }
            else if (ValidarCampo(var_datos_as_c.Rows[0]["per_sexo"]).Equals("M")) { Img_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg"; }
            else { Img_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg"; }
        }
    }

    // Carga Datos En El GridView (GvLista)
    private void CargaGVLista(string varId, string varCed, string varPat, string varMat, string varNom)
    {
        try
        {
            _persona = new cls_persona();
            GvLista.DataSource = _persona.ObtenerTablaGrilla(varId, "", varCed, "", varPat, varMat, varNom, "", "", "", "", "", "", "");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Carga Datos En El DropDownList (Ddl_as_tipo_baja)
    private void CargaDDLTipoBaja(string par_val)
    {
        _catalogo = new cls_catalogo();
        Ddl_as_tipo_baja.Items.Clear();
        Ddl_as_tipo_baja.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_as_tipo_baja.DataSource = _catalogo.ObtenerTablaGrilla("", par_val, "", "", "", "", "", "", "", "V");
        Ddl_as_tipo_baja.DataValueField = "cat_abreviacion";
        Ddl_as_tipo_baja.DataTextField = "cat_descripcion";
        Ddl_as_tipo_baja.DataBind();
    }

    // Carga Datos En El DropDownList (Ddl_gl_tipo_doc)
    private void CargaDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo();
        Ddl_gl_tipo_doc.Items.Clear();
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaGrilla("", "tipo_documento_impreso", "", "", "", "", "", "", "", "V");
        Ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Diseño Del GridView (GvLista)
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) { GvLista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvLista.FooterRow != null) { GvLista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Diseño Del GridView (GvLista)
    protected void GvLista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) { return; }
        _asignacion = new cls_mp_asignacion();
        var index = Convert.ToInt32(e.Row.DataItemIndex);
        var id = GvLista.DataKeys[index].Value.ToString();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        LinkButton lnkBtnA = (LinkButton)e.Row.FindControl("BtnAlta");
        LinkButton lnkBtnB = (LinkButton)e.Row.FindControl("BtnBaja");
        LinkButton lnkBtnM = (LinkButton)e.Row.FindControl("BtnModificar");

        if (var_datos_as_c.Rows.Count > 0 && var_datos_as_c.Rows[0]["as_estado"].ToString().Trim().Equals("V"))
        {
            // Tiene asignación vigente -> solo Baja y Modificar
            lnkBtnA.Visible = false;
            lnkBtnB.Visible = true;
            lnkBtnM.Visible = true;
        }
        else
        {
            // No tiene asignación vigente -> solo Alta
            lnkBtnA.Visible = true;
            lnkBtnB.Visible = false;
            lnkBtnM.Visible = false;
        }
    }

    // Evento Del GridView (GvLista)
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();
        Limpiar("frm_bj_cl");
        Limpiar("frm_glosa_cl");
        if (e.CommandName.Equals("GetAlta"))
        {
            _incompatibilidad = new cls_mp_incompatibilidad_fun();
            var count = _incompatibilidad.ObtenerTablaGrilla("", code, "", "", "V").Tables[0].Rows.Count;

            if (count > 0) { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro seleccionado no fue habilitado para contratación, tiene incompatibilidad funcionaria...!!' }, { type: 'warning' });"; }
            else { Response.Redirect("AsignacionAlta?id=" + code); }
        }
        else if (e.CommandName.Equals("GetBaja"))
        {
            _asignacion = new cls_mp_asignacion();
            var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", code, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

            if (var_datos_as_c.Rows.Count > 0)
            {
                if (var_datos_as_c.Rows[0]["ti_tipo_item_gral"].ToString().Trim().Equals("C")) { CargaDDLTipoBaja("tipo_mov_baja_contrato"); }
                else if (var_datos_as_c.Rows[0]["ti_tipo_item_gral"].ToString().Trim().Equals("P")) { CargaDDLTipoBaja("tipo_mov_baja_planta"); }

                // 1) Primero recargamos el dropdown ddl_asignacion con las asignaciones
                //    del funcionario NUEVO que se acaba de seleccionar (antes se hacía después,
                //    y por eso CargaDatosFuncionario usaba el SelectedValue viejo)
                CargarAsignaciones(Convert.ToInt32(code));

                if (var_datos_as_c.Rows[0]["as_validacion"].ToString().Trim().Equals("N"))
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no puede ser dado de baja, falta validación...!!' }, { type: 'warning' });";
                }
                else
                {
                    Hf_as_id.Value = var_datos_as_c.Rows[0]["as_id"].ToString().Trim();
                    Hf_as_ca_id.Value = var_datos_as_c.Rows[0]["as_ca_id"].ToString().Trim();
                    Hf_as_per_id.Value = var_datos_as_c.Rows[0]["as_per_id"].ToString().Trim();
                    Hf_ti_tipo_ig.Value = var_datos_as_c.Rows[0]["ti_tipo_item_gral"].ToString().Trim();

                    // 2) Recién ahora, con ddl_asignacion ya actualizado, cargamos los datos
                    //    visibles del funcionario (nombre, foto, cargo, etc.)
                    CargaDatosFuncionario(code);
                    sc = "$('#bajaModal').modal('show');";
                }
            }
        }
        if (e.CommandName.Equals("GetEdit"))
        {
            cls_mp_asignacion asignacion = new cls_mp_asignacion();
            string vv = asignacion.ObtenerTablaGrilla("", code, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0].Rows[0]["as_id"].ToString();
            if (asignacion.ObtenerTablaGrilla("", code, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0].Rows[0]["as_id"].ToString() != "S")
            {
                CargarAsignaciones(Convert.ToInt32(code));
                BindFormEdit(code);
                sc = "$('#modificarAsig').modal('show');";
                SetScript(sc, ", dropdownParent: $('#modificarAsig')");
            }
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El item se encuentra validado para el proceso de sueldos y no puede modificarse...' }, { type: 'warning' });";
        }
        SetScript(sc, ", dropdownParent: $('#bajaModal')");
    }
    private void BindFormEdit(string code)
    {
        _persona = new cls_persona();
        cls_mp_asignacion asignacion = new cls_mp_asignacion();
        DataSet dsAsignacion = asignacion.ObtenerTablaGrilla("", code, ddl_asignacion_edit.SelectedValue, "", "", "", "", "", "", "", "", "", "", "");
        int as_id = Convert.ToInt32(dsAsignacion.Tables[0].Rows[0]["as_id"].ToString());
        string pr_id = dsAsignacion.Tables[0].Rows[0]["as_pr_id"].ToString();
        informacionFuncionario(Convert.ToInt32(code), as_id, HttpContext.Current.Session["pr_id"].ToString());
        Hf_as_per_id.Value = code;
        Hf_as_id.Value = as_id.ToString();
    }
    private void informacionFuncionario(int codFun = 0, int as_id = 0, string pr_id = "")
    {
        cargo = new cls_mp_cargo();
        cargo.as_per_id = codFun;
        cargo.as_id_actual = as_id;
        var detalleFuncionario = cargo.ObtenerDatosDetalleFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                //ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                //ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
                txtFechaAsignacion.Text = validarCampo(funcionario["as_fecha_inicio"]);
                txtFechaBaja.Text = validarCampo(funcionario["as_fecha_fin"]);
                //aux_per_id.Value = cargo.as_per_id.ToString().Trim();
                string haberBasico = validarCampo(funcionario["haber_basico"]);
                decimal haberBasico2 = Convert.ToDecimal(haberBasico);
                haberBasico2 = Math.Round(haberBasico2, 2);
                ltl_haber_basico.Text = Convert.ToString(haberBasico2);

                if (validarCampo(funcionario["as_estado"]) == "V")
                {
                    btn_estado.Text = "Vigente";
                    btn_estado.CssClass = "btn btn-sm btn-info float-right";
                }
                else
                {
                    btn_estado.Text = "Pasivo";
                    btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
                }

                if (validarCampo(funcionario["fp_foto"]) != null && validarCampo(funcionario["fp_foto"]) != "")
                {
                    imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
                }
                else
                {
                    if (validarCampo(funcionario["per_sexo"]) == "M")
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
                    }
                    else
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
                    }
                }
            }
            cls_mp_cargo cargo = new cls_mp_cargo();
            cargo.eo_id = Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["as_ca_id"].ToString());
            cargo.gestion_selec = pr_id;
            string ti_tipo = cargo.ObtenerDetalleitem().Tables[0].Rows[0]["ti_tipo"].ToString();
            if (ti_tipo == "DOC")
            {
                cls_mp_asignacion asignacion = new cls_mp_asignacion();
                DataSet ds = asignacion.ObtenerEscalafonDocente();
                ddlDocente.Items.Clear();
                ddlDocente.DataSource = asignacion.ObtenerEscalafonDocente();
                ddlDocente.DataTextField = "categoria";
                ddlDocente.DataValueField = "ed_id";
                ddlDocente.DataBind();
                ddlDocente.SelectedValue = detalleFuncionario.Tables[0].Rows[0]["ed_id"].ToString();
                panelEscalafonDocentes.Visible = true;
            }
            else
                panelEscalafonDocentes.Visible = false;
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
    // Evento Del DropDownList (Ddl_as_tipo_baja)
    //protected void Ddl_as_tipo_baja_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Hf_ti_tipo_ig.Value.Equals("C"))
    //    {
    //        if (Ddl_as_tipo_baja.SelectedValue.Equals("G")) { P_as_defuncion.Visible = true; }
    //        else { P_as_defuncion.Visible = false; }
    //    }
    //    else if (Hf_ti_tipo_ig.Value.Equals("P"))
    //    {
    //        if (Ddl_as_tipo_baja.SelectedValue.Equals("I")) { P_as_defuncion.Visible = true; }
    //        else { P_as_defuncion.Visible = false; }
    //    }
    //    //sc = "$('#bajaModal').modal('show');";
    //    //SetScript("", ", dropdownParent: $('#bajaModal')");
    //    sc = " $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#bajaModal').modal('show');";
    //    SetScript(sc, "");
    //}

    // Evento Del DropDownList (Ddl_gl_tipo_doc)
    protected void Ddl_gl_tipo_doc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_gl_tipo_doc.SelectedValue.Equals("2") || Ddl_gl_tipo_doc.SelectedValue.Equals("3") || Ddl_gl_tipo_doc.SelectedValue.Equals("6") || Ddl_gl_tipo_doc.SelectedValue.Equals("8"))
        {
            P_gl_numero_doc.Visible = true;
            sc = "$('#D_gl_tipo_doc').removeClass('col-md-6'); $('#D_gl_tipo_doc').addClass('col-md-4'); $('#D_gl_fecha_doc').removeClass('col-md-6'); $('#D_gl_fecha_doc').addClass('col-md-4');$('#glosaModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#glosaModal').modal('show');";
        }
        else
        {
            P_gl_numero_doc.Visible = false;
            sc = "$('#D_gl_tipo_doc').removeClass('col-md-4'); $('#D_gl_tipo_doc').addClass('col-md-6'); $('#D_gl_fecha_doc').removeClass('col-md-4'); $('#D_gl_fecha_doc').addClass('col-md-6');$('#glosaModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#glosaModal').modal('show');";
        }
        SetScript(sc, ", dropdownParent: $('#glosaModal')");

    }

    // buscar && string.IsNullOrEmpty(Txt_per_ap_casada_b.Text)
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });"; }
        else
        {
            //CargaGVLista(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_per_ap_casada_b.Text.Trim());
            CargaGVLista(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());
            Limpiar("sch_cl");

            if (GvLista.Rows.Count > 0) { P_result.Visible = true; }
            else
            {
                P_result.Visible = false;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
            }
        }
        SetScript(sc, "");
    }

    // guardar baja
    protected void BtnGuardarB_Click(object sender, EventArgs e)
    {
        CargaDDLTipoDocumentoImpreso();
        P_as_defuncion.Visible = false;
        sc = "$('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // cancelar baja
    protected void BtnCancelarB_Click(object sender, EventArgs e)
    {
        //P_as_defuncion.Visible = false;
        Limpiar("frm_bj_cl");
        sc = "$('#bajaModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }

    // guardar glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        var var_tipo_item = ""; var var_tipo_item_gral = ""; var var_est_ca = "";
        _asignacion = new cls_mp_asignacion();
        var var_datos_as = _asignacion.ObtenerTablaGrilla(Hf_as_id.Value, "", "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", Hf_as_per_id.Value, "", "", "", "V", "", "", "", "", "", "", "", "").Tables[0];

        if (var_datos_as.Rows.Count > 0)
        {
            string var_json = JsonConvert.SerializeObject(var_datos_as);
            AdicionarHistorico("B", "tbl_mp_asignacion", "as_id", Hf_as_id.Value, var_json);
        }

        if (var_datos_as_c.Rows.Count > 0)
        {
            var_tipo_item = var_datos_as_c.Rows[0]["ti_tipo"].ToString().Trim();
            var_tipo_item_gral = var_datos_as_c.Rows[0]["ti_tipo_item_gral"].ToString().Trim();
        }

        switch (var_tipo_item)
        {
            case "FC":
                if (var_tipo_item_gral.Equals("P")) { var_est_ca = "H"; }
                break;
            case "FE":
                if (var_tipo_item_gral.Equals("P")) { var_est_ca = "L"; }
                else if (var_tipo_item_gral.Equals("C")) { var_est_ca = "H"; }
                break;
            case "FD":
                if (var_tipo_item_gral.Equals("P")) { var_est_ca = "L"; }
                else if (var_tipo_item_gral.Equals("C")) { var_est_ca = "H"; }
                break;
            case "FP":
                if (var_tipo_item_gral.Equals("C")) { var_est_ca = "H"; }
                break;
            case "ADM":
                if (var_tipo_item_gral.Equals("P")) { var_est_ca = "L"; }
                else if (var_tipo_item_gral.Equals("C")) { var_est_ca = "H"; }
                break;
            case "DOC":
                if (var_tipo_item_gral.Equals("P")) { var_est_ca = "L"; }
                else if (var_tipo_item_gral.Equals("C")) { var_est_ca = "H"; }
                break;
            default:
                break;
        }
        _asignacion = new cls_mp_asignacion
        {
            as_id = Convert.ToInt32(Hf_as_id.Value),
            as_fecha_fin = Convert.ToDateTime(Txt_as_fecha_fin_p.Text.Trim()),
            as_tipo_baja = Ddl_as_tipo_baja.SelectedValue,
            as_memo_baja = 0,
            as_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString())
        };
        _asignacion.ActualizarBaja();
        _cargo = new cls_mp_cargo
        {
            ca_id_actual = Convert.ToInt32(Hf_as_ca_id.Value),
            ca_estado_actual = var_est_ca
        };
        _cargo.ActualizarCargoActual();
        //_cargo_puesto = new cls_mp_cargo_puesto { cap_ca_id = Convert.ToInt32(Hf_as_ca_id.Value) };
        //_cargo_puesto.Eliminar();
        _glosa = new cls_glosa
        {
            gl_valor_pk = Hf_as_id.Value,
            gl_nombre_pk = "as_id",
            gl_tabla = "tbl_mp_asignacion",
            gl_tipo_mov = 814,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_numero_doc = Txt_gl_numero_doc.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        Limpiar("frm_bj_cl");
        Limpiar("frm_glosa_cl");
        Limpiar("gv_cl");
        P_result.Visible = false;

        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro actualizado correctamente...!!' }, { type: 'success' }); $('#glosaModal, #bajaModal').modal('hide');$('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }

    // cancelar glosa 
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, ", dropdownParent: $('#bajaModal')");
    }

    // Validar Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    // Alta De Los Datos De La Asignación En Histórico
    private void AdicionarHistorico(string abm, string tabla, string nom_pk, string val_pk, string campos)
    {
        _historico = new cls_historico
        {
            his_tipo_abm = abm,
            his_nom_tabla = tabla,
            his_nom_pk = nom_pk,
            his_valor_pk = val_pk,
            his_campos = campos,
            his_usuario_creacion = Convert.ToInt32(Session["per_id"])
        };
        _historico.Adicionar();
    }

    // ejecutar scriptmanager
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar _MENU_ Registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando Registros del _START_ al _END_ de un total de _TOTAL_ Registros'," +
                    "'sInfoEmpty': 'Mostrando Registros del 0 al 0 de un total de 0 Registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ Registros)'," +
                    "'sInfoPostFix': ''," +
                    "'sSearch': 'Buscar:'," +
                    "'sUrl': ''," +
                    "'sInfoThousands': ','," +
                    "'sLoadingRecords': 'Cargando...'," +
                    "'oPaginate': {" +
                        "'sFirst': '«'," +
                        "'sLast': '»'," +
                        "'sNext': '<i class=\"fas fa-angle-right\"></i>'," +
                        "'sPrevious': '<i class=\"fas fa-angle-left\"></i>'" +
                    "}," +
                    "'oAria': {" +
                        "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                        "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                "}," +
                "'ordering': false," +
                "'searching': true," + // Muestra/Oculta el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" + // Muestra/Oculta el campo información
            "});");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerDefault\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: \"es\"" +
                    "});" +
                "});" +
                "var me = $(\".datepickerDefault\");" +
                "me.mask(\"99/99/9999\");" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Limpira
    private void Limpiar(string val)
    {
        if (val.Equals("sch_cl"))
        {
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
            //Txt_per_ap_casada_b.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
        }
        else if (val.Equals("gv_cl"))
        {
            GvLista.DataSource = null;
            GvLista.DataBind();
        }
        else if (val.Equals("frm_bj_cl"))
        {
            Ddl_as_tipo_baja.Items.Clear();
            Txt_as_fecha_fin_p.Text = string.Empty;
            Txt_as_fecha_fin_m.Text = string.Empty;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_numero_doc.Text = string.Empty;
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }



    protected void btnModificarAsignacion_Click(object sender, EventArgs e)
    {
        cls_mp_asignacion asignacion = new cls_mp_asignacion();
        asignacion.as_id = Convert.ToInt32(Hf_as_id.Value);
        if (txtFechaBaja.Text != "")
            asignacion.as_fecha_fin = Convert.ToDateTime(txtFechaBaja.Text);
        if (txtFechaAsignacion.Text != "")
            asignacion.as_fecha_inicio = Convert.ToDateTime(txtFechaAsignacion.Text);
        asignacion.ActualizarFechaInicioYBaja(asignacion);

        if (panelEscalafonDocentes.Visible == true)
        {
            cls_mp_asignacion escalafon = new cls_mp_asignacion();
            escalafon.ActualizarEscalafonDocente(Convert.ToInt32(Hf_as_per_id.Value), Convert.ToInt32(ddlDocente.SelectedValue));
        }
        sc = "$.notify({ icon: 'fa fa-check', message: 'Se modificó la información correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });$('#modificarAsig').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }

    protected void ddl_asignacion_SelectedIndexChanged(object sender, EventArgs e)
    {
        _asignacion = new cls_mp_asignacion();
        string code = Lt_per_id.Text;
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", code, ddl_asignacion.SelectedValue, "", "", "", "", "", "", "", "", "", "", "").Tables[0];
        //sc = "$('#bajaModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

        if (var_datos_as_c.Rows.Count > 0)
        {
            if (var_datos_as_c.Rows[0]["ti_tipo_item_gral"].ToString().Trim().Equals("C")) { CargaDDLTipoBaja("tipo_mov_baja_contrato"); }
            else if (var_datos_as_c.Rows[0]["ti_tipo_item_gral"].ToString().Trim().Equals("P")) { CargaDDLTipoBaja("tipo_mov_baja_planta"); }

            if (var_datos_as_c.Rows[0]["as_validacion"].ToString().Trim().Equals("N")) { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no puede ser dado de baja, falta validación...!!' }, { type: 'warning' });"; }
            else
            {
                Hf_as_id.Value = var_datos_as_c.Rows[0]["as_id"].ToString().Trim();
                Hf_as_ca_id.Value = var_datos_as_c.Rows[0]["as_ca_id"].ToString().Trim();
                Hf_as_per_id.Value = var_datos_as_c.Rows[0]["as_per_id"].ToString().Trim();
                Hf_ti_tipo_ig.Value = var_datos_as_c.Rows[0]["ti_tipo_item_gral"].ToString().Trim();
                CargaDatosFuncionario(code);
                //CargarAsignaciones(Convert.ToInt32(code));
                //ddl_asignacion.SelectedIndex = ddl_asignacion.Items.IndexOf(this.ddl_asignacion.Items.FindByValue(Hf_as_ca_id.Value.ToString()));
                sc = "$('#bajaModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#bajaModal').modal('show');";
                SetScript(sc, "");
            }
        }
        SetScript(sc, "");

    }

    protected void ddl_asignacion_edit_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_mp_asignacion asignacion = new cls_mp_asignacion();
        string code = ltl_cod_fun.Text;
        string vv = asignacion.ObtenerTablaGrilla("", code, ddl_asignacion_edit.SelectedValue, "", "", "", "", "", "", "", "", "", "", "").Tables[0].Rows[0]["as_id"].ToString();
        if (asignacion.ObtenerTablaGrilla("", code, ddl_asignacion_edit.SelectedValue, "", "", "", "", "", "", "", "", "", "", "").Tables[0].Rows[0]["as_id"].ToString() != "S")
        {
            //CargarAsignaciones(Convert.ToInt32(code));
            //ddl_asignacion_edit.SelectedIndex = ddl_asignacion_edit.Items.IndexOf(this.ddl_asignacion_edit.Items.FindByValue(asignacion.as_ca_id.ToString()));

            BindFormEdit(code);
            sc = "$('#modificarAsig').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#modificarAsig').modal('show');";
            SetScript(sc, ", dropdownParent: $('#modificarAsig')");
        }
        else
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El item se encuentra validado para el proceso de sueldos y no puede modificarse...' }, { type: 'warning' });";

    }
}
