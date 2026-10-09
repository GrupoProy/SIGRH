using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DescriptorPuesto_VerPDF : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string parametroByte = Request.QueryString["byte"];
        MostrarDoc();
    }

    private void InformacionEgreso(byte[] bytes)
    {
        Response.Clear();
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "inline;filename=archivo.pdf");
        Response.Buffer = true;
        Response.BinaryWrite(bytes);
        Response.End();
    }

    private void MostrarDoc()
    {
        string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"100%\" height=\"1000px\">";

        embed += "Si no es posible ver el archivo, por favor";
        embed += " descargue Adobe Reader del siguiente enlace <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> para ver los archivos con extensión pdf";
        embed += "</object>";
        ltEmbed.Text = string.Format(embed, ResolveUrl("Egreso.ashx?Id="), hf_id.Value);
    }
}