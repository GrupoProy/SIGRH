using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;

public partial class BienestarSocial_frmAsignacionBeneficio : System.Web.UI.Page
{
    private string sc = "";
    private cls_persona _persona = null;
    private cls_mp_asignacion _mp_asignacion = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa _glosa = null;
    private cls_persona_familiares _familiar = null;
    private cls_pla_factor _factor = null;
    private cls_bs_asignacion_beneficio _subsidio = null;

    private DateTime fechadesde;
    private DateTime fechahasta;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                sc = "CopiarCortarPegar(true);";
                SetScript(sc, "", "");
                BindDDLTipoTransaccion(Ddl_ab_fa_id);
                BindDDLTipoDoc();
                BindDDLMes();
            }
        }
        else Response.Redirect("../Index");
    }
    // cargar tr_fa_id
    private void BindDDLTipoTransaccion(DropDownList val)
    {
        _factor = new cls_pla_factor();
        val.Items.Insert(0, new ListItem("Seleccione...", "0"));
        val.DataSource = _factor.ObtenerTablaComboX("39,40");
        val.DataValueField = "fa_id";
        val.DataTextField = "fa_descripcion";
        val.DataBind();
    }
    private void SetScript(string val, string valS, string valD)
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
                "this.value = this.value.replace(/[^A-Z ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerDefault\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: 'es'" +
                    "});" +
                "});" +
                valD +
                "var me = $(\".datepickerDefault\");" +
                "me.mask('99/99/9999');" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Ayuda a buscar datos de la persona
    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        //limpiar
        Lt_as_estado.Text = "";

        if (string.IsNullOrEmpty(txt_per_num_doc.Text) && string.IsNullOrEmpty(txt_per_ap_paterno.Text) && string.IsNullOrEmpty(txt_per_ap_materno.Text) && string.IsNullOrEmpty(txt_per_nombres.Text) && string.IsNullOrEmpty(txt_per_ap_casada.Text) && string.IsNullOrEmpty(txt_per_id.Text))
        {
            sc = "$.notify('Debe ingresar algún parámetro de búsqueda...!!', 'warn');";
            SetScript(sc, "", "");
        }
        else
        {
            BindGrid(txt_per_id.Text.Trim(), txt_per_num_doc.Text.Trim(), txt_per_ap_paterno.Text.Trim(), txt_per_ap_materno.Text.Trim(), txt_per_nombres.Text.Trim(), txt_per_ap_casada.Text.Trim());
            Limpiar("sch_cl");
            if (gvLista.Rows.Count > 0)
            {
                sc = "$('#dResult').css('display', 'block');";
                SetScript(sc, "", "");
            }
            else
            {
                sc = "$.notify('No se ha encontrado el registro, revise los parámetros...!!', 'warn');";
                SetScript(sc, "", "");
            }
        }
        //Limpiar("frm_fam");
    }

    // Evento del griview de la tabla tbl_persona
    protected void gvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvLista.Rows.Count > 0)
        {
            if (gvLista.HeaderRow != null)
            {
                gvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvLista.FooterRow != null)
            {
                gvLista.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    // Carga el gridview con datos de la tabla tbl_persona
    private void BindGrid(string id, string ced, string pat, string mat, string nom, string cas)
    {
        try
        {
            _persona = new cls_persona();
            gvLista.DataSource = _persona.ObtenerTablaGrilla(id, "", ced, "", pat, mat, nom, cas, "", "", "", "", "", "");
            gvLista.DataBind();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    // Evento del griview de la tabla tbl_persona
    protected void gvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = gvLista.DataKeys[index].Value.ToString();
        if (e.CommandName.Equals("GetCodFun"))
        {
            BindUltimaAsignacionLaboral(Convert.ToInt16(code));

            if (Lt_as_estado.Text == "V")
            {
                BindForm(code);
                BindGridViewLBenef(code);

                Hf_per_id.Value = code;

                if (GvListaBenef.Rows.Count > 0)
                {
                    sc = "$('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                }
                else
                {
                    sc = "$('#addModal').modal('show'); $('#dGvLBenef').css('display', 'none');";
                }
            }
            else
            {
                sc = "$.notify('El funcionario no es vigente !!', 'warn');";
                SetScript(sc, "", "");
            }


            SetScript(sc, ", dropdownParent: $('#addModal')", "");
        }
    }

    // Cargar Ultima Asignacion Laboral de persona de la tabla tbl_mp_asignacion
    private void BindUltimaAsignacionLaboral(int p_ps_per_id)
    {
        DataSet ds = new DataSet();
        _mp_asignacion = new cls_mp_asignacion();
        ds = _mp_asignacion.ObtenerUltimaAsignacionLaboral(p_ps_per_id);
        Lt_as_estado.Text = ds.Tables[0].Rows[0]["as_estado"].ToString();
    }



    // Limpias los campos de los formularios
    private void Limpiar(string val)
    {
        // Limpiar el formulario de búsqueda
        if (val.Equals("sch_cl"))
        {
            txt_per_num_doc.Text = string.Empty;
            txt_per_ap_paterno.Text = string.Empty;
            txt_per_ap_materno.Text = string.Empty;
            txt_per_nombres.Text = string.Empty;
            txt_per_ap_casada.Text = string.Empty;
            txt_per_id.Text = string.Empty;
        }
        // Limpiar el gridview
        else if (val.Equals("gv_cl"))
        {
            gvLista.DataSource = null;
            gvLista.DataBind();
        }
        //Limpiar el formulario de glosa
        else if (val.Equals("fg_cl"))
        {
            txt_gl_glosa.Text = "";
            txt_gl_fecha_doc.Text = "";
            ddl_gl_tipo_doc.SelectedValue = "0";
            lblaccionglosa.Text = "";
        }
        //limpiar datos asignacion
        else if (val.Equals("da_cl"))
        {
            Ddl_ab_fa_id.SelectedValue = "0";
            Txt_ab_fecha_inicio.Text = string.Empty;
            Txt_ab_fecha_fin.Text = string.Empty;
            ltbeneficiario.Text = string.Empty;
            Lbl_mes_gestion.Text = string.Empty;
            btnfamiliares.Visible = false;

        }
    }

    // cargar datos
    private void BindForm(string per_id)
    {
        _mp_asignacion = new cls_mp_asignacion();
        var data = _mp_asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "V", "", "", "", "", "", "", "", "").Tables[0];

        if (data.Rows.Count > 0)
        {
            Lt_per_id.Text = data.Rows[0]["per_nombres"].ToString() + " " + data.Rows[0]["per_ap_paterno"].ToString() + " " + data.Rows[0]["per_ap_materno"].ToString();
            Lt_ci.Text = data.Rows[0]["per_num_doc"].ToString();
            Lt_ca_num_item.Text = data.Rows[0]["ca_ti_item"].ToString() + "-" + data.Rows[0]["ca_num_item"].ToString();
            Lt_as_fecha_inicio.Text = Convert.ToDateTime(data.Rows[0]["as_fecha_inicio"]).ToString("dd/MM/yyyy");
            Lt_as_fecha_fin.Text = (string.IsNullOrEmpty(data.Rows[0]["as_fecha_fin"].ToString())) ? "" : Convert.ToDateTime(data.Rows[0]["as_fecha_fin"]).ToString("dd/MM/yyyy");
            Lt_es_descripcion.Text = data.Rows[0]["es_descripcion"].ToString();
            Lt_sexo.Text = data.Rows[0]["per_sexo"].ToString();
        }
    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        lblaccionglosa.Text = "GUARDAR";
        sc = "$('#addGlosa').modal('show');";
        SetScript(sc, "", "");
    }
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Hf_ab_id.Value = "";
        Hf_pf_id.Value = "";
        Limpiar("da_cl");
        sc = "$('#addModal').modal('hide');";
        SetScript(sc, "", "");
    }

    protected void GvListaFamily_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string fnac, fdefunc;
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvListaFamily.DataKeys[index].Value.ToString();
        _familiar = new cls_persona_familiares();
        if (e.CommandName.Equals("Getpf_id"))
        {

            Hf_pf_id.Value = code;
            _familiar.ObtenerRegistro(Convert.ToInt32(code));
            if (String.IsNullOrEmpty(_familiar.pf_fecha_nac.ToString()))
            {
                fnac = string.Empty;
            }
            else
            {
                fnac = Convert.ToDateTime(_familiar.pf_fecha_nac).ToShortDateString();
            }
            if (String.IsNullOrEmpty(_familiar.pf_fecha_defuncion.ToString()))
            {
                fdefunc = string.Empty;
            }
            else
            {
                fdefunc = Convert.ToDateTime(_familiar.pf_fecha_defuncion).ToShortDateString();
            }


            ltbeneficiario.Text = "<b>Beneficiario Seleccionado:</b> " + _familiar.pf_paterno + " " + _familiar.pf_materno + " " + _familiar.pf_nombres;

            BindGridViewLBenef(Hf_per_id.Value);

            if (GvListaBenef.Rows.Count > 0)
            {
                sc = "$('#dGvLBenef').css('display', 'block'); $('#dGvBenef').modal('hide');";
            }
            else
            {
                sc = "$('#dGvLBenef').css('display', 'none'); $('#dGvBenef').modal('hide');";
            }

            SetScript(sc, ", dropdownParent: $('#addModal')", "");
        }
    }
    // Alta Licencia
    protected void BtnFamiliares_Click(object sender, EventArgs e)
    {
        _familiar = new cls_persona_familiares();
        var listFam = 0;

        if (Lt_sexo.Text.Trim() == "M" && Ddl_ab_fa_id.SelectedValue == "40")
        {
            listFam = _familiar.ObtenerTablaGrilla("", Hf_per_id.Value, "8,13,3", "", "", "", "", "", "V", "", "").Tables[0].Rows.Count;
        }

        else
        {
            listFam = _familiar.ObtenerTablaGrilla("", Hf_per_id.Value, "3", "", "", "", "", "", "V", "", "").Tables[0].Rows.Count;

        }
        if (listFam > 0)
        {

            BindGridViewLBenef(Hf_per_id.Value);

            if (GvListaBenef.Rows.Count > 0)
            {
                sc = "$('#dGvBenef').modal('show'); $('#dGvLBenef').css('display', 'block');";
            }
            else
            {
                sc = "$('#dGvBenef').modal('show'); $('#dGvLBenef').css('display', 'none');";
            }


        }
        else
        {
            BindGridViewLBenef(Hf_per_id.Value);

            if (GvListaBenef.Rows.Count > 0)
            {
                sc = "$.notify('No tiene Beneficiarios con ese tipo de parentezco...!!', 'warn'); $('#dGvLBenef').css('display', 'block');";
            }
            else
            {
                sc = "$.notify('No tiene Beneficiarios con ese tipo de parentezco...!!', 'warn'); $('#dGvLBenef').css('display', 'none');";
            }
        }
        SetScript(sc, ", dropdownParent: $('#addModal')", "");
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

    protected void Ddl_ab_fa_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        
            if (Ddl_ab_fa_id.SelectedValue == "39" || Ddl_ab_fa_id.SelectedValue == "40")
            {
                ddlmes.SelectedValue = "0";
                ddlmes.Visible = true;
            }
            else
            {
                ddlmes.Visible = false;
                ddlmes.SelectedValue = "0";
            }

            Txt_ab_fecha_inicio.Text = string.Empty;
            Txt_ab_fecha_fin.Text = string.Empty;
            ltbeneficiario.Text = string.Empty;
            Lbl_mes_gestion.Text = string.Empty;
            btnfamiliares.Visible = true;
        
        BindGridViewLBenef(Hf_per_id.Value);

        if (GvListaBenef.Rows.Count > 0)
        {
            sc = "$('#dGvLBenef').css('display', 'block');";
        }
        else
        {
            sc = "$('#dGvLBenef').css('display', 'none');";
        }
        SetScript(sc, ", dropdownParent: $('#addModal')", "");
    }

    protected void btnCancelarBeneficiario_Click(object sender, EventArgs e)
    {
        Hf_pf_id.Value = "";
        ltbeneficiario.Text = "";
        Lbl_mes_gestion.Text = "";
        sc = "$('#dGvBenef').modal('hide');";
        SetScript(sc, ", dropdownParent: $('#addModal')", "");
    }

    // Evento TextBox
    protected void Txt_ab_fecha_inicio_TextChanged(object sender, EventArgs e)
    {
        int dias, meses, anios;
        if (!string.IsNullOrEmpty(Txt_ab_fecha_fin.Text))
        {
            var fec_ini = Convert.ToDateTime(Txt_ab_fecha_inicio.Text.Trim());
            var fec_fin = Convert.ToDateTime(Txt_ab_fecha_fin.Text.Trim());

            if (fec_fin > fec_ini)
            {
                TimeSpan ts = fec_fin - fec_ini;
                anios = ts.Days / 365;
                meses = Convert.ToInt32((ts.Days - (anios * 365)) / 30.4167);
                dias = Convert.ToInt32((ts.Days - (anios * 365)) - (meses * 30.4167));
                Lbl_mes_gestion.Text = "";
                

                BindGridViewLBenef(Hf_per_id.Value);

                if (GvListaBenef.Rows.Count > 0)
                {
                    sc = "$('#dGvLBenef').css('display', 'block');";
                }
                else
                {
                    sc = "$('#dGvLBenef').css('display', 'none');";
                }
            }
            else
            {
                BindGridViewLBenef(Hf_per_id.Value);

                if (GvListaBenef.Rows.Count > 0)
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha Inico) no puede ser mayor que el campo (Fecha Fin)...!!' }, { type: 'warning' }); $('#dGvLBenef').css('display', 'block');";
                }
                else
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha Inico) no puede ser mayor que el campo (Fecha Fin)...!!' }, { type: 'warning' }); $('#dGvLBenef').css('display', 'none');";
                }
            }
        }
        else
        {
            BindGridViewLBenef(Hf_per_id.Value);

            if (GvListaBenef.Rows.Count > 0)
            {
                sc = "$('#dGvLBenef').css('display', 'block');";
            }
            else
            {
                sc = "$('#dGvLBenef').css('display', 'none');";
            }

        }


        SetScript(sc, ", dropdownParent: $('#addModal')", "");
    }

    // Evento TextBox
    protected void Txt_ab_fecha_fin_TextChanged(object sender, EventArgs e)
    {
        int dias, meses, anios;

        if (!string.IsNullOrEmpty(Txt_ab_fecha_inicio.Text))
        {
            var fec_ini = Convert.ToDateTime(Txt_ab_fecha_inicio.Text.Trim());
            var fec_fin = Convert.ToDateTime(Txt_ab_fecha_fin.Text.Trim());

            if (fec_fin > fec_ini)
            {
                TimeSpan ts = fec_fin - fec_ini;
                anios = ts.Days / 365;
                meses = Convert.ToInt32((ts.Days - (anios * 365)) / 30.4167);
                dias = Convert.ToInt32((ts.Days - (anios * 365)) - (meses * 30.4167));

                Lbl_mes_gestion.Text = "";

                BindGridViewLBenef(Hf_per_id.Value);

                if (GvListaBenef.Rows.Count > 0)
                {
                    sc = "$('#dGvLBenef').css('display', 'block');";
                }
                else
                {
                    sc = "$('#dGvLBenef').css('display', 'none');";
                }

            }
            else
            {
                BindGridViewLBenef(Hf_per_id.Value);

                if (GvListaBenef.Rows.Count > 0)
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha Inicio) no puede ser mayor que el campo (Fecha Fin)...!!' }, { type: 'warning' }); $('#dGvLBenef').css('display', 'block');";
                }
                else
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha Inico) no puede ser mayor que el campo (Fecha Fin)...!!' }, { type: 'warning' }); $('#dGvLBenef').css('display', 'none');";
                }
            }
        }
        else
        {
            BindGridViewLBenef(Hf_per_id.Value);

            if (GvListaBenef.Rows.Count > 0)
            {
                sc = "$('#dGvLBenef').css('display', 'block');";
            }
            else
            {
                sc = "$('#dGvLBenef').css('display', 'none');";
            }

        }

        SetScript(sc, ", dropdownParent: $('#addModal')", "");
    }

    // Registrar Glosa de los datos en la tabla tbl_glosa
    protected void btnRegistrarGlosa_Click(object sender, EventArgs e)
    {

        _subsidio = new cls_bs_asignacion_beneficio();
        _glosa = new cls_glosa();

        _familiar = new cls_persona_familiares();


        if (txt_gl_fecha_doc.Text != string.Empty && txt_gl_glosa.Text != string.Empty & ddl_gl_tipo_doc.SelectedValue != "0")
        {
            if (lblaccionglosa.Text == "GUARDAR")
            {
                fechadesde = Convert.ToDateTime(Txt_ab_fecha_inicio.Text.Trim());
                fechahasta = Convert.ToDateTime(Txt_ab_fecha_fin.Text.Trim());

                TimeSpan dif = fechahasta - fechadesde;
                Int32 totaldias;
                totaldias = Convert.ToInt32(dif.TotalDays);

                _subsidio.ObtenerId();

                if (Ddl_ab_fa_id.SelectedValue == "39")
                {
                    if (Hf_pf_id.Value != "")
                    {
                        //VERIFICAR Q NO SE DIFUNTO
                        _familiar.ObtenerRegistro(Convert.ToInt32(Hf_pf_id.Value));

                        if (_familiar.pf_estado_vivo == "D")
                        {
                            _subsidio.VerificarSubsidioenMes(Hf_per_id.Value, Ddl_ab_fa_id.SelectedValue, Txt_ab_fecha_inicio.Text, Txt_ab_fecha_fin.Text);


                            if (_subsidio.VerificarSubsidioenMes(Hf_per_id.Value, Ddl_ab_fa_id.SelectedValue, Txt_ab_fecha_inicio.Text, Txt_ab_fecha_fin.Text).Tables[0].Rows.Count > 0)
                            {
                                Limpiar("fg_cl");
                                BindGridViewLBenef(Hf_per_id.Value);

                                if (GvListaBenef.Rows.Count > 0)
                                {
                                    sc = "$.notify('Existe un subsidio registrado en el mes seleccionado !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                                }
                                else
                                {
                                    sc = "$.notify('Existe un subsidio registrado en el mes seleccionado !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'none');";
                                }
                                SetScript(sc, ", dropdownParent: $('#addModal')", "");
                            }
                            else
                            {
                                _subsidio.ab_aeb_id = Convert.ToInt32(Hf_pf_id.Value);
                                _subsidio.ab_tipo_beneficiario = "1";
                                _subsidio.ab_fa_id = Convert.ToInt32(Ddl_ab_fa_id.SelectedValue);
                                _subsidio.ab_fecha_inicio = Convert.ToString(Txt_ab_fecha_inicio.Text);
                                _subsidio.ab_fecha_fin = Convert.ToString(Txt_ab_fecha_fin.Text);
                                _subsidio.ab_estado = "V";

                                if (_subsidio.Adicionar())
                                {

                                    //insertar glosa
                                    _glosa.gl_valor_pk = Convert.ToString(_subsidio.ab_id);
                                    _glosa.gl_nombre_pk = "ab_id";
                                    _glosa.gl_tabla = "tbl_bs_asignacion_beneficio";
                                    _glosa.gl_tipo_mov = 813;
                                    _glosa.gl_fecha_doc = Convert.ToDateTime(txt_gl_fecha_doc.Text.Trim());
                                    _glosa.gl_tipo_doc = Convert.ToInt32(ddl_gl_tipo_doc.SelectedValue);
                                    _glosa.gl_glosa = txt_gl_glosa.Text.Trim().ToUpper();
                                    Session["id_usuario"] = "1";
                                    _glosa.gl_usuario = Convert.ToInt32(Session["id_usuario"]);
                                    _glosa.Adicionar();

                                    BindGridViewLBenef(Hf_per_id.Value);
                                    Limpiar("fg_cl");
                                    sc = "$.notify('Se ha registrado correctamente !!!', 'success'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                                    SetScript(sc, ", dropdownParent: $('#addModal')", "");

                                }
                                else
                                {
                                    Limpiar("fg_cl");
                                    sc = "$.notify('Error al registrar !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'none');";
                                    SetScript(sc, ", dropdownParent: $('#addModal')", "");

                                }

                            }

                        }
                        else
                        {
                            Limpiar("fg_cl");
                            BindGridViewLBenef(Hf_per_id.Value);

                            if (GvListaBenef.Rows.Count > 0)
                            {
                                sc = "$.notify('El Beneficiario NO debe ser uno VIVO para asignar subsidio !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                            }
                            else
                            {
                                sc = "$.notify('El Beneficiario NO debe ser uno VIVO para asignar subsidio !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'none');";
                            }
                            SetScript(sc, ", dropdownParent: $('#addModal')", "");

                        }



                    }
                    else
                    {
                        Limpiar("fg_cl");
                        BindGridViewLBenef(Hf_per_id.Value);

                        if (GvListaBenef.Rows.Count > 0)
                        {
                            sc = "$.notify('Debe Seleccionar un Beneficario !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                        }
                        else
                        {
                            sc = "$.notify('Debe Seleccionar un Beneficario !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'none');";
                        }
                        SetScript(sc, ", dropdownParent: $('#addModal')", "");
                    }
                }

                else if (Ddl_ab_fa_id.SelectedValue == "40")
                {
                    if (Hf_pf_id.Value != "")
                    {
                        //VERIFICAR Q NO SE DIFUNTO
                        _familiar.ObtenerRegistro(Convert.ToInt32(Hf_pf_id.Value));

                        if (_familiar.pf_estado_vivo == "V")
                        {
                            _subsidio.VerificarSubsidioenMes(Hf_per_id.Value, Ddl_ab_fa_id.SelectedValue, Txt_ab_fecha_inicio.Text, Txt_ab_fecha_fin.Text);
                            if (_subsidio.VerificarSubsidioenMes(Hf_per_id.Value, Ddl_ab_fa_id.SelectedValue, Txt_ab_fecha_inicio.Text, Txt_ab_fecha_fin.Text).Tables[0].Rows.Count > 0)
                            {
                                Limpiar("fg_cl");
                                BindGridViewLBenef(Hf_per_id.Value);

                                if (GvListaBenef.Rows.Count > 0)
                                {
                                    sc = "$.notify('Existe un subsidio registrado en el mes seleccionado !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                                }
                                else
                                {
                                    sc = "$.notify('Existe un subsidio registrado en el mes seleccionado !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'none');";
                                }
                                SetScript(sc, ", dropdownParent: $('#addModal')", "");
                            }
                            else
                            {
                                _subsidio.ab_aeb_id = Convert.ToInt32(Hf_pf_id.Value);
                                _subsidio.ab_tipo_beneficiario = "1";
                                _subsidio.ab_fa_id = Convert.ToInt32(Ddl_ab_fa_id.SelectedValue);
                                _subsidio.ab_fecha_inicio = Convert.ToString(Txt_ab_fecha_inicio.Text);
                                _subsidio.ab_fecha_fin = Convert.ToString(Txt_ab_fecha_fin.Text);
                                _subsidio.ab_estado = "V";
                                if (_subsidio.Adicionar())
                                {
                                    //insertar glosa
                                    _glosa.gl_valor_pk = Convert.ToString(_subsidio.ab_id);
                                    _glosa.gl_nombre_pk = "ab_id";
                                    _glosa.gl_tabla = "tbl_bs_asignacion_beneficio";
                                    _glosa.gl_tipo_mov = 813;
                                    _glosa.gl_fecha_doc = Convert.ToDateTime(txt_gl_fecha_doc.Text.Trim());
                                    _glosa.gl_tipo_doc = Convert.ToInt32(ddl_gl_tipo_doc.SelectedValue);
                                    _glosa.gl_glosa = txt_gl_glosa.Text.Trim().ToUpper();
                                    Session["id_usuario"] = "1";
                                    _glosa.gl_usuario = Convert.ToInt32(Session["id_usuario"]);
                                    _glosa.Adicionar();

                                    BindGridViewLBenef(Hf_per_id.Value);
                                    Limpiar("fg_cl");
                                    sc = "$.notify('Se ha registrado correctamente !!!', 'success'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                                    SetScript(sc, ", dropdownParent: $('#addModal')", "");
                                }
                                else
                                {
                                    Limpiar("fg_cl");
                                    sc = "$.notify('Error al registrar !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                                    SetScript(sc, ", dropdownParent: $('#addModal')", "");
                                }
                            }
                        }
                        else
                        {
                            Limpiar("fg_cl");
                            BindGridViewLBenef(Hf_per_id.Value);
                            if (GvListaBenef.Rows.Count > 0)
                            {
                                sc = "$.notify('El Beneficiario NO debe ser uno VIVO para asignar subsidio !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                            }
                            else
                            {
                                sc = "$.notify('El Beneficiario NO debe ser uno VIVO para asignar subsidio !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'none');";
                            }
                            SetScript(sc, ", dropdownParent: $('#addModal')", "");
                        }
                    }
                    else
                    {
                        Limpiar("fg_cl");
                        BindGridViewLBenef(Hf_per_id.Value);
                        if (GvListaBenef.Rows.Count > 0)
                        {
                            sc = "$.notify('Debe Seleccionar un Beneficario !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'block');";
                        }
                        else
                        {
                            sc = "$.notify('Debe Seleccionar un Beneficario !!!', 'warn'); $('#addGlosa').modal('hide');  $('#addModal').modal('show'); $('#dGvLBenef').css('display', 'none');";
                        }
                        SetScript(sc, ", dropdownParent: $('#addModal')", "");
                    }

                }
                Hf_pf_id.Value = "";
                Hf_ab_id.Value = "";
                Txt_ab_fecha_inicio.Text = string.Empty;
                Txt_ab_fecha_fin.Text = string.Empty;
                ltbeneficiario.Text = string.Empty;
                Lbl_mes_gestion.Text = string.Empty;
                btnfamiliares.Visible = false;
                Ddl_ab_fa_id.SelectedValue = "0";
            }
            else if (lblaccionglosa.Text == "ANULAR")
            {
                _subsidio.ab_id = Convert.ToInt32(Hf_ab_id.Value);
                _subsidio.ab_estado = "B";
                if (_subsidio.Eliminar())
                {
                    //insertar glosa
                    _glosa.gl_valor_pk = Convert.ToString(Hf_ab_id.Value);
                    _glosa.gl_nombre_pk = "ab_id";
                    _glosa.gl_tabla = "tbl_bs_asignacion_beneficio";
                    _glosa.gl_tipo_mov = 813;
                    _glosa.gl_fecha_doc = Convert.ToDateTime(txt_gl_fecha_doc.Text.Trim());
                    _glosa.gl_tipo_doc = Convert.ToInt32(ddl_gl_tipo_doc.SelectedValue);
                    _glosa.gl_glosa = txt_gl_glosa.Text.Trim().ToUpper();
                    Session["id_usuario"] = "1";
                    _glosa.gl_usuario = Convert.ToInt32(Session["id_usuario"]);
                    _glosa.Adicionar();
                    BindGridViewLBenef(Hf_per_id.Value);
                    Limpiar("fg_cl");
                    sc = "$.notify('Se ha anulado correctamente !!!', 'success'); $('#addGlosa').modal('hide');  $('#addModal').modal('hide');";
                    SetScript(sc, "", "");
                }
                else
                {

                    Limpiar("fg_cl");
                    sc = "$.notify('Error al registrar !!!', 'warn');";
                    SetScript(sc, "", "");
                }

            }
            else if (lblaccionglosa.Text == "CANCELAR")
            {
                _subsidio.ab_id = Convert.ToInt32(Hf_ab_id.Value);
                _subsidio.ab_estado = "C";
                if (_subsidio.Eliminar())
                {
                    //insertar glosa
                    _glosa.gl_valor_pk = Convert.ToString(Hf_ab_id.Value);
                    _glosa.gl_nombre_pk = "ab_id";
                    _glosa.gl_tabla = "tbl_bs_asignacion_beneficio";
                    _glosa.gl_tipo_mov = 815;
                    _glosa.gl_fecha_doc = Convert.ToDateTime(txt_gl_fecha_doc.Text.Trim());
                    _glosa.gl_tipo_doc = Convert.ToInt32(ddl_gl_tipo_doc.SelectedValue);
                    _glosa.gl_glosa = txt_gl_glosa.Text.Trim().ToUpper();
                    Session["id_usuario"] = "1";
                    _glosa.gl_usuario = Convert.ToInt32(Session["id_usuario"]);
                    _glosa.Adicionar();
                    BindGridViewLBenef(Hf_per_id.Value);
                    Limpiar("fg_cl");
                    sc = "$.notify('Se ha cancelado correctamente !!!', 'success'); $('#addGlosa').modal('hide');  $('#addModal').modal('show');";
                    SetScript(sc, "", "");
                }
                else
                {

                    Limpiar("fg_cl");
                    sc = "$.notify('Error al registrar !!!', 'warn');";
                    SetScript(sc, "", "");
                }

            }
            else if (lblaccionglosa.Text == "ACTIVAR")
            {
                _subsidio.ab_id = Convert.ToInt32(Hf_ab_id.Value);
                _subsidio.ab_estado = "V";
                if (_subsidio.Eliminar())
                {

                    //insertar glosa
                    _glosa.gl_valor_pk = Convert.ToString(Hf_ab_id.Value);
                    _glosa.gl_nombre_pk = "ab_id";
                    _glosa.gl_tabla = "tbl_bs_asignacion_beneficio";
                    _glosa.gl_tipo_mov = 815;
                    _glosa.gl_fecha_doc = Convert.ToDateTime(txt_gl_fecha_doc.Text.Trim());
                    _glosa.gl_tipo_doc = Convert.ToInt32(ddl_gl_tipo_doc.SelectedValue);
                    _glosa.gl_glosa = txt_gl_glosa.Text.Trim().ToUpper();
                    Session["id_usuario"] = "1";
                    _glosa.gl_usuario = Convert.ToInt32(Session["id_usuario"]);
                    _glosa.Adicionar();
                    BindGridViewLBenef(Hf_per_id.Value);
                    Limpiar("fg_cl");
                    sc = "$.notify('Se ha activado correctamente !!!', 'success'); $('#addGlosa').modal('hide');  $('#addModal').modal('show');";
                    SetScript(sc, "", "");
                }
                else
                {

                    Limpiar("fg_cl");
                    sc = "$.notify('Error al registrar !!!', 'warn');";
                    SetScript(sc, "", "");
                }
            }
        }
    }

    // Cancelar el registro de los datos en la tabla tbl_glosa
    protected void btnCancelarGlosa_Click(object sender, EventArgs e)
    {
        Hf_ab_id.Value = "";
        Limpiar("fg_cl");

        BindGridViewLBenef(Hf_per_id.Value);

        if (GvListaBenef.Rows.Count > 0)
        {
            sc = "$('#addGlosa').modal('hide'); $('#dGvLBenef').css('display', 'block');";
        }
        else
        {
            sc = "$('#addGlosa').modal('hide'); $('#dGvLBenef').css('display', 'none');";
        }
        SetScript(sc, "", "");
    }

    // Carga el dropdownlist tipo documento con datos de la tabla catalogo
    private void BindDDLTipoDoc()
    {
        try
        {
            _catalogo = new cls_catalogo();
            _catalogo.cat_tabla = "tipo_documento_impreso";

            ddl_gl_tipo_doc.Items.Insert(0, new ListItem("-- Seleccione --", "0"));
            ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
            ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
            ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
            ddl_gl_tipo_doc.DataBind();

        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    // evento gridview
    protected void GvListaBenef_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        _subsidio = new cls_bs_asignacion_beneficio();

        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvListaBenef.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("Getab_id_eliminar"))
        {
            Hf_ab_id.Value = code;

            lblaccionglosa.Text = "ANULAR";
            sc = "$('#addGlosa').modal('show'); $('#dGvLBenef').css('display', 'block');";
        }
        if (e.CommandName.Equals("Getab_id"))
        {
            Hf_ab_id.Value = code;
            _subsidio.ab_id = Convert.ToInt32(code);
            _subsidio.ObtenerRegistro(Convert.ToInt32(code));
            if (_subsidio.ab_estado == "V")
                lblaccionglosa.Text = "CANCELAR";
            else if (_subsidio.ab_estado == "C")
                lblaccionglosa.Text = "ACTIVAR";


            sc = "$('#addGlosa').modal('show'); $('#dGvLBenef').css('display', 'block');";
        }

        SetScript(sc, ", dropdownParent: $('#addModal')", "$('.datepicker').datepicker('setDate', 'today');");
    }

    // diseño gridview
    protected void GvListaBenef_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvListaBenef.Rows.Count > 0)
        {
            if (GvListaBenef.HeaderRow != null) GvListaBenef.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvListaBenef.FooterRow != null) GvListaBenef.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    // Cargar GridView
    private void BindGridViewLBenef(string per_id)
    {
       
            _subsidio = new cls_bs_asignacion_beneficio();
            GvListaBenef.DataSource = _subsidio.ListarBenef(Convert.ToInt32(per_id));
            GvListaBenef.DataBind();
    }

    // Carga el dropdownlist tipo documento con datos de la tabla catalogo
    private void BindDDLMes()
    {
        try
        {
            _catalogo = new cls_catalogo();
            _catalogo.cat_tabla = "mes";

            ddlmes.Items.Insert(0, new ListItem("-- Seleccione --", "0"));

            DataSet ds = new DataSet();

            ds = _catalogo.ObtenerTablaCombo();

            DataView dvs = ds.Tables[0].DefaultView;
            dvs.Sort = "cat_secuencial";

            ddlmes.DataSource = dvs;
            ddlmes.DataValueField = "cat_secuencial";
            ddlmes.DataTextField = "cat_descripcion";
            ddlmes.DataBind();

        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void ddlmes_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlmes.SelectedValue == "10" || ddlmes.SelectedValue == "11" || ddlmes.SelectedValue == "12")
        {
            Txt_ab_fecha_inicio.Text = "01/" + ddlmes.SelectedValue + "/" + DateTime.Now.Year;
            Txt_ab_fecha_fin.Text = DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ddlmes.SelectedValue)) + "/" + ddlmes.SelectedValue + "/" + DateTime.Now.Year;
        }
        else
        {
            Txt_ab_fecha_inicio.Text = "01/" + "0" + ddlmes.SelectedValue + "/" + DateTime.Now.Year;
            Txt_ab_fecha_fin.Text = DateTime.DaysInMonth(DateTime.Now.Year, Convert.ToInt32(ddlmes.SelectedValue)) + "/0" + ddlmes.SelectedValue + "/" + DateTime.Now.Year;
        }
        BindGridViewLBenef(Hf_per_id.Value);

        if (GvListaBenef.Rows.Count > 0)
        {
            sc = "$('#dGvLBenef').css('display', 'block');";
        }
        else
        {
            sc = "$('#dGvLBenef').css('display', 'none');";
        }
        SetScript(sc, ", dropdownParent: $('#addModal')", "");
    }
}