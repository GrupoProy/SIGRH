using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;

/// Página principal del módulo de Declaración Jurada del Funcionario.
/// Gestiona las 4 secciones: Domicilio, Educación, Familiares y Doble Percepción.

public partial class Kardex_FiliacionUpdate : System.Web.UI.Page
{
    #region ═══════════════ CAMPOS PRIVADOS ═══════════════

    private string sc = "";
    private int _per_id = 0;
    private int? _gestionActual = null;

    #endregion

    #region ═══════════════ EVENTOS DE PÁGINA ═══════════════

    
    /// Evento de carga inicial de la página.
    
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string perIdFromSession = Session["per_id"]?.ToString();
            string perIdFromQuery = Request.QueryString["per_id"];

            // Priorizar QueryString sobre Session
            if (!string.IsNullOrEmpty(perIdFromQuery))
            {
                perIdFromSession = perIdFromQuery;
                Session["per_id"] = perIdFromSession;
            }

            if (string.IsNullOrEmpty(perIdFromSession))
            {
                Response.Redirect("../Index");
                return;
            }

            _per_id = Convert.ToInt32(perIdFromSession);

            if (!Page.IsPostBack)
            {
                InicializarPagina();
                

            }
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar la página: {ex.Message}", "danger");
        }
    }

    /// Inicializa todos los componentes de la página en la primera carga.
    
    private void InicializarPagina()
    {
        BindForm(_per_id.ToString());
        VerificarEstadoDeclaracion(_per_id);
        CargarCatalogosOpcion1();
        CargarLibretaMilitar(_per_id);
        CargarDomicilioExistente();
        hf_uniqueid_finalizar.Value = btnFinalizar4_2.UniqueID;
        ActivarPestana(btnTab1, 0);
    }

    #endregion

    #region ═══════════════ DECLARACIÓN JURADA ═══════════════

    
    /// Verifica el estado de la DDJJ para la gestión actual y ajusta el botón principal.
    /// Estados:
    ///   1. No existe → COMENZAR (verde)
    ///   2. Estado 'V' → CONTINUAR DECLARACIÓN (amarillo)
    ///   3. Estado 'F' → DECLARACIÓN YA FINALIZADA (gris) + IMPRIMIR visible
 
    private void VerificarEstadoDeclaracion(int personaId)
    {
        try
        {
            var declaracion = new cls_declaracion_jurada();
            int gestionActual = ObtenerGestion();

            DataSet ds = declaracion.ObtenerEstadoDeclaracionPorGestion(personaId, gestionActual);

            // CASO 1: No existe declaración
            if (EsDataSetVacio(ds))
            {
                ConfigurarBotonPrincipal(
                    texto: "COMENZAR",
                    cssClass: "btn btn-success w-100 py-3 rounded-pill shadow-sm fw-bold fs-6",
                    leyenda: "Actualice su información personal y profesional",
                    mostrarImprimir: false);

                DivImprimirDDJJ.Visible = false;
                return;
            }

            DataRow row = ds.Tables[0].Rows[0];
            string estado = row["dj_estado"].ToString();
            string djId = row["dj_id"].ToString();

            // CASO 2: Estado 'V' (Vigente)
            if (estado == "V")
            {
                ConfigurarBotonPrincipal(
                    texto: "CONTINUAR DECLARACIÓN",
                    cssClass: "btn btn-warning w-100 py-3 rounded-pill shadow-sm fw-bold fs-6",
                    leyenda: $"Tiene una DDJJ EN CURSO para la gestión {gestionActual}. Haga clic para continuar editando.",
                    mostrarImprimir: false);

                Session["dj_id"] = djId;
                Session["dj_estado"] = "V";
                DivImprimirDDJJ.Visible = false;
            }
            // CASO 3: Estado 'F' (Finalizada)
            else if (estado == "F")
            {
                DateTime fechaFin = row["dj_fecha_fin"] != DBNull.Value
                    ? Convert.ToDateTime(row["dj_fecha_fin"])
                    : DateTime.MinValue;

                ConfigurarBotonPrincipal(
                    texto: "DECLARACIÓN YA FINALIZADA",
                    cssClass: "btn btn-secondary w-100 py-3 rounded-pill shadow-sm fw-bold fs-6",
                    leyenda: $"Usted ya realizó su DDJJ para la gestión {gestionActual}. Finalizada el {fechaFin:dd/MM/yyyy HH:mm}.",
                    mostrarImprimir: true);

                Session["dj_id"] = djId;
                Session["dj_estado"] = "F";
                DivImprimirDDJJ.Visible = true;
            }
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al verificar declaración: {ex.Message}", "danger");
        }
    }

    /// Maneja el clic del botón principal (COMENZAR/CONTINUAR/FINALIZADA).
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        try
        {
            if (_per_id == 0)
            {
                MostrarNotificacion("No se pudo identificar al usuario", "danger");
                return;
            }

            var declaracion = new cls_declaracion_jurada();
            int gestionActual = ObtenerGestion();
            DataSet ds = declaracion.ObtenerEstadoDeclaracionPorGestion(_per_id, gestionActual);

            // CASO 1: Crear nueva DDJJ
            if (EsDataSetVacio(ds))
            {
                CrearNuevaDeclaracion(gestionActual);
                return;
            }

            DataRow row = ds.Tables[0].Rows[0];
            string estado = row["dj_estado"].ToString();
            string djId = row["dj_id"].ToString();

            // CASO 2: Continuar DDJJ existente
            if (estado == "V")
            {
                Session["dj_id"] = djId;
                Session["dj_estado"] = "V";

                ltl_dj_id.Text = djId;
                ltl_fecha_inicio.Text = Convert.ToDateTime(row["dj_fecha_inicio"]).ToString("dd/MM/yyyy HH:mm");

                MostrarNotificacion($"Continuando con la DDJJ de la gestión {gestionActual}", "info");
                MostrarFormulario();
                return;
            }

            // CASO 3: DDJJ finalizada - solo mostrar alerta
            if (estado == "F")
            {
                DateTime fechaFin = row["dj_fecha_fin"] != DBNull.Value
                    ? Convert.ToDateTime(row["dj_fecha_fin"])
                    : DateTime.MinValue;

                string mensaje = $"Usted ya realizó su DDJJ para la gestión {gestionActual}. " +
                                 $"Finalizada el {fechaFin:dd/MM/yyyy} a las {fechaFin:HH:mm}.";

                MostrarNotificacion(mensaje, "warning", 8000, "top");
                DivImprimirDDJJ.Visible = true;
            }
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error: {ex.Message}", "danger");
        }
    }

    /// Crea una nueva Declaración Jurada.
    private void CrearNuevaDeclaracion(int gestionActual)
    {
        var nuevaDeclaracion = new cls_declaracion_jurada
        {
            dj_persona_id = _per_id,
            dj_fecha_inicio = DateTime.Now,
            dj_fecha_fin = null,
            dj_gestion = gestionActual,
            dj_estado = "V",
            dj_usuario = Session["usuario"]?.ToString() ?? "Sistema",
            dj_fecha_creacion = DateTime.Now,
            dj_usuario_modificacion = _per_id,
            dj_fecha_modificacion = DateTime.Now
        };

        if (nuevaDeclaracion.Adicionar())
        {
            Session["dj_id"] = nuevaDeclaracion.dj_id;
            Session["dj_estado"] = "V";

            ltl_dj_id.Text = nuevaDeclaracion.dj_id.ToString();
            ltl_fecha_inicio.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            MostrarNotificacion($"DDJJ iniciada para la gestión {gestionActual}", "success");
            MostrarFormulario();
        }
        else
        {
            MostrarNotificacion("No se pudo iniciar la DDJJ", "danger");
        }
    }

    /// Muestra el formulario y oculta el botón COMENZAR.
    private void MostrarFormulario()
    {
        divCV.Visible = true;
        LinkButton1.Visible = false;
        leyenda.Visible = false;
        DivImprimirDDJJ.Visible = false;
        ActivarPestana(btnTab1, 0);
    }


    /// Finaliza la Declaración Jurada completa (cambia estado a 'F').
    /*
    private void FinalizarDeclaracionCompleta()
    {
        string djIdStr = Session["dj_id"]?.ToString();

        if (string.IsNullOrEmpty(djIdStr))
            throw new Exception("No hay DDJJ activa en sesión");

        int djId = Convert.ToInt32(djIdStr);
        var declaracion = new cls_declaracion_jurada();

        if (!declaracion.FinalizarDeclaracionJurada(djId))
            throw new Exception("No se pudo finalizar la declaración");

        Session["dj_estado"] = "F";
        DivImprimirDDJJ.Visible = true;
        LinkButton1.Visible = false;
    }*/

    /// Finaliza la Declaración Jurada completa (cambia estado a 'F' en BD).
    /// Valida previamente que exista al menos un registro en Doble Percepción.
    private void FinalizarDeclaracionCompleta()
    {
        try
        {
            string djIdStr = Session["dj_id"]?.ToString();

            if (string.IsNullOrEmpty(djIdStr))
                throw new Exception("No hay una Declaración Jurada activa en sesión.");

            int djId = Convert.ToInt32(djIdStr);

            // ═══════════════════════════════════════════════════════
            // ✅ VALIDACIÓN PREVIA: Doble Percepción registrada
            // ═══════════════════════════════════════════════════════
            if (!TieneDoblePercepcionRegistrada(_per_id))
            {
                MostrarAlerta(
                    "Debe registrar al menos una declaración en la sección " +
                    "'Doble Percepción' (Sí o No) antes de finalizar su Declaración Jurada.",
                    "warning");
                return;  // ⛔ No finaliza
            }

            // ═══════════════════════════════════════════════════════
            // 1. Obtener la DDJJ para verificar que sigue vigente
            // ═══════════════════════════════════════════════════════
            var declaracion = new cls_declaracion_jurada();
            DataSet ds = declaracion.ObtenerDeclaracionJuradaActiva(_per_id);

            if (EsDataSetVacio(ds))
                throw new Exception("No se encontró una Declaración Jurada activa para finalizar.");

            string estadoActual = ds.Tables[0].Rows[0]["dj_estado"].ToString();
            if (estadoActual == "F")
                throw new Exception("La Declaración Jurada ya fue finalizada previamente.");

            // ═══════════════════════════════════════════════════════
            // 2. Finalizar en BD (UPDATE dj_estado = 'F', dj_fecha_fin = GETDATE())
            // ═══════════════════════════════════════════════════════
            if (!declaracion.FinalizarDeclaracionJurada(djId, _per_id))
                throw new Exception("No se pudo finalizar la Declaración Jurada en la base de datos.");

            // ═══════════════════════════════════════════════════════
            // 3. Actualizar estado en sesión y UI
            // ═══════════════════════════════════════════════════════
            Session["dj_estado"] = "F";
            DivImprimirDDJJ.Visible = true;
            LinkButton1.Visible = false;

            // 4. Refrescar la pantalla para reflejar el nuevo estado
            VerificarEstadoDeclaracion(_per_id);

            MostrarAlerta("¡Declaración Jurada finalizada correctamente!", "success");
        }
        catch (Exception ex)
        {
            MostrarAlerta("Error al finalizar: " + ex.Message, "error");
        }
    }

    /// Verifica si el funcionario tiene al menos un registro en Doble Percepción
    /// (sin importar si es Sí o No).

    private bool TieneDoblePercepcionRegistrada(int per_id)
    {
        try
        {
            var dp = new cls_doblepercepcion();
            DataSet ds = dp.ObtenerGrillaDoblePercepcion(per_id);

            return !EsDataSetVacio(ds);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error TieneDoblePercepcionRegistrada: {ex.Message}");
            return false;
        }
    }

    /// Obtiene el año de gestión actual desde el servidor de base de datos.
    /// Usa caché interna para evitar consultas múltiples en el mismo postback.

    private int ObtenerGestion()
    {
        if (_gestionActual.HasValue)
            return _gestionActual.Value;

        var declaracion = new cls_declaracion_jurada();
        _gestionActual = declaracion.ObtenerGestionActualDesdeServidor();
        return _gestionActual.Value;
    }


    /// Configura el botón principal según el estado de la DDJJ.

    private void ConfigurarBotonPrincipal(string texto, string cssClass, string leyenda, bool mostrarImprimir)
    {
        LinkButton1.Text = texto;
        LinkButton1.CssClass = cssClass;
        LinkButton1.Enabled = true;
        this.leyenda.InnerText = leyenda;
        DivImprimirDDJJ.Visible = mostrarImprimir;
    }

    #endregion

    #region ═══════════════ DATOS PERSONALES ═══════════════

    /// Carga los datos personales del funcionario en los Literals.
    private void BindForm(string perId)
    {
        try
        {
            var persona = new cls_persona();
            DataSet ds = persona.ObtenerRegistroX(Convert.ToInt32(perId));

            if (EsDataSetVacio(ds)) return;

            DataRow row = ds.Tables[0].Rows[0];

            ltl_nombre_fun.Text = $"{row["per_nombres"]} {row["per_ap_paterno"]} {row["per_ap_materno"]}".Trim();
            ltl_num_doc.Text = $"{row["per_num_doc"]} - {ObtenerDescripcionCatalogo("departamento", row["per_lugar_exp"])}";
            ltl_estado_civil.Text = ObtenerDescripcionCatalogo("estado_civil", row["per_estado_civil"]);
            ltl_genero.Text = row["per_sexo"].ToString() == "M" ? "Masculino" : "Femenino";
            ltl_fecha_nac.Text = Convert.ToDateTime(row["per_fecha_nac"]).ToString("dd/MM/yyyy");
            ltl_pais.Text = ObtenerDescripcionCatalogo("pais", row["per_procedencia"]);
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar datos personales: {ex.Message}", "danger");
        }
    }

    /// Obtiene la descripción de un catálogo por su ID.
    private string ObtenerDescripcionCatalogo(string tabla, object id)
    {
        if (id == null || id == DBNull.Value || Convert.ToInt32(id) == 0)
            return "";

        try
        {
            var catalogo = new cls_catalogo { cat_tabla = tabla };
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

    /// Carga el Nro. de Libreta Militar del funcionario.
    private void CargarLibretaMilitar(int personaId)
    {
        try
        {
            const string query = "SELECT per_serie_libreta_militar FROM tbl_persona WHERE per_id = @per_id";
            string connStr = ConfigurationManager.ConnectionStrings["CnxSigrh3"].ConnectionString;

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@per_id", personaId);
                conn.Open();

                object result = cmd.ExecuteScalar();
                if (result != null && result != DBNull.Value)
                    txt_nro_lib.Text = result.ToString();
            }
        }
        catch { }
    }

    #endregion

    #region ═══════════════ CATÁLOGOS EN CASCADA ═══════════════

    /// Carga los catálogos raíz de la Opción 1 (Departamento, Tipo Vía).
    private void CargarCatalogosOpcion1()
    {
        try
        {
            var catalogo = new cls_catalogo();

            // Departamento
            ddl_perd_departamento.Items.Clear();
            ddl_perd_departamento.Items.Add(new ListItem("", ""));

            DataSet dsDepartamentos = catalogo.ObtenerCatalogoPorTabla("departamento");
            if (dsDepartamentos != null && dsDepartamentos.Tables.Count > 0)
            {
                ddl_perd_departamento.DataSource = dsDepartamentos;
                ddl_perd_departamento.DataTextField = "cat_descripcion";
                ddl_perd_departamento.DataValueField = "cat_id";
                ddl_perd_departamento.DataBind();
            }

            // Tipo Vía
            ddl_perd_tipo_via.Items.Clear();
            ddl_perd_tipo_via.Items.Add(new ListItem("", ""));

            DataSet dsTiposVia = catalogo.ObtenerCatalogoPorTabla("tipo_via");
            if (dsTiposVia != null && dsTiposVia.Tables.Count > 0)
            {
                ddl_perd_tipo_via.DataSource = dsTiposVia;
                ddl_perd_tipo_via.DataTextField = "cat_descripcion";
                ddl_perd_tipo_via.DataValueField = "cat_id";
                ddl_perd_tipo_via.DataBind();
            }

            // Inicializar combos hijos
            LimpiarCombo(ddl_perd_provincia);
            LimpiarCombo(ddl_perd_ciudad_residencia);
            LimpiarCombo(ddl_perd_zona);
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar catálogos: {ex.Message}", "danger");
        }
    }

    /// Limpia un DropDownList y agrega el item vacío por defecto.
    private void LimpiarCombo(DropDownList combo)
    {
        combo.Items.Clear();
        combo.Items.Add(new ListItem("", ""));
    }

    #endregion

    #region ═══════════════ CASCADA GEOGRÁFICA ═══════════════

    protected void ddl_perd_departamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int idDepartamento = 0;
            int.TryParse(ddl_perd_departamento.SelectedValue, out idDepartamento);

            // Limpiar todos los combos hijos
            LimpiarCombo(ddl_perd_provincia);
            LimpiarCombo(ddl_perd_ciudad_residencia);
            LimpiarCombo(ddl_perd_zona);

            if (idDepartamento <= 0) return;

            // 1. Cargar Provincias del Departamento
            var catalogo = new cls_catalogo();
            DataSet dsProv = catalogo.ObtenerCatalogoPorTablaYSuperior("provincia", idDepartamento);

            if (dsProv == null || dsProv.Tables.Count == 0 || dsProv.Tables[0].Rows.Count == 0)
                return;

            ddl_perd_provincia.DataSource = dsProv;
            ddl_perd_provincia.DataTextField = "cat_descripcion";
            ddl_perd_provincia.DataValueField = "cat_id";
            ddl_perd_provincia.DataBind();
            ddl_perd_provincia.Items.Insert(0, new ListItem("", ""));

            // ✅ Auto-seleccionar la primera provincia
            if (ddl_perd_provincia.Items.Count > 1)
            {
                ddl_perd_provincia.SelectedIndex = 1;

                // ✅ Cargar ciudades de la primera provincia automáticamente
                CargarCiudadesPorProvincia(Convert.ToInt32(ddl_perd_provincia.SelectedValue));
            }
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar provincias: {ex.Message}", "danger");
        }
    }

    protected void ddl_perd_provincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int idProvincia = 0;
            int.TryParse(ddl_perd_provincia.SelectedValue, out idProvincia);

            // Limpiar ciudad y zona
            LimpiarCombo(ddl_perd_ciudad_residencia);
            LimpiarCombo(ddl_perd_zona);

            if (idProvincia <= 0) return;

            // ✅ Cargar ciudades y auto-seleccionar la primera
            CargarCiudadesPorProvincia(idProvincia);
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar ciudades: {ex.Message}", "danger");
        }
    }

    protected void ddl_perd_ciudad_residencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            int idCiudad = 0;
            int.TryParse(ddl_perd_ciudad_residencia.SelectedValue, out idCiudad);

            LimpiarCombo(ddl_perd_zona);

            if (idCiudad <= 0) return;

            // ✅ Cargar zonas y auto-seleccionar la primera
            CargarZonasPorCiudad(idCiudad);
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar zonas: {ex.Message}", "danger");
        }
    }

    /// Carga las ciudades de una provincia y auto-selecciona la primera.
    private void CargarCiudadesPorProvincia(int idProvincia)
    {
        if (idProvincia <= 0) return;

        var catalogo = new cls_catalogo();
        DataSet ds = catalogo.ObtenerCatalogoPorTablaYSuperior("ciudad_localidad", idProvincia);

        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return;

        ddl_perd_ciudad_residencia.DataSource = ds;
        ddl_perd_ciudad_residencia.DataTextField = "cat_descripcion";
        ddl_perd_ciudad_residencia.DataValueField = "cat_id";
        ddl_perd_ciudad_residencia.DataBind();
        ddl_perd_ciudad_residencia.Items.Insert(0, new ListItem("", ""));

        // ✅ Auto-seleccionar la primera ciudad
        if (ddl_perd_ciudad_residencia.Items.Count > 1)
        {
            ddl_perd_ciudad_residencia.SelectedIndex = 1;

            // ✅ Cargar zonas de la primera ciudad automáticamente
            CargarZonasPorCiudad(Convert.ToInt32(ddl_perd_ciudad_residencia.SelectedValue));
        }
    }

    /// Carga las zonas de una ciudad y auto-selecciona la primera.
    private void CargarZonasPorCiudad(int idCiudad)
    {
        if (idCiudad <= 0) return;

        var catalogo = new cls_catalogo();
        DataSet ds = catalogo.ObtenerCatalogoPorTablaYSuperior("zona", idCiudad);

        if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            return;

        ddl_perd_zona.DataSource = ds;
        ddl_perd_zona.DataTextField = "cat_descripcion";
        ddl_perd_zona.DataValueField = "cat_id";
        ddl_perd_zona.DataBind();
        ddl_perd_zona.Items.Insert(0, new ListItem("", ""));

        // ✅ Auto-seleccionar la primera zona
        if (ddl_perd_zona.Items.Count > 1)
        {
            ddl_perd_zona.SelectedIndex = 1;
        }
    }
    #endregion

    #region ═══════════════ NAVEGACIÓN POR PESTAÑAS ═══════════════

    protected void btnTab1_Click(object sender, EventArgs e)
    {
        ActivarPestana(btnTab1, 0);
        CargarDatosOpcion1();
    }

    protected void btnTab2_Click(object sender, EventArgs e)
    {
        ActivarPestana(btnTab2, 1);
        CargarDatosOpcion2();
    }

    protected void btnTab3_Click(object sender, EventArgs e)
    {
        ActivarPestana(btnTab3, 2);
        CargarDatosOpcion3();
    }

    protected void btnTab4_Click(object sender, EventArgs e)
    {
        ActivarPestana(btnTab4, 3);
        CargarDatosOpcion4();
    }

    /// Activa la pestaña seleccionada y su vista correspondiente.

    private void ActivarPestana(LinkButton btnActivo, int indexVista)
    {
        LinkButton[] tabs = { btnTab1, btnTab2, btnTab3, btnTab4 };

        foreach (var tab in tabs)
        {
            tab.CssClass = "nav-link";
            tab.Attributes["style"] = "color: #6c757d !important;"; // gris para inactivos
        }

        btnActivo.CssClass = "nav-link active";
        btnActivo.Attributes["style"] = "color: #007bff !important;"; // azul para el activo

        mvOpciones.ActiveViewIndex = indexVista;
    }

    #endregion

    #region ═══════════════ CARGA DE DATOS POR PESTAÑA ═══════════════

    private void CargarDatosOpcion1()
    {
        CargarDomicilioExistente();
    }

    private void CargarDatosOpcion2()
    {
        try
        {
            CargarCombosEducacionFormal();
            CargarGrillaEducacionFormal();
            LimpiarFormularioEducacion();
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar educación: {ex.Message}", "danger");
        }
    }

    private void CargarDatosOpcion3()
    {
        try
        {
            CargarComboParentesco();
            CargarComboGenero();
            CargarGrillaFamiliares();
            LimpiarFormularioFamiliar();
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar familiares: {ex.Message}", "danger");
        }
    }

    private void CargarDatosOpcion4()
    {
        try
        {
            CargarGrillaDoblePercepcion();
            LimpiarFormularioDoblePercepcion();
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar doble percepción: {ex.Message}", "danger");
        }
    }

    #endregion

    #region ═══════════════ OPCIÓN 2: EDUCACIÓN FORMAL ═══════════════

    /// Carga los combos de la Opción 2.
    private void CargarComboGradoAcademico(DropDownList ddl)
    {
        try
        {
            var grado = new cls_grado_academico();

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("", ""));

            DataSet ds = grado.ObtenerGradoAcademico();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = "ga_nombre";
                ddl.DataValueField = "ga_id";
                ddl.DataBind();

                // Insertar item vacío al inicio
                ddl.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error CargarComboGradoAcademico: {ex.Message}");
            MostrarNotificacion($"Error al cargar Nivel de Instrucción: {ex.Message}", "danger");
        }
    }
    private void CargarCombosEducacionFormal()
    {
        // ✅ Nivel de instrucción: usa sp_grado_academico (C2)
        CargarComboGradoAcademico(ddl_ef_nivel_instruccion);

        // ✅ Centro de formación: usa sp_instituciones (C2) vía cls_grado_academico
        CargarComboInstituciones(ddl_ef_centro_form, "C2");

        // ✅ Carrera/Especialidad: usa sp_carreras (C2) vía cls_grado_academico
        CargarComboCarreras(ddl_ef_carrera_especialidad);
    }

    /// Carga un combo desde el catálogo (helper genérico).
    private void CargarComboDesdeCatalogo(DropDownList ddl, string catTabla,
        string textField = "cat_descripcion", string valueField = "cat_secuencial")
    {
        try
        {
            var catalogo = new cls_catalogo { cat_tabla = catTabla, cat_id_superior = 0 };

            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("", ""));

            DataSet ds = catalogo.ObtenerTablaCombo();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = textField;
                ddl.DataValueField = valueField;
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error CargarComboDesdeCatalogo({catTabla}): {ex.Message}");
        }
    }
    /// Carga el combo de instituciones de formación.
    private void CargarComboInstituciones(DropDownList ddl, string accion)
    {
        try
        {
            var formacion = new cls_grado_academico();
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("", ""));

            DataSet ds = formacion.ComboFormacion(accion);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = "it_nombre";
                ddl.DataValueField = "it_id";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error CargarComboInstituciones({accion}): {ex.Message}");
        }
    }

    /// Carga el combo de carreras.
    private void CargarComboCarreras(DropDownList ddl)
    {
        try
        {
            var formacion = new cls_grado_academico();
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem("", ""));

            DataSet ds = formacion.ComboFormacionCarreras("C2");
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddl.DataSource = ds;
                ddl.DataTextField = "carr_nombre";
                ddl.DataValueField = "carr_id";
                ddl.DataBind();
                ddl.Items.Insert(0, new ListItem("", ""));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error CargarComboCarreras: " + ex.Message);
        }
    }

    /// Carga la grilla de educación formal.
    private void CargarGrillaEducacionFormal()
    {
        try
        {
            var formacion = new cls_kd_respuesta_combo();
            DataSet ds = formacion.ObtenerGrillaEducacionFormal(_per_id);

            cls_paginador.ConfigurarConBootstrap(gvEducacionFormalKardex, cls_paginador.TAMANIO_PAGINA_PEQUENIO);

            if (EsDataSetVacio(ds))
            {
                ViewState["EducacionFormalData"] = null;
                gvEducacionFormalKardex.DataSource = null;
                gvEducacionFormalKardex.DataBind();
                ltlInfoPaginacionEducacion.Text = "";
                return;
            }

            DataTable dt = ds.Tables[0];
            ViewState["EducacionFormalData"] = dt;
            gvEducacionFormalKardex.DataSource = dt;
            gvEducacionFormalKardex.DataBind();

            ltlInfoPaginacionEducacion.Text = cls_paginador.GenerarHtmlInfo(gvEducacionFormalKardex, dt.Rows.Count);
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar grilla: {ex.Message}", "danger");
        }
    }

    /// Limpia el formulario de educación formal.
 
    private void LimpiarFormularioEducacion()
    {
        hf_ef_id.Value = "";
        ddl_ef_nivel_instruccion.SelectedIndex = 0;
        ddl_ef_centro_form.SelectedIndex = 0;
        ddl_ef_carrera_especialidad.SelectedIndex = 0;
        txt_ef_fecha_ini.Text = "";
        txt_ef_fecha_fin.Text = "";
        txt_ef_anios_estudio.Text = "";
        txt_ef_fecha_titulo_obtenido.Text = "";
        //txt_ef_nro_titulo.Text = "";
        txt_ef_nro_titulo.Enabled = true;
        txt_ef_descripcion.Text = "";

        btn_ef_registrar.Text = "💾 REGISTRAR FORMACIÓN";
        btn_ef_registrar.CssClass = "btn btn-success px-4 rounded-pill fw-bold shadow-sm";
        btn_ef_cancelar.Visible = false;
    }

    protected void btn_ef_registrar_Click(object sender, EventArgs e)
    {
        try
        {
            ValidarFormularioEducacion();

            var formacion = new cls_kd_respuesta_combo
            {
                ef_per_id = _per_id,
                ef_nivel_instruccion = ConvertirIntSeguro(ddl_ef_nivel_instruccion.SelectedValue),
                ef_centro_form = ConvertirIntSeguro(ddl_ef_centro_form.SelectedValue),
                ef_carrera_especialidad = ConvertirIntSeguro(ddl_ef_carrera_especialidad.SelectedValue),
                ef_fecha_ini = txt_ef_fecha_ini.Text ?? "",
                ef_fecha_fin = txt_ef_fecha_fin.Text ?? "",
                ef_anios_estudio = string.IsNullOrEmpty(txt_ef_anios_estudio.Text) ? 0 : Convert.ToInt32(txt_ef_anios_estudio.Text),
                ef_titulo_obtenido = 0,
                ef_fecha_titulo_obtenido = txt_ef_fecha_titulo_obtenido.Text ?? "",
                ef_nro_titulo = txt_ef_nro_titulo.Text.Trim(),
                ef_descripcion = txt_ef_descripcion.Text.Trim(),
                ef_usuario_creacion = _per_id,
                ef_usuario_modificacion = _per_id
            };

            bool exito;
            string mensaje;

            if (!string.IsNullOrEmpty(hf_ef_id.Value))
            {
                formacion.ef_id = Convert.ToInt32(hf_ef_id.Value);
                exito = formacion.ActualizarFormacionKardex();
                mensaje = "Formación ACTUALIZADA correctamente.";
            }
            else
            {
                exito = formacion.RegistrarFormacionKardex();
                mensaje = "Formación REGISTRADA correctamente.";
            }

            if (exito)
            {
                MostrarAlerta(mensaje);
                LimpiarFormularioEducacion();
                CargarGrillaEducacionFormal();
            }
            else
            {
                throw new Exception("No se pudieron guardar los datos.");
            }
        }
        catch (ValidationException vex)
        {
            MostrarAlerta(vex.Message, "warning");
        }
        catch (Exception ex)
        {
            MostrarAlerta(ex.Message, "error");
        }
    }

    /// Valida los campos del formulario de educación.

    private void ValidarFormularioEducacion()
    {
        // 1. Nivel de instrucción obligatorio
        if (string.IsNullOrEmpty(ddl_ef_nivel_instruccion.SelectedValue))
            throw new ValidationException("Nivel de Instrucción", "Debe seleccionar un Nivel de Instrucción.");
        
        if (string.IsNullOrEmpty(ddl_ef_centro_form.SelectedValue))
            throw new ValidationException("Centro de Formación",
                "Debe seleccionar un Centro de Formación.");

        if (string.IsNullOrEmpty(ddl_ef_carrera_especialidad.SelectedValue))
            throw new ValidationException("Carrera/Especialidad",
                "Debe seleccionar una Carrera/Especialidad.");

        
        cls_validador.ValidarObligatorio(txt_ef_descripcion.Text, "Descripción Formación");
        cls_validador.ValidarLongitudMaxima(txt_ef_descripcion.Text, 250, "Descripción Formación");
        // 2. Longitudes
        //cls_validador.ValidarLongitudMaxima(txt_ef_nro_titulo.Text, 50, "Nº Título");
        if (!string.IsNullOrEmpty(txt_ef_fecha_titulo_obtenido.Text))
        {
            cls_validador.ValidarObligatorio(txt_ef_nro_titulo.Text, "Nº Título");
            cls_validador.ValidarLongitudMaxima(txt_ef_nro_titulo.Text, 50, "Nº Título");
        }
        else
        {
            // Si no hay fecha título, el Nº Título debe estar vacío
            txt_ef_nro_titulo.Text = "";
        }
        cls_validador.ValidarLongitudMaxima(txt_ef_descripcion.Text, 250, "Descripción");

        // 3. Parsear fechas (si están presentes)
        // ─── VALIDACIÓN: Fecha Inicio obligatoria ───
        cls_validador.ValidarObligatorio(txt_ef_fecha_ini.Text, "Fecha Inicio");
        cls_validador.ValidarObligatorio(txt_ef_fecha_fin.Text, "Fecha Fin");
        DateTime? fIni = null;
        DateTime? fFin = null;
        DateTime? fTit = null;

        // Fecha Inicio
        if (!string.IsNullOrEmpty(txt_ef_fecha_ini.Text))
        {
            fIni = cls_validador.ParsearFecha(txt_ef_fecha_ini.Text, "Fecha Inicio");
            cls_validador.ValidarFechaMenorHoy(fIni.Value, "Fecha Inicio", permitirHoy: true);
        }

        // Fecha Fin (opcional)
        if (!string.IsNullOrEmpty(txt_ef_fecha_fin.Text))
        {
            fFin = cls_validador.ParsearFecha(txt_ef_fecha_fin.Text, "Fecha Fin");
            cls_validador.ValidarFechaMenorHoy(fFin.Value, "Fecha Fin", permitirHoy: true);
        }

        // Fecha Título (opcional, pero si viene → Nº Título obligatorio)
        if (!string.IsNullOrEmpty(txt_ef_fecha_titulo_obtenido.Text))
        {
            fTit = cls_validador.ParsearFecha(txt_ef_fecha_titulo_obtenido.Text, "Fecha Título");
            cls_validador.ValidarFechaMenorHoy(fTit.Value, "Fecha Título", permitirHoy: true);
        }

        // ─── VALIDACIÓN: Fecha Inicio ≤ Fecha Fin ───
        if (fIni.HasValue && fFin.HasValue)
        {
            if (fIni.Value > fFin.Value)
            {
                throw new ValidationException(
                    "Fecha Inicio",
                    "La 'Fecha Inicio' no puede ser mayor que la 'Fecha Fin'.");
            }
        }

        // ─── VALIDACIÓN: Fecha Título ≥ Fecha Fin ───
        if (fTit.HasValue && fFin.HasValue)
        {
            if (fTit.Value < fFin.Value)
            {
                throw new ValidationException(
                    "Fecha Título",
                    "La 'Fecha Título' no puede ser menor que la 'Fecha Fin'.");
            }
        }

        // ─── VALIDACIÓN: Nº Título obligatorio si hay Fecha Título ───
        if (!string.IsNullOrEmpty(txt_ef_fecha_titulo_obtenido.Text))
        {
            cls_validador.ValidarObligatorio(txt_ef_nro_titulo.Text, "Nº Título");
            cls_validador.ValidarLongitudMaxima(txt_ef_nro_titulo.Text, 50, "Nº Título");
        }
        else
        {
            txt_ef_nro_titulo.Text = "";
        }
    }

    /// Valida que la Fecha Inicio ≤ Fecha Fin en Doble Percepción.
    private void ValidarFechasDoblePercepcion()
    {
        DateTime? fIni = null;
        DateTime? fFin = null;

        if (!string.IsNullOrEmpty(txt_dp_fecha_ini.Text))
            fIni = cls_validador.ParsearFecha(txt_dp_fecha_ini.Text, "Fecha Inicio");

        if (!string.IsNullOrEmpty(txt_dp_fecha_fin.Text))
            fFin = cls_validador.ParsearFecha(txt_dp_fecha_fin.Text, "Fecha Fin");

        if (fIni.HasValue && fFin.HasValue)
        {
            if (fIni.Value > fFin.Value)
            {
                throw new ValidationException(
                    "Fecha Inicio",
                    "La 'Fecha Inicio' no puede ser mayor que la 'Fecha Fin'.");
            }
        }
    }

    protected void btn_ef_cancelar_Click(object sender, EventArgs e)
    {
        LimpiarFormularioEducacion();
        MostrarNotificacion("Edición cancelada.", "info");
    }

    protected void gvEducacionFormalKardex_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Page") return;
            if (e.CommandName != "GetEdit" && e.CommandName != "GetDelete") return;

            int ef_id = ConvertirArgumentoAInt(e.CommandArgument);
            hf_ef_id.Value = ef_id.ToString();

            switch (e.CommandName)
            {
                case "GetEdit":
                    CargarFormacionParaEditar(ef_id);
                    sc = "window.scrollTo({ top: 0, behavior: 'smooth' });";
                    SetScript(sc, "");
                    break;

                case "GetDelete":
                    ltlFormacionEliminar.Text = ObtenerNombreFormacionPorId(ef_id);
                    sc = "$('#modalEliminarEducacionKardex').modal('show');";
                    SetScript(sc, "");
                    break;
            }
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error: {ex.Message}", "danger");
        }
    }

    private string ObtenerNombreFormacionPorId(int ef_id)
    {
        try
        {
            DataTable dt = ViewState["EducacionFormalData"] as DataTable;
            if (dt != null)
            {
                DataRow[] rows = dt.Select($"ef_id = {ef_id}");
                if (rows.Length > 0)
                {
                    string nivel = rows[0]["nivel_instruccion"] != DBNull.Value ? rows[0]["nivel_instruccion"].ToString() : "";
                    string carrera = rows[0]["carrera_especialidad_nombre"] != DBNull.Value ? rows[0]["carrera_especialidad_nombre"].ToString() : "";
                    return $"{nivel} - {carrera}".Trim(' ', '-');
                }
            }
        }
        catch { }
        return "";
    }

    private void CargarFormacionParaEditar(int ef_id)
    {
        try
        {
            var formacion = new cls_kd_respuesta_combo();
            DataSet ds = formacion.ObtenerFormacionXKardex(ef_id, _per_id);

            if (EsDataSetVacio(ds))
                throw new Exception("No se encontró la formación.");

            DataRow row = ds.Tables[0].Rows[0];
            hf_ef_id.Value = ef_id.ToString();

            SetComboValue(ddl_ef_nivel_instruccion, ObtenerValorSeguro(row, "ef_nivel_instruccion"));
            SetComboValue(ddl_ef_centro_form, ObtenerValorSeguro(row, "ef_centro_form"));
            SetComboValue(ddl_ef_carrera_especialidad, ObtenerValorSeguro(row, "ef_carrera_especialidad"));

            txt_ef_nro_titulo.Text = ObtenerValorSeguro(row, "ef_nro_titulo");
            txt_ef_descripcion.Text = ObtenerValorSeguro(row, "ef_descripcion");
            txt_ef_anios_estudio.Text = ObtenerValorSeguro(row, "ef_anios_estudio");

            txt_ef_fecha_ini.Text = ConvertirFechaParaInput(ObtenerValorSeguro(row, "ef_fecha_ini"));
            txt_ef_fecha_fin.Text = ConvertirFechaParaInput(ObtenerValorSeguro(row, "ef_fecha_fin"));
            //txt_ef_fecha_titulo_obtenido.Text = ConvertirFechaParaInput(ObtenerValorSeguro(row, "ef_fecha_titulo_obtenido"));
            ScriptManager.RegisterStartupScript(this, GetType(), "toggleNroTitulo_" + Guid.NewGuid(),
    "setTimeout(function(){ toggleNroTitulo(document.getElementById('" + txt_ef_fecha_titulo_obtenido.ClientID + "')); }, 200);",
    true);

            btn_ef_registrar.Text = "💾 ACTUALIZAR FORMACIÓN";
            btn_ef_registrar.CssClass = "btn btn-warning px-4 rounded-pill fw-bold shadow-sm";
            btn_ef_cancelar.Visible = true;
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar: {ex.Message}", "danger");
        }
    }

    private int ConvertirIntSeguro(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor)) return 0;

        int numero;
        return int.TryParse(valor.Trim(), out numero) ? numero : 0;
    }
    protected void btnConfirmarEliminarEducacion_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hf_ef_id.Value))
                throw new Exception("No se pudo identificar la formación a eliminar.");

            int ef_id = Convert.ToInt32(hf_ef_id.Value);
            var formacion = new cls_kd_respuesta_combo();
            bool exito = formacion.EliminarFormacionKardex(ef_id, _per_id);

            if (exito)
            {
                OcultarModalYCerrar("modalEliminarEducacionKardex");
                MostrarAlerta("La formación fue eliminada.");

                hf_ef_id.Value = "";
                ltlFormacionEliminar.Text = "";
                LimpiarFormularioEducacion();
                CargarGrillaEducacionFormal();
                cls_paginador.AjustarIndicePagina(gvEducacionFormalKardex);
            }
            else
            {
                throw new Exception("No se pudo eliminar la formación.");
            }
        }
        catch (Exception ex)
        {
            OcultarModalYCerrar("modalEliminarEducacionKardex");
            MostrarAlerta(ex.Message, "error");
        }
    }

    protected void gvEducacionFormalKardex_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PaginarGrilla(gvEducacionFormalKardex, "EducacionFormalData", e, ltlInfoPaginacionEducacion);
    }

    #endregion

    #region ═══════════════ OPCIÓN 3: DATOS FAMILIARES ═══════════════

    private void CargarComboParentesco()
    {
        try
        {
            var catalogo = new cls_catalogo { cat_tabla = "parentesco", cat_id_superior = 0 };

            ddl_pf_tipo_parentesco.Items.Clear();
            ddl_pf_tipo_parentesco.Items.Add(new ListItem("", ""));

            DataSet ds = catalogo.ObtenerTablaCombo();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddl_pf_tipo_parentesco.DataSource = ds;
                ddl_pf_tipo_parentesco.DataTextField = "cat_descripcion";
                ddl_pf_tipo_parentesco.DataValueField = "cat_secuencial";
                ddl_pf_tipo_parentesco.DataBind();
                ddl_pf_tipo_parentesco.Items.Insert(0, new ListItem("", ""));
            }

            ddl_pf_tipo_parentesco.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar parentescos: {ex.Message}", "danger");
        }
    }

    private void CargarComboGenero()
    {
        try
        {
            var catalogo = new cls_catalogo { cat_tabla = "genero", cat_id_superior = 0 };
            DataSet ds = catalogo.ObtenerTablaCombo();

            ddl_pf_sexo.Items.Clear();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ddl_pf_sexo.DataSource = ds.Tables[0];
                ddl_pf_sexo.DataTextField = "cat_descripcion";
                ddl_pf_sexo.DataValueField = "cat_abreviacion";
                ddl_pf_sexo.DataBind();
            }

            ddl_pf_sexo.Items.Insert(0, new ListItem("", ""));
            ddl_pf_sexo.SelectedIndex = 0;
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar géneros: {ex.Message}", "danger");
        }
    }

    private void CargarGrillaFamiliares()
    {
        try
        {
            var familiar = new cls_persona_familiares();
            DataSet ds = familiar.ObtenerGrillaFamiliaresKardex(_per_id);

            cls_paginador.ConfigurarConBootstrap(gvFamiliaresKardex, cls_paginador.TAMANIO_PAGINA_PEQUENIO);

            if (EsDataSetVacio(ds))
            {
                ViewState["FamiliaresData"] = null;
                gvFamiliaresKardex.DataSource = null;
                gvFamiliaresKardex.DataBind();
                ltlInfoPaginacionFamiliares.Text = "";
                return;
            }

            DataTable dt = ds.Tables[0];
            AgregarColumnasCalculadasFamiliares(dt);

            ViewState["FamiliaresData"] = dt;
            gvFamiliaresKardex.DataSource = dt;
            gvFamiliaresKardex.DataBind();

            ltlInfoPaginacionFamiliares.Text = cls_paginador.GenerarHtmlInfo(gvFamiliaresKardex, dt.Rows.Count);
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar grilla: {ex.Message}", "danger");
        }
    }

    private void AgregarColumnasCalculadasFamiliares(DataTable dt)
    {
        if (!dt.Columns.Contains("nombre_completo"))
            dt.Columns.Add("nombre_completo", typeof(string));

        if (!dt.Columns.Contains("pf_fecha_nac_formato"))
            dt.Columns.Add("pf_fecha_nac_formato", typeof(string));

        foreach (DataRow row in dt.Rows)
        {
            string paterno = row["pf_paterno"] != DBNull.Value ? row["pf_paterno"].ToString() : "";
            string materno = row["pf_materno"] != DBNull.Value ? row["pf_materno"].ToString() : "";
            string nombres = row["pf_nombres"] != DBNull.Value ? row["pf_nombres"].ToString() : "";
            string esposo = row["pf_ap_esposo"] != DBNull.Value ? row["pf_ap_esposo"].ToString() : "";

            row["nombre_completo"] = $"{paterno} {materno} {nombres} {esposo}".Trim().Replace("  ", " ");

            if (row["pf_fecha_nac"] != DBNull.Value)
            {
                DateTime fNac;
                row["pf_fecha_nac_formato"] = DateTime.TryParse(row["pf_fecha_nac"].ToString(), out fNac)
                    ? fNac.ToString("dd/MM/yyyy")
                    : row["pf_fecha_nac"].ToString();
            }
            else
            {
                row["pf_fecha_nac_formato"] = "";
            }
        }
    }

    private void LimpiarFormularioFamiliar()
    {
        hf_pf_id.Value = "";
        txt_pf_paterno.Text = "";
        txt_pf_materno.Text = "";
        txt_pf_nombres.Text = "";
        txt_pf_ap_esposo.Text = "";
        txt_pf_fecha_nac.Text = "";
        txt_pf_ci.Text = "";

        if (ddl_pf_tipo_parentesco.Items.Count > 0)
            ddl_pf_tipo_parentesco.SelectedIndex = 0;

        if (ddl_pf_sexo.Items.Count > 0)
            ddl_pf_sexo.SelectedIndex = 0;

        btn_pf_registrar.Text = "💾 REGISTRAR FAMILIAR";
        btn_pf_registrar.CssClass = "btn btn-success px-4 rounded-pill fw-bold shadow-sm";
        btn_pf_registrar.Visible = true;
        btn_pf_cancelar.Visible = false;
    }

    protected void btn_pf_registrar_Click(object sender, EventArgs e)
    {
        try
        {
            ValidarFormularioFamiliar();

            var familiar = new cls_persona_familiares
            {
                pf_per_id = _per_id,
                pf_tipo_parentesco = ddl_pf_tipo_parentesco.SelectedValue,
                pf_paterno = txt_pf_paterno.Text.Trim().ToUpper(),
                pf_materno = txt_pf_materno.Text.Trim().ToUpper(),
                pf_nombres = txt_pf_nombres.Text.Trim().ToUpper(),
                pf_ap_esposo = txt_pf_ap_esposo.Text.Trim().ToUpper(),
                pf_fecha_nac = txt_pf_fecha_nac.Text ?? "",
                pf_estado = "V",
                pf_estado_vivo = "V",
                pf_sexo = ddl_pf_sexo.SelectedValue,
                pf_ci = txt_pf_ci.Text.Trim(),
                pf_usuario_creacion = _per_id,
                pf_usuario_modificacion = _per_id
            };

            bool exito;
            string mensaje;

            if (!string.IsNullOrEmpty(hf_pf_id.Value))
            {
                familiar.pf_id = Convert.ToInt32(hf_pf_id.Value);
                exito = familiar.ActualizarFamiliarKardex();
                mensaje = "Datos del familiar actualizados correctamente.";
            }
            else
            {
                exito = familiar.AdicionarFamiliarKardex();
                mensaje = "Familiar registrado correctamente.";
            }

            if (exito)
            {
                MostrarAlerta(mensaje);
                LimpiarFormularioFamiliar();
                CargarGrillaFamiliares();
            }
            else
            {
                throw new Exception("No se pudo completar la transacción.");
            }
        }
        catch (ValidationException vex)
        {
            MostrarAlerta(vex.Message, "warning");
        }
        catch (Exception ex)
        {
            MostrarAlerta(ex.Message, "error");
        }
    }

    private void ValidarFormularioFamiliar()
    {
        cls_validador.ValidarObligatorio(txt_pf_paterno.Text, "Apellido Paterno");
        cls_validador.ValidarObligatorio(txt_pf_materno.Text, "Apellido Materno");
        cls_validador.ValidarObligatorio(txt_pf_nombres.Text, "Nombres");

        cls_validador.ValidarLongitudMaxima(txt_pf_paterno.Text, 100, "Apellido Paterno");
        cls_validador.ValidarLongitudMaxima(txt_pf_materno.Text, 100, "Apellido Materno");
        cls_validador.ValidarLongitudMaxima(txt_pf_nombres.Text, 100, "Nombres");

        if (string.IsNullOrEmpty(ddl_pf_tipo_parentesco.SelectedValue))
            throw new ValidationException("Tipo de Parentesco", "Debe seleccionar un Tipo de Parentesco.");

        cls_validador.ValidarCI(txt_pf_ci.Text.Trim(), obligatorio: false, minLength: 5, maxLength: 10);

        if (!string.IsNullOrEmpty(txt_pf_fecha_nac.Text))
        {
            DateTime fechaNac = cls_validador.ParsearFecha(txt_pf_fecha_nac.Text, "Fecha de Nacimiento");
            cls_validador.ValidarFechaMenorHoy(fechaNac, "Fecha de Nacimiento");
            cls_validador.ValidarFechaRazonable(fechaNac, 120, "Fecha de Nacimiento");
        }
    }

    protected void btn_pf_cancelar_Click(object sender, EventArgs e)
    {
        LimpiarFormularioFamiliar();
        MostrarNotificacion("Edición cancelada.", "info");
    }

    protected void gvFamiliaresKardex_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Page") return;
            if (e.CommandName != "GetEdit" && e.CommandName != "GetDelete") return;

            int pf_id = ConvertirArgumentoAInt(e.CommandArgument);
            hf_pf_id.Value = pf_id.ToString();

            switch (e.CommandName)
            {
                case "GetEdit":
                    CargarFamiliarParaEditar(pf_id);
                    sc = "window.scrollTo({ top: 0, behavior: 'smooth' });";
                    SetScript(sc, "");
                    break;

                case "GetDelete":
                    ltlFamiliarEliminar.Text = ObtenerNombreFamiliarPorId(pf_id);
                    sc = "$('#modalEliminarFamiliarKardex').modal('show');";
                    SetScript(sc, "");
                    break;
            }
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error: {ex.Message}", "danger");
        }
    }

    private string ObtenerNombreFamiliarPorId(int pf_id)
    {
        try
        {
            DataTable dt = ViewState["FamiliaresData"] as DataTable;
            if (dt != null)
            {
                DataRow[] rows = dt.Select($"pf_id = {pf_id}");
                if (rows.Length > 0)
                    return rows[0]["nombre_completo"].ToString();
            }
        }
        catch { }
        return "";
    }

    private void CargarFamiliarParaEditar(int pf_id)
    {
        try
        {
            var familiar = new cls_persona_familiares();
            DataSet ds = familiar.ObtenerFamiliarXKardex(pf_id);

            if (EsDataSetVacio(ds))
                throw new Exception("No se encontró el familiar.");

            DataRow row = ds.Tables[0].Rows[0];
            hf_pf_id.Value = row["pf_id"].ToString();
            txt_pf_paterno.Text = ObtenerValorSeguro(row, "pf_paterno");
            txt_pf_materno.Text = ObtenerValorSeguro(row, "pf_materno");
            txt_pf_nombres.Text = ObtenerValorSeguro(row, "pf_nombres");
            txt_pf_ap_esposo.Text = ObtenerValorSeguro(row, "pf_ap_esposo");

            string fecha = ObtenerValorSeguro(row, "pf_fecha_nac");
            if (!string.IsNullOrEmpty(fecha))
            {
                DateTime f;
                txt_pf_fecha_nac.Text = DateTime.TryParse(fecha, out f) ? f.ToString("yyyy-MM-dd") : "";
            }

            SetComboValue(ddl_pf_tipo_parentesco, ObtenerValorSeguro(row, "pf_tipo_parentesco"));

            btn_pf_registrar.Text = "💾 ACTUALIZAR FAMILIAR";
            btn_pf_registrar.CssClass = "btn btn-warning px-4 rounded-pill fw-bold shadow-sm";
            btn_pf_cancelar.Visible = true;
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar: {ex.Message}", "danger");
        }
    }

    protected void btnConfirmarEliminarFamiliar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hf_pf_id.Value))
                throw new Exception("No se pudo identificar el familiar a eliminar.");

            int pf_id = Convert.ToInt32(hf_pf_id.Value);
            var familiar = new cls_persona_familiares();
            bool exito = familiar.EliminarFamiliarKardex(pf_id, _per_id);

            if (exito)
            {
                OcultarModalYCerrar("modalEliminarFamiliarKardex");
                MostrarAlerta("El familiar fue eliminado correctamente.");

                hf_pf_id.Value = "";
                ltlFamiliarEliminar.Text = "";
                LimpiarFormularioFamiliar();
                CargarGrillaFamiliares();
                cls_paginador.AjustarIndicePagina(gvFamiliaresKardex);
            }
            else
            {
                throw new Exception("No se pudo eliminar el familiar.");
            }
        }
        catch (Exception ex)
        {
            OcultarModalYCerrar("modalEliminarFamiliarKardex");
            MostrarAlerta(ex.Message, "error");
        }
    }

    protected void gvFamiliaresKardex_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PaginarGrilla(gvFamiliaresKardex, "FamiliaresData", e, ltlInfoPaginacionFamiliares);
    }

    #endregion

    #region ═══════════════ OPCIÓN 4: DOBLE PERCEPCIÓN ═══════════════

    private void CargarGrillaDoblePercepcion()
    {
        try
        {
            var dp = new cls_doblepercepcion();
            DataSet ds = dp.ObtenerGrillaDoblePercepcion(_per_id);

            cls_paginador.ConfigurarConBootstrap(gvDoblePercepcion, cls_paginador.TAMANIO_PAGINA_PEQUENIO);

            if (EsDataSetVacio(ds))
            {
                ViewState["DoblePercepcionData"] = null;
                gvDoblePercepcion.DataSource = null;
                gvDoblePercepcion.DataBind();
                ltlInfoPaginacionDoblePercepcion.Text = "";
                return;
            }

            DataTable dt = ds.Tables[0];
            AgregarColumnaDocenciaLiteral(dt);

            ViewState["DoblePercepcionData"] = dt;
            gvDoblePercepcion.DataSource = dt;
            gvDoblePercepcion.DataBind();

            ltlInfoPaginacionDoblePercepcion.Text = cls_paginador.GenerarHtmlInfo(gvDoblePercepcion, dt.Rows.Count);
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar grilla: {ex.Message}", "danger");
        }
    }

    private void AgregarColumnaDocenciaLiteral(DataTable dt)
    {
        if (!dt.Columns.Contains("dp_docente_lit"))
            dt.Columns.Add("dp_docente_lit", typeof(string));

        foreach (DataRow row in dt.Rows)
        {
            bool docente = row["dp_docente"] != DBNull.Value && Convert.ToBoolean(row["dp_docente"]);
            row["dp_docente_lit"] = docente ? "Sí" : "No";
        }
    }

    protected void ddl_dp_tiene_docencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            string valor = ddl_dp_tiene_docencia.SelectedValue;

            if (valor == "1")
            {
                pnlDatosDocencia.Visible = true;
                btn_dp_registrar.Text = "💾 REGISTRAR DECLARACIÓN";
            }
            else
            {
                pnlDatosDocencia.Visible = false;
                LimpiarCamposDocencia();
            }
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error: {ex.Message}", "danger");
        }
    }

    private void LimpiarCamposDocencia()
    {
        if (ddl_dp_tipo_jornada.Items.Count > 0)
            ddl_dp_tipo_jornada.SelectedIndex = 0;

        txt_dp_universidad.Text = "";
        txt_dp_total_ganado_mes.Text = "";
        txt_dp_aguinaldo.Text = "";
        txt_dp_otros_ingresos.Text = "";
        txt_dp_horario.Text = "";
        txt_dp_total_horas.Text = "";
        txt_dp_fecha_ini.Text = "";
        txt_dp_fecha_fin.Text = "";
        txt_dp_numero_materias.Text = "";
        txt_dp_materias.Text = "";
    }

    private void LimpiarFormularioDoblePercepcion()
    {
        hf_dp_id.Value = "";
        ddl_dp_tiene_docencia.SelectedIndex = 0;
        pnlDatosDocencia.Visible = false;
        LimpiarCamposDocencia();

        btn_dp_registrar.Text = "💾 REGISTRAR DECLARACIÓN";
        btn_dp_registrar.CssClass = "btn btn-success px-4 rounded-pill fw-bold shadow-sm";
        btn_dp_cancelar.Visible = false;
    }

    protected void btn_dp_registrar_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(ddl_dp_tiene_docencia.SelectedValue))
                throw new ValidationException("Docencia", "Debe seleccionar si tiene docencia o no.");

            bool tieneDocencia = ddl_dp_tiene_docencia.SelectedValue == "1";

            if (tieneDocencia)
            {
                // ─── Universidad ───
                if (string.IsNullOrWhiteSpace(txt_dp_universidad.Text))
                    throw new ValidationException("Universidad", "Debe ingresar el nombre de la Universidad.");
                cls_validador.ValidarLongitudMaxima(txt_dp_universidad.Text, 200, "Universidad");

                // ─── Total Ganado Mes (obligatorio) ───
                cls_validador.ValidarObligatorio(txt_dp_total_ganado_mes.Text, "Total Ganado Mes");
                ParsearDecimal2(txt_dp_total_ganado_mes.Text, "Total Ganado Mes"); // valida que sea número válido

                // ─── Total Horas (obligatorio) ───
                cls_validador.ValidarObligatorio(txt_dp_total_horas.Text, "Total Horas");
                ParsearEntero(txt_dp_total_horas.Text, "Total Horas"); // valida que sea entero válido

                // ─── Fecha Inicio (obligatorio) ───
                cls_validador.ValidarObligatorio(txt_dp_fecha_ini.Text, "Fecha Inicio");

                // ─── Turno/Jornada (obligatorio) ───
                if (string.IsNullOrEmpty(ddl_dp_tipo_jornada.SelectedValue))
                    throw new ValidationException("Tipo Jornada", "Debe seleccionar un Tipo de Jornada.");

                // ─── Horario (obligatorio) ───
                cls_validador.ValidarObligatorio(txt_dp_horario.Text, "Horario");
                cls_validador.ValidarLongitudMaxima(txt_dp_horario.Text, 500, "Horario");
                ValidarFechasDoblePercepcion();
            }

            int? djId = Session["dj_id"] != null ? Convert.ToInt32(Session["dj_id"]) : (int?)null;

            var dp = new cls_doblepercepcion
            {
                dp_per_id = _per_id,
                dp_docente = tieneDocencia,
                dp_dj_id = djId,
                dp_usuario_creacion = _per_id,
                dp_usuario_modificacion = _per_id
            };

            if (tieneDocencia)
            {
                dp.dp_universidad = txt_dp_universidad.Text.Trim().ToUpper();
                dp.dp_total_ganado_mes = ParsearDecimal2(txt_dp_total_ganado_mes.Text, "Total Ganado Mes");
                dp.dp_aguinaldo = ParsearDecimal2(txt_dp_aguinaldo.Text, "Aguinaldo");
                dp.dp_otros_ingresos = ParsearDecimal2(txt_dp_otros_ingresos.Text, "Otros Ingresos");
                dp.dp_total_horas = ParsearEntero(txt_dp_total_horas.Text, "Total Horas");
                dp.dp_numero_materias = ParsearEntero(txt_dp_numero_materias.Text, "Número de Materias");
                dp.dp_horario = txt_dp_horario.Text.Trim();
                dp.dp_fecha_ini = ParsearFechaNullable(txt_dp_fecha_ini.Text);
                dp.dp_fecha_fin = ParsearFechaNullable(txt_dp_fecha_fin.Text);
                dp.dp_materias = txt_dp_materias.Text.Trim();
                dp.dp_tipo_jornada = ParsearEntero(ddl_dp_tipo_jornada.SelectedValue, "Tipo Jornada");
            }

            bool exito;
            string mensaje;

            if (!string.IsNullOrEmpty(hf_dp_id.Value))
            {
                dp.dp_id = Convert.ToInt32(hf_dp_id.Value);
                exito = dp.Actualizar();
                mensaje = "Declaración ACTUALIZADA correctamente.";
            }
            else
            {
                exito = dp.Adicionar();
                mensaje = "Declaración REGISTRADA correctamente.";
            }

            if (exito)
            {
                MostrarAlerta(mensaje);
                LimpiarFormularioDoblePercepcion();
                CargarGrillaDoblePercepcion();
            }
            else
            {
                throw new Exception("No se pudieron guardar los datos.");
            }
        }
        catch (ValidationException vex)
        {
            MostrarAlerta(vex.Message, "warning");
        }
        catch (Exception ex)
        {
            MostrarAlerta(ex.Message, "error");
        }
    }

    protected void btn_dp_cancelar_Click(object sender, EventArgs e)
    {
        LimpiarFormularioDoblePercepcion();
        MostrarNotificacion("Edición cancelada.", "info");
    }

    protected void gvDoblePercepcion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "Page") return;
            if (e.CommandName != "GetEdit" && e.CommandName != "GetDelete") return;

            int dp_id = ConvertirArgumentoAInt(e.CommandArgument);
            hf_dp_id.Value = dp_id.ToString();

            switch (e.CommandName)
            {
                case "GetEdit":
                    CargarDoblePercepcionParaEditar(dp_id);
                    sc = "window.scrollTo({ top: 0, behavior: 'smooth' });";
                    SetScript(sc, "");
                    break;

                case "GetDelete":
                    ltlDoblePercepcionEliminar.Text = ObtenerNombreDoblePercepcionPorId(dp_id);
                    sc = "$('#modalEliminarDoblePercepcion').modal('show');";
                    SetScript(sc, "");
                    break;
            }
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error: {ex.Message}", "danger");
        }
    }

    private string ObtenerNombreDoblePercepcionPorId(int dp_id)
    {
        try
        {
            DataTable dt = ViewState["DoblePercepcionData"] as DataTable;
            if (dt != null)
            {
                DataRow[] rows = dt.Select($"dp_id = {dp_id}");
                if (rows.Length > 0)
                {
                    string docente = rows[0]["dp_docente_lit"].ToString();
                    string uni = rows[0]["dp_universidad"] != DBNull.Value ? rows[0]["dp_universidad"].ToString() : "";
                    return $"Docencia: {docente} - {uni}".Trim();
                }
            }
        }
        catch { }
        return "";
    }

    private void CargarDoblePercepcionParaEditar(int dp_id)
    {
        try
        {
            var dp = new cls_doblepercepcion();
            DataSet ds = dp.ObtenerDoblePercepcionX(dp_id);

            if (EsDataSetVacio(ds))
                throw new Exception("No se encontró la declaración.");

            DataRow row = ds.Tables[0].Rows[0];
            hf_dp_id.Value = dp_id.ToString();

            bool tieneDocencia = row["dp_docente"] != DBNull.Value && Convert.ToBoolean(row["dp_docente"]);
            ddl_dp_tiene_docencia.SelectedValue = tieneDocencia ? "1" : "0";

            if (tieneDocencia)
            {
                pnlDatosDocencia.Visible = true;

                txt_dp_universidad.Text = ObtenerValorSeguro(row, "dp_universidad");
                txt_dp_total_ganado_mes.Text = FormatearDecimal2(ObtenerValorSeguro(row, "dp_total_ganado_mes"));
                txt_dp_aguinaldo.Text = FormatearDecimal2(ObtenerValorSeguro(row, "dp_aguinaldo"));
                txt_dp_otros_ingresos.Text = FormatearDecimal2(ObtenerValorSeguro(row, "dp_otros_ingresos"));
                txt_dp_horario.Text = ObtenerValorSeguro(row, "dp_horario");
                txt_dp_total_horas.Text = ObtenerValorSeguro(row, "dp_total_horas");
                txt_dp_fecha_ini.Text = ObtenerValorSeguro(row, "dp_fecha_ini");
                txt_dp_fecha_fin.Text = ObtenerValorSeguro(row, "dp_fecha_fin");
                txt_dp_numero_materias.Text = ObtenerValorSeguro(row, "dp_numero_materias");
                txt_dp_materias.Text = ObtenerValorSeguro(row, "dp_materias");

                SetComboValue(ddl_dp_tipo_jornada, ObtenerValorSeguro(row, "dp_tipo_jornada"));
            }
            else
            {
                pnlDatosDocencia.Visible = false;
                LimpiarCamposDocencia();
            }

            btn_dp_registrar.Text = "💾 ACTUALIZAR DECLARACIÓN";
            btn_dp_registrar.CssClass = "btn btn-warning px-4 rounded-pill fw-bold shadow-sm";
            btn_dp_cancelar.Visible = true;
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al cargar: {ex.Message}", "danger");
        }
    }

    protected void btnConfirmarEliminarDoblePercepcion_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(hf_dp_id.Value))
                throw new Exception("No se pudo identificar la declaración a eliminar.");

            int dp_id = Convert.ToInt32(hf_dp_id.Value);

            var dp = new cls_doblepercepcion
            {
                dp_id = dp_id,
                dp_usuario_modificacion = _per_id
            };

            bool exito = dp.Eliminar(_per_id);

            if (exito)
            {
                OcultarModalYCerrar("modalEliminarDoblePercepcion");
                MostrarAlerta("La declaración fue eliminada.");

                hf_dp_id.Value = "";
                ltlDoblePercepcionEliminar.Text = "";
                LimpiarFormularioDoblePercepcion();
                CargarGrillaDoblePercepcion();
                cls_paginador.AjustarIndicePagina(gvDoblePercepcion);
            }
            else
            {
                throw new Exception("No se pudo eliminar la declaración.");
            }
        }
        catch (Exception ex)
        {
            OcultarModalYCerrar("modalEliminarDoblePercepcion");
            MostrarAlerta(ex.Message, "error");
        }
    }

    protected void gvDoblePercepcion_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        PaginarGrilla(gvDoblePercepcion, "DoblePercepcionData", e, ltlInfoPaginacionDoblePercepcion);
    }

    #endregion

    #region ═══════════════ PRECARGA DE DOMICILIO ═══════════════

    private void CargarDomicilioExistente()
    {
        try
        {
            var domicilio = new cls_persona_domicilio();
            DataSet ds = domicilio.ObtenerDomicilioVigentePorPerId(_per_id);

            if (EsDataSetVacio(ds))
                return;

            DataRow row = ds.Tables[0].Rows[0];

            int idCiudad = row["perd_ciudad_residencia"] != DBNull.Value ? Convert.ToInt32(row["perd_ciudad_residencia"]) : 0;
            int idZona = row["perd_zona"] != DBNull.Value ? Convert.ToInt32(row["perd_zona"]) : 0;
            int idTipoVia = row["perd_tipo_via"] != DBNull.Value ? Convert.ToInt32(row["perd_tipo_via"]) : 0;

            // Cascada inversa
            if (idCiudad > 0)
            {
                int idProvincia = ObtenerCatIdSuperior("ciudad_localidad", idCiudad);
                int idDepartamento = idProvincia > 0 ? ObtenerCatIdSuperior("provincia", idProvincia) : 0;

                PreCargarCascada(idDepartamento, idProvincia, idCiudad, idZona);
            }

            if (idTipoVia > 0)
                ddl_perd_tipo_via.SelectedValue = idTipoVia.ToString();

            // TextBoxes
            txt_nombre_via.Text = ObtenerValorSeguro(row, "perd_descripcion_via");
            txt_numero_casa.Text = ObtenerValorSeguro(row, "perd_numero");
            txt_edificio.Text = ObtenerValorSeguro(row, "perd_edificio");
            txt_bloque.Text = ObtenerValorSeguro(row, "perd_bloque");
            txt_piso.Text = ObtenerValorSeguro(row, "perd_piso");
            txt_departamento.Text = ObtenerValorSeguro(row, "perd_dpto");
            txt_telefono.Text = ObtenerValorSeguro(row, "perd_telefono");
            txt_celular.Text = ObtenerValorSeguro(row, "perd_celular");
            txt_email_personal.Text = ObtenerValorSeguro(row, "perd_email_personal");
            txt_email_trabajo.Text = ObtenerValorSeguro(row, "perd_email_trabajo");
            txt_en_caso_emer.Text = ObtenerValorSeguro(row, "perd_fam_emergencia");
            txt_direccion_emer.Text = ObtenerValorSeguro(row, "perd_dir_emergencia");
            txt_telf_emer.Text = ObtenerValorSeguro(row, "perd_tel_emergencia");

            hf_perd_id.Value = row["perd_id"].ToString();
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al precargar domicilio: {ex.Message}", "danger");
        }
    }


    /// Precarga la cascada Departamento → Provincia → Ciudad → Zona.

    private void PreCargarCascada(int idDepartamento, int idProvincia, int idCiudad, int idZona)
    {
        var cat = new cls_catalogo();

        if (idDepartamento > 0)
            ddl_perd_departamento.SelectedValue = idDepartamento.ToString();

        if (idDepartamento > 0)
        {
            DataSet dsProv = cat.ObtenerCatalogoPorTablaYSuperior("provincia", idDepartamento);
            if (dsProv != null && dsProv.Tables.Count > 0)
            {
                ddl_perd_provincia.DataSource = dsProv;
                ddl_perd_provincia.DataTextField = "cat_descripcion";
                ddl_perd_provincia.DataValueField = "cat_id";
                ddl_perd_provincia.DataBind();
                ddl_perd_provincia.Items.Insert(0, new ListItem("", ""));

                // ✅ Seleccionar la provincia guardada
                if (idProvincia > 0)
                    ddl_perd_provincia.SelectedValue = idProvincia.ToString();
            }
        }

        if (idProvincia > 0)
        {
            DataSet dsCiud = cat.ObtenerCatalogoPorTablaYSuperior("ciudad_localidad", idProvincia);
            if (dsCiud != null && dsCiud.Tables.Count > 0)
            {
                ddl_perd_ciudad_residencia.DataSource = dsCiud;
                ddl_perd_ciudad_residencia.DataTextField = "cat_descripcion";
                ddl_perd_ciudad_residencia.DataValueField = "cat_id";
                ddl_perd_ciudad_residencia.DataBind();
                ddl_perd_ciudad_residencia.Items.Insert(0, new ListItem("", ""));

                // ✅ Seleccionar la ciudad guardada
                if (idCiudad > 0)
                    ddl_perd_ciudad_residencia.SelectedValue = idCiudad.ToString();
            }
        }

        if (idCiudad > 0)
        {
            DataSet dsZonas = cat.ObtenerCatalogoPorTablaYSuperior("zona", idCiudad);
            if (dsZonas != null && dsZonas.Tables.Count > 0)
            {
                ddl_perd_zona.DataSource = dsZonas;
                ddl_perd_zona.DataTextField = "cat_descripcion";
                ddl_perd_zona.DataValueField = "cat_id";
                ddl_perd_zona.DataBind();
                ddl_perd_zona.Items.Insert(0, new ListItem("", ""));

                // ✅ Seleccionar la zona guardada
                if (idZona > 0)
                    ddl_perd_zona.SelectedValue = idZona.ToString();
            }
        }
    }

    private int ObtenerCatIdSuperior(string catTabla, int catId)
    {
        try
        {
            const string query = @"
                SELECT cat_id_superior 
                FROM General.dbo.tbl_catalogo 
                WHERE cat_tabla = @cat_tabla AND cat_id = @cat_id";

            string connStr = ConfigurationManager.ConnectionStrings["CnxGeneral"].ConnectionString;

            using (var conn = new SqlConnection(connStr))
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@cat_tabla", catTabla);
                cmd.Parameters.AddWithValue("@cat_id", catId);

                conn.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                    return Convert.ToInt32(result);
            }
        }
        catch { }
        return 0;
    }

    #endregion

    #region ═══════════════ BOTONES FINALIZAR ═══════════════

    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        try
        {
            Control btn = (Control)sender;
            string idBoton = btn.ID;

            //System.Diagnostics.Debug.WriteLine($"[DDJJ] btnFinalizar_Click ejecutado. ID = {btn.ID}");
           // MostrarNotificacion($"Botón detectado: {btn.ID}", "info");
            switch (btn.ID)
            {
                case "btnFinalizar1":
                    GuardarOpcion1();
                    break;

                case "btnFinalizar2":
                    GuardarOpcion2();
                    MostrarNotificacion("Opción 2 guardada correctamente", "success");
                    break;

                case "btnFinalizar3":
                    GuardarOpcion3();
                    MostrarNotificacion("Opción 3 guardada correctamente", "success");
                    break;

                case "btnFinalizar4_1":
                    GuardarOpcion4Parcial();
                    MostrarNotificacion("Opción 4 guardada parcialmente", "info");
                    break;

                case "btnFinalizar4_2":
                    FinalizarDeclaracionCompleta();
                    break;

                default:
                    // 🔍 LOG TEMPORAL
                    MostrarNotificacion($"ID no reconocido: {btn.ID}", "warning");
                    break;
            }
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error: {ex.Message}", "danger");
        }
    }

    /// Guarda los datos de la Opción 1 (Domicilio).
    /// Si ya existe → ACTUALIZA, si no → INSERTA.

    private void GuardarOpcion1()
    {
        try
        {
            ValidarDomicilio();

            var domicilio = new cls_persona_domicilio();
            DataSet dsExistente = domicilio.ObtenerDomicilioVigentePorPerId(_per_id);
            bool existe = !EsDataSetVacio(dsExistente);

            var obj = new cls_persona_domicilio
            {
                perd_per_id = _per_id,
                perd_ciudad_residencia = Convert.ToInt32(ddl_perd_ciudad_residencia.SelectedValue),
                perd_zona = Convert.ToInt32(ddl_perd_zona.SelectedValue),
                perd_tipo_via = Convert.ToInt32(ddl_perd_tipo_via.SelectedValue),
                perd_descripcion_via = txt_nombre_via.Text.Trim().ToUpper(),
                perd_numero = txt_numero_casa.Text.Trim(),
                perd_edificio = txt_edificio.Text.Trim(),
                perd_bloque = txt_bloque.Text.Trim(),
                perd_piso = txt_piso.Text.Trim(),
                perd_dpto = txt_departamento.Text.Trim(),
                perd_telefono = txt_telefono.Text.Trim(),
                perd_celular = txt_celular.Text.Trim(),
                perd_email = txt_email_personal.Text.Trim(),
                perd_email_trabajo = txt_email_trabajo.Text.Trim(),
                perd_fam_emergencia = txt_en_caso_emer.Text.Trim().ToUpper(),
                perd_dir_emergencia = txt_direccion_emer.Text.Trim().ToUpper(),
                perd_tel_emergencia = txt_telf_emer.Text.Trim(),
                perd_coordenadas = hf_coordenadas?.Value ?? "",
                perd_usuario_creacion = _per_id,
                perd_usuario_modificacion = _per_id,
                perd_ultima_modificacion = DateTime.Now
            };

            bool exito;
            string mensaje;

            if (existe)
            {
                obj.perd_id = Convert.ToInt32(dsExistente.Tables[0].Rows[0]["perd_id"]);
                exito = obj.ActualizarTodosLosCampos();
                mensaje = "Datos de domicilio ACTUALIZADOS correctamente.";
            }
            else
            {
                int fileIdCod = 1;
                if (!string.IsNullOrEmpty(txt_codigo_file.Text))
                    fileIdCod = Convert.ToInt32(txt_codigo_file.Text.Trim());

                exito = obj.AdicionarDomicilioKardex(fileIdCod, txt_nro_lib.Text.Trim());
                mensaje = "Datos de domicilio GUARDADOS correctamente.";
            }

            if (!string.IsNullOrWhiteSpace(txt_nro_lib.Text))
                obj.ActualizarLibretaMilitar(_per_id, txt_nro_lib.Text.Trim());

            if (exito)
            {
                MostrarAlerta(mensaje);
                CargarDomicilioExistente();
            }
            else
            {
                throw new Exception("No se pudieron guardar los datos.");
            }
        }
        catch (ValidationException vex)
        {
            MostrarAlerta(vex.Message, "warning");
        }
        catch (Exception ex)
        {
            MostrarAlerta(ex.Message, "error");
        }
    }


    /// Valida los campos de la Opción 1.

    private void ValidarDomicilio()
    {
        if (string.IsNullOrEmpty(ddl_perd_departamento.SelectedValue))
            throw new ValidationException("Departamento", "Debe seleccionar un Departamento.");
        if (string.IsNullOrEmpty(ddl_perd_provincia.SelectedValue))
            throw new ValidationException("Provincia", "Debe seleccionar una Provincia.");
        if (string.IsNullOrEmpty(ddl_perd_ciudad_residencia.SelectedValue))
            throw new ValidationException("Ciudad/Localidad", "Debe seleccionar una Ciudad/Localidad.");
        if (string.IsNullOrEmpty(ddl_perd_zona.SelectedValue))
            throw new ValidationException("Zona", "Debe seleccionar una Zona.");
        if (string.IsNullOrEmpty(ddl_perd_tipo_via.SelectedValue))
            throw new ValidationException("Tipo Vía", "Debe seleccionar un Tipo de Vía.");

        cls_validador.ValidarObligatorio(txt_nombre_via.Text, "Nombre de la Vía");
        cls_validador.ValidarLongitudMaxima(txt_nombre_via.Text, 100, "Nombre de la Vía");
        cls_validador.ValidarObligatorio(txt_numero_casa.Text, "Número");
        cls_validador.ValidarLongitudMaxima(txt_numero_casa.Text, 5, "Número");
        cls_validador.ValidarLongitudMaxima(txt_edificio.Text, 50, "Edificio");
        cls_validador.ValidarLongitudMaxima(txt_bloque.Text, 50, "Bloque");
        cls_validador.ValidarLongitudMaxima(txt_piso.Text, 5, "Piso");
        cls_validador.ValidarLongitudMaxima(txt_departamento.Text, 10, "Departamento");

        cls_validador.ValidarTelefono(txt_telefono.Text, "Teléfono");
        cls_validador.ValidarSoloNumeros(txt_numero_casa.Text, "Número");
        cls_validador.ValidarObligatorio(txt_celular.Text, "Celular");
        cls_validador.ValidarCelular(txt_celular.Text, "Celular");

        cls_validador.ValidarEmail(txt_email_personal.Text, "Email Personal");
        cls_validador.ValidarLongitudMaxima(txt_email_personal.Text, 100, "Email Personal");
        cls_validador.ValidarEmail(txt_email_trabajo.Text, "Email Institucional");
        cls_validador.ValidarLongitudMaxima(txt_email_trabajo.Text, 50, "Email Institucional");

        cls_validador.ValidarObligatorio(txt_en_caso_emer.Text, "Nombre del Contacto de Emergencia");
        cls_validador.ValidarLongitudMaxima(txt_en_caso_emer.Text, 50, "Nombre del Contacto de Emergencia");
        cls_validador.ValidarLongitudMaxima(txt_direccion_emer.Text, 100, "Dirección de Emergencia");
        cls_validador.ValidarObligatorio(txt_telf_emer.Text, "Teléfono de Emergencia");
        cls_validador.ValidarTelefono(txt_telf_emer.Text, "Teléfono de Emergencia");

        cls_validador.ValidarLongitudMaxima(txt_nro_lib.Text, 20, "Nº Libreta Militar");
    }

    private void GuardarOpcion2() { /* TODO */ }
    private void GuardarOpcion3() { /* TODO */ }

    private void GuardarOpcion4Parcial()
    {
        MostrarNotificacion("Datos de Doble Percepción guardados.", "success");
    }

    #endregion

    #region ═══════════════ BOTONES GENERALES ═══════════════

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(ResolveUrl("~/Inicio/Sigrh"));
    }

    protected void btnImprimirDDJJ_Click(object sender, EventArgs e)
    {
        string djId = Session["dj_id"]?.ToString() ?? "";
        string perId = Session["per_id"]?.ToString() ?? "";
        string url = $"ImprimirDeclaracion.aspx?dj_id={djId}&per_id={perId}";

        sc = $"window.open('{url}', '_blank', 'width=900,height=700,scrollbars=yes');";
        SetScript(sc, "");
    }

    #endregion

    #region ═══════════════ HELPERS Y UTILIDADES ═══════════════


    /// Verifica si un DataSet está vacío o es nulo.

    private bool EsDataSetVacio(DataSet ds)
    {
        return ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0;
    }

 
    /// Convierte un CommandArgument a int de forma segura.
 
    private int ConvertirArgumentoAInt(object argumento)
    {
        if (argumento == null || string.IsNullOrWhiteSpace(argumento.ToString()))
            throw new Exception("No se pudo identificar el registro seleccionado.");

        int id;
        if (!int.TryParse(argumento.ToString().Trim(), out id))
            throw new Exception($"El identificador '{argumento}' no es válido.");

        return id;
    }


    /// Obtiene un valor seguro de un DataRow.

    private string ObtenerValorSeguro(DataRow row, string columnName)
    {
        if (row.Table.Columns.Contains(columnName) && row[columnName] != DBNull.Value)
            return row[columnName].ToString();

        return "";
    }


    /// Asigna un valor a un DropDownList si existe.

    private void SetComboValue(DropDownList ddl, string valor)
    {
        if (string.IsNullOrEmpty(valor)) return;

        ListItem item = ddl.Items.FindByValue(valor);
        if (item != null)
            ddl.SelectedValue = valor;
    }


    /// Convierte una fecha dd/MM/yyyy a yyyy-MM-dd (para input date).

    private string ConvertirFechaParaInput(string fecha)
    {
        if (string.IsNullOrEmpty(fecha) || fecha == "01/01/1900") return "";

        DateTime f;
        return DateTime.TryParse(fecha, out f) ? f.ToString("yyyy-MM-dd") : "";
    }

    /// Formatea un decimal a 2 dígitos.

    private string FormatearDecimal2(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor)) return "";

        decimal numero;
        return decimal.TryParse(valor, out numero)
            ? numero.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)
            : "";
    }

    /// Parsea un string a decimal con 2 decimales.

    private decimal? ParsearDecimal2(string texto, string nombreCampo)
    {
        if (string.IsNullOrWhiteSpace(texto)) return null;

        decimal numero;
        if (!decimal.TryParse(texto,
            System.Globalization.NumberStyles.Any,
            System.Globalization.CultureInfo.InvariantCulture,
            out numero))
        {
            throw new ValidationException(nombreCampo, $"El campo '{nombreCampo}' debe ser un número válido.");
        }

        if (numero < 0)
            throw new ValidationException(nombreCampo, $"El campo '{nombreCampo}' no puede ser negativo.");

        return Math.Round(numero, 2);
    }

    /// Parsea un string a int nullable.

    private int? ParsearEntero(string texto, string nombreCampo)
    {
        if (string.IsNullOrWhiteSpace(texto)) return null;

        int numero;
        if (!int.TryParse(texto, out numero))
            throw new ValidationException(nombreCampo, $"El campo '{nombreCampo}' debe ser un número entero válido.");

        if (numero < 0)
            throw new ValidationException(nombreCampo, $"El campo '{nombreCampo}' no puede ser negativo.");

        return numero;
    }


    /// Parsea un string a DateTime nullable.

    private DateTime? ParsearFechaNullable(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto)) return null;

        DateTime fecha;
        return DateTime.TryParse(texto, out fecha) ? fecha : (DateTime?)null;
    }


    /// Registra un script de JavaScript en el cliente.

    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }


    /// Muestra una notificación tipo notify.
    private void MostrarNotificacion(string mensaje, string tipo = "info", int time = 3000, string placement = "bottom")
    {
        string icon = tipo == "success" ? "fas fa-check-circle"
                    : tipo == "danger" ? "fas fa-exclamation-triangle"
                    : tipo == "warning" ? "fas fa-exclamation-triangle"
                    : "fas fa-info-circle";

        string align = placement == "top" ? "center" : "right";

        sc = "$.notify({ icon: '" + icon + "', message: '" + mensaje.Replace("'", "").Replace("\"", "") + "' }, " +
             "{ type: '" + tipo + "', placement: { from: '" + placement + "', align: '" + align + "' }, time: " + time + " });";
        SetScript(sc, "");
    }

    /// Muestra una alerta SweetAlert.

    private void MostrarAlerta(string mensaje, string tipo = "success")
    {
        sc = "Swal.fire({ icon: '" + tipo + "', title: '" + (tipo == "success" ? "¡Guardado exitoso!" : "Atención") +
             "', text: '" + mensaje.Replace("'", "").Replace("\"", "") + "', " +
             (tipo == "success" ? "timer: 2500, showConfirmButton: false " : "") + "});";
        SetScript(sc, "");
    }


    /// Cierra un modal de Bootstrap.

    private void OcultarModalYCerrar(string modalId)
    {
        sc = "$('#" + modalId + "').modal('hide'); " +
             "$('body').removeClass('modal-open'); " +
             "$('.modal-backdrop').remove();";
        SetScript(sc, "");
    }


    /// Aplica paginación a una grilla desde el ViewState.

    private void PaginarGrilla(GridView gv, string viewStateKey, GridViewPageEventArgs e, Literal ltlInfo)
    {
        try
        {
            DataTable dt = ViewState[viewStateKey] as DataTable;

            if (dt == null || dt.Rows.Count == 0)
            {
                return;
            }

            cls_paginador.PaginarDesdeViewState(gv, dt, e);
            ltlInfo.Text = cls_paginador.GenerarHtmlInfo(gv, dt.Rows.Count);
        }
        catch (Exception ex)
        {
            MostrarNotificacion($"Error al paginar: {ex.Message}", "danger");
        }
    }

    #endregion
}