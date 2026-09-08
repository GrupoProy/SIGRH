using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Drawing;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Text;
using System.Web.UI;

public partial class Kardex_FileVirtualNuevo : System.Web.UI.Page
{
    private cls_persona persona_foto = null;
    private cls_mp_cargo cargo = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            CargarCategoriasKardex();
        }
    }

    private void CargarCategoriasKardex() {
        cls_persona kardex = new cls_persona();
        ddlCategoria.Items.Clear();
        ddlCategoria.Items.Add("Seleccione..");
        ddlCategoria.DataSource = kardex.FileVirtual(0,null,0,"","",0,"","","C2");
        ddlCategoria.DataTextField = "categoria";
        ddlCategoria.DataBind();
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


    protected void guardar_recorte_Click(object sender, EventArgs e)
    {
        if (hf_img.Value != "" && ddlCategoria.SelectedIndex>0 && ddlDocumento.SelectedIndex>0)
        {
            sc = "$('#guardarCambios').modal('show');";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, por favor seleccione una foto o mueva el cuadro de selección para recortar la foto.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }

    }
    private void guardarFoto(int fp_id = 0, int fp_per_id = 0, byte[] fp_foto = null, string fp_estado = "")
    {
        cls_persona imagen_documento = new cls_persona();
        imagen_documento.FileVirtual(0, fp_foto, Convert.ToInt32(ddlDocumento.SelectedItem.Value), txt_fecha_doc.Text, DateTime.Now.ToString(), Convert.ToInt32(Request.QueryString["id"].ToString()), txtObservaciones.Text, "V", "A1");
        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente el documento' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#blockResultados').css('display', 'none'); $('#modalCatalogo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
        string codFun = Request.QueryString["id"].ToString();
        string as_id = Request.QueryString["id2"].ToString();
        Response.Redirect("FileVirtual?id=" + codFun + "&id2=" + as_id);

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

    protected void btn_guardar_cambios_Click(object sender, EventArgs e)
    {
        if (ddlCategoria.SelectedIndex > 0 && ddlDocumento.SelectedIndex > 0 && txt_fecha_doc.Text != "")
        {
            int per_id = (Request.QueryString["id"].ToString() != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;

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

            guardarFoto(0, per_id, bytes, "V");

            Session["texto_notificacion"] = "Foto guardada correctamente";
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            Response.Redirect("FileVirtual?id=" + codFun + "&id2=" + as_id);
        }
    }


    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScript("");
        cls_persona kardex = new cls_persona();
        ddlDocumento.Items.Clear();
        ddlDocumento.Items.Add("Seleccione..");
        ddlDocumento.DataSource = kardex.FileVirtual(0, null, 0, "", "", 0, ddlCategoria.SelectedItem.Text, "", "C3");
        ddlDocumento.DataTextField = "rq_descripcion";
        ddlDocumento.DataValueField = "rq_id";
        ddlDocumento.DataBind();
    }
}