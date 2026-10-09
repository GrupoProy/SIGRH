using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using System.Data;
using System.Text;
using Newtonsoft.Json;
public partial class Precontratacion_PlanillaValidacion : System.Web.UI.Page
{
    private cls_pc_frecuencia frecuencia = null;
    private cls_pc_precontratado precontratado = null;
    private cls_pc_precontratado planilla = null;
    private cls_historico historico = null;
    private cls_catalogo _catalogo = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
                int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
                int pl_ue = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
                int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
                informacionPlanilla(pl_id);
                listarPlanilla(pl_id);
                listarAnulados(pl_id);
                verificarValidacion();
                SetScriptInicio("$('.table').DataTable().destroy(); ");
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }
    private void SetScriptInicio(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();
        string l = " {" +
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
       "},";

        sb.Append(data);
        sb.Append("$('.table').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('#ContentPlaceHolder1_gv_planilla').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_planilla').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('#ContentPlaceHolder1_gv_planilla_ajuste').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_planilla_ajuste')) { $('#ContentPlaceHolder1_gv_planilla_ajuste').DataTable({" +
            "'language': " + l +
            "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto').select2({ dropdownParent: $('#modalAdicionarFrecPost'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_afp').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_pre_genero').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_usuarios').select2({ dropdownParent: $('#modalEnviar'), placeholder: { id: '0', text: 'Seleccione...' } });");

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        string l = " {" +
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
            "},";

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('#ContentPlaceHolder1_gv_planilla').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_planilla')) { $('#ContentPlaceHolder1_gv_planilla').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('#ContentPlaceHolder1_gv_planilla_ajuste').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_planilla_ajuste')) { $('#ContentPlaceHolder1_gv_planilla_ajuste').DataTable({" +
            "'language': " + l +
            "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto').select2({ dropdownParent: $('#modalAdicionarFrecPost'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto_modificar').select2({ dropdownParent: $('#modalModificarPuesto'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_afp').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_pre_genero').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_item').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_usuarios').select2({ dropdownParent: $('#modalEnviar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
    private void informacionPlanilla(int pl_id = 0)
    {
        planilla = new cls_pc_precontratado { pl_id = Convert.ToString(pl_id) };
        var detalle_planilla = planilla.DetallePlanilla();
        if (detalle_planilla.Tables.Count > 0)
        {
            if (detalle_planilla.Tables[0].Rows.Count > 0)
            {
                var planillaX = detalle_planilla.Tables[0].Rows[0];
                ltl_pl_correlativo.Text = validarCampo(planillaX["pl_id"]);
                ltl_pl_fecha.Text = validarCampo(planillaX["fecha_creacion"]);
                ltl_pl_estado.Text = validarCampo(planillaX["pl_estado"]);
                ltl_pl_ue.Text = validarCampo(planillaX["pl_ue"]) + " - " +validarCampo(planillaX["ue"]);
            }
        }
    }
    private void listarPlanilla(int pl_id = 0, int es_id = 0, string paterno = "0")
    {
        try
        {
            precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, es_id = es_id, pre_paterno = paterno };
            var precontratos = precontratado.ListarPrecontratos();
            int tam = precontratos.Tables[0].Rows.Count;
            no_existe_prec.Visible = (tam > 0) ? false : true;
            gv_planilla.DataSource = precontratos;
            gv_planilla.DataBind();

            foreach (GridViewRow row in gv_planilla.Rows)
            {
                for (int i = 0; i < gv_planilla.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        string estado = row.Cells[i].Text;
                        if (estado == "ACEFALIA")
                        {
                            row.CssClass = "grid-row-enabled";
                        }
                    }

                }
            }

            listaFiltradoPlanilla(pl_id, es_id, paterno, "C21", "ddl_gv_planilla_paterno", "ap_paterno_x", "ap_paterno_x", " CASE WHEN P.per_id IS NULL AND TPC.tmp_id IS NULL THEN 'ACEFALIA' WHEN P.per_id IS NOT NULL AND TPC.tmp_id IS NULL THEN LTRIM(RTRIM(P.per_ap_paterno)) WHEN P.per_id IS NULL AND TPC.tmp_id IS NOT NULL THEN LTRIM(RTRIM(TPC.tmp_paterno)) END AS ap_paterno_x ");
            listaFiltradoPlanilla(pl_id, es_id, paterno, "C20", "ddl_gv_planilla_cargo", "es_id", "es_descripcion", "ES.es_descripcion, ES.es_id");

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void verificarValidacion()
    {

        switch (ltl_pl_estado.Text)
        {
            case "APROBADO":
                btn_ajustar.Visible = true;
                btn_aprobar.Visible = true;
                btn_ajustar.CssClass = "btn btn-warning btn-round btn-icon";
                btn_aprobar.CssClass = "btn btn-vimeo btn-round btn-icon";
                break;
            case "VALIDADO":
                btn_ajustar.Visible = false;
                btn_aprobar.Visible = true;
                btn_aprobar.Text = "<span class='btn-inner--icon'><i class='fas fa-check'></i></span><span class='btn-inner--text'>VALIDADO</span>";
                btn_aprobar.Enabled = false;
                break;
            case "ENVIADO":
                int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
                planilla = new cls_pc_precontratado { pre_pl_id = pl_id };
                var detalle_estados = planilla.ObtenerEstadoPlanilla();
                bool sw = false;
                if (detalle_estados.Tables[0].Rows.Count > 0)
                {
                    var estadosP = detalle_estados.Tables[0].Rows;
                    for (int i = 0; i < estadosP.Count; i++)
                    {
                        if (validarCampo(estadosP[i]["seg_accion"]) == "APROBADO")
                        {
                            sw = true;
                            break;
                        }
                    }
                }
                if (sw)
                {
                    btn_ajustar.Visible = true;
                    btn_aprobar.Visible = true;
                    btn_ajustar.CssClass = "btn btn-warning btn-round btn-icon";
                    btn_aprobar.CssClass = "btn btn-vimeo btn-round btn-icon";
                }
                else
                {
                    btn_ajustar.Visible = false;
                    btn_aprobar.Visible = false;
                }
                break;
            case "AJUSTAR":
                btn_ajustar.Visible = true;
                btn_aprobar.Visible = false;
                btn_ajustar.Text = "<span class='btn-inner--icon'><i class='fas fa-wrench'></i></span><span class='btn-inner--text'>Por Ajustar</span>";
                btn_ajustar.Enabled = false;
                break;
            default:
                break;
        }
    }
    private void listaFiltradoPlanilla(int pl_id = 0, int es_id = 0, string paterno = "0", string accion = "", string ddl_id = "", string ddl_value = "", string ddl_desc = "", string q = "")
    {
        try
        {
            precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, es_id = es_id, pre_paterno = paterno, accion = accion };

            DropDownList ddl = gv_planilla.HeaderRow.FindControl(ddl_id) as DropDownList;
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("TODOS", "0"));
            ddl.DataValueField = ddl_value;
            ddl.DataTextField = ddl_desc;
            ddl.DataSource = precontratado.ObtenerListaFiltradoPlanilla(q);
            ddl.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
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
    protected void ddl_gv_planilla_cargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        DropDownList ddl_gv_planilla_paterno = gv_planilla.HeaderRow.FindControl("ddl_gv_planilla_paterno") as DropDownList;
        DropDownList ddl_gv_planilla_cargo = gv_planilla.HeaderRow.FindControl("ddl_gv_planilla_cargo") as DropDownList;

        string pre_paterno = (ddl_gv_planilla_paterno.SelectedValue != "0") ? ddl_gv_planilla_paterno.SelectedValue : "0";
        int fr_es_id = (ddl_gv_planilla_cargo.SelectedValue != "0") ? Convert.ToInt32(ddl_gv_planilla_cargo.SelectedValue) : 0;

        listarPlanilla(pl_id, fr_es_id, pre_paterno);

        DropDownList ddl_gv_planilla_paterno_after = gv_planilla.HeaderRow.FindControl("ddl_gv_planilla_paterno") as DropDownList;
        DropDownList ddl_gv_planilla_cargo_after = gv_planilla.HeaderRow.FindControl("ddl_gv_planilla_cargo") as DropDownList;
        ddl_gv_planilla_paterno_after.SelectedValue = pre_paterno;
        ddl_gv_planilla_cargo_after.SelectedValue = fr_es_id + "";
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


    protected void gv_planilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_pre_id.Value = gv_planilla.DataKeys[index].Values[0].ToString();
        hf_fr_id.Value = gv_planilla.DataKeys[index].Values[1].ToString();
        int cp_id = Convert.ToInt32(gv_planilla.DataKeys[index].Values[2].ToString());
        switch (e.CommandName)
        {

            case "GetEditP":
                datosPuesto();
                sc = "$('#modalPuesto').modal('show');";
                SetScript(sc);
                verificarValidacion();
                break;
            default:
                break;
        }
    }
    private void datosPuesto()
    {
        precontratado = new cls_pc_precontratado { pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detallePuesto = precontratado.DatosPuestoX();

        if (detallePuesto.Tables.Count > 0)
        {
            if (detallePuesto.Tables[0].Rows.Count > 0)
            {
                var puestoX = detallePuesto.Tables[0].Rows[0];
                ltl_puesto.Text = validarCampo(puestoX["pu_descripcion"]);
                ltl_objetivo.Text = validarCampo(puestoX["pre_obj_puesto"]).Replace("\n", "<br />");
                lbl_tareas.Text = validarCampo(puestoX["pre_tareas"]).Replace("\n", "<br />");
            }
        }
    }
    protected void btn_cancelar_puesto_Click(object sender, EventArgs e)
    {
        sc = "$('#modalPuesto').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    protected void btn_cerrar_puesto_Click(object sender, EventArgs e)
    {
        sc = "$('#modalPuesto').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_ajustar_Click(object sender, EventArgs e)
    {
        txt_observaciones.Text = string.Empty;
        sc = "$('#modalAjustarPr').modal('show');";
        SetScript(sc);
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
    private void listarAnulados(int pl_id = 0)
    {
        try
        {
            precontratado = new cls_pc_precontratado { pre_pl_id = pl_id };
            var anulados = precontratado.ListarAnulados();
            int tam = anulados.Tables[0].Rows.Count;
            no_existe_anulados.Visible = (tam > 0) ? false : true;
            existe_anulado.Visible = (tam > 0);
            gv_anulados.DataSource = anulados;
            gv_anulados.DataBind();

            foreach (GridViewRow row in gv_anulados.Rows)
            {
                row.CssClass = "grid-row-disabled";
            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void gv_anulados_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_anulados.Rows.Count > 0)
        {
            if (gv_anulados.HeaderRow != null)
            {
                gv_anulados.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_anulados.FooterRow != null)
            {
                gv_anulados.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void btn_aprobar_Click(object sender, EventArgs e)
    {
        string pl_id = (Request.QueryString["id"] != null) ? Request.QueryString["id"].ToString() : "";
        planilla = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id) };
        var detalle_planillas = planilla.ObtenerValidacionFechas();
        gv_planilla_ajuste.DataSource = detalle_planillas;
        gv_planilla_ajuste.DataBind();

        sc = (detalle_planillas.Tables[0].Rows.Count > 0) ? "$('#modalAjusteFecha').modal('show');" : "$('#modalConfirmacionV').modal('show');";
        SetScript(sc);
    }

    protected void btn_confirmar_envio_Click(object sender, EventArgs e)
    {
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        string pl_id = (Request.QueryString["id"] != null) ? Request.QueryString["id"].ToString() : "";

        planilla = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id) };
        var estados = planilla.ObtenerEstadoPlanilla();
        int tam_cat = estados.Tables[0].Rows.Count;
        if (tam_cat > 0)
        {
            if (validarCampo(estados.Tables[0].Rows[tam_cat - 1]["seg_accion"]) == "ENVIADO")
            {
                planilla = new cls_pc_precontratado { pl_id = pl_id, pl_estado = "P" };
                var pl = planilla.ActualizarEstadoPlanilla();
                string json = JsonConvert.SerializeObject(pl.Tables[0]);
                AdicionarHistorico("M", "tbl_pc_planilla", "pl_id", pl_id, json);

                precontratado = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id), pre_estado = "E", pre_estado_x = "P" };
                precontratado.ActualizarEstadoPrecontrato();

                string usuario = (ddl_usuarios.SelectedValue);
                string[] words = usuario.Split('-');
                string us_id_r = words[0].Trim();
                string us_correo = words[1].Trim();
                planilla.seg_pk_id = Convert.ToInt32(pl_id);
                planilla.seg_us_id_remitente = us_id;
                planilla.seg_us_id_recepcion = Convert.ToInt32(us_id_r);
                planilla.seg_accion = "ENVIADO";
                planilla.seg_observaciones = null;
                planilla.seg_tabla = "tbl_pc_planilla";
                planilla.AdicionarSeguimiento();

                Session["texto_notificacion"] = "Planilla aprobada correctamente.";
                Response.Redirect("ListaPlanillaAprobacion");
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    protected void btn_cancelar_envio_Click(object sender, EventArgs e)
    {
        sc = "$('#modalEnviar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_confirmar_ajuste_Click(object sender, EventArgs e)
    {
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        string correo_remitente = (Session["correo"] != null) ? Session["correo"].ToString() : "";
        string usuario_remitente = (Session["per_nombres"] != null) ? Session["per_nombres"].ToString() : "";
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        planilla = new cls_pc_precontratado { pre_pl_id = pl_id };
        var detalle_estados = planilla.ObtenerEstadoPlanilla();
        if (detalle_estados.Tables[0].Rows.Count > 0)
        {
            var estadosP = detalle_estados.Tables[0].Rows;
            int us_rec = 0;
            string correo_recepcion = "";
            string usuario_recepcion = "";
            string correo_recepcion_cc = "";
            string usuario_recepcion_cc = "";
            for (int i = 0; i < estadosP.Count; i++)
            {
                if (validarCampo(estadosP[i]["seg_accion"]) == "ENVIADO")
                {
                    us_rec = Convert.ToInt32(validarCampo(estadosP[i]["seg_us_id_remitente"]));
                    correo_recepcion = validarCampo(estadosP[i]["correo_remitente"]);
                    usuario_recepcion = validarCampo(estadosP[i]["remitente"]);
                    correo_recepcion_cc = validarCampo(estadosP[i]["correo_recepcion"]);
                    usuario_recepcion_cc = validarCampo(estadosP[i]["recepcion"]);
                    break;
                }
            }

            if (us_rec != 0)
            {
                if (validarCampo(estadosP[0]["seg_accion"]) == "APROBADO")
                {
                    precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, pre_estado = "P", pre_estado_x = "A", pl_estado = "P", pl_estado_x = "A", pl_observaciones = (txt_observaciones.Text.Trim() != "") ? txt_observaciones.Text.ToUpper().Trim() : null };

                    var detallePrecontratado = precontratado.ObtenerCambiarEstadoPlanilla();
                    string json = JsonConvert.SerializeObject(detallePrecontratado.Tables[0]);
                    AdicionarHistorico("M", "tbl_pc_planilla", "pl_id", Convert.ToString(pl_id), json);

                    planilla.seg_pk_id = pl_id;
                    planilla.seg_us_id_remitente = us_id;
                    planilla.seg_us_id_recepcion = us_rec;
                    planilla.seg_accion = "AJUSTAR";
                    planilla.seg_observaciones = (txt_observaciones.Text.Trim() != "") ? txt_observaciones.Text.ToUpper().Trim() : null;
                    planilla.seg_tabla = "tbl_pc_planilla";
                    planilla.AdicionarSeguimiento();

                    string asunto = "SOLICITUD DE REVISIÓN DE PLANILLA Nº  " + ltl_pl_correlativo.Text + " MOTIVO: AJUSTAR LA PLANILLA";
                    string contenido = "<p>Se le comunica que se devuelve la <strong>Planilla Nº " + ltl_pl_correlativo.Text + "</strong>, que fue observado por el usuario <strong>" + usuario_remitente + "</strong> para el ajuste correspondiente según las siguientes observaciones:</p><p>" + txt_observaciones.Text.ToUpper().Trim() + "</p>";
                    enviarCorreo(correo_remitente, correo_recepcion, correo_recepcion_cc, usuario_remitente, usuario_recepcion, usuario_recepcion_cc, contenido, asunto);

                    Session["texto_notificacion"] = "Solicitud de ajuste de Planilla enviado correctamente.";
                    Response.Redirect("ListaPlanillaAprobacion");
                }
                else
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                    SetScript(sc);
                }
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }

        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }
    protected void btn_confirmar_val_Click(object sender, EventArgs e)
    {
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        string correo_remitente = (Session["correo"] != null) ? Session["correo"].ToString() : "";
        string usuario_remitente = (Session["per_nombres"] != null) ? Session["per_nombres"].ToString() : "";
        string pl_id = (Request.QueryString["id"] != null) ? Request.QueryString["id"].ToString() : "";

        planilla = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id) };
        var detalle_estados = planilla.ObtenerEstadoPlanilla();
        if (detalle_estados.Tables[0].Rows.Count > 0)
        {
            var estadosP = detalle_estados.Tables[0].Rows;
            bool sw = false;
            for (int i = 0; i < estadosP.Count; i++)
            {
                if (validarCampo(estadosP[i]["seg_accion"]) == "APROBADO")
                {
                    sw = true;
                    break;
                }
            }
            string correo_recepcion = "";
            string usuario_recepcion = "";
            string correo_recepcion_cc = "";
            string usuario_recepcion_cc = "";
            for (int i = 0; i < estadosP.Count; i++)
            {
                if (validarCampo(estadosP[i]["seg_accion"]) == "ENVIADO")
                {
                    correo_recepcion = validarCampo(estadosP[i]["correo_recepcion"]);
                    usuario_recepcion = validarCampo(estadosP[i]["recepcion"]);
                    correo_recepcion_cc = validarCampo(estadosP[i]["correo_remitente"]);
                    usuario_recepcion_cc = validarCampo(estadosP[i]["remitente"]);
                    break;
                }
            }
            if (sw)
            {
                planilla = new cls_pc_precontratado { pl_id = pl_id, pl_estado = "V" };
                var pl = planilla.ActualizarEstadoPlanilla();
                string json = JsonConvert.SerializeObject(pl.Tables[0]);
                AdicionarHistorico("M", "tbl_pc_planilla", "pl_id", pl_id, json);

                precontratado = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id), pre_estado = "P", pre_estado_x = "V" };
                precontratado.ActualizarEstadoPrecontrato();

                planilla.seg_pk_id = Convert.ToInt32(pl_id);
                planilla.seg_us_id_remitente = us_id;
                planilla.seg_us_id_recepcion = 0;
                planilla.seg_accion = "VALIDADO";
                planilla.seg_observaciones = null;
                planilla.seg_tabla = "tbl_pc_planilla";
                planilla.AdicionarSeguimiento();

                planilla = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id) };
                //planilla.ObtenerCambiarFechas();

                string asunto = "LA PLANILLA Nº " + ltl_pl_correlativo.Text + " FUE VALIDADA";
                string contenido = "<p>Se le comunica que la <strong>Planilla Nº " + ltl_pl_correlativo.Text + "</strong>, fue validada con éxito.</p>";
                enviarCorreo(correo_remitente, correo_recepcion, correo_recepcion_cc, usuario_remitente, usuario_recepcion, usuario_recepcion_cc, contenido, asunto);

                Session["texto_notificacion"] = "Planilla validada correctamente.";
                Response.Redirect("ListaPlanillaValidacion");
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, la planilla no fue aprobada.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }
    private void enviarCorreo(string correo_remitente = "", string correo_recepcion = "", string correo_recepcion_cc = "", string usuario_remitente = "", string usuario_recepcion = "", string usuario_recepcion_cc = "", string contenido = "", string asunto = "")
    {
        string h = "http://gmlpsr00001/sigrh3/";
        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        correo.From = new System.Net.Mail.MailAddress(correo_remitente);
        correo.To.Add(correo_recepcion);
        correo.CC.Add(correo_recepcion_cc);
        correo.Subject = asunto;
        string html;

        html = "  <!doctype html><html> <body><div style='font: 20px Calibri, arial; margin-bottom: 30px; border: 0; box-shadow: 0 0 32px 0 rgba(136, 152, 170, .15); '>";
        html += "<div style='margin-bottom: 16px; padding-top: 20px; padding-bottom: 20px; background-color: #fff;' align='right'>";
        html += "<img src='cid:imagen' style='width: 70; display: block; margin-left: auto; border-radius: 7% !important;' /> ";
        html += "</div>";
        html += "<div class='card-body' style='min-height: 1px; padding: 24px; flex: 1 1 auto; text-align: justify;' >";
        html += "<div style='padding-bottom: 20px; margin-bottom: 32px' align='center'>";
        html += "<img src='cid:imagen2' style='width: 70; display: block; margin-right: auto; margin-left: auto; border-radius: 50% !important;'  /> ";
        html += "</div>";
        html += "Estimado usuario: <strong>" + usuario_recepcion + "</strong>";
        html += contenido;
        html += "<p>Por lo que se le solicita hacer clic en el siguiente enlace.</p>";
        html += "<div style='text-align: center;'>";
        html += "<a href= '" + h + "' target='_blank'><img src='cid:imagen3' style='width: 70; display: block; margin-right: auto; margin-left: auto; border-radius: 50% !important;'  /> </a> ";
        html += "<p style='margin-top: 32px; font-size: 14px; text-align: right;'> Este mensaje es generado automáticamente por el SISTEMA INTEGRADO DE GESTIÓN DE RECURSOS HUMANOS </p> ";
        html += "<p style='margin-top: 8px; font-size: 14px; text-align: right; color: #adb5bd;'> DIRECCIÓN DE GESTIÓN DE RECURSOS HUMANOS</p> ";
        html += "</div></div></div>  </body></html>";
        System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(html, System.Text.Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Html);
        System.Net.Mail.LinkedResource img = new System.Net.Mail.LinkedResource(Server.MapPath("../Content/img/brand/logo_lp2.png"));
        System.Net.Mail.LinkedResource img2 = new System.Net.Mail.LinkedResource(Server.MapPath("../Content/img/brand/correo5.png"));
        System.Net.Mail.LinkedResource img3 = new System.Net.Mail.LinkedResource(Server.MapPath("../Content/img/brand/correo7.png"));
        img.ContentId = "imagen";
        img2.ContentId = "imagen2";
        img3.ContentId = "imagen3";
        htmlView.LinkedResources.Add(img);
        htmlView.LinkedResources.Add(img2);
        htmlView.LinkedResources.Add(img3);
        correo.AlternateViews.Add(htmlView);
        correo.Priority = System.Net.Mail.MailPriority.Normal;

        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = "legado";
        try
        {
            smtp.Send(correo);
        }
        catch (Exception ex)
        {
            Console.Write(ex);
        }

    }

    protected void gv_planilla_ajuste_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_planilla_ajuste.Rows.Count > 0)
        {
            if (gv_planilla_ajuste.HeaderRow != null)
            {
                gv_planilla_ajuste.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_planilla_ajuste.FooterRow != null)
            {
                gv_planilla_ajuste.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void btn_aceptar_ajuste_Click(object sender, EventArgs e)
    {
        sc = "$('#modalConfirmacionV').modal('show');";
        SetScript(sc);
    }
}