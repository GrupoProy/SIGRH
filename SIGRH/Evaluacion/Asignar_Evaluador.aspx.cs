using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
using Solution_Framework_Evaluacion.DataAccessLayer;
//using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using System.Data;

//using Solution_Framework_ControlPersonal.BussinessLogicLayer;
//using Solution_Framework_General.BussinessLogicLayer;
//using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
//using Solution_Framework_Salarios.BussinessLogicLayer;

using System.Text;

public partial class Evaluacion_Asignar_Evaluador : System.Web.UI.Page
{
    private cls_Habilitados habilitados = null;
    private int id_gestion = 0; //
    private int id_periodo = 0;//
    private string tipo_evaluacion = "";
    private string nombre_evaluacion = "";


    private cls_mp_descriptor_puestos descriptor_puestos = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        // Attach the event handler to DdlSemestre.SelectedIndexChanged event
        tipo_evaluacion = Convert.ToString(HttpContext.Current.Session["tipo_evaluacion"]);
        nombre_evaluacion = Convert.ToString(HttpContext.Current.Session["nombre_evaluacion"]);

        EvaluacionActiva(tipo_evaluacion);
        
        if (!Page.IsPostBack)
        {
            //TipoEvaluacion();
            ListarUnidades();
            lblEvaluacion.Text = nombre_evaluacion;
            descriptor_puestos = new cls_mp_descriptor_puestos();

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
        string gestion = "";
        string periodo = "";
        DataSet dependientesDataSet = cls_Habilitados.AsignarEvaluadorDesempenio("C1", tipo_evaluacion);
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
            if (!table.Columns.Contains("eva_estado_evaluador"))
            {
                table.Columns.Add("eva_estado_evaluador", typeof(string));
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
            ///////////////////////////////////////////////////////////////////
            table.Columns.Add("TarjetaInfo", typeof(string));

            if (!table.Columns.Contains("EstadoCssClass"))
            {
                table.Columns.Add("EstadoCssClass", typeof(string));
            }

            foreach (DataRow row in table.Rows)
            {
                // Agrega los valores de las nuevas columnas
                row["eva_pr_id"] = row["eva_pr_id"]; // Ajusta según el nombre real de la columna
                row["eva_periodo"] = row["eva_periodo"];
                row["eva_estado_evaluador"] = row["eva_estado_evaluador"];
                row["eo_id"] = row["eo_id"]; // Ajusta según el nombre real de la columna
                row["eo_descripcion"] = row["eo_descripcion"];
                ///////////////////////////////////////////////////////////////////////////////////
                string estado = row["eva_estado_evaluador"].ToString(); // Asegúrate de que ESTADO sea el nombre correcto del campo
                string colorClase = "";
                // Determina el color de la clase según el estado
                if (estado == "asignado")
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
                tarjetaInfo += $"{row["eo_descripcion"]}";
                tarjetaInfo += $"   <strong>    CASOS: </strong> {row["casos"]}</div>";


                row["TarjetaInfo"] = tarjetaInfo;
                row["EstadoCssClass"] = colorClase; // Asigna la clase CSS del estado a la nueva columna
                                                    // Almacenar el primer valor de "eva_pr_id" si aún no se ha almacenado

                if (string.IsNullOrEmpty(gestion))
                {
                    gestion = row["eva_pr_id"].ToString();
                }
                if (string.IsNullOrEmpty(periodo))
                {
                    periodo = row["eva_periodo"].ToString();
                }
            }
        }

        id_gestion = Convert.ToInt32(gestion);
        id_periodo = Convert.ToInt32(periodo);
        GvListaUnidades.DataSource = dependientesDataSet;
        GvListaUnidades.DataBind();

    }

