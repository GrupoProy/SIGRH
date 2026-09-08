using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Data;
using System.Text;
using Solution_Framework_Kardex.BussinessLogicLayer;

public partial class Cheques_DetalleCheques : System.Web.UI.Page
{
    public int index = 0;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {

            if (!Page.IsPostBack)
            {
            string codFun = "853";//Request.QueryString["id"].ToString();
            string as_id = "245245";//Request.QueryString["id2"].ToString();
                informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
                Session["FileFirtual_Index"] = 0;
                Session["FileVirtual_Categoria"] = 0;
                Session["pdf_id"] = 0;
                CargarCategoriasKardex();
                //ddlCategoria_SelectedIndexChanged(null, null);
                CargarBuscador();
            //MostrarFoto(Convert.ToInt32(Session["FileFirtual_Index"].ToString()), "");
            //MostrarDoc(0);
            Session["per_id"] = "853";
            }


    }
    private void CargarBuscador()
    {
        cls_persona kardex = new cls_persona();
        ddlFInd.Items.Clear();
        ddlFInd.Items.Add("Seleccione..");
        ddlFInd.DataSource = kardex.MostrarFileVirtualPDF_PorPdf_Per_id(Convert.ToInt32(Request.QueryString["id"].ToString()), 0);
        ddlFInd.DataTextField = "pdf_nombre";
        ddlFInd.DataValueField = "pdf_id";
        ddlFInd.DataBind();
    }
    private void CargarCategoriasKardex()
    {
        cls_persona kardex = new cls_persona();
        ddlCategoria.Items.Clear();
        ddlCategoria.Items.Add("Seleccione..");
        ddlCategoria.DataSource = kardex.FileVirtual(0, null, 0, "", "", 0, "", "", "C2");
        ddlCategoria.DataTextField = "categoria";
        ddlCategoria.DataBind();
        //ddlCategoria.SelectedIndex = 1;
        Session["FileVirtual_Categoria"] = ddlCategoria.SelectedItem.Text;
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
    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        cls_kd_respuesta_combo resp_combo = new cls_kd_respuesta_combo();
        resp_combo.p_per_id = codFun;
        var detalleFuncionario = resp_combo.ObtenerDatosFuncioanrio();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_estado_civil.Text = validarCampo(funcionario["estado_civil"]);
                //ltl_genero.Text = validarCampo(funcionario["genero"]);
                //txt_nro_lib.Text = validarCampo(funcionario["nro_lib_mil"]);
                ltl_num_doc.Text = validarCampo(funcionario["num_doc"]) + " " + validarCampo(funcionario["lugar_exp"]);
                ltl_fecha_nac.Text = validarCampo(funcionario["fecha_nac"]);
                //ltl_pais.Text = validarCampo(funcionario["pais"]);
                //ltl_departamento.Text = validarCampo(funcionario["departamento"]);
                //ltl_provincia.Text = validarCampo(funcionario["provincia"]);
                //ltl_localidad.Text = validarCampo(funcionario["localidad"]);
            }
        }
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        string codFun = Request.QueryString["id"].ToString();
        string as_id = Request.QueryString["id2"].ToString();
        Response.Redirect("FileVirtualNuevoPdf?id=" + codFun + "&id2=" + as_id);
    }
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }
    private void MostrarDoc(int pdf_id)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "" && HttpContext.Current.Session["FileVirtual_Categoria"] != null && HttpContext.Current.Session["FileVirtual_Categoria"].ToString() != "")
        {
            cls_persona pdf = new cls_persona();
            //string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"800px\" height=\"1000px\">";
            string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"100%\" height=\"1000px\">";

            embed += "Si no es posible ver el archivo, por favor";
            embed += " descargue Adobe Reader del siguiente enlace <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> para ver los archivos con extensión pdf";
            embed += "</object>";
            ltEmbed.Text = string.Format(embed, ResolveUrl("FileCS.ashx?Id="), pdf_id);

            Session["pdf_id"] = pdf_id;

        }
    }
    private int ObtenerIndex(int pdf_id, DataSet ds, string sentido)
    {
        int index = 0;
        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                if (item["pdf_id"].ToString() != pdf_id.ToString())
                    index = index + 1;
                else break;
            }
        }
        if (sentido == "adelante")
            return index + 1;
        else
            if (sentido == "atras")
            return index - 1;
        else return 1;

    }
    private void MostrarFoto(int index)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "" && HttpContext.Current.Session["FileVirtual_Categoria"] != null && HttpContext.Current.Session["FileVirtual_Categoria"].ToString() != "")
        {
            cls_persona pdf = new cls_persona();
            //DataSet ds = foto.FileVirtual(0, null, 0, "", "", Convert.ToInt32(Request.QueryString["id"].ToString()), HttpContext.Current.Session["FileVirtual_Categoria"].ToString(), "V", "C1");
            DataSet ds = pdf.MostrarFileVirtualPDF(Convert.ToInt32(Request.QueryString["id"].ToString()), HttpContext.Current.Session["FileVirtual_Categoria"].ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (index <= ds.Tables[0].Rows.Count - 1 && index >= 0)
                {
                    Session["FileFirtual_Index"] = index;

                    string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"100%\" height=\"1000px\">";
                    //            embed += "Si no es posible ver el archivo, you can download from <a href = \"{0}{1}&download=1\">here</a>";
                    embed += "Si no es posible ver el archivo, por favor";
                    embed += " descargue Adobe Reader del siguiente enlace <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> para ver los archivos con extensión pdf";
                    embed += "</object>";
                    ltEmbed.Text = string.Format(embed, ResolveUrl("FileCS.ashx?Id="), ds.Tables[0].Rows[index]["pdf_id"].ToString());

                    //imgDocumento.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[index]["fv_imagen_documento"]);
                    Session["pdf_id"] = ds.Tables[0].Rows[index]["pdf_id"];

                    lblContador.Text = (index + 1).ToString() + "/" + ds.Tables[0].Rows.Count.ToString();
                    lblContador.Visible = true;
                }
                else
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se mostraron todas las imágenes' }, { type: 'warning' });";
                    SetScript2(sc, "");
                }
            }
            else
            {
                //imgDocumento.ImageUrl = "";
                ltEmbed.Text = "No existen documentos en esta categoría";
                Session["pdf_id"] = 0;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No existen registros digitales dentro de la categoría' }, { type: 'info' });";
                SetScript2(sc, "");
            }
        }

    }

    protected void btnImagenAdelante_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["FileFirtual_Index"] != null && HttpContext.Current.Session["FileFirtual_Index"].ToString() != "")
            if (Convert.ToInt32(HttpContext.Current.Session["FileFirtual_Index"].ToString()) != -1)
                MostrarFoto(Convert.ToInt32(HttpContext.Current.Session["FileFirtual_Index"].ToString()) + 1);
        SetScript2("", "");
    }

    protected void btnImagenAtras_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["FileFirtual_Index"] != null && HttpContext.Current.Session["FileFirtual_Index"].ToString() != "")
            if (Convert.ToInt32(HttpContext.Current.Session["FileFirtual_Index"].ToString()) != -1)
                MostrarFoto(Convert.ToInt32(HttpContext.Current.Session["FileFirtual_Index"].ToString()) - 1);
        SetScript2("", "");
    }

    protected void btn100_Click(object sender, EventArgs e)
    {
        //imgDocumento.Width = (int)(1500);
    }

    protected void btn50_Click(object sender, EventArgs e)
    {
        //imgDocumento.Width = (int)(750);
    }


    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["FileVirtual_Categoria"] = ddlCategoria.SelectedItem.Text;
        CargarDocs();
        //MostrarFoto(0);
        SetScript2("", "");
        ltEmbed.Text = "";
        //ddlDocs.SelectedIndex = 1;
        Session["FileFirtual_Index"] = 0;
        //ddlDocs_SelectedIndexChanged(null, null);

    }
    private void SetScript2(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        //sb.Append("$('#ddlDocs').select2({ dropdownParent: $('#modalNuevaVacacion')});");

        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void CargarDocs()
    {
        cls_persona PDF = new cls_persona();
        ddlDocs.Items.Clear();
        ddlDocs.Items.Add("Seleccione..");

        ddlDocs.DataSource = PDF.MostrarFileVirtualPDF(Convert.ToInt32(Request.QueryString["id"].ToString()), ddlCategoria.SelectedItem.Text);
        ddlDocs.DataTextField = "pdf_nombre";
        ddlDocs.DataValueField = "pdf_id";
        ddlDocs.DataBind();
    }
    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["pdf_id"] != null && HttpContext.Current.Session["pdf_id"].ToString() != "" && Convert.ToInt32(HttpContext.Current.Session["pdf_id"].ToString()) > 0)
        {
            sc = "$('#guardarCambios').modal('show');";
            SetScript(sc, "");
        }
    }
    protected void ddlDocs_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlDocs.SelectedItem.Text != "")
        {
            MostrarDoc(Convert.ToInt32(ddlDocs.SelectedItem.Value));
            Session["pdf_id"] = ddlDocs.SelectedItem.Value;
            Session["FileFirtual_Index"] = 0;
            lblContador.Visible = false;
        }
        SetScript2("", "");

    }

    protected void btnEliminarDoc_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["pdf_id"] != null && HttpContext.Current.Session["pdf_id"].ToString() != "")
        {
            cls_persona foto = new cls_persona();
            foto.EliminarFileVirtualPDF(Convert.ToInt32(HttpContext.Current.Session["pdf_id"].ToString()));
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se eliminó el documento digital correctamente' }, { type: 'success' });$('#guardarCambios').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            Response.Redirect("FileVirtualPdf?id=" + codFun + "&id2=" + as_id);
        }
    }

    protected void ddlFInd_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlFInd.SelectedItem.Text != "")
        {
            MostrarDoc(Convert.ToInt32(ddlFInd.SelectedItem.Value));
            Session["pdf_id"] = ddlFInd.SelectedItem.Value;
            Session["FileFirtual_Index"] = 0;
            lblContador.Visible = false;
        }
        SetScript2("", "");
    }
}