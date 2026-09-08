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

public partial class tbl_mdp_formacion : System.Web.UI.Page
{
    private cls_mdp_formacion form_id = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null)
        {

            listaFormacion();
        }
        else
        {
            Response.Redirect("../index");
        }
        
    }

    private void listaFormacion()
    {
        try
        {
            form_id = new cls_mdp_formacion();
            gv_formacion.DataSource = form_id.ObtenerGrillaFormacion();
            gv_formacion.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_formacion_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_formacion.Rows.Count > 0)
        {
            if (gv_formacion.HeaderRow != null)
            {
                gv_formacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_formacion.FooterRow != null)
            {
                gv_formacion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_formacion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = gv_formacion.DataKeys[index].Value.ToString();
        p_fo_id.Value = code;
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#EliminarFormacion').modal('show');";
                SetScript(sc);
                break;

            case "GetEdit":
                form_id = new cls_mdp_formacion();
                form_id.ObtenerFormacionP(code);
                txt_fo_descripcion.Text = form_id.fo_descripcion.ToString();
                //ddl_formacion.SelectedItem.Value.= form_id.fo_tipo.ToString();
                dll_formacion_e.SelectedValue = form_id.fo_tipo.ToString();
                //txt_fo_tipo.Text = form_id.fo_tipo.ToString();

                sc = "$('#EditarFormacion').modal('show');";
                SetScript(sc);
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }
    }

    protected void btnEliminarFormacion_Click(object sender, EventArgs e)
    {
        form_id = new cls_mdp_formacion();
        form_id.fo_id = Convert.ToInt32(p_fo_id.Value);
        string id = p_fo_id.Value;
        form_id.EliminarFormacion();
        listaFormacion();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Formación eliminado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EliminarFormacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btnEditarFormacion_Click(object sender, EventArgs e)
    {
        form_id = new cls_mdp_formacion();
        form_id.fo_id = Convert.ToInt32(p_fo_id.Value);
        form_id.fo_descripcion = txt_fo_descripcion.Text.ToUpper();
        form_id.fo_tipo = dll_formacion_e.SelectedItem.Value.Trim(); //xt_fo_tipo.Text.ToUpper();
        form_id.Actualizar();
        listaFormacion();
        sc = "$.notify({ icon: 'fa fa-edit', message: 'Formación actualizado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EditarFormacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btnRegistrarFormacion_Click(object sender, EventArgs e)
    {
        form_id = new cls_mdp_formacion();
        form_id.fo_descripcion = txt_fo_descripcion_n.Text.ToUpper();
        form_id.fo_tipo = ddl_formacion.SelectedItem.Value.Trim(); // txt_fo_tipo_n.Text.ToUpper();
        form_id.Adicionar();
        Limpiar();
        listaFormacion();
        sc = "$.notify({ icon: 'fa fa-check', message: 'Formación añadido correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#RegistrarFormacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    private void Limpiar()
    {
        txt_fo_descripcion_n.Text = string.Empty;
        ddl_formacion.SelectedValue = "0";
        //txt_fo_tipo_n.Text = string.Empty;
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




