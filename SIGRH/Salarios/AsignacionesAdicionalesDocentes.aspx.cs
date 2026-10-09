using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Salarios_AsignacionesAdicionalesDocentes : System.Web.UI.Page
{
    private cls_persona _persona = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                Txt_per_id_b.Focus();
            }
        }
        else Response.Redirect("../Index");
    }
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //int index = Convert.ToInt32(e.CommandArgument);
        //string code = GvLista.DataKeys[index].Value.ToString();
        //if (e.CommandName.Equals("GetNew")) { Response.Redirect("BonoAntiguedadAlta?id=" + code); }
        //SetScript(sc);
    }
    protected void btnVerificarCi_Click(object sender, EventArgs e)
    {
        cls_persona persona = new cls_persona();
        int per_id = 0;
        string ci_buscar; int per_id_buscar = 0;
        if (Txt_per_num_doc_b.Text == "") ci_buscar = "0"; else ci_buscar = Txt_per_num_doc_b.Text;
        if (Txt_per_id_b.Text == "") per_id_buscar = 0; else per_id_buscar = Convert.ToInt32(Txt_per_id_b.Text);
        DataSet ds = persona.VerificarNuevoFuncionario(ci_buscar, per_id_buscar);

        if (ds.Tables[0].Rows.Count > 0)
        {
            per_id = Convert.ToInt32(ds.Tables[0].Rows[0]["per_id"].ToString());
            //sc = "$.notify({ icon: 'fa fa-check', message: 'Funcionario Existente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); ";
            //SetScript(sc);
            Session["per_id_asignacion_adicional_docentes"] = per_id;
            Response.Redirect("RegistroAsignacionesAdicionalesDocentes.aspx");
        }
        else
        {
            if (ds.Tables[1].Rows.Count > 0)
            {
                per_id = Convert.ToInt32(ds.Tables[1].Rows[0]["per_id"].ToString());
                //sc = "$.notify({ icon: 'fa fa-check', message: 'Funcionario Existente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); ";
                //SetScript(sc);
                Session["per_id_asignacion_adicional_docentes"] = per_id;
                Response.Redirect("RegistroAsignacionesAdicionalesDocentes.aspx");
            }
            else
                if (ds.Tables[0].Rows.Count == 0 && ds.Tables[1].Rows.Count == 0)
            {
                sc = "$.notify({ icon: 'fa fa-check', message: 'No existe ningún funcionario con el CI o código de funcionario buscados, debe registrar a la persona...'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
                Response.Redirect("../MovimientoPersonal/PersonaAlta");
            }
        }
    }
    // diseño gridview
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) GvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvLista.FooterRow != null) GvLista.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom)
    {
        try
        {
            _persona = new cls_persona();
            GvLista.DataSource = _persona.ObtenerTablaGrillaPCED(varId, varCed, varPat, varMat, varNom, "");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }
    // Ejecutar ScriptManager
    private void SetScript(string val)
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
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" +
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
    private void Limpiar(string val)
    {
        if (val.Equals("sch_cl"))
        {
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
        }
    }
}