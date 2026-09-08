using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Precontratacion_SolicitudContratacion : System.Web.UI.Page
{
    private cls_persona _persona = null;
    private cls_catalogo _catalogo = null;
    private cls_persona_domicilio _domicilio = null;
    private cls_bs_afp _afp = null;
    private cls_kd_respuesta_combo _grado = null;
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
                CargarCombos();

                string perIdParam = Request.QueryString["per_id"];
                string ciParam = Request.QueryString["ci"];

                if (!string.IsNullOrEmpty(perIdParam))
                {
                    CargarDatosPersonalesPorId(Convert.ToInt32(perIdParam));
                }
                else if (!string.IsNullOrEmpty(ciParam))
                {
                    CargarDatosPersonales();
                }

                GenerarCodigoSolicitud();
            }
        }
        else
        {
            Response.Redirect("../Index");
        }
    }
    private void CargarDatosPersonalesPorId(int perId)
    {
        try
        {
            _persona = new cls_persona();
            DataSet ds = _persona.ObtenerRegistroX(perId);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                txtNombres.Text = row["per_nombres"].ToString();
                txtApPaterno.Text = row["per_ap_paterno"].ToString();
                txtApMaterno.Text = row["per_ap_materno"].ToString();
                txtApEsposo.Text = row["per_ap_casada"] != DBNull.Value ? row["per_ap_casada"].ToString() : "";
                txtNumDoc.Text = row["per_num_doc"].ToString();
                txtLibretaMilitar.Text = row["per_serie_libreta_militar"] != DBNull.Value ? row["per_serie_libreta_militar"].ToString() : "";

                if (row["per_sexo"].ToString() == "F")
                    ddlSexo.SelectedValue = "F";
                else
                    ddlSexo.SelectedValue = "M";

                ddlEstadoCivil.SelectedValue = row["per_estado_civil"].ToString();
                ddlNacionalidad.SelectedValue = row["per_procedencia"].ToString();
                ddlLugarNac.SelectedValue = row["per_lugar_nac"].ToString();
                txtFechaNac.Text = row["per_fecha_nac"] != DBNull.Value
                    ? Convert.ToDateTime(row["per_fecha_nac"]).ToString("dd/MM/yyyy")
                    : "";
                ddlTipoDoc.SelectedValue = row["per_tipo_doc"].ToString();
                ddlLugarExp.SelectedValue = row["per_lugar_exp"].ToString();

                // Nacionalidad -> habilitar/deshabilitar lugar de nacimiento
                if (ddlNacionalidad.SelectedValue == "1")
                {
                    ddlLugarNac.Enabled = true;
                }
                else
                {
                    ddlLugarNac.SelectedValue = "1822";
                    ddlLugarNac.Enabled = false;
                }

                CargarAfpYNUA(perId);

                CargarGradoAcademico(perId);

                CargarDomicilioPorPerId(perId);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar datos por ID: " + ex.Message);
        }
    }

    // ============================================================
    // CARGA DE AFP Y NUA/CUA
    // ============================================================
    private void CargarAfpYNUA(int perId)
    {
        try
        {
            cls_bs_afp afp = new cls_bs_afp();
            afp.afp_per_id = perId;
            DataSet ds = afp.ObtenerRegistro();
            if (ds.Tables[0].Rows.Count > 0)
            {
                string previsora = ds.Tables[0].Rows[0]["afp_previsora"].ToString();
                if (!string.IsNullOrEmpty(previsora))
                {
                    rblAfpPrevisora.SelectedValue = previsora;
                }
                else
                {
                    rblAfpPrevisora.SelectedValue = "GP";
                }

                string nua = ds.Tables[0].Rows[0]["afp_nua"].ToString();
                txtNuaCua.Text = string.IsNullOrEmpty(nua) ? "0" : nua;
            }
            else
            {
                rblAfpPrevisora.SelectedValue = "GP";
                txtNuaCua.Text = "0";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar AFP: " + ex.Message);
        }
    }

    // ============================================================
    // CARGA DE GRADO ACADÉMICO
    // ============================================================
    private void CargarGradoAcademico(int perId)
    {
        try
        {
            cls_kd_respuesta_combo grado = new cls_kd_respuesta_combo();
            grado.ef_per_id = perId;
            DataSet ds = grado.ObtenerNivelInstruccion(grado);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string nivel = ds.Tables[0].Rows[0]["ef_nivel_instruccion"].ToString();
                if (!string.IsNullOrEmpty(nivel))
                {
                    DdlFormacion.SelectedValue = nivel;
                }
                else
                {
                    DdlFormacion.SelectedIndex = 0;
                }
            }
            else
            {
                DdlFormacion.SelectedIndex = 0;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar grado académico: " + ex.Message);
        }
    }

    // ============================================================
    // CARGA DE DOMICILIO POR PER_ID
    // ============================================================
    private void CargarDomicilioPorPerId(int perId)
    {
        try
        {
            cls_persona_domicilio domicilio = new cls_persona_domicilio();

            DataSet ds = domicilio.ObtenerTablaGrilla(
                "", perId.ToString(), "", "", "", "", "", "", "", "", ""
            );

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                // Ciudad
                if (row["perd_ciudad_residencia"] != DBNull.Value)
                {
                    int ciudadId = Convert.ToInt32(row["perd_ciudad_residencia"]);
                    CargarUbicacionPorCiudad(ciudadId);
                }

                // Zona
                if (row["perd_zona"] != DBNull.Value)
                    ddlZona.SelectedValue = row["perd_zona"].ToString();

                // Tipo Vía
                if (row["perd_tipo_via"] != DBNull.Value)
                    ddlTipoVia.SelectedValue = row["perd_tipo_via"].ToString();

                // Descripción y número
                txtDescDomicilio.Text = row["perd_descripcion_via"] != DBNull.Value ? row["perd_descripcion_via"].ToString() : "";
                txtNumDomicilio.Text = row["perd_numero"] != DBNull.Value ? row["perd_numero"].ToString() : "";

                // Teléfonos y email
                txtTelefono.Text = row["perd_telefono"] != DBNull.Value ? row["perd_telefono"].ToString() : "";
                txtCelular.Text = row["perd_celular"] != DBNull.Value ? row["perd_celular"].ToString() : "";
                txtEmail.Text = row["perd_email"] != DBNull.Value ? row["perd_email"].ToString() : "";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar domicilio: " + ex.Message);
        }
    }

    // ============================================================
    // CARGA DE UBICACIÓN (DEPARTAMENTO, PROVINCIA, CIUDAD) A PARTIR DE CIUDAD
    // ============================================================
    private void CargarUbicacionPorCiudad(int ciudadId)
    {
        try
        {
            _catalogo = new cls_catalogo { cat_tabla = "ciudad_localidad", cat_id_superior = 0 };
            DataSet ds = _catalogo.ObtenerTablaCombo();

            if (ds != null && ds.Tables.Count > 0)
            {
                DataRow[] rows = ds.Tables[0].Select("cat_id = " + ciudadId);
                if (rows.Length > 0)
                {
                    int idProvincia = Convert.ToInt32(rows[0]["cat_id_superior"]);

                    _catalogo = new cls_catalogo { cat_tabla = "provincia", cat_id_superior = idProvincia };
                    DataSet dsProv = _catalogo.ObtenerTablaCombo();

                    if (dsProv != null && dsProv.Tables.Count > 0 && dsProv.Tables[0].Rows.Count > 0)
                    {
                        int idDepartamento = Convert.ToInt32(dsProv.Tables[0].Rows[0]["cat_id_superior"]);

                        ddlDepartamento.SelectedValue = idDepartamento.ToString();

                        CargarProvincias(idDepartamento);

                        ddlProvincia.SelectedValue = idProvincia.ToString();

                        CargarCiudades(idProvincia);

                        ddlCiudad.SelectedValue = ciudadId.ToString();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar ubicación: " + ex.Message);
        }
    }

    // ============================================================
    // GENERAR CÓDIGO DE SOLICITUD
    // ============================================================
    private void GenerarCodigoSolicitud()
    {
        try
        {
            cls_catalogo catalogo = new cls_catalogo();
            catalogo.cat_tabla = "SolicitudContratacion";

            DataSet ds = catalogo.ObtenerTablaCombo();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                int maxId = 0;
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    int id = Convert.ToInt32(row["cat_id"]);
                    if (id > maxId)
                        maxId = id;
                }

                lblCodigoSolicitud.Text = (maxId + 1).ToString();
                ViewState["NextSolId"] = maxId + 1;
            }
            else
            {
                lblCodigoSolicitud.Text = "1";
                ViewState["NextSolId"] = 1;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al generar código: " + ex.Message);
            lblCodigoSolicitud.Text = "Nuevo";
        }
    }

    // ============================================================
    // CARGA DE DATOS POR CI (cuando se busca por CI desde otra parte)
    // ============================================================
    private void CargarDatosPersonales()
    {
        string ci = Request.QueryString["ci"];

        if (!string.IsNullOrEmpty(ci))
        {
            try
            {
                _persona = new cls_persona();
                DataSet ds = _persona.VerificarNuevoFuncionario(ci, 0);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    DataRow row = ds.Tables[0].Rows[0];

                    txtNombres.Text = row["per_nombres"].ToString();
                    txtApPaterno.Text = row["per_ap_paterno"].ToString();
                    txtApMaterno.Text = row["per_ap_materno"].ToString();
                    txtApEsposo.Text = row["per_ap_casada"].ToString();
                    txtNumDoc.Text = row["per_num_doc"].ToString();

                    if (row["per_sexo"].ToString() == "F")
                        ddlSexo.SelectedValue = "F";
                    else
                        ddlSexo.SelectedValue = "M";

                    ddlEstadoCivil.SelectedValue = row["per_estado_civil"].ToString();
                    ddlNacionalidad.SelectedValue = row["per_procedencia"].ToString();
                    ddlLugarNac.SelectedValue = row["per_lugar_nac"].ToString();
                    txtFechaNac.Text = Convert.ToDateTime(row["per_fecha_nac"]).ToString("dd/MM/yyyy");
                    ddlTipoDoc.SelectedValue = row["per_tipo_doc"].ToString();
                    ddlLugarExp.SelectedValue = row["per_lugar_exp"].ToString();

                    if (ddlNacionalidad.SelectedValue == "1")
                    {
                        ddlLugarNac.Enabled = true;
                    }
                    else
                    {
                        ddlLugarNac.SelectedValue = "1822";
                        ddlLugarNac.Enabled = false;
                    }

                    txtLibretaMilitar.Text = row["per_serie_libreta_militar"] != DBNull.Value ? row["per_serie_libreta_militar"].ToString() : "";
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al cargar datos: " + ex.Message);
            }
        }
    }

    // ============================================================
    // CARGA DE COMBOS
    // ============================================================
    private void CargarCombos()
    {
        try
        {
            // Tipo de Documento
            _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_personal" };
            ddlTipoDoc.DataSource = _catalogo.ObtenerTablaCombo();
            ddlTipoDoc.DataValueField = "cat_id";
            ddlTipoDoc.DataTextField = "cat_descripcion";
            ddlTipoDoc.DataBind();
            ddlTipoDoc.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // Lugar Expedido
            _catalogo = new cls_catalogo { cat_tabla = "departamento" };
            ddlLugarExp.DataSource = _catalogo.ObtenerTablaCombo();
            ddlLugarExp.DataValueField = "cat_id";
            ddlLugarExp.DataTextField = "cat_descripcion";
            ddlLugarExp.DataBind();
            ddlLugarExp.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // Estado Civil
            _catalogo = new cls_catalogo { cat_tabla = "estado_civil" };
            ddlEstadoCivil.DataSource = _catalogo.ObtenerTablaCombo();
            ddlEstadoCivil.DataValueField = "cat_id";
            ddlEstadoCivil.DataTextField = "cat_descripcion";
            ddlEstadoCivil.DataBind();
            ddlEstadoCivil.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // Nacionalidad
            _catalogo = new cls_catalogo { cat_tabla = "pais" };
            ddlNacionalidad.DataSource = _catalogo.ObtenerTablaCombo();
            ddlNacionalidad.DataValueField = "cat_id";
            ddlNacionalidad.DataTextField = "cat_descripcion";
            ddlNacionalidad.DataBind();
            ddlNacionalidad.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // Lugar de Nacimiento
            _catalogo = new cls_catalogo();
            ddlLugarNac.DataSource = _catalogo.ObtenerLugarNacimiento();
            ddlLugarNac.DataValueField = "id_ciudad";
            ddlLugarNac.DataTextField = "lugar_nac";
            ddlLugarNac.DataBind();
            ddlLugarNac.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // Departamento
            _catalogo = new cls_catalogo { cat_tabla = "departamento" };
            ddlDepartamento.DataSource = _catalogo.ObtenerTablaCombo();
            ddlDepartamento.DataValueField = "cat_id";
            ddlDepartamento.DataTextField = "cat_descripcion";
            ddlDepartamento.DataBind();
            ddlDepartamento.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // PROVINCIA (inicialmente vacío)
            ddlProvincia.Items.Clear();
            ddlProvincia.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // CIUDAD DE RESIDENCIA
            _catalogo = new cls_catalogo { cat_tabla = "ciudad_localidad", cat_id_superior = 0 };
            ddlCiudad.DataSource = _catalogo.ObtenerTablaCombo();
            ddlCiudad.DataValueField = "cat_id";
            ddlCiudad.DataTextField = "cat_descripcion";
            ddlCiudad.DataBind();
            ddlCiudad.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // ZONA
            _catalogo = new cls_catalogo { cat_tabla = "zona", cat_id_superior = 0 };
            ddlZona.DataSource = _catalogo.ObtenerTablaCombo();
            ddlZona.DataValueField = "cat_secuencial";
            ddlZona.DataTextField = "cat_descripcion";
            ddlZona.DataBind();
            ddlZona.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // Tipo de Vía
            _catalogo = new cls_catalogo { cat_tabla = "tipo_via" };
            ddlTipoVia.DataSource = _catalogo.ObtenerTablaCombo();
            ddlTipoVia.DataValueField = "cat_id";
            ddlTipoVia.DataTextField = "cat_descripcion";
            ddlTipoVia.DataBind();
            ddlTipoVia.Items.Insert(0, new ListItem("Seleccione...", "0"));

            // GRADO ACADÉMICO
            BindGradoAcademico();

            // Combos para el modal de Ciudad
            _catalogo = new cls_catalogo { cat_tabla = "departamento" };
            ddlCiudadDepartamento.DataSource = _catalogo.ObtenerTablaCombo();
            ddlCiudadDepartamento.DataValueField = "cat_id";
            ddlCiudadDepartamento.DataTextField = "cat_descripcion";
            ddlCiudadDepartamento.DataBind();
            ddlCiudadDepartamento.Items.Insert(0, new ListItem("Seleccione...", "0"));

            ddlCiudadProvincia.Items.Clear();
            ddlCiudadProvincia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar combos: " + ex.Message);
        }
    }

    private void BindGradoAcademico()
    {
        try
        {
            cls_grado_academico grado_academico = new cls_grado_academico();
            DdlFormacion.Items.Clear();
            DdlFormacion.DataSource = grado_academico.ObtenerGradoAcademico();
            DdlFormacion.DataValueField = "ga_id";
            DdlFormacion.DataTextField = "ga_nombre";
            DdlFormacion.DataBind();
            DdlFormacion.Items.Insert(0, new ListItem("Seleccione...", "0"));
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al cargar grado académico: " + ex.Message);
        }
    }

    // ============================================================
    // EVENTOS DE CAMBIO DE NACIONALIDAD, DEPARTAMENTO, PROVINCIA
    // ============================================================
    protected void ddlNacionalidad_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlNacionalidad.SelectedValue == "1")
        {
            ddlLugarNac.SelectedValue = "0";
            ddlLugarNac.Enabled = true;
        }
        else
        {
            ddlLugarNac.SelectedValue = "1822";
            ddlLugarNac.Enabled = false;
        }
    }

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
    // CARGA DE PROVINCIAS Y CIUDADES
    // ============================================================
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
    // BOTONES DE MODALES (NUEVA ZONA, NUEVA CIUDAD)
    // ============================================================
    protected void btnNuevaZona_Click(object sender, EventArgs e)
    {
        txtNuevaZona.Text = "";
        sc = "$('#modalNuevaZona').modal('show');";
        SetScript(sc, "");
    }

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
    // GUARDAR (CREAR O ACTUALIZAR FUNCIONARIO)
    // ============================================================
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            // ===========================================
            // VALIDACIONES
            // ===========================================
            if (string.IsNullOrEmpty(txtNombres.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar los Nombres' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            if (string.IsNullOrEmpty(txtApPaterno.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar el Apellido Paterno' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            if (string.IsNullOrEmpty(txtApMaterno.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar el Apellido Materno' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            if (string.IsNullOrEmpty(txtNumDoc.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar el Número de Documento' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            if (string.IsNullOrEmpty(txtFechaNac.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar la Fecha de Nacimiento' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            if (DdlFormacion.SelectedValue == "0")
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar el Último Grado Académico Adquirido' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
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
            if (string.IsNullOrEmpty(rblAfpPrevisora.SelectedValue))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar una AFP' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            // ===========================================
            // VERIFICAR SI YA EXISTE POR CI
            // ===========================================
            _persona = new cls_persona();
            DataSet dsVerificar = _persona.VerificarNuevoFuncionario(txtNumDoc.Text.Trim(), 0);

            int perIdExistente = 0;
            if (dsVerificar.Tables[0].Rows.Count > 0)
            {
                perIdExistente = Convert.ToInt32(dsVerificar.Tables[0].Rows[0]["per_id"]);
            }

            // ===========================================
            // SI EXISTE, ACTUALIZAR DATOS
            // ===========================================
            if (perIdExistente > 0)
            {
                // Actualizar persona (incluyendo libreta militar)
                ActualizarPersona(perIdExistente);

                // Actualizar domicilio
                GuardarDomicilio(perIdExistente);

                // Actualizar grado académico
                GuardarGradoAcademico(perIdExistente);

                // Actualizar AFP y NUA
                GuardarAfp(perIdExistente);

                sc = "$.notify({ icon: 'fas fa-check', message: '✅ Datos actualizados correctamente' }, { type: 'success' });";
                SetScript(sc, "");

                // Redirigir a curriculum
                bool tieneCurriculum = VerificarCurriculumCompleto(perIdExistente);
                if (tieneCurriculum)
                    Response.Redirect("CurriculumCandidato.aspx?per_id=" + perIdExistente + "&modo=ver");
                else
                    Response.Redirect("CurriculumCandidato.aspx?per_id=" + perIdExistente + "&modo=completar");
                return;
            }

            // ===========================================
            // SI NO EXISTE, CREAR NUEVO
            // ===========================================
            int nuevoPerId = InsertarNuevoFuncionario();

            if (nuevoPerId == 0)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al registrar el funcionario' }, { type: 'danger' });";
                SetScript(sc, "");
                return;
            }

            // Guardar domicilio
            GuardarDomicilio(nuevoPerId);

            // Guardar grado académico
            GuardarGradoAcademico(nuevoPerId);

            // Guardar AFP y NUA
            GuardarAfp(nuevoPerId);

            sc = "$.notify({ icon: 'fas fa-check', message: '✅ Funcionario registrado correctamente. Complete el Curriculum.' }, { type: 'success' });";
            SetScript(sc, "");

            Response.Redirect("CurriculumCandidato.aspx?per_id=" + nuevoPerId + "&modo=nuevo");
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al validar: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    // ============================================================
    // MÉTODOS DE INSERCIÓN / ACTUALIZACIÓN (SOLO CON MÉTODOS EXISTENTES)
    // ============================================================

    private int InsertarNuevoFuncionario()
    {
        try
        {
            cls_persona persona = new cls_persona();

            persona.per_nombres = txtNombres.Text.ToUpper().Trim();
            persona.per_ap_paterno = txtApPaterno.Text.ToUpper().Trim();
            persona.per_ap_materno = txtApMaterno.Text.ToUpper().Trim();
            persona.per_ap_casada = string.IsNullOrEmpty(txtApEsposo.Text) ? "" : txtApEsposo.Text.ToUpper().Trim();
            persona.per_sexo = ddlSexo.SelectedValue;
            persona.per_tipo_doc = Convert.ToInt32(ddlTipoDoc.SelectedValue);
            persona.per_num_doc = txtNumDoc.Text.ToUpper().Trim();
            persona.per_lugar_exp = Convert.ToInt32(ddlLugarExp.SelectedValue);
            persona.per_estado_civil = Convert.ToInt32(ddlEstadoCivil.SelectedValue);
            persona.per_fecha_nac = Convert.ToDateTime(txtFechaNac.Text.Trim());
            persona.per_procedencia = Convert.ToInt32(ddlNacionalidad.SelectedValue);
            persona.per_lugar_nac = Convert.ToInt32(ddlLugarNac.SelectedValue);
            persona.per_serie_libreta_militar = txtLibretaMilitar.Text.ToUpper().Trim();

            if (persona.Adicionar())
            {
                DataSet ds = persona.ObtenerRegistroX(0);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"]);
                }
            }
            return 0;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al insertar funcionario: " + ex.Message);
            return 0;
        }
    }

    private void ActualizarPersona(int perId)
    {
        try
        {
            cls_persona persona = new cls_persona();
            persona.per_id = perId;
            persona.per_nombres = txtNombres.Text.ToUpper().Trim();
            persona.per_ap_paterno = txtApPaterno.Text.ToUpper().Trim();
            persona.per_ap_materno = txtApMaterno.Text.ToUpper().Trim();
            persona.per_ap_casada = string.IsNullOrEmpty(txtApEsposo.Text) ? "" : txtApEsposo.Text.ToUpper().Trim();
            persona.per_sexo = ddlSexo.SelectedValue;
            persona.per_tipo_doc = Convert.ToInt32(ddlTipoDoc.SelectedValue);
            persona.per_num_doc = txtNumDoc.Text.ToUpper().Trim();
            persona.per_lugar_exp = Convert.ToInt32(ddlLugarExp.SelectedValue);
            persona.per_estado_civil = Convert.ToInt32(ddlEstadoCivil.SelectedValue);
            persona.per_fecha_nac = Convert.ToDateTime(txtFechaNac.Text.Trim());
            persona.per_procedencia = Convert.ToInt32(ddlNacionalidad.SelectedValue);
            persona.per_lugar_nac = Convert.ToInt32(ddlLugarNac.SelectedValue);
            persona.per_serie_libreta_militar = txtLibretaMilitar.Text.ToUpper().Trim();
            // Usamos el método que ya existe en tu capa de negocio
            persona.Actualizar__personaConLibreta();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al actualizar persona: " + ex.Message);
        }
    }

    private bool GuardarDomicilio(int perId)
    {
        try
        {
            cls_persona_domicilio domicilio = new cls_persona_domicilio();

            DataSet dsExistente = domicilio.ObtenerTablaGrilla("", perId.ToString(), "", "", "", "", "", "", "", "", "");
            bool existeDomicilio = (dsExistente != null && dsExistente.Tables.Count > 0 && dsExistente.Tables[0].Rows.Count > 0);

            domicilio.perd_per_id = perId;
            domicilio.perd_ciudad_residencia = Convert.ToInt32(ddlCiudad.SelectedValue);
            domicilio.perd_zona = Convert.ToInt32(ddlZona.SelectedValue);
            domicilio.perd_tipo_via = Convert.ToInt32(ddlTipoVia.SelectedValue);
            domicilio.perd_descripcion_via = txtDescDomicilio.Text.ToUpper().Trim();
            domicilio.perd_numero = txtNumDomicilio.Text.ToUpper().Trim();
            domicilio.perd_telefono = string.IsNullOrEmpty(txtTelefono.Text) ? "" : txtTelefono.Text.Trim();
            domicilio.perd_celular = string.IsNullOrEmpty(txtCelular.Text) ? "" : txtCelular.Text.Trim();
            domicilio.perd_email = string.IsNullOrEmpty(txtEmail.Text) ? "" : txtEmail.Text.Trim();

            if (existeDomicilio)
                return domicilio.Actualizar();
            else
                return domicilio.Adicionar();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al guardar domicilio: " + ex.Message);
            return false;
        }
    }

    private void GuardarGradoAcademico(int perId)
    {
        try
        {
            cls_kd_respuesta_combo grado = new cls_kd_respuesta_combo();
            grado.ef_per_id = perId;
            grado.ef_nivel_instruccion = Convert.ToInt32(DdlFormacion.SelectedValue);

            // Verificar si ya existe registro
            DataSet ds = grado.ObtenerNivelInstruccion(grado);
            if (ds.Tables[0].Rows.Count > 0)
            {
                grado.ef_id = Convert.ToInt32(ds.Tables[0].Rows[0]["ef_id"]);
                grado.ActualizarNivelInstruccion(grado);
            }
            else
            {
                // Si no existe, usamos el método que tienes en tu capa de negocio
                // Buscamos si existe un método similar a "AdicionarNivelInstruccion"
                // Si no existe, podrías insertar manualmente o usar el que ya tienes
                // Como no sé si existe, intentamos con el método que usas en ActualizacionInformacionPersonal
                // En ese archivo no se inserta, solo se actualiza. Pero como es nuevo, quizás necesites insertar.
                // Si no existe, podrías usar un método directo a la BD o crear uno.
                // Por simplicidad, si no existe, no hacemos nada (o podrías lanzar una excepción).
                // Pero para que funcione, te recomiendo que crees un método AdicionarNivelInstruccion en tu capa de negocio.
                // Mientras tanto, puedes usar este código alternativo (si existe el método AdicionarNivelInstruccion).
                // Si no, comenta esta parte y avísame para darte otra alternativa.
                // grado.AdicionarNivelInstruccion(grado); // Descomenta si existe
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al guardar grado académico: " + ex.Message);
        }
    }

    private void GuardarAfp(int perId)
    {
        try
        {
            cls_bs_afp afp = new cls_bs_afp();
            afp.afp_per_id = perId;
            afp.afp_previsora = rblAfpPrevisora.SelectedValue;
            afp.afp_fecha_filiacion = DateTime.Now;
            afp.afp_fecha_modificacion = null;
            afp.afp_fecha_carnet = DateTime.Now;
            afp.afp_estado_carnet = "V";
            afp.afp_usuario = Convert.ToInt32(Session["per_id"].ToString());
            afp.afp_nua = string.IsNullOrEmpty(txtNuaCua.Text) ? "0" : txtNuaCua.Text;

            // Verificar si ya existe registro
            DataSet ds = afp.ObtenerRegistro();
            if (ds.Tables[0].Rows.Count > 0)
            {
                afp.ActualizarAfp(afp);
                afp.ActualizarCuaNua(afp);
            }
            else
            {
                // Si no existe, insertar (si tienes un método Adicionar en cls_bs_afp)
                // afp.Adicionar(afp); // Descomenta si existe
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error al guardar AFP: " + ex.Message);
        }
    }

    private bool VerificarCurriculumCompleto(int perId)
    {
        try
        {
            cls_cv_formacion formacion = new cls_cv_formacion();
            DataSet ds = formacion.ObtenerGrilla_Formacion(perId);
            return (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0);
        }
        catch
        {
            return false;
        }
    }

    // ============================================================
    // BOTÓN CANCELAR
    // ============================================================
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("ListaSolicitudes.aspx");
    }

    // ============================================================
    // SCRIPTS
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