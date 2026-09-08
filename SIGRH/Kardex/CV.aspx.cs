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
        // Obtener per_id de la sesión o del QueryString
        string per_id = Session["per_id"]?.ToString();
        string perIdQuery = Request.QueryString["per_id"];

        // Priorizar el QueryString si existe
        if (!string.IsNullOrEmpty(perIdQuery))
        {
            per_id = perIdQuery;
            // También podrías guardarlo en sesión para futuras peticiones
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
        ddlOtrosC_nombre.DataSource = formacion.ListadoConocimientos();
        ddlOtrosC_nombre.DataTextField = "cv_oc_conocimiento";
        ddlOtrosC_nombre.DataValueField = "cv_oc_id";
        ddlOtrosC_nombre.DataBind();
    }
private void BindCursos()
{
    cls_cv_formacion formacion = new cls_cv_formacion();
    ddlCursos_Curso.Items.Clear();
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

//cargar grados academicos
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
        gvFormacione.DataSource =  formacion.ObtenerGrilla_Formacion(Convert.ToInt32(per_id));
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
        catch (Exception ex) { Console.Error.Write(ex.Message); }
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
    //    protected void GvLista_PreRender(object sender, EventArgs e)
    //    {
    //        base.OnPreRender(e);

    //        if (gvFormacion.Rows.Count > 0)
    //        {
    //            if (gvFormacion.HeaderRow != null) gvFormacion.HeaderRow.TableSection = TableRowSection.TableHeader;
    //            if (gvFormacion.FooterRow != null) gvFormacion.FooterRow.TableSection = TableRowSection.TableFooter;
    //        }
    //    }
    //protected void gvCursos_PreRender(object sender, EventArgs e)
    //{
    //    base.OnPreRender(e);

    //    if (gvCursos.Rows.Count > 0)
    //    {
    //        if (gvCursos.HeaderRow != null) gvCursos.HeaderRow.TableSection = TableRowSection.TableHeader;
    //        if (gvCursos.FooterRow != null) gvCursos.FooterRow.TableSection = TableRowSection.TableFooter;
    //    }
    //}
    //    protected void GvTrayectoria_PreRender(object sender, EventArgs e)
    //    {
    //        base.OnPreRender(e);

    //        if (gvTrayectoria.Rows.Count > 0)
    //        {
    //            if (gvTrayectoria.HeaderRow != null) gvTrayectoria.HeaderRow.TableSection = TableRowSection.TableHeader;
    //            if (gvTrayectoria.FooterRow != null) gvTrayectoria.FooterRow.TableSection = TableRowSection.TableFooter;
    //        }
    //    }
    //    protected void GvIdiomas_PreRender(object sender, EventArgs e)
    //    {
    //        base.OnPreRender(e);

    //        if (gvIdiomas.Rows.Count > 0)
    //        {
    //            if (gvIdiomas.HeaderRow != null) gvIdiomas.HeaderRow.TableSection = TableRowSection.TableHeader;
    //            if (gvIdiomas.FooterRow != null) gvIdiomas.FooterRow.TableSection = TableRowSection.TableFooter;
    //        }
    //    }
    //    protected void GvOtrosC_PreRender(object sender, EventArgs e)
    //    {
    //        base.OnPreRender(e);

    //        if (gvOtrosConocimientos.Rows.Count > 0)
    //        {
    //            if (gvOtrosConocimientos.HeaderRow != null) gvOtrosConocimientos.HeaderRow.TableSection = TableRowSection.TableHeader;
    //            if (gvOtrosConocimientos.FooterRow != null) gvOtrosConocimientos.FooterRow.TableSection = TableRowSection.TableFooter;
    //        }
    //    }
    private void BindForm(string id)
    {
        cls_persona _persona = new cls_persona();
        DataSet dsPersona = _persona.ObtenerRegistroX(Convert.ToInt32(id));
        if (dsPersona != null && dsPersona.Tables.Count > 0 && dsPersona.Tables[0].Rows.Count > 0)
        {
            DataRow row = dsPersona.Tables[0].Rows[0];

            // Nombres y apellidos
            ltl_nombre_fun.Text = $"{row["per_nombres"]} {row["per_ap_paterno"]} {row["per_ap_materno"]}".Trim();
            ltl_num_doc.Text = $"{row["per_num_doc"]} - {ObtenerDescripcionCatalogo("departamento", row["per_lugar_exp"])}";
            ltl_estado_civil.Text = ObtenerDescripcionCatalogo("estado_civil", row["per_estado_civil"]);
            ltl_genero.Text = row["per_sexo"].ToString() == "M" ? "Masculino" : "Femenino";
            ltl_fecha_nac.Text = Convert.ToDateTime(row["per_fecha_nac"]).ToString("dd/MM/yyyy");
            ltl_pais.Text = ObtenerDescripcionCatalogo("pais", row["per_procedencia"]);

            // Obtener domicilio
            cls_persona_domicilio domicilio = new cls_persona_domicilio();
            DataSet dsDomicilio = domicilio.ObtenerTablaGrilla("", id, "", "", "", "", "", "", "", "", "");
            if (dsDomicilio != null && dsDomicilio.Tables.Count > 0 && dsDomicilio.Tables[0].Rows.Count > 0)
            {
                DataRow rowDom = dsDomicilio.Tables[0].Rows[0];

                // Construir dirección: tipo de vía + descripción + número
                string tipoVia = ObtenerDescripcionCatalogo("tipo_via", rowDom["perd_tipo_via"]);
                string descripcion = rowDom["perd_descripcion_via"].ToString();
                string numero = rowDom["perd_numero"].ToString();
                ltl_direccion.Text = $"{tipoVia} {descripcion} Nro. {numero}".Trim();

                // Ciudad de residencia
                string ciudad = ObtenerDescripcionCatalogo("ciudad_localidad", rowDom["perd_ciudad_residencia"]);
                ltl_residencia.Text = ciudad;

                // Teléfonos y email
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

    private void informacionFuncionario(int codFun = 0, int as_id = 0)
{
    cls_bs_asignacion_beneficio familiar = new cls_bs_asignacion_beneficio();
    familiar.pf_per_id = codFun;
    familiar.as_id = as_id;
    var detalleFuncionario = familiar.ObtenerDatosDetalleFuncionario();
    if (detalleFuncionario.Tables.Count > 0)
    {
        if (detalleFuncionario.Tables[0].Rows.Count > 0)
        {
            var funcionario = detalleFuncionario.Tables[0].Rows[0];
            ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
            ltl_num_doc.Text = validarCampo(funcionario["ci"]);
            //ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
            ltl_fecha_nac.Text = validarCampo(funcionario["fecha_nac"]);
            ltl_estado_civil.Text = validarCampo(funcionario["per_estado_civil"]);
            ltl_genero.Text = validarCampo(funcionario["per_sexo_desc"]);
            //ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
            ltl_pais.Text = validarCampo(funcionario["per_procedencia"]);
            //ltl_localidad.Text = validarCampo(funcionario["perd_cuidad_residencia"]);
            ltl_direccion.Text = validarCampo(funcionario["DIRECCION"]);
            ltl_residencia.Text = validarCampo(funcionario["CIUDAD_RESIDENCIA"]);
            //ltl_numero.Text = validarCampo(funcionario["perd_numero"]);
            //ltl_cargo.Text = validarCampo(funcionario["cargo"]);
            //ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
            //ltl_item.Text = validarCampo(funcionario["item"]);
            //ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
            //ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
            string haberBasico = validarCampo(funcionario["haber_basico"]);
            decimal haberBasico2 = Convert.ToDecimal(haberBasico);
            haberBasico2 = Math.Round(haberBasico2, 2);
            //ltl_haber_basico.Text = Convert.ToString(haberBasico2);
            //ltl_jornada.Text = validarCampo(funcionario["ca_tipo_jornada_lit"]);
            
                
                
                //if (validarCampo(funcionario["as_estado"]) == "V")
            //{
            //    btn_estado.Text = "Vigente";
            //    btn_estado.CssClass = "btn btn-sm btn-info float-right";
            //}
            //else
            //{
            //    btn_estado.Text = "Pasivo";
            //    btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
            //}

            //if (validarCampo(funcionario["fp_foto"]) != null && validarCampo(funcionario["fp_foto"]) != "")
            //{
            //    imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
            //}
            //else
            //{
            //    if (validarCampo(funcionario["per_sexo"]) == "M")
            //    {
            //        imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
            //    }
            //    else
            //    {
            //        imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
            //    }
            //}

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


private void Bind_Instituciones()
{
    //Formación Instituciones
    cls_grado_academico formacion = new cls_grado_academico();
    ddlFormacion_Institucion.Items.Clear();
        ddlFormacion_Institucion.Items.Add("Seleccione..");
    ddlFormacion_Institucion.DataSource = formacion.ComboFormacion("C2");
    ddlFormacion_Institucion.DataTextField = "it_nombre";
    ddlFormacion_Institucion.DataValueField = "it_id";
    ddlFormacion_Institucion.DataBind();

        ddlCursos_Institucion.Items.Add("Seleccione..");
        ddlCursos_Institucion.DataSource = formacion.ComboFormacion("C7");
    ddlCursos_Institucion.DataTextField = "it_nombre";
    ddlCursos_Institucion.DataValueField = "it_id";
    ddlCursos_Institucion.DataBind();

        ddlTrayectoria_NuevaInstitucion.Items.Add("Seleccione..");
        ddlTrayectoria_NuevaInstitucion.DataSource = formacion.ComboFormacion("C7");
    ddlTrayectoria_NuevaInstitucion.DataTextField = "it_nombre";
    ddlTrayectoria_NuevaInstitucion.DataValueField = "it_id";
    ddlTrayectoria_NuevaInstitucion.DataBind();


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
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se eliminó correctamente la Formación Académica' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");

            break;

        default:
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
            if (string.IsNullOrEmpty(txtFormacionAñoFin.Text))
            {

            }
            else
            {
                fechaFin = Convert.ToInt32(txtFormacionAñoFin.Text);
            }
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
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente la Formación Académica' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
            BindGridViewFormacion(per_id.ToString());
            ddlFormacionNivel.SelectedIndex = 0;
            ddlFormacion_Institucion.SelectedIndex = 0;
            ddlFormacionCarrera.SelectedIndex = 0;
            txtFormacionAñoInicio.Text = "";
            txtFormacionAñoFin.Text = "";
        }
}


protected void btnFormacion_NuevaInst_Click(object sender, EventArgs e)
{
        limpiarModales();
        sc = "$('#ModalFormacion_InstitucionNueva').modal('show');";
    SetScript(sc, "");
}

protected void BotonCerrarCatalogo_Click(object sender, EventArgs e)
{
    sc = "$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    SetScript(sc, "");
}

protected void btnFormacion_NuevaCarrera_Click(object sender, EventArgs e)
{
        limpiarModales();
        sc = "$('#ModalFormacion_CarreraNueva').modal('show');";
    SetScript(sc, "");
}

protected void btnFormacion_Cerrar_AdicionarCarrera_Click(object sender, EventArgs e)
{
    sc = "$('#ModalFormacion_CarreraNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
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

protected void btnAdicionarTrayectoria_Click(object sender, EventArgs e)
{
        if (ddlTrayectoria_NuevaInstitucion.SelectedItem.Text != "Seleccione..")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.Adicionar_CurriculumTrayectoria(Convert.ToInt32(ddlTrayectoria_NuevaInstitucion.SelectedValue), txtTrayectoriaEspecialidad.Text, txtTrayectoriaUltimoCargo.Text, Convert.ToInt32(txtTrayectoriaMesInicio.Text), Convert.ToInt32(txtTrayectoriaAñoInicio.Text), Convert.ToInt32(txtTrayectoriaMesFin.Text), Convert.ToInt32(txtTrayectoriaAñoFin.Text), "V", Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString())))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente la Trayectoria Laboral' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

            SetScript(sc, "");
            BindGridViewTrayectoria(HttpContext.Current.Session["per_id"].ToString());
            txtTrayectoriaMesInicio.Text = "";
            txtTrayectoriaAñoInicio.Text = "";
            txtTrayectoriaMesFin.Text = "";
            txtTrayectoriaAñoFin.Text = "";ddlTrayectoria_NuevaInstitucion.SelectedIndex = 0;
            txtTrayectoriaEspecialidad.Text = "";
            txtTrayectoriaUltimoCargo.Text = "";
        }
    }

    protected void btnTrayectoria_NuevaInstitucion_Click(object sender, EventArgs e)
{
        limpiarModales();
        sc = "$('#ModalTrayectoria_NuevaInstitucion').modal('show');";
    SetScript(sc, "");
}

protected void btnAdicionarIdiomas_Click(object sender, EventArgs e)
{
        if (ddlIdiomas_Idioma.SelectedItem.Text != "Seleccione..")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.Adicionar_CurriculumIdioma(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString()), Convert.ToInt32(ddlIdiomas_Idioma.SelectedValue), "V", ddlIdiomasNivel.SelectedItem.Text))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente el Idioma' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

            SetScript(sc, "");
            BindGridViewIdiomas(HttpContext.Current.Session["per_id"].ToString());
            ddlIdiomas_Idioma.SelectedIndex = 0;
        }
    }

    protected void btnIdiomas_NuevoIdioma_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#ModalIdioma_NuevoIdioma').modal('show');";
        SetScript(sc, "");
    }

    protected void btnAdicionarOtroConocimiento_Click(object sender, EventArgs e)
{
        if (ddlOtrosC_nombre.SelectedItem.Text != "Seleccione..")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.Adicionar_CurriculumOtrosC(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString()), Convert.ToInt32(ddlOtrosC_nombre.SelectedValue), "V"))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente el Conocimiento Adicional' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

            SetScript(sc, "");
            BindGridViewOtrosConocimientos(HttpContext.Current.Session["per_id"].ToString());
            ddlOtrosC_nombre.SelectedIndex = 0;
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
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se eliminó correctamente la Formación Académica' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");

                break;

            default:
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
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se eliminó correctamente la Trayectoria Laboral' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");

                break;

            default:
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
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se eliminó correctamente el Idioma Seleccionado' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");

                break;

            default:
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
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se eliminó correctamente el Conocimiento Adicional seleccionado' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo eliminar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc, "");

                break;

            default:
                break;
        }
        BindGridViewOtrosConocimientos(HttpContext.Current.Session["per_id"].ToString());
    }


    protected void btnCursos_AdicionarInstitucionCerrar_Click(object sender, EventArgs e)
{
    sc = "$('#ModalCursos_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    SetScript(sc, "");
}

