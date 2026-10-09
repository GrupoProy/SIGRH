using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;

public partial class Precontratacion_CurriculumCandidato : System.Web.UI.Page
{
    private string sc = "";
    private int per_id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                string modo = Request.QueryString["modo"] ?? "";
                string perIdParam = Request.QueryString["per_id"] ?? "";
                string ciParam = Request.QueryString["ci"] ?? "";

                if (!string.IsNullOrEmpty(perIdParam))
                    per_id = Convert.ToInt32(perIdParam);
                else if (!string.IsNullOrEmpty(ciParam))
                    per_id = ObtenerPerIdPorCI(ciParam);
                else if (Session["PerIdPendiente"] != null)
                    per_id = Convert.ToInt32(Session["PerIdPendiente"]);
                else
                    per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"]);

                if (per_id == 0)
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se encontró el candidato. Primero registre los datos personales.' }, { type: 'danger' });";
                    SetScript(sc, "");
                    Response.Redirect("SolicitudContratacion.aspx");
                    return;
                }

                hfPerId.Value = per_id.ToString();

                bool tieneCurriculum = VerificarCurriculumExistente(per_id);

                if (string.IsNullOrEmpty(modo))
                {
                    if (tieneCurriculum)
                        Response.Redirect("CurriculumCandidato.aspx?per_id=" + per_id + "&modo=ver");
                    else
                        Response.Redirect("CurriculumCandidato.aspx?per_id=" + per_id + "&modo=nuevo");
                    return;
                }

                BindForm(per_id.ToString());

                BindGradoAcademico();
                BindInstituciones();
                BindCarreras();
                BindCursos();
                BindIdiomas();
                BindOtrosConocimientos();

                BindGridViewFormacion(per_id.ToString());
                BindGridViewCursos(per_id.ToString());
                BindGridViewTrayectoria(per_id.ToString());
                BindGridViewIdiomas(per_id.ToString());
                BindGridViewOtrosConocimientos(per_id.ToString());

                switch (modo)
                {
                    case "nuevo":
                        sc = "$.notify({ icon: 'fas fa-info-circle', message: 'Nuevo candidato. Complete todo el curriculum.' }, { type: 'info', delay: 5000 });";
                        SetScript(sc, "");
                        break;
                    case "completar":
                    case "edicion":
                        sc = "$.notify({ icon: 'fas fa-exclamation-triangle', message: 'Curriculum incompleto. Complete los campos obligatorios.' }, { type: 'warning', delay: 6000 });";
                        SetScript(sc, "");
                        break;
                    case "ver":
                        sc = "$.notify({ icon: 'fas fa-check-circle', message: 'Curriculum completo. Visualizando información...' }, { type: 'success' });";
                        SetScript(sc, "");
                        DeshabilitarEdicion(true);
                        break;
                    default:
                        if (tieneCurriculum)
                            sc = "$.notify({ icon: 'fas fa-info', message: 'Editando curriculum existente' }, { type: 'info' });";
                        else
                            sc = "$.notify({ icon: 'fas fa-info', message: 'Complete el curriculum' }, { type: 'info' });";
                        SetScript(sc, "");
                        break;
                }
            }
        }
        else
        {
            Response.Redirect("../Index");
        }
    }

    private void BindForm(string id)
    {
        try
        {
            cls_persona _persona = new cls_persona();
            DataSet ds = _persona.ObtenerRegistroX(Convert.ToInt32(id));

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                ltlNombreCompleto.Text = ValidarCampo(row["per_nombres"]) + " " +
                                         ValidarCampo(row["per_ap_paterno"]) + " " +
                                         ValidarCampo(row["per_ap_materno"]);

                ltlCarnet.Text = ValidarCampo(row["per_num_doc"]);

                ltlFechaNac.Text = row["per_fecha_nac"] != DBNull.Value
                    ? Convert.ToDateTime(row["per_fecha_nac"]).ToString("dd/MM/yyyy")
                    : "";

                string sexo = ValidarCampo(row["per_sexo"]);
                ltlSexo.Text = sexo == "M" ? "Masculino" : sexo == "F" ? "Femenino" : "";

                ltlEstadoCivil.Text = ObtenerDescripcion("estado_civil", ValidarCampo(row["per_estado_civil"]));
                ltlNacionalidad.Text = ObtenerDescripcion("pais", ValidarCampo(row["per_procedencia"]));

                cls_persona_domicilio domicilio = new cls_persona_domicilio();
                DataSet dsDomicilio = domicilio.ObtenerTablaGrilla("", id, "", "", "", "", "", "", "", "", "");

                if (dsDomicilio != null && dsDomicilio.Tables.Count > 0 && dsDomicilio.Tables[0].Rows.Count > 0)
                {
                    DataRow domicilioRow = dsDomicilio.Tables[0].Rows[0];

                    ltlEmail.Text = ValidarCampo(domicilioRow["perd_email_personal"]);
                    ltlTelefono.Text = ValidarCampo(domicilioRow["perd_telefono"]);
                    ltlCelular.Text = ValidarCampo(domicilioRow["perd_celular"]);
                    ltlCiudad.Text = ObtenerDescripcion("ciudad_localidad", ValidarCampo(domicilioRow["perd_ciudad_residencia"]));
                    ltlDireccion.Text = ValidarCampo(domicilioRow["perd_descripcion_via"]) + " N° " + ValidarCampo(domicilioRow["perd_numero"]);
                }
                else
                {
                    ltlEmail.Text = "No registrado";
                    ltlTelefono.Text = "No registrado";
                    ltlCelular.Text = "No registrado";
                    ltlCiudad.Text = "No registrada";
                    ltlDireccion.Text = "No registrada";
                }
            }
            else
            {
                ltlNombreCompleto.Text = "No registrado";
                ltlFechaNac.Text = "No registrada";
                ltlCarnet.Text = "No registrado";
                ltlSexo.Text = "No registrado";
                ltlEmail.Text = "No registrado";
                ltlTelefono.Text = "No registrado";
                ltlCelular.Text = "No registrado";
                ltlEstadoCivil.Text = "No registrado";
                ltlCiudad.Text = "No registrada";
                ltlNacionalidad.Text = "No registrada";
                ltlDireccion.Text = "No registrada";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar datos: " + ex.Message);
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al cargar datos personales' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    private string ValidarCampo(object valor)
    {
        return (valor == null || valor == DBNull.Value) ? "" : valor.ToString().Trim();
    }

    private string ObtenerDescripcion(string tabla, string id)
    {
        if (string.IsNullOrEmpty(id) || id == "0") return "";

        try
        {
            cls_catalogo catalogo = new cls_catalogo { cat_tabla = tabla };
            DataSet ds = catalogo.ObtenerTablaCombo();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow[] rows = ds.Tables[0].Select("cat_id = " + id);
                return rows.Length > 0 ? rows[0]["cat_descripcion"].ToString() : id;
            }
            return id;
        }
        catch { return id; }
    }

    private int ObtenerPerIdPorCI(string ci)
    {
        try
        {
            cls_persona persona = new cls_persona();
            DataSet ds = persona.VerificarNuevoFuncionario(ci, 0);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                return Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"]);
            return 0;
        }
        catch { return 0; }
    }

    private bool VerificarCurriculumExistente(int perId)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            DataSet ds = formacion.ObtenerGrilla_Formacion(perId);
            return ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0;
        }
        catch { return false; }
    }

    private void DeshabilitarEdicion(bool deshabilitar)
    {
        btnAdicionarFormacion.Enabled = !deshabilitar;
        btnAdicionarCursos.Enabled = !deshabilitar;
        btnAdicionarTrayectoria.Enabled = !deshabilitar;
        btnAdicionarIdiomas.Enabled = !deshabilitar;
        btnAdicionarOtroConocimiento.Enabled = !deshabilitar;

        btnFormacion_NuevaInst.Enabled = !deshabilitar;
        btnFormacion_NuevaCarrera.Enabled = !deshabilitar;
        btnCursos_NuevaInstitucion.Enabled = !deshabilitar;
        btnCursos_NuevoCurso.Enabled = !deshabilitar;
        btnTrayectoria_NuevaInstitucion.Enabled = !deshabilitar;
        btnIdiomas_NuevoIdioma.Enabled = !deshabilitar;
        btnOtrosC_NuevoConocimiento.Enabled = !deshabilitar;

        ViewState["ModoLectura"] = deshabilitar;
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

    private void BindInstituciones()
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
            Notificar("❌ " + ex.Message, "danger");
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

    protected void gvFormacione_PreRender(object sender, EventArgs e)
    {
        if (gvFormacione.Rows.Count > 0)
        {
            gvFormacione.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (gvFormacione.FooterRow != null)
                gvFormacione.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        if (ViewState["ModoLectura"] != null && (bool)ViewState["ModoLectura"])
            if (gvFormacione.Columns.Count > 0)
                gvFormacione.Columns[gvFormacione.Columns.Count - 1].Visible = false;
    }

    protected void gvTrayectoria_PreRender(object sender, EventArgs e)
    {
        if (gvTrayectoria.Rows.Count > 0)
        {
            gvTrayectoria.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (gvTrayectoria.FooterRow != null)
                gvTrayectoria.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        if (ViewState["ModoLectura"] != null && (bool)ViewState["ModoLectura"])
            if (gvTrayectoria.Columns.Count > 0)
                gvTrayectoria.Columns[gvTrayectoria.Columns.Count - 1].Visible = false;
    }

    protected void gvCursos_PreRender(object sender, EventArgs e)
    {
        if (gvCursos.Rows.Count > 0)
        {
            gvCursos.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (gvCursos.FooterRow != null)
                gvCursos.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        if (ViewState["ModoLectura"] != null && (bool)ViewState["ModoLectura"])
            if (gvCursos.Columns.Count > 0)
                gvCursos.Columns[gvCursos.Columns.Count - 1].Visible = false;
    }

    protected void gvIdiomas_PreRender(object sender, EventArgs e)
    {
        if (gvIdiomas.Rows.Count > 0)
        {
            gvIdiomas.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (gvIdiomas.FooterRow != null)
                gvIdiomas.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        if (ViewState["ModoLectura"] != null && (bool)ViewState["ModoLectura"])
            if (gvIdiomas.Columns.Count > 0)
                gvIdiomas.Columns[gvIdiomas.Columns.Count - 1].Visible = false;
    }

    protected void gvOtrosConocimientos_PreRender(object sender, EventArgs e)
    {
        if (gvOtrosConocimientos.Rows.Count > 0)
        {
            gvOtrosConocimientos.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (gvOtrosConocimientos.FooterRow != null)
                gvOtrosConocimientos.FooterRow.TableSection = TableRowSection.TableFooter;
        }
        if (ViewState["ModoLectura"] != null && (bool)ViewState["ModoLectura"])
            if (gvOtrosConocimientos.Columns.Count > 0)
                gvOtrosConocimientos.Columns[gvOtrosConocimientos.Columns.Count - 1].Visible = false;
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
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente la Formación Académica' }, { type: 'success' });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning' });";
                SetScript(sc, "");
                break;
        }
        BindGridViewFormacion(hfPerId.Value);
    }

    protected void gvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetDelete":
                string per_id_gv = gvCursos.DataKeys[index].Values[0].ToString();
                string curs_id = gvCursos.DataKeys[index].Values[1].ToString();
                cls_cv_formacion formacion = new cls_cv_formacion();
                if (formacion.Eliminar_CurriculumCursos(Convert.ToInt32(per_id_gv), Convert.ToInt32(curs_id)))
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente el Curso' }, { type: 'success' });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning' });";
                SetScript(sc, "");
                break;
        }
        BindGridViewCursos(hfPerId.Value);
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
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente la Trayectoria Laboral' }, { type: 'success' });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning' });";
                SetScript(sc, "");
                break;
        }
        BindGridViewTrayectoria(hfPerId.Value);
    }

    protected void gvIdiomas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetDelete":
                string per_id_gv = gvIdiomas.DataKeys[index].Values[0].ToString();
                string idio_id = gvIdiomas.DataKeys[index].Values[1].ToString();
                cls_cv_formacion formacion = new cls_cv_formacion();
                if (formacion.Eliminar_CurriculumIdioma(Convert.ToInt32(per_id_gv), Convert.ToInt32(idio_id)))
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente el Idioma' }, { type: 'success' });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning' });";
                SetScript(sc, "");
                break;
        }
        BindGridViewIdiomas(hfPerId.Value);
    }

    protected void gvOtrosConocimientos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetDelete":
                string per_id_gv = gvOtrosConocimientos.DataKeys[index].Values[0].ToString();
                string oc_id = gvOtrosConocimientos.DataKeys[index].Values[1].ToString();
                cls_cv_formacion formacion = new cls_cv_formacion();
                if (formacion.Eliminar_CurriculumOtrosC(Convert.ToInt32(per_id_gv), Convert.ToInt32(oc_id)))
                    sc = "$.notify({ icon: 'fas fa-check', message: 'Se eliminó correctamente el Conocimiento' }, { type: 'success' });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning' });";
                SetScript(sc, "");
                break;
        }
        BindGridViewOtrosConocimientos(hfPerId.Value);
    }

    protected void btnAdicionarFormacion_Click(object sender, EventArgs e)
    {
        if (ddlFormacion_Institucion.SelectedItem.Text != "Seleccione.." &&
            ddlFormacionNivel.SelectedItem.Text != "Seleccione.." &&
            ddlFormacionCarrera.SelectedItem.Text != "Seleccione..")
        {
            int perId = Convert.ToInt32(hfPerId.Value);

            cls_cv_formacion formacion = new cls_cv_formacion();
            int fechaFin = 0;
            if (!string.IsNullOrEmpty(txtFormacionAñoFin.Text))
                fechaFin = Convert.ToInt32(txtFormacionAñoFin.Text);

            formacion.cv_ga_id = Convert.ToInt32(ddlFormacionNivel.SelectedValue);
            formacion.cv_inst_id = Convert.ToInt32(ddlFormacion_Institucion.SelectedValue);
            formacion.cv_carr_id = Convert.ToInt32(ddlFormacionCarrera.SelectedValue);
            formacion.cv_form_año_inicio = Convert.ToInt32(txtFormacionAñoInicio.Text);
            formacion.cv_form_año_fin = fechaFin;
            formacion.cv_form_prov_nal = rblFormacionProvision.SelectedItem.Text;
            formacion.cv_form_per_id = perId;

            if (formacion.Adicionar())
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Formación Académica' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindGridViewFormacion(perId.ToString());
            LimpiarFormacion();
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Complete todos los campos de formación' }, { type: 'warning' });";
            SetScript(sc, "");
        }
    }

    private void LimpiarFormacion()
    {
        ddlFormacionNivel.SelectedIndex = 0;
        ddlFormacion_Institucion.SelectedIndex = 0;
        ddlFormacionCarrera.SelectedIndex = 0;
        txtFormacionAñoInicio.Text = "";
        txtFormacionAñoFin.Text = "";
        rblFormacionProvision.ClearSelection();
    }

    protected void btnAdicionarCursos_Click(object sender, EventArgs e)
    {
        if (ddlCursos_Institucion.SelectedItem.Text != "Seleccione.." &&
            ddlCursos_Curso.SelectedItem.Text != "Seleccione..")
        {
            int perId = Convert.ToInt32(hfPerId.Value);
            cls_cv_formacion formacion = new cls_cv_formacion();

            if (formacion.Adicionar_CurriculumCurso(perId,
                Convert.ToInt32(ddlCursos_Curso.SelectedValue),
                Convert.ToInt32(ddlCursos_Institucion.SelectedValue),
                Convert.ToInt32(txtCursosDias.Text), "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Curso' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindGridViewCursos(perId.ToString());
            LimpiarCursos();
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Complete todos los campos del curso' }, { type: 'warning' });";
            SetScript(sc, "");
        }
    }

    private void LimpiarCursos()
    {
        ddlCursos_Institucion.SelectedIndex = 0;
        ddlCursos_Curso.SelectedIndex = 0;
        txtCursosDias.Text = "";
    }

    private void Notificar(string mensaje, string tipo)
    {
        string icono = tipo == "success" ? "fas fa-check"
                     : tipo == "warning" ? "fas fa-exclamation-triangle"
                     : tipo == "danger" ? "fas fa-exclamation"
                     : "fas fa-info-circle";

        // Escape completo para no romper el JS si el SP lanza un RAISERROR
        string msg = (mensaje ?? "")
            .Replace("\\", "\\\\")
            .Replace("'", "\\'")
            .Replace("\"", "\\\"")
            .Replace("\r", " ")
            .Replace("\n", " ");

        sc = $"$.notify({{ icon: '{icono}', message: '{msg}' }}, {{ type: '{tipo}' }});";
        SetScript(sc, "");
    }

    // ============================================================
    //  NUEVO: Registrar Experiencia con datepickers
    //  Extrae mes/año de la fecha para enviarlos al SP
    // ============================================================
    protected void btnAdicionarTrayectoria_Click(object sender, EventArgs e)
    {
        // 1) Validar institución
        if (ddlTrayectoria_NuevaInstitucion.SelectedItem.Text == "Seleccione..")
        {
            Notificar("Seleccione una institución", "warning");
            return;
        }

        // 2) Validar campos de texto
        if (string.IsNullOrWhiteSpace(txtTrayectoriaEspecialidad.Text) ||
            string.IsNullOrWhiteSpace(txtTrayectoriaUltimoCargo.Text))
        {
            Notificar("Complete Área de Especialidad y Último Cargo", "warning");
            return;
        }

        // 3) Validar fechas (input type=date siempre manda yyyy-MM-dd)
        DateTime fechaIni, fechaFin;
        if (!DateTime.TryParseExact(txtTrayectoriaFechaInicio.Text, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out fechaIni))
        {
            Notificar("Debe ingresar una fecha de inicio válida", "warning");
            return;
        }

        if (!DateTime.TryParseExact(txtTrayectoriaFechaFin.Text, "yyyy-MM-dd",
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None, out fechaFin))
        {
            Notificar("Debe ingresar una fecha de fin válida", "warning");
            return;
        }

        if (fechaFin <= fechaIni)
        {
            Notificar("La fecha de fin debe ser posterior a la fecha de inicio", "warning");
            return;
        }

        // 4) Guardar
        try
        {
            int perId = Convert.ToInt32(hfPerId.Value);
            int instId = Convert.ToInt32(ddlTrayectoria_NuevaInstitucion.SelectedValue);

            cls_cv_formacion formacion = new cls_cv_formacion();
            bool ok = formacion.Adicionar_CurriculumTrayectoria(
                instId,
                txtTrayectoriaEspecialidad.Text.Trim(),
                txtTrayectoriaUltimoCargo.Text.Trim(),
                fechaIni.ToString("yyyy-MM-dd"),
                fechaFin.ToString("yyyy-MM-dd"),
                "V",
                perId);

            if (ok)
            {
                Notificar("Se adicionó correctamente la Experiencia Laboral", "success");
                BindGridViewTrayectoria(perId.ToString());
                LimpiarTrayectoria();
            }
            else
            {
                Notificar("No se pudo registrar la información", "warning");
            }
        }
        catch (Exception ex)
        {
            Notificar(ex.Message, "warning");
        }
    }
    private void LimpiarTrayectoria()
    {
        ddlTrayectoria_NuevaInstitucion.SelectedIndex = 0;
        txtTrayectoriaEspecialidad.Text = "";
        txtTrayectoriaUltimoCargo.Text = "";
        txtTrayectoriaFechaInicio.Text = "";
        txtTrayectoriaFechaFin.Text = "";
    }

    protected void btnAdicionarIdiomas_Click(object sender, EventArgs e)
    {
        if (ddlIdiomas_Idioma.SelectedItem.Text != "Seleccione..")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.Adicionar_CurriculumIdioma(
                Convert.ToInt32(hfPerId.Value),
                Convert.ToInt32(ddlIdiomas_Idioma.SelectedValue),
                "V",
                ddlIdiomasNivel.SelectedItem.Text))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Idioma' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindGridViewIdiomas(hfPerId.Value);
            LimpiarIdiomas();
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Seleccione un idioma' }, { type: 'warning' });";
            SetScript(sc, "");
        }
    }

    private void LimpiarIdiomas()
    {
        ddlIdiomas_Idioma.SelectedIndex = 0;
        ddlIdiomasNivel.SelectedIndex = 0;
    }

    protected void btnAdicionarOtroConocimiento_Click(object sender, EventArgs e)
    {
        if (ddlOtrosC_nombre.SelectedItem.Text != "Seleccione..")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.Adicionar_CurriculumOtrosC(
                Convert.ToInt32(hfPerId.Value),
                Convert.ToInt32(ddlOtrosC_nombre.SelectedValue),
                "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Conocimiento' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindGridViewOtrosConocimientos(hfPerId.Value);
            LimpiarOtrosConocimientos();
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Seleccione un conocimiento' }, { type: 'warning' });";
            SetScript(sc, "");
        }
    }

    private void LimpiarOtrosConocimientos()
    {
        ddlOtrosC_nombre.SelectedIndex = 0;
    }

    protected void btnFormacion_NuevaInst_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#modalFormacion_InstitucionNueva').modal('show');";
        SetScript(sc, "");
    }

    protected void btnFormacion_NuevaCarrera_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#modalFormacion_CarreraNueva').modal('show');";
        SetScript(sc, "");
    }

    protected void btnCursos_NuevaInstitucion_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#modalCursos_InstitucionNueva').modal('show');";
        SetScript(sc, "");
    }

    protected void btnCursos_NuevoCurso_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#modalCursos_CursoNuevo').modal('show');";
        SetScript(sc, "");
    }

    protected void btnTrayectoria_NuevaInstitucion_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#modalTrayectoria_NuevaInstitucion').modal('show');";
        SetScript(sc, "");
    }

    protected void btnIdiomas_NuevoIdioma_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#modalIdioma_NuevoIdioma').modal('show');";
        SetScript(sc, "");
    }

    protected void btnOtrosC_NuevoConocimiento_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#modalOtrosC_NuevoC').modal('show');";
        SetScript(sc, "");
    }

    protected void btnFormacion_AdicionarInstitucion_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtFormacion_NuevaInstitucion.Text))
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarFormacion_Insitucion(txtFormacion_NuevaInstitucion.Text, 0, "V", 0, 0, "formación"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Institución' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindInstituciones();
            SeleccionarUltimoItem(ddlFormacion_Institucion, txtFormacion_NuevaInstitucion.Text);
            txtFormacion_NuevaInstitucion.Text = "";
            sc = "$('#modalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnFormacion_AdicionarCarrera_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtFormacion_NuevaCarrera.Text))
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarFormacion_Carrera(txtFormacion_NuevaCarrera.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Carrera' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindCarreras();
            SeleccionarUltimoItem(ddlFormacionCarrera, txtFormacion_NuevaCarrera.Text);
            txtFormacion_NuevaCarrera.Text = "";
            sc = "$('#modalFormacion_CarreraNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnCursos_AdicionarInstitucion_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtCursos_NuevaInstitucion.Text))
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarCursos_Insitucion(txtCursos_NuevaInstitucion.Text, 0, "V", 0, 0, "cursos"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Institución' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindInstituciones();
            SeleccionarUltimoItem(ddlCursos_Institucion, txtCursos_NuevaInstitucion.Text);
            txtCursos_NuevaInstitucion.Text = "";
            sc = "$('#modalCursos_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnCursos_AdicionarCurso_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtCursos_NuevoCurso.Text))
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarCursos_Curso(txtCursos_NuevoCurso.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Curso' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindCursos();
            SeleccionarUltimoItem(ddlCursos_Curso, txtCursos_NuevoCurso.Text);
            txtCursos_NuevoCurso.Text = "";
            sc = "$('#modalCursos_CursoNuevo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnTrayectoria_AdicionarNuevaInstitucion_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtTrayectoria_NuevaInstitucion.Text))
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarTrayectoria_Insitucion(txtTrayectoria_NuevaInstitucion.Text, 0, "V", 0, 0, "trayectoria"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente la Institución' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindInstituciones();
            SeleccionarUltimoItem(ddlTrayectoria_NuevaInstitucion, txtTrayectoria_NuevaInstitucion.Text);
            txtTrayectoria_NuevaInstitucion.Text = "";
            sc = "$('#modalTrayectoria_NuevaInstitucion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnIdioma_NuevoIdioma_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtIdioma_NuevoIdioma.Text))
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarNuevoIdioma(txtIdioma_NuevoIdioma.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Idioma' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindIdiomas();
            SeleccionarUltimoItem(ddlIdiomas_Idioma, txtIdioma_NuevoIdioma.Text);
            txtIdioma_NuevoIdioma.Text = "";
            sc = "$('#modalIdioma_NuevoIdioma').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    protected void btnNuevoC_NuevoC_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txtNuevoC_NuevoC.Text))
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarNuevoConocimiento(txtNuevoC_NuevoC.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se adicionó correctamente el Conocimiento' }, { type: 'success' });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning' });";

            SetScript(sc, "");
            BindOtrosConocimientos();
            SeleccionarUltimoItem(ddlOtrosC_nombre, txtNuevoC_NuevoC.Text);
            txtNuevoC_NuevoC.Text = "";
            sc = "$('#modalOtrosC_NuevoC').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
    }

    private void SeleccionarUltimoItem(DropDownList ddl, string texto)
    {
        foreach (ListItem item in ddl.Items)
        {
            if (item.Text.ToUpper().Trim() == texto.ToUpper().Trim())
            {
                ddl.SelectedValue = item.Value;
                return;
            }
        }
        if (ddl.Items.Count > 0)
            ddl.SelectedIndex = ddl.Items.Count - 1;
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

    protected void btnGuardarCurriculum_Click(object sender, EventArgs e)
    {
        try
        {
            int perId = Convert.ToInt32(hfPerId.Value);

            if (perId == 0)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se encontró el ID del funcionario' }, { type: 'danger' });";
                SetScript(sc, "");
                return;
            }

            bool tieneFormacion = VerificarCurriculumExistente(perId);

            if (!tieneFormacion)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe registrar al menos una Formación Académica para guardar el curriculum' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            sc = "$.notify({ icon: 'fas fa-check', message: '✅ Curriculum guardado correctamente' }, { type: 'success' });";
            SetScript(sc, "");

            Response.Redirect("CurriculumCandidato.aspx?per_id=" + perId + "&modo=ver");
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al guardar: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    protected void btnAtras_Click(object sender, EventArgs e)
    {
        try
        {
            int perId = Convert.ToInt32(hfPerId.Value);
            Response.Redirect("SolicitudContratacion.aspx?per_id=" + perId);
        }
        catch
        {
            Response.Redirect("SolicitudContratacion.aspx");
        }
    }

    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$('.radios label').addClass('custom-control-label mb-3');");
        sb.Append("$('.radios input[type=\"radio\"]').addClass('custom-control-input mb-3');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void SetScript(string val)
    {
        SetScript(val, "");
    }
}