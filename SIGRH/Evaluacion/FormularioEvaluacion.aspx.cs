using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

public partial class Evaluacion_FormularioEvaluacion : System.Web.UI.Page
{
    private string id_evaluacion;
    protected void Page_Load(object sender, EventArgs e)
    {
        id_evaluacion = Convert.ToString(HttpContext.Current.Session["id_evaluacion"]);

        if (!Page.IsPostBack)
        {
            cargarFormulario(id_evaluacion);
        }
    }

    private void cargarFormulario(string id_evaluacion)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SRV_LONDRA:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/Formulario_Evaluacion_UAP_new";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("id_evaluacion", id_evaluacion, false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }

}