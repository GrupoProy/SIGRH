using System;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluacion_InformeActividadesRpt : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string id_evaluacion = Request.QueryString["id_evaluacion"].ToString();
            cargarModeloInforme(id_evaluacion);
        }
    }

    private void cargarModeloInforme(string id_evaluacion)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SRV_LONDRA:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/Informe_actividades";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("v_id_evaluacion", id_evaluacion, false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }
}