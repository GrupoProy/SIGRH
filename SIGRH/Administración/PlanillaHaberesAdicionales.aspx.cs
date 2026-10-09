using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System.Data;
public partial class Administración_PlanillaHaberesAdicionales : System.Web.UI.Page
{
    private string sc = "";
    public string pc_id = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarMeses();
            CargarTipoPersonal();
        }
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
        if (Convert.ToInt32(ddlMesPlanilla.SelectedValue) > 0)
        {
            cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
            DataSet ds = proceso.VerificarPlanillasAdicionales(ddlMesPlanilla.SelectedValue);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlAdicional.Items.Clear();
                ddlAdicional.DataSource = proceso.VerificarPlanillasAdicionales(ddlMesPlanilla.SelectedValue);
                ddlAdicional.DataTextField = "descripcion";
                ddlAdicional.DataValueField = "ad_secuencial";
                ddlAdicional.DataBind();
                DivTipoPersonal.Visible = true;
                divAdicional.Visible = true;

            }
            else
            {
                ddlAdicional.DataSource = null;
                ddlAdicional.DataBind();
                divAdicional.Visible = false;
                //ReportViewer1.ServerReport.ReportPath =null;
                //ReportViewer1.ServerReport.Refresh();
                DivTipoPersonal.Visible = false;
            }
        }
        //SetScript("");
    }

    protected void ddlTipoPersonal_SelectedIndexChanged(object sender, EventArgs e)
    {
        string tipoPersonal = "";
        cls_pla_proceso_salarios pla_proceso = new cls_pla_proceso_salarios();
        pc_id = ddlMesPlanilla.SelectedValue;

        if (ddlTipoPersonal.SelectedItem.Text != "Seleccione tipo de Personal" && Convert.ToInt32(ddlAdicional.SelectedValue) > 0 && divAdicional.Visible == true)
        {
            if (ddlTipoPersonal.SelectedItem.Text == "Administrativo")
                tipoPersonal = "Reporte_UAP_V1_ADICIONAL_SIN_MEMBRETE";
            if (ddlTipoPersonal.SelectedItem.Text == "Docente")
                tipoPersonal = "Reporte_UAP_V2_ADICIONAL_SIN_MEMBRETE";
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;
            ReportViewer1.ServerReport.ReportServerUrl = new
            Uri("http://SRV_LONDRA:8008/ReportServer");
            ReportViewer1.ServerReport.ReportPath =
            "/ReportesUAP/" + tipoPersonal;
            List<ReportParameter> paramList = new List<ReportParameter>();
            paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedValue, false));
            paramList.Add(new ReportParameter("SECUENCIAL", ddlAdicional.SelectedValue, false));
            ReportViewer1.ServerReport.SetParameters(paramList);
            ReportViewer1.Height = 2000;
            ReportViewer1.ServerReport.Refresh();
            divAporte.Visible = true;
        }
        else
        {
            divAporte.Visible = false;
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
                    tipoPersonal = "Reporte_UAP_V1_ADICIONAL_SIN_MEMBRETE";
                if (ddlTipoPersonal.SelectedItem.Text == "Docente")
                    tipoPersonal = "Reporte_UAP_V2_ADICIONAL_SIN_MEMBRETE";
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new
                Uri("http://SRV_LONDRA:8008/ReportServer");
                ReportViewer1.ServerReport.ReportPath =
                "/ReportesUAP/" + tipoPersonal;
                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedValue, false));
                paramList.Add(new ReportParameter("SECUENCIAL", ddlAdicional.SelectedValue, false));
                ReportViewer1.ServerReport.SetParameters(paramList);
                ReportViewer1.Height = 2000;
                ReportViewer1.ServerReport.Refresh();

            }
        }
        else
        {
            if (ddlTipoPersonal.SelectedItem.Text != "Seleccione tipo de Personal")
            {
                if (ddlTipoPersonal.SelectedItem.Text == "Administrativo")
                    tipoPersonal = "Reporte_UAP_General_ADMINISTRATIVOS_ADICIONAL";
                if (ddlTipoPersonal.SelectedItem.Text == "Docente")
                    tipoPersonal = "Reporte_UAP_General_DOCENTES_ADICIONAL";
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;
                ReportViewer1.ServerReport.ReportServerUrl = new
                Uri("http://SRV_LONDRA:8008/ReportServer");
                ReportViewer1.ServerReport.ReportPath =
                "/ReportesUAP/" + tipoPersonal;
                List<ReportParameter> paramList = new List<ReportParameter>();
                paramList.Add(new ReportParameter("MES_GESTION", ddlMesPlanilla.SelectedValue, false));
                paramList.Add(new ReportParameter("SECUENCIAL", ddlAdicional.SelectedValue, false));
                ReportViewer1.ServerReport.SetParameters(paramList);
                ReportViewer1.Height = 2000;
                ReportViewer1.ServerReport.Refresh();

            }
        }
        SetScript("");

    }

    protected void ddlAdicional_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedIndex > 0)
            DivTipoPersonal.Visible = true;
        else
            DivTipoPersonal.Visible = false;
        SetScript("");
    }

    protected void btnAporte_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReportePatronal.aspx?id=" + ddlMesPlanilla.SelectedValue.ToString() + "&planilla=" + ddlAdicional.SelectedValue.ToString());

        //ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://SRV_LONDRA:8008/ReportServer");
        ////ReportViewer1.ServerReport.ReportServerUrl = new
        ////Uri("http://ANTHRACIS-DESK/ReportServer");
        //ReportViewer1.ServerReport.ReportPath =
        //"/ReportesUAP/REPORTE_CONTABILIDAD";
        //List<ReportParameter> paramList = new List<ReportParameter>();
        //paramList.Add(new ReportParameter("CODMES", ddlMesPlanilla.SelectedValue, false));
        //paramList.Add(new ReportParameter("NROPLANILLA", ddlAdicional.SelectedValue, false));
        //ReportViewer1.ServerReport.SetParameters(paramList);
        //ReportViewer1.Height = 2000;
        //ReportViewer1.ServerReport.Refresh();
        //divExcel.Visible = true;
    }

    protected void btn_Acreedores_Click(object sender, EventArgs e)
    {
        Response.Redirect("ReporteAcreedores.aspx?mes=" + ddlMesPlanilla.SelectedValue.ToString() + "&planilla="+ddlAdicional.SelectedValue.ToString());
    }
}