using Solution_Framework_Salarios.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administración_ReportesAdicionales : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            CargarMeses();
        }
    }
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
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
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");

        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void CargarMeses()
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlMesPlanilla.Items.Add("Seleccione el Mes");
        ddlMesPlanilla.DataSource = proceso.ObtenerMesesProceso();
        ddlMesPlanilla.DataTextField = "pc_titulo";
        ddlMesPlanilla.DataValueField = "pc_id";
        ddlMesPlanilla.DataBind();
    }
    private void CargarNumeroPlanilla(string cod_id)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlNroPlanilla.Items.Clear();
        ddlNroPlanilla.DataSource = proceso.NumeroPlanilla_ComboReportesAdicionales(cod_id);
        ddlNroPlanilla.DataTextField = "NRO_NOMBRE";
        ddlNroPlanilla.DataValueField = "NRO";
        ddlNroPlanilla.DataBind();
    }
    protected void ddlMesPlanilla_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedItem.Text != "Seleccione el Mes")
        {
            DivMinisterioVer.Visible = true;
            Session["pc_id"] = ddlMesPlanilla.SelectedItem.Value;
            divPlanilla.Visible = true;
            CargarNumeroPlanilla(ddlMesPlanilla.SelectedValue);
        }
        else
        {
            DivMinisterioVer.Visible = false;
            DivTrabajoVer.Visible = false;
            DivAfpVer.Visible = false;
            DivAfpGenerar.Visible = false;
            divPlanilla.Visible = false;
        }
    }

    protected void btnVerMinisterioEco_Click(object sender, EventArgs e)
    {
        //Session["VerGenerar"] = "Ver";
        //sc = "window.open('ReporteMinEconomia.aspx', 'width=300,height=300', '_blank');";
        //SetScript(sc, ", dropdownParent: $('#addModal')");
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        if (ddlMesPlanilla.SelectedIndex >0)
        {
            if (proceso.GenerarCarpetas_C31(Convert.ToInt32(ddlMesPlanilla.SelectedItem.Value)))
            {
                CargarCombosC31();
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe Seleccionar el mes..' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }
    }
    private void CargarCombosC31() {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        ddlC31_1.Items.Clear();
        ddlC31_1.DataSource = proceso.Combos_C31(Convert.ToInt32(ddlMesPlanilla.SelectedItem.Value), "C2");
        ddlC31_1.DataTextField = "GLOSA";
        ddlC31_1.DataValueField = "C31_ID";
        ddlC31_1.DataBind();

        ddlC31_2.Items.Clear();
        ddlC31_2.DataSource = proceso.Combos_C31(Convert.ToInt32(ddlMesPlanilla.SelectedItem.Value), "C3");
        ddlC31_2.DataTextField = "cat_abreviacion";
        ddlC31_2.DataValueField = "cat_descripcion";
        ddlC31_2.DataBind();
    }

    protected void btnGenerarMinisterioEco_Click(object sender, EventArgs e)
    {
        //Session["VerGenerar"] = "Ver";
        //sc = "window.open('ReporteMinEconomia.aspx', 'width=300,height=300', '_blank');";
        //SetScript(sc, ", dropdownParent: $('#addModal')");

    }
    protected void btnVerMinTrabajo_Click(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedIndex > 0)
        {

            HttpContext.Current.Session["VerGenerar"] = "Ver";
        sc = "window.open('ReporteMinTrabajo.aspx', 'width=300,height=300', '_blank');";
        SetScript(sc, ", dropdownParent: $('#addModal')");
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe Seleccionar el mes..' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }

    }
    protected void btnMinTrabajo_Generar_Click(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedIndex > 0)
        {
            cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
            proceso.GenerarRegistroC31_4("N", ddlC31_1.SelectedItem.Value, Convert.ToInt32(ddlMesPlanilla.SelectedItem.Value), ddlC31_2.SelectedItem.Text);
            DataSet ds = proceso.Combos_C31(Convert.ToInt32(ddlMesPlanilla.SelectedItem.Value), "C4");
            string txt = string.Empty;
        foreach (DataColumn column in ds.Tables[0].Columns)
        {
            //Add the Header row for Text file.
            //txt += column.ColumnName + "\t\t";
            txt += "\r\n";
        }
        foreach (DataRow row in ds.Tables[0].Rows)
        {
            foreach (DataColumn column in ds.Tables[0].Columns)
            {
                //Add the Data rows.
                txt += row[column.ColumnName].ToString();
            }

            //Add new line.
            txt += "\r\n";
        }
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + ddlC31_1.SelectedItem.Value + "." + ddlC31_2.SelectedItem.Text.ToLower());
        Response.Charset = "";
        Response.ContentType = "application/text";
        Response.Output.Write(txt);
        Response.Flush();
        Response.End();
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe Seleccionar el mes..' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }

    }

    protected void btnFPC_FS_Futuro_Click(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedIndex > 0)
        {

            HttpContext.Current.Session["VerGenerar"] = "Ver";
            if(ddlNroPlanilla.SelectedIndex>0)
                Session["nro_planilla"] = ddlNroPlanilla.SelectedItem.Value;
            else
                Session["nro_planilla"] = "0";


            sc = "window.open('ReporteFPC_FondoSolidario_FUTURO.aspx', 'width=300,height=300', '_blank');";
            SetScript(sc, ", dropdownParent: $('#addModal')");
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe Seleccionar el mes..' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }

        }

        protected void btnFPC_Futuro_Click(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedIndex > 0)
        { 
            HttpContext.Current.Session["VerGenerar"] = "Ver";
            if (ddlNroPlanilla.SelectedIndex > 0)
                Session["nro_planilla"] = ddlNroPlanilla.SelectedItem.Value;
            else
                Session["nro_planilla"] = "0";

            sc = "window.open('ReporteFPC_FUTURO.aspx', 'width=300,height=300', '_blank');";
        SetScript(sc, ", dropdownParent: $('#addModal')");
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe Seleccionar el mes..' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }

    }

    protected void btnFPC_FS_Prevision_Click(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedIndex > 0)
        {

            HttpContext.Current.Session["VerGenerar"] = "Ver";
            if (ddlNroPlanilla.SelectedIndex > 0)
                Session["nro_planilla"] = ddlNroPlanilla.SelectedItem.Value;
            else
                Session["nro_planilla"] = "0";
            sc = "window.open('ReporteFPC_FondoSolidario_PREVISION.aspx', 'width=300,height=300', '_blank');";
        SetScript(sc, ", dropdownParent: $('#addModal')");
    }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe Seleccionar el mes..' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
}

    }

    protected void btnFPC_Prevision_Click(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedIndex > 0)
        {

            HttpContext.Current.Session["VerGenerar"] = "Ver";
            if (ddlNroPlanilla.SelectedIndex > 0)
                Session["nro_planilla"] = ddlNroPlanilla.SelectedItem.Value;
            else
                Session["nro_planilla"] = "0";

            sc = "window.open('ReporteFPC_PREVISION.aspx', 'width=300,height=300', '_blank');";
        SetScript(sc, ", dropdownParent: $('#addModal')");
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe Seleccionar el mes..' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }
    }

    protected void BtnConta_Click(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedIndex > 0)
        {
            HttpContext.Current.Session["VerGenerar"] = "Ver";
            if (ddlNroPlanilla.SelectedIndex > 0)
            {
                Session["nro_planilla"] = ddlNroPlanilla.SelectedItem.Value;
            }
            else
            {
                Session["nro_planilla"] = "0";
            }
            sc = "window.open('ReporteContabilidad.aspx', 'width=300,height=300', '_blank');";
            SetScript(sc, ", dropdownParent: $('#addModal')");
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe Seleccionar el mes..' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }
    }

    protected void btnGesto_Click(object sender, EventArgs e)
    {
        if (ddlMesPlanilla.SelectedIndex > 0)
        {

            HttpContext.Current.Session["VerGenerar"] = "Ver";
            if (ddlNroPlanilla.SelectedIndex > 0)
                Session["nro_planilla"] = ddlNroPlanilla.SelectedItem.Value;
            else
                Session["nro_planilla"] = "0";

            sc = "window.open('ReporteFPC_GESTORA.aspx', 'width=300,height=300', '_blank');";
            SetScript(sc, ", dropdownParent: $('#addModal')");
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe Seleccionar el mes..' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc, "");
        }
    }
}