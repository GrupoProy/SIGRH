using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class Kardex_ImpresionVacacionAnual : System.Web.UI.Page
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
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://srv_londra:8008/ReportServer");
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://ANTHRACIS-DESK/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/REPORTE_CERT_VACACION_UAP";
        List<ReportParameter> paramList = new List<ReportParameter>();
        if (HttpContext.Current.Session["vacacion_id"] != null && HttpContext.Current.Session["vacacion_id"].ToString() != "")
            paramList.Add(new ReportParameter("vac_lj", HttpContext.Current.Session["vacacion_id"].ToString(), false));
        if (HttpContext.Current.Session["cod_persona"] != null && HttpContext.Current.Session["cod_persona"].ToString() != "")
            paramList.Add(new ReportParameter("cod_persona", HttpContext.Current.Session["cod_persona"].ToString(), false));

        ReportViewer1.ServerReport.SetParameters(paramList);

        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }
}