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

public partial class Evaluacion_VerSeguimientoEvaluaciones : System.Web.UI.Page
{
    int id_gestion = 0;//id de cargo
    int periodo = 0;//código de funcionario
    int id_unidad = 0;//id evaluacion
    string unidad;
    string pagina_anterior;
    string nombre_evaluacion;

    private string tipo_evaluacion = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        id_gestion = Convert.ToInt32(HttpContext.Current.Session["id_gestionE"].ToString());
        periodo = Convert.ToInt32(HttpContext.Current.Session["id_periodoE"].ToString());
        id_unidad = Convert.ToInt32(HttpContext.Current.Session["id_unidadE"]);
        //id_tipo_evaluacion = Convert.ToInt32(HttpContext.Current.Session["tipo_evaluacion"]);
        unidad = Convert.ToString(HttpContext.Current.Session["unidad"]);
        pagina_anterior = Convert.ToString(HttpContext.Current.Session["pagina_actual"]);

        nombre_evaluacion = Convert.ToString(HttpContext.Current.Session["nombre_evaluacion"]);
        tipo_evaluacion = Convert.ToString(HttpContext.Current.Session["tipo_evaluacion2"]);

        if (!Page.IsPostBack)
        {
            lblUnidadSeleccionada.Text = unidad;
            ListarItemsPorUnidad(id_gestion, periodo, id_unidad);
            lblEvaluacion.Text = nombre_evaluacion;
        }
    }
    protected void ListarItemsPorUnidad(int id_gestion2, int id_periodo2, int id_unidad2)
    {
        DataSet ItemsDataSet = cls_Habilitados.SeguimientoEvaluacionItem("C4", id_gestion2, id_periodo2, id_unidad2, tipo_evaluacion);//(string opcion, int id_gestion, int id_periodo, int id_unidad)
        foreach (DataTable table in ItemsDataSet.Tables)
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
            if (!table.Columns.Contains("eva_estado"))
            {
                table.Columns.Add("eva_estado", typeof(string));
            }
            if (!table.Columns.Contains("eo_id"))
            {
                table.Columns.Add("eo_id", typeof(string));
            }
            if (!table.Columns.Contains("eo_descripcion"))
            {
                table.Columns.Add("eo_descripcion", typeof(string));
            }
            if (!table.Columns.Contains("eva_ca_id"))
            {
                table.Columns.Add("eva_ca_id", typeof(string));
            }
            if (!table.Columns.Contains("item"))
            {
                table.Columns.Add("item", typeof(string));
            }
            if (!table.Columns.Contains("cargo"))
            {
                table.Columns.Add("cargo", typeof(string));
            }
            if (!table.Columns.Contains("puesto"))
            {
                table.Columns.Add("puesto", typeof(string));
            }
            if (!table.Columns.Contains("nombre_completo"))
            {
                table.Columns.Add("nombre_completo", typeof(string));
            }
            if (!table.Columns.Contains("eva_id_evaluacion"))
            {
                table.Columns.Add("eva_id_evaluacion", typeof(string));
            }
            if (!table.Columns.Contains("eva_ca_id_evaluador"))
            {
                table.Columns.Add("eva_ca_id_evaluador", typeof(string));
            }
            if (!table.Columns.Contains("cargo_ev"))
            {
                table.Columns.Add("cargo_ev", typeof(string));
            }
            if (!table.Columns.Contains("puesto_ev"))
            {
                table.Columns.Add("puesto_ev", typeof(string));
            }
            if (!table.Columns.Contains("nombre_completo_ev"))
            {
                table.Columns.Add("nombre_completo_ev", typeof(string));
            }
            if (!table.Columns.Contains("estado_evaluacion"))
            {
                table.Columns.Add("estado_evaluacion", typeof(string));
            }
            ///////////////////////////////////////////////////////////////////
            table.Columns.Add("TarjetaInfo", typeof(string));
            table.Columns.Add("TarjetaInfoEV", typeof(string));

            if (!table.Columns.Contains("EstadoCssClass"))
            {
                table.Columns.Add("EstadoCssClass", typeof(string));
            }
            if (!table.Columns.Contains("EstadoCssClass2"))
            {
                table.Columns.Add("EstadoCssClass2", typeof(string));
            }
            if (!table.Columns.Contains("puntaje"))
            {
                table.Columns.Add("puntaje", typeof(string));
            }
            foreach (DataRow row in table.Rows)
            {
                // Agrega los valores de las nuevas columnas
                row["eva_pr_id"] = row["eva_pr_id"];
                row["eva_periodo"] = row["eva_periodo"];
                row["eva_estado"] = row["eva_estado"];
                row["eo_id"] = row["eo_id"];
                row["eo_descripcion"] = row["eo_descripcion"];
                row["eva_ca_id"] = row["eva_ca_id"];
                row["item"] = row["item"];
                row["cargo"] = row["cargo"];
                row["puesto"] = row["puesto"];
                row["nombre_completo"] = row["nombre_completo"];
                row["eva_id_evaluacion"] = row["eva_id_evaluacion"];
                row["eva_ca_id_evaluador"] = row["eva_ca_id_evaluador"];
                row["cargo_ev"] = row["cargo_ev"];
                row["puesto_ev"] = row["puesto_ev"];
                row["nombre_completo_ev"] = row["nombre_completo_ev"];
                row["eva_calificacion"] = row["eva_calificacion"];
                row["eva_valoracion"] = row["eva_valoracion"];
                
                ///////////////////////////////////////////////////////////////////////////////////
                string puntajeE = "badge block badge-striped border-left-purple border-right-purple round text-center";
                                                                       ////////////////////////
                string estado = row["estado_evaluacion"].ToString(); // Asegúrate de que ESTADO sea el nombre correcto del campo
                string colorClase = "";
                // Determina el color de la clase según el estado
                if (estado == "FINALIZADO")
                {
                    colorClase = "badge badge-success";
                }
                if (estado == "EN PROCESO")
                {
                    colorClase = "badge badge-info";
                }
                if (estado == "SIN INICIAR")
                {
                    colorClase = "badge badge-danger";
                }
                // PREGUNTAR SI EL ID-EVALUADOR ES ACEFALO
                string evaluador_acefalo = row["nombre_completo_ev"].ToString();
                ///////////////////////////////////////////////////////
                string tarjetaInfo = $"<div class='ct-page-title3'style='margin-top: 2px; margin-botton: 0px;'><div  style='margin-bottom: 0px; display: flex; align-items: left;'>";

                if (row["fp_foto"] != DBNull.Value && row["fp_foto"] != null && !string.IsNullOrEmpty(row["fp_foto"].ToString()))
                {
                    tarjetaInfo += $"<div style='margin-right: 1px;'><img class='rounded-circle' style='width: 1.1cm; height: 1.1cm;' src='data:image/jpg;base64,{Convert.ToBase64String((byte[])row["fp_foto"])}' /></div>";
                }
                else
                {
                    tarjetaInfo += $"<div style='margin-right: 1px;'><img class='rounded-circle' style='width: 1.1cm; height: 1.1cm;' src='../Content/img/theme/user3.jpg' /></div>";
                }

                tarjetaInfo += $"<div><h5 class='card-title'>{row["nombre_completo"]} ";
                tarjetaInfo += $"</br><strong>&nbsp;PUESTO: </strong> {row["puesto"]}";
                tarjetaInfo += $"</h5></div></div></div>";

                ///////////////////////////////////////////////////////
                string tarjetaInfoEV = $"<div class='ct-page-title3'style='margin-top: 2px; margin-botton: 0px;'><div  style='margin-bottom: 0px; display: flex; align-items: left;'>";

                if (row["fp_fotoE"] != DBNull.Value && row["fp_fotoE"] != null && !string.IsNullOrEmpty(row["fp_fotoE"].ToString()))
                {
                    tarjetaInfoEV += $"<div style='margin-right: 1px;'><img class='rounded-circle' style='width: 1.1cm; height: 1.1cm;' src='data:image/jpg;base64,{Convert.ToBase64String((byte[])row["fp_fotoE"])}' /></div>";
                }
                else
                {
                    tarjetaInfoEV += $"<div style='margin-right: 1px;'><img class='rounded-circle' style='width: 1.1cm; height: 1.1cm;' src='../Content/img/theme/user3.jpg' /></div>";
                }

                tarjetaInfoEV += $"<div><h5 class='card-title'>{row["nombre_completo_ev"]} ";
                tarjetaInfoEV += $"</br><strong>&nbsp;PUESTO: </strong> {row["puesto_ev"]}";
                tarjetaInfoEV += $"</h5></div></div></div>";

                row["TarjetaInfo"] = tarjetaInfo;
                row["TarjetaInfoEV"] = tarjetaInfoEV;
                row["EstadoCssClass"] = colorClase; // Asigna la clase CSS del estado a la nueva columna
                row["EstadoCssClass2"] = puntajeE;
            }
        }

        GvListaItemsUnidad.DataSource = ItemsDataSet;
        GvListaItemsUnidad.DataBind();

    }
    protected void GvListaItemsUnidad_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (GvListaItemsUnidad.Rows.Count > 0)
        {
            if (GvListaItemsUnidad.HeaderRow != null)
            {
                GvListaItemsUnidad.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GvListaItemsUnidad.FooterRow != null)
            {
                GvListaItemsUnidad.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void GvListaItemsUnidad_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        int eva_id_evaluacion = Convert.ToInt32(GvListaItemsUnidad.DataKeys[index].Values[4].ToString());//3
        string sc;
        switch (e.CommandName)
        {
            case "Habilitar":
                cls_Formulario.Finalizar_Evaluacion(eva_id_evaluacion, "proceso");
                ListarItemsPorUnidad(id_gestion, periodo, id_unidad);
                Response.Redirect("VerSeguimientoEvaluaciones.aspx");
                break;
            case "Finalizar":

                cls_Formulario.Finalizar_Evaluacion(eva_id_evaluacion, "finalizado");
                //sc = "location.reload();";
                //SetScript(sc, "");
                //ListarItemsPorUnidad(id_gestion, periodo, id_unidad);
                ListarItemsPorUnidad(id_gestion, periodo, id_unidad);
                Response.Redirect("VerSeguimientoEvaluaciones.aspx");
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "$(function(){ $('#ModalAlerta1').modal('show'); });", true);

                break;

        }

    }
    
    protected void GvListaItemsUnidad_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Obtener el valor de la columna "Estado"
            string estado = DataBinder.Eval(e.Row.DataItem, "estado_evaluacion") as string;

            // Buscar el LinkButton de Finalizar en la fila actual
            LinkButton btnFinalizar = e.Row.FindControl("btnFinalizar") as LinkButton;//btnHabilitar
            LinkButton btnHabilitar = e.Row.FindControl("btnHabilitar") as LinkButton;

            if (btnFinalizar != null)
            {
                // Cambiar la imagen según el estado         <img src="imagenes/habilitadoOK.png" alt="Finalizar" style="width: 30px; height:35px;" />
                //if (estado == "FINALIZADO")
                //{

                //}
                //if (estado == "EN PROCESO")
                //{

                //}
                //if (estado == "SIN INICIAR")
                //{

                //}

                if (estado == "FINALIZADO")
                {
                    btnHabilitar.Text = "<img src = 'imagenes/habilitadoOK.png' alt = 'Habilitar' style = 'width: 30px; height:35px;' /> ";
                    btnFinalizar.Text = "<img src ='imagenes/habilitadoNO4.png' alt='Finalizar' style='width: 30px; height:35px;' />";
                    btnFinalizar.Enabled = false;
                    //btnFinalizar.ToolTip = "Evaluacion Cerrada";

                }
                else
                {
                    if (estado == "SIN INICIAR")
                    {
                        btnHabilitar.Text = "<img src = 'imagenes/habilitadoOK4.png' alt = 'Habilitar' style = 'width: 30px; height:35px;' /> ";
                        btnFinalizar.Text = "<img src ='imagenes/habilitadoNO4.png' alt='Finalizar' style='width: 30px; height:35px;' />";
                        btnFinalizar.Enabled = false;
                        btnHabilitar.Enabled = false;
                    }
                    else
                    {
                        btnHabilitar.Text = "<img src = 'imagenes/habilitadoOK4.png' alt = 'Habilitar' style = 'width: 30px; height:35px;' /> ";
                        btnFinalizar.Text = "<img src ='imagenes/habilitadoNO.png' alt='Finalizar' style='width: 30px; height:35px;' />";
                        btnHabilitar.Enabled = false;
                    }

                }
            }
        }
    }
    protected void imgbtnVolver_Click(object sender, ImageClickEventArgs e)
    {
        // Redirige a la página anterior
        if (pagina_anterior != null)
        {
            Response.Redirect(pagina_anterior);
        }
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