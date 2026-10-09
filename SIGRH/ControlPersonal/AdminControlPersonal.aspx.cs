using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;


public partial class ControlPersonal_AdminControlPersonal : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_cp_controles_personal control_personal = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
            listarGrillaEdificio();
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
                aux_per_id.Value = validarCampo(funcionario["per_id"]);
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

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.fecha').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");

        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_edificio').select2({ dropdownParent: $('#modalNuevoEdificio') });");
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
                    "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true });");

        sb.Append("$('#ContentPlaceHolder1_gv_items_filter').css({ display: 'none' }); var me = $('.datepicker'); me.mask('99/99/9999');");

        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append("$('.radios label').addClass('custom-control-label mb-3');");
        sb.Append("$('.radios input[type=" + '"' + "radio" + '"' + "]').addClass('custom-control-input mb-3');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }


    protected void gv_asignacionEdificio_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_asignacionEdificio.Rows.Count > 0)
        {
            if (gv_asignacionEdificio.HeaderRow != null)
            {
                gv_asignacionEdificio.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_asignacionEdificio.FooterRow != null)
            {
                gv_asignacionEdificio.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_asignacionEdificio_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string cp_id = gv_asignacionEdificio.DataKeys[index].Values[0].ToString();
        string cp_edificio = gv_asignacionEdificio.DataKeys[index].Values[1].ToString();
        aux_cp_id.Value = cp_id;
        aux_cp_edificio.Value = cp_edificio;
        switch (e.CommandName)
        {
            case "GetEdit":
                aux_accion.Value = "1";
                ltl_titulo.Text = "EDITAR ASIGNACIÓN EDIFICIO";
                listarTipoEdificioEditar(Convert.ToInt32(aux_cp_edificio.Value));
                LlenarDatosAsigEdificio(Convert.ToInt32(aux_cp_id.Value));
                sc = "$('#modalNuevoEdificio').modal('show');";
                SetScript(sc);
                break;
            case "GetBaja":
                LlenarDatosBajaEdificio(Convert.ToInt32(aux_cp_id.Value));
                sc = "$('#modalBajaEdificio').modal('show');";
                SetScript(sc);
                break;
            case "GetDelete":
                sc = "$('#modalEliminarEdificio').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    private void listarGrillaEdificio()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            control_personal = new cls_cp_controles_personal();
            control_personal.cp_per_id = per_id;
            var edificio = control_personal.ListarGrillaEdificio();
            int tam = edificio.Tables[0].Rows.Count;
            if (edificio.Tables[0].Rows.Count > 0)
            {
                gv_asignacionEdificio.DataSource = edificio;
                this.block_notificacion.Visible = false;
            }
            else
            {
                this.block_notificacion.Visible = true;
            }
            gv_asignacionEdificio.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_nuevo_edificio_Click(object sender, EventArgs e)
    {
        Limpiar();
        aux_accion.Value = "0";
        ltl_titulo.Text = "REGISTRAR NUEVA ASIGNACIÓN EDIFICIO";
        listarTipoEdificio();
        sc = "$('#modalNuevoEdificio').modal('show');";
        SetScript(sc);
    }

    private void listarTipoEdificio()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        control_personal = new cls_cp_controles_personal();
        control_personal.cp_per_id = per_id;
        ddl_tipo_edificio.Items.Clear();
        ddl_tipo_edificio.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_edificio.DataValueField = "cat_secuencial";
        ddl_tipo_edificio.DataTextField = "cat_descripcion";
        ddl_tipo_edificio.DataSource = control_personal.ListarFiltradoEdificio();
        ddl_tipo_edificio.DataBind();
    }

    private void listarTipoEdificioEditar(int cp_edificio = 0)
    {
        ddl_tipo_edificio.Items.Clear();
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        control_personal = new cls_cp_controles_personal();
        control_personal.cp_per_id = per_id;
        control_personal.cp_edificio = cp_edificio;
        ddl_tipo_edificio.Items.Clear();
        ddl_tipo_edificio.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_edificio.DataValueField = "cat_secuencial";
        ddl_tipo_edificio.DataTextField = "cat_descripcion";
        ddl_tipo_edificio.DataSource = control_personal.ListarFiltradoEdificioEditar();
        ddl_tipo_edificio.DataBind();
    }

    protected void btnGuardarEdificio_Click(object sender, EventArgs e)
    {
        if (aux_accion.Value == "1")
        {
            EditarAsignacionEdificio();
        }
        else
        {
            GuardarNuevoAsignaciónEdificio();
        }
        Limpiar();
        listarGrillaEdificio();
    }

    private void GuardarNuevoAsignaciónEdificio()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        control_personal = new cls_cp_controles_personal
        {
            cp_per_id = per_id,
            cp_edificio = Convert.ToInt32(ddl_tipo_edificio.SelectedValue),
            cp_fecha_inicio = txt_fecha_alta.Text
        };
        control_personal.Adicionar();
        sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Edificio asignado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevoEdificio').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void Limpiar()
    {
        ddl_tipo_edificio.SelectedValue = "0";
        txt_fecha_alta.Text = string.Empty;
        txt_fecha_baja.Text = string.Empty;
    }

    protected void LlenarDatosAsigEdificio(int cp_id = 0)
    {
        control_personal = new cls_cp_controles_personal();
        control_personal.cp_id = cp_id;
        var detalleEdificio = control_personal.ObtieneAsignacionEdicioX();
        var edificioX = detalleEdificio.Tables[0].Rows[0];
        txt_fecha_alta.Text = validarCampo(edificioX["cp_fecha_inicio"]);
        ddl_tipo_edificio.SelectedValue = (validarCampo(edificioX["cp_edificio"]) != "") ? validarCampo(edificioX["cp_edificio"]) : "0";
    }

    private void EditarAsignacionEdificio()
    {
        control_personal = new cls_cp_controles_personal();
        control_personal.cp_id = Convert.ToInt32(aux_cp_id.Value);
        control_personal.cp_fecha_inicio = txt_fecha_alta.Text;
        control_personal.cp_edificio = Convert.ToInt32(ddl_tipo_edificio.SelectedValue);
        control_personal.Actualizar();
        sc = "$.notify({ icon: 'fa fa-check', message: 'Asignación Edificio editado correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });$('#modalNuevoEdificio').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_eliminar_edificio_Click(object sender, EventArgs e)
    {
        control_personal = new cls_cp_controles_personal();
        control_personal.cp_id = Convert.ToInt32(aux_cp_id.Value);
        control_personal.Eliminar();
        listarGrillaEdificio();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#modalEliminarEdificio').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void LlenarDatosBajaEdificio(int cp_id = 0)
    {
        control_personal = new cls_cp_controles_personal();
        control_personal.cp_id = cp_id;
        var detalleEdificio = control_personal.ObtieneAsignacionEdicioX();
        var edificioX = detalleEdificio.Tables[0].Rows[0];
        ltl_fecha_alta.Text = validarCampo(edificioX["cp_fecha_inicio"]);
        ltl_edificio.Text = validarCampo(edificioX["edificio"]);
        txt_fecha_baja.Text = string.Empty;
    }

    protected void btn_asignarFechaBaja_Click(object sender, EventArgs e)
    {
        DateTime startDate = Convert.ToDateTime(ltl_fecha_alta.Text);
        DateTime endDate = Convert.ToDateTime(txt_fecha_baja.Text);
        double diferencia = (endDate - startDate).TotalDays;
        if (diferencia >= 0)
        {
            control_personal = new cls_cp_controles_personal
            {
                cp_id = Convert.ToInt32(aux_cp_id.Value),
                cp_fecha_final = txt_fecha_baja.Text
            };
            control_personal.AdicionarFechaBaja();
            Limpiar();
            listarGrillaEdificio();
            sc = "Swal.fire({ icon: 'success', title: 'Baja exitosa', text: 'Baja registrada exitosamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalBajaEdificio').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'La fecha alta deber ser mayor o igual a la fecha baja.'},{ type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

}