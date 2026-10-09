using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DescriptorPuesto_ReporteResultado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string pu_id = Request.QueryString["id"].ToString();
            cargarReporteViatico(pu_id);
        }
    }

    private void cargarReporteViatico(string pu_id)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SRV_LONDRA:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/evaluación_resultados";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("descrip_pu_id", pu_id, false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }
}