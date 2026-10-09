using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using System.Data;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using System.Text;

public partial class Kardex_CV : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        string per_id = Session["per_id"]?.ToString();
        string perIdQuery = Request.QueryString["per_id"];

        if (!string.IsNullOrEmpty(perIdQuery))
        {
            per_id = perIdQuery;
            Session["per_id"] = per_id;
        }

        if (!string.IsNullOrEmpty(per_id))
        {
            if (!Page.IsPostBack)
            {
                BindForm(per_id);
                BindGradoAcademico();
                Bind_Instituciones();
                BindCarreras();
                BindGridViewFormacion(per_id);
                BindCursos();
                BindGridViewCursos(per_id);
                BindGridViewTrayectoria(per_id);
                BindIdiomas();
                BindGridViewIdiomas(per_id);
                BindOtrosConocimientos();
                BindGridViewOtrosConocimientos(per_id);
            }
        }
        else
        {
            Response.Redirect("../Index");
        }
    }

    private void BindIdiomas()
    {
        cls_cv_formacion formacion = new cls_cv_formacion();
        ddlIdiomas_Idioma.Items.Clear();
        ddlIdiomas_Idioma.Items.Add("Seleccione..");
        ddlIdiomas_Idioma.DataSource = formacion.ListadoIdiomas();
        ddlIdiomas_Idioma.DataTextField = "idm_nombre";
        ddlIdiomas_Idioma.DataValueField = "idm_id";
        ddlIdiomas_Idioma.DataBind();
    }

    private void BindOtrosConocimientos()
    {
        cls_cv_formacion formacion = new cls_cv_formacion();
        ddlOtrosC_nombre.Items.Clear();
        ddlOtrosC_nombre.Items.Add("Seleccione..");
        ddlOtrosC_nombre.DataSource = formacion.ListadoConocimientos();
        ddlOtrosC_nombre.DataTextField = "cv_oc_conocimiento";
        ddlOtrosC_nombre.DataValueField = "cv_oc_id";
        ddlOtrosC_nombre.DataBind();
    }

    private void BindCursos()
    {
        cls_cv_formacion formacion = new cls_cv_formacion();
        ddlCursos_Curso.Items.Clear();
        ddlCursos_Curso.Items.Add("Seleccione..");
        ddlCursos_Curso.DataSource = formacion.ListadoCursos(0, "C2");
        ddlCursos_Curso.DataTextField = "cv_curs_nombre_curso";
        ddlCursos_Curso.DataValueField = "cv_curs_id";
        ddlCursos_Curso.DataBind();
    }

    private void BindCarreras()
    {
        cls_grado_academico formacion = new cls_grado_academico();
        ddlFormacionCarrera.Items.Clear();
        ddlFormacionCarrera.Items.Add("Seleccione..");
        ddlFormacionCarrera.DataSource = formacion.ComboFormacionCarreras("C2");
        ddlFormacionCarrera.DataTextField = "carr_nombre";
        ddlFormacionCarrera.DataValueField = "carr_id";
        ddlFormacionCarrera.DataBind();
    }

    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void BindGradoAcademico()
    {
        cls_grado_academico grado_academico = new cls_grado_academico();
        ddlFormacionNivel.Items.Clear();
        ddlFormacionNivel.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlFormacionNivel.DataSource = grado_academico.ObtenerGradoAcademico();
        ddlFormacionNivel.DataValueField = "ga_id";
        ddlFormacionNivel.DataTextField = "ga_nombre";
        ddlFormacionNivel.DataBind();
    }

    private void BindGridViewCursos(string per_id)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            gvCursos.DataSource = formacion.ObtenerGrilla_Cursos(Convert.ToInt32(per_id));
            gvCursos.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    private void BindGridViewFormacion(string per_id)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            gvFormacione.DataSource = formacion.ObtenerGrilla_Formacion(Convert.ToInt32(per_id));
            gvFormacione.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    private void BindGridViewTrayectoria(string per_id)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            gvTrayectoria.DataSource = formacion.ObtenerGrilla_Trayectoria(Convert.ToInt32(per_id));
            gvTrayectoria.DataBind();
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error grilla: " + ex.Message.Replace("'", "\\'").Replace("\r", " ").Replace("\n", " ") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    private void BindGridViewIdiomas(string per_id)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            gvIdiomas.DataSource = formacion.ObtenerGrilla_Idiomas(Convert.ToInt32(per_id));
            gvIdiomas.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    private void BindGridViewOtrosConocimientos(string per_id)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            gvOtrosConocimientos.DataSource = formacion.ObtenerGrilla_OtrosC(Convert.ToInt32(per_id));
            gvOtrosConocimientos.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    private void BindForm(string id)
    {
        cls_persona _persona = new cls_persona();
        DataSet dsPersona = _persona.ObtenerRegistroX(Convert.ToInt32(id));
        if (dsPersona != null && dsPersona.Tables.Count > 0 && dsPersona.Tables[0].Rows.Count > 0)
        {
            DataRow row = dsPersona.Tables[0].Rows[0];

            ltl_nombre_fun.Text = $"{row["per_nombres"]} {row["per_ap_paterno"]} {row["per_ap_materno"]}".Trim();
            ltl_num_doc.Text = $"{row["per_num_doc"]} - {ObtenerDescripcionCatalogo("departamento", row["per_lugar_exp"])}";
            ltl_estado_civil.Text = ObtenerDescripcionCatalogo("estado_civil", row["per_estado_civil"]);
            ltl_genero.Text = row["per_sexo"].ToString() == "M" ? "Masculino" : "Femenino";
            ltl_fecha_nac.Text = Convert.ToDateTime(row["per_fecha_nac"]).ToString("dd/MM/yyyy");
            ltl_pais.Text = ObtenerDescripcionCatalogo("pais", row["per_procedencia"]);

            cls_persona_domicilio domicilio = new cls_persona_domicilio();
            DataSet dsDomicilio = domicilio.ObtenerTablaGrilla("", id, "", "", "", "", "", "", "", "", "");
            if (dsDomicilio != null && dsDomicilio.Tables.Count > 0 && dsDomicilio.Tables[0].Rows.Count > 0)
            {
                DataRow rowDom = dsDomicilio.Tables[0].Rows[0];

                string tipoVia = ObtenerDescripcionCatalogo("tipo_via", rowDom["perd_tipo_via"]);
                string descripcion = rowDom["perd_descripcion_via"].ToString();
                string numero = rowDom["perd_numero"].ToString();
                ltl_direccion.Text = $"{tipoVia} {descripcion} Nro. {numero}".Trim();

                string ciudad = ObtenerDescripcionCatalogo("ciudad_localidad", rowDom["perd_ciudad_residencia"]);
                ltl_residencia.Text = ciudad;

                ltl_telef_domicilio.Text = rowDom["perd_telefono"].ToString();
                ltl_telef_movil.Text = rowDom["perd_celular"].ToString();
                ltl_email.Text = rowDom["perd_email_personal"].ToString();
            }
        }
    }

    private string ObtenerDescripcionCatalogo(string tabla, object id)
    {
        if (id == null || id == DBNull.Value || Convert.ToInt32(id) == 0)
            return "";

        try
        {
            cls_catalogo catalogo = new cls_catalogo { cat_tabla = tabla };
            DataSet ds = catalogo.ObtenerTablaCombo();
            if (ds != null && ds.Tables.Count > 0)
            {
                DataRow[] rows = ds.Tables[0].Select($"cat_id = {id}");
                if (rows.Length > 0)
                    return rows[0]["cat_descripcion"].ToString();
            }
        }
        catch { }
        return "";
    }

    private void Bind_Instituciones()
    {
        cls_grado_academico formacion = new cls_grado_academico();

        ddlFormacion_Institucion.Items.Clear();
        ddlFormacion_Institucion.Items.Add("Seleccione..");
        ddlFormacion_Institucion.DataSource = formacion.ComboFormacion("C2");
        ddlFormacion_Institucion.DataTextField = "it_nombre";
        ddlFormacion_Institucion.DataValueField = "it_id";
        ddlFormacion_Institucion.DataBind();

        ddlCursos_Institucion.Items.Clear();
        ddlCursos_Institucion.Items.Add("Seleccione..");
        ddlCursos_Institucion.DataSource = formacion.ComboFormacion("C7");
        ddlCursos_Institucion.DataTextField = "it_nombre";
        ddlCursos_Institucion.DataValueField = "it_id";
        ddlCursos_Institucion.DataBind();

        ddlTrayectoria_NuevaInstitucion.Items.Clear();
        ddlTrayectoria_NuevaInstitucion.Items.Add("Seleccione..");
        ddlTrayectoria_NuevaInstitucion.DataSource = formacion.ComboFormacion("C7");
        ddlTrayectoria_NuevaInstitucion.DataTextField = "it_nombre";
        ddlTrayectoria_NuevaInstitucion.DataValueField = "it_id";
        ddlTrayectoria_NuevaInstitucion.DataBind();
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        divCV.Visible = true;
        pnlBienvenida.Visible = false;
    }

    protected void gvFormacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetDelete":
                string form_id = gvFormacione.DataKeys[index].Values[0].ToString();
                cls_cv_formacion formacion = new cls_cv_formacion();
                formacion.cv_form_id = Convert.ToInt32(form_id);
                if (formacion.Eliminar())
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente la Formación Académica' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                break;
        }
        BindGridViewFormacion(HttpContext.Current.Session["per_id"].ToString());
    }

    protected void btnAdicionarFormacion_Click(object sender, EventArgs e)
    {
        if (ddlFormacion_Institucion.SelectedItem.Text != "Seleccione.." && ddlFormacionNivel.SelectedItem.Text != "Seleccione.." && ddlFormacionCarrera.SelectedItem.Text != "Seleccione..")
        {
            int per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString());

            cls_cv_formacion formacion = new cls_cv_formacion();
            int fechaFin = 0;
            if (!string.IsNullOrEmpty(txtFormacionAñoFin.Text))
                fechaFin = Convert.ToInt32(txtFormacionAñoFin.Text);

            formacion = new cls_cv_formacion
            {
                cv_ga_id = Convert.ToInt32(ddlFormacionNivel.SelectedValue),
                cv_inst_id = Convert.ToInt32(ddlFormacion_Institucion.SelectedValue),
                cv_carr_id = Convert.ToInt32(ddlFormacionCarrera.SelectedValue),
                cv_form_año_inicio = Convert.ToInt32(txtFormacionAñoInicio.Text),
                cv_form_año_fin = fechaFin,
                cv_form_prov_nal = rblFormacionProvision.SelectedItem.Text,
                cv_form_per_id = per_id
            };

            if (formacion.Adicionar())
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Formación Académica' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
            BindGridViewFormacion(per_id.ToString());
            ddlFormacionNivel.SelectedIndex = 0;
            ddlFormacion_Institucion.SelectedIndex = 0;
            ddlFormacionCarrera.SelectedIndex = 0;
            txtFormacionAñoInicio.Text = "";
            txtFormacionAñoFin.Text = "";
            rblFormacionProvision.ClearSelection();
        }
    }

    protected void btnFormacion_NuevaInst_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#ModalFormacion_InstitucionNueva').modal('show');";
        SetScript(sc, "");
    }

    protected void btnFormacion_NuevaCarrera_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#ModalFormacion_CarreraNueva').modal('show');";
        SetScript(sc, "");
    }

    protected void btnCursos_NuevaInstitucion_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#ModalCursos_InstitucionNueva').modal('show');";
        SetScript(sc, "");
    }

    protected void btnCursos_NuevoCurso_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#ModalCursos_CursoNuevo').modal('show');";
        SetScript(sc, "");
    }

    protected void btnTrayectoria_NuevaInstitucion_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#ModalTrayectoria_NuevaInstitucion').modal('show');";
        SetScript(sc, "");
    }

    protected void btnIdiomas_NuevoIdioma_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#ModalIdioma_NuevoIdioma').modal('show');";
        SetScript(sc, "");
    }

    protected void btnOtrosC_NuevoConocimiento_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#ModalOtrosC_NuevoC').modal('show');";
        SetScript(sc, "");
    }

    // ============================================================
    //  NUEVO: Registrar Experiencia con datepickers
    //  Extrae mes/año de la fecha para enviarlos al SP (que sigue
    //  recibiendo mes y año por separado).
    // ============================================================
    protected void btnAdicionarTrayectoria_Click(object sender, EventArgs e)
    {
        if (ddlTrayectoria_NuevaInstitucion.SelectedItem.Text != "Seleccione..")
        {
            int per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString());
            cls_cv_formacion formacion = new cls_cv_formacion();

            // 👇 Parsear fechas con formato fijo del input type=date
            DateTime fechaIni, fechaFin;
            if (!DateTime.TryParseExact(txtTrayectoriaFechaInicio.Text, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out fechaIni))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar una fecha de inicio válida.' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                return;
            }
            if (!DateTime.TryParseExact(txtTrayectoriaFechaFin.Text, "yyyy-MM-dd",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out fechaFin))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar una fecha de fin válida.' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                return;
            }
            if (fechaFin <= fechaIni)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'La fecha de fin debe ser posterior a la fecha de inicio.' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                return;
            }

            try
            {
                bool ok = formacion.Adicionar_CurriculumTrayectoria(
                    Convert.ToInt32(ddlTrayectoria_NuevaInstitucion.SelectedValue),
                    txtTrayectoriaEspecialidad.Text.Trim(),
                    txtTrayectoriaUltimoCargo.Text.Trim(),
                    fechaIni.ToString("yyyy-MM-dd"),
                    fechaFin.ToString("yyyy-MM-dd"),
                    "V",
                    per_id);

                if (ok)
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Experiencia Laboral' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            }
            catch (Exception ex)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: '" + ex.Message.Replace("'", "\\'").Replace("\r", " ").Replace("\n", " ") + "' }, { type: 'danger', placement: { from: 'bottom', align: 'right'} });";
            }

            SetScript(sc, "");
            BindGridViewTrayectoria(per_id.ToString());

            // Limpiar
            ddlTrayectoria_NuevaInstitucion.SelectedIndex = 0;
            txtTrayectoriaEspecialidad.Text = "";
            txtTrayectoriaUltimoCargo.Text = "";
            txtTrayectoriaFechaInicio.Text = "";
            txtTrayectoriaFechaFin.Text = "";
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar una institución' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }
    }

    protected void btnAdicionarIdiomas_Click(object sender, EventArgs e)
    {
        if (ddlIdiomas_Idioma.SelectedItem.Text != "Seleccione..")
        {
            int per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString());
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.Adicionar_CurriculumIdioma(per_id, Convert.ToInt32(ddlIdiomas_Idioma.SelectedValue), "V", ddlIdiomasNivel.SelectedItem.Text))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Idioma' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";

            SetScript(sc, "");
            BindGridViewIdiomas(per_id.ToString());
            ddlIdiomas_Idioma.SelectedIndex = 0;
            ddlIdiomasNivel.SelectedIndex = 0;
        }
    }

    protected void btnAdicionarOtroConocimiento_Click(object sender, EventArgs e)
    {
        if (ddlOtrosC_nombre.SelectedItem.Text != "Seleccione..")
        {
            int per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString());
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.Adicionar_CurriculumOtrosC(per_id, Convert.ToInt32(ddlOtrosC_nombre.SelectedValue), "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Conocimiento' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";

            SetScript(sc, "");
            BindGridViewOtrosConocimientos(per_id.ToString());
            ddlOtrosC_nombre.SelectedIndex = 0;
        }
    }

    protected void btnAdicionarCursos_Click(object sender, EventArgs e)
    {
        if (ddlCursos_Institucion.SelectedItem.Text != "Seleccione.." && ddlCursos_Curso.SelectedItem.Text != "Seleccione..")
        {
            int per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString());
            cls_cv_formacion formacion = new cls_cv_formacion();

            if (formacion.Adicionar_CurriculumCurso(per_id, Convert.ToInt32(ddlCursos_Curso.SelectedValue), Convert.ToInt32(ddlCursos_Institucion.SelectedValue), Convert.ToInt32(txtCursosDias.Text), "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Curso' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
            BindGridViewCursos(per_id.ToString());
            ddlCursos_Institucion.SelectedIndex = 0;
            ddlCursos_Curso.SelectedIndex = 0;
            txtCursosDias.Text = "";
        }
    }

    protected void gvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetDelete":
                string per_id = gvCursos.DataKeys[index].Values[0].ToString();
                string curs_id = gvCursos.DataKeys[index].Values[1].ToString();
                cls_cv_formacion formacion = new cls_cv_formacion();
                if (formacion.Eliminar_CurriculumCursos(Convert.ToInt32(per_id), Convert.ToInt32(curs_id)))
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente el Curso' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                break;
        }
        BindGridViewCursos(HttpContext.Current.Session["per_id"].ToString());
    }

    protected void gvTrayectoria_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetDelete":
                string form_id = gvTrayectoria.DataKeys[index].Values[0].ToString();
                cls_cv_formacion formacion = new cls_cv_formacion();
                if (formacion.Eliminar_CurriculumTrayectoria(Convert.ToInt32(form_id)))
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente la Trayectoria Laboral' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                break;
        }
        BindGridViewTrayectoria(HttpContext.Current.Session["per_id"].ToString());
    }

    protected void gvIdiomas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetDelete":
                string per_id = gvIdiomas.DataKeys[index].Values[0].ToString();
                string idio_id = gvIdiomas.DataKeys[index].Values[1].ToString();
                cls_cv_formacion formacion = new cls_cv_formacion();
                if (formacion.Eliminar_CurriculumIdioma(Convert.ToInt32(per_id), Convert.ToInt32(idio_id)))
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente el Idioma' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                break;
        }
        BindGridViewIdiomas(HttpContext.Current.Session["per_id"].ToString());
    }

    protected void gvOtrosConocimientos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetDelete":
                string per_id = gvOtrosConocimientos.DataKeys[index].Values[0].ToString();
                string oc_id = gvOtrosConocimientos.DataKeys[index].Values[1].ToString();
                cls_cv_formacion formacion = new cls_cv_formacion();
                if (formacion.Eliminar_CurriculumOtrosC(Convert.ToInt32(per_id), Convert.ToInt32(oc_id)))
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente el Conocimiento' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                break;
        }
        BindGridViewOtrosConocimientos(HttpContext.Current.Session["per_id"].ToString());
    }

    protected void btnFormacion_AdicionarInstitucion_Click(object sender, EventArgs e)
    {
        if (txtFormacion_NuevaInstitucion.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarFormacion_Insitucion(txtFormacion_NuevaInstitucion.Text, 0, "V", 0, 0, "formación"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Institución' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";

            SetScript(sc, "");
            Bind_Instituciones();
            txtFormacion_NuevaInstitucion.Text = "";
            sc = "$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnFormacion_AdicionarCarrera_Click(object sender, EventArgs e)
    {
        if (txtFormacion_NuevaCarrera.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarFormacion_Carrera(txtFormacion_NuevaCarrera.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Carrera' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";

            SetScript(sc, "");
            BindCarreras();
            txtFormacion_NuevaCarrera.Text = "";
            sc = "$('#ModalFormacion_CarreraNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnCursos_AdicionarInstitucion_Click(object sender, EventArgs e)
    {
        if (txtCursos_NuevaInstitucion.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarCursos_Insitucion(txtCursos_NuevaInstitucion.Text, 0, "V", 0, 0, "cursos"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Institución' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";

            SetScript(sc, "");
            Bind_Instituciones();
            txtCursos_NuevaInstitucion.Text = "";
            sc = "$('#ModalCursos_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnCursos_AdicionarCurso_Click(object sender, EventArgs e)
    {
        if (txtCursos_NuevoCurso.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarCursos_Curso(txtCursos_NuevoCurso.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Curso' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";

            SetScript(sc, "");
            BindCursos();
            txtCursos_NuevoCurso.Text = "";
            sc = "$('#ModalCursos_CursoNuevo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnTrayectoria_AdicionarNuevaInstitucion_Click(object sender, EventArgs e)
    {
        if (txtTrayectoria_NuevaInstitucion.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarTrayectoria_Insitucion(txtTrayectoria_NuevaInstitucion.Text, 0, "V", 0, 0, "trayectoria"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Institución' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";

            SetScript(sc, "");
            Bind_Instituciones();
            txtTrayectoria_NuevaInstitucion.Text = "";
            sc = "$('#ModalTrayectoria_NuevaInstitucion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnIdioma_NuevoIdioma_Click(object sender, EventArgs e)
    {
        if (txtIdioma_NuevoIdioma.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarNuevoIdioma(txtIdioma_NuevoIdioma.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Idioma' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";

            SetScript(sc, "");
            BindIdiomas();
            txtIdioma_NuevoIdioma.Text = "";
            sc = "$('#ModalIdioma_NuevoIdioma').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnNuevoC_NuevoC_Click(object sender, EventArgs e)
    {
        if (txtNuevoC_NuevoC.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarNuevoConocimiento(txtNuevoC_NuevoC.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Conocimiento' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";

            SetScript(sc, "");
            BindOtrosConocimientos();
            txtNuevoC_NuevoC.Text = "";
            sc = "$('#ModalOtrosC_NuevoC').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    // ============================================================
    //  NUEVO: Guardar CV (solo mensaje, sin redirigir)
    // ============================================================
    protected void btnGuardarCV_Click(object sender, EventArgs e)
    {
        try
        {
            string per_id = Session["per_id"]?.ToString();
            if (string.IsNullOrEmpty(per_id))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se identificó al funcionario.' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                return;
            }

            int perIdNum = Convert.ToInt32(per_id);
            cls_cv_formacion formacion = new cls_cv_formacion();

            bool tieneFormacion = false;
            bool tieneExperiencia = false;

            try
            {
                DataSet dsForm = formacion.ObtenerGrilla_Formacion(perIdNum);
                tieneFormacion = dsForm != null && dsForm.Tables.Count > 0 && dsForm.Tables[0].Rows.Count > 0;

                DataSet dsExp = formacion.ObtenerGrilla_Trayectoria(perIdNum);
                tieneExperiencia = dsExp != null && dsExp.Tables.Count > 0 && dsExp.Tables[0].Rows.Count > 0;
            }
            catch { }

            if (!tieneFormacion)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation-triangle', message: 'Debe registrar al menos un registro de Formación Académica antes de guardar.' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                return;
            }

            if (!tieneExperiencia)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation-triangle', message: 'Debe registrar al menos una Experiencia Laboral antes de guardar.' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");
                return;
            }

            sc = "Swal.fire({ " +
                 "icon: 'success', " +
                 "title: 'Currículum guardado', " +
                 "text: 'La información se guardó correctamente.', " +
                 "timer: 2500, " +
                 "showConfirmButton: false, " +
                 "allowOutsideClick: false " +
                 "});";
            SetScript(sc, "");
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    protected void btnImprimirCv_Click(object sender, EventArgs e)
    {
        sc = "window.open('ImprimirCV.aspx', 'width=300,height=300', '_blank');";
        SetScript(sc, ", dropdownParent: $('#addModal')");
    }

    private void limpiarModales()
    {
        txtFormacion_NuevaInstitucion.Text = "";
        txtFormacion_NuevaCarrera.Text = "";
        txtCursos_NuevaInstitucion.Text = "";
        txtCursos_NuevoCurso.Text = "";
        txtTrayectoria_NuevaInstitucion.Text = "";
        txtIdioma_NuevoIdioma.Text = "";
        txtNuevoC_NuevoC.Text = "";
    }
}