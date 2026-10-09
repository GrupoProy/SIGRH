using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using System.Text;
using System.Data;

public partial class BienestarSocial_ExamenPreocupacional : System.Web.UI.Page
{
    private cls_bs_examen_preocupacional ex_preo = null;
    private cls_kd_asignacion_vacaciones asig_vacaciones = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa glosa = null;
    private cls_persona_domicilio persona_dom = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string per_id = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            informacionFuncionario(Convert.ToInt32(per_id), Convert.ToInt32(as_id));
            listar_historicoAsignaciones();
            listarExamnes(per_id);
            listarLugar();
            listaFiltradoTipoDoc();
        }
    }
    private void listarExamnes(string per_id = "")
    {
        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.exp_per_id = Convert.ToInt32(per_id);
        var examenes = ex_preo.ObtenerExamenesRealizados();
        int tam = examenes.Tables[0].Rows.Count;
        ltl_no_existe.Visible = !(tam > 0);
        ltl_total_reg.Text = tam + "";
        lv_examen.DataSource = examenes;
        lv_examen.DataBind();
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

            int[] ids = { 816, 818 };

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
            ddl_tipo_documento.DataSource = _catalogo.ObtenerTablaCombo();
            ddl_tipo_documento.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listarLugar()
    {
        _catalogo = new cls_catalogo { cat_tabla = "lugar_examen_preocupacional" };
        ddl_lugar.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_lugar.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_lugar.DataValueField = "cat_secuencial";
        ddl_lugar.DataTextField = "cat_descripcion";
        ddl_lugar.DataBind();
        ddl_lugar.SelectedValue = "1";
    }
    private void informacionFuncionario(int per_id = 0, int as_id = 0)
    {
        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.as_id = as_id;
        ex_preo.exp_per_id = per_id;
        ex_preo.pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        var detalleFuncionario = ex_preo.ObtenerDatosFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_estado_civil.Text = validarCampo(funcionario["per_estado_civil"]);
                ltl_fecha_nac.Text = validarCampo(funcionario["per_fecha_nac"]);
                ltl_genero.Text = validarCampo(funcionario["per_sexo"]);
                ltl_nacionalidad.Text = validarCampo(funcionario["per_procedencia"]);
                ltl_prefesion.Text = validarCampo(funcionario["ef_carrera_especialidad"]);
                string domi_numero = (validarCampo(funcionario["perd_numero"]) != "") ? "#" + validarCampo(funcionario["perd_numero"]) : "";
                ltl_direccion.Text = validarCampo(funcionario["perd_zona"]) + " " + validarCampo(funcionario["perd_tipo_via"]) + " " + validarCampo(funcionario["perd_descripcion_via"]) + " " + domi_numero + " " + validarCampo(funcionario["perd_edificio"]) + " " + validarCampo(funcionario["perd_bloque"]);
                ltl_telefono.Text = validarCampo(funcionario["perd_telefono"]);
                ltl_cel.Text = validarCampo(funcionario["perd_celular"]);
                ltl_departamento.Text = validarCampo(funcionario["departamento"]);
                ltl_provincia.Text = validarCampo(funcionario["provincia"]);
                ltl_localidad.Text = validarCampo(funcionario["localidad"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_ubicacion.Text = validarCampo(funcionario["eo_descripcion"]);
                ltl_cargo.Text = validarCampo(funcionario["es_descripcion"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                ltl_afp.Text = validarCampo(funcionario["afp_previsora"]);
                ltl_nua.Text = validarCampo(funcionario["afp_nua"]);
                ltl_egs.Text = validarCampo(funcionario["fa_descripcion"]);
                ltl_seguro.Text = validarCampo(funcionario["matricula_cns"]);

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
    protected void listar_historicoAsignaciones()
    {
        int id_fun = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = id_fun;
            var grillaHistorico = asig_vacaciones.obtenerGrillaHistoricoAsig();
            int tam = grillaHistorico.Tables[0].Rows.Count;
            block_HisAsignaciones.Visible = (tam > 0) ? false : true;
            gv_historicoAsig.DataSource = grillaHistorico;
            gv_historicoAsig.DataBind();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }
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
    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }

    protected void btn_regitrar_ex_Click(object sender, EventArgs e)
    {
        limpiarExmaen();
        hf_exp_id.Value = string.Empty;

        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        var detalleNroAut = ex_preo.ObtenerNroAutorizacion();
        ltl_nro_aut.Text = validarCampo(detalleNroAut.Tables[0].Rows[0]["exp_nro_autorizacion"]);

        obtenerTelefonosFun();

        sc = "$('#modalNuevoExamen').modal('show');";
        SetScript(sc);
    }
    private void obtenerTelefonosFun()
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.exp_per_id = per_id;
        var detalleNroTelf = ex_preo.ObtenerTelefonos();
        if (detalleNroTelf.Tables[0].Rows.Count > 0)
        {
            hf_perd_id.Value = validarCampo(detalleNroTelf.Tables[0].Rows[0]["perd_id"]);
            txt_telf_fun.Text = validarCampo(detalleNroTelf.Tables[0].Rows[0]["perd_telefono"]);
            txt_cel_fun.Text = validarCampo(detalleNroTelf.Tables[0].Rows[0]["perd_celular"]);
        }
    }
    private void limpiarExmaen()
    {
        ltl_nro_aut.Text = "";
        ddl_convenio.SelectedValue = "1";
        ddl_lugar.SelectedValue = "1";
        txt_fecha_prog.Text = "";
        txt_telf_of.Text = "";
        txt_telf_fun.Text = "";
        txt_cel_fun.Text = "";
        txt_obs.Text = "";
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
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('#ContentPlaceHolder1_gv_historicoAsig').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_historicoAsig')) { $('#ContentPlaceHolder1_gv_historicoAsig').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_frecuencias')) { $('#ContentPlaceHolder1_gv_frecuencias').DataTable({" +
        "'language': " + l +
        "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_convenio').select2({ dropdownParent: $('#modalNuevoExamen') });");
        sb.Append("$('#ContentPlaceHolder1_ddl_lugar').select2({ dropdownParent: $('#modalNuevoExamen'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_adicionar_prog_Click(object sender, EventArgs e)
    {
        DateTime dateX = Convert.ToDateTime(txt_fecha_prog.Text);
        DateTime nowX = DateTime.Now.Date;

        if (dateX >= nowX)
        {
            if (hf_exp_id.Value != "")
            {
                sc = "$('#reprogramarExamen').modal('show');";
                SetScript(sc);
            }
            else
            {
                sc = "$('#modalGlosa').modal('show');";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'ni ni-settings-gear-65', message: 'La fecha programada es incorrecta.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    protected void btn_cancelar_prog_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevoExamen').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        string per_id = Request.QueryString["id"].ToString();
        string as_id = Request.QueryString["id2"].ToString();
        int exp_id = programarExamen();
        actualizarTelefonosFun();
        guardarGlosa(exp_id, "exp_id", "tbl_bs_examen_preocupacional");

        informacionFuncionario(Convert.ToInt32(per_id), Convert.ToInt32(as_id));
        listarExamnes(per_id);
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Se programó el examen correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalGlosa').modal('hide'); $('#modalNuevoExamen').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('hide');";
        SetScript(sc);
    }
    private int programarExamen()
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        int as_id = Convert.ToInt32(Request.QueryString["id2"].ToString());
        int exp_id = 0;
        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.exp_per_id = per_id;
        ex_preo.exp_convenio = (ddl_convenio.SelectedValue == "1");
        ex_preo.exp_lugar = Convert.ToInt32(ddl_lugar.SelectedValue);
        ex_preo.exp_fecha_prog = txt_fecha_prog.Text;
        ex_preo.exp_tel_of_fun = txt_telf_of.Text;
        ex_preo.exp_actividad_realiza = txt_act_realiza.Text.Trim().ToUpper();
        ex_preo.exp_obs_aut = txt_obs.Text.Trim().ToUpper();
        ex_preo.exp_pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        ex_preo.exp_as_id = as_id;
        var detalle_ex_preo = ex_preo.Adicionar();
        if (detalle_ex_preo.Tables[0].Rows.Count > 0)
        {
            exp_id = Convert.ToInt32(validarCampo(detalle_ex_preo.Tables[0].Rows[0]["exp_id"]));
        }

        return exp_id;
    }
    private void guardarGlosa(int gl_valor_pk = 0, string gl_nombre_pk = "", string gl_tabla = "")
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;
        glosa = new cls_glosa();
        glosa.gl_valor_pk = gl_valor_pk + "";
        glosa.gl_nombre_pk = gl_nombre_pk;
        glosa.gl_tabla = gl_tabla;
        glosa.gl_tipo_mov = 813;
        glosa.gl_fecha_doc = Convert.ToDateTime(fechaMov);
        glosa.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        glosa.gl_numero_doc = (txt_num_doc.Text.Trim() != "") ? txt_num_doc.Text.Trim() : null;
        glosa.gl_glosa = txt_descripcion_add.Text.Trim().ToUpper();
        glosa.gl_estado = "V";
        glosa.gl_usuario = Convert.ToInt32(Session["us_id"].ToString());
        glosa.Adicionar();
        restablecerGlosa();
    }

    protected void lv_examen_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string exp_id = lv_examen.DataKeys[index].Values[0].ToString();
        hf_exp_id.Value = exp_id;

        switch (e.CommandName)
        {
            case "GetAssign":
                SetScript("");
                break;
            case "GetPrint":
                SetScript("");
                break;
            case "GetEdit":
                limpiarExmaen();
                llenarDatosExamen();
                obtenerTelefonosFun();
                sc = "$('#modalNuevoExamen').modal('show');";
                SetScript(sc);
                break;
            case "GetDelete":
                sc = "$('#anularExamen').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }
    private void actualizarTelefonosFun()
    {
        persona_dom = new cls_persona_domicilio();
        if (hf_perd_id.Value != "")
        {
            persona_dom.perd_id = Convert.ToInt32(hf_perd_id.Value);
            persona_dom.perd_telefono = txt_telf_fun.Text;
            persona_dom.perd_celular = txt_cel_fun.Text;
            persona_dom.ActualizarTelefonosFun();
        }

    }
    private void llenarDatosExamen()
    {
        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.exp_id = Convert.ToInt32(hf_exp_id.Value);
        var detalleExamen = ex_preo.ObtenerExamenProgramado();
        if (detalleExamen.Tables[0].Rows.Count > 0)
        {
            var examen_prog_x = detalleExamen.Tables[0].Rows[0];
            ltl_nro_aut.Text = validarCampo(examen_prog_x["exp_nro_autorizacion"]);
            ddl_convenio.SelectedValue = (Convert.ToBoolean(validarCampo(examen_prog_x["exp_convenio"]))) ? "1" : "0";
            ddl_lugar.SelectedValue = validarCampo(examen_prog_x["exp_lugar"]);
            txt_fecha_prog.Text = validarCampo(examen_prog_x["exp_fecha_examen"]);
            txt_telf_of.Text = validarCampo(examen_prog_x["exp_tel_of_fun"]);
            txt_act_realiza.Text = validarCampo(examen_prog_x["exp_actividad_realiza"]);
            txt_obs.Text = validarCampo(examen_prog_x["exp_obs_aut"]);
        }
    }

    protected void btn_reprogramar_examen_Click(object sender, EventArgs e)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        int as_id = Convert.ToInt32(Request.QueryString["id2"].ToString());

        reprogramarExamenFun();
        actualizarTelefonosFun();

        informacionFuncionario(Convert.ToInt32(per_id), Convert.ToInt32(as_id));
        listarExamnes(per_id + "");
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Se reprogramó el examen correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#reprogramarExamen').modal('hide'); $('#modalNuevoExamen').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }
    private void reprogramarExamenFun()
    {
        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.exp_id = Convert.ToInt32(hf_exp_id.Value);
        ex_preo.exp_convenio = (ddl_convenio.SelectedValue == "1");
        ex_preo.exp_lugar = Convert.ToInt32(ddl_lugar.SelectedValue);
        ex_preo.exp_fecha_prog = txt_fecha_prog.Text;
        ex_preo.exp_tel_of_fun = txt_telf_of.Text;
        ex_preo.exp_actividad_realiza = txt_act_realiza.Text.Trim().ToUpper();
        ex_preo.exp_obs_aut = txt_obs.Text.Trim().ToUpper();
        ex_preo.ReprogramarExamen();
    }

    protected void btn_anular_examen_Click(object sender, EventArgs e)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        int as_id = Convert.ToInt32(Request.QueryString["id2"].ToString());

        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.exp_id = Convert.ToInt32(hf_exp_id.Value);
        ex_preo.Eliminar();

        informacionFuncionario(Convert.ToInt32(per_id), Convert.ToInt32(as_id));
        listarExamnes(per_id + "");
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Se anulo el examen correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#anularExamen').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_estado_Click(object sender, EventArgs e)
    {
        SetScript("");
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
}