using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
public partial class BienestarSocial_AnalisisExPreo : System.Web.UI.Page
{
    private cls_bs_examen_preocupacional ex_preo = null;
    private cls_bs_agente_expuesto agente_exp = null;
    private cls_bs_enfermedades_recurrentes enf_rec = null;
    private cls_catalogo _catalogo = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            string exp_id = Request.QueryString["id3"].ToString();
            listarPatologias();
            listarAgenteFisico();
            listarAgenteQuimico();
            listarAgenteBiologico();
            listarAgentePsicosocial();
            listarPatologia();

            informacionFuncionario(Convert.ToInt32(exp_id));
            obtenerAgenteExpuesto(Convert.ToInt32(exp_id));
            SetScriptInicio("");

        }
    }
    private void listarPatologia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "patologia" };
        ddl_patologias.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_patologias.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_patologias.DataValueField = "cat_secuencial";
        ddl_patologias.DataTextField = "cat_descripcion";
        ddl_patologias.DataBind();
    }
    private void listarEspecualidad()
    {
        _catalogo = new cls_catalogo { cat_tabla = "especialidad" };
        ddl_especiadlidad_add.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_especiadlidad_add.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_especiadlidad_add.DataValueField = "cat_secuencial";
        ddl_especiadlidad_add.DataTextField = "cat_descripcion";
        ddl_especiadlidad_add.DataBind();
    }
    private void SetScriptInicio(string data)
    {
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

        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        data = "$('#ContentPlaceHolder1_lb_agente_fisico').prop('disabled', true); $('#ContentPlaceHolder1_lb_agente_quimico').prop('disabled', true); $('#ContentPlaceHolder1_lb_agente_biologico').prop('disabled', true); $('#ContentPlaceHolder1_lb_agente_psicosociales').prop('disabled', true); ";
        StringBuilder sb = new StringBuilder();

        sb.Append(data);
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
                 "'language': " + l +
                 "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 }); }");

        sb.Append("$('#ContentPlaceHolder1_gv_patologias').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_patologias').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 });");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
    }
    private void SetScript(string data)
    {
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

        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
         "'language': " + l +
         "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append(data);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_especiadlidad_add').select2({ dropdownParent: $('#nuevaPatologia'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_lb_agente_fisico').prop('disabled', true); $('#ContentPlaceHolder1_lb_agente_quimico').prop('disabled', true); $('#ContentPlaceHolder1_lb_agente_biologico').prop('disabled', true); $('#ContentPlaceHolder1_lb_agente_psicosociales').prop('disabled', true); ");
  
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
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

    private void listarPatologias()
    {
        int exp_id = Convert.ToInt32(Request.QueryString["id3"].ToString());
        try
        {
            enf_rec = new cls_bs_enfermedades_recurrentes();
            enf_rec.enfrec_exp_id = exp_id;
            gv_patologias.DataSource = enf_rec.ObtenerTablaGrilla();
            gv_patologias.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
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

                ltl_diagnostico.Text = validarCampo(funcionario["exp_diagnostico"]);
                ltl_comentario.Text = validarCampo(funcionario["exp_comentario"]);
                ltl_recomendaciones.Text = validarCampo(funcionario["exp_recomendaciones"]);
                ltl_carac_puesto.Text = validarCampo(funcionario["exp_caracteristica_puesto"]);
              
      

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

    protected void btn_adicionar_patologia_Click(object sender, EventArgs e)
    {
        sc = "$('#analisisExamen').modal('show');";
        SetScript(sc);
    }

    protected void ddl_patologias_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddl_especialidad.Items.Clear();


        _catalogo = new cls_catalogo { cat_tabla = "patologia", cat_secuencial = Convert.ToInt32(ddl_patologias.SelectedValue) };
        var detalle_padre = _catalogo.ObtenerRegistroPadre();

        ddl_especialidad.DataSource = detalle_padre;
        ddl_especialidad.DataValueField = "cat_secuencial";
        ddl_especialidad.DataTextField = "cat_descripcion";
        ddl_especialidad.DataBind();
        SetScript("");
    }


    protected void gv_patologias_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_patologias.Rows.Count > 0)
        {
            if (gv_patologias.HeaderRow != null)
            {
                gv_patologias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_patologias.FooterRow != null)
            {
                gv_patologias.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_patologias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_enfrec_id.Value = gv_patologias.DataKeys[index].Values[0].ToString();

        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarPatologia').modal('show');";
                SetScript(sc);
                break;

            default:
                break;
        }
    }

    protected void btn_analisi_examen_Click(object sender, EventArgs e)
    {
        int exp_id = Convert.ToInt32(Request.QueryString["id3"].ToString());
        enf_rec = new cls_bs_enfermedades_recurrentes();
        enf_rec.enfrec_exp_id = exp_id;
        enf_rec.enfrec_pat_id = Convert.ToInt32(ddl_patologias.SelectedValue);
        enf_rec.enfrec_esp_id = Convert.ToInt32(ddl_especialidad.SelectedValue);
        enf_rec.Adicionar();

        ddl_patologias.SelectedValue = "0";
        ddl_especialidad.Items.Clear();
        listarPatologias();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Patología registrada correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#analisisExamen').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_eliminar_patologia_Click(object sender, EventArgs e)
    {
        enf_rec = new cls_bs_enfermedades_recurrentes();
        enf_rec.enfrec_id = Convert.ToInt32(hf_enfrec_id.Value);
        enf_rec.Eliminar();
        listarPatologias();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Se eliminó la patología correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarPatologia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_nueva_patologia_Click(object sender, EventArgs e)
    {
        ddl_especiadlidad_add.SelectedValue = "0";
        txt_patologia.Text = "";
        listarEspecualidad();
        sc = "$('#nuevaPatologia').modal('show');";
        SetScript(sc);
    }

    protected void btn_adicionar_patologia_ad_Click(object sender, EventArgs e)
    {
        _catalogo = new cls_catalogo();
        _catalogo.cat_tabla = "patologia";
        _catalogo.cat_tabla_aux = "especialidad";
        _catalogo.cat_descripcion = txt_patologia.Text.Trim().ToUpper();
        _catalogo.cat_id_superior = Convert.ToInt32(ddl_especiadlidad_add.SelectedValue);
        _catalogo.AdicionarCatalogoSecuencial();
        listarPatologia();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Patología nueva guardada correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#nuevaPatologia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }
}