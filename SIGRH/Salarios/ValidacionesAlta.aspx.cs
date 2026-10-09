using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode.Codec;
using Newtonsoft.Json;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;

public partial class Salarios_Validaciones : System.Web.UI.Page
{
    private cls_mp_asignacion asignacion = null;
    private cls_mp_cargo cargo = null;
    private cls_mp_seguimiento_memorandum seg_memo = null;
    private cls_pc_precontratado precontratado = null;
    string sc = "";
    //fas fa-user-check

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                cargar();
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }

    private void cargar()
    {
        aux_tipo_validacion.Value = "1";
        ltl_nombre_grilla.Text = "Altas";
        try
        {
            string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

            DataSet grillaValida = null;
            grillaValida = seg_memo.ObtenerGrillaAltaRector();
            gv_validar_items.DataSource = grillaValida;
            gv_validar_items.DataBind();

            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
            }
            else
            {
                sc = "$('#block_gv_validar').css('display', 'none'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                sc = sc + "$.notify({ icon: 'fa fa-exclamation', message: 'No se encontraron resultados.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            }
            SetScript(sc);
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    private string convertirDecimal(string hb = "")
    {
        decimal hbVista = (hb != "") ? Convert.ToDecimal(hb) : 0;
        hbVista = Math.Round(hbVista, 2);
        return hbVista + "";
    }

    private void armarEstructura(DataSet p_funcionario)
    {
        var funcionarioDataset = p_funcionario;
        var funcionario = funcionarioDataset.Tables[0].Rows[0];
        ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
        ltl_ci.Text = validarCampo(funcionario["ci"]);
        ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
        ltl_cargo.Text = validarCampo(funcionario["cargo"]);
        ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
        ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
        ltl_programatica.Text = validarCampo(funcionario["cod_prog"]);
        ltl_escalafon.Text = validarCampo(funcionario["es_escalafon"]) + " - " + validarCampo(funcionario["ns_clase"]) + " - " + validarCampo(funcionario["ns_nivel"]);
        ltl_haber_basico.Text = convertirDecimal(validarCampo(funcionario["haber_basico"]));
        ltl_item.Text = validarCampo(funcionario["item"]);
        ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
        ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
        ltl_tipo_jornada.Text = validarCampo(funcionario["ca_tipo_jornada"]);
        ltl_cat_ubicacion.Text = validarCampo(funcionario["cp_descripcion"]);
        ltl_cat_programatica.Text = validarCampo(funcionario["cat_prog"]);
        hf_ti_item.Value = validarCampo(funcionario["ti_item"]);
        HF_TI_TIPO.Value = validarCampo(funcionario["ti_tipo"]);
        aux_as_id.Value = (funcionarioDataset.Tables[0].Columns.Contains("as_id")) ? validarCampo(funcionario["as_id"]) : (funcionarioDataset.Tables[0].Columns.Contains("ci_id")) ? validarCampo(funcionario["ci_id"]) : validarCampo(funcionario["mv_id"]);
        aux_as_per_id.Value = validarCampo(funcionario["per_id"]);
        string estado = (funcionarioDataset.Tables[0].Columns.Contains("as_estado")) ? "as_estado" : (funcionarioDataset.Tables[0].Columns.Contains("ci_estado")) ? "ci_estado" : "mv_estado";
        if (validarCampo(funcionario[estado]) == "V")
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
            imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])funcionarioDataset.Tables[0].Rows[0]["fp_foto"]);
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

        /*INFORMACIÓN EXTRA COMISION INTERINATO*/
        if (funcionarioDataset.Tables[0].Columns.Contains("ci_id"))
        {
            if (validarCampo(funcionario["ci_id"]) != "")
            {
                llenarDatosFunCI(funcionarioDataset);
            }
        }

        /*INFORMACIÓN EXTRA MEMORANDUM VARIOS*/
        if (funcionarioDataset.Tables[0].Columns.Contains("mv_id"))
        {
            if (validarCampo(funcionario["mv_id"]) != "")
            {
                llenarDatosFunMV(funcionarioDataset);
            }
        }
    }

    private void llenarDatosFunCI(DataSet p_funcionario)
    {
        var funcionarioDataset = p_funcionario;
        var funcionario = funcionarioDataset.Tables[0].Rows[0];
        aux_as_id.Value = validarCampo(funcionario["ci_id"]);
        ltl_nombre_fun_int.Text = validarCampo(funcionario["nombreFunInt"]);
        ltl_ci_int.Text = validarCampo(funcionario["ciFunInt"]);
        ltl_item_int.Text = validarCampo(funcionario["itemFunInt"]);
        ltl_ubicacion_int.Text = validarCampo(funcionario["ubicacion_int"]);
        ltl_programatica_int.Text = validarCampo(funcionario["cod_prog_int"]);
        ltl_cargo_int.Text = validarCampo(funcionario["cargo_int"]);
        ltl_puesto_int.Text = validarCampo(funcionario["puesto_int"]);
        ltl_haber_basico_int.Text = convertirDecimal(validarCampo(funcionario["ca_basico_calculado_int"]));
        ltl_fecha_inicio_int.Text = validarCampo(funcionario["as_fecha_inicio_int"]);
        ltl_fecha_fin_int.Text = validarCampo(funcionario["as_fecha_fin_int"]);
        ltl_memo_int.Text = validarCampo(funcionario["ci_memo"]);
        ltl_tipo_int.Text = validarCampo(funcionario["tipo"]);

        sc = (ltl_tipo_int.Text == "INTERINATO") ? "$('#block_datos_adicionales_int').css('display', 'block');" : "$('#block_datos_adicionales_int').css('display', 'none');";
        SetScript(sc);
    }
    
    private void llenarDatosFunMV(DataSet p_funcionario)
    {
        var funcionarioDataset = p_funcionario;
        var funcionario = funcionarioDataset.Tables[0].Rows[0];
        ltl_descMovimiento_memo.Text = validarCampo(funcionario["mv_tipo"]);
        ltl_num_memo.Text = validarCampo(funcionario["mv_nro_memo"]);
    }

    private void informacionFuncionarioAlta(int as_id = 0)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var detalleFuncionario = seg_memo.obtenerDatosInformacionAlta();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            }
            SetScript(sc);
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

    protected void btn_guardar_validacion_Click(object sender, EventArgs e)
    {
        
    }

    private bool tieneBaja(int as_id = 0)
    {
        bool sw = false;
        //seg_memo = new cls_mp_seguimiento_memorandum();
        //seg_memo.as_id = as_id;
        var detalle_baja = seg_memo.ObtenerValidacionBaja();

        sw = (detalle_baja.Tables[0].Rows.Count > 0);
        return sw;
    }

    private void actualizarGrilla()
    {
        cargar();
    }

    private bool gestionCorrecto(string fecha_valida = "")
    {
        int pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        bool sw = false;

        if (fecha_valida != null && fecha_valida != "")
        {
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

            DateTime fecha_valida_x = Convert.ToDateTime(fecha_valida);

            if (fecha_valida_x.Year.ToString() == gestion_x)
            {
                sw = true;
            }
        }
        return sw;
    }

    protected void gv_validar_items_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_validar_items.Rows.Count > 0)
        {
            if (gv_validar_items.HeaderRow != null)
            {
                gv_validar_items.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_validar_items.FooterRow != null)
            {
                gv_validar_items.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_validar_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        int as_id = Convert.ToInt32(gv_validar_items.DataKeys[index].Values[0].ToString());
        informacionFuncionarioAlta(as_id);
        if (e.CommandName == "Aprobar")
        {
            //int us_id = Convert.ToInt32(Session["us_id"].ToString());
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_id = as_id;
            seg_memo.usuario_creacion = Convert.ToInt32(Session["us_id"]);
            seg_memo.as_fecha_inicio = ltl_fecha_inicio.Text;
            seg_memo.as_fecha_fin = ltl_fecha_fin.Text;

            string aux = "";
            string aux_sc = "";
            if (aux_tipo_validacion.Value != "")
            {
                aux = " $('#block_gv_validar').css('display', 'block'); ";
            }

            if (tieneBaja(as_id))
            {
                aux_sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, el funcionario tiene una baja pendiente por validar.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            }
            else
            {
                if (gestionCorrecto(ltl_fecha_inicio.Text))
                {
                    seg_memo.ActualizarValidacionAlta();
                    aux_sc = "Swal.fire({ icon: 'success', title: 'Validación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); " + aux + " }});";
                }
                else
                {
                    aux_sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, revise la fecha asignada por favor.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                }
            }
            actualizarGrilla();
            SetScript(aux_sc);
        }
        if (e.CommandName == "Reprobar")
        {
            asignacion = new cls_mp_asignacion();
            asignacion.as_id = as_id;
            asignacion.as_per_id = Convert.ToInt32(ltl_cod_fun.Text);
            asignacion.as_ca_id = Convert.ToInt32(gv_validar_items.DataKeys[index].Values[2].ToString());
            asignacion.ti_item = hf_ti_item.Value;
            asignacion.ti_tipo = HF_TI_TIPO.Value;

            asignacion.ReprobarAlta();
            sc = "Swal.fire({ icon: 'success', title: 'Registro reprobado', text: 'Registro reprobado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  $('#modalDetalleMovimiento').modal('hide'); $('#reprobarMov').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#grillaMov').css('display', 'none'); }});";

            SetScript(sc);
        }
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
        sb.Append("$('.ql-editor').css('border', 'none'); $('.ql-container.ql-snow').css('border', 'none'); $('.ql-editor').css('padding', '0rem .75rem');");
        sb.Append(data);
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10}); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_listar_altas_Click(object sender, EventArgs e)
    {
        aux_tipo_validacion.Value = "1";
        ltl_nombre_grilla.Text = "Altas";
        try
        {
            string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaValidaAlta();
            gv_validar_items.DataSource = grillaValida;
            gv_validar_items.DataBind();

            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
            }
            else
            {
                sc = "$('#block_gv_validar').css('display', 'none'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                sc = sc + "$.notify({ icon: 'fa fa-exclamation', message: 'No se encontraron resultados.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            }
            SetScript(sc);
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_altasCI_Click(object sender, EventArgs e)
    {
        aux_tipo_validacion.Value = "4";
        ltl_nombre_grilla.Text = "Altas Comisión e Interinato";
        try
        {
            string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaValidaAltaCI();
            gv_validar_items.DataSource = grillaValida;
            gv_validar_items.DataBind();

            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
            }
            else
            {
                sc = "$('#block_gv_validar').css('display', 'none'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                sc = sc + "$.notify({ icon: 'fa fa-exclamation', message: 'No se encontraron resultados.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            }
            SetScript(sc);
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_estado_Click(object sender, EventArgs e)
    {
        SetScript("");
    }
}