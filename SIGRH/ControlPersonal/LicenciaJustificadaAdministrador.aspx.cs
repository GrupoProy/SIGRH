using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_LicenciaJustificadaAdministrador : System.Web.UI.Page
{
    private cls_persona _persona = null;
    //private cls_mp_asignacion _asignacion = null;
    //private cls_situacion_persona _situacion = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                //sc = "CopiarCortarPegar(true);";
                //SetScript(sc);
            }
        }
        else Response.Redirect("../Index");
    }

    // Cargar GridView
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom)
    {
        try
        {
            _persona = new cls_persona();
            GvLista.DataSource = _persona.ObtenerTablaGrillaLicencias(varId, "", varCed, "", varPat, varMat, varNom, "", "", "", "", "", "", "");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño GridView
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) GvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvLista.FooterRow != null) GvLista.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    // Evento GridView
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //_asignacion = new cls_mp_asignacion();
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();
        //var data = _asignacion.ObtenerTablaGrilla("", code, "", "", "", "V", "", "", "", "", "", "", "", "").Tables[0];
        //_situacion = new cls_situacion_persona
        //{
        //    st_per_id = Convert.ToInt32(code),
        //    st_estado = "V"
        //};
        //var dataS = _situacion.ObtenerTablaGrilla().Tables[0];

        //if (dataS.Rows.Count > 0)
        //{
        //    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se puede realizar ninguna acción sobre el funcionario...!!' }, { type: 'warning' });";
        //    SetScript(sc);
        //    return;
        //}

        //if (data.Rows.Count > 0) { if (e.CommandName.Equals("GetNew")) Response.Redirect("LicenciaJustificadaAdministradorAlta?id=" + code); }
        //else sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El funcionario no tiene una asignación vigente...!!' }, { type: 'warning' });";

        if (e.CommandName.Equals("GetNew")) { Response.Redirect("LicenciaJustificadaAdministradorAlta?id=" + code); }
        else if (e.CommandName.Equals("GetLicense")) { Response.Redirect("LicenciasAlta?id=" + code); }
        else if (e.CommandName.Equals("GetLocation")) { Response.Redirect("UbicacionAlta?id=" + code); }
        else if (e.CommandName.Equals("GetSchedule")) { Response.Redirect("HorariosAlta?id=" + code); }
        SetScript(sc);
    }

    // Buscar
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });";
        else
        {
            BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());
            Limpiar("sch_cl");

            if (GvLista.Rows.Count > 0) sc = "$('#dResult').css('display', 'block');";
            else sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' }); $('#dResult').css('display', 'none');";
        }
        SetScript(sc);
    }

    // Ejecutar ScriptManager
    private void SetScript(string data)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
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

    // Limpiar
    private void Limpiar(string val)
    {
        if (val.Equals("sch_cl"))
        {
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
        }
        else if (val.Equals("gv_cl"))
        {
            GvLista.DataSource = null;
            GvLista.DataBind();
        }
    }
}