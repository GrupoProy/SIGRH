using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Administración_Reportes : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarTipoPersonal();
        }
    }
    private void CargarTipoPersonal() {
        ddlTipoPersonal.Items.Add("Seleccione tipo de Personal");
        ddlTipoPersonal.Items.Add("Administrativo");
        ddlTipoPersonal.Items.Add("Docente");
        ddlTipoPersonal.DataBind();
    }
    private void CargarReporte() {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SERVIDOR-DELL:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/Reporte_UAP_V1";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("MES_GESTION", "247", false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;

        ReportViewer1.ServerReport.Refresh();
    }
    private void CargarMeses() {
        ddlMesPlanilla.Items.Add("OCTUBRE 2021");
        ddlMesPlanilla.Items.Add("NOVIEMBRE 2021");

    }
    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SERVIDOR-DELL:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/Reporte_UAP_V3";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedItem.Text, false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;

        ReportViewer1.ServerReport.Refresh();
    }

    protected void ddlTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tipoPersonal = "";
        if (ddlTipoPersonal.SelectedItem.Text!= "Seleccione tipo de Personal")
        {
            if (ddlTipoPersonal.SelectedItem.Text == "Administrativo")
                tipoPersonal = "Reporte_UAP_V1";
            if (ddlTipoPersonal.SelectedItem.Text == "Docente")
                tipoPersonal = "Reporte_UAP_V2";
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SERVIDOR-DELL:8008/ReportServer");
            ReportViewer1.ServerReport.ReportPath =
            "/ReportesUAP/" + tipoPersonal;
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("MES_GESTION", "247", false));
            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;

            ReportViewer1.ServerReport.Refresh();

        }
    }
}