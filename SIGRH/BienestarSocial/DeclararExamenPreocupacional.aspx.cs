using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
public partial class BienestarSocial_DeclararExamenPreocupacional : System.Web.UI.Page
{
    private cls_bs_examen_preocupacional ex_preo = null;
    private cls_bs_agente_expuesto agente_exp = null;
    private cls_catalogo _catalogo = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string exp_id = Request.QueryString["id3"].ToString();

            listarTipoSangre();
            listarAgenteFisico();
            listarAgenteQuimico();
            listarAgenteBiologico();
            listarAgentePsicosocial();

            informacionFuncionario(Convert.ToInt32(exp_id));
            obtenerAgenteExpuesto(Convert.ToInt32(exp_id));
        }
    }
    private void obtenerAgenteExpuesto(int exp_id = 0)
    {
        agente_exp = new cls_bs_agente_expuesto();
        agente_exp.agexp_exp_id = exp_id;
        /*AGENTES FISICOS*/
        var detalle_ag_fisico = agente_exp.ObtenerAgentesExpFisico();
        if (detalle_ag_fisico.Tables[0].Rows.Count > 0)
        {
            var agente_fisico = detalle_ag_fisico.Tables[0].Rows;
            for (int i = 0; i < agente_fisico.Count; i++)
            {
                string ag_id = validarCampo(agente_fisico[i]["ag_id"]);
                foreach (ListItem item in lb_agente_fisico.Items)
                {
                    if (item.Value == ag_id)
                    {
                        item.Selected = true;
                    }
                }
            }
        }
        /*AGENTES QUIMICOS*/
        var detalle_ag_quimico = agente_exp.ObtenerAgentesExpQuimico();
        if (detalle_ag_quimico.Tables[0].Rows.Count > 0)
        {
            var agente_quimico = detalle_ag_quimico.Tables[0].Rows;
            for (int i = 0; i < agente_quimico.Count; i++)
            {
                string ag_id = validarCampo(agente_quimico[i]["ag_id"]);
                foreach (ListItem item in lb_agente_quimico.Items)
                {
                    if (item.Value == ag_id)
                    {
                        item.Selected = true;
                    }
                }
            }
        }
        /*AGENTES BIOLOGICOS*/
        var detalle_ag_biologico = agente_exp.ObtenerAgentesExpBilogico();
        if (detalle_ag_biologico.Tables[0].Rows.Count > 0)
        {
            var agente_biologico = detalle_ag_biologico.Tables[0].Rows;
            for (int i = 0; i < agente_biologico.Count; i++)
            {
                string ag_id = validarCampo(agente_biologico[i]["ag_id"]);
                foreach (ListItem item in lb_agente_biologico.Items)
                {
                    if (item.Value == ag_id)
                    {
                        item.Selected = true;
                    }
                }
            }
        }
        /*AGENTES PSICOSOCIALES*/
        var detalle_ag_psicosocial = agente_exp.ObtenerAgentesExpPsicosocial();
        if (detalle_ag_psicosocial.Tables[0].Rows.Count > 0)
        {
            var agente_psicosocial = detalle_ag_psicosocial.Tables[0].Rows;
            for (int i = 0; i < agente_psicosocial.Count; i++)
            {
                string ag_id = validarCampo(agente_psicosocial[i]["ag_id"]);
                foreach (ListItem item in lb_agente_psicosociales.Items)
                {
                    if (item.Value == ag_id)
                    {
                        item.Selected = true;
                    }
                }
            }
        }
    }
    private void listarTipoSangre()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_sangre" };
        var detalle_tipo_sangre = _catalogo.ObtenerTablaCombo();
        ddl_tipo_sangre.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_sangre.DataSource = detalle_tipo_sangre;
        ddl_tipo_sangre.DataValueField = "cat_secuencial";
        ddl_tipo_sangre.DataTextField = "cat_descripcion";
        ddl_tipo_sangre.DataBind();
    }
    private void listarAgenteFisico()
    {
        _catalogo = new cls_catalogo { cat_tabla = "agente_riesgo_fisico" };
        var detalle_agente_fisico = _catalogo.ObtenerTablaCombo();

        lb_agente_fisico.DataSource = detalle_agente_fisico;
        lb_agente_fisico.DataValueField = "cat_secuencial";
        lb_agente_fisico.DataTextField = "cat_descripcion";
        lb_agente_fisico.DataBind();
    }
    private void listarAgenteQuimico()
    {
        _catalogo = new cls_catalogo { cat_tabla = "agente_riesgo_quimico" };
        var detalle_agente_quimico = _catalogo.ObtenerTablaCombo();

        lb_agente_quimico.DataSource = detalle_agente_quimico;
        lb_agente_quimico.DataValueField = "cat_secuencial";
        lb_agente_quimico.DataTextField = "cat_descripcion";
        lb_agente_quimico.DataBind();
    }
    private void listarAgenteBiologico()
    {
        _catalogo = new cls_catalogo { cat_tabla = "agente_riesgo_biologico" };
        var detalle_agente_biologico = _catalogo.ObtenerTablaCombo();

        lb_agente_biologico.DataSource = detalle_agente_biologico;
        lb_agente_biologico.DataValueField = "cat_secuencial";
        lb_agente_biologico.DataTextField = "cat_descripcion";
        lb_agente_biologico.DataBind();
    }
    private void listarAgentePsicosocial()
    {
        _catalogo = new cls_catalogo { cat_tabla = "agente_riesgo_psicosociales" };
        var detalle_agente_psicosocial = _catalogo.ObtenerTablaCombo();

        lb_agente_psicosociales.DataSource = detalle_agente_psicosocial;
        lb_agente_psicosociales.DataValueField = "cat_secuencial";
        lb_agente_psicosociales.DataTextField = "cat_descripcion";
        lb_agente_psicosociales.DataBind();
    }
    private void informacionFuncionario(int exp_id = 0)
    {
        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.exp_id = exp_id;
        var detalleFuncionario = ex_preo.ObtenerDatosFuncionarioExamen();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_nro_auto.Text = validarCampo(funcionario["exp_nro_autorizacion"]);
                ltl_convenio.Text = validarCampo(funcionario["exp_convenio"]);
                ltl_lugar.Text = validarCampo(funcionario["exp_lugar"]);
                ltl_fecha_ex_pre.Text = validarCampo(funcionario["exp_fecha_prog"]);
                ltl_telf_of.Text = validarCampo(funcionario["exp_tel_of_fun"]);
                ltl_telf_fun.Text = validarCampo(funcionario["perd_telefono"]);
                ltl_cel_fun.Text = validarCampo(funcionario["perd_celular"]);
                ltl_unidad.Text = validarCampo(funcionario["eo_descripcion"]);
                ltl_actividad.Text = validarCampo(funcionario["exp_actividad_realiza"]);

                /*Datos declarar examen*/
                txt_diagnostico.Text = validarCampo(funcionario["exp_diagnostico"]);
                txt_comentario.Text = validarCampo(funcionario["exp_comentario"]);
                txt_recomendaciones.Text = validarCampo(funcionario["exp_recomendaciones"]);
                txt_fecha_resultado_med.Text = validarCampo(funcionario["exp_fecha_examen"]);
                txt_nombre_med.Text = validarCampo(funcionario["exp_medico"]);
                txt_nro_hist.Text = validarCampo(funcionario["exp_nro_historia_clinica"]);
                ddl_tipo_sangre.SelectedValue = validarCampo(funcionario["exp_tipo_sangre"]);
                txt_caracteristica_p.Text = validarCampo(funcionario["exp_caracteristica_puesto"]);

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

    protected void btn_adicionar_dec_ex_Click(object sender, EventArgs e)
    {
        sc = "$('#declararExamen').modal('show');";
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
    protected void btn_declarar_examen_Click(object sender, EventArgs e)
    {
        int exp_id = Convert.ToInt32(Request.QueryString["id3"].ToString());
        ex_preo = new cls_bs_examen_preocupacional();
        ex_preo.exp_id = exp_id;
        ex_preo.exp_diagnostico = txt_diagnostico.Text.Trim().ToUpper();
        ex_preo.exp_comentario = txt_comentario.Text.Trim().ToUpper();
        ex_preo.exp_recomendaciones = txt_recomendaciones.Text.Trim().ToUpper();
        ex_preo.exp_fecha_examen = txt_fecha_resultado_med.Text;
        ex_preo.exp_medico = txt_nombre_med.Text.Trim().ToUpper();
        ex_preo.exp_nro_historia_clinica = Convert.ToInt32(txt_nro_hist.Text);
        ex_preo.exp_tipo_sangre = ddl_tipo_sangre.SelectedValue;
        ex_preo.exp_caracteristica_puesto = txt_caracteristica_p.Text.Trim().ToUpper();
        ex_preo.exp_importe = (ltl_convenio.Text.Trim().ToUpper() == "SI") ? 190 : 0;
        ex_preo.DeclararExamen();

        guardarAgenteExpuesto();
        informacionFuncionario(exp_id);
        obtenerAgenteExpuesto(exp_id);
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Se declaró el examen correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#declararExamen').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }
    private void guardarAgenteExpuesto()
    {
        int exp_id = Convert.ToInt32(Request.QueryString["id3"].ToString());
        agente_exp = new cls_bs_agente_expuesto();
        agente_exp.agexp_exp_id = exp_id;
        agente_exp.agexp_fisico = formatearLista(lb_agente_fisico.Items);
        agente_exp.agexp_quimico = formatearLista(lb_agente_quimico.Items);
        agente_exp.agexp_biologico = formatearLista(lb_agente_biologico.Items);
        agente_exp.agexp_psicosocial = formatearLista(lb_agente_psicosociales.Items);

        var existe = agente_exp.ObtenerRegistro();
        if (existe.Tables[0].Rows.Count > 0)
        {
            agente_exp.Actualizar();
        }
        else
        {
            agente_exp.Adicionar();
        }


    }
    private string formatearLista(ListItemCollection items)
    {
        string json = "";

        DataTable lista_ = new DataTable();
        lista_.Columns.Add("ag_id");
        DataRow dr = null;
        foreach (ListItem item in items)
        {
            if (item.Selected)
            {
                dr = lista_.NewRow();
                dr["ag_id"] = item.Value;
                lista_.Rows.Add(dr);
            }
        }
        json = (lista_.Rows.Count > 0) ? JsonConvert.SerializeObject(lista_) : null;

        return json;
    }
}