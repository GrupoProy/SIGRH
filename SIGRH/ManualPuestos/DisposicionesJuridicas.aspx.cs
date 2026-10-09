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

public partial class tbl_mdp_disposicion_juridica : System.Web.UI.Page
{
    private cls_mdp_disposicion_juridica disposicionj = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null)
        {

            listarDisposicion();
        }
        else
        {
            Response.Redirect("../index");
        }
    }

    private void listarDisposicion()
    {
        try
        {
            disposicionj = new cls_mdp_disposicion_juridica();
            gv_disposicion.DataSource = disposicionj.ObtenerGrillaDisposicion();
            gv_disposicion.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_disposicion_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_disposicion.Rows.Count > 0)
        {
            if (gv_disposicion.HeaderRow != null)
            {
                gv_disposicion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_disposicion.FooterRow != null)
            {
                gv_disposicion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    
    protected void gv_disposicion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = gv_disposicion.DataKeys[index].Value.ToString();
        p_dj_id.Value = code;
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#EliminarDisposicion').modal('show');";
                SetScript(sc);
                break;

            case "GetEdit":
                disposicionj = new cls_mdp_disposicion_juridica();
                disposicionj.ObtenerDisposicionP(code);
                txt_dj_descripcion.Text = disposicionj.dj_descripcion.ToString();
                sc = "$('#EditarDisposicion').modal('show');";
                SetScript(sc);
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }
    }

    protected void btnEliminarDisposicion_Click(object sender, EventArgs e)
    {
        disposicionj = new cls_mdp_disposicion_juridica();
        disposicionj.dj_id = Convert.ToInt32(p_dj_id.Value);
        string id = p_dj_id.Value;
        disposicionj.EliminarDisposicion();
        listarDisposicion();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Disposición Jurídica eliminado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EliminarDisposicion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    
    protected void btnEditarDisposicion_Click(object sender, EventArgs e)
    {
        disposicionj = new cls_mdp_disposicion_juridica();
        disposicionj.dj_id = Convert.ToInt32(p_dj_id.Value);
        disposicionj.dj_descripcion = txt_dj_descripcion.Text.ToUpper();
        disposicionj.Actualizar();
        listarDisposicion();
        sc = "$.notify({ icon: 'fa fa-edit', message: 'Disposición Jurídica actualizado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EditarDisposicion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btnRegistrarDisposicion_Click(object sender, EventArgs e)
    {
        disposicionj = new cls_mdp_disposicion_juridica();
        disposicionj.dj_descripcion = txt_dj_descripcion_n.Text.ToUpper();
        disposicionj.Adicionar();
        Limpiar();
        listarDisposicion();
        sc = "$.notify({ icon: 'fas fa-check', message: 'Disposición Jurídica añadido correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#RegistrarDisposicion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    private void Limpiar()
    {
        txt_dj_descripcion_n.Text = string.Empty;
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
