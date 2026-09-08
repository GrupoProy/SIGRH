using Newtonsoft.Json;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Mantenimiento_TipoItem : System.Web.UI.Page
{
    private cls_historico _historico = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa _glosa = null;
    private cls_mp_tipo_item _tipo_item = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                CargaGVTipoItem();

                if (Gv_tipo_item_lista.Rows.Count > 0) { P_tipo_item_lista.Visible = true; }
                else { P_tipo_item_lista.Visible = false; }
            }
        }
        else { Response.Redirect("../Index"); }
    }

    // Carga Datos En El DropDownList (Ddl_ti_tipo)
    private void CargaDDLTipoItem()
    {
        _tipo_item = new cls_mp_tipo_item();
        Ddl_ti_tipo.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_ti_tipo.Items.Insert(1, new ListItem("- NUEVO REGISTRO -", "1"));
        Ddl_ti_tipo.DataSource = _tipo_item.ObtenerTablaComboTI();
        Ddl_ti_tipo.DataValueField = "ti_tipo";
        Ddl_ti_tipo.DataTextField = "ti_tipo";
        Ddl_ti_tipo.DataBind();
    }

    // Carga Datos En El DropDownList (Ddl_ti_item_suplencia)
    private void CargaDDLItemSuplencia()
    {
        _tipo_item = new cls_mp_tipo_item();
        Ddl_ti_item_suplencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_ti_item_suplencia.Items.Insert(1, new ListItem("- NUEVO REGISTRO -", "1"));
        Ddl_ti_item_suplencia.DataSource = _tipo_item.ObtenerTablaComboIS();
        Ddl_ti_item_suplencia.DataValueField = "ti_item_suplencia";
        Ddl_ti_item_suplencia.DataTextField = "ti_item_suplencia";
        Ddl_ti_item_suplencia.DataBind();
    }

    // Carga Datos En El DropDownList (Ddl_ti_tipo_item_gral)
    private void CargaDDLTipoItemGeneral()
    {
        _tipo_item = new cls_mp_tipo_item();
        Ddl_ti_tipo_item_gral.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_ti_tipo_item_gral.Items.Insert(1, new ListItem("- NUEVO REGISTRO -", "1"));
        Ddl_ti_tipo_item_gral.DataSource = _tipo_item.ObtenerTablaComboTIG();
        Ddl_ti_tipo_item_gral.DataValueField = "ti_tipo_item_gral";
        Ddl_ti_tipo_item_gral.DataTextField = "ti_tipo_item_gral";
        Ddl_ti_tipo_item_gral.DataBind();
    }

    // Carga Datos En El DropDownList (Ddl_gl_tipo_doc)
    private void CargaDDLTipoDocumento()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Carga Datos En El GridView (Gv_tipo_item_lista)
    private void CargaGVTipoItem()
    {
        try
        {
            _tipo_item = new cls_mp_tipo_item();
            Gv_tipo_item_lista.DataSource = _tipo_item.ObtenerTablaGrilla("", "", "V", "", "", "", "", "", "");
            Gv_tipo_item_lista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño Del GridView (Gv_tipo_item_lista)
    protected void Gv_tipo_item_lista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_tipo_item_lista.Rows.Count > 0)
        {
            if (Gv_tipo_item_lista.HeaderRow != null) { Gv_tipo_item_lista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_tipo_item_lista.FooterRow != null) { Gv_tipo_item_lista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del GridView (Gv_tipo_item_lista)
    protected void Gv_tipo_item_lista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = Gv_tipo_item_lista.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("BtnGlosa"))
        {
            CargaDDLTipoDocumento();
            Ddl_gl_tipo_doc.Enabled = false;
            Txt_gl_fecha_doc.Enabled = false;
            Txt_gl_glosa.Enabled = false;
            BtnGuardarG.Visible = false;
            _glosa = new cls_glosa();
            var data = _glosa.ObtenerTablaGrilla("", code, "ti_item", "tbl_mp_tipo_item", "", "", "", "", "", "V").Tables[0];

            if (data.Rows.Count > 0)
            {
                Ddl_gl_tipo_doc.SelectedValue = data.Rows[0]["gl_tipo_doc"].ToString().Trim();
                Txt_gl_fecha_doc.Text = Convert.ToDateTime(data.Rows[0]["gl_fecha_doc"]).ToString("dd/MM/yyyy").Trim();
                Txt_gl_glosa.Text = data.Rows[0]["gl_glosa"].ToString().Trim();
                sc = "$('#Txt_gl_fecha_doc').addClass('form-control'); $('#Ddl_gl_tipo_doc').removeClass('select2'); $('#glosaModal').modal('show');";
            }
            else { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no tinene glosa...!!' }, { type: 'warning' });"; }
        }
        SetScript(sc, "");
    }

    // Evento Del DropDownList (Ddl_ti_tipo)
    protected void Ddl_ti_tipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_ti_tipo.SelectedValue.Equals("1")) { P_ti_tipo.Visible = true; }
        else { P_ti_tipo.Visible = false; }
        SetScript("", ", dropdownParent: $('#tipoItemModal')");
    }

    // Evento Del DropDownList (Ddl_ti_item_suplencia)
    protected void Ddl_ti_item_suplencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_ti_item_suplencia.SelectedValue.Equals("1"))
        {
            P_ti_item_suplencia.Visible = true;
            Txt_ti_item_suplencia.Text = Txt_ti_item.Text.Trim() + "s";
        }
        else { P_ti_item_suplencia.Visible = false; }
        SetScript("", ", dropdownParent: $('#tipoItemModal')");
    }

    // Evento Del DropDownList (Ddl_ti_tipo_item_gral)
    protected void Ddl_ti_tipo_item_gral_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_ti_tipo_item_gral.SelectedValue.Equals("1")) { P_ti_tipo_item_gral.Visible = true; }
        else { P_ti_tipo_item_gral.Visible = false; }
        SetScript("", ", dropdownParent: $('#tipoItemModal')");
    }

    // Nuevo Registro
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        CargaDDLTipoItem();
        CargaDDLItemSuplencia();
        CargaDDLTipoItemGeneral();
        sc = "$('#tipoItemModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#tipoItemModal')");
    }

    // Alta De Los Datos De Tipo Ítem (Parcial)
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        _tipo_item = new cls_mp_tipo_item();
        var var_dataTI = _tipo_item.ObtenerTablaGrilla(Txt_ti_item.Text.Trim(), "", "", "", "", "", "", "", "").Tables[0];

        if (var_dataTI.Rows.Count > 0)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Ya existe un registro con los mismos datos...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        CargaDDLTipoDocumento();
        sc = "$('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Cancela La Alta De Los Datos De Tipo Ítem (Parcial)
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar("frm_ti_cl");
        sc = "$('#tipoItemModal').modal('hide');";
        SetScript(sc, "");
    }

    // Alta De Los Datos De Tipo Ítem Y Datos De La Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        _tipo_item = new cls_mp_tipo_item { ti_tipo = Ddl_ti_tipo.SelectedValue.Trim() };
        int var_orden = _tipo_item.ObtenerRegistroOM();
        _tipo_item = new cls_mp_tipo_item
        {
            ti_item = Txt_ti_item.Text.ToUpper().Trim(),
            ti_descripcion = Txt_ti_descripcion.Text.ToUpper().Trim(),
            ti_tipo = (Ddl_ti_tipo.SelectedValue.Equals("1")) ? Txt_ti_tipo.Text.ToUpper().Trim() : Ddl_ti_tipo.SelectedValue.Trim(),
            ti_item_suplencia = (Ddl_ti_item_suplencia.SelectedValue.Equals("0")) ? null : (Ddl_ti_item_suplencia.SelectedValue.Equals("1")) ? Txt_ti_item_suplencia.Text.ToUpper().Trim() : Ddl_ti_item_suplencia.SelectedValue.Trim(),
            ti_tipo_item_gral = (Ddl_ti_tipo_item_gral.SelectedValue.Equals("1")) ? Txt_ti_tipo_item_gral.Text.ToUpper().Trim() : Ddl_ti_tipo_item_gral.SelectedValue.Trim(),
            ti_tipo_pago = (Chk_ti_tipo_pago.Checked) ? "SI" : "NO",
            ti_orden = var_orden + 1
        };
        _tipo_item.Adicionar();
        _glosa = new cls_glosa
        {
            gl_valor_pk = Txt_ti_item.Text.ToUpper().Trim(),
            gl_nombre_pk = "ti_item",
            gl_tabla = "tbl_mp_tipo_item",
            gl_tipo_mov = 813,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();
        _tipo_item = new cls_mp_tipo_item();
        var var_dataTI = _tipo_item.ObtenerTablaGrilla(Txt_ti_item.Text.Trim(), "", "", "", "", "", "", "", "").Tables[0];

        if (var_dataTI.Rows.Count > 0)
        {
            string json = JsonConvert.SerializeObject(var_dataTI);
            AdicionarHistorico("A", "tbl_cp_sanciones", "sa_id", Txt_ti_item.Text.Trim(), json);
        }
        CargaGVTipoItem();
        Limpiar("frm_ti_cl");
        Limpiar("frm_glosa_cl");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal, #tipoItemModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela La Alta De Los Datos De Tipo Ítem Y Datos De La Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        Ddl_gl_tipo_doc.Enabled = true;
        Txt_gl_fecha_doc.Enabled = true;
        Txt_gl_glosa.Enabled = true;
        BtnGuardarG.Visible = true;
        Limpiar("frm_glosa_cl");
        sc = "$('#Txt_gl_fecha_doc').addClass('datepickerDefault'); $('#Ddl_gl_tipo_doc').addClass('select2'); $('#glosaModal').modal('hide');";
        SetScript(sc, ", dropdownParent: $('#tipoItemModal')");
    }

    // Alta De Los Datos Del Tipo Ítem En Histórico
    private void AdicionarHistorico(string abm, string tabla, string nom_pk, string val_pk, string campos)
    {
        _historico = new cls_historico
        {
            his_tipo_abm = abm,
            his_nom_tabla = tabla,
            his_nom_pk = nom_pk,
            his_valor_pk = val_pk,
            his_campos = campos,
            his_usuario_creacion = Convert.ToInt32(Session["per_id"])
        };
        _historico.Adicionar();
    }

    // Ejecuta Scripts
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
                "'searching': true," + // Permite mostrar/ocultar el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" + // Permite mostrar/ocultar el campo de información
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
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

    // Limpia Los Campos
    private void Limpiar(string val)
    {
        if (val.Equals("frm_ti_cl"))
        {
            Txt_ti_item.Text = string.Empty;
            Txt_ti_descripcion.Text = string.Empty;
            Ddl_ti_tipo.Items.Clear();
            Txt_ti_tipo.Text = string.Empty;
            Ddl_ti_item_suplencia.Items.Clear();
            Txt_ti_item_suplencia.Text = string.Empty;
            Ddl_ti_tipo_item_gral.Items.Clear();
            Txt_ti_tipo_item_gral.Text = string.Empty;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}