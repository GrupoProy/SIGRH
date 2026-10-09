using Microsoft.Reporting.WebForms;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;

public partial class Precontrataciones_ImprimirContratacion : System.Web.UI.Page
{
    private cls_precontrataciones_cs _contrato = new cls_precontrataciones_cs();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] == null)
        {
            Response.Redirect("../Index");
            return;
        }

        if (!Page.IsPostBack)
        {
            CargarReporte();
        }
    }

    // ============================================================
    // CARGA DEL REPORTE
    // ============================================================
    private void CargarReporte()
    {
        if (Request.QueryString["per_id"] == null || Request.QueryString["tipo"] == null)
        {
            MostrarError("Parámetros insuficientes para generar el reporte.");
            return;
        }

        int perId = Convert.ToInt32(Request.QueryString["per_id"]);
        string tipo = Request.QueryString["tipo"].ToLower().Trim();

        // Obtener datos del contrato
        var ds = _contrato.ObtenerContratoPorPersona(perId);
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
        {
            MostrarError("No se encontró información del contrato.");
            return;
        }

        DataRow row = ds.Tables[0].Rows[0];

        int asId = Convert.ToInt32(row["as_id"]);
        string estado = row["as_estado"] != DBNull.Value ? row["as_estado"].ToString().Trim() : "";
        string tipoBaja = row["as_tipo_baja"] != DBNull.Value ? row["as_tipo_baja"].ToString().Trim() : "";

        // Validar y obtener la ruta del reporte
        string reportPath = ObtenerRutaReporte(tipo, estado, tipoBaja);
        if (string.IsNullOrEmpty(reportPath))
        {
            // El mensaje de error ya se mostró dentro del método
            return;
        }

        // Configurar ReportViewer
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://10.0.0.30:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath = reportPath;

        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("as_id", asId.ToString(), false));
        paramList.Add(new ReportParameter("per_id", perId.ToString(), false));

        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }

    // ============================================================
    // DETERMINA LA RUTA DEL REPORTE SEGÚN TIPO Y ESTADO DEL CONTRATO
    // ============================================================
    private string ObtenerRutaReporte(string tipo, string estado, string tipoBaja)
    {
        switch (tipo)
        {
            // ---------- ALTA ----------
            case "alta":
                if (estado == "V")
                {
                    MostrarError("Este contrato ya fue validado. No se puede reimprimir la Alta.");
                    return null;
                }
                return "/ReportesPrecontratacion/ContratacionAlta";

            // ---------- MODIFICACIÓN ----------
            case "modificacion":
                if (tipoBaja != "L")
                {
                    MostrarError("Este contrato no tiene una modificación registrada.");
                    return null;
                }
                return "/ReportesPrecontratacion/ContratacionModificacion";

            // ---------- BAJA ----------
            case "baja":
                if (string.IsNullOrEmpty(tipoBaja) || tipoBaja == "L")
                {
                    MostrarError("Este contrato no tiene una baja registrada.");
                    return null;
                }
                return "/ReportesPrecontratacion/ContratacionBaja";

            // ---------- TIPO NO RECONOCIDO ----------
            default:
                MostrarError("Tipo de reporte no reconocido.");
                return null;
        }
    }

    // ============================================================
    // MOSTRAR MENSAJE DE ERROR
    // ============================================================
    private void MostrarError(string mensaje)
    {
        ltlMensaje.Text = $"<div class='alert alert-warning mt-3'><i class='fas fa-exclamation-triangle'></i> {mensaje}</div>";
        ReportViewer1.Visible = false;
        btnVolver.Visible = true;
    }

    protected void btnVolver_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaSolicitudes.aspx");
    }
}