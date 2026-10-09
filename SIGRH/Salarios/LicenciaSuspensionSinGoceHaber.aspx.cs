using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salarios_LSSinGoceHaber : System.Web.UI.Page
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
                CargaGVLicenciaSuspension();
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

    // Carga Datos En El GridView (Gv_lista_ls)
    //private void CargaGVLicenciaSuspension(string varId, string varCed, string varPat, string varMat, string varNom, string varPsId)
    private void CargaGVLicenciaSuspension()
    {
        try
        {
            _licencia_justificada = new cls_cp_licencia_justificada();
            //Gv_lista_ls.DataSource = _licencia_justificada.ObtenerTablaGrillaC(varId, varCed, varPat, varMat, varNom, varPsId);
            Gv_lista_ls.DataSource = _licencia_justificada.ObtenerTablaGrillaLS();
            Gv_lista_ls.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño Del GridView (Gv_lista_ls)
    protected void Gv_lista_ls_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_lista_ls.Rows.Count > 0)
        {
            if (Gv_lista_ls.HeaderRow != null) { Gv_lista_ls.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_lista_ls.FooterRow != null) { Gv_lista_ls.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Diseño Del GridView (Gv_lista_ls)
    protected void Gv_lista_ls_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) { return; }
        LinkButton btn_validar = (LinkButton)e.Row.FindControl("BtnValidar");
        var var_estado = e.Row.Cells[7].Text.Split('-');

        if (var_estado[1].Equals("P")) { btn_validar.Visible = true; }
        else if (var_estado[1].Equals("V")) { btn_validar.Visible = false; }
        e.Row.Cells[7].Text = var_estado[0];
    }

    // Evento Del GridView (Gv_lista_ls)
    protected void Gv_lista_ls_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = Gv_lista_ls.DataKeys[index].Values[0].ToString();
        string tipo = Gv_lista_ls.DataKeys[index].Values[1].ToString();

        if (e.CommandName.Equals("BtnValidar"))
        {
            if (tipo.Equals("41")) { P_lj_fechas_l.Visible = false; P_lj_fechas_s.Visible = true; }
            else { P_lj_fechas_l.Visible = true; P_lj_fechas_s.Visible = false; }
            Hf_lj_id.Value = code;
            Lt_lj_fecha_inicial.Text = Gv_lista_ls.Rows[index].Cells[4].Text;
            Lt_lj_fecha_final.Text = Gv_lista_ls.Rows[index].Cells[5].Text;
            Lt_lj_dias.Text = Gv_lista_ls.Rows[index].Cells[6].Text;
            CargaDatosFuncionario(Gv_lista_ls.Rows[index].Cells[0].Text);
            sc = "$('#validarModal').modal('show');";
        }
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Busca Registros De Acuerdo A Los Parámetros
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        //Hf_campos_b.Value = Txt_per_id_b.Text.Trim() + "," + Txt_per_num_doc_b.Text.Trim() + "," + Txt_per_ap_paterno_b.Text.Trim() + "," + Txt_per_ap_materno_b.Text.Trim() + "," + Txt_per_nombres_b.Text.Trim() + "," + Txt_ps_id.Text.Trim();
        //CargaGVLicenciaSuspension(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_ps_id.Text.Trim());
        //Limpiar("sch_cl");

        //if (Gv_lista_ls.Rows.Count > 0) { P_result.Visible = true; }
        //else
        //{
        //    P_result.Visible = false;
        //    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
        //}
        ////}
        //SetScript(sc, "");
    }

    // Alta De Los Datos De La Validación De La Sanción
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        var var_fecha_inicial = (P_lj_fechas_l.Visible) ? Lt_lj_fecha_inicial.Text : Txt_lj_fecha_inicial.Text.Trim();
        var var_fecha_final = (P_lj_fechas_l.Visible) ? Lt_lj_fecha_final.Text : Txt_lj_fecha_final.Text.Trim();
        _licencia_justificada = new cls_cp_licencia_justificada
        {
            lj_id = Convert.ToInt32(Hf_lj_id.Value),
            lj_fecha_inicial = Convert.ToDateTime(var_fecha_inicial),
            lj_fecha_final = Convert.ToDateTime(var_fecha_final)
        };
        _licencia_justificada.ActualizarLSBM();
        CargaGVLicenciaSuspension();
        Limpiar("frm_ls_cl");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro validado correctamente...!!' }, { type: 'success' }); $('#validarModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela La Alta De Los Datos De La Validación De La Sanción
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        var cpps_id = Hf_campos_b.Value.Split(',');
        //CargaGVLicenciaSuspension(cpps_id[0], cpps_id[1], cpps_id[2], cpps_id[3], cpps_id[4], cpps_id[5]);
        sc = "$('#validarModal').modal('hide');";
        SetScript(sc, "");
    }

    // Alta De Los Datos De La Desvalidación De La Sanción Y Los Datos De La Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        var cpps_id = Hf_campos_b.Value.Split(',');
        var codigo = Convert.ToInt32(Hf_lj_id_g.Value);
        _glosa = new cls_glosa
        {
            gl_valor_pk = codigo.ToString(),
            gl_nombre_pk = "lj_id",
            gl_tabla = "tbl_cp_licencia_justificada",
            gl_tipo_mov = 814,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        //CargaGVLicenciaSuspension(cpps_id[0], cpps_id[1], cpps_id[2], cpps_id[3], cpps_id[4], cpps_id[5]);
        Limpiar("frm_glosa_cl");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro anulado correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela La Alta De Los Datos De La Desvalidación De La Sanción Y Los Datos De La Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
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

    //// Obtener Proceso Actual
    //private string GetProceso()
    //{
    //    _proceso = new cls_pla_proceso();
    //    return _proceso.ObtenerTablaGrilla("", "", "", "", "", "", "", "", "V", "").Tables[0].Rows[0]["pc_id"].ToString();
    //}

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
            //Txt_per_id_b.Text = string.Empty;
            //Txt_per_num_doc_b.Text = string.Empty;
            //Txt_per_ap_paterno_b.Text = string.Empty;
            //Txt_per_ap_materno_b.Text = string.Empty;
            //Txt_per_nombres_b.Text = string.Empty;
            //Txt_ps_id.Text = string.Empty;
        }
        else if (val.Equals("frm_ls_cl"))
        {
            Txt_lj_fecha_inicial.Text = string.Empty;
            Txt_lj_fecha_final.Text = string.Empty;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}