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

public partial class ControlPersonal_ValidacionLicenciaJustificada : System.Web.UI.Page
{
    private cls_historico _historico = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_cp_licencia_justificada _licencia_justificada = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                Txt_lj_id.Focus();
                CargaGVValidacionLicencia("", "", "", "", "", "", "P");

                if (Gv_lista_lj_p.Rows.Count > 0) { P_lista_lj_p.Visible = true; }
                else { P_lista_lj_p.Visible = false; }
            }
        }
        else Response.Redirect("../Index");
    }

    

    private void Compartido()
    {
        string trimmedInput = codigoComisionInput.Text.Trim();
        if (Int32.TryParse(trimmedInput, out int codigoComision))
        {
            _licencia_justificada = new cls_cp_licencia_justificada();
            _licencia_justificada.ActualizarLC(codigoComision);

            string script = $"showModalAndClearInput('{codigoComision}');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", script, true);

            codigoComisionInput.Text = "";
        }
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
    private void CargaGVValidacionLicencia(string par_lj_id, string varId, string varCed, string varPat, string varMat, string varNom, string par_lj_estado)
    {
        try
        {
            _licencia_justificada = new cls_cp_licencia_justificada();

            //if (par_lj_estado.Equals("P"))
            //{
                Gv_lista_lj_p.DataSource = _licencia_justificada.ObtenerTablaGrillaC(par_lj_id, varId, varCed, varPat, varMat, varNom, "", "", "", "P");
                Gv_lista_lj_p.DataBind();
            //}
            //else
            //{
            //    Gv_lista_lj_v.DataSource = _licencia_justificada.ObtenerTablaGrillaC(par_lj_id, varId, varCed, varPat, varMat, varNom, "V");
            //    Gv_lista_lj_v.DataBind();
            //}
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño del listado de licencias pendientes
    protected void Gv_lista_lj_p_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_lista_lj_p.Rows.Count > 0)
        {
            if (Gv_lista_lj_p.HeaderRow != null)
                Gv_lista_lj_p.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (Gv_lista_lj_p.FooterRow != null)
                Gv_lista_lj_p.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    // El botón verde abre la licencia para aprobarla.
    // El botón azul abre exactamente los mismos datos en modo de solo lectura.
    protected void Gv_lista_lj_p_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        if (!int.TryParse(e.CommandArgument.ToString(), out index) ||
            index < 0 || index >= Gv_lista_lj_p.Rows.Count ||
            Gv_lista_lj_p.DataKeys[index] == null)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo identificar la licencia seleccionada.' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        string code = Gv_lista_lj_p.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("BtnValidar"))
        {
            if (VistaPreviaLicencia(code))
            {
                ConfigurarModalLicencia(true);
                sc = "$('#validarModal').modal('show');";
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se encontraron los datos de la licencia.' }, { type: 'warning' });";
            }
        }
        else if (e.CommandName.Equals("BtnVer"))
        {
            if (VistaPreviaLicencia(code))
            {
                ConfigurarModalLicencia(false);
                sc = "$('#validarModal').modal('show');";
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se encontraron los datos de la licencia.' }, { type: 'warning' });";
            }
        }

        SetScript(sc, "");
    }

    // Busca Registros De Acuerdo A Los Parámetros
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        //CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());

        if (Gv_lista_lj_p.Rows.Count > 0)
        {
            P_lista_lj_p.Visible = true;
            if (!string.IsNullOrEmpty(Txt_lj_id.Text))
            {
                CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), "", "", "", "", "", "P");

                if (Gv_lista_lj_p.Rows.Count > 0)
                {
                    if (VistaPreviaLicencia(Txt_lj_id.Text.Trim()))
                    {
                        ConfigurarModalLicencia(true);
                        sc = "$('#validarModal').modal('show');";
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se encontraron los datos de la licencia.' }, { type: 'warning' });";
                    }
                }
                else
                {
                    CargaGVValidacionLicencia("", "", "", "", "", "", "P");
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
                }
            }
            else
            {
                CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), "P");

                if (Gv_lista_lj_p.Rows.Count > 0) { P_lista_lj_p.Visible = true; }
                else
                {
                    P_lista_lj_p.Visible = true;
                    CargaGVValidacionLicencia("", "", "", "", "", "", "P");
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
                }
            }
        }
        else
        {
            P_lista_lj_p.Visible = true;
            CargaGVValidacionLicencia("", "", "", "", "", "", "P");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
        }

        //if (Gv_lista_lj_v.Rows.Count > 0)
        //{
        //    P_lista_lj_v.Visible = true;
        //    if (!string.IsNullOrEmpty(Txt_lj_id.Text))
        //    {
        //        CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), "", "", "", "", "", "V");
        //        VistaPreviaLicencia(Txt_lj_id.Text.Trim());
        //        sc = "$('#desvalidarModal').modal('show');";
        //    }
        //    else
        //    {
        //        CargaGVValidacionLicencia(Txt_lj_id.Text.Trim(), Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), "V");

        //        if (Gv_lista_lj_v.Rows.Count > 0) { P_lista_lj_v.Visible = true; }
        //        else
        //        {
        //            P_lista_lj_v.Visible = true;
        //            CargaGVValidacionLicencia("", "", "", "", "", "", "V");
        //            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
        //        }
        //    }
        //}
        //else
        //{
        //    P_lista_lj_v.Visible = true;
        //    CargaGVValidacionLicencia("", "", "", "", "", "", "V");
        //    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
        //}
        Limpiar("sch_cl");
        Txt_lj_id.Focus();
        SetScript(sc, "");
    }

    // Alta De Los Datos De La Validación De La Sanción
    protected void BtnGuardarV_Click(object sender, EventArgs e)
    {
        _licencia_justificada = new cls_cp_licencia_justificada
        {
            lj_id = Convert.ToInt32(Hf_lj_id.Value),
            lj_estado = "V"
        };
        _licencia_justificada.Actualizar();
        var var_dt_lj = _licencia_justificada.ObtenerTablaGrilla(Hf_lj_id.Value, "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (var_dt_lj.Rows.Count > 0)
        {
            string json = JsonConvert.SerializeObject(var_dt_lj);
            AdicionarHistorico("A", "tbl__cp_licencia_justificada", "lj_id", Hf_lj_id.Value, json);
        }
        CargaGVValidacionLicencia("", "", "", "", "", "", "P");

        if (Gv_lista_lj_p.Rows.Count > 0) { P_lista_lj_p.Visible = true; }
        else { P_lista_lj_p.Visible = false; }
        Txt_lj_id.Focus();
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro validado correctamente...!!' }, { type: 'success' }); $('#validarModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela La Alta De Los Datos De La Validación De La Sanción
    protected void BtnCancelarV_Click(object sender, EventArgs e)
    {
        CargaGVValidacionLicencia("", "", "", "", "", "", "P");

        if (Gv_lista_lj_p.Rows.Count > 0) { P_lista_lj_p.Visible = true; }
        else { P_lista_lj_p.Visible = false; }
        Txt_lj_id.Focus();
        sc = "$('#validarModal').modal('hide');";
        SetScript(sc, "");
    }

    // Carga exclusivamente los datos de la licencia devueltos por el SP C3.
    private bool VistaPreviaLicencia(string par_lj_id)
    {
        _licencia_justificada = new cls_cp_licencia_justificada();
        var datos = _licencia_justificada.ObtenerTablaGrillaC(
            par_lj_id, "", "", "", "", "", "", "", "", "P");

        if (datos == null || datos.Tables.Count == 0 || datos.Tables[0].Rows.Count == 0)
        {
            Hf_lj_id.Value = "";
            return false;
        }

        var var_dt_lj = datos.Tables[0];
        Hf_lj_id.Value = par_lj_id;

        CargaDatosFuncionario(var_dt_lj.Rows[0]["per_id"].ToString());
        Lt_lj_tipo_licencia.Text = ValidarCampo(var_dt_lj.Rows[0]["cat_descripcion"]);
        Lt_lj_fecha_licencia.Text = ValidarCampo(var_dt_lj.Rows[0]["lj_fecha_licencia"]);
        Lt_lj_hora_licencia.Text = ValidarCampo(var_dt_lj.Rows[0]["lj_hora_licencia"]);
        Lt_lj_motivo.Text = ValidarCampo(var_dt_lj.Rows[0]["lj_motivo"]);
        Lt_lj_lugar.Text = ValidarCampo(var_dt_lj.Rows[0]["lj_lugar"]);
        Lt_lj_per_id_autoriza.Text = var_dt_lj.Columns.Contains("Autoriza")
            ? ValidarCampo(var_dt_lj.Rows[0]["Autoriza"])
            : "";

        return true;
    }

    private void ConfigurarModalLicencia(bool permitirAprobacion)
    {
        BtnGuardarV.Visible = permitirAprobacion;
        Lt_titulo_modal_licencia.Text = permitirAprobacion
            ? "Aprobar Licencia Justificada"
            : "Detalle de Licencia Justificada";
        BtnCancelarV.Text = permitirAprobacion
            ? "<i class='fas fa-times mr-2'></i> Cancelar"
            : "<i class='fas fa-times mr-2'></i> Cerrar";
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
        if (p_campo == null || p_campo == DBNull.Value) return "";
        return p_campo.ToString().Trim();
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
    }

    protected void BtnMismoFuncionamiento_Click(object sender, EventArgs e)
    {
        Compartido();
        //Response.Redirect("ValidacionLicenciaJustificada");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Se cambió el estado correctamente.' }, { type: 'success' });";
        SetScript(sc, "");
    }
}
