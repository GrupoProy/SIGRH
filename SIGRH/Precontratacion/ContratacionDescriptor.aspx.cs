using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Precontrataciones_ContratacionDescriptor : System.Web.UI.Page
{
    private cls_persona _persona = null;
    private cls_mp_cargo _cargo = null;
    private cls_precontrataciones_cs _precontrato = new cls_precontrataciones_cs();
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                txtLugarFecha.Text = "La Paz, " + DateTime.Now.ToString("dd/MM/yyyy");

                CargarCargos();
                CargarFunciones();

                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"];
                    CargarDatosPorID(id);
                    CargarContratoVigente(Convert.ToInt32(id));
                }
                else if (Request.QueryString["ci"] != null)
                {
                    CargarDatosPorCI(Request.QueryString["ci"]);
                }
            }
        }
        else
        {
            Response.Redirect("../Index");
        }
    }

    private void CargarContratoVigente(int perId)
    {
        try
        {
            DataSet ds = _precontrato.ObtenerContratoPorPersona(perId);

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                return;
            }

            DataRow row = ds.Tables[0].Rows[0];

            string esId = row["es_id"] != DBNull.Value ? row["es_id"].ToString() : "0";
            string eoId = row["eo_id"] != DBNull.Value ? row["eo_id"].ToString() : "0";

            if (esId != "0" && ddlCargo.Items.FindByValue(esId) != null)
            {
                ddlCargo.SelectedValue = esId;
                ActualizarDatosCargo(Convert.ToInt32(esId));
            }

            if (eoId != "0" && ddlFunciones.Items.FindByValue(eoId) != null)
            {
                ddlFunciones.SelectedValue = eoId;
            }

            if (row["as_fecha_inicio"] != DBNull.Value)
            {
                txtFechaInicio.Text = Convert.ToDateTime(row["as_fecha_inicio"]).ToString("yyyy-MM-dd");
            }
            if (row["as_fecha_fin"] != DBNull.Value)
            {
                txtFechaFin.Text = Convert.ToDateTime(row["as_fecha_fin"]).ToString("yyyy-MM-dd");
            }

            // ✅ Si el contrato NO tiene descriptor registrado, mostrar aviso claro
            txtDescripcionPuesto.Text = (row["descrip_pu_puesto"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["descrip_pu_puesto"].ToString()))
                ? row["descrip_pu_puesto"].ToString()
                : "";

            txtObjetivo.Text = (row["descrip_pu_objetivo"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["descrip_pu_objetivo"].ToString()))
                ? row["descrip_pu_objetivo"].ToString()
                : "";

            txtFunciones.Text = (row["result_resultado"] != DBNull.Value && !string.IsNullOrWhiteSpace(row["result_resultado"].ToString()))
                ? row["result_resultado"].ToString()
                : "";

            // Si el descriptor viene vacío, avisamos al usuario con un notify
            bool sinDescriptor = string.IsNullOrWhiteSpace(txtDescripcionPuesto.Text)
                              && string.IsNullOrWhiteSpace(txtObjetivo.Text)
                              && string.IsNullOrWhiteSpace(txtFunciones.Text);

            if (sinDescriptor)
            {
                sc = "$.notify({ icon: 'fas fa-info-circle', message: 'El contrato vigente no tiene descriptor registrado. Puede completarlo abajo.' }, { type: 'warning', placement: { from: 'bottom', align: 'right' }, delay: 6000 });";
                SetScript(sc, "");
            }
        }
        catch (Exception ex)
        {
            // ✅ Ahora el error es visible
            sc = "$.notify({ icon: 'fas fa-exclamation-circle', message: 'Error al cargar contrato vigente: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
            System.Diagnostics.Debug.WriteLine("Error al cargar contrato vigente: " + ex.Message);
        }
    }

    private void CargarCargos()
    {
        try
        {
            _cargo = new cls_mp_cargo();
            string gestionSelec = Session["pr_id"] != null ? Session["pr_id"].ToString() : "1";
            _cargo.gestion_selec = gestionSelec;
            _cargo.ca_ti_item = "C";

            DataSet ds = _cargo.ObtenerFiltradoCargoUO();

            ddlCargo.Items.Clear();
            ddlCargo.Items.Insert(0, new ListItem("Seleccione Cargo...", "0"));

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string es_id = row["es_id"].ToString();
                    string es_descripcion = row["es_descripcion"].ToString();
                    ddlCargo.Items.Add(new ListItem(es_descripcion, es_id));
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error al cargar cargos: " + ex.Message);
        }
    }

    private void CargarFunciones()
    {
        try
        {
            ddlFunciones.Items.Clear();
            ddlFunciones.Items.Insert(0, new ListItem("Seleccione...", "0"));

            if (Session["us_id"] == null || Session["us_id"].ToString() == "")
            {
                return;
            }

            int usuarioId = Convert.ToInt32(Session["us_id"]);

            cls_permiso_categoria_programatica permiso = new cls_permiso_categoria_programatica();
            permiso.pcp_us_id = usuarioId;

            DataSet ds = permiso.ObtenerTablaCombo();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    string eo_id = row["eo_id"].ToString();
                    string eo_descripcion = row["eo_descripcion"].ToString();
                    ddlFunciones.Items.Add(new ListItem(eo_descripcion, eo_id));
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error al cargar funciones: " + ex.Message);
        }
    }

    private void ActualizarDatosCargo(int es_id)
    {
        try
        {
            _cargo = new cls_mp_cargo();
            string gestionSelec = Session["pr_id"] != null ? Session["pr_id"].ToString() : "1";
            _cargo.gestion_selec = gestionSelec;
            _cargo.es_cod_esc = es_id;

            DataSet ds = _cargo.ObtenerDetalleUO();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                if (row["haber_basico"] != DBNull.Value && row["haber_basico"].ToString().Trim() != "")
                {
                    decimal sueldo = Convert.ToDecimal(row["haber_basico"]);
                    txtSueldo.Text = sueldo.ToString("0.00");
                }
                else
                {
                    txtSueldo.Text = "";
                }

                txtNivelSalarial.Text = row["ns_nivel"] != DBNull.Value ? row["ns_nivel"].ToString() : "";
                txtClase.Text = row["ns_clase"] != DBNull.Value ? row["ns_clase"].ToString() : "";
            }
            else
            {
                txtSueldo.Text = "";
                txtNivelSalarial.Text = "";
                txtClase.Text = "";
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error al obtener datos del cargo: " + ex.Message);
            txtSueldo.Text = "";
            txtNivelSalarial.Text = "";
            txtClase.Text = "";
        }
    }

    protected void ddlCargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlCargo.SelectedValue != "0")
            {
                ActualizarDatosCargo(Convert.ToInt32(ddlCargo.SelectedValue));
            }
            else
            {
                txtSueldo.Text = "";
                txtNivelSalarial.Text = "";
                txtClase.Text = "";
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error al obtener datos del cargo: " + ex.Message);
            txtSueldo.Text = "";
            txtNivelSalarial.Text = "";
            txtClase.Text = "";
        }
    }

    private void CargarDatosPorID(string id)
    {
        try
        {
            _persona = new cls_persona();
            DataSet ds = _persona.ObtenerRegistroX(Convert.ToInt32(id));

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                ltlNombreCompleto.Text = row["per_nombres"].ToString().Trim() + " " +
                                         row["per_ap_paterno"].ToString().Trim() + " " +
                                         row["per_ap_materno"].ToString().Trim();
                ltlCarnet.Text = row["per_num_doc"].ToString().Trim();
                ltlFechaNac.Text = Convert.ToDateTime(row["per_fecha_nac"]).ToString("dd/MM/yyyy");
                ltlSexo.Text = row["per_sexo"].ToString().Trim() == "M" ? "Masculino" : "Femenino";
                ltlEstadoCivil.Text = ObtenerDescripcion("estado_civil", row["per_estado_civil"].ToString());
                ltlNacionalidad.Text = ObtenerDescripcion("pais", row["per_procedencia"].ToString());

                cls_persona_domicilio domicilio = new cls_persona_domicilio();
                DataSet dsDomicilio = domicilio.ObtenerTablaGrilla("", id, "", "", "", "", "", "", "", "", "");

                if (dsDomicilio != null && dsDomicilio.Tables.Count > 0 && dsDomicilio.Tables[0].Rows.Count > 0)
                {
                    DataRow rowD = dsDomicilio.Tables[0].Rows[0];
                    ltlEmail.Text = rowD["perd_email_personal"].ToString().Trim();
                    ltlTelefono.Text = rowD["perd_telefono"].ToString().Trim();
                    ltlCelular.Text = rowD["perd_celular"].ToString().Trim();
                    ltlCiudad.Text = ObtenerDescripcion("ciudad_localidad", rowD["perd_ciudad_residencia"].ToString());
                    ltlDireccion.Text = rowD["perd_descripcion_via"].ToString().Trim() + " N° " + rowD["perd_numero"].ToString().Trim();
                }
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error al cargar datos: " + ex.Message);
        }
    }

    private void CargarDatosPorCI(string ci)
    {
        try
        {
            _persona = new cls_persona();
            DataSet ds = _persona.VerificarNuevoFuncionario(ci, 0);

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                ltlNombreCompleto.Text = row["per_nombres"].ToString().Trim() + " " +
                                         row["per_ap_paterno"].ToString().Trim() + " " +
                                         row["per_ap_materno"].ToString().Trim();
                ltlCarnet.Text = row["per_num_doc"].ToString().Trim();
                ltlFechaNac.Text = Convert.ToDateTime(row["per_fecha_nac"]).ToString("dd/MM/yyyy");
                ltlSexo.Text = row["per_sexo"].ToString().Trim() == "M" ? "Masculino" : "Femenino";
                ltlEstadoCivil.Text = ObtenerDescripcion("estado_civil", row["per_estado_civil"].ToString());
                ltlNacionalidad.Text = ObtenerDescripcion("pais", row["per_procedencia"].ToString());
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error al cargar datos por CI: " + ex.Message);
        }
    }

    private string ObtenerDescripcion(string tabla, string id)
    {
        try
        {
            if (string.IsNullOrEmpty(id) || id == "0")
                return "";

            cls_catalogo catalogo = new cls_catalogo { cat_tabla = tabla };
            DataSet ds = catalogo.ObtenerTablaCombo();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow[] rows = ds.Tables[0].Select("cat_id = " + id);
                if (rows.Length > 0)
                {
                    return rows[0]["cat_descripcion"].ToString();
                }
            }
            return id;
        }
        catch
        {
            return id;
        }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            // ============ VALIDACIONES BÁSICAS ============
            if (string.IsNullOrEmpty(ltlNombreCompleto.Text) || ltlNombreCompleto.Text == "Cargando...")
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No hay datos de funcionario cargados' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            if (ddlCargo.SelectedValue == "0")
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar un cargo' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            if (ddlFunciones.SelectedValue == "0")
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar una función' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            // ============ ✅ VALIDACIONES NUEVAS DEL DESCRIPTOR ============
            if (string.IsNullOrWhiteSpace(txtDescripcionPuesto.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar la descripción del puesto' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtObjetivo.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar el objetivo o justificación de la contratación' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            if (string.IsNullOrWhiteSpace(txtFunciones.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar las funciones del puesto' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
            // ============ FIN VALIDACIONES NUEVAS ============

            int perId = 0;
            if (ViewState["PerId"] != null)
            {
                perId = Convert.ToInt32(ViewState["PerId"]);
            }
            else if (Request.QueryString["id"] != null)
            {
                perId = Convert.ToInt32(Request.QueryString["id"]);
            }

            if (perId == 0)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se encontró el ID del funcionario' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            int usuarioId = Session["us_id"] != null ? Convert.ToInt32(Session["us_id"]) : 1;
            int escalaSalarialId = Convert.ToInt32(ddlCargo.SelectedValue);
            int unidadOrganizacionalId = Convert.ToInt32(ddlFunciones.SelectedValue);

            decimal haberBasico = 0;
            if (!string.IsNullOrEmpty(txtSueldo.Text))
            {
                decimal.TryParse(txtSueldo.Text, out haberBasico);
            }

            DateTime fechaInicio = DateTime.Now;
            DateTime fechaFin = DateTime.Now.AddMonths(1);

            if (!string.IsNullOrEmpty(txtFechaInicio.Text))
            {
                fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            }
            if (!string.IsNullOrEmpty(txtFechaFin.Text))
            {
                fechaFin = Convert.ToDateTime(txtFechaFin.Text);
            }

            if (fechaFin <= fechaInicio)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'La fecha de fin debe ser mayor a la fecha de inicio' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            _precontrato.p_accion = "A2";
            _precontrato.pp_us_id = usuarioId;
            _precontrato.pp_per_id = perId;
            _precontrato.pp_es_id = escalaSalarialId;
            _precontrato.pp_eo_id = unidadOrganizacionalId;
            _precontrato.pp_haber_basico = haberBasico;
            _precontrato.pp_fecha_inicio = fechaInicio.ToString("dd/MM/yyyy");
            _precontrato.pp_fecha_fin = fechaFin.ToString("dd/MM/yyyy");
            _precontrato.pp_p_descripcion = txtDescripcionPuesto.Text.ToUpper().Trim();
            _precontrato.pp_pu_objetivo = txtObjetivo.Text.ToUpper().Trim();
            _precontrato.pp_p_funciones = txtFunciones.Text.ToUpper().Trim();
            _precontrato.pp_cite = txtCITE.Text.Trim().ToUpper();

            int nuevoAsId = _precontrato.CrearContrato();

            if (nuevoAsId == 0)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al crear el contrato. Verifique los datos.' }, { type: 'danger' });";
                SetScript(sc, "");
                return;
            }

            System.Diagnostics.Debug.WriteLine($"✅ Contrato creado con AS_ID: {nuevoAsId}");

            sc = "$.notify({ icon: 'fas fa-check', message: 'Solicitud registrada correctamente' }, { type: 'success' });";
            SetScript(sc, "");

            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertExito",
            "Swal.fire({title:'Éxito', text:'Solicitud registrada correctamente', icon:'success'})" +
            ".then((result) => { if(result.isConfirmed) { window.location='ContratacionDeclaracion.aspx'; } });", true);
        }
        catch (Exception ex)
        {
            string mensajeError = ex.Message.Replace("'", "\\'").Replace("\r", "").Replace("\n", " ");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al guardar: " + mensajeError + "' }, { type: 'danger' });";
            SetScript(sc, "");
            System.Diagnostics.Debug.WriteLine($"Error en btnGuardar_Click: {ex.Message}");
        }
    }

    private void SetScript(string val, string valS)
    {
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
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