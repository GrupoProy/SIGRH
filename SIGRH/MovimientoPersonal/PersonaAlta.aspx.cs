using Newtonsoft.Json;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_BolsaTrabajo.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Kardex.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovimientoPersonal_PersonaAlta : System.Web.UI.Page
{
    private cls_historico _historico = null;
    private cls_catalogo _catalogo = null;
    private cls_bt_postulante _postulante = null;
    private cls_persona _persona = null;
    private cls_persona_domicilio _domicilio = null;
    private cls_persona_familiares _familiar = null;
    private cls_bs_afp _afp = null;
    private string sc = "";
    private string connectionString = ConfigurationManager.ConnectionStrings["CnxSigrh3"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                sc = "CopiarCortarPegar(true);";
                SetScript(sc, "");
                BindForm();
            }
        }
        else Response.Redirect("../Index");
    }

    // ============================================================
    // BIND FORM - CARGAR TODOS LOS COMBOS
    // ============================================================
    private void BindForm()
    {
        _persona = new cls_persona();
        _persona.ObtenerId();
        Lt_per_id.Text = _persona.per_id.ToString();
        BindDDLTipoDocumentoPersonal();
        BindDDLLugarExpedido();
        BindDDLProcedencia();
        BindDDLLugarNacimiento();
        BindDDLEstadoCivil();
        BindDDLDepartamento();
        BindDDLZona();
        BindDDLTipoVia();
        BindDDLCiudadResidencia();
        BindGradoAcademico();
    }

    // ============================================================
    // CARGAR COMBOS
    // ============================================================

    private void BindDDLTipoDocumentoPersonal()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_personal" };
        Ddl_per_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_tipo_doc.DataValueField = "cat_id";
        Ddl_per_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_per_tipo_doc.DataBind();
    }

    private void BindDDLLugarExpedido()
    {
        _catalogo = new cls_catalogo { cat_tabla = "departamento" };
        Ddl_per_lugar_exp.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_lugar_exp.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_lugar_exp.DataValueField = "cat_id";
        Ddl_per_lugar_exp.DataTextField = "cat_descripcion";
        Ddl_per_lugar_exp.DataBind();
    }

    private void BindDDLProcedencia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "pais" };
        Ddl_per_procedencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_procedencia.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_procedencia.DataValueField = "cat_id";
        Ddl_per_procedencia.DataTextField = "cat_descripcion";
        Ddl_per_procedencia.DataBind();
    }

    private void BindDDLLugarNacimiento()
    {
        _catalogo = new cls_catalogo();
        Ddl_per_lugar_nac.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_lugar_nac.DataSource = _catalogo.ObtenerLugarNacimiento();
        Ddl_per_lugar_nac.DataValueField = "id_ciudad";
        Ddl_per_lugar_nac.DataTextField = "lugar_nac";
        Ddl_per_lugar_nac.DataBind();
    }

    private void BindDDLEstadoCivil()
    {
        _catalogo = new cls_catalogo { cat_tabla = "estado_civil" };
        Ddl_per_estado_civil.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_estado_civil.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_estado_civil.DataValueField = "cat_id";
        Ddl_per_estado_civil.DataTextField = "cat_descripcion";
        Ddl_per_estado_civil.DataBind();
    }

    // ============================================================
    // CARGAR COMBOS DE DOMICILIO (DESDE SolicitudContratacion)
    // ============================================================

    private void BindDDLDepartamento()
    {
        _catalogo = new cls_catalogo { cat_tabla = "departamento" };
        ddlDepartamento.DataSource = _catalogo.ObtenerTablaCombo();
        ddlDepartamento.DataValueField = "cat_id";
        ddlDepartamento.DataTextField = "cat_descripcion";
        ddlDepartamento.DataBind();
        ddlDepartamento.Items.Insert(0, new ListItem("Seleccione...", "0"));
    }

    private void BindDDLZona()
    {
        _catalogo = new cls_catalogo { cat_tabla = "zona", cat_id_superior = 0 };
        ddlZona.Items.Clear();
        ddlZona.DataSource = _catalogo.ObtenerTablaCombo();
        ddlZona.DataValueField = "cat_secuencial";
        ddlZona.DataTextField = "cat_descripcion";
        ddlZona.DataBind();
        ddlZona.Items.Insert(0, new ListItem("Seleccione...", "0"));
    }

    private void BindDDLTipoVia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_via" };
        ddlTipoVia.DataSource = _catalogo.ObtenerTablaCombo();
        ddlTipoVia.DataValueField = "cat_id";
        ddlTipoVia.DataTextField = "cat_descripcion";
        ddlTipoVia.DataBind();
        ddlTipoVia.Items.Insert(0, new ListItem("Seleccione...", "0"));
    }

    private void BindDDLCiudadResidencia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "ciudad_localidad", cat_id_superior = 0 };
        ddlCiudad.Items.Clear();
        ddlCiudad.DataSource = _catalogo.ObtenerTablaCombo();
        ddlCiudad.DataValueField = "cat_id";
        ddlCiudad.DataTextField = "cat_descripcion";
        ddlCiudad.DataBind();
        ddlCiudad.Items.Insert(0, new ListItem("Seleccione...", "0"));
    }

    private void CargarProvincias(int idDepartamento)
    {
        try
        {
            _catalogo = new cls_catalogo { cat_tabla = "provincia", cat_id_superior = idDepartamento };
            DataSet ds = _catalogo.ObtenerTablaCombo();

            ddlProvincia.DataSource = ds;
            ddlProvincia.DataValueField = "cat_id";
            ddlProvincia.DataTextField = "cat_descripcion";
            ddlProvincia.DataBind();
            ddlProvincia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar provincias: " + ex.Message);
        }
    }

    private void CargarCiudades(int idProvincia)
    {
        try
        {
            _catalogo = new cls_catalogo { cat_tabla = "ciudad_localidad", cat_id_superior = idProvincia };
            DataSet ds = _catalogo.ObtenerTablaCombo();

            ddlCiudad.DataSource = ds;
            ddlCiudad.DataValueField = "cat_id";
            ddlCiudad.DataTextField = "cat_descripcion";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar ciudades: " + ex.Message);
        }
    }

    // ============================================================
    // GRADO ACADÉMICO
    // ============================================================

    private void BindGradoAcademico()
    {
        cls_grado_academico grado_academico = new cls_grado_academico();
        DdlFormacion.Items.Insert(0, new ListItem("Seleccione...", "0"));
        DdlFormacion.DataSource = grado_academico.ObtenerGradoAcademico();
        DdlFormacion.DataValueField = "ga_id";
        DdlFormacion.DataTextField = "ga_nombre";
        DdlFormacion.DataBind();
    }

    // ============================================================
    // GRIDVIEW FAMILIAR
    // ============================================================

    private void BindGridViewFamily(string varId)
    {
        try
        {
            _familiar = new cls_persona_familiares();
            GvListaFamily.DataSource = _familiar.ObtenerTablaGrilla("", varId, "", "", "", "", "", "", "V", "", "");
            GvListaFamily.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // ============================================================
    // EVENTOS
    // ============================================================

    protected void Rbl_per_sexo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rbl_per_sexo.SelectedValue.Equals("F"))
            sc = "$('#d_slm').css('display', 'block'); $('#lbl_txt_slm').css('display', 'none'); $('#d_txt_slm').css('display', 'none');";
        else
            sc = "$('#d_slm').css('display', 'none'); $('#lbl_txt_slm').css('display', 'block'); $('#d_txt_slm').css('display', 'block');";
        SetScript(sc, "");
    }

    protected void Ddl_per_procedencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_per_procedencia.SelectedValue.Equals("1"))
        {
            Ddl_per_lugar_nac.SelectedValue = "0";
            Ddl_per_lugar_nac.Enabled = true;
        }
        else
        {
            Ddl_per_lugar_nac.SelectedValue = "1822";
            Ddl_per_lugar_nac.Enabled = false;
        }

        if (Rbl_per_sexo.SelectedValue.Equals("F"))
            sc = "$('#d_slm').css('display', 'block'); $('#lbl_txt_slm').css('display', 'none'); $('#d_txt_slm').css('display', 'none');";
        SetScript(sc, "");
    }

    protected void Ddl_per_has_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_per_has.SelectedValue.Equals("1"))
            sc = "$('#d_slm').css('display', 'block'); $('#lbl_txt_slm').css('display', 'none'); $('#d_txt_slm').css('display', 'block');";
        else
            sc = "$('#d_slm').css('display', 'block'); $('#lbl_txt_slm').css('display', 'none'); $('#d_txt_slm').css('display', 'none');";
        SetScript(sc, "");
    }

    // ============================================================
    // EVENTOS: DEPARTAMENTO Y PROVINCIA CAMBIAN
    // ============================================================

    protected void ddlDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlProvincia.Items.Clear();
        ddlProvincia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddlCiudad.Items.Clear();
        ddlCiudad.Items.Insert(0, new ListItem("Seleccione...", "0"));

        if (ddlDepartamento.SelectedValue != "0")
        {
            int idDepartamento = Convert.ToInt32(ddlDepartamento.SelectedValue);
            CargarProvincias(idDepartamento);
        }

        UpdatePanelUbicacion.Update();
    }

    protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        ddlCiudad.Items.Clear();
        ddlCiudad.Items.Insert(0, new ListItem("Seleccione...", "0"));

        if (ddlProvincia.SelectedValue != "0")
        {
            int idProvincia = Convert.ToInt32(ddlProvincia.SelectedValue);
            CargarCiudades(idProvincia);
        }

        UpdatePanelUbicacion.Update();
    }

    // ============================================================
    // NUEVA ZONA - ABRE MODAL
    // ============================================================

    protected void btnNuevaZona_Click(object sender, EventArgs e)
    {
        txtNuevaZona.Text = "";
        sc = "$('#modalNuevaZona').modal('show');";
        SetScript(sc, "");
    }

    // ============================================================
    // REGISTRAR NUEVA ZONA
    // ============================================================

    protected void btnRegistrarZona_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtNuevaZona.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar el nombre de la zona' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            cls_catalogo catalogo = new cls_catalogo();
            catalogo.Adicionar("zona", txtNuevaZona.Text.ToUpper().Trim(), "", "0");

            _catalogo = new cls_catalogo { cat_tabla = "zona", cat_id_superior = 0 };
            ddlZona.DataSource = _catalogo.ObtenerTablaCombo();
            ddlZona.DataValueField = "cat_secuencial";
            ddlZona.DataTextField = "cat_descripcion";
            ddlZona.DataBind();
            ddlZona.Items.Insert(0, new ListItem("Seleccione...", "0"));

            if (ddlZona.Items.Count > 1)
            {
                ddlZona.SelectedIndex = ddlZona.Items.Count - 1;
            }

            sc = "$.notify({ icon: 'fas fa-check', message: 'Zona registrada correctamente' }, { type: 'success' }); $('#modalNuevaZona').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");

            txtNuevaZona.Text = "";
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al registrar zona: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    // ============================================================
    // NUEVA CIUDAD - ABRE MODAL
    // ============================================================

    protected void btnNuevaCiudad_Click(object sender, EventArgs e)
    {
        txtNuevaCiudad.Text = "";
        _catalogo = new cls_catalogo { cat_tabla = "departamento" };
        ddlCiudadDepartamento.DataSource = _catalogo.ObtenerTablaCombo();
        ddlCiudadDepartamento.DataValueField = "cat_id";
        ddlCiudadDepartamento.DataTextField = "cat_descripcion";
        ddlCiudadDepartamento.DataBind();
        ddlCiudadDepartamento.Items.Insert(0, new ListItem("Seleccione...", "0"));

        ddlCiudadProvincia.Items.Clear();
        ddlCiudadProvincia.Items.Insert(0, new ListItem("Seleccione...", "0"));

        sc = "$('#modalNuevaCiudad').modal('show');";
        SetScript(sc, "");
    }

    // ============================================================
    // DEPARTAMENTO DEL MODAL CAMBIA
    // ============================================================

    protected void ddlCiudadDepartamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlCiudadDepartamento.SelectedValue != "0")
        {
            int idDepartamento = Convert.ToInt32(ddlCiudadDepartamento.SelectedValue);
            try
            {
                _catalogo = new cls_catalogo { cat_tabla = "provincia", cat_id_superior = idDepartamento };
                ddlCiudadProvincia.DataSource = _catalogo.ObtenerTablaCombo();
                ddlCiudadProvincia.DataValueField = "cat_id";
                ddlCiudadProvincia.DataTextField = "cat_descripcion";
                ddlCiudadProvincia.DataBind();
                ddlCiudadProvincia.Items.Insert(0, new ListItem("Seleccione...", "0"));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar provincias: " + ex.Message);
            }
        }
        else
        {
            ddlCiudadProvincia.Items.Clear();
            ddlCiudadProvincia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }
    }

    // ============================================================
    // REGISTRAR NUEVA CIUDAD
    // ============================================================

    protected void btnRegistrarCiudad_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(txtNuevaCiudad.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar el nombre de la ciudad' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            if (ddlCiudadDepartamento.SelectedValue == "0")
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar un departamento' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            if (ddlCiudadProvincia.SelectedValue == "0")
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar una provincia' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            cls_catalogo catalogo = new cls_catalogo();
            catalogo.Adicionar("ciudad_localidad", txtNuevaCiudad.Text.ToUpper().Trim(), "", Convert.ToInt32(ddlCiudadProvincia.SelectedValue).ToString());

            int idProvincia = Convert.ToInt32(ddlCiudadProvincia.SelectedValue);
            CargarCiudades(idProvincia);

            UpdatePanelUbicacion.Update();

            if (ddlCiudad.Items.Count > 1)
            {
                ddlCiudad.SelectedIndex = ddlCiudad.Items.Count - 1;
            }

            sc = "$.notify({ icon: 'fas fa-check', message: 'Ciudad registrada correctamente' }, { type: 'success' }); $('#modalNuevaCiudad').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");

            txtNuevaCiudad.Text = "";
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al registrar ciudad: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    // ============================================================
    // GRIDVIEW FAMILIAR PRE RENDER
    // ============================================================

    protected void GvListaFamily_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvListaFamily.Rows.Count > 0)
        {
            if (GvListaFamily.HeaderRow != null) GvListaFamily.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvListaFamily.FooterRow != null) GvListaFamily.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    // ============================================================
    // GUARDAR PERSONA
    // ============================================================

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (Ddl_per_procedencia.SelectedValue.Equals("1"))
        {
            if (Ddl_per_lugar_nac.SelectedValue.Equals("0"))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Lugar de Nacimiento) es obligatorio...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }

        if (Rbl_per_sexo.SelectedValue.Equals("F"))
        {
            if (!Ddl_per_has.SelectedValue.Equals("0"))
            {
                if (Ddl_per_has.SelectedValue.Equals("1"))
                {
                    if (string.IsNullOrEmpty(Txt_per_serie_libreta_militar.Text))
                    {
                        Txt_per_serie_libreta_militar.Text = "PENDIENTE";
                        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Nº Libreta de Serv. Militar) está vacío, se registrará un valor por defecto...!!' }, { type: 'warning' }); $('#d_slm').css('display', 'block'); $('#lbl_txt_slm').css('display', 'none'); $('#d_txt_slm').css('display', 'block');";
                        SetScript(sc, "");
                        return;
                    }
                }
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar una opción (Nº Libreta de Serv. Militar)...!!' }, { type: 'warning' }); $('#d_slm').css('display', 'block'); $('#lbl_txt_slm').css('display', 'none'); $('#d_txt_slm').css('display', 'none');";
                SetScript(sc, "");
                return;
            }
        }
        else
        {
            if (string.IsNullOrEmpty(Txt_per_serie_libreta_militar.Text))
            {
                Txt_per_serie_libreta_militar.Text = "PENDIENTE";
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Nº Libreta de Serv. Militar) está vacío, se registrará un valor por defecto...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }

        var edad = DateTime.Now.Year - Convert.ToDateTime(Txt_per_fecha_nac.Text.Trim()).Year;

        if (edad > 0)
        {
            // Validaciones de edad comentadas
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha de Nacimiento), no tiene una fecha de nacimiento válida...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        // Validación de domicilio
        if (ddlDepartamento.SelectedValue == "0")
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar un Departamento' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (ddlProvincia.SelectedValue == "0")
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar una Provincia' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (ddlCiudad.SelectedValue == "0")
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar una Ciudad' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (ddlZona.SelectedValue == "0")
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar una Zona' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (string.IsNullOrEmpty(txtDescDomicilio.Text))
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar la Descripción del Domicilio' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (string.IsNullOrEmpty(txtNumDomicilio.Text))
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar el Número de Domicilio' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        // Verificar si ya existe el CI
        _persona = new cls_persona();
        var data = _persona.ObtenerTablaGrilla("", "", Txt_per_num_doc.Text.Trim(), "", Txt_per_ap_paterno.Text.ToUpper().Trim(), Txt_per_ap_materno.Text.ToUpper().Trim(), "", "", "", "", "", "", "", "").Tables[0];

        if (data.Rows.Count > 0)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los datos no se pueden guardar, ya existe un registro con los mismos parámetros...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        _postulante = new cls_bt_postulante();
        _catalogo = new cls_catalogo();
        string primer_nombre = "", segundo_nombre = "";
        var haveBT = true;
        var dataC = _catalogo.ObtenerRegistro(Convert.ToInt32(Ddl_per_estado_civil.SelectedValue)).Tables[0];

        if (Txt_per_nombres.Text.ToUpper().Trim().Contains(" "))
        {
            var nombre_completo = Txt_per_nombres.Text.ToUpper().Trim().Split(' ');
            primer_nombre = nombre_completo[0].ToString();
            segundo_nombre = nombre_completo[1].ToString();
        }
        else primer_nombre = Txt_per_nombres.Text.ToUpper().Trim();

        AdicionarPersona();
        Session["texto_notificacion"] = "Registro añadido correctamente...!!";
        Response.Redirect("Persona");
    }

    // ============================================================
    // ADICIONAR PERSONA
    // ============================================================

    private void AdicionarPersona()
    {
        DateTime? fecha_mod = null;

        // 1. GUARDAR PERSONA
        _persona = new cls_persona
        {
            per_id = Convert.ToInt32(Lt_per_id.Text.Trim()),
            per_tipo_doc = Convert.ToInt32(Ddl_per_tipo_doc.SelectedValue),
            per_num_doc = Txt_per_num_doc.Text.ToUpper().Trim(),
            per_lugar_exp = Convert.ToInt32(Ddl_per_lugar_exp.SelectedValue),
            per_ap_paterno = Txt_per_ap_paterno.Text.ToUpper().Trim(),
            per_ap_materno = Txt_per_ap_materno.Text.ToUpper().Trim(),
            per_nombres = Txt_per_nombres.Text.ToUpper().Trim(),
            per_ap_casada = Txt_per_ap_casada.Text.ToUpper().Trim(),
            per_sexo = Rbl_per_sexo.SelectedValue,
            per_fecha_nac = Convert.ToDateTime(Txt_per_fecha_nac.Text.Trim()),
            per_procedencia = Convert.ToInt32(Ddl_per_procedencia.SelectedValue),
            per_serie_libreta_militar = Txt_per_serie_libreta_militar.Text.ToUpper().Trim(),
            per_lugar_nac = Convert.ToInt32(Ddl_per_lugar_nac.SelectedValue),
            per_estado_civil = Convert.ToInt32(Ddl_per_estado_civil.SelectedValue)
        };
        _persona.Adicionar();

        // 2. GUARDAR DOMICILIO (con los nuevos campos)
        _domicilio = new cls_persona_domicilio
        {
            perd_per_id = Convert.ToInt32(Lt_per_id.Text.Trim()),
            perd_ciudad_residencia = Convert.ToInt32(ddlCiudad.SelectedValue),
            perd_zona = Convert.ToInt32(ddlZona.SelectedValue),
            perd_tipo_via = Convert.ToInt32(ddlTipoVia.SelectedValue),
            perd_descripcion_via = txtDescDomicilio.Text.ToUpper().Trim(),
            perd_numero = txtNumDomicilio.Text.ToUpper().Trim(),
            perd_telefono = Txt_perd_telefono.Text.Trim(),
            perd_celular = Txt_perd_celular.Text.Trim(),
            perd_email = Txt_perd_email.Text.Trim()
        };
        _domicilio.Adicionar();

        // 3. GUARDAR AFP
        string cua;
        if (string.IsNullOrEmpty(txtNuaCua.Text))
            cua = "0";
        else
            cua = txtNuaCua.Text;

        _afp = new cls_bs_afp
        {
            afp_per_id = Convert.ToInt32(Lt_per_id.Text.Trim()),
            afp_previsora = Rbl_afp_previsora.SelectedValue,
            afp_fecha_filiacion = DateTime.Now,
            afp_fecha_modificacion = fecha_mod,
            afp_fecha_carnet = DateTime.Now,
            afp_estado_carnet = "V",
            afp_usuario = Convert.ToInt32(Session["per_id"].ToString()),
            afp_nua = cua
        };
        _afp.Adicionar();

        // 4. GUARDAR FORMACIÓN ACADÉMICA
        cls_kd_respuesta_combo gradoAcademico = new cls_kd_respuesta_combo();
        gradoAcademico.ef_nivel_instruccion = Convert.ToInt32(DdlFormacion.SelectedValue);
        gradoAcademico.ef_per_id = Convert.ToInt32(_afp.afp_per_id);
        gradoAcademico.RegistrarFormacion();

        // 5. GUARDAR TIPO APORTANTE
        cls_mp_asignacion tipoAportante = new cls_mp_asignacion();
        tipoAportante.InsertarTipoAportante(Convert.ToInt32(_afp.afp_per_id));

        Limpiar("frm_add_cl");
    }

    // ============================================================
    // FAMILIARES
    // ============================================================

    protected void BtnNuevoF_Click(object sender, EventArgs e)
    {
        _familiar = new cls_persona_familiares();
        var listFam = _familiar.ObtenerTablaGrilla("", Lt_per_id.Text, "", "", "", "", "", "", "V", "", "").Tables[0].Rows.Count;
        Hf_per_id_f.Value = Lt_per_id.Text;
        BindDDLTipoParentesco();

        if (listFam > 0)
        {
            BindGridViewFamily(Lt_per_id.Text);
            sc = "$('#dGvFamily').css('display', 'block'); $('#familyModal').modal('show');";
        }
        else
        {
            Limpiar("gv_fam_cl");
            sc = "$('#dGvFamily').css('display', 'none'); $('#familyModal').modal('show');";
        }
        SetScript(sc, ", dropdownParent: $('#familyModal')");
    }

    private void BindDDLTipoParentesco()
    {
        _catalogo = new cls_catalogo { cat_tabla = "parentesco" };
        Ddl_pf_tipo_parentesco.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_pf_tipo_parentesco.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_pf_tipo_parentesco.DataValueField = "cat_id";
        Ddl_pf_tipo_parentesco.DataTextField = "cat_descripcion";
        Ddl_pf_tipo_parentesco.DataBind();
    }

    protected void BtnGuardarF_Click(object sender, EventArgs e)
    {
        _familiar = new cls_persona_familiares();
        var count = _familiar.ObtenerTablaGrilla("", Hf_per_id_f.Value, Ddl_pf_tipo_parentesco.SelectedValue, Txt_pf_paterno.Text.ToUpper().Trim(), Txt_pf_materno.Text.ToUpper().Trim(), Txt_pf_nombres.Text.ToUpper().Trim(), "", "", "", "", "").Tables[0].Rows.Count;

        if (count > 0)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los datos no se pueden guardar, ya existe un registro con los mismos parámetros...!!' }, { type: 'warning' }); $('#dGvFamily').css('display', 'block');";
            SetScript(sc, ", dropdownParent: $('#familyModal')");
            return;
        }
        _familiar = new cls_persona_familiares
        {
            pf_per_id = Convert.ToInt32(Hf_per_id_f.Value),
            pf_tipo_parentesco = Ddl_pf_tipo_parentesco.SelectedValue,
            pf_paterno = Txt_pf_paterno.Text.ToUpper().Trim(),
            pf_materno = Txt_pf_materno.Text.ToUpper().Trim(),
            pf_nombres = Txt_pf_nombres.Text.ToUpper().Trim(),
            pf_ap_esposo = Txt_pf_ap_esposo.Text.ToUpper().Trim()
        };
        _familiar.Adicionar();
        Limpiar("frm_fam");
        BindGridViewFamily(Hf_per_id_f.Value);
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#dGvFamily').css('display', 'block');";
        SetScript(sc, ", dropdownParent: $('#familyModal')");
    }

    protected void BtnCancelarF_Click(object sender, EventArgs e)
    {
        Limpiar("frm_fam_cl");
        Limpiar("gv_fam_cl");
        sc = "$('#familyModal').modal('hide');";
        SetScript(sc, "");
    }

    // ============================================================
    // LIMPIAR
    // ============================================================

    private void Limpiar(string val)
    {
        if (val.Equals("frm_add_cl"))
        {
            Lt_per_id.Text = string.Empty;
            Ddl_per_tipo_doc.Items.Clear();
            Txt_per_num_doc.Text = string.Empty;
            Ddl_per_lugar_exp.Items.Clear();
            Txt_per_ap_paterno.Text = string.Empty;
            Txt_per_ap_materno.Text = string.Empty;
            Txt_per_nombres.Text = string.Empty;
            Txt_per_ap_casada.Text = string.Empty;
            Rbl_per_sexo.ClearSelection();
            Txt_per_fecha_nac.Text = string.Empty;
            Ddl_per_procedencia.Items.Clear();
            Txt_per_serie_libreta_militar.Text = string.Empty;
            Ddl_per_lugar_nac.Items.Clear();
            Ddl_per_estado_civil.Items.Clear();
            Ddl_per_has.SelectedValue = "0";
            // Domicilio
            ddlDepartamento.Items.Clear();
            ddlProvincia.Items.Clear();
            ddlCiudad.Items.Clear();
            ddlZona.Items.Clear();
            ddlTipoVia.Items.Clear();
            txtDescDomicilio.Text = string.Empty;
            txtNumDomicilio.Text = string.Empty;
            Txt_perd_telefono.Text = string.Empty;
            Txt_perd_celular.Text = string.Empty;
            Txt_perd_email.Text = string.Empty;
            Rbl_afp_previsora.ClearSelection();
            txtNuaCua.Text = "0";
        }
    }

    // ============================================================
    // SET SCRIPT
    // ============================================================

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

    private void SetScript(string val)
    {
        SetScript(val, "");
    }
}