using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_RegistroViatico : System.Web.UI.Page
{
    cls_cp_viatico viatico = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarDestino();
            cargarPlanilla();
        }
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        viatico = new cls_cp_viatico();
        GvFuncionarios.DataSource = viatico.BuscarFuncionario(txt_ci.Text);
        GvFuncionarios.DataBind();
        if (GvFuncionarios.Rows.Count > 0)
        {
            GridPersonal.Visible = true;
        }
        SetScript("", "");
    }
    private void cargarDestino()
    {
        viatico = new cls_cp_viatico();
        ddl_destino.DataSource = viatico.cargarDestino();
        ddl_destino.DataTextField = "ev_destino";
        ddl_destino.DataValueField = "";
        ddl_destino.DataBind();
    }

    private void cargarCategoria()
    {
        viatico = new cls_cp_viatico();
        if (ddl_destino.Text != "")
        {
            ddl_categoria.Items.Clear();
            ddl_categoria.Items.Add("SELECCIONE...");
            ddl_categoria.DataSource = viatico.cargarCategoria(ddl_destino.Text);
            ddl_categoria.DataTextField = "Categoria";
            ddl_categoria.DataValueField = "ev_id";
            ddl_categoria.DataBind();
        }
    }

    protected void ddl_destino_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarCategoria();
        SetScript("", "");
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

    protected void GvFuncionarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        viatico = new cls_cp_viatico();
        int index;
        int per_id = 0;
        int as_id = 0;
        if (e.CommandName == "Elegir")
        {
            index = Convert.ToInt32(e.CommandArgument);
            if (ddl_destino.Text != "" && ddl_categoria.Text != "SELECCIONE..." && txt_fecha_inicio.Text != "" && txt_fecha_fin.Text != "")
            {
                per_id = Convert.ToInt32(GvFuncionarios.DataKeys[index]["per_id"].ToString());
                as_id = Convert.ToInt32(GvFuncionarios.DataKeys[index]["as_id"].ToString());
                viatico.LlenarGridViatico(per_id, Convert.ToInt32(ddl_categoria.SelectedValue.ToString()), txt_cambio.Text, txt_fecha_inicio.Text, txt_fecha_fin.Text, as_id, txtMontoCurso.Text, txtObjeto.Text, txtDias.Text);
                sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Viatico registrado', timer: 3200, showConfirmButton: false, allowOutsideClick: true, onAfterClose: () => {  }});";
                cargarPlanilla();
            }
            else
            {
                sc = "Swal.fire({ icon: 'warning', title: 'Alerta', text: 'Asegurese de llenar todos los parametros', timer: 5200, showConfirmButton: false, allowOutsideClick: true, onAfterClose: () => {  }});";
            }
        }
        SetScript(sc, "");
    }

    protected void ddl_categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScript("", "");
    }

    private void cargarPlanilla()
    {
        viatico = new cls_cp_viatico();
        GvNoImpreso.DataSource = "";
        GvNoImpreso.DataSource = viatico.LlenarGridPlanillaViatico();
        GvNoImpreso.DataBind();
        if (GvNoImpreso.Rows.Count > 0)
        {
            GridPlanilla.Visible = true;
        }
        else
        {
            GridPlanilla.Visible = false;
        }
    }

    protected void GvNoImpreso_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (GvNoImpreso.Rows.Count > 0)
        {
            if (GvNoImpreso.HeaderRow != null)
            {
                GvNoImpreso.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (GvNoImpreso.FooterRow != null)
            {
                GvNoImpreso.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void GvNoImpreso_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        viatico = new cls_cp_viatico();
        int index = 0;
        int ev_id = 0;
        if (e.CommandName == "Eliminar")
        {
            index = Convert.ToInt32(e.CommandArgument);
            ev_id = Convert.ToInt32(GvNoImpreso.DataKeys[index]["vi_id"].ToString());
            viatico.Eliminar(ev_id);
            cargarPlanilla();
            sc = "Swal.fire({ icon: 'success', title: 'Eliminado exitoso', text: 'Viatico eliminado', timer: 3200, showConfirmButton: false, allowOutsideClick: true, onAfterClose: () => {  }});";
        }
        SetScript(sc, "");
    }

    protected void btnProcesar_Click(object sender, EventArgs e)
    {
        int nro_planilla = 0;
        viatico = new cls_cp_viatico();
        if (GvNoImpreso.Rows.Count > 0)
        {
            nro_planilla = Convert.ToInt32(GvNoImpreso.Rows[0].Cells[0].Text);
            viatico.ProcesarPlanillaViatico(nro_planilla, Convert.ToInt32(Session["us_id"].ToString()));
            sc = "window.open('../ControlPersonal/ImpresionViaticos.aspx?id=" + nro_planilla + "', 'width=500,height=500', '_blank');";
            SetScript(sc, "");
        }
    }


    protected void txt_fecha_fin_TextChanged(object sender, EventArgs e)
    {
        cls_cp_viatico viatico = new cls_cp_viatico();
        if (string.IsNullOrEmpty(txt_fecha_inicio.Text) && string.IsNullOrEmpty(txt_fecha_inicio.Text))
        {
        }
        else
        {
            txtDias.Text = viatico.ObtenerDiasViatico(txt_fecha_inicio.Text.ToString(), txt_fecha_fin.Text.ToString()).ToString();
        }
        SetScript("", "");
    }

    protected void txt_fecha_inicio_TextChanged(object sender, EventArgs e)
    {
        cls_cp_viatico viatico = new cls_cp_viatico();
        if (string.IsNullOrEmpty(txt_fecha_fin.Text) && string.IsNullOrEmpty(txt_fecha_inicio.Text))
        {
        }
        else
        {
            txtDias.Text = viatico.ObtenerDiasViatico(txt_fecha_inicio.Text.ToString(), txt_fecha_fin.Text.ToString()).ToString();
        }
        SetScript("", "");
    }
}