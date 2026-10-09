using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salarios_SancionesAlta : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_pla_factor _factor = null;
    private cls_cp_cierre_mensual _cierre_mensual = null;
    private cls_cp_sanciones _sancion = null;
    //private cls_cp_sanciones_rel_cierre _sancion_cierre = null;
    private cls_glosa _glosa = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                BindForm(id);
                BindDDLTipoSancion();
            }
        }
        else Response.Redirect("../Index");
    }

    // Carga La Información Del Funcionario
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
            Hf_cp_id.Value = ValidarCampo(var_datos_as_c.Rows[0]["cp_id"]);
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

    // Carga Datos En El DropDownList (sa_factor)
    private void BindDDLTipoSancion()
    {
        _factor = new cls_pla_factor();
        Ddl_sa_factor.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_sa_factor.DataSource = _factor.ObtenerTablaComboX("57,58,59,60");
        Ddl_sa_factor.DataValueField = "fa_id";
        Ddl_sa_factor.DataTextField = "fa_descripcion";
        Ddl_sa_factor.DataBind();
    }

    // Carga Datos En El DropDownList (sa_minutos)
    private void BindDDLMinutos()
    {
        Ddl_sa_minutos.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_sa_minutos.Items.Insert(1, new ListItem("0,5", "1"));
        Ddl_sa_minutos.Items.Insert(2, new ListItem("1", "2"));
        Ddl_sa_minutos.Items.Insert(3, new ListItem("1,5", "3"));
        Ddl_sa_minutos.DataBind();
    }

    // Carga Datos En El DropDownList (gl_tipo_doc)
    private void BindDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_id";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Evento Del DropDownList (sa_facor)
    protected void Ddl_sa_factor_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_sa_factor.SelectedValue.Equals("57"))
        {
            _cierre_mensual = new cls_cp_cierre_mensual();
            var dataCM = _cierre_mensual.ObtenerTablaGrilla("", "", "", "V").Tables[0];
            Limpiar("frm_sancion");
            Limpiar("frm_ddl_cl");
            Txt_sa_fecha_inicio.Text = Convert.ToDateTime(dataCM.Rows[0]["cm_fecha_inicio"]).ToString("dd/MM/yyyy");
            Txt_sa_fecha_fin.Text = Convert.ToDateTime(dataCM.Rows[0]["cm_fecha_final"]).ToString("dd/MM/yyyy");
            Txt_sa_minutos.Enabled = true;
            Txt_sa_fecha_inicio.Enabled = false;
            Txt_sa_fecha_fin.Enabled = false;
            Lbl_sa_minutos.Text = "Minutos Acumulados";
            Lbl_sa_fecha_inicio.Text = "Fecha Inicio";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_dias_sancion.Visible = false;
            P_sa_fecha_fin.Visible = true;
        }
        else if (Ddl_sa_factor.SelectedValue.Equals("58"))
        {
            Limpiar("frm_sancion");
            BindDDLMinutos();
            Txt_sa_fecha_inicio.Enabled = true;
            Txt_sa_fecha_fin.Enabled = true;
            Lbl_sa_fecha_inicio.Text = "Fecha Sanción";
            P_sa_minutos_t.Visible = false;
            P_sa_minutos_d.Visible = true;
            P_sa_dias_sancion.Visible = false;
            P_sa_fecha_fin.Visible = false;
        }
        else if (Ddl_sa_factor.SelectedValue.Equals("59"))
        {
            Limpiar("frm_sancion");
            Limpiar("frm_ddl_cl");
            Txt_sa_minutos.Text = "1";
            Txt_sa_minutos.Enabled = false;
            Txt_sa_fecha_inicio.Enabled = true;
            Hf_sa_dias_sancion.Value = (Convert.ToInt32(Txt_sa_minutos.Text.Trim()) * 0.5).ToString();
            Txt_sa_dias_sancion.Text = (Hf_sa_dias_sancion.Value.Equals("0,5")) ? "Medio día" : Hf_sa_dias_sancion.Value + " día(s)";
            Lbl_sa_minutos.Text = "Días Acumulados";
            Lbl_sa_fecha_inicio.Text = "Fecha Sanción";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_dias_sancion.Visible = true;
            P_sa_fecha_fin.Visible = false;
        }
        else if (Ddl_sa_factor.SelectedValue.Equals("60"))
        {
            Limpiar("frm_sancion");
            Limpiar("frm_ddl_cl");
            Txt_sa_minutos.Text = "1";
            Txt_sa_minutos.Enabled = false;
            Txt_sa_fecha_inicio.Enabled = true;
            Hf_sa_dias_sancion.Value = Txt_sa_minutos.Text.Trim();
            Txt_sa_dias_sancion.Text = Hf_sa_dias_sancion.Value + " día(s)";
            Lbl_sa_minutos.Text = "Días Acumulados";
            Lbl_sa_fecha_inicio.Text = "Fecha Sanción";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_dias_sancion.Visible = true;
            P_sa_fecha_fin.Visible = false;
        }
        P_sa_fecha_inicio.Visible = true;
        SetScript(sc, "");
    }

    // Evento Del TextBox (sa_minutos)
    protected void Txt_sa_minutos_TextChanged(object sender, EventArgs e)
    {
        if (Ddl_sa_factor.SelectedValue.Equals("57"))
        {
            _sancion = new cls_cp_sanciones();
            var dataDS = _sancion.ObtenerRegistroDS(Convert.ToInt32(Txt_sa_minutos.Text.Trim())).Tables[0];

            if (dataDS.Rows.Count > 0)
            {
                Hf_sa_dias_sancion.Value = dataDS.Rows[0]["ra_valor"].ToString().Trim();
                Txt_sa_dias_sancion.Text = (Hf_sa_dias_sancion.Value.Equals("0,5")) ? "Medio día" : Hf_sa_dias_sancion.Value + " día(s)";
                P_sa_dias_sancion.Visible = true;
            }
            else
            {
                P_sa_dias_sancion.Visible = false;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Minutos Acumulados) no puede ser menor a 45 y mayor a 300...!!' }, { type: 'warning' });";
            }
            Lbl_sa_fecha_inicio.Text = "Fecha Inicio";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_fecha_inicio.Visible = true;
            P_sa_fecha_fin.Visible = true;
        }
        SetScript(sc, "");
    }

    // Evento Del DropDownList (sa_minutos)
    protected void Ddl_sa_minutos_SelectedIndexChanged(object sender, EventArgs e)
    {
        Hf_sa_dias_sancion.Value = (Convert.ToDouble(Ddl_sa_minutos.SelectedItem.Text) * 2).ToString();
        Txt_sa_dias_sancion.Text = Hf_sa_dias_sancion.Value + " día(s)";

        if (Ddl_sa_minutos.SelectedValue.Equals("1") || Ddl_sa_minutos.SelectedValue.Equals("2"))
        {
            Lbl_sa_fecha_inicio.Text = "Fecha Sanción";
            P_sa_fecha_fin.Visible = false;
        }
        else
        {
            Lbl_sa_fecha_inicio.Text = "Fecha Inicio";
            P_sa_fecha_fin.Visible = true;
        }
        P_sa_minutos_t.Visible = false;
        P_sa_minutos_d.Visible = true;
        P_sa_dias_sancion.Visible = true;
        P_sa_fecha_inicio.Visible = true;
        SetScript(sc, "");
    }

    // Validación De Los Datos De Sanciones
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (Ddl_sa_factor.SelectedValue.Equals("57"))
        {
            _sancion = new cls_cp_sanciones();
            var dataDS = _sancion.ObtenerRegistroDS(Convert.ToInt32(Txt_sa_minutos.Text.Trim())).Tables[0];

            if (dataDS.Rows.Count > 0)
            {
                P_sa_dias_sancion.Visible = true;
                sc = "$('#glosaModal').modal('show');";
            }
            else
            {
                Lbl_sa_minutos.Text = "Minutos Acumulados";
                P_sa_dias_sancion.Visible = false;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Minutos Acumulados) no puede ser menor a 45 y mayor a 300...!!' }, { type: 'warning' });";
            }
            Lbl_sa_fecha_inicio.Text = "Fecha Inicio";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_fecha_fin.Visible = true;
        }
        else if (Ddl_sa_factor.SelectedValue.Equals("58"))
        {
            if (Ddl_sa_minutos.SelectedValue.Equals("1") || Ddl_sa_minutos.SelectedValue.Equals("2"))
            {
                Lbl_sa_fecha_inicio.Text = "Fecha Sanción";
                P_sa_fecha_fin.Visible = false;
            }
            else
            {
                Lbl_sa_fecha_inicio.Text = "Fecha Inicio";
                P_sa_fecha_fin.Visible = true;
            }
            P_sa_minutos_t.Visible = false;
            P_sa_minutos_d.Visible = true;
            P_sa_dias_sancion.Visible = true;
            sc = "$('#glosaModal').modal('show');";
        }
        else if (Ddl_sa_factor.SelectedValue.Equals("59"))
        {
            Lbl_sa_minutos.Text = "Días";
            Lbl_sa_fecha_inicio.Text = "Fecha Sanción";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_dias_sancion.Visible = true;
            P_sa_fecha_fin.Visible = false;
            sc = "$('#glosaModal').modal('show');";
        }
        else if (Ddl_sa_factor.SelectedValue.Equals("60"))
        {
            Lbl_sa_minutos.Text = "Días";
            Lbl_sa_fecha_inicio.Text = "Fecha Sanción";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_dias_sancion.Visible = true;
            P_sa_fecha_fin.Visible = false;
            sc = "$('#glosaModal').modal('show');";
        }
        BindDDLTipoDocumentoImpreso();
        P_sa_fecha_inicio.Visible = true;
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Alta De Los Datos De Sanciones Y Datos De Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        _cierre_mensual = new cls_cp_cierre_mensual();
        var dataCM = _cierre_mensual.ObtenerTablaGrilla("", "", "", "V").Tables[0];
        _sancion = new cls_cp_sanciones();
        _sancion.ObtenerId();
        var codigo = _sancion.sa_id;
        var fecha_fin = Txt_sa_fecha_fin.Text.Trim();

        if (Ddl_sa_factor.SelectedValue.Equals("58")) { if (Ddl_sa_minutos.SelectedValue.Equals("1") || Ddl_sa_minutos.SelectedValue.Equals("2")) { fecha_fin = Txt_sa_fecha_inicio.Text.Trim(); } }

        if (Ddl_sa_factor.SelectedValue.Equals("59") || Ddl_sa_factor.SelectedValue.Equals("60")) { fecha_fin = Txt_sa_fecha_inicio.Text.Trim(); }
        _sancion = new cls_cp_sanciones
        {
            sa_id = codigo,
            sa_per_id = Convert.ToInt32(id),
            sa_factor = Convert.ToInt32(Ddl_sa_factor.SelectedValue),
            sa_minutos = (Ddl_sa_factor.SelectedValue.Equals("57")) ? Convert.ToInt32(Txt_sa_minutos.Text.Trim()) : 0,
            sa_fecha_inicio = Convert.ToDateTime(Txt_sa_fecha_inicio.Text.Trim()),
            sa_fecha_fin = Convert.ToDateTime(fecha_fin),
            sa_tipo_sancion = "M",
            sa_dias_sancion = Convert.ToDouble(Hf_sa_dias_sancion.Value),
            sa_estado = "V"
        };
        _sancion.Adicionar();
        //_sancion_cierre = new cls_cp_sanciones_rel_cierre
        //{
        //    src_sa_id = codigo,
        //    src_cp_id = Convert.ToInt32(Hf_cp_id.Value),
        //    src_cm_id = Convert.ToInt32(dataCM.Rows[0]["cm_id"]),
        //    src_fecha_ejecucion = Convert.ToDateTime(dataCM.Rows[0]["cm_fecha_final"])
        //};
        //_sancion_cierre.Adicionar();
        _glosa = new cls_glosa
        {
            gl_valor_pk = codigo.ToString(),
            gl_nombre_pk = "sa_id",
            gl_tabla = "tbl_cp_sanciones",
            gl_tipo_mov = 813,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        Limpiar("frm_glosa_cl");
        Limpiar("frm_sancion_cl");
        Session["texto_notificacion"] = "Registro añadido correctamente...!!";
        SetScript(sc, "");
        Response.Redirect("Sanciones");
    }

    // Cancela Alta De Los Datos De Sanciones Y Datos De Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        if (Ddl_sa_factor.SelectedValue.Equals("57"))
        {
            Lbl_sa_minutos.Text = "Minutos Acumulados";
            Lbl_sa_fecha_inicio.Text = "Fecha Inicio";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_fecha_fin.Visible = true;
        }
        else if (Ddl_sa_factor.SelectedValue.Equals("58"))
        {
            if (Ddl_sa_minutos.SelectedValue.Equals("1") || Ddl_sa_minutos.SelectedValue.Equals("2")) { P_sa_fecha_fin.Visible = false; }
            else { P_sa_fecha_fin.Visible = true; }
            Lbl_sa_fecha_inicio.Text = "Fecha Inicio";
            P_sa_minutos_t.Visible = false;
            P_sa_minutos_d.Visible = true;
        }
        else if (Ddl_sa_factor.SelectedValue.Equals("59"))
        {
            Lbl_sa_minutos.Text = "Días";
            Lbl_sa_fecha_inicio.Text = "Fecha Sanción";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_fecha_fin.Visible = false;
        }
        else if (Ddl_sa_factor.SelectedValue.Equals("60"))
        {
            Lbl_sa_minutos.Text = "Días";
            Lbl_sa_fecha_inicio.Text = "Fecha Sanción";
            P_sa_minutos_t.Visible = true;
            P_sa_minutos_d.Visible = false;
            P_sa_fecha_fin.Visible = false;
        }
        P_sa_dias_sancion.Visible = true;
        P_sa_fecha_inicio.Visible = true;
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Valida Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    // Ejecuta Scripts
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: \"es\"" +
                    "});" +
                "});" +
                "var me = $(\".datepickerD\");" +
                "me.mask(\"99/99/9999\");" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Limpia Los Campos De Los Formularios
    private void Limpiar(string val)
    {
        if (val.Equals("frm_ddl_cl")) { Ddl_sa_minutos.Items.Clear(); }
        else if (val.Equals("frm_sancion"))
        {
            Txt_sa_minutos.Text = string.Empty;
            Txt_sa_fecha_inicio.Text = string.Empty;
            Txt_sa_fecha_fin.Text = string.Empty;
        }
        else if (val.Equals("frm_sancion_cl"))
        {
            Ddl_sa_factor.Items.Clear();
            Txt_sa_minutos.Text = string.Empty;
            Ddl_sa_minutos.Items.Clear();
            Txt_sa_dias_sancion.Text = string.Empty;
            Txt_sa_fecha_inicio.Text = string.Empty;
            Txt_sa_fecha_fin.Text = string.Empty;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}