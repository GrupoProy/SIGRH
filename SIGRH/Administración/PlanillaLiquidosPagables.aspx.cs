using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class Administración_PlanillaLiquidosPagables : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarMeses();
        }
    }
    private void cargarMeses() {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlMesPlanilla.Items.Clear();
        ddlMesPlanilla.Items.Add("Seleccione...");
        ddlMesPlanilla.DataSource = proceso.ObtenerMesesProceso_Liquidos();
        ddlMesPlanilla.DataTextField = "pc_titulo";
        ddlMesPlanilla.DataValueField = "pc_id";
        ddlMesPlanilla.DataBind();
    }
    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarReporte();
    }

    private void CargarReporte()
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SERVIDOR-DELL:8008/ReportServer");
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://ANTHRACIS-DESK/ReportServer");

        ReportViewer1.ServerReport.ReportPath = 
        "/ReportesUAP/REPORTE_PLANILLA_LIQUIDOS_UAP";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedItem.Text, false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;

        ReportViewer1.ServerReport.Refresh();
    }

}