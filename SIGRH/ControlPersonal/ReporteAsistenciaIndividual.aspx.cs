using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Globalization;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;

public partial class ControlPersonal_ReporteAsistenciaIndividual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        //cls_cp_licencia_justificada licencia = new cls_cp_licencia_justificada();
        //licencia.GenerarAsistencia_UpdateFaltas___LicenciasJustificadas(Convert.ToInt32(HttpContext.Current.Session["per_id_reporte"].ToString()), txtFechaInicio.Text, txtFechaFin.Text);
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new
            Uri("http://10.0.0.31:8008/ReportServer");
            //ReportViewer1.ServerReport.ReportServerUrl = new
            //Uri("http://ANTHRACIS-DESK/ReportServer");
            ReportViewer1.ServerReport.ReportPath =
            "/ReportesUAP/REPORTE_ASISTENCIA_UAP";
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("cod_persona", HttpContext.Current.Session["per_id_reporte"].ToString(), false));
            paramList.Add(new ReportParameter("f_ini", txtFechaInicio.Text, false));
            paramList.Add(new ReportParameter("f_fin", txtFechaFin.Text, false));
            
            
            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;

            ReportViewer1.ServerReport.Refresh();
    }
}