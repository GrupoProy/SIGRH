using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MessagingToolkit.QRCode.Codec;
using Newtonsoft.Json;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
public partial class MovimientoPersonal_FuncionarioMemoVario : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_mp_seguimiento_memorandum memo_vario = null;
    private cls_catalogo _catalogo = null;
    private cls_glosa glosa = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null)
        {
            if (!Page.IsPostBack)
            {
                string codFun = Request.QueryString["id"].ToString();
                string as_id = Request.QueryString["id2"].ToString();
                informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
                listaFiltradoMemoVario();
                listaFiltradoTipoDoc();
                listarMemosAsignados();
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }
    private void listarMemosAsignados()
    {
        string codFun = Request.QueryString["id"].ToString();
        try
        {
            memo_vario = new cls_mp_seguimiento_memorandum();
            memo_vario.mh_per_id = Convert.ToInt32(codFun);
            var memos = memo_vario.ObtenerGrillaMemosAsig();
            gv_memos.DataSource = memos;
            gv_memos.DataBind();
            no_existe_datos.Visible = !(gv_memos.Rows.Count > 0);
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        cargo = new cls_mp_cargo();
        cargo.as_per_id = codFun;
        cargo.as_id_actual = as_id;
        var detalleFuncionario = cargo.ObtenerDatosDetalleFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
                ltl_programatica.Text = validarCampo(funcionario["cod_prog"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_cod_esc.Text = validarCampo(funcionario["es_escalafon"]);
                ltl_clase.Text = validarCampo(funcionario["ns_clase"]);
                ltl_nivel_salarial.Text = validarCampo(funcionario["ns_nivel"]);
                ltl_haber_basico.Text = validarCampo(funcionario["haber_basico"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);

                if (validarCampo(funcionario["as_estado"]) == "V")
                {
                    btn_estado.Text = "Vigente";
                    btn_estado.CssClass = "btn btn-sm btn-info float-right";
                }
                else
                {
                    btn_estado.Text = "Pasivo";
                    btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
                }

                if (validarCampo(funcionario["fp_foto"]) != "")
                {
                    imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
                }
                else
                {
                    if (validarCampo(funcionario["per_sexo"]) == "M")
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
                    }
                    else
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
                    }
                }

            }
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
    private void listaFiltradoMemoVario()
    {
        try
        {
            cargo = new cls_mp_cargo();
            var tiposTenor = cargo.ObtenerFiltradoTipoMemoV();
            if (tiposTenor.Tables[0].Rows.Count > 0)
            {
                ddl_tenor.Items.Clear();
                ddl_tenor.Items.Insert(0, new ListItem("Seleccione...", "0"));
                ddl_tenor.DataValueField = "cat_secuencial";
                ddl_tenor.DataTextField = "cat_descripcion";
                ddl_tenor.DataSource = tiposTenor;
                ddl_tenor.DataBind();
                ddl_tenor.Enabled = true;

                ListItem itemToRemove = ddl_tenor.Items.FindByValue("9");
                if (itemToRemove != null)
                {
                    ddl_tenor.Items.Remove(itemToRemove);
                }

                itemToRemove = ddl_tenor.Items.FindByValue("17");
                if (itemToRemove != null)
                {
                    ddl_tenor.Items.Remove(itemToRemove);
                }
            }
            else
            {
                ddl_tenor.Items.Clear();
                ddl_tenor.Enabled = false;
                SetScript("$.notify({ icon: 'fa fa-info', message:'No existen tenores para el tipo de movimiento seleccionado'},{type: 'darker', placement: { from: 'bottom', align: 'right'} }); ");

            }
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
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
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
            "'sNext': '<i class=" + '"' + "fas fa-angle-right" + '"' + "></i>'," +
            "'sPrevious': '<i class=" + '"' + "fas fa-angle-left" + '"' + "></i>'" +
            "}," +
            "'oAria': {" +
            "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
            "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
            "}" +
            "}," +
            "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    private void SetScriptNDT(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('.ql-editor').css('border', 'none'); $('.ql-container.ql-snow').css('border', 'none'); $('.ql-editor').css('padding', '0rem .75rem');");
        sb.Append(data);
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        AdicionarMemoVario();
        Session["texto_notificacion"] = "¡Memorándum asignado correctamente!";
        Response.Redirect("AsignacionMemosVarios");
    }
    protected void AdicionarMemoVario()
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        DataTable mv_datos = new DataTable();
        mv_datos.Columns.Add("mv_tipo");
        mv_datos.Columns.Add("mv_fecha_inicio");
        mv_datos.Columns.Add("mv_fecha_fin");
        mv_datos.Columns.Add("mv_texto_adicional_tenor");
        mv_datos.Columns.Add("mv_nro_memo_anterior");
        mv_datos.Columns.Add("mv_fecha_memo_anterior");
        DataRow dr = null;
        dr = mv_datos.NewRow();
        dr["mv_tipo"] = (ddl_tenor.SelectedValue != "0") ? ddl_tenor.SelectedValue : "0";
        dr["mv_fecha_inicio"] = (txt_fecha_inicio.Text != "") ? txt_fecha_inicio.Text : "";
        dr["mv_fecha_fin"] = (txt_fecha_fin.Text != "") ? txt_fecha_fin.Text : "";
        dr["mv_texto_adicional_tenor"] = (txt_adicional_tenor.Text != "") ? txt_adicional_tenor.Text.ToUpper().Trim() : "";
        dr["mv_nro_memo_anterior"] = (txt_nro_memo_ant.Text != "") ? txt_nro_memo_ant.Text : "";
        dr["mv_fecha_memo_anterior"] = (txt_fecha_memo_ant.Text != "") ? txt_fecha_memo_ant.Text : "";
        mv_datos.Rows.Add(dr);

        memo_vario = new cls_mp_seguimiento_memorandum();
        memo_vario.mv_per_id = per_id;
        memo_vario.mv_datos = JsonConvert.SerializeObject(mv_datos);
        memo_vario.mv_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());
        memo_vario.mv_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var datosAdicionales = memo_vario.AdicionarTenorFunMV();

        if (datosAdicionales.Tables[0].Rows.Count > 0)
        {
            int mv_id = Convert.ToInt32(validarCampo(datosAdicionales.Tables[0].Rows[0]["mv_id"]));
            guardarGlosa(mv_id, "mv_id", "tbl_mp_memos_varios");
        }
    }
    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        sc = " $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
        SetScript(sc);
    }

    protected void btn_guardar_item_Click(object sender, EventArgs e)
    {
        sc = "$('#modalGlosa').modal('show');";
        SetScript(sc);
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

            int[] ids = { 816, 818, 819, 821 };

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
    protected void gv_memos_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_memos.Rows.Count > 0)
        {
            if (gv_memos.HeaderRow != null)
            {
                gv_memos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_memos.FooterRow != null)
            {
                gv_memos.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void gv_memos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_mv_id.Value = gv_memos.DataKeys[index].Values[0].ToString();

        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarMemo').modal('show');";
                SetScript(sc);
                break;
        }
    }
    protected void btnEliminarTenor_Click(object sender, EventArgs e)
    {
        memo_vario = new cls_mp_seguimiento_memorandum();
        memo_vario.mv_id = Convert.ToInt32(hf_mv_id.Value);
        memo_vario.EliminarMemoAsignado();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Memorándum anulado correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarMemo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
        listarMemosAsignados();
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
    protected void btn_estado_Click(object sender, EventArgs e)
    {
        SetScript("");
    }
}