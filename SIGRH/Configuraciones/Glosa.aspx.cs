using Newtonsoft.Json;
using Solution_Framework_General.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenimiento_Glosa : System.Web.UI.Page
{
    private cls_historico _historico = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa _glosa = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                CargaGVGlosa();

                if (Gv_glosa_lista.Rows.Count > 0) { P_glosa_lista.Visible = true; }
                else { P_glosa_lista.Visible = false; }
            }
        }
        else { Response.Redirect("../Index"); }
    }

    // Carga La Información De La Glosa
    private void CargaInformacionGlosa(string var_id)
    {
        _glosa = new cls_glosa();
        var var_datosG = _glosa.ObtenerTablaGrillaC(var_id, "", "", "", "", "", "", "", "", "").Tables[0];

        if (var_datosG.Rows.Count > 0)
        {
            Hf_gl_id.Value = var_datosG.Rows[0]["gl_id"].ToString();
            LT_gl_valor_pk.Text = var_datosG.Rows[0]["gl_valor_pk"].ToString();
            Lt_gl_nombre_pk.Text = var_datosG.Rows[0]["gl_nombre_pk"].ToString();
            Lt_gl_tabla.Text = var_datosG.Rows[0]["gl_tabla"].ToString();
            Lt_gl_tipo_mov.Text = var_datosG.Rows[0]["cat_descripcion_tm"].ToString();
            Lt_gl_numero_doc.Text = var_datosG.Rows[0]["gl_numero_doc"].ToString();
            Lt_gl_estado.Text = var_datosG.Rows[0]["gl_estado"].ToString();
            Ddl_gl_tipo_doc.SelectedValue = var_datosG.Rows[0]["gl_tipo_doc"].ToString();
            Txt_gl_fecha_doc.Text = Convert.ToDateTime(var_datosG.Rows[0]["gl_fecha_doc"]).ToString("dd/MM/yyyy");
            Txt_gl_glosa.Text = var_datosG.Rows[0]["gl_glosa"].ToString();
        }
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

    // Carga Datos En El GridView (Gv_glosa_lista)
    private void CargaGVGlosa()
    {
        try
        {
            _glosa = new cls_glosa();
            Gv_glosa_lista.DataSource = _glosa.ObtenerTablaGrillaC("", "", "", "", "", "", "", "", "", "");
            Gv_glosa_lista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño Del GridView (Gv_glosa_lista)
    protected void Gv_glosa_lista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_glosa_lista.Rows.Count > 0)
        {
            if (Gv_glosa_lista.HeaderRow != null) { Gv_glosa_lista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_glosa_lista.FooterRow != null) { Gv_glosa_lista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del GridView (Gv_glosa_lista)
    protected void Gv_glosa_lista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int var_indice = Convert.ToInt32(e.CommandArgument);
        string var_codigo = Gv_glosa_lista.DataKeys[var_indice].Value.ToString();

        if (e.CommandName.Equals("BtnEditar"))
        {
            CargaDDLTipoDocumento();
            CargaInformacionGlosa(var_codigo);
            sc = "$('#glosaModal').modal('show');";
        }
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Alta De Los Datos De Glosa
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        _glosa = new cls_glosa();
        var var_datosG = _glosa.ObtenerTablaGrilla(Hf_gl_id.Value.Trim(), "", "", "", "", "", "", "", "", "").Tables[0];

        if (var_datosG.Rows.Count > 0)
        {
            string json = JsonConvert.SerializeObject(var_datosG);
            AdicionarHistorico("M", "tbl_glosa", "gl_id", Hf_gl_id.Value.Trim(), json);
        }
        _glosa = new cls_glosa
        {
            gl_id = Convert.ToInt32(Hf_gl_id.Value.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"])
        };
        _glosa.Actualizar();
        CargaGVGlosa();
        Limpiar("frm_glosa_cl");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro actualizado correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela La Alta De Los Datos De Glosa
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Alta De Los Datos Del Tipo Ítem En Histórico
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

    // Limpia Los Campos
    private void Limpiar(string val)
    {
        if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}