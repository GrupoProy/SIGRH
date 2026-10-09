using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_AprobarComision : System.Web.UI.Page
{

    private cls_cp_licencia_justificada _licencia_justificada = null;
   
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (HttpContext.Current.Session["us_id"] != null)
        {


        }
        else
        {
            Response.Redirect("../index");
        }
    }

    // Extrae el código a un método independiente
    private void Compartido()
    {
        string trimmedInput = codigoComisionInput.Text.Trim();
        if (Int32.TryParse(trimmedInput, out int codigoComision))
        {
            _licencia_justificada = new cls_cp_licencia_justificada();
            _licencia_justificada.ActualizarLC(codigoComision);

            string script = $"showModalAndClearInput('{codigoComision}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", script, true);

            codigoComisionInput.Text = "";
        }
        else
        {
            
        }
    }


    // Usa el método en ambos eventos
    protected void codigoComisionInput_TextChanged(object sender, EventArgs e)
    {
        Compartido();
    }

    protected void BtnMismoFuncionamiento_Click(object sender, EventArgs e)
    {
        Compartido();
    }
}