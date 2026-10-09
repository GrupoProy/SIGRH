using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Microsoft.Reporting.WebForms;

public partial class Administración_AsignacionAdicionalDocentes : System.Web.UI.Page
{
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarGridviewAsignacionesAdicionales();
        }
    }
    protected void CargarGridviewAsignacionesAdicionales()
    {
        cls_pla_docentes_adicional adicional = new cls_pla_docentes_adicional();
        GvLista.DataSource = adicional.ObtenerTodasAsignacionesAdicionalesDocentes();
        GvLista.DataBind();
        if (GvLista.Rows.Count > 0)
            BtnProcesar.Visible = true;
        else
        {
            BtnProcesar.Visible = false;
            sc = "$.notify({ icon: 'ni ni-bell-55', message: 'No hay asignaciones para procesar...!!' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }
    }
    private void SetScript(string data, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: 'es'" +
                    "});" +
                "});" +
                "var me = $(\".datepickerD\");" +
                "me.mask('99/99/9999');" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
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

    protected void BtnProcesar_Click(object sender, EventArgs e)
    {
        cls_pla_docentes_adicional adicional = new cls_pla_docentes_adicional();
        if (adicional.ProcesarAsignacionesAdicionales())
        {

            P_lista.Visible = false;
            BtnProcesar.Visible = false;
            sc = "$.notify({ icon: 'ni ni-bell-55', message: 'Se procesaron correctamente los registros...!!' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }
    }

    protected void BtnReporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteAsignacionDocenteAdicional.aspx");
    }
}