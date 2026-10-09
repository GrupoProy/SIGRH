using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using System.Text;

public partial class tbl_mdp_conocimiento : System.Web.UI.Page
{
    private cls_mdp_conocimiento con_id = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null)
        {

            con_id = new cls_mdp_conocimiento();
            listarConocimientos();
        }
        else
        {
            Response.Redirect("../index");
        }
   
    }

    private void listarConocimientos()
    {
        try
        {
            con_id = new cls_mdp_conocimiento();
            gv_conocimiento.DataSource = con_id.ObtenerGrillaConocimiento();
            gv_conocimiento.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_conocimiento_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_conocimiento.Rows.Count > 0)
        {
            if (gv_conocimiento.HeaderRow != null)
            {
                gv_conocimiento.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_conocimiento.FooterRow != null)
            {
                gv_conocimiento.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_conocimiento_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = gv_conocimiento.DataKeys[index].Value.ToString();
        p_co_id.Value = code;
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#EliminarConocimiento').modal('show');";
                SetScript(sc);
                break;

            case "GetEdit":
                con_id = new cls_mdp_conocimiento();
                con_id.ObtenerConocimientoP(code);
                txt_co_descripcion.Text = con_id.co_descripcion.ToString();
                sc = "$('#EditarConocimiento').modal('show');";
                SetScript(sc);
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }
    }

    protected void btnEliminarConocimiento_Click(object sender, EventArgs e)
    {
        con_id = new cls_mdp_conocimiento();
        con_id.co_id = Convert.ToInt32(p_co_id.Value);
        string id = p_co_id.Value;
        con_id.EliminarConocimiento();
        listarConocimientos();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Conocimiento eliminado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EliminarConocimiento').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
       
    }

    protected void btnEditarConocimiento_Click(object sender, EventArgs e)
    {
        con_id = new cls_mdp_conocimiento();
        con_id.co_id = Convert.ToInt32(p_co_id.Value);
        con_id.co_descripcion = txt_co_descripcion.Text.ToUpper();
        con_id.Actualizar();
        listarConocimientos();
        sc = "$.notify({ icon: 'fa fa-edit', message: 'Conocimiento actualizado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EditarConocimiento').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btnRegistrarConocimiento_Click(object sender, EventArgs e)
    {
        con_id = new cls_mdp_conocimiento();
        con_id.co_descripcion = txt_co_descripcion_n.Text.ToUpper();
        con_id.Adicionar();
        Limpiar();
        listarConocimientos();
        sc = "$.notify({ icon: 'fa fa-check', message: 'Conocimiento añadido correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#RegistrarConocimiento').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    private void Limpiar()
    {
        txt_co_descripcion_n.Text = string.Empty;
    }

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
            "'sNext': '›'," +
            "'sPrevious': '‹'" +
        "}," +
        "'oAria': {" +
                "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
            "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
        "}" +
        "}," +

  "'responsive': true });");


        sb.Append("$('.tooltip').css('display','none');");


        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }
}
