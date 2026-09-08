using System;
using System.Collections.Generic;
using System.IO;
 
using System.Web;


using System.Drawing;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Text;
using System.Web.UI;

public partial class Configuraciones_RegistroFoto : System.Web.UI.Page
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
            informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
        }
    }
    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        cargo = new cls_mp_cargo();
        cargo.as_per_id = codFun;
        cargo.as_id_actual = as_id;
        var detalleFuncionario = cargo.ObtenerDatosDetalleFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
 
                if (validarCampo(funcionario["fp_foto"]) != "")
                {
                    imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
                }
                else
                {
                    if (validarCampo(funcionario["per_sexo"]) == "M")
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
                    }
                    else
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
                    }
                }

            }
        }
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
        if (hf_img.Value != "")
        {
            sc = "$('#guardarCambios').modal('show');";
            SetScript(sc);
        } else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, por favor seleccione una foto.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }

    }
    private void guardarFoto(int fp_id = 0, int fp_per_id = 0, byte[] fp_foto = null, string fp_estado = "")
    {
        persona_foto = new cls_persona();
        //persona_foto.fp_id = fp_id;
        persona_foto.per_id = fp_per_id;
        persona_foto.fp_foto = fp_foto;
        persona_foto.fp_estado = fp_estado;
        persona_foto.AdicionarFoto();
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_guardar_cambios_Click(object sender, EventArgs e)
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
        Response.Redirect("FotoFuncionario");
        /*CONVERTIR A BASE64*/
        //persona_foto = new cls_persona();

        //var detalle_foto = persona_foto.ObtenerRegistroFoto();
        //if (detalle_foto.Tables[0].Rows.Count > 0)
        //{
        //    for (int i = 0; i < detalle_foto.Tables[0].Rows.Count; i++)
        //    {
        //        var foto_x = detalle_foto.Tables[0].Rows[i];
        //        int fp_id = Convert.ToInt32(validarCampo(foto_x["fp_id"]));
        //        int fp_per_id = Convert.ToInt32(validarCampo(foto_x["fp_per_id"]));
        //        string fp_foto = "data:image/jpg;base64," + Convert.ToBase64String((byte[])foto_x["fp_foto"]);
        //        string fp_estado = validarCampo(foto_x["fp_estado"]);
        //        guardarFoto(fp_id, fp_per_id, fp_foto, fp_estado);
        //    }
        //}
    }
}