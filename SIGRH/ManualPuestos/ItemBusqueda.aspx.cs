using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
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
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (!Page.IsPostBack)
        {
            Session["intervalo"] = true;
            if (HttpContext.Current.Session["us_id"] != null)
            {
                listaFiltradoGestion();
            }
            else
            {
                Response.Redirect("../index");
            }
        }

    }

    private void listarPuestos (string gestionFiltrar)
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
        string poai_ca_id = gvPuesto.DataKeys[index].Values[1].ToString();
        string item = gvPuesto.DataKeys[index].Values[2].ToString();

        string gestionActual = ddl_gestion.Items[0].Value;
        Session["editarGestion"] = (ddl_gestion.SelectedValue == gestionActual) ? true : true;

        sc = (chk_intervalo.Checked) ? "$('#blockItem').removeClass('col-md-8').addClass('col-md-4'); $('#blockHastaItem').css('display', 'block'); " : "$('#blockItem').removeClass('col-md-4').addClass('col-md-8'); $('#blockHastaItem').css('display', 'none'); ";
        switch (e.CommandName)
        {
            case "GetDetail":
                var inter = Session["intervalo"];
                Response.Redirect("ItemDetalle?id=" + idFicha);
                //sc = "window.open('tbl_mdp_resultados_especificos.aspx?id=" + idFicha + "','_blank');";
                //SetScript(sc);
                break;
            case "GetItemNow":
                DataTable historico = new DataTable();
                historico.Columns.Add("as_id");
                historico.Columns.Add("nombre_fun");
                historico.Columns.Add("fecha_inicio");
                historico.Columns.Add("fecha_fin");
                historico.Columns.Add("estado");
                historico.Columns.Add("item");
                historico.Columns.Add("cargo");
                historico.Columns.Add("poai_id");
                historico.Columns.Add("poai_anterior_id");
                historico.Columns.Add("puesto");
                var listaHistorico = armarHistorico(historico, Convert.ToInt32(idFicha));

                gv_item_hist.DataSource = listaHistorico;
                gv_item_hist.DataBind();
                sc = sc + "$('#modalHistoricoItem').modal('show');";
                SetScript(sc);
                break;

            case "GetDetailReport":
                Session["idFicha"] = gvPuesto.DataKeys[index].Value.ToString();
                //Response.Redirect("Reportes/Reporte_POAI.aspx");
                SetScript(sc + "window.open('Reportes/Reporte_POAI.aspx','_blank');");
                break;

            default:
                break;
        }

    }
    private DataTable armarHistorico(DataTable historico, int id_ficha_anterior)
    {
        puestos = new cls_mdp_puesto();
        puestos.ca_num_item = Convert.ToInt32(id_ficha_anterior);
        DataRow dr = null;

        var item = puestos.ObtenerHistoricoItem();
        if (item.Tables[0].Rows.Count > 0)
        {
            var itemSeleccionado = item.Tables[0].Rows[0];
            int poai_id = Convert.ToInt32(validarCampo(itemSeleccionado["poai_id"]));
            int poai_anterior_id  = Convert.ToInt32(validarCampo(itemSeleccionado["poai_anterior_id"]));

            if (poai_id != poai_anterior_id && poai_anterior_id != 0)
            {
                dr = historico.NewRow();
                dr["as_id"] = validarCampo(itemSeleccionado["as_id"]);
                dr["nombre_fun"] = validarCampo(itemSeleccionado["nombre_fun"]);
                dr["fecha_inicio"] = validarCampo(itemSeleccionado["fecha_inicio"]);
                dr["fecha_fin"] = validarCampo(itemSeleccionado["fecha_fin"]);
                dr["estado"] = validarCampo(itemSeleccionado["estado"]);
                dr["item"] = validarCampo(itemSeleccionado["item"]);
                dr["cargo"] = validarCampo(itemSeleccionado["cargo"]);
                dr["poai_id"] = validarCampo(itemSeleccionado["poai_id"]);
                dr["poai_anterior_id"] = validarCampo(itemSeleccionado["poai_anterior_id"]);
                dr["puesto"] = validarCampo(itemSeleccionado["puesto"]);
                historico.Rows.Add(dr);
                armarHistorico(historico, poai_anterior_id);
            } 
        }
        return historico;
    }
    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
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

    //private void listaFiltradoDirAdm(string gestionFiltrar)
    //{
    //    try
    //    {
    //        puestos = new cls_mdp_puesto();
    //        puestos.gestion_selec = gestionFiltrar;

    //        ddl_direccion_administrativa.Items.Clear();
    //        ddl_direccion_administrativa.Items.Insert(0, new ListItem("Seleccione...", "0"));
    //        ddl_direccion_administrativa.DataValueField = "cp_da";
    //        ddl_direccion_administrativa.DataTextField = "cp_da_descripcion";
    //        ddl_direccion_administrativa.DataSource = puestos.ObtenerFiltradoDirAdm();
    //        ddl_direccion_administrativa.DataBind();

    //        ddl_direccion_administrativa.Enabled = (ddl_direccion_administrativa.Items.Count > 1) ? true : false;
    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}

    //private void listaFiltradoUnidadEjec(string gestionFiltrar)
    //{
    //    try
    //    {
    //        puestos = new cls_mdp_puesto();
    //        puestos.gestion_selec = gestionFiltrar;

    //        ddl_unidad_ejecutiva.Items.Clear();
    //        ddl_unidad_ejecutiva.Items.Insert(0, new ListItem("Seleccione...", "0"));
    //        ddl_unidad_ejecutiva.DataValueField = "cp_ue";
    //        ddl_unidad_ejecutiva.DataTextField = "cp_ue_descripcion";
    //        ddl_unidad_ejecutiva.DataSource = puestos.ObtenerFiltradoUnidadEjec();
    //        ddl_unidad_ejecutiva.DataBind();

    //        ddl_unidad_ejecutiva.Enabled = (ddl_unidad_ejecutiva.Items.Count > 1) ? true : false;
    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}

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
        int pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        try
        {
            puestos = new cls_mdp_puesto();

            ddl_gestion.DataValueField = "pr_id";
            ddl_gestion.DataTextField = "periodo";
            ddl_gestion.DataSource = puestos.ObtenerFiltradoGestion();
            ddl_gestion.DataBind();

            var gestionActual = puestos.ObtenerGestion();

            if (gestionActual.Tables[0].Rows.Count > 0)
            {
                if (gestionActual.Tables[0].Rows[0]["pr_id"] != DBNull.Value && gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim() != "")
                {
                    ddl_gestion.SelectedValue = pr_id + "";
                    string gestionFiltrar = pr_id + "";
                    listaFiltradoCargo(gestionFiltrar);
                    //listaFiltradoDirAdm(gestionFiltrar);
                   // listaFiltradoUnidadEjec(gestionFiltrar);
                    listaFiltradoUnidadOrg(gestionFiltrar);

                    sc = "";
                    SetScript(sc);
                }
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
        
        string item = txt_item.Text.Trim();
        string hasta_item = txt_hasta_item.Text.Trim();
        string cargo = ddl_cargo.SelectedItem.Text.Trim();
        string direccion_administrativa = "Seleccione..."; //ddl_direccion_administrativa.SelectedItem.Text.Trim(); //
        string unidad_ejecutiva = "Seleccione...";// ddl_unidad_ejecutiva.SelectedItem.Text.Trim();//"Seleccione...";
        string unidad_organizacional = ddl_unidad_organizacional.SelectedItem.Text.Trim();

        if (chk_intervalo.Checked)
        {
            if (item != "" && hasta_item != "")
            {
                if (Convert.ToInt32(item) < Convert.ToUInt32(hasta_item))
                {
                    try
                    {
                        puestos.param1 = (item != null && item != "") ? item : "";
                        puestos.param2 = (cargo != null && cargo != "" && cargo != "Seleccione...") ? cargo : "";
                        puestos.param3 = (direccion_administrativa != null && direccion_administrativa != "" && direccion_administrativa != "Seleccione...") ? direccion_administrativa : "";
                        puestos.param4 = (unidad_ejecutiva != null && unidad_ejecutiva != "" && unidad_ejecutiva != "Seleccione...") ? unidad_ejecutiva : "";
                        puestos.param5 = (unidad_organizacional != null && unidad_organizacional != "" && unidad_organizacional != "Seleccione...") ? unidad_organizacional : "";
                        puestos.param6 = (hasta_item != null && hasta_item != "") ? hasta_item : "";

                        puestos.gestion_selec = ddl_gestion.SelectedValue;

                        var puestos_resp = puestos.ObtenerGrillaFiltroIntervalo();
                        int total_puestos = puestos_resp.Tables[0].Rows.Count;
                        gvPuesto.DataSource = puestos_resp;
                        gvPuesto.DataBind();


                        if (gvPuesto.Rows.Count == 0)
                        {
                            sc = "$.notify({ icon: 'fas fa-times-circle', message: 'No se encontraron resultados'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
                        }
                        else
                        {
                            sc = "$('#grillaPuestos').css('display', 'block');";
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.Error.Write(ex.Message);
                    }
                }
                else
                {
                    sc = "$.notify({ icon: 'fas fa-times-circle', message: 'El rango de ítems es incorrecto.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); ";
                }
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-times-circle', message: 'El rango de ítems es incorrecto.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); ";
            }
            sc = sc + "$('#blockItem').removeClass('col-md-8').addClass('col-md-4'); $('#blockHastaItem').css('display', 'block');";
            SetScript(sc);
        }
        else
        {
            try
            {
                puestos.param1 = (item != null && item != "") ? item : "";
                puestos.param2 = (cargo != null && cargo != "" && cargo != "Seleccione...") ? cargo : "";
                puestos.param3 = (direccion_administrativa != null && direccion_administrativa != "" && direccion_administrativa != "Seleccione...") ? direccion_administrativa : "";
                puestos.param4 = (unidad_ejecutiva != null && unidad_ejecutiva != "" && unidad_ejecutiva != "Seleccione...") ? unidad_ejecutiva : "";
                puestos.param5 = (unidad_organizacional != null && unidad_organizacional != "" && unidad_organizacional != "Seleccione...") ? unidad_organizacional : "";

                puestos.gestion_selec = ddl_gestion.SelectedValue;

                var puestos_resp = puestos.ObtenerGrillaFiltro();
                int total_puestos = puestos_resp.Tables[0].Rows.Count;
                gvPuesto.DataSource = puestos_resp;
                gvPuesto.DataBind();


                if (gvPuesto.Rows.Count == 0)
                {
                    sc = "$.notify({ icon: 'fas fa-times-circle', message: 'No se encontraron resultados'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
                }
                else
                {
                    sc = "$('#grillaPuestos').css('display', 'block');";
                }
            }
            catch (Exception ex)
            {
                Console.Error.Write(ex.Message);
            }
            sc = sc + " $('#blockItem').removeClass('col-md-4').addClass('col-md-8'); $('#blockHastaItem').css('display', 'none');";
            SetScript(sc);
        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        txt_item.Text = string.Empty;
        txt_hasta_item.Text = string.Empty;
        ddl_cargo.SelectedValue = "0";
        ddl_unidad_organizacional.SelectedValue = "0";
        ddl_direccion_administrativa.SelectedValue = "0";
        ddl_unidad_ejecutiva.SelectedValue = "0";

        gvPuesto.DataSource = null;
        gvPuesto.DataBind();

        listaFiltradoGestion();

        sc = (chk_intervalo.Checked) ? "$('#blockItem').removeClass('col-md-8').addClass('col-md-4'); $('#blockHastaItem').css('display', 'block'); " : "$('#blockItem').removeClass('col-md-4').addClass('col-md-8'); $('#blockHastaItem').css('display', 'none'); ";
        sc = sc + "$('#grillaPuestos').css('display', 'none');";
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
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
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
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); console.log('cargarTooltip'); }");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "MDPScript", sb.ToString(), false);
    }
    protected void ddl_gestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        sc = (chk_intervalo.Checked) ? "$('#blockItem').removeClass('col-md-8').addClass('col-md-4'); $('#blockHastaItem').css('display', 'block'); " : "$('#blockItem').removeClass('col-md-4').addClass('col-md-8'); $('#blockHastaItem').css('display', 'none'); ";
        string gestionFiltrar = ddl_gestion.SelectedValue;
        //listarPuestos(gestionFiltrar);
        listaFiltradoCargo(gestionFiltrar);
        //listaFiltradoDirAdm(gestionFiltrar);
        //listaFiltradoUnidadEjec(gestionFiltrar);
        listaFiltradoUnidadOrg(gestionFiltrar);
        SetScript(sc);
    }

    protected void gv_item_hist_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_item_hist.Rows.Count > 0)
        {
            if (gv_item_hist.HeaderRow != null)
            {
                gv_item_hist.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_item_hist.FooterRow != null)
            {
                gv_item_hist.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_item_hist_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btn_cerrar_hitorico_Click(object sender, EventArgs e)
    {
        sc = (chk_intervalo.Checked) ? "$('#blockItem').removeClass('col-md-8').addClass('col-md-4'); $('#blockHastaItem').css('display', 'block'); " : "$('#blockItem').removeClass('col-md-4').addClass('col-md-8'); $('#blockHastaItem').css('display', 'none'); ";
        sc = sc + "$('#modalHistoricoItem').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void chk_intervalo_CheckedChanged(object sender, EventArgs e)
    {
        txt_item.Text = string.Empty;
        txt_hasta_item.Text = string.Empty;
        if (chk_intervalo.Checked)
        {
            //rfv_txt_item.Enabled = true;
            //rfv_txt_hasta_item.Enabled = true;
            Session["intervalo"] = true;
            sc = "$('#blockItem').removeClass('col-md-8').addClass('col-md-4'); $('#blockHastaItem').css('display', 'block');";
            SetScript(sc);
        } else
        {
            //rfv_txt_item.Enabled = false;
            //rfv_txt_hasta_item.Enabled = false;
            Session["intervalo"] = false;
            sc = "$('#blockItem').removeClass('col-md-4').addClass('col-md-8'); $('#blockHastaItem').css('display', 'none');";
            SetScript(sc);
        }

    }
}