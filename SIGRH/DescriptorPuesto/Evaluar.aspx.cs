using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using System;
using System.Activities.Expressions;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DescriptorPuesto_Evaluar : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            var id = Convert.ToString(Session["per_id"]);
            if (!Page.IsPostBack)
            {
                if (Session["r_id"] != null)

                {
                    cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
                    int r_id = Convert.ToInt32(Session["r_id"].ToString());
                    //descriptor_puestos = new cls_mp_descriptor_puestos();
                    //int superv_id = descriptor_puestos.Obtener_idSuperv(per_id);
                    LLenarGridEvaluacion(r_id);

                    string Nom_Comp = descriptor_puestos.Nom_Com(r_id);
                    Nom.InnerText = Nom_Comp;
                    // string cc = Nom_Comp;
                     
                    LLenarGridEvaluacionCa(r_id);
                }

            }

        }
        else Response.Redirect("../Index");

    }
    protected void GridView4_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument);

        if (index >= 0 && index < GridView4.DataKeys.Count)
        {
            string r_id = GridView4.DataKeys[index].Value.ToString();
            h_r_id.Value = r_id;
           // Session["hr_id"] = r_id;
            ViewState["hr_id"] = r_id;


            switch (e.CommandName)
            {

                case "getViewPDF":

            
             int descrip_pu_id = Convert.ToInt32(r_id);
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

               break;


               case "Evaluar":
                    sc = "$('#evaluarModal').modal('show');";

                    SetScript(sc, "");
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#evaluarModal').modal('show');", true);


                    break;
                default:
                    break;
            }
        }
    }
    private void LLenarGridEvaluacion(int dpr)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();

        if (Session["r_id"] != null)
        {
            
            int r_id = Convert.ToInt32(Session["r_id"].ToString());
            var dataSource = descriptor_puestos.ListarTareaER(r_id);

            if (dataSource != null && dataSource.Tables[0].Rows.Count > 0)
            {
                GridView4.DataSource = dataSource;
                Btn_ir_imprimirEva.Visible = false;
            }
            else
            {
                GridView4.DataSource = new List<object>();
                Btn_ir_imprimirEva.Visible = true;
            }
        }
        else
        {
            GridView4.DataSource = new List<object>();
           // Btn_ir_imprimirEva.Visible = true;
        }

        GridView4.DataBind();
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

    protected void btnAdd_Click_Eva(object sender, EventArgs e)
    {

        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
       
        int ad = Convert.ToInt32(ViewState["hr_id"].ToString());

        decimal pd = descriptor_puestos.result_PonderacionTarea(ad);
        decimal ponderacion = Convert.ToDecimal(this.inputPonderacion.Text.Trim());

        if (ponderacion <= pd )
        {
            
            string resultadoSP = descriptor_puestos.Add_Eva(ponderacion, 1, ad);
            bool resultado = descriptor_puestos.Update_EstadoResultado(ad, "E");

            string d = resultadoSP;
            Response.Redirect("Evaluar");
        }
        else
        {
            // Session["texto_notificacion"] = "hola";
            /*  string mensaje = "La ponderación ingresada es mayor a ." + pd;
              string script = $"alert('{mensaje}');";
              sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Factor registrado exitosamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevoFactor').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
              SetScript(sc, "");*/
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'La ponderación ingresada es mayor a " + pd+ " ' }, { type: 'warning' });";
            //sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Factor registrado exitosamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#evaluarModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            SetScript(sc,"");


        }

        //Response.Redirect("Evaluar");


    }



    protected void GridView5_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        int index = Convert.ToInt32(e.CommandArgument);

        if (index >= 0 && index < GridView5.DataKeys.Count)
        {
            string r_id = GridView5.DataKeys[index].Value.ToString();
            h_r_id1.Value = r_id;
            // Session["hr_id"] = r_id;
            //ViewState["hr_id"] = r_id;


            switch (e.CommandName)
            {

                case "EditarEva":
                   /* sc = "$('#modalEditarResulEva').modal('show');";
                    //Session["PdfDataUrl"] = pdfDataUrl;
                    SetScript(sc, "");*/

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#modalEditarResulEva').modal('show');", true);



                    break;


                case "Evaluar":
                   


                    break;
                default:
                    break;
            }
        }
    }

    private void LLenarGridEvaluacionCa(int dpr)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();

        if (Session["r_id"] != null)
        {

            int r_id = Convert.ToInt32(Session["r_id"].ToString());
            var dataSource = descriptor_puestos.Listar_EvaluacionesCa(r_id);
          
            if (dataSource != null )
            {
                GridView5.DataSource = dataSource;
               
            }
            else
            {
                GridView5.DataSource = new List<object>();
                
            }
        }
        else
        {
            GridView5.DataSource = new List<object>();
            
        }

        GridView5.DataBind();
    }

    public void Result_Eva(int evalua_dp_id)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        DataSet data = descriptor_puestos.ResultEva(evalua_dp_id);

        if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
        {
            DataRow row = data.Tables[0].Rows[0];

            Eva_PonderacionText.Text = row["evalua_ponderacion"].ToString();
            //IndicadorText.Text = row["result_indicador"].ToString();
           // PonderacionText.Text = row["result_ponderacion"].ToString();
        }
        else
        {

        }
    }




    protected void Btn_imprimirEvalua_Click(object sender, EventArgs e)
    {
        int r_id = Convert.ToInt32(Session["r_id"].ToString());
        string sc = "window.open('ReporteResultado.aspx?id=" + r_id + "', 'width=500,height=500', '_blank');";
        SetScript(sc, "");
        
    }




    protected void btnCerrar_Click(object sender, EventArgs e)
    {
        Response.Redirect("Evaluar");
    }



  

    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar MENU Registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando Registros del START al END de un total de TOTAL Registros'," +
                    "'sInfoEmpty': 'Mostrando Registros del 0 al 0 de un total de 0 Registros'," +
                    "'sInfoFiltered': '(filtrado de un total de MAX Registros)'," +
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


}