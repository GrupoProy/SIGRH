<%@ WebHandler Language="C#" Class="FileCS" %>

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class FileCS : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        int id = int.Parse(context.Request.QueryString["Id"]);
        byte[] bytes;
        string fileName;
        string constr = ConfigurationManager.ConnectionStrings["CnxSigrh3"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = "SELECT * FROM tbl_kd_file_virtualPDF WHERE pdf_id=@Id";
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    bytes = (byte[])sdr["pdf_documento"];
                    //contentType = "pdf";// sdr["ContentType"].ToString();
                    fileName = sdr["pdf_observacion"].ToString();
                }
                con.Close();
            }
        }

        context.Response.Buffer = true;
        context.Response.Charset = "";
        if (context.Request.QueryString["download"] == "1")
        {
            context.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
        }
        context.Response.Cache.SetCacheability(HttpCacheability.NoCache);
        context.Response.ContentType = "application/pdf";
        context.Response.BinaryWrite(bytes);
        context.Response.Flush();
        context.Response.End();
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}