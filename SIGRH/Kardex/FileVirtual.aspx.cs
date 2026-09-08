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
public partial class Kardex_FileVirtual : System.Web.UI.Page
{
    public int index = 0;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                string codFun = Request.QueryString["id"].ToString();
                string as_id = Request.QueryString["id2"].ToString();
                informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
                CargarCategoriasKardex();
                Session["FileFirtual_Index"] = 0;
                Session["FileVirtual_Categoria"] = 0;
                Session["fv_id"] = 0;
                MostrarFoto(Convert.ToInt32(Session["FileFirtual_Index"].ToString()));
            }

        }
    }
    private void CargarCategoriasKardex()
    {
        cls_persona kardex = new cls_persona();
        ddlCategoria.Items.Clear();
        ddlCategoria.Items.Add("Seleccione..");
        ddlCategoria.DataSource = kardex.FileVirtual(0, null, 0, "", "", 0, "", "", "C2");
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
                ltl_genero.Text = validarCampo(funcionario["genero"]);
                //txt_nro_lib.Text = validarCampo(funcionario["nro_lib_mil"]);
                ltl_num_doc.Text = validarCampo(funcionario["num_doc"]) + " " + validarCampo(funcionario["lugar_exp"]);
                ltl_fecha_nac.Text = validarCampo(funcionario["fecha_nac"]);
                ltl_pais.Text = validarCampo(funcionario["pais"]);
                ltl_departamento.Text = validarCampo(funcionario["departamento"]);
                ltl_provincia.Text = validarCampo(funcionario["provincia"]);
                ltl_localidad.Text = validarCampo(funcionario["localidad"]);
            }
        }
    }

    protected void btn_nuevo_Click(object sender, EventArgs e)
    {
        string codFun = Request.QueryString["id"].ToString();
        string as_id = Request.QueryString["id2"].ToString();
        Response.Redirect("FileVirtualNuevo?id=" + codFun + "&id2=" + as_id);
    }
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void MostrarFoto(int index) {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            cls_persona foto = new cls_persona();
            DataSet ds = foto.FileVirtual(0, null, 0, "", "", Convert.ToInt32(Request.QueryString["id"].ToString()), HttpContext.Current.Session["FileVirtual_Categoria"].ToString(), "V", "C1");
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (index <= ds.Tables[0].Rows.Count - 1 && index >= 0)
                {
                    Session["FileFirtual_Index"] = index;

                    imgDocumento.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])ds.Tables[0].Rows[index]["fv_imagen_documento"]);
                    Session["fv_id"] = ds.Tables[0].Rows[index]["fv_id"];
                }
                else
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se mostraron todas las imágenes' }, { type: 'warning' });";
                    SetScript(sc, "");
                }
            }else
            {
                imgDocumento.ImageUrl = "";
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No existen registros digitales dentro de la categoría' }, { type: 'info' });";
                SetScript(sc, "");
            }
        }
    }
    protected void btnImagenAdelante_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["FileFirtual_Index"] != null && HttpContext.Current.Session["FileFirtual_Index"].ToString() != "")
            if (Convert.ToInt32(HttpContext.Current.Session["FileFirtual_Index"].ToString()) != -1)
                MostrarFoto(Convert.ToInt32(HttpContext.Current.Session["FileFirtual_Index"].ToString())+1);
    }

    protected void btnImagenAtras_Click(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["FileFirtual_Index"] != null && HttpContext.Current.Session["FileFirtual_Index"].ToString() != "")
            if(Convert.ToInt32(HttpContext.Current.Session["FileFirtual_Index"].ToString())!=-1)
                MostrarFoto(Convert.ToInt32(HttpContext.Current.Session["FileFirtual_Index"].ToString()) - 1);
    }

    protected void btn100_Click(object sender, EventArgs e)
    {
        imgDocumento.Width =  (int)(1500);
    }

    protected void btn50_Click(object sender, EventArgs e)
    {
        imgDocumento.Width = (int)(750);
    }
    //protected void btnEvaluacion_Click(object sender, EventArgs e)
    //{
    //    Session["FileVirtual_Categoria"] = btnEvaluacion.Text;
    //    MostrarFoto(0);
    //}

    //protected void btnHistoria_Click(object sender, EventArgs e)
    //{
    //    Session["FileVirtual_Categoria"] = btnHistoria.Text;
    //    MostrarFoto(0);
    //}

    //protected void btnCertificados_Click(object sender, EventArgs e)
    //{
    //    Session["FileVirtual_Categoria"] = btnCertificados.Text;
    //    MostrarFoto(0);
    //}

    //protected void btnSeleccion_Click(object sender, EventArgs e)
    //{
    //    Session["FileVirtual_Categoria"] = btnSeleccion.Text;
    //    MostrarFoto(0);
    //}

    //protected void btnLicencias_Click(object sender, EventArgs e)
    //{
    //    Session["FileVirtual_Categoria"] = btnLicencias.Text;
    //    MostrarFoto(0);
    //}

    //protected void btnIncorporacion_Click(object sender, EventArgs e)
    //{
    //    Session["FileVirtual_Categoria"] = btnIncorporacion.Text;
    //    MostrarFoto(0);
    //}

    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["FileVirtual_Categoria"] = ddlCategoria.SelectedItem.Text;
        MostrarFoto(0);
    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {
        sc = "$('#guardarCambios').modal('show');";
        SetScript(sc, "");
    }
    protected void btn_guardar_cambios_Click(object sender, EventArgs e)
    {

        if (HttpContext.Current.Session["fv_id"] != null && HttpContext.Current.Session["fv_id"].ToString() != "")
        {
            cls_persona foto = new cls_persona();
            foto.FileVirtual(Convert.ToInt32(HttpContext.Current.Session["fv_id"].ToString()), null, 0, "", "", Convert.ToInt32(Request.QueryString["id"].ToString()), HttpContext.Current.Session["FileVirtual_Categoria"].ToString(), "V", "B1");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se eliminó el documento digital correctamente' }, { type: 'success' });$('#guardarCambios').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            Response.Redirect("FileVirtual?id=" + codFun + "&id2=" + as_id);
        }
    }

}