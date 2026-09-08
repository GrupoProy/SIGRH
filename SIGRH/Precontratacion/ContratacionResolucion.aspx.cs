using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;

using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Precontrataciones_ContratacionResolucion : System.Web.UI.Page
{
    private cls_persona _persona = null;
    private cls_cp_sanciones _sanciones = null;
    private cls_catalogo _catalogo = null;
    private cls_precontrataciones_cs _precontrato = new cls_precontrataciones_cs();
    private cls_glosa _glosa = new cls_glosa();
    private cls_mp_cargo _cargo = new cls_mp_cargo();
    private cls_mp_asignacion _asignacion = new cls_mp_asignacion();

    private string sc = "";
    private int personaId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        personaId = Convert.ToInt32(Request.QueryString["id"]);
                        hfPerId.Value = personaId.ToString();
                        CargarDatosPersonales(personaId);
                        CargarAsignaciones(personaId);
                        CargaDDLTipoBaja("tipo_mov_baja_contrato");

                        txtNuevoFechaInicio.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error en Page_Load: " + ex.Message);
                    }
                }
                else
                {
                    Response.Redirect("ListaSolicitudes.aspx");
                }

                txtLugarFecha.Text = "La Paz, " + DateTime.Now.ToString("dd/MM/yyyy");
            }
        }
        else
        {
            Response.Redirect("../Index");
        }
    }

    private void CargarDatosPersonales(int per_id)
    {
        try
        {
            _persona = new cls_persona();
            DataSet ds = _persona.ObtenerRegistroX(per_id);

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
                DataSet dsDomicilio = domicilio.ObtenerTablaGrilla("", per_id.ToString(), "", "", "", "", "", "", "", "", "");

                if (dsDomicilio != null && dsDomicilio.Tables.Count > 0 && dsDomicilio.Tables[0].Rows.Count > 0)
                {
                    DataRow rowD = dsDomicilio.Tables[0].Rows[0];
                    ltlEmail.Text = rowD["perd_email_personal"].ToString().Trim();
                    ltlTelefono.Text = rowD["perd_telefono"].ToString().Trim();
                    ltlCelular.Text = rowD["perd_celular"].ToString().Trim();
                    ltlCiudad.Text = ObtenerDescripcion("ciudad_localidad", rowD["perd_ciudad_residencia"].ToString());
                    ltlDireccion.Text = rowD["perd_descripcion_via"].ToString().Trim() + " N° " + rowD["perd_numero"].ToString().Trim();
                }

                ViewState["PerId"] = per_id;
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error al cargar datos de persona: " + ex.Message);
        }
    }
    private void CargarAsignaciones(int per_id)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine($"=== CargarAsignaciones para per_id: {per_id} ===");

            DataSet ds = _precontrato.ObtenerContratoPorPersona(per_id);

            if (ds == null)
            {
                System.Diagnostics.Debug.WriteLine("DataSet es NULL");
                txtVigenteCargo.Text = "Sin contrato vigente";
                txtVigenteSueldo.Text = "0.00";
                ViewState["AsId"] = "0";
                ViewState["CaId"] = "0";
                return;
            }

            if (ds.Tables.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("DataSet no tiene tablas");
                txtVigenteCargo.Text = "Sin contrato vigente";
                txtVigenteSueldo.Text = "0.00";
                ViewState["AsId"] = "0";
                ViewState["CaId"] = "0";
                return;
            }

            if (ds.Tables[0].Rows.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("No se encontraron contratos vigentes para per_id: {per_id}");
                txtVigenteCargo.Text = "Sin contrato vigente";
                txtVigenteSueldo.Text = "0.00";
                ViewState["AsId"] = "0";
                ViewState["CaId"] = "0";
                return;
            }

            DataRow row = ds.Tables[0].Rows[0];

            if (!ds.Tables[0].Columns.Contains("as_id"))
            {
                System.Diagnostics.Debug.WriteLine("La columna 'as_id' no existe en el resultado");
                txtVigenteCargo.Text = "Error en estructura de datos";
                return;
            }

            if (!ds.Tables[0].Columns.Contains("ca_id"))
            {
                System.Diagnostics.Debug.WriteLine("La columna 'ca_id' no existe en el resultado");
                txtVigenteCargo.Text = "Error en estructura de datos";
                return;
            }

            int asId = Convert.ToInt32(row["as_id"]);
            int caId = Convert.ToInt32(row["ca_id"]);

            ViewState["AsId"] = asId.ToString();
            ViewState["CaId"] = caId.ToString();

            System.Diagnostics.Debug.WriteLine($"as_id: {asId}, ca_id: {caId}");

            txtVigenteCargo.Text = row["es_descripcion"] != DBNull.Value ? row["es_descripcion"].ToString() : "Sin cargo";

            txtVigenteSueldo.Text = row["ns_haber_basico"] != DBNull.Value
                ? Convert.ToDecimal(row["ns_haber_basico"]).ToString("N2")
                : "0.00";

            txtVigenteFechaInicio.Text = row["as_fecha_inicio"] != DBNull.Value
                ? Convert.ToDateTime(row["as_fecha_inicio"]).ToString("dd/MM/yyyy")
                : "";

            txtVigenteFechaFin.Text = row["as_fecha_fin"] != DBNull.Value
                ? Convert.ToDateTime(row["as_fecha_fin"]).ToString("dd/MM/yyyy")
                : "";

            txtVigenteUnidad.Text = row["eo_descripcion"] != DBNull.Value
                ? row["eo_descripcion"].ToString()
                : "Sin unidad";

            System.Diagnostics.Debug.WriteLine("Contrato vigente cargado correctamente");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"Error en CargarAsignaciones: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
            txtVigenteCargo.Text = "Error al cargar datos";
            txtVigenteSueldo.Text = "0.00";
            ViewState["AsId"] = "0";
            ViewState["CaId"] = "0";
        }
    }
    private void CargaDDLTipoBaja(string par_val)
    {
        try
        {
            _catalogo = new cls_catalogo();
            Ddl_as_tipo_baja.Items.Clear();

            DataSet ds = _catalogo.ObtenerTablaGrilla("", par_val, "", "", "", "", "", "", "", "V");

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                Ddl_as_tipo_baja.DataSource = ds;
                Ddl_as_tipo_baja.DataValueField = "cat_abreviacion";
                Ddl_as_tipo_baja.DataTextField = "cat_descripcion";
                Ddl_as_tipo_baja.DataBind();
                Ddl_as_tipo_baja.Items.Insert(0, new ListItem("Seleccione...", "0"));
            }
            else
            {
                Ddl_as_tipo_baja.Items.Add(new ListItem("Seleccione...", "0"));
                Ddl_as_tipo_baja.Items.Add(new ListItem("Renuncia Voluntaria", "R"));
                Ddl_as_tipo_baja.Items.Add(new ListItem("Despido Justificado", "D"));
                Ddl_as_tipo_baja.Items.Add(new ListItem("Finalización de Contrato", "F"));
                Ddl_as_tipo_baja.Items.Add(new ListItem("Mutuo Acuerdo", "M"));
                Ddl_as_tipo_baja.Items.Add(new ListItem("Otros", "O"));
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error en CargaDDLTipoBaja: " + ex.Message);
            Ddl_as_tipo_baja.Items.Clear();
            Ddl_as_tipo_baja.Items.Add(new ListItem("Seleccione...", "0"));
            Ddl_as_tipo_baja.Items.Add(new ListItem("Renuncia Voluntaria", "R"));
            Ddl_as_tipo_baja.Items.Add(new ListItem("Despido Justificado", "D"));
            Ddl_as_tipo_baja.Items.Add(new ListItem("Finalización de Contrato", "F"));
            Ddl_as_tipo_baja.Items.Add(new ListItem("Mutuo Acuerdo", "M"));
            Ddl_as_tipo_baja.Items.Add(new ListItem("Otros", "O"));
        }
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
                if (rows.Length > 0) return rows[0]["cat_descripcion"].ToString();
            }
            return id;
        }
        catch { return id; }
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine("=== INICIO btnGuardar_Click ===");

            if (Ddl_as_tipo_baja.SelectedValue == "0")
            {
                MostrarMensaje("Debe seleccionar el tipo de baja", "warning");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCITE.Text))
            {
                MostrarMensaje("Debe ingresar el CITE / Número de Documento", "warning");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNuevoFechaInicio.Text))
            {
                MostrarMensaje("Debe seleccionar la fecha de proceso", "warning");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNuevoFechaFin.Text))
            {
                MostrarMensaje("Debe seleccionar la fecha de memo", "warning");
                return;
            }

            DateTime fechaProceso;
            DateTime fechaMemo;

            if (!DateTime.TryParse(txtNuevoFechaInicio.Text, out fechaProceso))
            {
                MostrarMensaje("Formato de fecha de proceso inválido", "warning");
                return;
            }

            if (!DateTime.TryParse(txtNuevoFechaFin.Text, out fechaMemo))
            {
                MostrarMensaje("Formato de fecha de memo inválido", "warning");
                return;
            }

            if (fechaMemo <= fechaProceso)
            {
                MostrarMensaje("La fecha de memo debe ser mayor a la fecha de proceso", "warning");
                return;
            }

            int perId = Convert.ToInt32(hfPerId.Value);
            int asId = ViewState["AsId"] != null ? Convert.ToInt32(ViewState["AsId"]) : 0;
            int usuarioId = Session["per_id"] != null ? Convert.ToInt32(Session["per_id"]) : 0;

            if (usuarioId == 0)
            {
                MostrarMensaje("No se encontró el usuario en sesión", "warning");
                return;
            }

            if (asId == 0)
            {
                MostrarMensaje("No se encontró la asignación vigente", "warning");
                return;
            }

            int caId = 0;
            DataSet dsCargo = _precontrato.ObtenerContratoPorPersona(perId);
            if (dsCargo != null && dsCargo.Tables.Count > 0 && dsCargo.Tables[0].Rows.Count > 0)
            {
                caId = Convert.ToInt32(dsCargo.Tables[0].Rows[0]["ca_id"]);
            }

            if (caId == 0)
            {
                MostrarMensaje("No se encontró el cargo asociado", "warning");
                return;
            }

            _asignacion.as_id = asId;
            _asignacion.as_fecha_fin = fechaMemo;
            _asignacion.as_tipo_baja = Ddl_as_tipo_baja.SelectedValue;
            _asignacion.as_memo_baja = 0;
            _asignacion.as_usuario_creacion = usuarioId;

            bool bajaExitosa = _asignacion.ActualizarBaja();

            if (!bajaExitosa)
            {
                MostrarMensaje("Error al dar de baja la asignación", "danger");
                return;
            }

            System.Diagnostics.Debug.WriteLine("Asignación dada de baja usando SP sp_mp_asignacion");

            _cargo.ca_id_actual = caId;
            _cargo.ca_estado_actual = "H";
            _cargo.ca_usuario_creacion = usuarioId;

            bool cargoLiberado = _cargo.ActualizarCargoActual();

            if (cargoLiberado)
            {
                System.Diagnostics.Debug.WriteLine("Cargo liberado usando sp_mp_cargo ");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Error al liberar el cargo");
            }

            string numeroDocumento = string.IsNullOrWhiteSpace(txtCITE.Text) ? "N/A" : txtCITE.Text.Trim().ToUpper();
            string tipoMovimiento = Ddl_as_tipo_baja.SelectedItem.Text.Trim().ToUpper();

            string glosaCompleta = $"RESOLUCION DE CONTRATO - {tipoMovimiento} - CITE: {numeroDocumento} - FECHA: {fechaProceso:dd/MM/yyyy}";

            _glosa.gl_valor_pk = asId.ToString();
            _glosa.gl_nombre_pk = "as_id";
            _glosa.gl_tabla = "tbl_mp_asignacion";
            _glosa.gl_tipo_mov = 814;
            _glosa.gl_fecha_doc = fechaProceso;
            _glosa.gl_tipo_doc = 5;
            _glosa.gl_glosa = glosaCompleta;
            _glosa.gl_numero_doc = numeroDocumento;
            _glosa.gl_usuario = usuarioId;

            bool glosaGuardada = _glosa.Adicionar();

            if (glosaGuardada)
            {
                System.Diagnostics.Debug.WriteLine($"Glosa guardada: {glosaCompleta}");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Error al guardar la glosa");
            }

            MostrarMensaje("Baja registrada correctamente", "success");

            ClientScript.RegisterStartupScript(this.GetType(), "redirect",
                "Swal.fire({title:'¡Éxito!', text:'El contrato ha sido dado de baja correctamente', icon:'success'})" +
                ".then(function() { window.location='ListaSolicitudes.aspx'; });", true);
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"ERROR: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
            MostrarMensaje($"Error al guardar: {ex.Message}", "danger");
        }
    }

    private void MostrarMensaje(string mensaje, string tipo)
    {
        sc = $"$.notify({{ icon: 'fas fa-exclamation', message: '{mensaje.Replace("'", "\\'")}' }}, {{ type: '{tipo}' }});";
        SetScript(sc, "");
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