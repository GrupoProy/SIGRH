using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Kardex.BussinessLogicLayer;



public partial class Kardex_RegistroFeriados : System.Web.UI.Page
{
    private cls_kd_feriados feriados = null;

    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listarFeriados();
        }
    }

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.fecha').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
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
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gv_feriados_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_feriados.Rows.Count > 0)
        {
            if (gv_feriados.HeaderRow != null)
            {
                gv_feriados.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_feriados.FooterRow != null)
            {
                gv_feriados.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_feriados_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string fe_id = gv_feriados.DataKeys[index].Values[0].ToString();
        aux_fe_id.Value = fe_id;
        switch (e.CommandName)
        {
            case "GetEdit":
                aux_accion.Value = "1";
                ltl_titulo.Text = "EDITAR FERIADO";
                LlenarDatosFeriado(Convert.ToInt32(fe_id));
                sc = "$('#modalNuevoFeriado').modal('show');";
                SetScript(sc);
                break;
            case "GetDelete":
                sc = "$('#modalEliminarFeriado').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    private void listarFeriados()
    {
        try
        {
            feriados = new cls_kd_feriados();
            gv_feriados.DataSource = feriados.ObtenerGrillaFeriados();
            gv_feriados.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_nuevo_feriado_Click(object sender, EventArgs e)
    {
        Limpiar();
        aux_accion.Value = "0";
        ltl_titulo.Text = "REGISTRAR FERIADO";
        sc = "$('#modalNuevoFeriado').modal('show');";
        SetScript(sc);
    }

    protected void btn_adicionar_nuevoFeriado_Click(object sender, EventArgs e)
    {
        if (aux_accion.Value == "1")
        {
            EditarFeriado();
        }
        else
        {
            GuardarNuevoFeriado();
        }
        Limpiar();
        listarFeriados();
    }

    private void GuardarNuevoFeriado()
    {
        feriados = new cls_kd_feriados
        {
            fe_fecha = txt_fecha_feriado.Text,
            fe_descripcion = txt_descripcion_feriado.Text
        };
        feriados.Adicionar();
        sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Feriado registrado exitosamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevoFeriado').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void Limpiar()
    {
        txt_fecha_feriado.Text = string.Empty;
        txt_descripcion_feriado.Text = string.Empty;
    }

    private void EditarFeriado()
    {
        feriados = new cls_kd_feriados();
        feriados.fe_id = Convert.ToInt32(aux_fe_id.Value);
        feriados.fe_fecha = txt_fecha_feriado.Text;
        feriados.fe_descripcion = txt_descripcion_feriado.Text;
        feriados.Actualizar();
        sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-check', message: 'Feriado editado correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });$('#modalNuevoFeriado').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void LlenarDatosFeriado(int fe_id = 0)
    {
        feriados = new cls_kd_feriados();
        feriados.fe_id = fe_id;
        var detalleFeriado = feriados.ObtenerFeriadoX();
        var feriadoX = detalleFeriado.Tables[0].Rows[0];
        txt_fecha_feriado.Text = validarCampo(feriadoX["fe_fecha"]);
        txt_descripcion_feriado.Text = validarCampo(feriadoX["fe_descripcion"]);
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

    protected void btn_eliminar_feriado_Click(object sender, EventArgs e)
    {
        feriados = new cls_kd_feriados();
        feriados.fe_id = Convert.ToInt32(aux_fe_id.Value);
        feriados.Eliminar();
        listarFeriados();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#modalEliminarFeriado').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
}