using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
using System.Data;
public partial class Evaluacion_PreguntasAbiertas : System.Web.UI.Page
{
    int ca_id = 0;//id de cargo
    int per_id = 0;//código de funcionario
    int id_evaluacion = 0;//id evaluacion
    int periodo; string gestion;
    int per_id_evaluado = 0;
    string tipo_evaluacion = "";
    private string categoria = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            ca_id = Convert.ToInt32(HttpContext.Current.Session["ca_id_funcionario"].ToString());
            periodo = Convert.ToInt32(HttpContext.Current.Session["periodo"].ToString());
            per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"]);
            id_evaluacion = Convert.ToInt32(HttpContext.Current.Session["id_evaluacion"]);
            per_id_evaluado = Convert.ToInt32(HttpContext.Current.Session["imprimir_per_id"]);
            tipo_evaluacion = Convert.ToString(HttpContext.Current.Session["tipo_evaluacion"]);

            if (HttpContext.Current.Session["respuestas_DNC"] == null)
                Session["respuestas_DNC"] = 0;
            if (!Page.IsPostBack)
            {                
                Bind_DatosPersonales(per_id);//se cargan los datos personales del evaluado y evaluador
                BindMenuSmall();
                Bind_PreguntasAbiertas();//se cargan las preguntas abiertas
                //***********Bind_DNC();
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
    private void Gestion_Bind()
    {
        ///int periodo = Convert.ToInt32(HttpContext.Current.Session["periodo"].ToString());//cls_Formulario.GestionActual("periodo").Tables[0].Rows[0]["periodo_gestion"].ToString();
        gestion = cls_Formulario.GestionActual("gestion",tipo_evaluacion).Tables[0].Rows[0]["periodo_gestion"].ToString();
        Session["gestion"] = gestion;
        Session["periodo"] = periodo;
        //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "gestion", "$('h6').text('Evaluación del Desempeño " + periodo + "/" + gestion + "');", true);
    }
    protected void Bind_DatosPersonales(int per_id)
    {
        //STAR DATOS EVALUADO
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
    protected void Bind_PreguntasAbiertas()
    {
        PreguntasAbiertas.DataSource = cls_PreguntasAbiertas.Bind_PreguntasAbiertas(id_evaluacion);
        PreguntasAbiertas.DataBind();
    }
    protected void Registrar_PreguntasAbiertas(object sender, EventArgs e)
    {
        //se registra en la base de datos, las preguntas abiertas, en la bd no se podrá realizar el insert en caso de respuesta vacía
        foreach (RepeaterItem item in PreguntasAbiertas.Items)
        {
                foreach (Control pa in item.Controls)
                {
                    TextBox txt = pa as TextBox;
                    Label pa_id = (Label)item.FindControl("lblPa_id");
                    if (txt != null)
                    {
                    cls_PreguntasAbiertas.Registrar_PreguntasAbiertas(Convert.ToInt32(pa_id.Text), id_evaluacion, txt.Text);
                    }
                }
        }
       //***** GuardarDnc();//se registran las necesidades de capacitacion en la base de datos, en la bd no se podrá realizar el insert en caso de dnc vacía
        //pasamos la variable de sesión a la cual utilizaremos en el reporte
        Session["imprimir_ca_id"] = HttpContext.Current.Session["ca_id_funcionario"].ToString();
        periodo = +Convert.ToInt32(HttpContext.Current.Session["periodo"].ToString());
        Session["id_evaluacion"] = Convert.ToString( id_evaluacion);
        Response.Redirect("FormularioEvaluacion.aspx");
    }

    protected void PreguntasAbiertas_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //Se enlazan las preguntas abiertas y se cargan las respuestas si existen
        TextBox txt = (TextBox)e.Item.FindControl("txtPreguntasAbiertas");
        Label pa_id = (Label)e.Item.FindControl("lblPa_id");
        DataSet DS = cls_PreguntasAbiertas.Bind_PreguntasAbiertas_Resupuestas(id_evaluacion, Convert.ToInt32(pa_id.Text));
        if (DS.Tables[0].Rows.Count > 0)
        {
            txt.Text = DS.Tables[0].Rows[0]["rpa_respuesta"].ToString();
        }
        if (pa_id.Text == "2") txt.CssClass = "form-control border-danger";
        if (pa_id.Text == "4") txt.CssClass = "form-control border-primary";
    }
    //protected void Bind_DNC()
    //{
    //    //se cargan las necesidades de capacitación en caso de existir
    //    DataSet DS = cls_NecesidadesCapacitacion.Bind_Necesidades_Capacitacion_Respuestas(id_evaluacion);
    //    rblDnc1.DataSource = rblDnc2.DataSource = rblDnc3.DataSource = rblDnc4.DataSource = rblDnc5.DataSource = rblDnc6.DataSource = rblDnc7.DataSource = cls_NecesidadesCapacitacion.Bind_Necesidades_Capacitacion();
    //    rblDnc1.DataValueField = rblDnc2.DataValueField = rblDnc3.DataValueField = rblDnc4.DataValueField = rblDnc5.DataValueField = rblDnc6.DataValueField = rblDnc7.DataValueField =  "rdnc_id_dnc";
    //    rblDnc1.DataTextField = rblDnc2.DataTextField = rblDnc3.DataTextField = rblDnc4.DataTextField = rblDnc5.DataTextField = rblDnc6.DataTextField = rblDnc7.DataTextField =  "cat_descripcion";
    //    rblDnc1.DataBind(); rblDnc2.DataBind(); rblDnc3.DataBind(); rblDnc4.DataBind(); rblDnc5.DataBind(); rblDnc6.DataBind(); rblDnc7.DataBind(); 
    //    rblDnc1.SelectedValue = "1"; rblDnc2.SelectedValue = "2";
    //    lblRdnc_id1.Text = lblRdnc_id2.Text = lblRdnc_id3.Text = lblRdnc_id4.Text = lblRdnc_id5.Text = lblRdnc_id6.Text = lblRdnc_id7.Text = "0";
    //    rblDnc1.SelectedValue = rblDnc3.SelectedValue = rblDnc4.SelectedValue = rblDnc5.SelectedValue = rblDnc6.SelectedValue = rblDnc7.SelectedValue = "1";

    //    if (DS.Tables[0].Rows.Count > 0)
    //    {
    //        Session["respuestas_DNC"] = DS.Tables[0].Rows.Count;
    //        foreach (DataRow item in DS.Tables[0].Rows)
    //        {
    //            switch (item["nro"].ToString())
    //            {
    //                case "1":
    //                    txtDnc1.Text = item["rdnc_respuesta"].ToString();
    //                    lblRdnc_id1.Text = item["rdnc_id"].ToString();
    //                    rblDnc1.SelectedValue = item["rdnc_id_dnc"].ToString();
    //                    break;
    //                case "2":
    //                    txtDnc2.Text = item["rdnc_respuesta"].ToString();
    //                    lblRdnc_id2.Text = item["rdnc_id"].ToString();
    //                    rblDnc2.SelectedValue = item["rdnc_id_dnc"].ToString();
    //                    break;
    //                case "3":
    //                    txtDnc3.Text = item["rdnc_respuesta"].ToString();
    //                    lblRdnc_id3.Text = item["rdnc_id"].ToString();
    //                    rblDnc3.SelectedValue = item["rdnc_id_dnc"].ToString();
    //                    break;
    //                case "4":
    //                    txtDnc4.Text = item["rdnc_respuesta"].ToString();
    //                    lblRdnc_id4.Text = item["rdnc_id"].ToString();
    //                    rblDnc4.SelectedValue = item["rdnc_id_dnc"].ToString();
    //                    break;
    //                case "5":
    //                    txtDnc5.Text = item["rdnc_respuesta"].ToString();
    //                    lblRdnc_id5.Text = item["rdnc_id"].ToString();
    //                    rblDnc5.SelectedValue = item["rdnc_id_dnc"].ToString();
    //                    break;
    //                case "6":
    //                    txtDnc6.Text = item["rdnc_respuesta"].ToString();
    //                    lblRdnc_id6.Text = item["rdnc_id"].ToString();
    //                    rblDnc6.SelectedValue = item["rdnc_id_dnc"].ToString();
    //                    break;
    //                case "7":
    //                    txtDnc7.Text = item["rdnc_respuesta"].ToString();
    //                    lblRdnc_id7.Text = item["rdnc_id"].ToString();
    //                    rblDnc7.SelectedValue = item["rdnc_id_dnc"].ToString();
    //                    break;
    //            }
    //        }
    //        //si hay más de dos dnc, mostramos la totalidad de los textbox
    //        if (DS.Tables[0].Rows.Count > 2) ScriptManager.RegisterStartupScript(Page, Page.GetType(), "MostrarDncExtras", "$('#DncNavbar').show();", true);
    //    }
    //}
    //protected void Dnc_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    //enlazamos los radiobutton para la clasificación de las dnc
    //    RadioButtonList rdblDnc = (RadioButtonList)e.Item.FindControl("rblDnc");
    //    Label rdnc_id_dnc = (Label)e.Item.FindControl("lblRdnc_id_dnc");
    //    rdblDnc.DataSource = cls_NecesidadesCapacitacion.Bind_Necesidades_Capacitacion();
    //    rdblDnc.DataValueField = "rdnc_id_dnc";
    //    rdblDnc.DataTextField = "cat_descripcion";
    //    rdblDnc.DataBind();
    //    rdblDnc.SelectedValue =rdnc_id_dnc.Text;
    //}
    //protected void GuardarDnc() {
    //    //registramos las dnc en la bd. La BD restringirá el insert en caso de dnc vacíos
    //    cls_NecesidadesCapacitacion.Registar_Dnc(Convert.ToInt32(lblRdnc_id1.Text), Convert.ToInt32(rblDnc1.SelectedValue), id_evaluacion, txtDnc1.Text);
    //    cls_NecesidadesCapacitacion.Registar_Dnc(Convert.ToInt32(lblRdnc_id2.Text), Convert.ToInt32(rblDnc2.SelectedValue), id_evaluacion, txtDnc2.Text);
    //    cls_NecesidadesCapacitacion.Registar_Dnc(Convert.ToInt32(lblRdnc_id3.Text), Convert.ToInt32(rblDnc3.SelectedValue), id_evaluacion, txtDnc3.Text);
    //    cls_NecesidadesCapacitacion.Registar_Dnc(Convert.ToInt32(lblRdnc_id4.Text), Convert.ToInt32(rblDnc4.SelectedValue), id_evaluacion, txtDnc4.Text);
    //    cls_NecesidadesCapacitacion.Registar_Dnc(Convert.ToInt32(lblRdnc_id5.Text), Convert.ToInt32(rblDnc5.SelectedValue), id_evaluacion, txtDnc5.Text);
    //    cls_NecesidadesCapacitacion.Registar_Dnc(Convert.ToInt32(lblRdnc_id6.Text), Convert.ToInt32(rblDnc6.SelectedValue), id_evaluacion, txtDnc6.Text);
    //    cls_NecesidadesCapacitacion.Registar_Dnc(Convert.ToInt32(lblRdnc_id7.Text), Convert.ToInt32(rblDnc7.SelectedValue), id_evaluacion, txtDnc7.Text);

    //}
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