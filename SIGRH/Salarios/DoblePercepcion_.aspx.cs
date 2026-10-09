using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salarios_DoblePercepcion_ : System.Web.UI.Page
{
    private cls_persona _persona = null;
    //private cls_mp_asignacion _asignacion = null;
    //private cls_situacion_persona _situacion = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack) { }
        }
        else { Response.Redirect("../Index"); }
    }

    // Carga Datos En La Lista De Búsqueda
    //private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom, string varCas)
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom)
    {
        try
        {
            _persona = new cls_persona();
            //GvLista.DataSource = _persona.ObtenerTablaGrilla(varId, "", varCed, "", varPat, varMat, varNom, varCas, "", "", "", "", "", "");
            GvLista.DataSource = _persona.ObtenerTablaGrilla(varId, "", varCed, "", varPat, varMat, varNom, "", "", "", "", "", "", "");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño De La Lista De Búsqueda
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) { GvLista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvLista.FooterRow != null) { GvLista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento De La Lista De Búsqueda
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //_asignacion = new cls_mp_asignacion();
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();
        if (e.CommandName.Equals("GetNew")) { Response.Redirect("RegistroDoblePercepcion?id=" + code); }
        SetScript(sc);
    }

    // Busca Registros De Acuerdo A Los Parámetros && string.IsNullOrEmpty(Txt_per_ap_casada_b.Text)
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });";
        else
        {
            //BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_per_ap_casada_b.Text.Trim());
            BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());
            Limpiar("sch_cl");

            if (GvLista.Rows.Count > 0) { P_result.Visible = true; }
            else
            {
                P_result.Visible = false;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
            }
        }
        SetScript(sc);
    }

    // Ejecuta Scripts
    private void SetScript(string data)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
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
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Limpia Los Campos
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
    }
}