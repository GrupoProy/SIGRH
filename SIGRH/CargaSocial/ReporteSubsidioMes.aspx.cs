using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CargaSocial_ReporteSubsidioMes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarReporte();
        }
    }

    private void cargarReporte()
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SRV_LONDRA:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/ReporteeSubsidio";
        List<ReportParameter> paramList = new List<ReportParameter>();
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }
}