using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
public partial class Evaluacion_FactoresEvaluacion : System.Web.UI.Page
{
    int ca_id = 0;//id de cargo
    int per_id = 0;//código de funcionario
    int id_evaluacion = 0;//id evaluacion
    int respuestas_fev = 0;//flag para saber si la evaluación ya tiene factores de evaluación
    int periodo;
    string gestion;
    int per_id_evaluado = 0;
    string tipo_evaluacion = "";
    private string categoria = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            //asignamos a las variables, las variables de sesión establecidas en el Listado de Evaluación
            ca_id = Convert.ToInt32(HttpContext.Current.Session["ca_id_funcionario"].ToString());
            periodo = Convert.ToInt32(HttpContext.Current.Session["periodo"].ToString());
            per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"]);
            id_evaluacion = Convert.ToInt32(HttpContext.Current.Session["id_evaluacion"]);
            per_id_evaluado = Convert.ToInt32(HttpContext.Current.Session["imprimir_per_id"]);
            tipo_evaluacion = Convert.ToString(HttpContext.Current.Session["tipo_evaluacion"]);

            if (HttpContext.Current.Session["respuestas_factores_evaluacion"] != null)
                respuestas_fev = Convert.ToInt32(HttpContext.Current.Session["respuestas_factores_evaluacion"]);

            if (!Page.IsPostBack)
            {
                Bind_DatosPersonales(per_id);//se cargan los datos personales del evaluado y evaluador
                BindMenuSmall();

                Bind_FactoresEvaluacion();//se cargan los factores de evaluación por categoría 
                VerificarRespuestas_Evaluacion(id_evaluacion);//se verifica si existen respuestas asociadas al id de evaluación

                BIndTareasRecurrentes(id_evaluacion, tipo_evaluacion);

            }

