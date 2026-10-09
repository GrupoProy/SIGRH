using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Precontratacion_ListaSolicitudes : System.Web.UI.Page
{
    private cls_persona _persona = null;
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
        else
        {
            Response.Redirect("../Index");
        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtApPaterno_b.Text) &&
                string.IsNullOrEmpty(txtApMaterno_b.Text) &&
                string.IsNullOrEmpty(txtNombres_b.Text) &&
                string.IsNullOrEmpty(txtCI_b.Text) &&
                string.IsNullOrEmpty(txtCodigo_b.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            _persona = new cls_persona();
            DataSet ds = _persona.ObtenerTablaGrilla__persona_gamlp(
                txtCodigo_b.Text.Trim(),
                "",
                txtCI_b.Text.Trim(),
                "",
                txtApPaterno_b.Text.Trim(),
                txtApMaterno_b.Text.Trim(),
                txtNombres_b.Text.Trim(),
                "", "", "", "", "", "", ""
            );

            // ============================================================
            // CARGAR ESTADO REAL DE CONTRATACIÓN DESDE LA BD
            // ============================================================
            if (ds != null && ds.Tables.Count > 0)
            {
                // Asegurar columnas
                if (!ds.Tables[0].Columns.Contains("as_estado"))
                    ds.Tables[0].Columns.Add("as_estado", typeof(string));
                if (!ds.Tables[0].Columns.Contains("as_validacion"))
                    ds.Tables[0].Columns.Add("as_validacion", typeof(string));

                // Obtener diccionario de estados reales
                var estados = ObtenerEstadosContrato(ds.Tables[0]);

                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int perId = Convert.ToInt32(row["per_id"]);

                    if (estados.ContainsKey(perId))
                    {
                        row["as_estado"] = estados[perId].Estado;
                        row["as_validacion"] = estados[perId].Validacion;
                    }
                    else
                    {
                        // Persona sin contrato en la gestión actual
                        // → mostrar botones de Alta / Currículum / Evaluación
                        row["as_estado"] = "V";
                        row["as_validacion"] = "N";
                    }
                }
            }
            // ============================================================
            // FIN DE LA CARGA DE ESTADO REAL
            // ============================================================

            gvResultados.DataSource = ds;
            gvResultados.DataBind();

            if (ds.Tables[0].Rows.Count > 0)
            {
                sc = "$('#dResult').css('display', 'block');";
                sc += "$.notify({ icon: 'fas fa-check', message: 'Funcionarios encontrados.' }, { type: 'success' });";
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se han encontrado funcionarios con esos datos' }, { type: 'warning' }); $('#dResult').css('display', 'none');";
            }
            SetScript(sc, "");
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al buscar: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    /// <summary>
    /// Consulta una sola vez todos los estados de contrato de las personas encontradas.
    /// Devuelve un diccionario per_id -> (as_estado, as_validacion).
    /// </summary>
    private Dictionary<int, EstadoContrato> ObtenerEstadosContrato(DataTable personas)
    {
        var resultado = new Dictionary<int, EstadoContrato>();

        if (personas == null || personas.Rows.Count == 0) return resultado;

        // Recolectar todos los per_id
        var ids = new List<int>();
        foreach (DataRow row in personas.Rows)
        {
            if (row["per_id"] != DBNull.Value)
                ids.Add(Convert.ToInt32(row["per_id"]));
        }
        if (ids.Count == 0) return resultado;

        // Gestión actual (si está en sesión)
        object prIdObj = Session["pr_id"];
        int? prId = (prIdObj != null && prIdObj.ToString() != "")
                    ? (int?)Convert.ToInt32(prIdObj)
                    : null;

        string cadena = ConfigurationManager.ConnectionStrings["CnxSigrh3"].ConnectionString;

        // Construir IN (@p0, @p1, ...)
        var parametros = new List<string>();
        for (int i = 0; i < ids.Count; i++)
            parametros.Add("@p" + i);

        string sql = @"
            SELECT as_per_id, as_estado, as_validacion
            FROM tbl_mp_asignacion
            WHERE as_per_id IN (" + string.Join(",", parametros) + @")
              AND as_estado IN ('V','B')
              " + (prId.HasValue ? "AND as_pr_id = @prId" : "") + @"
        ";

        using (var cn = new SqlConnection(cadena))
        using (var cmd = new SqlCommand(sql, cn))
        {
            for (int i = 0; i < ids.Count; i++)
                cmd.Parameters.AddWithValue("@p" + i, ids[i]);

            if (prId.HasValue)
                cmd.Parameters.AddWithValue("@prId", prId.Value);

            cn.Open();
            using (var dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    int perId = Convert.ToInt32(dr["as_per_id"]);
                    string estado = dr["as_estado"] != DBNull.Value ? dr["as_estado"].ToString() : "";
                    string validacion = dr["as_validacion"] != DBNull.Value ? dr["as_validacion"].ToString() : "";

                    // Si hay más de una asignación, priorizar la vigente
                    if (!resultado.ContainsKey(perId) || estado == "V")
                    {
                        resultado[perId] = new EstadoContrato
                        {
                            Estado = estado,
                            Validacion = validacion
                        };
                    }
                }
            }
        }

        return resultado;
    }

    private class EstadoContrato
    {
        public string Estado { get; set; }
        public string Validacion { get; set; }
    }

    private string ObtenerEstadoCurriculum(int perId)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();

            DataSet dsForm = formacion.ObtenerGrilla_Formacion(perId);
            bool tieneFormacion = dsForm != null
                && dsForm.Tables.Count > 0
                && dsForm.Tables[0].Rows.Count > 0;

            DataSet dsExp = formacion.ObtenerGrilla_Trayectoria(perId);
            bool tieneExperiencia = dsExp != null
                && dsExp.Tables.Count > 0
                && dsExp.Tables[0].Rows.Count > 0;

            if (!tieneFormacion && !tieneExperiencia) return "SIN_LLENAR";
            if (tieneFormacion && tieneExperiencia) return "COMPLETO";
            return "INCOMPLETO";
        }
        catch
        {
            return "SIN_LLENAR";
        }
    }

    protected void gvResultados_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) return;

        try
        {
            int perId = Convert.ToInt32(gvResultados.DataKeys[e.Row.RowIndex].Value);

            DataRowView drv = e.Row.DataItem as DataRowView;
            string asEstado = "";
            string asValidacion = "";

            if (drv != null)
            {
                if (drv.Row.Table.Columns.Contains("as_estado") && drv["as_estado"] != DBNull.Value)
                    asEstado = drv["as_estado"].ToString();

                if (drv.Row.Table.Columns.Contains("as_validacion") && drv["as_validacion"] != DBNull.Value)
                    asValidacion = drv["as_validacion"].ToString();
            }

            // Si el contrato YA está validado (S), no procesar el botón de currículum
            if (asEstado == "V" && asValidacion == "S") return;

            string estado = ObtenerEstadoCurriculum(perId);

            LinkButton lnkCurr = (LinkButton)e.Row.FindControl("lnkCurriculum");
            if (lnkCurr == null) return;

            switch (estado)
            {
                case "COMPLETO":
                    lnkCurr.CssClass = "btn btn-sm btn-info";
                    lnkCurr.ToolTip = "Ver Currículum (completo)";
                    lnkCurr.Text = "<i class='fas fa-eye'></i>";
                    break;

                case "INCOMPLETO":
                    lnkCurr.CssClass = "btn btn-sm btn-warning";
                    lnkCurr.ToolTip = "Completar Currículum (falta información)";
                    lnkCurr.Text = "<i class='fas fa-edit'></i>";
                    break;

                case "SIN_LLENAR":
                default:
                    lnkCurr.CssClass = "btn btn-sm btn-success";
                    lnkCurr.ToolTip = "Llenar Currículum (sin datos)";
                    lnkCurr.Text = "<i class='fas fa-file-alt'></i>";
                    break;
            }
        }
        catch
        {
            // Silencioso
        }
    }

    protected void btnVerificarCI_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtCIVerificacion.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar un número de Carnet de Identidad' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(txtCIVerificacion.Text, @"^\d+$"))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El Carnet de Identidad solo debe contener números' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            string ci = txtCIVerificacion.Text.Trim();

            _persona = new cls_persona();
            DataSet ds = _persona.VerificarNuevoFuncionario(ci, 0);

            if (ds.Tables[0].Rows.Count == 0)
            {
                sc = "$.notify({ icon: 'fas fa-check', message: 'CI no registrado. Puede continuar con la solicitud.' }, { type: 'success' });";
                SetScript(sc, "");

                string script = "setTimeout(function(){ window.location='SolicitudContratacion.aspx?ci=" + ci + "&modo=nuevo'; }, 1500);";
                ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", script, true);
            }
            else
            {
                DataRow row = ds.Tables[0].Rows[0];
                int perId = Convert.ToInt32(row["per_id"]);

                bool tieneCurriculum = VerificarCurriculumCompleto(perId);

                if (tieneCurriculum)
                {
                    sc = "$.notify({ icon: 'fas fa-info', message: 'El funcionario ya tiene curriculum. Redirigiendo...' }, { type: 'info' });";
                    SetScript(sc, "");

                    string script = "setTimeout(function(){ window.location='CurriculumCandidato.aspx?per_id=" + perId + "&modo=ver'; }, 1500);";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", script, true);
                }
                else
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation-triangle', message: 'El funcionario no tiene curriculum. Debe completarlo.' }, { type: 'warning' });";
                    SetScript(sc, "");

                    string script = "setTimeout(function(){ window.location='CurriculumCandidato.aspx?per_id=" + perId + "&modo=completar'; }, 1500);";
                    ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", script, true);
                }
            }
            txtCIVerificacion.Text = "";
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al verificar: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    private bool VerificarCurriculumCompleto(int perId)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            DataSet ds = formacion.ObtenerGrilla_Formacion(perId);
            return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
        }
        catch
        {
            return false;
        }
    }

    protected void btnCancelarVerificacionCI_Click(object sender, EventArgs e)
    {
        txtCIVerificacion.Text = "";
        sc = "$('#modalVerificarCI').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
        string script = "setTimeout(function(){ window.location='ListaSolicitudes.aspx'; }, 500);";
        ScriptManager.RegisterStartupScript(this, GetType(), "Redirect", script, true);
    }

    protected void gvResultados_PreRender(object sender, EventArgs e)
    {
        if (gvResultados.Rows.Count > 0)
        {
            if (gvResultados.HeaderRow != null)
                gvResultados.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (gvResultados.FooterRow != null)
                gvResultados.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void gvResultados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int perId = Convert.ToInt32(gvResultados.DataKeys[index].Value);

            switch (e.CommandName)
            {
                case "IrCurriculum":
                    {
                        string estado = ObtenerEstadoCurriculum(perId);
                        string modo = "nuevo";

                        switch (estado)
                        {
                            case "COMPLETO": modo = "ver"; break;
                            case "INCOMPLETO": modo = "completar"; break;
                            case "SIN_LLENAR":
                            default: modo = "nuevo"; break;
                        }

                        Response.Redirect($"CurriculumCandidato.aspx?per_id={perId}&modo={modo}");
                        break;
                    }

                case "IrEvaluacion":
                    Response.Redirect($"EvaluacionCurricular.aspx?per_id={perId}");
                    break;

                case "Alta":
                    Response.Redirect($"ContratacionDescriptor.aspx?id={perId}");
                    break;

                case "Modificar":
                    Response.Redirect($"ContratacionModificacion.aspx?id={perId}");
                    break;

                case "Baja":
                    Response.Redirect($"ContratacionResolucion.aspx?id={perId}");
                    break;

                case "ImprimirAlta":
                    Response.Redirect($"ImprimirContratacion.aspx?per_id={perId}&tipo=alta");
                    break;

                case "ImprimirModificacion":
                    Response.Redirect($"ImprimirContratacion.aspx?per_id={perId}&tipo=modificacion");
                    break;

                case "ImprimirBaja":
                    Response.Redirect($"ImprimirContratacion.aspx?per_id={perId}&tipo=baja");
                    break;

                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            string sc2 = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al procesar la acción: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc2, "");
        }
    }

    private void SetScript(string val, string valS = "")
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
        sb.Append("$('.radios label').addClass('custom-control-label mb-3');" +
            "$('.radios input[type=\"radio\"]').addClass('custom-control-input mb-3');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }
}