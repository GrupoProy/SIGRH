using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_ListaViaticos : System.Web.UI.Page
{
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["nro_pla"] = null;
            cargarLista();
            cargarMeses();
        }
    }

    private void cargarLista()
    {
        cls_cp_viatico viatico = new cls_cp_viatico();
        lv_viaticos.DataSource = viatico.LlenarListaViatico();
        lv_viaticos.DataBind();
        no_existe_cat.Visible = (lv_viaticos.Items.Count > 0) ? false : true;
        ltl_total_reg.Text = lv_viaticos.Items.Count.ToString();
    }

    private void cargarMeses()
    {
        cls_cp_viatico viatico = new cls_cp_viatico();
        ddl_mes.Items.Clear();
        ddl_mes.Items.Add("Seleccione un mes");
        ddl_mes.DataSource = viatico.cargarMeses();
        ddl_mes.DataTextField = "cat_descripcion";
        ddl_mes.DataValueField = "cat_secuencial";
        ddl_mes.DataBind();
    }

    protected void btn_nuevo_viatico_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistroViatico");
    }

    protected void btn_buscar_cat_Click(object sender, EventArgs e)
    {
        cls_cp_viatico viatico = new cls_cp_viatico();
        lv_viaticos.DataSource = viatico.LlenarViaticosMes(Convert.ToInt32(ddl_mes.SelectedValue.ToString()));
        lv_viaticos.DataBind();
        no_existe_cat.Visible = (lv_viaticos.Items.Count > 0) ? false : true;
        ltl_total_reg.Text = lv_viaticos.Items.Count.ToString();
        //sc = "$.notify({ icon: 'fas fa-check', message: 'Hace algo' }, { type: 'success' });";
        SetScript(sc);
    }

    protected void lv_viaticos_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string nro_planilla = lv_viaticos.DataKeys[index].Value.ToString();
        
        cls_cp_viatico viatico = new cls_cp_viatico();

        switch (e.CommandName)
        {
            case "Eliminar":
                sc = "$('#eliminarViatico').modal('show');";
                Session["nro_pla"] = nro_planilla;
                SetScript(sc);
                break;
            case "Detalles":
                ver_planilla(Convert.ToInt32(nro_planilla));
                break;
            case "Imprimir":
                sc = "window.open('../ControlPersonal/ImpresionViaticos.aspx?id="+ nro_planilla +"', 'width=500,height=500', '_blank');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    private void ver_planilla(int nro_planilla)
    {
        cls_cp_viatico viatico = new cls_cp_viatico();
        gv_planilla.DataSource = viatico.CargarInfoPlanilla(nro_planilla);
        gv_planilla.DataBind();
        no_existe_acciones.Visible = (gv_planilla.Rows.Count > 0) ? false : true;
        sc = "$('#modalEstados').modal('show'); ";
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
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_gestion').select2({ dropdownParent: $('#modalPeriodo') });");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gv_planilla_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_planilla.Rows.Count > 0)
        {
            if (gv_planilla.HeaderRow != null)
            {
                gv_planilla.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_planilla.FooterRow != null)
            {
                gv_planilla.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void btn_eliminar_planilla_Click(object sender, EventArgs e)
    {
        cls_cp_viatico viatico = new cls_cp_viatico();
        int verifica = 0;
        verifica = viatico.ReprobarPlanilla(Convert.ToInt32(Session["nro_pla"].ToString()));
        if (verifica > 0)
        {
            sc = "Swal.fire({ icon: 'success', title: 'Planilla eliminada correctamente.', text: 'Registro exitoso', timer: 3200, showConfirmButton: false, allowOutsideClick: true, onAfterClose: () => { $('#eliminarViatico').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-times', message: 'No se ha podido reprobar' }, { type: 'warning' });";
        }
        SetScript(sc);
        cargarLista();
    }
}