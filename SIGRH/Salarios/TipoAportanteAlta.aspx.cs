using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salarios_TipoAportanteAlta : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_mp_asignacion_tipo_aportante _aportante = null;
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
                BindGridView(id);

                if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
                else { P_lista.Visible = false; }
                SetScript(sc, "");
            }
        }
        else { Response.Redirect("../Index"); }
    }

    // Cargar Datos
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

            if (ValidarCampo(var_datos_as_c.Rows[0]["per_fecha_nac"]).Equals("")) { Lt_per_fecha_nac.Text = ""; }
            else
            {
                Lt_per_fecha_nac.Text = Convert.ToDateTime(var_datos_as_c.Rows[0]["per_fecha_nac"]).ToString("dd/MM/yyyy");
                Lt_per_edad.Text = Edad(Convert.ToDateTime(var_datos_as_c.Rows[0]["per_fecha_nac"])).ToString() + " AÑOS";
            }

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

    // Cargar GridView
    private void BindGridView(string per_id)
    {
        try
        {
            _aportante = new cls_mp_asignacion_tipo_aportante();
            GvLista.DataSource = _aportante.ObtenerTablaGrillaC("", per_id, "", "");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Cargar at_ta_id
    private void BindDDLTipoAportante(int at_edad, bool at_jubilado)
    {
        _aportante = new cls_mp_asignacion_tipo_aportante();
        Ddl_at_ta_id.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_at_ta_id.DataSource = _aportante.ObtenerTablaComboTA(at_edad, at_jubilado);
        Ddl_at_ta_id.DataValueField = "ta_id";
        Ddl_at_ta_id.DataTextField = "ta_descripcion";
        Ddl_at_ta_id.DataBind();
    }

    // Cargar gl_tipo_doc
    private void BindDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_id";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Diseño GridView
    protected void GvLista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;
        var tip_reg = e.Row.Cells[1].Text;

        if (!tip_reg.Equals("V"))
        {
            LinkButton lnkBtn = (LinkButton)e.Row.FindControl("BtnEdit");
            lnkBtn.Visible = false;
        }
    }

    // Diseño GridView
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) { GvLista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvLista.FooterRow != null) { GvLista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento GridView
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("GetGlosa"))
        {
            BindDDLTipoDocumentoImpreso();
            Ddl_gl_tipo_doc.Enabled = false;
            Txt_gl_fecha_doc.Enabled = false;
            Txt_gl_glosa.Enabled = false;
            BtnGuardarG.Visible = false;
            _glosa = new cls_glosa();
            var data = _glosa.ObtenerTablaGrilla("", code, "at_id", "tbl_mp_asignacion_tipo_aportante", "", "", "", "", "", "V").Tables[0];

            if (data.Rows.Count > 0)
            {
                Ddl_gl_tipo_doc.SelectedValue = data.Rows[0]["gl_tipo_doc"].ToString().Trim();
                Txt_gl_fecha_doc.Text = Convert.ToDateTime(data.Rows[0]["gl_fecha_doc"]).ToString("dd/MM/yyyy").Trim();
                Txt_gl_glosa.Text = data.Rows[0]["gl_glosa"].ToString().Trim();
                sc = "$('#Txt_gl_fecha_doc').addClass('form-control'); $('#Ddl_gl_tipo_doc').removeClass('select2'); $('#glosaModal').modal('show');";
            }
            else { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no tinene glosa...!!' }, { type: 'warning' });"; }
        }
        else if (e.CommandName.Equals("GetEdit"))
        {
        }

        if (string.IsNullOrEmpty(Lt_ta_lab_cotizacion_mensual.Text) && string.IsNullOrEmpty(Lt_ta_lab_prima_riesgo_comun.Text) && string.IsNullOrEmpty(Lt_ta_lab_comision_afp.Text) && string.IsNullOrEmpty(Lt_ta_lab_solidario.Text) && string.IsNullOrEmpty(Lt_ta_pat_prima_riesgo_prof.Text) && string.IsNullOrEmpty(Lt_ta_pat_caja.Text) && string.IsNullOrEmpty(Lt_ta_pat_provivienda.Text) && string.IsNullOrEmpty(Lt_ta_pat_solidario.Text)) { P_info.Visible = false; }
        else { P_info.Visible = true; }
        SetScript(sc, ", dropdownParent: $('#addModal')");
    }

    // Evento RadioButtonList
    protected void Rbl_at_jubilado_SelectedIndexChanged(object sender, EventArgs e)
    {
        Limpiar("frm_aport_cl");
        var edad = Lt_per_edad.Text.Split(' ');
        var jubi = Rbl_at_jubilado.SelectedValue;
        BindDDLTipoAportante(Convert.ToInt32(edad[0]), Convert.ToBoolean(jubi));
        Ddl_at_ta_id.Enabled = true;

        if (string.IsNullOrEmpty(Lt_ta_lab_cotizacion_mensual.Text) && string.IsNullOrEmpty(Lt_ta_lab_prima_riesgo_comun.Text) && string.IsNullOrEmpty(Lt_ta_lab_comision_afp.Text) && string.IsNullOrEmpty(Lt_ta_lab_solidario.Text) && string.IsNullOrEmpty(Lt_ta_pat_prima_riesgo_prof.Text) && string.IsNullOrEmpty(Lt_ta_pat_caja.Text) && string.IsNullOrEmpty(Lt_ta_pat_provivienda.Text) && string.IsNullOrEmpty(Lt_ta_pat_solidario.Text)) { P_info.Visible = false; }
        else { P_info.Visible = true; }
        SetScript("", "");
    }

    // Evento DropDownList
    protected void Ddl_at_ta_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        _aportante = new cls_mp_asignacion_tipo_aportante();
        var data = _aportante.ObtenerRegistroTA(Convert.ToInt32(Ddl_at_ta_id.SelectedValue)).Tables[0];
        Lt_ta_lab_cotizacion_mensual.Text = (Convert.ToDouble(ValidarCampo(data.Rows[0]["ta_lab_cotizacion_mensual"])) * 100).ToString() + " %";
        Lt_ta_lab_prima_riesgo_comun.Text = (Convert.ToDouble(ValidarCampo(data.Rows[0]["ta_lab_prima_riesgo_comun"])) * 100).ToString() + " %";
        Lt_ta_lab_comision_afp.Text = (Convert.ToDouble(ValidarCampo(data.Rows[0]["ta_lab_comision_afp"])) * 100).ToString() + " %";
        Lt_ta_lab_solidario.Text = (Convert.ToDouble(ValidarCampo(data.Rows[0]["ta_lab_solidario"])) * 100).ToString() + " %";
        Lt_ta_pat_prima_riesgo_prof.Text = (Convert.ToDouble(ValidarCampo(data.Rows[0]["ta_pat_prima_riesgo_prof"])) * 100).ToString() + " %";
        Lt_ta_pat_caja.Text = (Convert.ToDouble(ValidarCampo(data.Rows[0]["ta_pat_caja"])) * 100).ToString() + " %";
        Lt_ta_pat_provivienda.Text = (Convert.ToDouble(ValidarCampo(data.Rows[0]["ta_pat_provivienda"])) * 100).ToString() + " %";
        Lt_ta_pat_solidario.Text = (Convert.ToDouble(ValidarCampo(data.Rows[0]["ta_pat_solidario"])) * 100).ToString() + " %";

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }
        P_info.Visible = true;
        SetScript(sc, "");
    }

    // Alta Tipo Aportante
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        var edad = Lt_per_edad.Text.Split(' ');

        if (Ddl_at_ta_id.SelectedItem.Text.Contains("MAYOR"))
        {
            if (Convert.ToInt32(edad[0]) < 65)
            {
                if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
                else { P_lista.Visible = false; }
                P_info.Visible = true;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'La edad del funcionario(a) no corresponde...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }

        if (Ddl_at_ta_id.SelectedItem.Text.Contains("MENOR"))
        {
            if (Convert.ToInt32(edad[0]) > 65)
            {
                if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
                else { P_lista.Visible = false; }
                P_info.Visible = true;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'La edad del funcionario(a) no corresponde...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }
        BindDDLTipoDocumentoImpreso();
        P_info.Visible = true;
        sc = "$('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Alta Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        _aportante = new cls_mp_asignacion_tipo_aportante();
        _aportante.ObtenerId();
        var codigo = _aportante.at_id;
        _aportante = new cls_mp_asignacion_tipo_aportante
        {
            at_id = codigo,
            at_per_id = Convert.ToInt32(id),
            at_ta_id = Convert.ToInt32(Ddl_at_ta_id.SelectedValue)
        };
        _aportante.Adicionar();
        _glosa = new cls_glosa
        {
            gl_valor_pk = codigo.ToString(),
            gl_nombre_pk = "at_id",
            gl_tabla = "tbl_mp_asignacion_tipo_aportante",
            gl_tipo_mov = 813,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        Limpiar("frm_aport_cl");
        Limpiar("frm_glosa_cl");
        BindGridView(id);

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancelar Alta Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        Ddl_gl_tipo_doc.Enabled = true;
        Txt_gl_fecha_doc.Enabled = true;
        Txt_gl_glosa.Enabled = true;
        BtnGuardarG.Visible = true;

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }

        if (string.IsNullOrEmpty(Lt_ta_lab_cotizacion_mensual.Text) && string.IsNullOrEmpty(Lt_ta_lab_prima_riesgo_comun.Text) && string.IsNullOrEmpty(Lt_ta_lab_comision_afp.Text) && string.IsNullOrEmpty(Lt_ta_lab_solidario.Text) && string.IsNullOrEmpty(Lt_ta_pat_prima_riesgo_prof.Text) && string.IsNullOrEmpty(Lt_ta_pat_caja.Text) && string.IsNullOrEmpty(Lt_ta_pat_provivienda.Text) && string.IsNullOrEmpty(Lt_ta_pat_solidario.Text)) { P_info.Visible = false; }
        else { P_info.Visible = true; }
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Baja Tipo Aportante
    private void BajaTipoAportante(int val_id)
    {
        _aportante = new cls_mp_asignacion_tipo_aportante { at_id = val_id };
        _aportante.Eliminar();
    }

    // Validar Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    // Obtener Edad
    private int Edad(DateTime fecha_nac)
    {
        var age = DateTime.Now.Year - fecha_nac.Year;

        if (fecha_nac.Month > DateTime.Now.Month) { age--; }
        return age;
    }

    // Ejecutar Scriptmanager
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar _MENU_ registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros'," +
                    "'sInfoEmpty': 'Mostrando registros del 0 al 0 de un total de 0 registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ registros)'," +
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
                "'searching': true," +
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
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

    // Limpiar
    private void Limpiar(string val)
    {
        if (val.Equals("frm_aport_cl"))
        {
            Ddl_at_ta_id.Items.Clear();
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}