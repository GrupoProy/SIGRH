using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_Kardex.BussinessLogicLayer;

public partial class Kardex_AdmFiliacionUpdate : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] == null ||
            HttpContext.Current.Session["per_id"].ToString() == "")
        {
            Response.Redirect("../Index");
        }

    }

    // ═══════════════ BÚSQUEDA ═══════════════

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {
            // Validar que al menos un filtro tenga valor
            if (string.IsNullOrEmpty(Txt_ap_paterno_b.Text) &&
                string.IsNullOrEmpty(Txt_ap_materno_b.Text) &&
                string.IsNullOrEmpty(Txt_nombres_b.Text) &&
                string.IsNullOrEmpty(Txt_ci_b.Text) &&
                string.IsNullOrEmpty(Txt_per_id_b.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar al menos un criterio de búsqueda...!!' }, { type: 'warning' });";
                SetScript(sc);
                return;
            }

            var adm = new cls_adm_filiacion();
            DataSet ds = adm.BuscarPersonasConDDJJ(
                Txt_nombres_b.Text.Trim(),
                Txt_ap_paterno_b.Text.Trim(),
                Txt_ap_materno_b.Text.Trim(),
                Txt_ci_b.Text.Trim(),
                Txt_per_id_b.Text.Trim());

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                ViewState["ResultadosDDJJ"] = ds.Tables[0];
                Gv_busqueda_lista.DataSource = ds.Tables[0];
                Gv_busqueda_lista.DataBind();
                P_busqueda_lista.Visible = true;
            }
            else
            {
                ViewState["ResultadosDDJJ"] = null;
                Gv_busqueda_lista.DataSource = null;
                Gv_busqueda_lista.DataBind();
                P_busqueda_lista.Visible = false;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se encontraron registros...!!' }, { type: 'warning' });";
            }
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error: " + LimpiarJS(ex.Message) + "' }, { type: 'danger' });";
        }
        SetScript(sc);
    }

    // ═══════════════ GRILLA ═══════════════

    protected void Gv_busqueda_lista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_busqueda_lista.Rows.Count > 0)
        {
            if (Gv_busqueda_lista.HeaderRow != null)
                Gv_busqueda_lista.HeaderRow.TableSection = TableRowSection.TableHeader;

            if (Gv_busqueda_lista.FooterRow != null)
                Gv_busqueda_lista.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void Gv_busqueda_lista_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // ✅ Leer el estado desde 'dj_estado' (V/F) para el coloreado
            string estadoCodigo = DataBinder.Eval(e.Row.DataItem, "dj_estado").ToString();

            // ✅ Índice de la columna 'estado_descripcion' (empezando de 0)
            int colEstado = 7;

            if (estadoCodigo == "V")
            {
                e.Row.Cells[colEstado].BackColor = System.Drawing.Color.LightGreen;
                e.Row.Cells[colEstado].ForeColor = System.Drawing.Color.DarkGreen;
                e.Row.Cells[colEstado].Font.Bold = true;
            }
            else if (estadoCodigo == "F")
            {
                e.Row.Cells[colEstado].BackColor = System.Drawing.Color.LightCoral;
                e.Row.Cells[colEstado].ForeColor = System.Drawing.Color.DarkRed;
                e.Row.Cells[colEstado].Font.Bold = true;
            }
        }
    }

    protected void Gv_busqueda_lista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName != "EditarEstado") return;

            int index = Convert.ToInt32(e.CommandArgument);
            int dj_id = Convert.ToInt32(Gv_busqueda_lista.DataKeys[index].Value);

            // Cargar datos del registro para mostrar en el modal
            DataTable dt = ViewState["ResultadosDDJJ"] as DataTable;
            if (dt == null) return;

            DataRow row = dt.Rows[index];

            Hf_dj_id.Value = dj_id.ToString();
            Hf_per_id_estado.Value = row["per_id"].ToString();

            Lt_nombre_estado.Text = $"{row["apellido_paterno"]} {row["apellido_materno"]} {row["nombre"]}".Trim();
            Lt_ci_estado.Text = row["ci"].ToString();
            Lt_per_id_estado.Text = row["per_id"].ToString();
            Lt_gestion_estado.Text = row["dj_gestion"].ToString();
            //Lt_estado_actual.Text = row["dj_estado"].ToString();
            Lt_estado_actual.Text = row["estado_descripcion"].ToString();

            // Resetear combo
            Ddl_nuevo_estado.SelectedIndex = 0;

            sc = "$('#estadoModal').modal('show');";
            SetScript(sc);
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error: " + LimpiarJS(ex.Message) + "' }, { type: 'danger' });";
            SetScript(sc);
        }
    }

    // ═══════════════ MODAL: ESTADÍSTICAS ═══════════════

    protected void BtnEstadisticas_Click(object sender, EventArgs e)
    {
        try
        {
            var adm = new cls_adm_filiacion();
            DataSet ds = adm.ObtenerResumenDDJJ();

            if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
            {
                DataRow row = ds.Tables[0].Rows[0];

                Lt_total_personas.Text = row["total_personas"].ToString();
                Lt_total_vigentes.Text = row["total_vigentes"].ToString();
                Lt_total_finalizadas.Text = row["total_finalizadas"].ToString();
                Lt_total_sin_declaracion.Text = row["total_sin_declaracion"].ToString();
            }
            else
            {
                Lt_total_personas.Text = "0";
                Lt_total_vigentes.Text = "0";
                Lt_total_finalizadas.Text = "0";
                Lt_total_sin_declaracion.Text = "0";
            }

            sc = "$('#estadisticasModal').modal('show');";
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error: " + LimpiarJS(ex.Message) + "' }, { type: 'danger' });";
        }
        SetScript(sc);
    }

    protected void BtnCerrarEstadisticas_Click(object sender, EventArgs e)
    {
        sc = "$('#estadisticasModal').modal('hide');";
        SetScript(sc);
    }
    // ═══════════════ MODAL: GUARDAR / CANCELAR ESTADO ═══════════════

    protected void BtnGuardarEstado_Click(object sender, EventArgs e)
    {
        try
        {
            if (string.IsNullOrEmpty(Hf_dj_id.Value))
                throw new Exception("No se pudo identificar la DDJJ.");

            if (string.IsNullOrEmpty(Ddl_nuevo_estado.SelectedValue))
                throw new Exception("Debe seleccionar un nuevo estado.");

            int dj_id = Convert.ToInt32(Hf_dj_id.Value);
            string nuevoEstado = Ddl_nuevo_estado.SelectedValue;
            int usuarioMod = Convert.ToInt32(Session["per_id"].ToString());

            var adm = new cls_adm_filiacion();
            bool exito = adm.CambiarEstado(dj_id, nuevoEstado, usuarioMod);

            if (exito)
            {
                sc = "$.notify({ icon: 'fas fa-check', message: 'Estado actualizado correctamente...!!' }, { type: 'success' });";
                sc += "$('#estadoModal').modal('hide');";

                // Refrescar la búsqueda
                BtnBuscar_Click(sender, e);
            }
            else
            {
                throw new Exception("No se pudo actualizar el estado.");
            }
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error: " + LimpiarJS(ex.Message) + "' }, { type: 'danger' });";
        }
        SetScript(sc);
    }

    protected void BtnCancelarEstado_Click(object sender, EventArgs e)
    {
        Hf_dj_id.Value = "";
        Hf_per_id_estado.Value = "";
        Ddl_nuevo_estado.SelectedIndex = 0;

        sc = "$('#estadoModal').modal('hide');";
        SetScript(sc);
    }

    // ═══════════════ HELPERS ═══════════════

    /// Escapa comillas y saltos de línea para usar en JS.

    private string LimpiarJS(string mensaje)
    {
        return mensaje.Replace("'", "").Replace("\"", "").Replace("\r", " ").Replace("\n", " ");
    }

    /// Registra un script JS en el cliente.
    private void SetScript(string val)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.numero').on('input', function () {" +
                    "this.value = this.value.replace(/[^0-9]/g, '');" +
                  "});");
        sb.Append("$('.letras').on('input', function () {" +
                    "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
                  "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }
}