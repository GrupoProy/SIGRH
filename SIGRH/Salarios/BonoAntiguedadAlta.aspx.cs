using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salarios_BonoAntiguedadAlta : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_pla_cas _cas = null;
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
                BindGridView(id);

                if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
                else { P_lista.Visible = false; }
            }
        }
        else Response.Redirect("../Index");
    }

    // Cargar Datos
    private void BindForm(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];
        cls_pla_cas pla_cas = new cls_pla_cas();
        if (var_datos_as_c.Rows.Count > 0)
        {
            Lt_per_id.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_id"]);
            Lt_per_nombres.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_nombres"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_num_doc"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["cat_abreviacion"]);
            Lt_ca_num_item.Text = ValidarCampo(var_datos_as_c.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["ca_num_item"]);
            Lt_ca_basico_calculado.Text = pla_cas.ObtenerHaberBasico_3Minimos().ToString(); // Convert.ToDouble(ValidarCampo(var_datos_as_c.Rows[0]["ca_basico_calculado"])).ToString("N");
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
            ltl_jornada.Text = var_datos_as_c.Rows[0]["ca_tipo_jornada_lit"].ToString().Trim();

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

    // Cargar GridView
    private void BindGridView(string per_id)
    {
        try
        {
            _cas = new cls_pla_cas();
            GvLista.DataSource = _cas.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño GridView
    protected void GvLista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;
        var tip_reg = e.Row.Cells[4].Text.Split('-');
        var state = tip_reg[1];
        e.Row.Cells[4].Text = tip_reg[0];

        //if (!state.Equals("V"))
        //{
        //    LinkButton lnkBtn = (LinkButton)e.Row.FindControl("BtnEdit");
        //    lnkBtn.Visible = false;
        //}
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
            Txt_cs_meses.Enabled = true;
            Txt_cs_dias.Enabled = true;
            BtnGuardar.Visible = false;
            BtnEditar.Visible = true;
            BtnCancelar.Visible = true;
            _cas = new cls_pla_cas();
            var data = _cas.ObtenerTablaGrilla(code, "", "", "", "", "", "", "", "", "", "").Tables[0];
            Hf_cs_id.Value = code;
            Txt_cs_res_adm.Text = data.Rows[0]["cs_res_adm"].ToString();
            Txt_cs_nro_cas.Text = data.Rows[0]["cs_nro_cas"].ToString();
            lblFechaCas.Text= Convert.ToDateTime( data.Rows[0]["cs_fecha_cas"].ToString()).ToShortDateString();
            Txt_cs_fecha_cas.Visible = false;
            lblFechaCas.Visible = true;
            //Txt_cs_fecha_cas.Text = data.Rows[0]["cs_fecha_cas"].ToString();
            Txt_cs_anos.Text = data.Rows[0]["cs_anos"].ToString();
            Txt_cs_meses.Text = data.Rows[0]["cs_meses"].ToString();
            Txt_cs_dias.Text = data.Rows[0]["cs_dias"].ToString();
            var dataPB = _cas.ObtenerRegistroPB(Convert.ToInt32(data.Rows[0]["cs_anos"])).Tables[0];
            Txt_cs_porcentaje.Text = (Convert.ToDouble(dataPB.Rows[0]["ra_valor"]) * 100).ToString() + " %";
            Txt_cs_monto.Text = Math.Round(Convert.ToDouble(Lt_ca_basico_calculado.Text) * Convert.ToDouble(dataPB.Rows[0]["ra_valor"])).ToString();
        }
        SetScript(sc, "");
    }

    // Evento TextBox
    protected void Txt_cs_anos_TextChanged(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        BindGridView(id);

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }

        if (Convert.ToInt32(Txt_cs_anos.Text.Trim()) < 2 || Convert.ToInt32(Txt_cs_anos.Text.Trim()) > 65)
        {
            Txt_cs_meses.Enabled = false;
            Txt_cs_dias.Enabled = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Años) no puede ser menor a 2 años ó mayor a 65 años...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        Txt_cs_meses.Enabled = true;
        Txt_cs_dias.Enabled = true;

        if (!string.IsNullOrEmpty(Txt_cs_meses.Text) && !string.IsNullOrEmpty(Txt_cs_dias.Text))
        {
            _cas = new cls_pla_cas();
            var data = _cas.ObtenerRegistroPB(Convert.ToInt32(Txt_cs_anos.Text.Trim())).Tables[0];
            Txt_cs_porcentaje.Text = (Convert.ToDouble(data.Rows[0]["ra_valor"]) * 100).ToString() + " %";
            Txt_cs_monto.Text = Math.Round(Convert.ToDouble(Lt_ca_basico_calculado.Text) * Convert.ToDouble(data.Rows[0]["ra_valor"])).ToString();
        }
        SetScript("", "");
    }

    // Evento TextBox
    protected void Txt_cs_meses_TextChanged(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        BindGridView(id);

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }

        if (Convert.ToInt32(Txt_cs_anos.Text.Trim()) < 2 || Convert.ToInt32(Txt_cs_anos.Text.Trim()) > 65)
        {
            Txt_cs_meses.Enabled = false;
            Txt_cs_dias.Enabled = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Años) no puede ser menor a 2 años ó mayor a 65 años...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        Txt_cs_meses.Enabled = true;
        Txt_cs_dias.Enabled = true;

        if (Convert.ToInt32(Txt_cs_meses.Text.Trim()) >= 12)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Meses) no puede ser mayor o igual a 12 meses...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (!string.IsNullOrEmpty(Txt_cs_meses.Text) && !string.IsNullOrEmpty(Txt_cs_dias.Text))
        {
            _cas = new cls_pla_cas();
            var data = _cas.ObtenerRegistroPB(Convert.ToInt32(Txt_cs_anos.Text.Trim())).Tables[0];
            Txt_cs_porcentaje.Text = (Convert.ToDouble(data.Rows[0]["ra_valor"]) * 100).ToString() + " %";
            Txt_cs_monto.Text = Math.Round(Convert.ToDouble(Lt_ca_basico_calculado.Text) * Convert.ToDouble(data.Rows[0]["ra_valor"])).ToString();
        }
        SetScript("", "");
    }

    // Evento TextBox
    protected void Txt_cs_dias_TextChanged(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        BindGridView(id);

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }

        if (Convert.ToInt32(Txt_cs_anos.Text.Trim()) < 2 || Convert.ToInt32(Txt_cs_anos.Text.Trim()) > 65)
        {
            Txt_cs_meses.Enabled = false;
            Txt_cs_dias.Enabled = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Años) no puede ser menor a 2 años ó mayor a 65 años...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        Txt_cs_meses.Enabled = true;
        Txt_cs_dias.Enabled = true;

        if (Convert.ToInt32(Txt_cs_dias.Text.Trim()) > 31)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Días) no puede ser mayor a 31 días...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (!string.IsNullOrEmpty(Txt_cs_meses.Text) && !string.IsNullOrEmpty(Txt_cs_dias.Text))
        {
            _cas = new cls_pla_cas();
            var data = _cas.ObtenerRegistroPB(Convert.ToInt32(Txt_cs_anos.Text.Trim())).Tables[0];
            Txt_cs_porcentaje.Text = (Convert.ToDouble(data.Rows[0]["ra_valor"]) * 100).ToString() + " %";
            Txt_cs_monto.Text = Math.Round(Convert.ToDouble(Lt_ca_basico_calculado.Text) * Convert.ToDouble(data.Rows[0]["ra_valor"])).ToString();
        }
        SetScript("", "");
    }

    // Alta CAS (Bono Antigüedad)
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        _cas = new cls_pla_cas();
        var id = Request.QueryString["id"].ToString();
        var dataCAS = _cas.ObtenerTablaGrilla("", id, Txt_cs_res_adm.Text.Trim(), Txt_cs_nro_cas.Text.Trim(), Txt_cs_fecha_cas.Text.Trim(), Txt_cs_anos.Text.Trim(), Txt_cs_meses.Text.Trim(), Txt_cs_dias.Text.Trim(), "", "", "").Tables[0];
        var dataCAS_2 = _cas.ObtenerTablaGrilla("", id, "", "", "", "", "", "", "", "", "").Tables[0];
        BindGridView(id);

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }

        if (Convert.ToInt32(Txt_cs_anos.Text.Trim()) < 2 || Convert.ToInt32(Txt_cs_anos.Text.Trim()) > 65)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Años) no puede ser menor a 2 años ó mayor a 65 años...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (Convert.ToInt32(Txt_cs_meses.Text.Trim()) >= 12)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Meses) no puede ser mayor o igual a 12 meses...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (Convert.ToInt32(Txt_cs_dias.Text.Trim()) > 31)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Días) no puede ser mayor a 31 días...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (dataCAS.Rows.Count > 0)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los datos no se pueden guardar, ya existe un registro con los mismos parámetros...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (dataCAS_2.Rows.Count > 0)
        {
            if (Convert.ToInt32(dataCAS_2.Rows[0]["cs_anos"]) > Convert.ToInt32(Txt_cs_anos.Text.Trim()))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El tiempo de antigüedad debe ser mayor...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }

        if (dataCAS_2.Rows.Count > 0)
        {
            if (dataCAS_2.Rows[0]["cs_anos"].ToString().Equals(Txt_cs_anos.Text.Trim()))
            {
                if (Convert.ToInt32(dataCAS_2.Rows[0]["cs_meses"]) >= Convert.ToInt32(Txt_cs_meses.Text.Trim()))
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El tiempo de antigüedad debe ser mayor...!!' }, { type: 'warning' });";
                    SetScript(sc, "");
                    return;
                }
            }
        }
        BindDDLTipoDocumentoImpreso();
        Ddl_gl_tipo_doc.SelectedValue = "1914";
        Ddl_gl_tipo_doc.Enabled = false;
        sc = "$('#Ddl_gl_tipo_doc').removeClass('select2'); $('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Modificación CAS (Bono Antigüedad)
    protected void BtnEditar_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        _cas = new cls_pla_cas
        {
            cs_id = Convert.ToInt32(Hf_cs_id.Value),
            cs_res_adm = Txt_cs_res_adm.Text.ToUpper().Trim(),
            cs_nro_cas = Txt_cs_nro_cas.Text.ToUpper().Trim(),
            cs_fecha_cas = Convert.ToDateTime("01/01/2022"),// Convert.ToDateTime(Txt_cs_fecha_cas.Text.Trim()),
            cs_anos = Convert.ToInt32(Txt_cs_anos.Text.Trim()),
            cs_meses = Convert.ToInt32(Txt_cs_meses.Text.Trim()),
            cs_dias = Convert.ToInt32(Txt_cs_dias.Text.Trim())
        };
        _cas.Actualizar();
        BindGridView(id);
        Limpiar("frm_bono_cl");
        BtnGuardar.Visible = true;
        BtnEditar.Visible = false;
        BtnCancelar.Visible = false;
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro actualizado correctamente...!!' }, { type: 'success' });";
        SetScript(sc, "");
        Txt_cs_fecha_cas.Visible = true;
        lblFechaCas.Visible = false;
    }

    // Cancelar CAS (Bono Antigüedad)
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar("frm_bono_cl");
        Txt_cs_meses.Enabled = false;
        Txt_cs_dias.Enabled = false;
        BtnGuardar.Visible = true;
        BtnEditar.Visible = false;
        BtnCancelar.Visible = false;
        SetScript("", "");
    }

    // alta glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        _cas = new cls_pla_cas();
        _cas.ObtenerId();
        var id = Request.QueryString["id"].ToString();
        string tipo_reg = "";
        var _cs_id = _cas.cs_id;
        var data = _cas.ObtenerTablaGrilla("", id, "", "", "", "", "", "", "", "", "").Tables[0];

        if (data.Rows.Count > 0)
        {
            if (data.Rows[0]["cs_tipo_reg"].ToString().Equals("N") && data.Rows[0]["cs_estado"].ToString().Equals("V"))
            {
                BajaCAS(Convert.ToInt32(data.Rows[0]["cs_id"]));
                tipo_reg = "A";
            }
            else if (data.Rows[0]["cs_tipo_reg"].ToString().Equals("N") && data.Rows[0]["cs_estado"].ToString().Equals("C")) { tipo_reg = "R"; }
            else if (data.Rows[0]["cs_tipo_reg"].ToString().Equals("R") && data.Rows[0]["cs_estado"].ToString().Equals("V"))
            {
                BajaCAS(Convert.ToInt32(data.Rows[0]["cs_id"]));
                tipo_reg = "A";
            }
            else if (data.Rows[0]["cs_tipo_reg"].ToString().Equals("A") && data.Rows[0]["cs_estado"].ToString().Equals("V"))
            {
                BajaCAS(Convert.ToInt32(data.Rows[0]["cs_id"]));
                tipo_reg = "A";
            }
            else if (data.Rows[0]["cs_tipo_reg"].ToString().Equals("A") && data.Rows[0]["cs_estado"].ToString().Equals("C")) { tipo_reg = "R"; }
        }
        else tipo_reg = "N";
        _cas = new cls_pla_cas
        {
            cs_id = _cs_id,
            cs_per_id = Convert.ToInt32(id),
            cs_res_adm = Txt_cs_res_adm.Text.ToUpper().Trim(),
            cs_nro_cas = Txt_cs_nro_cas.Text.ToUpper().Trim(),
            cs_fecha_cas = Convert.ToDateTime(Txt_cs_fecha_cas.Text.Trim()),
            cs_anos = Convert.ToInt32(Txt_cs_anos.Text.Trim()),
            cs_meses = Convert.ToInt32(Txt_cs_meses.Text.Trim()),
            cs_dias = Convert.ToInt32(Txt_cs_dias.Text.Trim()),
            cs_tipo_reg = tipo_reg
        };
        _cas.Adicionar();
        _glosa = new cls_glosa
        {
            gl_valor_pk = _cs_id.ToString(),
            gl_nombre_pk = "cs_id",
            gl_tabla = "tbl_pla_cas",
            gl_tipo_mov = 813,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        BindGridView(id);

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }
        Limpiar("frm_bono_cl");
        Limpiar("frm_glosa_cl");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // cancelar alta glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        BindGridView(id);

        if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Baja CAS (Bono Antigüedad)
    private void BajaCAS(int val_id)
    {
        _cas = new cls_pla_cas
        {
            cs_id = val_id,
            cs_estado = "H"
        };
        _cas.Eliminar();
    }

    // Validar Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) campo = p_campo.ToString().Trim();
        return campo;
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
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" +
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
        if (val.Equals("frm_bono_cl"))
        {
            Txt_cs_res_adm.Text = string.Empty;
            Txt_cs_nro_cas.Text = string.Empty;
            Txt_cs_fecha_cas.Text = string.Empty;
            Txt_cs_anos.Text = string.Empty;
            Txt_cs_meses.Text = string.Empty;
            Txt_cs_dias.Text = string.Empty;
            Txt_cs_porcentaje.Text = string.Empty;
            Txt_cs_monto.Text = string.Empty;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}