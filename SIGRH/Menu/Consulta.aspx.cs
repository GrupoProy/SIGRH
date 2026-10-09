using Solution_Framework_Kardex.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu_Consulta : System.Web.UI.Page
{
    cls_informacion info = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["as_id"] = Request.QueryString["id2"].ToString();
            Session["per_id"] = Request.QueryString["id"].ToString();
            CargarInformacion();
        }
    }

    private void CargarInformacion()
    {
        info = new cls_informacion();
        int as_id =  Convert.ToInt32(Session["as_id"]);
        int per_id = Convert.ToInt32(Session["per_id"]);
        var detalles = info.UltimoCargo(as_id, per_id);
        if (detalles.Tables.Count > 0)
        {
            if (detalles.Tables[0].Rows.Count > 0)
            {
                var informacion = detalles.Tables[0].Rows[0];
                ltl_cargo.Text = validarCampo(informacion["Cargo"]);
                ltl_nombre.Text = validarCampo(informacion["NOMBRE_COMPLETO"]);
                ltl_ci.Text = validarCampo(informacion["CI"]);
                ltl_puesto.Text = validarCampo(informacion["puesto"]);
                ltl_hb.Text = validarCampo(informacion["haber_basico"]);
                ltl_bono_f.Text = validarCampo(informacion["bono_frontera"]);
                ltl_bono_a.Text = validarCampo(informacion["bono_antiguedad"]);
                ltl_afp.Text = validarCampo(informacion["descuento_afp"]);
                ltl_total_g.Text = validarCampo(informacion["total_ganado"]);
                ltl_liquido.Text = validarCampo(informacion["liquido"]);
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
}