using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;

using System.Data;
using System.Text;
using Newtonsoft.Json;
using MessagingToolkit.QRCode.Codec;
using System.Drawing;
using System.IO;

public partial class MovimientoPersonal_PlanillaContrato : System.Web.UI.Page
{
    private cls_pc_frecuencia frecuencia = null;
    private cls_pc_precontratado precontratado = null;
    private cls_pc_precontratado planilla = null;
    private cls_historico historico = null;
    private cls_mp_cargo cargo = null;
    private cls_mp_cargo tenor = null;
    private cls_mp_asignacion asignacion = null;
    private cls_mp_cargo_puesto cargo_puesto = null;
    private cls_catalogo _catalogo = null;
    private cls_persona persona = null;
    private cls_persona_domicilio domicilio = null;
    private cls_persona_familiares familiar = null;
    private cls_bs_afp afp = null;
    private cls_mp_seguimiento_memorandum seg_memo = null;
    private cls_glosa glosa = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["us_id"] != null && Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
                int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
                int pl_ue = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
                int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
                informacionPlanilla(pl_id);
                informacionResumen(pl_id);
                listarPlanilla(pl_id);
                listaFiltradoTipoDoc();

                SetScriptInicio("$('.table').DataTable().destroy(); ");
            }
        } else
        {
            Response.Redirect("../index");
        }

    }
    protected void listarContratados()
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        planilla = new cls_pc_precontratado();
        planilla.pl_id = pl_id + "";
        planilla.pl_pr_id = pr_id + "";
        var grillaFunc = planilla.DetalleContratados();
        gvFuncionario.DataSource = grillaFunc;
        gvFuncionario.DataBind();
  
    }
    private void listaFiltradoTipoDocumentoPersonal()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_personal" };
        ddl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_tipo_doc.DataValueField = "cat_id";
        ddl_tipo_doc.DataTextField = "cat_descripcion";
        ddl_tipo_doc.DataBind();
    }
    private void listaFiltradoLugarExpedido()
    {
        _catalogo = new cls_catalogo { cat_tabla = "departamento" };
        ddl_lugar_exp.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_lugar_exp.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_lugar_exp.DataValueField = "cat_id";
        ddl_lugar_exp.DataTextField = "cat_descripcion";
        ddl_lugar_exp.DataBind();
    }
    private void listarGenero()
    {
        _catalogo = new cls_catalogo { cat_tabla = "genero" };
        ddl_genero.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_genero.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_genero.DataValueField = "cat_abreviacion";
        ddl_genero.DataTextField = "cat_descripcion";
        ddl_genero.DataBind();
    }
    private void listaFiltradoEstadoCivil()
    {
        _catalogo = new cls_catalogo { cat_tabla = "estado_civil" };
        ddl_estado_civil.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_estado_civil.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_estado_civil.DataValueField = "cat_id";
        ddl_estado_civil.DataTextField = "cat_descripcion";
        ddl_estado_civil.DataBind();
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

            int[] ids = { 816, 818, 819, 821 };

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
    protected void ddl_tipo_documento_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_num_doc.Text = "";
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

                txt_num_doc.Attributes.Add("class", "form-control");
                break;

            case "816":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control numero");
                break;
            case "819":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control");
                break;
            case "821":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control");
                break;
            default:
                break;
        }
        SetScript("");
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
    private void listaFiltradoProcedencia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "pais" };
        ddl_nacionalidad.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_nacionalidad.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_nacionalidad.DataValueField = "cat_id";
        ddl_nacionalidad.DataTextField = "cat_descripcion";
        ddl_nacionalidad.DataBind();
    }

    // cargar per_lugar_nac
    private void listaFiltradoLugarNacimiento()
    {
        _catalogo = new cls_catalogo();
        ddl_lugar_nac.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_lugar_nac.DataSource = _catalogo.ObtenerLugarNacimiento();
        ddl_lugar_nac.DataValueField = "id_ciudad";
        ddl_lugar_nac.DataTextField = "lugar_nac";
        ddl_lugar_nac.DataBind();
    }
    private void listaFiltradoCiudadResidencia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "ciudad_localidad", cat_id_superior = 29 };
        ddl_ciudad_residencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_ciudad_residencia.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_ciudad_residencia.DataValueField = "cat_id";
        ddl_ciudad_residencia.DataTextField = "cat_descripcion";
        ddl_ciudad_residencia.DataBind();
    }
    private void listarTipoParentesco()
    {
        _catalogo = new cls_catalogo { cat_tabla = "parentesco" };
        var tipo = _catalogo.ObtenerTablaCombo();

        ddl_tipo_paren_p.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_paren_p.DataSource = tipo;
        ddl_tipo_paren_p.DataValueField = "cat_secuencial";
        ddl_tipo_paren_p.DataTextField = "cat_descripcion";
        ddl_tipo_paren_p.DataBind();
        ddl_tipo_paren_p.Enabled = false;

        ddl_tipo_paren_m.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_paren_m.DataSource = tipo;
        ddl_tipo_paren_m.DataValueField = "cat_secuencial";
        ddl_tipo_paren_m.DataTextField = "cat_descripcion";
        ddl_tipo_paren_m.DataBind();
        ddl_tipo_paren_m.Enabled = false;

        ddl_tipo_paren_e.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_paren_e.DataSource = tipo;
        ddl_tipo_paren_e.DataValueField = "cat_secuencial";
        ddl_tipo_paren_e.DataTextField = "cat_descripcion";
        ddl_tipo_paren_e.DataBind();
        ddl_tipo_paren_e.Enabled = false;
    }
    private void listaFiltradoAFP()
    {
        _catalogo = new cls_catalogo { cat_tabla = "previsora" };
        ddl_afp.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_afp.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_afp.DataValueField = "cat_abreviacion";
        ddl_afp.DataTextField = "cat_descripcion";
        ddl_afp.DataBind();
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
        sb.Append("$('#ContentPlaceHolder1_gvFuncionario').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gvFuncionario').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('.select2').select2({ dropdownParent: $('#modalCargo'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('.select2').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_item').select2({ dropdownParent: $('#modalImpresion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tenor').select2({ dropdownParent: $('#modalImpresion'), placeholder: { id: '0', text: 'Seleccione...' } });");

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
        sb.Append("$('#ContentPlaceHolder1_gvFuncionario').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gvFuncionario')) { $('#ContentPlaceHolder1_gvFuncionario').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_item').select2({ dropdownParent: $('#modalCargo'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto').select2({ dropdownParent: $('#modalAsignacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_doc').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_lugar_exp').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_genero').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_estado_civil').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_nacionalidad').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_lugar_nac').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_ciudad_residencia').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_afp').select2({ dropdownParent: $('#modalPersona'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_paren_p').select2({ dropdownParent: $('#modalFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_item').select2({ dropdownParent: $('#modalImpresion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tenor').select2({ dropdownParent: $('#modalImpresion'), placeholder: { id: '0', text: 'Seleccione...' } });");

        sb.Append("$('.ql-editor').css('border', 'none'); $('.ql-container.ql-snow').css('border', 'none'); $('.ql-editor').css('padding', '0rem .75rem');");

        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
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
    private void informacionResumen(int pl_id = 0)
    {
        planilla = new cls_pc_precontratado { pl_id = Convert.ToString(pl_id) };
        var detalle_planilla = planilla.ObtenerResumenPlanilla();
        if (detalle_planilla.Tables.Count > 0)
        {
            if (detalle_planilla.Tables[0].Rows.Count > 0)
            {
                var planillaX = detalle_planilla.Tables[0].Rows[0];
                ltl_cantidad_pre_cont.Text = validarCampo(planillaX["cantidad_precontratados"]);
                ltl_desc_pre_cont.Text = (Convert.ToInt32(validarCampo(planillaX["cantidad_precontratados"])) != 1) ? "Pre-contratos pendientes" : "Pre-contrato pendiente";
                ltl_cantidad_cont.Text = validarCampo(planillaX["cantidad_contratados"]);
                ltl_desc_cont.Text = (Convert.ToInt32(validarCampo(planillaX["cantidad_contratados"])) != 1) ? "Contratos ejecutados" : "Contrato ejecutado";
            }
        }
    }
    private void listarPlanilla(int pl_id = 0, int es_id = 0, string paterno = "0")
    {
        try
        {
            precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, es_id = es_id, pre_paterno = paterno };
            var precontratos = precontratado.ListarPrecontratosValidados();
            int tam = precontratos.Tables[0].Rows.Count;
            no_existe_prec.Visible = (tam > 0) ? false : true;
            gv_planilla.DataSource = precontratos;
            gv_planilla.DataBind();

            foreach (GridViewRow row in gv_planilla.Rows)
            {
                string estado_fun = gv_planilla.DataKeys[row.DataItemIndex].Values[4].ToString();
                if (estado_fun == "NUEVO")
                {
                    row.CssClass = "grid-row-new";
                }
            }

            bool sw = true;
            var detalle_precontratos = precontratos.Tables[0].Rows;
            for (int i = 0; i < detalle_precontratos.Count; i++)
            {
                var precontrato_x = detalle_precontratos[i];
                if (validarCampo(precontrato_x["bloqueo"]) != "0")
                {
                    sw = false;
                }
                if (validarCampo(precontrato_x["incompatibilidad"]) != "0")
                {
                    sw = false;
                }
                if (validarCampo(precontrato_x["cantidad_fam"]) == "0")
                {
                    sw = false;
                }
                if (!sw)
                {
                    break;
                }
            }

            btn_contratar.Visible = (!sw) ? false : (ltl_cantidad_pre_cont.Text.Trim() == "0") ? false : true;

            listaFiltradoPlanilla(pl_id, es_id, paterno, "C21", "ddl_gv_planilla_paterno", "ap_paterno_x", "ap_paterno_x", " CASE WHEN P.per_id IS NULL AND TPC.tmp_id IS NULL THEN 'ACEFALIA' WHEN P.per_id IS NOT NULL AND TPC.tmp_id IS NULL THEN LTRIM(RTRIM(P.per_ap_paterno)) WHEN P.per_id IS NULL AND TPC.tmp_id IS NOT NULL THEN LTRIM(RTRIM(TPC.tmp_paterno)) END AS ap_paterno_x ");
            listaFiltradoPlanilla(pl_id, es_id, paterno, "C20", "ddl_gv_planilla_cargo", "es_id", "es_descripcion", "ES.es_descripcion, ES.es_id");

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
    private void AdicionarHistorico(string abm = "", string tabla = "", string nom_pk = "", string val_pk = "", string campos = "")
    {
        historico = new cls_historico
        {
            his_tipo_abm = abm,
            his_nom_tabla = tabla,
            his_nom_pk = nom_pk,
            his_valor_pk = val_pk,
            his_campos = campos,
            his_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString())
        };
        historico.Adicionar();
    }

    protected void btn_cancelar_cargo_Click(object sender, EventArgs e)
    {
        sc = "$('#modalCargo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;

        if (pl_id != 0 && pr_id != 0)
        {
            construirContratos();
            guardarGlosa(pl_id, "pl_id", "tbl_pc_planilla");
            limpiarGlosa();
            informacionResumen(pl_id);
            listarPlanilla(pl_id);
            listarContratados();

            sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Se asignó los contratos correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalAsignacion').modal('hide'); $('#modalGlosa').modal('hide'); $('#modalContratados').modal('show');  }});";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }
    private void construirContratos()
    {
        int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        precontratado = new cls_pc_precontratado { pre_pl_id = pl_id, es_id = 0, pre_paterno = "0" };
        var precontratos = precontratado.ListarPrecontratosValidados();
 
        if (precontratos.Tables[0].Rows.Count > 0)
        {
            var detalle_precontratos = precontratos.Tables[0].Rows;
            for (int i = 0; i < detalle_precontratos.Count; i++)
            {
                var precontrato_x = detalle_precontratos[i];
                int as_id = (validarCampo(precontrato_x["rap_as_id"]) != "") ? Convert.ToInt32(validarCampo(precontrato_x["rap_as_id"])) : 0;
                int cp_id = Convert.ToInt32(validarCampo(precontrato_x["fr_cp_id"]));
                int es_id = Convert.ToInt32(validarCampo(precontrato_x["fr_es_id"]));
                string tipo_jornada = validarCampo(precontrato_x["tipo_jornada"]);
                int per_id = Convert.ToInt32(validarCampo(precontrato_x["per_id"]));
                int pu_id = Convert.ToInt32(validarCampo(precontrato_x["pu_id"]));
                string fecha_inicio = validarCampo(precontrato_x["pre_fecha_inicio"]);
                string fecha_fin = validarCampo(precontrato_x["pre_fecha_fin"]);
                int pre_id = Convert.ToInt32(validarCampo(precontrato_x["pre_id"]));
                int pre_numero_item = Convert.ToInt32(validarCampo(precontrato_x["pre_numero_item"]));
                crearCargos(as_id, cp_id, es_id, tipo_jornada, per_id, pu_id, fecha_inicio, fecha_fin, pr_id, pre_id, pre_numero_item);
            }
        } else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

    }
    private void crearCargos(int as_id = 0, int cp_id = 0, int es_id = 0, string tipo_jornada = "", int per_id = 0, int pu_id = 0, string fecha_inicio = "", string fecha_fin = "", int pr_id = 0, int pre_id = 0, int pre_numero_item = 0)
    {
        if (as_id == 0)
        {
            if (cp_id != 0 && es_id != 0 && tipo_jornada != "" && per_id != 0 && pu_id != 0 && fecha_inicio != "" & fecha_fin != "" && pr_id != 0 && pre_id != 0)
            {
                cargo = new cls_mp_cargo();
                cargo.eo_id = cp_id;
                var tipoItem = cargo.ObtenerFiltradoTipoItemUO();
                string ca_ti_item = "";
                if (tipoItem.Tables[0].Rows.Count > 0)
                {
                    var item_x = tipoItem.Tables[0].Rows[0];
                    ca_ti_item = validarCampo(item_x["ti_item"]);
                }

                planilla = new cls_pc_precontratado { cp_id = cp_id, es_id = es_id };
                var detalle_cargo = planilla.DetalleCargo();
                string hf_haber_basico = "";
                int eo_id = 0;
                if (detalle_cargo.Tables[0].Rows.Count > 0)
                {
                    var cargo_x = detalle_cargo.Tables[0].Rows[0];
                    eo_id = Convert.ToInt32(validarCampo(cargo_x["eo_id"]));
                    string haberBasico = validarCampo(cargo_x["haber_basico"]);
                    double haberBasicoAsignar = Convert.ToDouble(haberBasico);
                    haberBasicoAsignar = Math.Round(haberBasicoAsignar);
                    hf_haber_basico = Convert.ToString(haberBasicoAsignar);
                }

                decimal hb = Convert.ToDecimal(hf_haber_basico);

                string num_item = generarNroItem(pr_id, eo_id);
                int genera_num_item = Convert.ToInt32(num_item);
                genera_num_item = genera_num_item + 1;

                cargo.ca_es_id = es_id;
                cargo.ca_eo_id = eo_id;
                cargo.ca_ti_item = ca_ti_item;
                cargo.ca_num_item = (pre_numero_item != 0) ? pre_numero_item : genera_num_item;
                cargo.ca_estado = "O";
                cargo.ca_aplica_incremento = "NO";
                cargo.ca_tipo_jornada = tipo_jornada;
                cargo.ca_basico_calculado = hb + "";
                cargo.ca_fecha_modificacion = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                cargo.ca_pr_id = pr_id + "";
                cargo.ca_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());

                var detalleCargoHis = cargo.AdicionarCargoUO();
                if (detalleCargoHis.Tables.Count > 0)
                {
                    if (detalleCargoHis.Tables[0].Rows.Count > 0)
                    {
                        var cargo_his_X = detalleCargoHis.Tables[0].Rows[0];
                        string ca_id_x = validarCampo(cargo_his_X["ca_id"]);
                        string json = JsonConvert.SerializeObject(detalleCargoHis.Tables[0]);
                        AdicionarHistorico("A", "tbl_mp_cargo", "ca_id", Convert.ToString(ca_id_x), json);

                        asignarCargos(per_id, Convert.ToInt32(ca_id_x), fecha_inicio, fecha_fin, pu_id, pr_id, pre_id);
                    }
                }

            } else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
    
        }
    }
    private void asignarCargos(int per_id = 0, int ca_id = 0, string fecha_inicio = null, string fecha_fin = null, int pu_id = 0, int pr_id = 0, int pre_id = 0)
    {
        asignacion = new cls_mp_asignacion();
        var data = asignacion.ObtenerTablaGrilla("", per_id + "", "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];
        string tipo_reg = (data.Rows.Count > 0) ? "R" : "I";

        asignacion = new cls_mp_asignacion
        {
            as_per_id = per_id,
            as_ca_id = ca_id,
            as_fecha_inicio = Convert.ToDateTime(fecha_inicio),
            as_fecha_fin = Convert.ToDateTime(fecha_fin),
            as_tipo_reg = tipo_reg,
            as_tipo_mov = "B",
            as_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString()),
            as_pr_id = pr_id,
            pre_id = pre_id
        };
        asignacion.Adicionar();
        var detalle_asignacion = asignacion.ObtenerASignacion();
        if (detalle_asignacion.Tables.Count > 0)
        {
            if (detalle_asignacion.Tables[0].Rows.Count > 0)
            {
                var asig_his_x = detalle_asignacion.Tables[0].Rows[0];
                string as_id_x = validarCampo(asig_his_x["as_id"]);
                string json = JsonConvert.SerializeObject(detalle_asignacion.Tables[0]);
                AdicionarHistorico("A", "tbl_mp_asignacion", "as_id", Convert.ToString(as_id_x), json);
            }
        }

        cargo_puesto = new cls_mp_cargo_puesto
        {
            cap_ca_id = ca_id,
            cap_p_id = pu_id
        };
        cargo_puesto.Adicionar();
    }
    private void limpiarGlosa()
    {
        ddl_tipo_documento.SelectedValue = "0";
        txt_fechaMov.Text = "";
        txt_descripcion_add.Text = "";
    }
    private string generarIdCargo()
    {
        cargo = new cls_mp_cargo();
        var pe_cargo = cargo.ObtenerIdCargo();
        string ca_id = "";
        if (pe_cargo.Tables[0].Rows.Count > 0)
        {
            if (pe_cargo.Tables[0].Rows[0]["ca_id"] != DBNull.Value && pe_cargo.Tables[0].Rows[0]["ca_id"].ToString().Trim() != "")
            {
                ca_id = pe_cargo.Tables[0].Rows[0]["ca_id"].ToString().Trim();
            }

        }
        return ca_id;
    }
    private string generarNroItem(int pr_id = 0, int eo_id = 0)
    {
        cargo = new cls_mp_cargo();
        cargo.ca_eo_id = eo_id;
        cargo.gestion_selec = pr_id + "";

        var pe_cargo = cargo.ObtenerNroItem();
        string ca_num_item = "";
        if (pe_cargo.Tables[0].Rows.Count > 0)
        {
            if (pe_cargo.Tables[0].Rows[0]["ca_num_item"] != DBNull.Value && pe_cargo.Tables[0].Rows[0]["ca_num_item"].ToString().Trim() != "")
            {
                ca_num_item = pe_cargo.Tables[0].Rows[0]["ca_num_item"].ToString().Trim();
            }

        }
        return ca_num_item;
    }

    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('hide');";
        SetScript(sc);
    }
    protected void btn_asignar_item_Click(object sender, EventArgs e)
    {
        sc = "$('#modalAsignacion').modal('hide'); $('#modalItems').modal('show');";
        SetScript(sc);
    }
    protected void gv_planilla_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_pre_id.Value = gv_planilla.DataKeys[index].Values[0].ToString();
        hf_fr_id.Value = gv_planilla.DataKeys[index].Values[1].ToString();
        hf_fr_cp_id.Value = gv_planilla.DataKeys[index].Values[2].ToString();
        hf_fr_es_id.Value = gv_planilla.DataKeys[index].Values[3].ToString();
        string estado_fun = gv_planilla.DataKeys[index].Values[4].ToString();
        hf_per_id.Value = gv_planilla.DataKeys[index].Values[5].ToString();
        switch (e.CommandName)
        {
            case "GetAssign":
                if (estado_fun.Trim() == "NUEVO")
                {
                    listaFiltradoTipoDocumentoPersonal();
                    listaFiltradoLugarExpedido();
                    listarGenero();
                    listaFiltradoEstadoCivil();
                    listaFiltradoProcedencia();
                    listaFiltradoLugarNacimiento();
                    listaFiltradoCiudadResidencia();
                    listaFiltradoAFP();
                    datosFuncionarioNuevo();
                    sc = "$('#modalPersona').modal('show'); Swal.fire({icon: 'info', title: 'El funcionario es nuevo, regístrelo por favor.', showConfirmButton: true, allowOutsideClick: false});";
                    SetScript(sc);
                }

                break;
            case "GetAssignFam":
                listarTipoParentesco();
                llenarDatosFamiliar();
                sc = "$('#modalFamiliar').modal('show');";
                SetScript(sc);
                break;
            case "GetDetail":
                detalleRestriccion();
                break;
            default:
                break;
        }
    }
    private void datosFuncionarioNuevo()
    {
        planilla = new cls_pc_precontratado { pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_precontratado_fun = planilla.DetallePreFuncionarioNuevo();

        if (detalle_precontratado_fun.Tables[0].Rows.Count > 0)
        {
            var precontratado_fun = detalle_precontratado_fun.Tables[0].Rows[0];
            txt_ci.Text = validarCampo(precontratado_fun["ci_x"]);
            txt_pre_paterno.Text = validarCampo(precontratado_fun["ap_paterno_x"]);
            txt_pre_materno.Text = validarCampo(precontratado_fun["ap_materno_x"]);
            txt_pre_nombres.Text = validarCampo(precontratado_fun["nombres_x"]);
            txt_pre_ap_casada.Text = validarCampo(precontratado_fun["ap_casada_x"]);

            ddl_tipo_doc.SelectedValue = "795";
            ddl_genero.SelectedValue = validarCampo(precontratado_fun["genero_x"]);
            ddl_afp.SelectedValue = validarCampo(precontratado_fun["afp_x"]);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

    }
    protected void llenarDatosFamiliar()
    {
        familiar = new cls_persona_familiares();
        familiar.pf_per_id =  Convert.ToInt32(hf_per_id.Value);
        var detalleFamiliar = familiar.ObtenerPersonaFamilarX();
        

        ddl_tipo_paren_p.SelectedValue = "1";
        ddl_tipo_paren_m.SelectedValue = "2";
        ddl_tipo_paren_e.SelectedValue = "8";
        if (detalleFamiliar.Tables.Count > 0)
        {
            var familiares = detalleFamiliar.Tables[0].Rows;
            for (int i = 0; i < familiares.Count; i++)
            {
                var fam_x = familiares[i];
                if (validarCampo(fam_x["pf_tipo_parentesco"]) == "1")
                {
                    txt_ap_paterno_p.Text = validarCampo(fam_x["pf_paterno"]);
                    txt_ap_materno_p.Text = validarCampo(fam_x["pf_materno"]);
                    txt_nombres_p.Text = validarCampo(fam_x["pf_nombres"]);
                    hf_pf_id_p.Value = validarCampo(fam_x["pf_id"]);
                }
                if (validarCampo(fam_x["pf_tipo_parentesco"]) == "2")
                {
                    txt_ap_paterno_m.Text = validarCampo(fam_x["pf_paterno"]);
                    txt_ap_materno_m.Text = validarCampo(fam_x["pf_materno"]);
                    txt_nombres_m.Text = validarCampo(fam_x["pf_nombres"]);
                    hf_pf_id_m.Value = validarCampo(fam_x["pf_id"]);
                }
                if (validarCampo(fam_x["pf_tipo_parentesco"]) == "8")
                {
                    txt_ap_paterno_e.Text = validarCampo(fam_x["pf_paterno"]);
                    txt_ap_materno_e.Text = validarCampo(fam_x["pf_materno"]);
                    txt_nombres_e.Text = validarCampo(fam_x["pf_nombres"]);
                    hf_pf_id_m.Value = validarCampo(fam_x["pf_id"]);
                }
            }
        }
    }
    private void detalleRestriccion()
    {
        precontratado = new cls_pc_precontratado { pre_id = Convert.ToInt32(hf_pre_id.Value) };
        var detalle_precontratado_fun = precontratado.DetalleRestriccion();

        string alert = "";
        string mje = "";
        if (detalle_precontratado_fun.Tables[0].Rows.Count > 0)
        {
            var precontratado_fun = detalle_precontratado_fun.Tables[0].Rows[0];

            string cantidad_fam = validarCampo(precontratado_fun["cantidad_fam"]);
            mje = (cantidad_fam == "0") ? mje + "No tiene familiares registrados. </br>" : mje + "";

            string incompatibilidad = validarCampo(precontratado_fun["incompatibilidad"]);
            mje = (incompatibilidad != "0") ? mje + "Incompatibilidad funcionaria. </br>" : mje + "";

            string bloqueo = validarCampo(precontratado_fun["bloqueo"]);
            mje = (bloqueo != "0") ? mje + "Bloqueo de funcionario. </br>" : mje + "";

            alert = "No se puede realizar la asignación por los siguientes motivos: ', html: '" + mje;
            sc = "$('#modalVerificarDoc').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); Swal.fire({icon: 'info', title: '" + alert + "', showConfirmButton: true, allowOutsideClick: false});";
            SetScript(sc);

        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

    }
    protected void btn_adicionar_funcionario_Click(object sender, EventArgs e)
    {
        if (hf_ca_id.Value != "")
        {
            hf_tipo_abm.Value = "asignacion";
            sc = "$('#modalGlosa').modal('show');";
            SetScript(sc);
        } else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, debe seleccionar un ítem acéfalo para realizar la asignación.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    protected void btn_guardar_fun_nuevo_Click(object sender, EventArgs e)
    {
        if (txt_pre_paterno.Text.Trim() == "" && txt_pre_materno.Text.Trim() == "")
        {
            sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, debe ingresar al menos un apellido.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
            return;
        }

        var edad = DateTime.Now.Year - Convert.ToDateTime(txt_fecha_nac.Text.Trim()).Year;

        if (edad > 0)
        {
            if (edad < 18)
            {
                sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-exclamation', message: 'La persona debe ser mayor de edad, verifique el campo (Fecha de Nacimiento)'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
            }
            else if (edad >= 65)
            {
                sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-exclamation', message: 'La persona debe ser menor a 65 años, verifique el campo (Fecha de Nacimiento)'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
            } else
            {
                persona = new cls_persona();
                persona.ObtenerId();
                int per_id = Convert.ToInt32(persona.per_id.ToString());

                DateTime? fecha_mod = null;
                persona = new cls_persona
                {
                    per_id = per_id,
                    per_tipo_doc = Convert.ToInt32(ddl_tipo_doc.SelectedValue),
                    per_num_doc = txt_ci.Text.ToUpper().Trim(),
                    per_lugar_exp = Convert.ToInt32(ddl_lugar_exp.SelectedValue),
                    per_ap_paterno = txt_pre_paterno.Text.ToUpper().Trim(),
                    per_ap_materno = txt_pre_materno.Text.ToUpper().Trim(),
                    per_nombres = txt_pre_nombres.Text.ToUpper().Trim(),
                    per_ap_casada = txt_pre_ap_casada.Text.ToUpper().Trim(),
                    per_sexo = ddl_genero.SelectedValue,
                    per_fecha_nac = Convert.ToDateTime(txt_fecha_nac.Text.Trim()),
                    per_procedencia = Convert.ToInt32(ddl_nacionalidad.SelectedValue),
                    per_serie_libreta_militar = txt_nro_libreta.Text.ToUpper().Trim(),
                    per_lugar_nac = Convert.ToInt32(ddl_lugar_nac.SelectedValue),
                    per_estado_civil = Convert.ToInt32(ddl_estado_civil.SelectedValue)
                };
                persona.Adicionar();

                precontratado = new cls_pc_precontratado { pre_id = Convert.ToInt32(hf_pre_id.Value), pre_per_id = per_id };
                precontratado.EliminarPreFuncionarioNuevo();

                domicilio = new cls_persona_domicilio
                {
                    perd_per_id = per_id,
                    perd_ciudad_residencia = Convert.ToInt32(ddl_ciudad_residencia.SelectedValue),
                    perd_celular = txt_celular.Text.Trim()
                };
                domicilio.Adicionar();
                afp = new cls_bs_afp
                {
                    afp_per_id = per_id,
                    afp_previsora = ddl_afp.SelectedValue,
                    afp_fecha_filiacion = DateTime.Now,
                    afp_fecha_modificacion = fecha_mod,
                    afp_fecha_carnet = DateTime.Now,
                    afp_estado_carnet = "V",
                    afp_usuario = Convert.ToInt32(Session["us_id"].ToString())
                };
                afp.Adicionar();
                int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
                informacionResumen(pl_id);
                listarPlanilla(pl_id);
                limpiarFun();
                sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Funcionario creado correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                SetScript(sc);
            } 
        }
        else
        {
            sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-exclamation', message: 'El campo (Fecha de Nacimiento), no tiene una fecha de nacimiento válida.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }

    protected void btn_cancelar_fun_nuevo_Click(object sender, EventArgs e)
    {
        ddl_tipo_doc.SelectedValue = "0";
        txt_ci.Text = "";
        ddl_lugar_exp.SelectedValue = "0";
        txt_fecha_nac.Text = "";

        txt_pre_paterno.Text = "";
        txt_pre_materno.Text = "";
        txt_pre_nombres.Text = "";
        txt_pre_ap_casada.Text = "";

        ddl_genero.SelectedValue = "0";
        ddl_estado_civil.SelectedValue = "0";
        ddl_nacionalidad.SelectedValue = "0";
        ddl_lugar_nac.SelectedValue = "0";

        ddl_ciudad_residencia.SelectedValue = "0";
        txt_celular.Text = "";
        txt_nro_libreta.Text = "";
        ddl_afp.SelectedValue = "0";

        sc = "$('#modalPersona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void ddl_nacionalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddl_nacionalidad.SelectedValue == "1")
        {
            ddl_lugar_nac.SelectedValue = "0";
            ddl_lugar_nac.Enabled = true;
        }
        else
        {
            ddl_lugar_nac.SelectedValue = "1822";
            ddl_lugar_nac.Enabled = false;
        }
        SetScript("");
    }


    protected void btn_adicionar_fam_Click(object sender, EventArgs e)
    {
        familiar = new cls_persona_familiares();
        string mje = "";
        if (((txt_ap_paterno_p.Text.Trim() != null && txt_ap_paterno_p.Text.Trim() != "" && txt_nombres_p.Text.Trim() != null && txt_nombres_p.Text.Trim() != "") || (txt_ap_materno_p.Text.Trim() != null && txt_ap_materno_p.Text.Trim() != "" && txt_nombres_p.Text.Trim() != null && txt_nombres_p.Text.Trim() != "")) ||
            ((txt_ap_paterno_m.Text.Trim() != null && txt_ap_paterno_m.Text.Trim() != "" && txt_nombres_m.Text.Trim() != null && txt_nombres_m.Text.Trim() != "") || (txt_ap_materno_m.Text.Trim() != null && txt_ap_materno_m.Text.Trim() != "" && txt_nombres_m.Text.Trim() != null && txt_nombres_m.Text.Trim() != "")))
        {
            if ((txt_ap_paterno_p.Text.Trim() != null && txt_ap_paterno_p.Text.Trim() != "" && txt_nombres_p.Text.Trim() != null && txt_nombres_p.Text.Trim() != "") || (txt_ap_materno_p.Text.Trim() != null && txt_ap_materno_p.Text.Trim() != "" && txt_nombres_p.Text.Trim() != null && txt_nombres_p.Text.Trim() != ""))
            {
                familiar.pf_per_id = Convert.ToInt32(hf_per_id.Value);
                familiar.pf_tipo_parentesco = ddl_tipo_paren_p.SelectedValue;
                familiar.pf_paterno = txt_ap_paterno_p.Text.ToUpper().Trim();
                familiar.pf_materno = txt_ap_materno_p.Text.ToUpper().Trim();
                familiar.pf_nombres = txt_nombres_p.Text.ToUpper().Trim();
                familiar.pf_ap_esposo = null;
                familiar.pf_fecha_nac = null;
                string pf_id_p = hf_pf_id_p.Value;
                if (pf_id_p != "")
                {
                    familiar.pf_id = Convert.ToInt32(pf_id_p);
                    familiar.ActualizarEstadoFam();
                    familiar.Adicionar();
                }
                else
                {
                    familiar.Adicionar();
                }
                mje = "al padre ";
            }

            if ((txt_ap_paterno_m.Text.Trim() != null && txt_ap_paterno_m.Text.Trim() != "" && txt_nombres_m.Text.Trim() != null && txt_nombres_m.Text.Trim() != "") || (txt_ap_materno_m.Text.Trim() != null && txt_ap_materno_m.Text.Trim() != "" && txt_nombres_m.Text.Trim() != null && txt_nombres_m.Text.Trim() != ""))
            {
                familiar.pf_per_id = Convert.ToInt32(hf_per_id.Value);
                familiar.pf_tipo_parentesco = ddl_tipo_paren_m.SelectedValue;
                familiar.pf_paterno = txt_ap_paterno_m.Text.ToUpper().Trim();
                familiar.pf_materno = txt_ap_materno_m.Text.ToUpper().Trim();
                familiar.pf_nombres = txt_nombres_m.Text.ToUpper().Trim();
                familiar.pf_ap_esposo = null;
                familiar.pf_fecha_nac = null;

                string pf_id_m = hf_pf_id_m.Value;
                if (pf_id_m != "")
                {
                    familiar.pf_id = Convert.ToInt32(pf_id_m);
                    familiar.ActualizarEstadoFam();
                    familiar.Adicionar();
                }
                else
                {
                    familiar.Adicionar();
                }
                mje = (mje != "") ? mje + "y madre " : "a la madre ";
            }

            if ((txt_ap_paterno_e.Text.Trim() != null && txt_ap_paterno_e.Text.Trim() != "" && txt_nombres_e.Text.Trim() != null && txt_nombres_e.Text.Trim() != "") || (txt_ap_materno_e.Text.Trim() != null && txt_ap_materno_e.Text.Trim() != "" && txt_nombres_e.Text.Trim() != null && txt_nombres_e.Text.Trim() != ""))
            {
                familiar.pf_per_id = Convert.ToInt32(hf_per_id.Value);
                familiar.pf_tipo_parentesco = ddl_tipo_paren_e.SelectedValue;
                familiar.pf_paterno = txt_ap_paterno_e.Text.ToUpper().Trim();
                familiar.pf_materno = txt_ap_materno_e.Text.ToUpper().Trim();
                familiar.pf_nombres = txt_nombres_e.Text.ToUpper().Trim();
                familiar.pf_ap_esposo = null;
                familiar.pf_fecha_nac = null;

                string pf_id_m = hf_pf_id_m.Value;
                if (pf_id_m != "")
                {
                    familiar.pf_id = Convert.ToInt32(pf_id_m);
                    familiar.ActualizarEstadoFam();
                    familiar.Adicionar();
                }
                else
                {
                    familiar.Adicionar();
                }
            }

            int pl_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
            listarPlanilla(pl_id);
            limpiarFam();
            sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Se registró " + mje + "de familia correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            SetScript(sc);
        } else
        {
            sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, por favor registre al menos a un familiar.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }

    protected void btn_cancelar_fam_Click(object sender, EventArgs e)
    {
        sc = "$('#modalFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    private void limpiarFam()
    {
        txt_ap_paterno_p.Text = "";
        txt_ap_materno_p.Text = "";
        txt_nombres_p.Text = "";
        txt_ap_paterno_m.Text = "";
        txt_ap_materno_m.Text = "";
        txt_nombres_m.Text = "";
        txt_ap_paterno_e.Text = "";
        txt_ap_materno_e.Text = "";
        txt_nombres_e.Text = "";
    }
    private void limpiarFun()
    {
        ddl_lugar_exp.SelectedValue = "0";
        txt_fecha_nac.Text = "";
        ddl_estado_civil.SelectedValue = "0";
        ddl_nacionalidad.SelectedValue = "0";
        ddl_lugar_nac.SelectedValue = "0";
        ddl_ciudad_residencia.SelectedValue = "0";
        txt_celular.Text = "";
        txt_nro_libreta.Text = "";
    }

    protected void btn_contratar_Click(object sender, EventArgs e)
    {
        sc = "$('#modalGlosa').modal('show');";
        SetScript(sc);
    }
    protected void chk_print_memo_all_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvFuncionario.Rows.Count; i++)
        {
            GridViewRow row = gvFuncionario.Rows[i];
            bool isChecked = ((CheckBox)gvFuncionario.HeaderRow.FindControl("chk_print_memo_all")).Checked;

            if (isChecked)
            {
                ((CheckBox)row.FindControl("chk_print_memo")).Checked = true;
            }
            else
            {
                ((CheckBox)row.FindControl("chk_print_memo")).Checked = false;
            }
        }
        SetScript("");
    }
    protected void chk_print_memo_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void gvFuncionario_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvFuncionario.Rows.Count > 0)
        {
            if (gvFuncionario.HeaderRow != null)
            {
                gvFuncionario.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvFuncionario.FooterRow != null)
            {
                gvFuncionario.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void LimpiarGrilla()
    {
        gvFuncionario.DataSource = null;
        gvFuncionario.DataBind();
    }

    protected void btn_cancelar_impresion_Click(object sender, EventArgs e)
    {
        sc = "$('#modalContratados').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_contratos_ejec_Click(object sender, EventArgs e)
    {
        listarContratados();

        if (gvFuncionario.Rows.Count > 0)
        {
            sc = "$('#modalContratados').modal('show'); ";
            SetScript(sc);
        } else
        {
            sc = "$.notify({ icon: 'fa fa-info-circle', message: 'No se puede realizar la acción, los contratos de la planilla aun no fueron ejecutados.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

    }
}