using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;


public partial class ManualPuestos_Reportes_Default : System.Web.UI.Page
{
    public string pc_id = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarReporte();

            //ReportViewer rview = new ReportViewer();
            //rview.ServerReport.ReportServerUrl = new Uri("http://DESKTOP-C44RAI7/ReportServer");
            //// *********************************************************************
            //// //Uri("http://SERVIDOR-DELL:8008/ReportServer");
            //// **********************************************************************
            //List<ReportParameter> paramList = new List<ReportParameter>();
            //string idFicha = HttpContext.Current.Session["idFicha"].ToString();
            //paramList.Add(new ReportParameter("poai_id", idFicha, false));
            //rview.ServerReport.ReportPath = "../Reportes/Reporte_POAI";//
            //rview.ServerReport.SetParameters(paramList);
            //string mimeType, encoding, extension, deviceInfo;
            //string[] streamids;
            //Warning[] warnings;
            //string format = "PDF"; //Desired format goes here (PDF, Excel, or Image)
            //deviceInfo = "<DeviceInfo>" + "<SimplePageHeaders>True</SimplePageHeaders>" + "</DeviceInfo>";
            //byte[] bytes = rview.ServerReport.Render(format, deviceInfo, out mimeType, out encoding, out extension, out streamids, out warnings);
            //Response.Clear();

            //if (format == "PDF")
            //{
            //    Response.ContentType = "application/pdf";
            //    Response.AddHeader("Content-disposition", "filename=output.pdf");
            //}
            //else if (format == "Excel")
            //{
            //    Response.ContentType = "application/excel";
            //    Response.AddHeader("Content-disposition", "filename=output.xls");
            //}
            //Response.OutputStream.Write(bytes, 0, bytes.Length);
            //Response.OutputStream.Flush();
            //Response.OutputStream.Close();
            //Response.Flush();
            //Response.Close();
        }

    }

    private void CargarReporte()
    {

        ///////////**************************/////////////
        //ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://SERVIDOR-DELL:8008/ReportServer");

        //string idFicha = HttpContext.Current.Session["idFicha"].ToString();
        //paramList.Add(new ReportParameter("poai_id", idFicha, false));
        //ReportViewer1.ServerReport.ReportPath =
        //"/Reportes/Reporte_POAI";
        //ReportViewer1.Height = 2000;
        //ReportViewer1.ServerReport.Refresh();
        //****23 MARZO ****//
        //ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://SERVIDOR-DELL:8008/ReportServer");
        ////ReportViewer1.ServerReport.ReportServerUrl = new
        ////Uri("http://ANTHRACIS-DESK/ReportServer");
        //ReportViewer1.ServerReport.ReportPath = "../Reportes/Reporte_POAI";
        //List<ReportParameter> paramList = new List<ReportParameter>();
        //ReportViewer1.ServerReport.SetParameters(paramList);
        //ReportViewer1.Height = 2000;

        //ReportViewer1.ServerReport.Refresh();
        //*** 24 MARXO ***//

        // rview.ServerReport.ReportServerUrl = new Uri("http://gmlpsr00038/ReportServer");
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new Uri("http://SRV_LONDRA:8008/ReportServer");
 
        List<ReportParameter> paramList = new List<ReportParameter>();
        string idFicha = HttpContext.Current.Session["idFicha"].ToString();
        paramList.Add(new ReportParameter("poai_id", idFicha, false));
        //string pl_id = HttpContext.Current.Session["pl_id"].ToString();
        //paramList.Add(new ReportParameter("p_pl_id", pl_id, false));
        //paramList.Add(new ReportParameter("p_accion", "C2", false));
        ReportViewer1.ServerReport.ReportPath = "/ReportesUAP/Reporte_POAI";
        ReportViewer1.ServerReport.SetParameters(paramList);
        //ReportViewer1.Height = 2000;
        ReportViewer1.ServerReport.Refresh();


        //string mimeType, encoding, extension;
        //string[] streamids; Microsoft.Reporting.WebForms.Warning[] warnings;
        //string format = "PDF";
        //byte[] bytes = ReportViewer1.ServerReport.Render(format, "", out mimeType, out encoding, out extension, out streamids, out warnings);

    }
}
