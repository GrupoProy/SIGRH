using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_ReporteSubsidio : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            hf_ab_id.Value = Request.QueryString["ab_id"].ToString();
            hf_per_id.Value = Request.QueryString["per_id"].ToString();
            cargarProceso();
        }
    }

    private void cargarReporte()
    {
        if (ddlMesPlanilla.Text != "Seleccione..")
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new
            Uri("http://DESKTOP-GUS:8008/ReportServer");
            ReportViewer1.ServerReport.ReportPath =
            "/ReportesUAP/Subsidio";
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("pc_id", ddlMesPlanilla.SelectedValue.ToString(), false));
            paramList.Add(new ReportParameter("per_id", hf_per_id.Value.ToString(), false));
            paramList.Add(new ReportParameter("ab_id", hf_ab_id.Value.ToString(), false));
            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;

            ReportViewer1.ServerReport.Refresh();
        }
    }

    private void cargarProceso()
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlMesPlanilla.DataSource = proceso.ObtenerMesesProceso();
        ddlMesPlanilla.Items.Add("Seleccione..");
        ddlMesPlanilla.DataTextField = "pc_titulo";
        ddlMesPlanilla.DataValueField = "pc_id";
        ddlMesPlanilla.DataBind();
    }

    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarReporte();
        SetScript("");
    }

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_pf_tipo_parentesco').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_genero').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_estado_vivo').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_parentesco_add').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_genero_add').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
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
                    "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });}");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
}