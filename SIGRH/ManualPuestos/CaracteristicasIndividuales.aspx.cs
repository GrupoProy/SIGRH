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

public partial class tbl_mdp_caracter_individual : System.Web.UI.Page
{
    private cls_mdp_caracter_individual carin_id = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null)
        {

            listarCaracterIndividual();
        }
        else
        {
            Response.Redirect("../index");
        }
        
    }

    private void listarCaracterIndividual()
    {
        try
        {
            carin_id = new cls_mdp_caracter_individual();
            gv_caracterIn.DataSource = carin_id.ObtenerGrillaCaracterIndividual();
            gv_caracterIn.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_caracterIn_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_caracterIn.Rows.Count > 0)
        {
            if (gv_caracterIn.HeaderRow != null)
            {
                gv_caracterIn.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_caracterIn.FooterRow != null)
            {
                gv_caracterIn.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_caracterIn_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = gv_caracterIn.DataKeys[index].Value.ToString();
        p_ci_id.Value = code;
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#EliminarCaracteristicas').modal('show');";
                SetScript(sc);
                break;

            case "GetEdit":
                carin_id = new cls_mdp_caracter_individual();
                carin_id.ObtenerCaracterIndividualP(code);
                txt_ci_orden.Text = carin_id.ci_orden.ToString();
                txt_ci_factor.Text = carin_id.ci_factor.ToString();
                txt_ci_descripcion.Text = carin_id.ci_descripcion.ToString();
                txt_ci_puntaje.Text = carin_id.ci_puntaje.ToString();
                sc = "$('#EditarCaracteristicas').modal('show');";
                SetScript(sc);
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }
    }

    protected void btnEliminarCaracterInd_Click(object sender, EventArgs e)
    {
        carin_id = new cls_mdp_caracter_individual();
        carin_id.ci_id = Convert.ToInt32(p_ci_id.Value);
        string id = p_ci_id.Value;
        carin_id.EliminarCaracterInd();
        listarCaracterIndividual();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message:'Carácter Individual eliminado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EliminarCaracteristicas').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btnEditarCaracterInd_Click(object sender, EventArgs e)
    {
        carin_id = new cls_mdp_caracter_individual();
        carin_id.ci_id= Convert.ToInt32(p_ci_id.Value);
        carin_id.ci_orden = Convert.ToInt32(txt_ci_orden.Text);
        carin_id.ci_factor = txt_ci_factor.Text.ToUpper();
        carin_id.ci_descripcion = txt_ci_descripcion.Text.ToUpper();
        carin_id.ci_puntaje = Convert.ToInt32(txt_ci_puntaje.Text);
        carin_id.Actualizar();
        listarCaracterIndividual();
        sc = "$.notify({ icon: 'fa fa-edit', message: 'Carácter Individual actualizado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EditarCaracteristicas').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btnRegistrarCaracteriticas_Click(object sender, EventArgs e)
    {
        carin_id = new cls_mdp_caracter_individual();
        carin_id.ci_orden = Convert.ToInt32(txt_ci_orden_n.Text);
        carin_id.ci_factor = txt_ci_factor_n.Text.ToUpper();
        carin_id.ci_descripcion = txt_ci_descripcion_n.Text.ToUpper();
        carin_id.ci_puntaje = Convert.ToInt32(txt_ci_puntaje_n.Text);
        carin_id.Adicionar();
        Limpiar();
        listarCaracterIndividual();
        sc = "$.notify({ icon: 'fa fa-check', message: 'Carácter Individual añadido correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#RegistrarCaracteristicas').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    private void Limpiar()
    {
        txt_ci_orden_n.Text = string.Empty;
        txt_ci_factor_n.Text = string.Empty;
        txt_ci_descripcion_n.Text = string.Empty;
        txt_ci_puntaje_n.Text = string.Empty;
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


