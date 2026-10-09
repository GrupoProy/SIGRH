using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Kardex.BussinessLogicLayer;

public partial class Cheques_ChequeDetallado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string algo = Request.QueryString["pago_id1"].ToString();
        InformacionCheque(Convert.ToInt32(algo));
    }
    private void InformacionCheque(int pago_id)
    {
        cls_kd_finiquito2 finiquito2 = new cls_kd_finiquito2();
        var cheque = finiquito2.DetalleCheque(pago_id);
        if (cheque.Tables.Count > 0)
        {
            if (cheque.Tables[0].Rows.Count > 0)
            {
                var detalle = cheque.Tables[0].Rows[0];
                ltl_preventivo.Text = validarCampo(detalle["preventivo"]);
                ltl_comp.Text = validarCampo(detalle["compromiso"]);
                ltl_deve.Text = validarCampo(detalle["devengado"]);
                ltl_nombre_proce.Text = validarCampo(detalle["proceso_nombre"]);
                ltl_proc_fech_ini.Text = validarCampo(detalle["proceso_fecha_inicio"]);
                ltl_proce_descri.Text = validarCampo(detalle["proceso_descripcion"]);
                ltl_proce_esta.Text = validarCampo(detalle["proceso_estado"]);
                ltl_gesti.Text = validarCampo(detalle["gestion"]);
                ltl_gest_id.Text = validarCampo(detalle["gestion_id"]);
                ltl_bene_id.Text = validarCampo(detalle["benef_id"]);
                ltl_numcont.Text = validarCampo(detalle["num_contrato"]);
                ltl_adju_fech.Text = validarCampo(detalle["adjudicacion_fecha"]);
                ltl_nro_cheque.Text = validarCampo(detalle["num_cheque"]);
                ltl_adj_mont.Text = validarCampo(detalle["Monto_Adjudicado"]);
                ltl_benf_ci.Text = validarCampo(detalle["benef_nit_ci"]);
                ltl_ben_raz.Text = validarCampo(detalle["benef_razon_social"]);
                ltl_idsol.Text = validarCampo(detalle["per_id"]);
                ltl_soli_nom.Text = validarCampo(detalle["Nombre_solicitante"]);
                ltl_soli_carg.Text = validarCampo(detalle["cargo"]);
                ltl_solpu.Text = validarCampo(detalle["puesto"]);
                ltl_factu.Text = validarCampo(detalle["factura"]);
                ltl_pag_fech_fact.Text = validarCampo(detalle["fecha_factura"]);
                ltl_fechpago.Text = validarCampo(detalle["fecha_pago"]);
                ltl_pagdes.Text = validarCampo(detalle["descripcion"]);
                ltl_pagmon.Text = validarCampo(detalle["Monto_Pagado"]);
                ltl_ben_rep.Text = validarCampo(detalle["benef_rep_legal"]);
                ltl_pago_id.Text = validarCampo(pago_id);
            }
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
}