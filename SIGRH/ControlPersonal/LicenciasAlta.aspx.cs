using Newtonsoft.Json.Linq;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_Licencias : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_cp_licencia_justificada _licencia_justificada = null;
    private cls_glosa _glosa = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                BindForm(id);
                CargaDDLTipoLicencia();
                BindGridViewL(id);
                CargaDDLInmediatoSuperior(id);
                if (GvListaL.Rows.Count > 0) { P_ListaL.Visible = true; }
                else { P_ListaL.Visible = false; }
            }
        }
        else Response.Redirect("../Index");
    }

    // Cargar Datos
    private void BindForm(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (var_datos_as_c.Rows.Count > 0)
        {
            Lt_per_id.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_id"]);
            Lt_per_nombres.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_nombres"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_num_doc"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["cat_abreviacion"]);
            Lt_ca_num_item.Text = ValidarCampo(var_datos_as_c.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["ca_num_item"]);
            Lt_ca_basico_calculado.Text = Convert.ToDouble(ValidarCampo(var_datos_as_c.Rows[0]["ca_basico_calculado"])).ToString("N");
            Lt_es_escalafon.Text = ValidarCampo(var_datos_as_c.Rows[0]["es_escalafon"]);
            Lt_ns_clase.Text = ValidarCampo(var_datos_as_c.Rows[0]["ns_clase"]);
            Lt_ns_nivel.Text = ValidarCampo(var_datos_as_c.Rows[0]["ns_nivel"]);
            Lt_as_fecha_inicio.Text = Convert.ToDateTime(ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_inicio"])).ToString("dd/MM/yyyy");
            Lt_as_fecha_fin.Text = (ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_fin"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_fin"])).ToString("dd/MM/yyyy");
            Lt_es_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["es_descripcion"]);
            Lt_p_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["p_descripcion"]);
            Lt_eo_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["eo_descripcion"]);
            Lt_eo_prog.Text = ValidarCampo(var_datos_as_c.Rows[0]["eo_prog"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_sprog"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_proy"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_obract"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_unidad"]);
            Lt_cp_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["cp_descripcion"]);
            Lt_cp_da.Text = ValidarCampo(var_datos_as_c.Rows[0]["cp_da"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_ue"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_programa"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_proyecto"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_actividad"]);

            if (ValidarCampo(var_datos_as_c.Rows[0]["as_estado"]).Equals("V"))
            {
                Lbl_as_estado.Text = "Vigente";
                Lbl_as_estado.CssClass = "btn btn-sm btn-info float-right";
            }
            else
            {
                Lbl_as_estado.Text = "Pasivo";
                Lbl_as_estado.CssClass = "btn btn-sm btn-secondary float-right";
            }

            if (ValidarCampo(var_datos_as_c.Rows[0]["fp_foto"]) != "") Img_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])var_datos_as_c.Rows[0]["fp_foto"]);
            else if (ValidarCampo(var_datos_as_c.Rows[0]["per_sexo"]).Equals("M")) Img_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg";
            else Img_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg";
        }
    }

    // Cargar GridView
    private void BindGridViewL(string par_per_id)
    {
        try
        {
            _licencia_justificada = new cls_cp_licencia_justificada();
            GvListaL.DataSource = _licencia_justificada.ObtenerTablaGrillaC("", par_per_id, "", "", "", "", "", "", "", "");
            GvListaL.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Cargar DropDownList
    private void CargaDDLTipoLicencia()
    {
        _catalogo = new cls_catalogo();
        Ddl_lj_tipo_licencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_lj_tipo_licencia.DataSource = _catalogo.ObtenerTablaGrilla("", "Tipo_Licencia", "", "1, 2, 14, 32, 34, 41", "", "", "", "", "", "V");
        Ddl_lj_tipo_licencia.DataValueField = "cat_id";
        Ddl_lj_tipo_licencia.DataTextField = "cat_descripcion";
        Ddl_lj_tipo_licencia.DataBind();
    }

    // Cargar DropDownList
    private void CargaDDLInmediatoSuperior(string per_id)
    {
        _licencia_justificada = new cls_cp_licencia_justificada { lj_per_id = Convert.ToInt32(per_id) };
        Ddl_lj_per_id_autoriza.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_lj_per_id_autoriza.DataSource = _licencia_justificada.AutoridadesParaValidarComisiones();
        Ddl_lj_per_id_autoriza.DataTextField = "NOMBRES";
        Ddl_lj_per_id_autoriza.DataValueField = "PER_ID_AUTORIDAD";
        Ddl_lj_per_id_autoriza.DataBind();
    }

    // Cargar DropDownList
    private void CargaDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo();
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaGrilla("", "tipo_documento_impreso", "", "", "", "", "", "", "", "V");
        Ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Diseño GridView
    protected void GvListaL_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvListaL.Rows.Count > 0)
        {
            if (GvListaL.HeaderRow != null) { GvListaL.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvListaL.FooterRow != null) { GvListaL.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento GridView
    protected void GvListaL_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvListaL.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("BtnGlosa"))
        {
            CargaDDLTipoDocumentoImpreso();
            Ddl_gl_tipo_doc.Enabled = false;
            Txt_gl_numero_doc.Enabled = false;
            Txt_gl_fecha_doc.Enabled = false;
            Txt_gl_glosa.Enabled = false;
            BtnGuardarG.Visible = false;
            _glosa = new cls_glosa();
            var data = _glosa.ObtenerTablaGrilla("", code, "lj_id", "tbl_cp_licencia_Justificada", "", "", "", "", "", "V").Tables[0];

            if (data.Rows.Count > 0)
            {
                Ddl_gl_tipo_doc.SelectedValue = data.Rows[0]["gl_tipo_doc"].ToString().Trim();
                Txt_gl_numero_doc.Text = data.Rows[0]["gl_numero_doc"].ToString().Trim();
                Txt_gl_fecha_doc.Text = Convert.ToDateTime(data.Rows[0]["gl_fecha_doc"]).ToString("dd/MM/yyyy").Trim();
                Txt_gl_glosa.Text = data.Rows[0]["gl_glosa"].ToString().Trim();

                if (data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("2") || data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("3") || data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("6") || data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("8"))
                {
                    P_gl_numero_doc.Visible = true;
                    sc = "$('#D_gl_tipo_doc').removeClass('col-md-6'); $('#D_gl_tipo_doc').addClass('col-md-4'); $('#D_gl_fecha_doc').removeClass('col-md-6'); $('#D_gl_fecha_doc').addClass('col-md-4');";
                }
                else
                {
                    P_gl_numero_doc.Visible = false;
                    sc = "$('#D_gl_tipo_doc').removeClass('col-md-4'); $('#D_gl_tipo_doc').addClass('col-md-6'); $('#D_gl_fecha_doc').removeClass('col-md-4'); $('#D_gl_fecha_doc').addClass('col-md-6');";
                }
                sc += "$('#Txt_gl_fecha_doc').addClass('form-control'); $('#glosaModal').modal('show');";
            }
            else { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no tinene glosa...!!' }, { type: 'warning' });"; }
        }
        else if (e.CommandName.Equals("BtnEliminar"))
        {
            Hf_lj_id.Value = code;
            sc = "$('#questionElModal').modal('show');";
        }
        SetScript(sc, ", dropdownParent: $('#addModal')");
    }

    // Evento Del DropDownList (Ddl_lj_tipo_licencia)
    protected void Ddl_lj_tipo_licencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        _catalogo = new cls_catalogo();
        Limpiar("frm_l_cl");
        Limpiar("frm_l_txt");
        var var_dat_tiplic = _catalogo.ObtenerTablaGrilla("", "Tipo_Licencia", Ddl_lj_tipo_licencia.SelectedValue, "", "", "", "", "", "", "V").Tables[0];

        if (var_dat_tiplic.Rows.Count > 0)
        {
            var var_ary = JArray.Parse(var_dat_tiplic.Rows[0]["cat_adicional"].ToString());
            var var_obj = JObject.Parse(var_ary[0].ToString());
            var var_ddl_tl = Ddl_lj_tipo_licencia.SelectedValue;
            Hf_dia.Value = string.Empty;

            if (!var_obj["dia"].ToString().Equals("A"))
            {
                if (!var_obj["dia"].ToString().Equals("I")) { Hf_dia.Value = var_obj["dia"].ToString(); }
            }

            if (var_obj["dia"].ToString().Equals("I"))
            {
                Txt_lj_fecha_final.Enabled = false;
                Rfv_lj_fecha_final.Enabled = false;
            }
            else
            {
                Txt_lj_fecha_final.Enabled = true;
                Rfv_lj_fecha_final.Enabled = true;
            }

            if (var_obj["tipo"].ToString().Equals("T"))
            {
                Txt_lj_hora_salida.Text = "00:01";
                Txt_lj_hora_retorno.Text = "23:59";
                Txt_lj_hora_salida.Enabled = false;
                Txt_lj_hora_retorno.Enabled = false;
            }
            else
            {
                Txt_lj_hora_salida.Text = string.Empty;
                Txt_lj_hora_retorno.Text = string.Empty;
                Txt_lj_hora_salida.Enabled = true;
                Txt_lj_hora_retorno.Enabled = true;
            }

            if (var_ddl_tl.Equals("8") || var_ddl_tl.Equals("9") || var_ddl_tl.Equals("18") || var_ddl_tl.Equals("21") || var_ddl_tl.Equals("25") || var_ddl_tl.Equals("36") || var_ddl_tl.Equals("37") || var_ddl_tl.Equals("38") || var_ddl_tl.Equals("39") || var_ddl_tl.Equals("40"))
            {
                sc = "$('#P_txt_lj_per_id_autoriza').removeClass('col-md-10'); $('#P_txt_lj_per_id_autoriza').addClass('col-md-12');";
                P_habilitar_txt.Visible = false;
                P_ddl_lj_per_id_autoriza.Visible = false;
                P_txt_lj_per_id_autoriza.Visible = true;
            }
            else
            {
                var id = Request.QueryString["id"].ToString();
                CargaDDLInmediatoSuperior(id);
                //P_habilitar_txt.Visible = true;
                P_ddl_lj_per_id_autoriza.Visible = false;
                P_txt_lj_per_id_autoriza.Visible = false;
            }
        }
        SetScript(sc, "");
    }

    // Evento del CheckBox (Chk_habilitar_txt)
    protected void Chk_habilitar_txt_CheckedChanged(object sender, EventArgs e)
    {
        if (Chk_habilitar_txt.Checked)
        {
            Limpiar("frm_l_txt");
            sc = "$('#P_txt_lj_per_id_autoriza').removeClass('col-md-12'); $('#P_txt_lj_per_id_autoriza').addClass('col-md-10');";
            P_ddl_lj_per_id_autoriza.Visible = false;
            P_txt_lj_per_id_autoriza.Visible = true;
        }
        else
        {
            var id = Request.QueryString["id"].ToString();
            CargaDDLInmediatoSuperior(id);
            P_ddl_lj_per_id_autoriza.Visible = false;
            P_txt_lj_per_id_autoriza.Visible = false;
        }
        SetScript(sc, "");
    }

    // Evento Del DropDownList (Ddl_gl_tipo_doc)
    protected void Ddl_gl_tipo_doc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_gl_tipo_doc.SelectedValue.Equals("2") || Ddl_gl_tipo_doc.SelectedValue.Equals("3") || Ddl_gl_tipo_doc.SelectedValue.Equals("6") || Ddl_gl_tipo_doc.SelectedValue.Equals("8"))
        {
            P_gl_numero_doc.Visible = true;
            sc = "$('#D_gl_tipo_doc').removeClass('col-md-6'); $('#D_gl_tipo_doc').addClass('col-md-4'); $('#D_gl_fecha_doc').removeClass('col-md-6'); $('#D_gl_fecha_doc').addClass('col-md-4');";
        }
        else
        {
            P_gl_numero_doc.Visible = false;
            sc = "$('#D_gl_tipo_doc').removeClass('col-md-4'); $('#D_gl_tipo_doc').addClass('col-md-6'); $('#D_gl_fecha_doc').removeClass('col-md-4'); $('#D_gl_fecha_doc').addClass('col-md-6');";
        }
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Guardar Licencia
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        var var_fecha_ini = Convert.ToDateTime(Txt_lj_fecha_inicial.Text.Trim());
        var var_ddl_tl = Ddl_lj_tipo_licencia.SelectedValue;

        if (var_ddl_tl.Equals("8") || var_ddl_tl.Equals("9") || var_ddl_tl.Equals("18") || var_ddl_tl.Equals("21") || var_ddl_tl.Equals("25") || var_ddl_tl.Equals("36") || var_ddl_tl.Equals("37") || var_ddl_tl.Equals("38") || var_ddl_tl.Equals("39") || var_ddl_tl.Equals("40")) { sc = "$('#P_txt_lj_per_id_autoriza').removeClass('col-md-10'); $('#P_txt_lj_per_id_autoriza').addClass('col-md-12');"; }

        if (!string.IsNullOrEmpty(Txt_lj_fecha_final.Text))
        {
            var var_fecha_fin = Convert.ToDateTime(Txt_lj_fecha_final.Text.Trim());

            if (var_fecha_ini > var_fecha_fin)
            {
                sc += "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA SALIDA) no puede ser mayor al campo (FECHA RETORNO)...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            if (!string.IsNullOrEmpty(Hf_dia.Value))
            {
                if (Hf_dia.Value.Equals("0.5") || Hf_dia.Value.Equals("1"))
                {
                    if (var_fecha_fin > var_fecha_ini)
                    {
                        sc += "$.notify({ icon: 'fas fa-exclamation', message: 'El rango máximo para la licencia es de: 1 día...!!' }, { type: 'warning' });";
                        SetScript(sc, "");
                        return;
                    }
                }
                else
                {
                    var var_dif_fecha = var_fecha_fin.Subtract(var_fecha_ini);

                    if (var_dif_fecha.Days > Convert.ToInt32(Hf_dia.Value))
                    {
                        sc += "$.notify({ icon: 'fas fa-exclamation', message: 'El rango máximo para la licencia es de: " + Hf_dia.Value + " día(s), revise las fechas...!!' }, { type: 'warning' });";
                        SetScript(sc, "");
                        return;
                    }
                }
            }
        }

        var id = Request.QueryString["id"].ToString();
        _licencia_justificada = new cls_cp_licencia_justificada();
        var var_dt_lj = _licencia_justificada.ObtenerTablaGrilla("", id, Ddl_lj_tipo_licencia.SelectedValue, Txt_lj_fecha_inicial.Text.Trim(), Txt_lj_fecha_final.Text.Trim(), "", "", "", "", "", "", "V").Tables[0];

        if (var_dt_lj.Rows.Count > 0)
        {
            sc += "$.notify({ icon: 'fas fa-exclamation', message: 'Los datos no se pueden guardar, ya existe un registro con los mismos parámetros...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (Ddl_lj_tipo_licencia.SelectedValue.Equals("1")) { sc += "$('#questionGlModal').modal('show');"; }
        else
        {
            CargaDDLTipoDocumentoImpreso();
            sc += "$('#glosaModal').modal('show');";
        }
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Guardar Pregunta Glosa
    protected void BtnGuardarQG_Click(object sender, EventArgs e)
    {
        CargaDDLTipoDocumentoImpreso();
        sc = "$('#questionGlModal').modal('hide'); $('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Cancelar Pregunta Glosa
    protected void BtnCancelarQG_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        AdicionarLicencia(id);
        Limpiar("frm_l_ddl");
        Limpiar("frm_l_cl");
        Limpiar("frm_l_txt");
        Limpiar("frm_l_hb");
        BindGridViewL(id);
        
        if (GvListaL.Rows.Count > 0) { P_ListaL.Visible = true; }
        else { P_ListaL.Visible = false; }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#questionGlModal').modal('hide');";
        SetScript(sc, "");
    }

    // Guardar Pregunta Anular
    protected void BtnGuardarQE_Click(object sender, EventArgs e)
    {
        CargaDDLTipoDocumentoImpreso();
        sc = "$('#questionElModal').modal('hide'); $('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Guardar Pregunta Cancelar
    protected void BtnCancelarQE_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        BindGridViewL(id);

        if (GvListaL.Rows.Count > 0) { P_ListaL.Visible = true; }
        else { P_ListaL.Visible = false; }
        sc = "$('#questionGlModal').modal('hide');";
        SetScript(sc, "");
    }

    // alta glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        int var_lj_id, var_tipo_mov;

        if (string.IsNullOrEmpty(Hf_lj_id.Value))
        {
            var_lj_id = AdicionarLicencia(id);
            var_tipo_mov = 813;
        }
        else
        {
            var_lj_id = Convert.ToInt32(Hf_lj_id.Value);
            var_tipo_mov = 814;
            _licencia_justificada = new cls_cp_licencia_justificada { lj_id = var_lj_id };
            _licencia_justificada.Eliminar();
        }
        _glosa = new cls_glosa
        {
            gl_valor_pk = var_lj_id.ToString(),
            gl_nombre_pk = "lj_id",
            gl_tabla = "tbl_cp_licencia_Justificada",
            gl_tipo_mov = var_tipo_mov,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_numero_doc = Txt_gl_numero_doc.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        Limpiar("frm_glosa_cl");
        Limpiar("frm_l_ddl");
        Limpiar("frm_l_cl");
        Limpiar("frm_l_txt");
        Limpiar("frm_l_hb");
        BindGridViewL(id);

        if (GvListaL.Rows.Count > 0) { P_ListaL.Visible = true; }
        else { P_ListaL.Visible = false; }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // cancelar alta glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        P_gl_numero_doc.Visible = false;
        Ddl_gl_tipo_doc.Enabled = true;
        Txt_gl_numero_doc.Enabled = true;
        Txt_gl_fecha_doc.Enabled = true;
        Txt_gl_glosa.Enabled = true;
        BtnGuardarG.Visible = true;
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Adiciona los datos de la licencia
    private int AdicionarLicencia(string par_per_id)
    {
        DateTime? var_fecha_fin = null;
        var var_per_id_autoriza = "";

        if (P_habilitar_txt.Visible)
        {
            if (Chk_habilitar_txt.Checked) { var_per_id_autoriza = Txt_lj_per_id_autoriza.Text.ToUpper().Trim(); }
            else { var_per_id_autoriza = Ddl_lj_per_id_autoriza.SelectedValue; }
        }
        else { var_per_id_autoriza = Txt_lj_per_id_autoriza.Text.ToUpper().Trim(); }

        _licencia_justificada = new cls_cp_licencia_justificada
        {
            lj_per_id = Convert.ToInt32(par_per_id),
            lj_tipo_licencia = Convert.ToInt32(Ddl_lj_tipo_licencia.SelectedValue),
            lj_fecha_inicial = Convert.ToDateTime(Txt_lj_fecha_inicial.Text.Trim()),
            lj_fecha_final = (string.IsNullOrEmpty(Txt_lj_fecha_final.Text)) ? var_fecha_fin : Convert.ToDateTime(Txt_lj_fecha_final.Text.Trim()),
            lj_hora_salida = Convert.ToDateTime(Txt_lj_hora_salida.Text.Trim()),
            lj_hora_retorno = Convert.ToDateTime(Txt_lj_hora_retorno.Text.Trim()),
            lj_motivo = Txt_lj_motivo.Text.ToUpper().Trim(),
            lj_lugar = Txt_lj_lugar.Text.ToUpper().Trim(),
            lj_per_id_autoriza = "0", //var_per_id_autoriza,
            lj_estado = "V"
        };
        return _licencia_justificada.Adicionar();
    }

    // Validar Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    // Ejecutar ScriptManager
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
                "'searching': true," + // Muestra/Oculta el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" + // Muestra/Oculta el campo información
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 .]+$/i, '');" +
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
        sb.Append("$(function () {" +
                "var me = $(\".timepickerD\");" +
                    "me.mask(\"99:99\");" +
                "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Limpiar
    private void Limpiar(string val)
    {
        if (val.Equals("frm_l_ddl")) { Ddl_lj_tipo_licencia.SelectedValue = "0"; }
        else if (val.Equals("frm_l_cl"))
        {
            Hf_lj_id.Value = string.Empty;
            Txt_lj_fecha_inicial.Text = string.Empty;
            Txt_lj_fecha_final.Text = string.Empty;
            Txt_lj_fecha_final.Text = string.Empty;
            Txt_lj_hora_salida.Text = string.Empty;
            Txt_lj_hora_retorno.Text = string.Empty;
            Txt_lj_motivo.Text = string.Empty;
            Txt_lj_lugar.Text = string.Empty;
            Txt_lj_fecha_final.Enabled = true;
            Txt_lj_hora_salida.Enabled = true;
            Txt_lj_hora_retorno.Enabled = true;
        }
        else if (val.Equals("frm_l_txt"))
        {
            Ddl_lj_per_id_autoriza.Items.Clear();
            Txt_lj_per_id_autoriza.Text = string.Empty;
        }
        else if (val.Equals("frm_l_hb"))
        {
            Chk_habilitar_txt.Checked = false;
            P_habilitar_txt.Visible = false;
            P_ddl_lj_per_id_autoriza.Visible = false;
            P_txt_lj_per_id_autoriza.Visible = false;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_numero_doc.Text = string.Empty;
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}