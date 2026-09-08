using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Kardex.BussinessLogicLayer; //para cheques

public partial class Cheques_BusquedaCheques : System.Web.UI.Page
{
    private string sc = "";
    private string id_pago;
    protected void Page_Load(object sender, EventArgs e)
    {
        string x = Session["per_id"].ToString();
        
        if (x != null && x != "")
        {
            if (!Page.IsPostBack)
            {
                Response.Redirect("BuscarProceso.aspx?id=" + Convert.ToInt32(x));
            }
        }
        CargarGestion();
    }
    private void CargarGestion() {
        cls_kd_finiquito2 cheques = new cls_kd_finiquito2();
        ddlGestion.DataSource = cheques.gestion();
        ddlGestion.DataTextField = "gestion";
        ddlGestion.DataValueField = "gestion_id";
        ddlGestion.DataBind();
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

        //string valor = "";
        int index = 0;
        int col = 0;
        col = gv_items.Rows[0].Cells.Count;
        if (e.CommandName == "ObtenerPagoId" )
        {
            index = Convert.ToInt32(e.CommandArgument);
            //valor = gv_items.DataKeys[index].Value.ToString();
            id_pago = gv_items.Rows[index].Cells[col - 1].Text;
            Response.Redirect("ChequeDetallado.aspx?pago_id1=" + id_pago);
        }
        
        //string script = "alert( " + valor + ");";
        //ScriptManager.RegisterStartupScript(this, typeof(Page), "alerta", script, true);
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
        sb.Append("$('.radios label').addClass('custom-control-label mb-3');");
        sb.Append("$('.radios input[type=" + '"' + "radio" + '"' + "]').addClass('custom-control-input mb-3');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtPreventivo.Text) && string.IsNullOrEmpty(txtNomProceso.Text) && string.IsNullOrEmpty(txtBeneficiario.Text) && string.IsNullOrEmpty(txtNitCi.Text) && string.IsNullOrEmpty(txtNumeroCheque.Text) ) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });";
        else
        {
            cls_kd_finiquito2 cheques = new cls_kd_finiquito2();
            gv_items.DataSource = cheques.BuscarCheque(txtPreventivo.Text,txtNomProceso.Text, Convert.ToInt32(ddlGestion.SelectedValue), txtBeneficiario.Text, txtNitCi.Text, txtNumeroCheque.Text);
            gv_items.DataBind();
            //    BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_per_ap_casada_b.Text.Trim());
                Limpiar("sch_cl");

            if (gv_items.Rows.Count > 0)
            {
                sc = "$('#blockResultados').css('display', 'block');";
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#blockResultados').css('display', 'none');";
                    }
            }
        SetScript(sc);
    }
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom, string varCas)
    {
        try
        {
            //_persona = new cls_persona();
            //DataSet ds = _persona.ObtenerTablaGrilla__persona_gamlp(varId, "", varCed, "", varPat, varMat, varNom, varCas, "", "", "", "", "", "");
            //gv_items.DataSource = _persona.ObtenerTablaGrilla__persona_gamlp(varId, "", varCed, "", varPat, varMat, varNom, varCas, "", "", "", "", "", "");
            //gv_items.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    private void Limpiar(string val)
    {
        // Limpiar el formulario de búsqueda
        if (val.Equals("sch_cl"))
        {
            txtNomProceso.Text = string.Empty;
            txtPreventivo.Text = string.Empty;
            txtBeneficiario.Text = string.Empty;
            txtNitCi.Text = string.Empty;
            txtNumeroCheque.Text = string.Empty;
        }
        // Limpiar el gridview de la búsqueda
        else if (val.Equals("gv_cl"))
        {
            gv_items.DataSource = null;
            gv_items.DataBind();
        }
    }
}