using Solution_Framework_Kardex.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Precontrataciones_EvaluacionCurricular : System.Web.UI.Page
{
    private int perId = 0;
    private int cargoId = 0;
    private int asId = 0;

    public class FilaExperiencia
    {
        public int CvExpId { get; set; }
        public string Institucion { get; set; }
        public string Cargo { get; set; }
        public int Anios { get; set; }
        public int Meses { get; set; }
        public int Dias { get; set; }
        public DateTime Ini { get; set; }
        public DateTime Fin { get; set; }
        public bool Especifica { get; set; }
    }

    public class FilaFormacion
    {
        public int CvForId { get; set; }
        public string GradoAcademico { get; set; }
        public string Carrera { get; set; }
        public string Institucion { get; set; }
        public string AnioEgreso { get; set; }
        public bool Especifica { get; set; }
    }

    private int _totalGenAnios, _totalGenMeses, _totalGenDias;
    private int _totalEspAnios, _totalEspMeses, _totalEspDias;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] == null)
        {
            Response.Redirect("../Index");
            return;
        }

        if (!Page.IsPostBack)
        {
            int.TryParse(Request.QueryString["per_id"], out perId);
            int.TryParse(Request.QueryString["cargo_id"], out cargoId);

            if (perId == 0)
            {
                Response.Redirect("ListaSolicitudes.aspx");
                return;
            }

            ObtenerAsignacionVigente();

            ViewState["perId"] = perId;
            ViewState["cargoId"] = cargoId;
            ViewState["AsId"] = asId;

            CargarEvaluacion();
        }
        else
        {
            perId = Convert.ToInt32(ViewState["perId"] ?? 0);
            cargoId = Convert.ToInt32(ViewState["cargoId"] ?? 0);
            asId = Convert.ToInt32(ViewState["AsId"] ?? 0);

            _totalGenAnios = Convert.ToInt32(ViewState["TG_A"] ?? 0);
            _totalGenMeses = Convert.ToInt32(ViewState["TG_M"] ?? 0);
            _totalGenDias = Convert.ToInt32(ViewState["TG_D"] ?? 0);
            _totalEspAnios = Convert.ToInt32(ViewState["TE_A"] ?? 0);
            _totalEspMeses = Convert.ToInt32(ViewState["TE_M"] ?? 0);
            _totalEspDias = Convert.ToInt32(ViewState["TE_D"] ?? 0);
        }
    }

    private void ObtenerAsignacionVigente()
    {
        try
        {
            cls_Evaluacion_Curricular bll = new cls_Evaluacion_Curricular();
            DataSet ds = bll.ObtenerAsignacionVigente(perId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow r = ds.Tables[0].Rows[0];
                if (r["as_id"] != DBNull.Value) asId = Convert.ToInt32(r["as_id"]);
                if (cargoId == 0 && r["as_ca_id"] != DBNull.Value) cargoId = Convert.ToInt32(r["as_ca_id"]);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error al obtener asignación vigente: " + ex.Message);
        }
    }

    private void CargarEvaluacion()
    {
        try
        {
            cls_Evaluacion_Curricular bll = new cls_Evaluacion_Curricular();
            DataSet ds = bll.ObtenerEvaluacionCurricular(perId, cargoId);

            if (ds == null || ds.Tables.Count < 5)
            {
                Response.Write("<div class='alert alert-warning'>No se pudieron obtener datos.</div>");
                return;
            }

            // ---- RS 1: Datos del postulante ----
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow r = ds.Tables[0].Rows[0];
                ltlNombre.Text = r["nombre_completo"].ToString();
                ltlCI.Text = r["ci"].ToString();
            }

            // ---- RS 2: Experiencias ----
            List<FilaExperiencia> todas = new List<FilaExperiencia>();
            _totalGenAnios = 0; _totalGenMeses = 0; _totalGenDias = 0;
            _totalEspAnios = 0; _totalEspMeses = 0; _totalEspDias = 0;

            foreach (DataRow r in ds.Tables[1].Rows)
            {
                if (r["cv_exp_fecha_inicio"] == DBNull.Value || r["cv_exp_fecha_fin"] == DBNull.Value) continue;

                DateTime ini = Convert.ToDateTime(r["cv_exp_fecha_inicio"]);
                DateTime fin = Convert.ToDateTime(r["cv_exp_fecha_fin"]);
                var dur = CalcularDuracionPeriodo(ini, fin);

                _totalGenAnios += dur.Item1;
                _totalGenMeses += dur.Item2;
                _totalGenDias += dur.Item3;

                bool especifica = r["especifica"] != DBNull.Value && Convert.ToBoolean(r["especifica"]);
                if (especifica)
                {
                    _totalEspAnios += dur.Item1;
                    _totalEspMeses += dur.Item2;
                    _totalEspDias += dur.Item3;
                }

                todas.Add(new FilaExperiencia
                {
                    CvExpId = Convert.ToInt32(r["cv_exp_id"]),
                    Institucion = r["institucion"].ToString(),
                    Cargo = r["cargo"].ToString(),
                    Anios = dur.Item1,
                    Meses = dur.Item2,
                    Dias = dur.Item3,
                    Ini = ini,
                    Fin = fin,
                    Especifica = especifica
                });
            }

            NormalizarTotales();
            Session["EvalFilas_" + perId] = todas;

            gvExpGeneral.DataSource = todas;
            gvExpGeneral.DataBind();

            gvExpEspecifica.DataSource = todas.FindAll(x => x.Especifica);
            gvExpEspecifica.DataBind();

            GuardarTotalesEnViewState();

            // ---- Formación Académica ----
            CargarFormacionAcademica(bll);

            // ---- RS 4: Llenar dropdown ----
            ddlRequisito.Items.Clear();
            ddlRequisito.Items.Add(new ListItem("-- Seleccione un requisito --", "0"));

            foreach (DataRow r in ds.Tables[3].Rows)
            {
                int rfId = Convert.ToInt32(r["rf_id"]);
                string formacion = r["rf_formacion"].ToString();
                if (formacion.Length > 80) formacion = formacion.Substring(0, 80) + "...";

                int gralAnios = Convert.ToInt32(r["rf_exp_gral"]);
                int espAnios = Convert.ToInt32(r["rf_exp_esp"]);

                string texto = string.Format("{0} - {1} ({2} años gen / {3} años esp)",
                    rfId, formacion, gralAnios, espAnios);

                ddlRequisito.Items.Add(new ListItem(texto, rfId.ToString()));
            }

            // ---- RS 5: Datos del cargo ----
            if (ds.Tables[4].Rows.Count > 0)
            {
                DataRow r = ds.Tables[4].Rows[0];
                string item = r["item_cargo"]?.ToString() ?? "";
                string puesto = r["pu_nombre_puesto"]?.ToString() ?? "";
                string escala = r["escala_descripcion"]?.ToString() ?? "";

                ltlCargo.Text = item + " — " + puesto;
                if (!string.IsNullOrEmpty(escala)) ltlCargo.Text += " (" + escala + ")";
            }
            else
            {
                ltlCargo.Text = "Sin cargo especificado";
            }

            // ---- RS 3: ¿Hay requisito AUTOMÁTICO? ----
            bool tieneRequisitoAutomatico = false;

            if (ds.Tables[2].Rows.Count > 0 && ds.Tables[2].Rows[0]["rf_id"] != DBNull.Value)
            {
                DataRow reqAuto = ds.Tables[2].Rows[0];
                int rfIdAuto = Convert.ToInt32(reqAuto["rf_id"]);
                ListItem itemAuto = ddlRequisito.Items.FindByValue(rfIdAuto.ToString());
                if (itemAuto != null)
                {
                    ddlRequisito.SelectedValue = rfIdAuto.ToString();
                    tieneRequisitoAutomatico = true;
                }
            }

            Session["EvalDS_" + perId] = ds;
            pnlRequisito.Visible = true;

            if (tieneRequisitoAutomatico)
            {
                ddlRequisito.Enabled = false;
                pnlMensajeAuto.Visible = true;
                pnlMensajeManual.Visible = false;
                RecalcularEvaluacion();
            }
            else
            {
                ddlRequisito.Enabled = true;
                pnlMensajeAuto.Visible = false;
                pnlMensajeManual.Visible = true;
            }
        }
        catch (Exception ex)
        {
            Response.Write("<div class='alert alert-danger'>Error: " + ex.Message + "</div>");
        }
    }

    private void CargarFormacionAcademica(cls_Evaluacion_Curricular bll)
    {
        List<FilaFormacion> formaciones = new List<FilaFormacion>();

        try
        {
            var cvBll = new cls_cv_formacion();
            DataSet dsFor = cvBll.ObtenerGrilla_Formacion(perId);

            if (dsFor != null && dsFor.Tables.Count > 0 && dsFor.Tables[0].Rows.Count > 0)
            {
                DataTable t = dsFor.Tables[0];

                Func<DataRow, string[], string> pick = (row, names) =>
                {
                    foreach (var n in names)
                        if (t.Columns.Contains(n) && row[n] != DBNull.Value)
                            return row[n].ToString().Trim();
                    return "";
                };

                foreach (DataRow r in t.Rows)
                {
                    string idStr = pick(r, new[] { "cv_form_id", "cv_for_id", "CvForId" });
                    int cvForId = 0;
                    int.TryParse(idStr, out cvForId);

                    formaciones.Add(new FilaFormacion
                    {
                        CvForId = cvForId,
                        GradoAcademico = pick(r, new[] { "ga_nombre", "grado_academico", "GradoAcademico" }),
                        Carrera = pick(r, new[] { "carr_nombre", "carrera", "Carrera", "cv_carr_nombre" }),
                        Institucion = pick(r, new[] { "it_nombre", "institucion", "Institucion", "cv_inst_nombre" }),
                        AnioEgreso = pick(r, new[] { "cv_form_año_fin", "anio_egreso", "AnioEgreso", "cv_form_anio_fin" }),
                        Especifica = false
                    });
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Formación no disponible: " + ex.Message);
        }

        Session["EvalFor_" + perId] = formaciones;
        gvFormacion.DataSource = formaciones;
        gvFormacion.DataBind();

        CalcularTotalFormacionRelacionada();
    }

    private void CalcularTotalFormacionRelacionada()
    {
        var formaciones = Session["EvalFor_" + perId] as List<FilaFormacion>;
        int n = (formaciones != null) ? formaciones.FindAll(x => x.Especifica).Count : 0;
        ltlTotalForRel.Text = n.ToString();
    }

    protected void chkEspecificaFor_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            int cvForId = Convert.ToInt32(gvFormacion.DataKeys[row.RowIndex].Value);

            var formaciones = Session["EvalFor_" + perId] as List<FilaFormacion>;
            if (formaciones == null) return;

            var fila = formaciones.Find(x => x.CvForId == cvForId);
            if (fila != null) fila.Especifica = chk.Checked;

            Session["EvalFor_" + perId] = formaciones;
            CalcularTotalFormacionRelacionada();
            RecalcularEvaluacion();
        }
        catch (Exception ex)
        {
            Response.Write("<div class='alert alert-danger'>Error al actualizar formación: " + ex.Message + "</div>");
        }
    }

    private void NormalizarTotales()
    {
        _totalGenMeses += (_totalGenDias / 30);
        _totalGenDias = _totalGenDias % 30;
        _totalGenAnios += (_totalGenMeses / 12);
        _totalGenMeses = _totalGenMeses % 12;

        _totalEspMeses += (_totalEspDias / 30);
        _totalEspDias = _totalEspDias % 30;
        _totalEspAnios += (_totalEspMeses / 12);
        _totalEspMeses = _totalEspMeses % 12;
    }

    private void GuardarTotalesEnViewState()
    {
        ViewState["TG_A"] = _totalGenAnios;
        ViewState["TG_M"] = _totalGenMeses;
        ViewState["TG_D"] = _totalGenDias;
        ViewState["TE_A"] = _totalEspAnios;
        ViewState["TE_M"] = _totalEspMeses;
        ViewState["TE_D"] = _totalEspDias;

        ltlTotalGenAnios.Text = _totalGenAnios.ToString();
        ltlTotalGenMeses.Text = _totalGenMeses.ToString();
        ltlTotalGenDias.Text = _totalGenDias.ToString();

        ltlTotalEspAnios.Text = _totalEspAnios.ToString();
        ltlTotalEspMeses.Text = _totalEspMeses.ToString();
        ltlTotalEspDias.Text = _totalEspDias.ToString();
    }

    protected void chkEspecificaEval_CheckedChanged(object sender, EventArgs e)
    {
        try
        {
            CheckBox chk = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chk.NamingContainer;
            int index = row.RowIndex;
            int cvExpId = Convert.ToInt32(gvExpGeneral.DataKeys[index].Value);
            bool especifica = chk.Checked;

            List<FilaExperiencia> filas = Session["EvalFilas_" + perId] as List<FilaExperiencia>;
            if (filas == null) return;

            var fila = filas.Find(x => x.CvExpId == cvExpId);
            if (fila != null) fila.Especifica = especifica;

            Session["EvalFilas_" + perId] = filas;

            _totalGenAnios = 0; _totalGenMeses = 0; _totalGenDias = 0;
            _totalEspAnios = 0; _totalEspMeses = 0; _totalEspDias = 0;

            foreach (var f in filas)
            {
                _totalGenAnios += f.Anios;
                _totalGenMeses += f.Meses;
                _totalGenDias += f.Dias;

                if (f.Especifica)
                {
                    _totalEspAnios += f.Anios;
                    _totalEspMeses += f.Meses;
                    _totalEspDias += f.Dias;
                }
            }

            NormalizarTotales();
            GuardarTotalesEnViewState();

            gvExpEspecifica.DataSource = filas.FindAll(x => x.Especifica);
            gvExpEspecifica.DataBind();

            RecalcularEvaluacion();
        }
        catch (Exception ex)
        {
            Response.Write("<div class='alert alert-danger'>Error al actualizar: " + ex.Message + "</div>");
        }
    }

    protected void ddlRequisito_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlRequisito.SelectedValue == "0")
        {
            pnlResultado.Visible = false;
            btnGuardarEvaluacion.Visible = false;
            return;
        }

        RecalcularEvaluacion();
        btnGuardarEvaluacion.Visible = true;
    }

    private void RecalcularEvaluacion()
    {
        if (ddlRequisito.SelectedValue == "0") return;

        DataSet ds = Session["EvalDS_" + perId] as DataSet;
        if (ds == null) return;

        int rfId = Convert.ToInt32(ddlRequisito.SelectedValue);
        DataRow req = null;
        foreach (DataRow r in ds.Tables[3].Rows)
        {
            if (Convert.ToInt32(r["rf_id"]) == rfId) { req = r; break; }
        }
        if (req == null) return;

        int reqGenAnios = Convert.ToInt32(req["rf_exp_gral"]);
        int reqEspAnios = Convert.ToInt32(req["rf_exp_esp"]);

        int totalGenDias = (_totalGenAnios * 360) + (_totalGenMeses * 30) + _totalGenDias;
        int totalEspDias = (_totalEspAnios * 360) + (_totalEspMeses * 30) + _totalEspDias;

        int reqGenDias = reqGenAnios * 360;
        int reqEspDias = reqEspAnios * 360;

        ltlReqFormacion.Text = req["rf_formacion"].ToString();
        ltlReqExpGeneral.Text = reqGenAnios + " años";
        ltlReqExpEspecifica.Text = reqEspAnios + " años";

        bool cumpleGen = totalGenDias >= reqGenDias;
        bool cumpleEsp = totalEspDias >= reqEspDias;

        var formaciones = Session["EvalFor_" + perId] as List<FilaFormacion>;
        int formRelacionadas = (formaciones != null) ? formaciones.FindAll(x => x.Especifica).Count : 0;
        bool cumpleFormacion = formRelacionadas > 0;

        ltlEvalExpGeneral.Text = BadgeEstado(cumpleGen);
        ltlEvalExpEspecifica.Text = BadgeEstado(cumpleEsp);
        ltlEvalFormacion.Text = BadgeEstado(cumpleFormacion);

        pnlResultado.Visible = true;
        btnGuardarEvaluacion.Visible = true;
    }

    private string BadgeEstado(bool cumple)
    {
        if (cumple)
            return "<span style=\"display:inline-block;padding:.5rem 1.1rem;border-radius:6px;"
                 + "background:#111827;color:#fff;font-size:.85rem;font-weight:600;letter-spacing:.5px;\">CUMPLE</span>";

        return "<span style=\"display:inline-block;padding:.5rem 1.1rem;border-radius:6px;"
             + "background:#f3f4f6;color:#6b7280;border:1px solid #e5e7eb;font-size:.85rem;font-weight:600;letter-spacing:.5px;\">NO CUMPLE</span>";
    }

    private Tuple<int, int, int> CalcularDuracionPeriodo(DateTime ini, DateTime fin)
    {
        if (fin < ini) return Tuple.Create(0, 0, 0);

        int dias = fin.Day - ini.Day;
        int meses = fin.Month - ini.Month;
        int anios = fin.Year - ini.Year;

        if (dias < 0) { dias += DateTime.DaysInMonth(ini.Year, ini.Month); meses--; }
        if (meses < 0) { meses += 12; anios--; }
        return Tuple.Create(anios, meses, dias);
    }

    // ============================================================
    //  GUARDAR EVALUACIÓN  (✅ CORREGIDO con ScriptManager + redirección)
    // ============================================================
    protected void btnGuardarEvaluacion_Click(object sender, EventArgs e)
    {
        try
        {
            if (ddlRequisito.SelectedValue == "0")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertWarn",
                    "Swal.fire('Atención','Seleccione un requisito','warning');", true);
                return;
            }

            if (asId == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertErr",
                    "Swal.fire('Error','No se encontró la asignación vigente','error');", true);
                return;
            }

            int usuarioId = Convert.ToInt32(Session["us_id"] ?? 1);
            int rfId = Convert.ToInt32(ddlRequisito.SelectedValue);

            int diasGen = (_totalGenAnios * 360) + (_totalGenMeses * 30) + _totalGenDias;
            int diasEsp = (_totalEspAnios * 360) + (_totalEspMeses * 30) + _totalEspDias;

            cls_Evaluacion_Curricular bll = new cls_Evaluacion_Curricular();

            // 1) Cabecera
            int evId = bll.Insertar(asId, diasEsp, diasGen, usuarioId, rfId);
            if (evId <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertErr2",
                    "Swal.fire('Error','No se pudo guardar la evaluación','error');", true);
                return;
            }

            // 2) Limpiar detalle anterior
            bll.Eliminar(evId, false);

            // 3) Detalle de experiencias específicas (tipo "E")
            int contadorExp = 0;
            foreach (GridViewRow row in gvExpGeneral.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkEspecificaEval");
                if (chk != null && chk.Checked)
                {
                    int cvExpId = Convert.ToInt32(gvExpGeneral.DataKeys[row.RowIndex].Value);
                    bll.InsertarDetalle(evId, cvExpId, "E");
                    contadorExp++;
                }
            }

            // 4) Detalle de formación académica relacionada (tipo "F")
            int contadorFor = 0;
            foreach (GridViewRow row in gvFormacion.Rows)
            {
                CheckBox chk = (CheckBox)row.FindControl("chkEspecificaFor");
                if (chk != null && chk.Checked)
                {
                    int cvForId = Convert.ToInt32(gvFormacion.DataKeys[row.RowIndex].Value);
                    try
                    {
                        bll.InsertarDetalle(evId, cvForId, "F");
                        contadorFor++;
                    }
                    catch (Exception exIns)
                    {
                        System.Diagnostics.Debug.WriteLine("No se guardó formación: " + exIns.Message);
                    }
                }
            }

            // ✅ MENSAJE DE ÉXITO + REDIRECCIÓN
            string script = @"
            Swal.fire({
                title: '¡Guardado con éxito!',
                html: 'Evaluación curricular registrada.<br>'
                    + '<b>" + contadorExp + @"</b> experiencia(s) específica(s) y '
                    + '<b>" + contadorFor + @"</b> título(s) relacionado(s).',
                icon: 'success',
                confirmButtonText: 'Aceptar',
                confirmButtonColor: '#00a8b5',
                allowOutsideClick: false,
                allowEscapeKey: false
            }).then(function () {
                window.location.href = 'ListaSolicitudes.aspx';
            });";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExitoEval", script, true);
        }
        catch (Exception ex)
        {
            string msg = ex.Message.Replace("'", "\\'").Replace("\r", "").Replace("\n", " ");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExcep",
                "Swal.fire('Error','" + msg + "','error');", true);
        }
    }
}