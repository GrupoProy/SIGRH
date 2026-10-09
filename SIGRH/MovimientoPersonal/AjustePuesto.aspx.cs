using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Text;
public partial class MovimientoPersonal_AjustePuesto : System.Web.UI.Page
{
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                CargarPuestos();
            }
        }
        else
        {
            Response.Redirect("../index");
        }

    }
    private void CargarPuestos() {
        cls_puestos puestos = new cls_puestos();
        gv_puestos.DataSource = puestos.ObtenerPuestosVigentes();
        gv_puestos.DataBind();
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }});");
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
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gv_puestos_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_puestos.Rows.Count > 0)
        {
            if (gv_puestos.HeaderRow != null)
            {
                gv_puestos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_puestos.FooterRow != null)
            {
                gv_puestos.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void gv_validar_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //int index = Convert.ToInt32(e.CommandArgument);
        //int as_id = Convert.ToInt32(gv_validar_items.DataKeys[index].Values[0].ToString());

    }

    protected void gv_puestos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gv_puestos.EditIndex = -1;
        CargarPuestos();
        SetScript("");
    }

    protected void gv_puestos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gv_puestos.EditIndex = e.NewEditIndex;
        CargarPuestos();
        SetScript("");
    }

    protected void gv_puestos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        TextBox puestoNuevo = gv_puestos.Rows[e.RowIndex].FindControl("txt_puesto") as TextBox;
        cls_puestos puestos = new cls_puestos();
        int index = Convert.ToInt32(e.RowIndex);
        puestos.p_id= Convert.ToInt32(gv_puestos.DataKeys[index].Values[0].ToString());
        puestos.p_descripcion = puestoNuevo.Text;
        puestos.p_estado = "V";
        puestos.Actualizar();
        gv_puestos.EditIndex = -1;
        CargarPuestos();
        SetScript("");
    }

}