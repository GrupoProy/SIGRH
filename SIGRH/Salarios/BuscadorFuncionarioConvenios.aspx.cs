using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class Salarios_BuscadorFuncionarioConvenios : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_persona _persona = null;
    private string sc = "";
protected void Page_Load(object sender, EventArgs e)
{
    Txt_per_id_b.Focus();
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

    switch (e.CommandName)
    {
        case "GetAssign":
            string per_id = gv_items.DataKeys[index].Values[0].ToString();
            string as_id = gv_items.DataKeys[index].Values[2].ToString();
            Response.Redirect("RegistroConvenios?id=" + per_id + "&id2=" + as_id);
            break;

        default:
            break;
    }
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
    sb.Append("$('.fecha').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
    sb.Append("$('#ContentPlaceHolder1_ddl_cargo').select2({ dropdownParent: $('#EditarItem') });");
    sb.Append("$('#ContentPlaceHolder1_ddl_tipo_jornada').select2({ dropdownParent: $('#EditarItem') });");
    sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa') });");
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
    sb.Append("$('#ContentPlaceHolder1_gv_items_filter').css({ display: 'none' }); var me = $('.datepicker'); me.mask('99/99/9999');");
    sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
    sb.Append(@"</script>");
    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
}

protected void BtnBuscar_Click(object sender, EventArgs e)
{
    if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_ap_casada_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });";
    else
    {
        BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_per_ap_casada_b.Text.Trim());
        Limpiar("sch_cl");

        if (gv_items.Rows.Count > 0)
        {
            sc = "$('#blockResultados').css('display', 'block');";
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro o el cargo de las persona buscada no esta considerado para aportes al Sindicato' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#blockResultados').css('display', 'none');";
        }
    }
    SetScript(sc);
}

private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom, string varCas)
{
    int pr_id = Convert.ToInt32(Session["pr_id"].ToString());
    try
    {
        _persona = new cls_persona();
        //gv_items.DataSource = _persona.ObtenerTablaGrilla__persona_plantaTecLab(varId, "", varCed, "", varPat, varMat, varNom, varCas, "", "", "", "", "", "", pr_id);
            gv_items.DataSource= _persona.ObtenerTablaGrilla__gamlp_vigente(varId, "", varCed, "", varPat, varMat, varNom, "", "", "", "", "", "", "", pr_id);
            gv_items.DataBind();
    }
    catch (Exception ex) { Console.Error.Write(ex.Message); }
}

private void Limpiar(string val)
{
    // Limpiar el formulario de búsqueda
    if (val.Equals("sch_cl"))
    {
        Txt_per_num_doc_b.Text = string.Empty;
        Txt_per_ap_paterno_b.Text = string.Empty;
        Txt_per_ap_materno_b.Text = string.Empty;
        Txt_per_nombres_b.Text = string.Empty;
        Txt_per_ap_casada_b.Text = string.Empty;
        Txt_per_id_b.Text = string.Empty;
    }
    // Limpiar el gridview de la búsqueda
    else if (val.Equals("gv_cl"))
    {
        gv_items.DataSource = null;
        gv_items.DataBind();
    }
}
}