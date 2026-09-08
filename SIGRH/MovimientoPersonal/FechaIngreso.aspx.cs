using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;

public partial class MovimientoPersonal_FechaIngreso : System.Web.UI.Page
{
    private string sc = "";
    private cls_persona _persona = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                //CargarGrillaFechas();
            }
        }
        else Response.Redirect("../Index");
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
    protected void gvFechas_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvFechas.Rows.Count > 0)
        {
            if (gvFechas.HeaderRow != null)
            {
                gvFechas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvFechas.FooterRow != null)
            {
                gvFechas.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
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
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#blockResultados').css('display', 'none');";
            }
        }
        SetScript(sc);
    }
    protected void gv_items_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox txt = e.Row.FindControl("txtFechaIngreso") as  TextBox;
            if (txt != null)
                if (txt.Text != "")
                {
                    txt.Text = Convert.ToDateTime(txt.Text).ToShortDateString();
                    txt.Enabled = false;
                    LinkButton lnkb = e.Row.FindControl("lnbInsertar") as LinkButton;
                    lnkb.Visible = false;
                }

        }
    }
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom, string varCas)
    {
        try
        {
            _persona = new cls_persona();
            gv_items.DataSource = _persona.ObtenerTablaGrilla__persona_FechaIngreso(varId, "", varCed, "", varPat, varMat, varNom, varCas, "", "", "", "", "", "");
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

        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_situacion_persona').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");


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
    protected void gv_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string per_id = gv_items.DataKeys[index].Values[0].ToString();
        string estado = gv_items.DataKeys[index].Values[1].ToString();

        TextBox txt =  gv_items.Rows[index].FindControl("txtFechaIngreso") as TextBox;

        cls_mp_asignacion asignacion = new cls_mp_asignacion();
        switch (e.CommandName)
  
        {
            case "Insertar":
                if (txt.Text !="")
                { if (asignacion.InsertarFechaIngreso(Convert.ToInt32(per_id), txt.Text, estado) == true)
                        sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Se asignó correctamente la fecha de ingreso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
                }
                else
                sc = "$.notify({ icon: 'fa fa-check', message: 'Debe ingresar una fecha...'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";

                break;
            default:
                break;
        }
                SetScript(sc);

    }

}