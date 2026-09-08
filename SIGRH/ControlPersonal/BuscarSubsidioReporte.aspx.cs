using Microsoft.Reporting.WebForms;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_ReporteSubsidio : System.Web.UI.Page
{
    cls_bs_asignacion_beneficio beneficio = new cls_bs_asignacion_beneficio();
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (beneficio.DatosFuncionario(Convert.ToInt32(Txt_per_id_b.Text), Txt_per_nombres_b.Text, Txt_per_ap_paterno_b.Text, Txt_per_ap_materno_b.Text, Txt_per_ap_casada_b.Text, Txt_per_num_doc_b.Text).Tables.Count > 0)
        {
            sc = "$('#blockResultados').css('display', 'block');";
            gv_items.DataSource = beneficio.DatosFuncionario(Convert.ToInt32(Txt_per_id_b.Text), Txt_per_nombres_b.Text, Txt_per_ap_paterno_b.Text, Txt_per_ap_materno_b.Text, Txt_per_ap_casada_b.Text, Txt_per_num_doc_b.Text);
            gv_items.DataBind();
        }
        SetScript(sc);
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
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_pf_tipo_parentesco').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_genero').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_estado_vivo').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_parentesco_add').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_genero_add').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
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
                    "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });}");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gv_items_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_items.Rows.Count > 0)
        {
            if (gv_items.HeaderRow != null)
            {
                gv_items.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_items.FooterRow != null)
            {
                gv_items.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string ab_id1 = gv_items.DataKeys[index].Values[1].ToString();
        string per_id1 = gv_items.DataKeys[index].Values[0].ToString();
        if (e.CommandName == "print")
        {
            Response.Redirect("ReporteSubsidio.aspx?per_id="+per_id1+"&ab_id="+ab_id1);
        }
    }
}