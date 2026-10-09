using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Globalization;
using Solution_Framework_Kardex.BussinessLogicLayer;
using System.Text;
public partial class Kardex_ReporteCurriculum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {

                BindDdlGrado();
            }
        }
    }
    private void BindDdlGrado() {
        cls_cv_formacion formacion = new cls_cv_formacion();
        ddlGradoAcademico.Items.Clear();
        ddlGradoAcademico.DataSource = formacion.ObtenerGradoAcademico_Reporte();
        ddlGradoAcademico.Items.Add("Seleccione..");
        ddlGradoAcademico.DataTextField = "ga_nombre";
        ddlGradoAcademico.DataBind();
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

    private void BindDdlCarreras(string grado)
    {
        cls_cv_formacion formacion = new cls_cv_formacion();
        ddlCarreras.Items.Clear();
        ddlCarreras.DataSource = formacion.ObtenerCarreras_Reporte(grado);
        ddlCarreras.DataTextField = "carr_nombre";
        ddlCarreras.DataBind();
    }
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        ReportViewer1.ProcessingMode = ProcessingMode.Remote;
        ReportViewer1.ServerReport.ReportServerUrl = new
        Uri("http://SERVIDOR-DELL:8008/ReportServer");
        //ReportViewer1.ServerReport.ReportServerUrl = new
        //Uri("http://ANTHRACIS-DESK/ReportServer");
        ReportViewer1.ServerReport.ReportPath =
        "/ReportesUAP/REPORTE_CV_DETALLE_UAP";
        List<ReportParameter> paramList = new List<ReportParameter>();
        paramList.Add(new ReportParameter("grado", ddlGradoAcademico.SelectedItem.Text, false));
        paramList.Add(new ReportParameter("carrera", ddlCarreras.SelectedItem.Text, false));


        ReportViewer1.ServerReport.SetParameters(paramList);
        ReportViewer1.Height = 2000;

        ReportViewer1.ServerReport.Refresh();
        SetScript("");

    }


    protected void ddlGradoAcademico_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindDdlCarreras(ddlGradoAcademico.SelectedItem.Text);
        SetScript("");

    }
}