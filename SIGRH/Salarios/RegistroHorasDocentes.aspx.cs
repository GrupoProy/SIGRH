using System;
using System.Collections.Generic;
using System.Data;
 using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Salarios.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class Salarios_RegistroHorasDocentes : System.Web.UI.Page
{
    private cls_pla_factor factor = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ListarUnidades();
            ListarDocentes();
        }
    }

    private void ListarUnidades() {
        cls_pla_docente_horas horas = new cls_pla_docente_horas();
        ddlUnidades.Items.Add("TODAS");
        ddlUnidades.DataSource = horas.ObtenerUnidadesOrganizacionales();
        ddlUnidades.DataTextField = "UNIDAD";
        ddlUnidades.DataValueField = "unidad_id";
        ddlUnidades.DataBind();
    }

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.decimal').on('input', function (event) { this.value = this.value.replace(/[^,0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
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
                    "'sNext': '<i class=" + '"' + "fas fa-angle-right" + '"' + "></i>'," +
                    "'sPrevious': '<i class=" + '"' + "fas fa-angle-left" + '"' + "></i>'" +
                    "}," +
                    "'oAria': {" +
                    "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                    "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                    "}," +
                    "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gv_horas_docentes_PreRender(object sender, EventArgs e)
    {
        //base.OnPreRender(e);
        //if (gv_horas_docentes.Rows.Count > 0)
        //{
        //    if (gv_horas_docentes.HeaderRow != null)
        //    {
        //        gv_horas_docentes.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //    if (gv_horas_docentes.FooterRow != null)
        //    {
        //        gv_horas_docentes.FooterRow.TableSection = TableRowSection.TableFooter;
        //    }
        //}
    }



    private void ListarDocentes()
    {
        try
        {
            cls_pla_docente_horas horasDocentes = new cls_pla_docente_horas();
            DataSet ds= horasDocentes.ListarGrillaDocentesMes();
            gv_horas_docentes.DataSource = horasDocentes.ListarGrillaDocentesMes();
            gv_horas_docentes.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }




    protected void Limpiar()
    {
    }


    protected void btnGuardarHorasDocentes_Click(object sender, EventArgs e)
    {
        string horas = "";
        cls_pla_docente_horas horasDocente = new cls_pla_docente_horas();
        int index = 0;
        foreach (GridViewRow item in gv_horas_docentes.Rows)
        {
            horasDocente.pdh_per_id=  Convert.ToInt32(gv_horas_docentes.DataKeys[index]["as_per_id"].ToString());
            horas= ((TextBox)item.FindControl("txtHoras")).Text;
            if (horas != "" && horas != "0")
            {
                horasDocente.pdh_horas = Convert.ToInt32(horas);
                horasDocente.AdicionarHorasDocentes(horasDocente);
            }
            //else
            //{
                ////sc = "$.notify({ icon: 'fas fa-check', message: 'Las horas en Cero no fueron registradas...!!' }, { type: 'success' });";
                ////SetScript(sc, "");
            //}
            index = index + 1;
        }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Se registraron solamente las horas diferentes a cero...!!' }, { type: 'success' });";
        SetScript(sc, "");
        ListarDocentes();

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


    protected void gv_horas_docentes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox txtHoras = e.Row.Cells[0].FindControl("txtHoras") as TextBox;
        Label lblHoras = e.Row.Cells[0].FindControl("lblHoras") as Label;
        if (txtHoras!= null)
            txtHoras.Text = lblHoras.Text;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            cls_mp_asignacion asignacion = new cls_mp_asignacion();
            //if(asignacion.ObtenerTodasLasAsignacionesVigentes(Convert.ToInt32(2)
        }
    }
    protected void ddlUnidades_SelectedNodeChanged(object sender, EventArgs e)
    {
        cls_pla_docente_horas horas = new cls_pla_docente_horas();
        gv_horas_docentes.DataSource = horas.ListarGrillaDocentesMesPorUnidad(Convert.ToInt32(ddlUnidades.SelectedValue));
        gv_horas_docentes.DataBind();
    }
    }