using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManualPuestos_frmPuestos : System.Web.UI.Page
{
    private cls_mdp_puesto puestos = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            if (HttpContext.Current.Session["cod_fun"] != null)
            {

                listaFiltradoGestion();
            }
            else
            {
                Response.Redirect("../index");
            }
        }

    }

    private void listarPuestos(string gestionFiltrar)
    {
        try
        {
            puestos = new cls_mdp_puesto();
            puestos.gestion_selec = gestionFiltrar;
            gvPuesto.DataSource = puestos.ObtenerGrillaPuesto();
            gvPuesto.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gvPuesto_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvPuesto.Rows.Count > 0)
        {
            if (gvPuesto.HeaderRow != null)
            {
                gvPuesto.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvPuesto.FooterRow != null)
            {
                gvPuesto.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gvPuesto_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string idFicha = gvPuesto.DataKeys[index].Values[0].ToString();
        string gestionComp = "";
        string gestionSelec = "";
        for (int i = 0; i < ddl_gestion.Items.Count; i++)
        {
            gestionComp = ddl_gestion.Items[i].Value;
            gestionSelec = ddl_gestion.SelectedValue;
            if (i == 0)
            {
                Session["editarGestion"] = (gestionComp == gestionSelec) ? true : false;
                break;
            }
            else
            {
                Session["editarGestion"] = false;
            }
        }

        switch (e.CommandName)
        {
            case "GetDetailReport":
                Session["idFicha"] = gvPuesto.DataKeys[index].Value.ToString();
                Response.Redirect("Reportes/Reporte_POAI.aspx");
                break;

            default:
                break;
        }
    }

    private void listaFiltradoCargo(string gestionFiltrar)
    {
        try
        {
            puestos = new cls_mdp_puesto();
            puestos.gestion_selec = gestionFiltrar;

            ddl_cargo.Items.Clear();
            ddl_cargo.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_cargo.DataValueField = "es_id";
            ddl_cargo.DataTextField = "es_descripcion";
            ddl_cargo.DataSource = puestos.ObtenerFiltradoCargo();
            ddl_cargo.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoDirAdm(string gestionFiltrar)
    {
        try
        {
            puestos = new cls_mdp_puesto();
            puestos.gestion_selec = gestionFiltrar;

            ddl_direccion_administrativa.Items.Clear();
            ddl_direccion_administrativa.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_direccion_administrativa.DataValueField = "cp_da";
            ddl_direccion_administrativa.DataTextField = "cp_da_descripcion";
            ddl_direccion_administrativa.DataSource = puestos.ObtenerFiltradoDirAdm();
            ddl_direccion_administrativa.DataBind();
            ddl_direccion_administrativa.Enabled = (ddl_direccion_administrativa.Items.Count > 1) ? true : false;
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoUnidadEjec(string gestionFiltrar)
    {
        try
        {
            puestos = new cls_mdp_puesto();
            puestos.gestion_selec = gestionFiltrar;

            ddl_unidad_ejecutiva.Items.Clear();
            ddl_unidad_ejecutiva.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_unidad_ejecutiva.DataValueField = "cp_ue";
            ddl_unidad_ejecutiva.DataTextField = "cp_ue_descripcion";
            ddl_unidad_ejecutiva.DataSource = puestos.ObtenerFiltradoUnidadEjec();
            ddl_unidad_ejecutiva.DataBind();
            ddl_unidad_ejecutiva.Enabled = (ddl_unidad_ejecutiva.Items.Count > 1) ? true : false;
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoUnidadOrg(string gestionFiltrar)
    {
        try
        {
            puestos = new cls_mdp_puesto();
            puestos.gestion_selec = gestionFiltrar;
            ddl_unidad_organizacional.Items.Clear();
            ddl_unidad_organizacional.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_unidad_organizacional.DataValueField = "eo_id";
            ddl_unidad_organizacional.DataTextField = "est_org";
            ddl_unidad_organizacional.DataSource = puestos.ObtenerFiltradoUnidadOrg();
            ddl_unidad_organizacional.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoGestion()
    {
        try
        {
            puestos = new cls_mdp_puesto();
            ddl_gestion.DataValueField = "pr_id";
            ddl_gestion.DataTextField = "periodo";
            ddl_gestion.DataSource = puestos.ObtenerFiltradoGestion();
            ddl_gestion.DataBind();
            string anio = DateTime.Now.ToString("yyyy");

            puestos.gestion = anio;
            var gestionActual = puestos.ObtenerGestion();

            if (gestionActual.Tables[0].Rows[0]["pr_id"] != DBNull.Value && gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim() != "")
            {
                ddl_gestion.SelectedValue = gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim();
                string gestionFiltrar = gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim();
                listarPuestos(gestionFiltrar);
                listaFiltradoCargo(gestionFiltrar);
                listaFiltradoDirAdm(gestionFiltrar);
                listaFiltradoUnidadEjec(gestionFiltrar);
                listaFiltradoUnidadOrg(gestionFiltrar);

            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        puestos = new cls_mdp_puesto();

        string item = txt_item.Text;
        string cargo = ddl_cargo.SelectedItem.Text.Trim();
        string direccion_administrativa = ddl_direccion_administrativa.SelectedItem.Text.Trim();
        string unidad_ejecutiva = ddl_unidad_ejecutiva.SelectedItem.Text.Trim();
        string unidad_organizacional = ddl_unidad_organizacional.SelectedItem.Text.Trim();

        try
        {
            puestos.param1 = (item != null && item != "") ? item : "";
            puestos.param2 = (cargo != null && cargo != "" && cargo != "Seleccione...") ? cargo : "";
            puestos.param3 = (direccion_administrativa != null && direccion_administrativa != "" && direccion_administrativa != "Seleccione...") ? direccion_administrativa : "";
            puestos.param4 = (unidad_ejecutiva != null && unidad_ejecutiva != "" && unidad_ejecutiva != "Seleccione...") ? unidad_ejecutiva : "";
            puestos.param5 = (unidad_organizacional != null && unidad_organizacional != "" && unidad_organizacional != "Seleccione...") ? unidad_organizacional : "";

            puestos.gestion_selec = ddl_gestion.SelectedValue;
            gvPuesto.DataSource = puestos.ObtenerGrillaFiltro();
            gvPuesto.DataBind();

            if (gvPuesto.Rows.Count == 0)
            {
                sc = "$.notify({ icon: 'fas fa-times-circle', message: 'No se encontraron resultados'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
            SetScriptDataTables();

        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }

    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txt_item.Text = string.Empty;
        ddl_cargo.SelectedValue = "0";
        ddl_unidad_organizacional.SelectedValue = "0";
        ddl_direccion_administrativa.SelectedValue = "0";
        ddl_unidad_ejecutiva.SelectedValue = "0";

        listaFiltradoGestion();
    }

    private void SetScript(string data)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('#ContentPlaceHolder1_gvPuesto thead tr').clone(true).appendTo('#ContentPlaceHolder1_gvPuesto thead'); " +
            "$('#ContentPlaceHolder1_gvPuesto thead tr:eq(1) th').each(function(i) { var title = $(this).text(); " +
            "$(this).html('<input type=" + '"' + "text" + '"' + "class=" + '"' + "form-control form-control-sm" + '"' + "placeholder=" + '"' + "Buscar" + '"' + "/>'); " +
            "$('input', this).on('keyup change', function() { var table = $('#ContentPlaceHolder1_gvPuesto').DataTable(); " +
            "if (table.column(i).search() !== this.value) { table.column(i).search(this.value).draw();}" +
            "});}); ");
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
         "'sNext': '›'," +
         "'sPrevious': '‹'" +
     "}," +
     "'oAria': {" +
             "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
         "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
     "}" +
     "}," +

    "'ordering': false,'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); console.log('paso');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MDPScript", sb.ToString(), false);
    }

    private void SetScriptDataTables()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");



        sb.Append("$('#ContentPlaceHolder1_gvPuesto thead tr').clone(true).appendTo('#ContentPlaceHolder1_gvPuesto thead'); " +
            "$('#ContentPlaceHolder1_gvPuesto thead tr:eq(1) th').each(function(i) { var title = $(this).text(); " +
            "$(this).html('<input type=" + '"' + "text" + '"' + "class=" + '"' + "form-control form-control-sm" + '"' + "placeholder=" + '"' + "Buscar" + '"' + "/>'); " +
            "console.log('filterDataTable', this, i); $('input', this).on('keyup change', function() { var table = $('#ContentPlaceHolder1_gvPuesto').DataTable(); " +
            "if (table.column(i).search() !== this.value) { table.column(i).search(this.value).draw();}});});");


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
                "'sNext': '›'," +
                "'sPrevious': '‹'" +
            "}," +
            "'oAria': {" +
                "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                "}" +
            "}," +

            "'ordering': false,'searching': false, 'ordering': false, 'searching': true,'autoWidth': false, 'orderCellsTop': true,'fixedHeader': true   });");
        sb.Append("$('td').css('white-space', 'normal'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MDPScript", sb.ToString(), false);
    }

    protected void ddl_gestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        string gestionFiltrar = ddl_gestion.SelectedValue;
        listarPuestos(gestionFiltrar);
        listaFiltradoCargo(gestionFiltrar);
        listaFiltradoDirAdm(gestionFiltrar);
        listaFiltradoUnidadEjec(gestionFiltrar);
        listaFiltradoUnidadOrg(gestionFiltrar);

    }
}