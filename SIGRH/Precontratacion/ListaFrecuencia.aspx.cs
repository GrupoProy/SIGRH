using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_Precontratacion.BussinessLogicLayer;
public partial class Precontratacion_Frecuencia : System.Web.UI.Page
{
    private cls_pc_frecuencia frecuencia = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                //listaFiltradoGestion();
                //sc = "$('#modalPeriodo').modal('show'); $('#ContentPlaceHolder1_ddl_gestion').select2({ dropdownParent: $('#modalPeriodo') });";
                //SetScriptInicio(sc);


            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }
    //private void SetScriptInicio(string data)
    //{
    //    Guid g;
    //    g = Guid.NewGuid();
    //    string uuid = g.ToString();

    //    ClientScript.RegisterStartupScript(this.GetType(), uuid, data, true);
    //}
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

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
          "'sNext': '<i class=" + '"' + "fas fa-angle-right" + '"' + "></i>'," +
          "'sPrevious': '<i class=" + '"' + "fas fa-angle-left" + '"' + "></i>'" +
          "}," +
          "'oAria': {" +
          "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
          "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
          "}" +
          "}," +
          "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_gestion').select2({ dropdownParent: $('#modalPeriodo') });");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
    //private void listaFiltradoGestion()
    //{
    //    try
    //    {
    //        frecuencia = new cls_pc_frecuencia();

    //        ddl_gestion.Items.Clear();
    //        ddl_gestion.DataValueField = "pr_id";
    //        ddl_gestion.DataTextField = "pr_gestion";
    //        ddl_gestion.DataSource = frecuencia.ObtenerFiltradoGestion();
    //        ddl_gestion.DataBind();
    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}
    //protected void btn_cancelar_gestion_Click(object sender, EventArgs e)
    //{
    //    sc = "$('#modalPeriodo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    //    SetScript(sc);
    //    Response.Redirect("../Inicio/Sigrh");
    //}

    //protected void btn_gestion_Click(object sender, EventArgs e)
    //{
    //    ltl_desc_gestion.Text = "Gestión " + ddl_gestion.SelectedItem.Text;
    //    hf_pr_id.Value = ddl_gestion.SelectedValue;
    //    hf_perm_per_id.Value = Session["per_id"].ToString();
    //    sc = "$('#modalPeriodo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    //    SetScript(sc);
    //}

    protected void btn_buscar_categorias_Click(object sender, EventArgs e)
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.cp_da = (txt_da.Text != "") ? Convert.ToInt32(txt_da.Text) : 0;
        frecuencia.cp_ue = (txt_ue.Text != "") ? Convert.ToInt32(txt_ue.Text) : 0;
        frecuencia.cp_programa = (txt_prog.Text != "") ? Convert.ToInt32(txt_prog.Text) : 0;
        frecuencia.cp_proyecto = (txt_proy.Text != "") ? Convert.ToInt32(txt_proy.Text) : 0;
        frecuencia.cp_actividad = (txt_act.Text != "") ? Convert.ToInt32(txt_act.Text) : 0;

        frecuencia.fr_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        frecuencia.perm_us_id = Convert.ToInt32(Session["us_id"].ToString());
        var categoria = frecuencia.BuscarCategorias();
        int tam_cat = categoria.Tables[0].Rows.Count;

        if (tam_cat > 0)
        {
            gv_categorias.DataSource = categoria;
            gv_categorias.DataBind();
            sc = "$('#grillaCategorias').css('display', 'block');";
            SetScript(sc);
        }
        else
        {
            gv_categorias.DataSource = categoria;
            gv_categorias.DataBind();
            sc = "$('#grillaCategorias').css('display', 'none'); $.notify({ icon: 'fa fa-exclamation', message:'No existen resultados por mostrar.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

    }

    protected void gv_categorias_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_categorias.Rows.Count > 0)
        {
            if (gv_categorias.HeaderRow != null)
            {
                gv_categorias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_categorias.FooterRow != null)
            {
                gv_categorias.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_categorias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string cp_id = gv_categorias.DataKeys[index].Values[0].ToString();

        switch (e.CommandName)
        {
            case "GetAssign":
                Response.Redirect("Frecuencia?id=" + cp_id + "&id2=" + Session["pr_id"].ToString());
                break;
            //case "GetEdit":
            //    break;
            default:
                break;
        }
    }
}