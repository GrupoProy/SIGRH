using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Evaluacion.BussinessLogicLayer;
using Solution_Framework_Evaluacion.DataAccessLayer;
using System.Data;
using System.IO;
using System.Text;

public partial class Evaluacion_InformeActividadesEvaluacion : System.Web.UI.Page
{
    private string sc = "";
    private cls_mp_asignacion _asignacion = null;
    private cls_mp_descriptor_puestos descriptor_puestos = null;
    private int id_evaluacion=0;
    private int periodo;
    private string tipo_evaluacion;
    private int id_gestion;
    private string gestion;
    private string categoria;
    protected void Page_Load(object sender, EventArgs e)
    {


        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            //var id = 276;//266 Convert.ToString(Session["per_id"]);
            //var id = 266;//266 
            var id = Convert.ToString(Session["per_id"]); ///********txtId.Text;
            Parametros_Bind(Convert.ToInt32(id));

            if (!Page.IsPostBack)
            {
                int id_per = Convert.ToInt32(Session["per_id"]);

            }

        }
        else Response.Redirect("../Index");
    }

    private void Parametros_Bind(int per_id)
    {
        //gestion = cls_Formulario.GestionActual("gestion", tipo_evaluacion).Tables[0].Rows[0]["periodo_gestion"].ToString();
        
        //STAR DATOS EVALUADO
        DataSet DS2 = cls_Formulario.ObtenerIdEvaluacionPdf(per_id);

        if (DS2.Tables.Count > 0 && DS2.Tables[0].Rows.Count > 0)
        {
            DataRow row = DS2.Tables[0].Rows[0];

            id_gestion = Convert.ToInt32($"{row["eva_pr_id"]}");
            periodo = Convert.ToInt32($"{row["eva_periodo"]}");
            tipo_evaluacion = $"{row["eva_tipo_evaluacion"]}";
            id_evaluacion = Convert.ToInt32($"{row["eva_id_evaluacion"]}");
            categoria = $"{row["categoria"]}";
            gestion = $"{row["gestion"]}";
            PanelDatosGenerales.Visible = true;
        }

        if (id_evaluacion == 0)
        {
            lblPeriodoEvaluado.Text = "*** NO CORRESPONDE SER EVALUADO ***";
            PanelPasosInforme.Visible = false;
        }
        else
        {
            Bind_DatosPersonales(per_id);
            BindTipoEvaluacion();
        }

    }
    protected void Bind_DatosPersonales(int per_id)
    {
        //STAR DATOS EVALUADO
        PanelDatosGenerales.Visible = true;
        DataSet DS = cls_DatosPersonales.FuncionarioDatosPersonales(per_id, periodo, tipo_evaluacion);

        if (DS.Tables.Count > 0 && DS.Tables[0].Rows.Count > 0)
        {
            DataRow row = DS.Tables[0].Rows[0];

            // Asigna los datos a los elementos correspondientes
            //li.Text = $"{row["nombres"]} {row["paterno"]} {row["materno"]}";
            ltl_cargo.Text = $"{row["cargo"]}";
            ltl_puesto.Text = $"{row["puesto"]}";
            ltl_ubicacion.Text = $"{row["unidad"]}";
            ltl_item.Text= $"{row["item"]}";
            ltl_nombreCompleto.Text = $"{row["nombres"]}" + " " + $"{row["paterno"]}" + " " + $"{row["materno"]}";


        }
        //
    }
    private void BindTipoEvaluacion()
    {
        if (tipo_evaluacion == "P")
        { lblTipoEvaluacion.Text = "EVALUACION DEL DESEMPEÑO"; }
        else
        { lblTipoEvaluacion.Text = "EVALUACION DEL RENDIMIENTO"; }
        if (periodo == 1)
        { lblPeriodoEvaluado.Text = "Primer Semestre "+gestion; }
        else
        { lblPeriodoEvaluado.Text = "Segundo Semestre "+ gestion; }
////////////////////////////////////////////////////////////////
        if (categoria == "D" || categoria == "E")
        {
            lblMsgInforme.Text = "*** NO CORRESPONDE CARGAR INFORME DE ACTIVIDADES ***";
            PanelPasosInforme.Visible = false;
        }
        else
        {
            PanelPasosInforme.Visible = true;
            lblMsgInforme.Text = "";
        }


        
    }
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    protected void btnDescargarPdf_Click(object sender, ImageClickEventArgs e)
    {
        // protected void Btn_imprimirEva_Click(object sender, EventArgs e)
        //int id_evaluacionInf = id_evaluacion;
        string sc = "window.open('../Evaluacion/InformeActividadesRpt.aspx?id_evaluacion=" + id_evaluacion+ "', 'width=500,height=500', '_blank');";
        SetScript(sc,"");


    }
    protected void btnAbrirPdf_Click(object sender, EventArgs e)
    {

        //if (descriptor_puestos.devuelver_Si_hayPDF(Convert.ToInt32("1045")) == 1)
        //{
        //    textoHaypdf.Visible = true;
        //}
        //else
        //{
        //    textoHaypdf.Visible = false;
        //}
        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#myModal3').modal('show');", true);
    }


    protected void btnSubirPdf_Click(object sender, EventArgs e)
    {
        cls_Formulario evaluacion = new cls_Formulario();
        evaluacion.eva_id_evaluacion = int.Parse(Convert.ToString(id_evaluacion));

        if (pdfUpload.HasFile)
        {
            try
            {
                string filename = Path.GetFileName(pdfUpload.PostedFile.FileName);
                string filename2 = filename.Substring(0, filename.Length - 4);
                string contentType = pdfUpload.PostedFile.ContentType;
                using (Stream fs = pdfUpload.PostedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        evaluacion.eva_pdf = bytes;
                    }
                }


                int result = evaluacion.UpdateTER_PDF(
                    evaluacion.eva_id_evaluacion,
                    evaluacion.eva_pdf);
                if (result == 1)
                {
                    int resultado2 = evaluacion.devuelver_Si_hayPDF(id_evaluacion);
                    if (resultado2 == 1)
                    {
                        textoHaypdf.Visible = true;//existe archivo ya cargado
                    }
                    else
                    {
                        textoHaypdf.Visible = false;
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "uploadSuccess", "alert('Archivo subido con éxito');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "uploadFailure", "alert('Hubo un error al subir el archivo');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "error", "alert('Hubo un error: " + ex.Message + "');", true);
            }
        }
        else
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "noFile", "alert('No se seleccionó ningún archivo');", true);
        }
    }

   
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar _MENU_ Registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando Registros del _START_ al _END_ de un total de _TOTAL_ Registros'," +
                    "'sInfoEmpty': 'Mostrando Registros del 0 al 0 de un total de 0 Registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ Registros)'," +
                    "'sInfoPostFix': ''," +
                    "'sSearch': 'Buscar:'," +
                    "'sUrl': ''," +
                    "'sInfoThousands': ','," +
                    "'sLoadingRecords': 'Cargando...'," +
                    "'oPaginate': {" +
                        "'sFirst': '«'," +
                        "'sLast': '»'," +
                        "'sNext': '<i class=\"fas fa-angle-right\"></i>'," +
                        "'sPrevious': '<i class=\"fas fa-angle-left\"></i>'" +
                    "}," +
                    "'oAria': {" +
                        "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                        "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                "}," +
                "'ordering': false," +
                "'searching': true," + // Muestra/Oculta el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" + // Muestra/Oculta el campo información
            "});");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerDefault\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: \"es\"" +
                    "});" +
                "});" +
                "var me = $(\".datepickerDefault\");" +
                "me.mask(\"99/99/9999\");" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }

    protected void VerInforme_Click(object sender, EventArgs e)
    {
        LinkButton imgButton = (LinkButton)sender;
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
}