using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administración_ReporteAsignacionDocenteAdicional : System.Web.UI.Page
{
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarInfoDropdown();
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

    private void CargarInfoDropdown()
    {
        cls_pla_docentes_adicional docentes = new cls_pla_docentes_adicional();
        //ddlMesPlanilla.Items.Add("Seleccione...");
        //ddlMesPlanilla.Items.Add("EXAMEN DE MESA");
        //ddlMesPlanilla.Items.Add("CURSO DE TEMPORADA");
        //ddlMesPlanilla.DataBind();
        ddlMesPlanilla.DataSource = docentes.ObtenerAsignacionAdicionalDocentes();
        ddlMesPlanilla.DataTextField = "cat_descripcion";
        ddlMesPlanilla.DataValueField = "cat_abreviacion";
        ddlMesPlanilla.DataBind();

        ddlTipoPersonal.DataSource = docentes.ObtenerPeriodoAsignacionesAdicionales();
        ddlTipoPersonal.DataTextField = "cat_descripcion";
        ddlTipoPersonal.DataBind();
    }
    protected void CargarReporte()
    {
        string tipo = "";
        if (ddlMesPlanilla.SelectedItem.Text == "EXAMEN DE MESA")
        {
            tipo = "MESA";
        }
        if (ddlMesPlanilla.SelectedItem.Text == "CURSO DE TEMPORADA")
        {
            tipo = "CURSO";
        }
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://DESKTOP-GUS:8008/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/REPORTE_DOCENTES_ADICIONAL_UAP";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("tipo_planilla", tipo, false));
        paramList.Add(new ReportParameter("PERIODO", ddlTipoPersonal.SelectedItem.Text.ToString(), false));
        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;

        ReportViewer1.ServerReport.Refresh();
    }

    protected void ddlTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string tipo = "";
        //if (ddlMesPlanilla.SelectedItem.Text == "EXAMEN DE MESA") tipo = "MESA";
        //if (ddlMesPlanilla.SelectedItem.Text == "CURSO DE TEMPORADA") tipo = "CURSO";
        //sc = "$.notify({ icon: 'ni ni-bell-55', message: '"+ tipo +"' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
        //SetScript(sc, "");
        ////if (ddlMesPlanilla.SelectedIndex != 0 && ddlTipoPersonal.SelectedIndex != 0)
        ////{
        ////    CargarReporte();
        ////}

    }

    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        //string tipo = "";
        //if (ddlMesPlanilla.SelectedItem.Text == "EXAMEN DE MESA") tipo = "MESA";
        //if (ddlMesPlanilla.SelectedItem.Text == "CURSO DE TEMPORADA") tipo = "CURSO";
        //sc = "$.notify({ icon: 'ni ni-bell-55', message: '" + tipo + "' }, { type: 'success', placement: { from: 'bottom', align: 'right'} });";
        //SetScript(sc, "");
        ////if (ddlMesPlanilla.SelectedIndex != 0 && ddlTipoPersonal.SelectedIndex != 0)
        ////{
        ////    CargarReporte();
        ////}
    }


    protected void btnGene_Click(object sender, EventArgs e)
    {
        string tipo = "";
        cls_pla_docentes_adicional adicional = new cls_pla_docentes_adicional();
        adicional.td_periodo = ddlTipoPersonal.SelectedItem.Text.ToString();
        adicional.td_tipo_docente = tipo;
        if (ddlMesPlanilla.SelectedItem.Text == "EXAMEN DE MESA") tipo = "MESA";
        if (ddlMesPlanilla.SelectedItem.Text == "CURSO DE TEMPORADA") tipo = "CURSO";
        if (ddlMesPlanilla.SelectedIndex != 0 && ddlTipoPersonal.SelectedIndex != 0)
        {
            CargarReporte();
            
        }
        else
        {
            sc = "$.notify({ icon: 'ni ni-bell-55', message: 'No hay todos los paremetros' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }
        adicional.Estadoimpreso(adicional);
    }
}