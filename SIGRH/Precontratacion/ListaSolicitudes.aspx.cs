using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Precontratacion_ListaSolicitudes : System.Web.UI.Page
{
    private cls_persona _persona = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                sc = "CopiarCortarPegar(true);";
                SetScript(sc, "");
            }
        }
        else
        {
            Response.Redirect("../Index");
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtApPaterno_b.Text) &&
                string.IsNullOrEmpty(txtApMaterno_b.Text) &&
                string.IsNullOrEmpty(txtNombres_b.Text) &&
                string.IsNullOrEmpty(txtCI_b.Text) &&
                string.IsNullOrEmpty(txtCodigo_b.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            _persona = new cls_persona();
            DataSet ds = _persona.ObtenerTablaGrilla__persona_gamlp(
                txtCodigo_b.Text.Trim(),      
                "",                          
                txtCI_b.Text.Trim(),          
                "",                          
                txtApPaterno_b.Text.Trim(),   
                txtApMaterno_b.Text.Trim(),   
                txtNombres_b.Text.Trim(),     
                "", "", "", "", "", "", ""    
            );

            gvResultados.DataSource = ds;
            gvResultados.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                sc = "$('#dResult').css('display', 'block');";
                sc += "$.notify({ icon: 'fas fa-check', message: 'Funcionarios encontrados.' }, { type: 'success' });";
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se han encontrado funcionarios con esos datos' }, { type: 'warning' }); $('#dResult').css('display', 'none');";
            }
            SetScript(sc, "");
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al buscar: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }
    protected void btnVerificarCI_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtCIVerificacion.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar un número de Carnet de Identidad' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCIVerificacion.Text, @"^\d+$"))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El Carnet de Identidad solo debe contener números' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            string ci = txtCIVerificacion.Text.Trim();

            _persona = new cls_persona();
            DataSet ds = _persona.VerificarNuevoFuncionario(ci, 0);

            if (ds.Tables[0].Rows.Count == 0)
            {
                sc = "$.notify({ icon: 'fas fa-check', message: 'CI no registrado. Puede continuar con la solicitud.' }, { type: 'success' });";
                SetScript(sc, "");

                string script = "setTimeout(function(){ window.location='SolicitudContratacion.aspx?ci=" + ci + "&modo=nuevo'; }, 1500);";
                ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", script, true);
            }
            else
            {
                DataRow row = ds.Tables[0].Rows[0];
                int perId = Convert.ToInt32(row["per_id"]);  

                bool tieneCurriculum = VerificarCurriculumCompleto(perId);

                if (tieneCurriculum)
                {
                    sc = "$.notify({ icon: 'fas fa-info', message: 'El funcionario ya tiene curriculum. Redirigiendo...' }, { type: 'info' });";
                    SetScript(sc, "");

                    string script = "setTimeout(function(){ window.location='CurriculumCandidato.aspx?per_id=" + perId + "&modo=ver'; }, 1500);";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", script, true);
                }
                else
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation-triangle', message: 'El funcionario no tiene curriculum. Debe completarlo.' }, { type: 'warning' });";
                    SetScript(sc, "");

                    string script = "setTimeout(function(){ window.location='CurriculumCandidato.aspx?per_id=" + perId + "&modo=completar'; }, 1500);";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", script, true);
                }
            }
            txtCIVerificacion.Text = "";
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al verificar: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }
    private bool VerificarCurriculumCompleto(int perId)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();

            DataSet ds = formacion.ObtenerGrilla_Formacion(perId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                return true;
            }

            return false;
        }
        catch
        {
            return false;
        }
    }

    protected void btnCancelarVerificacionCI_Click(object sender, EventArgs e)
    {
        txtCIVerificacion.Text = "";
        sc = "$('#modalVerificarCI').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
        string script = "setTimeout(function(){ window.location='ListaSolicitudes.aspx'; }, 500);";
        ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", script, true);
    }

    protected void gvResultados_PreRender(object sender, EventArgs e)
    {
        if (gvResultados.Rows.Count > 0)
        {
            if (gvResultados.HeaderRow != null)
                gvResultados.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (gvResultados.FooterRow != null)
                gvResultados.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    private void SetScript(string val, string valS = "")
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar _MENU_ registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros'," +
                    "'sInfoEmpty': 'Mostrando registros del 0 al 0 de un total de 0 registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ registros)'," +
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
                "'searching': true," +
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true" +
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
        sb.Append("$('.radios label').addClass('custom-control-label mb-3');" +
            "$('.radios input[type=\"radio\"]').addClass('custom-control-input mb-3');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }
}