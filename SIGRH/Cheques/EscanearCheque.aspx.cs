using Solution_Framework_Kardex.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Drawing;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;
using System.IO;

public partial class Cheques_EscanearCheque : System.Web.UI.Page
{
    public int index = 0;
    private string sc = "";
    cls_kd_finiquito2 cheque = new cls_kd_finiquito2();
    protected void Page_Load(object sender, EventArgs e)
    {
        CargarTipoDoc();
    }

    private void CargarTipoDoc()
    {
        ddl_tipo_doc.Items.Clear();
        ddl_tipo_doc.DataSource = cheque.GetTipDoc();
        ddl_tipo_doc.DataTextField = "tipo_doc_descripcion";
        ddl_tipo_doc.DataValueField = "tipo_doc_id";
        ddl_tipo_doc.DataBind();
    }
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        int per_id = (Request.QueryString["per_id"].ToString() != null) ? Convert.ToInt32(Request.QueryString["per_id"].ToString()) : 0;

        string[] words = hf_img.Value.Split(',');
        string str_out = "";
        for (int i = 0; i < words.Length; i++)
        {
            if (i != 0)
            {
                str_out = str_out + words[i];
            }
        }
        
        byte[] bytes = Convert.FromBase64String(str_out);
        Image img;
        using (MemoryStream stream = new MemoryStream(bytes))
        {
            img = Image.FromStream(stream);
        }

        guardarFoto(per_id, bytes);

        Session["texto_notificacion"] = "Foto guardada correctamente";
        string codFun = Request.QueryString["per_id"].ToString();
        Response.Redirect("BuscarProceso.aspx?per_id=" + codFun);

    }

    private void guardarFoto(int fp_per_id = 0, byte[] fp_foto = null, string fp_estado = "")
    {
        cls_kd_finiquito2 cheque = new cls_kd_finiquito2();
        cheque.AdicionarPDF(Convert.ToInt32(ddl_tipo_doc.SelectedItem.Text), Convert.ToInt32(Request.QueryString["per_id"].ToString()),fp_foto, txt_fecha_doc.Text.ToString(), fp_per_id, txtObservaciones.Text.ToString());
        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente el documento' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#blockResultados').css('display', 'none'); $('#modalCatalogo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
        string codFun = Request.QueryString["per_id"].ToString();
        Response.Redirect("BuscarProceso.aspx?id=" + codFun);
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }});");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
}