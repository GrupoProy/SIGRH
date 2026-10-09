using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovimientoPersonal_IncompatibilidadFuncionaria : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_glosa _glosa = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_mp_incompatibilidad_fun _incompatibilidad_fun = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                CargaInfoFuncionario(id);
                CargaGVIncompatibilidadFunc(id);
            }
        }
        else Response.Redirect("../Index");
    }

    // Carga La Información Del Funcionario
    private void CargaInfoFuncionario(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (var_datos_as_c.Rows.Count > 0)
        {
            Lt_per_nombres.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_nombres"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_num_doc"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["cat_abreviacion"]);
            Lt_per_id.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_id"]);
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

            if (ValidarCampo(var_datos_as_c.Rows[0]["fp_foto"]) != "") Img_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])var_datos_as_c.Rows[0]["fp_foto"]);
            else if (ValidarCampo(var_datos_as_c.Rows[0]["per_sexo"]).Equals("M")) Img_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg";
            else Img_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg";
        }
    }

    // Carga La Información Del Funcionario Con Parentesco
    private void CargaInfoParentesco(string if_per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", if_per_id, "", "", "", "V", "", "", "", "", "", "", "", "").Tables[0];

        if (var_datos_as_c.Rows.Count > 0)
        {
            Lt_if_per_nombres.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_nombres"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_materno"]);
            Lt_if_per_num_doc.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_num_doc"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["cat_abreviacion"]);
            Lt_if_per_id.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_id"]);
            Lt_if_ca_num_item.Text = ValidarCampo(var_datos_as_c.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["ca_num_item"]);
            Lt_if_as_fecha_inicio.Text = Convert.ToDateTime(ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_inicio"])).ToString("dd/MM/yyyy");
            Lt_if_as_fecha_fin.Text = (ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_fin"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_fin"])).ToString("dd/MM/yyyy");
            Lt_if_eo_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["eo_descripcion"]);
            Lt_if_cp_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["cp_descripcion"]);

            if (ValidarCampo(var_datos_as_c.Rows[0]["as_estado"]).Equals("V"))
            {
                Lbl_if_as_estado.Text = "Vigente";
                Lbl_if_as_estado.CssClass = "btn btn-sm btn-info float-right";
            }
            else
            {
                Lbl_if_as_estado.Text = "Pasivo";
                Lbl_if_as_estado.CssClass = "btn btn-sm btn-secondary float-right";
            }

            if (ValidarCampo(var_datos_as_c.Rows[0]["fp_foto"]) != "") Img_if_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])var_datos_as_c.Rows[0]["fp_foto"]);
            else if (ValidarCampo(var_datos_as_c.Rows[0]["per_sexo"]).Equals("M")) Img_if_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg";
            else Img_if_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg";
        }
    }

    // Carga Datos En El DropDownList (Ddl_if_parentesco)
    private void CargaDDLParentesco()
    {
        _catalogo = new cls_catalogo { cat_tabla = "parentesco" };
        Ddl_if_parentesco.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_if_parentesco.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_if_parentesco.DataValueField = "cat_secuencial";
        Ddl_if_parentesco.DataTextField = "cat_descripcion";
        Ddl_if_parentesco.DataBind();
    }

    // Carga Datos En El DropDownList (Ddl_gl_tipo_doc)
    private void CargaDDLTipoDocumento()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Carga Datos En El GridView (Gv_inc_fun)
    private void CargaGVIncompatibilidadFunc(string varId)
    {
        try
        {
            _asignacion = new cls_mp_asignacion();
            var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", varId, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];
            _incompatibilidad_fun = new cls_mp_incompatibilidad_fun();
            Gv_inc_fun.DataSource = _incompatibilidad_fun.ObtenerTablaGrillaC(varId, ValidarCampo(var_datos_as_c.Rows[0]["per_ap_paterno"]), ValidarCampo(var_datos_as_c.Rows[0]["per_ap_materno"]));
            Gv_inc_fun.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño Del GridView (Gv_inc_fun)
    protected void Gv_inc_fun_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_inc_fun.Rows.Count > 0)
        {
            if (Gv_inc_fun.HeaderRow != null) { Gv_inc_fun.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_inc_fun.FooterRow != null) { Gv_inc_fun.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Diseño Del GridView (Gv_inc_fun)
    protected void Gv_inc_fun_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) { return; }

        var var_per_id = e.Row.Cells[0].Text;
        Panel P_nuevo_registro = (Panel)e.Row.FindControl("P_nuevo_registro");
        LinkButton Btn_ver_registro = (LinkButton)e.Row.FindControl("Btn_ver_registro");
        _incompatibilidad_fun = new cls_mp_incompatibilidad_fun();
        var dataIF = _incompatibilidad_fun.ObtenerTablaGrilla("", "", var_per_id, "", "V").Tables[0];

        if (dataIF.Rows.Count > 0)
        {
            P_nuevo_registro.Visible = false;
            Btn_ver_registro.Visible = true;
        }
        else
        {
            P_nuevo_registro.Visible = true;
            Btn_ver_registro.Visible = false;
        }
    }

    // Evento Del GridView (Gv_inc_fun)
    protected void Gv_inc_fun_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        int index = Convert.ToInt32(e.CommandArgument);
        string code = Gv_inc_fun.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("Btn_ver_registro"))
        {
            _incompatibilidad_fun = new cls_mp_incompatibilidad_fun();
            var dataIF = _incompatibilidad_fun.ObtenerTablaGrilla("", id, code, "", "V").Tables[0];

            if (dataIF.Rows.Count > 0)
            {
                P_if_parentesco_frm.Visible = false;
                P_if_parentesco_v.Visible = true;
                BtnGuardarP.Visible = false;
                CargaInfoParentesco(code);
                Lt_if_parentesco.Text = dataIF.Rows[0]["cat_descripcion"].ToString();
                sc = "$('#parentescoModal').modal('show');";
            }
            else { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El funcionario no tiene registro de incompatibilidad funcionaria...!!' }, { type: 'warning' });"; }
        }
        SetScript(sc, "");
    }

    // Evento Del CheckBox Que Se Encuentra En El GridView (Gv_inc_fun)
    protected void Chk_nuevo_registro_CheckedChanged(object sender, EventArgs e)
    {
        foreach (GridViewRow item in Gv_inc_fun.Rows)
        {
            CheckBox var_chk_nuevo_registro = (CheckBox)item.FindControl("Chk_nuevo_registro");

            if (var_chk_nuevo_registro.Checked)
            {
                var var_if_per_id = item.Cells[0].Text.Trim();
                P_if_parentesco_frm.Visible = true;
                P_if_parentesco_v.Visible = false;
                CargaInfoParentesco(var_if_per_id);
                CargaDDLParentesco();
                sc = "$('#parentescoModal').modal('show');";
            }
        }
        SetScript(sc, ", dropdownParent: $('#parentescoModal')");
    }

    // Alta De Los Datos Del Funcionario Con Parentesco
    protected void BtnGuardarP_Click(object sender, EventArgs e)
    {
        CargaDDLTipoDocumento();
        sc = "$('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Cancela La Alta De Los Datos Del Funcionario Con Parentesco
    protected void BtnCancelarP_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        BtnGuardarP.Visible = true;
        CargaGVIncompatibilidadFunc(id);
        Limpiar("frm_if_cl");
        sc = "$('#parentescoModal').modal('hide');";
        SetScript(sc, "");
    }

    // Alta De Los Datos De Incompatibilidad Funcionaria Y Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        _incompatibilidad_fun = new cls_mp_incompatibilidad_fun
        {
            if_per_id = Convert.ToInt32(id),
            if_per_id_pariente = Convert.ToInt32(Lt_if_per_id.Text.Trim()),
            if_parentesco = Convert.ToInt32(Ddl_if_parentesco.SelectedValue)
        };
        var var_if_id = _incompatibilidad_fun.Adicionar();
        _glosa = new cls_glosa
        {
            gl_valor_pk = var_if_id.ToString(),
            gl_nombre_pk = "if_id",
            gl_tabla = "tbl_mp_incompatibilidad_fun",
            gl_tipo_mov = 813,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        CargaGVIncompatibilidadFunc(id);
        Limpiar("frm_if_cl");
        Limpiar("frm_glosa_cl");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal, #parentescoModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela Alta De Los Datos De Incompatibilidad Funcionaria Y Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, ", dropdownParent: $('#parentescoModal')");
    }

    // Valida Los Campos
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
                "'searching': true," + // Permite mostrar/ocultar el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" + // Permite mostrar/ocultar el campo de información
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

    // Limpia Los Campos
    private void Limpiar(string val)
    {
        if (val.Equals("frm_if_cl"))
        {
            Ddl_if_parentesco.Items.Clear();
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}