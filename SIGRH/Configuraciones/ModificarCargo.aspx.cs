using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using System.Data;

public partial class Configuraciones_ModificarCargo : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa glosa = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["us_id"] != null && Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                listar_items();
                listar_cargo();
                listar_puesto();
                listar_tipo_item();
                listaFiltradoTipoDoc();
            }
        }
        else
        {
            Response.Redirect("../index");
        }
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

            int[] ids = { 816 };

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
    protected void ddl_tipo_documento_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_num_doc.Text = "";
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

                txt_num_doc.Attributes.Add("class", "form-control");
                break;

            case "816":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control numero");
                break;
            case "819":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control");
                break;
            case "821":
                d_tipo_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Attributes.Add("class", "col-md-4");
                d_fecha_doc.Attributes.Add("class", "col-md-4");
                d_num_doc.Visible = true;

                txt_num_doc.Attributes.Add("class", "form-control");
                break;
            default:
                break;
        }
        SetScript("");
    }
    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('hide');";
        SetScript(sc);
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
    private void listar_items()
    {
        cargo = new cls_mp_cargo { ca_pr_id = Session["pr_id"].ToString() };
        ddl_item.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_item.DataSource = cargo.ObtenerListaItemPlanta();
        ddl_item.DataValueField = "ca_id";
        ddl_item.DataTextField = "item_planta";
        ddl_item.DataBind();
    }
    private void listar_cargo()
    {
        cargo = new cls_mp_cargo { ca_pr_id = Session["pr_id"].ToString() };
        ddl_cargo.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_cargo.DataSource = cargo.ObtenerListaCargoPlanta();
        ddl_cargo.DataValueField = "es_id";
        ddl_cargo.DataTextField = "es_descripcion";
        ddl_cargo.DataBind();
    }
    private void listar_puesto()
    {
        cargo = new cls_mp_cargo { ca_pr_id = Session["pr_id"].ToString() };
        ddl_puesto.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_puesto.Items.Insert(1, new ListItem("REGISTRAR NUEVO PUESTO...", "-1"));
        ddl_puesto.DataSource = cargo.ObtenerListaPuestoPlanta();
        ddl_puesto.DataValueField = "p_id";
        ddl_puesto.DataTextField = "p_descripcion";
        ddl_puesto.DataBind();
    }
    private void listar_tipo_item()
    {
        cargo = new cls_mp_cargo();
        ddl_tipo_item.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_item.DataSource = cargo.ObtenerListaTipoItemPlanta();
        ddl_tipo_item.DataValueField = "ti_item";
        ddl_tipo_item.DataTextField = "ti_descripcion";
        ddl_tipo_item.DataBind();
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
    protected void btn_regitrar_puesto_Click(object sender, EventArgs e)
    {
        if (ddl_tipo_item.SelectedValue != "0" || ddl_cargo.SelectedValue != "0" || ddl_puesto.SelectedValue != "0")
        {
            sc = "$('#modalGlosa').modal('show');";
            SetScript(sc);
        } else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se realizó ningún cambio en el ítem seleccionado.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    protected void ddl_item_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargo = new cls_mp_cargo { ca_pr_id = Session["pr_id"].ToString(), ca_id = Convert.ToInt32(ddl_item.SelectedValue) };
        var detalle_puesto = cargo.ObtenerPuestoPlanta();
        ltl_puesto.Text = (detalle_puesto.Tables[0].Rows.Count > 0) ? validarCampo(detalle_puesto.Tables[0].Rows[0]["p_descripcion"]) : "";

        listarItems(Convert.ToInt32(ddl_item.SelectedValue));

        sc = "$('#datos_historico').css('display', 'block'); $('#datos_modificar').css('display', 'block'); $('#desc_puesto').css('display', 'block');";
        SetScript(sc);
    }
    private void listarItems(int ca_id = 0)
    {
        try
        {
            cargo = new cls_mp_cargo { ca_pr_id = Session["pr_id"].ToString(), ca_id = ca_id };
            var detalle_items = cargo.ObtenerGrillaItem();
            int tam = detalle_items.Tables[0].Rows.Count;
            //no_existe_prec.Visible = (tam > 0) ? false : true;
            gv_items.DataSource = detalle_items;
            gv_items.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void ddl_puesto_SelectedIndexChanged(object sender, EventArgs e)
    {
        txt_desc_puesto.Text = "";
        if (ddl_puesto.SelectedValue == "-1")
        {
            sc = "$('#datos_historico').css('display', 'block'); $('#datos_modificar').css('display', 'block'); $('#nuevo_puesto').css('display', 'block'); $('#desc_puesto').css('display', 'block');";
            SetScript(sc);
        }
        else
        {
            sc = "$('#datos_historico').css('display', 'block'); $('#datos_modificar').css('display', 'block'); $('#nuevo_puesto').css('display', 'none'); $('#desc_puesto').css('display', 'block');";
            SetScript(sc);
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
        //sb.Append("$('#ContentPlaceHolder1_gv_planilla').DataTable().destroy(); ");
        //sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_planilla')) { $('#ContentPlaceHolder1_gv_planilla').DataTable({" +
        //  "'language': " + l +
        //  "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        //sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable().destroy(); ");
        //sb.Append("if (!$.fn.dataTable.isDataTable('#ContentPlaceHolder1_gv_frecuencias')) { $('#ContentPlaceHolder1_gv_frecuencias').DataTable({" +
        //"'language': " + l +
        //"'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 10, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        //sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");

        //sb.Append("$('#modalPersona .select2').each(function() { var $p = $(this).parent(); $(this).select2({ dropdownParent: $p, placeholder: { id: '0', text: 'Seleccione...' }}); });");

        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#modalGlosa .select2').each(function() { var $p = $(this).parent(); $(this).select2({ dropdownParent: $p, placeholder: { id: '0', text: 'Seleccione...' }}); });");

        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
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

    }
    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        cargo = new cls_mp_cargo();
        cargo.ca_id = Convert.ToInt32(ddl_item.SelectedValue);
        var detalle_cargo = cargo.ObtenerRegistro();

        if (detalle_cargo.Tables[0].Rows.Count > 0)
        {
            var cargo_x = detalle_cargo.Tables[0].Rows[0];
            string haberBasico = obtenerHB() + "";
            cargo = new cls_mp_cargo();
            cargo.ca_id = Convert.ToInt32(ddl_item.SelectedValue);
            cargo.ca_es_id = (ddl_cargo.SelectedValue != "0") ? Convert.ToInt32(ddl_cargo.SelectedValue) : Convert.ToInt32(validarCampo(cargo_x["ca_es_id"]));
            cargo.ca_eo_id = Convert.ToInt32(validarCampo(cargo_x["ca_eo_id"]));
            cargo.ca_ti_item = (ddl_tipo_item.SelectedValue != "0") ? ddl_tipo_item.SelectedValue : validarCampo(cargo_x["ca_ti_item"]);
            cargo.ca_num_item = Convert.ToInt32(validarCampo(cargo_x["ca_num_item"]));
            cargo.ca_estado = "L";
            cargo.ca_aplica_incremento = validarCampo(cargo_x["ca_aplica_incremento"]);
            cargo.ca_tipo_jornada = validarCampo(cargo_x["ca_tipo_jornada"]);
            cargo.ca_basico_calculado = (ddl_cargo.SelectedValue != "0") ? haberBasico : Math.Round(Convert.ToDouble(validarCampo(cargo_x["ca_basico_calculado"]))) + "";
            cargo.ca_pr_id = Session["pr_id"].ToString();
            cargo.ca_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());

            cargo.p_id = (ddl_puesto.SelectedValue == "-1") ? 0 : Convert.ToInt32(ddl_puesto.SelectedValue);
            cargo.p_descripcion = txt_desc_puesto.Text.Trim().ToUpper();
            cargo.ModificarItemPlanta();

        } else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Ocurrió un error al intentar recuperar los datos.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
        //guardarGlosa(pl_id, "pl_id", "tbl_pc_planilla");

    }
    private void guardarGlosa(int gl_valor_pk = 0, string gl_nombre_pk = "", string gl_tabla = "")
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;

        glosa = new cls_glosa();
        glosa.gl_valor_pk = gl_valor_pk + "";
        glosa.gl_nombre_pk = gl_nombre_pk;
        glosa.gl_tabla = gl_tabla;
        glosa.gl_tipo_mov = 813;
        glosa.gl_fecha_doc = Convert.ToDateTime(fechaMov);
        glosa.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        glosa.gl_numero_doc = (txt_num_doc.Text.Trim() != "") ? txt_num_doc.Text.Trim() : null;
        glosa.gl_glosa = txt_descripcion_add.Text.Trim().ToUpper();
        glosa.gl_estado = "V";
        glosa.gl_usuario = Convert.ToInt32(Session["us_id"].ToString());
        glosa.Adicionar();
        restablecerGlosa();
    }

    private double obtenerHB()
    {
        double haberBasico = 0;

        cargo = new cls_mp_cargo();
        cargo.gestion_selec = Session["pr_id"].ToString();
        cargo.es_cod_esc = Convert.ToInt32(ddl_cargo.SelectedValue);
        var detalleUO = cargo.ObtenerDetalleUO();

        if (detalleUO.Tables[0].Rows.Count > 0)
        {
            haberBasico = Convert.ToDouble(validarCampo(detalleUO.Tables[0].Rows[0]["haber_basico"]));
            haberBasico = Math.Round(haberBasico);

        }
        return haberBasico;
    }
}