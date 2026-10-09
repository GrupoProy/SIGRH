using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;

public partial class Docentes_Planes : System.Web.UI.Page
{
    private cls_materia materia = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                CargarAreas();
                //materia = new cls_materia();
                //ddl_plan_area.Items.Clear();
                //ddl_plan_area.DataSource = materia.ObtenerArea();
                //ddl_plan_area.DataTextField = "plan_area";
                //ddl_plan_area.DataBind();
                SetScript("","");
            }
        }
        else Response.Redirect("../Index");
    }

    private void CargarAreas()
    {
        materia = new cls_materia();
        ddl_area.Items.Clear();
        ddl_area.Items.Add("Seleccione un area...");
        ddl_area.DataSource = materia.ObtenerArea();
        ddl_area.DataTextField = "plan_area";
        ddl_area.DataBind();
    }

    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
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
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: 'es'" +
                    "});" +
                "});" +
                "var me = $(\".datepickerD\");" +
                "me.mask('99/99/9999');" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        plan_result.Visible = false;
        plan_adicionar.Visible = true;
    }
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        plan_adicionar.Visible = false;
        materia = new cls_materia();
        GvLista.DataSource = materia.ObtenerPlan();
        GvLista.DataBind();
        plan_result.Visible = true;
    }
    protected void BtnCrear_Click(object sender, EventArgs e)
    {
        
        if (string.IsNullOrEmpty(txtRegCarrera.Text) || string.IsNullOrEmpty(Txt_plan_año.Text) || ddl_area.SelectedItem.Text == "Seleccione un area...")
        {
            
        }
        else
        {
            materia = new cls_materia();
            materia.carrera = txtRegCarrera.Text;
            materia.gestion = Convert.ToInt32(Txt_plan_año.Text);
            materia.area = ddl_area.SelectedItem.Text;
            materia.AdicionarPlan();
            sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' });";
            SetScript(sc, "");
            Limpiar();
        }
    }
    private void Limpiar()
    {
        Txt_plan_año.Text = string.Empty;
    }
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        materia = new cls_materia();
        string id_plan;
        int index;
        if (e.CommandName == "GetId")
        {
            index = Convert.ToInt32(e.CommandArgument);
            id_plan = GvLista.DataKeys[index].Value.ToString();
            materia.id = Convert.ToInt32(id_plan);
            materia.CambiarEstadoPlan();
            sc = "$.notify({ icon: 'fas fa-check', message: 'Cambio de estado efectuado correctamente...' }, { type: 'success' });";
            SetScript(sc, "");

        }
    }

    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null)
            {
                GvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GvLista.FooterRow != null)
            {
                GvLista.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void ddl_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScript("", "");
    }
}