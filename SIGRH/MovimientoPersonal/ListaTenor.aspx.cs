using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class MovimientoPersonal_ListaTenor : System.Web.UI.Page
{
    private cls_mp_cargo tenor = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null)
        {
            if (HttpContext.Current.Session["per_id"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {
                    listarTenor();
                }
            }
            else
            {
                Response.Redirect("../index");
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }

    private void listarTenor()
    {
        try
        {
            tenor = new cls_mp_cargo();
            gv_tenor.DataSource = tenor.ObtenerGrillaTenor();
            gv_tenor.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_tenor_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_tenor.Rows.Count > 0)
        {
            if (gv_tenor.HeaderRow != null)
            {
                gv_tenor.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_tenor.FooterRow != null)
            {
                gv_tenor.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_tenor_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string p_te_cod_tenor = gv_tenor.DataKeys[index].Values[0].ToString();
        hf_te_cod_tenor.Value = gv_tenor.DataKeys[index].Values[0].ToString();

        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarTenor').modal('show');";
                SetScript(sc);
                break;
            case "GetEdit":
                Response.Redirect("Tenor?id=" + p_te_cod_tenor);
                break;
            default:
                break;
        }
    }

    protected void btn_nuevo_tenor_Click(object sender, EventArgs e)
    {
        Response.Redirect("Tenor");
    }

    protected void btnEliminarTenor_Click(object sender, EventArgs e)
    {
        tenor = new cls_mp_cargo();

        tenor.te_cod_tenor = Convert.ToInt32(hf_te_cod_tenor.Value);
        tenor.EliminarTenor();

        listarTenor();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Tenor eliminado correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarTenor').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);

    }
    private void SetScript(string data)
    {
        Guid g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");

        // Script que se recibe como parámetro
        sb.Append(data);

        // Validación para números
        sb.Append(@"
        $('.numero').off('input').on('input', function (event) {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    ");

        // Validación para fechas
        sb.Append(@"
        $('.fecha').off('input').on('input', function (event) {
            this.value = this.value.replace(/[^0-9]/g, '');
        });
    ");

        // Inicializar DataTable solamente si todavía no está inicializado
        sb.Append(@"
        if ($.fn.DataTable && !$.fn.DataTable.isDataTable('#" + gv_tenor.ClientID + @"')) {

            $('#" + gv_tenor.ClientID + @"').DataTable({
                'language': {
                    'sProcessing': 'Procesando...',
                    'sLengthMenu': 'Mostrar _MENU_ registros',
                    'sZeroRecords': 'No se encontraron resultados',
                    'sEmptyTable': 'Ningún dato disponible en esta tabla',
                    'sInfo': 'Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros',
                    'sInfoEmpty': 'Mostrando registros del 0 al 0 de un total de 0 registros',
                    'sInfoFiltered': '(filtrado de un total de _MAX_ registros)',
                    'sInfoPostFix': '',
                    'sSearch': 'Buscar:',
                    'sUrl': '',
                    'sInfoThousands': ',',
                    'sLoadingRecords': 'Cargando...',
                    'oPaginate': {
                        'sFirst': '«',
                        'sLast': '»',
                        'sNext': '<i class=""fas fa-angle-right""></i>',
                        'sPrevious': '<i class=""fas fa-angle-left""></i>'
                    },
                    'oAria': {
                        'sSortAscending': ': Activar para ordenar la columna de manera ascendente',
                        'sSortDescending': ': Activar para ordenar la columna de manera descendente'
                    }
                },
                'ordering': false,
                'searching': true,
                'autoWidth': false,
                'orderCellsTop': true,
                'fixedHeader': true
            });
        }
    ");

        // Inicializar Tooltip solamente una vez
        sb.Append(@"
        $('[data-toggle=""tooltip""]').each(function () {

            if (!$(this).data('bs.tooltip')) {
                $(this).tooltip({
                    trigger: 'hover'
                });
            }

        });
    ");

        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(
            this,
            this.GetType(),
            uuid,
            sb.ToString(),
            false
        );
    }
}