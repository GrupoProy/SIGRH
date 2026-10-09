using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class AdministracionDePersonal_PlanillaHaberes : System.Web.UI.Page
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
                CargarTipoPersonal();
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

    private void CargarTipoPersonal()
    {
        ddlTipoPersonal.Items.Add("Seleccione tipo de Personal");
        ddlTipoPersonal.Items.Add("Administrativo");
        ddlTipoPersonal.Items.Add("Docente");
        ddlTipoPersonal.DataBind();
    }
    private void CargarReporte()
    {
        //ReportViewer1.ProcessingMode = ProcessingMode.Local;
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://SERVIDOR-DELL:8008/ReportServer");
        ////ReportViewer1.ServerReport.ReportServerUrl = new
        ////Uri("http://ANTHRACIS-DESK/ReportServer");

        //ReportViewer1.ServerReport.ReportPath =
        //"/ReportesUAP/Reporte_UAP_V1";
        ////List<ReportParameter> paramList = new List<ReportParameter>();
        ////paramList.Add(new ReportParameter("MES_GESTION", "247", false));
        ////ReportViewer1.ServerReport.SetParameters(paramList);
        //ReportViewer1.Height = 2000;

        //ReportViewer1.ServerReport.Refresh();
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
        if (ddlMesPlanilla.SelectedIndex > 0)
            DivTipoPersonal.Visible = true;
        else
            DivTipoPersonal.Visible = false;
        SetScript("");
    }

    protected void ddlTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tipoPersonal = "";
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        pc_id = pla_proceso.ObtenerSalarioMinimo().Tables[0].Rows[0]["pc_id"].ToString();
        if (ddlTipoPersonal.SelectedItem.Text != "Seleccione tipo de Personal")
        {
            if (ddlTipoPersonal.SelectedItem.Text == "Administrativo")
                tipoPersonal = "Reporte_UAP_V1_SIN_MEMBRETE";
            if (ddlTipoPersonal.SelectedItem.Text == "Docente")
                tipoPersonal = "Reporte_UAP_V2_SIN_MEMBRETE";
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new
            Uri("http://SRV_LONDRA:8008/ReportServer");
            ReportViewer1.ServerReport.ReportPath =
            "/ReportesUAP/" + tipoPersonal;
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedValue, false));
            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;
            ReportViewer1.ServerReport.Refresh();
            divAporte.Visible = true;
            divExcel.Visible = true;
        }
        else
        {

        }
        SetScript("");

    }



    protected void chkExcel_CheckedChanged(object sender, EventArgs e)
    {
        string tipoPersonal = "";
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        pc_id = pla_proceso.ObtenerSalarioMinimo().Tables[0].Rows[0]["pc_id"].ToString();

        if (chkExcel.Checked == false)
        {
            if (ddlTipoPersonal.SelectedItem.Text != "Seleccione tipo de Personal")
            {
                if (ddlTipoPersonal.SelectedItem.Text == "Administrativo")
                    tipoPersonal = "Reporte_UAP_V1_SIN_MEMBRETE";
                if (ddlTipoPersonal.SelectedItem.Text == "Docente")
                    tipoPersonal = "Reporte_UAP_V2_SIN_MEMBRETE";
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new
                Uri("http://SRV_LONDRA:8008/ReportServer");
                //ReportViewer1.ServerReport.ReportServerUrl = new
                //Uri("http://ANTHRACIS-DESK/ReportServer");
                ReportViewer1.ServerReport.ReportPath =
                "/ReportesUAP/" + tipoPersonal;
                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedValue, false));
                ReportViewer1.ServerReport.SetParameters(paramList);
                ReportViewer1.Height = 2000;
                ReportViewer1.ServerReport.Refresh();
                divExcel.Visible = true;
            }
        }
        else
        {

            if (ddlTipoPersonal.SelectedItem.Text != "Seleccione tipo de Personal")
            {
                if (ddlTipoPersonal.SelectedItem.Text == "Administrativo")
                    tipoPersonal = "Reporte_UAP_General_ADMINISTRATIVOS";
                if (ddlTipoPersonal.SelectedItem.Text == "Docente")
                    tipoPersonal = "Reporte_UAP_General_DOCENTES";
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new
                Uri("http://SRV_LONDRA:8008/ReportServer");
                //ReportViewer1.ServerReport.ReportServerUrl = new
                //Uri("http://ANTHRACIS-DESK/ReportServer");
                ReportViewer1.ServerReport.ReportPath =
                "/ReportesUAP/" + tipoPersonal;
                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedValue, false));
                ReportViewer1.ServerReport.SetParameters(paramList);
                ReportViewer1.Height = 2000;
                ReportViewer1.ServerReport.Refresh();
                divExcel.Visible = true;

            }
        }
        SetScript("");

    }

    protected void btnAporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportePatronal.aspx?id="+ddlMesPlanilla.SelectedValue.ToString() + "&planilla=0");

        //ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://SERVIDOR-DELL:8008/ReportServer");
        ////ReportViewer1.ServerReport.ReportServerUrl = new
        ////Uri("http://ANTHRACIS-DESK/ReportServer");
        //ReportViewer1.ServerReport.ReportPath =
        //"/ReportesUAP/REPORTE_CONTABILIDAD";
        //List<ReportParameter> paramList = new List<ReportParameter>();
        //paramList.Add(new ReportParameter("CODMES", ddlMesPlanilla.SelectedValue, false));
        //paramList.Add(new ReportParameter("NROPLANILLA", 0.ToString(), false));
        //ReportViewer1.ServerReport.SetParameters(paramList);
        //ReportViewer1.Height = 2000;
        //ReportViewer1.ServerReport.Refresh();
        //divExcel.Visible = true;
        //divMembrete.Visible = true;
        //chkMembrete.Visible = true;
    }

    protected void btn_Acreedores_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteAcreedores.aspx?mes=" + ddlMesPlanilla.SelectedValue.ToString()+"&planilla=0");
    }
}