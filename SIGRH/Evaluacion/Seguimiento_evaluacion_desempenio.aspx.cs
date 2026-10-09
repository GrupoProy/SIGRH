using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
using Solution_Framework_Evaluacion.DataAccessLayer;
using System.Data;
using System.Text;

public partial class Evaluacion_Seguimiento_evaluacion_desempenio : System.Web.UI.Page
{
    private int id_gestion = 0; //
    private int id_periodo = 0; //

    private string nombre_evaluacion = "";
    private string tipo_evaluacion = "";

    private string barraColorSinIniciar = "bg-warning";
    private string barraColorEnProceso = "bg-info";
    private string barraColorFinalizado = "bg-success";
    protected void Page_Load(object sender, EventArgs e)
    {
        //se limpian las variables de sesión para registrarlas luego con la información del funcionario a evaluar
        Session.Remove("id_gestionE"); Session["id_gestionE"] = null;
        Session.Remove("id_periodoE"); Session["periodoE"] = null;
        Session.Remove("id_unidad"); Session["id_unidad"] = null;
        Session.Remove("unidad"); Session["unidad"] = null;
        //        Session.Remove("tipo_evaluacion"); Session["tipo_evaluacion"] = null;
        Session.Remove("pagina_actual"); Session["pagina_actual"] = null;
        Session.Remove("tipo_evaluacion2"); Session["tipo_evaluacion2"] = null;
        //Session.Remove("nombre_evaluacion"); Session["nombre_evaluacion"] = null;

        nombre_evaluacion = Convert.ToString(HttpContext.Current.Session["nombre_evaluacion"]);
        tipo_evaluacion = Convert.ToString(HttpContext.Current.Session["tipo_evaluacion"]);

        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            //per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString());//se asigna a la variable, el código de funcionario almacenado en la variable de sesión
            EvaluacionActiva(tipo_evaluacion);// EVALUACION DESEMPE;O
            //EvaluacionActiva('C');// EVALUACION RENDIMIENTO

            if (!Page.IsPostBack)
            {
                ListarUnidades();//se carga el listado de los funcionarios dependientes del evaluador
                ListaTotales(tipo_evaluacion);
                lblEvaluacion.Text = nombre_evaluacion;
            }

        }

    }
    protected void EvaluacionActiva(string tipo_evaluacion)
    {
        //consultar cual es la evaluacion activa
        DataSet parametrosDataSet = cls_Habilitados.ParametrosEvaluacionActiva(tipo_evaluacion);

        foreach (DataTable table in parametrosDataSet.Tables)
        {
            // Agrega las columnas que faltan
            if (!table.Columns.Contains("eva_pr_id"))
            {
                table.Columns.Add("eva_pr_id", typeof(string));
            }
            if (!table.Columns.Contains("eva_periodo"))
            {
                table.Columns.Add("eva_periodo", typeof(string));
            }

            ///////////////////////////////////////////////////////////////////
            foreach (DataRow row in table.Rows)
            {
                // Agrega los valores de las nuevas columnas
                id_gestion = Convert.ToInt32(row["eva_pr_id"]);
                id_periodo = Convert.ToInt32(row["eva_periodo"]);

            }

        }


    }
    protected void ListarUnidades()
    {
        DataSet dependientesDataSet = cls_Habilitados.SeguimientoEvaluacion("C3",id_gestion, id_periodo, tipo_evaluacion);
        foreach (DataTable table in dependientesDataSet.Tables)
        {
            // Agrega las columnas que faltan
            if (!table.Columns.Contains("eva_pr_id"))
            {
                table.Columns.Add("eva_pr_id", typeof(string));
            }
            if (!table.Columns.Contains("eva_periodo"))
            {
                table.Columns.Add("eva_periodo", typeof(string));
            }
            if (!table.Columns.Contains("eo_id"))
            {
                table.Columns.Add("eo_id", typeof(string));
            }
            if (!table.Columns.Contains("eo_descripcion"))
            {
                table.Columns.Add("eo_descripcion", typeof(string));
            }
            if (!table.Columns.Contains("casos"))
            {
                table.Columns.Add("casos", typeof(string));
            }
            if (!table.Columns.Contains("periodo_evaluacion"))
            {
                table.Columns.Add("periodo_evaluacion", typeof(string));
            }
            if (!table.Columns.Contains("estado_evaluacion"))
            {
                table.Columns.Add("estado_evaluacion", typeof(string));
            }
            if (!table.Columns.Contains("casos_habilitado"))
            {
                table.Columns.Add("casos_habilitado", typeof(string));
            }
            if (!table.Columns.Contains("casos_proceso"))
            {
                table.Columns.Add("casos_proceso", typeof(string));
            }
            if (!table.Columns.Contains("casos_finalizado"))
            {
                table.Columns.Add("casos_finalizado", typeof(string));
            }
            ///////////////////////////////////////////////////////////////////
            table.Columns.Add("TarjetaInfo", typeof(string));
            table.Columns.Add("TarjetaInfoT1", typeof(string));
            table.Columns.Add("TarjetaInfoT2", typeof(string));
            table.Columns.Add("TarjetaInfoT3", typeof(string));

            if (!table.Columns.Contains("EstadoCssClass"))
            {
                table.Columns.Add("EstadoCssClass", typeof(string));
            }

            foreach (DataRow row in table.Rows)
            {
                // Agrega los valores de las nuevas columnas
                row["eva_pr_id"] = row["eva_pr_id"]; 
                row["eva_periodo"] = row["eva_periodo"];
                row["eo_id"] = row["eo_id"];
                row["eo_descripcion"] = row["eo_descripcion"];
                row["casos"] = row["casos"];
                ///////////////////////////////////////////////////////////////////////////////////
                string estado = row["estado_evaluacion"].ToString(); // Asegúrate de que ESTADO sea el nombre correcto del campo
                string colorClase = "";
                // Determina el color de la clase según el estado
                if (estado == "FINALIZADO")
                {
                    colorClase = "badge badge-success";
                }
                else
                {
                    if (estado == "SIN INICIAR")
                    {
                        colorClase = "badge badge-danger";
                    }
                    else
                    {
                        colorClase = "badge badge-info";
                    }
                    
                }
                ////////////////////////////////////////////////////////////////////////////////////////
                int totalCasos = Convert.ToInt32(row["casos"]);
                int casosHabilitados = Convert.ToInt32(row["casos_habilitado"]);
                int casosProceso = Convert.ToInt32(row["casos_proceso"]);
                int casosFinalizados = Convert.ToInt32(row["casos_finalizado"]);


                int porcentaje = 0; string barraColor = "";

                if (casosFinalizados == totalCasos)
                {
                    porcentaje = 100;
                    barraColor = "bg-success";  // Color verde para casos finalizados
                }
                else if (casosHabilitados == totalCasos)
                {
                    porcentaje = 0;
                    barraColor = "bg-warning";  // Color amarillo para casos habilitados
                }
                else
                {
                    porcentaje = (int)(((casosProceso + casosFinalizados) / (1.0 * totalCasos)) * 100);
                    barraColor = "bg-info";  // Color azul para casos en proceso
                }
                //////////////////////////////////////////////////////////////////////

                string barraProgreso = $"<div class='progress' style='height: 10px;' data-toggle='tooltip' data-original-title='{porcentaje}%'>";
                barraProgreso += $"<div class='progress-bar {barraColor}' role='progressbar' style='width: {porcentaje}%;' aria-valuenow='{porcentaje}' aria-valuemin='0' aria-valuemax='100'>{porcentaje}%</div>";
                barraProgreso += $"</div>";

                row["TarjetaInfo"] = barraProgreso;
                row["EstadoCssClass"] = colorClase; 

            }
        }


        GvListaUnidades.DataSource = dependientesDataSet;
        GvListaUnidades.DataBind();

    }
    protected void ListaTotales(string tipo_evaluacion)
    {
        //consultar cual es la evaluacion activa
        DataSet parametrosDataSet = cls_Habilitados.SeguimientoEvaluacionTotal("C9", id_gestion, id_periodo, tipo_evaluacion);

        foreach (DataTable table in parametrosDataSet.Tables)
        {
            // Agrega las columnas que faltan
            if (!table.Columns.Contains("eva_pr_id"))
            {
                table.Columns.Add("eva_pr_id", typeof(string));
            }
            if (!table.Columns.Contains("eva_periodo"))
            {
                table.Columns.Add("eva_periodo", typeof(string));
            }

            table.Columns.Add("TarjetaInfoT1", typeof(string));
            table.Columns.Add("TarjetaInfoT2", typeof(string));
            table.Columns.Add("TarjetaInfoT3", typeof(string));

            ///////////////////////////////////////////////////////////////////
            foreach (DataRow row in table.Rows)
            {
                int  totalSinIniciar = Convert.ToInt32(row["casos_habilitado"]); ;
                int  totalEnProceso = Convert.ToInt32(row["casos_proceso"]);
                int  totalFinalizado = Convert.ToInt32(row["casos_finalizado"]);

                int Total = totalSinIniciar + totalEnProceso + totalFinalizado;

                //porcentajeT1 = (int)((totalSinIniciar / (1.0 * Total)) * 100);
                double porcentajeT2 = (totalEnProceso / (1.0 * Total)) * 100;
                double porcentajeT3 = (totalFinalizado / (1.0 * Total)) * 100;

                // Ajusta la declaración de porcentajeT1 como double
                double porcentajeT1 = (totalSinIniciar / (1.0 * Total)) * 100;

                // O utiliza una conversión explícita a float si lo necesitas como float
                float porcentajeT1Float = (float)porcentajeT1;
                float porcentajeT2Float = (float)porcentajeT2;
                float porcentajeT3Float = (float)porcentajeT3;

                // Formatea el porcentaje con dos decimales
                string porcentajeT1Formateado = porcentajeT1Float.ToString("0.00");
                string porcentajeT2Formateado = porcentajeT2Float.ToString("0.00");
                string porcentajeT3Formateado = porcentajeT3Float.ToString("0.00");

                string barraProgresoT1 = $"<div class='progress' style='height: 20px; width:100%' data-toggle='tooltip' data-original-title='{porcentajeT1Formateado}%'>";
                barraProgresoT1 += $"<div class='progress-bar {barraColorSinIniciar}' role='progressbar' style='width: {porcentajeT1Formateado}%;' aria-valuenow='{porcentajeT1Formateado}' aria-valuemin='0' aria-valuemax='100'></div>";
                barraProgresoT1 += $"</div> {porcentajeT1Formateado}%";

                row["TarjetaInfoT1"] = barraProgresoT1;

                string barraProgresoT2 = $"<div class='progress' style='height: 20px;  width:100%' data-toggle='tooltip' data-original-title='{porcentajeT2Formateado}%'>";
                barraProgresoT2 += $"<div class='progress-bar {barraColorEnProceso}' role='progressbar' style='width: {porcentajeT2Formateado}%;' aria-valuenow='{porcentajeT2Formateado}' aria-valuemin='0' aria-valuemax='100'></div>";
                barraProgresoT2 += $"</div> {porcentajeT2Formateado}% ";

                row["TarjetaInfoT2"] = barraProgresoT2;

                string barraProgresoT3 = $"<div class='progress' style='height: 20px;  width:100%' data-toggle='tooltip' data-original-title='{porcentajeT3Formateado}%'>";
                barraProgresoT3 += $"<div class='progress-bar {barraColorFinalizado}' role='progressbar' style='width: {porcentajeT3Formateado}%;' aria-valuenow='{porcentajeT3Formateado}' aria-valuemin='0' aria-valuemax='100'></div>";
                barraProgresoT3 += $"</div> {porcentajeT3Formateado}% ";

                row["TarjetaInfoT3"] = barraProgresoT3;
            }

        }
        GridView1.DataSource = parametrosDataSet;
        GridView1.DataBind();
        GridView2.DataSource = parametrosDataSet;
        GridView2.DataBind();
        GridView3.DataSource = parametrosDataSet;
        GridView3.DataBind();

    }
    protected void GvListaUnidades_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (GvListaUnidades.Rows.Count > 0)
        {
            if (GvListaUnidades.HeaderRow != null)
            {
                GvListaUnidades.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GvListaUnidades.FooterRow != null)
            {
                GvListaUnidades.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void GvListaUnidades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        //string unidad_s = GvListaUnidades.DataKeys[index2].Values[1].ToString();
        switch (e.CommandName)
        {
            case "Ver":    //se almacena la información del evaluado seleccionado para cargar sus respuestas en variables de sesión
                //DataKeyNames = "eva_pr_id,eva_periodo,eo_id, eo_descripcion" -- quiza agregar tipo de evaluacion P/C
                Session["id_gestionE"] = GvListaUnidades.DataKeys[index].Values["eva_pr_id"].ToString();
                Session["id_periodoE"] = GvListaUnidades.DataKeys[index].Values["eva_periodo"].ToString();
                Session["id_unidadE"] = GvListaUnidades.DataKeys[index].Values["eo_id"].ToString();
                Session["unidad"] = GvListaUnidades.DataKeys[index].Values["eo_descripcion"].ToString();
                //Session["tipo_evaluacion"] = GvListaUnidades.DataKeys[index].Values["tipo_evaluacion"].ToString();
                Session["pagina_actual"] = Request.Url.ToString();
                Session["nombre_evaluacion"] = Convert.ToString(HttpContext.Current.Session["nombre_evaluacion"]);
                Session["tipo_evaluacion2"] = tipo_evaluacion;
                //se redirecciona a la sección de resultados específicos
                Response.Redirect("VerSeguimientoEvaluaciones.aspx");
                break;

        }
    }

    protected void CerrarEvaluacion_OnClick(object sender, EventArgs e)
    {
        string scCerrar = "$('#ModalCerrarEvaluacion').modal('show');";
        SetScript(scCerrar, ", dropdownParent: $('#ModalCerrarEvaluacion')");
    }
    protected void CerrarEvaluacionGral_OnClick(object sender, EventArgs e)
    {
        cls_Habilitados.CerrarEvaluacionTotal("", id_gestion, id_periodo, tipo_evaluacion);

        string sc;
        sc = "$('#ModalCerrarEvaluacion').modal('hide'); ";// location.reload();";
        SetScript(sc, "");

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