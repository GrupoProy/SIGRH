using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;

public partial class Salarios_Registro_Horas_Extras : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_pla_factor factor = null;
    private cls_catalogo _catalogo = null;

    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
            listarGrillaHorasExtras(Convert.ToInt32(codFun));
            tipoTransaccion();
            obtiene_txt_mes_ant();
            horasExtras();
            listaFiltradoTipoDoc();
            txt_horas.Focus();
        }
    }

    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        cargo = new cls_mp_cargo();
        cargo.as_per_id = codFun;
        cargo.as_id_actual = as_id;
        var detalleFuncionario = cargo.ObtenerDatosDetalleFuncionario();
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
                aux_per_id.Value = cargo.as_per_id.ToString().Trim();
                aux_es_id.Value = validarCampo(funcionario["es_id"]);
                aux_eo_id.Value = validarCampo(funcionario["eo_id"]);
                aux_cp_id.Value = validarCampo(funcionario["cp_id"]);
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

    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        string mes = DateTime.Now.ToString("MM");
        int mesAnterior = Convert.ToInt32(mes) - 1;
        factor = new cls_pla_factor();
        factor.tr_per_id = Convert.ToInt32(aux_per_id.Value);
        factor.tr_fecha_creacion_nro = mesAnterior;
        var grillaHoras = factor.ObtenerGrillaHE();
        int num = grillaHoras.Tables[0].Rows.Count;
        if (txt_maximo_horas.Text != null && txt_maximo_horas.Text != "")
        {
            if (num > 0)
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'Registro de horas extras insertado anteriormente'},{ type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_gv_horasExtras').css('display', 'block');";
                txt_horas.Focus();
                SetScriptDataTable(sc);
            }
            else
            {
                if (Convert.ToInt32(txt_horas.Text) > 0 && Convert.ToInt32(txt_horas.Text) <= Convert.ToInt32(txt_maximo_horas.Text))
                {
                    datosPresupuestariosFinal();
                }
                else
                {
                    Limpiar();
                    sc = "$.notify({ icon: 'fa fa-info', message: 'El número de horas insertado es incorrecto'},{ type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                    txt_horas.Focus();
                    SetScriptDataTable(sc);
                }
            }
        }
        else
        {
            Limpiar();
            sc = "$.notify({ icon: 'fa fa-info', message: 'No se puede asignar horas extras al funcionario seleccionado'},{ type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            txt_horas.Focus();
            SetScriptDataTable(sc);
        }
    }

    protected void btn_cancelar_buscar_Click(object sender, EventArgs e)
    {
        Limpiar();
        sc = " $('#datosPresupuestarios').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
        txt_horas.Focus();
        SetScriptDataTable(sc);
    }

    private string tipoTransaccion()
    {
        factor = new cls_pla_factor();
        factor.fa_id = 1;
        var tipoTrans = factor.ObtenerTipoTrans();
        string tipoTransaccion = "";
        if (tipoTrans.Tables[0].Rows[0]["fa_id"] != DBNull.Value && tipoTrans.Tables[0].Rows[0]["fa_id"].ToString().Trim() != "")
        {
            txt_tipo_transaccion.Text = tipoTrans.Tables[0].Rows[0]["fa_descripcion"].ToString().Trim();
            aux_tipo_transaccion.Value = factor.fa_id.ToString().Trim();
        }
        return tipoTransaccion;
    }

    protected void obtiene_txt_mes_ant()
    {
        DateTime mesAnterior = DateTime.Now.AddMonths(-1);
        string mesAnt = mesAnterior.ToString("MMMM");
        txt_mes.Text = mesAnt.ToUpper();
    }

    private void horasExtras()
    {
        factor = new cls_pla_factor();
        factor.es_id = Convert.ToInt32(aux_es_id.Value);
        factor.gestion_selec = Session["pr_id"].ToString();
        var nroHExtras = factor.ObtenerNroHorasExtras();
        if (nroHExtras.Tables[0].Rows.Count > 0)
        {
            if (nroHExtras.Tables[0].Rows[0]["es_id"] != DBNull.Value && nroHExtras.Tables[0].Rows[0]["es_id"].ToString().Trim() != "")
            {
                txt_maximo_horas.Text = nroHExtras.Tables[0].Rows[0]["cat_descripcion"].ToString().Trim();
            }
        }
    }

    private void datosPresupuestarios()
    {
        factor = new cls_pla_factor();
        factor.eo_id = Convert.ToInt32(aux_eo_id.Value);
        factor.gestion_selec = Session["pr_id"].ToString();
        var datosCategoria = factor.ObtenerCategoriaProg();
        if (datosCategoria.Tables[0].Rows.Count > 0)
        {
            if (datosCategoria.Tables[0].Rows[0]["eo_id"] != DBNull.Value && datosCategoria.Tables[0].Rows[0]["eo_id"].ToString().Trim() != "")
            {
                txt_categoria_prog.Text = datosCategoria.Tables[0].Rows[0]["categoria"].ToString().Trim();
                txt_descripcion.Text = datosCategoria.Tables[0].Rows[0]["cp_descripcion"].ToString().Trim();
            }
        }
    }

    private decimal presupuesto()
    {
        factor = new cls_pla_factor();
        factor.cp_id = Convert.ToInt32(aux_cp_id.Value);
        factor.gestion_selec = Session["pr_id"].ToString();
        var datosPresupuesto = factor.ObtenerPresupuesto();
        decimal datosPresup = 0;
        if (datosPresupuesto.Tables[0].Rows.Count > 0)
        {
            if (datosPresupuesto.Tables[0].Rows[0]["cp_id"] != DBNull.Value && datosPresupuesto.Tables[0].Rows[0]["cp_id"].ToString().Trim() != "")
            {
                string str_datosPresup = datosPresupuesto.Tables[0].Rows[0]["pp_monto"].ToString().Trim();
                datosPresup = Convert.ToDecimal(str_datosPresup);
            }
        }
        return datosPresup;
    }

    private decimal pagadoDevengado()
    {
        factor = new cls_pla_factor();
        factor.cp_id = Convert.ToInt32(aux_cp_id.Value);
        factor.gestion_selec = Session["pr_id"].ToString();
        var datosPagadoDev = factor.ObtenerPagadoDevengado();
        decimal datosPagado = 0;
        if (datosPagadoDev.Tables[0].Rows.Count > 0)
        {
            if (datosPagadoDev.Tables[0].Rows[0]["eo_cp_id"] != DBNull.Value && datosPagadoDev.Tables[0].Rows[0]["eo_cp_id"].ToString().Trim() != "")
            {
                string str_datosPagado = datosPagadoDev.Tables[0].Rows[0]["pagado"].ToString().Trim();
                datosPagado = Convert.ToDecimal(str_datosPagado);
            }
        }
        return datosPagado;
    }

    private decimal comprometido()
    {
        factor = new cls_pla_factor();
        decimal datosComprometido = 0;
        decimal ca_basico_calculado = Convert.ToDecimal(ltl_haber_basico.Text);
        int horas = Convert.ToInt32(txt_horas.Text);
        decimal comprometido = (horas * ca_basico_calculado) / 120;
        comprometido = Math.Round(comprometido, 0);
        datosComprometido = comprometido;
        //double comprometido3 = Math.Round(Convert.ToDouble(comprometido2), 2)/1.00;
        //double comprometido = comprometido1;
        return datosComprometido;
    }

    private void datosPresupuestariosFinal()
    {
        decimal datoPresupuesto = presupuesto();
        decimal datoPagado = pagadoDevengado();
        decimal datoComprometido = comprometido();
        decimal saldo = datoPresupuesto - (datoPagado + datoComprometido);
        txt_presupuesto.Text = Convert.ToString(datoPresupuesto);
        txt_pagado_devengado.Text = Convert.ToString(datoPagado);
        txt_comprometido.Text = Convert.ToString(datoComprometido);
        txt_saldo.Text = Convert.ToString(saldo);
        if (saldo > 0)
        {
            sc = " $('#modalGlosa').modal('show');";
        }
        else
        {
            datosPresupuestarios();
            sc = "$.notify({ icon: 'fa fa-info', message: 'No existe presupuesto para asignar Horas Extras'},{ type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#datosPresupuestarios').modal('show');";
        }
        SetScript(sc);
    }

    protected void Limpiar()
    {
        txt_horas.Text = string.Empty;
        //ddl_tipo_documento.SelectedValue = "0";
        //txt_descripcion_add.Text = string.Empty;
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

    private int obtenerIdTransaccion(int per_id = 0)
    {
        factor = new cls_pla_factor();
        factor.tr_per_id = per_id;
        var transaccion = factor.ObtenerTransaccion();
        int idTransaccionNuevo = 0;
        if (transaccion.Tables[0].Rows[0]["tr_id"] != DBNull.Value && transaccion.Tables[0].Rows[0]["tr_id"].ToString().Trim() != "")
        {
            idTransaccionNuevo = Convert.ToInt32(transaccion.Tables[0].Rows[0]["tr_id"]);
        }
        return idTransaccionNuevo;
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
            // ddl_tipo_documento.Items.Insert(0, new ListItem("Seleccione...", "0"));
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

    private void guardarTransaccion()
    {
        string perId = Session["per_id"].ToString();
        factor = new cls_pla_factor();
        int idProceso = obtenerIdProceso();
        factor.tr_pc_id = idProceso;
        factor.tr_per_id = Convert.ToInt32(aux_per_id.Value);
        factor.tr_fa_id = 1;
        //factor.tr_monto = txt_comprometido.Text;
        factor.tr_monto = txt_horas.Text;
        factor.tr_estado = "V";
        factor.tr_usuario_creacion = Convert.ToInt32(perId);
        factor.AdicionarTransaccion();
        sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-check', message: 'Registro exitoso'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        txt_horas.Focus();
        SetScriptDataTable(sc);
    }

    private void guardarGlosaTransaccion(int per_id = 0)
    {
        string perId = Session["per_id"].ToString();
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;
        int idTransaccion = obtenerIdTransaccion(per_id);
        cargo = new cls_mp_cargo();
        cargo.gl_valor_pk = idTransaccion;
        cargo.gl_nombre_pk = "tr_id";
        cargo.gl_tabla = "tbl_pla_transacciones";
        cargo.gl_tipo_mov = 813;
        cargo.gl_fecha_doc = fechaMov;
        cargo.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        cargo.gl_glosa = txt_descripcion_add.Text;
        cargo.gl_numero_doc = txt_num_doc.Text;
        cargo.gl_estado = "V";
        cargo.gl_usuario = Convert.ToInt32(perId);
        cargo.AdicionarGlosa();
    }

    private void listarGrillaHorasExtras(int per_id = 0)
    {
        try
        {
            string mes = DateTime.Now.ToString("MM");
            int mesAnterior = Convert.ToInt32(mes) - 1;
            factor = new cls_pla_factor();
            factor.tr_per_id = per_id;
            factor.tr_fecha_creacion_nro = mesAnterior;
            var grillaHoras = factor.ObtenerGrillaHE();
            int num = grillaHoras.Tables[0].Rows.Count;
            block_gv_horasExtras.Visible = (num > 0) ? false : true;
            gv_horas_extras.DataSource = grillaHoras;
            gv_horas_extras.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_horas_extras_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_horas_extras.Rows.Count > 0)
        {
            if (gv_horas_extras.HeaderRow != null)
            {
                gv_horas_extras.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_horas_extras.FooterRow != null)
            {
                gv_horas_extras.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_horas_extras_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        aux_tr_id.Value = gv_horas_extras.DataKeys[index].Values[0].ToString();
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarItem').modal('show');";
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
        factor.EliminarTransaccion();
        listarGrillaHorasExtras(per_id);
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarItem').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        txt_horas.Focus();
        SetScript(sc);
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
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
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
                    "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        //string codFun = Request.QueryString["id"].ToString();
        factor = new cls_pla_factor();
        guardarTransaccion();
        int per_id = Convert.ToInt32(aux_per_id.Value);
        guardarGlosaTransaccion(per_id);
        listarGrillaHorasExtras(per_id);
        Limpiar();
        Session["texto_notificacion"] = "¡Registro creado correctamente!";
        Response.Redirect("BuscadorFuncionarioHorasExtras");
    }

    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        Limpiar();
        sc = " $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
        SetScriptDataTable(sc);
    }
}