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
public partial class Salarios_ReprobarValidaciones : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_mp_seguimiento_memorandum seg_memo = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listaFiltradoTipoValidacion();
            informacionTotalValidar();
        }
    }

    private void informacionTotalValidar()
    {
        //string gestionFiltrar = obtenerGestion();
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        //+++++cambiar las url de las var grilla USAR LOS COMENTADOS +++++++++
        //var grillaAlta = seg_memo.obtenerCantidadReprobarAlta();
        var grillaAlta = seg_memo.obtenerCantidadValidaAlta();
        //var grillaBaja = seg_memo.obtenerCantidadReprobarBaja();
        var grillaBaja = seg_memo.obtenerCantidadValidaBaja();
        //var grillaRPT = seg_memo.obtenerCantidadReprobarRPT();
        var grillaRPT = seg_memo.obtenerCantidadValidaRPT();
        //var grillaAltaCI = seg_memo.obtenerCantidadReprobarAltaCI();
        var grillaAltaCI = seg_memo.obtenerCantidadValidaAltaCI();
        //var grillaBajaCI = seg_memo.obtenerCantidadReprobarBajaCI();       
        var grillaBajaCI = seg_memo.obtenerCantidadValidaBajaCI();
        //var grillaMemosVarios = seg_memo.obtenerCantidadReprobarMemosVarios();
        var grillaMemosVarios = seg_memo.obtenerCantidadValidaMemosVarios();
        if (grillaAlta.Tables.Count > 0)
        {
            int nro = Convert.ToInt32(grillaAlta.Tables[0].Rows[0]["cantidad_validar"].ToString());
            ltl_valida_alta.Text = Convert.ToString(nro);
        }
        if (grillaBaja.Tables.Count > 0)
        {
            int nro = Convert.ToInt32(grillaBaja.Tables[0].Rows[0]["cantidad_validar"].ToString());
            ltl_valida_baja.Text = Convert.ToString(nro);
        }
        if (grillaRPT.Tables.Count > 0)
        {
            int nro = Convert.ToInt32(grillaRPT.Tables[0].Rows[0]["cantidad_validar"].ToString());
            ltl_valida_RPT.Text = Convert.ToString(nro);
        }
        if (grillaAltaCI.Tables.Count > 0)
        {
            int nro = Convert.ToInt32(grillaAltaCI.Tables[0].Rows[0]["cantidad_validar"].ToString());
            ltl_valida_altaCI.Text = Convert.ToString(nro);
        }
        if (grillaBajaCI.Tables.Count > 0)
        {
            int nro = Convert.ToInt32(grillaBajaCI.Tables[0].Rows[0]["cantidad_validar"].ToString());
            ltl_valida_bajaCI.Text = Convert.ToString(nro);
        }
        if (grillaMemosVarios.Tables.Count > 0)
        {
            int nro = Convert.ToInt32(grillaMemosVarios.Tables[0].Rows[0]["cantidad_validar"].ToString());
            ltl_valida_memosVarios.Text = Convert.ToString(nro);
        }
    }

    private void listaFiltradoTipoValidacion()
    {
        try
        {
            seg_memo = new cls_mp_seguimiento_memorandum();

            ddl_validaMemo.Items.Clear();
            ddl_validaMemo.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_validaMemo.DataValueField = "cat_secuencial";
            ddl_validaMemo.DataTextField = "cat_descripcion";
            ddl_validaMemo.DataSource = seg_memo.listaFiltradoTipoValidacion();
            ddl_validaMemo.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    //private string obtenerGestion()
    //{
    //    cargo = new cls_mp_cargo();
    //    //string anio = DateTime.Now.ToString("yyyy");
    //    string anio = "2019";
    //    cargo.gestion = anio;
    //    var gestionActual = cargo.ObtenerGestion();

    //    string gestionFiltrar = "";
    //    if (gestionActual.Tables[0].Rows[0]["pr_id"] != DBNull.Value && gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim() != "")
    //    {
    //        gestionFiltrar = gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim();
    //    }
    //    return gestionFiltrar;
    //}

    private void armarEstructura(DataSet p_funcionario)
    {
        var funcionarioDataset = p_funcionario;
        var funcionario = funcionarioDataset.Tables[0].Rows[0];

        ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
        ltl_ci.Text = validarCampo(funcionario["ci"]);
        ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
        ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
        ltl_programatica.Text = validarCampo(funcionario["cod_prog"]);
        ltl_cargo.Text = validarCampo(funcionario["cargo"]);
        ltl_cod_esc.Text = validarCampo(funcionario["es_escalafon"]);
        ltl_clase.Text = validarCampo(funcionario["ns_clase"]);
        ltl_nivel_salarial.Text = validarCampo(funcionario["ns_nivel"]);
        ltl_haber_basico.Text = validarCampo(funcionario["haber_basico"]);
        ltl_item.Text = validarCampo(funcionario["item"]);
        ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
        ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
        ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
        ltl_cat_ubicacion.Text = validarCampo(funcionario["cp_descripcion"]);
        ltl_cat_programatica.Text = validarCampo(funcionario["cat_prog"]);
        //txt_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
        //txt_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
        aux_as_id.Value = (funcionarioDataset.Tables[0].Columns.Contains("as_id")) ? validarCampo(funcionario["as_id"]) : (funcionarioDataset.Tables[0].Columns.Contains("ci_id")) ? validarCampo(funcionario["ci_id"]) : validarCampo(funcionario["tf_id"]);
        aux_as_per_id.Value = validarCampo(funcionario["per_id"]);
        string estado = (funcionarioDataset.Tables[0].Columns.Contains("as_estado")) ? "as_estado" : (funcionarioDataset.Tables[0].Columns.Contains("ci_estado")) ? "ci_estado" : "tf_estado";
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
        if (funcionarioDataset.Tables[0].Columns.Contains("tf_id"))
        {
            if (validarCampo(funcionario["tf_id"]) != "")
            {
                llenarDatosFunMV(funcionarioDataset);
            }
        }
    }

    private void llenarDatosFunCI(DataSet p_funcionario)
    {
        var funcionarioDataset = p_funcionario;
        var funcionario = funcionarioDataset.Tables[0].Rows[0];

        ltl_cod_fun_int.Text = validarCampo(funcionario["perIdFunInt"]);
        aux_as_id.Value = validarCampo(funcionario["ci_id"]);
        ltl_nombre_fun_int.Text = validarCampo(funcionario["nombreFunInt"]);
        ltl_ci_int.Text = validarCampo(funcionario["ciFunInt"]);
        ltl_item_int.Text = validarCampo(funcionario["itemFunInt"]);
        ltl_ubicacion_int.Text = validarCampo(funcionario["ubicacion_int"]);
        ltl_programatica_int.Text = validarCampo(funcionario["cod_prog_int"]);
        ltl_cargo_int.Text = validarCampo(funcionario["cargo_int"]);
        ltl_cod_esc_int.Text = validarCampo(funcionario["es_escalafon_int"]);
        ltl_clase_int.Text = validarCampo(funcionario["ns_clase_int"]);
        ltl_nivel_salarial_int.Text = validarCampo(funcionario["ns_nivel_int"]);
        ltl_haber_basico_int.Text = validarCampo(funcionario["ca_basico_calculado_int"]);
        //txt_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio_int"]);
        //txt_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin_int"]);
    }

    private void llenarDatosFunMV(DataSet p_funcionario)
    {
        var funcionarioDataset = p_funcionario;
        var funcionario = funcionarioDataset.Tables[0].Rows[0];

        ltl_descMovimiento_memo.Text = validarCampo(funcionario["te_descripcion"]);
        ltl_num_memo.Text = validarCampo(funcionario["tf_nro_memo"]);
        //txt_fecha_inicio.Text = validarCampo(funcionario["tf_fecha_inicio"]);
        //txt_fecha_fin.Text = validarCampo(funcionario["tf_fecha_fin"]);
    }

    private void informacionFuncionarioAlta(string ci = "", string gestion = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(gestion);
        var detalleFuncionario = seg_memo.obtenerInformacionReprobarAlta();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_gv_validar').css('display', 'block');$('#block_reprobar').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_reprobar').css('display', 'none');";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioBaja(string ci = "", string gestion = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(gestion);
        var detalleFuncionario = seg_memo.obtenerInformacionReprobarBaja();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block');$('#block_reprobar').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_reprobar').css('display', 'none');";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioRPT(string ci = "", string gestion = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(gestion);
        var detalleFuncionario = seg_memo.obtenerInformacionReprobarRPT();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block');$('#block_reprobar').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_reprobar').css('display', 'none');";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioAltasCI(string ci = "", string gestion = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(gestion);
        var detalleFuncionario = seg_memo.obtenerInformacionReprobarAltasCI();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block');$('#block_datos_fun_int').css('display', 'block'); $('#block_datos_adicionales_int').css('display', 'block');$('#block_reprobar').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');$('#block_reprobar').css('display', 'none');";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioBajasCI(string ci = "", string gestion = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(gestion);
        var detalleFuncionario = seg_memo.obtenerInformacionReprobarBajasCI();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block');$('#block_datos_fun_int').css('display', 'block'); $('#block_datos_adicionales_int').css('display', 'block');$('#block_reprobar').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');$('#block_reprobar').css('display', 'none');";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioMemosVarios(string ci = "", string gestion = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(gestion);
        var detalleFuncionario = seg_memo.obtenerInformacionReprobarMemosVarios();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block');$('#block_datos_memo').css('display', 'block');$('#block_reprobar').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_datos_memo').css('display', 'none');$('#block_reprobar').css('display', 'none');";
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

    protected void btn_Buscar_ci_Click(object sender, EventArgs e)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        gv_validar_items.DataSource = seg_memo.ListarMovimientosParaReprobar(Convert.ToInt32(Session["pr_id"].ToString()), Convert.ToInt32(txt_ci.Text));
        gv_validar_items.DataBind();
        grid.Visible = true;
        //gv_validar_items.DataSource
        //string gestionFiltrar = obtenerGestion();
        //string ci = txt_ci.Text;
        //string gestion = Session["pr_id"].ToString();
        //switch (ddl_validaMemo.SelectedValue)
        //{
        //    case "1":
        //        informacionFuncionarioAlta(ci, gestion);

        //        break;
        //    case "2":
        //        informacionFuncionarioBaja(ci, gestion);

        //        break;
        //    case "3":
        //        informacionFuncionarioRPT(ci, gestion);

        //        break;
        //    case "4":
        //        informacionFuncionarioAltasCI(ci, gestion);

        //        break;
        //    case "5":
        //        informacionFuncionarioBajasCI(ci, gestion);

        //        break;
        //    case "7":
        //        informacionFuncionarioMemosVarios(ci, gestion);

        //        break;
        //    default:
        //        break;
        //}

    }

    protected void Limpiar()
    {
        ddl_validaMemo.SelectedValue = "0";
        txt_ci.Text = string.Empty;
        //txt_fecha_inicio.Text = string.Empty;
        //txt_fecha_fin.Text = string.Empty;
    }

    //private void listaGrillaValidacion()
    //{
    //    try
    //    {
    //        string gestionFiltrar = obtenerGestion();
    //        string gestion = gestionFiltrar;
    //        seg_memo = new cls_mp_seguimiento_memorandum();
    //        seg_memo.gestion_selec = gestion;
    //        DataSet grillaValida = null;
    //        switch (ddl_validaMemo.SelectedValue)
    //        {
    //            case "1":
    //                grillaValida = seg_memo.obtenerGrillaValidaAlta();
    //                gv_validar_items.DataKeyNames = new string[] { "as_id" };
    //                break;
    //            case "2":
    //                grillaValida = seg_memo.obtenerGrillaValidaBaja();
    //                gv_validar_items.DataKeyNames = new string[] { "as_id" };
    //                break;
    //            case "3":
    //                grillaValida = seg_memo.obtenerGrillaValidaRPT();
    //                gv_validar_items.DataKeyNames = new string[] { "as_id" };
    //                break;
    //            case "4":
    //                grillaValida = seg_memo.obtenerGrillaValidaAltaCI();
    //                gv_validar_items.DataKeyNames = new string[] { "ci_id" };
    //                break;
    //            case "5":
    //                grillaValida = seg_memo.obtenerGrillaValidaBajaCI();
    //                gv_validar_items.DataKeyNames = new string[] { "ci_id" };
    //                break;
    //            case "7":
    //                grillaValida = seg_memo.obtenerGrillaValidaMemosVarios();
    //                gv_validar_items.DataKeyNames = new string[] { "tf_id" };
    //                break;
    //            default:
    //                break;
    //        }

    //        int num = grillaValida.Tables[0].Rows.Count;
    //        if (num > 0)
    //        {
    //            gv_validar_items.DataSource = grillaValida;
    //            gv_validar_items.DataBind();
    //            sc = "$('#block_gv_validar').css('display', 'block');";
    //            SetScriptDataTable(sc);
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}

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

    protected void ddl_validaMemo_SelectedIndexChanged(object sender, EventArgs e)
    {
        //listaGrillaValidacion();
        sc = "$('#block_datos_funcionario').css('display', 'none'); $('#block_gv_validar').css('display', 'none');";
        SetScript(sc);
        txt_ci.Text = string.Empty;
        //txt_fecha_inicio.Text = string.Empty;
        //txt_fecha_fin.Text = string.Empty;
    }

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('.ql-editor').css('border', 'none'); $('.ql-container.ql-snow').css('border', 'none'); $('.ql-editor').css('padding', '0rem .75rem');");
        sb.Append(data);
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
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
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
                    "'sFirst': '«'," +
                    "'sLast': '»'," +
                    "'sNext': '<i class=" + '"' + "fas fa-angle-right" + '"' + "></i>'," +
                    "'sPrevious': '<i class=" + '"' + "fas fa-angle-left" + '"' + "></i>'" +
                    "'sInfoEmpty': 'Mostrando registros del 0 al 0 de un total de 0 registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ registros)'," +
                    "'sInfoPostFix': ''," +
                    "'sSearch': 'Buscar:'," +
                    "'sUrl': ''," +
                    "'sInfoThousands': ','," +
                    "'sLoadingRecords': 'Cargando...'," +
                    "'oPaginate': {" +
                    "}," +
                    "'oAria': {" +
                    "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                    "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                    "}," +
                    "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_listar_altas_Click(object sender, EventArgs e)
    {
        try
        {
            //string gestionFiltrar = obtenerGestion();
            //string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaReprobarAlta();
            gv_validar_items.DataKeyNames = new string[] { "as_id" };
            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_validar_items.DataSource = grillaValida;
                gv_validar_items.DataBind();
                //block_gv_validar.Visible = true;

                //sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                //SetScriptDataTable(sc);
            }
            //Limpiar();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_bajas_Click(object sender, EventArgs e)
    {
        try
        {
            //string gestionFiltrar = obtenerGestion();
            //string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaReprobarBaja();
            gv_validar_items.DataKeyNames = new string[] { "as_id" };

            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_validar_items.DataSource = grillaValida;
                gv_validar_items.DataBind();
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                SetScriptDataTable(sc);
            }
            Limpiar();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_RPT_Click(object sender, EventArgs e)
    {
        try
        {
            //string gestionFiltrar = obtenerGestion();
            //string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaReprobarRPT();
            gv_validar_items.DataKeyNames = new string[] { "as_id" };

            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_validar_items.DataSource = grillaValida;
                gv_validar_items.DataBind();
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                SetScriptDataTable(sc);
            }
            Limpiar();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_altasCI_Click(object sender, EventArgs e)
    {
        try
        {
            //string gestionFiltrar = obtenerGestion();
            //string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaReprobarAltaCI();
            gv_validar_items.DataKeyNames = new string[] { "ci_id" };

            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_validar_items.DataSource = grillaValida;
                gv_validar_items.DataBind();
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                SetScriptDataTable(sc);
            }
            Limpiar();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_bajasCI_Click(object sender, EventArgs e)
    {
        try
        {
            //string gestionFiltrar = obtenerGestion();
            //string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaReprobarBajaCI();
            gv_validar_items.DataKeyNames = new string[] { "ci_id" };

            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_validar_items.DataSource = grillaValida;
                gv_validar_items.DataBind();
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                SetScriptDataTable(sc);
            }
            Limpiar();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_memosVarios_Click(object sender, EventArgs e)
    {
        try
        {
            //string gestionFiltrar = obtenerGestion();
            //string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaReprobarMemosVarios();
            gv_validar_items.DataKeyNames = new string[] { "tf_id" };

            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_validar_items.DataSource = grillaValida;
                gv_validar_items.DataBind();
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                SetScriptDataTable(sc);
            }
            Limpiar();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_reprobar_validacion_Click(object sender, EventArgs e)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = Convert.ToInt32(aux_as_id.Value);
        seg_memo.mh_per_id = Convert.ToInt32(aux_as_per_id.Value);
        switch (ddl_validaMemo.SelectedValue)
        {
            case "1":
                seg_memo.ActualizarReprobacionAlta();
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-trash-alt', message: ' Registro desvalidado correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_gv_validar').css('display', 'none');$('#block_reprobar').css('display', 'none');";
                break;
            case "2":
                seg_memo.ActualizarReprobacionAlta();
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-trash-alt', message: ' Registro desvalidado correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_gv_validar').css('display', 'none');$('#block_reprobar').css('display', 'none');";
                break;
            case "3":
                seg_memo.ActualizarReprobacionAlta();
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-trash-alt', message: ' Registro desvalidado correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_gv_validar').css('display', 'none');$('#block_reprobar').css('display', 'none');";
                break;
            case "4":
                seg_memo.ActualizarReprobacionAltaCI();
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-check', message: ' Registro desvalidado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_gv_validar').css('display', 'none');$('#block_reprobar').css('display', 'none');";
                break;
            case "5":
                seg_memo.ActualizarReprobacionAltaCI();
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-check', message: ' Registro desvalidado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_gv_validar').css('display', 'none');$('#block_reprobar').css('display', 'none');";
                break;
            case "7":
                seg_memo.ActualizarReprobacionMemosVarios();
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-check', message: ' Registro desvalidado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_gv_validar').css('display', 'none');$('#block_reprobar').css('display', 'none');";
                break;
            default:
                break;
        }
        informacionTotalValidar();
        SetScript(sc);
    }

    protected void gv_validar_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string as_id = gv_validar_items.DataKeys[index].Values[0].ToString();
        cls_mp_seguimiento_memorandum memo = new cls_mp_seguimiento_memorandum();
        switch (e.CommandName)
        {
            case "Reprobar":
                memo.as_id = Convert.ToInt32(as_id);
                if(memo.ActualizarReprobacionAlta())
                    sc = "$.notify({ icon: 'fa fa-check', message: ' Se reprobó satisfactoriamente el movimiento'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none');$('#block_gv_validar').css('display', 'none');$('#block_reprobar').css('display', 'none');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }
}