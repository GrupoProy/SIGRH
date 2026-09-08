using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class Kardex_ImprimirCV : System.Web.UI.Page
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
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://SERVIDOR-DELL:8008/ReportServer");
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://ANTHRACIS-DESK/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/REPORTE_CV_UAP";
        List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("cod_persona", HttpContext.Current.Session["per_id"].ToString(), false));

        ReportViewer1.ServerReport.SetParameters(paramList);

        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }
}