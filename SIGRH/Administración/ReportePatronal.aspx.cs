using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administración_ReportePatronal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string pc_id = Request.QueryString["id"].ToString();
            string planilla = Request.QueryString["planilla"].ToString();
            cargarReporte(pc_id, planilla);
        }
    }

    private void cargarReporte(string pc_id, string plani_nro)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SRV_LONDRA:8008/ReportServer");
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://ANTHRACIS-DESK/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/REPORTE_CONTABILIDAD";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("CODMES", pc_id, false));
        paramList.Add(new ReportParameter("NROPLANILLA", plani_nro.ToString(), false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }

}