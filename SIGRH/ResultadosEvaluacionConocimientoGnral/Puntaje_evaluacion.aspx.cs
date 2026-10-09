using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Evaluacion_puntaje_Puntaje_evaluacion : System.Web.UI.Page
{
    private cls_cp_puntaje_evaluacion puntaje_evaluacion = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (HttpContext.Current.Session["per_id"] != null)
            {
                int id_per = Convert.ToInt32(Session["per_id"]);
               
                
                puntaje_evaluacion = new cls_cp_puntaje_evaluacion();
                decimal a = puntaje_evaluacion.puntaje_evaluacion(id_per);

                ID_Puntaje.Text = Convert.ToString(a);

            }
            else
            {
                Response.Redirect("../index");
            }

        }
    }
}