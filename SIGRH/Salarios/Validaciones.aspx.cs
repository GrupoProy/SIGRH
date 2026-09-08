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
    private cls_mp_cargo cargo = null;
    private cls_mp_seguimiento_memorandum seg_memo = null;
    private cls_pc_precontratado precontratado = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                listaFiltradoTipoValidacion();
                informacionTotalValidar();
                txt_fecha_inicio.Enabled = false;
                txt_fecha_fin.Enabled = false;
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }

    private void informacionTotalValidar()
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

        var grillaAlta = seg_memo.obtenerCantidadValidaAlta();
        var grillaBaja = seg_memo.obtenerCantidadValidaBaja();
        var grillaRPT = seg_memo.obtenerCantidadValidaRPT();
        var grillaAltaCI = seg_memo.obtenerCantidadValidaAltaCI();
        var grillaBajaCI = seg_memo.obtenerCantidadValidaBajaCI();
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
        txt_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
        txt_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
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

        txt_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio_int"]);
        txt_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin_int"]);

        sc = (ltl_tipo_int.Text == "INTERINATO") ? "$('#block_datos_adicionales_int').css('display', 'block');" : "$('#block_datos_adicionales_int').css('display', 'none');";
        SetScript(sc);
    }

    private void llenarDatosFunMV(DataSet p_funcionario)
    {
        var funcionarioDataset = p_funcionario;
        var funcionario = funcionarioDataset.Tables[0].Rows[0];
        ltl_descMovimiento_memo.Text = validarCampo(funcionario["mv_tipo"]);
        ltl_num_memo.Text = validarCampo(funcionario["mv_nro_memo"]);
        txt_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
        txt_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
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
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_aprobar').css('display', 'block'); $('#block_gv_validar').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none');";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioBaja(int as_id = 0)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString()); ;
        var detalleFuncionario = seg_memo.obtenerDatosInformacionBaja();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_aprobar').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none');";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioRPT(int as_id = 0)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var detalleFuncionario = seg_memo.obtenerDatosInformacionRPT();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_aprobar').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none');";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioAltasCI(int as_id = 0)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var detalleFuncionario = seg_memo.obtenerDatosInformacionAltasCI();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_aprobar').css('display', 'block'); $('#block_datos_fun_int').css('display', 'block'); ";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); ";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioAltasCIGrilla(int as_id = 0)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

        var detalleFuncionario = seg_memo.obtenerDatosInformacionAltasCIGrilla();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_aprobar').css('display', 'block'); $('#block_datos_fun_int').css('display', 'block'); ";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); ";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioBajasCI(int as_id = 0)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var detalleFuncionario = seg_memo.obtenerDatosInformacionBajasCI();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_aprobar').css('display', 'block'); $('#block_datos_fun_int').css('display', 'block'); ";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); ";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioBajasCIGrilla(int as_id = 0)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var detalleFuncionario = seg_memo.obtenerDatosInformacionBajasCIGrilla();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_aprobar').css('display', 'block'); $('#block_datos_fun_int').css('display', 'block'); ";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); ";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioMemosVarios(int as_id = 0)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

        var detalleFuncionario = seg_memo.obtenerDatosInformacionMemosVarios();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_aprobar').css('display', 'block'); $('#block_datos_memo').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); $('#block_datos_memo').css('display', 'none');";
            }
            SetScript(sc);
        }
    }

    private void informacionFuncionarioMemosVariosGrilla(int as_id = 0)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var detalleFuncionario = seg_memo.obtenerDatosInformacionMemosVariosGrilla();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                armarEstructura(detalleFuncionario);
                sc = "$.notify({ icon: 'fa fa-check', message: 'Datos seleccionados correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'block'); $('#block_aprobar').css('display', 'block'); $('#block_datos_memo').css('display', 'block');";
            }
            else
            {
                Limpiar();
                sc = "$.notify({ icon: 'fa fa-info', message: 'No se encontraron resultados'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); $('#block_datos_memo').css('display', 'none');";
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
        aux_tipo_validacion.Value = "";

        seg_memo = new cls_mp_seguimiento_memorandum();
        string ci = txt_ci.Text.Trim();
        int as_id = 0;

        switch (ddl_validaMemo.SelectedValue)
        {
            case "1":
                as_id = obtenerAltaID(ci);
                informacionFuncionarioAlta(as_id);
                break;
            case "2":
                as_id = obtenerBajaID(ci);
                informacionFuncionarioBaja(as_id);
                break;
            case "3":
                as_id = obtenerRPTID(ci);
                informacionFuncionarioRPT(as_id);
                break;
            case "4":
                as_id = obtenerAltaCIDID(ci);
                informacionFuncionarioAltasCI(as_id);
                break;
            case "5":
                as_id = obtenerBajaCIDID(ci);
                informacionFuncionarioBajasCI(as_id);
                break;
            case "7":
                as_id = obtenerMemoVarioID(ci);
                informacionFuncionarioMemosVarios(as_id);
                break;
            default:
                break;
        }
        SetScript("$('#block_gv_validar').css('display', 'none'); MostrarMascara(false);");
    }

    protected void btn_guardar_validacion_Click(object sender, EventArgs e)
    {
        //int us_id = Convert.ToInt32(Session["us_id"].ToString());
        int as_id = Convert.ToInt32(aux_as_id.Value);
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = as_id;
        seg_memo.usuario_creacion = Convert.ToInt32(Session["us_id"]);
        seg_memo.as_fecha_inicio = (txt_fecha_inicio.Text == ltl_fecha_inicio.Text) ? ltl_fecha_inicio.Text : txt_fecha_inicio.Text;
        seg_memo.as_fecha_fin = (txt_fecha_fin.Text == ltl_fecha_fin.Text) ? (ltl_fecha_fin.Text == "") ? null : ltl_fecha_fin.Text : (txt_fecha_fin.Text == "") ? null : txt_fecha_fin.Text;

        string aux = "";
        string aux_sc = "";
        if (aux_tipo_validacion.Value != "")
        {
            aux = " $('#block_gv_validar').css('display', 'block'); ";
        }

        switch (ddl_validaMemo.SelectedValue)
        {
            case "1":
                if (tieneBaja(as_id))
                {
                    aux_sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, el funcionario tiene una baja pendiente por validar.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                } else
                {
                    if (gestionCorrecto(txt_fecha_inicio.Text))
                    {
                        seg_memo.ActualizarValidacionAlta();
                        Limpiar();
                        aux_sc = "Swal.fire({ icon: 'success', title: 'Validación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); " + aux + " }});";
                    }
                    else
                    {
                        aux_sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, revise la fecha asignada por favor.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                    }
                }
                break;
            case "2":
                if (gestionCorrecto(txt_fecha_fin.Text))
                {
                    seg_memo.ActualizarValidacionAlta();
                    Limpiar();
                    aux_sc = "Swal.fire({ icon: 'success', title: 'Validación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); " + aux + " }});";
                }
                else
                {
                    aux_sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, revise la fecha asignada por favor.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                }

                break;
            case "3":
                if (gestionCorrecto(txt_fecha_inicio.Text))
                {
                    seg_memo.ActualizarValidacionAlta();
                    Limpiar();
                    aux_sc = "Swal.fire({ icon: 'success', title: 'Validación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); " + aux + " }});";
                }
                else
                {
                    aux_sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, revise la fecha asignada por favor.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                }
                break;
            case "4":
                if (gestionCorrecto(txt_fecha_inicio.Text))
                {
                    seg_memo.ActualizarValidacionAltaCI();
                    Limpiar();
                    aux_sc = "Swal.fire({ icon: 'success', title: 'Validación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); " + aux + " }});";
                }
                else
                {
                    aux_sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, revise la fecha asignada por favor.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                }
                break;
            case "5":
                seg_memo.ActualizarValidacionAltaCI();
                Limpiar();
                aux_sc = "Swal.fire({ icon: 'success', title: 'Validación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); " + aux + " }});";
                break;
            case "7":
                if (gestionCorrecto(txt_fecha_inicio.Text))
                {
                    seg_memo.ActualizarValidacionMemosVarios();
                    Limpiar();
                    aux_sc = "Swal.fire({ icon: 'success', title: 'Validación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_datos_funcionario').css('display', 'none'); $('#block_aprobar').css('display', 'none'); " + aux + " }});";
                }
                else
                {
                    aux_sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, revise la fecha asignada por favor.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                }
                break;
            default:
                break;
        }
        informacionTotalValidar();
        actualizarGrilla();
        SetScript(aux_sc);
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
        switch (aux_tipo_validacion.Value)
        {
            case "1":
                btn_listar_altas_Click(null, null);
                break;
            case "2":
                btn_listar_bajas_Click(null, null);
                break;
            case "3":
                btn_listar_RPT_Click(null, null);
                break;
            case "4":
                btn_listar_altasCI_Click(null, null);
                break;
            case "5":
                btn_listar_bajasCI_Click(null, null);
                break;
            case "7":
                btn_listar_memosVarios_Click(null, null);
                break;
            default:

                break;
        }
    }
    private bool gestionCorrecto(string fecha_valida = "")
    {
        if (string.IsNullOrEmpty(fecha_valida))
            return false;

        try
        {
            DateTime fecha = Convert.ToDateTime(fecha_valida);
            int anioFecha = fecha.Year;

            if (anioFecha >= 2024 && anioFecha <= 2099)
                return true;

            return false;
        }
        catch
        {
            return false;
        }
    }

    protected void Limpiar()
    {
        //ddl_validaMemo.SelectedValue = "0";
        txt_ci.Text = string.Empty;
        txt_fecha_inicio.Text = string.Empty;
        txt_fecha_fin.Text = string.Empty;
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

        switch (e.CommandName)
        {
            case "GetDetail":
                switch (ddl_validaMemo.SelectedValue)
                {
                    case "1":
                        informacionFuncionarioAlta(as_id);

                        break;
                    case "2":
                        informacionFuncionarioBaja(as_id);

                        break;
                    case "3":
                        informacionFuncionarioRPT(as_id);

                        break;
                    case "4":
                        informacionFuncionarioAltasCIGrilla(as_id);

                        break;
                    case "5":
                        informacionFuncionarioBajasCIGrilla(as_id);

                        break;
                    case "7":
                        informacionFuncionarioMemosVariosGrilla(as_id);
                        break;
                    default:
                        break;
                }
                break;
            default:
                break;
        }
    }
    private void habilitarCampos()
    {
        switch (ddl_validaMemo.SelectedValue)
        {
            case "1":
                txt_fecha_inicio.Enabled = true;
                txt_fecha_fin.Enabled = true;
                break;
            case "2":
                txt_fecha_inicio.Enabled = false;
                txt_fecha_fin.Enabled = true;
                break;
            case "3":
                txt_fecha_inicio.Enabled = true;
                txt_fecha_fin.Enabled = false;
                break;
            case "4":
                txt_fecha_inicio.Enabled = true;
                txt_fecha_fin.Enabled = true;
                break;
            case "5":
                txt_fecha_inicio.Enabled = false;
                txt_fecha_fin.Enabled = true;
                break;
            case "7":
                txt_fecha_inicio.Enabled = true;
                txt_fecha_fin.Enabled = true;
                break;
            default:
                break;
        }
    }
    private int obtenerAltaID(string ci = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"]);
        var detalle_alta = seg_memo.ObtenerAltaID();

        int as_id = 0;
        as_id = (detalle_alta.Tables[0].Rows.Count > 0) ? Convert.ToInt32(validarCampo(detalle_alta.Tables[0].Rows[0]["as_id"])) : 0;
        return as_id;
    }
    private int obtenerBajaID(string ci = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"]);
        var detalle_alta = seg_memo.ObtenerBajaID();

        int as_id = 0;
        as_id = (detalle_alta.Tables[0].Rows.Count > 0) ? Convert.ToInt32(validarCampo(detalle_alta.Tables[0].Rows[0]["as_id"])) : 0;
        return as_id;
    }
    private int obtenerRPTID(string ci = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"]);
        var detalle_alta = seg_memo.ObtenerRPTID();

        int as_id = 0;
        as_id = (detalle_alta.Tables[0].Rows.Count > 0) ? Convert.ToInt32(validarCampo(detalle_alta.Tables[0].Rows[0]["as_id"])) : 0;
        return as_id;
    }
    private int obtenerAltaCIDID(string ci = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"]);
        var detalle_alta = seg_memo.ObtenerAltaCIDID();

        int as_id = 0;
        as_id = (detalle_alta.Tables[0].Rows.Count > 0) ? Convert.ToInt32(validarCampo(detalle_alta.Tables[0].Rows[0]["as_id"])) : 0;
        return as_id;
    }
    private int obtenerBajaCIDID(string ci = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"]);
        var detalle_alta = seg_memo.ObtenerBajaCIDID();

        int as_id = 0;
        as_id = (detalle_alta.Tables[0].Rows.Count > 0) ?  Convert.ToInt32(validarCampo(detalle_alta.Tables[0].Rows[0]["as_id"])) : 0;
        return as_id;
    }
    private int obtenerMemoVarioID(string ci = "")
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.per_num_doc = ci;
        seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"]);
        var detalle_alta = seg_memo.ObtenerMemoVarioID();

        int as_id = 0;
        as_id = (detalle_alta.Tables[0].Rows.Count > 0) ? Convert.ToInt32(validarCampo(detalle_alta.Tables[0].Rows[0]["as_id"])) : 0;
        return as_id;
    }
    protected void ddl_validaMemo_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_ci.Text = string.Empty;
        txt_fecha_inicio.Text = string.Empty;
        txt_fecha_fin.Text = string.Empty;

        habilitarCampos();

        txt_ci.Focus();
        sc = "$('#block_datos_funcionario').css('display', 'none'); $('#block_gv_validar').css('display', 'none');";
        SetScript(sc);
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
        try
        {
            ddl_validaMemo.SelectedValue = "1";
            aux_tipo_validacion.Value = "1";
            ltl_nombre_grilla.Text = "Altas";

            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

            DataSet grillaValida = seg_memo.obtenerGrillaValidaAlta();

            if (grillaValida == null || grillaValida.Tables.Count == 0 || grillaValida.Tables[0].Rows.Count == 0)
            {
                sc = "$('#block_gv_validar').css('display', 'none'); $('#block_datos_funcionario').css('display', 'none');";
                sc += "$.notify({ icon: 'fa fa-exclamation', message: 'No se encontraron resultados.' }, { type: 'info' });";
                SetScript(sc);
                Limpiar();
                habilitarCampos();
                return;
            }

            // Verificar si la columna fecha_solicitud existe, si no, crearla
            if (!grillaValida.Tables[0].Columns.Contains("fecha_solicitud"))
            {
                grillaValida.Tables[0].Columns.Add("fecha_solicitud", typeof(string));
                foreach (DataRow row in grillaValida.Tables[0].Rows)
                {
                    row["fecha_solicitud"] = "N/D";
                }
            }

            gv_validar_items.DataSource = grillaValida;
            gv_validar_items.DataBind();

            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none');";
            }
            else
            {
                sc = "$('#block_gv_validar').css('display', 'none');";
                sc += "$.notify({ icon: 'fa fa-exclamation', message: 'No se encontraron resultados.' }, { type: 'info' });";
            }
            SetScript(sc);
            Limpiar();
            habilitarCampos();
        }
        catch (Exception ex)
        {
            string errorMsg = ex.Message.Replace("'", "\\'");
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Error: " + errorMsg + "' }, { type: 'danger' });";
            SetScript(sc);
        }
    }

    protected void btn_listar_bajas_Click(object sender, EventArgs e)
    {
        ddl_validaMemo.SelectedValue = "2";
        aux_tipo_validacion.Value = "2";
        ltl_nombre_grilla.Text = "Bajas";
        try
        {
            string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaValidaBaja();
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
            Limpiar();

            habilitarCampos();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_RPT_Click(object sender, EventArgs e)
    {
        ddl_validaMemo.SelectedValue = "3";
        aux_tipo_validacion.Value = "3";
        ltl_nombre_grilla.Text = "Rem./ Prom./ Transf.";
        try
        {
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaValidaRPT();
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
            Limpiar();

            habilitarCampos();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_altasCI_Click(object sender, EventArgs e)
    {
        ddl_validaMemo.SelectedValue = "4";
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
            Limpiar();

            habilitarCampos();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_bajasCI_Click(object sender, EventArgs e)
    {
        ddl_validaMemo.SelectedValue = "5";
        aux_tipo_validacion.Value = "5";
        ltl_nombre_grilla.Text = "Bajas Comisión e Interinato";
        try
        {
            string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaValidaBajaCI();
            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_validar_items.DataSource = grillaValida;
                gv_validar_items.DataBind();
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
            }
            else
            {
                sc = "$('#block_gv_validar').css('display', 'none'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                sc = sc + "$.notify({ icon: 'fa fa-exclamation', message: 'No se encontraron resultados.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            }
            SetScript(sc);
            Limpiar();

            habilitarCampos();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void btn_listar_memosVarios_Click(object sender, EventArgs e)
    {
        ddl_validaMemo.SelectedValue = "7";
        aux_tipo_validacion.Value = "7";
        ltl_nombre_grilla.Text = "Memorándums Varios";
        try
        {
            string gestion = Session["pr_id"].ToString();
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            DataSet grillaValida = null;
            grillaValida = seg_memo.obtenerGrillaValidaMemosVarios();
            int num = grillaValida.Tables[0].Rows.Count;
            if (num > 0)
            {
                gv_validar_items.DataSource = grillaValida;
                gv_validar_items.DataBind();
                sc = "$('#block_gv_validar').css('display', 'block'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
            }
            else
            {
                sc = "$('#block_gv_validar').css('display', 'none'); $('#block_datos_funcionario').css('display', 'none'); $('#block_datos_fun_int').css('display', 'none'); $('#block_datos_adicionales_int').css('display', 'none');";
                sc = sc + "$.notify({ icon: 'fa fa-exclamation', message: 'No se encontraron resultados.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            }
            SetScript(sc);
            Limpiar();

            habilitarCampos();
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

    protected void btn_ver_movimientos_Click(object sender, EventArgs e)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());
        var detalleMovimientos = seg_memo.ObtenerMovimientosValidados();

        no_existe_mov.Visible = !(detalleMovimientos.Tables[0].Rows.Count > 0);
        gv_movimientos.DataSource = (detalleMovimientos.Tables[0].Rows.Count > 0) ? detalleMovimientos : null;
        gv_movimientos.DataBind();
        gv_movimientos.Columns[6].Visible = (validarCampo(detalleMovimientos.Tables[0].Rows[0]["us_id_rep"]) != "0");

        sc = "$('#modalMovimientos').modal('show'); MostrarMascara(false);";
        SetScript(sc);
    }
    protected void gv_movimientos_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_movimientos.Rows.Count > 0)
        {
            if (gv_movimientos.HeaderRow != null)
            {
                gv_movimientos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_movimientos.FooterRow != null)
            {
                gv_movimientos.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_movimientos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        int his_id = Convert.ToInt32(gv_movimientos.DataKeys[index].Values[0].ToString());
        int his_valor_pk = Convert.ToInt32(gv_movimientos.DataKeys[index].Values[1].ToString());
        string his_nom_pk = gv_movimientos.DataKeys[index].Values[2].ToString();

        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = his_valor_pk;
        seg_memo.usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());

        switch (e.CommandName)
        {
            case "GetAssign":
                switch (his_nom_pk)
                {
                    case "as_id":
                        seg_memo.ActualizarReprobacionAlta();
                        break;
                    case "ci_id":
                        seg_memo.ActualizarReprobacionAltaCI();
                        break;
                    case "mv_id":
                        seg_memo.ActualizarReprobacionMemosVarios();
                        break;
                    default:
                        break;
                }

                gv_movimientos.DataSource = null;
                gv_movimientos.DataBind();

                informacionTotalValidar();
                sc = "Swal.fire({ icon: 'success', title: 'Reprobación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalMovimientos').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false); }});";
                SetScript(sc);
                break;
            default:
                break;
        }
    }
}