using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ManualPuestos_frmPuestosCM : System.Web.UI.Page
{
    private cls_mdp_puesto puestos = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (HttpContext.Current.Session["us_id"] != null)
            {

                modalGuardarConocimientoCM.Enabled = false;
                puestos = new cls_mdp_puesto();
                string anio = DateTime.Now.ToString("yyyy");
                puestos.gestion = anio;
                var gestionActual = puestos.ObtenerGestion();
                if (gestionActual.Tables[0].Rows[0]["pr_id"] != DBNull.Value && gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim() != "")
                {
                    string gestionFiltrar = (Session["pr_id"] != null) ? Session["pr_id"].ToString() : "0";
                    listaFiltradoCargo(gestionFiltrar);
                    //listaFiltradoDirAdm(gestionFiltrar);
                    //listaFiltradoUnidadEjec(gestionFiltrar);
                    listaFiltradoUnidadOrg(gestionFiltrar);
                    listaFiltradoConcocimiento();
                }
            }
            else
            {
                Response.Redirect("../index");
            }
  
        }
    }

    protected void gvPuestoCM_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvPuestoCM.Rows.Count > 0)
        {
            if (gvPuestoCM.HeaderRow != null)
            {
                gvPuestoCM.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvPuestoCM.FooterRow != null)
            {
                gvPuestoCM.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gvPuestoCM_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string idFicha = gvPuestoCM.DataKeys[index].Values[0].ToString();
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

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {
        puestos = new cls_mdp_puesto();
        //string cargo = ddl_cargo.SelectedItem.Value;
        string cargo = ddl_cargo.SelectedItem.Text.Trim();
        string direccion_administrativa = "Seleccione..."; //ddl_direccion_administrativa.SelectedItem.Text.Trim();
        string unidad_ejecutiva = "Seleccione..."; //ddl_unidad_ejecutiva.SelectedItem.Text.Trim();
        string unidad_organizacional = ddl_unidad_organizacional.SelectedItem.Text.Trim();

        if (cargo == "Seleccione..." && direccion_administrativa == "Seleccione..." && unidad_ejecutiva == "Seleccione..." && unidad_organizacional == "Seleccione...")
        {
            sc = "$.notify({ icon: 'fas fa-times-circle', message: 'Debe seleccionar uno de los filtros de búsqueda'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); $('.aspNetDisabled ').addClass('disabled'); $('#ContentPlaceHolder1_ddl_cargo').select2(); $('#ContentPlaceHolder1_ddl_unidad_organizacional').select2(); $('#ContentPlaceHolder1_ddl_direccion_administrativa').select2(); $('#ContentPlaceHolder1_ddl_unidad_ejecutiva').select2(); ";
            SetScript(sc);
            modalGuardarConocimientoCM.Enabled = false;
        }
        else
        {
            modalGuardarConocimientoCM.Enabled = true;
            try
            {
                puestos.param2 = (cargo != null && cargo != "" && cargo != "Seleccione...") ? cargo : "";
                puestos.param3 = (direccion_administrativa != null && direccion_administrativa != "" && direccion_administrativa != "Seleccione...") ? direccion_administrativa : "";
                puestos.param4 = (unidad_ejecutiva != null && unidad_ejecutiva != "" && unidad_ejecutiva != "Seleccione...") ? unidad_ejecutiva : "";
                puestos.param5 = (unidad_organizacional != null && unidad_organizacional != "" && unidad_organizacional != "Seleccione...") ? unidad_organizacional : "";
        
                puestos.gestion_selec = (Session["pr_id"] != null) ? Session["pr_id"].ToString() : "0";
                gvPuestoCM.DataSource = puestos.ObtenerGrillaFiltroConocimientoCM();
                gvPuestoCM.DataBind();
                gvPuestoCM_PreRender(sender, e);

                if (gvPuestoCM.Rows.Count == 0)
                {
                    sc = "$.notify({ icon: 'fas fa-times-circle', message: 'No se encontraron resultados'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); $('#grillaTareasBlock').css('display', 'none'); $('#descripcionConocimiento').css('display', 'none'); $('#ContentPlaceHolder1_ddl_cargo').select2(); $('#ContentPlaceHolder1_ddl_unidad_organizacional').select2(); $('#ContentPlaceHolder1_ddl_direccion_administrativa').select2(); $('#ContentPlaceHolder1_ddl_unidad_ejecutiva').select2();";
                    SetScript(sc);
                }
                else
                {
                    sc = "$('#grillaTareasBlock').css('display', 'block'); $('#descripcionConocimiento').css('display', 'block'); ";
                    SetScript(sc);
                }
                SetScriptDataTables();
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex.Message);
            }
        }
    }

    private void listaFiltradoConcocimiento()
    {
        try
        {
            puestos = new cls_mdp_puesto();

            //poai_id.ico_poai_id = Convert.ToInt32(id);
            //ddl_conocimineto_add.DataSource = null;
            ddl_conocimineto_add.Items.Clear();
            ddl_conocimineto_add.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_conocimineto_add.DataValueField = "co_id";
            ddl_conocimineto_add.DataTextField = "co_descripcion";
            ddl_conocimineto_add.DataSource = puestos.ObtenerFiltradoConcocimiento();
            ddl_conocimineto_add.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btnGuardarCM_Click(object sender, EventArgs e)
    {
        if (gvPuestoCM.Rows.Count > 0)
        {
            foreach (GridViewRow gvr in gvPuestoCM.Rows)
            {
                string ico_id = ddl_conocimineto_add.SelectedValue;
                string ico_poai_id = gvPuestoCM.DataKeys[gvr.RowIndex].Values[0].ToString();
                puestos = new cls_mdp_puesto();
                puestos.co_id = Convert.ToInt32(ico_id);
                puestos.co_poai_id = Convert.ToInt32(ico_poai_id);
                if (!puestos.validaRegistroConocimiento())
                {
                    puestos.AdicionarConocimientoCM();
                }
            }
            sc = "$.notify({ icon: 'fa fa-check', message: 'Conocimientos Complementarios añadido correctamente a los items seleccionados'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#modalGuardarCM').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#grillaTareasBlock').css('display', 'none'); $('#descripcionConocimiento').css('display', 'none'); $('#ContentPlaceHolder1_ddl_cargo').select2(); $('#ContentPlaceHolder1_ddl_unidad_organizacional').select2(); $('#ContentPlaceHolder1_ddl_direccion_administrativa').select2(); $('#ContentPlaceHolder1_ddl_unidad_ejecutiva').select2();";
            SetScript(sc);
            Limpiar();
        }
    }

    protected void modalGuardarConocimientoCM_Click(object sender, EventArgs e)
    {
        sc = "$('#modalGuardarCM').modal('show');";
        SetScript(sc);
    }

    private void Limpiar()
    {
        gvPuestoCM.DataSource = null;
        gvPuestoCM.DataBind();
        ddl_conocimineto_add.SelectedValue = "0";
        ddl_cargo.SelectedValue = "0";
        ddl_unidad_organizacional.SelectedValue = "0";
        ddl_direccion_administrativa.SelectedValue = "0";
        ddl_unidad_ejecutiva.SelectedValue = "0";
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        ddl_cargo.SelectedValue = "0";
        ddl_unidad_organizacional.SelectedValue = "0";
        ddl_direccion_administrativa.SelectedValue = "0";
        ddl_unidad_ejecutiva.SelectedValue = "0";
        sc = "$('#ContentPlaceHolder1_ddl_cargo').select2(); $('#ContentPlaceHolder1_ddl_unidad_organizacional').select2(); $('#ContentPlaceHolder1_ddl_direccion_administrativa').select2(); $('#ContentPlaceHolder1_ddl_unidad_ejecutiva').select2();";
        SetScript(sc);
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
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
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
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MDPScript", sb.ToString(), false);
    }
}