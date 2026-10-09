using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class BienestarSocial_BuscadorFuncionarioAsignacionBeneficio : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_persona _persona = null;
    private cls_bs_asignacion_beneficio beneficio = null;
    private cls_catalogo _catalogo = null;
    private Subsidio natalidad = new Subsidio();
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            cargarEG();
            listaFiltradoTipoDoc();
        }
    }

    private void cargarEG()
    {
        beneficio = new cls_bs_asignacion_beneficio();

        ddl_caja_aseguradora.Items.Clear();
        //ddl_caja_aseguradora.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_caja_aseguradora.DataValueField = "fa_id";
        ddl_caja_aseguradora.DataTextField = "fa_descripcion";
        ddl_caja_aseguradora.DataSource = beneficio.listaFiltradoCajaAseguradora();
        ddl_caja_aseguradora.DataBind();
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
        aux_per_id.Value = gv_items.DataKeys[index].Values[0].ToString();
        aux_as_id.Value = gv_items.DataKeys[index].Values[2].ToString();

        switch (e.CommandName)
        {
            case "GetAssign":
                string per_id = gv_items.DataKeys[index].Values[0].ToString();
                string as_id = gv_items.DataKeys[index].Values[2].ToString();
                Response.Redirect("RegistroAsignacionBeneficio?id=" + per_id + "&id2=" + as_id);
                break;
            case "Asegurar":
                sc = "$('#modalAfiliacionEGS').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
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

    private void listaFiltradoTipoDoc()
    {
        try
        {
            _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
            var detalle_catalogo = _catalogo.ObtenerTablaCombo().Tables[0];
            DataTable lista_catalogo = new DataTable();
            lista_catalogo.Columns.Add("cat_id");
            lista_catalogo.Columns.Add("cat_descripcion");
            DataRow dr = null;

            int[] ids = { 816, 1839 };

            for (int i = 0; i < ids.Length; i++)
            {
                for (int j = 0; j < detalle_catalogo.Rows.Count; j++)
                {
                    if (ids[i] == Convert.ToInt32(validarCampo(detalle_catalogo.Rows[j]["cat_id"])))
                    {
                        dr = lista_catalogo.NewRow();
                        dr["cat_id"] = validarCampo(detalle_catalogo.Rows[j]["cat_id"]);
                        dr["cat_descripcion"] = validarCampo(detalle_catalogo.Rows[j]["cat_descripcion"]);
                        lista_catalogo.Rows.Add(dr);
                        break;
                    }
                }
            }
            ddl_tipo_documento.Items.Clear();
            ddl_tipo_documento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_documento.DataValueField = "cat_id";
            ddl_tipo_documento.DataTextField = "cat_descripcion";
            ddl_tipo_documento.DataSource = lista_catalogo;
            ddl_tipo_documento.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
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
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('.fecha').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('#ContentPlaceHolder1_ddl_cargo').select2({ dropdownParent: $('#EditarItem') });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_jornada').select2({ dropdownParent: $('#EditarItem') });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_caja_aseguradora').select2({ dropdownParent: $('#modalAfiliacionEGS'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_afiliación').select2({ dropdownParent: $('#modalAfiliacionEGS'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_egs').select2({ placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_estado_afiliacion').select2({ placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
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
        sb.Append("$('#ContentPlaceHolder1_gv_items_filter').css({ display: 'none' }); var me = $('.datepicker'); me.mask('99/99/9999');");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append("$('.radios label').addClass('custom-control-label mb-3');");
        sb.Append("$('.radios input[type=" + '"' + "radio" + '"' + "]').addClass('custom-control-input mb-3');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_ap_casada_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });";
        else
        {
            gv_items.DataSource = natalidad.BuscarAfiliacionEGS(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_per_ap_casada_b.Text.Trim());
            gv_items.DataBind();
            

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

    protected void btn_asignar_afiliacionEGS_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('show');";
        SetScript(sc);
    }

    protected void btn_cancelar_afiliacion_Click(object sender, EventArgs e)
    {
        sc = " $('#modalAfiliacionEGS').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        ddl_tipo_documento.SelectedValue = "0";
        txt_descripcion_add.Text = string.Empty;
        sc = " $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    private void AfiliarNuevoFuncionario()
    {
        cls_bs_afiliacion_egs afiliacion = new cls_bs_afiliacion_egs();
        afiliacion.ae_as_id = Convert.ToInt32(aux_as_id.Value);
        afiliacion.ae_per_id = Convert.ToInt32(aux_per_id.Value);
        afiliacion.ae_fecha_form = Convert.ToDateTime(txt_fecha_registro.Text);
        afiliacion.ae_tipo_ingreso = ddl_tipo_afiliación.SelectedValue;
        afiliacion.Adicionar_2_bs_afiliacion_egs();
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        beneficio = new cls_bs_asignacion_beneficio
        {
            as_id = Convert.ToInt32(aux_as_id.Value),
            pf_per_id = Convert.ToInt32(aux_per_id.Value),
            ae_egs_id = Convert.ToInt32(ddl_caja_aseguradora.SelectedValue),
            ae_fecha_form = txt_fecha_registro.Text,
            ae_tipo_ingreso = ddl_tipo_afiliación.SelectedValue
        };
        beneficio.ae_matricula = txt_matricula.Text;
        if (ddl_tipo_afiliación.SelectedValue == "1")
        {
            AfiliarNuevoFuncionario();
        }
        else
        {
            beneficio.ActualizarDatosAfiliacion();
        }
        guardarGlosaAsignacion();
        beneficio = new cls_bs_asignacion_beneficio();
        beneficio.as_id = Convert.ToInt32(aux_as_id.Value);
        var detalle_afiliacion = beneficio.ObtenerDatosAfiliacion();
        if (detalle_afiliacion.Tables[0].Rows.Count > 0)
        {
            var afiliacion = detalle_afiliacion.Tables[0].Rows[0];
            int per_id_aux = Convert.ToInt32(validarCampo(afiliacion["as_per_id"]));
            int as_id_aux = Convert.ToInt32(validarCampo(afiliacion["as_id"]));
            int fa_id_aux = Convert.ToInt32(validarCampo(afiliacion["fa_id"]));
            if (validarCampo(afiliacion["ae_estado"]) == "A")
            {
                sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Afiliación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#blockResultados').css('display', 'none'); $('#modalAfiliacionEGS').modal('hide'); $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            }
            else
            {
                sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Afiliación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#blockResultados').css('display', 'none'); $('#modalAfiliacionEGS').modal('hide'); $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
                
            }
            SetScript(sc);
        }
    }

    private int obtenerIdAfiliacionEGS()
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            as_id = Convert.ToInt32(aux_as_id.Value),
            pf_per_id = Convert.ToInt32(aux_per_id.Value)
        };

        var obtAfiliacion = beneficio.obtenerIdAfiliacionEGS();
        int id_afiliacion = 0;
        if (obtAfiliacion.Tables[0].Rows[0]["ae_id"] != DBNull.Value && obtAfiliacion.Tables[0].Rows[0]["ae_id"].ToString().Trim() != "")
        {
            id_afiliacion = Convert.ToInt32(obtAfiliacion.Tables[0].Rows[0]["ae_id"]);
        }
        return id_afiliacion;
    }

    private void guardarGlosaAsignacion()
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;
        int idBeneficio = obtenerIdAfiliacionEGS();
        cargo = new cls_mp_cargo();
        cargo.gl_valor_pk = idBeneficio;
        cargo.gl_nombre_pk = "ae_id";
        cargo.gl_tabla = "tbl_bs_afiliacion_egs";
        cargo.gl_tipo_mov = 813;
        cargo.gl_fecha_doc = fechaMov;
        cargo.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        cargo.gl_glosa = txt_descripcion_add.Text;
        cargo.gl_numero_doc = txt_num_doc.Text;
        cargo.gl_estado = "V";
        cargo.gl_usuario = Convert.ToInt32(Session["per_id"].ToString());
        cargo.AdicionarGlosa();
    }

    private void restablecerGlosa()
    {
        ddl_tipo_documento.SelectedValue = "0";
        txt_num_doc.Text = "";
        txt_fechaMov.Text = "";
        txt_descripcion_add.Text = "";
        d_num_doc.Visible = false;
        d_tipo_doc.Attributes.Add("class", "col-md-6");
        d_fecha_doc.Attributes.Add("class", "col-md-6");
    }

    protected void gv_items_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) { return; }
        var index = Convert.ToInt32(e.Row.DataItemIndex);
        //int pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var datos = natalidad.BuscarAfiliacionEGS(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim(), Txt_per_ap_casada_b.Text.Trim()).Tables[0];
        if (datos.Rows.Count > 0)
        {
            if (datos.Rows[index]["ae_estado"].ToString().Trim().Equals("A"))
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("btnAfiliar");
                lnk.Visible = false;
            }
            else if (datos.Rows[index]["ae_estado"].ToString().Trim().Equals("P"))
            {
                LinkButton lnk = (LinkButton)e.Row.FindControl("btnBenefici");
                lnk.Visible = false;
            }
        }
        
    }

    protected void ddl_tipo_documento_SelectedIndexChanged(object sender, EventArgs e)
    {
        d_num_doc.Visible = false;
        d_tipo_doc.Attributes.Add("class", "col-md-6");
        d_fecha_doc.Attributes.Add("class", "col-md-6");

        switch (ddl_tipo_documento.SelectedValue)
        {
            case "818":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;
                break;

            case "816":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;
                break;
            case "819":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;
                break;
            default:
                break;
        }
        SetScript("");
    }
}