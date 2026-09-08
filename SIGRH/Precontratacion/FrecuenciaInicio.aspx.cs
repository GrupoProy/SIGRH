using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_Precontratacion.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using System.Text;
using Newtonsoft.Json;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

public partial class Precontratacion_FrecuenciaInicio : System.Web.UI.Page
{
    private cls_pc_frecuencia frecuencia = null;
    private cls_mp_cargo cargo = null;
    private cls_historico historico = null;
    private cls_pc_precontratado precontratado = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
                int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
                int cod_pa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
                informacionCategoria(cp_id);
                listarFrecuencias(cod_pa, pr_id);
                listarResumenFrecuencias(cod_pa, pr_id);
                listarResumenPresup(cod_pa);
                listarResumenPresupGral();
                listaFiltradoCargo(pr_id);
                ver_estado(cod_pa);
                SetScriptInicio("$('.table').DataTable().destroy(); ");
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }
    protected void ver_estado(int cp_id = 0)
    {
        frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id };
        var detalleEstado = frecuencia.VerEstadoCategoria();

        btn_enviar_categoria.Visible = false;
        btn_enviar_categoria.Enabled = false;
        string estado_fr = "";
        if (detalleEstado.Tables.Count > 0)
        {
            if (detalleEstado.Tables[0].Rows.Count > 0)
            {
                var estado = detalleEstado.Tables[0].Rows[0];
                estado_fr = validarCampo(estado["seg_accion"]);
            }
        }
        if (estado_fr == "" || estado_fr == "OBSERVADO")
        {

            btn_enviar_categoria.Enabled = true;
            btn_enviar_categoria.CssClass = "btn btn-slack btn-round btn-icon";
            btn_enviar_categoria.Text = "<span class='btn-inner--icon'><i class='fas fa-share-alt'></i></span><span class='btn-inner--text'>Enviar</span>";
            btn_enviar_categoria.Visible = true;
        }
        else
        {
            if (estado_fr == "ENVIADO")
            {
                btn_enviar_categoria.Enabled = false;
                btn_enviar_categoria.CssClass = "btn btn-slack btn-round btn-icon disabled";
                btn_enviar_categoria.Text = "<span class='btn-inner--icon'><i class='fas fa-share-alt'></i></span><span class='btn-inner--text'>Enviado</span>";
                btn_enviar_categoria.Visible = true;
            }
        }
    }
    protected void gv_frecuencias_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_frecuencias.Rows.Count > 0)
        {
            if (gv_frecuencias.HeaderRow != null)
            {
                gv_frecuencias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_frecuencias.FooterRow != null)
            {
                gv_frecuencias.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }


    private void listarFrecuencias(int cod_pa = 0, int pr_id = 0, int fr_es_id = 0, decimal fr_tiempo = -1, string fr_estado = "L")
    {
        try
        {
            frecuencia = new cls_pc_frecuencia { fr_cod_poa = cod_pa, fr_pr_id = pr_id, fr_es_id = fr_es_id, fr_tiempo = fr_tiempo, fr_estado = fr_estado };
            gv_frecuencias.DataSource = frecuencia.ObtenerFrecuenciasOperacion();
            gv_frecuencias.DataBind();

            d_gv_frecuencias.Visible = (gv_frecuencias.Rows.Count > 0) ? false : true;

            foreach (GridViewRow row in gv_frecuencias.Rows)
            {
                for (int i = 0; i < gv_frecuencias.Columns.Count; i++)
                {
                    if (i == 7)
                    {
                        string estado = row.Cells[i].Text;
                        if (estado != "LIBRE" && estado != "OCUPADO")
                        {
                            row.CssClass = "grid-row-disabled";
                        }
                    }

                }
            }

            listaFiltradoFrec(cod_pa, pr_id, fr_es_id, fr_tiempo, fr_estado, "C37", "ddl_gv_frec_cargo", "es_id", "es_descripcion", "ES.es_descripcion, ES.es_id");
            listaFiltradoFrec(cod_pa, pr_id, fr_es_id, fr_tiempo, fr_estado, "C37", "ddl_gv_frec_tiempo", "fr_tiempo", "fr_tiempo", "F.fr_tiempo");
            //listaFiltradoFrec(cp_id, pr_id, fr_es_id, fr_tiempo, fr_estado, "C22", "ddl_gv_frec_estado", "fr_estado", "fr_estado", "F.fr_estado ");
            //listaFiltradoFrec(cp_id, pr_id, fr_es_id, fr_tiempo, fr_estado, "C22", "ddl_gv_frec_estado", "fr_estado", "fr_estado", "F.fr_estado, CASE WHEN F.fr_estado = ''L'' THEN ''LIBRE'' WHEN F.fr_estado = ''H'' THEN ''HISTÓRICO'' WHEN F.fr_estado = ''O'' THEN ''OCUPADO'' END ");
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaFiltradoFrec(int cod_pa = 0, int pr_id = 0, int fr_es_id = 0, decimal fr_tiempo = -1, string fr_estado = "L", string accion = "", string ddl_id = "", string ddl_value = "", string ddl_desc = "", string q = "")
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cod_poa = cod_pa;
            frecuencia.fr_pr_id = pr_id;
            frecuencia.fr_es_id = fr_es_id;
            frecuencia.fr_tiempo = fr_tiempo;
            frecuencia.fr_estado = fr_estado;
            frecuencia.accion = accion;

            DropDownList ddl = gv_frecuencias.HeaderRow.FindControl(ddl_id) as DropDownList;
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("TODOS", "-1"));
            ddl.DataValueField = ddl_value;
            ddl.DataTextField = ddl_desc;
            ddl.DataSource = frecuencia.ObtenerListaFiltradoFrecuenciaOperacion(q);
            ddl.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
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
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_jornada').select2({ dropdownParent: $('#modalNuevaFrec') });");
        sb.Append("$('#ContentPlaceHolder1_ddl_cargo').select2({ dropdownParent: $('#modalNuevaFrec'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto').select2({ dropdownParent: $('#modalNuevaFrec'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
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
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false }); }");

        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('#ContentPlaceHolder1_gv_frecuencias').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");

        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_jornada').select2({ dropdownParent: $('#modalNuevaFrec') });");
        sb.Append("$('#ContentPlaceHolder1_ddl_cargo').select2({ dropdownParent: $('#modalNuevaFrec'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto').select2({ dropdownParent: $('#modalNuevaFrec'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_usuarios').select2({ dropdownParent: $('#modalEnviar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
        //ScriptManager _scriptMan = ScriptManager.GetCurrent(this);
        //_scriptMan.AsyncPostBackTimeout = 36000;
        //_scriptMan.GetRegisteredClientScriptBlocks
    }
    private void listarResumenFrecuencias(int cod_pa = 0, int pr_id = 0)
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cod_poa = cod_pa;
            frecuencia.fr_pr_id = pr_id;
            var frecuencias_resumen = frecuencia.ObtenerResumenFrecuenciasOperacion();
            gv_fracuencias_resumen.DataSource = frecuencias_resumen;
            gv_fracuencias_resumen.DataBind();

            d_gv_fracuencias_resumen.Visible = (frecuencias_resumen.Tables[0].Rows.Count > 0) ? false : true;
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_fracuencias_resumen_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string fr_es_id = gv_fracuencias_resumen.DataKeys[index].Values[0].ToString();
        string fr_pu_id = gv_fracuencias_resumen.DataKeys[index].Values[1].ToString();
        string fr_tipo_jornada = gv_fracuencias_resumen.DataKeys[index].Values[2].ToString();
        string fr_fecha_inicio = gv_fracuencias_resumen.DataKeys[index].Values[3].ToString();
        string fr_fecha_fin = gv_fracuencias_resumen.DataKeys[index].Values[4].ToString();
        string fr_tiempo = gv_fracuencias_resumen.DataKeys[index].Values[5].ToString();

        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;

        switch (e.CommandName)
        {
            case "GetAdd":
                //adicionarFrecuencia(cp_id, pr_id, fr_es_id, fr_pu_id, fr_tipo_jornada, fr_fecha_inicio, fr_fecha_fin, fr_tiempo);
                adicionarRepplicaFrecuencia(cp_id, pr_id, fr_es_id, fr_pu_id, fr_tipo_jornada, fr_fecha_inicio, fr_fecha_fin, fr_tiempo);
                break;
            case "GetDel":
                eliminarFrecuenciaX(cp_id, pr_id, fr_es_id, fr_pu_id, fr_tipo_jornada, fr_fecha_inicio, fr_fecha_fin, fr_tiempo);
                break;
            case "GetDeleteAll":
                eliminarFrecuenciaAll(cp_id, pr_id, fr_es_id, fr_pu_id, fr_tipo_jornada, fr_fecha_inicio, fr_fecha_fin, fr_tiempo);
                break;
            default:
                break;
        }
    }
    private void adicionarFrecuencia(int cp_id = 0, int pr_id = 0, string fr_es_id = "", string fr_pu_id = "", string fr_tipo_jornada = "", string fr_fecha_inicio = "", string fr_fecha_fin = "", string fr_tiempo = "")
    {
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        frecuencia = new cls_pc_frecuencia
        {
            fr_cp_id = cp_id,
            fr_pr_id = pr_id,
            fr_es_id = Convert.ToInt32(fr_es_id),
            fr_descrip_puesto = fr_pu_id,
            fr_tipo_jornada = fr_tipo_jornada,
            fr_fecha_inicio = fr_fecha_inicio,
            fr_fecha_fin = fr_fecha_fin,
            fr_tiempo = Convert.ToDecimal(fr_tiempo)
        };


        var detalleFrecuencia = frecuencia.ObtenerDetalleReplicaX();
        if (detalleFrecuencia.Tables.Count > 0)
        {
            if (detalleFrecuencia.Tables[0].Rows.Count > 0)
            {
                var frecuencia_x = detalleFrecuencia.Tables[0].Rows[0];
                if (montoValido(cp_id, 1, validarCampo(frecuencia_x["haber_basico"]), validarCampo(frecuencia_x["fr_tipo_jornada"]), validarCampo(frecuencia_x["fr_tiempo"])))
                {

                    frecuencia = new cls_pc_frecuencia();
                    frecuencia.fr_cp_id = cp_id;
                    frecuencia.fr_cod_poa = cod_poa;
                    frecuencia.fr_es_id = Convert.ToInt32(validarCampo(frecuencia_x["fr_es_id"]));
                    frecuencia.fr_tipo_jornada = validarCampo(frecuencia_x["fr_tipo_jornada"]);
                    frecuencia.fr_fecha_inicio = validarCampo(frecuencia_x["fr_fecha_inicio"]);
                    frecuencia.fr_fecha_fin = validarCampo(frecuencia_x["fr_fecha_fin"]);
                    frecuencia.fr_tiempo = Convert.ToDecimal(validarCampo(frecuencia_x["fr_tiempo"]));
                    frecuencia.fr_descrip_puesto = validarCampo(frecuencia_x["fr_pu_descripcion"]);
                    frecuencia.fr_obj_puesto = validarCampo(frecuencia_x["fr_obj_puesto"]);
                    frecuencia.fr_estado = "L";

                    var detalleFrecuencia_replica = frecuencia.Adicionar();
                    var frecuenciaX_replica = detalleFrecuencia_replica.Tables[0].Rows[0];
                    string fr_id_x = validarCampo(frecuenciaX_replica["fr_id"]);
                    string json = JsonConvert.SerializeObject(detalleFrecuencia_replica.Tables[0]);
                    AdicionarHistorico("A", "tbl_pc_frecuencias", "fr_id", Convert.ToString(fr_id_x), json);

                    listarFrecuencias(cod_poa, pr_id);
                    listarResumenFrecuencias(cod_poa, pr_id);
                    listarResumenPresup(cod_poa);
                    listarResumenPresupGral();
                    limpiar();
                    //sc = "Swal.fire({ icon: 'success', title: 'Frecuencia creada exitosamente.', text: 'Registro exitoso', timer: 1400, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                    sc = "$('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $.notify({ icon: 'fa fa-exclamation', message: 'Frecuencia creada exitosamente.'},{type: 'success', placement: { from: 'top', align: 'right'} });";
                    SetScript(sc);
                }
                else
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'El saldo es insuficiente, no se puede realizar la operación.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                    SetScript(sc);
                }
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Error en la operación.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
    }
    private void eliminarFrecuenciaX(int cp_id = 0, int pr_id = 0, string fr_es_id = "", string fr_pu_id = "", string fr_tipo_jornada = "", string fr_fecha_inicio = "", string fr_fecha_fin = "", string fr_tiempo = "")
    {
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        frecuencia = new cls_pc_frecuencia
        {
            fr_cp_id = cp_id,
            fr_pr_id = pr_id,
            fr_es_id = Convert.ToInt32(fr_es_id),
            fr_descrip_puesto = fr_pu_id,
            fr_tipo_jornada = fr_tipo_jornada,
            fr_fecha_inicio = fr_fecha_inicio,
            fr_fecha_fin = fr_fecha_fin,
            fr_tiempo = Convert.ToDecimal(fr_tiempo)
        };


        var detalleFrecuencia = frecuencia.ObtenerDetalleReplicaX();
        if (detalleFrecuencia.Tables.Count > 0)
        {
            if (detalleFrecuencia.Tables[0].Rows.Count > 0)
            {
                var frecuencia_x = detalleFrecuencia.Tables[0].Rows[0];

                frecuencia = new cls_pc_frecuencia { fr_id = Convert.ToInt32(validarCampo(frecuencia_x["fr_id"])) };
                var detalleFrecuencia_replica = frecuencia.EliminarFrecuencia();
                string json = JsonConvert.SerializeObject(detalleFrecuencia_replica.Tables[0]);
                AdicionarHistorico("B", "tbl_pc_frecuencias", "fr_id", validarCampo(frecuencia_x["fr_id"]), json);

                listarFrecuencias(cod_poa, pr_id);
                listarResumenFrecuencias(cod_poa, pr_id);
                listarResumenPresup(cod_poa);
                listarResumenPresupGral();

                sc = "Swal.fire({ icon: 'success', title: 'Frecuencia eliminada exitosamente.', text: 'Registro exitoso', timer: 1400, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarFrecuencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Error en la operación.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
    }
    private void eliminarFrecuenciaAll(int cp_id = 0, int pr_id = 0, string fr_es_id = "", string fr_pu_id = "", string fr_tipo_jornada = "", string fr_fecha_inicio = "", string fr_fecha_fin = "", string fr_tiempo = "")
    {
        hf_fr_es_id.Value = fr_es_id;
        hf_fr_pu_id.Value = fr_pu_id;
        hf_fr_tipo_jornada.Value = fr_tipo_jornada;
        hf_fr_fecha_inicio.Value = fr_fecha_inicio;
        hf_fr_fecha_fin.Value = fr_fecha_fin;
        hf_fr_tiempo.Value = fr_tiempo;
        sc = "$('#eliminarFrecuenciaAll').modal('show');";
        SetScript(sc);
    }
    private void adicionarRepplicaFrecuencia(int cp_id = 0, int pr_id = 0, string fr_es_id = "", string fr_pu_id = "", string fr_tipo_jornada = "", string fr_fecha_inicio = "", string fr_fecha_fin = "", string fr_tiempo = "")
    {
        txt_obj.Text = "";
        hf_fr_es_id.Value = fr_es_id;
        hf_fr_pu_id.Value = fr_pu_id;
        hf_fr_tipo_jornada.Value = fr_tipo_jornada;
        hf_fr_fecha_inicio.Value = fr_fecha_inicio;
        hf_fr_fecha_fin.Value = fr_fecha_fin;
        hf_fr_tiempo.Value = fr_tiempo;
        sc = "$('#objetivoFrecuencia').modal('show');";
        SetScript(sc);
    }
    protected void gv_fracuencias_resumen_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_fracuencias_resumen.Rows.Count > 0)
        {
            if (gv_fracuencias_resumen.HeaderRow != null)
            {
                gv_fracuencias_resumen.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_fracuencias_resumen.FooterRow != null)
            {
                gv_fracuencias_resumen.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_resumen_presup_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_resumen_presup.Rows.Count > 0)
        {
            if (gv_resumen_presup.HeaderRow != null)
            {
                gv_resumen_presup.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_resumen_presup.FooterRow != null)
            {
                gv_resumen_presup.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    private void listarResumenPresup(int cod_poa = 0)
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cod_poa = cod_poa;
            gv_resumen_presup.DataSource = frecuencia.ObtenerComprometidoPorOperacion();
            gv_resumen_presup.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    //private void listarResumenPresupGral()
    //{
    //    int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
    //    int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
    //    try
    //    {
    //        frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id, fr_pr_id = pr_id };
    //        var detalle_categorias = frecuencia.ObtenerCategoriasPresup();
    //        if (detalle_categorias.Tables[0].Rows.Count > 0)
    //        {
    //            var categoria = detalle_categorias.Tables[0].Rows;
    //            DataTable presup_operaciones_total = new DataTable();
    //            presup_operaciones_total.Columns.Add("pp_cp_id");
    //            presup_operaciones_total.Columns.Add("pp_partida");
    //            presup_operaciones_total.Columns.Add("monto");
    //            presup_operaciones_total.Columns.Add("comprometido");
    //            presup_operaciones_total.Columns.Add("saldo");
    //            DataRow dr = null;

    //            for (int i = 0; i < categoria.Count; i++)
    //            {
    //                frecuencia.fr_cp_id = Convert.ToInt32(validarCampo(categoria[i]["cp_id"]));
    //                var detalle_presupuesto_operacion = frecuencia.ObtenerResumenPresup();
    //                if (detalle_presupuesto_operacion.Tables[0].Rows.Count > 0)
    //                {
    //                    var presupuesto_operacion = detalle_presupuesto_operacion.Tables[0].Rows;
    //                    string json = JsonConvert.SerializeObject(detalle_presupuesto_operacion);

    //                    for (int j = 0; j < presupuesto_operacion.Count; j++)
    //                    {
    //                        dr = presup_operaciones_total.NewRow();
    //                        dr["pp_cp_id"] = presupuesto_operacion[j]["pp_cp_id"];
    //                        dr["pp_partida"] = presupuesto_operacion[j]["pp_partida"];
    //                        dr["monto"] = presupuesto_operacion[j]["monto"];
    //                        dr["comprometido"] = presupuesto_operacion[j]["comprometido"];
    //                        dr["saldo"] = presupuesto_operacion[j]["saldo"];
    //                        presup_operaciones_total.Rows.Add(dr);
    //                    }
    //                }
    //            }
    //            string json1 = JsonConvert.SerializeObject(presup_operaciones_total);
    //            //Console.WriteLine(presup_operaciones_total);
    //            var resumen_gral = construirResumen(presup_operaciones_total);
    //            string json2 = JsonConvert.SerializeObject(resumen_gral);
    //            gv_resumen_presup_gral.DataSource = resumen_gral;
    //            gv_resumen_presup_gral.DataBind();
    //        }
    //        //gv_resumen_presup.DataBind();
    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}
    //protected DataTable construirResumen (DataTable pDato = null)
    //{
    //    DataTable presup_gral = new DataTable();
    //    presup_gral.Columns.Add("pp_partida");
    //    presup_gral.Columns.Add("monto");
    //    presup_gral.Columns.Add("comprometido");
    //    presup_gral.Columns.Add("saldo");
    //    DataRow dr = null;

    //    for (int i = 0; i < 5; i++)
    //    {
    //        int partida_x = Convert.ToInt32(validarCampo(pDato.Rows[i]["pp_partida"]));
    //        double sum_monto = 0;
    //        int sum_comprometido = 0;
    //        for (int j = 0; j < pDato.Rows.Count; j++)
    //        {
    //            int partida = Convert.ToInt32(validarCampo(pDato.Rows[j]["pp_partida"]));
    //            double monto = Convert.ToDouble(validarCampo(pDato.Rows[j]["monto"]));
    //            int comprometido = Convert.ToInt32(validarCampo(pDato.Rows[j]["comprometido"]));

    //            if (partida_x == partida)
    //            {
    //                sum_monto = sum_monto + monto;
    //                sum_comprometido = sum_comprometido + comprometido;
    //            }
    //        }
    //        dr = presup_gral.NewRow();
    //        dr["pp_partida"] = partida_x + "";
    //        dr["monto"] = sum_monto;
    //        dr["comprometido"] = sum_comprometido;
    //        dr["saldo"] = sum_monto - sum_comprometido;
    //        presup_gral.Rows.Add(dr);
    //    }
    //    double monto_total = 0;
    //    int comprometido_total = 0;
    //    double saldo_total = 0;
    //    for (int i = 0; i < presup_gral.Rows.Count; i++)
    //    {
    //        double monto = Convert.ToDouble(validarCampo(presup_gral.Rows[i]["monto"]));
    //        int comprometido = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["comprometido"]));
    //        double saldo = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["saldo"]));
    //        monto_total = monto_total + monto;
    //        comprometido_total = comprometido_total + comprometido;
    //        saldo_total = saldo_total + saldo;
    //    }
    //    dr = presup_gral.NewRow();
    //    dr["pp_partida"] = "TOTAL";
    //    dr["monto"] = monto_total;
    //    dr["comprometido"] = comprometido_total;
    //    dr["saldo"] = saldo_total;
    //    presup_gral.Rows.Add(dr);
    //    return presup_gral;
    //}

    private DataTable construirResumenGralPost()
    {
        DataTable resumen_gral = null;
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;

        frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id, fr_pr_id = pr_id };
        var detalle_categorias = frecuencia.ObtenerCategoriasPresup();
        if (detalle_categorias.Tables[0].Rows.Count > 0)
        {
            var categoria = detalle_categorias.Tables[0].Rows;
            DataTable presup_operaciones_total = new DataTable();
            presup_operaciones_total.Columns.Add("pp_cp_id");
            presup_operaciones_total.Columns.Add("pp_partida");
            presup_operaciones_total.Columns.Add("monto");
            presup_operaciones_total.Columns.Add("comprometido");
            presup_operaciones_total.Columns.Add("saldo");
            DataRow dr = null;

            for (int i = 0; i < categoria.Count; i++)
            {
                frecuencia.fr_cp_id = Convert.ToInt32(validarCampo(categoria[i]["cp_id"]));
                var detalle_presupuesto_operacion = frecuencia.ObtenerResumenPresup();
                if (detalle_presupuesto_operacion.Tables[0].Rows.Count > 0)
                {
                    var presupuesto_operacion = detalle_presupuesto_operacion.Tables[0].Rows;
                    string json = JsonConvert.SerializeObject(detalle_presupuesto_operacion);

                    for (int j = 0; j < presupuesto_operacion.Count; j++)
                    {
                        dr = presup_operaciones_total.NewRow();
                        dr["pp_cp_id"] = presupuesto_operacion[j]["pp_cp_id"];
                        dr["pp_partida"] = presupuesto_operacion[j]["pp_partida"];
                        dr["monto"] = presupuesto_operacion[j]["monto"];
                        dr["comprometido"] = presupuesto_operacion[j]["comprometido"];
                        dr["saldo"] = presupuesto_operacion[j]["saldo"];
                        presup_operaciones_total.Rows.Add(dr);
                    }
                }
            }
            resumen_gral = operacionesResumenPost(presup_operaciones_total);
        }
        return resumen_gral;
    }
    protected DataTable operacionesResumenPost(DataTable pDato = null)
    {
        DataTable presup_gral = new DataTable();
        presup_gral.Columns.Add("pp_partida");
        presup_gral.Columns.Add("monto");
        presup_gral.Columns.Add("comprometido");
        presup_gral.Columns.Add("saldo");
        DataRow dr = null;

        for (int i = 0; i < 5; i++)
        {
            int partida_x = Convert.ToInt32(validarCampo(pDato.Rows[i]["pp_partida"]));
            double sum_monto = 0;
            int sum_comprometido = 0;
            for (int j = 0; j < pDato.Rows.Count; j++)
            {
                int partida = Convert.ToInt32(validarCampo(pDato.Rows[j]["pp_partida"]));
                double monto = Convert.ToDouble(validarCampo(pDato.Rows[j]["monto"]));
                int comprometido = Convert.ToInt32(validarCampo(pDato.Rows[j]["comprometido"]));

                if (partida_x == partida)
                {
                    sum_monto = sum_monto + monto;
                    sum_comprometido = sum_comprometido + comprometido;
                }
            }
            dr = presup_gral.NewRow();
            dr["pp_partida"] = partida_x + "";
            dr["monto"] = sum_monto;
            dr["comprometido"] = sum_comprometido;
            dr["saldo"] = sum_monto - sum_comprometido;
            presup_gral.Rows.Add(dr);
        }
        double monto_total = 0;
        int comprometido_total = 0;
        double saldo_total = 0;
        for (int i = 0; i < presup_gral.Rows.Count; i++)
        {
            double monto = Convert.ToDouble(validarCampo(presup_gral.Rows[i]["monto"]));
            int comprometido = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["comprometido"]));
            double saldo = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["saldo"]));
            monto_total = monto_total + monto;
            comprometido_total = comprometido_total + comprometido;
            saldo_total = saldo_total + saldo;
        }
        dr = presup_gral.NewRow();
        dr["pp_partida"] = "TOTAL";
        dr["monto"] = monto_total;
        dr["comprometido"] = comprometido_total;
        dr["saldo"] = saldo_total;
        presup_gral.Rows.Add(dr);
        return presup_gral;
    }

    private void listarResumenPresupGral()
    {
        try
        {
            //int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
            //frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id };
            //var detalle_presupuesto = frecuencia.ObtenerPresupuestoUE();

            //if (detalle_presupuesto.Tables[0].Rows.Count > 0)
            //{
            //    gv_resumen_presup_gral.DataSource = formatearTabla(construirResumenGralPost());
            //    gv_resumen_presup_gral.DataBind();
            //}
            //else
            //{
            //    gv_resumen_presup_gral.DataSource = formatearTabla(construirResumenGral());
            //    gv_resumen_presup_gral.DataBind();
            //}
            gv_resumen_presup_gral.DataSource = construirResumenGral();
            gv_resumen_presup_gral.DataBind();

            foreach (GridViewRow row in gv_resumen_presup_gral.Rows)
            {
                for (int i = 0; i < gv_resumen_presup_gral.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        string partida = row.Cells[i].Text;
                        if (partida == "COMPROMETIDO" || partida == "PRESUPUESTO" || partida == "SALDO")
                        {
                            row.CssClass = "grid-row-water ";
                        }
                        break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected DataTable listarOperaciones()
    {
        int cod_pa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        frecuencia = new cls_pc_frecuencia
        {
            perm_us_id = Convert.ToInt32(Session["us_id"].ToString()),
            fr_pr_id = Convert.ToInt32(Session["pr_id"].ToString()),
        };
        var detalle_persmiso = frecuencia.ObtenerPermisosUE();

        string param = "";
        if (detalle_persmiso.Tables[0].Rows.Count > 0)
        {
            var permisos = detalle_persmiso.Tables[0].Rows;

            for (int i = 0; i < permisos.Count; i++)
            {
                string pcp_ue = validarCampo(permisos[i]["pcp_ue"]);
                param = param + ", '" + pcp_ue + "'";
            }
            param = param.Substring(1, param.Length - 1);
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CnxSimV2"].ConnectionString);
        string q = "SELECT TOP 1 desc_cod_da, nombre_da, desc_cod_ue, nombre_ue, cod_poa, cod_programa, cod_proyecto, cod_actividad, desc_poa, gestion, cod_ue, Expr1, descrip_estado, cod_estado " +
        "FROM[SIMv2].[dbo].[vw_sigrh_sim_operaciones] SO WHERE SO.gestion = @gestion AND SO.cod_poa = @cod_poa";
        SqlCommand command = new SqlCommand(q, connection);

        command.Parameters.Add(new SqlParameter("@gestion", SqlDbType.VarChar, 40)).Value = Session["gestion"].ToString();
        command.Parameters.Add(new SqlParameter("@cod_poa", SqlDbType.VarChar, 40)).Value = cod_pa;
        connection.Open();

        DbDataReader reader = command.ExecuteReader();
        var detalle_operaciones = new DataTable();
        detalle_operaciones.Load(reader);

        return detalle_operaciones;
    }
    protected DataTable construirResumenGral()
    {
        DataTable resumen_gral = null;
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;

        frecuencia = new cls_pc_frecuencia
        {
            fr_cp_id = cp_id
        };
        resumen_gral = frecuencia.ObtenerResumenGral().Tables[0];

        return resumen_gral;
    }
    protected DataTable operacionesResumen(DataTable pDato = null, DataTable presupuesto = null)
    {
        DataTable presup_gral = new DataTable();
        presup_gral.Columns.Add("pp_partida");
        presup_gral.Columns.Add("monto");
        presup_gral.Columns.Add("comprometido");
        presup_gral.Columns.Add("saldo");
        DataRow dr = null;

        for (int i = 0; i < presupuesto.Rows.Count; i++)
        {
            int partida_x = Convert.ToInt32(validarCampo(presupuesto.Rows[i]["pp_partida"]));
            double monto = Convert.ToDouble(validarCampo(presupuesto.Rows[i]["pp_monto"]));
            double sum_comprometido = 0;
            for (int j = 0; j < pDato.Rows.Count; j++)
            {
                int partida = Convert.ToInt32(validarCampo(pDato.Rows[j]["partida"]));
                double comprometido = Convert.ToInt32(validarCampo(pDato.Rows[j]["comprometido"]));

                if (partida_x == partida)
                {
                    sum_comprometido = sum_comprometido + comprometido;
                }
            }
            dr = presup_gral.NewRow();
            dr["pp_partida"] = partida_x + "";
            dr["monto"] = monto;
            dr["comprometido"] = sum_comprometido;
            dr["saldo"] = monto - sum_comprometido;
            presup_gral.Rows.Add(dr);
        }
        double monto_total = 0;
        int comprometido_total = 0;
        double saldo_total = 0;
        for (int i = 0; i < presup_gral.Rows.Count; i++)
        {
            double monto = Convert.ToDouble(validarCampo(presup_gral.Rows[i]["monto"]));
            int comprometido = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["comprometido"]));
            double saldo = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["saldo"]));
            monto_total = monto_total + monto;
            comprometido_total = comprometido_total + comprometido;
            saldo_total = saldo_total + saldo;
        }
        dr = presup_gral.NewRow();
        dr["pp_partida"] = "TOTAL";
        dr["monto"] = monto_total;
        dr["comprometido"] = comprometido_total;
        dr["saldo"] = saldo_total;
        presup_gral.Rows.Add(dr);

        return presup_gral;
    }
    protected DataTable formatearTabla(DataTable pDato = null)
    {
        DataTable presup_gral = new DataTable();
        presup_gral.Columns.Add("pp_partida");
        presup_gral.Columns.Add("monto");
        presup_gral.Columns.Add("comprometido");
        presup_gral.Columns.Add("saldo");
        DataRow dr_partida_copia = null;

        foreach (DataRow dr_partida in pDato.Rows)
        {
            dr_partida_copia = presup_gral.NewRow();
            double monto_final = Convert.ToDouble(validarCampo(dr_partida["monto"]));
            double comprometido_final = Convert.ToDouble(validarCampo(dr_partida["comprometido"]));
            double saldo_final = Convert.ToDouble(validarCampo(dr_partida["saldo"]));
            dr_partida_copia["pp_partida"] = dr_partida["pp_partida"];
            dr_partida_copia["monto"] = String.Format("{0:N2}", monto_final);
            dr_partida_copia["comprometido"] = String.Format("{0:N2}", comprometido_final);
            dr_partida_copia["saldo"] = String.Format("{0:N2}", saldo_final);
            presup_gral.Rows.Add(dr_partida_copia);
        }
        return presup_gral;
    }
    protected void gv_resumen_presup_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void informacionCategoria(int cp_id = 0)
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_cp_id = cp_id;
        var detalleCategoria = frecuencia.ObtenerInformacionCategoria();
        if (detalleCategoria.Tables.Count > 0)
        {
            if (detalleCategoria.Tables[0].Rows.Count > 0)
            {
                var categoria = detalleCategoria.Tables[0].Rows[0];
                ltl_da.Text = validarCampo(categoria["cp_da"]);
                ltl_ue.Text = validarCampo(categoria["cp_ue"]);

                ltl_fuente.Text = validarCampo(categoria["cp_fuente"]);
                ltl_org.Text = validarCampo(categoria["cp_organismo"]);
                ltl_desc.Text = validarCampo(listarOperaciones().Rows[0]["desc_poa"]);
            }
        }
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

    protected void btn_nueva_frecuencia_Click(object sender, EventArgs e)
    {
        hf_editar_fr.Value = "0";
        txt_cantidad.Enabled = true;
        sc = "$('#modalNuevaFrec').modal('show');";
        SetScript(sc);
    }
    private void listaFiltradoCargo(int gestionFiltrar = 0)
    {
        try
        {
            cargo = new cls_mp_cargo();
            cargo.gestion_selec = Convert.ToString(gestionFiltrar);

            ddl_cargo.Items.Clear();
            ddl_cargo.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_cargo.DataValueField = "es_id";
            ddl_cargo.DataTextField = "es_descripcion";
            ddl_cargo.DataSource = cargo.ObtenerFiltradoCargoUO();
            ddl_cargo.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaFiltradoPuesto()
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"]) : 0;
            frecuencia.fr_es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
            var puestos = frecuencia.ObtenerListaFiltradoPuesto();

            ddl_puesto.Items.Clear();
            ddl_puesto.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_puesto.DataValueField = "pu_id";
            ddl_puesto.DataTextField = "pu_descripcion";
            ddl_puesto.DataSource = puestos;
            ddl_puesto.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void btn_cancelar_frecuencia_Click(object sender, EventArgs e)
    {
        txt_cantidad.Enabled = true;
        limpiar();
        sc = " $('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    protected void ddl_cargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
        var detallehaberBasico = frecuencia.ObtenerHaberBasico();
        if (detallehaberBasico.Tables.Count > 0)
        {
            if (detallehaberBasico.Tables[0].Rows.Count > 0)
            {
                var hb = detallehaberBasico.Tables[0].Rows[0];
                decimal haberBasicoAsignarVista = Convert.ToDecimal(validarCampo(hb["ns_haber_basico"]));
                haberBasicoAsignarVista = Math.Round(haberBasicoAsignarVista, 2);
                ltl_haber_basico.Text = Convert.ToString(haberBasicoAsignarVista);
                hf_haber_basico.Value = Convert.ToString(haberBasicoAsignarVista);
            }
        }

        listaFiltradoPuesto();
        ddl_tipo_jornada.Focus();
        calcularHB();
        SetScript("");
    }

    protected void ddl_tipo_jornada_SelectedIndexChanged(object sender, EventArgs e)
    {
        calcularHB();
        txt_fecha_inicio.Focus();
        SetScript("");
    }
    protected void calcularHB()
    {
        if (hf_haber_basico.Value != "")
        {
            decimal hb = Convert.ToDecimal(hf_haber_basico.Value);
            if (ddl_tipo_jornada.SelectedValue == "MT")
            {
                hb = Math.Round(hb / 2, 0);
                string hb_round = String.Format("{0:0.00}", hb);
                ltl_haber_basico.Text = Convert.ToString(hb_round);
            }
            else
            {
                ltl_haber_basico.Text = Convert.ToString(hb);
            }
        }
    }

    protected void txt_fecha_inicio_TextChanged(object sender, EventArgs e)
    {
        DateTime startDate;
        DateTime endDate;

        if ((DateTime.TryParse(txt_fecha_inicio.Text, out startDate)) && (DateTime.TryParse(txt_fecha_fin.Text, out endDate)))
        {
            startDate = Convert.ToDateTime(txt_fecha_inicio.Text);
            endDate = Convert.ToDateTime(txt_fecha_fin.Text);
            double diferencia = (endDate - startDate).TotalDays;
            if (diferencia >= 0)
            {
                ltl_tiempo_estimado.Text = calcularTiempoMeses();
            }
            else
            {
                ltl_tiempo_estimado.Text = "";
            }
        }
        txt_fecha_fin.Focus();
        SetScript("");
    }

    protected void txt_fecha_fin_TextChanged(object sender, EventArgs e)
    {
        DateTime startDate;
        DateTime endDate;

        if ((DateTime.TryParse(txt_fecha_inicio.Text, out startDate)) && (DateTime.TryParse(txt_fecha_fin.Text, out endDate)))
        {
            startDate = Convert.ToDateTime(txt_fecha_inicio.Text);
            endDate = Convert.ToDateTime(txt_fecha_fin.Text);
            double diferencia = (endDate - startDate).TotalDays;
            if (diferencia >= 0)
            {
                ltl_tiempo_estimado.Text = calcularTiempoMeses();
            }
            else
            {
                ltl_tiempo_estimado.Text = "";
            }
        }
        txt_cantidad.Focus();
        SetScript("");
    }
    protected string calcularTiempoMeses()
    {
        string tiempo = "";
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_fecha_inicio = txt_fecha_inicio.Text;
        frecuencia.fr_fecha_fin = txt_fecha_fin.Text;

        var detalleTiempoMes = frecuencia.ObtenerTiempoMeses();
        if (detalleTiempoMes.Tables.Count > 0)
        {
            if (detalleTiempoMes.Tables[0].Rows.Count > 0)
            {
                var tiempoMes = detalleTiempoMes.Tables[0].Rows[0];
                tiempo = validarCampo(tiempoMes["meses"]);
            }
        }
        return tiempo;
    }
    protected void btn_adicionar_frecuencia_Click(object sender, EventArgs e)
    {
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        string tiempo = calcularTiempoMeses();

        if (gestionCorrecto())
        {
            if (fechaCorrecto())
            {
                if (hf_editar_fr.Value == "0")
                {
                    int cantidad = Convert.ToInt32(txt_cantidad.Text);
                    if (cantidad > 0)
                    {
                        if (montoValido(cp_id, cantidad, hf_haber_basico.Value, ddl_tipo_jornada.SelectedValue, tiempo))
                        {
                            for (int i = 0; i < cantidad; i++)
                            {
                                frecuencia = new cls_pc_frecuencia();
                                frecuencia.fr_cp_id = cp_id;
                                frecuencia.fr_cod_poa = cod_poa;
                                frecuencia.fr_es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
                                frecuencia.fr_tipo_jornada = ddl_tipo_jornada.SelectedValue;
                                frecuencia.fr_fecha_inicio = txt_fecha_inicio.Text;
                                frecuencia.fr_fecha_fin = txt_fecha_fin.Text;
                                frecuencia.fr_tiempo = (tiempo != "") ? Convert.ToDecimal(tiempo) : 0;
                                frecuencia.fr_descrip_puesto = ddl_puesto.SelectedItem.Text;
                                frecuencia.fr_obj_puesto = txt_objetivo.Text;
                                frecuencia.fr_estado = "L";

                                var detalleFrecuencia = frecuencia.Adicionar();
                                var frecuenciaX = detalleFrecuencia.Tables[0].Rows[0];
                                string fr_id_x = validarCampo(frecuenciaX["fr_id"]);
                                string json = JsonConvert.SerializeObject(detalleFrecuencia.Tables[0]);
                                AdicionarHistorico("A", "tbl_pc_frecuencias", "fr_id", Convert.ToString(fr_id_x), json);

                            }
                            listarFrecuencias(cod_poa, pr_id);
                            listarResumenFrecuencias(cod_poa, pr_id);
                            listarResumenPresup(cod_poa);
                            listarResumenPresupGral();
                            limpiar();
                            //sc = "Swal.fire({ icon: 'success', title: 'Frecuencia creada exitosamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                            sc = "$('#objetivoFrecuencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $.notify({ icon: 'fa fa-exclamation', message: 'Frecuencia creada exitosamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });";
                            SetScript(sc);
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'El saldo es insuficiente, no se puede realizar la operación.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                            SetScript(sc);
                        }
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-exclamation', message: 'La cantidad no es valida.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                        SetScript(sc);
                    }
                }
                else
                {
                    if (montoValidoEditar(cp_id, 1, hf_haber_basico.Value, ddl_tipo_jornada.SelectedValue, tiempo))
                    {
                        frecuencia = new cls_pc_frecuencia();
                        frecuencia.fr_id = Convert.ToInt32(hf_fr_id.Value);
                        frecuencia.fr_cp_id = cp_id;
                        frecuencia.fr_cod_poa = cod_poa;
                        frecuencia.fr_es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
                        frecuencia.fr_tipo_jornada = ddl_tipo_jornada.SelectedValue;
                        frecuencia.fr_fecha_inicio = txt_fecha_inicio.Text;
                        frecuencia.fr_fecha_fin = txt_fecha_fin.Text;
                        frecuencia.fr_tiempo = (tiempo != "") ? Convert.ToDecimal(tiempo) : 0;
                        frecuencia.fr_descrip_puesto = ddl_puesto.SelectedItem.Text;
                        frecuencia.fr_obj_puesto = txt_objetivo.Text;
                        frecuencia.fr_estado = "L";

                        var detalleFrecuencia = frecuencia.ActualizarFrecuencia();
                        string json = JsonConvert.SerializeObject(detalleFrecuencia.Tables[0]);
                        AdicionarHistorico("M", "tbl_pc_frecuencias", "fr_id", Convert.ToString(hf_fr_id.Value), json);

                        listarFrecuencias(cod_poa, pr_id);
                        listarResumenFrecuencias(cod_poa, pr_id);
                        listarResumenPresup(cod_poa);
                        listarResumenPresupGral();
                        limpiar();
                        sc = "Swal.fire({ icon: 'success', title: 'Frecuencia modificada exitosamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                        SetScript(sc);
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-exclamation', message: 'El saldo es insuficiente, no se puede realizar la operación.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                        SetScript(sc);
                    }

                }
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'La fecha de inicio debe ser menor a la fecha fin.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Las fechas deben ser del mismo periodo seleccionado.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }


    }
    protected void gv_frecuencias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_fr_id.Value = gv_frecuencias.DataKeys[index].Values[0].ToString();

        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarFrecuencia').modal('show');";
                SetScript(sc);
                break;
            case "GetEdit":
                hf_editar_fr.Value = "1";
                obtenerFrecuenciaX();
                break;
            default:
                break;
        }
    }

    protected void btn_eilminar_frec_Click(object sender, EventArgs e)
    {
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_id = Convert.ToInt32(hf_fr_id.Value);

        var detalleFrecuencia = frecuencia.EliminarFrecuencia();
        string json = JsonConvert.SerializeObject(detalleFrecuencia.Tables[0]);
        AdicionarHistorico("B", "tbl_pc_frecuencias", "fr_id", Convert.ToString(hf_fr_id.Value), json);

        listarFrecuencias(cod_poa, pr_id);
        listarResumenFrecuencias(cod_poa, pr_id);
        listarResumenPresup(cod_poa);
        listarResumenPresupGral();

        sc = "Swal.fire({ icon: 'success', title: 'Frecuencia eliminada exitosamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarFrecuencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }
    protected void obtenerFrecuenciaX()
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_id = Convert.ToInt32(hf_fr_id.Value);
        var detalleFrecuencia = frecuencia.ObtenerFrecuenciaX();
        if (detalleFrecuencia.Tables.Count > 0)
        {
            if (detalleFrecuencia.Tables[0].Rows.Count > 0)
            {
                var frecuencia = detalleFrecuencia.Tables[0].Rows[0];
                string tipo_jor = validarCampo(frecuencia["fr_tipo_jornada"]);

                decimal hb = Convert.ToDecimal(validarCampo(frecuencia["haber_basico"]));
                hb = Math.Round(hb, 0);
                decimal hb_pr = (tipo_jor == "MT") ? Math.Round((hb / 2), 0) : hb;
                string hb_round = String.Format("{0:0.00}", hb_pr);
                ltl_haber_basico.Text = Convert.ToString(hb_round);
                hf_haber_basico.Value = Convert.ToString(String.Format("{0:0.00}", hb));

                ddl_cargo.SelectedValue = validarCampo(frecuencia["es_id"]);
                ddl_tipo_jornada.SelectedValue = (ddl_tipo_jornada.Items.FindByValue(tipo_jor) != null) ? tipo_jor : "TC";
                txt_fecha_inicio.Text = validarCampo(frecuencia["fr_fecha_inicio"]);
                txt_fecha_fin.Text = validarCampo(frecuencia["fr_fecha_fin"]);
                ltl_tiempo_estimado.Text = validarCampo(frecuencia["fr_tiempo"]);

                listaFiltradoPuesto();
                var puesto = ddl_puesto.Items.FindByText(validarCampo(frecuencia["pu_id"]));
                ddl_puesto.SelectedValue = (puesto != null) ? puesto.Value : "0";
                txt_objetivo.Text = validarCampo(frecuencia["fr_obj_puesto"]);

                txt_cantidad.Text = "1";
                txt_cantidad.Enabled = false;
                txt_cantidad.CssClass = "form-control numero";

                hf_tipo_jornada_edit.Value = tipo_jor;
                hf_tiempo_edit.Value = validarCampo(frecuencia["fr_tiempo"]);
                hf_hb_edit.Value = Convert.ToString(hb_round);
            }
        }


        SetScript("$('#modalNuevaFrec').modal('show');");
    }
    protected void limpiar()
    {
        ddl_cargo.SelectedValue = "0";
        ddl_tipo_jornada.SelectedValue = "TC";
        ltl_haber_basico.Text = "";
        txt_fecha_inicio.Text = "";
        txt_fecha_fin.Text = "";
        ltl_tiempo_estimado.Text = "";
        txt_cantidad.Text = "";
        ddl_puesto.SelectedValue = "0";
        txt_objetivo.Text = "";
        hf_haber_basico.Value = "";

        hf_tipo_jornada_edit.Value = "";
        hf_tiempo_edit.Value = "";
        hf_hb_edit.Value = "";
    }
    protected bool montoValidoEditar(int cp_id = 0, int cantidad_x = 0, string haber_basico = "", string tipo_jornada = "", string tiempo = "")
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_cp_id = cp_id;
        var detallePresup = frecuencia.ObtenerSaldoCategoria();

        int cantidad = cantidad_x;
        decimal haber_basico_x = Convert.ToDecimal(haber_basico);
        haber_basico_x = (tipo_jornada != "MT") ? haber_basico_x : (haber_basico_x / 2);
        decimal tiempo_estimado = Convert.ToDecimal(tiempo);
        decimal comprometido = (tiempo_estimado * haber_basico_x) * cantidad;

        decimal hb_edit_ant = Convert.ToDecimal(hf_hb_edit.Value);
        decimal tiempo_estimado_ant = Convert.ToDecimal(hf_tiempo_edit.Value);
        decimal comprometido_ant = tiempo_estimado_ant * hb_edit_ant;

        bool sw = true;

        if (detallePresup.Tables[0].Rows.Count > 0)
        {
            var presup = detallePresup.Tables[0].Rows[0];
            decimal saldo_part_presup = (validarCampo(presup["monto"]) != "") ? Convert.ToDecimal(validarCampo(presup["monto"])) : 0;
            saldo_part_presup = saldo_part_presup + (comprometido_ant + ((comprometido_ant) * Convert.ToDecimal(0.0833333))) + (comprometido_ant * Convert.ToDecimal(0.1)) + (comprometido_ant * Convert.ToDecimal(0.0171)) + (comprometido_ant * Convert.ToDecimal(0.03)) + (comprometido_ant * Convert.ToDecimal(0.02));

            comprometido = ((comprometido + ((comprometido) * Convert.ToDecimal(0.0833333))) + (comprometido * Convert.ToDecimal(0.1)) + (comprometido * Convert.ToDecimal(0.0171)) + (comprometido * Convert.ToDecimal(0.03)) + (comprometido * Convert.ToDecimal(0.02)));
            saldo_part_presup = saldo_part_presup - comprometido;
            sw = (saldo_part_presup >= 0) ? true : false;
        }
        return sw;
    }
    protected bool montoValido(int cp_id = 0, int cantidad_x = 0, string haber_basico = "", string tipo_jornada = "", string tiempo = "")
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_cp_id = cp_id;
        var detallePresup = frecuencia.ObtenerSaldoCategoria();

        int cantidad = cantidad_x;
        decimal haber_basico_x = Convert.ToDecimal(haber_basico);
        haber_basico_x = (tipo_jornada != "MT") ? haber_basico_x : (haber_basico_x / 2);
        decimal tiempo_estimado = Convert.ToDecimal(tiempo);
        decimal comprometido = (tiempo_estimado * haber_basico_x) * cantidad;

        bool sw = true;

        if (detallePresup.Tables[0].Rows.Count > 0)
        {
            var presup = detallePresup.Tables[0].Rows[0];
            decimal saldo_part_presup = (validarCampo(presup["monto"]) != "") ? Convert.ToDecimal(validarCampo(presup["monto"])) : 0;

            comprometido = ((comprometido + ((comprometido) * Convert.ToDecimal(0.0833333))) + (comprometido * Convert.ToDecimal(0.1)) + (comprometido * Convert.ToDecimal(0.0171)) + (comprometido * Convert.ToDecimal(0.03)) + (comprometido * Convert.ToDecimal(0.02)));
            saldo_part_presup = saldo_part_presup - comprometido;
            sw = (saldo_part_presup >= 0) ? true : false;
        }

        return sw;
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

    protected void ddl_gv_frec_cargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        DropDownList ddl_gv_frec_cargo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;
        DropDownList ddl_gv_frec_tiempo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_tiempo") as DropDownList;
        //DropDownList ddl_gv_frec_estado = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_estado") as DropDownList;

        int fr_es_id = (ddl_gv_frec_cargo.SelectedValue != "-1") ? Convert.ToInt32(ddl_gv_frec_cargo.SelectedValue) : 0;
        decimal fr_tiempo = (ddl_gv_frec_tiempo.SelectedValue != "-1") ? Convert.ToDecimal(ddl_gv_frec_tiempo.SelectedValue) : -1;
        //string fr_estado = (ddl_gv_frec_estado.SelectedValue != "-1") ? ddl_gv_frec_estado.SelectedValue : "";

        string fr_es_id_v = (ddl_gv_frec_cargo.SelectedValue != "-1") ? ddl_gv_frec_cargo.SelectedValue : "-1";
        string fr_tiempo_v = (ddl_gv_frec_tiempo.SelectedValue != "-1") ? ddl_gv_frec_tiempo.SelectedValue : "-1";
        //string fr_estado_v = (ddl_gv_frec_estado.SelectedValue != "-1") ? ddl_gv_frec_estado.SelectedValue : "-1";

        listarFrecuencias(cod_poa, pr_id, fr_es_id, fr_tiempo, "L");

        DropDownList ddl_gv_frec_cargo_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;
        DropDownList ddl_gv_frec_tiempo_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_tiempo") as DropDownList;
        DropDownList ddl_gv_frec_estado_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_estado") as DropDownList;
        ddl_gv_frec_cargo_after.SelectedValue = fr_es_id_v;
        ddl_gv_frec_tiempo_after.SelectedValue = fr_tiempo_v;
        //ddl_gv_frec_estado_after.SelectedValue = fr_estado_v;
        SetScript("");
    }
    private bool gestionCorrecto()
    {
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        bool sw = false;

        precontratado = new cls_pc_precontratado { pr_id = pr_id };
        var detalle_gestion = precontratado.ObtenerGestion();
        string gestion_x = "";
        if (detalle_gestion.Tables.Count > 0)
        {
            if (detalle_gestion.Tables[0].Rows.Count > 0)
            {
                var gestion = detalle_gestion.Tables[0].Rows[0];
                gestion_x = validarCampo(gestion["pr_gestion"]);
            }
        }

        DateTime fecha_inicio = Convert.ToDateTime(txt_fecha_inicio.Text);
        DateTime fecha_fin = Convert.ToDateTime(txt_fecha_fin.Text);

        if (fecha_inicio.Year.ToString() == gestion_x && fecha_fin.Year.ToString() == gestion_x)
        {
            sw = true;
        }

        return sw;
    }
    private bool fechaCorrecto()
    {
        bool sw = false;
        DateTime startDate = Convert.ToDateTime(txt_fecha_inicio.Text);
        DateTime endDate = Convert.ToDateTime(txt_fecha_fin.Text);
        double diferencia = (endDate - startDate).TotalDays + 1;

        if (diferencia >= 1)
        {
            sw = true;
        }

        return sw;
    }
    protected void btn_enviar_categoria_Click(object sender, EventArgs e)
    {
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        if (gv_frecuencias.Rows.Count > 0)
        {
            frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id, fr_pr_id = pr_id, perm_us_id = us_id };
            ddl_usuarios.Items.Clear();
            ddl_usuarios.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_usuarios.DataValueField = "usuario";
            ddl_usuarios.DataTextField = "nombre_fun";
            ddl_usuarios.DataSource = frecuencia.ObtenerUsuarios();
            ddl_usuarios.DataBind();

            sc = "$('#modalEnviar').modal('show');";
            SetScript(sc);

        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message: 'No se puede enviar la planilla.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }
    protected void btn_confirmar_envio_Click(object sender, EventArgs e)
    {
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        string correo_remitente = (Session["correo"] != null) ? Session["correo"].ToString() : "";
        string usuario_remitente = (Session["per_nombres"] != null) ? Session["per_nombres"].ToString() : "";

        precontratado = new cls_pc_precontratado();

        string usuario = (ddl_usuarios.SelectedValue);
        string[] words = usuario.Split('-');
        string us_id_r = words[0].Trim();

        string correo_recepcion = words[1].Trim();
        string usuario_recepcion = ddl_usuarios.SelectedItem.Text;
        precontratado.seg_pk_id = Convert.ToInt32(cod_poa);
        precontratado.seg_us_id_remitente = us_id;
        precontratado.seg_us_id_recepcion = Convert.ToInt32(us_id_r);
        precontratado.seg_accion = "ENVIADO";
        precontratado.seg_observaciones = null;
        precontratado.seg_tabla = "tbl_pc_frecuencias";
        precontratado.AdicionarSeguimiento();

        frecuencia = new cls_pc_frecuencia { fr_cp_id = cod_poa };
        var detalleEstado = frecuencia.VerEstadoCategoria();
        string verbo = (validarCampo(detalleEstado.Tables[0].Rows[0]["seg_accion"]) != "OBSERVADO") ? "registró " : "ajustó";
        string contenido = "<p>Se le comunica que se " + verbo + " las frecuencias de <strong>DA: " + ltl_da.Text + " , UE:" + ltl_ue.Text + ", COD. POA: " + cod_poa + "</strong>, por el usuario <strong>" + usuario_remitente + "</strong> para su revisión y validación.</p>";
        enviarCorreo(correo_remitente, correo_recepcion, usuario_remitente, usuario_recepcion, contenido);

        Session["texto_notificacion"] = "Frecuencias enviadas correctamente.";
        Response.Redirect("ListaFrecuenciaInicio");
    }
    private void enviarCorreo(string correo_remitente = "", string correo_recepcion = "", string usuario_remitente = "", string usuario_recepcion = "", string contenido = "")
    {
        string h = "http://gmlpsr00001/sigrh3/";
        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        correo.From = new System.Net.Mail.MailAddress(correo_remitente);
        correo.To.Add(correo_recepcion);
        correo.Subject = "SOLICITUD DE REVISIÓN Y VALIDACIÓN DE FRECUENCIAS ";
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
    protected void btn_cancelar_envio_Click(object sender, EventArgs e)
    {
        sc = "$('#modalEnviar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_eliminar_frec_all_Click(object sender, EventArgs e)
    {
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;

        frecuencia = new cls_pc_frecuencia
        {
            fr_cp_id = cp_id,
            fr_pr_id = pr_id,
            fr_es_id = Convert.ToInt32(hf_fr_es_id.Value),
            fr_descrip_puesto = hf_fr_pu_id.Value,
            fr_tipo_jornada = hf_fr_tipo_jornada.Value,
            fr_fecha_inicio = hf_fr_fecha_inicio.Value,
            fr_fecha_fin = hf_fr_fecha_fin.Value,
            fr_tiempo = Convert.ToDecimal(hf_fr_tiempo.Value)
        };

        var detalleFrecuencia = frecuencia.ObtenerDetalleReplicaX();
        if (detalleFrecuencia.Tables.Count > 0)
        {
            if (detalleFrecuencia.Tables[0].Rows.Count > 0)
            {
                var frecuencia_x = detalleFrecuencia.Tables[0].Rows;
                for (int i = 0; i < frecuencia_x.Count; i++)
                {
                    frecuencia = new cls_pc_frecuencia { fr_id = Convert.ToInt32(validarCampo(frecuencia_x[i]["fr_id"])) };
                    var detalleFrecuencia_replica = frecuencia.EliminarFrecuencia();
                    string json = JsonConvert.SerializeObject(detalleFrecuencia_replica.Tables[0]);
                    AdicionarHistorico("B", "tbl_pc_frecuencias", "fr_id", validarCampo(frecuencia_x[i]["fr_id"]), json);
                }

                listarFrecuencias(cod_poa, pr_id);
                listarResumenFrecuencias(cod_poa, pr_id);
                listarResumenPresup(cod_poa);
                listarResumenPresupGral();

                sc = "Swal.fire({ icon: 'success', title: 'Frecuencia(s) eliminada exitosamente.', text: 'Registro exitoso', timer: 1400, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarFrecuenciaAll').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Error en la operación.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
    }

    protected void gv_resumen_presup_gral_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_resumen_presup_gral.Rows.Count > 0)
        {
            if (gv_resumen_presup_gral.HeaderRow != null)
            {
                gv_resumen_presup_gral.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_resumen_presup_gral.FooterRow != null)
            {
                gv_resumen_presup_gral.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void btn_confirmar_replica_Click(object sender, EventArgs e)
    {
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;

        int fr_es_id = Convert.ToInt32(hf_fr_es_id.Value);
        string fr_pu_id = hf_fr_pu_id.Value;
        string fr_tipo_jornada = hf_fr_tipo_jornada.Value;
        string fr_fecha_inicio = hf_fr_fecha_inicio.Value;
        string fr_fecha_fin = hf_fr_fecha_fin.Value;
        string fr_tiempo = hf_fr_tiempo.Value;

        frecuencia = new cls_pc_frecuencia
        {
            fr_cp_id = cp_id,
            fr_pr_id = pr_id,
            fr_es_id = Convert.ToInt32(fr_es_id),
            fr_descrip_puesto = fr_pu_id,
            fr_tipo_jornada = fr_tipo_jornada,
            fr_fecha_inicio = fr_fecha_inicio,
            fr_fecha_fin = fr_fecha_fin,
            fr_tiempo = Convert.ToDecimal(fr_tiempo)
        };


        var detalleFrecuencia = frecuencia.ObtenerDetalleReplicaX();
        if (detalleFrecuencia.Tables.Count > 0)
        {
            if (detalleFrecuencia.Tables[0].Rows.Count > 0)
            {
                var frecuencia_x = detalleFrecuencia.Tables[0].Rows[0];
                if (montoValido(cp_id, 1, validarCampo(frecuencia_x["haber_basico"]), validarCampo(frecuencia_x["fr_tipo_jornada"]), validarCampo(frecuencia_x["fr_tiempo"])))
                {

                    frecuencia = new cls_pc_frecuencia();
                    frecuencia.fr_cp_id = cp_id;
                    frecuencia.fr_cod_poa = cod_poa;
                    frecuencia.fr_es_id = Convert.ToInt32(validarCampo(frecuencia_x["fr_es_id"]));
                    frecuencia.fr_tipo_jornada = validarCampo(frecuencia_x["fr_tipo_jornada"]);
                    frecuencia.fr_fecha_inicio = validarCampo(frecuencia_x["fr_fecha_inicio"]);
                    frecuencia.fr_fecha_fin = validarCampo(frecuencia_x["fr_fecha_fin"]);
                    frecuencia.fr_tiempo = Convert.ToDecimal(validarCampo(frecuencia_x["fr_tiempo"]));
                    frecuencia.fr_descrip_puesto = validarCampo(frecuencia_x["fr_pu_descripcion"]);
                    frecuencia.fr_obj_puesto = txt_obj.Text.Trim().ToUpper();
                    frecuencia.fr_estado = "L";

                    var detalleFrecuencia_replica = frecuencia.Adicionar();
                    var frecuenciaX_replica = detalleFrecuencia_replica.Tables[0].Rows[0];
                    string fr_id_x = validarCampo(frecuenciaX_replica["fr_id"]);
                    string json = JsonConvert.SerializeObject(detalleFrecuencia_replica.Tables[0]);
                    AdicionarHistorico("A", "tbl_pc_frecuencias", "fr_id", Convert.ToString(fr_id_x), json);

                    listarFrecuencias(cod_poa, pr_id);
                    listarResumenFrecuencias(cod_poa, pr_id);
                    listarResumenPresup(cod_poa);
                    listarResumenPresupGral();
                    limpiar();
                    txt_obj.Text = "";
                    //sc = "Swal.fire({ icon: 'success', title: 'Frecuencia creada exitosamente.', text: 'Registro exitoso', timer: 1400, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                    sc = "$('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $.notify({ icon: 'fa fa-exclamation', message: 'Frecuencia creada exitosamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });";
                    SetScript(sc);
                }
                else
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'El saldo es insuficiente, no se puede realizar la operación.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                    SetScript(sc);
                }
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Error en la operación.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }

    }
}