using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_Precontratacion.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Newtonsoft.Json;
using System.Text;

public partial class Precontratacion_ListaPlanillaValidada : System.Web.UI.Page
{
    private cls_pc_frecuencia plan = null;
    private cls_pc_precontratado planilla = null;
    private cls_catalogo catalogo = null;
    private cls_historico historico = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
                int pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
                //listarPlanillas(us_id, pr_id);
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }
    private void listarPlanillas(int us_id = 0, int pr_id = 0)
    {
        planilla = new cls_pc_precontratado { usuario_per_id = us_id, pl_pr_id = Convert.ToString(pr_id) };
        var planilla_cr = planilla.ListarPlanillas();
        int tam = planilla_cr.Tables[0].Rows.Count;
        ltl_total_reg.Text = Convert.ToString(tam);
        no_existe_pla.Visible = (tam > 0) ? false : true;
        lv_planilla.DataSource = planilla_cr;
        lv_planilla.DataBind();
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
        "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 50, 'paging': false, 'info': false });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_buscar_planilla_Click(object sender, EventArgs e)
    {
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        string pr_id = (Session["pr_id"] != null) ? Session["pr_id"].ToString() : "";
        planilla = new cls_pc_precontratado
        {
            usuario_per_id = us_id,
            pl_pr_id = pr_id,
            pl_correlativo = (txt_cod.Text.Trim() != "") ? txt_cod.Text : null,
            pl_ue = (txt_ue.Text.Trim() != "") ? Convert.ToInt32(txt_ue.Text) : 0,
            pl_estado = "V"
        };

        var planilla_cr = planilla.ListarPlanillasBusqueda();
        int tam = planilla_cr.Tables[0].Rows.Count;
        ltl_total_reg.Text = Convert.ToString(tam);

        if (tam > 0)
        {
            no_existe_pla.Visible = false;
            SetScript("$('#grillaPlanillas').css('display', 'block');");
        }
        else
        {
            ltl_no_existe.Text = "No existen planillas registradas.";
            no_existe_pla.Visible = true;
            SetScript("$('#grillaPlanillas').css('display', 'none');");
        }
        lv_planilla.DataSource = planilla_cr;
        lv_planilla.DataBind();
    }
    protected void gv_ue_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        SetScript("");
    }

    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }
    private void AdicionarHistorico(string abm = "", string tabla = "", string nom_pk = "", string val_pk = "", string campos = "")
    {
        historico = new cls_historico
        {
            his_tipo_abm = abm,
            his_nom_tabla = tabla,
            his_nom_pk = nom_pk,
            his_valor_pk = val_pk,
            his_campos = campos,
            his_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString())
        };
        historico.Adicionar();
    }

    protected void btn_eilminar_planilla_Click(object sender, EventArgs e)
    {
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        int pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        planilla = new cls_pc_precontratado { pl_id = hf_pl_id.Value };
        var detallePlanilla = planilla.EliminarPlanilla();
        if (detallePlanilla.Tables.Count > 0)
        {
            if (detallePlanilla.Tables[0].Rows.Count > 0)
            {
                var planillaX = detallePlanilla.Tables[0].Rows[0];
                string json = JsonConvert.SerializeObject(detallePlanilla.Tables[0]);
                AdicionarHistorico("B", "tbl_pc_planilla", "pl_id", Convert.ToString(hf_pl_id.Value), json);

                planilla.seg_pk_id = Convert.ToInt32(hf_pl_id.Value);
                planilla.seg_us_id_remitente = us_id;
                planilla.seg_us_id_recepcion = 0;
                planilla.seg_accion = "ANULADO";
                planilla.seg_observaciones = null;
                planilla.seg_tabla = "tbl_pc_planilla";
                planilla.AdicionarSeguimiento();
            }
        }

        listarPlanillas(us_id, pr_id);
        sc = "Swal.fire({ icon: 'success', title: 'Planilla eliminada correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarPlanilla').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);

    }

    protected void lv_planilla_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string pl_id = lv_planilla.DataKeys[index].Values[0].ToString();
        string pl_ue = lv_planilla.DataKeys[index].Values[1].ToString();
        string pl_estado = lv_planilla.DataKeys[index].Values[2].ToString();
        //string pl_ue = lv_planilla.Rows[index].Cells[0].Text;
        hf_pl_id.Value = pl_id;

        switch (e.CommandName)
        {
            case "GetAssign":
                if (pl_estado.Trim() == "VALIDADO" || pl_estado.Trim() == "VALIDADO POR RRHH")
                {
                    Response.Redirect("PlanillaValidada?id=" + pl_id + "&id2=" + pl_ue + "&id3=" + Session["pr_id"].ToString());
                }
                else
                {
                    sc = "$.notify({ icon: 'fa fa-info-circle', message: 'No se puede realizar la acción, la planilla ya ha sido ejecutada.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });";
                    SetScript(sc);
                }

                break;
            case "GetDelete":
                sc = "$('#eliminarPlanilla').modal('show');";
                SetScript(sc);
                break;
            case "GetPrint":
                Session["pl_id"] = pl_id;
                Response.Redirect("../Precontratacion/ReportePlanillaC.aspx");
                break;
            case "GetDetailPuestos":
                Session["pl_id"] = pl_id;
                Response.Redirect("ReporteDescriptorP.aspx");
                break;
            case "GetDetailPla":
                ver_estado(Convert.ToInt32(pl_id));
                break;
            default:
                break;
        }
    }
    protected void ver_estado(int pl_id = 0)
    {
        planilla = new cls_pc_precontratado { pre_pl_id = pl_id };
        var estados = planilla.ObtenerEstadoPlanilla();
        int tam_cat = estados.Tables[0].Rows.Count;
        no_existe_acciones.Visible = (tam_cat > 0) ? false : true;
        gv_estado.DataSource = estados;
        gv_estado.DataBind();

        foreach (GridViewRow row in gv_estado.Rows)
        {
            for (int i = 0; i < gv_estado.Columns.Count; i++)
            {
                if (i == 1)
                {
                    string estado = row.Cells[i].Text;
                    switch (estado)
                    {
                        case "ENVIADO":
                            row.CssClass = "grid-row-info";
                            break;
                        case "APROBADO":
                            row.CssClass = "grid-row-success";
                            break;
                        case "VALIDADO":
                            row.CssClass = "grid-row-vimeo";
                            break;
                        case "AJUSTAR":
                            row.CssClass = "grid-row-warning";
                            break;
                        default:
                            break;
                    }
                }

            }
        }

        sc = "$('#modalEstados').modal('show'); ";
        SetScript(sc);
    }
    protected void gv_estado_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_estado.Rows.Count > 0)
        {
            if (gv_estado.HeaderRow != null)
            {
                gv_estado.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_estado.FooterRow != null)
            {
                gv_estado.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}