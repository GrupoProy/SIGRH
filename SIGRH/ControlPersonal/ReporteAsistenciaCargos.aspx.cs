using System;
using System.Collections.Generic;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class ControlPersonal_ReporteAsistenciaCargos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarMes();
            CargarReporte();
        }
    }
    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedItem.Text != "")
            CargarReporte();
    }

    private void CargarMes()
    {
        cls_cp_sanciones sanciones = new cls_cp_sanciones();
        ddlMesPlanilla.DataSource = sanciones.ListarMesesParaSancion();
        ddlMesPlanilla.DataTextField = "pc_titulo";
        ddlMesPlanilla.DataValueField = "pc_id";
        ddlMesPlanilla.DataBind();
    }
    private void CargarReporte()
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://desktop-gus/:8008/ReportServer");
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://ANTHRACIS-DESK/ReportServer");

        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/REPORTE_SANCIONES_PROCESADO_UAP";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("cod_proceso", ddlMesPlanilla.SelectedValue, false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;

        ReportViewer1.ServerReport.Refresh();
    }

}