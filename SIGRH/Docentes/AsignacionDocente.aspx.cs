using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;

public partial class Docentes_AsignacionDocente : System.Web.UI.Page
{
    private cls_persona _persona = null;
    private cls_persona_domicilio _domicilio = null;
    private cls_persona_familiares _familiar = null;
    private string sc = "";
    private cls_historico _historico = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa _glosa = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_mp_cargo _cargo = null;
    private cls_situacion_persona _situacion = null;
    private cls_mp_incompatibilidad_fun _incompatibilidad = null;
    private cls_mp_cargo cargo = null;
    private cls_materia materia = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {

            }
        }
        else Response.Redirect("../Index");
    }

    private void CargarAsignaciones(int per_id)
    {
        cls_cp_sanciones sanciones = new cls_cp_sanciones();

        ddl_asignacion_edit.Items.Clear();
        ddl_asignacion_edit.DataSource = sanciones.ListarAsignacionesParaSancion(Convert.ToInt32(per_id));
        ddl_asignacion_edit.DataTextField = "cargo_compuesto";
        ddl_asignacion_edit.DataValueField = "as_ca_id";
        ddl_asignacion_edit.DataBind();
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
        _persona = new cls_persona();
        if (e.Row.RowType != DataControlRowType.DataRow) { return; }
        _asignacion = new cls_mp_asignacion();
        var index = Convert.ToInt32(e.Row.DataItemIndex);
        var id = GvLista.DataKeys[index].Value.ToString();
        var var_datos_as_c = _persona.ObtenerTablaGrilla(Txt_per_id_b.Text.Trim(), "", Txt_per_num_doc_b.Text.Trim(), "", Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(),"", "", "", "", "", "", "").Tables[0];
        
    }
    //Cargar Areas

    // Evento Del GridView (GvLista)
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();
        Limpiar("frm_bj_cl");
        Limpiar("frm_glosa_cl");
        if (e.CommandName.Equals("GetAsig"))
        {
                Response.Redirect("AsignacionMateria.aspx?id=" + code);
                CargarAsignaciones(Convert.ToInt32(code));
                BindFormEdit(code);
                sc = "$('#modificarAsig').modal('show');";
                SetScript(sc, ", dropdownParent: $('#modificarAsig')");
            
        }
        else if (e.CommandName.Equals("GetBaja"))
        {

            sc = "$('#bajaModal').modal('show');";
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

    // buscar && string.IsNullOrEmpty(Txt_per_ap_casada_b.Text)
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });"; }
        else
        {
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

    // Limpiar
    private void Limpiar(string val)
    {
        if (val.Equals("sch_cl"))
        {
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
        }
    }

    protected void ddl_asignacion_edit_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_mp_asignacion asignacion = new cls_mp_asignacion();
        string code = ltl_cod_fun.Text;
        string vv = asignacion.ObtenerTablaGrilla("", code, ddl_asignacion_edit.SelectedValue, "", "", "", "", "", "", "", "", "", "", "").Tables[0].Rows[0]["as_id"].ToString();
        if (asignacion.ObtenerTablaGrilla("", code, ddl_asignacion_edit.SelectedValue, "", "", "", "", "", "", "", "", "", "", "").Tables[0].Rows[0]["as_id"].ToString() != "S")
        {
            BindFormEdit(code);
            sc = "$('#modificarAsig').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#modificarAsig').modal('show');";
            SetScript(sc, ", dropdownParent: $('#modificarAsig')");
        }
        else
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El item se encuentra validado para el proceso de sueldos y no puede modificarse...' }, { type: 'warning' });";
    }

    protected void ddl_plan_SelectedIndexChanged(object sender, EventArgs e)
    {
        materia = new cls_materia();
        materia.p_id = Convert.ToInt32(ddl_plan.SelectedValue);
        ddl_materia.DataSource = materia.Listar();
        ddl_materia.DataValueField = "mat_id";
        ddl_materia.DataTextField = "mat_nombre";
        ddl_materia.DataBind();
    }
}