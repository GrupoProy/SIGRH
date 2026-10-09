using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System.Text;
public partial class Salarios_Retroactivo : System.Web.UI.Page
{
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                CargarPlanillas();
                CargarPlanillasMigradas();
            }
        }
        else Response.Redirect("../Index");
    }
    private void CargarPlanillas() {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        gvPlanillas.DataSource = proceso.VerificarPlanillasRetroactivo();
        gvPlanillas.DataBind();
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
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9\\.]+/g, '');" +
            "});");

        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gvPlanillas_PreRender(object sender, EventArgs e)
    {
        //base.OnPreRender(e);
        //if (gvPlanillas.Rows.Count > 0)
        //{
        //    if (gvPlanillas.HeaderRow != null)
        //    {
        //        gvPlanillas.HeaderRow.TableSection = TableRowSection.TableHeader;
        //    }
        //    if (gvPlanillas.FooterRow != null)
        //    {
        //        gvPlanillas.FooterRow.TableSection = TableRowSection.TableFooter;
        //    }
        //}
    }
    protected void gvMigradas_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvMigradas.Rows.Count > 0)
        {
            if (gvMigradas.HeaderRow != null)
            {
                gvMigradas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvMigradas.FooterRow != null)
            {
                gvMigradas.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    private void CargarPlanillasMigradas() {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        gvMigradas.DataSource = proceso.PlanillasMigradas_Retroactivo();
        gvMigradas.DataBind();
        if (gvMigradas.Rows.Count > 0)
        {
            btnFinalizar.Visible = true;
            divMigradas.Visible = true;
            divFinalizar.Visible = true;
                    }
    }
    protected void gvPlanillas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string pc_id = gvPlanillas.DataKeys[index].Values[0].ToString();
        string nro = gvPlanillas.DataKeys[index].Values[1].ToString();
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        switch (e.CommandName)
        {
            case "Migrar":
                if (proceso.MigrarPlanilla_Retroactivo(pc_id, nro, HttpContext.Current.Session["per_id"].ToString()) == true)
                {
                    CargarPlanillas();
                    CargarPlanillasMigradas();
                }

                break;
            default:
                break;
        }
        SetScript("");

    }


    protected void btnCalcular_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        if(proceso.InsertarIncremento_Retroactivo(Convert.ToDouble(txtIncremento.Text))==true)
            divProceso.Visible = true;
    }

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        if (proceso.FinalizarMigracion_Retroactivo() == true)
        //if (true == true)

        {
            sc = "Swal.fire({ icon: 'success', title: 'Se migraron las planillas para el retroactivo', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            divIncremento.Visible = true;
            divMigradas.Visible = false;
            divPlanillas.Visible = false;
            divFinalizar.Visible = false;
        }
        else
            sc = "$.notify({ icon: 'fa fa-info', message:'No se pudo realizar la operación, por favor consulte con el Administrador'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
        SetScript(sc);
    }

    protected void gvMigradas_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnProceso1_Click(object sender, EventArgs e)
    {
        btnProceso2.Visible = true;
        btnProceso1.Enabled = false;
        cls_pla_retroactivo retroactivo = new cls_pla_retroactivo();
        retroactivo.ProcesoRetroactivo1(2023,0);
        sc = "Swal.fire({ icon: 'success', title: 'Se proceso correctamente', text: 'Proceso exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
        SetScript(sc);
    }

    protected void btnProceso2_Click(object sender, EventArgs e)
    {
        btnProceso3.Visible = true;
        btnProceso2.Enabled = false;
    }

    protected void btnProceso3_Click(object sender, EventArgs e)
    {
        btnProceso4.Visible = true;
        btnProceso3.Enabled = false;
    }

    protected void btnProceso4_Click(object sender, EventArgs e)
    {

    }
}