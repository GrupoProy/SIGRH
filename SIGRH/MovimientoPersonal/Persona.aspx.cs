using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Kardex.BussinessLogicLayer;
public partial class MovimientoPersonal_frmPersona : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_persona _persona = null;
    private cls_persona_familiares _familiar = null;
    private cls_glosa _glosa = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                sc = "CopiarCortarPegar(true);";
                SetScript(sc, "");
            }
        }
        else Response.Redirect("../Index");
    }

    // cargar form
    private void BindForm(string id)
    {
        _persona = new cls_persona();
        BindDDLTipoDocumentoPersonal();
        BindDDLLugarExpedido();
        BindDDLEstadoCivil();
        BindDDLProcedencia();
        BindDDLLugarNacimiento();
        BindGradoAcademico();
        BindGradoAcademicoEditar(Convert.ToInt32(id));
        BindCuaNua(Convert.ToInt32(id));

        var data = _persona.ObtenerRegistroX(Convert.ToInt32(id)).Tables[0];
        Txt_per_id.Text = data.Rows[0]["per_id"].ToString().Trim();
        Ddl_per_tipo_doc.SelectedValue = data.Rows[0]["per_tipo_doc"].ToString().Trim();
        Txt_per_num_doc.Text = data.Rows[0]["per_num_doc"].ToString().Trim();
        Ddl_per_lugar_exp.SelectedValue = data.Rows[0]["per_lugar_exp"].ToString().Trim();
        Txt_per_ap_paterno.Text = data.Rows[0]["per_ap_paterno"].ToString().Trim();
        Txt_per_ap_materno.Text = data.Rows[0]["per_ap_materno"].ToString().Trim();
        Txt_per_nombres.Text = data.Rows[0]["per_nombres"].ToString().Trim();
        Txt_per_ap_casada.Text = data.Rows[0]["per_ap_casada"].ToString().Trim();
        Rbl_per_sexo.SelectedValue = data.Rows[0]["per_sexo"].ToString().Trim();
        Txt_per_fecha_nac.Text = Convert.ToDateTime(data.Rows[0]["per_fecha_nac"]).ToString("dd/MM/yyyy").Trim();

        if (data.Rows[0]["per_procedencia"].ToString().Trim().Equals("1")) Ddl_per_lugar_nac.Enabled = true;
        Ddl_per_procedencia.SelectedValue = data.Rows[0]["per_procedencia"].ToString().Trim();
        string aux = data.Rows[0]["per_lugar_nac"].ToString().Trim();
        Ddl_per_lugar_nac.SelectedValue = data.Rows[0]["per_lugar_nac"].ToString().Trim();// (string.IsNullOrEmpty(data.Rows[0]["per_lugar_nac"].ToString())) ? "0" : data.Rows[0]["per_lugar_nac"].ToString().Trim();
        Ddl_per_estado_civil.SelectedValue = data.Rows[0]["per_estado_civil"].ToString().Trim();
    }
    private void BindCuaNua(int per_id) {
        cls_bs_afp afp = new cls_bs_afp();
        afp.afp_per_id = per_id;
        DataSet ds = afp.ObtenerRegistro();
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtNuaCua.Text = ds.Tables[0].Rows[0]["afp_nua"].ToString();
            hdf_nua.Value = txtNuaCua.Text;
        }

    }
    // cargar gridview
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom)
    {
        try
        {
            _persona = new cls_persona();
            GvLista.DataSource = _persona.ObtenerTablaGrilla(varId, "", varCed, "", varPat, varMat, varNom, "", "", "", "", "", "", "");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // cargar per_tipo_doc
    private void BindDDLTipoDocumentoPersonal()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_personal" };
        Ddl_per_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_tipo_doc.DataValueField = "cat_id";
        Ddl_per_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_per_tipo_doc.DataBind();
    }

    // cargar per_lugar_exp
    private void BindDDLLugarExpedido()
    {
        _catalogo = new cls_catalogo { cat_tabla = "departamento" };
        Ddl_per_lugar_exp.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_lugar_exp.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_lugar_exp.DataValueField = "cat_id";
        Ddl_per_lugar_exp.DataTextField = "cat_descripcion";
        Ddl_per_lugar_exp.DataBind();
    }

    // cargar per_procedencia
    private void BindDDLProcedencia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "pais" };
        Ddl_per_procedencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_procedencia.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_procedencia.DataValueField = "cat_id";
        Ddl_per_procedencia.DataTextField = "cat_descripcion";
        Ddl_per_procedencia.DataBind();
    }

    // cargar per_lugar_nac
    private void BindDDLLugarNacimiento()
    {
        _catalogo = new cls_catalogo();
        Ddl_per_lugar_nac.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_lugar_nac.DataSource = _catalogo.ObtenerLugarNacimiento();
        Ddl_per_lugar_nac.DataValueField = "id_ciudad";
        Ddl_per_lugar_nac.DataTextField = "lugar_nac";
        Ddl_per_lugar_nac.DataBind();
    }

    // cargar per_estado_civil
    private void BindDDLEstadoCivil()
    {
        _catalogo = new cls_catalogo { cat_tabla = "estado_civil" };
        Ddl_per_estado_civil.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_estado_civil.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_estado_civil.DataValueField = "cat_id";
        Ddl_per_estado_civil.DataTextField = "cat_descripcion";
        Ddl_per_estado_civil.DataBind();
    }

    // cargar gl_tipo_doc
    private void BindDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_id";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // cargar pf_tipo_parentesco
    private void BindDDLTipoParentesco()
    {
        _catalogo = new cls_catalogo { cat_tabla = "parentesco" };
        Ddl_pf_tipo_parentesco.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_pf_tipo_parentesco.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_pf_tipo_parentesco.DataValueField = "cat_secuencial";
        Ddl_pf_tipo_parentesco.DataTextField = "cat_descripcion";
        Ddl_pf_tipo_parentesco.DataBind();
    }

    // diseño gridview
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) GvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvLista.FooterRow != null) GvLista.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    // evento gridview
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("GetEdit"))
        {
            Session["per_id_edit"] = code;
            Response.Redirect("ActualizacionInformacionPersonal");
            //BindForm(code);
            //sc = "$('#editModal').modal('show');";
            //SetScript(sc, ", dropdownParent: $('#editModal')");
        }
        else if (e.CommandName.Equals("GetAddFam"))
        {
            _familiar = new cls_persona_familiares();
            var listFam = _familiar.ObtenerTablaGrilla("", code, "", "", "", "", "", "", "V", "", "").Tables[0].Rows.Count;
            Hf_per_id_f.Value = code;
            BindDDLTipoParentesco();

            if (listFam > 0)
            {
                BindGridViewFamily(code);
                sc = "$('#accordionF').css('display', 'block'); $('#familyModal').modal('show');";
            }
            else
            {
                Limpiar("gv_fam_cl");
                sc = "$('#accordionF').css('display', 'none'); $('#familyModal').modal('show');";
            }
            SetScript(sc, ", dropdownParent: $('#familyModal')");
        }
    }

    // evento per_procedencia
    protected void Ddl_per_procedencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_per_procedencia.SelectedValue.Equals("1"))
        {
            Ddl_per_lugar_nac.SelectedValue = "0";
            Ddl_per_lugar_nac.Enabled = true;
        }
        else
        {
            Ddl_per_lugar_nac.SelectedValue = "1822";
            Ddl_per_lugar_nac.Enabled = false;
        }
        SetScript("", ", dropdownParent: $('#editModal')");
    }

    // cargar gridview familiar
    private void BindGridViewFamily(string varId)
    {
        try
        {
            _familiar = new cls_persona_familiares();
            GvListaFamily.DataSource = _familiar.ObtenerTablaGrilla("", varId, "", "", "", "", "", "", "V", "", "");
            GvListaFamily.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // diseño gridview familiar
    protected void GvListaFamily_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvListaFamily.Rows.Count > 0)
        {
            if (GvListaFamily.HeaderRow != null) GvListaFamily.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvListaFamily.FooterRow != null) GvListaFamily.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    // evento gridview familiar
    protected void GvListaFamily_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvListaFamily.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("GetEdit")) { }
        else if (e.CommandName.Equals("GetDelete")) { }
        SetScript("", "");
    }

    // buscar
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text)  && string.IsNullOrEmpty(Txt_per_id_b.Text)) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });";
        else
        {
            BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());
            Limpiar("sch_cl");

            if (GvLista.Rows.Count > 0) sc = "$('#dResult').css('display', 'block');";
            else sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' }); $('#dResult').css('display', 'none');";
        }
        SetScript(sc, "");
    }

    // nuevo
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        sc = "$('#ciVerificacionModal').modal('show'); ";
        SetScript(sc, "");
        txtCIVerificacion.Focus();
    }

    // modificación
    protected void BtnGuardarM_Click(object sender, EventArgs e)
    {
        if (Ddl_per_procedencia.SelectedValue.Equals("1"))
        {
            if (Ddl_per_lugar_nac.SelectedValue.Equals("0"))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Lugar de Nacimiento) es obligatorio...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }
        _persona = new cls_persona();
        var listPer = _persona.ObtenerTablaGrilla(Txt_per_id.Text.Trim(), Ddl_per_tipo_doc.SelectedValue, Txt_per_num_doc.Text.ToUpper().Trim(), Ddl_per_lugar_exp.SelectedValue, Txt_per_ap_paterno.Text.ToUpper().Trim(), Txt_per_ap_materno.Text.ToUpper().Trim(), Txt_per_nombres.Text.ToUpper().Trim(), Txt_per_ap_casada.Text.ToUpper().Trim(), Rbl_per_sexo.SelectedValue, Txt_per_fecha_nac.Text.Trim(), Ddl_per_procedencia.SelectedValue, "", Ddl_per_lugar_nac.SelectedValue, Ddl_per_estado_civil.SelectedValue).Tables[0].Rows.Count;

        if (listPer > 0 &&  hdf_ef_id.Value==DdlFormacion.SelectedValue && hdf_nua.Value==txtNuaCua.Text) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no se puede actualizar, aún mantiene los mismos parámetros...!!' }, { type: 'warning' });";
        else
        {
            BindDDLTipoDocumentoImpreso();
            sc = " $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false); $('#glosaModal').modal('show');";
        }
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // cancelar modificación
    protected void BtnCancelarM_Click(object sender, EventArgs e)
    {
        Limpiar("frm_edit_cl");
        sc = "$('#editModal').modal('hide');$('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false);";
        SetScript(sc, "");
    }
    private void BindGradoAcademico()
    {
        cls_grado_academico grado_academico = new cls_grado_academico();
        DdlFormacion.Items.Insert(0, new ListItem("Seleccione...", "0"));
        DdlFormacion.DataSource = grado_academico.ObtenerGradoAcademico();
        DdlFormacion.DataValueField = "ga_id";
        DdlFormacion.DataTextField = "ga_nombre";
        DdlFormacion.DataBind();
    }
    private void BindGradoAcademicoEditar(int per_id)
    {
        cls_kd_respuesta_combo grado_academico = new cls_kd_respuesta_combo();
        grado_academico.ef_per_id = per_id;
        DataSet nivelFormacion = grado_academico.ObtenerNivelInstruccion(grado_academico);
        if (nivelFormacion.Tables[0].Rows.Count==0)
            DdlFormacion.SelectedIndex = 0;
        else
            DdlFormacion.SelectedValue = nivelFormacion.Tables[0].Rows[0]["ef_nivel_instruccion"].ToString();

        hdf_ef_id.Value = DdlFormacion.SelectedValue;
    }
    // alta familiar
    protected void BtnGuardarF_Click(object sender, EventArgs e)
    {
        _familiar = new cls_persona_familiares();
        var count = _familiar.ObtenerTablaGrilla("", Hf_per_id_f.Value, Ddl_pf_tipo_parentesco.SelectedValue, Txt_pf_paterno.Text.ToUpper().Trim(), Txt_pf_materno.Text.ToUpper().Trim(), Txt_pf_nombres.Text.ToUpper().Trim(), "", "", "", "", "").Tables[0].Rows.Count;

        if (count > 0)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los datos no se pueden guardar, ya existe un registro con los mismos parámetros...!!' }, { type: 'warning' }); $('#accordionF').css('display', 'block');";
            SetScript(sc, ", dropdownParent: $('#familyModal')");
            return;
        }
        _familiar = new cls_persona_familiares
        {
            pf_per_id = Convert.ToInt32(Hf_per_id_f.Value),
            pf_tipo_parentesco = Ddl_pf_tipo_parentesco.SelectedValue,
            pf_paterno = Txt_pf_paterno.Text.ToUpper().Trim(),
            pf_materno = Txt_pf_materno.Text.ToUpper().Trim(),
            pf_nombres = Txt_pf_nombres.Text.ToUpper().Trim(),
            pf_ap_esposo = Txt_pf_ap_esposo.Text.ToUpper().Trim()
        };
        _familiar.Adicionar();
        Limpiar("frm_fam");
        BindGridViewFamily(Hf_per_id_f.Value);
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#accordionF').css('display', 'block');";
        SetScript(sc, ", dropdownParent: $('#familyModal')");
    }

    // cancelar alta familiar
    protected void BtnCancelarF_Click(object sender, EventArgs e)
    {
        Limpiar("frm_fam_cl");
        Limpiar("gv_fam_cl");
        sc = "$('#familyModal').modal('hide');";
        SetScript(sc, "");
    }

    // alta glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        _persona = new cls_persona
        {
            per_id = Convert.ToInt32(Txt_per_id.Text.Trim()),
            per_tipo_doc = Convert.ToInt32(Ddl_per_tipo_doc.SelectedValue),
            per_num_doc = Txt_per_num_doc.Text.ToUpper().Trim(),
            per_lugar_exp = Convert.ToInt32(Ddl_per_lugar_exp.SelectedValue),
            per_ap_paterno = Txt_per_ap_paterno.Text.ToUpper().Trim(),
            per_ap_materno = Txt_per_ap_materno.Text.ToUpper().Trim(),
            per_nombres = Txt_per_nombres.Text.ToUpper().Trim(),
            per_ap_casada = Txt_per_ap_casada.Text.ToUpper().Trim(),
            per_sexo = Rbl_per_sexo.SelectedValue,
            per_fecha_nac = Convert.ToDateTime(Txt_per_fecha_nac.Text.Trim()),
            per_procedencia = Convert.ToInt32(Ddl_per_procedencia.SelectedValue),
            per_lugar_nac = Convert.ToInt32(Ddl_per_lugar_nac.SelectedValue),
            per_estado_civil = Convert.ToInt32(Ddl_per_estado_civil.SelectedValue)
            
        };
        _persona.Actualizar();
        
        cls_bs_afp afp = new cls_bs_afp();
        afp.afp_nua = txtNuaCua.Text;
        afp.afp_per_id = _persona.per_id;
        afp.ActualizarCuaNua(afp);

        cls_kd_respuesta_combo gradoAcademico = new cls_kd_respuesta_combo();
        gradoAcademico.ef_per_id = Convert.ToInt32(_persona.per_id);
        
        DataSet ds = gradoAcademico.ObtenerNivelInstruccion(gradoAcademico);
        if(ds.Tables[0].Rows.Count>0)
            gradoAcademico.ef_id=Convert.ToInt32(ds.Tables[0].Rows[0]["ef_id"].ToString());
        gradoAcademico.ef_nivel_instruccion = Convert.ToInt32(DdlFormacion.SelectedValue);
        gradoAcademico.ActualizarNivelInstruccion(gradoAcademico);

        _glosa = new cls_glosa
        {
            gl_valor_pk = Txt_per_id.Text.Trim(),
            gl_nombre_pk = "per_id",
            gl_tabla = "tbl_persona",
            gl_tipo_mov = 815,
            gl_fecha_doc = Convert.ToDateTime(txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        Limpiar("frm_edit_cl");
        Limpiar("frm_glosa_cl");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro actualizado correctamente...!!' }, { type: 'success' }); $('#glosaModal, #editModal').modal('hide');  $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false);";
        SetScript(sc, "");
    }

    // cancelar alta glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');  $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false);";
        SetScript(sc, "");
    }

    // ejecutar scriptmanager
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
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
                        "'sNext': '<i class=\"fas fa-angle-right\"></i>'," +
                        "'sPrevious': '<i class=\"fas fa-angle-left\"></i>'" +
                    "}," +
                    "'oAria': {" +
                        "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                        "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                "}," +
                "'ordering': false," +
                "'searching': true," +
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true" +
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
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: 'es'" +
                    "});" +
                "});" +
                "var me = $(\".datepickerD\");" +
                "me.mask('99/99/9999');" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // limpiar
    private void Limpiar(string val)
    {
        if (val.Equals("sch_cl"))
        {
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
        }
        else if (val.Equals("gv_cl"))
        {
            GvLista.DataSource = null;
            GvLista.DataBind();
        }
        else if (val.Equals("frm_edit_cl"))
        {
            Txt_per_id.Text = string.Empty;
            Ddl_per_tipo_doc.Items.Clear();
            Txt_per_num_doc.Text = string.Empty;
            Ddl_per_lugar_exp.Items.Clear();
            Txt_per_ap_paterno.Text = string.Empty;
            Txt_per_ap_materno.Text = string.Empty;
            Txt_per_nombres.Text = string.Empty;
            Txt_per_ap_casada.Text = string.Empty;
            Rbl_per_sexo.ClearSelection();
            Txt_per_fecha_nac.Text = string.Empty;
            Ddl_per_procedencia.Items.Clear();
            Ddl_per_lugar_nac.Items.Clear();
            Ddl_per_estado_civil.Items.Clear();
        }
        else if (val.Equals("frm_fam_cl"))
        {
            Ddl_pf_tipo_parentesco.Items.Clear();
            Txt_pf_paterno.Text = string.Empty;
            Txt_pf_materno.Text = string.Empty;
            Txt_pf_nombres.Text = string.Empty;
            Txt_pf_ap_esposo.Text = string.Empty;
        }
        else if (val.Equals("frm_fam"))
        {
            Ddl_pf_tipo_parentesco.SelectedIndex = 0;
            Txt_pf_paterno.Text = string.Empty;
            Txt_pf_materno.Text = string.Empty;
            Txt_pf_nombres.Text = string.Empty;
            Txt_pf_ap_esposo.Text = string.Empty;
        }
        else if (val.Equals("gv_fam_cl"))
        {
            GvListaFamily.DataSource = null;
            GvListaFamily.DataBind();
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            txt_gl_fecha_doc.Text = string.Empty;
            txt_gl_glosa.Text = string.Empty;
        }
    }

    protected void btnVerificarCi_Click(object sender, EventArgs e)
    {
        cls_persona persona = new cls_persona();
        if (persona.VerificarNuevoFuncionario(txtCIVerificacion.Text, 0).Tables[0].Rows.Count == 0)
        {
            Response.Redirect("PersonaAlta");
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-check', message: 'Existe ya un funcionario con ese número de documento, no es posible realizar el nuevo registro'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });  $('#ciVerificacionModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false);";
        }
        SetScript(sc, "");
        txtCIVerificacion.Text = "";
    }

    protected void btnCancelarVerificacionCI_Click(object sender, EventArgs e)
    {
        sc = "$('#ciVerificacionModal').modal('hide'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }
}