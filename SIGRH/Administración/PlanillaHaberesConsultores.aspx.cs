using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System.Data;
public partial class Administración_PlanillaHaberesConsultores : System.Web.UI.Page
{
    private string sc = "";
    public string pc_id = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                CargarMeses();
            }
        }
        else Response.Redirect("../Index");

    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }});");
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar _MENU_ registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros'," +
                    "'sInfoEmpty': 'Mostrando registros del 0 al 0 de un total de 0 registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ registros)'," +
                    "'sInfoPostFix': ''," +
                    "'sSearch': 'Buscar:'," +
                    "'sUrl': ''," +
                    "'sInfoThousands': ','," +
                    "'sLoadingRecords': 'Cargando...'," +
                    "'oPaginate': {" +
                        "'sFirst': '«'," +
                        "'sLast': '»'," +
                        "'sNext': '<i class=\"fas fa-angle-right\"></i>'," +
                        "'sPrevious': '<i class=\"fas fa-angle-left\"></i>'" +
                    "}," +
                    "'oAria': {" +
                        "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                        "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                "}," +
                "'ordering': false," +
                "'searching': true," +
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true" +
            "});");
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    private void CargarMeses()
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlMesPlanilla.DataSource = proceso.ObtenerMesesProceso();
        ddlMesPlanilla.Items.Add("Seleccione..");
        ddlMesPlanilla.DataTextField = "pc_titulo";
        ddlMesPlanilla.DataValueField = "pc_id";
        ddlMesPlanilla.DataBind();

    }
    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();

        if (ddlMesPlanilla.SelectedIndex > 0)
        { DivTipoPersonal.Visible = true;
            ddlAdicional.Items.Clear();
            ddlAdicional.DataSource = proceso.NumeroPlanilla_Combo(ddlMesPlanilla.SelectedValue);
            ddlAdicional.Items.Add("Seleccione..");
            ddlAdicional.DataTextField = "cbh_pla_NRO_descripcion";
            ddlAdicional.DataValueField = "cbh_pla_NRO";
            ddlAdicional.DataBind();

            if (ddlAdicional.Items.Count > 01)
            {
                DivTipoPersonal.Visible = true;
                divReporte.Visible = true;
            }else
            {
                DivTipoPersonal.Visible = false;
                divReporte.Visible = false;
                divMembrete.Visible = false;
            }

        }
        else
            DivTipoPersonal.Visible = false;
        //SetScript("");
    }





    protected void ddlAdicional_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        pc_id = ddlMesPlanilla.SelectedValue;
        if (ddlAdicional.SelectedItem.Text != "Seleccione..")

        {
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new
            Uri("http://SERVIDOR-DELL:8008/ReportServer");
            //ReportViewer1.ServerReport.ReportServerUrl = new
            //Uri("http://ANTHRACIS-DESK/ReportServer");
            ReportViewer1.ServerReport.ReportPath =
            "/ReportesUAP/Reporte_UAP_CONSULTORES";
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedValue, false));
            paramList.Add(new ReportParameter("SECUENCIAL", ddlAdicional.SelectedValue, false));
            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;
            ReportViewer1.ServerReport.Refresh();
            chkMembrete.Visible = true;
            divMembrete.Visible = true;
        }
        else
        {
            chkMembrete.Visible = false;
            divMembrete.Visible = false;
            divReporte.Visible = false;
        }
        SetScript("");
    }

    protected void chkMembrete_CheckedChanged(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        pc_id = ddlMesPlanilla.SelectedValue;

        if (ddlAdicional.SelectedItem.Text != "Seleccione..")

        {
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new
            Uri("http://SERVIDOR-DELL:8008/ReportServer");

            if (chkMembrete.Checked == false)
            {
                ReportViewer1.ServerReport.ReportPath =
                "/ReportesUAP/Reporte_UAP_CONSULTORES_SIN_MEMBRETE";
            }
            else
            {
                ReportViewer1.ServerReport.ReportPath =
                "/ReportesUAP/Reporte_UAP_CONSULTORES";
            }
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedValue, false));
            paramList.Add(new ReportParameter("SECUENCIAL", ddlAdicional.SelectedValue, false));
            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;
            ReportViewer1.ServerReport.Refresh();
        }
        SetScript("");
    }
}