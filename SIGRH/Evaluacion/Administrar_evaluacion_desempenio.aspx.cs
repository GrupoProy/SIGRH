using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
using Solution_Framework_Evaluacion.DataAccessLayer;
using System.Data;

public partial class Evaluacion_Administrar_evaluacion_desempenio : System.Web.UI.Page
{
    private int id_gestion_activa = 0;
    private int id_periodo_activa = 0;
    private string gestion_activa;
    private string nombre_evaluacion;
    private string nombreTipoEvaluacion;
    protected void Page_Load(object sender, EventArgs e)
    {
        Session.Remove("nombre_evaluacion"); Session["nombre_evaluacion"] = null;
        Session.Remove("tipo_evaluacion"); Session["tipo_evaluacion"] = null;
        ImgBtn_1.Visible = true;
        Evaluacion("P");
        lblEvaluacion.Text = nombreTipoEvaluacion;
        if (id_gestion_activa>0)
        {
            ImgBtn_2.Visible = true;
            ImgBtn_3.Visible = false;
            ImgBtn_4.Visible = true;
        }
        else
        {
            ImgBtn_2.Visible = false;
            ImgBtn_3.Visible = true;
            ImgBtn_4.Visible = false;
        }
    }
    protected void Evaluacion(string tipo )
    {
        DataSet EvaluacionDataSet = cls_Habilitados.EvaluacionActiva(tipo);
        foreach (DataTable table in EvaluacionDataSet.Tables)
        {
            // Agrega las columnas que faltan
            if (!table.Columns.Contains("id_gestion_activa"))
            {
                table.Columns.Add("id_gestion_activa", typeof(string));
            }
            if (!table.Columns.Contains("id_periodo_activa"))
            {
                table.Columns.Add("id_periodo_activa", typeof(string));
            }
            if (!table.Columns.Contains("gestion_activa"))
            {
                table.Columns.Add("gestion_activa", typeof(string));
            }
            ///////////////////////////////////////////////////////////////////
            foreach (DataRow row in table.Rows)
            {
                // Agrega los valores de las nuevas columnas
                id_gestion_activa = Convert.ToInt32(row["id_gestion_activa"]);
                id_periodo_activa = Convert.ToInt32(row["id_periodo_activa"]);
                gestion_activa = Convert.ToString(row["gestion_activa"]);
            }
        }
        string semestre="";
        if (id_periodo_activa == 1)
        {
            semestre = "Primer Semestre  " ;
        }
        else
        {
            semestre = "Segundo Semestre  ";
        }
        string tipo_eva = "";
        if (tipo =="P")
        {
            tipo_eva = " DESEMPEÑO";
        }
        else
        {
            tipo_eva = "L RENDIMIENTO";
        }

        nombre_evaluacion = semestre + gestion_activa + " - EVALUACION DE" + tipo_eva;
        nombreTipoEvaluacion = " ********** EVALUACION DE" + tipo_eva + " ********** ";
    }
    protected void ImgBtn_1_Click(object sender, EventArgs e)
    {
        Session["tipo_evaluacion"] = "P";
        Response.Redirect("HistorialEvaluacionDesempenio.aspx");
    }
    protected void ImgBtn_2_Click(object sender, EventArgs e)
    {
        Session["tipo_evaluacion"] = "P";
        Session["nombre_evaluacion"] = nombre_evaluacion;
        Response.Redirect("Seguimiento_evaluacion_desempenio.aspx");
    }
    protected void ImgBtn_3_Click(object sender, EventArgs e)
    {
        Session["tipo_evaluacion"] = "P";
        Response.Redirect("Habilitar_evaluacion_desempenio.aspx");

    }
    protected void ImgBtn_4_Click(object sender, EventArgs e)
    {
        Session["tipo_evaluacion"] = "P";
        Session["nombre_evaluacion"] = nombre_evaluacion;
        Response.Redirect("Asignar_Evaluador.aspx");

    }

}