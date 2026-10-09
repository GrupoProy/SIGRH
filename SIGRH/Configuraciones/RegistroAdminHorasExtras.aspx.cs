using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Salarios.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;


public partial class Configuraciones_RegistroAdminHorasExtras : System.Web.UI.Page
{
    private cls_pla_factor factor = null;
    private cls_catalogo catalogo = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listarGrillaHorasExtras();
            listarFiltradoTipoHorasExtras();
            listaFiltradoTipoEscalafon();
        }
    }

    private void listarGrillaHorasExtras()
    {
        try
        {
            factor = new cls_pla_factor();
            factor.gestion_selec = Session["pr_id"].ToString();
            gv_horas_extras.DataSource = factor.ObtenerGrillaAsignacionHE();
            gv_horas_extras.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listarFiltradoTipoHorasExtras()
    {
        catalogo = new cls_catalogo { cat_tabla = "horas_extras" };
        ddl_tipo_horas_extras.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_horas_extras.DataSource = catalogo.ObtenerTablaCombo();
        ddl_tipo_horas_extras.DataValueField = "cat_secuencial";
        ddl_tipo_horas_extras.DataTextField = "cat_descripcion";
        ddl_tipo_horas_extras.DataBind();
    }

    private void listaFiltradoTipoEscalafon()
    {
        try
        {
            factor = new cls_pla_factor();

            ddl_tipo_escalafon.Items.Clear();
            ddl_tipo_escalafon.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_escalafon.DataValueField = "es_id";
            ddl_tipo_escalafon.DataTextField = "es_descripcion";
            ddl_tipo_escalafon.DataSource = factor.ObtenerTipoEscalafon();
            ddl_tipo_escalafon.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
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
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_escalafon').select2({ dropdownParent: $('#modalNuevoHorasExtras'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_horas_extras').select2({ dropdownParent: $('#modalNuevoHorasExtras'), placeholder: { id: '0', text: 'Seleccione...' } });");
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

    protected void gv_horas_extras_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_horas_extras.Rows.Count > 0)
        {
            if (gv_horas_extras.HeaderRow != null)
            {
                gv_horas_extras.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_horas_extras.FooterRow != null)
            {
                gv_horas_extras.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_horas_extras_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        aux_lhx_id.Value = gv_horas_extras.DataKeys[index].Values[0].ToString();
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarHorasExtras').modal('show');";
                SetScript(sc);
                break;

            default:
                break;
        }
    }

    protected void btn_nuevo_horasExtras_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevoHorasExtras').modal('show');";
        SetScript(sc);
    }

    private void guardarLimiteHorasExtras()
    {
        factor = new cls_pla_factor
        {
            es_id = Convert.ToInt32(ddl_tipo_escalafon.SelectedValue),
            lhx_cat_id = Convert.ToInt32(ddl_tipo_horas_extras.SelectedValue)
        };
        factor.AdicionarLimiteHorasExtras();
    }

    protected void btn_guardar_horasExtras_Click(object sender, EventArgs e)
    {
        factor = new cls_pla_factor();
        factor.es_id = Convert.ToInt32(ddl_tipo_escalafon.SelectedValue);
        var grillaHoras = factor.ObtenerGrillaLimiteHE();
        int num = grillaHoras.Tables[0].Rows.Count;
        if(num > 0)
        {
            Limpiar();
            sc = "$.notify({ icon: 'fa fa-info', message: 'Registro insertado anteriormente'},{ type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#modalNuevoHorasExtras').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc);
        }
        else
        {
            guardarLimiteHorasExtras();
            Limpiar();
            listarGrillaHorasExtras();
            sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevoHorasExtras').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            SetScript(sc);
        }
    }

    protected void btn_cancelar_horasExtras_Click(object sender, EventArgs e)
    {
        Limpiar();
        sc = " $('#modalNuevoHorasExtras').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_eliminar_horasExtras_Click(object sender, EventArgs e)
    {
        factor = new cls_pla_factor();
        factor.lhx_id = Convert.ToInt32(aux_lhx_id.Value);
        factor.EliminarAsigHorasExtras();
        Limpiar();
        listarGrillaHorasExtras();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarHorasExtras').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void Limpiar()
    {
        ddl_tipo_escalafon.SelectedValue = "0";
        ddl_tipo_horas_extras.SelectedValue = "0";
    }
}