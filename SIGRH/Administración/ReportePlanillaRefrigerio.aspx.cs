using Microsoft.Reporting.WebForms;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administración_ReportePlanillaRefrigerio : System.Web.UI.Page
{
    private cls_refrigerio refrigerio = new cls_refrigerio();
    private string sc = "";
    public string pc_id = "0";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarMeses();
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

    private void CargarMeses()
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlMesPlanilla.DataSource = proceso.ObtenerMesesProceso();
        ddlMesPlanilla.Items.Add("Seleccione..");
        ddlMesPlanilla.DataTextField = "pc_titulo";
        ddlMesPlanilla.DataValueField = "pc_id";
        ddlMesPlanilla.DataBind();
    }

    private void cargarNroPlanilla()
    {
        ddlAdicional.Items.Clear();
        ddlAdicional.Items.Add("Seleccione...");
        ddlAdicional.DataSource = refrigerio.ObtenerNroPlanilla(Convert.ToInt32(ddlMesPlanilla.SelectedValue));
        ddlAdicional.DataTextField = "nro_planilla";
        ddlAdicional.DataValueField = "nro_planilla";
        ddlAdicional.DataBind();
    }

    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedItem.Text != "Seleccione..")
        {
            cargarNroPlanilla();
        }
        SetScript("");
    }

    protected void ddlAdicional_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void btnReporte_Click(object sender, EventArgs e)
    {
        int nro_planilla;
        if (ddlAdicional.SelectedValue == "Planilla General")
        {
            nro_planilla = 0;
        }
        else
        {
            nro_planilla = Convert.ToInt32(ddlAdicional.SelectedValue);
        }

        int pl = nro_planilla;
        //if (txt_cite.Text != null && ddlMesPlanilla.SelectedItem.Text != "Seleccione.." && ddlAdicional.SelectedItem.Text != "Seleccione...")
        //{
        //    
        //    ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        //    ReportViewer1.ServerReport.ReportServerUrl = new
        //    Uri("http://SRV_LONDRA:8008/ReportServer");
        //    ReportViewer1.ServerReport.ReportPath =
        //    "/ReportesUAP/BonoRefrigerio";
        //    List<ReportParameter> paramList = new List<ReportParameter>();
        //    paramList.Add(new ReportParameter("MESPROCESO", ddlMesPlanilla.SelectedValue, false));
        //    paramList.Add(new ReportParameter("NROPLANILLA", nro_planilla.ToString(), false));
        //    paramList.Add(new ReportParameter("Cite", txt_cite.Text, false));
        //    ReportViewer1.ServerReport.SetParameters(paramList);
        //    ReportViewer1.Height = 2000;
        //    ReportViewer1.ServerReport.Refresh();
        //}
    }
}