protected void btnCursos_AdicionarCursoCerrar_Click(object sender, EventArgs e)
{
    sc = "$('#ModalCursos_CursoNuevo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    SetScript(sc, "");
}


    protected void btnAdicionarCursos_Click(object sender, EventArgs e)
    {
        if (ddlCursos_Institucion.SelectedItem.Text != "Seleccione.." && ddlCursos_Curso.SelectedItem.Text != "Seleccione..")
        {
            int per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString());

            cls_cv_formacion formacion = new cls_cv_formacion();

            if (formacion.Adicionar_CurriculumCurso(per_id, Convert.ToInt32(ddlCursos_Curso.SelectedValue), Convert.ToInt32(ddlCursos_Institucion.SelectedValue), Convert.ToInt32(txtCursosDias.Text), "V"))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente la Formación Académica' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
            BindGridViewCursos(per_id.ToString());
            ddlCursos_Institucion.SelectedIndex = 0;
            ddlCursos_Curso.SelectedIndex = 0;
            txtCursosDias.Text = "";
        }
    }

    protected void btnTrayectoria_AdicionarCerrar_Click(object sender, EventArgs e)
    {
        sc = "$('#ModalTrayectoria_NuevaInstitucion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }


    protected void btnIdioma_NuevoCerrar_Click(object sender, EventArgs e)
    {
        sc = "$('#ModalIdioma_NuevoIdioma').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }

    protected void btnOtrosC_NuevoConocimiento_Click(object sender, EventArgs e)
    {
        limpiarModales();
        sc = "$('#ModalOtrosC_NuevoC').modal('show');";
        SetScript(sc, "");
    }

    protected void btnNuevoC_Cerrar_Click(object sender, EventArgs e)
    {
        sc = "$('#ModalOtrosC_NuevoC').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }


    protected void btnImprimirCv_Click(object sender, EventArgs e)
    {
        sc = "window.open('ImprimirCV.aspx', 'width=300,height=300', '_blank');";
        SetScript(sc, ", dropdownParent: $('#addModal')");
    }


    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        sc = "";
        SetScript(sc, "");

        divCV.Visible = true;
        DivImprimir.Visible = true;
        LinkButton1.Visible = false;
        leyenda.Visible = false;
    }
    protected void btnCursos_AdicionarCurso_Click(object sender, EventArgs e)
    {
        if (txtCursos_NuevoCurso.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarCursos_Curso(txtCursos_NuevoCurso.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente el Curso' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

            SetScript(sc, "");
            BindCursos();
            int index = 0;
            foreach (ListItem item in ddlCursos_Curso.Items)
            {
                if (item.Text == txtCursos_NuevoCurso.Text.Substring(0, txtCursos_NuevoCurso.Text.Length - 1).ToLower() || item.Text == txtCursos_NuevoCurso.Text.Substring(0, txtCursos_NuevoCurso.Text.Length - 1).ToUpper())
                    index = Convert.ToInt32(item.Value);
            }
            ddlCursos_Curso.SelectedValue = index.ToString();
        }
    }

    protected void btnFormacion_AdicionarInstitucion_Click(object sender, EventArgs e)
    {
        if (txtFormacion_NuevaInstitucion.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarFormacion_Insitucion(txtFormacion_NuevaInstitucion.Text, 0, "V", 0, 0, "formación"))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente la Formación Académica' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

            SetScript(sc, "");
            Bind_Instituciones();
            int index = 0;
            foreach (ListItem item in ddlFormacion_Institucion.Items)
            {
                if (item.Text == txtFormacion_NuevaInstitucion.Text.Substring(0, txtFormacion_NuevaInstitucion.Text.Length - 1).ToLower() || item.Text == txtFormacion_NuevaInstitucion.Text.Substring(0, txtFormacion_NuevaInstitucion.Text.Length - 1).ToUpper())
                    index = Convert.ToInt32(item.Value);
            }
            ddlFormacion_Institucion.SelectedValue = index.ToString();
        }
    }
    protected void btnTrayectoria_AdicionarNuevaInstitucion_Click(object sender, EventArgs e)
    {
            if (txtTrayectoria_NuevaInstitucion.Text != "")
            {
                cls_cv_formacion formacion = new cls_cv_formacion();
                if (formacion.InsertarTrayectoria_Insitucion(txtTrayectoria_NuevaInstitucion.Text, 0, "V", 0, 0, "trayectoria"))
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente la Institución para Trayectoria Laboral' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
                else
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

                SetScript(sc, "");
                Bind_Instituciones();
                int index = 0;
                foreach (ListItem item in ddlTrayectoria_NuevaInstitucion.Items)
                {
                    if (item.Text == txtTrayectoria_NuevaInstitucion.Text.Substring(0, txtTrayectoria_NuevaInstitucion.Text.Length - 1).ToLower() || item.Text == txtTrayectoria_NuevaInstitucion.Text.Substring(0, txtTrayectoria_NuevaInstitucion.Text.Length - 1).ToUpper())
                        index = Convert.ToInt32(item.Value);
                }
                ddlTrayectoria_NuevaInstitucion.SelectedValue = index.ToString();
            }
        
    }
    protected void btnFormacion_AdicionarCarrera_Click(object sender, EventArgs e)
    {
        if (txtFormacion_NuevaCarrera.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarFormacion_Carrera(txtFormacion_NuevaCarrera.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente la Formación Académica' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

            SetScript(sc, "");
            BindCarreras();
            int index = 0;
            foreach (ListItem item in ddlFormacionCarrera.Items)
            {
                if (item.Text == txtFormacion_NuevaCarrera.Text.Substring(0, txtFormacion_NuevaCarrera.Text.Length - 1).ToLower() || item.Text == txtFormacion_NuevaCarrera.Text.Substring(0, txtFormacion_NuevaCarrera.Text.Length - 1).ToUpper())
                    index = Convert.ToInt32(item.Value);
            }
            ddlFormacionCarrera.SelectedValue = index.ToString();
        }
    }
    protected void btnIdioma_NuevoIdioma_Click(object sender, EventArgs e)
    {
        if (txtIdioma_NuevoIdioma.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarNuevoIdioma(txtIdioma_NuevoIdioma.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente el nuevo Idioma' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

            SetScript(sc, "");
            BindIdiomas();
            int index = 0;
            foreach (ListItem item in ddlIdiomas_Idioma.Items)
            {
                if (item.Text == txtIdioma_NuevoIdioma.Text.Substring(0, txtIdioma_NuevoIdioma.Text.Length - 1).ToLower() || item.Text == txtIdioma_NuevoIdioma.Text.Substring(0, txtIdioma_NuevoIdioma.Text.Length - 1).ToUpper())
                    index = Convert.ToInt32(item.Value);
            }
            ddlIdiomas_Idioma.SelectedValue = index.ToString();
        }
    }
    protected void btnNuevoC_NuevoC_Click(object sender, EventArgs e)
    {
        if (txtNuevoC_NuevoC.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarNuevoConocimiento(txtNuevoC_NuevoC.Text, "V"))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente el nuevo Conocimiento' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

            SetScript(sc, "");
            BindOtrosConocimientos();
            int index = 0;
            foreach (ListItem item in ddlOtrosC_nombre.Items)
            {
                if (item.Text == txtNuevoC_NuevoC.Text.Substring(0, txtNuevoC_NuevoC.Text.Length-1).ToLower() || item.Text == txtNuevoC_NuevoC.Text.Substring(0, txtNuevoC_NuevoC.Text.Length - 1).ToUpper())
                    index = Convert.ToInt32(item.Value);
            }
            ddlOtrosC_nombre.SelectedValue = index.ToString();
        }
    }
    protected void btnCursos_AdicionarInstitucion_Click(object sender, EventArgs e)
    {
        if (txtCursos_NuevaInstitucion.Text != "")
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            if (formacion.InsertarCursos_Insitucion(txtCursos_NuevaInstitucion.Text, 0, "V", 0, 0, "cursos"))
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente el Curso' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            else
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo registrar la información' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#ModalFormacion_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

            SetScript(sc, "");
            Bind_Instituciones();
            int index = 0;
            foreach (ListItem item in ddlCursos_Institucion.Items)
            {
                if (item.Text == txtCursos_NuevaInstitucion.Text.Substring(0, txtCursos_NuevaInstitucion.Text.Length - 1).ToLower() || item.Text == txtCursos_NuevaInstitucion.Text.Substring(0, txtCursos_NuevaInstitucion.Text.Length - 1).ToUpper())
                    index = Convert.ToInt32(item.Value);
            }
            ddlCursos_Institucion.SelectedValue = index.ToString();
        }
    }
    private void limpiarModales() {
        txtFormacion_NuevaInstitucion.Text = "";
        txtFormacion_NuevaCarrera.Text = "";
        txtCursos_NuevaInstitucion.Text = "";
        txtCursos_NuevoCurso.Text = "";txtTrayectoria_NuevaInstitucion.Text = "";
        txtIdioma_NuevoIdioma.Text = "";
        txtNuevoC_NuevoC.Text = "";
    }
}