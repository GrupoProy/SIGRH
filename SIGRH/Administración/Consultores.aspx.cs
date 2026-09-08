using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System.Text;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Data;
public partial class Administración_Consultores : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                CargarMeses();
            }
        }
        else Response.Redirect("../Index");
    }
    private void CargarNroPlanilla(string cod_proceso) {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        lblNroPlanilla.Text = proceso.ObtenerConsultores_NumeroPlanilla(cod_proceso);
    }
    protected void chk_print_memo_all_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvFuncionario.Rows.Count; i++)
        {
            GridViewRow row = gvFuncionario.Rows[i];
            bool isChecked = ((CheckBox)gvFuncionario.HeaderRow.FindControl("chk_print_memo_all")).Checked;

            if (isChecked)
            {
                ((CheckBox)row.FindControl("chk_print_memo")).Checked = true;
            }
            else
            {
                ((CheckBox)row.FindControl("chk_print_memo")).Checked = false;
            }
        }
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

        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
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
            "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 100, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('.checks label').addClass('custom-control-label mb-3'); $('.checks input[type =" + '"' + "checkbox" + '"' + "]').addClass('custom-control-input mb-3');");

        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gvFuncionario_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvFuncionario.Rows.Count > 0)
        {
            if (gvFuncionario.HeaderRow != null)
            {
                gvFuncionario.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvFuncionario.FooterRow != null)
            {
                gvFuncionario.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void gvFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //int index = Convert.ToInt32(e.CommandArgument);
        //string p_cod_fun = gvFuncionario.DataKeys[index].Values[0].ToString();
        //string p_as_id = gvFuncionario.DataKeys[index].Values[1].ToString();

        //switch (e.CommandName)
        //{
        //    case "GetDetail":
        //        if (ddl_tenor.SelectedValue != "0")
        //        {
        //            Response.Redirect("TenorFuncionario?id=" + p_cod_fun + "&id2=" + hf_cod_tenor.Value + "&id3=" + ddl_tipo_movimiento_gral.SelectedValue + "&id4=" + gestion);
        //        }
        //        else
        //        {
        //            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Debe escoger un Tenor para imprimir.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
        //            SetScript(sc);
        //        }
        //        break;
        //    case "GetPrint":
        //        if (ddl_tenor.SelectedValue != "0")
        //        {
        //            int cod_tenor = (ddl_tenor.SelectedValue != "") ? Convert.ToInt32(ddl_tenor.SelectedValue) : 0;
        //            var detalleTenor = obtenerTenor(cod_tenor);
        //            string containerQuill = ImprimirMemo(Convert.ToInt32(p_cod_fun), cod_tenor, detalleTenor, Convert.ToInt32(p_as_id));

        //            if (containerQuill != "")
        //            {
        //                hf_containerQuill.Value = containerQuill;
        //                sc = "armarQuill();";
        //            }
        //            else
        //            {
        //                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
        //            }
        //            SetScript(sc);
        //        }
        //        else
        //        {
        //            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Debe escoger un Tenor para imprimir.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
        //            SetScript(sc);
        //        }

        //        break;
        //    default:
        //        break;
        //}
    }
    protected void btnMigrar_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        foreach (GridViewRow item in gvFuncionario.Rows)
        {
            CheckBox chk = item.FindControl("chk_print_memo") as CheckBox;
            if (chk.Checked == true)
            {
                    
            }
        }
    }

    private void CargarMeses()
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlMesPlanilla.DataSource = proceso.ObtenerMesesProceso();
        ddlMesPlanilla.Items.Add("Seleccione..");
        ddlMesPlanilla.DataTextField = "pc_titulo";
        ddlMesPlanilla.DataValueField = "pc_id";
        ddlMesPlanilla.DataBind();
    }

    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        CargarNroPlanilla(ddlMesPlanilla.SelectedValue);
        if (proceso.VerificarPlanilla_Consultores(ddlMesPlanilla.SelectedValue, lblNroPlanilla.Text).Tables[0].Rows[0][0].ToString()=="0")
        {
            DataSet ds = proceso.Insertar_MostrarCasos_Consultores(ddlMesPlanilla.SelectedValue, lblNroPlanilla.Text);
                gvFuncionario.DataSource = proceso.Insertar_MostrarCasos_Consultores(ddlMesPlanilla.SelectedValue, lblNroPlanilla.Text);
                gvFuncionario.DataBind();
            if (gvFuncionario.Rows.Count > 0)
            {
                divProceso.Visible = true;
                divProceso1.Visible = true;
                divGrilla.Visible = true;
            }
            else
            {
                divProceso.Visible = false;
                divProceso1.Visible = false;
                divGrilla.Visible = false;
            }
        }
        else
        {
            divProceso1.Visible = false;
            divProceso2.Visible = false;
            divProceso3.Visible = false;
            divProceso4.Visible = false;
            divGrilla.Visible = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'La planilla ya fue procesada y finalizada' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#confimarGuardarSM').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        }
        SetScript(sc);

    }
    protected void btnProceso1_Click(object sender, EventArgs e)
    {   //Proceso inicial
        string list = "";
        int contador = 0;
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        foreach (GridViewRow row in gvFuncionario.Rows)
        {
            CheckBox chk = row.FindControl("chk_select") as CheckBox;
            if (chk.Checked == true)
            {
                contador = contador + 1;
                if (contador > 1)
                {
                    list = list + "," + gvFuncionario.DataKeys[row.RowIndex].Values[0].ToString();
                }
                else
                {
                    list = gvFuncionario.DataKeys[row.RowIndex].Values[0].ToString();
                }
            }
        }
        if (proceso.ProcesarConsultores_Paso1(ddlMesPlanilla.SelectedValue, lblNroPlanilla.Text, list) == true)
        {
            divProceso2.Visible = true;
            btnProceso1.Enabled = false;
        }
    }
    protected void btnProceso2_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        if (proceso.ProcesarConsultores_Paso2(ddlMesPlanilla.SelectedValue, lblNroPlanilla.Text) == true)
        {
            divProceso3.Visible = true;
            btnProceso2.Enabled = false;
        }
    }
    protected void btnProceso3_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        if (proceso.ProcesarConsultores_Paso3(ddlMesPlanilla.SelectedValue, lblNroPlanilla.Text) == true)
        {
            divProceso4.Visible = true;
            btnProceso3.Enabled = false;
        }
    }
    protected void btnProceso4_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        if (proceso.ProcesarConsultores_Paso4(ddlMesPlanilla.SelectedValue, lblNroPlanilla.Text) == true)
        {
            btnProceso4.Enabled = false;
            sc = "Swal.fire({ icon: 'success', title: 'Proceso de Planillas Completado', text: 'Revise las planillas físicas, se procederá a la generación de Líquidos Pagables, no será posible volver a procesar.', showConfirmButton: true, allowOutsideClick: false, onAfterClose: () => {  }});";
            SetScript(sc);

            Response.Redirect("PlanillaHaberesConsultores.aspx");
        }
        else
        {
            sc = "Swal.fire({ icon: 'warning', title: 'No fue posible concluir los procesos, consulte con el Administrador del Sistema.', showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            SetScript(sc);
        }
    }

    protected void btnAjustar_Click(object sender, EventArgs e)
    {


    }
}