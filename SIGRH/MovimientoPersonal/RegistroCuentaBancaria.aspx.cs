using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using System.Text;

public partial class MovimientoPersonal_RegistroCuentaBancaria : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_catalogo _catalogo = null;
    private cls_mp_tipo_abono tipo_abono = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
            listarTipoAbono();
            listarBanco();
            listaFiltradoTipoDoc();
            listar_cuentas();
            SetScriptInicio("$('.table').DataTable().destroy(); ");
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
       
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
    }
    private void listarTipoAbono()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_abono" };
        ddl_tipo_abono.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_abono.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_tipo_abono.DataValueField = "cat_abreviacion";
        ddl_tipo_abono.DataTextField = "cat_descripcion";
        ddl_tipo_abono.DataBind();

        foreach (ListItem ltItem in ddl_tipo_abono.Items)
        {
            if (ltItem.Value == "SA")
            {
                ltItem.Text = "SIN CUENTA";
            }
            if (ltItem.Value == "CB")
            {
                ltItem.Text = "CUENTA";
            }
        }
        ddl_tipo_abono.SelectedValue = "CB";
    }
    private void listarBanco()
    {
        _catalogo = new cls_catalogo { cat_tabla = "banco_autorizado" };
        ddl_banco.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_banco.DataValueField = "cat_secuencial";
        ddl_banco.DataTextField = "cat_descripcion";
        ddl_banco.DataBind();
    }
    private void listaFiltradoTipoDoc()
    {
        try
        {
            cargo = new cls_mp_cargo();

            ddl_tipo_documento.Items.Clear();
            ddl_tipo_documento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_documento.DataValueField = "cat_id";
            ddl_tipo_documento.DataTextField = "cat_descripcion";
            ddl_tipo_documento.DataSource = cargo.ObtenerFiltradoTipoDoc();
            ddl_tipo_documento.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listar_cuentas()
    {

        try
        {
            int per_id = (Request.QueryString["id"].ToString() != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
            tipo_abono = new cls_mp_tipo_abono();
            tipo_abono.cb_per_id = per_id;
            var cuentas = tipo_abono.ObtenerGrillaCuentas();
            gv_cuentas.DataSource = cuentas;
            gv_cuentas.DataBind();
            no_existe_cuentas.Visible = !(cuentas.Tables[0].Rows.Count > 0);
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
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
                ltl_programatica.Text = validarCampo(funcionario["cod_prog"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_cod_esc.Text = validarCampo(funcionario["es_escalafon"]);
                ltl_clase.Text = validarCampo(funcionario["ns_clase"]);
                ltl_nivel_salarial.Text = validarCampo(funcionario["ns_nivel"]);
                ltl_haber_basico.Text = Math.Round(Convert.ToDouble(funcionario["haber_basico"].ToString()), 2).ToString("0.00"); // validarCampo(funcionario["haber_basico"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                //ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                //ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                //ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);

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

    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }

    protected void btn_guardar_cuenta_Click(object sender, EventArgs e)
    {
        int per_id = (Request.QueryString["id"].ToString() != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        tipo_abono = new cls_mp_tipo_abono();
        tipo_abono.cb_per_id = per_id;
        var detalle_tipo_abono = tipo_abono.ObteneTipoAbonoVigente();
        if (detalle_tipo_abono.Tables[0].Rows.Count > 0)
        {
            sc = "$.notify({ icon: 'fa fa-info', message: 'No se puede realizar la acción, el funcionario tiene ya un registro de pago.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
        else
        {
            if (txt_nro_cuenta.Text == txt_confirm_nro_cuenta.Text)
            {
                sc = "$('#modalGlosa').modal('show');";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-info', message: 'El número de cuenta no coincide, por favor verifique.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
            }
        }

    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append("var me = $('.accountBank'); me.mask('9-00000-99999999'); ");

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
            "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        ddl_tipo_documento.SelectedValue = "0";
        txt_fechaMov.Text = "";
        txt_descripcion_add.Text = "";
        sc = " $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
        SetScript(sc);
    }
    protected void btn_guardar_Click(object sender, EventArgs e)
    {
        int per_id = (Request.QueryString["id"].ToString() != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;

        tipo_abono = new cls_mp_tipo_abono();
        tipo_abono.cb_cod_banco = Convert.ToInt32(ddl_banco.SelectedValue);
        tipo_abono.cb_per_id = per_id;
        tipo_abono.cb_num_cuenta = (ddl_tipo_abono.SelectedValue.Trim() == "CB") ? txt_nro_cuenta.Text : "";
        tipo_abono.cb_tipo_abono = ddl_tipo_abono.SelectedValue;
        tipo_abono.cb_fecha_formulario = (ddl_tipo_abono.SelectedValue.Trim() == "CB") ? txt_fecha_form.Text : null;

        var detalle_tipo_abono = tipo_abono.Adicionar();
        if (detalle_tipo_abono.Tables[0].Rows.Count > 0)
        {
            int cb_id = Convert.ToInt32(validarCampo(detalle_tipo_abono.Tables[0].Rows[0]["cb_id"]));
            guardarGlosa(cb_id);
            listar_cuentas();
            limpiar();
            sc = "Swal.fire({ icon: 'success', title: 'Cuenta guardada.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false); }});";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }

    private void guardarGlosa(int cb_id = 0)
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;
        cargo = new cls_mp_cargo();
        cargo.gl_valor_pk = cb_id;
        cargo.gl_nombre_pk = "cb_id";
        cargo.gl_tabla = "tbl_mp_tipo_abono";
        cargo.gl_tipo_mov = 813;
        cargo.gl_fecha_doc = fechaMov;
        cargo.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        cargo.gl_glosa = txt_descripcion_add.Text;
        cargo.gl_estado = "V";
        cargo.gl_usuario = Convert.ToInt32(Session["us_id"].ToString());
        cargo.AdicionarGlosa();
    }

    protected void ddl_tipo_abono_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_tipo_abono.SelectedValue.Trim() == "CB")
        {
            rv_ddl_banco.Enabled = true;
            rv_txt_fecha_form.Enabled = true;
            rv_txt_nro_cuenta.Enabled = true;
            rv_txt_confirm_nro_cuenta.Enabled = true;
            d_datos_cuenta.Visible = true;
        } else
        {
            rv_ddl_banco.Enabled = false;
            rv_txt_fecha_form.Enabled = false;
            rv_txt_nro_cuenta.Enabled = false;
            rv_txt_confirm_nro_cuenta.Enabled = false;
            d_datos_cuenta.Visible = false;
        }
        SetScript("");
    }
    private void limpiar()
    {
        ddl_tipo_abono.SelectedValue = "0";
        ddl_banco.SelectedIndex = 0;//.SelectedValue = "4";
        txt_fecha_form.Text = "";
        txt_nro_cuenta.Text = "";
        txt_confirm_nro_cuenta.Text = "";
        d_datos_cuenta.Visible = true;
        txt_descripcion_add.Text = "";
        ddl_tipo_documento.SelectedValue = "0";
        txt_fechaMov.Text = "";
    }
    protected void gv_cuentas_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_cuentas.Rows.Count > 0)
        {
            if (gv_cuentas.HeaderRow != null)
            {
                gv_cuentas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_cuentas.FooterRow != null)
            {
                gv_cuentas.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_cuentas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_cb_id.Value = gv_cuentas.DataKeys[index].Values[0].ToString();

        switch (e.CommandName)
        {
            case "GetAnular":
                sc = "$('#anularCuenta').modal('show');";
                SetScript(sc);
                break;
            case "GetBaja":
                sc = "$('#bajaCuenta').modal('show');";
                SetScript(sc);
                break;

        }
    }

    protected void btn_anular_cuenta_Click(object sender, EventArgs e)
    {
        int cb_id = Convert.ToInt32(hf_cb_id.Value);
        tipo_abono = new cls_mp_tipo_abono();
        tipo_abono.cb_id = cb_id;
        tipo_abono.cb_estado = "S";
        tipo_abono.Eliminar();
        listar_cuentas();
        limpiar();
        sc = "Swal.fire({ icon: 'success', title: 'Cuenta anulada correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#anularCuenta').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false); }});";
        SetScript(sc);
    }

    protected void btn_baja_cuenta_Click(object sender, EventArgs e)
    {
        int cb_id = Convert.ToInt32(hf_cb_id.Value);
        tipo_abono = new cls_mp_tipo_abono();
        tipo_abono.cb_id = cb_id;
        tipo_abono.cb_estado = "C";
        tipo_abono.Eliminar();
        listar_cuentas();
        limpiar();
        sc = "Swal.fire({ icon: 'success', title: 'Se canceló la cuenta bancaria.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#bajaCuenta').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false); }});";
        SetScript(sc);
    }
}