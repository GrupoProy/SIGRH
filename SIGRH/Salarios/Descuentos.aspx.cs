using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class Salarios_Descuentos : System.Web.UI.Page
{
    private cls_pla_factor factor = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            ListarDescuentos();
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
        sb.Append("$('.decimal').on('input', function (event) { this.value = this.value.replace(/[^,0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
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
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gv_descuentos_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_descuentos.Rows.Count > 0)
        {
            if (gv_descuentos.HeaderRow != null)
            {
                gv_descuentos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_descuentos.FooterRow != null)
            {
                gv_descuentos.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_descuentos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string fa_id = gv_descuentos.DataKeys[index].Values[0].ToString();
        aux_fa_id.Value = fa_id;
        switch (e.CommandName)
        {
            case "GetEdit":
                aux_accion.Value = "1";
                ltl_titulo.Text = "EDITAR FACTOR";
                LlenarDatosFactor(Convert.ToInt32(fa_id));
                sc = "$('#modalNuevoFactor').modal('show');";
                SetScript(sc);
                break;
            case "GetDelete":
                sc = "$('#eliminarFactor').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    private void ListarDescuentos()
    {
        try
        {
            factor = new cls_pla_factor();
            gv_descuentos.DataSource = factor.ListarGrillaDescuentos();
            gv_descuentos.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_nuevo_factor_Click(object sender, EventArgs e)
    {
        Limpiar();
        aux_accion.Value = "0";
        ltl_titulo.Text = "REGISTRAR DESCUENTO";
        sc = "$('#modalNuevoFactor').modal('show');";
        SetScript(sc);
    }

    protected void btn_adicionar_factor_Click(object sender, EventArgs e)
    {
        if (aux_accion.Value == "1")
        {
            EditarFactor();
        }
        else
        {
            GuardarNuevoFactor();
        }
        Limpiar();
        ListarDescuentos();
    }

    protected void Limpiar()
    {
        txt_descripcion_factor.Text = string.Empty;
        txt_signo.Text = string.Empty;
        txt_tipo_calculo.Text = string.Empty;
        txt_valor.Text = string.Empty;
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

    protected void LlenarDatosFactor(int fa_id = 0)
    {
        factor = new cls_pla_factor();
        factor.fa_id = fa_id;
        var detalleFactor = factor.ObtenerFactorX();
        var factorX = detalleFactor.Tables[0].Rows[0];
        txt_descripcion_factor.Text = validarCampo(factorX["fa_descripcion"]);
        txt_signo.Text = validarCampo(factorX["fa_signo"]);
        txt_tipo_calculo.Text = validarCampo(factorX["fa_tipo_calculo"]);
        txt_valor.Text = validarCampo(factorX["fa_valor"]);
    }

    private void GuardarNuevoFactor()
    {
        factor = new cls_pla_factor
        {
            fa_descripcion = txt_descripcion_factor.Text,
            fa_signo = txt_signo.Text,
            fa_tipo_calculo = txt_tipo_calculo.Text,
            fa_valor = Convert.ToDouble(txt_valor.Text)
        };
        factor.Adicionar();
        sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Factor registrado exitosamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevoFactor').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    private void EditarFactor()
    {
        factor = new cls_pla_factor();
        factor.fa_id = Convert.ToInt32(aux_fa_id.Value);
        factor.fa_descripcion = txt_descripcion_factor.Text;
        factor.fa_signo = txt_signo.Text;
        factor.fa_tipo_calculo = txt_tipo_calculo.Text;
        factor.fa_valor = Convert.ToDouble(txt_valor.Text);
        factor.ActualizarFactor();
        sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-check', message: 'Factor editado correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });$('#modalNuevoFactor').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_eliminar_factor_Click(object sender, EventArgs e)
    {
        factor = new cls_pla_factor();
        factor.fa_id = Convert.ToInt32(aux_fa_id.Value);
        factor.Eliminar();
        ListarDescuentos();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarFactor').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
}