using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
using Solution_Framework_Evaluacion.DataAccessLayer;
using System.Data;

public partial class Evaluacion_Habilitar_evaluacion_desempenio : System.Web.UI.Page
{
    private cls_Habilitados habilitados = null;
    private string tipo_evaluacion = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        // Attach the event handler to DdlSemestre.SelectedIndexChanged event
        tipo_evaluacion = Convert.ToString(HttpContext.Current.Session["tipo_evaluacion"]);
        if (!Page.IsPostBack)
        {
            TipoEvaluacion();
            PeriodoEvaluar(); //
            Dependientes_Bind();//
            
        }

    }
    protected void TipoEvaluacion()
    {
        if (tipo_evaluacion == "P")
        {
            lbltipo.Text = "DESEMPEÑO";
        }
        else
        {
            lbltipo.Text = "RENDIMIENTO";
        }
    }
     protected void PeriodoEvaluar()
    {
        DataSet DS = cls_Habilitados. ActivarEvaluacionDesempenio(Convert.ToInt32(0),tipo_evaluacion);
        txtGestionHabilitar.Text = DS.Tables[0].Rows[0]["gestion"].ToString();
        lblIdGestion.Text = DS.Tables[0].Rows[0]["id_gestion"].ToString();
        int periodo = 0;
        string periodo_habilitado = "";
        periodo = Convert.ToInt32(DS.Tables[0].Rows[0]["periodo"].ToString());
        lblIdperiodo.Text = DS.Tables[0].Rows[0]["periodo"].ToString();
        //LblPuesto.Text = DS.Tables[0].Rows[0]["puesto"].ToString();
        //-------------------------------------------------
        if (periodo == 1)
        {
            txtPeriodoHabilitar.Text = "Primer Semestre ";
            periodo_habilitado = "   Primer Semestre - "+ DS.Tables[0].Rows[0]["gestion"].ToString() + "   ";
        }
        else { txtPeriodoHabilitar.Text = "Segundo Semestre ";
            periodo_habilitado = "   Segundo Semestre - " + DS.Tables[0].Rows[0]["gestion"].ToString()+"   ";
        }

        txtPeriodoHabilitado.Text = periodo_habilitado;
    }
    private void Dependientes_Bind()
    {

    }
    protected void BtnGenerarHabilitados_Click(object sender, EventArgs e)
    {
        //Se genera el listado de personas habilitadas para la evaluación, de acuerdo a la gestión y periodo/ tipo
        int totalRegistrosAcefalo = 0;
        int totalRegistrosCumple = 0;
        int totalRegistrosNoCumple = 0;
        int totalRegistros = 0;

        DataSet dependientesDataSet = cls_Habilitados.ObtenerHabilitados("", Convert.ToInt32(lblIdGestion.Text), Convert.ToInt32(lblIdperiodo.Text),tipo_evaluacion);
        foreach (DataTable table in dependientesDataSet.Tables)
        {
            // Agrega las columnas que faltan
            if (!table.Columns.Contains("item"))
            {
                table.Columns.Add("item", typeof(string));
            }
            if (!table.Columns.Contains("as_per_id"))
            {
                table.Columns.Add("as_per_id", typeof(string));
            }
            if (!table.Columns.Contains("as_ca_id"))
            {
                table.Columns.Add("as_ca_id", typeof(string));
            }
            if (!table.Columns.Contains("fecha_inicio"))
            {
                table.Columns.Add("fecha_inicio", typeof(DateTime));
            }
            if (!table.Columns.Contains("fecha_fin"))
            {
                table.Columns.Add("fecha_fin", typeof(DateTime));
            }

            if (!table.Columns.Contains("nombre_completo"))
            {
                table.Columns.Add("nombre_completo", typeof(string));
            }

            if (!table.Columns.Contains("eo_descripcion"))
            {
                table.Columns.Add("eo_descripcion", typeof(string));
            }
            ///////////////////////////////////////////////////////////////////
            table.Columns.Add("TarjetaInfo", typeof(string));

            if (!table.Columns.Contains("EstadoCssClass"))
            {
                table.Columns.Add("EstadoCssClass", typeof(string));
            }

            foreach (DataRow row in table.Rows)
            {
                // Agrega los valores de las nuevas columnas
                row["item"] = row["item"]; // Ajusta según el nombre real de la columna
                row["fecha_inicio"] = row["fecha_inicio"];
                row["fecha_fin"] = row["fecha_fin"];
                row["as_per_id"] = row["as_per_id"];
                row["as_ca_id"] = row["as_ca_id"];
                row["nombre_completo"] = row["nombre_completo"]; // Ajusta según el nombre real de la columna
                row["eo_descripcion"] = row["eo_descripcion"];
                ///////////////////////////////////////////////////////////////////////////////////
                string estado = row["tipo"].ToString(); // Asegúrate de que ESTADO sea el nombre correcto del campo
                string colorClase = "";
                // Determina el color de la clase según el estado
                if (estado == "CUMPLE")
                {
                    colorClase = "badge badge-success";
                }
                else
                {
                        colorClase = "badge badge-danger";
                }
                // Puedes agregar más condiciones según sea necesario

                string tarjetaInfo = $"<div class='ct-page-title3'style='margin-top: 2px; margin-botton: 2px;align-items: left;font-size: 8pt;'>";
                //string tarjetaInfo = $"<div style='margin-bottom: 0px; display: flex; align-items: left;'>";


                tarjetaInfo += $"<strong>CARGO: </strong> {row["es_descripcion"]}<br/>";
                tarjetaInfo += $"<strong>PUESTO: </strong> {row["puesto"]}</div></div>";


                row["TarjetaInfo"] = tarjetaInfo;
                row["EstadoCssClass"] = colorClase; // Asigna la clase CSS del estado a la nueva columna

                // Lógica para calcular totales


                string tipo = row["tipo"].ToString();
                switch (tipo)
                {
                    case "ACEFALO":
                        totalRegistrosAcefalo++;
                        break;
                    case "CUMPLE":
                        totalRegistrosCumple++;
                        break;
                    case "NO CUMPLE":
                        totalRegistrosNoCumple++;
                        break;
                }
                totalRegistros++;

            }
        }
        lblTotalAcefalos.Text = Convert.ToString(totalRegistrosAcefalo);
        lblTotalCumple.Text = Convert.ToString(totalRegistrosCumple);
        lblTotalNoCumple.Text = Convert.ToString(totalRegistrosNoCumple);
        lblTotalCasos.Text = Convert.ToString(totalRegistros);
        //Se habilitan los botones
        BtnRegistrar.Visible = true;
        BtnGenerarHabilitados.Enabled = false;
        BtnGenerarHabilitados.Visible = false;
        lblIdGestion.Visible = false;
        lblIdperiodo.Visible = false;
        txtGestionHabilitar.Visible = false;
        txtPeriodoHabilitar.Visible = false;
        Label1.Visible = false;
        Label2.Visible = false;
        txtPeriodoHabilitado.Visible = true;


        GvListaHabilitacion.DataSource = dependientesDataSet;
        GvListaHabilitacion.DataBind();
    }
    protected void GvListaHabilitacion_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (GvListaHabilitacion.Rows.Count > 0)
        {
            if (GvListaHabilitacion.HeaderRow != null)
            {
                GvListaHabilitacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GvListaHabilitacion.FooterRow != null)
            {
                GvListaHabilitacion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
   /* protected void GvListaHabilitacion_DataBound(object sender, GridViewRowEventArgs e)
    {
        //se da formato a la grilla y se colorean celdas para facilitar la visualización
        if (e.Row.RowType == DataControlRowType.Header)
        {
            e.Row.Cells[0].Text = "";
            e.Row.Cells[1].Text = "Condición";
            e.Row.Cells[2].Text = "cod_fun";
            e.Row.Cells[3].Text = "cod_cargo";
            e.Row.Cells[4].Text = "";
            e.Row.Cells[5].Text = "item";
            e.Row.Cells[6].Text = "asignación";
            e.Row.Cells[7].Text = "baja";
            e.Row.Cells[8].Text = "cargo";
            e.Row.Cells[9].Text = "puesto";
            e.Row.Cells[10].Text = "unidad";
        }
        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            e.Row.Cells[i].BorderStyle = BorderStyle.Solid;
            e.Row.Cells[i].Style.Add("border-color", "darkgray");
            e.Row.Cells[i].Style.Add("border-width", "1px");
            e.Row.Cells[i].Style.Add("font-size", "10px");
            if (e.Row.RowType == DataControlRowType.DataRow)
                e.Row.Cells[i].Style.Add("background-color", "#E3EAEB");
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[6].Text != "&nbsp;")
                e.Row.Cells[6].Text = e.Row.Cells[6].Text.Substring(0, 10);
            if (e.Row.Cells[7].Text != "&nbsp;")
                e.Row.Cells[7].Text = e.Row.Cells[7].Text.Substring(0, 10);
            if (e.Row.Cells[1].Text == "NO CUMPLE" || e.Row.Cells[1].Text == "ACEFALO")
            {
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Style.Add("color", "red");
                    CheckBox cheky = (CheckBox)e.Row.FindControl("ChkHabilitar");
                    if (cheky != null)
                        cheky.Checked = false;
                        cheky.Enabled = false;
                }
            }
            if (cls_Habilitados.VerificarHabilitacion(Convert.ToInt32(e.Row.Cells[3].Text)) == "habilitado")
                for (int i = 0; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Enabled = false;
                    e.Row.Cells[i].Style.Add("background-color", "lightgreen");
                    CheckBox cheky = (CheckBox)e.Row.FindControl("ChkHabilitar");
                    cheky.Checked = true;
                }
        }

    }*/

    protected void BtnRegistrar_Click(object sender, EventArgs e)
    {
        //se importa la información de la grilla en la tabla tbl_evaluaciones de la base de datos
        try
        {
            GridView gv = new GridView();
            gv = GvListaHabilitacion;
            int cod_fun;
            if (gv.Rows.Count > 0)
            {
                //cls_Habilitados.InhabilitarEvaluacionesAnteriores();
                int totalRows = gv.Rows.Count;
                int currentRow = 0;

                foreach (GridViewRow item in gv.Rows)
                {
                    currentRow++;
                    CheckBox cheky = (CheckBox)item.FindControl("ChkHabilitar");
                    if (cheky != null)
                    {
                        if (cheky.Checked == true)
                        {
                            if (item.Enabled == true)
                            {
                                if (item.Cells[5].Text == "&nbsp;" || item.Cells[5].Text == "") cod_fun = 0;
                                else cod_fun = Convert.ToInt32(item.Cells[5].Text);
                                cls_Habilitados.Insertar_Habilitados(Convert.ToInt32(lblIdGestion.Text), Convert.ToInt32(lblIdperiodo.Text), cod_fun, Convert.ToInt32(item.Cells[9].Text),tipo_evaluacion);
                            }
                        }
                    }
                    // Show progress in modal popup
                    int percentage = (currentRow * 100) / totalRows;

                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "$(function(){ $('#ModalProgress').modal('show'); $('#progress-bar').css('width', '" + percentage + "%').attr('aria-valuenow', '" + percentage + "'); $('#progress-bar').text('" + percentage + "%'); });", true);
                }
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "$(function(){ $('#ModalAlerta1').modal('show'); });", true);
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#ModalAlerta1').modal('show');", true);

            //Response.Redirect("AsignarEvaluadorDesempenio.aspx");
        }
        catch (Exception ex)
        {
            //Response.Redirect("Error.html");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", "$(function(){ $('#error-text').text('" + ex + "'); });", true);
        }
    }

    protected void GvListaHabilitacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);



    }
}