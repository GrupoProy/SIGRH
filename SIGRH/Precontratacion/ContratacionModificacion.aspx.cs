using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;

using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Precontrataciones_ContratacionModificacion : System.Web.UI.Page
{
    private cls_persona _persona;
    private cls_mp_cargo _cargo = new cls_mp_cargo();
    private cls_precontrataciones_cs _precontrato = new cls_precontrataciones_cs();
    private cls_glosa _glosa = new cls_glosa();
    private cls_mp_asignacion _asignacion = new cls_mp_asignacion();
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["per_id"] == null || string.IsNullOrEmpty(Session["per_id"].ToString()))
        {
            Response.Redirect("../Index");
            return;
        }

        if (Page.IsPostBack)
            return;

        if (Request.QueryString["id"] == null)
        {
            Response.Redirect("ListaSolicitudes.aspx");
            return;
        }

        try
        {
            int personaId = Convert.ToInt32(Request.QueryString["id"]);
            int usuarioId = Session["us_id"] != null ? Convert.ToInt32(Session["us_id"]) : 1;

            hfPerId.Value = personaId.ToString();
            ViewState["PerId"] = personaId;
            ViewState["UsuarioId"] = usuarioId;

            CargarDatosPersonales(personaId);
            CargarCargos();
            CargarContratoVigente(personaId);

            txtLugarFecha.Text = "La Paz, " + DateTime.Now.ToString("dd/MM/yyyy");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error en Page_Load: " + ex.Message);
            MostrarMensaje("Error al cargar la página: " + ex.Message, "danger");
        }
    }
    private void CargarContratoVigente(int perId)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine($"=== CargarContratoVigente para per_id: {perId} ===");

            bool contratoEncontrado = _precontrato.CargarContratoPorPersona(perId);

            if (!contratoEncontrado)
            {
                System.Diagnostics.Debug.WriteLine($"No se encontraron contratos vigentes para per_id: {perId}");
                MostrarSinContrato();
                return;
            }

            int asId = _precontrato.as_id;
            int caId = _precontrato.ca_id;
            int eoId = _precontrato.eo_id;

            ViewState["AsId"] = asId.ToString();
            ViewState["CaId"] = caId.ToString();
            ViewState["EoId"] = eoId.ToString();
            hfCaId.Value = caId.ToString();

            // ÍTEM
            string tiItem = string.IsNullOrEmpty(_precontrato.ca_ti_item) ? "" : _precontrato.ca_ti_item;
            string numItem = _precontrato.ca_num_item > 0 ? _precontrato.ca_num_item.ToString() : "0";
            ltl_item.Text = $"{tiItem} - {numItem}";

            // CARGO / PUESTO
            ltl_puesto.Text = string.IsNullOrEmpty(_precontrato.p_descripcion) ? "" : _precontrato.p_descripcion;
            txtVigenteCargo.Text = string.IsNullOrEmpty(_precontrato.es_descripcion) ? "" : _precontrato.es_descripcion;

            // SUELDO
            txtVigenteSueldo.Text = _precontrato.ns_haber_basico > 0 ? _precontrato.ns_haber_basico.ToString("N2") : "0.00";

            // FECHA INICIO
            if (_precontrato.as_fecha_inicio != DateTime.MinValue)
            {
                string fechaInicio = _precontrato.as_fecha_inicio.ToString("yyyy-MM-dd");
                txtVigenteFechaInicio.Text = fechaInicio;
                txtNuevoFechaInicio.Text = fechaInicio;
            }
            else
            {
                txtVigenteFechaInicio.Text = "";
                txtNuevoFechaInicio.Text = "";
            }

            // FECHA FIN
            if (_precontrato.as_fecha_fin != DateTime.MinValue)
            {
                string fechaFin = _precontrato.as_fecha_fin.ToString("yyyy-MM-dd");
                txtVigenteFechaFin.Text = fechaFin;
                txtNuevoFechaFin.Text = fechaFin;
            }
            else
            {
                txtVigenteFechaFin.Text = "";
                txtNuevoFechaFin.Text = "";
            }

            // UNIDAD
            txtVigenteUnidad.Text = string.IsNullOrEmpty(_precontrato.eo_descripcion) ? "" : _precontrato.eo_descripcion;

            // NIVEL Y CLASE
            txtVigenteNivel.Text = string.IsNullOrEmpty(_precontrato.ns_nivel) ? "" : _precontrato.ns_nivel;
            txtVigenteClase.Text = string.IsNullOrEmpty(_precontrato.ns_clase) ? "" : _precontrato.ns_clase;

            // DESCRIPTOR DEL PUESTO
            txtVigenteDescripcionPuesto.Text = string.IsNullOrEmpty(_precontrato.descrip_pu_puesto) ? "" : _precontrato.descrip_pu_puesto;
            txtVigenteObjetivo.Text = string.IsNullOrEmpty(_precontrato.descrip_pu_objetivo) ? "" : _precontrato.descrip_pu_objetivo;
            txtVigenteFunciones.Text = string.IsNullOrEmpty(_precontrato.result_resultado) ? "" : _precontrato.result_resultado;

            string esId = caId.ToString();
            if (!string.IsNullOrEmpty(esId) && esId != "0" && ddlNuevoCargo.Items.FindByValue(esId) != null)
            {
                ddlNuevoCargo.SelectedValue = esId;
                CargarDatosCargo(esId);
            }

            // COPIAR DATOS AL NUEVO CONTRATO
            txtDescripcionPuesto.Text = txtVigenteDescripcionPuesto.Text;
            txtObjetivo.Text = txtVigenteObjetivo.Text;
            txtFunciones.Text = txtVigenteFunciones.Text;

            // CITE
            CargarCITEPorAsignacion(asId);

            System.Diagnostics.Debug.WriteLine($"Contrato vigente cargado: AS_ID={asId}, EO_ID={eoId}");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"ERROR EN CargarContratoVigente: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"STACKTRACE: {ex.StackTrace}");
            MostrarMensaje("Error al cargar el contrato vigente: " + ex.Message, "danger");
        }
    }
    private void CargarCITEPorAsignacion(int asId)
    {
        try
        {
            DataSet ds = _glosa.ObtenerTablaGrilla(
                "",
                asId.ToString(),
                "",
                "tbl_mp_asignacion",
                "814",
                "",
                "",
                "",
                "",
                ""
            );

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                txtCITE.Text = ds.Tables[0].Rows[0]["gl_numero_doc"] != DBNull.Value
                    ? ds.Tables[0].Rows[0]["gl_numero_doc"].ToString()
                    : "";
            }
            else
            {
                txtCITE.Text = "";
            }

            System.Diagnostics.Debug.WriteLine($"CITE cargado: {txtCITE.Text}");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error al cargar CITE: " + ex.Message);
            txtCITE.Text = "";
        }
    }
    private void CargarCargos()
    {
        try
        {
            _cargo = new cls_mp_cargo
            {
                gestion_selec = Session["pr_id"] != null ? Session["pr_id"].ToString() : "1",
                ca_ti_item = "C"
            };

            DataSet ds = _cargo.ObtenerFiltradoCargoUO();

            ddlNuevoCargo.Items.Clear();
            ddlNuevoCargo.Items.Insert(0, new ListItem("Seleccione Cargo...", "0"));

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                System.Diagnostics.Debug.WriteLine("No se encontraron cargos");
                return;
            }

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                ddlNuevoCargo.Items.Add(
                    new ListItem(
                        row["es_descripcion"].ToString(),
                        row["es_id"].ToString()
                    )
                );
            }

            System.Diagnostics.Debug.WriteLine($"Cargos cargados: {ddlNuevoCargo.Items.Count - 1}");
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error en CargarCargos: " + ex.Message);
            ddlNuevoCargo.Items.Clear();
            ddlNuevoCargo.Items.Insert(0, new ListItem("Seleccione Cargo...", "0"));
        }
    }
    protected void ddlNuevoCargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarDatosCargo(ddlNuevoCargo.SelectedValue);
    }
    private void CargarDatosCargo(string esId)
    {
        if (string.IsNullOrEmpty(esId) || esId == "0")
        {
            LimpiarCamposCargo();
            return;
        }

        try
        {
            _cargo = new cls_mp_cargo
            {
                gestion_selec = Session["pr_id"] != null ? Session["pr_id"].ToString() : "1",
                es_cod_esc = Convert.ToInt32(esId)
            };

            DataSet ds = _cargo.ObtenerDetalleUO();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                txtNuevoSueldo.Text = row["haber_basico"] != DBNull.Value
                    ? Convert.ToDecimal(row["haber_basico"]).ToString("0.00")
                    : "";

                txtNuevoNivel.Text = row["ns_nivel"] != DBNull.Value ? row["ns_nivel"].ToString() : "";
                txtNuevoClase.Text = row["ns_clase"] != DBNull.Value ? row["ns_clase"].ToString() : "";
            }
            else
            {
                LimpiarCamposCargo();
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error en CargarDatosCargo: " + ex.Message);
            LimpiarCamposCargo();
        }
    }
    private void LimpiarCamposCargo()
    {
        txtNuevoSueldo.Text = "";
        txtNuevoNivel.Text = "";
        txtNuevoClase.Text = "";
    }
    private void CargarDatosPersonales(int perId)
    {
        try
        {
            _persona = new cls_persona();

            DataSet ds = _persona.ObtenerRegistroX(perId);

            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
                return;

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
            DataSet dsDomicilio = domicilio.ObtenerTablaGrilla(
                "", perId.ToString(), "", "", "", "", "", "", "", "", ""
            );

            if (dsDomicilio != null && dsDomicilio.Tables.Count > 0 && dsDomicilio.Tables[0].Rows.Count > 0)
            {
                DataRow domicilioRow = dsDomicilio.Tables[0].Rows[0];
                ltlEmail.Text = ValidarCampo(domicilioRow["perd_email_personal"]);
                ltlTelefono.Text = ValidarCampo(domicilioRow["perd_telefono"]);
                ltlCelular.Text = ValidarCampo(domicilioRow["perd_celular"]);
                ltlCiudad.Text = ObtenerDescripcion("ciudad_localidad", ValidarCampo(domicilioRow["perd_ciudad_residencia"]));
                ltlDireccion.Text = ValidarCampo(domicilioRow["perd_descripcion_via"]) + " N° " + ValidarCampo(domicilioRow["perd_numero"]);
            }
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine("Error en CargarDatosPersonales: " + ex.Message);
        }
    }
    private void MostrarSinContrato()
    {
        ltl_item.Text = "SIN ÍTEM";
        ltl_puesto.Text = "SIN PUESTO";

        txtVigenteCargo.Text = "SIN CARGO";
        txtVigenteSueldo.Text = "0.00";
        txtVigenteFechaInicio.Text = "";
        txtVigenteFechaFin.Text = "";
        txtVigenteUnidad.Text = "SIN UNIDAD";
        txtVigenteNivel.Text = "";
        txtVigenteClase.Text = "";

        txtVigenteDescripcionPuesto.Text = "";
        txtVigenteObjetivo.Text = "";
        txtVigenteFunciones.Text = "";

        ScriptManager.RegisterStartupScript(
            this,
            GetType(),
            "SinContrato",
            "Swal.fire({" +
            "title:'Advertencia'," +
            "text:'No se encontró un contrato vigente para esta persona'," +
            "icon:'warning'" +
            "});",
            true
        );
    }
    protected void btnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            System.Diagnostics.Debug.WriteLine("=== btnGuardar_Click EJECUTADO ===");

            if (ddlNuevoCargo.SelectedValue == "0")
            {
                MostrarMensaje("Debe seleccionar un nuevo cargo", "warning");
                return;
            }
            if (string.IsNullOrEmpty(txtNuevoFechaInicio.Text))
            {
                MostrarMensaje("Debe seleccionar la nueva fecha de inicio", "warning");
                return;
            }
            if (string.IsNullOrEmpty(txtNuevoFechaFin.Text))
            {
                MostrarMensaje("Debe seleccionar la nueva fecha de fin", "warning");
                return;
            }

            DateTime fechaInicio = Convert.ToDateTime(txtNuevoFechaInicio.Text);
            DateTime fechaFin = Convert.ToDateTime(txtNuevoFechaFin.Text);

            if (fechaFin <= fechaInicio)
            {
                MostrarMensaje("La fecha de fin debe ser mayor a la fecha de inicio", "warning");
                return;
            }

            int perId = Convert.ToInt32(hfPerId.Value);
            int usuarioId = ViewState["UsuarioId"] != null ? Convert.ToInt32(ViewState["UsuarioId"]) : 1;
            int esId = Convert.ToInt32(ddlNuevoCargo.SelectedValue);
            decimal sueldo = string.IsNullOrEmpty(txtNuevoSueldo.Text) ? 0 : Convert.ToDecimal(txtNuevoSueldo.Text);
            int eoId = 0;

            if (ViewState["EoId"] != null)
            {
                eoId = Convert.ToInt32(ViewState["EoId"]);
                System.Diagnostics.Debug.WriteLine($"EO_ID obtenido de ViewState: {eoId}");
            }

            if (eoId == 0)
            {
                DataSet dsVigente = _precontrato.ObtenerContratoPorPersona(perId);
                if (dsVigente != null && dsVigente.Tables.Count > 0 && dsVigente.Tables[0].Rows.Count > 0)
                {
                    DataRow rowVigente = dsVigente.Tables[0].Rows[0];
                    eoId = rowVigente["eo_id"] != DBNull.Value ? Convert.ToInt32(rowVigente["eo_id"]) : 0;
                    System.Diagnostics.Debug.WriteLine("EO_ID obtenido de BD: " + eoId.ToString());
                }
            }

            if (eoId == 0)
            {
                MostrarMensaje("No se pudo determinar la Unidad Organizacional del contrato vigente", "warning");
                return;
            }

            DataSet dsVigente2 = _precontrato.ObtenerContratoPorPersona(perId);

            if (dsVigente2 == null || dsVigente2.Tables.Count == 0 || dsVigente2.Tables[0].Rows.Count == 0)
            {
                MostrarMensaje("No hay contrato vigente para modificar", "warning");
                return;
            }
            DataRow contratoVigente = dsVigente2.Tables[0].Rows[0];

            int asIdVigente = Convert.ToInt32(contratoVigente["as_id"]);
            int caIdVigente = Convert.ToInt32(contratoVigente["ca_id"]);
            int caNumItemVigente = Convert.ToInt32(contratoVigente["ca_num_item"]);

            System.Diagnostics.Debug.WriteLine($"Contrato vigente: AS_ID={asIdVigente}, CA_ID={caIdVigente}, EO_ID={eoId}, ITEM={caNumItemVigente}");

            _precontrato.p_accion = "U1";
            _precontrato.pp_us_id = usuarioId;
            _precontrato.pp_per_id = perId;
            _precontrato.pp_es_id = esId;
            _precontrato.pp_eo_id = eoId;  
            _precontrato.pp_haber_basico = sueldo;
            _precontrato.pp_fecha_inicio = fechaInicio.ToString("dd/MM/yyyy");
            _precontrato.pp_fecha_fin = fechaFin.ToString("dd/MM/yyyy");
            _precontrato.pp_p_descripcion = txtDescripcionPuesto.Text.ToUpper().Trim();
            _precontrato.pp_pu_objetivo = txtObjetivo.Text.ToUpper().Trim();
            _precontrato.pp_p_funciones = txtFunciones.Text.ToUpper().Trim();
            _precontrato.pp_cite = string.IsNullOrWhiteSpace(txtCITE.Text) ? "N/A" : txtCITE.Text.Trim().ToUpper();

            _precontrato.pp_as_id = asIdVigente;
            _precontrato.pp_as_tipo_baja = "L";
            _precontrato.pp_as_memo_baja = 0;
            _precontrato.p_ca_id_actual = caIdVigente;
            _precontrato.p_ca_num_item = caNumItemVigente;
            _precontrato.p_ca_estado = "H";

            int nuevoAsId = _precontrato.CrearContrato();

            if (nuevoAsId <= 0)
            {
                string mensajeError = nuevoAsId == -1
                    ? "Error al obtener datos del contrato vigente"
                    : nuevoAsId == -2
                        ? "Error al dar de baja el contrato anterior"
                        : nuevoAsId == -3
                            ? "Error al crear el nuevo contrato"
                            : "Error desconocido al crear el nuevo contrato";

                MostrarMensaje(mensajeError, "danger");
                return;
            }

            System.Diagnostics.Debug.WriteLine($"Nuevo AS_ID creado: {nuevoAsId}");

            string numeroDocumento = string.IsNullOrWhiteSpace(txtCITE.Text) ? "N/A" : txtCITE.Text.Trim().ToUpper();
            string glosaCompleta = $"MODIFICACION DE CONTRATO - CITE: {numeroDocumento} - FECHA: {fechaInicio:dd/MM/yyyy}";

            _glosa.gl_valor_pk = nuevoAsId.ToString();
            _glosa.gl_nombre_pk = "as_id";
            _glosa.gl_tabla = "tbl_mp_asignacion";
            _glosa.gl_tipo_mov = 814;
            _glosa.gl_tipo_doc = 5;
            _glosa.gl_glosa = glosaCompleta;
            _glosa.gl_numero_doc = numeroDocumento;
            _glosa.gl_fecha_doc = fechaInicio;
            _glosa.gl_usuario = usuarioId;

            bool glosaGuardada = _glosa.Adicionar();

            if (!glosaGuardada)
            {
                System.Diagnostics.Debug.WriteLine(" Error al guardar la glosa");
                MostrarMensaje("Error al guardar la glosa", "warning");
                return;
            }

            System.Diagnostics.Debug.WriteLine("Glosa guardada correctamente");

            string script = @"
                Swal.fire({
                    title: '¡Éxito!',
                    text: 'Modificación registrada correctamente',
                    icon: 'success',
                    confirmButtonColor: '#28a745',
                    confirmButtonText: 'Aceptar'
                }).then((result) => {
                    if (result.isConfirmed) {
                        location.reload();
                    }
                });
            ";
            ScriptManager.RegisterStartupScript(this, GetType(), "ExitoModificacion", script, true);

            CargarContratoVigente(perId);
            CargarCargos();
            LimpiarCamposCargo();
        }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"ERROR: {ex.Message}");
            System.Diagnostics.Debug.WriteLine($"StackTrace: {ex.StackTrace}");
            MostrarMensaje($"Error al guardar: {ex.Message}", "danger");
        }
    }
    private string ObtenerDescripcion(string tabla, string id)
    {
        if (string.IsNullOrEmpty(id) || id == "0")
            return "";

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
        catch
        {
            return id;
        }
    }
    private string ValidarCampo(object valor)
    {
        return (valor == null || valor == DBNull.Value) ? "" : valor.ToString().Trim();
    }
    private void MostrarMensaje(string mensaje, string tipo)
    {
        string icono = tipo == "success" ? "fas fa-check-circle" :
                       tipo == "warning" ? "fas fa-exclamation-triangle" :
                       "fas fa-exclamation-circle";

        string color = tipo == "success" ? "success" :
                       tipo == "warning" ? "warning" :
                       "danger";

        string scriptNotify = $"$.notify({{ icon: '{icono}', message: '{mensaje.Replace("'", "\\'")}' }}, {{ type: '{color}', placement: {{ from: 'bottom', align: 'right' }}, delay: 3000 }});";
        ScriptManager.RegisterStartupScript(this, GetType(), "Notify_" + Guid.NewGuid().ToString(), scriptNotify, true);
    }
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.select2-search').select2({placeholder:{id:'0',text:'Seleccione...'},allowClear:true,width:'100%',language:{searching:function(){return 'Buscando...';},noResults:function(){return 'No se encontraron resultados';},inputTooShort:function(){return 'Ingrese al menos 1 carácter';}}});");
        sb.Append("$('.select2').select2({placeholder:{id:'0',text:'Seleccione...'}});");
        sb.Append("$('.select2-search').on('select2:select',function(e){var id=$(this).attr('id');if(id){setTimeout(function(){__doPostBack(id,'');},100);}});");
        sb.Append("$('.radios label').addClass('custom-control-label mb-3');");
        sb.Append("$('.radios input[type=\"radio\"]').addClass('custom-control-input mb-3');");
        sb.Append("</script>");

        ScriptManager.RegisterClientScriptBlock(this, GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void SetScript(string val) => SetScript(val, "");
}