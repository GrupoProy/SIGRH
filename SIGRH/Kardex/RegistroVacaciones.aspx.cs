using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System.Data;
using Newtonsoft.Json;

public partial class Kardex_RegistroVacaciones : System.Web.UI.Page
{
    private cls_kd_asignacion_vacaciones asig_vacaciones = null;
    private cls_mp_cargo cargo = null;
    private cls_cp_licencia_justificada licencia = null;
    private cls_kd_respuesta_combo respuesta = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string codFun = Request.QueryString["id"].ToString();
            informacionFuncionario(codFun);
            listar_dias_vacacion_disp();
            listar_historico_vacaciones();
            listar_historico_licenciaVacaciones();
            listaFiltradoTipoLicencia();
            listar_historico_docCAS();
            listaFiltradoTipoCas();
            listaFiltradoInmediatoSuperior(Convert.ToInt32(codFun));
            listar_historico_gestionPrescrito();
            listar_filiacion();
            listar_historicoAsignaciones();
            //SetScriptInicio("$('.table').DataTable().destroy(); ");
        }
    }

    private void informacionFuncionario(string id = "")
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        string per_id = id;
        asig_vacaciones.va_per_id = Convert.ToInt32(per_id);
        asig_vacaciones.gestion_selec = Session["pr_id"].ToString();
        var detalleFuncionario = asig_vacaciones.ObtenerDatosFuncionarioP();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);

                if (validarCampo(funcionario["fp_foto"]) != "")
                {
                    imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
                }
                else
                {
                    if (validarCampo(funcionario["per_sexo"]) == "M")
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
                    }
                    else
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
                    }
                }
            }
        }
    }
    private double ObtenerTotalDiasVacacion()
    {
        double dias_vacacion = 0;
        foreach (GridViewRow row in gv_dias_vacacion_disp.Rows)
        {
            for (int i = 0; i < gv_dias_vacacion_disp.Columns.Count; i++)
            {
                if (i == 2)
                {
                    double dias = Convert.ToDouble(row.Cells[i].Text);
                    dias_vacacion = dias_vacacion + dias;
                }
            }
        }
        return dias_vacacion;
    }
    private void totalDiasVacacion(int conFun = 0)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_per_id = conFun;
        var detalleTotalDias = asig_vacaciones.ObtenerSumaTotalDiasV();
        if (detalleTotalDias.Tables.Count > 0)
        {
            if (detalleTotalDias.Tables[0].Rows.Count > 0)
            {
                var dato = detalleTotalDias.Tables[0].Rows[0];
                aux_suma_horas.Value = validarCampo(dato["suma_horas"]);
                txt_total_dias_vacacion.Text = validarCampo(dato["suma_dias"]) + " DÍAS // " + aux_suma_horas.Value + " HORAS";
            }
        }
    }
    private double obtenerNroDiasVacacionDisp()
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_per_id = per_id;
        var detalle_dias = asig_vacaciones.ObtenerNroDiasVacacionDisp();
        double nro_dias_dip = 0;
        if (detalle_dias.Tables[0].Rows.Count > 0)
        {
            nro_dias_dip = Convert.ToDouble(validarCampo(detalle_dias.Tables[0].Rows[0]["dias_disponibles"]));
        }
        return nro_dias_dip;
    }
    private int obtenerNroHorasVacacionDisp()
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_per_id = per_id;
        var detalle_horas = asig_vacaciones.ObtenerNroHorasVacacionDisp();
        double nro_horas_disp = 0;
        if (detalle_horas.Tables[0].Rows.Count > 0)
        {
            nro_horas_disp = Convert.ToInt32(validarCampo(detalle_horas.Tables[0].Rows[0]["horas_disponibles"]));
        }

        double nro_dias_disp = obtenerNroDiasVacacionDisp();
        nro_horas_disp = nro_horas_disp + (nro_dias_disp * 8);

        return Convert.ToInt32(nro_horas_disp);
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
        sb.Append("$('#ContentPlaceHolder1_gv_Hvacaciones').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_Hvacaciones').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('#ContentPlaceHolder1_gv_licenciaVacacion').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_licenciaVacacion').DataTable({" +
        "'language': " + l +
        "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_licencia').select2({ dropdownParent: $('#modalNuevaVacacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_cas').select2({ dropdownParent: $('#modalNuevoRegistroCAS'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_inmediato_superior').select2({ dropdownParent: $('#modalNuevaLicencia'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddlVacacionAnual_Autoriza').select2({ dropdownParent: $('#modalNuevaLicencia'), placeholder: { id: '0', text: 'Seleccione...' } });");

        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        //sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_licencia').select2({ dropdownParent: $('#modalNuevaVacacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_cas').select2({ dropdownParent: $('#modalNuevoRegistroCAS'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ddl_inmediato_superior').select2({ dropdownParent: $('#modalNuevaLicencia'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ddl_inmediato_superior').select2({ dropdownParent: $('#modalNuevaVacacion')});");

        sb.Append("$('#ddl_inmediato_superior').select2({ dropdownParent: $('#modalNuevaVacacion')});");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
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
                    "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
    private void SetScript2(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$('#ddl_inmediato_superior').select2({ dropdownParent: $('#modalNuevaVacacion')});");

        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    //private void SetScript(string data)
    //{
    //    Guid g;
    //    g = Guid.NewGuid();
    //    string uuid = g.ToString();

    //    StringBuilder sb = new StringBuilder();

    //    sb.Append(@"<script type='text/javascript'>");
    //    sb.Append(data);
    //    sb.Append("input.on('select2 - blur', function() { $(this).select2('close');});");
    //    sb.Append(@"</script>");

    //    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    //}
    protected void listar_dias_vacacion_disp()
    {
        string id_fun = Request.QueryString["id"].ToString(); 
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = Convert.ToInt32(id_fun);
            var grillaAsignacionV = asig_vacaciones.obtenerGrillaAsigVacaciones();
            gv_dias_vacacion_disp.DataSource = grillaAsignacionV;
            gv_dias_vacacion_disp.DataBind();

            gvActualizarSaldos.DataSource = grillaAsignacionV;
            gvActualizarSaldos.DataBind();

            txt_total_dias_vacacion.Text = Convert.ToString(ObtenerTotalDiasVacacion()) + " DÍAS";
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }
    protected void gv_dias_vacacion_disp_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_dias_vacacion_disp.Rows.Count > 0)
        {
            if (gv_dias_vacacion_disp.HeaderRow != null)
            {
                gv_dias_vacacion_disp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_dias_vacacion_disp.FooterRow != null)
            {
                gv_dias_vacacion_disp.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void listar_historico_vacaciones()
    {
        string id_fun = Request.QueryString["id"].ToString();
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = Convert.ToInt32(id_fun);
            var grillaHvacaciones = asig_vacaciones.obtenerGrillaHistoricoVacaciones();

            if (grillaHvacaciones.Tables[0].Rows.Count > 0)
            {
                gv_Hvacaciones.DataSource = grillaHvacaciones;
                this.block_vacacionAnual.Visible = false;
            }
            else
            {
                this.block_vacacionAnual.Visible = true;
            }
            gv_Hvacaciones.DataBind();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }
    protected void gv_Hvacaciones_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_Hvacaciones.Rows.Count > 0)
        {
            if (gv_Hvacaciones.HeaderRow != null)
            {
                gv_Hvacaciones.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_Hvacaciones.FooterRow != null)
            {
                gv_Hvacaciones.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_Hvacaciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string vac_id = gv_Hvacaciones.DataKeys[index].Values[0].ToString();
        string vac_per_id = gv_Hvacaciones.DataKeys[index].Values[1].ToString();
        aux_nro_dias_restantes.Value = gv_Hvacaciones.Rows[index].Cells[1].Text;
        aux_gestion.Value = gv_Hvacaciones.Rows[index].Cells[4].Text;
        aux_vac_id.Value = vac_id;
        aux_per_id.Value = vac_per_id;
        switch (e.CommandName)
        {
            case "GetDelete":
                llenarDatosVacacionAnual();
                sc = "$('#eliminarVacacion').modal('show');";
                break;
            case "Print":
                Session["vacacion_id"] = vac_id;
                Session["cod_persona"] = vac_per_id;

                sc = "window.open('ImpresionVacacionAnual.aspx', 'width=300,height=300', '_blank');";
                break;
        }
        SetScript(sc);

    }
    private void llenarDatosVacacionAnual()
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        int per_id = Convert.ToInt32(aux_per_id.Value);
        int vac_id = Convert.ToInt32(aux_vac_id.Value);
        asig_vacaciones.va_per_id = per_id;
        asig_vacaciones.vac_id = vac_id;

        var detalleVacacion = asig_vacaciones.ObtenerVacacionAnualX();
        if (detalleVacacion.Tables.Count > 0)
        {
            if (detalleVacacion.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleVacacion.Tables[0].Rows[0];
                ltl_fecha_solicitud.Text = validarCampo(funcionario["vac_fecha_creacion"]);
                ltl_nro_dias.Text = validarCampo(funcionario["vac_nro_dias_vacacion"]);
                ltl_a_partir.Text = validarCampo(funcionario["vac_a_partir"]);
                ltl_hasta.Text = validarCampo(funcionario["vac_hasta"]);
                txt_motivo.Text = string.Empty;
            }
        }
    }
    protected void btn_nueva_vacacion_Click(object sender, EventArgs e)
    {
        ddl_tipo_licencia.SelectedValue = "2271";
        ddl_tipo_licencia.Enabled = false;
        sc = "$('#modalNuevaVacacion').modal('show');";
        //SetScript(sc);
        SetScript2(sc, ", dropdownParent: $('#modalNuevaVacacion')");

    }


    protected void btn_cancelar_vacacion_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevaVacacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        Limpiar();
        SetScript(sc);
    }
    protected void btn_guardar_vacacion_LicEspecial_Click(object sender, EventArgs e)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        double nroDiasDisponibles = obtenerNroDiasVacacionDisp();
        double diasRequeridos = obtenerCantidadDiasRequeridos();
        double saldo_dias = nroDiasDisponibles - diasRequeridos;

        if (saldo_dias >= 0)
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = per_id;
            var detalleVacacion = asig_vacaciones.obtenerGrillaAsigVacaciones();

            if (detalleVacacion.Tables.Count > 0)
            {
                if (detalleVacacion.Tables[0].Rows.Count > 0)
                {
                    DataTable lista_va = new DataTable();
                    lista_va.Columns.Add("va_id");
                    lista_va.Columns.Add("dias");
                    DataRow dr = null;

                    double nro_dias_vacacion = diasRequeridos;
                    for (int i = 0; i < detalleVacacion.Tables[0].Rows.Count; i++)
                    {
                        var vacacionX = detalleVacacion.Tables[0].Rows[i];
                        double dias_restantes = Convert.ToDouble(validarCampo(vacacionX["va_dias_restantes"]));
                        int horas_restantes = Convert.ToInt32(validarCampo(vacacionX["va_horas_restantes"]));
                        int va_id = Convert.ToInt32(validarCampo(vacacionX["va_id"]));

                        dr = lista_va.NewRow();
                        dr["va_id"] = va_id;

                        if (dias_restantes >= diasRequeridos)
                        {
                            dr["dias"] = diasRequeridos;
                            diasRequeridos = dias_restantes - diasRequeridos;
                            ActualizarDiasVacacion(diasRequeridos, horas_restantes, va_id);
                            lista_va.Rows.Add(dr);
                            break;
                        }
                        else
                        {
                            dr["dias"] = dias_restantes;
                            ActualizarDiasVacacion(0, horas_restantes, va_id);
                            diasRequeridos = diasRequeridos - dias_restantes;
                            lista_va.Rows.Add(dr);
                        }
                    }

                    string json = JsonConvert.SerializeObject(lista_va);
                    int cod_vacacion = guardarVacacionLicencia(json, nro_dias_vacacion);

                    Limpiar();
                    listar_dias_vacacion_disp();
                    listar_historico_vacaciones();
                    
                    Session["cod_persona"] = per_id;
                    Session["vacacion_id"] = cod_vacacion;

                    //sc = "$.notify({ icon: 'fas fa-check', message: 'Se registró correctamente la vacación...!!' }, { type: 'success' }); $('#modalNuevaVacacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }}); window.open('ImpresionVacacionAnual.aspx', 'width=300,height=300', '_blank');";
                    sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso, puede ahora imprimir el documento...', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevaVacacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }}); window.open('ImpresionVacacionAnual.aspx', 'width=300,height=300', '_blank');";
                    SetScript2(sc,"");
                }
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-times', message: 'No se pudo registrar la solicitud.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-times', message: 'No se puede realizar la acción, los días requeridos son mayor al disponible.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }
    private void ActualizarDiasVacacion(double va_dias_restantes = 0, int horas_restantes = 0, int va_id = 0)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_id = va_id;
        asig_vacaciones.va_dias_restantes = va_dias_restantes;
        asig_vacaciones.va_estado = (va_dias_restantes == 0 && horas_restantes == 0) ? "C" : "V";
        asig_vacaciones.ActualizarSaldoDias();
    }
    private int guardarVacacionLicencia(string json = "", double vac_nro_dias_vacacion = 0)
    {
        string us_id = Session["us_id"].ToString();
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        int vac_correlativo = generarCorrelativo();
        vac_correlativo = vac_correlativo + 1;

        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_per_id = per_id;
        asig_vacaciones.vac_tipo_vacacion = Convert.ToInt32(ddl_tipo_licencia.SelectedValue);
        asig_vacaciones.vac_a_partir = txt_a_partir.Text.ToString().Trim();
        asig_vacaciones.vac_hasta = txt_hasta.Text.ToString().Trim();
        asig_vacaciones.vac_va_id = Convert.ToString(json);
        asig_vacaciones.vac_nro_dias_vacacion = vac_nro_dias_vacacion + "";
        asig_vacaciones.vac_observacion = txt_observacion.Text.ToString();
        asig_vacaciones.vac_correlativo = vac_correlativo;
        asig_vacaciones.vac_usuario_creacion = Convert.ToInt32(us_id);
        return asig_vacaciones.AdicionarVacacionLicencia(Convert.ToInt32( ddlVacacionAnual_Autoriza.SelectedItem.Value));
    }
    private int generarCorrelativo()
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        var correlativo = asig_vacaciones.ObtenerCorrelativo();
        int correlativo_id = 0;
        if (correlativo.Tables[0].Rows.Count > 0)
        {
            if (correlativo.Tables[0].Rows[0]["vac_correlativo"] != DBNull.Value && correlativo.Tables[0].Rows[0]["vac_correlativo"].ToString().Trim() != "")
            {
                correlativo_id = Convert.ToInt32(correlativo.Tables[0].Rows[0]["vac_correlativo"].ToString());
            }
        }
        return correlativo_id;
    }
    private void listaFiltradoTipoLicencia()
    {
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            ddl_tipo_licencia.Items.Clear();
            ddl_tipo_licencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_licencia.DataValueField = "cat_id";
            ddl_tipo_licencia.DataTextField = "cat_descripcion";
            ddl_tipo_licencia.DataSource = asig_vacaciones.listaFiltradoTipoLicencia();
            ddl_tipo_licencia.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void txt_a_partir_TextChanged(object sender, EventArgs e)
    {
        //string cantidadDias = obtenerCantidadDiasRequeridos().ToString();
        //txt_dias_autorizados.Text = cantidadDias;
        //SetScript2(sc, ", dropdownParent: $('#modalNuevaVacacion')");
    }

    protected void txt_hasta_TextChanged(object sender, EventArgs e)
    {
        string cantidadDias = obtenerCantidadDiasRequeridos().ToString();
        txt_dias_autorizados.Text = cantidadDias;
        SetScript2(sc, ", dropdownParent: $('#modalNuevaVacacion')");
    }

    private int obtenerCantidadDiasRequeridos()
    {
        int dif = 0;
        int feriados = 0;
        if (txt_a_partir.Text != null && txt_a_partir.Text != "" && txt_hasta.Text != null && txt_hasta.Text != "")
        {
            DateTime startDate = Convert.ToDateTime(txt_a_partir.Text);
            DateTime endDate = Convert.ToDateTime(txt_hasta.Text);
            startDate.ToString("dddd");
            double diferencia = (endDate - startDate).TotalDays + 1;
            if (diferencia > 0)
            {
                string dia = "";
                int cont = 0;
                for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
                {
                    dia = date.ToString("dddd");
                    if (dia == "sábado" || dia == "domingo")
                    {
                        cont = cont + 1;
                    }
                }
                dif = Convert.ToInt32(diferencia) - cont;
            }
            cls_kd_asignacion_vacaciones vacaciones = new cls_kd_asignacion_vacaciones();
            feriados=Convert.ToInt32(vacaciones.ObtenerVacaciones_ConDiasFeriados(txt_a_partir.Text, txt_hasta.Text));
        }

        return dif - feriados;
    }
    protected void Limpiar()
    {
        ddl_tipo_licencia.SelectedValue = "0";
        txt_a_partir.Text = string.Empty;
        txt_hasta.Text = string.Empty;
        txt_dias_autorizados.Text = string.Empty;
        ddl_tipo_cas.SelectedValue = "0";
        txt_nro_cas.Text = string.Empty;
        txt_fecha_cas.Text = string.Empty;
        txt_anio_cas.Text = string.Empty;
        txt_meses_cas.Text = string.Empty;
        txt_dias_cas.Text = string.Empty;
        txt_a_partir_lv.Text = string.Empty;
        txt_hasta_el_lv.Text = string.Empty;
        txt_hora_salida_lv.Text = string.Empty;
        txt_hora_retorno_lv.Text = string.Empty;
        ddl_inmediato_superior.SelectedValue = "0";
        txt_dias_autorizados_lv.Text = string.Empty;
        txt_nro_documento.Text = string.Empty;
        txt_fecha_habilitacion.Text = string.Empty;
        txt_fecha_validez.Text = string.Empty;
        txt_autorizado_por.Text = string.Empty;
        txt_observacion.Text = string.Empty;
    }

    protected void btn_eliminar_vacacion_Click(object sender, EventArgs e)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.vac_id = Convert.ToInt32(aux_vac_id.Value);
        asig_vacaciones.va_per_id = Convert.ToInt32(aux_per_id.Value);
        var gestiones = asig_vacaciones.ObtenerDiasAsignados();
        if (gestiones.Tables.Count > 0)
        {
            int nroGestiones = gestiones.Tables[0].Rows.Count;
            if (nroGestiones > 0)
            {
                double dias_vacacion = Convert.ToDouble(validarCampo(gestiones.Tables[0].Rows[0]["vac_nro_dias_vacacion"]));
                for (int i = 0; i < nroGestiones; i++)
                {
                    var detalle_gestion = gestiones.Tables[0].Rows[i];
                    int dias_ley = Convert.ToInt32(validarCampo(detalle_gestion["va_dias_ley"]));
                    double saldo_dias = Convert.ToDouble(validarCampo(detalle_gestion["va_dias_restantes"]));
                    int va_id = Convert.ToInt32(validarCampo(detalle_gestion["va_id"]));

                    if ((dias_vacacion + saldo_dias) > dias_ley)
                    {
                        double diferencia = dias_ley - saldo_dias;
                        saldo_dias = saldo_dias + diferencia;
                        dias_vacacion = dias_vacacion - diferencia;
                    }
                    else
                    {
                        saldo_dias = saldo_dias + dias_vacacion;
                    }
                    recuperarDias(va_id, saldo_dias);
                }
            }
        }

        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.vac_motivo_anulado = txt_motivo.Text;
        asig_vacaciones.vac_id = Convert.ToInt32(aux_vac_id.Value);
        asig_vacaciones.EliminarVacacion();
        listar_dias_vacacion_disp();
        listar_historico_vacaciones();
        txt_motivo.Text = string.Empty;
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Vacación eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarVacacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    private void recuperarDias(int va_id = 0, double saldoDias = 0)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_id = va_id;
        asig_vacaciones.va_dias_restantes = saldoDias;
        asig_vacaciones.RecuperarVacacion();
    }


    //LICENCIA CON CARGO A VACACION
    private void listaFiltradoInmediatoSuperior(int per_id = 0)
    {
        try
        {
            licencia = new cls_cp_licencia_justificada();
            licencia.lj_per_id = per_id;
            ddl_inmediato_superior.Items.Clear();
            ddl_inmediato_superior.Items.Insert(0, new ListItem("Seleccione...", "0"));
            //ddl_inmediato_superior.DataValueField = "per_id";
            //ddl_inmediato_superior.DataTextField = "per_inm_superior";
            //ddl_inmediato_superior.DataSource = licencia.ObtenerTablaComboIS();
            //ddl_inmediato_superior.DataBind();
            ddl_inmediato_superior.DataSource = licencia.AutoridadesParaValidarComisiones();
            ddl_inmediato_superior.DataTextField = "NOMBRES";
            ddl_inmediato_superior.DataValueField = "PER_ID_AUTORIDAD";
            ddl_inmediato_superior.DataBind();

            ddlVacacionAnual_Autoriza.Items.Clear();
            ddlVacacionAnual_Autoriza.Items.Insert(0, new ListItem("Seleccione...", "0"));
            //ddl_inmediato_superior.DataValueField = "per_id";
            //ddl_inmediato_superior.DataTextField = "per_inm_superior";
            //ddl_inmediato_superior.DataSource = licencia.ObtenerTablaComboIS();
            //ddl_inmediato_superior.DataBind();
            ddlVacacionAnual_Autoriza.DataSource = licencia.AutoridadesParaValidarComisiones();
            ddlVacacionAnual_Autoriza.DataTextField = "NOMBRES";
            ddlVacacionAnual_Autoriza.DataValueField = "PER_ID_AUTORIDAD";
            ddlVacacionAnual_Autoriza.DataBind();


        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void listar_historico_licenciaVacaciones()
    {
        string per_id = Request.QueryString["id"].ToString(); ;
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = Convert.ToInt32(per_id);
            var grillaLicenciaV = asig_vacaciones.obtenerGrillaHistoricoLicenciaVac();
            if (grillaLicenciaV.Tables[0].Rows.Count > 0)
            {
                gv_licenciaVacacion.DataSource = grillaLicenciaV;
                this.block_licenciaVacacion.Visible = false;
            }
            else
            {
                this.block_licenciaVacacion.Visible = true;
            }
            gv_licenciaVacacion.DataBind();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }
    protected void gv_licenciaVacacion_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_licenciaVacacion.Rows.Count > 0)
        {
            if (gv_licenciaVacacion.HeaderRow != null)
            {
                gv_licenciaVacacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_licenciaVacacion.FooterRow != null)
            {
                gv_licenciaVacacion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void gv_licenciaVacacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string lj_id = gv_licenciaVacacion.DataKeys[index].Values[0].ToString();
        string lj_per_id = gv_licenciaVacacion.DataKeys[index].Values[1].ToString();
        aux_lj_id.Value = lj_id;
        aux_per_id.Value = lj_per_id;
        switch (e.CommandName)
        {
            case "GetDelete":
                llenarDatosLicenciaCargoVacacion();
                sc = "$('#eliminarLicenciaVacacion').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }
    private void llenarDatosLicenciaCargoVacacion()
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        int per_id = Convert.ToInt32(aux_per_id.Value);
        int lj_id = Convert.ToInt32(aux_lj_id.Value);
        asig_vacaciones.va_per_id = per_id;
        asig_vacaciones.lj_id = lj_id;

        var detalleVacacion = asig_vacaciones.ObtenerLicenciaCargoVacacionX();
        if (detalleVacacion.Tables.Count > 0)
        {
            if (detalleVacacion.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleVacacion.Tables[0].Rows[0];
                ltl_a_partir_lic.Text = validarCampo(funcionario["lj_fecha_inicial"]);
                ltl_hasta_lic.Text = validarCampo(funcionario["lj_fecha_final"]);
                ltl_hora_inicio_lic.Text = validarCampo(funcionario["lj_hora_salida"]);
                ltl_hora_fin_lic.Text = validarCampo(funcionario["lj_hora_retorno"]);
            }
        }
    }
    protected void btn_eliminar_licenciaVacacion_Click(object sender, EventArgs e)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.lj_id = Convert.ToInt32(aux_lj_id.Value);
        asig_vacaciones.va_per_id = per_id;
        var detalleLicencia = asig_vacaciones.ObtenerDetalleLicencia();

        if (detalleLicencia.Tables.Count > 0)
        {
            if (detalleLicencia.Tables[0].Rows.Count > 0)
            {
                var licencia = detalleLicencia.Tables[0].Rows[0];
                DateTime startDate = Convert.ToDateTime(validarCampo(licencia["lj_fecha_inicial"]));
                DateTime endDate = Convert.ToDateTime(validarCampo(licencia["lj_fecha_final"]));
                DateTime hora_salida = Convert.ToDateTime(validarCampo(licencia["lj_hora_salida"]));
                DateTime hora_retorno = Convert.ToDateTime(validarCampo(licencia["lj_hora_retorno"]));
                //double diferencia_dias = ((endDate - startDate).TotalDays) + 1;
                double diferencia_dias = calcularDias(validarCampo(licencia["lj_fecha_inicial"]), validarCampo(licencia["lj_fecha_final"]));
                double diferencia_horas = (hora_retorno - hora_salida).TotalHours;
                diferencia_horas = (diferencia_horas > 0 && diferencia_horas < 1) ? 1 : diferencia_horas = Math.Round(diferencia_horas, 0);
                double totalHoras = (diferencia_dias * diferencia_horas);

                restablecerDiasHoras(totalHoras);
            }
        }

        asig_vacaciones.lj_id = Convert.ToInt32(aux_lj_id.Value);
        asig_vacaciones.EliminarLicenciaVacacion();
        listar_dias_vacacion_disp();
        listar_historico_licenciaVacaciones();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Licencia con cargo a Vacación eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarLicenciaVacacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    private void restablecerDiasHoras(double totalHoras = 0)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());

        int totalHorasRecuperar = Convert.ToInt32(totalHoras);
        int totalHorasDisponibles = obtenerNroHorasVacacionDisp();

        int totalRecuperar = totalHorasDisponibles + totalHorasRecuperar;
        double dias_vacacion_recuperar = Convert.ToDouble(totalRecuperar) / 8;
        int horas_vacacion_recuperar = Convert.ToInt32(totalRecuperar) % 8;

        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_per_id = per_id;
        var gestiones = asig_vacaciones.ObtenerVacacionesAsignadas();
        if (gestiones.Tables.Count > 0)
        {
            int nroGestiones = gestiones.Tables[0].Rows.Count;
            if (nroGestiones > 0)
            {
                for (int i = 0; i < nroGestiones; i++)
                {
                    var detalle_gestion = gestiones.Tables[0].Rows[i];
                    int va_id = Convert.ToInt32(validarCampo(detalle_gestion["va_id"]));
                    int dias_ley = Convert.ToInt32(validarCampo(detalle_gestion["va_dias_ley"]));

                    if (dias_vacacion_recuperar > dias_ley)
                    {
                        double diferencia = dias_vacacion_recuperar - dias_ley;
                        double dias_recuperar = dias_vacacion_recuperar - diferencia;
                        recuperarDiasHoras(va_id, dias_recuperar);
                        dias_vacacion_recuperar = dias_vacacion_recuperar - dias_recuperar;
                    }
                    else
                    {
                        recuperarDiasHoras(va_id, dias_vacacion_recuperar, horas_vacacion_recuperar);
                        break;
                    }
                }
            }
        }
    }
    private void recuperarDiasHoras(int va_id = 0, double saldoDias = 0, int saldoHoras = 0)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_id = va_id;
        asig_vacaciones.va_dias_restantes = saldoDias;
        asig_vacaciones.va_horas_restantes = saldoHoras;
        asig_vacaciones.RecuperarVacacionHoras();
    }

    protected void btn_nueva_licencia_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevaLicencia').modal('show');";
        SetScript(sc);
    }

    protected void btn_guardar_licencia_Click(object sender, EventArgs e)
    {
        DateTime startDate = Convert.ToDateTime(txt_a_partir_lv.Text);
        DateTime endDate = Convert.ToDateTime(txt_hasta_el_lv.Text);
        DateTime hora_salida = Convert.ToDateTime(txt_hora_salida_lv.Text.Trim());
        DateTime hora_retorno = Convert.ToDateTime(txt_hora_retorno_lv.Text.Trim());
        //double diferencia_dias = ((endDate - startDate).TotalDays) + 1;
        double diferencia_dias = calcularDias(txt_a_partir_lv.Text, txt_hasta_el_lv.Text);
        double diferencia_horas = (hora_retorno - hora_salida).TotalHours;

        if (diferencia_horas > 0 && diferencia_horas < 1)
        {
            diferencia_horas = 1;
        }
        else
        {
            diferencia_horas = Math.Round(diferencia_horas, 0);
        }
        if (diferencia_dias >= 0)
        {
            if (diferencia_horas >= 1)
            {
                double totalHorasRequeridas = (diferencia_dias * diferencia_horas);
                GuardarHorasVacacion(Convert.ToInt32(totalHorasRequeridas));
                sc = "console.log('Proceder a guardar' + " + diferencia_horas + ") ";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'La hora retorno deber ser mayor a la hora salida.'},{ type: 'info', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'La fecha inicio deber ser mayor o igual a la fecha fin.'},{ type: 'info', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    protected void btn_cancelar_licencia_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevaLicencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        Limpiar();
        SetScript(sc);
    }

    private int ObtenerTotalHorasVacacion()
    {
        int dias_vacacion = 0;
        int horas_vacacion = 0;
        foreach (GridViewRow row in gv_dias_vacacion_disp.Rows)
        {
            for (int i = 0; i < gv_dias_vacacion_disp.Columns.Count; i++)
            {
                if (i == 2)
                {
                    int dias = Convert.ToInt32(row.Cells[i].Text);
                    dias_vacacion = dias_vacacion + dias;
                }
                if (i == 3)
                {
                    int horas = Convert.ToInt32(row.Cells[i].Text);
                    horas_vacacion = horas_vacacion + horas;
                }
            }
        }
        dias_vacacion = (dias_vacacion * 8);
        horas_vacacion = dias_vacacion + horas_vacacion;
        return horas_vacacion;
    }

    protected void GuardarHorasVacacion(int totalHorasRequeridas = 0)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        int totalHorasDisponibles = obtenerNroHorasVacacionDisp();
        int horas_requeridas = totalHorasRequeridas;

        if (totalHorasDisponibles >= horas_requeridas)
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = Convert.ToInt32(per_id);
            var detalleVacacion = asig_vacaciones.obtenerGrillaAsigVacaciones();

            if (detalleVacacion.Tables.Count > 0)
            {
                if (detalleVacacion.Tables[0].Rows.Count > 0)
                {

                    for (int i = 0; i < detalleVacacion.Tables[0].Rows.Count; i++)
                    {
                        var vacacionX = detalleVacacion.Tables[0].Rows[i];
                        double dias_restantes = Convert.ToInt32(validarCampo(vacacionX["va_dias_restantes"]));
                        int horas_restantes = Convert.ToInt32(validarCampo(vacacionX["va_horas_restantes"]));
                        int va_id = Convert.ToInt32(validarCampo(vacacionX["va_id"]));

                        double total_restantes = (dias_restantes * 8) + horas_restantes;
                        if (horas_requeridas > 0)
                        {
                            if (total_restantes >= horas_requeridas)
                            {
                                total_restantes = total_restantes - horas_requeridas;
                                double dias = total_restantes / 8;
                                int horas = Convert.ToInt32(total_restantes) % 8;
                                ActualizarDiasHorasVacacion(dias, horas, va_id);
                                horas_requeridas = 0;
                            }
                            else
                            {
                                ActualizarDiasHorasVacacion(0, 0, va_id);
                                horas_requeridas = horas_requeridas - Convert.ToInt32(total_restantes);
                            }
                        }
                        else
                        {
                            break;
                        }
                    }

                    guardarLicenciaVacacion();
                    listar_historico_licenciaVacaciones();
                    listar_dias_vacacion_disp();
                    Limpiar();
                    sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevaLicencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                    SetScript(sc);
                }
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-check', message: 'No se pudo realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#modalNuevaVacacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'No existe horas dispobles.'},{ type: 'danger', placement: { from: 'bottom', align: 'right'} });$('#modalNuevaLicencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc);
        }
    }

    private void ActualizarHorasVacacion(int horasRestantes = 0)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        GridViewRow row = gv_dias_vacacion_disp.Rows[0];
        string va_id = gv_dias_vacacion_disp.DataKeys[row.RowIndex].Values[0].ToString();
        asig_vacaciones.va_id = Convert.ToInt32(va_id);
        asig_vacaciones.va_horas_restantes = horasRestantes;
        asig_vacaciones.ActualizarSaldoHoras();
    }

    private void ActualizarDiasHorasVacacion(double diasRestantes = 0, int horasRestantes = 0, int va_id = 0)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_id = va_id;
        asig_vacaciones.va_dias_restantes = diasRestantes;
        asig_vacaciones.va_horas_restantes = horasRestantes;
        asig_vacaciones.va_estado = (diasRestantes == 0 && horasRestantes == 0) ? "C" : "V";
        asig_vacaciones.ActualizarSaldoDiasHoras();
    }

    private void guardarLicenciaVacacion()
    {
        licencia = new cls_cp_licencia_justificada();
        string id = Request.QueryString["id"].ToString();        
        licencia.lj_per_id = Convert.ToInt32(id);
        licencia.lj_tipo_licencia = 2;
        licencia.lj_fecha_inicial = Convert.ToDateTime(txt_a_partir_lv.Text);
        licencia.lj_fecha_final = Convert.ToDateTime(txt_hasta_el_lv.Text);
        licencia.lj_hora_salida = Convert.ToDateTime(txt_hora_salida_lv.Text);
        licencia.lj_hora_retorno = Convert.ToDateTime(txt_hora_retorno_lv.Text);
        licencia.lj_per_id_autoriza = ddl_inmediato_superior.SelectedValue;
        licencia.AdicionarLicenciaVacacion();
    }

    private int calcularDias(string txt_a_partir_lv = "", string txt_hasta_el_lv = "")
    {
        int dif = 0;
        if (txt_a_partir_lv != null && txt_a_partir_lv != "" && txt_hasta_el_lv != null && txt_hasta_el_lv != "")
        {
            DateTime startDate = Convert.ToDateTime(txt_a_partir_lv);
            DateTime endDate = Convert.ToDateTime(txt_hasta_el_lv);
            startDate.ToString("dddd");
            double diferencia = (endDate - startDate).TotalDays + 1;
            if (diferencia > 0)
            {
                string dia = "";
                int cont = 0;
                for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
                {
                    dia = date.ToString("dddd");
                    if (dia == "sábado" || dia == "domingo")
                    {
                        cont = cont + 1;
                    }
                }
                dif = Convert.ToInt32(diferencia) - cont;
                txt_dias_autorizados_lv.Text = Convert.ToString(dif);
            }
        }
        return dif;
    }
    protected void txt_a_partir_lv_TextChanged(object sender, EventArgs e)
    {
        if (txt_a_partir_lv.Text != null && txt_a_partir_lv.Text != "" && txt_hasta_el_lv.Text != null && txt_hasta_el_lv.Text != "")
        {
            DateTime startDate = Convert.ToDateTime(txt_a_partir_lv.Text);
            DateTime endDate = Convert.ToDateTime(txt_hasta_el_lv.Text);
            startDate.ToString("dddd");
            double diferencia = (endDate - startDate).TotalDays + 1;
            if (diferencia > 0)
            {
                string dia = "";
                int cont = 0;
                for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
                {
                    dia = date.ToString("dddd");
                    if (dia == "sábado" || dia == "domingo")
                    {
                        cont = cont + 1;
                    }
                }
                int dif = Convert.ToInt32(diferencia) - cont;
                txt_dias_autorizados_lv.Text = Convert.ToString(dif);
            }
        }
        SetScript("");
    }

    protected void txt_hasta_el_lv_TextChanged(object sender, EventArgs e)
    {
        if (txt_a_partir_lv.Text != null && txt_a_partir_lv.Text != "" && txt_hasta_el_lv.Text != null && txt_hasta_el_lv.Text != "")
        {
            DateTime startDate = Convert.ToDateTime(txt_a_partir_lv.Text);
            DateTime endDate = Convert.ToDateTime(txt_hasta_el_lv.Text);
            startDate.ToString("dddd");
            double diferencia = (endDate - startDate).TotalDays + 1;
            if (diferencia > 0)
            {
                string dia = "";
                int cont = 0;
                for (DateTime date = startDate; date.Date <= endDate.Date; date = date.AddDays(1))
                {
                    dia = date.ToString("dddd");
                    if (dia == "sábado" || dia == "domingo")
                    {
                        cont = cont + 1;
                    }
                }
                int dif = Convert.ToInt32(diferencia) - cont;
                txt_dias_autorizados_lv.Text = Convert.ToString(dif);
            }
        }

        SetScript("");
    }

    // REGISTRO CAS
    private void listaFiltradoTipoCas()
    {
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();

            ddl_tipo_cas.Items.Clear();
            ddl_tipo_cas.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_cas.DataValueField = "cat_abreviacion";
            ddl_tipo_cas.DataTextField = "cat_descripcion";
            ddl_tipo_cas.DataSource = asig_vacaciones.listaFiltradoTipoCas();
            ddl_tipo_cas.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void gv_doc_cas_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_doc_cas.Rows.Count > 0)
        {
            if (gv_doc_cas.HeaderRow != null)
            {
                gv_doc_cas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_doc_cas.FooterRow != null)
            {
                gv_doc_cas.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_doc_cas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string cs_id = gv_doc_cas.DataKeys[index].Values[0].ToString();
        aux_cs_id.Value = cs_id;
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarDocumentoCAS').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    protected void listar_historico_docCAS()
    {
        string id_fun = Request.QueryString["id"].ToString(); ;
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = Convert.ToInt32(id_fun);
            var grillaDocCAS = asig_vacaciones.obtenerGrillaHistoricoDocumentoCAS();

            if (grillaDocCAS.Tables[0].Rows.Count > 0)
            {
                gv_doc_cas.DataSource = grillaDocCAS;
                gv_doc_cas.DataBind();
            }
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_nuevo_docCAS_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevoRegistroCAS').modal('show');";
        SetScript(sc);
    }

    protected void btn_guardar_docCas_Click(object sender, EventArgs e)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        int meses = Convert.ToInt32(txt_meses_cas.Text);
        int dias = Convert.ToInt32(txt_dias_cas.Text);
        int anios = Convert.ToInt32(txt_anio_cas.Text);
        if (anios > 0 && meses >= 0 && meses <= 12 && dias >= 0 && dias <= 31)
        {
            guardarRegistroCas();
            Limpiar();
            listar_historico_docCAS();
            sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevoRegistroCAS').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message: 'Error en el Registro CAS, verifique los datos'},{ type: 'danger', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    protected void btn_cancelar_docCas_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevoRegistroCAS').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    private void guardarRegistroCas()
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        string perId = Session["per_id"].ToString();
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string id = Request.QueryString["id"].ToString();
        asig_vacaciones.va_per_id = Convert.ToInt32(id);
        asig_vacaciones.cs_tipo_cas = Convert.ToInt32(ddl_tipo_cas.SelectedValue);
        asig_vacaciones.cs_nro_cas = txt_nro_cas.Text;
        asig_vacaciones.cs_fecha_cas = txt_fecha_cas.Text.ToString().Trim() + " " + hora;
        asig_vacaciones.cs_anios_calif = Convert.ToInt32(txt_anio_cas.Text);
        asig_vacaciones.cs_meses_calif = Convert.ToInt32(txt_meses_cas.Text);
        asig_vacaciones.cs_dias_calif = Convert.ToInt32(txt_dias_cas.Text);
        asig_vacaciones.vac_usuario_creacion = Convert.ToInt32(perId);
        asig_vacaciones.AdicionarRegistroCas();
    }

    protected void btn_eliminar_registroCas_Click(object sender, EventArgs e)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.cs_id = Convert.ToInt32(aux_cs_id.Value);
        asig_vacaciones.vac_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString());
        asig_vacaciones.EliminarRegistroCas();
        listar_historico_docCAS();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro CAS eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarDocumentoCAS').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    //GESTIÓN PRESCRITO
    protected void gv_gestion_prescrito_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_gestion_prescrito.Rows.Count > 0)
        {
            if (gv_gestion_prescrito.HeaderRow != null)
            {
                gv_gestion_prescrito.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_gestion_prescrito.FooterRow != null)
            {
                gv_gestion_prescrito.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_gestion_prescrito_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string va_id = gv_gestion_prescrito.DataKeys[index].Values[0].ToString();
        aux_va_id.Value = va_id;
        switch (e.CommandName)
        {
            case "GetEdit":
                llenarGestionPrescrito(Convert.ToInt32(va_id));
                sc = "$('#modalHabilitarGestionPrescrito').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    protected void llenarGestionPrescrito(int va_id = 0)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        asig_vacaciones.va_id = va_id;
        var detalleAsigVacacion = asig_vacaciones.ObtenerVacacionX();
        var vacacionX = detalleAsigVacacion.Tables[0].Rows[0];
        txt_gestion_prescrito.Text = validarCampo(vacacionX["va_gestion"]);
    }

    protected void guardarGestionPrescrito(int indice = 0)
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        string hora = DateTime.Now.ToString("HH:mm:ss");
        asig_vacaciones.va_id = Convert.ToInt32(aux_va_id.Value);
        asig_vacaciones.va_nro_documento = txt_nro_documento.Text;
        asig_vacaciones.va_fecha_habilitacion_prescrito = Convert.ToDateTime(txt_fecha_habilitacion.Text);
        asig_vacaciones.va_fecha_validez_prescrito = Convert.ToDateTime(txt_fecha_validez.Text);
        asig_vacaciones.va_autorizado_por = txt_autorizado_por.Text;
        asig_vacaciones.va_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString());
        asig_vacaciones.AdicionarGestionPrescrito();
    }

    protected void listar_historico_gestionPrescrito()
    {
        string id_fun = Request.QueryString["id"].ToString(); ;
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = Convert.ToInt32(id_fun);
            var grillagestionP = asig_vacaciones.obtenerGrillaHistoricoGestionPrescrito();
            if (grillagestionP.Tables[0].Rows.Count > 0)
            {
                gv_gestion_prescrito.DataSource = grillagestionP;
                this.block_gestionPrescrito.Visible = false;
            }
            else
            {
                this.block_gestionPrescrito.Visible = true;
            }
            gv_gestion_prescrito.DataBind();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_guardar_gestion_prescrito_Click(object sender, EventArgs e)
    {
        guardarGestionPrescrito();
        listar_historico_gestionPrescrito();
        listar_dias_vacacion_disp();
        Limpiar();
        sc = "Swal.fire({ icon: 'success', title: 'Habilitación exitosa', text: 'Gestión prescrito habilitado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalHabilitarGestionPrescrito').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
        //sc = "$.notify({ icon: 'fa fa-info', message: 'Gestión prescrito habilitado correctamente '},{ type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#modalHabilitarGestionPrescrito').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        //SetScript(sc);
    }

    protected void btn_cancelar_gestion_prescrito_Click(object sender, EventArgs e)
    {
        sc = "$('#modalHabilitarGestionPrescrito').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    // FILIACIÓN
    protected void gv_filiacion_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_filiacion.Rows.Count > 0)
        {
            if (gv_filiacion.HeaderRow != null)
            {
                gv_filiacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_filiacion.FooterRow != null)
            {
                gv_filiacion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void listar_filiacion()
    {
        string id_fun = Request.QueryString["id"].ToString();
        try
        {
            respuesta = new cls_kd_respuesta_combo();
            respuesta.rp_valor_pk = Convert.ToInt32(id_fun);
            respuesta.rp_nombre_pk = "per_id";
            var grillaFiliacion = respuesta.RequisitosPresentadosFun();
            if (grillaFiliacion.Tables[0].Rows.Count > 0)
            {
                gv_filiacion.DataSource = grillaFiliacion;
                gv_filiacion.DataBind();
            }
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    //HISTORICO DE ASIGNACIONES
    protected void gv_historicoAsig_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_historicoAsig.Rows.Count > 0)
        {
            if (gv_historicoAsig.HeaderRow != null)
            {
                gv_historicoAsig.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_historicoAsig.FooterRow != null)
            {
                gv_historicoAsig.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void listar_historicoAsignaciones()
    {
        int id_fun = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = id_fun;
            var grillaHistorico = asig_vacaciones.obtenerGrillaHistoricoAsig();
            if (grillaHistorico.Tables[0].Rows.Count > 0)
            {
                gv_historicoAsig.DataSource = grillaHistorico;
                gv_historicoAsig.DataBind();
            }
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
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

    protected void gvActualizarSaldos_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvActualizarSaldos.EditIndex = -1;
        listar_dias_vacacion_disp();
    }

    protected void gvActualizarSaldos_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvActualizarSaldos.EditIndex = e.NewEditIndex;
        listar_dias_vacacion_disp();
    }

    protected void gvActualizarSaldos_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        //Label id = gvActualizarSaldos.Rows[e.RowIndex].FindControl("lbl_ID") as Label;
        TextBox dias = gvActualizarSaldos.Rows[e.RowIndex].FindControl("txt_saldo") as TextBox;
        //TextBox city = gvActualizarSaldos.Rows[e.RowIndex].FindControl("txt_City") as TextBox;
        cls_kd_asignacion_vacaciones saldoVacaciones = new cls_kd_asignacion_vacaciones();
        int index = Convert.ToInt32(e.RowIndex);
        saldoVacaciones.va_id= Convert.ToInt32( gvActualizarSaldos.DataKeys[index].Values[0].ToString());
        saldoVacaciones.va_dias_restantes = Convert.ToDouble(dias.Text);
        saldoVacaciones.va_estado = "V";
        saldoVacaciones.ActualizarSaldoDias();
        gvActualizarSaldos.EditIndex = -1;
        listar_dias_vacacion_disp();
    }
}