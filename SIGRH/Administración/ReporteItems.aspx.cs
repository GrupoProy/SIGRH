using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Administración_ReporteItems : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarEstadoItems();
        }
    }
    private void CargarEstadoItems()
    {
        ddlMesPlanilla.Items.Add("Seleccionar...");
        ddlMesPlanilla.Items.Add("ACEFALO");
        ddlMesPlanilla.Items.Add("OCUPADO");
    }
    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedItem.Text != "Seleccionar...")
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SERVIDOR-DELL:8008/ReportServer");
            ReportViewer1.ServerReport.ReportPath =
            "/ReportesUAP/REPORTE_ITEMS_UAP";
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("I_ESTADO", ddlMesPlanilla.SelectedItem.Text, false));
            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;

            ReportViewer1.ServerReport.Refresh();
        }
    }
}