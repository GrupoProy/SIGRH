using Newtonsoft.Json;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;

using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_ValidacionComisiones : System.Web.UI.Page
{
    private cls_historico _historico = null;
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
                Txt_lj_id.Focus();
                CargaGVValidacionLicencia(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString()));

                if (Gv_lista_lj_p.Rows.Count > 0) { P_lista_lj_p.Visible = true; }
                else { P_lista_lj_p.Visible = false; }
            }
        }
        else Response.Redirect("../Index");
    }

    // Carga La Información Del Funcionario
    private void CargaDatosFuncionario(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var data = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (data.Rows.Count > 0)
        {
            Lt_per_nombres.Text = ValidarCampo(data.Rows[0]["per_nombres"]) + " " + ValidarCampo(data.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(data.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(data.Rows[0]["per_num_doc"]) + " " + ValidarCampo(data.Rows[0]["cat_abreviacion"]);
            Lt_per_id.Text = ValidarCampo(data.Rows[0]["per_id"]);
            Lt_ca_num_item.Text = ValidarCampo(data.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(data.Rows[0]["ca_num_item"]);
            Lt_as_fecha_inicio.Text = Convert.ToDateTime(ValidarCampo(data.Rows[0]["as_fecha_inicio"])).ToString("dd/MM/yyyy");
            Lt_as_fecha_fin.Text = (ValidarCampo(data.Rows[0]["as_fecha_fin"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(data.Rows[0]["as_fecha_fin"])).ToString("dd/MM/yyyy");
            Lt_eo_descripcion.Text = ValidarCampo(data.Rows[0]["eo_descripcion"]);
            Lt_cp_descripcion.Text = ValidarCampo(data.Rows[0]["cp_descripcion"]);

            if (ValidarCampo(data.Rows[0]["as_estado"]).Equals("V"))
            {
                Lbl_as_estado.Text = "Vigente";
                Lbl_as_estado.CssClass = "btn btn-sm btn-info float-right";
            }
            else
            {
                Lbl_as_estado.Text = "Pasivo";
                Lbl_as_estado.CssClass = "btn btn-sm btn-secondary float-right";
            }

            if (ValidarCampo(data.Rows[0]["fp_foto"]) != "") { Img_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])data.Rows[0]["fp_foto"]); }
            else if (ValidarCampo(data.Rows[0]["per_sexo"]).Equals("M")) { Img_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg"; }
            else { Img_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg"; }
        }
    }

    // Carga Datos En El GridView (Gv_lista_lj_p o Gv_lista_lj_v)
    private void CargaGVValidacionLicencia(int per_id)
    {
        try
        {
            _licencia_justificada = new cls_cp_licencia_justificada();

            //if (par_lj_estado.Equals("P"))
            //{
            Gv_lista_lj_p.DataSource = _licencia_justificada.Grilla_ComisionesSolicitadas(per_id);
            Gv_lista_lj_p.DataBind();
            if (Gv_lista_lj_p.Rows.Count == 0)
                leyenda.Visible = true;

            //}
            //else
            //{
            //    Gv_lista_lj_v.DataSource = _licencia_justificada.ObtenerTablaGrillaC(par_lj_id, varId, varCed, varPat, varMat, varNom, "V");
            //    Gv_lista_lj_v.DataBind();
            //}
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Carga Datos En El DropDownList (Ddl_gl_tipo_doc)
    private void CargaDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo();
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaGrilla("", "tipo_documento_impreso", "", "", "", "", "", "", "", "V");
        Ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Diseño Del GridView (Gv_lista_lj_p)
    protected void Gv_lista_lj_p_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_lista_lj_p.Rows.Count > 0)
        {
            if (Gv_lista_lj_p.HeaderRow != null) { Gv_lista_lj_p.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_lista_lj_p.FooterRow != null) { Gv_lista_lj_p.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del GridView (Gv_lista_lj_p)
    protected void Gv_lista_lj_p_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = Gv_lista_lj_p.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("BtnValidar"))
        {
            VistaPreviaLicencia(code);
            sc = "$('#validarModal').modal('show');";
        }
        else if (e.CommandName.Equals("BtnGlosa"))
        {
            CargaDDLTipoDocumentoImpreso();
            Ddl_gl_tipo_doc.Enabled = false;
            Txt_gl_numero_doc.Enabled = false;
            Txt_gl_fecha_doc.Enabled = false;
            Txt_gl_glosa.Enabled = false;
            //BtnGuardarG.Visible = false;
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
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    //// Diseño Del GridView (Gv_lista_lj_v)
    //protected void Gv_lista_lj_v_PreRender(object sender, EventArgs e)
    //{
    //    base.OnPreRender(e);

    //    if (Gv_lista_lj_v.Rows.Count > 0)
    //    {
    //        if (Gv_lista_lj_v.HeaderRow != null) { Gv_lista_lj_v.HeaderRow.TableSection = TableRowSection.TableHeader; }
    //        if (Gv_lista_lj_v.FooterRow != null) { Gv_lista_lj_v.FooterRow.TableSection = TableRowSection.TableFooter; }
    //    }
    //}

    //// Evento Del GridView (Gv_lista_lj_v)
    //protected void Gv_lista_lj_v_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    int index = Convert.ToInt32(e.CommandArgument);
    //    string code = Gv_lista_lj_v.DataKeys[index].Value.ToString();

    //    if (e.CommandName.Equals("BtnDesvalidar"))
    //    {
    //        sc = "$('#desvalidarModal').modal('show');";
    //    }
    //    else if (e.CommandName.Equals("BtnGlosa"))
    //    {
    //        CargaDDLTipoDocumentoImpreso();
    //        Ddl_gl_tipo_doc.Enabled = false;
    //        Txt_gl_numero_doc.Enabled = false;
    //        Txt_gl_fecha_doc.Enabled = false;
    //        Txt_gl_glosa.Enabled = false;
    //        //BtnGuardarG.Visible = false;
    //        _glosa = new cls_glosa();
    //        var data = _glosa.ObtenerTablaGrilla("", code, "lj_id", "tbl_cp_licencia_Justificada", "", "", "", "", "", "V").Tables[0];

    //        if (data.Rows.Count > 0)
    //        {
    //            Ddl_gl_tipo_doc.SelectedValue = data.Rows[0]["gl_tipo_doc"].ToString().Trim();
    //            Txt_gl_numero_doc.Text = data.Rows[0]["gl_numero_doc"].ToString().Trim();
    //            Txt_gl_fecha_doc.Text = Convert.ToDateTime(data.Rows[0]["gl_fecha_doc"]).ToString("dd/MM/yyyy").Trim();
    //            Txt_gl_glosa.Text = data.Rows[0]["gl_glosa"].ToString().Trim();

    //            if (data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("2") || data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("3") || data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("6") || data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("8"))
    //            {
    //                P_gl_numero_doc.Visible = true;
    //                sc = "$('#D_gl_tipo_doc').removeClass('col-md-6'); $('#D_gl_tipo_doc').addClass('col-md-4'); $('#D_gl_fecha_doc').removeClass('col-md-6'); $('#D_gl_fecha_doc').addClass('col-md-4');";
    //            }
    //            else
    //            {
    //                P_gl_numero_doc.Visible = false;
    //                sc = "$('#D_gl_tipo_doc').removeClass('col-md-4'); $('#D_gl_tipo_doc').addClass('col-md-6'); $('#D_gl_fecha_doc').removeClass('col-md-4'); $('#D_gl_fecha_doc').addClass('col-md-6');";
    //            }
    //            sc += "$('#Txt_gl_fecha_doc').addClass('form-control'); $('#glosaModal').modal('show');";
    //        }
    //        else { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no tinene glosa...!!' }, { type: 'warning' });"; }
    //    }
    //    SetScript(sc, ", dropdownParent: $('#glosaModal')");
    //}

    //// Evento Del RadioButtonList (Rbl_lj_ped_val)
    //protected void Rbl_lj_ped_val_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    if (Rbl_lj_ped_val.SelectedValue.Equals("P")) { CargaGVValidacionLicencia("", "", "", "", "", "", "P"); }
    //    else if (Rbl_lj_ped_val.SelectedValue.Equals("V")) { CargaGVValidacionLicencia("", "", "", "", "", "", "V"); }
    //    SetScript("", "");
    //}

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

    // Busca Registros De Acuerdo A Los Parámetros
    //protected void BtnBuscar_Click(object sender, EventArgs e)
    //{
    //    //CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());

    //    if (Gv_lista_lj_p.Rows.Count > 0)
    //    {
    //        P_lista_lj_p.Visible = true;
    //        if (!string.IsNullOrEmpty(Txt_lj_id.Text))
    //        {
    //            CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), "", "", "", "", "", "P");

    //            if (Gv_lista_lj_p.Rows.Count > 0)
    //            {
    //                VistaPreviaLicencia(Txt_lj_id.Text.Trim());
    //                sc = "$('#validarModal').modal('show');";
    //            }
    //            else
    //            {
    //                CargaGVValidacionLicencia("", "", "", "", "", "", "P");
    //                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
    //            }
    //        }
    //        else
    //        {
    //            CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), "P");

    //            if (Gv_lista_lj_p.Rows.Count > 0) { P_lista_lj_p.Visible = true; }
    //            else
    //            {
    //                P_lista_lj_p.Visible = true;
    //                CargaGVValidacionLicencia("", "", "", "", "", "", "P");
    //                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
    //            }
    //        }
    //    }
    //    else
    //    {
    //        P_lista_lj_p.Visible = true;
    //        CargaGVValidacionLicencia("", "", "", "", "", "", "P");
    //        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
    //    }

    //    //if (Gv_lista_lj_v.Rows.Count > 0)
    //    //{
    //    //    P_lista_lj_v.Visible = true;
    //    //    if (!string.IsNullOrEmpty(Txt_lj_id.Text))
    //    //    {
    //    //        CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), "", "", "", "", "", "V");
    //    //        VistaPreviaLicencia(Txt_lj_id.Text.Trim());
    //    //        sc = "$('#desvalidarModal').modal('show');";
    //    //    }
    //    //    else
    //    //    {
    //    //        CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), "V");

    //    //        if (Gv_lista_lj_v.Rows.Count > 0) { P_lista_lj_v.Visible = true; }
    //    //        else
    //    //        {
    //    //            P_lista_lj_v.Visible = true;
    //    //            CargaGVValidacionLicencia("", "", "", "", "", "", "V");
    //    //            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
    //    //        }
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    P_lista_lj_v.Visible = true;
    //    //    CargaGVValidacionLicencia("", "", "", "", "", "", "V");
    //    //    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
    //    //}
    //    Limpiar("sch_cl");
    //    Txt_lj_id.Focus();
    //    SetScript(sc, "");
    //}

    // Alta De Los Datos De La Validación De La Sanción
    protected void BtnGuardarV_Click(object sender, EventArgs e)
    {
        _licencia_justificada = new cls_cp_licencia_justificada
        {
            lj_id = Convert.ToInt32(Hf_lj_id.Value),
            lj_estado = "A"
        };
        _licencia_justificada.Actualizar();
        var var_dt_lj = _licencia_justificada.ObtenerTablaGrilla(Hf_lj_id.Value, "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (var_dt_lj.Rows.Count > 0)
        {
            string json = JsonConvert.SerializeObject(var_dt_lj);
            AdicionarHistorico("A", "tbl__cp_licencia_justificada", "lj_id", Hf_lj_id.Value, json);
        }
        CargaGVValidacionLicencia(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString()));

        if (Gv_lista_lj_p.Rows.Count > 0) { P_lista_lj_p.Visible = true; }
        else { P_lista_lj_p.Visible = false; }
        Txt_lj_id.Focus();
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro validado correctamente...!!' }, { type: 'success' }); $('#validarModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela La Alta De Los Datos De La Validación De La Sanción
    protected void BtnCancelarV_Click(object sender, EventArgs e)
    {
        CargaGVValidacionLicencia(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString()));

        if (Gv_lista_lj_p.Rows.Count > 0) { P_lista_lj_p.Visible = true; }
        else { P_lista_lj_p.Visible = false; }
        Txt_lj_id.Focus();
        sc = "$('#validarModal').modal('hide');";
        SetScript(sc, "");
    }

    //// Alta De Los Datos De La Desvalidación De La Sanción Y Los Datos De La Glosa
    //protected void BtnGuardarG_Click(object sender, EventArgs e)
    //{
    //    var cpps_id = Hf_campos_b.Value.Split(',');
    //    var codigo = Convert.ToInt32(Hf_lj_id_g.Value);
    //    _glosa = new cls_glosa
    //    {
    //        gl_valor_pk = codigo.ToString(),
    //        gl_nombre_pk = "lj_id",
    //        gl_tabla = "tbl_cp_licencia_justificada",
    //        gl_tipo_mov = 814,
    //        gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
    //        gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
    //        gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
    //        gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
    //    };
    //    _glosa.Adicionar();
    //    CargaGVValidacionLicencia(cpps_id[0], cpps_id[1], cpps_id[2], cpps_id[3], cpps_id[4]);
    //    Limpiar("frm_glosa_cl");
    //    sc = "$.notify({ icon: 'fas fa-check', message: 'Registro anulado correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
    //    SetScript(sc, "");
    //}

    // Cancela La Alta De Los Datos De La Desvalidación De La Sanción Y Los Datos De La Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        P_gl_numero_doc.Visible = false;
        Ddl_gl_tipo_doc.Enabled = true;
        Txt_gl_numero_doc.Enabled = true;
        Txt_gl_fecha_doc.Enabled = true;
        Txt_gl_glosa.Enabled = true;
        //BtnGuardarG.Visible = true;
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Vista previa de los datos de la licencia
    private void VistaPreviaLicencia(string par_lj_id)
    {
        _licencia_justificada = new cls_cp_licencia_justificada();
        var var_dt_lj = _licencia_justificada.ObtenerTablaGrillaC(par_lj_id, "", "", "", "", "", "", "", "", "P").Tables[0];
        Hf_lj_id.Value = par_lj_id;

        if (var_dt_lj.Rows.Count > 0)
        {
            CargaDatosFuncionario(var_dt_lj.Rows[0]["per_id"].ToString());
            Lt_lj_tipo_licencia.Text = ValidarCampo(var_dt_lj.Rows[0]["cat_descripcion"]);
            Lt_lj_fecha_licencia.Text = ValidarCampo(var_dt_lj.Rows[0]["lj_fecha_licencia"]);
            Lt_lj_hora_licencia.Text = ValidarCampo(var_dt_lj.Rows[0]["lj_hora_licencia"]);
            Lt_lj_motivo.Text = ValidarCampo(var_dt_lj.Rows[0]["lj_motivo"]);
            Lt_lj_lugar.Text = ValidarCampo(var_dt_lj.Rows[0]["lj_lugar"]);
            
            //Lt_lj_per_id_autoriza.Text = ValidarCampo(var_dt_lj.Rows[0]["lj_per_id_autoriza"]);
        }
    }

    // Alta De Los Datos De La Sanción En Histórico
    private void AdicionarHistorico(string abm, string tabla, string nom_pk, string val_pk, string campos)
    {
        _historico = new cls_historico
        {
            his_tipo_abm = abm,
            his_nom_tabla = tabla,
            his_nom_pk = nom_pk,
            his_valor_pk = val_pk,
            his_campos = campos,
            his_usuario_creacion = Convert.ToInt32(Session["per_id"])
        };
        _historico.Adicionar();
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
                "'searching': true," + // Muestra/Oculta el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" + // Muestra/Oculta el campo información
            "});");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
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
            Txt_lj_id.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_numero_doc.Text = string.Empty;
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }

    protected void Gv_lista_lj_p_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType != DataControlRowType.DataRow) { return; }

        //if (e.Row.Cells[7].Text == "VALIDADO")
        //{
        //    LinkButton lnkBtnB = (LinkButton)e.Row.FindControl("BtnValidar");
        //    lnkBtnB.Visible = true;
        //}
    }
}