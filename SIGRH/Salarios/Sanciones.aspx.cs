using Newtonsoft.Json;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salarios_Sanciones : System.Web.UI.Page
{
    private cls_historico _historico = null;
    private cls_catalogo _catalogo = null;
    //private cls_pla_proceso _proceso = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_cp_sanciones _sancion = null;
    private cls_pla_factor _factor = null;
    private cls_glosa _glosa = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
            }
        }
        else Response.Redirect("../Index");
    }

    // Carga La Información Del Funcionario
    private void BindForm(string per_id)
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

    // Carga Datos En El DropDownList (gl_tipo_doc)
    private void BindDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_id";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Carga Datos En El GridView (GvLista)
    //private void BindGridView(string varCpDa, string varCpUe, string varCpPrograma, string varCpProyecto, string varCpActividad, string varPsId)
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom, string varPsId)
    {
        try
        {
            _sancion = new cls_cp_sanciones();
            //GvLista.DataSource = _sancion.ObtenerTablaGrillaC(varCpDa, varCpUe, varCpPrograma, varCpProyecto, varCpActividad, varPsId);
            GvLista.DataSource = _sancion.ObtenerTablaGrillaC(varId, varCed, varPat, varMat, varNom, varPsId);
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño Del GridView (GvLista)
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) { GvLista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvLista.FooterRow != null) { GvLista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Diseño Del GridView (GvLista)
    protected void GvLista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) { return; }
        LinkButton lnkBtnV = (LinkButton)e.Row.FindControl("BtnValidate");
        LinkButton lnkBtnI = (LinkButton)e.Row.FindControl("BtnInvalidate");
        //LinkButton lnkBtnD = (LinkButton)e.Row.FindControl("BtnDelete");
        var tip = e.Row.Cells[8].Text.Split('-');
        var est = e.Row.Cells[9].Text.Split('-');
        e.Row.Cells[8].Text = tip[0].ToString();
        e.Row.Cells[9].Text = est[0].ToString();

        if(tip[1].Equals("M") && est[1].Equals("P")) { lnkBtnI.Visible = false; }
        else if(tip[1].Equals("M") && est[1].Equals("V")) { lnkBtnV.Visible = false; }
        else if(tip[1].Equals("OM") && est[1].Equals("P")) { lnkBtnI.Visible = false; }
        else if(tip[1].Equals("OM") && est[1].Equals("V")) { lnkBtnV.Visible = false; }
        else if(tip[1].Equals("OB") && est[1].Equals("P")) { lnkBtnI.Visible = false; }
        else if(tip[1].Equals("OB") && est[1].Equals("V")) { lnkBtnV.Visible = false; }
    }

    // Evento Del GridView (GvLista)
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("GetValidate"))
        {
            _sancion = new cls_cp_sanciones();
            _factor = new cls_pla_factor();
            var dataS = _sancion.ObtenerRegistro(Convert.ToInt32(code)).Tables[0];
            var dataF = _factor.ObtenerRegistro(Convert.ToInt32(dataS.Rows[0]["sa_factor"].ToString())).Tables[0];
            Hf_sa_id.Value = code;
            BindForm(dataS.Rows[0]["sa_per_id"].ToString());
            Lt_fa_descripcion.Text = dataF.Rows[0]["fa_descripcion"].ToString().Trim();

            if (dataS.Rows[0]["sa_factor"].ToString().Equals("57"))
            {
                Lt_fa_descripcion.Text = Lt_fa_descripcion.Text + " (" + dataS.Rows[0]["sa_minutos"].ToString() + " min.)";
                Lt_sa_fecha.Text = (ValidarCampo(dataS.Rows[0]["sa_fecha_inicio"]).Equals("")) ? "" : Convert.ToDateTime(dataS.Rows[0]["sa_fecha_inicio"]).ToString("dd/MM/yyyy") + " - " + Convert.ToDateTime(dataS.Rows[0]["sa_fecha_fin"]).ToString("dd/MM/yyyy");
            }

            if (dataS.Rows[0]["sa_factor"].ToString().Equals("58"))
            {
                if (dataS.Rows[0]["sa_dias_sancion"].ToString().Equals("1")) { Lt_sa_fecha.Text = (ValidarCampo(dataS.Rows[0]["sa_fecha_inicio"]).Equals("")) ? "" : Convert.ToDateTime(dataS.Rows[0]["sa_fecha_inicio"]).ToString("dd/MM/yyyy"); }
                else { Lt_sa_fecha.Text = (ValidarCampo(dataS.Rows[0]["sa_fecha_inicio"]).Equals("")) ? "" : Convert.ToDateTime(dataS.Rows[0]["sa_fecha_inicio"]).ToString("dd/MM/yyyy") + " - " + Convert.ToDateTime(dataS.Rows[0]["sa_fecha_fin"]).ToString("dd/MM/yyyy"); }
            }

            if (dataS.Rows[0]["sa_factor"].ToString().Equals("59") || dataS.Rows[0]["sa_factor"].ToString().Equals("60")) { Lt_sa_fecha.Text = (ValidarCampo(dataS.Rows[0]["sa_fecha_inicio"]).Equals("")) ? "" : Convert.ToDateTime(dataS.Rows[0]["sa_fecha_inicio"]).ToString("dd/MM/yyyy"); }
            Lt_sa_dias_sancion.Text = dataS.Rows[0]["sa_dias_sancion"].ToString().Trim() + " día(s) de sanción";
            sc = "$('#validateModal').modal('show');";
        }
        else if (e.CommandName.Equals("GetInvalidate"))
        {
            var cpps_id = Hf_campos_b.Value.Split(',');
            _sancion = new cls_cp_sanciones
            {
                sa_id = Convert.ToInt32(code),
                sa_estado = "P"
            };
            _sancion.Actualizar();
            BindGridView(cpps_id[0], cpps_id[1], cpps_id[2], cpps_id[3], cpps_id[4], cpps_id[5]);
            sc = "$.notify({ icon: 'fas fa-check', message: 'Registro invalidado correctamente...!!' }, { type: 'success' });";
        }
        //else if (e.CommandName.Equals("GetDelete"))
        //{
        //    BindDDLTipoDocumentoImpreso();
        //    Hf_sa_id_g.Value = code;
        //    sc = "$('#glosaModal').modal('show');";
        //}
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Busca Registros De Acuerdo A Los Parámetros
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        //if (string.IsNullOrEmpty(Txt_cp_da.Text) && string.IsNullOrEmpty(Txt_cp_ue.Text) && string.IsNullOrEmpty(Txt_cp_programa.Text) && string.IsNullOrEmpty(Txt_cp_proyecto.Text) && string.IsNullOrEmpty(Txt_cp_actividad.Text) && string.IsNullOrEmpty(Txt_ps_id.Text)) { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });"; }
        //else
        //{
        //Hf_campos_b.Value = Txt_cp_da.Text.Trim() + "," + Txt_cp_ue.Text.Trim() + "," + Txt_cp_programa.Text.Trim() + "," + Txt_cp_proyecto.Text.Trim() + "," + Txt_cp_actividad.Text.Trim() + "," + Txt_ps_id.Text.Trim();
        Hf_campos_b.Value = Txt_per_id_b.Text.Trim() + "," + Txt_per_num_doc_b.Text.Trim() + "," + Txt_per_ap_paterno_b.Text.Trim() + "," + Txt_per_ap_materno_b.Text.Trim() + "," + Txt_per_nombres_b.Text.Trim() + "," + Txt_ps_id.Text.Trim();
        //BindGridView(Txt_cp_da.Text.Trim(), Txt_cp_ue.Text.Trim(), Txt_cp_programa.Text.Trim(), Txt_cp_proyecto.Text.Trim(), Txt_cp_actividad.Text.Trim(), Txt_ps_id.Text.Trim());
        BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_ps_id.Text.Trim());
        Limpiar("sch_cl");

        if (GvLista.Rows.Count > 0) { P_result.Visible = true; }
        else
        {
            P_result.Visible = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
        }
        //}
        SetScript(sc, "");
    }

    // Alta De Los Datos De La Validación De La Sanción
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        var cpps_id = Hf_campos_b.Value.Split(',');
        _sancion = new cls_cp_sanciones
        {
            sa_id = Convert.ToInt32(Hf_sa_id.Value),
            sa_estado = "V"
        };
        _sancion.Actualizar();
        _sancion = new cls_cp_sanciones();
        var dataS = _sancion.ObtenerTablaGrilla(Hf_sa_id.Value, "", "", "", "", "", "", "", "").Tables[0];

        if (dataS.Rows.Count > 0)
        {
            string json = JsonConvert.SerializeObject(dataS);
            AdicionarHistorico("A", "tbl_cp_sanciones", "sa_id", Hf_sa_id.Value, json);
        }
        BindGridView(cpps_id[0], cpps_id[1], cpps_id[2], cpps_id[3], cpps_id[4], cpps_id[5]);
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro validado correctamente...!!' }, { type: 'success' }); $('#validateModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela La Alta De Los Datos De La Validación De La Sanción
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        var cpps_id = Hf_campos_b.Value.Split(',');
        BindGridView(cpps_id[0], cpps_id[1], cpps_id[2], cpps_id[3], cpps_id[4], cpps_id[5]);
        sc = "$('#validateModal').modal('hide');";
        SetScript(sc, "");
    }

    // Nuevo Registro De Datos
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("SancionesBusqueda");
    }

    // Alta De Los Datos De La Desvalidación De La Sanción Y Los Datos De La Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        var cpps_id = Hf_campos_b.Value.Split(',');
        var codigo = Convert.ToInt32(Hf_sa_id_g.Value);
        _sancion = new cls_cp_sanciones { sa_id = codigo };
        _sancion.Eliminar();
        _glosa = new cls_glosa
        {
            gl_valor_pk = codigo.ToString(),
            gl_nombre_pk = "sa_id",
            gl_tabla = "tbl_cp_sanciones",
            gl_tipo_mov = 814,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        BindGridView(cpps_id[0], cpps_id[1], cpps_id[2], cpps_id[3], cpps_id[4], cpps_id[5]);
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
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
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

    // Limpia Los Campos
    private void Limpiar(string val)
    {
        if (val.Equals("sch_cl"))
        {
            //Txt_cp_da.Text = string.Empty;
            //Txt_cp_ue.Text = string.Empty;
            //Txt_cp_programa.Text = string.Empty;
            //Txt_cp_proyecto.Text = string.Empty;
            //Txt_cp_actividad.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
            Txt_ps_id.Text = string.Empty;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}