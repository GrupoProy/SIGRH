using System;
using System.Collections.Generic;
using Solution_Framework_General.BussinessLogicLayer;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Data;
using Solution_Framework_Seguridad.BussinessLogicLayer;
using Solution_Framework_ManualPuesto.BussinessLogicLayer;

public partial class index : System.Web.UI.Page
{
    private cls_seg_usuario usuario = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        cls_periodo periodo = new cls_periodo();
        Response.Cache.SetNoStore();
        Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (HttpContext.Current.Session["per_id"] != null)
        {
            if (HttpContext.Current.Session["per_id"].ToString() != "")
            {
                sc = "$.notify({ icon: 'error', message: '" + HttpContext.Current.Session["per_id"].ToString() + "'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
                Response.Redirect("Inicio/Sigrh");
            }
        }
        if (!Page.IsPostBack)
        {
           
        }
    }

    protected void btn_modal_login_Click(object sender, EventArgs e)
    {
        sc = "$('#modal_sigrh').modal('show');";
        SetScript(sc);
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();
        //sb.Append(@"<script src='../Content/SIGRH3/js/Scripts.js'></script>");

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    private void Autenticar(AuthenticateEventArgs e)
    {

        usuario = new cls_seg_usuario();
        usuario.us_usuario = loginSigrh.UserName.Trim();
        usuario.us_contrasena = loginSigrh.Password.Trim();
        var funX = usuario.ObtenerFuncionarioX();
        if (funX.Tables[0].Rows.Count > 0)
        {
            if (funX.Tables[0].Rows[0]["us_per_id"] != DBNull.Value && funX.Tables[0].Rows[0]["us_per_id"].ToString().Trim() != "")
            {
                string fun_nombre = "";
                if (funX.Tables[0].Rows[0]["per_nombres"] != null)
                {
                    fun_nombre = funX.Tables[0].Rows[0]["per_nombres"].ToString().Trim();
                }
                string fun_paterno = "";
                if (funX.Tables[0].Rows[0]["per_ap_paterno"] != null)
                {
                    fun_paterno = funX.Tables[0].Rows[0]["per_ap_paterno"].ToString().Trim();
                }
                string fun_materno = "";
                if (funX.Tables[0].Rows[0]["per_ap_materno"] != null)
                {
                    fun_materno = funX.Tables[0].Rows[0]["per_ap_materno"].ToString().Trim();
                }

                string nombre_funcionario = (fun_paterno != "") ? fun_nombre + " " + fun_paterno : fun_nombre + " " + fun_materno;
                Session["us_id"] = Convert.ToInt32(funX.Tables[0].Rows[0]["us_id"]);
                Session["per_id"] = Convert.ToInt32(funX.Tables[0].Rows[0]["us_per_id"]);
                Session["per_nombres"] = nombre_funcionario;
                Session["per_nom"] = fun_nombre;
                Session["correo"] = funX.Tables[0].Rows[0]["us_correo_interno"].ToString();
                Session["rol"] = funX.Tables[0].Rows[0]["rol_descripcion"].ToString();
                Session["usuario"]= usuario.us_usuario;
                string d = funX.Tables[0].Rows[0]["rol_descripcion"].ToString();
                if (d == "CHEQUES")
                {
                    string x = Session["per_id"].ToString();
                    Response.Redirect("Cheques/BuscarProceso.aspx?id="+ Convert.ToInt32(Session["per_id"]));
                }
                Response.Redirect("Inicio/Sigrh");
            }
            else
            {
                sc = "$.notify({ icon: 'error', message: 'Ocurrió un error en el proceso.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
            }
        }
        else
        {
            cls_persona persona = new cls_persona();
            DataSet ds = persona.ObtenerTablaGrilla(loginSigrh.UserName, "", loginSigrh.Password, "", "", "", "", "", "", "", "", "", "", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                //Session["us_id"] = Convert.ToInt32(funX.Tables[0].Rows[0]["us_id"]);
                Session["per_id"] = Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"]);
                Session["per_nombres"] = ds.Tables[0].Rows[0]["per_ap_paterno"].ToString() + ds.Tables[0].Rows[0]["per_ap_materno"].ToString() + ds.Tables[0].Rows[0]["per_nombres"].ToString();
                Session["per_nom"] = ds.Tables[0].Rows[0]["per_nombres"];
                Session["correo"] = "";
                Session["rol"] = "INVITADO";
                Response.Redirect("Inicio/Sigrh");

                //Response.Redirect("ControlPersonal/LicenciaJustificada");
            }
            else
            {
                sc = "$.notify({ icon: 'error', message: 'El usuario ingresado no existe.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
            }
        }
    }

    protected void loginSigrh_Authenticate(object sender, AuthenticateEventArgs e)
    {
        try
        {
            Autenticar(e);
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
            sc = "$.notify({ icon: 'error', message: 'Usuario no existe y/o no se encuentra habilitado.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }
}