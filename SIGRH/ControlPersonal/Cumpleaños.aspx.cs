using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_Cumpleaños : System.Web.UI.Page
{
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarMes();
        }
    }

    private void cargarMes()
    {
        ddl_mes.Items.Add("SELECCIONE UN MES");
        ddl_mes.Items.Insert(1, new ListItem("ENERO", "1"));
        ddl_mes.Items.Insert(2, new ListItem("FEBRERO", "2"));
        ddl_mes.Items.Insert(3, new ListItem("MARZO", "3"));
        ddl_mes.Items.Insert(4, new ListItem("ABRIL", "4"));
        ddl_mes.Items.Insert(5, new ListItem("MAYO", "5"));
        ddl_mes.Items.Insert(6, new ListItem("JUNIO", "6"));
        ddl_mes.Items.Insert(7, new ListItem("JULIO", "7"));
        ddl_mes.Items.Insert(8, new ListItem("AGOSTO", "8"));
        ddl_mes.Items.Insert(9, new ListItem("SEPTIEMBRE", "9"));
        ddl_mes.Items.Insert(10, new ListItem("OCTUBRE", "10"));
        ddl_mes.Items.Insert(11, new ListItem("NOVIEMBRE", "11"));
        ddl_mes.Items.Insert(12, new ListItem("DICIEMBRE", "12"));
        ddl_mes.DataBind();
    }

    protected void ddl_mes_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void btn_generar_Click(object sender, EventArgs e)
    {
        if (ddl_mes.SelectedItem.Text != "SELECCIONE UN MES")
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new
            Uri("http://DESKTOP-GUS:8008/ReportServer");
            ReportViewer1.ServerReport.ReportPath =
            "/ReportesUAP/Cumpleaños";
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("MES", ddl_mes.SelectedValue, false));
            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;
            ReportViewer1.ServerReport.Refresh();
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-warning', message: 'No hay mes seleccionado'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
        }
        SetScript("");
    }

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append("var me = $('.accountBank'); me.mask('9-00000-99999999'); ");

        sb.Append(data);
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
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
            "'sNext': '<i class=" + '"' + "fas fa-angle-right" + '"' + "></i>'," +
            "'sPrevious': '<i class=" + '"' + "fas fa-angle-left" + '"' + "></i>'" +
            "}," +
            "'oAria': {" +
            "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
            "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
            "}" +
            "}," +
            "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
}