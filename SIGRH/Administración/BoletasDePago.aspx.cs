using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class Administración_BoletasDePago : System.Web.UI.Page
{
    public string pc_id = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarMeses();
            CargarTipoPersonal();
            CargarTipoTrabajo();
        }
    }
    private void CargarTipoPersonal()
    {
        ddlTipoPersonal.Items.Add("Seleccione tipo de Personal");
        ddlTipoPersonal.Items.Add("Administrativo");
        ddlTipoPersonal.Items.Add("Docente");
        ddlTipoPersonal.DataBind();
    }
    private void CargarTipoTrabajo()
    {
        ddlTipoTrabajo.Items.Add("Seleccione tipo de Trabajo");
        ddlTipoTrabajo.Items.Add("Planta");
        ddlTipoTrabajo.Items.Add("Eventual");
        ddlTipoTrabajo.DataBind();
    }
    private void CargarMeses()
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlMesPlanilla.Items.Add("Seleccione el Mes");
        ddlMesPlanilla.DataSource = proceso.ObtenerMesesProceso();
        ddlMesPlanilla.DataTextField = "pc_titulo";
        ddlMesPlanilla.DataValueField = "pc_id";
        ddlMesPlanilla.DataBind();
    }
    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        DivTipoPersonal.Visible = true;
    }

    protected void ddlTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
    {
        DivTipoTrabajo.Visible = true;
    }
    protected void ddlTipoTrabajo_SelectedIndexChanged(object sender, EventArgs e)
    {
        divBtn.Visible = true;
    }
    private void CargarReporte()
    {
        string tipoPersonal = ""; string tipoTrabajo = "";
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        pc_id = ddlMesPlanilla.SelectedValue;//pla_proceso.ObtenerSalarioMinimo().Tables[0].Rows[0]["pc_id"].ToString();

        if (ddlMesPlanilla.SelectedItem.Text!= "Seleccione el Mes" && ddlTipoPersonal.SelectedItem.Text != "Seleccione tipo de Personal" && ddlTipoTrabajo.SelectedItem.Text!= "Seleccione tipo de Trabajo")
        {
            if (ddlTipoPersonal.SelectedItem.Text == "Administrativo")
                tipoPersonal = "Boletas_UAP_ADM";
            if (ddlTipoPersonal.SelectedItem.Text == "Docente")
                tipoPersonal = "Boletas_UAP_DOC";
            if (ddlTipoTrabajo.SelectedItem.Text == "Planta")
                tipoTrabajo = "PLANTA";
            if (ddlTipoTrabajo.SelectedItem.Text == "Eventual")
                tipoTrabajo = "EVENTUAL";
            tipoPersonal = tipoPersonal + "_" + tipoTrabajo;
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            
            ReportViewer1.ServerReport.ReportServerUrl = new
            Uri("http://SERVIDOR-DELL:8008/ReportServer");
            //ReportViewer1.ServerReport.ReportServerUrl = new
            //Uri("http://ANTHRACIS-DESK/ReportServer");
            ReportViewer1.ServerReport.ReportPath =
            "/ReportesUAP/" + tipoPersonal;
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedValue, false));
            //paramList.Add(new ReportParameter("SECUENCIAL", "1", false));
ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;
            ReportViewer1.ServerReport.Refresh();

        }
    }


    protected void btnVerReporte_Click(object sender, EventArgs e)
    {
        CargarReporte();
    }
}