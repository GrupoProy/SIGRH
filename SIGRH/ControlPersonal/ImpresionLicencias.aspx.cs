using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;

public partial class ControlPersonal_ImpresionLicencias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarReporte();
        }
    }

    private void CargarReporte()
    {
        if (Session["cod_licencia"] == null || string.IsNullOrEmpty(Session["cod_licencia"].ToString()))
            return;

        string codLicencia = Session["cod_licencia"].ToString();

        // Obtener el cat_id_superior usando la capa de negocio
        int? catSuperior = ObtenerTipoSolicitud(codLicencia);
        if (!catSuperior.HasValue)
            return;

        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://10.0.0.31:8008/ReportServer");

        string reportPath = ObtenerRutaReporte(catSuperior.Value);
        ReportViewer1.ServerReport.ReportPath = reportPath;

        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("cod_licencia", codLicencia, false));
        ReportViewer1.ServerReport.SetParameters(paramList);

        ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();
    }

    private int? ObtenerTipoSolicitud(string codLicencia)
    {
        if (!int.TryParse(codLicencia, out int licenciaId))
            return null;

        cls_cp_licencia_justificada licencia = new cls_cp_licencia_justificada();
        DataSet ds = licencia.ObtenerTablaGrilla(codLicencia, "", "", "", "", "", "", "", "", "", "", "");
        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return null;

        DataRow row = ds.Tables[0].Rows[0];
        if (!ds.Tables[0].Columns.Contains("lj_tipo_licencia"))
            return null;

        int catId = Convert.ToInt32(row["lj_tipo_licencia"]);

        cls_catalogo catalogo = new cls_catalogo { cat_tabla = "Tipo_Licencia", cat_id_superior = 0 };
        DataSet dsCat = catalogo.ObtenerTablaCombo();
        if (dsCat == null || dsCat.Tables.Count == 0 || dsCat.Tables[0].Rows.Count == 0)
            return null;

        DataRow[] filtro = dsCat.Tables[0].Select("cat_id = " + catId);
        if (filtro.Length == 0)
            return null;

        return Convert.ToInt32(filtro[0]["cat_id_superior"]);
    }

    private string ObtenerRutaReporte(int tipoSolicitud)
    {
        switch (tipoSolicitud)
        {
            case 14605: // Sin goce de haber → Form. N°045
                return "/ReportesUAP/Solicitud_Sin_Goce_045";
            case 14604: // Licencias → Form. N°044
                return "/ReportesUAP/Solicitud_Licencia_044";
            default:    // Permisos, asuetos, etc. → Form. N°043
                return "/ReportesUAP/Solicitud_Permisos_043";
        }
    }
}