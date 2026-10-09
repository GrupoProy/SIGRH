using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Precontratacion_ReportePlanillaC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!Page.IsPostBack)
        {
            ReportViewer rview = new ReportViewer();
            rview.ServerReport.ReportServerUrl = new Uri("http://gmlpsr00038/ReportServer");
            List<ReportParameter> paramList = new List<ReportParameter>();
            string pl_id = HttpContext.Current.Session["pl_id"].ToString();
            paramList.Add(new ReportParameter("p_pl_id", pl_id, false));
            paramList.Add(new ReportParameter("p_accion", "C1", false));
            rview.ServerReport.ReportPath = "/SIGRH3/rptPC_ContratosPorValidar";
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
                Response.AddHeader("content-disposition", "inline; filename=NotaVenta.pdf");
                Response.AddHeader("content-length", bytes.Length.ToString());
                Response.BinaryWrite(memoryStream.ToArray());
                Response.Flush();
                Response.Close();
            }
        }
    }
}