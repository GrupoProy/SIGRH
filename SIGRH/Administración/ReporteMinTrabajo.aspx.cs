using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;


public partial class Administración_ReporteMinTrabajo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarReporte();
        }
    }
    private void CargarReporte()
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;

        if (HttpContext.Current.Session["VerGenerar"] != null && HttpContext.Current.Session["VerGenerar"].ToString() != "")
        {
            ReportViewer1.ServerReport.ReportServerUrl = new
            Uri("http://SERVIDOR-DELL:8008/ReportServer");
            //ReportViewer1.ServerReport.ReportServerUrl = new
            //Uri("http://ANTHRACIS-DESK/ReportServer");
            ReportViewer1.ServerReport.ReportPath = "/ReportesUAP/REPORTE_MINISTERIO_TRABAJO_UAP";
        }

        List<ReportParameter> paramList = new List<ReportParameter>();

        if (HttpContext.Current.Session["pc_id"] != null && HttpContext.Current.Session["pc_id"].ToString() != "")
            paramList.Add(new ReportParameter("MES_GESTION", HttpContext.Current.Session["pc_id"].ToString(), false));

        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;

        ReportViewer1.ServerReport.Refresh();
    }
}