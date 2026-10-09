using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Menu_Principal : System.Web.UI.Page
{
    cls_informacion info = null;
    private cls_persona _persona = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        cargarCargo();

    }


    private void cargarCargo()
    {
        info = new cls_informacion();
        ddl_escala.Items.Clear();
        ddl_escala.Items.Add("SELECCIONE UNA ESCALA");
        ddl_escala.DataSource = info.Cargos();
        ddl_escala.DataTextField = "es_descripcion";
        ddl_escala.DataValueField = "es_id";
        ddl_escala.DataBind();
    }

    protected void ddl_escala_SelectedIndexChanged(object sender, EventArgs e)
    {
        Informacion();
        SetScript("", "");
    }

    private void Informacion()
    {
        info = new cls_informacion();
        if (ddl_escala.Text != "SELECCIONE UNA ESCALA")
        {
            var detalle = info.Informacion(Convert.ToInt32(ddl_escala.SelectedValue));
            if (detalle.Tables.Count > 0)
            {
                if (detalle.Tables[0].Rows.Count > 0)
                {
                    var detallado = detalle.Tables[0].Rows[0];
                    ltl_hb.Text = validarCampo(detallado["haber_basico"]);
                    ltl_total.Text = validarCampo(detallado["total_ganado"]);
                    ltl_frontera.Text = validarCampo(detallado["bono_antiguedad"]);
                    ltl_afp.Text = validarCampo(detallado["descuento_afp"]);
                    ltl_liquido.Text = validarCampo(detallado["liquido"]);
                }
            }
        }
        else
        {
            Limpiar();
        }
    }

    private void Limpiar()
    {
        ltl_frontera.Text = "";
        ltl_hb.Text = "";
        ltl_total.Text = "";
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

    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar _MENU_ Registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando Registros del _START_ al _END_ de un total de _TOTAL_ Registros'," +
                    "'sInfoEmpty': 'Mostrando Registros del 0 al 0 de un total de 0 Registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ Registros)'," +
                    "'sInfoPostFix': ''," +
                    "'sSearch': 'Buscar:'," +
                    "'sUrl': ''," +
                    "'sInfoThousands': ','," +
                    "'sLoadingRecords': 'Cargando...'," +
                    "'oPaginate': {" +
                        "'sFirst': '«'," +
                        "'sLast': '»'," +
                        "'sNext': '<i class=\"fas fa-angle-right\"></i>'," +
                        "'sPrevious': '<i class=\"fas fa-angle-left\"></i>'" +
                    "}," +
                    "'oAria': {" +
                        "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                        "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                "}," +
                "'ordering': false," +
                "'searching': true," + // Muestra/Oculta el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" + // Muestra/Oculta el campo información
            "});");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerDefault\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: \"es\"" +
                    "});" +
                "});" +
                "var me = $(\".datepickerDefault\");" +
                "me.mask(\"99/99/9999\");" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    protected void gv_items_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_items.Rows.Count > 0)
        {
            if (gv_items.HeaderRow != null)
            {
                gv_items.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_items.FooterRow != null)
            {
                gv_items.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_items_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        switch (e.CommandName)
        {
            case "GetAssign":
                string per_id = gv_items.DataKeys[index].Values[0].ToString();
                string as_id = gv_items.DataKeys[index].Values[2].ToString();
                Response.Redirect("Consulta?id=" + per_id + "&id2=" + as_id);
                break;
            default:
                break;
        }
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_ap_casada_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });";
        else
        {
            BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_per_ap_casada_b.Text.Trim());
            Limpiar("sch_cl");

            if (gv_items.Rows.Count > 0)
            {
                sc = "$('#blockResultados').css('display', 'block');";
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#blockResultados').css('display', 'none');";
            }
        }
        SetScript(sc,"");
    }
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom, string varCas)
    {

        cls_informacion info = new cls_informacion();
        gv_items.DataSource = info.GrillaInformacionFunc(varId, "", varCed, "", varPat, varMat, varNom, varCas, "", "", "", "", "", "");
        gv_items.DataBind();
    }
    private void Limpiar(string val)
    {
        // Limpiar el formulario de búsqueda
        if (val.Equals("sch_cl"))
        {
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
            Txt_per_ap_casada_b.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
        }

        // Limpiar el gridview de la búsqueda
        else if (val.Equals("gv_cl"))
        {
            gv_items.DataSource = null;
            gv_items.DataBind();
        }
    }
}