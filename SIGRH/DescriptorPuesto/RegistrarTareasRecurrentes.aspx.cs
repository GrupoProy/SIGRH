using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DescriptorPuesto_RegistrarTareasRecurrentes : System.Web.UI.Page
{
    private string sc = "";
    private cls_mp_asignacion _asignacion = null;
    private cls_mp_descriptor_puestos descriptor_puestos = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            var id = Convert.ToString(Session["per_id"]);
            if (!Page.IsPostBack)
            {
                cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
                int id_per = Convert.ToInt32(Session["per_id"]);
                descriptor_puestos = new cls_mp_descriptor_puestos();
                int dprp = descriptor_puestos.Verificar_ca_id(id_per);

                LLenarGridResultadosE(dprp, "R");
                decimal totalE = descriptor_puestos.TotalER(dprp, "R");
                TotalAcumulado.Text = totalE.ToString();

                int car_id = descriptor_puestos.devuelver_ca_id(id_per);

              
                int result_ns = descriptor_puestos.result(car_id);
                
                result_nese.Text = result_ns.ToString();

                if (totalE >= result_ns)
                {
                    Btn_guardar_TaRE.Enabled = false;
                    Btn_guardar_TaRE.Attributes["onclick"] = "return false;";
                    Btn_guardar_TaRE.CssClass = "btn btn-success btn-round btn-icon mt-4 disabled";

                    resultado_input.Enabled = false;
                   // indicador_input.Enabled = false;
                    ponderacion_input.Enabled = false;
                }
                else
                {
                    Btn_guardar_TaRE.Enabled = true;
                    Btn_guardar_TaRE.Attributes["onclick"] = "return true;";
                    Btn_guardar_TaRE.CssClass = "btn btn-success btn-round btn-icon mt-4";
                }
                LLenarGridResultadosE(dprp, "R");


            }

        }
        else Response.Redirect("../Index");

    }
    protected void Btn_guardar_TaRE_Click(object sender, EventArgs e)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();

        int id_per = Convert.ToInt32(Session["per_id"]);
        int dprp = descriptor_puestos.Verificar_ca_id(id_per);

        string result_ponderacionText = ponderacion_input.Text.Trim();
        string result_resultado = resultado_input.Text.Trim();

        
        if (string.IsNullOrWhiteSpace(result_ponderacionText) || string.IsNullOrWhiteSpace(result_resultado))
        {
            lblMessage.Text = "Por favor, asegúrese de que todos los campos están llenos.";
            return;
        }

        decimal result_ponderacion;
        if (!decimal.TryParse(result_ponderacionText, out result_ponderacion))
        {
            lblMessage.Text = "Por favor, introduzca un número válido en la ponderación.";
            return;
        }

        string resultadoSP = descriptor_puestos.Add_TareaRecurrente(result_ponderacion, result_resultado, dprp);

        if (resultadoSP == "La inserción fue exitosa")
        {
            // Limpia los campos después de una inserción exitosa
            ponderacion_input.Text = string.Empty;
            resultado_input.Text = string.Empty;
            lblMessage.Text = string.Empty;
            checkRegistroExitoso.Visible = true;
            Response.Redirect("RegistrarTareasRecurrentes");


        }
        else
        {
            // Muestra el modal
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal();", true);
            lblMessage.Text = resultadoSP;
        }
    }




    /*  protected void Btn_guardar_TaRE_Click(object sender, EventArgs e)
      {
          cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();

          int id_per = Convert.ToInt32(Session["per_id"]);
          int dprp = descriptor_puestos.Verificar_ca_id(id_per);

          decimal result_ponderacion = Convert.ToDecimal(ponderacion_input.Text);
          string result_resultado = resultado_input.Text;


              descriptor_puestos.Add_TareaRecurrente(result_ponderacion, result_resultado, dprp);

              // Limpia los campos después de una inserción exitosa
              ponderacion_input.Text = string.Empty;
              resultado_input.Text = string.Empty;

      }*/

    private void LLenarGridResultadosE(int dpr, string result_tipo)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        //string rt = E;

        int id_per = Convert.ToInt32(Session["per_id"]);
        descriptor_puestos = new cls_mp_descriptor_puestos();
        int dprp = descriptor_puestos.Verificar_ca_id(id_per);
        GridView2.DataSource = descriptor_puestos.ListarTareaEspecifica(dprp, "R");
        GridView2.DataBind();

        //SetScript(sc, "");
        //============================================
        /* poai.ListarResultados(pu_id, "E");
         GridView1.DataSource = poai.ListarResultados(pu_id, "E");
         GridView1.DataBind();
         SetScript(sc, "");*/

    }

    protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);

        if (index >= 0 && index < GridView2.DataKeys.Count)
        {
            string r_id = GridView2.DataKeys[index].Value.ToString();
            h_r_id.Value = r_id;
            
           // TotalAcumulado.Text = totalE.ToString();

            switch (e.CommandName)
            {
                case "GetEdit":
                    LlenarDatosResultado(Convert.ToInt32(r_id));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalEditarResultado').modal('show');", true);
                    break;
                case "GetDelete":
                    string sc = "$('#eliminarResultado').modal('show');";
                    SetScript(sc, "");
                    break;
                case "GetArchivo":
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#myModal3').modal('show');", true);
                    break;
                default:
                    break;
            }
        }
    }

    public void LlenarDatosResultado(int id)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        DataSet data = descriptor_puestos.ListarResltaE(id);

        if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
        {
            DataRow row = data.Tables[0].Rows[0];

            ResultadoText.Text = row["result_resultado"].ToString();
            //IndicadorText.Text = row["result_indicador"].ToString();
            PonderacionText.Text = row["result_ponderacion"].ToString();
        }
        else
        {

        }
    }
    protected void btnUpdate_Click_DPER(object sender, EventArgs e)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        descriptor_puestos.result_indicador = null;
        descriptor_puestos.result_ponderacion = decimal.Parse(PonderacionText.Text);
        descriptor_puestos.result_resultado = ResultadoText.Text;
        descriptor_puestos.des_p_result_id = int.Parse(h_r_id.Value);

        bool result = descriptor_puestos.Update_DPER(
            descriptor_puestos.des_p_result_id,
            descriptor_puestos.result_indicador,
            descriptor_puestos.result_ponderacion,
            descriptor_puestos.result_resultado);
            

        if (result== true) 
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalEditarResultado').modal('hide');", true);
            LlenarDatosResultado(descriptor_puestos.des_p_result_id);
           // Response.Write("<script>alert('La actualización no se pudo realizar correctamente.');</script>");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshPage", "window.location.reload();", true);
            Response.Redirect("RegistrarTareasRecurrentes");
        }
        if (result == false)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshPage", "window.location.reload();", true);

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal').modal('show');", true);
        }


      
    }




    protected void btnDelete_Click_DPRR(object sender, EventArgs e)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        descriptor_puestos.des_p_result_id = int.Parse(h_r_id.Value);

        string result_estado = "C";

        bool result = descriptor_puestos.Eliminar_DPR(
            descriptor_puestos.des_p_result_id,
            result_estado);
        if (result)
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshPage", "window.location.reload();", true);
        }
        else
        {

        }
        Response.Redirect("RegistrarTareasRecurrentes");
    }

   /* protected void SubmitButton_Click1(object sender, EventArgs e)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        descriptor_puestos.des_p_result_id = int.Parse(h_r_id.Value);

        if (pdfUpload.HasFile)
        {
            try
            {
                descriptor_puestos.descrip_pdf = pdfUpload.FileBytes;

                bool result = descriptor_puestos.UpdateTER_PDF(
                    descriptor_puestos.des_p_result_id,
                    descriptor_puestos.descrip_pdf);
                if (result == true)
                {
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
    }*/





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




}