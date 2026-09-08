using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class Configuraciones_MigrarEscalaPuesto : System.Web.UI.Page
{
    private cls_escala_puesto epu = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ltl_gestion.Text = Session["gestion"].ToString();
            validarMigracion();
        }
    }
    private void validarMigracion()
    {
        epu = new cls_escala_puesto();
        epu.es_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var detalle_ep = epu.ValidarEP();
        if (detalle_ep.Tables[0].Rows.Count > 0)
        {
            no_existe_ep.Visible = true;
            existe_ep.Visible = false;
            btn_migrar_escala.Visible = false;
        }
        else
        {
            no_existe_ep.Visible = false;
            existe_ep.Visible = true;
            btn_migrar_escala.Visible = true;
        }
    }

    protected void btn_migrar_escala_Click(object sender, EventArgs e)
    {
        epu = new cls_escala_puesto();
        epu.es_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var detalle_ep = epu.ObtenerGrillaEscalaPuesto();
        int aux = detalle_ep.Tables[0].Rows.Count;
        if (detalle_ep.Tables[0].Rows.Count > 0)
        {
            var escala_puesto = detalle_ep.Tables[0].Rows;
            for (int i= 0; i < escala_puesto.Count; i++)
            {
                epu.epu_es_id = Convert.ToInt32(validarCampo(escala_puesto[i]["epu_es_id"]));
                epu.epu_p_id = Convert.ToInt32(validarCampo(escala_puesto[i]["epu_p_id"]));
                epu.epu_tipo = "CONTRATO";
                epu.Adicionar();
            }
            validarMigracion();
            sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Se migro los datos correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalGlosa').modal('hide'); $('#modalNuevoExamen').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            SetScript(sc);
        } else
        {
            sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, no existe la escala salarial del periodo seleccionado.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }
    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
}