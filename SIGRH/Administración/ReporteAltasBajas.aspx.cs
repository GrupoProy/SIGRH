using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Globalization;
using System.Data;
using Solution_Framework_Salarios.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Text;
public partial class Administración_ReporteAltasBajas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                CargarUnidades();
                CargarItems();
            }
            else SetScript("", "");

        }
        else
        {
            Response.Redirect("../index");
        }

    }
    protected void CargarUnidades() {
        cls_pla_docente_horas unidades = new cls_pla_docente_horas();
        ddlUnidad.Items.Add("TODAS");
        ddlUnidad.DataSource = unidades.UnidadesOrganizacionalesAltasBajas();
        ddlUnidad.DataTextField = "UNIDAD";
        ddlUnidad.DataValueField = "unidad_id";
        ddlUnidad.DataBind();
    }
    protected void CargarItems() {
        cls_mp_tipo_item item = new cls_mp_tipo_item();
        ddlItem.Items.Add("TODOS");
        ddlItem.DataSource = item.TipoItemAltasBajas();
        ddlItem.DataTextField = "ti_descripcion";
        ddlItem.DataValueField = "ti_item";
        ddlItem.DataBind();
    }
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SERVIDOR-DELL:8008/ReportServer");
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://ANTHRACIS-DESK/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/REPORTE_ALTA_BAJA_UAP";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("MOVIMIENTO", ddlMesPlanilla.SelectedItem.Text, false));
        //paramList.Add(new ReportParameter("FECHA_1", Convert.ToDateTime(txtFechaInicio.Text).Month + "/" + Convert.ToDateTime(txtFechaInicio.Text).Day + "/" + Convert.ToDateTime(txtFechaInicio.Text).Year, false));
        //paramList.Add(new ReportParameter("FECHA_2", Convert.ToDateTime(txtFechaFin.Text).Month + "/" + Convert.ToDateTime(txtFechaFin.Text).Day + "/" + Convert.ToDateTime(txtFechaFin.Text).Year, false));


        paramList.Add(new ReportParameter("FECHA_1", txtFechaInicio.Text, false));
        paramList.Add(new ReportParameter("FECHA_2", txtFechaFin.Text, false));
        if (ddlUnidad.SelectedItem.Text=="TODAS")
            paramList.Add(new ReportParameter("UNIDAD", "0", false));
        else
            paramList.Add(new ReportParameter("UNIDAD", ddlUnidad.SelectedValue, false));
        if(ddlItem.SelectedItem.Text=="TODOS")
            paramList.Add(new ReportParameter("ITEM", "TODOS", false));
        else
            paramList.Add(new ReportParameter("ITEM", ddlItem.SelectedValue, false));


        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;

        ReportViewer1.ServerReport.Refresh();
        SetScript("","");
    }
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
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" +
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
                "$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: 'es'" +
                    "});" +
                "});" +
                "var me = $(\".datepickerD\");" +
                "me.mask('99/99/9999');" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

}