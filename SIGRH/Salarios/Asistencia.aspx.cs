using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salarios_Asistencia : System.Web.UI.Page
{
    private int CodGestion;
    private int CODMes;
    private int Contador;
    private int cont2;

    protected void Page_Load(object sender, EventArgs e)
    {
        CargarCombos();
    }

    protected void Timer_Tick(object sender, EventArgs e)
    {

    }

    private void CargarCombos()
    {
        ddl_tipo_func.Items.Add("Administrativo");
        ddl_tipo_func.Items.Add("Consultor");
    }
    private void SepararCod(string texto)
    {
        string t = "";
        int e;
    }

    protected void BtnAgregar_Click(object sender, EventArgs e)
    {
        string x = HttpContext.Current.Session["per_id"].ToString();
        Response.Redirect("../Cheques/EscanearCheque.aspx?id="+x);
    }
}