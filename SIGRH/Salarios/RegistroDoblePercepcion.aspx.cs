using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Salarios_RegistroDoblePercepcion : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_glosa _glosa = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_pla_factor _factor = null;
    private cls_pla_acreedor_retencion _acreedor_retencion = null;
    private cls_pla_transacciones _transaccion = null;
    private cls_pla_transacciones_cuotas _transaccion_cuota = null;
    private cls_pla_transacciones_acreedor _transaccion_acreedor = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                BindForm(id);
                BindDDLTipoTransaccion();
                BindGridView(id);

                if (GvLista.Rows.Count > 0) { P_list.Visible = true; }
                else { P_list.Visible = false; }
            }
        }
        else { Response.Redirect("../Index"); }
    }

    // Carga Datos En El Formulario Información
    private void BindForm(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

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
            ltl_jornada.Text = ValidarCampo(var_datos_as_c.Rows[0]["ca_tipo_jornada_lit"]);
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

    // Carga Datos En La Lista TipoTransaccion
    private void BindDDLTipoTransaccion()
    {
        _factor = new cls_pla_factor();
        Ddl_tr_fa_id.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_tr_fa_id.DataSource = _factor.ObtenerTablaComboX("928");
        Ddl_tr_fa_id.DataValueField = "fa_id";
        Ddl_tr_fa_id.DataTextField = "fa_descripcion";
        Ddl_tr_fa_id.DataBind();
        Ddl_tr_fa_id.SelectedIndex = 1; Ddl_tr_fa_id.Enabled = false;
    }

    // Carga Datos En La Lista TipoDocumentoImpreso
    private void BindDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Carga Datos En La Lista TipoAcreedor
    private void BindDDLTipoAcreedor()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_acreedor" };
        Ddl_acr_tipo_entidad.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_acr_tipo_entidad.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_acr_tipo_entidad.DataValueField = "cat_abreviacion";
        Ddl_acr_tipo_entidad.DataTextField = "cat_descripcion";
        Ddl_acr_tipo_entidad.DataBind();
    }

    // Carga Datos En La Grilla Transacciones
    private void BindGridView(string per_id)
    {
        try
        {
            _transaccion = new cls_pla_transacciones();
            GvLista.DataSource = _transaccion.ObtenerTablaGrillaRR("", "", per_id, "", "", "", "", "V");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Carga Datos En La Grilla Cuotas
    private void BindGriviewC(string tr_id)
    {
        try
        {
            _transaccion_cuota = new cls_pla_transacciones_cuotas();
            GvCuota.DataSource = _transaccion_cuota.ObtenerTablaGrilla("", tr_id, "", "", "V");
            GvCuota.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Carga Datos En La Grilla Acreedor
    private void BindGridViewAc(string acr_per_id)
    {
        try
        {
            _acreedor_retencion = new cls_pla_acreedor_retencion();
            GvAcreedor.DataSource = _acreedor_retencion.ObtenerTablaGrillaF(acr_per_id);
            GvAcreedor.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño De La Grilla Transacciones
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) { GvLista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvLista.FooterRow != null) { GvLista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Diseño De La Grilla Transacciones
    protected void GvLista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) { return; }
        _transaccion_cuota = new cls_pla_transacciones_cuotas();
        var index = Convert.ToInt32(e.Row.DataItemIndex);
        var id = GvLista.DataKeys[index].Value.ToString();
        var data = _transaccion_cuota.ObtenerTablaGrilla("", id, "", "", "V").Tables[0];

        if (!(data.Rows.Count > 0))
        {
            LinkButton lnkBtn = (LinkButton)e.Row.FindControl("BtnCuota");
            lnkBtn.Visible = false;
        }
    }

    // Evento De La Grilla Transacciones
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();
        var id = Request.QueryString["id"].ToString();
        var bus = "true"; var txt = "true";

        if (e.CommandName.Equals("GetCuota"))
        {
            _transaccion = new cls_pla_transacciones();
            var data = _transaccion.ObtenerTablaGrilla(code, "", id, "", "", "", "", "").Tables[0];
            BindGriviewC(code);
            Lt_tr_fa_id.Text = data.Rows[0]["fa_descripcion"].ToString();
            Lt_tr_monto.Text = Convert.ToDouble(data.Rows[0]["tr_monto"]).ToString("N");
            Lt_tr_fecha_inicio.Text = Convert.ToDateTime(data.Rows[0]["tr_fecha_inicio"]).ToString("dd/MM/yyy");
            sc = "$('#cuotaModal').modal('show');";
            bus = "false"; txt = "false";
        }
        else if (e.CommandName.Equals("GetGlosa"))
        {
            BindDDLTipoDocumentoImpreso();
            Ddl_gl_tipo_doc.Enabled = false;
            Txt_gl_fecha_doc.Enabled = false;
            Txt_gl_glosa.Enabled = false;
            BtnGuardarG.Visible = false;
            _glosa = new cls_glosa();
            var data = _glosa.ObtenerTablaGrilla("", code, "tr_id", "tbl_pla_transacciones", "", "", "", "", "", "V").Tables[0];

            if (data.Rows.Count > 0)
            {
                Ddl_gl_tipo_doc.SelectedValue = data.Rows[0]["gl_tipo_doc"].ToString().Trim();
                Txt_gl_fecha_doc.Text = Convert.ToDateTime(data.Rows[0]["gl_fecha_doc"]).ToString("dd/MM/yyyy").Trim();
                Txt_gl_glosa.Text = data.Rows[0]["gl_glosa"].ToString().Trim();
                sc = "$('#Txt_gl_fecha_doc').addClass('form-control'); $('#glosaModal').modal('show');";
            }
            else { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no tinene glosa...!!' }, { type: 'warning' });"; }
        }
        else if (e.CommandName.Equals("GetDelete"))
        {
            _transaccion = new cls_pla_transacciones();
            var data = _transaccion.ObtenerTablaGrilla(code, "", id, "", "", "", "", "").Tables[0];
            Hf_tr_id_b.Value = code;
            Lt_tr_fa_id_b.Text = data.Rows[0]["fa_descripcion"].ToString();
            Lt_tr_monto_b.Text = Convert.ToDouble(data.Rows[0]["tr_monto"]).ToString("N");
            Lt_tr_fecha_inicio_b.Text = Convert.ToDateTime(data.Rows[0]["tr_fecha_inicio"]).ToString("dd/MM/yyy");
            sc = "$('#deleteModal').modal('show');";
        }

        if (string.IsNullOrEmpty(Lt_acr_tipo_entidad.Text) && string.IsNullOrEmpty(Lt_acr_descripcion.Text) && string.IsNullOrEmpty(Lt_acr_documento.Text)) { P_acreedor.Visible = false; }
        else { P_acreedor.Visible = true; }
        SetScript(sc, "", bus, txt);
    }

    // Diseño De La Grilla Cuotas
    protected void GvCuota_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvCuota.Rows.Count > 0)
        {
            if (GvCuota.HeaderRow != null) { GvCuota.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvCuota.FooterRow != null) { GvCuota.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Diseño De La Grilla Acreedor
    protected void GvAcreedor_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvAcreedor.Rows.Count > 0)
        {
            if (GvAcreedor.HeaderRow != null) { GvAcreedor.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvAcreedor.FooterRow != null) { GvAcreedor.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento De La Grilla Acreedor
    protected void GvAcreedor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvAcreedor.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("GetSelect"))
        {
            _catalogo = new cls_catalogo();
            _acreedor_retencion = new cls_pla_acreedor_retencion();
            var var_datosAR = _acreedor_retencion.ObtenerTablaGrilla(code, "", "", "", "V").Tables[0];
            var var_datosC = _catalogo.ObtenerTablaGrilla("", "tipo_acreedor", "", "", "", "", var_datosAR.Rows[0]["acr_tipo_entidad"].ToString(), "", "", "V").Tables[0];
            Hf_acr_id.Value = code;
            Hf_acr_tipo_entidad.Value = var_datosAR.Rows[0]["acr_tipo_entidad"].ToString();
            Lt_acr_tipo_entidad.Text = var_datosC.Rows[0]["cat_descripcion"].ToString();
            Lt_acr_descripcion.Text = var_datosAR.Rows[0]["acr_descripcion"].ToString();
            Lt_acr_documento.Text = var_datosAR.Rows[0]["acr_documento"].ToString();
            Limpiar("frm_acr_cl");
            P_acreedor.Visible = true;
            BindDDLTipoDocumentoImpreso();

            if (P_cuotas.Visible) { sc = "$('#BtnTabPU').removeClass('active'); $('#BtnTabPC').addClass('active');"; }
            else { sc = "$('#BtnTabPU').addClass('active'); $('#BtnTabPC').removeClass('active');"; }
            sc += "$('#acreedorModal').modal('hide'); $('#glosaModal').modal('show');";
        }
        SetScript(sc, ", dropdownParent: $('#glosaModal')", "true", "true");
    }

    // Evento De La Lista TipoTransaccion
    protected void Ddl_tr_fa_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_tr_fa_id.SelectedValue.Equals("998"))
        {
            Txt_tr_monto.Attributes.Add("OnKeyUp", "GetKeyUpD()");
            Txt_tc_cant_cuotas.Attributes.Add("OnKeyUp", "GetKeyUpD()");
            _catalogo = new cls_catalogo();
            _acreedor_retencion = new cls_pla_acreedor_retencion();
            var var_datosAR = _acreedor_retencion.ObtenerTablaGrilla("50", "", "", "", "V").Tables[0];
            var var_datosC = _catalogo.ObtenerTablaGrilla("", "tipo_acreedor", "", "", "", "", var_datosAR.Rows[0]["acr_tipo_entidad"].ToString(), "", "", "V").Tables[0];
            Hf_acr_id.Value = "50";
            Hf_acr_tipo_entidad.Value = var_datosAR.Rows[0]["acr_tipo_entidad"].ToString();
            Lt_acr_tipo_entidad.Text = var_datosC.Rows[0]["cat_descripcion"].ToString();
            Lt_acr_descripcion.Text = var_datosAR.Rows[0]["acr_descripcion"].ToString();
            Lt_acr_documento.Text = var_datosAR.Rows[0]["acr_documento"].ToString();
            P_acreedor.Visible = true;
        }
        else
        {
            Txt_tr_monto.Attributes.Add("OnKeyUp", "GetKeyUpE()");
            Txt_tc_cant_cuotas.Attributes.Add("OnKeyUp", "GetKeyUpE()");
        }

        if (P_cuotas.Visible) { sc = "$('#BtnTabPU').removeClass('active'); $('#BtnTabPC').addClass('active');"; }
        else { sc = "$('#BtnTabPU').addClass('active'); $('#BtnTabPC').removeClass('active');"; }

        if (!Ddl_tr_fa_id.SelectedValue.Equals("51"))
        {
            if (string.IsNullOrEmpty(Lt_acr_tipo_entidad.Text) && string.IsNullOrEmpty(Lt_acr_descripcion.Text) && string.IsNullOrEmpty(Lt_acr_documento.Text)) { P_acreedor.Visible = false; }
            else { P_acreedor.Visible = true; }
        }
        else { P_acreedor.Visible = false; }
        Limpiar("frm_tr_cl");
        SetScript(sc, "", "true", "true");
    }

    // Evento De La Lista TipoAcreedor
    protected void Ddl_acr_tipo_entidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_acr_tipo_entidad.SelectedValue.Equals("NT"))
        {
            Txt_acr_descripcion.Attributes.Add("placeholder", "Ej.: Juan Perez Torrez");
            Rfv_acr_documento.Enabled = true;
        }
        else
        {
            Txt_acr_descripcion.Attributes.Add("placeholder", "Ej.: Juzgado Primero de Instrucción");
            Rfv_acr_documento.Enabled = false;
        }

        if (P_cuotas.Visible) { sc = "$('#BtnTabPU').removeClass('active'); $('#BtnTabPC').addClass('active');"; }
        else { sc = "$('#BtnTabPU').addClass('active'); $('#BtnTabPC').removeClass('active');"; }

        if (string.IsNullOrEmpty(Lt_acr_tipo_entidad.Text) && string.IsNullOrEmpty(Lt_acr_descripcion.Text) && string.IsNullOrEmpty(Lt_acr_documento.Text)) { P_acreedor.Visible = false; }
        else { P_acreedor.Visible = true; }

        if (GvAcreedor.Rows.Count > 0) { P_list_acreedor.Visible = true; }
        else { P_list_acreedor.Visible = false; }
        SetScript(sc, ",dropdownParent: $('#acreedorModal')", "true", "true");
    }

    // Pago Único
    protected void BtnTabPU_Click(object sender, EventArgs e)
    {
        Limpiar("frm_tr_ddl");
        Limpiar("frm_tr_cl");
        Limpiar("frm_acr_i_cl");
        P_cuotas.Visible = false;
        P_acreedor.Visible = false;
        sc = "$('#BtnTabPU').addClass('active'); $('#BtnTabPC').removeClass('active');";
        SetScript(sc, "", "true", "true");
    }

    // Pago Cuotas
    protected void BtnTabPC_Click(object sender, EventArgs e)
    {
        Limpiar("frm_tr_ddl");
        Limpiar("frm_tr_cl");
        Limpiar("frm_acr_i_cl");
        P_cuotas.Visible = true;
        P_acreedor.Visible = false;
        sc = "$('#BtnTabPU').removeClass('active'); $('#BtnTabPC').addClass('active');";
        SetScript(sc, "", "true", "true");
    }

    // Guardar Alta Transacción / Transacción Cuota
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        var val_s = "";

        if (Ddl_tr_fa_id.SelectedValue.Equals("51") || Ddl_tr_fa_id.SelectedValue.Equals("998"))
        {
            BindDDLTipoDocumentoImpreso();
            sc = "$('#glosaModal').modal('show');";
            val_s = ", dropdownParent: $('#glosaModal')";
        }
        else
        {
            var id = Request.QueryString["id"].ToString();
            BindDDLTipoAcreedor();
            BindGridViewAc(id);

            if (GvAcreedor.Rows.Count > 0) { P_list_acreedor.Visible = true; }
            else { P_list_acreedor.Visible = false; }
            sc = "$('#acreedorModal').modal('show');";
            val_s = ", dropdownParent: $('#acreedorModal')";
        }

        if (P_cuotas.Visible) { sc += "$('#BtnTabPU').removeClass('active'); $('#BtnTabPC').addClass('active');"; }
        else { sc += "$('#BtnTabPU').addClass('active'); $('#BtnTabPC').removeClass('active');"; }

        if (string.IsNullOrEmpty(Lt_acr_tipo_entidad.Text) && string.IsNullOrEmpty(Lt_acr_descripcion.Text) && string.IsNullOrEmpty(Lt_acr_documento.Text)) { P_acreedor.Visible = false; }
        else { P_acreedor.Visible = true; }
        SetScript(sc, val_s, "true", "true");
    }

    // Cancelar Vista Pago Cuotas
    protected void BtnCancelarPC_Click(object sender, EventArgs e)
    {
        Limpiar("list_pc_cl");
        sc = "$('#cuotaModal').modal('hide');";
        SetScript(sc, "", "true", "true");
    }

    // Guardar Baja
    protected void BtnGuardarB_Click(object sender, EventArgs e)
    {

    }

    // Cancelar Baja
    protected void BtnCancelarB_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Lt_acr_tipo_entidad.Text) && string.IsNullOrEmpty(Lt_acr_descripcion.Text) && string.IsNullOrEmpty(Lt_acr_documento.Text)) { P_acreedor.Visible = false; }
        else { P_acreedor.Visible = true; }
        sc = "$('#deleteModal').modal('hide');";
        SetScript(sc, "", "true", "true");
    }

    // Guardar Alta Acreedor
    protected void BtnGuardarA_Click(object sender, EventArgs e)
    {
        _acreedor_retencion = new cls_pla_acreedor_retencion();
        var data = _acreedor_retencion.ObtenerTablaGrilla("", "", Txt_acr_descripcion.Text.ToUpper().Trim(), Txt_acr_documento.Text.Trim(), "V").Tables[0];

        if (data.Rows.Count > 0)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los datos no se pueden guardar, ya existe un registro con los mismos parámetros...!!' }, { type: 'warning' });";
            SetScript(sc, "", "true", "true");
            return;
        }
        Hf_acr_id.Value = "";
        Hf_acr_tipo_entidad.Value = Ddl_acr_tipo_entidad.SelectedValue;
        Lt_acr_tipo_entidad.Text = Ddl_acr_tipo_entidad.SelectedItem.Text;
        Lt_acr_descripcion.Text = Txt_acr_descripcion.Text.ToUpper().Trim();
        Lt_acr_documento.Text = Txt_acr_documento.Text.Trim();
        Limpiar("frm_acr_cl");
        P_acreedor.Visible = true;
        BindDDLTipoDocumentoImpreso();

        if (P_cuotas.Visible) { sc = "$('#BtnTabPU').removeClass('active'); $('#BtnTabPC').addClass('active');"; }
        else { sc = "$('#BtnTabPU').addClass('active'); $('#BtnTabPC').removeClass('active');"; }
        sc += "$('#acreedorModal').modal('hide'); $('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')", "true", "true");
    }

    // Cancelar Alta Acreedor
    protected void BtnCancelarA_Click(object sender, EventArgs e)
    {
        Limpiar("frm_acr_cl");

        if (P_cuotas.Visible) { sc = "$('#BtnTabPU').removeClass('active'); $('#BtnTabPC').addClass('active');"; }
        else { sc = "$('#BtnTabPU').addClass('active'); $('#BtnTabPC').removeClass('active');"; }

        if (string.IsNullOrEmpty(Lt_acr_tipo_entidad.Text) && string.IsNullOrEmpty(Lt_acr_descripcion.Text) && string.IsNullOrEmpty(Lt_acr_documento.Text)) { P_acreedor.Visible = false; }
        else { P_acreedor.Visible = true; }
        sc += "$('#acreedorModal').modal('hide');";
        SetScript(sc, "", "true", "true");
    }

    // Guardar Alta Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        var detalleFuncionario = pla_proceso.ObtenerSalarioMinimo();
        

        var id = Request.QueryString["id"].ToString();
        _transaccion = new cls_pla_transacciones
        {
            tr_per_id = Convert.ToInt32(id),
            tr_pc_id = Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["pc_id"].ToString()),
            tr_fa_id = Convert.ToInt32(Ddl_tr_fa_id.SelectedValue),
            tr_monto = Txt_tr_monto.Text.Trim()
        };
        var tr_id = _transaccion.Adicionar();

        if (P_cuotas.Visible)
        {
            var montt = Convert.ToDouble(Txt_tr_monto.Text.Trim());
            var cantc = Convert.ToInt32(Txt_tc_cant_cuotas.Text.Trim());
            var montc = Txt_tc_monto.Text.Trim();
            var montr = Hf_tc_cuota_resto.Value.Trim();

            for (int i = 0; i < cantc; i++)
            {
                if (i.Equals(cantc - 1)) { if (!Ddl_tr_fa_id.SelectedValue.Equals("998")) { montc = montr; } }
                _transaccion_cuota = new cls_pla_transacciones_cuotas
                {
                    tc_tr_id = tr_id,
                    tc_cant_cuotas = i + 1,
                    tc_monto = montc
                };
                _transaccion_cuota.Adicionar();
            }
        }

        if (!Ddl_tr_fa_id.SelectedValue.Equals("51"))
        {
            var acr_id = 0;

            if (string.IsNullOrEmpty(Hf_acr_id.Value))
            {
                _acreedor_retencion = new cls_pla_acreedor_retencion
                {
                    acr_tipo_entidad = Hf_acr_tipo_entidad.Value,
                    acr_descripcion = Lt_acr_descripcion.Text.ToUpper().Trim(),
                    acr_documento = Lt_acr_documento.Text.Trim()
                };
                acr_id = _acreedor_retencion.Adicionar();
            }
            else { acr_id = Convert.ToInt32(Hf_acr_id.Value); }
            _transaccion_acreedor = new cls_pla_transacciones_acreedor
            {
                tra_acr_id = acr_id,
                tra_tr_id = tr_id
            };
            _transaccion_acreedor.Adicionar();
        }
        _glosa = new cls_glosa
        {
            gl_valor_pk = tr_id.ToString(),
            gl_nombre_pk = "tr_id",
            gl_tabla = "tbl_pla_transacciones",
            gl_tipo_mov = 813,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        BindGridView(id);
        P_cuotas.Visible = false;
        Limpiar("frm_tr_ddl");
        Limpiar("frm_tr_cl");
        Limpiar("frm_acr_i_cl");
        Limpiar("frm_glosa_cl");

        if (GvLista.Rows.Count > 0) { P_list.Visible = true; }
        else { P_list.Visible = false; }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide'); $('#BtnTabPU').addClass('active'); $('#BtnTabPC').removeClass('active');";
        SetScript(sc, "", "true", "true");
    }

    // Cancelar Alta Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        Ddl_gl_tipo_doc.Enabled = true;
        Txt_gl_fecha_doc.Enabled = true;
        Txt_gl_glosa.Enabled = true;
        BtnGuardarG.Visible = true;

        if (P_cuotas.Visible) { sc = "$('#BtnTabPU').removeClass('active'); $('#BtnTabPC').addClass('active');"; }
        else { sc = "$('#BtnTabPU').addClass('active'); $('#BtnTabPC').removeClass('active');"; }

        if (GvLista.Rows.Count > 0) { P_list.Visible = true; }
        else { P_list.Visible = false; }

        if (string.IsNullOrEmpty(Lt_acr_tipo_entidad.Text) && string.IsNullOrEmpty(Lt_acr_descripcion.Text) && string.IsNullOrEmpty(Lt_acr_documento.Text)) { P_acreedor.Visible = false; }
        else { P_acreedor.Visible = true; }
        Limpiar("frm_glosa_cl");
        sc += "$('#Txt_gl_fecha_doc').addClass('datepickerD'); $('#glosaModal').modal('hide');";
        SetScript(sc, "", "true", "true");
    }

    // Validar Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    // Ejecutar SriptManager
    private void SetScript(string val, string valS, string valB, string valT)
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
                "'searching': " + valB + "," + // Muestra/Oculta el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': " + valT + "" + // Muestra/Oculta el campo información
            "});");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
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

    // Limpia Los Campos De Los Formularios
    private void Limpiar(string val)
    {
        if (val.Equals("frm_tr_ddl")) { Ddl_tr_fa_id.SelectedValue = "0"; }
        else if (val.Equals("frm_tr_cl"))
        {
            Txt_tr_monto.Text = string.Empty;
            Txt_tc_cant_cuotas.Text = string.Empty;
            Txt_tc_monto.Text = string.Empty;
        }
        else if (val.Equals("list_pc_cl"))
        {
            GvCuota.DataSource = null;
            GvCuota.DataBind();
        }
        else if (val.Equals("frm_acr_cl"))
        {
            Ddl_acr_tipo_entidad.Items.Clear();
            Txt_acr_descripcion.Text = string.Empty;
            Txt_acr_documento.Text = string.Empty;
            GvAcreedor.DataSource = null;
            GvAcreedor.DataBind();
        }
        else if (val.Equals("frm_acr_i_cl"))
        {
            Hf_acr_id.Value = string.Empty;
            Hf_acr_tipo_entidad.Value = string.Empty;
            Lt_acr_tipo_entidad.Text = string.Empty;
            Lt_acr_descripcion.Text = string.Empty;
            Lt_acr_documento.Text = string.Empty;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}