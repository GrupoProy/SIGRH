using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;

public partial class Salarios_Registro_Aporte_IVA : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_pla_factor factor = null;
    private cls_bs_asignacion_beneficio familiar = null;

    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int codFun = (Request.QueryString["id"].ToString() != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
            string as_id = Request.QueryString["id2"].ToString();
            informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
            listarGrillaAporteIVA(Convert.ToInt32(codFun));
            tipoTransaccion();
            obtieneCreditoFicalIVA(codFun);
            listarGrillaMontoPresentar(Convert.ToInt32(codFun));
            SetScriptInicio("$('.table').DataTable().destroy(); ");
            txt_valor_Bs.Focus();
        }
    }

    //private string obtenerGestion()
    //{
    //    cargo = new cls_mp_cargo();
    //    string anio = DateTime.Now.ToString("yyyy");
    //    cargo.gestion = anio;
    //    var gestionActual = cargo.ObtenerGestion();

    //    string gestionFiltrar = "";
    //    if (gestionActual.Tables[0].Rows[0]["pr_id"] != DBNull.Value && gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim() != "")
    //    {
    //        gestionFiltrar = gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim();
    //    }
    //    return gestionFiltrar;
    //}

    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        //cargo = new cls_mp_cargo();
        //cargo.as_per_id = codFun;
        //cargo.as_id_actual = as_id;
        familiar = new cls_bs_asignacion_beneficio();
        familiar.pf_per_id = codFun;
        familiar.as_id = as_id;
        aux_per_id.Value = codFun + "";
        var detalleFuncionario = familiar.ObtenerDatosDetalleFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
                string haberBasico = validarCampo(funcionario["haber_basico"]);
                decimal haberBasico2 = Convert.ToDecimal(haberBasico);
                haberBasico2 = Math.Round(haberBasico2, 2);
                ltl_haber_basico.Text = Convert.ToString(haberBasico2);

                if (validarCampo(funcionario["as_estado"]) == "V")
                {
                    btn_estado.Text = "Vigente";
                    btn_estado.CssClass = "btn btn-sm btn-info float-right";
                }
                else
                {
                    btn_estado.Text = "Pasivo";
                    btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
                }

                if (validarCampo(funcionario["fp_foto"]) != null && validarCampo(funcionario["fp_foto"]) != "")
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

    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }
    //private void informacionFuncionario(string id = "")
    //{
    //    string fu_num_ident = id;
    //    string gestion_selec = obtenerGestion();
    //    cargo.fu_num_ident = fu_num_ident;
    //    cargo.gestion_selec = gestion_selec;
    //    cargo.ObtenerDatosDetalleFuncionario(id);
    //    string haberBasico = cargo.haber_basico.ToString().Trim();
    //    decimal haberBasico2 = Convert.ToDecimal(haberBasico);
    //    haberBasico2 = Math.Round(haberBasico2, 2);
    //    aux_per_id.Value = cargo.as_per_id.ToString().Trim();
    //    txt_haber_basico.Text = Convert.ToString(haberBasico2);
    //    txt_puesto.Text = cargo.pu_nombre_puesto.ToString().Trim();
    //    txt_fechaAsignacion.Text = cargo.as_fecha_asignacion.ToString().Trim();

    //    //Encabezado nuevo
    //    ltl_apellido_fun.Text = cargo.fu_paterno.ToString().Trim() + " " + cargo.fu_materno.ToString().Trim();
    //    ltl_nombre_fun.Text = cargo.fu_nombres.ToString().Trim();
    //    ltl_ci.Text = cargo.fu_num_ident.ToString() + " " + cargo.fu_tipo_ident.ToString().Trim();
    //    ltl_cod_fun.Text = cargo.ca_ti_item_actual.ToString().Trim() + "-" + cargo.ca_num_item_actual.ToString().Trim();
    //    ltl_cargo.Text = cargo.es_descripcion.ToString().Trim();
    //    ltl_cod_fun.Text = aux_per_id.Value;
    //    //aux_per_id.Value = cargo.as_per_id.ToString().Trim();

    //}

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        factor = new cls_pla_factor();
        factor.tr_per_id = Convert.ToInt32(aux_per_id.Value);
        var grillaHoras = factor.ObtenerGrillaAporteIVA();
        int num = grillaHoras.Tables[0].Rows.Count;
        if (num > 0)
        {
            Limpiar();
            sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-info', message: 'Registro de aportes IVA insertado anteriormente'},{ type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_gv_AporteIVA').css('display', 'block');";
            SetScriptDataTable(sc);
        }
        else
        {
            if (Convert.ToInt32(txt_valor_Bs.Text) > 0)
            {
                guardarTransaccion();
                listarGrillaAporteIVA(Convert.ToInt32(aux_per_id.Value));
                Limpiar();
                Response.Redirect("BuscadorFuncionarioRegistroIVA");
            }
            else
            {
                Limpiar();
                sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-info', message: 'El valor insertado es incorrecto'},{ type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScriptDataTable(sc);
            }
        }
    }

    private string tipoTransaccion()
    {
        factor = new cls_pla_factor();
        factor.fa_id = 17;
        var tipoTrans = factor.ObtenerTipoTrans();

        string tipoTransaccion = "";
        if (tipoTrans.Tables[0].Rows[0]["fa_id"] != DBNull.Value && tipoTrans.Tables[0].Rows[0]["fa_id"].ToString().Trim() != "")
        {
            txt_tipo_transaccion.Text = tipoTrans.Tables[0].Rows[0]["fa_descripcion"].ToString().Trim();
            aux_tipo_transaccion.Value = factor.fa_id.ToString().Trim();
        }
        return tipoTransaccion;
    }

    private void obtieneCreditoFicalIVA(int per_id = 0)
    {
        factor = new cls_pla_factor();
        factor.tr_per_id = per_id;
        var aporteIva = factor.ObtenerAporteIva();

        if (aporteIva.Tables[0].Rows.Count > 0)
        {
            if (aporteIva.Tables[0].Rows[0]["tr_id"] != DBNull.Value && aporteIva.Tables[0].Rows[0]["tr_id"].ToString().Trim() != "")
            {
                double montoIva = Convert.ToDouble(aporteIva.Tables[0].Rows[0]["tr_monto"].ToString().Trim());
                montoIva = Math.Round(montoIva, 0);
                txt_credito_fiscal.Text = Convert.ToString(montoIva);
                double montoIvaBs = (montoIva / 0.13);
                montoIvaBs = Math.Round(montoIvaBs, 0);
                txt_credito_fiscal_bs.Text = Convert.ToString(montoIvaBs);
            }
        }
    }

    protected void Limpiar()
    {
        txt_valor_Bs.Text = string.Empty;
    }

    private int obtenerIdProceso()
    {
        factor = new cls_pla_factor();
        var proceso = factor.ObtenerProceso();
        int idProcesoNuevo = 0;
        if (proceso.Tables[0].Rows[0]["pc_id"] != DBNull.Value && proceso.Tables[0].Rows[0]["pc_id"].ToString().Trim() != "")
        {
            idProcesoNuevo = Convert.ToInt32(proceso.Tables[0].Rows[0]["pc_id"]);
        }
        return idProcesoNuevo;
    }

    private void guardarTransaccion()
    {
        string perId = Session["per_id"].ToString();
        factor = new cls_pla_factor();
        int idProceso = obtenerIdProceso();
        factor.tr_pc_id = idProceso;
        factor.tr_per_id = Convert.ToInt32(aux_per_id.Value);
        factor.tr_ac_id = 0;
        factor.tr_fa_id = 17;
        factor.tr_monto = txt_valor_Bs.Text;
        factor.tr_estado = "V";
        factor.tr_usuario_creacion = Convert.ToInt32(perId);
        factor.AdicionarTransaccion();
        sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-check', message: 'Registro exitoso'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_gv_AporteIVA').css('display', 'block');";
        SetScript(sc);
        Session["texto_notificacion"] = "¡Registro creado correctamente!";
        Response.Redirect("BuscadorFuncionarioRegistroIVA");
    }

    private void listarGrillaAporteIVA(int per_id = 0)
    {
        try
        {
            factor = new cls_pla_factor();
            factor.tr_per_id = per_id;
            var grillaAportes = factor.ObtenerGrillaAporteIVA();
            int num = grillaAportes.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_aportes_iva.DataSource = grillaAportes;
                gv_aportes_iva.DataBind();
                sc = "$('#block_gv_AporteIVA').css('display', 'block');";
                SetScriptDataTable(sc);
            }
            else
            {
                sc = "$('#block_gv_AporteIVA').css('display', 'none');";
                SetScript(sc);
            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_aportes_iva_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_aportes_iva.Rows.Count > 0)
        {
            if (gv_aportes_iva.HeaderRow != null)
            {
                gv_aportes_iva.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_aportes_iva.FooterRow != null)
            {
                gv_aportes_iva.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_aportes_iva_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        aux_tr_id.Value = gv_aportes_iva.DataKeys[index].Values[0].ToString();
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarAporte').modal('show');";
                SetScriptDataTable(sc);
                break;

            default:
                break;
        }
    }

    protected void btnEliminarResultado_Click(object sender, EventArgs e)
    {
        factor = new cls_pla_factor();
        factor.tr_id = Convert.ToInt32(aux_tr_id.Value);
        factor.tr_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString());
        int per_id = Convert.ToInt32(aux_per_id.Value);
        factor.EliminarTransaccionIVA();
        listarGrillaAporteIVA(per_id);
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarAporte').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#blockMontoPresentar').css('display', 'block');";
        SetScriptDataTable(sc);
    }

    private void SetScriptInicio(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();
        StringBuilder sb = new StringBuilder();
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
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
                    "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });}");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
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
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    private void SetScriptDataTable(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
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
                    "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true,'paging': false, 'info': false });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gv_monto_presentar_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_monto_presentar.Rows.Count > 0)
        {
            if (gv_monto_presentar.HeaderRow != null)
            {
                gv_monto_presentar.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_monto_presentar.FooterRow != null)
            {
                gv_monto_presentar.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    private void listarGrillaMontoPresentar(int per_id = 0)
    {
        try
        {
            factor = new cls_pla_factor();
            factor.tr_per_id = per_id;
            var grillaMontoPresentar = factor.ObtenerGrillaMontoPresentar();

            int num = grillaMontoPresentar.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_monto_presentar.DataSource = grillaMontoPresentar;
                gv_monto_presentar.DataBind();
            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
}