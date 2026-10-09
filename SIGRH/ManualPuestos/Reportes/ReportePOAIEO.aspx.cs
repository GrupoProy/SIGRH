using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_ManualPuestos.BussinessLogicLayer;

public partial class ManualPuestos_Reportes_ReportePOAIEO : System.Web.UI.Page
{
    private cls_mdp_resultados_especificos poai_id = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ReportViewer rview = new ReportViewer();
            rview.ServerReport.ReportServerUrl = new Uri("http://gmlpsr00038/ReportServer");
            List<ReportParameter> paramList = new List<ReportParameter>();

            string idFicha = HttpContext.Current.Session["idFicha"].ToString();
            paramList.Add(new ReportParameter("unidad", idFicha, false));

            string codigo = obtenerCod(idFicha);
            rview.ServerReport.ReportPath = "/Planillas/Reporte_POAI_grupal";

            rview.ServerReport.SetParameters(paramList);
            rview.ServerReport.Refresh();

            string mimeType, encoding, extension;
            string[] streamids; Microsoft.Reporting.WebForms.Warning[] warnings;
            string format = "PDF";
            byte[] bytes = rview.ServerReport.Render(format, "", out mimeType, out encoding, out extension, out streamids, out warnings);

            using (MemoryStream memoryStream = new MemoryStream(bytes))
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/pdf"; //"application/excel"
                Response.AddHeader("content-disposition", "inline; filename=" + codigo + ".pdf");
                Response.AddHeader("content-length", bytes.Length.ToString());
                Response.BinaryWrite(memoryStream.ToArray());
                Response.Flush();
                Response.Close();
            }
        }
    }
    private string obtenerCod(string eo_id = "")
    {
        string cod = "POAI";
        poai_id = new cls_mdp_resultados_especificos();
        poai_id.eo_id = Convert.ToInt32(eo_id);
        var detalle = poai_id.ObtenerCodigo();

        if (detalle.Tables[0].Rows.Count > 0)
        {
            cod = validarCampo(detalle.Tables[0].Rows[0]["nombre_pdf"]);
        }
    
        return cod;
    }
    private string validarCampo(object p_campo)
    {
        string campo = "";
        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }
}