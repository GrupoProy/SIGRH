using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Kardex_Sippase : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_glosa _glosa = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_persona _persona = null;
    //private cls_mp_asignacion _asignacion = null;
    //private cls_situacion_persona _situacion = null;
    private cls_kd_certificado_sippase _certificado_sippase = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack) { }
        }
        else { Response.Redirect("../Index"); }
    }

    // Carga La Información Del Funcionario
    private void CargaInfoFuncionario(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var dataA = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (dataA.Rows.Count > 0)
        {
            Lt_per_nombres.Text = ValidarCampo(dataA.Rows[0]["per_nombres"]) + " " + ValidarCampo(dataA.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(dataA.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(dataA.Rows[0]["per_num_doc"]) + " " + ValidarCampo(dataA.Rows[0]["cat_abreviacion"]);
            Lt_per_id.Text = ValidarCampo(dataA.Rows[0]["per_id"]);
            //Lt_ca_num_item.Text = ValidarCampo(dataA.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(dataA.Rows[0]["ca_num_item"]);
            //Lt_as_fecha_inicio.Text = Convert.ToDateTime(ValidarCampo(dataA.Rows[0]["as_fecha_inicio"])).ToString("dd/MM/yyyy");
            //Lt_as_fecha_fin.Text = (ValidarCampo(dataA.Rows[0]["as_fecha_fin"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(dataA.Rows[0]["as_fecha_fin"])).ToString("dd/MM/yyyy");
            //Lt_eo_descripcion.Text = ValidarCampo(dataA.Rows[0]["eo_descripcion"]);
            //Lt_cp_descripcion.Text = ValidarCampo(dataA.Rows[0]["cp_descripcion"]);

            if (ValidarCampo(dataA.Rows[0]["as_estado"]).Equals("V"))
            {
                Lbl_as_estado.Text = "Vigente";
                Lbl_as_estado.CssClass = "btn btn-sm btn-info float-right";
            }
            else
            {
                Lbl_as_estado.Text = "Pasivo";
                Lbl_as_estado.CssClass = "btn btn-sm btn-secondary float-right";
            }

            if (ValidarCampo(dataA.Rows[0]["fp_foto"]) != "") Img_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])dataA.Rows[0]["fp_foto"]);
            else if (ValidarCampo(dataA.Rows[0]["per_sexo"]).Equals("M")) Img_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg";
            else Img_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg";
        }
    }

    // Carga Datos En El DropDownList (Ddl_gl_tipo_doc)
    private void CargaDDLTipoDocumento()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Carga Datos En El GridView (Gv_busqueda_lista)
    //private void CargaGVBusqueda(string varId, string varCed, string varPat, string varMat, string varNom, string varCas)
    private void CargaGVBusqueda(string varId, string varCed, string varPat, string varMat, string varNom)
    {
        try
        {
            _persona = new cls_persona();
            //Gv_busqueda_lista.DataSource = _persona.ObtenerTablaGrilla(varId, "", varCed, "", varPat, varMat, varNom, varCas, "", "", "", "", "", "");
            Gv_busqueda_lista.DataSource = _persona.ObtenerTablaGrilla(varId, "", varCed, "", varPat, varMat, varNom, "", "", "", "", "", "", "");
            Gv_busqueda_lista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño Del GridView (Gv_busqueda_lista)
    protected void Gv_busqueda_lista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_busqueda_lista.Rows.Count > 0)
        {
            if (Gv_busqueda_lista.HeaderRow != null) { Gv_busqueda_lista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_busqueda_lista.FooterRow != null) { Gv_busqueda_lista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del GridView (Gv_busqueda_lista)
    protected void Gv_busqueda_lista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //_asignacion = new cls_mp_asignacion();
        int index = Convert.ToInt32(e.CommandArgument);
        string code = Gv_busqueda_lista.DataKeys[index].Value.ToString();
        //var data = _asignacion.ObtenerTablaGrilla("", code, "", "", "", "V", "", "", "", "", "", "", "", "").Tables[0];
        //_situacion = new cls_situacion_persona
        //{
        //    st_per_id = Convert.ToInt32(code),
        //    st_estado = "V"
        //};
        //var dataS = _situacion.ObtenerTablaGrilla().Tables[0];

        //if (dataS.Rows.Count > 0)
        //{
        //    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se puede realizar ninguna acción sobre el funcionario...!!' }, { type: 'warning' });";
        //    SetScript(sc);
        //    return;
        //}

        //if (data.Rows.Count > 0) { if (e.CommandName.Equals("GetNew")) Response.Redirect("IncompatibilidadFuncionaria?id=" + code); }
        //else sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El funcionario no tiene una asignación vigente...!!' }, { type: 'warning' });";
        if (e.CommandName.Equals("Btn_nuevo_registro"))
        {
            Hf_sip_per_id.Value = code;
            CargaInfoFuncionario(code);
            sc = "$('#sippaseModal').modal('show');";
        }
        SetScript(sc, "");
    }

    // Busca Registros De Acuerdo A Los Parámetros && string.IsNullOrEmpty(Txt_per_ap_casada_b.Text)
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });"; }
        else
        {
            //CargaGVBusqueda(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_per_ap_casada_b.Text.Trim());
            CargaGVBusqueda(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());
            Limpiar("sch_cl");

            if (Gv_busqueda_lista.Rows.Count > 0) { P_busqueda_lista.Visible = true; }
            else
            {
                P_busqueda_lista.Visible = false;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
            }
        }
        SetScript(sc, "");
    }

    // Alta De Los Datos Del Certificado SIPPASE
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        CargaDDLTipoDocumento();
        sc = "$('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Cancela Alta De Los Datos Del Certificado SIPPASE
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar("frm_sip_cl");
        sc = "$('#sippaseModal').modal('hide');";
        SetScript(sc,"");
    }

    // Alta De Los Datos De Incompatibilidad Funcionaria Y Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        _certificado_sippase = new cls_kd_certificado_sippase();
        var dataSIP = _certificado_sippase.ObtenerTablaGrilla("0", Hf_sip_per_id.Value, "", "", "", "V").Tables[0];

        if (dataSIP.Rows.Count > 0)
        {
            _certificado_sippase = new cls_kd_certificado_sippase { sip_id = Convert.ToInt32(dataSIP.Rows[0]["sip_id"]) };
            _certificado_sippase.Eliminar();
        }
        _certificado_sippase = new cls_kd_certificado_sippase
        {
            sip_per_id = Convert.ToInt32(Hf_sip_per_id.Value),
            sip_descripcion_cert = Txt_sip_descripcion_cert.Text.ToUpper().Trim(),
            sip_fecha_cert = Convert.ToDateTime(Txt_sip_fecha_cert.Text.Trim()),
            sip_fecha_pres = Convert.ToDateTime(Txt_sip_fecha_pres.Text.Trim())
        };
        var var_sip_id=_certificado_sippase.Adicionar();
        _glosa = new cls_glosa
        {
            gl_valor_pk = var_sip_id.ToString(),
            gl_nombre_pk = "sip_id",
            gl_tabla = "tbl_kd_certificado_sippase",
            gl_tipo_mov = 813,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        Limpiar("gv_cl");
        Limpiar("frm_sip_cl");
        Limpiar("frm_glosa_cl");

        if (Gv_busqueda_lista.Rows.Count > 0) { P_busqueda_lista.Visible = true; }
        else { P_busqueda_lista.Visible = false; }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal, #sippaseModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela Alta De Los Datos De Incompatibilidad Funcionaria Y Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Valida Los Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    // Ejecuta Scripts
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar _MENU_ Registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando Registros del _START_ al _END_ de un total de _TOTAL_ Registros'," +
                    "'sInfoEmpty': 'Mostrando Registros del 0 al 0 de un total de 0 Registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ Registros)'," +
                    "'sInfoPostFix': ''," +
                    "'sSearch': 'Buscar:'," +
                    "'sUrl': ''," +
                    "'sInfoThousands': ','," +
                    "'sLoadingRecords': 'Cargando...'," +
                    "'oPaginate': {" +
                        "'sFirst': '«'," +
                        "'sLast': '»'," +
                        "'sNext': '<i class=\"fas fa-angle-right\"></i>'," +
                        "'sPrevious': '<i class=\"fas fa-angle-left\"></i>'" +
                    "}," +
                    "'oAria': {" +
                        "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                        "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                "}," +
                "'ordering': false," +
                "'searching': true," + // Permite mostrar/ocultar el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" + // Permite mostrar/ocultar el campo de información
            "});");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerDefault\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: \"es\"" +
                    "});" +
                "});" +
                "var me = $(\".datepickerDefault\");" +
                "me.mask(\"99/99/9999\");" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Limpia Los Campos
    private void Limpiar(string val)
    {
        if (val.Equals("sch_cl"))
        {
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
            //Txt_per_ap_casada_b.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
        }
        else if (val.Equals("gv_cl"))
        {
            Gv_busqueda_lista.DataSource = null;
            Gv_busqueda_lista.DataBind();
        }
        else if (val.Equals("frm_sip_cl"))
        {
            Txt_sip_descripcion_cert.Text = string.Empty;
            Txt_sip_fecha_cert.Text = string.Empty;
            Txt_sip_fecha_pres.Text = string.Empty;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}