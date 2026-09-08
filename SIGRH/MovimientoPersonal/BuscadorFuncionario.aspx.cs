using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class MovimientoPersonal_BuscadorFuncionario : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_persona _persona = null;
    private cls_mp_asignacion_com_int asignacion_interinato = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listaFiltradoTipoDoc();
        }
    }
    private void listaFiltradoTipoDoc()
    {
        try
        {
            cargo = new cls_mp_cargo();

            ddl_tipo_documento.Items.Clear();
            ddl_tipo_documento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_documento.DataValueField = "cat_id";
            ddl_tipo_documento.DataTextField = "cat_descripcion";
            ddl_tipo_documento.DataSource = cargo.ObtenerFiltradoTipoDoc();
            ddl_tipo_documento.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
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
        string per_id = gv_items.DataKeys[index].Values[0].ToString();
        hf_ci_id.Value = gv_items.DataKeys[index].Values[2].ToString();
        hf_per_id.Value = per_id;
        switch (e.CommandName)
        {
            case "GetAssign":
                Response.Redirect("AsignacionInterinato?id=" + per_id);
                break;
            case "GetEdit":
                llenarDatosCI();
     
                break;
            case "GetDelete":
                sc = "$('#anularAsignacion').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
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

        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");


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

        sb.Append("$('#ContentPlaceHolder1_gv_items_filter').css({ display: 'none' }); var me = $('.datepickerDefault'); me.mask('99/99/9999');");

        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
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
        SetScript(sc);
    }
    private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom, string varCas)
    {
        try
        {
            _persona = new cls_persona();
            var resultados = _persona.ObtenerTablaGrilla__persona_ejecutivo(varId, "", varCed, "", varPat, varMat, varNom, varCas, "", "", "", "", "", "");
            gv_items.DataSource = resultados;
            gv_items.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
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
    protected void btnEliminarAsig_Click(object sender, EventArgs e)
    {
        asignacion_interinato = new cls_mp_asignacion_com_int();
        asignacion_interinato.ci_per_id = Convert.ToInt32(hf_per_id.Value);
        asignacion_interinato.Eliminar();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: '¡Asignación anulada correctamente!'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#anularAsignacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#blockResultados').css('display', 'none');";
        SetScript(sc);
    }

    protected void btnFinalizarAsignacion_Click(object sender, EventArgs e)
    {


        DateTime startDate = Convert.ToDateTime(ltl_fecha_inicio.Text);
        DateTime endDate = Convert.ToDateTime(txt_fin_asignacion.Text);
        double diferencia = (endDate - startDate).TotalDays;
        if (diferencia >= 0)
        {
            sc = "$('#modalGlosa').modal('show');";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'ni ni-settings-gear-65', message: 'El rango de fechas ingresado no es válido.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }
    private void guardarGlosa(int ci_id = 0)
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;
        cargo = new cls_mp_cargo();
        cargo.gl_valor_pk = ci_id;
        cargo.gl_nombre_pk = "ci_id";
        cargo.gl_tabla = "tbl_mp_asignacion_com_int";
        cargo.gl_tipo_mov = 814;
        cargo.gl_fecha_doc = fechaMov;
        cargo.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        cargo.gl_glosa = txt_descripcion_add.Text;
        cargo.gl_estado = "V";
        cargo.gl_usuario = Convert.ToInt32(Session["per_id"].ToString());
        cargo.AdicionarGlosa();
    }

    protected void btnGuardar_Click(object sender, EventArgs e)
    {

        asignacion_interinato = new cls_mp_asignacion_com_int();
        asignacion_interinato.ci_id = Convert.ToInt32(hf_ci_id.Value);
        asignacion_interinato.ci_per_id = Convert.ToInt32(hf_per_id.Value);
        asignacion_interinato.ci_fecha_fin = txt_fin_asignacion.Text;
        var asig = asignacion_interinato.FinalizarAsignacion();
        guardarGlosa(Convert.ToInt32(hf_ci_id.Value));

        sc = "$.notify({ icon: 'fa fa-trash-alt', message: '¡Asignación anulada correctamente!'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#finalizarAsignacion').modal('hide'); $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#blockResultados').css('display', 'none');";
        SetScript(sc);

    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        sc = " $('#modalGlosa').modal('hide'); ";
        SetScript(sc);
    }
    private void llenarDatosCI()
    {
        asignacion_interinato = new cls_mp_asignacion_com_int();
        int per_id = Convert.ToInt32(hf_per_id.Value);
        string gestionFiltrar = Session["pr_id"].ToString();
        asignacion_interinato.ci_per_id = per_id;
        asignacion_interinato.ci_pr_id = Convert.ToInt32(gestionFiltrar);

        var detalleFuncionario = asignacion_interinato.ObtenerDatosFunCI();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_tipo_asig.Text = validarCampo(funcionario["cat_descripcion"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_fecha_inicio.Text = validarCampo(funcionario["ci_fecha_inicio"]);
                ltl_fecha_fin.Text = validarCampo(funcionario["ci_fecha_fin"]);
                txt_fin_asignacion.Text = string.Empty;
                sc = "$('#finalizarAsignacion').modal('show');";
                
            } else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            }
        }
        SetScript(sc);
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
}