using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
using Solution_Framework_Evaluacion.DataAccessLayer;
using System.Data;


public partial class Evaluacion_HistorialEvaluacionRendimiento : System.Web.UI.Page
{
    private int id_gestion = 0; //
    private int id_periodo = 0; //
    private int totalSinIniciar = 0;
    private int totalEnProceso = 0;
    private int totalFinalizado = 0;
    private string nombre_evaluacion = "";
    private string tipo_evaluacion = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //se limpian las variables de sesión para registrarlas luego con la información del funcionario a evaluar
        Session.Remove("id_gestionE"); Session["id_gestionE"] = null;
        Session.Remove("id_periodoE"); Session["periodoE"] = null;
        Session.Remove("pagina_actual"); Session["pagina_actual"] = null;
        Session.Remove("tipo_evaluacion2"); Session["tipo_evaluacion2"] = null;

        tipo_evaluacion = Convert.ToString(HttpContext.Current.Session["tipo_evaluacion"]);

        if (tipo_evaluacion == "C")
        {
            nombre_evaluacion = "EVALUACION DEL RENDIMIENTO";
        }
        else
        {
            nombre_evaluacion = "EVALUACION DEL DESEMPEÑO";
        }
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                ListarEvaluaciones(tipo_evaluacion);
                lblEvaluacion.Text = nombre_evaluacion;
            }

        }

    }

    protected void ListarEvaluaciones(string tipo_evaluacion)
    {
        DataSet dependientesDataSet = cls_Habilitados.HistorialEvaluaciones("C7", tipo_evaluacion);
        foreach (DataTable table in dependientesDataSet.Tables)
        {
            if (!table.Columns.Contains("eva_periodo"))
            {
                table.Columns.Add("eva_periodo", typeof(string));
            }
            if (!table.Columns.Contains("eva_pr_id"))
            {
                table.Columns.Add("eva_pr_id", typeof(string));
            }
            if (!table.Columns.Contains("casos"))
            {
                table.Columns.Add("casos", typeof(string));
            }
            if (!table.Columns.Contains("periodo_evaluacion"))
            {
                table.Columns.Add("periodo_evaluacion", typeof(string));
            }

            ///////////////////////////////////////////////////////////////////

            foreach (DataRow row in table.Rows)
            {
                // Agrega los valores de las nuevas columnas
                row["eva_pr_id"] = row["eva_pr_id"];
                row["eva_periodo"] = row["eva_periodo"];
                row["casos"] = row["casos"];
                row["periodo_evaluacion"] = row["periodo_evaluacion"];

                ////////////////////////////////////////////////////////////////////////////////////////

            }
        }

        totalSinIniciar = 45;
        totalEnProceso = 10;
        totalFinalizado = 6;
        GvListaEvaluaciones.DataSource = dependientesDataSet;
        GvListaEvaluaciones.DataBind();


    }
    protected void GvListaEvaluaciones_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (GvListaEvaluaciones.Rows.Count > 0)
        {
            if (GvListaEvaluaciones.HeaderRow != null)
            {
                GvListaEvaluaciones.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GvListaEvaluaciones.FooterRow != null)
            {
                GvListaEvaluaciones.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void GvListaEvaluaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        //string unidad_s = GvListaEvaluaciones.DataKeys[index2].Values[1].ToString();
        switch (e.CommandName)
        {
            case "Ver":    //se almacena la información del evaluado seleccionado para cargar sus respuestas en variables de sesión
                Session["id_gestionE"] = GvListaEvaluaciones.DataKeys[index].Values["eva_pr_id"].ToString();
                Session["id_periodoE"] = GvListaEvaluaciones.DataKeys[index].Values["eva_periodo"].ToString();
                Session["pagina_actual"] = Request.Url.ToString();
                Session["periodo_evaluacion"] = GvListaEvaluaciones.DataKeys[index].Values["periodo_evaluacion"].ToString();
                Session["nombre_evaluacion"] = nombre_evaluacion;
                Session["tipo_evaluacion2"] = tipo_evaluacion;
                Response.Redirect("VerHistorialEvaluacion.aspx");
                break;
            case "Informe":    //se almacena la información del evaluado seleccionado para cargar sus respuestas en variables de sesión
                Session["id_gestionE"] = GvListaEvaluaciones.DataKeys[index].Values["eva_pr_id"].ToString();
                Session["id_periodoE"] = GvListaEvaluaciones.DataKeys[index].Values["eva_periodo"].ToString();
                Session["pagina_actual"] = Request.Url.ToString();
                Session["nombre_evaluacion"] = Convert.ToString(HttpContext.Current.Session["nombre_evaluacion"]);
                Session["tipo_evaluacion2"] = tipo_evaluacion;

                lblEvaluacionReporte.Text = GvListaEvaluaciones.DataKeys[index].Values["periodo_evaluacion"].ToString();
                btnInforme1.Visible = true;
                btnInforme2.Visible = true;
                btnAnexo1.Visible = true;
                btnAnexo2.Visible = true;
                btnAnexo3.Visible = true;
                btnAnexo4.Visible = true;
                btnAnexo5.Visible = true;
                btnAnexo6.Visible = true;
                break;
        }
    }
}