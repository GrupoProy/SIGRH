using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
using Solution_Framework_ManualPuestos.BussinessLogicLayer;

public partial class Evaluacion_ResultadosEspecificos : System.Web.UI.Page
{
    int ca_id = 0;//id de cargo
    int per_id = 0;//código de funcionario
    int id_evaluacion = 0;//id evaluacion
    int respuestas_res = 0;//flag para saber si la evaluación ya tiene resultados específicos
    int periodo;
    string gestion;
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

            if (HttpContext.Current.Session["respuestas_resultados_especificos"] != null)
                respuestas_res = Convert.ToInt32(HttpContext.Current.Session["respuestas_resultados_especificos"]);

            

            if (!Page.IsPostBack)
            {
                BindMenuSmall();
                Bind_DatosPersonales(per_id);//se cargan los datos personales del evaluado y evaluador
                Bind_ResultadosEspecificos();//se cargan los resultados específicos en los casos que corresponde
                //Si el POAI no contiene resultados específicos, se pasa los factores de evaluación
                if (ResultadosEspecificos.Items.Count == 0)
                {
                    Session["tipo_evaluacion"] = tipo_evaluacion;
                    Response.Redirect("FactoresEvaluacion.aspx");
                }
                else
                {
                    VerificarRespuestas_Evaluacion(id_evaluacion);//se verifica si existen respuestas asociadas al id de evaluación }
                }
            }
            Gestion_Bind();//se carga la información de la gestión y periodo

        }

    }
    private void BindMenuSmall()
    {
        if (categoria == "D")
        {
            lblResultados.Text = "";
            imgVerInforme.Visible = false;
        }
        else
        {
            imgVerInforme.Visible = true;
            if (tipo_evaluacion == "P")
            { lblResultados.Text = "RESULTADOS ESPECIFICOS"; }
            else
            { lblResultados.Text = "TAREAS ESPECIFICAS"; }

        }

        lblFactores.Text = "FACTORES DE EVALUACION";
        lblPreguntas.Text = "PREGUNTAS ABIERTAS";
    }
    private void VerificarRespuestas_Evaluacion(int id_evaluacion) {
        if (HttpContext.Current.Session["respuestas_resultados_especificos"] == null)
        {
            respuestas_res = cls_Formulario.VerificarRespuestas_Evaluacion(id_evaluacion, "ResultadosEspecificos");
            if (respuestas_res > 0)
            { 
                Session["respuestas_resultados_especificos"] = respuestas_res;

            }
        }
    }
    private void Gestion_Bind()
    {
        ///////////periodo = Convert.ToInt32(  HttpContext.Current.Session["periodo"].ToString());//cls_Formulario.GestionActual("periodo").Tables[0].Rows[0]["periodo_gestion"].ToString();
        //periodo = Convert.ToInt32(Request.QueryString["id"].ToString());
        gestion = cls_Formulario.GestionActual("gestion", tipo_evaluacion).Tables[0].Rows[0]["periodo_gestion"].ToString();
        Session["gestion"] = gestion;
        Session["periodo"] = periodo;
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
    protected void Bind_ResultadosEspecificos()
    {
        ResultadosEspecificos.DataSource = cls_ResultadosEspecificos.Bind_ResultadosEspecificos(ca_id, "ResultadosEspecificos", id_evaluacion);
        ResultadosEspecificos.DataBind();
    }

    protected void Verificar_ResultadosEspecificos(object sender, EventArgs e)
    {
        //se verifica si todos los resultados específicos fueron registrados antes de pasar a la siguiente instancia
        bool verificacion = true;
        if (respuestas_res == 0)
        {
            int id_evaluacion = Convert.ToInt32(HttpContext.Current.Session["id_evaluacion"].ToString());
            int ContadorRES = 1;
            int ca_id = Convert.ToInt32(HttpContext.Current.Session["ca_id_funcionario"].ToString());
            foreach (RepeaterItem item in ResultadosEspecificos.Items)
            {
                if (ContadorRES <= ResultadosEspecificos.Items.Count)
                {
                    foreach (Control ddl in item.Controls)
                    {
                        DropDownList dropdown = ddl as DropDownList;
                        Label res_id = (Label)item.FindControl("lblRes_Id");
                        if (dropdown != null)
                        {
                            if (dropdown.SelectedIndex == 0) { verificacion = false; break; }          
                        }
                    }
                    ContadorRES = ContadorRES + 1;
                }
            }
        }
        else
        {
            //si existe al menos un resultado/tarea especifico(a) calificado pero no en su totalidad
            int id_evaluacion = Convert.ToInt32(HttpContext.Current.Session["id_evaluacion"].ToString());
            int respuestas = Convert.ToInt32(cls_ResultadosEspecificos.RespuestasEspecificasFactores(id_evaluacion, "RespuestasEspecificos"));
            if (respuestas == (ResultadosEspecificos.Items.Count * 3))
               { verificacion = true; }
                else
                { verificacion = false; }
        }

        if (verificacion == true)
        {
            Session["tipo_evaluacion"] = tipo_evaluacion;
            Response.Redirect("FactoresEvaluacion.aspx");
        }
        else
        { ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "$(function(){ $('#ModalAlerta1').modal('show'); });", true); }
    }
    [System.Web.Services.WebMethod]
    public static void Registrar(int rp_id, string control_id , int res_id)
    {//Registra en la base de datos, los resultados específicos, al momento de hacer click en ellos
        if (rp_id > 0)
        {
            string clasificador = "";
            if (control_id.Contains("Calidad")) clasificador = "calidad";
            if (control_id.Contains("Oportunidad")) clasificador = "oportunidad";
            if (control_id.Contains("Eficiencia")) clasificador = "eficiencia";
            int ca_id = Convert.ToInt32(HttpContext.Current.Session["ca_id_funcionario"].ToString());
            int pr_id = Convert.ToInt32(HttpContext.Current.Session["pr_id"].ToString());
            int id_evaluacion = Convert.ToInt32(HttpContext.Current.Session["id_evaluacion"]);

            cls_ResultadosEspecificos.Registrar_ResultadosEspecificos(ca_id, res_id, id_evaluacion, pr_id, clasificador, rp_id);

        }  
    }

    protected void ResultadosEspecificos_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        //se enlazan los ponderadores de los resultados específicos: A,B,C
        DropDownList ddl1 = (DropDownList)e.Item.FindControl("ddlResCalidad");
        DropDownList ddl2 = (DropDownList)e.Item.FindControl("ddlResOportunidad");
        DropDownList ddl3 = (DropDownList)e.Item.FindControl("ddlResEficiencia");

        Label lblRes = (Label)e.Item.FindControl("lblRes_Id");

        DataSet DS = cls_ResultadosEspecificos.Bind_ResultadosEspecificos_Ponderadores();
        ddl1.DataSource = ddl2.DataSource = ddl3.DataSource = DS;
        ddl1.DataTextField = ddl2.DataTextField = ddl3.DataTextField = "cat_descripcion";
        ddl1.DataValueField = ddl2.DataValueField = ddl3.DataValueField = "cat_id";
        ddl1.DataBind(); ddl2.DataBind(); ddl3.DataBind();

        //se cargan las respuestas en caso de existir
        DataSet DS1 = cls_ResultadosEspecificos.Bind_ResultadosEspecificos_Ponderadores_Respuestas(Convert.ToInt32(lblRes.Text), "", "calidad", id_evaluacion);
        if (DS1.Tables[0].Rows.Count > 0)
        {
            string ponderador_calidad = DS1.Tables[0].Rows[0]["rres_rp_id"].ToString();
            if (ponderador_calidad != "")
            {
                ddl1.SelectedValue = ponderador_calidad;
                ddl1.DataValueField = DS1.Tables[0].Rows[0]["rres_res_id"].ToString();
                ColorearRespuestas(ddl1, DS1.Tables[0].Rows[0]["ponderador"].ToString());
            }
        }
        else { ddl1.Items.Insert(0, new ListItem("", "-1")); ddl1.SelectedIndex = 0; }

        DataSet DS2 = cls_ResultadosEspecificos.Bind_ResultadosEspecificos_Ponderadores_Respuestas(Convert.ToInt32(lblRes.Text), "", "oportunidad", id_evaluacion);
        if (DS2.Tables[0].Rows.Count > 0)
        {
            string ponderador_oportunidad = DS2.Tables[0].Rows[0]["rres_rp_id"].ToString();
            if (ponderador_oportunidad != "")
            {
                ddl2.SelectedValue = ponderador_oportunidad;
                ddl2.DataValueField = DS2.Tables[0].Rows[0]["rres_res_id"].ToString();
                ColorearRespuestas(ddl2, DS2.Tables[0].Rows[0]["ponderador"].ToString());
            }
        }
        else { ddl2.Items.Insert(0, new ListItem("", "-1")); ddl2.SelectedIndex = 0; }

        DataSet DS3 = cls_ResultadosEspecificos.Bind_ResultadosEspecificos_Ponderadores_Respuestas(Convert.ToInt32(lblRes.Text), "", "eficiencia", id_evaluacion);
        if (DS3.Tables[0].Rows.Count > 0)
        {
            string ponderador_eficiencia = DS3.Tables[0].Rows[0]["rres_rp_id"].ToString();
            if (ponderador_eficiencia != "")
            {
                ddl3.SelectedValue = ponderador_eficiencia;
                ddl3.DataValueField = DS3.Tables[0].Rows[0]["rres_res_id"].ToString();
                ColorearRespuestas(ddl3, DS3.Tables[0].Rows[0]["ponderador"].ToString());//para facilitar la visualización, se colorean las respuestas
            }
        }
        else { ddl3.Items.Insert(0, new ListItem("", "-1")); ddl3.SelectedIndex = 0; }
    }
    private void ColorearRespuestas(DropDownList ddl, string respuesta)
    {//para facilitar la visualización, se colorean las respuestas
        switch (respuesta)
        {
            case "A":
                ddl.BackColor = System.Drawing.Color.LightGreen;
                break;
            case "B":
                ddl.BackColor = System.Drawing.Color.LemonChiffon;
                break;
            case "C":
                ddl.BackColor = System.Drawing.Color.LightCoral;
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
    protected void VerPdf_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgButton = (ImageButton)sender;
        string resId = imgButton.CommandArgument;
        string sc = "";
        // Ahora, puedes hacer lo que necesites con resId, como asignarlo a un Label
        lblIdPdf.Text = resId;
        //string scJustificar = "$('#ModalPdf').modal('show');";
        //SetScript(scJustificar, ", dropdownParent: $('#ModalPdf')");
        //verPDF(Convert.ToInt32(resId));
        //************************************************************************
        int descrip_pu_id = Convert.ToInt32(resId);
        byte[] pdfBytes = verPDF(descrip_pu_id);

        if (pdfBytes != null)
        {
            string base64Pdf = Convert.ToBase64String(pdfBytes);
            string js = $"var blob = atob('{base64Pdf}'); " +
                        "var byteNumbers = new Array(blob.length); " +
                        "for (var i = 0; i < blob.length; i++) { " +
                        "    byteNumbers[i] = blob.charCodeAt(i); " +
                        "} " +
                        "var byteArray = new Uint8Array(byteNumbers); " +
                        "var blob = new Blob([byteArray], {type: 'application/pdf'}); " +
                        "var url = URL.createObjectURL(blob); " +
                        $"document.getElementById('{ID_pdfFrame.ClientID}').src = url; " +
                        "$('#vwrpdf').modal('show');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPdf", js, true);
        }
        else
        {
            // Muestra el modal si no hay PDF para mostrar
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#vwrpdf').modal('show');", true);
            sc = "$('#vwrpdf2').modal('show');";
            //Session["PdfDataUrl"] = pdfDataUrl;
            SetScript(sc, "");
        }

    }
    private byte[] verPDF(int des_p_result_id)
    {
        
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        DataSet data = descriptor_puestos.ObtenerPdf(des_p_result_id);


        if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
        {
            DataRow row = data.Tables[0].Rows[0];
            if (row["descrip_pdf"] == DBNull.Value)
            {
                return null;
            }
            if (row["descrip_pdf"] != DBNull.Value)
            {
                return (byte[])row["descrip_pdf"];
            }
        }

        return null;
    }
    protected void VerInforme_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton imgButton = (ImageButton)sender;
        string sc = "";
        // Ahora, puedes hacer lo que necesites con resId, como asignarlo a un Label
        lblIdPdf.Text = Convert.ToString(id_evaluacion);
        //************************************************************************
        byte[] pdfBytes = verPDFInforme(id_evaluacion);

        if (pdfBytes != null)
        {
            string base64Pdf = Convert.ToBase64String(pdfBytes);
            string js = $"var blob = atob('{base64Pdf}'); " +
                        "var byteNumbers = new Array(blob.length); " +
                        "for (var i = 0; i < blob.length; i++) { " +
                        "    byteNumbers[i] = blob.charCodeAt(i); " +
                        "} " +
                        "var byteArray = new Uint8Array(byteNumbers); " +
                        "var blob = new Blob([byteArray], {type: 'application/pdf'}); " +
                        "var url = URL.createObjectURL(blob); " +
                        $"document.getElementById('{ID_pdfFrame.ClientID}').src = url; " +
                        "$('#vwrpdf').modal('show');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowPdf", js, true);
        }
        else
        {
            sc = "$('#vwrpdf2').modal('show');";
            SetScript(sc, "");
        }

    }
    private byte[] verPDFInforme(int id_evaluacion)
    {

        //cls_Formulario evaluacion = new cls_Formulario();

        DataSet data = cls_Formulario.ObtenerPdfInforme(id_evaluacion);


        if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
        {
            DataRow row = data.Tables[0].Rows[0];
            if (row["eva_pdf"] == DBNull.Value)
            {
                return null;
            }
            if (row["eva_pdf"] != DBNull.Value)
            {
                return (byte[])row["eva_pdf"];
            }
        }

        return null;
    }
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: \"es\"" +
                    "});" +
                "});" +
                "var me = $(\".datepickerD\");" +
                "me.mask(\"99/99/9999\");" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }
}