using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using System.Data;

public partial class Precontrataciones_Planilla : System.Web.UI.Page
{
    private cls_pc_frecuencia frecuencia = null;
    private cls_pc_precontratado precontratado = null;
    private cls_pc_precontratado planilla = null;
    private cls_historico historico = null;
    private cls_catalogo _catalogo = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
                int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
                int pl_ue = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
                int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
                informacionPlanilla(pl_id);
                listarPlanilla(pl_id);
                listarAFP();
                listarGenero();
                SetScriptInicio("$('.table').DataTable().destroy(); ");
            }
        }
        else
        {
            Response.Redirect("../index");
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
        sb.Append("$('#ContentPlaceHolder1_gv_planilla').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_planilla').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable({" +
        "'language': " + l +
        "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto').select2({ dropdownParent: $('#modalAdicionarFrecPost'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_afp').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_pre_genero').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_usuarios').select2({ dropdownParent: $('#modalEnviar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        //sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
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
        sb.Append("$('#ContentPlaceHolder1_gv_planilla').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_planilla')) { $('#ContentPlaceHolder1_gv_planilla').DataTable({" +
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
        sb.Append("$('#modalAdicionarFrecPost .select2').each(function() { var $p = $(this).parent(); $(this).select2({ dropdownParent: $p, placeholder: { id: '0', text: 'Seleccione...' }}); });");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto_modificar').select2({ dropdownParent: $('#modalModificarPuesto'), placeholder: { id: '0', text: 'Seleccione...' } });");
        //sb.Append("$('#ContentPlaceHolder1_ddl_afp').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        //sb.Append("$('#ContentPlaceHolder1_ddl_pre_genero').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        //sb.Append("$('#ContentPlaceHolder1_ddl_tipo_item').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#modalPersona .select2').each(function() { var $p = $(this).parent(); $(this).select2({ dropdownParent: $p, placeholder: { id: '0', text: 'Seleccione...' }}); });");

        sb.Append("$('#ContentPlaceHolder1_ddl_usuarios').select2({ dropdownParent: $('#modalEnviar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
    protected void gv_planilla_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_planilla.Rows.Count > 0)
        {
            if (gv_planilla.HeaderRow != null)
            {
                gv_planilla.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_planilla.FooterRow != null)
            {
                gv_planilla.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_planilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_pre_id.Value = gv_planilla.DataKeys[index].Values[0].ToString();
        hf_fr_id.Value = gv_planilla.DataKeys[index].Values[1].ToString();
        int cp_id = Convert.ToInt32(gv_planilla.DataKeys[index].Values[2].ToString());
        hf_fr_es_id.Value = gv_planilla.DataKeys[index].Values[3].ToString();

        gv_persona.DataSource = null;
        gv_persona.DataBind();
        switch (e.CommandName)
        {
            case "GetAssign":

                hf_pre_editar.Value = "0";
                datosPrecontrato();
                listaFiltradoItem(cp_id);
                sc = "$('#modalPersona').modal('show');";
                SetScript(sc);
                break;
            case "GetEdit":
                //sc = "$('#anularAsignacion').modal('show');";
                //SetScript(sc);
                hf_pre_editar.Value = "1";
                datosPrecontratoEditar();
                listaFiltradoItem(cp_id);
                sc = "$('#modalPersona').modal('show'); " + datosFuncionario();
                SetScript(sc);
                break;
            case "GetEditP":
                datosPuesto();
                sc = "$('#modalModificarPuesto').modal('show');";
                SetScript(sc);
                break;
            case "GetDelete":
                sc = "$('#eliminarPrecontrato').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    private void datosPrecontrato()
    {
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        frecuencia = new cls_pc_frecuencia { fr_id = Convert.ToInt32(hf_fr_id.Value), fr_pr_id = pr_id };
        var detalleFrecuencia = frecuencia.ObtenerFrecuenciaOcupadoX();

        if (detalleFrecuencia.Tables.Count > 0)
        {
            if (detalleFrecuencia.Tables[0].Rows.Count > 0)
            {
                var frecuenciaX = detalleFrecuencia.Tables[0].Rows[0];
                ltl_cargo_ocupado.Text = validarCampo(frecuenciaX["es_descripcion"]);
                ltl_tiempo_libre.Text = validarCampo(frecuenciaX["tiempo"]);
                ltl_fr_tiempo_inicio.Text = validarCampo(frecuenciaX["fr_fecha_inicio"]);
                ltl_fr_tiempo_fin.Text = validarCampo(frecuenciaX["fr_fecha_fin"]);
                ltl_tipo_jornada_ocupado.Text = validarCampo(frecuenciaX["fr_tipo_jornada"]);
                ltl_puesto_ocupado.Text = validarCampo(frecuenciaX["pu_descripcion"]);
                hf_pre_fr_id.Value = validarCampo(frecuenciaX["fr_id"]);
                imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
            }
        }
    }
    private void datosPrecontratoEditar()
    {
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        frecuencia = new cls_pc_frecuencia { fr_id = Convert.ToInt32(hf_fr_id.Value), fr_pr_id = pr_id, fr_pu_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalleFrecuencia = frecuencia.ObtenerFrecuenciaOcupadoX2();

        if (detalleFrecuencia.Tables.Count > 0)
        {
            if (detalleFrecuencia.Tables[0].Rows.Count > 0)
            {
                var frecuenciaX = detalleFrecuencia.Tables[0].Rows[0];
                ltl_cargo_ocupado.Text = validarCampo(frecuenciaX["es_descripcion"]);
                ltl_tiempo_libre.Text = validarCampo(frecuenciaX["tiempo"]);
                ltl_fr_tiempo_inicio.Text = validarCampo(frecuenciaX["fr_fecha_inicio"]);
                ltl_fr_tiempo_fin.Text = validarCampo(frecuenciaX["fr_fecha_fin"]);
                ltl_tipo_jornada_ocupado.Text = validarCampo(frecuenciaX["fr_tipo_jornada"]);
                ltl_puesto_ocupado.Text = validarCampo(frecuenciaX["pu_descripcion"]);
                hf_pre_fr_id.Value = validarCampo(frecuenciaX["fr_id"]);
            }
        }
    }
    private void datosPuesto()
    {
        listaFiltradoPuesto();
        precontratado = new cls_pc_precontratado { pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detallePuesto = precontratado.DatosPuestoX();

        if (detallePuesto.Tables.Count > 0)
        {
            if (detallePuesto.Tables[0].Rows.Count > 0)
            {
                var puestoX = detallePuesto.Tables[0].Rows[0];
                ddl_puesto_modificar.SelectedValue = validarCampo(puestoX["pre_p_id"]);
                txt_objetivo_modificar.Text = validarCampo(puestoX["pre_obj_puesto"]);
                txt_tareas_modificar.Text = validarCampo(puestoX["pre_tareas"]);
            }
        }
        hf_fr_es_id.Value = "";
    }

    private string datosFuncionario()
    {
        string js = "";
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_precontrato = precontratado.DatosDetallePrecontrato();
        if (detalle_precontrato.Tables.Count > 0)
        {
            if (detalle_precontrato.Tables[0].Rows.Count > 0)
            {
                var funcionarioX = detalle_precontrato.Tables[0].Rows[0];
                hf_pre_per_id.Value = validarCampo(funcionarioX["per_id"]);
                txt_pre_paterno.Text = validarCampo(funcionarioX["ap_paterno_x"]);
                txt_pre_materno.Text = validarCampo(funcionarioX["ap_materno_x"]);
                txt_pre_nombres.Text = validarCampo(funcionarioX["nombres_x"]);
                txt_pre_ap_casada.Text = validarCampo(funcionarioX["ap_casada_x"]);
                txt_ci.Text = validarCampo(funcionarioX["ci_x"]);
                ddl_pre_genero.SelectedValue = validarCampo(funcionarioX["genero_x"]);
                ddl_afp.SelectedValue = validarCampo(funcionarioX["afp_x"]);
                chk_pre_djbr.Checked = Convert.ToBoolean(validarCampo(funcionarioX["pre_presenta_djbr"]));
                txt_pre_fecha_asig.Text = validarCampo(funcionarioX["pre_fecha_inicio"]);
                txt_pre_fecha_baja.Text = validarCampo(funcionarioX["pre_fecha_fin"]);
                ltl_pre_tiempo_calculo.Text = validarCampo(funcionarioX["pre_tiempo"]);
                txt_pre_numero_item.Text = validarCampo(funcionarioX["pre_numero_item"]);
                hf_tmp_id.Value = validarCampo(funcionarioX["tmp_id"]);

                txt_fecha_sipasse.Text = validarCampo(funcionarioX["pre_fecha_sipasse"]);
                txt_fecha_djbr.Text = validarCampo(funcionarioX["pre_fecha_djbr"]);

                string fp_foto = (funcionarioX["fp_foto"] != DBNull.Value && funcionarioX["fp_foto"].ToString().Trim() != "") ? funcionarioX["fp_foto"].ToString().Trim() : "";
                string sexo_int = validarCampo(funcionarioX["genero_x"]);

                if (fp_foto != "")
                {
                    imgFun_int.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])funcionarioX["fp_foto"]);
                }
                else
                {
                    if (sexo_int == "")
                    {
                        imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
                    }
                    else
                    {
                        if (sexo_int == "M")
                        {
                            imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
                        }
                        else
                        {
                            imgFun_int.ImageUrl = "../Content/img/theme/user4.jpg";
                        }
                    }

                }
            }
        }

        if (hf_pre_per_id.Value != "0")
        {
            txt_pre_paterno.Enabled = false;
            txt_pre_materno.Enabled = false;
            txt_pre_nombres.Enabled = false;
            txt_pre_ap_casada.Enabled = false;
            txt_ci.Enabled = false;
            ddl_afp.Enabled = false;
            ddl_pre_genero.Enabled = false;
            js = "";
        }
        else
        {
            txt_pre_paterno.Enabled = true;
            txt_pre_materno.Enabled = true;
            txt_pre_nombres.Enabled = true;
            txt_pre_ap_casada.Enabled = true;
            txt_ci.Enabled = true;
            ddl_afp.Enabled = true;
            ddl_pre_genero.Enabled = true;

        }
        return js;
    }
    private void listarCategorias(int us_id = 0, int pl_ue = 0, int pr_id = 0)
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.perm_us_id = us_id;
            frecuencia.perm_ue = pl_ue;
            frecuencia.perm_pr_id = pr_id;
            var cat_disp = frecuencia.ObtenerCategorias();
            int tam = cat_disp.Tables[0].Rows.Count;

            if (tam > 0)
            {
                no_existe_cat.Visible = false;

            }
            else
            {
                no_existe_cat.Visible = true;
            }
            masivo_frec.Visible = false;
            gv_categorias.DataSource = cat_disp;
            gv_categorias.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void gv_categorias_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_categorias.Rows.Count > 0)
        {
            if (gv_categorias.HeaderRow != null)
            {
                gv_categorias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_categorias.FooterRow != null)
            {
                gv_categorias.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_categorias_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btn_adicionar_frec_Click(object sender, EventArgs e)
    {

    }

    protected void btn_adic_nueva_frec_Click(object sender, EventArgs e)
    {
        no_existe_cat.Visible = false;
        no_existe_frec.Visible = false;
        no_existe_frec_t.Visible = false;

        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        int pl_ue = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        listarCategorias(us_id, pl_ue, pr_id);
        gv_frecuencias.DataSource = null;
        gv_frecuencias.DataBind();
        sc = "$('#modalAdicionarFrec').modal('show');";
        SetScript(sc);
    }


    protected void chk_cp_CheckedChanged(object sender, EventArgs e)
    {
        CheckBox checkbox = (CheckBox)sender;
        GridViewRow rowMarcado = (GridViewRow)checkbox.NamingContainer;
        bool chk_marcado = ((CheckBox)rowMarcado.FindControl("chk_cp")).Checked;
        int nro = rowMarcado.DataItemIndex;

        int cp_id = 0;
        if (chk_marcado)
        {
            for (int i = 0; i < gv_categorias.Rows.Count; i++)
            {
                GridViewRow row = gv_categorias.Rows[i];

                if (i != nro)
                {
                    ((CheckBox)row.FindControl("chk_cp")).Checked = false;
                }
                else
                {
                    cp_id = (int)gv_categorias.DataKeys[nro].Value;
                    hf_cp_id.Value = Convert.ToString(cp_id);
                }
            }
        }
        if (cp_id != 0)
        {
            ltl_msj_no_existe_frec.Text = "No existe frecuencias libres en la categoría seleccionada.";
        }
        else
        {
            ltl_msj_no_existe_frec.Text = "Seleccione una categoría para listar las frecuencias libres.";
        }
        listarFrecuencias(cp_id);
        SetScript("");
    }
    private void listarFrecuencias(int cp_id = 0, int fr_es_id = 0, string fr_descrip_puesto = "0", decimal fr_tiempo = 0)
    {
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cp_id = cp_id;
            frecuencia.fr_pr_id = pr_id;
            frecuencia.fr_es_id = fr_es_id;
            frecuencia.fr_descrip_puesto = fr_descrip_puesto;
            frecuencia.fr_tiempo = fr_tiempo;
            var frecuencia_libre = frecuencia.ObtenerFrecuenciasLibres();
            int tam = frecuencia_libre.Tables[0].Rows.Count;

            if (tam > 0)
            {
                no_existe_frec.Visible = false;
                no_existe_frec_t.Visible = true;
            }
            else
            {
                no_existe_frec.Visible = true;
                no_existe_frec_t.Visible = true;
            }
            gv_frecuencias.DataSource = frecuencia_libre;
            gv_frecuencias.DataBind();

            listaFiltradoFrec(cp_id, pr_id, fr_es_id, fr_descrip_puesto, fr_tiempo, "C15", "ddl_gv_frec_cargo", "es_id", "es_descripcion", "ES.es_descripcion, ES.es_id");
            listaFiltradoFrec(cp_id, pr_id, fr_es_id, fr_descrip_puesto, fr_tiempo, "C15", "ddl_gv_frec_puesto", "fr_pu_descripcion", "fr_pu_descripcion", "F.fr_pu_descripcion");
            listaFiltradoFrec(cp_id, pr_id, fr_es_id, fr_descrip_puesto, fr_tiempo, "C15", "ddl_gv_frec_tiempo", "fr_tiempo", "fr_tiempo", "ROUND((F.fr_tiempo - ISNULL(PC.tiempo, 0)), 6) AS fr_tiempo");
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaFiltradoFrec(int cp_id = 0, int pr_id = 0, int fr_es_id = 0, string fr_descrip_puesto = "0", decimal fr_tiempo = 0, string accion = "", string ddl_id = "", string ddl_value = "", string ddl_desc = "", string q = "")
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cp_id = cp_id;
            frecuencia.fr_pr_id = pr_id;
            frecuencia.fr_es_id = fr_es_id;
            frecuencia.fr_descrip_puesto = fr_descrip_puesto;
            frecuencia.fr_tiempo = fr_tiempo;
            frecuencia.accion = accion;

            DropDownList ddl = gv_frecuencias.HeaderRow.FindControl(ddl_id) as DropDownList;
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("TODOS", "0"));
            ddl.DataValueField = ddl_value;
            ddl.DataTextField = ddl_desc;
            ddl.DataSource = frecuencia.ObtenerListaFiltradoFrec(q);
            ddl.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_frecuencias_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_frecuencias.Rows.Count > 0)
        {
            if (gv_frecuencias.HeaderRow != null)
            {
                gv_frecuencias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_frecuencias.FooterRow != null)
            {
                gv_frecuencias.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_frecuencias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string fr_id = gv_frecuencias.DataKeys[index].Values[0].ToString();
        string fr_es_id = gv_frecuencias.DataKeys[index].Values[1].ToString();
        hf_fr_id.Value = fr_id;
        hf_fr_es_id.Value = fr_es_id;

        switch (e.CommandName)
        {
            case "GetAssign":
                datosfrecuencia();
                break;
            default:
                break;
        }
    }
    private void datosfrecuencia()
    {
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        listaFiltradoPuesto();
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_cp_id = Convert.ToInt32(hf_cp_id.Value);
        frecuencia.fr_pr_id = pr_id;
        frecuencia.fr_id = Convert.ToInt32(hf_fr_id.Value);
        var detalle_frecuencia_x = frecuencia.ObtenerFrecuenciasLibresX();

        if (detalle_frecuencia_x.Tables.Count > 0)
        {
            if (detalle_frecuencia_x.Tables[0].Rows.Count > 0)
            {
                var frecuenciaX = detalle_frecuencia_x.Tables[0].Rows[0];
                ltl_desc.Text = validarCampo(frecuenciaX["cp_descripcion"]);
                ltl_da.Text = validarCampo(frecuenciaX["cp_da"]);
                ltl_ue.Text = validarCampo(frecuenciaX["cp_ue"]);
                ltl_prog.Text = validarCampo(frecuenciaX["cp_programa"]);
                ltl_proy.Text = validarCampo(frecuenciaX["cp_proyecto"]);
                ltl_act.Text = validarCampo(frecuenciaX["cp_actividad"]);
                ltl_cargo.Text = validarCampo(frecuenciaX["es_descripcion"]);
                string hb = validarCampo(frecuenciaX["haber_basico"]);
                ltl_hb.Text = String.Format("{0:0.00}", Convert.ToDecimal(hb)); 
                ltl_tiempo.Text = validarCampo(frecuenciaX["tiempo"]);
                ltl_tipo_jornada.Text = validarCampo(frecuenciaX["fr_tipo_jornada"]);
                var puesto = ddl_puesto.Items.FindByText(validarCampo(frecuenciaX["fr_pu_descripcion"]));
                ddl_puesto.SelectedValue = (puesto != null) ? puesto.Value : "0";

                ltl_cantidad_post.Text = "1";
                ltl_cantidad_desc_post.Text = "Frecuencia a registrar";
                hf_masivo.Value = "0";
            }
        }
        sc = "$('#modalAdicionarFrec').modal('hide'); $('#modalAdicionarFrecPost').modal('show');";
        SetScript(sc);
    }

    protected void btn_cerrar_categorias_Click(object sender, EventArgs e)
    {
        sc = "$('#modalAdicionarFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_adicionar_frecuencia_Click(object sender, EventArgs e)
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        if (hf_masivo.Value != "1")
        {
            precontratado = new cls_pc_precontratado();
            precontratado.pre_pl_id = pl_id;
            precontratado.pre_fr_id = Convert.ToInt32(hf_fr_id.Value);
            precontratado.pre_pu_id = Convert.ToInt32(ddl_puesto.SelectedValue);
            precontratado.pre_obj_puesto = txt_objetivo.Text;
            precontratado.pre_tareas = txt_tareas.Text;
            var detallePrecontratado = precontratado.AdicionarPreContratadoPuesto();
            if (detallePrecontratado.Tables.Count > 0)
            {
                if (detallePrecontratado.Tables[0].Rows.Count > 0)
                {
                    var precontratadoX = detallePrecontratado.Tables[0].Rows[0];
                    string pre_id_x = validarCampo(precontratadoX["pre_id"]);
                    string json = JsonConvert.SerializeObject(detallePrecontratado.Tables[0]);
                    AdicionarHistorico("A", "tbl_pc_precontratado", "pre_id", Convert.ToString(pre_id_x), json);
                }
            }
        }
        else
        {
            for (int i = 0; i < gv_frecuencias.Rows.Count; i++)
            {
                GridViewRow row = gv_frecuencias.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chk_frec")).Checked;

                if (isChecked)
                {
                    int fr_id = (int)gv_frecuencias.DataKeys[i].Values[0];
                    precontratado = new cls_pc_precontratado();
                    precontratado.pre_pl_id = pl_id;
                    precontratado.pre_fr_id = fr_id;
                    precontratado.pre_pu_id = Convert.ToInt32(ddl_puesto.SelectedValue);
                    precontratado.pre_obj_puesto = txt_objetivo.Text;
                    precontratado.pre_tareas = txt_tareas.Text;
                    var detallePrecontratado = precontratado.AdicionarPreContratadoPuesto();
                    if (detallePrecontratado.Tables.Count > 0)
                    {
                        if (detallePrecontratado.Tables[0].Rows.Count > 0)
                        {
                            var precontratadoX = detallePrecontratado.Tables[0].Rows[0];
                            string pre_id_x = validarCampo(precontratadoX["pre_id"]);
                            string json = JsonConvert.SerializeObject(detallePrecontratado.Tables[0]);
                            AdicionarHistorico("A", "tbl_pc_precontratado", "pre_id", Convert.ToString(pre_id_x), json);
                        }
                    }
                }

            }
        }
        listarPlanilla(pl_id);
        limpiar();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Frecuencia adicionada correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalAdicionarFrec').modal('hide'); $('#modalAdicionarFrecPost').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_cancelar_frecuencia_Click(object sender, EventArgs e)
    {
        limpiar();
        sc = "$('#modalAdicionarFrecPost').modal('hide'); $('#modalAdicionarFrec').modal('show');  MostrarMascara(false);";
        SetScript(sc);
    }
    private void listaFiltradoPuesto()
    {
        try
        {
            int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_pr_id = pr_id;
            frecuencia.fr_es_id = Convert.ToInt32(hf_fr_es_id.Value);
            var puestos = frecuencia.ObtenerListaFiltradoPuesto();

            ddl_puesto.Items.Clear();
            ddl_puesto.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_puesto.DataValueField = "pu_id";
            ddl_puesto.DataTextField = "pu_descripcion";
            ddl_puesto.DataSource = puestos;
            ddl_puesto.DataBind();

            ddl_puesto_modificar.Items.Clear();
            ddl_puesto_modificar.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_puesto_modificar.DataValueField = "pu_id";
            ddl_puesto_modificar.DataTextField = "pu_descripcion";
            ddl_puesto_modificar.DataSource = puestos;
            ddl_puesto_modificar.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listarPlanilla(int pl_id = 0, int es_id = 0, string paterno = "0")
    {
        try
        {
            precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, es_id = es_id, pre_paterno = paterno };
            var precontratos = precontratado.ListarPrecontratos();
            int tam = precontratos.Tables[0].Rows.Count;
            no_existe_prec.Visible = (tam > 0) ? false : true;
            gv_planilla.DataSource = precontratos;
            gv_planilla.DataBind();

            foreach (GridViewRow row in gv_planilla.Rows)
            {
                for (int i = 0; i < gv_planilla.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        string estado = row.Cells[i].Text;
                        if (estado == "ACEFALIA")
                        {
                            row.CssClass = "grid-row-enabled";
                        }
                    }

                }
            }

            listaFiltradoPlanilla(pl_id, es_id, paterno, "C21", "ddl_gv_planilla_paterno", "ap_paterno_x", "ap_paterno_x", " CASE WHEN P.per_id IS NULL AND TPC.tmp_id IS NULL THEN 'ACEFALIA' WHEN P.per_id IS NOT NULL AND TPC.tmp_id IS NULL THEN LTRIM(RTRIM(P.per_ap_paterno)) WHEN P.per_id IS NULL AND TPC.tmp_id IS NOT NULL THEN LTRIM(RTRIM(TPC.tmp_paterno)) END AS ap_paterno_x ");
            listaFiltradoPlanilla(pl_id, es_id, paterno, "C20", "ddl_gv_planilla_cargo", "es_id", "es_descripcion", "ES.es_descripcion, ES.es_id");

            btn_enviar_planilla.Visible = (ltl_pl_estado.Text.Trim() != "") ? (ltl_pl_estado.Text.Trim() == "CREADO" || ltl_pl_estado.Text.Trim() == "AJUSTAR") ? true : false : false;
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaFiltradoPlanilla(int pl_id = 0, int es_id = 0, string paterno = "0", string accion = "", string ddl_id = "", string ddl_value = "", string ddl_desc = "", string q = "")
    {
        try
        {
            precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, es_id = es_id, pre_paterno = paterno, accion = accion };

            DropDownList ddl = gv_planilla.HeaderRow.FindControl(ddl_id) as DropDownList;
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("TODOS", "0"));
            ddl.DataValueField = ddl_value;
            ddl.DataTextField = ddl_desc;
            ddl.DataSource = precontratado.ObtenerListaFiltradoPlanilla(q);
            ddl.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void informacionPlanilla(int pl_id = 0)
    {
        planilla = new cls_pc_precontratado { pl_id = Convert.ToString(pl_id) };
        var detalle_planilla = planilla.DetallePlanilla();
        if (detalle_planilla.Tables.Count > 0)
        {
            if (detalle_planilla.Tables[0].Rows.Count > 0)
            {
                var planillaX = detalle_planilla.Tables[0].Rows[0];
                ltl_pl_correlativo.Text = validarCampo(planillaX["pl_id"]);
                ltl_pl_fecha.Text = validarCampo(planillaX["fecha_creacion"]);
                ltl_pl_estado.Text = validarCampo(planillaX["pl_estado"]);
                ltl_pl_ue.Text = validarCampo(planillaX["pl_ue"]) + " - " + validarCampo(planillaX["ue"]);
            }
        }
    }
    private void limpiar()
    {
        ddl_puesto.SelectedValue = "0";
        txt_objetivo.Text = "";
        txt_tareas.Text = "";
    }

    protected void btn_eilminar_pre_Click(object sender, EventArgs e)
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        precontratado = new cls_pc_precontratado();
        precontratado.pre_id = Convert.ToInt32(hf_pre_id.Value);
        precontratado.pre_fr_id = Convert.ToInt32(hf_fr_id.Value);
        precontratado.Eliminar();

        listarPlanilla(pl_id);
        limpiar();
        sc = "Swal.fire({ icon: 'success', title: 'Pre-Contrato eliminado correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarPrecontrato').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void ddl_gv_frec_cargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        masivo_frec.Visible = false;
        listarFrecuenciasLibres();
    }

    protected void ddl_gv_frec_puesto_SelectedIndexChanged(object sender, EventArgs e)
    {
        masivo_frec.Visible = false;
        listarFrecuenciasLibres();
    }

    protected void ddl_gv_frec_tiempo_SelectedIndexChanged(object sender, EventArgs e)
    {
        masivo_frec.Visible = false;
        listarFrecuenciasLibres();
    }
    private void listarFrecuenciasLibres()
    {
        DropDownList ddl_gv_frec_cargo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;
        DropDownList ddl_gv_frec_puesto = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_puesto") as DropDownList;
        DropDownList ddl_gv_frec_tiempo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_tiempo") as DropDownList;
        int cp_ip = Convert.ToInt32(hf_cp_id.Value);
        int fr_es_id = Convert.ToInt32(ddl_gv_frec_cargo.SelectedValue);
        string fr_descrip_puesto = ddl_gv_frec_puesto.SelectedValue;
        decimal fr_tiempo = Convert.ToDecimal(ddl_gv_frec_tiempo.SelectedValue);
        listarFrecuencias(cp_ip, fr_es_id, fr_descrip_puesto, fr_tiempo);

        DropDownList ddl_gv_frec_cargo_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;
        DropDownList ddl_gv_frec_puesto_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_puesto") as DropDownList;
        DropDownList ddl_gv_frec_tiempo_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_tiempo") as DropDownList;
        ddl_gv_frec_cargo_after.SelectedValue = fr_es_id + "";
        ddl_gv_frec_puesto_after.SelectedValue = fr_descrip_puesto + "";
        ddl_gv_frec_tiempo_after.SelectedValue = fr_tiempo + "";
        SetScript("");
    }

    //protected void txt_cantidad_TextChanged(object sender, EventArgs e)
    //{
    //    if (ltl_cantidad.Text != "")
    //    {
    //        int cantidad = Convert.ToInt32(ltl_cantidad.Text);
    //        for (int i = 0; i < gv_frecuencias.Rows.Count; i++)
    //        {
    //            GridViewRow row = gv_frecuencias.Rows[i];
    //            if (i < cantidad)
    //            {
    //                bool isChecked = ((CheckBox)row.FindControl("chk_frec")).Checked;

    //                if (!isChecked)
    //                {
    //                    ((CheckBox)row.FindControl("chk_frec")).Checked = true;
    //                }
    //            } else
    //            {
    //                ((CheckBox)row.FindControl("chk_frec")).Checked = false;
    //            } 

    //        }
    //    }
    //    SetScript("");
    //}

    protected void chk_frec_all_CheckedChanged(object sender, EventArgs e)
    {
        DropDownList ddl_gv_frec_cargo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;

        if (ddl_gv_frec_cargo.SelectedValue != "0" && ddl_gv_frec_cargo.SelectedValue != "")
        {
            bool isChecked = ((CheckBox)gv_frecuencias.HeaderRow.FindControl("chk_frec_all")).Checked;
            masivo_frec.Visible = (isChecked) ? true : false;
            for (int i = 0; i < gv_frecuencias.Rows.Count; i++)
            {
                GridViewRow row = gv_frecuencias.Rows[i];
                if (isChecked)
                {
                    ((CheckBox)row.FindControl("chk_frec")).Checked = true;
                }
                else
                {
                    ((CheckBox)row.FindControl("chk_frec")).Checked = false;
                }
            }
            int nro = obtenerMarcados();
            ltl_cantidad.Text = Convert.ToString(nro);
            ltl_cantidad_desc.Text = (nro == 1) ? "Frecuencia marcada" : "Frecuencias marcadas";
            SetScript("");
        }
        else
        {
            ((CheckBox)gv_frecuencias.HeaderRow.FindControl("chk_frec_all")).Checked = false;
            sc = "$.notify({ icon: 'fa fa-info', message: 'Por favor filtre el cargo requerido.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }

    private int obtenerMarcados()
    {
        int nro = 0;
        for (int i = 0; i < gv_frecuencias.Rows.Count; i++)
        {
            GridViewRow row = gv_frecuencias.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chk_frec")).Checked;

            if (isChecked)
            {
                int fr_es_id = (int)gv_frecuencias.DataKeys[i].Values[1];
                hf_fr_es_id.Value = fr_es_id + "";
                nro++;
            }
        }
        return nro;
    }

    protected void chk_frec_CheckedChanged(object sender, EventArgs e)
    {
        DropDownList ddl_gv_frec_cargo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;

        if (ddl_gv_frec_cargo.SelectedValue != "0" && ddl_gv_frec_cargo.SelectedValue != "")
        {
            int nro = obtenerMarcados();
            ltl_cantidad.Text = Convert.ToString(nro);
            ltl_cantidad_desc.Text = (nro == 1) ? "Frecuencia marcada" : "Frecuencias marcadas";

            bool sw = false;
            for (int i = 0; i < gv_frecuencias.Rows.Count; i++)
            {
                GridViewRow row = gv_frecuencias.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chk_frec")).Checked;

                if (isChecked)
                {
                    sw = true;
                    break;
                }
            }

            if (!sw)
            {
                ((CheckBox)gv_frecuencias.HeaderRow.FindControl("chk_frec_all")).Checked = false;
                masivo_frec.Visible = false;
            }
            else
            {
                masivo_frec.Visible = true;
            }

            SetScript("");
        }
        else
        {
            CheckBox checkbox = (CheckBox)sender;
            GridViewRow rowMarcado = (GridViewRow)checkbox.NamingContainer;
            ((CheckBox)rowMarcado.FindControl("chk_frec")).Checked = false;
            sc = "$.notify({ icon: 'fa fa-info', message: 'Por favor filtre el cargo requerido.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }



    protected void btn_adicionar_fr_masivo_Click(object sender, EventArgs e)
    {
        int nro = obtenerMarcados();
        if (nro > 0)
        {
            listaFiltradoPuesto();
            int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
            DropDownList ddl_gv_frec_cargo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cp_id = Convert.ToInt32(hf_cp_id.Value);
            frecuencia.fr_pr_id = pr_id;
            frecuencia.fr_es_id = Convert.ToInt32(ddl_gv_frec_cargo.SelectedValue);
            var detalle_frecuencia_x = frecuencia.ObtenerFrecuenciasLibresES();
            if (detalle_frecuencia_x.Tables.Count > 0)
            {
                if (detalle_frecuencia_x.Tables[0].Rows.Count > 0)
                {
                    var frecuenciaX = detalle_frecuencia_x.Tables[0].Rows[0];
                    ltl_desc.Text = validarCampo(frecuenciaX["cp_descripcion"]);
                    ltl_da.Text = validarCampo(frecuenciaX["cp_da"]);
                    ltl_ue.Text = validarCampo(frecuenciaX["cp_ue"]);
                    ltl_prog.Text = validarCampo(frecuenciaX["cp_programa"]);
                    ltl_proy.Text = validarCampo(frecuenciaX["cp_proyecto"]);
                    ltl_act.Text = validarCampo(frecuenciaX["cp_actividad"]);
                    ltl_cargo.Text = validarCampo(frecuenciaX["es_descripcion"]);
                    ltl_hb.Text = validarCampo(frecuenciaX["haber_basico"]);
                    ltl_tiempo.Text = "";
                    ltl_tipo_jornada.Text = validarCampo(frecuenciaX["fr_tipo_jornada"]);

                    ltl_cantidad_post.Text = Convert.ToString(nro);
                    ltl_cantidad_desc_post.Text = (nro == 1) ? "Frecuencia a registrar" : "Frecuencias a registrar";
                    hf_masivo.Value = "1";
                }
            }
            sc = "$('#modalAdicionarFrec').modal('hide'); $('#modalAdicionarFrecPost').modal('show');";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message: 'Por favor marque las frecuencias requeridas.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
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
    private void AdicionarHistorico(string abm = "", string tabla = "", string nom_pk = "", string val_pk = "", string campos = "")
    {
        historico = new cls_historico
        {
            his_tipo_abm = abm,
            his_nom_tabla = tabla,
            his_nom_pk = nom_pk,
            his_valor_pk = val_pk,
            his_campos = campos,
            his_usuario_creacion = Convert.ToInt32(Session["per_id"])
        };
        historico.Adicionar();
    }

    protected void txt_ci_TextChanged(object sender, EventArgs e)
    {
        if (txt_ci.Text != "")
        {
            precontratado = new cls_pc_precontratado();
            precontratado.pre_ci = txt_ci.Text;
            precontratado.param = " TOP 1 ";

            var detalle_funcionario = precontratado.BuscarFuncionario();
            if (detalle_funcionario.Tables.Count > 0)
            {
                if (detalle_funcionario.Tables[0].Rows.Count > 0)
                {
                    llenarDatosFuncionario(detalle_funcionario.Tables[0].Rows[0]);
                    //txt_pre_fecha_asig.Focus();
                }
                else
                {
                    txt_pre_paterno.Focus();
                }
            }
        }

        SetScript("");
    }

    protected void btn_cancelar_persona_Click(object sender, EventArgs e)
    {
        limpiarDatosFun();
        sc = "$('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    private void listarAFP()
    {
        _catalogo = new cls_catalogo { cat_tabla = "previsora" };
        ddl_afp.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_afp.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_afp.DataValueField = "cat_abreviacion";
        ddl_afp.DataTextField = "cat_descripcion";
        ddl_afp.DataBind();
    }
    private void listarGenero()
    {
        _catalogo = new cls_catalogo { cat_tabla = "genero" };
        ddl_pre_genero.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_pre_genero.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_pre_genero.DataValueField = "cat_abreviacion";
        ddl_pre_genero.DataTextField = "cat_descripcion";
        ddl_pre_genero.DataBind();
    }

    protected void gv_persona_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string per_id = gv_persona.DataKeys[index].Values[0].ToString();
        hf_pre_per_id.Value = per_id;

        if (e.CommandName == "GetAssign")
        {
            precontratado = new cls_pc_precontratado { pre_per_id = Convert.ToInt32(per_id), param = " TOP 1 " };
            var detalle_funcionario = precontratado.BuscarFuncionario();
            if (detalle_funcionario.Tables.Count > 0)
            {
                if (detalle_funcionario.Tables[0].Rows.Count > 0)
                {
                    llenarDatosFuncionario(detalle_funcionario.Tables[0].Rows[0]);
                }
            }
        }
        SetScript("");
    }

    protected void gv_persona_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_persona.Rows.Count > 0)
        {
            if (gv_persona.HeaderRow != null)
            {
                gv_persona.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_persona.FooterRow != null)
            {
                gv_persona.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void txt_pre_paterno_TextChanged(object sender, EventArgs e)
    {

        precontratado = new cls_pc_precontratado
        {
            pre_ci = null,
            pre_paterno = (txt_pre_paterno.Text.Trim() != "") ? txt_pre_paterno.Text.Trim() : null,
            pre_materno = (txt_pre_materno.Text.Trim() != "") ? txt_pre_materno.Text.Trim() : null,
            pre_nombres = (txt_pre_nombres.Text.Trim() != "") ? txt_pre_nombres.Text.Trim() : null,
            pre_per_id = 0,
            param = " "
        };

        var funcionarios = (txt_pre_paterno.Text.Trim() != "" && txt_pre_materno.Text.Trim() != "" && txt_pre_nombres.Text.Length >= 3) ? precontratado.BuscarFuncionario() : null;

        gv_persona.DataSource = funcionarios;
        gv_persona.DataBind();

        sc = (ddl_pre_genero.SelectedValue.Trim() == "F") ? "" : "";
        SetScript(sc);
        TextBox txtX = sender as TextBox;
        switch (txtX.ID)
        {
            case "txt_pre_paterno":
                txt_pre_materno.Focus();
                break;
            case "txt_pre_materno":
                txt_pre_nombres.Focus();
                break;
            case "txt_pre_nombres":
                txt_pre_ap_casada.Focus();
                break;
        }
    }
    private void llenarDatosFuncionario(DataRow detalle_funcionario)
    {
        var funcionarioX = detalle_funcionario;
        hf_pre_per_id.Value = validarCampo(funcionarioX["per_id"]);
        txt_pre_paterno.Text = validarCampo(funcionarioX["per_ap_paterno"]);
        txt_pre_materno.Text = validarCampo(funcionarioX["per_ap_materno"]);
        txt_pre_nombres.Text = validarCampo(funcionarioX["per_nombres"]);
        txt_pre_ap_casada.Text = validarCampo(funcionarioX["per_ap_casada"]);
        txt_ci.Text = validarCampo(funcionarioX["per_num_doc"]);
        //ddl_afp.SelectedValue = validarCampo(funcionarioX["afp_previsora"]);
        var afp_x = ddl_afp.Items.FindByValue(validarCampo(funcionarioX["afp_previsora"]));
        ddl_afp.SelectedValue = (afp_x != null) ? afp_x.Value : "0";

        ddl_pre_genero.SelectedValue = validarCampo(funcionarioX["per_sexo"]);
        string fp_foto = (funcionarioX["fp_foto"] != DBNull.Value && funcionarioX["fp_foto"].ToString().Trim() != "") ? funcionarioX["fp_foto"].ToString().Trim() : "";
        string sexo_int = (funcionarioX["per_sexo"] != DBNull.Value && funcionarioX["per_sexo"].ToString().Trim() != "") ? funcionarioX["per_sexo"].ToString().Trim() : "";

        if (fp_foto != "")
        {
            imgFun_int.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])funcionarioX["fp_foto"]);
        }
        else
        {
            if (sexo_int == "")
            {
                imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
            }
            else
            {
                if (sexo_int == "M")
                {
                    imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
                }
                else
                {
                    imgFun_int.ImageUrl = "../Content/img/theme/user4.jpg";
                }
            }

        }

        txt_pre_paterno.Enabled = false;
        txt_pre_materno.Enabled = false;
        txt_pre_nombres.Enabled = false;
        txt_pre_ap_casada.Enabled = false;
        txt_ci.Enabled = false;
        ddl_afp.Enabled = false;
        ddl_pre_genero.Enabled = false;

        gv_persona.DataSource = null;
        gv_persona.DataBind();
    }

    protected void btn_limpiar_Click(object sender, EventArgs e)
    {
        limpiarDatosFun();
        SetScript("");
    }
    private void limpiarDatosFun()
    {
        txt_ci.Text = string.Empty;
        txt_pre_paterno.Text = string.Empty;
        txt_pre_materno.Text = string.Empty;
        txt_pre_nombres.Text = string.Empty;
        txt_pre_ap_casada.Text = string.Empty;
        ddl_pre_genero.SelectedValue = "0";
        ddl_afp.SelectedValue = "0";
        chk_pre_djbr.Checked = false;
        txt_pre_fecha_asig.Text = string.Empty;
        txt_pre_fecha_baja.Text = string.Empty;
        ltl_pre_tiempo_calculo.Text = string.Empty;

        txt_ci.Enabled = true;
        txt_pre_paterno.Enabled = true;
        txt_pre_materno.Enabled = true;
        txt_pre_nombres.Enabled = true;
        txt_pre_ap_casada.Enabled = true;
        ddl_pre_genero.Enabled = true;
        ddl_afp.Enabled = true;
        txt_pre_fecha_asig.Enabled = true;
        txt_pre_fecha_baja.Enabled = true;

        if (ddl_tipo_item.SelectedValue == "")
        {
            txt_pre_numero_item.Text = string.Empty;
            txt_pre_numero_item.Enabled = true;
        }
        imgFun_int.ImageUrl = "../Content/img/theme/user3.jpg";
        hf_pre_per_id.Value = "";


        txt_fecha_djbr.Text = "";
        txt_fecha_sipasse.Text = "";
    }

    protected void btn_adicionar_funcionario_Click(object sender, EventArgs e)
    {
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pl_ue = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;

        if (txt_pre_paterno.Text.Trim() == "" && txt_pre_materno.Text.Trim() == "")
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, debe ingresar al menos un apellido.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
            return;
        }

        int pre_id = Convert.ToInt32(hf_pre_id.Value);
        string pre_contrato = "";
        string pre_estado_x = "";
        switch (ltl_pl_estado.Text)
        {
            case "CREADO":
                pre_estado_x = "N";
                break;
            case "ENVIADO":
                pre_estado_x = "E";
                break;
            case "APROBADO":
                pre_estado_x = "P";
                break;
            case "VALIDADO":
                pre_estado_x = "V";
                break;
            case "AJUSTAR":
                pre_estado_x = "A";
                break;
            case "VALIDADO POR RRHH":
                pre_estado_x = "VR";
                break;
            default:
                break;
        }
        if (d_tipo_item.Visible)
        {
            if (validarFechasDoc() == "")
            {
                if (hf_pre_editar.Value != "1")
                {
                    if (gestionCorrecto())
                    {
                        if (fechaCorrecto())
                        {
                            if (saldoCorrecto())
                            {
                                int per_id = (hf_pre_per_id.Value.Trim() != "") ? Convert.ToInt32(hf_pre_per_id.Value) : 0;
                                if (per_id != 0)
                                {
                                    pre_contrato = sinPreContratoCorrecto();
                                    if (pre_contrato != "")
                                    {
                                        if (contratoVigenteCorrecto())
                                        {
                                            if (fechasFrecuenciaCorrecto())
                                            {
                                                asignarFuncionario(pre_id, per_id, pre_estado_x);
                                                listarPlanilla(pl_id);
                                                limpiarDatosFun();
                                                sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                                SetScript(sc);
                                            }
                                            else
                                            {
                                                sc = obtenerErroreFrecuencia();
                                                SetScript(sc);
                                            }
                                        }
                                        else
                                        {
                                            sc = "$.notify({ icon: 'fa fa-exclamation', message: '" + pre_contrato + "'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                                            SetScript(sc);
                                        }
                                    }
                                    else
                                    {
                                        if (fechasFrecuenciaCorrecto())
                                        {
                                            asignarFuncionario(pre_id, per_id, pre_estado_x);
                                            listarPlanilla(pl_id);
                                            limpiarDatosFun();
                                            sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                            SetScript(sc);
                                        }
                                        else
                                        {
                                            sc = obtenerErroreFrecuencia();
                                            SetScript(sc);
                                        }
                                    }
                                }
                                else
                                {
                                    pre_contrato = sinPreContratoCorrecto();
                                    if (pre_contrato == "")
                                    {
                                        if (fechasFrecuenciaCorrecto())
                                        {
                                            precontratado = new cls_pc_precontratado
                                            {
                                                pl_ue = pl_ue,
                                                pl_pr_id = pr_id + "",
                                                ti_item = ddl_tipo_item.SelectedValue,

                                                pre_id = pre_id,
                                                pre_fecha_inicio = txt_pre_fecha_asig.Text,
                                                pre_fecha_fin = txt_pre_fecha_baja.Text,
                                                pre_tiempo = (ltl_pre_tiempo_calculo.Text != "") ? Convert.ToDecimal(ltl_pre_tiempo_calculo.Text) : 0,
                                                pre_presenta_djbr = (chk_pre_djbr.Checked) ? 1 : 0,
                                                pre_numero_item = (txt_pre_numero_item.Text != "") ? Convert.ToInt32(txt_pre_numero_item.Text) : 0,
                                                pre_estado = pre_estado_x,
                                                tmp_ci = txt_ci.Text,
                                                tmp_ap_paterno = txt_pre_paterno.Text.ToUpper().Trim(),
                                                tmp_ap_materno = txt_pre_materno.Text.ToUpper().Trim(),
                                                tmp_nombres = txt_pre_nombres.Text.ToUpper().Trim(),
                                                tmp_ap_casada = txt_pre_ap_casada.Text.ToUpper().Trim(),
                                                tmp_sexo = ddl_pre_genero.SelectedValue,
                                                tmp_afp = ddl_afp.SelectedValue,
                                                tmp_estado = "V",
                                                pre_fecha_sipasse = (txt_fecha_sipasse.Text != "" ) ? txt_fecha_sipasse.Text : null,
                                                pre_fecha_djbr = (chk_pre_djbr.Checked) ? txt_fecha_djbr.Text : null
                                            };
                                            var detallePrecontratado = precontratado.AsignarPersonaNueva();
                                            string json = JsonConvert.SerializeObject(detallePrecontratado.Tables[0]);
                                            AdicionarHistorico("M", "tbl_pc_precontratado", "pre_id", Convert.ToString(pre_id), json);

                                            listarPlanilla(pl_id);
                                            limpiarDatosFun();
                                            sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                            SetScript(sc);
                                        }
                                        else
                                        {
                                            sc = obtenerErroreFrecuencia();
                                            SetScript(sc);
                                        }
                                    }
                                    else
                                    {
                                        sc = "$.notify({ icon: 'fa fa-exclamation', message: '" + pre_contrato + "'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                                        SetScript(sc);
                                    }
                                }
                            }
                            else
                            {
                                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, el tiempo requerido es mayor al disponible.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                                SetScript(sc);
                            }

                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'La fecha de asignación  debe ser menor a la fecha de baja.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                            SetScript(sc);
                        }
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Las fechas deben ser del mismo periodo seleccionado.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                        SetScript(sc);
                    }
                }
                else
                {
                    if (gestionCorrecto())
                    {
                        if (fechaCorrecto())
                        {
                            if (saldoCorrecto())
                            {
                                int per_id = (hf_pre_per_id.Value.Trim() != "") ? Convert.ToInt32(hf_pre_per_id.Value) : 0;
                                if (per_id != 0)
                                {
                                    pre_contrato = sinPreContratoCorrecto();
                                    if (pre_contrato != "")
                                    {
                                        if (contratoVigenteCorrecto())
                                        {
                                            if (fechasFrecuenciaCorrecto())
                                            {
                                                asignarFuncionario(pre_id, per_id, pre_estado_x);
                                                listarPlanilla(pl_id);
                                                limpiarDatosFun();
                                                sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                                SetScript(sc);
                                            }
                                            else
                                            {
                                                sc = obtenerErroreFrecuencia();
                                                SetScript(sc);
                                            }
                                        }
                                        else
                                        {
                                            sc = "$.notify({ icon: 'fa fa-exclamation', message: '" + pre_contrato + "'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                                            SetScript(sc);
                                        }
                                    }
                                    else
                                    {
                                        if (fechasFrecuenciaCorrecto())
                                        {
                                            asignarFuncionario(pre_id, per_id, pre_estado_x);
                                            listarPlanilla(pl_id);
                                            limpiarDatosFun();
                                            sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                            SetScript(sc);
                                        }
                                        else
                                        {
                                            sc = obtenerErroreFrecuencia();
                                            SetScript(sc);
                                        }
                                    }
                                }
                                else
                                {
                                    pre_contrato = sinPreContratoCorrecto();
                                    if (pre_contrato == "")
                                    {
                                        if (fechasFrecuenciaCorrecto())
                                        {
                                            precontratado = new cls_pc_precontratado
                                            {
                                                pl_ue = pl_ue,
                                                pl_pr_id = pr_id + "",
                                                ti_item = ddl_tipo_item.SelectedValue,

                                                pre_id = pre_id,
                                                pre_fecha_inicio = txt_pre_fecha_asig.Text,
                                                pre_fecha_fin = txt_pre_fecha_baja.Text,
                                                pre_tiempo = (ltl_pre_tiempo_calculo.Text != "") ? Convert.ToDecimal(ltl_pre_tiempo_calculo.Text) : 0,
                                                pre_presenta_djbr = (chk_pre_djbr.Checked) ? 1 : 0,
                                                pre_numero_item = (txt_pre_numero_item.Text != "") ? Convert.ToInt32(txt_pre_numero_item.Text) : 0,
                                                pre_estado = pre_estado_x,
                                                tmp_id = (hf_tmp_id.Value != "") ? Convert.ToInt32(hf_tmp_id.Value) : 0,
                                                tmp_ci = txt_ci.Text,
                                                tmp_ap_paterno = txt_pre_paterno.Text.ToUpper().Trim(),
                                                tmp_ap_materno = txt_pre_materno.Text.ToUpper().Trim(),
                                                tmp_nombres = txt_pre_nombres.Text.ToUpper().Trim(),
                                                tmp_ap_casada = txt_pre_ap_casada.Text.ToUpper().Trim(),
                                                tmp_sexo = ddl_pre_genero.SelectedValue,
                                                tmp_afp = ddl_afp.SelectedValue,
                                                tmp_estado = "V",
                                                pre_fecha_sipasse = (txt_fecha_sipasse.Text != "") ? txt_fecha_sipasse.Text : null,
                                                pre_fecha_djbr = (chk_pre_djbr.Checked) ? txt_fecha_djbr.Text : null
                                            };

                                            var detallePrecontratado = (hf_tmp_id.Value != "") ? precontratado.ActualizarPersonaNueva() : precontratado.AsignarPersonaNueva();
                                            string json = JsonConvert.SerializeObject(detallePrecontratado.Tables[0]);
                                            AdicionarHistorico("M", "tbl_pc_precontratado", "pre_id", Convert.ToString(pre_id), json);

                                            listarPlanilla(pl_id);
                                            limpiarDatosFun();
                                            sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                            SetScript(sc);
                                        }
                                        else
                                        {
                                            sc = obtenerErroreFrecuencia();
                                            SetScript(sc);
                                        }
                                    }
                                    else
                                    {
                                        sc = "$.notify({ icon: 'fa fa-exclamation', message: '" + pre_contrato + "'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                                        SetScript(sc);
                                    }
                                }
                            }
                            else
                            {
                                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, el tiempo requerido es mayor al disponible.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                                SetScript(sc);
                            }

                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'La fecha de asignación  debe ser menor a la fecha de baja.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                            SetScript(sc);
                        }
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Las fechas deben ser del mismo periodo seleccionado.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                        SetScript(sc);
                    }
                }
            } else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: '" + validarFechasDoc() + "'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
            }

        }
        else
        {
            if (hf_pre_editar.Value != "1")
            {
                if (gestionCorrecto())
                {
                    if (fechaCorrecto())
                    {
                        if (saldoCorrecto())
                        {
                            int per_id = (hf_pre_per_id.Value.Trim() != "") ? Convert.ToInt32(hf_pre_per_id.Value) : 0;
                            if (per_id != 0)
                            {
                                pre_contrato = sinPreContratoCorrecto();
                                if (pre_contrato != "")
                                {
                                    if (contratoVigenteCorrecto())
                                    {
                                        if (fechasFrecuenciaCorrecto())
                                        {
                                            asignarFuncionario(pre_id, per_id, pre_estado_x);
                                            listarPlanilla(pl_id);
                                            limpiarDatosFun();
                                            sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                            SetScript(sc);
                                        }
                                        else
                                        {
                                            sc = obtenerErroreFrecuencia();
                                            SetScript(sc);
                                        }
                                    }
                                    else
                                    {
                                        sc = "$.notify({ icon: 'fa fa-exclamation', message: '" + pre_contrato + "'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                                        SetScript(sc);
                                    }
                                }
                                else
                                {
                                    if (fechasFrecuenciaCorrecto())
                                    {
                                        asignarFuncionario(pre_id, per_id, pre_estado_x);
                                        listarPlanilla(pl_id);
                                        limpiarDatosFun();
                                        sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                        SetScript(sc);
                                    }
                                    else
                                    {
                                        sc = obtenerErroreFrecuencia();
                                        SetScript(sc);
                                    }
                                }
                            }
                            else
                            {
                                pre_contrato = sinPreContratoCorrecto();
                                if (pre_contrato == "")
                                {
                                    if (fechasFrecuenciaCorrecto())
                                    {
                                        precontratado = new cls_pc_precontratado
                                        {
                                            pl_ue = pl_ue,
                                            pl_pr_id = pr_id + "",
                                            ti_item = ddl_tipo_item.SelectedValue,

                                            pre_id = pre_id,
                                            pre_fecha_inicio = txt_pre_fecha_asig.Text,
                                            pre_fecha_fin = txt_pre_fecha_baja.Text,
                                            pre_tiempo = (ltl_pre_tiempo_calculo.Text != "") ? Convert.ToDecimal(ltl_pre_tiempo_calculo.Text) : 0,
                                            pre_presenta_djbr = (chk_pre_djbr.Checked) ? 1 : 0,
                                            pre_numero_item = (txt_pre_numero_item.Text != "") ? Convert.ToInt32(txt_pre_numero_item.Text) : 0,
                                            pre_estado = pre_estado_x,
                                            tmp_ci = txt_ci.Text,
                                            tmp_ap_paterno = txt_pre_paterno.Text.ToUpper().Trim(),
                                            tmp_ap_materno = txt_pre_materno.Text.ToUpper().Trim(),
                                            tmp_nombres = txt_pre_nombres.Text.ToUpper().Trim(),
                                            tmp_ap_casada = txt_pre_ap_casada.Text.ToUpper().Trim(),
                                            tmp_sexo = ddl_pre_genero.SelectedValue,
                                            tmp_afp = ddl_afp.SelectedValue,
                                            tmp_estado = "V"
                                        };
                                        var detallePrecontratado = precontratado.AsignarPersonaNueva();
                                        string json = JsonConvert.SerializeObject(detallePrecontratado.Tables[0]);
                                        AdicionarHistorico("M", "tbl_pc_precontratado", "pre_id", Convert.ToString(pre_id), json);

                                        listarPlanilla(pl_id);
                                        limpiarDatosFun();
                                        sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                        SetScript(sc);
                                    }
                                    else
                                    {
                                        sc = obtenerErroreFrecuencia();
                                        SetScript(sc);
                                    }
                                }
                                else
                                {
                                    sc = "$.notify({ icon: 'fa fa-exclamation', message: '" + pre_contrato + "'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                                    SetScript(sc);
                                }
                            }
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, el tiempo requerido es mayor al disponible.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                            SetScript(sc);
                        }

                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-exclamation', message: 'La fecha de asignación  debe ser menor a la fecha de baja.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                        SetScript(sc);
                    }
                }
                else
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Las fechas deben ser del mismo periodo seleccionado.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                    SetScript(sc);
                }
            }
            else
            {
                if (gestionCorrecto())
                {
                    if (fechaCorrecto())
                    {
                        if (saldoCorrecto())
                        {
                            int per_id = (hf_pre_per_id.Value.Trim() != "") ? Convert.ToInt32(hf_pre_per_id.Value) : 0;
                            if (per_id != 0)
                            {
                                pre_contrato = sinPreContratoCorrecto();
                                if (pre_contrato != "")
                                {
                                    if (contratoVigenteCorrecto())
                                    {
                                        if (fechasFrecuenciaCorrecto())
                                        {
                                            asignarFuncionario(pre_id, per_id, pre_estado_x);
                                            listarPlanilla(pl_id);
                                            limpiarDatosFun();
                                            sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                            SetScript(sc);
                                        }
                                        else
                                        {
                                            sc = obtenerErroreFrecuencia();
                                            SetScript(sc);
                                        }
                                    }
                                    else
                                    {
                                        sc = "$.notify({ icon: 'fa fa-exclamation', message: '" + pre_contrato + "'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                                        SetScript(sc);
                                    }
                                }
                                else
                                {
                                    if (fechasFrecuenciaCorrecto())
                                    {
                                        asignarFuncionario(pre_id, per_id, pre_estado_x);
                                        listarPlanilla(pl_id);
                                        limpiarDatosFun();
                                        sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                        SetScript(sc);
                                    }
                                    else
                                    {
                                        sc = obtenerErroreFrecuencia();
                                        SetScript(sc);
                                    }
                                }
                            }
                            else
                            {
                                pre_contrato = sinPreContratoCorrecto();
                                if (pre_contrato == "")
                                {
                                    if (fechasFrecuenciaCorrecto())
                                    {
                                        precontratado = new cls_pc_precontratado
                                        {
                                            pl_ue = pl_ue,
                                            pl_pr_id = pr_id + "",
                                            ti_item = ddl_tipo_item.SelectedValue,

                                            pre_id = pre_id,
                                            pre_fecha_inicio = txt_pre_fecha_asig.Text,
                                            pre_fecha_fin = txt_pre_fecha_baja.Text,
                                            pre_tiempo = (ltl_pre_tiempo_calculo.Text != "") ? Convert.ToDecimal(ltl_pre_tiempo_calculo.Text) : 0,
                                            pre_presenta_djbr = (chk_pre_djbr.Checked) ? 1 : 0,
                                            pre_numero_item = (txt_pre_numero_item.Text != "") ? Convert.ToInt32(txt_pre_numero_item.Text) : 0,
                                            pre_estado = pre_estado_x,
                                            tmp_id = (hf_tmp_id.Value != "") ? Convert.ToInt32(hf_tmp_id.Value) : 0,
                                            tmp_ci = txt_ci.Text,
                                            tmp_ap_paterno = txt_pre_paterno.Text.ToUpper().Trim(),
                                            tmp_ap_materno = txt_pre_materno.Text.ToUpper().Trim(),
                                            tmp_nombres = txt_pre_nombres.Text.ToUpper().Trim(),
                                            tmp_ap_casada = txt_pre_ap_casada.Text.ToUpper().Trim(),
                                            tmp_sexo = ddl_pre_genero.SelectedValue,
                                            tmp_afp = ddl_afp.SelectedValue,
                                            tmp_estado = "V"
                                        };

                                        var detallePrecontratado = (hf_tmp_id.Value != "") ? precontratado.ActualizarPersonaNueva() : precontratado.AsignarPersonaNueva();
                                        string json = JsonConvert.SerializeObject(detallePrecontratado.Tables[0]);
                                        AdicionarHistorico("M", "tbl_pc_precontratado", "pre_id", Convert.ToString(pre_id), json);

                                        listarPlanilla(pl_id);
                                        limpiarDatosFun();
                                        sc = "Swal.fire({ icon: 'success', title: 'Asignación exitosa.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                                        SetScript(sc);
                                    }
                                    else
                                    {
                                        sc = obtenerErroreFrecuencia();
                                        SetScript(sc);
                                    }
                                }
                                else
                                {
                                    sc = "$.notify({ icon: 'fa fa-exclamation', message: '" + pre_contrato + "'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                                    SetScript(sc);
                                }
                            }
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, el tiempo requerido es mayor al disponible.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                            SetScript(sc);
                        }

                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-exclamation', message: 'La fecha de asignación  debe ser menor a la fecha de baja.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                        SetScript(sc);
                    }
                }
                else
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Las fechas deben ser del mismo periodo seleccionado.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                    SetScript(sc);
                }
            }
        }

    }
    private string validarFechasDoc()
    {
        string mje = "";
        DateTime djbrDate;
        DateTime sipasseDate;

        if (chk_pre_djbr.Checked)
        {
            if ((DateTime.TryParse(txt_fecha_djbr.Text, out djbrDate)) && (DateTime.TryParse(txt_fecha_sipasse.Text, out sipasseDate)))
            {
                djbrDate = Convert.ToDateTime(txt_fecha_djbr.Text);
                sipasseDate = Convert.ToDateTime(txt_fecha_sipasse.Text);
                DateTime startDate = Convert.ToDateTime(txt_pre_fecha_asig.Text);

                if (djbrDate > startDate && sipasseDate > startDate)
                {
                    mje = "";
                }
                else
                {
                    mje = "Las fechas no son válidas, por favor actualice los documentos.";
                }
            } 
            else
            {
                mje = "Las fechas no son válidas, por favor actualice los documentos.";
            }
        }
        else
        {
            if (DateTime.TryParse(txt_fecha_sipasse.Text, out sipasseDate))
            {
                sipasseDate = Convert.ToDateTime(txt_fecha_sipasse.Text);
                DateTime startDate = Convert.ToDateTime(txt_pre_fecha_asig.Text);

                if (sipasseDate > startDate)
                {
                    mje = "";
                }
                else
                {
                    mje = "Las fecha del SIPASSE no es válida, por favor actualice el documento.";
                }
            }
            else
            {
                mje = "Por favor registre la fecha de validez de SIPASSE.";
            }
        }

        return mje;
    }
    private string obtenerErroreFrecuencia()
    {
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;

        string msj = "";
        string last_fecha_inicio = "";
        string last_fecha_fin = "";
        precontratado = new cls_pc_precontratado { pl_pr_id = pr_id + "", pre_fr_id = Convert.ToInt32(hf_pre_fr_id.Value), pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_contrato = (hf_pre_editar.Value != "1") ? precontratado.ObtenerUltimaFrec() : precontratado.ObtenerUltimaFrecEditar();
        if (detalle_contrato.Tables[0].Rows.Count > 0)
        {
            last_fecha_inicio = validarCampo(detalle_contrato.Tables[0].Rows[0]["pre_fecha_inicio"]);
            last_fecha_fin = validarCampo(detalle_contrato.Tables[0].Rows[0]["pre_fecha_fin"]);
        }

        msj = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, la frecuencia ya fue usada en el intervalo de tiempo requerido (" + last_fecha_inicio + " " + last_fecha_fin + ")'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
        return msj;
    }

    private void asignarFuncionario(int pre_id = 0, int per_id = 0, string pre_estado_x = "")
    {
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        precontratado = new cls_pc_precontratado
        {
            pl_pr_id = pr_id + "",
            pre_id = pre_id,
            pre_per_id = per_id,
            pre_fecha_inicio = txt_pre_fecha_asig.Text,
            pre_fecha_fin = txt_pre_fecha_baja.Text,
            pre_tiempo = (ltl_pre_tiempo_calculo.Text != "") ? Convert.ToDecimal(ltl_pre_tiempo_calculo.Text) : 0,
            pre_presenta_djbr = (chk_pre_djbr.Checked) ? 1 : 0,
            pre_numero_item = (txt_pre_numero_item.Text != "") ? Convert.ToInt32(txt_pre_numero_item.Text) : 0,
            pre_estado = pre_estado_x,
            pre_fecha_sipasse = (txt_fecha_sipasse.Text != "") ? txt_fecha_sipasse.Text : null,
            pre_fecha_djbr = (chk_pre_djbr.Checked) ? (txt_fecha_djbr.Text != "") ? txt_fecha_djbr.Text : null : null
        };
        var detallePrecontratado = (hf_pre_editar.Value != "1") ? precontratado.AsignarPersona() : precontratado.ModificarPersona();
        string json = JsonConvert.SerializeObject(detallePrecontratado.Tables[0]);
        AdicionarHistorico("M", "tbl_pc_precontratado", "pre_id", Convert.ToString(pre_id), json);
    }
    private bool gestionCorrecto()
    {
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        bool sw = false;

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

        DateTime fecha_inicio = Convert.ToDateTime(txt_pre_fecha_asig.Text);
        DateTime fecha_fin = Convert.ToDateTime(txt_pre_fecha_baja.Text);

        if (fecha_inicio.Year.ToString() == gestion_x && fecha_fin.Year.ToString() == gestion_x)
        {
            sw = true;
        }

        return sw;
    }
    private bool fechaCorrecto()
    {
        bool sw = false;
        DateTime startDate = Convert.ToDateTime(txt_pre_fecha_asig.Text);
        DateTime endDate = Convert.ToDateTime(txt_pre_fecha_baja.Text);
        double diferencia = (endDate - startDate).TotalDays + 1;

        if (diferencia >= 1)
        {
            sw = true;
        }

        return sw;
    }
    private bool contratoVigenteCorrecto()
    {
        bool sw = false;
        int per_id = Convert.ToInt32(hf_pre_per_id.Value);
        precontratado = new cls_pc_precontratado { pre_per_id = per_id, pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_contrato = (hf_pre_editar.Value != "1") ? precontratado.ObtenerContrato() : precontratado.ObtenerContratoEditar();
        if (detalle_contrato.Tables.Count > 0)
        {
            if (detalle_contrato.Tables[0].Rows.Count > 0)
            {
                var contrato = detalle_contrato.Tables[0].Rows[0];
                string fecha_fin = validarCampo(contrato["pre_fecha_fin"]);


                //string dato = "27/04/2019";
                //DateTime startDate = Convert.ToDateTime(dato);
                DateTime startDate = DateTime.Today;
                DateTime endDate = Convert.ToDateTime(fecha_fin);
                double diferencia = (endDate - startDate).TotalDays + 1;

                if (diferencia <= 15)
                {
                    sw = true;
                }
            }
        }

        return sw;
    }
    private bool fechasFrecuenciaCorrecto()
    {
        bool sw = false;
        string pr_id = (Request.QueryString["id3"] != null) ? Request.QueryString["id3"].ToString() : "";

        DateTime startDate = Convert.ToDateTime(txt_pre_fecha_asig.Text);
        DateTime endDate = Convert.ToDateTime(txt_pre_fecha_baja.Text);

        DateTime frecStartDate = Convert.ToDateTime(ltl_fr_tiempo_inicio.Text);
        DateTime frecEndDate = Convert.ToDateTime(ltl_fr_tiempo_fin.Text);

        precontratado = new cls_pc_precontratado { pl_pr_id = pr_id, pre_fr_id = Convert.ToInt32(hf_pre_fr_id.Value), pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_contrato = (hf_pre_editar.Value != "1") ? precontratado.ObtenerUltimaFrec() : precontratado.ObtenerUltimaFrecEditar();
        if (detalle_contrato.Tables.Count > 0)
        {
            if (detalle_contrato.Tables[0].Rows.Count > 0)
            {
                var contrato = detalle_contrato.Tables[0].Rows[0];
                string last_fecha_inicio = validarCampo(contrato["pre_fecha_inicio"]);
                string last_fecha_fin = validarCampo(contrato["pre_fecha_fin"]);
                DateTime lastStartDate = Convert.ToDateTime(last_fecha_inicio);
                DateTime lastEndDate = Convert.ToDateTime(last_fecha_fin);

                if (startDate > lastEndDate)
                {
                    sw = true;
                }
            }
            else
            {

                sw = true;
            }
        }

        return sw;
    }

    private string sinPreContratoCorrecto()
    {
        string resp = "";
        string pr_id = (Request.QueryString["id3"] != null) ? Request.QueryString["id3"].ToString() : "";
        precontratado = new cls_pc_precontratado { pl_pr_id = pr_id, pre_ci = txt_ci.Text, pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_pre_contrato = (hf_pre_editar.Value != "1") ? precontratado.ObtenerPrecontrato() : precontratado.ObtenerPrecontratoEditar();
        if (detalle_pre_contrato.Tables.Count > 0)
        {
            if (detalle_pre_contrato.Tables[0].Rows.Count > 0)
            {
                var pre_contrato = detalle_pre_contrato.Tables[0].Rows[0];
                resp = "No se puede realizar la acción, el CI " + validarCampo(pre_contrato["ci"]) + " está registrado en la UE: " + validarCampo(pre_contrato["cp_descripcion"]) + " " +
                    validarCampo(pre_contrato["cp_da"]) + " - " + validarCampo(pre_contrato["cp_ue"]) + " - " + validarCampo(pre_contrato["cp_programa"]) + " - " + validarCampo(pre_contrato["cp_proyecto"]) + " - " +
                    validarCampo(pre_contrato["cp_actividad"]) + " ( " + validarCampo(pre_contrato["cp_fuente"]) + " - " + validarCampo(pre_contrato["cp_organismo"]) + ")";
            }
        }
        return resp;
    }
    private bool saldoCorrecto()
    {
        bool sw = false;
        double tiempoRequerido = Convert.ToDouble(calcularTiempoMeses());
        double tiempoDisponible = Convert.ToDouble(ltl_tiempo_libre.Text);

        if ((tiempoDisponible - tiempoRequerido) >= 0)
        {
            sw = true;
        }

        return sw;
    }

    protected string calcularTiempoMeses()
    {
        string tiempo = "";
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_fecha_inicio = txt_pre_fecha_asig.Text;
        frecuencia.fr_fecha_fin = txt_pre_fecha_baja.Text;

        var detalleTiempoMes = frecuencia.ObtenerTiempoMeses();
        if (detalleTiempoMes.Tables.Count > 0)
        {
            if (detalleTiempoMes.Tables[0].Rows.Count > 0)
            {
                var tiempoMes = detalleTiempoMes.Tables[0].Rows[0];
                tiempo = validarCampo(tiempoMes["meses"]);
            }
        }
        return tiempo;
    }
    protected void txt_pre_fecha_asig_TextChanged(object sender, EventArgs e)
    {
        DateTime startDate;
        DateTime endDate;

        if ((DateTime.TryParse(txt_pre_fecha_asig.Text, out startDate)) && (DateTime.TryParse(txt_pre_fecha_baja.Text, out endDate)))
        {
            startDate = Convert.ToDateTime(txt_pre_fecha_asig.Text);
            endDate = Convert.ToDateTime(txt_pre_fecha_baja.Text);
            double diferencia = (endDate - startDate).TotalDays;
            if (diferencia >= 0)
            {
                ltl_pre_tiempo_calculo.Text = calcularTiempoMeses();
            }
            else
            {
                ltl_pre_tiempo_calculo.Text = "";
            }
        }

        SetScript("");
        txt_pre_fecha_baja.Focus();
    }
    protected void txt_pre_fecha_baja_TextChanged(object sender, EventArgs e)
    {
        if (txt_pre_fecha_asig.Text != null && txt_pre_fecha_asig.Text != "" && txt_pre_fecha_baja.Text != null && txt_pre_fecha_baja.Text != "")
        {
            DateTime startDate = Convert.ToDateTime(txt_pre_fecha_asig.Text);
            DateTime endDate = Convert.ToDateTime(txt_pre_fecha_baja.Text);
            double diferencia = (endDate - startDate).TotalDays;
            if (diferencia >= 0)
            {
                ltl_pre_tiempo_calculo.Text = calcularTiempoMeses();
            }
            else
            {
                ltl_pre_tiempo_calculo.Text = "";
            }
        }
        SetScript("");
        txt_pre_numero_item.Focus();
    }

    protected void btn_enviar_planilla_Click(object sender, EventArgs e)
    {
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        int pl_ue = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;

        if (validarEnvio())
        {
            //planilla = new cls_pc_precontratado { pre_pl_id = pl_id };
            //var detalle_estados = planilla.ObtenerEstadoPlanilla();
            //bool sw = false;
            //if (detalle_estados.Tables[0].Rows.Count > 0)
            //{
            //    var estadosP = detalle_estados.Tables[0].Rows;
            //    for (int i = 0; i < estadosP.Count; i++)
            //    {
            //        if (validarCampo(estadosP[i]["seg_accion"]) == "APROBADO")
            //        {
            //            sw = true;
            //            break;
            //        }
            //    }
            //}
            //if (sw)
            //{
            //    sc = "$('#modalConfirmacionV').modal('show');";
            //    SetScript(sc);
            //} else
            //{
            precontratado = new cls_pc_precontratado { pl_ue = pl_ue, pl_pr_id = Convert.ToString(pr_id), us_id = us_id };
            var detalle_usuarios = precontratado.ListarUsuarios();
            ddl_usuarios.Items.Clear();
            ddl_usuarios.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_usuarios.DataValueField = "usuario";
            ddl_usuarios.DataTextField = "nombre_fun";
            ddl_usuarios.DataSource = detalle_usuarios;
            ddl_usuarios.DataBind();

            sc = (detalle_usuarios.Tables[0].Rows.Count > 0) ? "$('#modalEnviar').modal('show');" : "$.notify({ icon: 'fa fa-info-circle', message: 'No se puede realizar la acción.'},{ type: 'info', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
            //}
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info-circle', message: 'No se puede enviar la planilla.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }

    private bool validarEnvio()
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        precontratado = new cls_pc_precontratado { pre_pl_id = pl_id };
        var detalle_pre_contrato = precontratado.ListarPrecontratos();

        bool sw = true;
        string acefalo = "";
        if (detalle_pre_contrato.Tables.Count > 0)
        {
            if (detalle_pre_contrato.Tables[0].Rows.Count > 0)
            {
                var pre_contrato = detalle_pre_contrato.Tables[0].Rows;
                foreach (DataRow row in pre_contrato)
                {
                    acefalo = validarCampo(row["acefalo"]);
                    if (acefalo == "1")
                    {
                        sw = false;
                        break;
                    }
                }
            }
            else
            {
                sw = false;
            }
        }
        return sw;
    }

    protected void btn_cancelar_envio_Click(object sender, EventArgs e)
    {
        sc = "$('#modalEnviar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }


    protected void btn_anular_asig_Click(object sender, EventArgs e)
    {
        int per_id = 0;
        int pre_id = Convert.ToInt32(hf_pre_id.Value);
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_precontrato = precontratado.DetallePrecontrato();
        if (detalle_precontrato.Tables.Count > 0)
        {
            if (detalle_precontrato.Tables[0].Rows.Count > 0)
            {
                var funcionarioX = detalle_precontrato.Tables[0].Rows[0];
                per_id = Convert.ToInt32(validarCampo(funcionarioX["per_id"]));
            }
        }

        string pre_estado_x = "";
        switch (ltl_pl_estado.Text)
        {
            case "CREADO":
                pre_estado_x = "N";
                break;
            case "ENVIADO":
                pre_estado_x = "E";
                break;
            case "APROBADO":
                pre_estado_x = "P";
                break;
            case "VALIDADO":
                pre_estado_x = "V";
                break;
            case "AJUSTAR":
                pre_estado_x = "A";
                break;
            default:
                break;
        }

        precontratado = new cls_pc_precontratado { pre_id = pre_id, pre_estado = pre_estado_x };
        if (per_id != 0)
        {
            precontratado.EliminarAsignacion();
        }
        else
        {
            precontratado.EliminarAsignacionNuevo();
        }
        listarPlanilla(pl_id);
        sc = "Swal.fire({ icon: 'success', title: 'Asignación anulada correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#anularAsignacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_cancelar_puesto_Click(object sender, EventArgs e)
    {
        sc = "$('#modalModificarPuesto').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_modificar_puesto_Click(object sender, EventArgs e)
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pre_id = Convert.ToInt32(hf_pre_id.Value);
        precontratado = new cls_pc_precontratado
        {
            pre_id = Convert.ToInt32(hf_pre_id.Value),
            pre_pu_id = Convert.ToInt32(ddl_puesto_modificar.SelectedValue),
            pre_obj_puesto = txt_objetivo_modificar.Text,
            pre_tareas = txt_tareas_modificar.Text
        };
        precontratado.ActualizarPuesto();
        listarPlanilla(pl_id);
        sc = "Swal.fire({ icon: 'success', title: 'Puesto actualizado correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalModificarPuesto').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }
    private void listaFiltradoItem(int cp_id = 0)
    {
        try
        {
            frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id };
            var tipo_item = frecuencia.ObtenerListaFiltradoTipoItem();

            ddl_tipo_item.Items.Clear();
            ddl_tipo_item.DataValueField = "ti_item";
            ddl_tipo_item.DataTextField = "ti_descripcion";
            ddl_tipo_item.DataSource = tipo_item;
            ddl_tipo_item.DataBind();
            ddl_tipo_item.Enabled = false;

            if (tipo_item.Tables[0].Rows.Count > 0)
            {
                precontratado = new cls_pc_precontratado
                {
                    pl_ue = Convert.ToInt32(Request.QueryString["id2"].ToString()),
                    pl_pr_id = Request.QueryString["id3"].ToString(),
                    ti_item = validarCampo(tipo_item.Tables[0].Rows[0]["ti_item"])
                };

                var detallePlanilla = precontratado.ObtenerNroItem();
                txt_pre_numero_item.Text = validarCampo(detallePlanilla.Tables[0].Rows[0]["pre_numero_item"]);
                txt_pre_numero_item.Enabled = false;
            }
            d_tipo_item.Visible = (tipo_item.Tables[0].Rows.Count > 0);
            d_tipo_item_1.Visible = (tipo_item.Tables[0].Rows.Count > 0);
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void ddl_gv_planilla_cargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        DropDownList ddl_gv_planilla_paterno = gv_planilla.HeaderRow.FindControl("ddl_gv_planilla_paterno") as DropDownList;
        DropDownList ddl_gv_planilla_cargo = gv_planilla.HeaderRow.FindControl("ddl_gv_planilla_cargo") as DropDownList;

        string pre_paterno = (ddl_gv_planilla_paterno.SelectedValue != "0") ? ddl_gv_planilla_paterno.SelectedValue : "0";
        int fr_es_id = (ddl_gv_planilla_cargo.SelectedValue != "0") ? Convert.ToInt32(ddl_gv_planilla_cargo.SelectedValue) : 0;

        listarPlanilla(pl_id, fr_es_id, pre_paterno);

        DropDownList ddl_gv_planilla_paterno_after = gv_planilla.HeaderRow.FindControl("ddl_gv_planilla_paterno") as DropDownList;
        DropDownList ddl_gv_planilla_cargo_after = gv_planilla.HeaderRow.FindControl("ddl_gv_planilla_cargo") as DropDownList;
        ddl_gv_planilla_paterno_after.SelectedValue = pre_paterno;
        ddl_gv_planilla_cargo_after.SelectedValue = fr_es_id + "";
        SetScript("");
    }

    protected void btn_confirmar_val_Click(object sender, EventArgs e)
    {
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        string pl_id = (Request.QueryString["id"] != null) ? Request.QueryString["id"].ToString() : "";

        planilla = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id) };
        var detalle_estados = planilla.ObtenerEstadoPlanilla();
        if (detalle_estados.Tables[0].Rows.Count > 0)
        {
            var estadosP = detalle_estados.Tables[0].Rows;
            int us_recepcion = 0;
            for (int i = 0; i < estadosP.Count; i++)
            {
                if (validarCampo(estadosP[i]["seg_accion"]) == "APROBADO")
                {
                    us_recepcion = (validarCampo(estadosP[i]["seg_us_id_recepcion"]) != "") ? Convert.ToInt32(validarCampo(estadosP[i]["seg_us_id_recepcion"])) : 0;
                    break;
                }
            }
            if (us_recepcion != 0)
            {
                planilla = new cls_pc_precontratado { pl_id = pl_id, pl_estado = "E" };
                var pl = planilla.ActualizarEstadoPlanilla();
                string json = JsonConvert.SerializeObject(pl.Tables[0]);
                AdicionarHistorico("M", "tbl_pc_planilla", "pl_id", pl_id, json);

                precontratado = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id), pre_estado = "A", pre_estado_x = "E" };
                precontratado.ActualizarEstadoPrecontrato();

                planilla.seg_pk_id = Convert.ToInt32(pl_id);
                planilla.seg_us_id_remitente = us_id;
                planilla.seg_us_id_recepcion = us_recepcion;
                planilla.seg_accion = "ENVIADO";
                planilla.seg_observaciones = null;
                planilla.seg_tabla = "tbl_pc_planilla";
                planilla.AdicionarSeguimiento();

                Session["texto_notificacion"] = "Planilla validada correctamente.";
                Response.Redirect("ListaPlanilla");
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, la planilla no fue aprobada.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }
    protected void btn_confirmar_envio_Click(object sender, EventArgs e)
    {
        int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
        string correo_remitente = (Session["correo"] != null) ? Session["correo"].ToString() : "";
        string usuario_remitente = (Session["per_nombres"] != null) ? Session["per_nombres"].ToString() : "";
        string pl_id = (Request.QueryString["id"] != null) ? Request.QueryString["id"].ToString() : "";

        planilla = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id) };
        var estados = planilla.ObtenerEstadoPlanilla();
        int tam_cat = estados.Tables[0].Rows.Count;
        if (tam_cat > 0)
        {
            if (validarCampo(estados.Tables[0].Rows[tam_cat - 1]["seg_accion"]) == "CREADO" || validarCampo(estados.Tables[0].Rows[0]["seg_accion"]) == "AJUSTAR")
            {
                planilla = new cls_pc_precontratado { pl_id = pl_id, pl_estado = "E" };
                var pl = planilla.ActualizarEstadoPlanilla();
                string json = JsonConvert.SerializeObject(pl.Tables[0]);
                AdicionarHistorico("M", "tbl_pc_planilla", "pl_id", pl_id, json);

                string estado_pre = (ltl_pl_estado.Text.Trim() == "CREADO") ? "N" : (ltl_pl_estado.Text.Trim() == "AJUSTAR") ? "A" : "";
                precontratado = new cls_pc_precontratado { pre_pl_id = Convert.ToInt32(pl_id), pre_estado = estado_pre, pre_estado_x = "E" };
                precontratado.ActualizarEstadoPrecontratoEnvio();

                string usuario = (ddl_usuarios.SelectedValue);
                string[] words = usuario.Split('-');
                string us_id_r = words[0].Trim();
                string correo_recepcion = words[1].Trim();
                string usuario_recepcion = ddl_usuarios.SelectedItem.Text;
                planilla.seg_pk_id = Convert.ToInt32(pl_id);
                planilla.seg_us_id_remitente = us_id;
                planilla.seg_us_id_recepcion = Convert.ToInt32(us_id_r);
                planilla.seg_accion = "ENVIADO";
                planilla.seg_observaciones = null;
                planilla.seg_tabla = "tbl_pc_planilla";
                planilla.AdicionarSeguimiento();

                string verbo = (ltl_pl_estado.Text.Trim() == "CREADO") ? "generó " : (ltl_pl_estado.Text.Trim() == "AJUSTAR") ? "ajustó " : "";
                string contenido = "<p>Se le comunica que se " + verbo + " la <strong>Planilla Nº " + ltl_pl_correlativo.Text + "</strong>, por el usuario <strong>" + usuario_remitente + "</strong> para su revisión y aprobación.</p>";
                enviarCorreo(correo_remitente, correo_recepcion, usuario_remitente, usuario_recepcion, contenido);

                Session["texto_notificacion"] = "Planilla enviada correctamente.";
                Response.Redirect("ListaPlanilla");

            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }
    private void enviarCorreo(string correo_remitente = "", string correo_recepcion = "", string usuario_remitente = "", string usuario_recepcion = "", string contenido = "")
    {
        SetScript("console.log('armandoCorreo');");
        string h = "http://gmlpsr00001/sigrh3/";
        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        correo.From = new System.Net.Mail.MailAddress(correo_remitente);
        correo.To.Add(correo_recepcion);
        correo.Subject = "SOLICITUD DE REVISIÓN Y APROBACIÓN DE LA PLANILLA Nº " + ltl_pl_correlativo.Text;
        string html;

        html = "  <!doctype html><html> <body><div style='font: 20px Calibri, arial; margin-bottom: 30px; border: 0; box-shadow: 0 0 32px 0 rgba(136, 152, 170, .15); '>";
        html += "<div style='margin-bottom: 16px; padding-top: 20px; padding-bottom: 20px; background-color: #fff;' align='right'>";
        html += "<img src='cid:fp_foto' style='width: 70; display: block; margin-left: auto; border-radius: 7% !important;' /> ";
        html += "</div>";
        html += "<div class='card-body' style='min-height: 1px; padding: 24px; flex: 1 1 auto; text-align: justify;' >";
        html += "<div style='padding-bottom: 20px; margin-bottom: 32px' align='center'>";
        html += "<img src='cid:fp_foto2' style='width: 70; display: block; margin-right: auto; margin-left: auto; border-radius: 50% !important;'  /> ";
        html += "</div>";
        html += "Estimado usuario: <strong>" + usuario_recepcion + "</strong>";
        html += contenido;
        html += "<p>Por lo que se le solicita hacer clic en el siguiente enlace.</p>";
        html += "<div style='text-align: center;'>";
        html += "<a href= '" + h + "' target='_blank'><img src='cid:fp_foto3' style='width: 70; display: block; margin-right: auto; margin-left: auto; border-radius: 50% !important;'  /> </a> ";
        html += "<p style='margin-top: 32px; font-size: 14px; text-align: right;'> Este mensaje es generado automáticamente por el SISTEMA INTEGRADO DE GESTIÓN DE RECURSOS HUMANOS </p> ";
        html += "<p style='margin-top: 8px; font-size: 14px; text-align: right; color: #adb5bd;'> DIRECCIÓN DE GESTIÓN DE RECURSOS HUMANOS</p> ";
        html += "</div></div></div>  </body></html>";
        System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(html, System.Text.Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Html);
        System.Net.Mail.LinkedResource img = new System.Net.Mail.LinkedResource(Server.MapPath("../Content/img/brand/logo_lp2.png"));
        System.Net.Mail.LinkedResource img2 = new System.Net.Mail.LinkedResource(Server.MapPath("../Content/img/brand/correo5.png"));
        System.Net.Mail.LinkedResource img3 = new System.Net.Mail.LinkedResource(Server.MapPath("../Content/img/brand/correo7.png"));
        img.ContentId = "fp_foto";
        img2.ContentId = "fp_foto2";
        img3.ContentId = "fp_foto3";
        htmlView.LinkedResources.Add(img);
        htmlView.LinkedResources.Add(img2);
        htmlView.LinkedResources.Add(img3);
        correo.AlternateViews.Add(htmlView);
        correo.Priority = System.Net.Mail.MailPriority.Normal;

        SetScript("console.log('enviandoCorreoBefore');");
        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = "libertad";
        SetScript("console.log('enviandoCorreoAfter');");
        try
        {
            smtp.Send(correo);
        }
        catch (Exception ex)
        {
            SetScript("console.log('error: " + ex.ToString() + "');");
            Console.Write(ex);
        }

    }
}