using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
public partial class Administración_PlanillaAdicional2 : System.Web.UI.Page
{
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                txt_ci.Focus();
                CargarMeses();
                CargarCasosAdicionales();
            }
        }
        else Response.Redirect("../Index");
    }
    private void CargarCasosAdicionales() {
        if (ddlMes.SelectedIndex > 0)
        {
            cls_mp_cargo cargo = new cls_mp_cargo();
            gvAdicionales.DataSource = cargo.MostrarCasosAdicionales(ObtenerCodigoProceso());
            gvAdicionales.DataBind();
            if (gvAdicionales.Rows.Count > 0)
                grillaAdicionales.Visible = true;
            else
                grillaAdicionales.Visible = false;
        }
    }
    private void CargarMeses()
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlMes.DataSource = proceso.ObtenerMesesProceso();
        ddlMes.Items.Add("Seleccione..");
        ddlMes.DataTextField = "pc_titulo";
        ddlMes.DataValueField = "pc_id";
        ddlMes.DataBind();
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.decimal').on('input', function (event) { this.value = this.value.replace(/[^0-9,]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
    private string ObtenerCodigoProceso()
    {
        //cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        //int gestion = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        //pla_proceso.pc_pr_id = gestion;
        //var detalleFuncionario = pla_proceso.ObtenerSalarioMinimo();
        //return detalleFuncionario.Tables[0].Rows[0]["pc_id"].ToString();
        return ddlMes.SelectedValue.ToString();
    }
    protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (ddlMes.SelectedIndex > 0)
        {
            if (e.CommandName == "Elegir")
            {
                cls_mp_cargo cargo = new cls_mp_cargo();
                int index = Convert.ToInt32(e.CommandArgument);
                string as_id = gvItems.DataKeys[index].Values[0].ToString();
                //string p_as_id = gvItems.DataKeys[index].Values[1].ToString();
                string cod_proceso = ObtenerCodigoProceso();
                if ((cargo.InsertarCasosParaAdicionales(cod_proceso, as_id)) == true)
                {
                    gvAdicionales.DataSource = cargo.MostrarCasosAdicionales(cod_proceso);
                    gvAdicionales.DataBind();
                    grillaAdicionales.Visible = true;
                    CargarItems();
                    sc = "$.notify({ icon: 'fa fa-check', message: 'Se adicionó correctamente el caso para Planilla salarial Adicional'},{type: 'success', placement: { from: 'bottom', align: 'right'} });";
                }
                else
                    sc = "$.notify({ icon: 'fa fa-info', message:'No se pudo adicionar el caso, consulte con el Administrador'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            }
        }
        else
            sc = "$.notify({ icon: 'fa fa-info', message:'Debe escoger un Mes para la Planilla Adicional...'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";

        SetScript(sc);
    }
    private void CargarItems()
    {
        cls_mp_cargo cargo = new cls_mp_cargo();
        int gestion = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;

        gvItems.DataSource = cargo.BuscarParaAdicionales(txt_ci.Text, ObtenerCodigoProceso());
        gvItems.DataBind();
        grillaItems.Visible = true;
    }
    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        if (txt_ci.Text != "")
        {
            CargarItems();
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message:'Por favor, busque un numero de CI'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
        }
        SetScript(sc);
    }

    protected void btnProcesar_Click(object sender, EventArgs e)
    {
        Session["cod_proceso_adicional"] = ddlMes.SelectedValue;

        if (gvAdicionales.Rows.Count > 0)
        {
            Session["secuencial_adicional"] = gvAdicionales.DataKeys[0].Values[2];
            Response.Redirect("../AdministracionDePersonal/ProcesoSueldosAdicionales.aspx");
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message:'No hay casos para Planilla Adicional..'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    protected void ddlMes_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarCasosAdicionales();
        SetScript(sc);

    }

    protected void gvAdicionales_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (ddlMes.SelectedIndex > 0)
        {
            if (e.CommandName == "Eliminar")
            {
                cls_mp_cargo cargo = new cls_mp_cargo();
                int index = Convert.ToInt32(e.CommandArgument);
                string ad_as_id = gvAdicionales.DataKeys[index].Values[0].ToString();
                string cod_proceso = gvAdicionales.DataKeys[index].Values[1].ToString();
                string secuencial = gvAdicionales.DataKeys[index].Values[2].ToString();

                if ((cargo.EliminarCasosAdicional(ad_as_id, cod_proceso, secuencial)) == true)
                {
                    sc = "$.notify({ icon: 'fa fa-info', message:'Se eliminó correctamente el caso para Planilla salarial Adicional'},{type: 'success', placement: { from: 'bottom', align: 'right'} });";
                    gvAdicionales.DataSource = cargo.MostrarCasosAdicionales(cod_proceso);
                    gvAdicionales.DataBind();
                    grillaAdicionales.Visible = true;

                    if (txt_ci.Text != "")
                        CargarItems();
                }
                else
                    sc = "$.notify({ icon: 'fa fa-info', message:'No se pudo eliminar el caso, consulte con el Administrador'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            }
        }
        else
            sc = "$.notify({ icon: 'fa fa-info', message:'Debe escoger un Mes para la Planilla Adicional...'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";

        SetScript(sc);
    }
}