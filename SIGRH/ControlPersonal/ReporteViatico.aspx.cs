using Microsoft.Reporting.WebForms;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_ReporteViatico : System.Web.UI.Page
{
    cls_cp_viatico viatico = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarNroPlanilla();
        }
    }

    private void cargarNroPlanilla()
    {
        viatico = new cls_cp_viatico();
        ddl_nro_planilla.Items.Clear();
        ddl_nro_planilla.Items.Add("SELECCIONAR");
        ddl_nro_planilla.DataSource = viatico.NroPlanillaCombo(Convert.ToInt32(HttpContext.Current.Session["pr_id"].ToString()));
        ddl_nro_planilla.DataTextField = "nro_pla";
        ddl_nro_planilla.DataValueField = "vi_nro_planilla";
        ddl_nro_planilla.DataBind();
    }

    public void cargarReporte()
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SRV_LONDRA:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/Viaticos";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("NRO_PLANILLA", ddl_nro_planilla.SelectedValue, false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }

    protected void ddl_nro_planilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_nro_planilla.Text != "SELECCIONAR")
        {
            cargarReporte();
        }
    }
}