    protected void ListarItemsPorUnidad(int id_gestion, int id_periodo, int id_unidad)
    {
        DataSet ItemsDataSet = cls_Habilitados.AsignarEvaluadorUnidadDesempenio("C2", id_gestion, id_periodo, id_unidad, tipo_evaluacion);//(string opcion, int id_gestion, int id_periodo, int id_unidad)
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
            if (!table.Columns.Contains("eva_estado_evaluador"))
            {
                table.Columns.Add("eva_estado_evaluador", typeof(string));
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
            ///////////////////////////////////////////////////////////////////
            table.Columns.Add("TarjetaInfo", typeof(string));
            table.Columns.Add("TarjetaInfoEV", typeof(string));

            if (!table.Columns.Contains("EstadoCssClass"))
            {
                table.Columns.Add("EstadoCssClass", typeof(string));
            }
            if (!table.Columns.Contains("EstadoCssClassEvaluado"))
            {
                table.Columns.Add("EstadoCssClassEvaluado", typeof(string));
            }
            foreach (DataRow row in table.Rows)
            {
                // Agrega los valores de las nuevas columnas
                row["eva_pr_id"] = row["eva_pr_id"]; 
                row["eva_periodo"] = row["eva_periodo"];
                row["eva_estado"] = row["eva_estado"];
                row["eva_estado_evaluador"] = row["eva_estado_evaluador"];
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
                ///////////////////////////////////////////////////////////////////////////////////
                string estado = row["eva_estado_evaluador"].ToString(); // Asegúrate de que ESTADO sea el nombre correcto del campo
                string colorClase = "";
                // Determina el color de la clase según el estado evaluador
                if (estado == "asignado")
                {
                    colorClase = "badge badge-info";
                }
                else
                {
                    colorClase = "badge badge-danger";
                }
                /////////////////////////////////////////////////////////////
                string estadoEvaluado = row["eva_estado"].ToString();
                string colorClaseEvaluado = "";
                // Determina el color de la clase según el estado Evaluacion
                if (estadoEvaluado.ToUpper() == "FINALIZADO") //if (estadoEvaluador == "Finalizado")
                {
                    colorClaseEvaluado = "badge badge-success";
                }
                else
                {
                    if (estadoEvaluado == "proceso")
                    {
                        colorClaseEvaluado = "badge badge-info";
                    }
                    else
                    {
                        colorClaseEvaluado = "badge badge-danger";
                    }
                        
                }
                // PREGUNTAR SI EL ID-EVALUADOR ES ACEFALO
                string evaluador_acefalo = row["nombre_completo_ev"].ToString();
                if (evaluador_acefalo  == "ACEFALO")
                {
                    string tarjetaInfo = $"<div class='ct-page-title3'style='margin-top: 2px; margin-botton: 2px;align-items: left;font-size: 8pt;'>";
                    tarjetaInfo += $"<div><strong>{row["nombre_completo"]} </strong>";
                    tarjetaInfo += $"</br><strong>CARGO: </strong> {row["cargo"]}";
                    tarjetaInfo += $"<strong>&nbsp;&nbsp;   ITEM: </strong> {row["item"]}";
                    tarjetaInfo += $"</br><strong>PUESTO: </strong> {row["puesto"]}</div></div></div>";
                    ///EVALUADOR
                    string tarjetaInfoEV = $"<div class='ct-page-title3'style='margin-top: 2px; margin-botton: 2px;align-items: left;font-size: 8pt;color: red;'>";
                    tarjetaInfoEV += $"<div  CssClass='pl-0 pr-0 pt-0 pb-0' ><strong>{row["nombre_completo_ev"]} </strong>";
                    tarjetaInfoEV += $"</br><strong>CARGO: </strong> {row["cargo_ev"]}";
                    //tarjetaInfoEV += $"<strong>&nbsp;&nbsp;   ITEM: </strong> {row["item"]}";
                    tarjetaInfoEV += $"</br><strong>PUESTO: </strong> {row["puesto_ev"]}</div></div></div>";

                    row["TarjetaInfo"] = tarjetaInfo;
                    row["TarjetaInfoEV"] = tarjetaInfoEV;
                }
                else
                {
                    string tarjetaInfo = $"<div class='ct-page-title3'style='margin-top: 2px; margin-botton: 2px;align-items: left;font-size: 8pt;'>";
                    tarjetaInfo += $"<div><strong>{row["nombre_completo"]} </strong>";
                    tarjetaInfo += $"</br><strong>CARGO: </strong> {row["cargo"]}";
                    tarjetaInfo += $"<strong>&nbsp;&nbsp;   ITEM: </strong> {row["item"]}";
                    tarjetaInfo += $"</br><strong>PUESTO: </strong> {row["puesto"]}</div></div></div>";
                    ///EVALUADOR
                    string tarjetaInfoEV = $"<div class='ct-page-title3'style='margin-top: 2px; margin-botton: 2px;align-items: left;font-size: 8pt;'>";
                    tarjetaInfoEV += $"<div  CssClass='pl-0 pr-0 pt-0 pb-0' ><strong>{row["nombre_completo_ev"]} </strong>";
                    tarjetaInfoEV += $"</br><strong>CARGO: </strong> {row["cargo_ev"]}";
                    //tarjetaInfoEV += $"<strong>&nbsp;&nbsp;   ITEM: </strong> {row["item"]}";
                    tarjetaInfoEV += $"</br><strong>PUESTO: </strong> {row["puesto_ev"]}</div></div></div>";

                    row["TarjetaInfo"] = tarjetaInfo;
                    row["TarjetaInfoEV"] = tarjetaInfoEV;
                }

                row["EstadoCssClass"] = colorClase; // Asigna la clase CSS del estado a la nueva columna
                row["EstadoCssClassEvaluado"] = colorClaseEvaluado; // Asigna la clase CSS del estado a la nueva columna
            }
        }

        GvListaItemsUnidad.DataSource = ItemsDataSet;
        GvListaItemsUnidad.DataBind();

    }
    /*protected void BtnGenerarHabilitados_Click(object sender, EventArgs e)
    {

        DataSet dependientesDataSet = cls_Habilitados.AsignarEvaluadorDesempenio("C1");
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
            if (!table.Columns.Contains("eva_estado_evaluador"))
            {
                table.Columns.Add("eva_estado_evaluador", typeof(string));
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
            ///////////////////////////////////////////////////////////////////
            table.Columns.Add("TarjetaInfo", typeof(string));

            foreach (DataRow row in table.Rows)
            {
                // Agrega los valores de las nuevas columnas
                row["eva_pr_id"] = row["eva_pr_id"]; // Ajusta según el nombre real de la columna
                row["eva_periodo"] = row["eva_periodo"];
                row["eva_estado_evaluador"] = row["eva_estado_evaluador"];
                row["eo_id"] = row["eo_id"]; // Ajusta según el nombre real de la columna
                row["eo_descripcion"] = row["eo_descripcion"];
                ///////////////////////////////////////////////////////////////////////////////////
                string estado = row["eva_estado_evaluador"].ToString(); // Asegúrate de que ESTADO sea el nombre correcto del campo
                string colorClase = "";
                // Determina el color de la clase según el estado
                if (estado == "confirmado")
                {
                    colorClase = "badge badge-success";
                }
                else
                {
                    colorClase = "badge badge-danger";
                }
                // Puedes agregar más condiciones según sea necesario

                string tarjetaInfo = $"<div class='ct-page-title3'style='margin-top: 2px; margin-botton: 2px;align-items: left;'>";
                //string tarjetaInfo = $"<div style='margin-bottom: 0px; display: flex; align-items: left;'>";


                tarjetaInfo += $"{row["es_descripcion"]}<br/>";
                tarjetaInfo += $"<strong>  CASOS: </strong> {row["casos"]}</div>";


                row["TarjetaInfo"] = tarjetaInfo;
                row["EstadoCssClass"] = colorClase; // Asigna la clase CSS del estado a la nueva columna
            }
        }

        GvListaUnidades.DataSource = dependientesDataSet;
        GvListaUnidades.DataBind();
    }
    */
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
    /*protected void BtnRegistrar_Click(object sender, EventArgs e)
    {
        //se importa la información de la grilla en la tabla tbl_evaluaciones de la base de datos
        try
        {
            GridView gv = new GridView();
            gv = GvListaUnidades;
            int cod_fun;
            if (gv.Rows.Count > 0)
            {
                cls_Habilitados.InhabilitarEvaluacionesAnteriores();
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
                                cls_Habilitados.Insertar_Habilitados(Convert.ToInt32(lblIdGestion.Text), Convert.ToInt32(lblIdperiodo.Text), cod_fun, Convert.ToInt32(item.Cells[9].Text));
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
            Response.Redirect("Error.html");
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "error", "$(function(){ $('#error-text').text('" + ex + "'); });", true);
        }
    }
    */
    protected void GvListaUnidades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index2 = Convert.ToInt32(e.CommandArgument);
        int id_unidad = 0;
        string ca_id = GvListaUnidades.DataKeys[index2].Values[2].ToString();//3
        //string unidad_s = GvListaUnidades.DataKeys[index2].Values[1].ToString();
        switch (e.CommandName)
        {
            case "Asignar":    //se almacena la información del evaluado seleccionado para cargar sus respuestas en variables de sesión
                //DataKeyNames = "per_id, ca_id, ca_id_evaluador, pr_id, id_evaluacion, paterno, materno, nombres, cargo, puesto"
                id_unidad = Convert.ToInt32(GvListaUnidades.DataKeys[index2].Values["eo_id"].ToString());
                lblUnidadSeleccionada.Text = GvListaUnidades.DataKeys[index2].Values["eo_descripcion"].ToString();
                ListarItemsPorUnidad(id_gestion, id_periodo, id_unidad);
                break;

        }
    }
    protected void GvListaItemsUnidad_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string eva_id_evaluacion = GvListaItemsUnidad.DataKeys[index].Values[2].ToString();//3
        int ca_id_evaluado = Convert.ToInt32( GvListaItemsUnidad.DataKeys[index].Values[3].ToString());
        string sc;
        switch (e.CommandName)
        {
            case "Evaluador":
                //DataKeyNames="eva_pr_id, eva_periodo, eo_id,eva_ca_id,nombre_completo,cargo,puesto"
                sc = "$('#ModalEvaluador').modal('show');";
                Llenar_List_Supervisores(ca_id_evaluado);
                lblEvaluado.Text = GvListaItemsUnidad.DataKeys[index].Values[4].ToString();
                lblEvaluadoCargo.Text = GvListaItemsUnidad.DataKeys[index].Values[5].ToString();
                lblEvaluadoPuesto.Text = GvListaItemsUnidad.DataKeys[index].Values[6].ToString();
                lblEvaluadoEvaluador.Text = GvListaItemsUnidad.DataKeys[index].Values[7].ToString();
                lblEvaluadoId.Text = GvListaItemsUnidad.DataKeys[index].Values[8].ToString();
                lblEvaluadoEoId.Text = GvListaItemsUnidad.DataKeys[index].Values[2].ToString();
                SetScript(sc, ", dropdownParent: $('#ModalEvaluador')");
       // ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "$(function(){ $('#ModalEvaluador').modal('show'); });", true);
                
                break;
        }

    }

    protected void GvListaUnidades_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Obtener el valor de la columna "Estado"
            string estado = DataBinder.Eval(e.Row.DataItem, "eva_estado_evaluador") as string;

            // Buscar el LinkButton de Finalizar en la fila actual
            LinkButton btnEvaluador = e.Row.FindControl("btnEvaluador") as LinkButton;

            if (btnEvaluador != null)
            {
                // Cambiar la imagen según el estado         <img src="imagenes/habilitadoOK.png" alt="Finalizar" style="width: 30px; height:35px;" />
                if (estado == "asignado")
                {
                    btnEvaluador.Text = "<img src='imagenes/user1.png' alt='Evaluar' style='width: 20px; height: 22px;'/>";
                    //btnEvaluador.Enabled = false;
                    btnEvaluador.ToolTip = "Ver Evaluador";
                }
                else
                {
                    btnEvaluador.Text = "<img src='imagenes/user4.png' alt='Finalizar' style='width: 20px; height:22px;' />";
                    btnEvaluador.ToolTip = "Asignar Evaluador";

                }
            }
        }
    }
    protected void GvListaItemsUnidad_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Obtener el valor de la columna "Estado"
            string estado = DataBinder.Eval(e.Row.DataItem, "eva_estado") as string;

            // Buscar el LinkButton de Finalizar en la fila actual
            LinkButton btnEvaluadorItem = e.Row.FindControl("btnEvaluadorItem") as LinkButton;

            if (btnEvaluadorItem != null)
            {
                // Cambiar la imagen según el estado  <img src="imagenes/lapiz.png" alt="Evaluar" style="width: 18px; height: 25px;" />
                if(estado.ToUpper() != "FINALIZADO")
                {
                    btnEvaluadorItem.Text = "<img src='imagenes/lapiz.png' alt='Evaluar' style='width: 18px; height: 25px;'/>";
                    btnEvaluadorItem.Visible = true;
                    //btnEvaluadorItem.ToolTip = "Ver Evaluador";
                }
                else
                {
                    //btnEvaluadorItem.Text = "<img src='imagenes/user4.png' alt='Finalizar' style='width: 20px; height:22px;' />";
                    btnEvaluadorItem.Visible = false;

                }
            }
        }
    }

    private void Llenar_List_Supervisores(int id_cargo)
    {
        DataSet supervisoresHabilitados = cls_Habilitados.EvaluadoresHabilitados("C5", id_gestion, id_periodo, id_cargo, tipo_evaluacion);
        List_Supervisores.DataSource = supervisoresHabilitados;
        List_Supervisores.DataValueField = "s_ca_id";
        List_Supervisores.DataTextField = "s_descripcion";
        List_Supervisores.ToolTip = "s_puesto";
        List_Supervisores.DataBind();

    }
    
    protected void BtnGuardarG_OnClick(object sender, EventArgs e)
    {

            if (List_Supervisores.SelectedItem != null && !string.IsNullOrEmpty(List_Supervisores.SelectedItem.Text))
            {
                cls_Habilitados.EvaluadorAsignado("C6", id_gestion, id_periodo, Convert.ToInt32(lblEvaluadoId.Text), Convert.ToInt32(List_Supervisores.SelectedValue), tipo_evaluacion);
            string sc;
            sc = "$('#ModalEvaluador').modal('hide'); ";// location.reload();";
            SetScript(sc, "");
            ListarUnidades();
            ListarItemsPorUnidad(id_gestion, id_periodo, Convert.ToInt32(lblEvaluadoEoId.Text));

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