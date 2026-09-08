using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Salarios_RegistroSanciones : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_persona _persona = null;
    private cls_persona_familiares _familiar = null;
    private cls_glosa _glosa = null;
    private cls_mp_cargo cargo = null;
    public double diasSancion = 0;
    public int ca_id = 0;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                sc = "CopiarCortarPegar(true);";
                SetScript(sc, "");
                Txt_per_id_b.Focus();                
            }

        }
        else Response.Redirect("../Index");
    }
    private void ObtenerDiasSancion(int per_id, string ca_id) {
        cls_cp_sanciones sanciones = new cls_cp_sanciones();
        DataSet dsSanciones = sanciones.ObtenerTablaGrilla("", per_id.ToString(), "", ca_id, "", "", "", "", "V");
        int index = 0;
        if (dsSanciones.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow item in dsSanciones.Tables[0].Rows)
            {
                if (item.Table.Rows[index]["sa_factor"].ToString() == "57")
                {
                    txtRetrasos.Text = item.Table.Rows[index]["sa_dias_sancion"].ToString();
                    hdf_sa_id56.Value= item.Table.Rows[index]["sa_id"].ToString();
                }
                if (item.Table.Rows[index]["sa_factor"].ToString() == "58")
                { 
                    txtInasistencia.Text = item.Table.Rows[index]["sa_dias_sancion"].ToString();
                    hdf_sa_id57.Value = item.Table.Rows[index]["sa_id"].ToString();
                }
                index = index + 1;
            }
            hdf_retrasos.Value = txtRetrasos.Text; hdf_inasistencia.Value = txtInasistencia.Text;
        }
    }
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
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });";
        else
        {
            BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());
            Limpiar("sch_cl");

            if (GvLista.Rows.Count > 0) sc = "$('#dResult').css('display', 'block');";
            else sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' }); $('#dResult').css('display', 'none');";
        }
        SetScript(sc, "");
    }
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom)
    {
        try
        {
            _persona = new cls_persona();
            //DataSet DS= _persona.ObtenerTablaGrilla__AsignacionesPersona(varId, "", varCed, "", varPat, varMat, varNom, "", "", "", "", "", "", "");
            GvLista.DataSource = _persona.ObtenerTablaGrilla__AsignacionesPersona(varId, "", varCed, "", varPat, varMat, varNom, "", "", "", "", "", "", "");
            //GvLista.DataSource = _persona.ObtenerTablaGrilla__AsignacionesPersona_SoloDocentes(varId, "", varCed, "", varPat, varMat, varNom, "", "", "", "", "", "", "");

            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }
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
        //else if (val.Equals("gv_cl"))
        //{
        //    GvLista.DataSource = null;
        //    GvLista.DataBind();
        //}
        //else if (val.Equals("frm_edit_cl"))
        //{
        //    Txt_per_id.Text = string.Empty;
        //    Ddl_per_tipo_doc.Items.Clear();
        //    Txt_per_num_doc.Text = string.Empty;
        //    Ddl_per_lugar_exp.Items.Clear();
        //    Txt_per_ap_paterno.Text = string.Empty;
        //    Txt_per_ap_materno.Text = string.Empty;
        //    Txt_per_nombres.Text = string.Empty;
        //    Txt_per_ap_casada.Text = string.Empty;
        //    Rbl_per_sexo.ClearSelection();
        //    Txt_per_fecha_nac.Text = string.Empty;
        //    Ddl_per_procedencia.Items.Clear();
        //    Ddl_per_lugar_nac.Items.Clear();
        //    Ddl_per_estado_civil.Items.Clear();
        //}
        //else if (val.Equals("frm_fam_cl"))
        //{
        //    Ddl_pf_tipo_parentesco.Items.Clear();
        //    Txt_pf_paterno.Text = string.Empty;
        //    Txt_pf_materno.Text = string.Empty;
        //    Txt_pf_nombres.Text = string.Empty;
        //    Txt_pf_ap_esposo.Text = string.Empty;
        //}
        //else if (val.Equals("frm_fam"))
        //{
        //    Ddl_pf_tipo_parentesco.SelectedIndex = 0;
        //    Txt_pf_paterno.Text = string.Empty;
        //    Txt_pf_materno.Text = string.Empty;
        //    Txt_pf_nombres.Text = string.Empty;
        //    Txt_pf_ap_esposo.Text = string.Empty;
        //}
        //else if (val.Equals("gv_fam_cl"))
        //{
        //    GvListaFamily.DataSource = null;
        //    GvListaFamily.DataBind();
        //}
        //else if (val.Equals("frm_glosa_cl"))
        //{
        //    Ddl_gl_tipo_doc.Items.Clear();
        //    txt_gl_fecha_doc.Text = string.Empty;
        //    txt_gl_glosa.Text = string.Empty;
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
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();
        hdf_per_id.Value = code;
        if (e.CommandName.Equals("GetEdit"))
        {
            txtInasistencia.Text = "";
            txtRetrasos.Text = "";
            hdf_ca_id.Value = GvLista.DataKeys[index].Values[1].ToString();

            BindForm(code, Convert.ToInt32(hdf_ca_id.Value));
            CargarAsignaciones(Convert.ToInt32(code));
            ddl_asignacion.SelectedIndex = ddl_asignacion.Items.IndexOf(this.ddl_asignacion.Items.FindByValue(hdf_ca_id.Value.ToString())); 
            sc = "$('#modalSancionInasistencia').modal('show');";
            SetScript(sc, "");
        }
        //ltl_titulo.Text = "Registro de Sanciones por Inasistencia";
    }
    private void CargarAsignaciones(int per_id)
    {
        cls_cp_sanciones sanciones = new cls_cp_sanciones();
        ddl_asignacion.Items.Clear();
        ddl_asignacion.DataSource = sanciones.ListarAsignacionesParaSancion(Convert.ToInt32(per_id));
        ddl_asignacion.DataTextField = "cargo_compuesto";
        ddl_asignacion.DataValueField = "as_ca_id";
        ddl_asignacion.DataBind();
    }

    // cargar form
    private void BindForm(string per_id, int ca_id)
    {
        _persona = new cls_persona();
        cls_cp_sanciones sanciones = new cls_cp_sanciones();
        cls_mp_asignacion asignacion = new cls_mp_asignacion();
        DataSet ds = asignacion.ObtenerTablaGrilla("", per_id, ca_id.ToString(), "", "", "", "", "", "", "", "", "", "", "");
        if (ds.Tables[0].Rows.Count > 0)
        {
            int as_id = Convert.ToInt32(ds.Tables[0].Rows[0][0].ToString());
            informacionFuncionario(Convert.ToInt32(per_id), as_id);
            ObtenerDiasSancion(Convert.ToInt32(per_id), ca_id.ToString());
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El funcionario no tiene asignación...' }, { type: 'danger' });";
            SetScript(sc,"");
        }
    }
    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        cargo = new cls_mp_cargo();
        cargo.as_per_id = codFun;
        cargo.as_id_actual = as_id;
        var detalleFuncionario = cargo.ObtenerDatosDetalleFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
                //aux_per_id.Value = cargo.as_per_id.ToString().Trim();
                string haberBasico = validarCampo(funcionario["haber_basico"]);
                decimal haberBasico2 = Convert.ToDecimal(haberBasico);
                haberBasico2 = Math.Round(haberBasico2, 2);
                ltl_haber_basico.Text = Convert.ToString(haberBasico2);
                ltl_jornada.Text= validarCampo(funcionario["ca_tipo_jornada_lit"]);


                if (validarCampo(funcionario["as_estado"]) == "V")
                {
                    btn_estado.Text = "Vigente";
                    btn_estado.CssClass = "btn btn-sm btn-info float-right";
                }
                else
                {
                    btn_estado.Text = "Pasivo";
                    btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
                }

                if (validarCampo(funcionario["fp_foto"]) != null && validarCampo(funcionario["fp_foto"]) != "")
                {
                    imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
                }
                else
                {
                    if (validarCampo(funcionario["per_sexo"]) == "M")
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
                    }
                    else
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
                    }
                }

            }
        }
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




    protected void btnAdicionarSancion_Click(object sender, EventArgs e)
    {
        cls_cp_sanciones sanciones = new cls_cp_sanciones();
        sanciones.sa_per_id = Convert.ToInt32(hdf_per_id.Value);
        bool atrasos=false;
        bool inasistencia=false;
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        var fechas_proceso = pla_proceso.ObtenerSalarioMinimo();
        DateTime fechaInicioProceso = Convert.ToDateTime(fechas_proceso.Tables[0].Rows[0]["pc_fecha_inicio"].ToString());
        DateTime fechaFinProceso = Convert.ToDateTime(fechas_proceso.Tables[0].Rows[0]["pc_fecha_fin"].ToString());

        if (fechaFinProceso != null && fechaInicioProceso != null)
        {
            sanciones.sa_fecha_inicio = fechaInicioProceso;
            sanciones.sa_fecha_fin = fechaFinProceso;
        }
        if (hdf_retrasos.Value == "")
        {
            if (txtRetrasos.Text != "" && Convert.ToInt32(txtRetrasos.Text) > 0)
            {
                sanciones.sa_dias_sancion = Convert.ToInt32(txtRetrasos.Text);
                sanciones.sa_factor = 57;
                sanciones.sa_minutos = Convert.ToInt32(hdf_ca_id.Value);
                atrasos = sanciones.Adicionar();
            }
        }
        else
        {
            if (Convert.ToInt32(hdf_retrasos.Value)>=0)
            {
                if (txtRetrasos.Text != "" && Convert.ToInt32(txtRetrasos.Text)>=0 && txtRetrasos.Text!=hdf_retrasos.Value)
                {
                    sanciones.sa_dias_sancion = Convert.ToInt32(txtRetrasos.Text);
                    sanciones.sa_id = Convert.ToInt32(hdf_sa_id56.Value);
                    atrasos = sanciones.ActualizarRegistroSanciones(sanciones);
                }
            }
        }
        if (hdf_inasistencia.Value == "")
        {
            if (txtInasistencia.Text != "" && Convert.ToInt32(txtInasistencia.Text)>0)
            {
                sanciones.sa_dias_sancion = Convert.ToInt32(txtInasistencia.Text);
                sanciones.sa_factor = 58;
                sanciones.sa_minutos = Convert.ToInt32(hdf_ca_id.Value);
                inasistencia = sanciones.Adicionar();
            }
        }
        else
        {
            if (Convert.ToInt32(hdf_inasistencia.Value) >= 0)
            {
                if (txtInasistencia.Text != "" && txtInasistencia.Text != hdf_inasistencia.Value)
                {
                    sanciones.sa_dias_sancion = Convert.ToInt32(txtInasistencia.Text);
                    sanciones.sa_id = Convert.ToInt32(hdf_sa_id57.Value);
                    atrasos = sanciones.ActualizarRegistroSanciones(sanciones);
                }
            }
        }


        if (atrasos == true && inasistencia == true)
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se registraron los atrasos e inasistencia satisfactoriamente' }, { type: 'success' }); $('#modalSancionInasistencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        else
        {
            if (atrasos == true)
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se registraron los atrasos correctamente' }, { type: 'success' }); $('#modalSancionInasistencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            if (inasistencia == true)
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se registraron las inasistencias correctamente' }, { type: 'success' }); $('#modalSancionInasistencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        }
        txtInasistencia.Text = ""; txtRetrasos.Text = "";
        hdf_retrasos.Value = "";
        hdf_inasistencia.Value = "";
        hdf_ca_id.Value = "";
        SetScript(sc, "");
    }
}