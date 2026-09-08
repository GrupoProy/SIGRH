using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DescriptorPuesto_RegistrarTareasEspecificas : System.Web.UI.Page
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
                
                LLenarGridResultados(dprp, "E");
                decimal totalE = descriptor_puestos.TotalER(dprp, "E");
                TotalAcumulado.Text = totalE.ToString();

                if (totalE >= 70)
                {
                    Btn_guardar_TaEs.Enabled = false;
                    Btn_guardar_TaEs.Attributes["onclick"] = "return false;";
                    Btn_guardar_TaEs.CssClass = "btn btn-success btn-round btn-icon mt-4 disabled";

                    resultado_input.Enabled = false;
                    indicador_input.Enabled = false;
                    ponderacion_input.Enabled = false;
                }
                else
                {
                    Btn_guardar_TaEs.Enabled = true;
                    Btn_guardar_TaEs.Attributes["onclick"] = "return true;";
                    Btn_guardar_TaEs.CssClass = "btn btn-success btn-round btn-icon mt-4";
                }


            }

        }
        else Response.Redirect("../Index");
    }
    protected void Btn_guardar_TaEs_Click(object sender, EventArgs e)
    {

        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();

        int id_per = Convert.ToInt32(Session["per_id"]);
        int dprp = descriptor_puestos.Verificar_ca_id(id_per);
        string result_indicador = indicador_input.Text.Trim();
        string result_ponderacionText = ponderacion_input.Text.Trim();
        string result_resultado = resultado_input.Text.Trim();


        if (string.IsNullOrWhiteSpace(result_ponderacionText) || string.IsNullOrWhiteSpace(result_resultado))
        {
            lblMessage.Text = "Por favor, asegúrese de que todos los campos están llenos.";

            return;
        }

        decimal result_ponderacion;
        if (!Decimal.TryParse(result_ponderacionText, out result_ponderacion))
        {
            lblMessage.Text = "Por favor, introduzca un número válido en la ponderación.";
            return;
        }

        string resultadoSP = descriptor_puestos.Add_TareaEspecifica(result_indicador,result_ponderacion, result_resultado, dprp);

        if (resultadoSP == "La inserción fue exitosa")
        {
            indicador_input.Text = string.Empty;
            ponderacion_input.Text = string.Empty;
            resultado_input.Text = string.Empty;
            lblMessage.Text = string.Empty;
            //checkRegistroExitoso.Visible = true;
            Response.Redirect("../DescriptorPuesto/RegistrarTareasEspecificas");
        }
        else
        {
            // Muestra el modal
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myModal", "$('#myModal').modal();", true);
            lblMessage.Text = resultadoSP;

        }




    }

    /* protected void Btn_guardar_TaEs_Click(object sender, EventArgs e)
     {

         cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();

         int id_per = Convert.ToInt32(Session["per_id"]);
         descriptor_puestos = new cls_mp_descriptor_puestos();
         int dprp = descriptor_puestos.Verificar_ca_id(id_per);


         string result_indicador = indicador_input.Text;
         decimal result_ponderacion = Convert.ToDecimal(ponderacion_input.Text);
         string result_resultado = resultado_input.Text;

         descriptor_puestos.Add_DPR(result_indicador, result_ponderacion, result_resultado, dprp);

         indicador_input.Text = string.Empty;
         ponderacion_input.Text = string.Empty;
         resultado_input.Text = string.Empty;
     }*/

    private void LLenarGridResultados(int dpr, string result_tipo)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        //string rt = E;

        int id_per = Convert.ToInt32(Session["per_id"]);
        descriptor_puestos = new cls_mp_descriptor_puestos();
        int dprp = descriptor_puestos.Verificar_ca_id(id_per);
        GridView1.DataSource = descriptor_puestos.ListarTareaEspecifica(dprp, "E");
        GridView1.DataBind();

        //SetScript(sc, "");
        //============================================
        /* poai.ListarResultados(pu_id, "E");
         GridView1.DataSource = poai.ListarResultados(pu_id, "E");
         GridView1.DataBind();
         SetScript(sc, "");*/

    }

    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }


    /*
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        if (e.CommandName.Equals("GetEdit"))
        {
            descriptor_puestos = new cls_mp_descriptor_puestos();

            GridViewRow row = GridView1.Rows[index];
            int r_id = Convert.ToInt32(GridView1.DataKeys[index].Value);

            DataSet ds = descriptor_puestos.DevolverDatosResultadosEspecificos(r_id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                resultado_input.Text = ds.Tables[0].Rows[0]["result_resultado"].ToString();
                indicador_input.Text = ds.Tables[0].Rows[0]["result_indicador"].ToString();
                ponderacion_input.Text = ds.Tables[0].Rows[0]["result_ponderacion"].ToString();
            }



        }
        else if (e.CommandName.Equals("GetDelete"))
        {
            
        }
        else if (e.CommandName.Equals("GetActividad"))
        {
            
        }
    }

    */

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        // Comprobar si el index está en el rango correcto.
        if (index >= 0 && index < GridView1.DataKeys.Count)
        {
            string r_id = GridView1.DataKeys[index].Value.ToString();
            h_r_id.Value = r_id;

            switch (e.CommandName)
            {
                case "GetEdit":
                    LlenarDatosResultado(Convert.ToInt32(r_id)); // Aquí se llama a LlenarDatosResultado
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalEditarResultado').modal('show');", true);
                    break;
                case "GetDelete":
                    string sc = "$('#eliminarResultado').modal('show');";
                    SetScript(sc, "");
                    break;

                case "GetArchivo":
                    if (descriptor_puestos.devuelver_Si_hayPDF(Convert.ToInt32(r_id)) == 1)
                    {
                        textoHaypdf.Visible = true;
                    }
                    else
                    {
                        textoHaypdf.Visible = false;
                    }
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "$('#myModal3').modal('show');", true);
                    break;
                default:
                    break;
            }
        }
        else
        {
            
        }
    }

    




    /*
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        int dpr_id = Convert.ToInt32(GridView1.DataKeys[index].Value);
        int h_r_id = dpr_id; // h_r_id es ahora una variable local

        switch (e.CommandName)
        {
            case "GetEdit":
                string  aux_accion = "1";
                ltl_titulo.Text = "EDITAR RESULTADO";
                LlenarDatosResultado(dpr_id);

                string sc = "$('#modalEditarResultado').modal('show');";
                SetScript(sc, "");
                break;
            case "GetDelete":
                sc = "$('#eliminarResultado').modal('show');";
                SetScript(sc, "");
                break;
            case "GetActividad":
                // aux3 es igual a h_r_id
                Response.Redirect("../ManualDePuestos/RegistrarActividad?id_resultado=" + h_r_id);
                break;
            default:
                break;
        }
    }
    */
    public void LlenarDatosResultado(int id)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        DataSet data = descriptor_puestos.ListarResltaE(id);

        if (data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0)
        {
            DataRow row = data.Tables[0].Rows[0];

            ResultadoText.Text = row["result_resultado"].ToString();
            IndicadorText.Text = row["result_indicador"].ToString();
            PonderacionText.Text = row["result_ponderacion"].ToString();                    
        }
        else
        {
            
        }
    }

    protected void btnUpdate_Click_DPR(object sender, EventArgs e)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        descriptor_puestos.result_indicador = IndicadorText.Text;
        descriptor_puestos.result_ponderacion = decimal.Parse(PonderacionText.Text);
        descriptor_puestos.result_resultado = ResultadoText.Text;
        descriptor_puestos.des_p_result_id = int.Parse(h_r_id.Value); // Aquí estableces el ID

        bool result = descriptor_puestos.Update_DPEE(
            descriptor_puestos.des_p_result_id,
            descriptor_puestos.result_indicador,
            descriptor_puestos.result_ponderacion,
            descriptor_puestos.result_resultado);

        if (result == true)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "$('#modalEditarResultado').modal('hide');", true);
            LlenarDatosResultado(descriptor_puestos.des_p_result_id);
            ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshPage", "window.location.reload();", true);
        }
        else
        {

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal", "$('#myModal1').modal('show');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshPage", "window.location.reload();", true);
            /*  ScriptManager.RegisterStartupScript(this, this.GetType(), "refreshPage", "window.location.reload();", true);
              ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La actualización falló. La suma total de ponderaciones excede 30.');", true);*/

        }
    }

    protected void btnDelete_Click_DPR(object sender, EventArgs e)
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
    }


    protected void SubmitButton_Click(object sender, EventArgs e)
    {
        cls_mp_descriptor_puestos descriptor_puestos = new cls_mp_descriptor_puestos();
        descriptor_puestos.des_p_result_id = int.Parse(h_r_id.Value);

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
                        descriptor_puestos.descrip_pdf = bytes;
                    }
                }


                int result = descriptor_puestos.UpdateTER_PDF(
                    descriptor_puestos.des_p_result_id,
                    descriptor_puestos.descrip_pdf);
                if (result == 1)
                {
                    if (descriptor_puestos.devuelver_Si_hayPDF(Convert.ToInt32(h_r_id.Value)) == 1)
                    {
                        textoHaypdf.Visible = true;
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

    protected void Btn_ir_TareasRecurrentes_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistrarTareasRecurrentes");
    }








    /*
    protected void LlenarDatosResultado(int dpr_id = 0  )
    {
        //int id_per = Convert.ToInt32(Session["per_id"]);
        descriptor_puestos = new cls_mp_descriptor_puestos();
        //int dprid = descriptor_puestos.Verificar_ca_id(id_per);
        var resultadoEspecifico = descriptor_puestos.DevolverDatosResultadosEspecificos(dpr_id);
        var resultadoV = resultadoEspecifico.Tables[0].Rows[0];

        ResultadoText.Text = validarCampo(resultadoV["result_resultado"]);
        IndicadorText.Text = validarCampo(resultadoV["result_indicador"]);
        PonderacionText.Text = validarCampo(resultadoV["result_ponderacion"]);
        //h_numE.Value = validarCampo(resultadoV["result_ponderacion"]);

    }
    */

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


    protected void Btn_RedireccionarATareasRecurrentes_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistrarTareasEspecificas");
    }


}