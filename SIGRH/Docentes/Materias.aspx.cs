using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;

public partial class MovimientoPersonal_DocenteAgre : System.Web.UI.Page
{
    private string sc = "";
    private cls_materia materia = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                if (ddl_area.Items.Count < 2)
                {
                    CargarAreas();
                }
            }
        }
        else Response.Redirect("../Index");
        //[]
    }
    
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        materia = new cls_materia();
        if (string.IsNullOrEmpty(ddl_plan.SelectedItem.Text) && string.IsNullOrWhiteSpace(Txt_sigla.Text) && string.IsNullOrWhiteSpace(Txt_mat_nombre.Text) && string.IsNullOrWhiteSpace(Txt_grupo.Text) && string.IsNullOrWhiteSpace(Txt_horas.Text) && string.IsNullOrWhiteSpace(Txt_nivel.Text))
        {

        }
        else
        {
            materia.area = ddl_plan_area.SelectedItem.Text;
            materia.sigla = Txt_sigla.Text;
            materia.mat_nombre = Txt_mat_nombre.Text;
            materia.hrs_asig = Convert.ToInt32(Txt_horas.Text);
            materia.mat_nivel = Convert.ToInt32(Txt_nivel.Text);
            materia.mat_grupo = Convert.ToInt32(Txt_grupo.Text);
            materia.carrera = ddl_plan_carrera.SelectedItem.Text;
            materia.p_id = Convert.ToInt32(ddl_plan.SelectedValue.ToString());
            materia.AdicionarMateria();
            ddl_plan_area.ClearSelection();
            Limpiar("nuevo");
            Session["texto_notificacion"] = "Materia Adicionada con Exito";
        }
        SetScript("", "");
    }

    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        mat_Agregar.Visible = true;
        materia_result.Visible = false;
        if (ddl_plan_area.Items.Count < 2)
        {
            B_cargarAreas();
        }
        SetScript("", "");
    }

    protected void ddl_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarCarreras();
        SetScript("","");
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

    private void CargarCarreras()
    {
        materia = new cls_materia();
        Ddl_carrera_nombre.Items.Clear();
        Ddl_carrera_nombre.Items.Add("Seleccione una carrera...");
        materia.area = ddl_area.SelectedItem.Text;
        Ddl_carrera_nombre.DataSource = materia.ObtenerCarrera();
        Ddl_carrera_nombre.DataTextField = "plan_carrera_nombre";
        Ddl_carrera_nombre.DataBind();

    }

    private void B_cargarAreas()
    {
        materia = new cls_materia();
        ddl_plan_area.Items.Clear();
        ddl_plan_area.Items.Add("Seleccione un area...");
        ddl_plan_area.DataSource = materia.ObtenerArea();
        ddl_plan_area.DataTextField = "plan_area";
        ddl_plan_area.DataBind();
    }

    protected void ddl_plan_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        B_CargarCarreras();
        SetScript("", "");
    }
    private void B_CargarCarreras()
    {
        materia = new cls_materia();
        ddl_plan_carrera.Items.Clear();
        materia.area = ddl_plan_area.SelectedItem.Text;
        ddl_plan_carrera.Items.Add("Seleccione una carrera...");
        ddl_plan_carrera.DataSource = materia.ObtenerCarrera();
        ddl_plan_carrera.DataTextField = "plan_carrera_nombre";
        ddl_plan_carrera.DataBind();
    }

    protected void ddl_plan_carrera_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarPlanes();
        SetScript("", "");
    }
    private void CargarPlanes()
    {
        materia = new cls_materia();
        ddl_plan.Items.Clear();
        materia.area = ddl_plan_area.SelectedItem.Text;
        materia.carrera = ddl_plan_carrera.SelectedItem.Text;
        ddl_plan.DataSource = materia.C_ObtenerPlan();
        ddl_plan.DataValueField = "plan_id";
        ddl_plan.DataTextField = "plan_gestion";
        ddl_plan.DataBind();
    }
    public void Limpiar(string campo)
    {
        if (campo.Equals("nuevo"))
        {
            Txt_grupo.Text = null;
            Txt_horas.Text = null;
            Txt_mat_nombre.Text = null;
            Txt_nivel.Text = null;
            Txt_sigla.Text = null;
            ddl_plan.Items.Clear();
            ddl_plan_carrera.Items.Clear();
        }
        if (campo.Equals("busqueda"))
        {
            ddl_plan_area.Items.Clear();
            ddl_plan.Items.Clear();
        }
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        mat_Agregar.Visible = false;
        materia_result.Visible = true;
        if (string.IsNullOrWhiteSpace(ddl_area.SelectedItem.Text) && string.IsNullOrWhiteSpace(Ddl_carrera_nombre.SelectedItem.Text) && string.IsNullOrWhiteSpace(ddl_plan_bus.SelectedItem.Text))
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise que los parametros no esten vacios' }, { type: 'warning' });";
        }
        else
        {
            if (ddl_plan_bus.SelectedIndex != 0 && ddl_area.SelectedIndex != 0 && Ddl_carrera_nombre.SelectedIndex != 0)
            {
                materia = new cls_materia();
                materia.p_id = Convert.ToInt32(ddl_plan_bus.SelectedValue);
                //GvLista.DataSource = "";
                GvLista.DataSource = materia.Listar();
                GvLista.DataBind();
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise si esta seleccionando todos los parametros' }, { type: 'warning' });";
            }
        }
        //SetScript(sc, "");
        SetScript("", "");
    }

    protected void Ddl_carrera_nombre_SelectedIndexChanged(object sender, EventArgs e)
    {
        mat_Agregar.Visible = false;
        Limpiar("busqueda");
        materia = new cls_materia();
        ddl_plan_bus.Items.Clear();
        materia.area = ddl_area.SelectedItem.Text;
        materia.carrera = Ddl_carrera_nombre.SelectedItem.Text;
        ddl_plan_bus.Items.Add("Seleccione un plan...");
        ddl_plan_bus.DataSource = materia.C_ObtenerPlan();
        ddl_plan_bus.DataValueField = "plan_id";
        ddl_plan_bus.DataTextField = "plan_gestion";
        ddl_plan_bus.DataBind();
        SetScript("", "");
    }

    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        string id_plan;
        materia = new cls_materia();
        if (e.CommandName== "Eliminar")
        {
            index = Convert.ToInt32(e.CommandArgument);
            id_plan = GvLista.DataKeys[index].Values[0].ToString();
            materia.mat_id = Convert.ToInt32(id_plan);
            materia.EliminarMateria__();
            sc = "$.notify({ icon: 'fas fa-check', message: 'Cambio de estado efectuado correctamente...' }, { type: 'success' });";
        }
        SetScript(sc, "");
    }

    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar _MENU_ Registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando Registros del _START_ al _END_ de un total de _TOTAL_ Registros'," +
                    "'sInfoEmpty': 'Mostrando Registros del 0 al 0 de un total de 0 Registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ Registros)'," +
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
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
            "});");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerDefault\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: \"es\"" +
                    "});" +
                "});" +
                "var me = $(\".datepickerDefault\");" +
                "me.mask(\"99/99/9999\");" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
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
}