using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administración_ReporteAcreedores : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string pc_id = Request.QueryString["mes"].ToString();
            string plani = Request.QueryString["planilla"].ToString();
            cargarReporte(Convert.ToInt32(pc_id), Convert.ToInt32(plani));
        }
    }

    private void cargarReporte(int pc_id, int nro_planilla)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SRV_LONDRA:8008/ReportServer");
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://ANTHRACIS-DESK/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/Otros_Acreedores";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("CODMES", pc_id.ToString(), false));
        paramList.Add(new ReportParameter("NROPLANILLA", nro_planilla.ToString(), false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }
}