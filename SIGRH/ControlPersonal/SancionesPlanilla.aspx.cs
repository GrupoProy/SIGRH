using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_SancionesPlanilla : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                BindDDL_();
                BindDDL__();
                BindDDL___();
                //sc = "CopiarCortarPegar(true);";
                //SetScript(sc, "");
            }
        }
        else Response.Redirect("../Index");
    }

    // Cargar DropDownList
    private void BindDDL_()
    {
        Ddl_.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_.Items.Insert(1, new ListItem("PLANILLA DE ASISTENCIA", "1"));
        Ddl_.Items.Insert(2, new ListItem("FUNCIONARIOS QUE FALTARON", "2"));
        Ddl_.Items.Insert(3, new ListItem("FUNCIONARIOS QUE FALTARON MEDIO DÍA", "3"));
        Ddl_.DataBind();
    }

    // Cargar DropDownList
    private void BindDDL__()
    {
        Ddl__.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl__.Items.Insert(1, new ListItem("42 - 16/09/2020 - 08/10/2020", "1"));
        Ddl__.Items.Insert(2, new ListItem("41 - 16/08/2020 - 15/09/2020", "2"));
        Ddl__.Items.Insert(3, new ListItem("40 - 16/07/2020 - 15/08/2020", "3"));
        Ddl__.DataBind();
    }

    // Cargar DropDownList
    private void BindDDL___()
    {
        Ddl___.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl___.Items.Insert(1, new ListItem("FORTALECIMIENTO DE SALUD MUNICIPAL HOSPITAL LA PAZ (26 - 144 - 20 - 0 - 10)", "1"));
        Ddl___.Items.Insert(2, new ListItem("SERVICIO DE SALUD UNIVARSAL Y GRATUITA - SUS (26 - 144 - 20 - 0 - 99)", "2"));
        Ddl___.Items.Insert(3, new ListItem("SERVICIO DE ATENCIÓN ESPECIALIZADA CARDIOLOGÍA (S.U.S.) HOSPITAL LA PAZ (26 - 144 - 20 - 0 - 103)", "3"));
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
                "'searching': " + valB + "," +
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': " + valT + "" +
            "});");
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
}