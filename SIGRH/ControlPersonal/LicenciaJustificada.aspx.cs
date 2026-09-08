using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
// Punto IV definitivo: grupos 14600-14605 + compatibilidad JSON/postback.
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_LicenciaJustificada : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_cp_licencia_justificada _licencia = null;
    private string sc = "";

    private sealed class ConfiguracionLicenciaCatalogo
    {
        public string dia { get; set; }
        public string tipo { get; set; }
        public string modo { get; set; }
        public string control { get; set; }
        public object fraccion { get; set; }
    }

    private static ConfiguracionLicenciaCatalogo LeerConfiguracion(string json)
    {
        if (string.IsNullOrWhiteSpace(json)) return null;

        try
        {
            var serializer = new JavaScriptSerializer();
            object raiz = serializer.DeserializeObject(json);

            // Admite valores que hayan llegado doblemente serializados.
            if (raiz is string)
                raiz = serializer.DeserializeObject((string)raiz);

            object primerElemento = raiz;
            object[] arreglo = raiz as object[];
            if (arreglo != null)
                primerElemento = arreglo.Length > 0 ? arreglo[0] : null;

            ArrayList lista = raiz as ArrayList;
            if (lista != null)
                primerElemento = lista.Count > 0 ? lista[0] : null;

            var valores = primerElemento as Dictionary<string, object>;
            if (valores == null) return null;

            return new ConfiguracionLicenciaCatalogo
            {
                dia = Convert.ToString(ObtenerValor(valores, "dia"), CultureInfo.InvariantCulture),
                tipo = Convert.ToString(ObtenerValor(valores, "tipo"), CultureInfo.InvariantCulture),
                modo = Convert.ToString(ObtenerValor(valores, "modo"), CultureInfo.InvariantCulture),
                control = Convert.ToString(ObtenerValor(valores, "control"), CultureInfo.InvariantCulture),
                fraccion = ObtenerValor(valores, "fraccion")
            };
        }
        catch
        {
            return null;
        }
    }

    private static object ObtenerValor(Dictionary<string, object> valores, string nombre)
    {
        foreach (KeyValuePair<string, object> valor in valores)
        {
            if (string.Equals(valor.Key, nombre, StringComparison.OrdinalIgnoreCase))
                return valor.Value;
        }

        return null;
    }

    private static string Normalizar(string valor)
    {
        return (valor ?? string.Empty).Trim().ToUpperInvariant();
    }

    private string ResolverModoPantalla(string modoConfigurado, string tipoConfigurado)
    {
        int solicitudId;
        if (int.TryParse(Ddl_lj_tipo_solicitud.SelectedValue, out solicitudId))
        {
            // Grupos mostrados en el catálogo actual.
            if (solicitudId == 14600 || solicitudId == 14601 || solicitudId == 14603)
                return "H"; // Permiso personal, oficial y tolerancias.

            if (solicitudId == 14602 || solicitudId == 14604 || solicitudId == 14605)
                return "D"; // Asuetos, licencias y sin goce.
        }

        // Respaldo por nombre, por si los IDs cambian en otra instalación.
        string solicitud = Ddl_lj_tipo_solicitud.SelectedItem == null
            ? ""
            : Normalizar(Ddl_lj_tipo_solicitud.SelectedItem.Text);

        if (solicitud.Contains("LICENCIA") || solicitud.Contains("SIN GOCE"))
            return "D";

        if (solicitud.Contains("ASUETO")) return "D";
        if (solicitud.Contains("PERMISO") || solicitud.Contains("TOLERANCIA")) return "H";

        string modo = Normalizar(modoConfigurado);
        if (modo == "H" || modo == "D") return modo;

        // Último respaldo para registros antiguos que sólo tienen dia/tipo.
        return Normalizar(tipoConfigurado) == "H" ? "H" : "D";
    }

    private static string ClaveConfiguracion(int tipoLicencia, string campo)
    {
        return "LJ_CONFIG_" + tipoLicencia.ToString(CultureInfo.InvariantCulture) + "_" + campo;
    }

    private void GuardarConfiguracionEnViewState(
        int tipoLicencia,
        string modo,
        string tipo,
        string control,
        int fraccion)
    {
        ViewState[ClaveConfiguracion(tipoLicencia, "MODO")] = modo;
        ViewState[ClaveConfiguracion(tipoLicencia, "TIPO")] = tipo;
        ViewState[ClaveConfiguracion(tipoLicencia, "CONTROL")] = control;
        ViewState[ClaveConfiguracion(tipoLicencia, "FRACCION")] =
            fraccion.ToString(CultureInfo.InvariantCulture);
    }

    private string ObtenerConfiguracionSeleccionada(string campo)
    {
        if (Ddl_lj_tipo_licencia.SelectedItem == null) return "";

        string valor = Ddl_lj_tipo_licencia.SelectedItem.Attributes["data-" + campo.ToLowerInvariant()];
        if (!string.IsNullOrWhiteSpace(valor)) return Normalizar(valor);

        int tipoLicencia;
        if (!int.TryParse(Ddl_lj_tipo_licencia.SelectedValue, out tipoLicencia)) return "";

        return Normalizar(Convert.ToString(
            ViewState[ClaveConfiguracion(tipoLicencia, campo.ToUpperInvariant())],
            CultureInfo.InvariantCulture));
    }

    private static bool TryParseFecha(string texto, out DateTime fecha)
    {
        string[] formatos = { "dd/MM/yyyy", "d/M/yyyy", "yyyy-MM-dd" };
        return DateTime.TryParseExact(
            (texto ?? string.Empty).Trim(),
            formatos,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None,
            out fecha);
    }

    private static bool TryParseHora(string texto, out TimeSpan hora)
    {
        string[] formatos = { @"hh\:mm", @"h\:mm" };
        return TimeSpan.TryParseExact(
            (texto ?? string.Empty).Trim(),
            formatos,
            CultureInfo.InvariantCulture,
            out hora);
    }

    private void Notificar(string mensaje, string tipo = "warning")
    {
        string seguro = HttpUtility.JavaScriptStringEncode(mensaje ?? string.Empty);
        sc = "$.notify({ icon: 'fas fa-exclamation', message: '" + seguro + "' }, { type: '" + tipo + "' });";
        SetScript(sc, "");
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                cls_cp_licencia_justificada corresponde = new cls_cp_licencia_justificada();
                if (corresponde.VerificarSiCorrespondeBoletaComision(Convert.ToInt32(Session["per_id"].ToString())).Tables[0].Rows.Count > 0)
                {
                    Session["cod_licencia"] = 0;
                    BindGridView(Session["per_id"].ToString());
                    aviso.Visible = false;
                }
                else
                {
                    aviso.Visible = true;
                    BtnNuevo.Visible = false;
                }
            }
        }
        else Response.Redirect("../Index");
    }

    // ================= CARGA DE COMBOS =================
    private void BindDDLTipoSolicitud()
    {
        Ddl_lj_tipo_solicitud.Items.Clear();
        Ddl_lj_tipo_solicitud.Items.Insert(0, new ListItem("Seleccione...", "0"));
        _catalogo = new cls_catalogo { cat_tabla = "Tipo_Solicitud", cat_id_superior = 0 };
        DataSet ds = _catalogo.ObtenerTablaCombo();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Ddl_lj_tipo_solicitud.DataSource = ds.Tables[0];
            Ddl_lj_tipo_solicitud.DataValueField = "cat_id";
            Ddl_lj_tipo_solicitud.DataTextField = "cat_descripcion";
            Ddl_lj_tipo_solicitud.DataBind();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var item = Ddl_lj_tipo_solicitud.Items.FindByValue(row["cat_id"].ToString());
                if (item != null) item.Attributes["data-abrev"] = row["cat_abreviacion"].ToString();
            }
        }
    }

    private void BindDDLTipoLicenciaPorSolicitud(int solicitudId)
    {
        Ddl_lj_tipo_licencia.Items.Clear();
        Ddl_lj_tipo_licencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        _catalogo = new cls_catalogo { cat_tabla = "Tipo_Licencia", cat_id_superior = solicitudId };
        DataSet ds = _catalogo.ObtenerTablaCombo();
        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        {
            Ddl_lj_tipo_licencia.DataSource = ds.Tables[0];
            Ddl_lj_tipo_licencia.DataValueField = "cat_id";
            Ddl_lj_tipo_licencia.DataTextField = "cat_descripcion";
            Ddl_lj_tipo_licencia.DataBind();

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                var item = Ddl_lj_tipo_licencia.Items.FindByValue(row["cat_id"].ToString());
                if (item != null)
                {
                    string catAdicional = ds.Tables[0].Columns.Contains("cat_adicional")
                        ? row["cat_adicional"].ToString() : "";
                    ConfiguracionLicenciaCatalogo configuracion = LeerConfiguracion(catAdicional);

                    string tipo = configuracion == null ? "" : Normalizar(configuracion.tipo);
                    string modo = ResolverModoPantalla(
                        configuracion == null ? "" : configuracion.modo,
                        tipo);
                    string control = configuracion == null ? "" : Normalizar(configuracion.control);
                    if (string.IsNullOrEmpty(control)) control = "NINGUNO";
                    int fraccion = 1;

                    if (configuracion != null && configuracion.fraccion != null)
                    {
                        int fraccionConfigurada;
                        if (int.TryParse(Convert.ToString(configuracion.fraccion, CultureInfo.InvariantCulture), out fraccionConfigurada)
                            && fraccionConfigurada > 0)
                        {
                            fraccion = fraccionConfigurada;
                        }
                    }

                    item.Attributes["data-modo"] = modo;
                    item.Attributes["data-tipo"] = tipo;
                    item.Attributes["data-control"] = control;
                    item.Attributes["data-fraccion"] = fraccion.ToString(CultureInfo.InvariantCulture);

                    int tipoLicenciaId;
                    if (int.TryParse(row["cat_id"].ToString(), out tipoLicenciaId))
                        GuardarConfiguracionEnViewState(tipoLicenciaId, modo, tipo, control, fraccion);
                }
            }
        }
    }

    private void BindDDLPerIdAutoriza()
    {
        cls_cp_licencia_justificada licencia = new cls_cp_licencia_justificada();
        Ddl_lj_per_id_autoriza.DataSource = licencia.AutoridadesParaValidarComisiones();
        Ddl_lj_per_id_autoriza.DataTextField = "NOMBRES";
        Ddl_lj_per_id_autoriza.DataValueField = "PER_ID_AUTORIDAD";
        Ddl_lj_per_id_autoriza.DataBind();
        Ddl_lj_per_id_autoriza.Items.Insert(0, new ListItem("Seleccione...", "0"));
    }

    // ================= CASCADA SOLICITUD -> LICENCIA =================
    protected void Ddl_lj_tipo_solicitud_SelectedIndexChanged(object sender, EventArgs e)
    {
        Ddl_lj_tipo_licencia.Items.Clear();
        Ddl_lj_tipo_licencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        int solicitudId = Convert.ToInt32(Ddl_lj_tipo_solicitud.SelectedValue);

        pnlModoHoras.Visible = false;
        pnlModoDias.Visible = false;
        pnlSeleccioneTipo.Visible = true;
        lblConfiguracionTiempo.Text = "";
        lblSaldoDisponible.Text = "";
        Txt_lj_hora_salida.Text = string.Empty;
        Txt_lj_hora_retorno.Text = string.Empty;
        Txt_lj_fecha_inicio_rango.Text = string.Empty;
        Txt_lj_fecha_final.Text = string.Empty;

        if (solicitudId > 0)
        {
            BindDDLTipoLicenciaPorSolicitud(solicitudId);

            // Si la solicitud sólo tiene una licencia hija, se selecciona
            // automáticamente para que el bloque de tiempo no quede vacío.
            if (Ddl_lj_tipo_licencia.Items.Count == 2)
            {
                Ddl_lj_tipo_licencia.SelectedIndex = 1;
                ConfigurarTipoLicenciaSeleccionado();
            }
        }

        UpdatePanelLicencia.Update();
        SetScript(sc, "");
    }

    // ================= GRIDVIEW =================
    private void BindGridView(string per_id)
    {
        try
        {
            _licencia = new cls_cp_licencia_justificada();
            GvLista.DataSource = _licencia.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    private void BindForm(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var data = _asignacion.ObtenerTablaGrilla__AsignacionesPersonaComision("", per_id, "", "", "", "V", "", "", "", "", "", "", "", "").Tables[0];
        if (data.Rows.Count > 0)
        {
            Lt_per_id.Text = data.Rows[0]["per_nombres"].ToString().Trim() + " " + data.Rows[0]["per_ap_paterno"].ToString().Trim() + " " + data.Rows[0]["per_ap_materno"].ToString().Trim();
            Lt_per_num_doc.Text = data.Rows[0]["per_num_doc"].ToString().Trim() + " " + data.Rows[0]["cat_abreviacion"].ToString().Trim();
            Lt_ca_num_item.Text = data.Rows[0]["ca_ti_item"].ToString().Trim() + "" + data.Rows[0]["ca_num_item"].ToString().Trim();
            Lt_as_fecha_inicio.Text = Convert.ToDateTime(data.Rows[0]["as_fecha_inicio"]).ToString("dd/MM/yyyy").Trim();
            Lt_as_fecha_fin.Text = (string.IsNullOrEmpty(data.Rows[0]["as_fecha_fin"].ToString())) ? "" : Convert.ToDateTime(data.Rows[0]["as_fecha_fin"]).ToString("dd/MM/yyyy").Trim();
            Lt_es_descripcion.Text = data.Rows[0]["es_descripcion"].ToString().Trim();
        }
    }

    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) GvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvLista.FooterRow != null) GvLista.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();
        if (e.CommandName.Equals("GetDelete"))
        {
            _licencia = new cls_cp_licencia_justificada { lj_id = Convert.ToInt32(code) };
            if (_licencia.Eliminar() > 0)
            {
                BindGridView(Session["per_id"].ToString());
                sc = "$.notify({ icon: 'fas fa-check', message: 'Registro anulado correctamente...!!' }, { type: 'success' });";
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-check', message: 'No se ha podido eliminar el registro' }, { type: 'warning' });";
            }
        }
        if (e.CommandName.Equals("GetPrint"))
        {
            Session["cod_licencia"] = code;
            sc = "window.open('ImpresionLicencias.aspx', 'width=300,height=300', '_blank');";
        }
        SetScript(sc, ", dropdownParent: $('#addModal')");
    }

    protected void GvLista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[5].Text == "VALIDADO") e.Row.ForeColor = System.Drawing.Color.Green;
        }
    }

    // ================= MODAL =================
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        BindForm(Session["per_id"].ToString());
        BindDDLTipoSolicitud();
        BindDDLPerIdAutoriza();
        if (Ddl_lj_tipo_solicitud.Items.Count > 1)
        {
            Ddl_lj_tipo_solicitud.SelectedIndex = 1;
            Ddl_lj_tipo_solicitud_SelectedIndexChanged(null, null);
        }
        if (!string.IsNullOrEmpty(Lt_as_fecha_fin.Text)) sc = "$('#d_as_ff').css('display', 'block');";
        ScriptManager.RegisterStartupScript(this, this.GetType(), "OpenModal", "$('#addModal').modal('show');", true);
        SetScript(sc, ", dropdownParent: $('#addModal')");
    }

    // CONSULTA SALDO
    private static string FormatearSaldo(decimal valor, string tipo)
    {
        if (Normalizar(tipo) != "H")
            return valor.ToString("0.##", CultureInfo.CurrentCulture) + " día(s)";

        int minutosTotales = Convert.ToInt32(
            Math.Round(Math.Max(0m, valor) * 60m, 0, MidpointRounding.AwayFromZero));
        int horas = minutosTotales / 60;
        int minutos = minutosTotales % 60;

        if (horas > 0 && minutos > 0) return horas + " h " + minutos + " min";
        if (horas > 0) return horas + " h";
        return minutos + " min";
    }

    private void MostrarSaldoDisponible(int tipoLicencia)
    {
        if (tipoLicencia == 0) { lblSaldoDisponible.Text = ""; return; }
        try
        {
            int perId = Convert.ToInt32(Session["per_id"]);
            cls_cp_licencia_justificada obj = new cls_cp_licencia_justificada();
            DataSet ds = obj.ObtenerSaldoLicencia(perId, tipoLicencia);
            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                var row = ds.Tables[0].Rows[0];
                object saldoDato = row["SaldoDisponible"];
                string saldo = Convert.ToString(saldoDato, CultureInfo.InvariantCulture);
                string tipo = Normalizar(row["TipoLimite"].ToString());
                string control = ds.Tables[0].Columns.Contains("Control") ? Normalizar(row["Control"].ToString()) : "";
                string mensajeError = ds.Tables[0].Columns.Contains("MensajeError")
                    ? row["MensajeError"].ToString() : "";

                if (!string.IsNullOrWhiteSpace(mensajeError))
                {
                    lblSaldoDisponible.Text = "⚠️ " + HttpUtility.HtmlEncode(mensajeError);
                    lblSaldoDisponible.CssClass = "form-text text-danger font-weight-bold";
                    return;
                }

                if (saldo == "Ilimitado")
                {
                    lblSaldoDisponible.Text = "✔️ Sin límite para este tipo.";
                    lblSaldoDisponible.CssClass = "form-text text-success font-weight-bold";
                }
                else
                {
                    decimal valor = Convert.ToDecimal(saldoDato, CultureInfo.InvariantCulture);
                    string cantidad = FormatearSaldo(valor, tipo);

                    if (control == "EVENTO")
                    {
                        lblSaldoDisponible.Text = "ℹ️ Máximo permitido por evento: " + cantidad + ".";
                        lblSaldoDisponible.CssClass = "form-text text-info font-weight-bold";
                    }
                    else if (valor <= 0)
                    {
                        lblSaldoDisponible.Text = "⚠️ No le queda saldo este mes/año.";
                        lblSaldoDisponible.CssClass = "form-text text-danger font-weight-bold";
                    }
                    else
                    {
                        string periodo = control == "ACUM_M" ? " del mes actual" :
                                         control == "ACUM_A" ? " del año actual" : "";
                        lblSaldoDisponible.Text = "✔️ Saldo disponible" + periodo + ": " + cantidad + ".";
                        lblSaldoDisponible.CssClass = "form-text text-success font-weight-bold";
                    }
                }
            }
            else lblSaldoDisponible.Text = "No se pudo consultar el saldo.";
        }
        catch (Exception ex)
        {
            lblSaldoDisponible.Text = "Error al consultar saldo: " + ex.Message;
            lblSaldoDisponible.CssClass = "form-text text-danger";
        }
    }

    private void ConfigurarTipoLicenciaSeleccionado()
    {
        int tipoLicencia;
        bool seleccionValida = int.TryParse(Ddl_lj_tipo_licencia.SelectedValue, out tipoLicencia)
                               && tipoLicencia > 0;

        pnlModoHoras.Visible = false;
        pnlModoDias.Visible = false;
        pnlSeleccioneTipo.Visible = !seleccionValida;
        lblConfiguracionTiempo.Text = "";
        lblSaldoDisponible.Text = "";

        if (!seleccionValida) return;

        string modo = ObtenerConfiguracionSeleccionada("MODO");
        string tipo = ObtenerConfiguracionSeleccionada("TIPO");

        // Algunos navegadores/postbacks no conservan atributos agregados a
        // los ListItem. Si tampoco llegaron por ViewState, se recarga el
        // catálogo y se restaura la opción seleccionada.
        if (modo != "H" && modo != "D")
        {
            string valorSeleccionado = Ddl_lj_tipo_licencia.SelectedValue;
            int solicitudId;
            if (int.TryParse(Ddl_lj_tipo_solicitud.SelectedValue, out solicitudId) && solicitudId > 0)
            {
                BindDDLTipoLicenciaPorSolicitud(solicitudId);
                ListItem opcion = Ddl_lj_tipo_licencia.Items.FindByValue(valorSeleccionado);
                if (opcion != null) Ddl_lj_tipo_licencia.SelectedValue = valorSeleccionado;

                modo = ObtenerConfiguracionSeleccionada("MODO");
                tipo = ObtenerConfiguracionSeleccionada("TIPO");
            }
        }

        // El grupo de solicitud define la presentación del punto IV.
        modo = ResolverModoPantalla(modo, tipo);
        if (modo != "H" && modo != "D") modo = "D";

        pnlSeleccioneTipo.Visible = false;
        pnlModoDias.Visible = true;
        pnlModoHoras.Visible = modo == "H";
        MostrarSaldoDisponible(tipoLicencia);
    }

    protected void Ddl_lj_tipo_licencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        Txt_lj_hora_salida.Text = string.Empty;
        Txt_lj_hora_retorno.Text = string.Empty;
        Txt_lj_fecha_inicio_rango.Text = string.Empty;
        Txt_lj_fecha_final.Text = string.Empty;

        ConfigurarTipoLicenciaSeleccionado();
        UpdatePanelLicencia.Update();
    }

    // ================= GUARDAR =================
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        int tipoLicencia;
        if (!int.TryParse(Ddl_lj_tipo_licencia.SelectedValue, out tipoLicencia) || tipoLicencia <= 0)
        {
            Notificar("Debe seleccionar un tipo de licencia.");
            return;
        }

        string modo = ObtenerConfiguracionSeleccionada("MODO");
        string tipoConfigurado = ObtenerConfiguracionSeleccionada("TIPO");
        modo = ResolverModoPantalla(modo, tipoConfigurado);
        if (modo != "H" && modo != "D") modo = "D";

        if (Ddl_lj_per_id_autoriza.SelectedValue == "0")
        {
            Notificar("Debe seleccionar al inmediato superior que autorizará la solicitud.");
            return;
        }

        string motivoSeleccionado = "";
        if (rbInstitucional.Checked) motivoSeleccionado = "INSTITUCIONAL";
        else if (rbPersonal.Checked) motivoSeleccionado = "PERSONAL";
        else if (rbSalud.Checked) motivoSeleccionado = "SALUD";

        if (string.IsNullOrEmpty(motivoSeleccionado))
        {
            Notificar("Debe seleccionar un motivo.");
            return;
        }

        if (string.IsNullOrWhiteSpace(Txt_lj_justificacion.Text))
        {
            Notificar("Debe registrar la justificación.");
            return;
        }

        if (string.IsNullOrWhiteSpace(Txt_lj_lugar.Text))
        {
            Notificar("Debe registrar el lugar.");
            return;
        }

        _licencia = new cls_cp_licencia_justificada();
        var code = _licencia.lj_id;
        DateTime fec_ini, fec_fin;
        DateTime? hor_sal = null, hor_ret = null;

        // El punto IV siempre solicita un rango de fechas.
        if (!TryParseFecha(Txt_lj_fecha_inicio_rango.Text, out fec_ini)
            || !TryParseFecha(Txt_lj_fecha_final.Text, out fec_fin))
        {
            Notificar("Ingrese fechas válidas en formato dd/mm/aaaa.");
            return;
        }

        fec_ini = fec_ini.Date;
        fec_fin = fec_fin.Date;
        if (fec_fin < fec_ini)
        {
            Notificar("La fecha hasta no puede ser menor a la fecha desde.");
            return;
        }

        // Los tipos en modo H solicitan además hora de salida y retorno.
        if (modo == "H")
        {
            TimeSpan horaSalida;
            TimeSpan horaRetorno;
            if (!TryParseHora(Txt_lj_hora_salida.Text, out horaSalida)
                || !TryParseHora(Txt_lj_hora_retorno.Text, out horaRetorno))
            {
                Notificar("Ingrese horas válidas en formato HH:mm.");
                return;
            }

            hor_sal = fec_ini + horaSalida;
            hor_ret = fec_ini + horaRetorno;

            int diferenciaMinutos = Convert.ToInt32((hor_ret.Value - hor_sal.Value).TotalMinutes);
            if (diferenciaMinutos <= 0)
            {
                Notificar("La hora de retorno debe ser mayor a la hora de salida.");
                return;
            }

            int fraccion = 1;
            int fraccionConfigurada;
            if (int.TryParse(ObtenerConfiguracionSeleccionada("FRACCION"), out fraccionConfigurada)
                && fraccionConfigurada > 0)
            {
                fraccion = fraccionConfigurada;
            }

            if (diferenciaMinutos < fraccion || diferenciaMinutos % fraccion != 0)
            {
                Notificar("El tiempo solicitado debe registrarse en fracciones de " + fraccion + " minutos.");
                return;
            }
        }

        if (fec_ini < DateTime.Today)
        {
            Notificar("No se pueden registrar licencias de días pasados.");
            return;
        }

        _licencia = new cls_cp_licencia_justificada
        {
            lj_id = code,
            lj_per_id = Convert.ToInt32(Session["per_id"]),
            lj_tipo_licencia = tipoLicencia,
            lj_fecha_inicial = fec_ini,
            lj_fecha_final = fec_fin,
            lj_hora_salida = hor_sal ?? fec_ini,
            lj_hora_retorno = hor_ret ?? fec_ini,
            lj_motivo = motivoSeleccionado + "-" + Txt_lj_justificacion.Text.ToUpper().Trim(),
            lj_lugar = Txt_lj_lugar.Text.ToUpper().Trim(),
            lj_per_id_autoriza = Ddl_lj_per_id_autoriza.SelectedValue,
            lj_estado = "P"
        };

        int resultado = _licencia.Adicionar();
        if (resultado == -2)
        {
            Notificar("La solicitud excede el saldo disponible.");
            return;
        }
        else if (resultado == -3)
        {
            Notificar("La fecha seleccionada ya no es válida porque es anterior a hoy.");
            return;
        }
        else if (resultado == -4)
        {
            Notificar("Las fechas u horas enviadas no son válidas.");
            return;
        }
        else if (resultado == -5)
        {
            Notificar("El tiempo no cumple la fracción mínima configurada.");
            return;
        }
        else if (resultado == -6)
        {
            Notificar("La configuración del catálogo de esta licencia es inválida. Comuníquese con Personal.");
            return;
        }
        else if (resultado <= 0)
        {
            Notificar("No se pudo registrar la solicitud.", "danger");
            return;
        }

        Session["cod_licencia"] = resultado;
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#addModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); window.open('ImpresionLicencias.aspx', 'width=300,height=300', '_blank');";
        Limpiar("frm_lic_cl");
        BindGridView(Session["per_id"].ToString());
        SetScript(sc, ", dropdownParent: $('#addModal')");
    }

    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar("frm_lic_cl");
        sc = "$('#addModal').modal('hide');";
        SetScript(sc, "");
    }

    // ================= SCRIPTS Y LIMPIEZA =================
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {'sProcessing': 'Procesando...','sLengthMenu': 'Mostrar _MENU_ registros','sZeroRecords': 'No se encontraron resultados','sEmptyTable': 'Ningún dato disponible en esta tabla','sInfo': 'Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros','sInfoEmpty': 'Mostrando registros del 0 al 0 de un total de 0 registros','sInfoFiltered': '(filtrado de un total de _MAX_ registros)','sInfoPostFix': '','sSearch': 'Buscar:','sUrl': '','sInfoThousands': ',','sLoadingRecords': 'Cargando...','oPaginate': {'sFirst': '«','sLast': '»','sNext': '<i class=\"fas fa-angle-right\"></i>','sPrevious': '<i class=\"fas fa-angle-left\"></i>'},'oAria': {'sSortAscending': ': Activar para ordenar la columna de manera ascendente','sSortDescending': ': Activar para ordenar la columna de manera descendente'}},'ordering': false,'searching': true,'autoWidth': false,'orderCellsTop': true,'fixedHeader': true});");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, ''); });");
        sb.Append("$('.tooltip').css('display', 'none'); $('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$('.radios label').addClass('custom-control-label mb-3'); $('.radios input[type=\"radio\"]').addClass('custom-control-input mb-3');");
        sb.Append("$(function () { $(\"body\").delegate(\".datepickerD\", \"focusin\", function () { $(this).datepicker({ format: \"dd/mm/yyyy\", autoclose: true, language: 'es' }); }); var me = $(\".datepickerD\"); me.mask('99/99/9999'); });");
        sb.Append("$(function () { var me = $(\".timepickerD\"); me.mask(\"99:99\"); });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void Limpiar(string val)
    {
        if (val.Equals("gv_cl")) { GvLista.DataSource = null; GvLista.DataBind(); }
        else if (val.Equals("frm_lic_cl"))
        {
            Ddl_lj_tipo_solicitud.SelectedIndex = 0;
            Ddl_lj_tipo_licencia.Items.Clear();
            Txt_lj_fecha_inicio_rango.Text = string.Empty;
            Txt_lj_fecha_final.Text = string.Empty;
            Txt_lj_hora_salida.Text = string.Empty;
            Txt_lj_hora_retorno.Text = string.Empty;
            Txt_lj_justificacion.Text = string.Empty;
            Txt_lj_lugar.Text = string.Empty;
            Ddl_lj_per_id_autoriza.SelectedIndex = 0;
            rbInstitucional.Checked = false;
            rbPersonal.Checked = false;
            rbSalud.Checked = false;
            lblSaldoDisponible.Text = "";
            lblConfiguracionTiempo.Text = "";
            pnlSeleccioneTipo.Visible = true;
            pnlModoHoras.Visible = false;
            pnlModoDias.Visible = false;
        }
    }
}
