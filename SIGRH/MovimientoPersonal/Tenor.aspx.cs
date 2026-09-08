using System;
using System.Collections.Generic;

using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class MovimientoPersonal_Tenor : System.Web.UI.Page
{
    private cls_mp_cargo tenor = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null)
        {
            if (HttpContext.Current.Session["per_id"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {
                    listaFiltradoTipoMov();
                    string te_cod_tenor = (Request.QueryString["id"] != null) ? Request.QueryString["id"].ToString() : "";
                    if (te_cod_tenor != "")
                    {
                        obtenerTenorX(te_cod_tenor);
                    }
                }
            }
            else
            {
                Response.Redirect("../index");
            }
        }
        else
        {
            Response.Redirect("../index");
        }

    }

    protected void modalGuardarTenor_Click(object sender, EventArgs e)
    {
        sc = "$('#modalGuardarT').modal('show');";
        SetScript(sc);
    }

    protected void btnGuardarTenor_Click(object sender, EventArgs e)
    {
        int te_cod_tenor = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int us_id = Convert.ToInt32(Session["us_id"].ToString());

        tenor = new cls_mp_cargo();
        string contentQ = hf_containerQuill.Value;

        tenor.te_cod_tenor = te_cod_tenor;
        tenor.te_descripcion = txt_desc_tenor.Text;
        tenor.te_contenido = contentQ;
        tenor.te_tipo_reg = ddl_tipo_movimiento.SelectedValue;
        tenor.te_usuario_creacion = us_id;

        if (te_cod_tenor != 0)
        {
            tenor.ActualizacionTenor();
            Session["texto_notificacion"] = "Tenor editado correctamente";
            Response.Redirect("ListaTenor");
        }
        else
        {
            tenor.AdicionarTenor();
            Session["texto_notificacion"] = "Tenor guardado correctamente";
            Response.Redirect("ListaTenor");
        }
    }

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("quill.enable(false); ");
        sb.Append("$('.ql-editor').css('border', 'none'); $('.ql-container.ql-snow').css('border', 'none'); $('.ql-editor').css('padding', '0rem .75rem');");
        sb.Append(data);

        sb.Append("$('#ContentPlaceHolder1_modalGuardarTenor').click(function () { " +
            "var contentQuill = JSON.stringify(quill.getContents()); " +
            "console.log('contentQuillContent', quill.getContents()); " +
            "console.log('contentQuill', contentQuill); " +
            "$('#hf_containerQuill').val(contentQuill);}); ");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_movimiento').select2({ placeholder: { id: '0', text: 'Selecciona una Opción' } });");
        sb.Append("$('.ql-editor').css('border', '1px solid #dee2e6'); $('.ql-container.ql-snow').css('border', '1px solid #ccc'); $('.ql-editor').css('padding', ' .625rem .75rem');");
        sb.Append("quill.enable(); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    private void obtenerTenorX(string te_cod_tenor = "")
    {
        tenor = new cls_mp_cargo();
        tenor.te_cod_tenor = Convert.ToInt32(te_cod_tenor);
        var tenorX = tenor.ObtenerDatosTenor();
        string te_contenido = "";
        if (tenorX.Tables[0].Rows.Count > 0)
        {
            var detalle_tenor = tenorX.Tables[0].Rows[0];
            txt_desc_tenor.Text = validarCampo(detalle_tenor["te_descripcion"]);
            te_contenido = validarCampo(detalle_tenor["te_contenido"]);
            ddl_tipo_movimiento.SelectedValue = validarCampo(detalle_tenor["te_tipo_reg"]);
            hf_containerQuill.Value = te_contenido;
        }
        modalGuardarTenor.Text = "<i class='fas fa-save mr-2'></i>Modificar";

    }
    private void listaFiltradoTipoMov()
    {
        try
        {
            tenor = new cls_mp_cargo();

            ddl_tipo_movimiento.Items.Clear();
            ddl_tipo_movimiento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_movimiento.DataValueField = "cat_abreviacion";
            ddl_tipo_movimiento.DataTextField = "cat_descripcion";
            ddl_tipo_movimiento.DataSource = tenor.ObtenerFiltradoTipoMov();
            ddl_tipo_movimiento.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void ddl_tipo_movimiento_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void btn_vista_previa_Click(object sender, EventArgs e)
    {
        sc = "vistaPrevia();";
        SetScript(sc);
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

    protected void btnAtras_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaTenor.aspx");
    }
}