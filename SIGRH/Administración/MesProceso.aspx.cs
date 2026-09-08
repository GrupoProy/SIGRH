using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Solution_Framework_Salarios.BussinessLogicLayer;
public partial class Administración_MesProceso : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                ProcesoActual();
                CargarMeses();
            }
        }
        else Response.Redirect("../Index");
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
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        sc = "$('#modalMesProceso').modal('hide'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    protected void btnActualizarMesProceso_Click(object sender, EventArgs e)
    {
        if (ddlMes.SelectedItem.Text != "Seleccione..")
        {
            cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
            if (proceso.ActualizarMesProceso(ddlMes.SelectedValue) > 0)
                sc = "Swal.fire({ icon: 'success', title: 'Se actualizó correctamente el mes de proceso', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalMesProceso').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            else
                sc = "$.notify({ icon: 'fa fa-info', message:'No se pudo realizar la operación, por favor consulte con el Administrador'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#modalMesProceso').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        }
    }
    protected void ProcesoActual()
    {
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        var detalleFuncionario = pla_proceso.ObtenerSalarioMinimo();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
                txt_pc_id.Text = detalleFuncionario.Tables[0].Rows[0]["pc_titulo"].ToString();
        }
    }

}