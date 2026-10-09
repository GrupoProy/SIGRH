using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Solution_Framework_General.BussinessLogicLayer;
using System.Text;
using System.Diagnostics;

public partial class ControlPersonal_ProcesarAsistencia : System.Web.UI.Page
{
    cls_periodo periodo = null;
    cls_cp_marcaciones marca = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarGestion();
            cargarMes();
            cargarFuncionarios();
        }
    }

    private void Procesar()
    {
        try
        {
            cls_cp_marcaciones marca = new cls_cp_marcaciones();
            DateTime fecha1;
            DateTime fecha2;
            string fec1;
            string fec2;
            fecha1 = Convert.ToDateTime(txt_fecha_inicio.Text);
            fecha2 = Convert.ToDateTime(txt_fecha_fin.Text);
            //marca.ProcesarAsistencia();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    protected void btnListarFunc_Click(object sender, EventArgs e)
    {
        string tipo = "";
        if (ddl_tipo.Text == "ADMINISTRATIVO")
        {
            tipo = "ADM";
        }
        else if (ddl_tipo.Text == "CONSULTOR")
        {
            tipo = "CON";
        }

        if (rdLista.Checked)
        {
            marca = new cls_cp_marcaciones();
            GvFuncionarios.DataSource = marca.ListarFuncAsis(txtLista.Value.ToString());
            GvFuncionarios.DataBind();
            if (GvFuncionarios.Rows.Count > 0)
            {
                funcio_result.Visible = true;
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise si esta seleccionando todos los parametros' }, { type: 'warning' });";
            }
            SetScript(sc, "");
        }
        else if (rdFechas.Checked)
        {
            marca = new cls_cp_marcaciones();
            GvFuncionarios.DataSource = marca.ListarPorFecha(tipo, ddl_mes.SelectedValue.ToString());
            GvFuncionarios.DataBind();
            if (GvFuncionarios.Rows.Count > 0)
            {
                funcio_result.Visible = true;
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise si esta seleccionando todos los parametros' }, { type: 'warning' });";
            }
            SetScript(sc, "");
        }
    }

    private void cargarGestion()
    {
        periodo = new cls_periodo();
        ddl_gestion.DataSource = periodo.ObtenerTablaGrilla("", "", "", "");
        ddl_gestion.DataTextField = "pr_gestion";
        ddl_gestion.DataValueField = "pr_id";
        ddl_gestion.DataBind();
    }

    private void cargarMes()
    {
        marca = new cls_cp_marcaciones();
        ddl_mes.DataSource = marca.MesAsistencia();
        ddl_mes.DataTextField = "MES";
        ddl_mes.DataValueField = "FM";
        ddl_mes.DataBind();
    }

    private void cargarFuncionarios()
    {
        ddl_tipo.Items.Add("ADMINISTRATIVO");
        ddl_tipo.Items.Add("CONSULTOR");
        ddl_tipo.DataBind();
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
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
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

    protected void GvFuncionarios_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (GvFuncionarios.Rows.Count > 0)
        {
            if (GvFuncionarios.HeaderRow != null)
            {
                GvFuncionarios.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GvFuncionarios.FooterRow != null)
            {
                GvFuncionarios.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    //En Proceso, todavia no fonuncia bien
    protected void btnProcesar_Click(object sender, EventArgs e)
    {
        marca = new cls_cp_marcaciones();
        string Lista_Per_Id = "";
        if (txt_fecha_fin.Text != "" && txt_fecha_inicio.Text != "")
        {
            foreach (GridViewRow row in GvFuncionarios.Rows)
            {
                Lista_Per_Id += row.Cells[0].Text + ",";
            }
        }
        Lista_Per_Id = Lista_Per_Id.TrimEnd(',');
        marca.Procesar(Lista_Per_Id, txt_fecha_inicio.Text, txt_fecha_fin.Text);

        sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Asistencia en Proceso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";

        SetScript(sc, "");
    }
}