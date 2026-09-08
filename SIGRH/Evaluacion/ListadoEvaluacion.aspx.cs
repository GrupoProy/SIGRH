using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
using Solution_Framework_Evaluacion.DataAccessLayer;
using System.Data;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class Evaluacion_ListadoEvaluacion : System.Web.UI.Page
{
    private string previousEoDescripcion = string.Empty;
    private int rowIndexCounter = 0;
    int per_id = 0;//código de funcionario
    int id_evaluacion = 0;//id de evaluación
    int pr_id;
    int periodo;
    private string tipo = "P";
    private int ca_id_evaluador = 0;
    private int casosNoFinalizado = 0;
    private int casosFinalizado = 0;
    protected void Page_Load(object sender, EventArgs e)
    {

        //se limpian las variables de sesión para registrarlas luego con la información del funcionario a evaluar
        Session.Remove("respuestas_resultados_especificos"); Session["respuestas_resultados_especificos"] = null;
        Session.Remove("respuestas_factores_evaluacion"); Session["respuestas_factores_evaluacion"] = null;
        Session.Remove("respuestas_DNC"); Session["respuestas_DNC"] = null;
        Session.Remove("ca_id_funcionario"); Session["ca_id_funcionario"] = null;
        Session.Remove("id_evaluacion"); Session["id_evaluacion"] = null;

        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString());//se asigna a la variable, el código de funcionario almacenado en la variable de sesión
            Gestion_Bind(tipo);//se carga la información de la gestión y periodo
            if (!Page.IsPostBack)
            {
                //Debug.WriteLine("cargando dependientesn");
                DatosPersonales_Bind();//se cargan los datos personales del evaluado y evaluador
                Dependientes_Bind();//se carga el listado de los funcionarios dependientes del evaluador
                MsgFinalizado();
            }
            
        }
        else Response.Redirect("../Index");//si el usuario no está loggeado, no puede ingresar al sistema de evaluación
    }
    private void Gestion_Bind(string tipo)
    {
        periodo = Convert.ToInt32(cls_Formulario.GestionActual("periodo",tipo).Tables[0].Rows[0]["periodo_gestion"].ToString());
        pr_id = Convert.ToInt32(cls_Formulario.GestionActual("id_gestion",tipo).Tables[0].Rows[0]["periodo_gestion"].ToString());
        Session["gestion"] = pr_id;
        Session["periodo"] = periodo;
    }
    private void DatosPersonales_Bind()
    {
        if (periodo == 1)  { Labeleva.Text = "Primer Semestre " + cls_Formulario.GestionActual("gestion", tipo).Tables[0].Rows[0]["periodo_gestion"].ToString();
        } else { Labeleva.Text = "Segundo Semestre "+ cls_Formulario.GestionActual("gestion", tipo).Tables[0].Rows[0]["periodo_gestion"].ToString(); }  

        DataSet DS = cls_DatosPersonales.FuncionarioDatosPersonalesEvaluador(per_id, periodo,tipo);
        //VALIDAR VERIFICAR QUE O JALAR DATOS DEL EVALUADOR AUNQUE NO SEA DE PLANTA O CONTRATO
        //O VRIFICAR EL ESTADO_EVALUADOR > confirmado
        LblEvaluador.Text = DS.Tables[0].Rows[0]["nombres"].ToString() + " " + DS.Tables[0].Rows[0]["paterno"].ToString() + " " + DS.Tables[0].Rows[0]["materno"].ToString();
        LblPuesto.Text = DS.Tables[0].Rows[0]["puesto"].ToString();
        LblUnidad.Text = DS.Tables[0].Rows[0]["unidad"].ToString();
        ca_id_evaluador = Convert.ToInt32(DS.Tables[0].Rows[0]["ca_id"].ToString());
    }
    private void MsgFinalizado()
    {
        lblcasosNoFinalizado.Text = Convert.ToString(casosFinalizado);
        lblcasosFinalizado.Text = Convert.ToString(casosFinalizado+ casosNoFinalizado);
        if (casosFinalizado == (casosFinalizado + casosNoFinalizado))
        {
            lblMsgEvaluacion1.Text = "<strong> Bien hecho!</strong>";
            lblMsgEvaluacion2.Text = " Usted ha finalizado la Evaluacion satisfactoriamente. </br><strong>Debe remitir los formularios de cada evaluado, debidamente firmado, a la Unidad de Recursos Humanos.</strong>";
            string FinalizadoCssClass = "alert alert-success mb-0";
        }

    }
    private void Dependientes_Bind()
    {
        
    DataSet dependientesDataSet = cls_DatosPersonales.FuncionariosDependientes(per_id, LblUnidad.Text, pr_id, periodo,tipo, ca_id_evaluador);

     foreach (DataTable table in dependientesDataSet.Tables)
    {
        table.Columns.Add("TarjetaInfo", typeof(string));

            if (!table.Columns.Contains("EstadoCssClass"))
            {
                table.Columns.Add("EstadoCssClass", typeof(string));
            }

        foreach (DataRow row in table.Rows)
        {
            string estado = row["ESTADO"].ToString(); // Asegúrate de que ESTADO sea el nombre correcto del campo

            string colorClase = "";


                // Determina el color de la clase según el estado
                if (estado == "FINALIZADO")
                {
                    colorClase = "badge badge-success";
                    casosFinalizado++;
                }
                if (estado == "SIN INICIAR")
                {
                    colorClase = "badge badge-danger";
                    casosNoFinalizado++;
                }
                   if (estado == "EN PROCESO")
                    {
                        colorClase = "badge badge-info";
                    casosNoFinalizado++;
                }
                    
                // Puedes agregar más condiciones según sea necesario

                string tarjetaInfo = $"<div class='ct-page-title3'style='margin-top: 2px; margin-botton: 2px;'><div  style='margin-bottom: 0px; display: flex; align-items: center;'>";

            if (row["fp_foto"] != DBNull.Value && row["fp_foto"] != null && !string.IsNullOrEmpty(row["fp_foto"].ToString()))
            {
                tarjetaInfo += $"<div style='margin-right: 2px;'><img class='rounded-circle' style='width: 1.2cm; height: 1.2cm;' src='data:image/jpg;base64,{Convert.ToBase64String((byte[])row["fp_foto"])}' /></div>";
            }
            else
            {
                tarjetaInfo += $"<div style='margin-right: 2px;'><img class='rounded-circle' style='width: 1.2cm; height: 1.2cm;' src='../Content/img/theme/user3.jpg' /></div>";
            }

            tarjetaInfo += $"<div><h5 class='card-title'><strong>{row["nombres"]} {row["paterno"]} {row["materno"]} </strong>";
            tarjetaInfo += $"</br><strong>&nbsp;&nbsp;   CARGO: </strong> {row["cargo"]}";
            tarjetaInfo += $"</br><strong>&nbsp;&nbsp;   PUESTO: </strong> {row["puesto"]}</h5></div></div></div>";

            row["TarjetaInfo"] = tarjetaInfo;
            row["EstadoCssClass"] = colorClase; // Asigna la clase CSS del estado a la nueva columna

            }
        }

        GvLista.DataSource = dependientesDataSet;
        GvLista.DataBind();
    }


    protected void GvLista_PreRender(object sender, EventArgs e)
        {
            base.OnPreRender(e);
            if (GvLista.Rows.Count > 0)
            {
                if (GvLista.HeaderRow != null)
                {
                    GvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
                }
                if (GvLista.FooterRow != null)
                {
                    GvLista.FooterRow.TableSection = TableRowSection.TableFooter;
                }
            }
        }
    protected void GvListaUnidades_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //    
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Obtener el valor de la columna "Estado"
            string estado = DataBinder.Eval(e.Row.DataItem, "ESTADO") as string;

            // Buscar el LinkButton de Finalizar en la fila actual
            LinkButton btnFinalizar = e.Row.FindControl("btnFinalizar") as LinkButton;

            if (btnFinalizar != null)
            {
                // Cambiar la imagen según el estado         <img src="imagenes/habilitadoOK.png" alt="Finalizar" style="width: 30px; height:35px;" />
                LinkButton btnEvaluar= e.Row.FindControl("btnEvaluar") as LinkButton;
                LinkButton btnImprimmir = e.Row.FindControl("btnImprimir") as LinkButton;
                LinkButton btnFinalizado = e.Row.FindControl("btnFinalizado") as LinkButton;
                LinkButton btnJustificar = e.Row.FindControl("btnJustificar") as LinkButton;


                if (estado == "FINALIZADO")
                {
                    btnFinalizar.Text = "<img src='imagenes/habilitadoNO4.png' alt='Finalizar' style='width: 30px; height:35px;' />";
                    btnEvaluar.Text = "<img src='imagenes/evaluar_4.png' alt='Evaluar' style='width: 30px; height:35px;' />";
                    btnFinalizar.Enabled = false;
                    btnEvaluar.Enabled = false;
                    btnEvaluar.ToolTip = "Evaluacion Cerrada";
                    btnFinalizar.ToolTip = "Evaluacion Cerrada";
                    btnFinalizado.Text= "<img src='imagenes/check.png' alt='Finalizado' style='width: 17px; height:25px;' />";
                    btnFinalizado.Visible = true;
                    btnFinalizado.Enabled = false;
                    btnJustificar.Enabled = false;
                    //btnEvaluar.Visible = false;

                }
                else
                {
                    if( estado == "SIN INICIAR")
                    {
                        btnImprimmir.Text = "<img src='imagenes/imprimir_4.png' alt='Finalizar' style='width: 30px; height:35px;' />";
                        btnFinalizar.Text = "<img src='imagenes/habilitadoOK4.png' alt='Evaluar' style='width: 30px; height:35px;' />";
                        btnFinalizar.Enabled = false;
                        btnImprimmir.Enabled = false;
                        btnJustificar.Text = "<img src='imagenes/justificar.png' alt='Evaluar' style='width: 17px; height:25px;' />";
                        btnJustificar.Enabled = true;

                    }
                    else
                    {
                        btnFinalizar.Text = "<img src='imagenes/habilitadoOK.png' alt='Finalizar' style='width: 30px; height:35px;' />";
                    }
                    
                }
            }
        }
    }

    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        //sp_ev_Evaluador_Dependientes
        //DataKeyNames = "per_id, ca_id, ca_id_evaluador, pr_id, id_evaluacion, paterno, materno, nombres, cargo, puesto"
        string per_id = GvLista.DataKeys[index].Values[0].ToString();
        string ca_id = GvLista.DataKeys[index].Values[1].ToString();
        string ca_id_evaluador = GvLista.DataKeys[index].Values[2].ToString();
        string pr_id = GvLista.DataKeys[index].Values[3].ToString();
        string id_evaluacion = GvLista.DataKeys[index].Values[4].ToString();
        string paterno = GvLista.DataKeys[index].Values[5].ToString();
        string materno = GvLista.DataKeys[index].Values[6].ToString();
        string nombres = GvLista.DataKeys[index].Values[7].ToString();
        string cargo = GvLista.DataKeys[index].Values[8].ToString();
        string puesto = GvLista.DataKeys[index].Values[9].ToString();
        int id_evaluacionList = Convert.ToInt32(GvLista.DataKeys[index].Values["id_evaluacion"].ToString());

        switch (e.CommandName)
        {
            case "Evaluar":    //se almacena la información del evaluado seleccionado para cargar sus respuestas en variables de sesión
                //DataKeyNames = "per_id, ca_id, ca_id_evaluador, pr_id, id_evaluacion, paterno, materno, nombres, cargo, puesto"
                Session["ca_id_funcionario"] = GvLista.DataKeys[index].Values["ca_id"].ToString();
                Session["id_evaluacion"] = GvLista.DataKeys[index].Values["id_evaluacion"].ToString();
                Session["pr_id"] = GvLista.DataKeys[index].Values["pr_id"].ToString();
                Session["nombre_funcionario"] = GvLista.DataKeys[index].Values["paterno"].ToString() + " " + GvLista.DataKeys[index].Values["materno"].ToString() + " " + GvLista.DataKeys[index].Values["nombres"].ToString();
                Session["cargo_funcionario"] = GvLista.DataKeys[index].Values["cargo"].ToString();
                Session["puesto_funcionario"] = GvLista.DataKeys[index].Values["puesto"].ToString();
                Session["imprimir_per_id"] = GvLista.DataKeys[index].Values["per_id"].ToString();
                Session["periodo"] = periodo;
                Session["tipo_evaluacion"] = tipo;
                //se redirecciona a la sección de resultados específicos
                Response.Redirect("ResultadosEspecificos.aspx");
                break;
            case "Imprimir":
                Session["imprimir_ca_id"] = GvLista.DataKeys[index].Values["ca_id"].ToString();
                Session["pr_id"] = GvLista.DataKeys[index].Values["pr_id"].ToString();
                Session["periodo"] = periodo;
                Session["imprimir_per_id"] = GvLista.DataKeys[index].Values["per_id"].ToString();
                Session["tipo_evaluacion"] = tipo;
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "imprimir", "window.open('FormularioEvaluacion.aspx', '_blank', 'width = 800, height = 500')", true);

                break;
            case "Finalizar":

                int respuestasFactores = Convert.ToInt32(cls_ResultadosEspecificos.RespuestasEspecificasFactores(id_evaluacionList, "RespuestasFactores"));
                int respuestasEspecificas = Convert.ToInt32(cls_ResultadosEspecificos.RespuestasEspecificasFactores(id_evaluacionList, "RespuestasEspecificos"));

                DataSet DS1 = cls_ResultadosEspecificos.Bind_ResultadosEspecificos(Convert.ToInt32(ca_id), "ResultadosEspecificos", id_evaluacionList);
                int especificas = (DS1.Tables[0].Rows.Count)*3;
                DataSet DS2 = cls_FactoresEvaluacion.Bind_FactoresEvaluacion(Convert.ToInt32(ca_id), "FactoresEvaluacion", id_evaluacionList);
                int factores = DS2.Tables[0].Rows.Count;
                //lblFinalizarEvaluacion.Text = "pp";
               
                string sc = "$('#ModalAlerta1').modal('show');";

                if (respuestasEspecificas == especificas && respuestasFactores == factores)
                {
                    lblFinalizarEvaluacion.Text = "Esta seguro(a) que desea finalizar la Evaluacion seleccionada?";
                    lblEvaluacion.Text = GvLista.DataKeys[index].Values["id_evaluacion"].ToString();
                    BtnGuardarG.Visible = true;
                    SetScript(sc, ", dropdownParent: $('#ModalAlerta1')");
                    //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "$(function(){ $('#ModalAlerta1').modal('show'); });", true);
                    //cls_Formulario.Finalizar_Evaluacion(Convert.ToInt32(GvLista.DataKeys[index].Values["id_evaluacion"].ToString()), "finalizado");
                }
                else
                {
                    lblFinalizarEvaluacion.Text = "No puede FINALIZAR EVALUACION, tiene pendiente campos a evaluar";
                    BtnGuardarG.Visible = false;
                    BtnCancelarG.Text = "<i class='fas fa-save mr-2'></i> OK";
                    ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "$(function(){ $('#ModalAlerta1').modal('show'); });", true);

                }
                Gestion_Bind(tipo);
                DatosPersonales_Bind();
                Dependientes_Bind();
                break;

            case "Justificar":
                //Response.Redirect("finalizar_eva.aspx"); 
                string scJustificar = "$('#ModalJustificar').modal('show');";
                SetScript(scJustificar, ", dropdownParent: $('#ModalJustificar')");
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "key", "$(function(){ $('#ModalAlerta1').modal('show'); });", true);
                //cls_Formulario.Finalizar_Evaluacion(Convert.ToInt32(GvLista.DataKeys[index].Values["id_evaluacion"].ToString()), "finalizado");
                lblEvaluado.Text = nombres + " " + paterno + " " + materno;
                lblEvaluadoCargo.Text = cargo;
                lblEvaluadoPuesto.Text = puesto;
                lblEvaluadoId.Text = id_evaluacion;

                Gestion_Bind(tipo);
                DatosPersonales_Bind();
                Dependientes_Bind();
                break;
        }

    }

    protected void BtnGuardarG_OnClick(object sender, EventArgs e)
    {
        cls_Formulario.Finalizar_Evaluacion(Convert.ToInt32(lblEvaluacion.Text), "finalizado");
        Gestion_Bind(tipo);
        DatosPersonales_Bind();
        Dependientes_Bind();
        string sc;
        sc = "$('#ModalAlerta1').modal('hide'); ";// location.reload();";
        SetScript(sc, "");
    }
    
    protected void BtnGuardarJustificacion_OnClick(object sender, EventArgs e)
    {
        if (List_Justificaciones.SelectedItem != null && !string.IsNullOrEmpty(List_Justificaciones.SelectedItem.Text))
        {
            cls_Formulario.JustificarEvaluacion(Convert.ToInt32(lblEvaluadoId.Text), List_Justificaciones.SelectedValue);
            Gestion_Bind(tipo);
            DatosPersonales_Bind();
            Dependientes_Bind();
            string sc;
            sc = "$('#ModalJustificar').modal('hide'); ";// location.reload();";
            SetScript(sc, "");
            cls_Formulario.Finalizar_Evaluacion(Convert.ToInt32(lblEvaluadoId.Text), "finalizado");
            Gestion_Bind(tipo);
            DatosPersonales_Bind();
            Dependientes_Bind();

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

