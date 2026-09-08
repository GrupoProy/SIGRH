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

public partial class Kardex_Curriculum : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                string per_id = HttpContext.Current.Session["per_id"].ToString();
                BindForm(per_id);
                BindGradoAcademico();
                Bind_Instituciones();
                BindCarreras();
                BindGridViewFormacion(per_id);

                BindCursos();
                BindGridViewCursos(per_id);

            }
        }
        else Response.Redirect("../Index");
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
            gvFormacion.DataSource = formacion.ObtenerGrilla_Formacion(Convert.ToInt32(per_id));
            gvFormacion.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (gvFormacion.Rows.Count > 0)
        {
            if (gvFormacion.HeaderRow != null) gvFormacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (gvFormacion.FooterRow != null) gvFormacion.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    private void BindForm(string id)
    {
        cls_persona _persona = new cls_persona();

        var data = _persona.ObtenerRegistroX(Convert.ToInt32(id)).Tables[0];
        if (data.Rows.Count > 0)
        {
            ltl_nombre_fun.Text = data.Rows[0]["per_nombres"].ToString().Trim() + " " + data.Rows[0]["per_ap_paterno"].ToString().Trim() + " " + data.Rows[0]["per_ap_materno"].ToString().Trim();
            ltl_num_doc.Text = data.Rows[0]["per_num_doc"].ToString().Trim() + " " + data.Rows[0]["per_lugar_exp"].ToString().Trim();
            ltl_estado_civil.Text = data.Rows[0]["per_estado_civil"].ToString().Trim();
            ltl_genero.Text = data.Rows[0]["per_sexo"].ToString().Trim();
            ltl_fecha_nac.Text = Convert.ToDateTime(data.Rows[0]["per_fecha_nac"]).ToString("dd/MM/yyyy").Trim();
            cls_persona_domicilio domicilio = new cls_persona_domicilio();
            DataSet ds = domicilio.ObtenerTablaGrilla("", id, "", "", "", "", "", "", "", "", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                ltl_zona.Text = ds.Tables[0].Rows[0]["perd_zona"].ToString();
                ltl_pais.Text = data.Rows[0]["per_procedencia"].ToString().Trim();
                ltl_localidad.Text = data.Rows[0]["per_lugar_nac"].ToString().Trim();
                ltl_zona.Text = ds.Tables[0].Rows[0]["perd_zona"].ToString();
                ltl_nombre_via.Text = ds.Tables[0].Rows[0]["perd_tipo_via"].ToString();
                ltl_numero.Text = ds.Tables[0].Rows[0]["perd_descripcion_via"].ToString();
                ltl_telef_domicilio.Text = ds.Tables[0].Rows[0]["perd_telefono"].ToString().Trim();
                ltl_telef_movil.Text = ds.Tables[0].Rows[0]["perd_celular"].ToString().Trim();
                ltl_email.Text = ds.Tables[0].Rows[0]["perd_email_personal"].ToString().Trim();
            }
        }
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
                ltl_localidad.Text = validarCampo(funcionario["perd_cuidad_residencia"]);
                ltl_zona.Text = validarCampo(funcionario["perd_zona"]);
                ltl_nombre_via.Text = validarCampo(funcionario["perd_descripcion_via"]);
                ltl_numero.Text = validarCampo(funcionario["perd_numero"]);
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

        //ddlTrayectoria_NuevaInstitucion.Items.Add("Seleccione..");
        //ddlTrayectoria_NuevaInstitucion.DataSource = formacion.ComboFormacion("C7");
        //ddlTrayectoria_NuevaInstitucion.DataTextField = "it_nombre";
        //ddlTrayectoria_NuevaInstitucion.DataValueField = "it_id";
        //ddlTrayectoria_NuevaInstitucion.DataBind();

    }
    protected void gvFormacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetDelete":
                string form_id = gvFormacion.DataKeys[index].Values[0].ToString();
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
            formacion = new cls_cv_formacion
            {
                cv_ga_id = Convert.ToInt32(ddlFormacionNivel.SelectedValue),
                cv_inst_id = Convert.ToInt32(ddlFormacion_Institucion.SelectedValue),
                cv_carr_id = Convert.ToInt32(ddlFormacionCarrera.SelectedValue),
                cv_form_año_inicio = Convert.ToInt32(txtFormacionAñoInicio.Text),
                cv_form_año_fin = Convert.ToInt32(txtFormacionAñoFin.Text),
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
        sc = "$('#ModalFormacion_CarreraNueva').modal('show');";
        SetScript(sc, "");
    }

    protected void btnFormacion_Cerrar_AdicionarCarrera_Click(object sender, EventArgs e)
    {
        sc = "$('#ModalFormacion_CarreraNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }

    protected void btnFormacion_AdicionarInstitucion_Click(object sender, EventArgs e)
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
            if (item.Text == txtFormacion_NuevaInstitucion.Text)
                index = Convert.ToInt32(item.Value);
        }
        ddlFormacion_Institucion.SelectedValue = index.ToString();
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

    protected void btnCursos_NuevaInstitucion_Click(object sender, EventArgs e)
    {
        sc = "$('#ModalCursos_InstitucionNueva').modal('show');";
        SetScript(sc, "");
    }

    protected void btnCursos_NuevoCurso_Click(object sender, EventArgs e)
    {
        sc = "$('#ModalCursos_CursoNuevo').modal('show');";
        SetScript(sc, "");
    }

    protected void btnAdicionarTrayectoria_Click(object sender, EventArgs e)
    {

    }

    protected void btnTrayectoria_NuevaInstitucion_Click(object sender, EventArgs e)
    {
        sc = "$('#ModalTrayectoria_InstitucionNueva').modal('show');";
        SetScript(sc, "");
    }

    protected void btnTrayectoria_NuevaEspecialidad_Click(object sender, EventArgs e)
    {
        sc = "$('#ModalTrayectoria_InstitucionNueva').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }

    protected void btnAdicionarIdiomas_Click(object sender, EventArgs e)
    {

    }

    protected void btnIdiomas_NuevoIdioma_Click(object sender, EventArgs e)
    {

    }

    protected void btnAdicionarOtroConocimiento_Click(object sender, EventArgs e)
    {

    }

    protected void gvCursos_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gvTrayectoria_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gvIdiomas_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void gvOtrosConocimientos_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnCursos_AdicionarInstitucion_Click(object sender, EventArgs e)
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
            if (item.Text == txtCursos_NuevaInstitucion.Text)
                index = Convert.ToInt32(item.Value);
        }
        ddlCursos_Institucion.SelectedValue = index.ToString();
    }



    protected void btnCursos_AdicionarCurso_Click(object sender, EventArgs e)
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
            if (item.Text == txtCursos_NuevoCurso.Text)
                index = Convert.ToInt32(item.Value);
        }
        ddlCursos_Curso.SelectedValue = index.ToString();
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

    protected void btnFormacion_AdicionarCarrera_Click(object sender, EventArgs e)
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
            if (item.Text == txtFormacion_NuevaCarrera.Text)
                index = Convert.ToInt32(item.Value);
        }
        ddlFormacionCarrera.SelectedValue = index.ToString();

    }
}