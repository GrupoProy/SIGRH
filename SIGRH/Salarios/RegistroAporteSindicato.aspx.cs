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

public partial class Salarios_RegistroAporteSindicato : System.Web.UI.Page
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
            listaFiltradoTipoSindicato();
            listaFiltradoTipoDoc();
            listaFiltradoEstadoAporte();
            listarGrillaAporteSindicato();
            SetScriptInicio("$('.table').DataTable().destroy(); ");
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
                string haberBasico = validarCampo(funcionario["haber_basico"]);
                decimal haberBasico2 = Convert.ToDecimal(haberBasico);
                haberBasico2 = Math.Round(haberBasico2, 2);
                ltl_haber_basico.Text = Convert.ToString(haberBasico2);
                ltl_jornada.Text= validarCampo(funcionario["ca_tipo_jornada_lit"]);
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
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_aporte').select2({ placeholder: { id: '-1', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
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
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_transaccion').select2({ placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_aporte').select2({ placeholder: { id: '-1', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
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
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
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

            int[] ids = { 816, 819, 820, 6475 };

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

    private void listaFiltradoTipoSindicato()
    {
        try
        {
            factor = new cls_pla_factor();

            ddl_tipo_transaccion.Items.Clear();
            ddl_tipo_transaccion.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_transaccion.DataValueField = "fa_id";
            ddl_tipo_transaccion.DataTextField = "fa_descripcion";
            ddl_tipo_transaccion.DataSource = factor.ObtenerTipoSindicato();
            ddl_tipo_transaccion.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoEstadoAporte()
    {
        try
        {
            factor = new cls_pla_factor();
            int tam = factor.ObtenerTipoEstadoAporte().Tables[0].Rows.Count;
            ddl_tipo_aporte.Items.Clear();
            ddl_tipo_aporte.Items.Insert(0, new ListItem("Seleccione...", "-1"));
            ddl_tipo_aporte.DataValueField = "cat_secuencial";
            ddl_tipo_aporte.DataTextField = "cat_descripcion";
            ddl_tipo_aporte.DataSource = factor.ObtenerTipoEstadoAporte();
            ddl_tipo_aporte.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
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

    private void guardarAporteSindicato()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        factor = new cls_pla_factor();
        int id_proceso = obtenerIdProceso();
        factor.tr_pc_id = id_proceso;
        factor.tr_per_id = per_id;
        factor.tr_fa_id = Convert.ToInt32(ddl_tipo_transaccion.SelectedValue);
        factor.tr_monto = ddl_tipo_aporte.SelectedValue;
        factor.tr_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString());
        factor.AdicionarTransaccion();
        ltl_valor_descuento_sindicato.Text = "";
    }

    protected void btn_guardar_aporte_Click(object sender, EventArgs e)
    {
        string mes = DateTime.Now.ToString("MM");
        factor = new cls_pla_factor();
        factor.tr_per_id = Convert.ToInt32(aux_per_id.Value);
        factor.tr_fecha_creacion_nro = Convert.ToInt32(mes);
        var grillaAporte = factor.ObtenerGrillaAporteSindicato();
        int num = grillaAporte.Tables[0].Rows.Count;
        if (num > 0)
        {
            Limpiar();
            sc = "$.notify({ icon: 'fa fa-info', message: 'Registro insertado anteriormente'},{ type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
        else
        {
            restablecerGlosa();
            sc = "$('#modalGlosa').modal('show');";
            SetScript(sc);
        }
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

    private void listarGrillaAporteSindicato()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            factor = new cls_pla_factor();
            factor.tr_per_id = per_id;
            var aportes = factor.ListarGrillaAporteSindicato();
            int tam = aportes.Tables[0].Rows.Count;
            if (aportes.Tables[0].Rows.Count > 0)
            {
                gv_aporte_sindicato.DataSource = aportes;
                this.block_familia.Visible = false;
            }
            else
            {
                this.block_familia.Visible = true;
            }
            gv_aporte_sindicato.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_aporte_sindicato_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_aporte_sindicato.Rows.Count > 0)
        {
            if (gv_aporte_sindicato.HeaderRow != null)
            {
                gv_aporte_sindicato.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_aporte_sindicato.FooterRow != null)
            {
                gv_aporte_sindicato.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_aporte_sindicato_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string tr_id = gv_aporte_sindicato.DataKeys[index].Values[0].ToString();
        aux_tr_id.Value = tr_id;
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarAporteSindicato').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    protected void btn_eliminar_aporte_sindicato_Click(object sender, EventArgs e)
    {
        factor = new cls_pla_factor();
        factor.tr_id = Convert.ToInt32(aux_tr_id.Value);
        factor.tr_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString());
        factor.EliminarTransaccion();
        Limpiar();
        listarGrillaAporteSindicato();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });$('#eliminarAporteSindicato').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void Limpiar()
    {
        ddl_tipo_transaccion.SelectedValue = "0";
        ddl_tipo_aporte.SelectedValue = "-1";
        ddl_tipo_documento.SelectedValue = "0";
        txt_descripcion_add.Text = string.Empty;
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        guardarAporteSindicato();
        guardarGlosaTransaccion(per_id);
        Limpiar();
        listarGrillaAporteSindicato();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        sc = " $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        Limpiar();
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
    protected void ddl_tipo_aporte_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_pla_factor factor = new cls_pla_factor();

        ltl_valor_descuento_sindicato.Text = "Bs " + Math.Round( Convert.ToDouble(factor.ObtenerRegistro(32).Tables[0].Rows[0]["fa_valor"].ToString()),2);

    }
    }