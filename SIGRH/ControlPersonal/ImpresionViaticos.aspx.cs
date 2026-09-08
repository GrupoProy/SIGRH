using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_ImpresionViaticos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string nro_planilla = Request.QueryString["id"].ToString();
            cargarReporteViatico(nro_planilla);
        }
    }

    private void cargarReporteViatico(string nro_pla)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SRV_LONDRA:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/Viaticos";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("NRO_PLANILLA", nro_pla, false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }
}