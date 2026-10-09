using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;

using System.Data;
using System.Text;
using Newtonsoft.Json;

public partial class Precontratacion_ValidacionDocDesc : System.Web.UI.Page
{
    private cls_pc_frecuencia frecuencia = null;
    private cls_pc_precontratado precontratado = null;
    private cls_pc_precontratado planilla = null;
    private cls_kd_respuesta_combo resp_combo = null;
    private cls_historico historico = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa glosa = null;
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
                contruirDocumentos();
                informacionPlanilla(pl_id);
                listarPlanilla(pl_id);
                listarAFP();
                listarGenero();
                listaFiltradoTipoDoc();
                SetScriptInicio("$('.table').DataTable().destroy(); ");
                verificarValidacion();
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }
    private void verificarPlanillaRRHH()
    {
        bool sw = false;
        foreach (GridViewRow row in gv_planilla.Rows)
        {
            for (int i = 0; i < gv_planilla.Columns.Count; i++)
            {
                if (i == 15)
                {
                    string estado = row.Cells[i].Text.Trim();
                    if (estado == "OBSERVADO")
                    {
                        sw = true;
                        break;
                    }
                }

            }
        }

        if (sw)
        {
            btn_devolver.CssClass = "btn btn-warning btn-round btn-icon";
            btn_devolver.Text = "<span class='btn-inner--icon'><i class='fas fa-reply'></i></span><span class='btn-inner--text'>DEVOLVER PLANILLA</span>";
            btn_devolver.Visible = true;
            btn_devolver.Enabled = true;
        }
        else
        {
            btn_devolver.Enabled = false;
            btn_devolver.Visible = false;
        }

        sw = true;
        foreach (GridViewRow row in gv_planilla.Rows)
        {
            for (int i = 0; i < gv_planilla.Columns.Count; i++)
            {
                if (i == 15)
                {
                    string estado = row.Cells[i].Text.Trim();
                    if (estado != "VALIDADO POR RRHH")
                    {
                        sw = false;
                        break;
                    }
                }

            }
        }

        if (sw)
        {
            if (ltl_pl_estado.Text == "VALIDADO POR RRHH")
            {
                btn_validar_planilla.CssClass = "btn btn-vimeo btn-round btn-icon";
                btn_validar_planilla.Text = "<span class='btn-inner--icon'><i class='fas fa-check'></i></span><span class='btn-inner--text'>PLANILLA VALIDADA</span>";
                btn_validar_planilla.Visible = true;
                btn_validar_planilla.Enabled = false;

                gv_planilla.Columns[16].Visible = false;
            }
            else
            {
                btn_validar_planilla.CssClass = "btn btn-vimeo btn-round btn-icon";
                btn_validar_planilla.Text = "<span class='btn-inner--icon'><i class='fas fa-check'></i></span><span class='btn-inner--text'>VALIDAR PLANILLA</span>";
                btn_validar_planilla.Visible = true;
                btn_validar_planilla.Enabled = true;
            }
        }
        else
        {
            btn_validar_planilla.Enabled = false;
            btn_validar_planilla.Visible = false;
        }

    }
    private void listarAFP()
    {
        _catalogo = new cls_catalogo { cat_tabla = "previsora" };
        ddl_afp.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_afp.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_afp.DataValueField = "cat_abreviacion";
        ddl_afp.DataTextField = "cat_descripcion";
        ddl_afp.DataBind();
    }
    private void listarGenero()
    {
        _catalogo = new cls_catalogo { cat_tabla = "genero" };
        ddl_pre_genero.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_pre_genero.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_pre_genero.DataValueField = "cat_abreviacion";
        ddl_pre_genero.DataTextField = "cat_descripcion";
        ddl_pre_genero.DataBind();
    }
    private void listaFiltradoTipoDoc()
    {
        try
        {
            _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
            var detalle_catalogo = _catalogo.ObtenerTablaCombo().Tables[0];

            DataTable lista_catalogo = new DataTable();
            lista_catalogo.Columns.Add("cat_id");
            lista_catalogo.Columns.Add("cat_descripcion");
            DataRow dr = null;

            int[] ids = { 816 };

            for (int i = 0; i < ids.Length; i++)
            {
                for (int j = 0; j < detalle_catalogo.Rows.Count; j++)
                {
                    if (ids[i] == Convert.ToInt32(validarCampo(detalle_catalogo.Rows[j]["cat_id"])))
                    {
                        dr = lista_catalogo.NewRow();
                        dr["cat_id"] = validarCampo(detalle_catalogo.Rows[j]["cat_id"]);
                        dr["cat_descripcion"] = validarCampo(detalle_catalogo.Rows[j]["cat_descripcion"]);
                        lista_catalogo.Rows.Add(dr);
                        break;
                    }
                }
            }

            ddl_tipo_documento.Items.Clear();
            ddl_tipo_documento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_documento.DataValueField = "cat_id";
            ddl_tipo_documento.DataTextField = "cat_descripcion";
            ddl_tipo_documento.DataSource = lista_catalogo;
            ddl_tipo_documento.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void verificarValidacion()
    {
        btn_devolver.CssClass = "btn btn-warning btn-round btn-icon disabled";
        btn_devolver.Visible = false;
        btn_devolver.Enabled = false;
        switch (ltl_pl_estado.Text)
        {
            case "OBSERVADO":
                btn_devolver.CssClass = "btn btn-warning btn-round btn-icon disabled";
                btn_devolver.Text = "<span class='btn-inner--icon'><i class='fas fa-eye'></i></span><span class='btn-inner--text'>OBSERVADO</span>";
                btn_devolver.Enabled = false;
                btn_devolver.Visible = true;
                gv_planilla.Columns[16].Visible = false;
                break;
            //case "VALIDADO":
            //    btn_devolver.CssClass = "btn btn-warning btn-round btn-icon";
            //    btn_devolver.Text = "<span class='btn-inner--icon'><i class='fas fa-reply'></i></span><span class='btn-inner--text'>DEVOLVER PLANILLA</span>";
            //    btn_devolver.Enabled = true;
            //    btn_devolver.Visible = true;
            //    break;

            default:
                break;
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
          "'lengthMenu': [ 10, 25, 50, 75, 100, 200, 300, 1000 ]," +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 100, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('.select2').select2({ dropdownParent: $('#modalVerificarDoc'), placeholder: { id: '0', text: 'Seleccione...' } });");

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
          "'lengthMenu': [ 10, 25, 50, 75, 100, 200, 300, 1000 ]," +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 100, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('.select2').select2({ dropdownParent: $('#modalVerificarDoc'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_afp').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_pre_genero').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
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
                ltl_pl_ue.Text = validarCampo(planillaX["pl_ue"]) + " - " + validarCampo(planillaX["ue"]);
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
                    if (i == 15)
                    {
                        string estado = row.Cells[i].Text;
                        if (estado == "OBSERVADO")
                        {
                            row.CssClass = "grid-row-disabled";
                        }
                        if (estado == "VALIDADO POR RRHH")
                        {
                            row.CssClass = "grid-row-enabled";
                        }
                    }

                }
            }

            verificarPlanillaRRHH();

            listaFiltradoPlanilla(pl_id, es_id, paterno, "C21", "ddl_gv_planilla_paterno", "ap_paterno_x", "ap_paterno_x", " CASE WHEN P.per_id IS NULL AND TPC.tmp_id IS NULL THEN 'ACEFALIA' WHEN P.per_id IS NOT NULL AND TPC.tmp_id IS NULL THEN LTRIM(RTRIM(P.per_ap_paterno)) WHEN P.per_id IS NULL AND TPC.tmp_id IS NOT NULL THEN LTRIM(RTRIM(TPC.tmp_paterno)) END AS ap_paterno_x ");
            listaFiltradoPlanilla(pl_id, es_id, paterno, "C20", "ddl_gv_planilla_cargo", "es_id", "es_descripcion", "ES.es_descripcion, ES.es_id");

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
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
    protected void gv_planilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int index = Convert.ToInt32(e.CommandArgument);
        hf_pre_id.Value = gv_planilla.DataKeys[index].Values[0].ToString();
        hf_fr_id.Value = gv_planilla.DataKeys[index].Values[1].ToString();
        int cp_id = Convert.ToInt32(gv_planilla.DataKeys[index].Values[2].ToString());
        string pre_estado = gv_planilla.DataKeys[index].Values[3].ToString();
        hf_pre_estado.Value = pre_estado;
        switch (e.CommandName)
        {
            case "GetValidar":
                if (pre_estado != null && pre_estado != "")
                {
                    if (pre_estado.Trim() == "V")
                    {
                        cambiarEstadoPC("VR");
                    }
                }
                listarPlanilla(pl_id);
                SetScript("");
                break;
            case "GetAnularObs":
                if (pre_estado != null && pre_estado != "")
                {
                    if (pre_estado.Trim() == "O")
                    {
                        cambiarEstadoPC("V");
                    }
                }
                listarPlanilla(pl_id);
                SetScript("");
                break;
            case "GetObservar":
                if (pre_estado != null && pre_estado != "")
                {
                    if (pre_estado.Trim() == "V" || pre_estado.Trim() == "VR")
                    {
                        cambiarEstadoPC("O");
                    }
                }
                //actualizarEstadoPlanilla();
                informacionPlanilla(pl_id);
                listarPlanilla(pl_id);
                SetScript("");
                break;
            case "GetAssign":
                if (pre_estado != null && pre_estado != "")
                {
                    if (pre_estado.Trim() != "O")
                    {
                        resp_combo = new cls_kd_respuesta_combo { rq_categoria = "PRECONTRATOS" };
                        var requisitos = resp_combo.ListaRequisitos();

                        datosFuncionario();
                        requisitosPresentados(requisitos);
                        sc = "$('#modalVerificarDoc').modal('show');";
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-exclamation', message: 'El Pre-Contrato esta observado no se puede realizar la acción.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });";
                    }
                }
                SetScript(sc);
                break;
            case "GetEditP":
                datosPuesto();
                sc = "$('#modalModificarPuesto').modal('show');";
                SetScript(sc);
                break;
            case "GetEditPersona":
                obtenerDatosFuncionario();
                sc = "$('#modalPersona').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }
    private void obtenerDatosFuncionario()
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_precontrato = precontratado.DatosDetallePrecontrato();
        if (detalle_precontrato.Tables.Count > 0)
        {
            if (detalle_precontrato.Tables[0].Rows.Count > 0)
            {
                var funcionarioX = detalle_precontrato.Tables[0].Rows[0];
                var afp = ddl_afp.Items.FindByValue(validarCampo(funcionarioX["afp_x"]));
                hf_pre_per_id.Value = validarCampo(funcionarioX["per_id"]);
                txt_pre_paterno.Text = validarCampo(funcionarioX["ap_paterno_x"]);
                txt_pre_materno.Text = validarCampo(funcionarioX["ap_materno_x"]);
                txt_pre_nombres.Text = validarCampo(funcionarioX["nombres_x"]);
                txt_pre_ap_casada.Text = validarCampo(funcionarioX["ap_casada_x"]);
                txt_ci.Text = validarCampo(funcionarioX["ci_x"]);
                ddl_pre_genero.SelectedValue = validarCampo(funcionarioX["genero_x"]);
                ddl_afp.SelectedValue = (afp != null) ? validarCampo(funcionarioX["afp_x"]) : "0";
                ddl_afp.Enabled = (validarCampo(funcionarioX["per_id"]) == "0");
                hf_tmp_id.Value = validarCampo(funcionarioX["tmp_id"]);

                string fp_foto = (funcionarioX["fp_foto"] != DBNull.Value && funcionarioX["fp_foto"].ToString().Trim() != "") ? funcionarioX["fp_foto"].ToString().Trim() : "";
                string sexo_int = validarCampo(funcionarioX["genero_x"]);

                if (fp_foto != "")
                {
                    imgFun_int.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])funcionarioX["fp_foto"]);
                }
                else
                {
                    if (sexo_int == "")
                    {
                        imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
                    }
                    else
                    {
                        if (sexo_int == "M")
                        {
                            imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
                        }
                        else
                        {
                            imgFun_int.ImageUrl = "../Content/img/theme/user4.jpg";
                        }
                    }

                }
            }
        }
    }
    private void cambiarEstadoPC(string pre_estado = "")
    {
        precontratado = new cls_pc_precontratado();
        precontratado.pre_id = Convert.ToInt32(hf_pre_id.Value);
        precontratado.pre_estado = pre_estado;
        precontratado.PrecontratoEstadoUDEP();
    }
    private void datosFuncionario()
    {
        precontratado = new cls_pc_precontratado { pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_precontrato = precontratado.DatosPrecontratoUDEP();
        if (detalle_precontrato.Tables[0].Rows.Count > 0)
        {
            var precontrato = detalle_precontrato.Tables[0].Rows[0];
            ltl_ci_val.Text = validarCampo(precontrato["ci_x"]);
            ltl_nombres_val.Text = validarCampo(precontrato["ap_paterno_x"]) + " " + validarCampo(precontrato["ap_materno_x"]) + " " + validarCampo(precontrato["nombres_x"]);
            ltl_genero_val.Text = validarCampo(precontrato["genero_x"]);
            ltl_cargo_val.Text = validarCampo(precontrato["es_descripcion"]);
            ltl_djbr_val.Text = validarCampo(precontrato["pre_presenta_djbr"]);
            ltl_estado_fun.Text = validarCampo(precontrato["estado_fun"]);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
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
    protected void btn_cancelar_puesto_Click(object sender, EventArgs e)
    {
        sc = "$('#modalModificarPuesto').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    protected void btn_cerrar_Click(object sender, EventArgs e)
    {
        SetScript("$('#modalVerificarDoc').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();");
    }
    private void contruirDocumentos()
    {
        resp_combo = new cls_kd_respuesta_combo { rq_categoria = "PRECONTRATOS" };
        var requisitos = resp_combo.ListaRequisitos();
        var combo_resp = resp_combo.ComboRequisitos();

        DataTable lista_docuementos = new DataTable();
        lista_docuementos.Columns.Add("rq_descripcion");
        lista_docuementos.Columns.Add("rc_id");
        DataRow dr = null;

        int nro_requisito = 0;
        if (requisitos.Tables.Count > 0)
        {
            if (requisitos.Tables[0].Rows.Count > 0)
            {
                nro_requisito = requisitos.Tables[0].Rows.Count;
                hf_nro_requisitos.Value = Convert.ToString(nro_requisito);
                DataRow requisito_x = null;

                for (int i = 0; i < nro_requisito; i++)
                {
                    requisito_x = requisitos.Tables[0].Rows[i];
                    var lista_respuesta = construirCombo(validarCampo(requisito_x["rq_id"]), combo_resp);

                    if (lista_respuesta.Rows.Count == 2)
                    {
                        for (int j = 0; j < lista_respuesta.Rows.Count; j++)
                        {

                            if (validarCampo(lista_respuesta.Rows[j]["rc_desc"]) == "NO")
                            {
                                dr = lista_docuementos.NewRow();
                                dr["rq_descripcion"] = validarCampo(requisito_x["rq_descripcion"]);
                                dr["rc_id"] = validarCampo(requisito_x["rq_id"]) + "-" + buscarRespuesta(lista_respuesta, "SI") + "-" + buscarRespuesta(lista_respuesta, "NO");
                                lista_docuementos.Rows.Add(dr);
                            }
                        }
                    }
                }

                string json = JsonConvert.SerializeObject(lista_docuementos);
                if (lista_docuementos.Rows.Count > 0)
                {
                    lb_documentos.DataSource = lista_docuementos;
                    lb_documentos.DataValueField = "rc_id";
                    lb_documentos.DataTextField = "rq_descripcion";
                    lb_documentos.DataBind();

                }
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No existen requisitos por presentar.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }
    private string buscarRespuesta(DataTable lista_respuesta = null, string tipo = "")
    {
        string id = "";

        for (int i = 0; i < lista_respuesta.Rows.Count; i++)
        {
            if (validarCampo(lista_respuesta.Rows[i]["rc_desc"]) == tipo)
            {
                id = validarCampo(lista_respuesta.Rows[i]["rc_id"]);
                break;
            }
        }

        return id;
    }
    private DataTable construirCombo(string nro_requisito = "", DataSet combo_resp = null)
    {
        DataTable lista_respuesta = new DataTable();
        lista_respuesta.Columns.Add("rc_id");
        lista_respuesta.Columns.Add("rc_desc");
        DataRow dr = null;

        if (combo_resp.Tables[0].Rows.Count > 0)
        {
            int nroRespuestas = combo_resp.Tables[0].Rows.Count;
            bool sw_si = false;
            bool sw_no = false;
            for (int i = 0; i < nroRespuestas; i++)
            {
                var respuesta = combo_resp.Tables[0].Rows[i];
                string rc_rq_id = validarCampo(respuesta["rc_rq_id"]);
                if (nro_requisito == rc_rq_id)
                {
                    if (validarCampo(respuesta["rc_desc"]) == "SI")
                    {
                        if (!sw_si)
                        {
                            dr = lista_respuesta.NewRow();
                            dr["rc_id"] = validarCampo(respuesta["rc_id"]);
                            dr["rc_desc"] = validarCampo(respuesta["rc_desc"]);
                            lista_respuesta.Rows.Add(dr);
                            sw_si = true;
                        }
                    }
                    if (validarCampo(respuesta["rc_desc"]) == "NO")
                    {
                        if (!sw_no)
                        {
                            dr = lista_respuesta.NewRow();
                            dr["rc_id"] = validarCampo(respuesta["rc_id"]);
                            dr["rc_desc"] = validarCampo(respuesta["rc_desc"]);
                            lista_respuesta.Rows.Add(dr);
                            sw_no = true;
                        }
                    }

                }
            }
        }
        return lista_respuesta;
    }
    protected void btn_guardar_requisitos_Click(object sender, EventArgs e)
    {
        resp_combo = new cls_kd_respuesta_combo { rq_categoria = "PRECONTRATOS" };
        var requisitos = resp_combo.ListaRequisitos();

        if (requisitos.Tables[0].Rows.Count > 0)
        {
            DataTable lista_respuesta = new DataTable();
            lista_respuesta.Columns.Add("rp_rq_id");
            lista_respuesta.Columns.Add("rp_rc_id");
            DataRow dr = null;

            for (int i = 0; i < requisitos.Tables[0].Rows.Count; i++)
            {
                bool sw = true;
                var detalle_requisito = requisitos.Tables[0].Rows[i];

                int rp_rq_id = 0;
                int rp_rc_id_si = 0;
                int rp_rc_id_no = 0;

                foreach (ListItem item in lb_documentos.Items)
                {
                    string[] words = item.Value.Split('-');
                    rp_rq_id = Convert.ToInt32(words[0]);
                    rp_rc_id_si = Convert.ToInt32(words[1]);
                    rp_rc_id_no = Convert.ToInt32(words[2]);

                    if (rp_rq_id == Convert.ToInt32(validarCampo(detalle_requisito["rq_id"])))
                    {
                        if (item.Selected)
                        {
                            sw = false;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    } 
                }

                if (sw)
                {
                    dr = lista_respuesta.NewRow();
                    dr["rp_rq_id"] = rp_rq_id;
                    dr["rp_rc_id"] = rp_rc_id_si;
                    lista_respuesta.Rows.Add(dr);
                }
            }

            //string json = JsonConvert.SerializeObject(lista_respuesta);

            string json = JsonConvert.SerializeObject(lista_respuesta);
            resp_combo.rp_nombre_pk = "pre_id";
            resp_combo.rp_valor_pk = Convert.ToInt32(hf_pre_id.Value);
            resp_combo.rp_respuesta = json;
            resp_combo.rp_rq_id = 0;
            resp_combo.rp_rc_id = 0;
            resp_combo.rp_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());
            resp_combo.GuardarRequisitosPresentadosUDEP();

            lb_documentos.ClearSelection();
            sc = "Swal.fire({ icon: 'success', title: 'Documentos faltantes, registrado exitosamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalVerificarDoc').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

    }
    private void actualizarEstadoPlanilla()
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        precontratado = new cls_pc_precontratado { pl_id = pl_id + "" };
        var estado = precontratado.ActualizarEstadoPlanillaUDEP();
        string pl_estado = validarCampo(estado.Tables[0].Rows[0]["estado"]);

        planilla = new cls_pc_precontratado { pl_id = Convert.ToString(pl_id), pl_estado = pl_estado };
        var pl = planilla.ActualizarEstadoPlanilla();
        string json = JsonConvert.SerializeObject(pl.Tables[0]);
        AdicionarHistorico("M", "tbl_pc_planilla", "pl_id", Convert.ToString(pl_id), json);
        //string json = JsonConvert.SerializeObject(pl.Tables[0]);
        //AdicionarHistorico("M", "tbl_pc_planilla", "pl_id", Convert.ToString(pl_id), json);
    }
    private void requisitosPresentados(DataSet requisitos = null)
    {
        resp_combo = new cls_kd_respuesta_combo();
        resp_combo.rp_nombre_pk = "pre_id";
        resp_combo.rp_valor_pk = Convert.ToInt32(hf_pre_id.Value);
        var requisitos_presentados = resp_combo.RequisitosPresentadosFun();

        DataTable lista_no_presentado = new DataTable();
        lista_no_presentado.Columns.Add("rp_rq_id");
        DataRow dr = null;
        if (requisitos.Tables[0].Rows.Count > 0 && requisitos_presentados.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < requisitos.Tables[0].Rows.Count; i++)
            {
                var requisito_x = requisitos.Tables[0].Rows[i];

                bool sw = true;
                for (int j = 0; j < requisitos_presentados.Tables[0].Rows.Count; j++)
                {
                    var requisito_presentado_x = requisitos_presentados.Tables[0].Rows[j];

                    if (validarCampo(requisito_presentado_x["rp_rq_id"]) == validarCampo(requisito_x["rq_id"]))
                    {
                        sw = false;
                        break;
                    }
                }

                if (sw)
                {
                    dr = lista_no_presentado.NewRow();
                    dr["rp_rq_id"] = validarCampo(requisito_x["rq_id"]);
                    lista_no_presentado.Rows.Add(dr);
                }
            }
        }
        

        if (lista_no_presentado.Rows.Count > 0)
        {
            for (int i = 0; i < lista_no_presentado.Rows.Count; i++)
            {
                int rp_rq_id = 0;
                int rp_rc_id_si = 0;
                int rp_rc_id_no = 0;

                foreach (ListItem item in lb_documentos.Items)
                {
                    string[] words = item.Value.Split('-');
                    rp_rq_id = Convert.ToInt32(words[0]);
                    rp_rc_id_si = Convert.ToInt32(words[1]);
                    rp_rc_id_no = Convert.ToInt32(words[2]);

                    if (Convert.ToInt32(validarCampo(lista_no_presentado.Rows[i]["rp_rq_id"])) == rp_rq_id)
                    {
                        item.Selected = true;
                        break;
                    }
                }
            }
        }

    }
    protected void btn_enviar_planilla_Click(object sender, EventArgs e)
    {
        sc = "$('#modalEnviar').modal('show');";
        SetScript(sc);
    }

    protected void btn_devolver_Click(object sender, EventArgs e)
    {
        txt_observaciones.Text = string.Empty;
        sc = "$('#modalDevolver').modal('show');";
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
            string correo_recepcion_creador = "";
            string usuario_recepcion_creador = "";
            string correo_recepcion_aprobador = "";
            string usuario_recepcion_aprobador = "";
            string correo_recepcion_validador = "";
            string usuario_recepcion_validador = "";
            for (int i = 0; i < estadosP.Count; i++)
            {
                if (validarCampo(estadosP[i]["seg_accion"]) == "APROBADO")
                {
                    correo_recepcion_aprobador = validarCampo(estadosP[i]["correo_remitente"]);
                    usuario_recepcion_aprobador = validarCampo(estadosP[i]["remitente"]);
                    correo_recepcion_validador = validarCampo(estadosP[i]["correo_recepcion"]);
                    usuario_recepcion_validador = validarCampo(estadosP[i]["recepcion"]);
                }
                if (validarCampo(estadosP[i]["seg_accion"]) == "ENVIADO")
                {
                    us_rec = Convert.ToInt32(validarCampo(estadosP[i]["seg_us_id_remitente"]));
                    correo_recepcion_creador = validarCampo(estadosP[i]["correo_remitente"]);
                    usuario_recepcion_creador = validarCampo(estadosP[i]["remitente"]);
                }
            }

            if (us_rec != 0)
            {
                if (validarCampo(estadosP[0]["seg_accion"]) == "VALIDADO")
                {
                    planilla = new cls_pc_precontratado { pl_id = Convert.ToString(pl_id), pl_estado = "O" };
                    var pl = planilla.ActualizarEstadoPlanilla();
                    string json = JsonConvert.SerializeObject(pl.Tables[0]);
                    AdicionarHistorico("M", "tbl_pc_planilla", "pl_id", Convert.ToString(pl_id), json);

                    planilla.seg_pk_id = pl_id;
                    planilla.seg_us_id_remitente = us_id;
                    planilla.seg_us_id_recepcion = us_rec;
                    planilla.seg_accion = "OBSERVADO";
                    planilla.seg_observaciones = (txt_observaciones.Text.Trim() != "") ? txt_observaciones.Text.ToUpper().Trim() : null;
                    planilla.seg_tabla = "tbl_pc_planilla";
                    planilla.AdicionarSeguimiento();

                    string asunto = "ENVIÓ DE PLANILLA Nº  " + ltl_pl_correlativo.Text;
                    string contenido = "<p>Se le comunica que se devuelve la <strong>Planilla Nº " + ltl_pl_correlativo.Text + "</strong> que fue observado por el motivo:</p><p>" + txt_observaciones.Text.ToUpper().Trim() + "</p><p>Se solicita realizar los ajustes correspondientes.</p>";
                    enviarCorreo(correo_remitente, correo_recepcion_creador, correo_recepcion_aprobador, correo_recepcion_validador, usuario_remitente, usuario_recepcion_creador, usuario_recepcion_aprobador, usuario_recepcion_validador, contenido, asunto);

                    Session["texto_notificacion"] = "Solicitud de ajuste de Planilla enviado correctamente.";
                    Response.Redirect("ListaValidacionDoc");
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
    private void enviarCorreo(string correo_remitente = "", string correo_recepcion_creador = "", string correo_recepcion_aprobador = "", string correo_recepcion_validador = "", string usuario_remitente = "", string usuario_recepcion_creador = "", string usuario_recepcion_aprobador = "", string usuario_recepcion_validador = "", string contenido = "", string asunto = "")
    {
        string h = "http://gmlpsr00001/sigrh3/";
        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        correo.From = new System.Net.Mail.MailAddress(correo_remitente);
        correo.To.Add(correo_recepcion_creador);
        correo.CC.Add(correo_recepcion_aprobador);
        correo.CC.Add(correo_recepcion_validador);
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
        html += "Estimado usuario: <strong>" + usuario_recepcion_creador + "</strong>";
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
    private void AdicionarHistorico(string abm = "", string tabla = "", string nom_pk = "", string val_pk = "", string campos = "")
    {
        historico = new cls_historico
        {
            his_tipo_abm = abm,
            his_nom_tabla = tabla,
            his_nom_pk = nom_pk,
            his_valor_pk = val_pk,
            his_campos = campos,
            his_usuario_creacion = Convert.ToInt32(Session["per_id"])
        };
        historico.Adicionar();
    }

    protected void btn_cancelar_persona_Click(object sender, EventArgs e)
    {
        sc = "$('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_adicionar_funcionario_Click(object sender, EventArgs e)
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        if (hf_pre_per_id.Value != "0")
        {
            sc = "$('#modalGlosa').modal('show');";
            SetScript(sc);
        }
        else
        {
            precontratado = new cls_pc_precontratado
            {
                pre_id = (hf_pre_id.Value != "") ? Convert.ToInt32(hf_pre_id.Value) : 0,
                tmp_id = (hf_tmp_id.Value != "") ? Convert.ToInt32(hf_tmp_id.Value) : 0,
                tmp_ci = txt_ci.Text,
                tmp_ap_paterno = txt_pre_paterno.Text.ToUpper().Trim(),
                tmp_ap_materno = txt_pre_materno.Text.ToUpper().Trim(),
                tmp_nombres = txt_pre_nombres.Text.ToUpper().Trim(),
                tmp_ap_casada = txt_pre_ap_casada.Text.ToUpper().Trim(),
                tmp_sexo = ddl_pre_genero.SelectedValue,
                tmp_afp = ddl_afp.SelectedValue,
                tmp_estado = "V",
                accion = "C51"
            };

            precontratado.ActualizarDatosPersonaUDEP();

            if (hf_pre_estado.Value != null && hf_pre_estado.Value != "")
            {
                if (hf_pre_estado.Value.Trim() == "V" || hf_pre_estado.Value.Trim() == "VR")
                {
                    cambiarEstadoPC("O");
                }
            }
            cambiarEstadoPC("O");
            informacionPlanilla(pl_id);
            listarPlanilla(pl_id);

            sc = "Swal.fire({ icon: 'success', title: 'Datos personales modificados correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            SetScript(sc);
        }


    }
    private void LimpiarGlosa()
    {
        ddl_tipo_documento.Text = "0";
        txt_fechaMov.Text = string.Empty;
        txt_descripcion_add.Text = string.Empty;
    }

    protected void btn_validar_planilla_Click(object sender, EventArgs e)
    {
        hf_val_rrhh.Value = "1";
        sc = "$('#modalConfirmacionV').modal('show');";
        SetScript(sc);
    }
    protected void btn_cancelar_val_Click(object sender, EventArgs e)
    {
        hf_val_rrhh.Value = "0";
        sc = "$('#modalConfirmacionV').modal('hide');";
        SetScript(sc);
    }

    protected void btn_confirmar_val_Click(object sender, EventArgs e)
    {
        sc = "$('#modalGlosa').modal('show');";
        SetScript(sc);
    }
    protected void ddl_tipo_documento_SelectedIndexChanged(object sender, EventArgs e)
    {
        d_num_doc.Visible = false;
        d_tipo_doc.Attributes.Add("class", "col-md-6");
        d_fecha_doc.Attributes.Add("class", "col-md-6");

        switch (ddl_tipo_documento.SelectedValue)
        {
            case "818":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;
                break;

            case "816":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;
                break;
            case "819":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;
                break;
            default:
                break;
        }
        SetScript("");
    }
    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        if (hf_val_rrhh.Value == "1")
        {
            planilla = new cls_pc_precontratado { pl_id = pl_id + "", pl_estado = "VR" };
            var pl = planilla.ActualizarEstadoPlanilla();
            guardarGlosa(pl_id, "pl_id", "tbl_pc_planilla");

            Session["texto_notificacion"] = "Planilla validada correctamente.";
            Response.Redirect("ListaValidacionDoc");
        }
        else
        {
            if (hf_pre_per_id.Value != "")
            {

                precontratado = new cls_pc_precontratado
                {
                    pre_per_id = (hf_pre_per_id.Value != "") ? Convert.ToInt32(hf_pre_per_id.Value) : 0,
                    tmp_ci = txt_ci.Text,
                    tmp_ap_paterno = txt_pre_paterno.Text.ToUpper().Trim(),
                    tmp_ap_materno = txt_pre_materno.Text.ToUpper().Trim(),
                    tmp_nombres = txt_pre_nombres.Text.ToUpper().Trim(),
                    tmp_ap_casada = txt_pre_ap_casada.Text.ToUpper().Trim(),
                    tmp_sexo = ddl_pre_genero.SelectedValue,
                    tmp_afp = ddl_afp.SelectedValue,
                    tmp_estado = "V",
                    accion = "C50"
                };

                precontratado.ActualizarDatosPersonaUDEP();
                guardarGlosa(Convert.ToInt32(hf_pre_per_id.Value), "per_id", "tbl_persona");

                if (hf_pre_estado.Value != null && hf_pre_estado.Value != "")
                {
                    cambiarEstadoPC("O");
                }
                informacionPlanilla(pl_id);
                listarPlanilla(pl_id);

                LimpiarGlosa();
                sc = "Swal.fire({ icon: 'success', title: 'Datos personales modificados correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }}); MostrarMascara(false);";
                SetScript(sc);
            }

        }

    }

    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('hide');";
        SetScript(sc);
    }
    private void restablecerGlosa()
    {
        ddl_tipo_documento.SelectedValue = "0";
        txt_num_doc.Text = "";
        txt_fechaMov.Text = "";
        txt_descripcion_add.Text = "";
        d_num_doc.Visible = false;
        d_tipo_doc.Attributes.Add("class", "col-md-6");
        d_fecha_doc.Attributes.Add("class", "col-md-6");
    }
    private void guardarGlosa(int gl_valor_pk = 0, string gl_nombre_pk = "", string gl_tabla = "")
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;
        glosa = new cls_glosa();
        glosa.gl_valor_pk = gl_valor_pk + "";
        glosa.gl_nombre_pk = gl_nombre_pk;
        glosa.gl_tabla = gl_tabla;
        glosa.gl_tipo_mov = 813;
        glosa.gl_fecha_doc = Convert.ToDateTime(fechaMov);
        glosa.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        glosa.gl_numero_doc = (txt_num_doc.Text.Trim() != "") ? txt_num_doc.Text.Trim() : null;
        glosa.gl_glosa = txt_descripcion_add.Text.Trim().ToUpper();
        glosa.gl_estado = "V";
        glosa.gl_usuario = Convert.ToInt32(Session["us_id"].ToString());
        glosa.Adicionar();
        restablecerGlosa();
    }
}