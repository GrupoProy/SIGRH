using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class Salarios_CambioFuente : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null)
        {
            if (HttpContext.Current.Session["us_id"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {
                    CargarTotales();
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
    protected void gvItems_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvItems.Rows.Count > 0)
        {
            if (gvItems.HeaderRow != null)
            {
                gvItems.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvItems.FooterRow != null)
            {
                gvItems.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void gvUnidades_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvUnidades.Rows.Count > 0)
        {
            if (gvUnidades.HeaderRow != null)
            {
                gvUnidades.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvUnidades.FooterRow != null)
            {
                gvUnidades.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void gvTotales_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvTotales.Rows.Count > 0)
        {
            if (gvTotales.HeaderRow != null)
            {
                gvTotales.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvTotales.FooterRow != null)
            {
                gvTotales.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        cls_mp_cargo cargo = new cls_mp_cargo();
        int index = Convert.ToInt32(e.CommandArgument);
        string ca_id = gvItems.DataKeys[index].Values[0].ToString();
        //string p_as_id = gvItems.DataKeys[index].Values[1].ToString();
        int gestion = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        gvUnidades.DataSource = cargo.ObtenerUnidades_MoverFuente(ca_id);
        gvUnidades.DataBind();
        grillaUnidades.Visible = true;
        SetScript("");
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


    protected void gvUnidades_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        int eo_id = Convert.ToInt32(gvUnidades.DataKeys[index].Values[0].ToString());
        string ca_id_actual = gvUnidades.DataKeys[index].Values[1].ToString();
        cls_mp_cargo cargo = new cls_mp_cargo();
        if (cargo.Modificar_FuenteFinanciamiento(eo_id.ToString(), ObtenerCodigoProceso(), ca_id_actual) != 0)
            sc = "Swal.fire({ icon: 'success', title: 'Se modificó la fuente de financiamiento satisfactoriamente', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
        else
            sc = "$.notify({ icon: 'fa fa-info', message:'No se pudo realizar la operación, por favor consulte con el Administrador'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
        SetScript(sc);
        txt_item.Text = "";
        PanelTotales.Visible = true;
        CargarTotales();
        txt_item.Text = "";
        grillaItems.Visible = false;
        grillaUnidades.Visible = false;
    }
    private string ObtenerCodigoProceso()
    {
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        int gestion = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        pla_proceso.pc_pr_id = gestion;
        var detalleFuncionario = pla_proceso.ObtenerSalarioMinimo();
        return detalleFuncionario.Tables[0].Rows[0]["pc_id"].ToString();
    }

    protected void btnFiltrar_Click1(object sender, EventArgs e)
    {
        if (txt_item.Text != "")
        {
            cls_mp_cargo cargo = new cls_mp_cargo();
            int gestion = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
            int ca_id = Convert.ToInt32(cargo.Obtener_CaId(txt_item.Text, gestion.ToString()));

//            gvItems.DataSource = cargo.ObtenerItem_MoverFuente(ca_id.ToString());
            gvItems.DataSource = cargo.ObtenerItem_MoverFuente_Grilla(txt_item.Text, gestion.ToString());

            gvItems.DataBind();
            grillaItems.Visible = true;
            grillaUnidades.Visible = false;
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message:'Por favor seleccione un Item'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
        }
        SetScript(sc);
    }
    protected void CargarTotales()
    {
        cls_mp_cargo cargo = new cls_mp_cargo();
        gvTotales.DataSource = cargo.TotalesFuenteFinanciamiento(ObtenerCodigoProceso());
        //gvTotales.DataSource = cargo.TotalesFuenteFinanciamiento("249");

        gvTotales.DataBind();
    }
    protected void btnAjustar_Click(object sender, EventArgs e)
    {
        sc = "$('#ConfirmacionProceso').modal('show');";
        SetScript(sc);
    }
    protected void btnCancelarVerificacionCI_Click(object sender, EventArgs e)
    {
        sc = "$('#ConfirmacionProceso').modal('hide'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    protected void btnVerificarCi_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        if (proceso.FinalizarProcesoPlanilla(ObtenerCodigoProceso(), "0") == true)
        {
            sc = "Swal.fire({ icon: 'success', title: 'Se modificó la fuente de financiamiento satisfactoriamente', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            SetScript(sc);
            Response.Redirect("../Administración/PlanillaHaberes.aspx");
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message:'No se pudo finalizar la planilla, consulte con el Administrador'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }


    }
}