            Gestion_Bind();//se carga la información de la gestión y periodo
        }
    }
    private void BindMenuSmall()
    {
        if (categoria == "D")
        {
            lblResultados.Text = "";
        }
        else
        {
            if (tipo_evaluacion == "P")
            { lblResultados.Text = "RESULTADOS ESPECIFICOS"; }
            else
            { lblResultados.Text = "TAREAS ESPECIFICAS"; }

        }

        lblFactores.Text = "FACTORES DE EVALUACION";
        lblPreguntas.Text = "PREGUNTAS ABIERTAS";
    }
    private void VerificarRespuestas_Evaluacion(int id_evaluacion)
    {
        if (HttpContext.Current.Session["respuestas_factores_evaluacion"] == null)
        {
            respuestas_fev = cls_Formulario.VerificarRespuestas_Evaluacion(id_evaluacion, "FactoresEvaluacion");
            if (respuestas_fev > 0)
            {
                Session["respuestas_factores_evaluacion"] = respuestas_fev;

            }
        }
    }
    private void BIndTareasRecurrentes(int id_evaluacion, string tipo)
    {
        DataSet tareasDataSet = cls_FactoresEvaluacion.ListarTareasRecurrentes(id_evaluacion, tipo);
        ddlTareas.DataSource = tareasDataSet;
        ddlTareas.DataTextField = "tar_descripcion";
        ddlTareas.DataValueField = "tar_id";
        ddlTareas.DataBind();
    }
    private void Gestion_Bind()
    {
        //////periodo = Convert.ToInt32(HttpContext.Current.Session["periodo"].ToString());//cls_Formulario.GestionActual("periodo").Tables[0].Rows[0]["periodo_gestion"].ToString();
        gestion = cls_Formulario.GestionActual("gestion", tipo_evaluacion).Tables[0].Rows[0]["periodo_gestion"].ToString();
        Session["gestion"] = gestion;
        Session["periodo"] = periodo;
       //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gestion", "$('h6').text('Evaluación del Desempeño " + periodo + "/" + gestion + "');", true);
    }
    protected void Bind_DatosPersonales(int per_id)
    {

        DataSet DS = cls_DatosPersonales.FuncionarioDatosPersonales(per_id_evaluado, periodo,tipo_evaluacion);

        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
        {
            DataRow row = DS.Tables[0].Rows[0];

            // Asigna los datos a los elementos correspondientes
            ltlEvaluado.Text = $"{row["nombres"]} {row["paterno"]} {row["materno"]}";
            ltlPuestoEvaluado.Text = $"{row["puesto"]}";

            // Puedes cargar la imagen en un control Image de ASP.NET
            if (row["fp_foto"] != DBNull.Value && row["fp_foto"] != null)
            {
                byte[] bytes = (byte[])row["fp_foto"];
                string base64String = Convert.ToBase64String(bytes);
                string imageUrl = "data:image/jpg;base64," + base64String;
                categoria = $"{row["es_categoria"]}";

                // Asegúrate de que imgEvaluado es el ID correcto de tu control Image
                imgEvaluado.ImageUrl = imageUrl;
            }
            else
            {
                // Si no hay imagen, muestra una imagen predeterminada
                imgEvaluado.ImageUrl = "~/Content/img/theme/user3.jpg";
            }
        }
        //
    }
    public void Bind_FactoresEvaluacion()
    {
        FactoresEvaluacion.DataSource = cls_FactoresEvaluacion.Bind_FactoresEvaluacion(ca_id, "FactoresEvaluacion",id_evaluacion);
        FactoresEvaluacion.DataBind();
    }
    protected void Verificar_FactoresEvaluacion(object sender, EventArgs e)//Antes de Pasar a la siguente instancia, se verifica si no faltan respuestas que registrar
    {
        bool verificacion = true;
        if (respuestas_fev == 0)
        {
            int ContadorFEV = 1;
            foreach (RepeaterItem item in FactoresEvaluacion.Items)
            {
                if (ContadorFEV <= FactoresEvaluacion.Items.Count)
                {
                    foreach (Control rdb in item.Controls)
                    {
                        RadioButtonList radio = rdb as RadioButtonList;
                        Label ci_id = (Label)item.FindControl("lblRfe_ci_id");
                        if (radio != null)
                        {
                            if (radio.SelectedValue == "" || radio.SelectedIndex == -1) { verificacion = false; break; }
                        }
                    }
                    ContadorFEV = ContadorFEV + 1;
                }
            }
        }
        else
        {
            //si existe al menos un factor calificado pero no en su totalidad
            int respuestas = Convert.ToInt32(cls_ResultadosEspecificos.RespuestasEspecificasFactores(id_evaluacion, "RespuestasFactores"));
            if (respuestas == (FactoresEvaluacion.Items.Count ))
            { verificacion = true; }
            else
            { verificacion = false; }
        }
        if (verificacion == true)
        {
            Session["tipo_evaluacion"] = tipo_evaluacion;
            Response.Redirect("PreguntasAbiertas.aspx");
        }
        else
        { ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "$(function(){ $('#ModalAlerta1').modal('show'); });", true); }
    }
    [System.Web.Services.WebMethod]
    public static void Registrar(int rfe_pond_id, int rfe_ci_id)//Registra en la base de datos, los factores de evaluación, al momento de hacer click en ellos
    {
        try
        {
            int id_evaluacion = Convert.ToInt32(HttpContext.Current.Session["id_evaluacion"]);
            cls_FactoresEvaluacion.Registrar_FactoresEvaluacion(id_evaluacion, rfe_ci_id, rfe_pond_id);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error en el método 'Registrar': " + ex.Message);
        }
    }

    protected void FactoresEvaluacion_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //Se utiliza e.Item.FindControl para encontrar controles específicos dentro del elemento actual del Repeater.
        RadioButtonList rbl = (RadioButtonList)e.Item.FindControl("rblPonderadoresFEV");
        Label ci_id = (Label)e.Item.FindControl("lblRfe_ci_id");
        //se enlazan los ponderadores de los factores de evaluación
        rbl.DataSource = cls_FactoresEvaluacion.Bind_FactoresEvaluacion_Ponderadores();
        rbl.DataTextField = "cat_descripcion";
        rbl.DataValueField = "cat_id";
        rbl.DataBind();
        
        DataSet DS = cls_FactoresEvaluacion.Bind_FactoresEvaluacion_Ponderadores_Respuestas(id_evaluacion, Convert.ToInt32(ci_id.Text));
        //se cargan las respuestas si existen
        if (DS.Tables[0].Rows.Count > 0)
        {
            rbl.SelectedValue = DS.Tables[0].Rows[0]["pond_id"].ToString();
            ColorearRespuestas(rbl, DS.Tables[0].Rows[0]["respuesta"].ToString());//para facilitar la visualización, se colorean las respuestas
        }
    }
    private void ColorearRespuestas(RadioButtonList rbl, string respuesta)
    {//para facilitar la visualización, se colorean las respuestas
        switch (respuesta)
        {
            case "EXCELENTE":
                rbl.BackColor = System.Drawing.Color.LightGreen;
                break;
            case "BUENO":
                rbl.BackColor = System.Drawing.Color.LightBlue;
                break;
            case "SUFICIENTE":
                rbl.BackColor = System.Drawing.Color.Orange;
                break;
            case "EN OBSERVACIÓN":
                rbl.BackColor = System.Drawing.Color.LightCoral;
                break;
        }
    }
    protected void imgListado_Click(object sender, EventArgs e)
    {
        if (tipo_evaluacion == "P")
        { Response.Redirect("ListadoEvaluacion.aspx"); }
        else
        {
            Response.Redirect("ListadoEvaluacionR.aspx");
        }
    }
}