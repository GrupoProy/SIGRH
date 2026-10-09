using System;
using System.Collections.Generic;
using System.Data;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;

public partial class MovimientoPersonal_TenorFuncionario : System.Web.UI.Page
{
    private cls_mp_cargo tenor = null;
    //private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null)
        {
            if (HttpContext.Current.Session["per_id"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {
                    string cod_fun = (Request.QueryString["id"] != null) ? Request.QueryString["id"].ToString() : "";
                    string te_cod_tenor = (Request.QueryString["id2"] != null) ? Request.QueryString["id2"].ToString() : "";
                    string tipo_mov = (Request.QueryString["id3"] != null) ? Request.QueryString["id3"].ToString() : "";
                    string gestion = (Request.QueryString["id4"] != null) ? Request.QueryString["id4"].ToString() : "";
                    obtenerTenor(Convert.ToInt32(te_cod_tenor));
                    obtenerFuncionario(Convert.ToInt32(cod_fun), Convert.ToInt32(gestion), tipo_mov, Convert.ToInt32(te_cod_tenor));
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
    private void obtenerTenor (int cod_tenor = 0)
    {
        tenor = new cls_mp_cargo();
        tenor.te_cod_tenor = cod_tenor;
        var detalleTenor = tenor.ObtenerDetalleTenor();

        string te_descripcion = "";
        string te_contenido = "";
        if (detalleTenor.Tables[0].Rows.Count > 0)
        {
            if (detalleTenor.Tables[0].Rows[0]["te_descripcion"] != DBNull.Value && detalleTenor.Tables[0].Rows[0]["te_descripcion"].ToString().Trim() != "") { te_descripcion = detalleTenor.Tables[0].Rows[0]["te_descripcion"].ToString().Trim(); }
            if (detalleTenor.Tables[0].Rows[0]["te_contenido"] != DBNull.Value && detalleTenor.Tables[0].Rows[0]["te_contenido"].ToString().Trim() != "") { te_contenido = detalleTenor.Tables[0].Rows[0]["te_contenido"].ToString().Trim(); }
            hf_containerQuill.Value = te_contenido;
            ltl_descripcion_tenor.Text = te_descripcion;
        }
    }
    private void obtenerFuncionario(int cod_fun = 0, int gestion = 0, string tipo_mov = "", int te_cod_tenor = 0)
    {
        tenor = new cls_mp_cargo();
        tenor.p_per_id = cod_fun;
        var detalleFuncionario = ObtenerDetalleFuncionario(cod_fun, gestion, tipo_mov, te_cod_tenor);

        if (detalleFuncionario.Tables[0].Rows.Count > 0)
        {
            hf_resp.Value = JsonConvert.SerializeObject(detalleFuncionario);
        }
    }

    private DataSet ObtenerDetalleFuncionario(int cod_fun = 0, int gestion = 0, string tipo_mov = "", int te_cod_tenor = 0)
    {
        tenor = new cls_mp_cargo();
        tenor.p_per_id = cod_fun;
        tenor.gestion_selec = Convert.ToString(gestion);
        tenor.te_cod_tenor = te_cod_tenor;

        DataSet aux = null;
        var detalleFuncionario = aux;
        string tipo_movimiento = tipo_mov;
        switch (tipo_movimiento)
        {
            case "A":
                detalleFuncionario = tenor.ObtenerDetalleFuncionario();

                if (detalleFuncionario.Tables[0].Rows.Count > 0)
                {
                    if (detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"] != DBNull.Value && detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"].ToString().Trim() != "" && Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"].ToString().Trim()) != 0)
                    {

                        tenor.p_nro_memo = Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"].ToString().Trim());
                        tenor.as_id_actual = Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["AS_ID"].ToString().Trim());
                        tenor.as_ca_id = Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["AS_CA_ID"].ToString().Trim());
                        tenor.ActualizarMemoAsignacion();
                    }
                }
                break;
            case "B":
                detalleFuncionario = tenor.ObtenerDetalleFuncionarioBajas();

                if (detalleFuncionario.Tables.Count > 0)
                {
                    if (detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"] != DBNull.Value && detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"].ToString().Trim() != "" && Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"].ToString().Trim()) != 0)
                    {

                        tenor.p_nro_memo = Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"].ToString().Trim());
                        tenor.as_id_actual = Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["AS_ID"].ToString().Trim());
                        tenor.as_ca_id = Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["AS_CA_ID"].ToString().Trim());
                        tenor.ActualizarMemoAsignacion();
                    }
                }
                break;
            case "T":
                detalleFuncionario = tenor.ObtenerDetalleFuncionarioPRTCargos();
                break;
            case "P":
                detalleFuncionario = tenor.ObtenerDetalleFuncionarioPRTAcefalias();
                break;
            case "X":
                detalleFuncionario = tenor.ObtenerDetalleFuncionarioAComInt();
                break;
            case "Y":
                detalleFuncionario = tenor.ObtenerDetalleFuncionarioBComInt();
                break;
            case "V":
                detalleFuncionario = tenor.ObtenerDetalleFuncionarioADispPersonal();
                break;
            case "W":
                detalleFuncionario = tenor.ObtenerDetalleFuncionarioBDispPersonal();
                break;
            //case "H":
            //    armarConsulta("T", "C60");
            //    break;
            default:
                break;
        }

        return detalleFuncionario;
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
        Response.Redirect("AsignacionTenor.aspx");
    }
}