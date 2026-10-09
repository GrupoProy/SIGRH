using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;

public partial class ControlPersonal_ReporteAsistenciaIndividual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        lblMensaje.Text = "";
        pnlReporte.Visible = false;
        pnlGrilla.Visible = false;

        try
        {
            cls_cp_asistencia asistencia = new cls_cp_asistencia();
            asistencia.cod_persona = Convert.ToInt32(Session["per_id_reporte"]);
            asistencia.f_ini = txtFechaInicio.Text;
            asistencia.f_fin = txtFechaFin.Text;

            DataSet ds = asistencia.ObtenerReporteAsistencia();
            bool hayDatos = ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;

            if (hayDatos)
            {
                gvAsistencia.DataSource = ds.Tables[0];
                gvAsistencia.DataBind();
                pnlGrilla.Visible = true;

                ViewState["f_ini"] = txtFechaInicio.Text;
                ViewState["f_fin"] = txtFechaFin.Text;
            }
            else
            {
                lblMensaje.Text = "No hay registros en ese rango de fechas.";
            }

            BtnImprimir.Visible = hayDatos;
        }

        catch (Exception ex)
        {
            lblMensaje.Text = "Error al obtener la asistencia: " + ex.Message;
            BtnImprimir.Visible = false;
        }
    }

    protected void BtnImprimir_Click(object sender, EventArgs e)
    {
        pnlGrilla.Visible = false;
        pnlReporte.Visible = true;

        ReportViewer1.Reset();
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://10.0.0.31:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath = "/ReportesUAP/REPORTE_ASISTENCIA_UAP";

        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("cod_persona", Session["per_id_reporte"].ToString(), false));
        paramList.Add(new ReportParameter("f_ini", (ViewState["f_ini"] ?? txtFechaInicio.Text).ToString(), false));
        paramList.Add(new ReportParameter("f_fin", (ViewState["f_fin"] ?? txtFechaFin.Text).ToString(), false));

        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.ServerReport.Refresh();
    }

    protected void BtnVolver_Click(object sender, EventArgs e)
    {
        pnlReporte.Visible = false;
        pnlGrilla.Visible = true;
        BtnImprimir.Visible = true;


        // Reenlazar la grilla
        BtnBuscar_Click(sender, e);
    }
}