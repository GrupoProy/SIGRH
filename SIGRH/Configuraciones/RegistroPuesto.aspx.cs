using System;
using System.Collections.Generic;
using System.Globalization;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class Configuraciones_RegistroPuesto : System.Web.UI.Page
{
    private cls_mp_escala_salarial escala_salarial = null;
    private cls_escala_puesto escala_puesto = null;
    private cls_puestos puestos = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listaFiltradoEscala();
            no_existe_puestos.Visible = false;
            string aux = RemoveDiacritics("ANFITRIÓN");
        }
    }
    static string RemoveDiacritics(string text)
    {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var stringBuilder = new StringBuilder();

        foreach (var c in normalizedString)
        {
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
            if (unicodeCategory != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
    private void listaFiltradoEscala()
    {
        try
        {
            escala_salarial = new cls_mp_escala_salarial();
            escala_salarial.es_pr_id = Convert.ToInt32(Session["pr_id"].ToString());

            ddl_escala_salarial.Items.Clear();
            ddl_escala_salarial.Items.Insert(0, new ListItem("Seleccione", "0"));
            ddl_escala_salarial.DataValueField = "es_id";
            ddl_escala_salarial.DataTextField = "es_descripcion";
            ddl_escala_salarial.DataSource = escala_salarial.ObtenerTablaCombo();
            ddl_escala_salarial.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void ddl_escala_salarial_SelectedIndexChanged(object sender, EventArgs e)
    {
        listarPuestos();
        SetScript("");
    }

    private void listarPuestos()
    {
        escala_puesto = new cls_escala_puesto();
        escala_puesto.epu_es_id = Convert.ToInt32(ddl_escala_salarial.SelectedValue);
        var detalle_puestos = escala_puesto.ObtenerPuestos();
        int tam = detalle_puestos.Tables[0].Rows.Count;
        no_existe_puestos.Visible = (tam > 0) ? false : true;
        gv_puestos.DataSource = detalle_puestos;
        gv_puestos.DataBind();
    }

    protected void gv_puestos_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_puestos.Rows.Count > 0)
        {
            if (gv_puestos.HeaderRow != null)
            {
                gv_puestos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_puestos.FooterRow != null)
            {
                gv_puestos.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
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
        sb.Append("$('#ContentPlaceHolder1_gv_puestos').DataTable().destroy(); ");
        sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_puestos')) { $('#ContentPlaceHolder1_gv_puestos').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
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

    protected void btn_adicionar_puesto_Click(object sender, EventArgs e)
    {
        if (cadenaCorrecta())
        {
            puestos = new cls_puestos();
            puestos.p_descripcion = txt_descripcion_puesto.Text.Trim().ToUpper();
            var detalle_puesto = puestos.Adicionar();
            if (detalle_puesto.Tables[0].Rows.Count > 0)
            {
                escala_puesto = new cls_escala_puesto();
                escala_puesto.epu_es_id = Convert.ToInt32(ddl_escala_salarial.SelectedValue);
                escala_puesto.epu_p_id = Convert.ToInt32(validarCampo(detalle_puesto.Tables[0].Rows[0]["p_id"]));
                escala_puesto.epu_tipo = "CONTRATO";
                escala_puesto.Adicionar();

                txt_descripcion_puesto.Text = "";
                listarPuestos();
                sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Puesto adicionado correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#adicionarPuesto').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                SetScript(sc);
            }
        } 
        else
        {
            sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, el puesto ya existe.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }
    private bool cadenaCorrecta()
    {
        bool sw = true;
        escala_puesto = new cls_escala_puesto();
        escala_puesto.epu_es_id = Convert.ToInt32(ddl_escala_salarial.SelectedValue);
        var detalle_puestos = escala_puesto.ObtenerPuestos();

        if (detalle_puestos.Tables[0].Rows.Count > 0)
        {
            var puesto = detalle_puestos.Tables[0].Rows;

            for (int i = 0; i < puesto.Count; i++)
            {
                string p_descripcion = RemoveDiacritics(validarCampo(puesto[i]["p_descripcion"]).Trim().ToUpper());
                string puesto_desc = RemoveDiacritics(txt_descripcion_puesto.Text.Trim().ToUpper());
                if (p_descripcion == puesto_desc)
                {
                    sw = false;
                    break;
                }
            }
        }
        return sw;
    }
    protected void btn_adicionar_Click(object sender, EventArgs e)
    {
        sc = "$('#adicionarPuesto').modal('show');";
        SetScript(sc);
    }
}