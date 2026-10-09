using System;
using System.Collections.Generic;
using System.Data;
// 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;


public partial class BienestarSocial_RegistroBajaEGS : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_bs_asignacion_beneficio beneficio = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listarGrillaBajas();
            SetScriptInicio("$('.table').DataTable().destroy(); ");
        }
    }

    private void SetScriptInicio(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();
        string l = " {" +
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
        "},";

        sb.Append(data);
        sb.Append("$('.table').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('#ContentPlaceHolder1_gv_bajas').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_bajas').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('#ContentPlaceHolder1_gv_nro_egs').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_nro_egs').DataTable({" +
        "'language': " + l +
        "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': false, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        //sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        string l = " {" +
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
            "},";

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('#ContentPlaceHolder1_gv_bajas').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_bajas')) { $('#ContentPlaceHolder1_gv_bajas').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('#ContentPlaceHolder1_gv_nro_egs').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_nro_egs')) { $('#ContentPlaceHolder1_gv_nro_egs').DataTable({" +
        "'language': " + l +
        "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': false, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z]+$/i, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
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

    protected void gv_bajas_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_bajas.Rows.Count > 0)
        {
            if (gv_bajas.HeaderRow != null)
            {
                gv_bajas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_bajas.FooterRow != null)
            {
                gv_bajas.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    private void listarGrillaBajas()
    {
        try
        {
            beneficio = new cls_bs_asignacion_beneficio();
            var bajas = beneficio.ListarGrillaBajas();
            int tam = bajas.Tables[0].Rows.Count;
            block_notificacion.Visible = (tam > 0) ? false : true;
            gv_bajas.DataSource = bajas;
            gv_bajas.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_bajas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string as_id = gv_bajas.DataKeys[index].Values[0].ToString();
        string per_id = gv_bajas.DataKeys[index].Values[1].ToString();
        //string motivo = gv_bajas.Rows[index].Cells[6].Text;
        aux_as_id.Value = as_id;
        aux_per_id.Value = per_id;
        //aux_motivo.Value = motivo;
        switch (e.CommandName)
        {
            case "GetAssig":
                llenarDatosBaja();
                sc = "$('#asignarFechaFormulario').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    private void llenarDatosBaja()
    {
        beneficio = new cls_bs_asignacion_beneficio();
        int per_id = Convert.ToInt32(aux_per_id.Value);
        int as_id = Convert.ToInt32(aux_as_id.Value);
        beneficio.pf_per_id = per_id;
        beneficio.as_id = as_id;

        var detalleBaja = beneficio.ObtenerFuncionarioBajaX();
        if (detalleBaja.Tables.Count > 0)
        {
            if (detalleBaja.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleBaja.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_fecha_baja.Text = validarCampo(funcionario["as_fecha_fin"]);
                ltl_motivo.Text = validarCampo(funcionario["motivo_baja"]);
                ltl_egs.Text = validarCampo(funcionario["fa_descripcion"]);
                txt_fecha_impresion.Text = string.Empty;
            }
        }
    }

    protected void btn_asignarFechaBaja_Click(object sender, EventArgs e)
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            as_id = Convert.ToInt32(aux_as_id.Value),
            pf_per_id = Convert.ToInt32(aux_per_id.Value),
            ae_fecha_baja_elab = txt_fecha_impresion.Text,
            ae_tipo_proceso_baja = "M"
        };
        beneficio.AdicionarFechaBajaForm();
        Limpiar();
        listarGrillaBajas();
        sc = "Swal.fire({ icon: 'success', title: 'Proceso exitoso', text: 'Baja exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#asignarFechaFormulario').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void chk_bajas_all_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gv_bajas.Rows.Count; i++)
        {
            GridViewRow row = gv_bajas.Rows[i];
            bool isChecked = ((CheckBox)gv_bajas.HeaderRow.FindControl("chk_bajas_all")).Checked;

            if (isChecked)
            {
                ((CheckBox)row.FindControl("chk_bajas")).Checked = true;
            }
            else
            {
                ((CheckBox)row.FindControl("chk_bajas")).Checked = false;
            }
        }
        SetScript("");
    }

    protected void btn_bajas_masiv_Click(object sender, EventArgs e)
    {
        beneficio = new cls_bs_asignacion_beneficio();
        bool sw = false;

        for (int i = 0; i < gv_bajas.Rows.Count; i++)
        {
            GridViewRow row = gv_bajas.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chk_bajas")).Checked;
            if (isChecked)
            {
                sw = true;
                break;
            }
            else
            {
                sw = false;
            }
        }

        string param = "";
        if (sw)
        {
            for (int i = 0; i < gv_bajas.Rows.Count; i++)
            {
                GridViewRow row = gv_bajas.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chk_bajas")).Checked;

                if (isChecked)
                {
                    int per_id = (int)Convert.ToInt32(gv_bajas.DataKeys[i].Values[1].ToString());
                    param = param + ", " + per_id;
                }
            }
            string aux = param.Substring(1, param.Length - 1);
            listarGrillaNroBajasEgs(aux);
            sc = "$('#asignarFechaFormularioMasiv').modal('show');";
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message:'Seleccione a los funcionarios para el proceso de baja.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
        }
        SetScript(sc);
    }

    protected void gv_nro_egs_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_nro_egs.Rows.Count > 0)
        {
            if (gv_nro_egs.HeaderRow != null)
            {
                gv_nro_egs.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_nro_egs.FooterRow != null)
            {
                gv_nro_egs.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    private void listarGrillaNroBajasEgs(string param = "")
    {
        try
        {
            beneficio = new cls_bs_asignacion_beneficio();
            beneficio.param = param;
            var bajas = beneficio.ObtenerCantidadBajasEGS();
            int tam = bajas.Tables[0].Rows.Count;
            gv_nro_egs.DataSource = bajas;
            gv_nro_egs.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_baja_masiv_Click(object sender, EventArgs e)
    {
        beneficio = new cls_bs_asignacion_beneficio();
        for (int i = 0; i < gv_bajas.Rows.Count; i++)
        {
            GridViewRow row = gv_bajas.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chk_bajas")).Checked;
            if (isChecked)
            {
                int masiv_as_id = (int)Convert.ToInt32(gv_bajas.DataKeys[i].Values[0].ToString());
                int masiv_per_id = (int)Convert.ToInt32(gv_bajas.DataKeys[i].Values[1].ToString());
                beneficio.as_id = masiv_as_id;
                beneficio.pf_per_id = masiv_per_id;
                beneficio.ae_fecha_baja_elab = txt_fecha_baja_masiv.Text;
                beneficio.ae_tipo_proceso_baja = "P";
                beneficio.AdicionarFechaBajaForm();
            }
        }
        listarGrillaBajas();
        Limpiar();
        sc = "Swal.fire({ icon: 'success', title: 'Proceso exitoso', text: 'Bajas registradas exitosamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#asignarFechaFormularioMasiv').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void Limpiar()
    {
        txt_fecha_impresion.Text = string.Empty;
        txt_fecha_baja_masiv.Text = string.Empty;
    }
}