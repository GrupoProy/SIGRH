using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DescriptorPuesto_ListaEvaluaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            var id = Convert.ToString(Session["per_id"]);
            if (!Page.IsPostBack)
            {
                cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
                int per_id = Convert.ToInt32(id);
                descriptor_puestos = new cls_mp_descriptor_puestos();
                int superv_id=descriptor_puestos.Obtener_idSuperv(per_id);
                LLenarGridListaTarea(superv_id);

                // descriptor_puestos = new cls_mp_descriptor_puestos();
                //int superv_id = descriptor_puestos.Obtener_idSuperv(id_per);
                // LLenarGridResultadosE(superv_id);
                /* cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
                 int ide = Convert.ToInt32(id);
                 LlenarTE(ide);*/

            }

        }
        else Response.Redirect("../Index");

    }

    protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        if (index >= 0 && index < GridView3.DataKeys.Count)
        {
            string r_id = GridView3.DataKeys[index].Value.ToString();
            h_r_id.Value = r_id;
           // Session["r_id"] = r_id;
            // TotalAcumulado.Text = totalE.ToString();

            switch (e.CommandName)
            {
                case "getEvaluar":
                    Session["r_id"] = r_id;
                    Response.Redirect("Evaluar.aspx");
                    /* string descrip_pu_id = GridView3.DataKeys[index].Value.ToString();
                     * 
                     Session["r_id"] = r_id;*/
                    //LlenarDatosResultado(Convert.ToInt32(r_id));
                    //  ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalEditarResultado').modal('show');", true);*/
                    break;
                case "GetDelete":
                   /* string sc = "$('#eliminarResultado').modal('show');";
                    SetScript(sc, "");*/
                    break;
                case "GetArchivo":
                   /* ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#myModal3').modal('show');", true);
                    break;*/
                default:
                    break;
            }
        }
    }
    private void LLenarGridListaTarea(int supervisor_id)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();

        int per_id = Convert.ToInt32(Session["per_id"]);
        int superv_id = descriptor_puestos.Obtener_idSuperv(per_id);

        if (superv_id != 0)
        {
            var dataSource = descriptor_puestos.ListarTareaSuper(superv_id);

            if (dataSource != null)
            {
                GridView3.DataSource = dataSource;
            }
            else
            {
                GridView3.DataSource = new List<object>();
            }
        }
        else
        {
            GridView3.DataSource = new List<object>();
        }

        GridView3.DataBind();
        //cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        //string rt = E;


    }


    /*public void LlenarTE(int id)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        int id_per = Convert.ToInt32(Session["per_id"]);
        int sprv_id = descriptor_puestos.Obtener_idSuperv(id_per);
        DataSet data = descriptor_puestos.ListarTareaSuper(sprv_id);

        if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
        {
            Repeater1.DataSource = data;
            Repeater1.DataBind();
        }
    }*/
   /* protected void evaluar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Evaluar");


    }*/


}