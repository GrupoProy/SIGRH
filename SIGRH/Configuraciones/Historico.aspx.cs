using Solution_Framework_General.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovimientoPersonal_Historico : System.Web.UI.Page
{
    private cls_historico _historico = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                CargaGVHistorico();

                if (Gv_historico_lista.Rows.Count > 0) { P_historico_lista.Visible = true; }
                else { P_historico_lista.Visible = false; }
            }
        }
        else { Response.Redirect("../Index"); }
    }

    // Carga La Información Del Histórico
    private void CargaInformacionHistorico(string par_id)
    {
        
    }

    // Carga Datos En El GridView (Gv_historico_lista)
    private void CargaGVHistorico()
    {
        try
        {
            _historico = new cls_historico();
            Gv_historico_lista.DataSource = _historico.ObtenerTablaGrilla("", "", "", "", "", "", "", "");
            Gv_historico_lista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño Del GridView (Gv_historico_lista)
    protected void Gv_historico_lista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_historico_lista.Rows.Count > 0)
        {
            if (Gv_historico_lista.HeaderRow != null) { Gv_historico_lista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_historico_lista.FooterRow != null) { Gv_historico_lista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del GridView (Gv_historico_lista)
    protected void Gv_historico_lista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int var_indice = Convert.ToInt32(e.CommandArgument);
        string var_codigo = Gv_historico_lista.DataKeys[var_indice].Value.ToString();

        if (e.CommandName.Equals(""))
        {
            
        }
        SetScript(sc, ", dropdownParent: $('Modal')");
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
        
    }
}