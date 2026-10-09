using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_General.BussinessLogicLayer;

public partial class Administración_Catalogo : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null)
        {
            if (HttpContext.Current.Session["per_id"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {
                    ObtenerCat_TablaPando();
                }

            }
            else Response.Redirect("../index");
        }
        else Response.Redirect("../index");
    }
    private void ObtenerCat_TablaPando()
    {
        cls_catalogo catalogo = new cls_catalogo();
        ddl_cat_tabla.Items.Clear();
        DataSet ds= catalogo.ObtenerCat_TablaPando();
        ddl_cat_tabla.DataSource = catalogo.ObtenerCat_TablaPando();
        ddl_cat_tabla.DataTextField = "cat_tabla";
        ddl_cat_tabla.DataBind();
    }
    protected void btnRegistrarCatalogo_Click(object sender, EventArgs e)
    {
        cls_catalogo catalogo = new cls_catalogo();
        string id_superior = "";
        if (ddl_cat_tabla.SelectedItem.Text == "CIUDAD_LOCALIDAD")
            id_superior = ddlProvincia.SelectedValue;
        else
            id_superior = "0";
        if (catalogo.Adicionar(ddl_cat_tabla.SelectedItem.Text, txt_cat_descripcion.Text, txt_cat_abreviacion.Text, id_superior ))
        {
            //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "SIGRHScript", "javascript:window.alert('Se registró correctamente el catálogo.');window.location.href='Administración/Catalogo.aspx'", true);
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los datos se registraron correctamente en catálogo...' }, { type: 'warning' }); ";
            SetScript(sc);
        }
        ObtenerCat_TablaPando();
    }
    protected void ddl_cat_tabla_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_catalogo catalogo = new cls_catalogo();
        DataSet ds = catalogo.ObtenerTablaGrilla("", ddl_cat_tabla.SelectedItem.Text, "", "", "", "", "", "", "", "");
        gvCatalogo.DataSource = catalogo.ObtenerTablaGrilla("", ddl_cat_tabla.SelectedItem.Text, "", "", "","", "", "", "", "v");
        gvCatalogo.DataBind();
        if (ddl_cat_tabla.SelectedItem.Text == "CIUDAD_LOCALIDAD")
        {
            divDpto.Visible = true;
            ddlProvincia.DataSource = catalogo.ObtenerDptoProvincia();
            ddlProvincia.DataTextField = "lugar_nac";
            ddlProvincia.DataValueField = "id_provincia";
            ddlProvincia.DataBind();
        }
        SetScript(sc);

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


}