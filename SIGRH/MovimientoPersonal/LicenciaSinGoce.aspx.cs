using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System.Data;
using Newtonsoft.Json;

public partial class MovimientoPersonal_LicenciaSinGoce : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_cargo cargo = null;
    private cls_mp_seguimiento_memorandum memo_vario = null;
    private cls_cp_licencia_justificada _licencia = null;
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
                listaFiltradoTipoLicencia();
                listaFiltradoTipoDoc();
                listarLicenciasAsignados();
            }
        }
        else
        {
            Response.Redirect("../index");
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
    private void listaFiltradoTipoLicencia()
    {
        try
        {
            _catalogo = new cls_catalogo { cat_tabla = "Tipo_Licencia" };
            DataTable lista_ = new DataTable();
            //lista_.Columns.Add("cat_secuencial");
            lista_.Columns.Add("cat_id");

            lista_.Columns.Add("cat_descripcion");
            DataRow dr = null;

            var detalle_cat = _catalogo.ObtenerTablaCombo().Tables[0];
            for (int i = 0; i < detalle_cat.Rows.Count; i++)
            {
                //if (validarCampo(detalle_cat.Rows[i]["cat_secuencial"]) == "41" || validarCampo(detalle_cat.Rows[i]["cat_secuencial"]) == "32")
                    if (validarCampo(detalle_cat.Rows[i]["cat_id"]) == "2298" || validarCampo(detalle_cat.Rows[i]["cat_id"]) == "9561")

                    {
                        dr = lista_.NewRow();
                    //dr["cat_secuencial"] = validarCampo(detalle_cat.Rows[i]["cat_secuencial"]);
                    dr["cat_id"] = validarCampo(detalle_cat.Rows[i]["cat_id"]);

                    dr["cat_descripcion"] = validarCampo(detalle_cat.Rows[i]["cat_descripcion"]);
                    lista_.Rows.Add(dr);
                }
            }

            _catalogo = new cls_catalogo { cat_tabla = "Tipo_Licencia" };
            ddl_tipo_licencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
            //ddl_tipo_licencia.DataValueField = "cat_secuencial";
            ddl_tipo_licencia.DataValueField = "cat_id";

            ddl_tipo_licencia.DataTextField = "cat_descripcion";
            ddl_tipo_licencia.DataSource = lista_;
            ddl_tipo_licencia.DataBind();
            //ddl_tipo_licencia.SelectedValue = "32";
            //ddl_tipo_licencia.Enabled = true;

            //ListItem itemToRemove = ddl_tipo_licencia.Items.FindByValue("M");
            //if (itemToRemove != null)
            //{
            //    ddl_tipo_movimiento_gral.Items.Remove(itemToRemove);
            //}

            //foreach (ListItem item in ddl_tipo_licencia.Items)
            //{
            //    if (item.Value != "41" || item.Value != "32")
            //    {
            //        ddl_tipo_licencia.Items.Remove(item);
            //    }
            //}


        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
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

            int[] ids = { 816, 818 };

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
    private void listarLicenciasAsignados()
    {
        int per_id = (Request.QueryString["id"].ToString() != "") ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            _licencia = new cls_cp_licencia_justificada();
            _licencia.lj_per_id = per_id;
            var licencias = _licencia.ObtenerLicenciasSGHFun();
            gv_licencias.DataSource = licencias;
            gv_licencias.DataBind();
            no_existe_datos.Visible = !(gv_licencias.Rows.Count > 0);
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
    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }

    protected void gv_licencias_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_licencias.Rows.Count > 0)
        {
            if (gv_licencias.HeaderRow != null)
            {
                gv_licencias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_licencias.FooterRow != null)
            {
                gv_licencias.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_licencias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_lj_id.Value = gv_licencias.DataKeys[index].Values[0].ToString();

        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarLicencia').modal('show');";
                SetScript(sc);
                break;
        }
    }

    protected void btn_estado_Click(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void btn_guardar_licencia_Click(object sender, EventArgs e)
    {
        sc = "$('#modalGlosa').modal('show');";
        SetScript(sc);
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
    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalGlosa').modal('hide');";
        SetScript(sc);
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        //if (ddl_tipo_licencia.SelectedValue == "32")
        if (ddl_tipo_licencia.SelectedValue=="2298" || ddl_tipo_licencia.SelectedValue == "9561")
        {
            DateTime startDate = Convert.ToDateTime(txt_fecha_inicio.Text);
            DateTime endDate = Convert.ToDateTime(txt_fecha_fin.Text);
            if (chk_contar.Checked)
            {
                bool sw = false;
                DateTime? startDate_aux = null;
                DateTime? endDate_aux = null;
                for (var day = startDate.Date; day.Date <= endDate.Date; day = day.AddDays(1))
                {
                    string dia = day.ToString("dddd");
                    if (dia != "sábado" && dia != "domingo")
                    {
                        if (startDate_aux == null)
                        {
                            startDate_aux = day;
                        }
                        endDate_aux = day;

                        if (endDate == day)
                        {
                            sw = true;
                        }
                    }
                    else
                    {
                        sw = true;
                    }
                    if (sw)
                    {
                        if (startDate_aux != null && endDate_aux != null)
                        {
                            guardarLicencia(startDate_aux, endDate_aux);
                            startDate_aux = null;
                            endDate_aux = null;

                        }
                        sw = false;
                    }
                }
            }
            else
            {
                guardarLicencia(startDate, endDate);
            }
        } else
        {
            guardarLicencia(null, null);
        }
        AdicionarMemoVario();
        listarLicenciasAsignados();
        limpiar();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Licencia registrada correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
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
        mv_datos.Columns.Add("mv_fecha_inicio_licencia");
        mv_datos.Columns.Add("mv_fecha_fin_licencia");
        DataRow dr = null;
        dr = mv_datos.NewRow();
        dr["mv_tipo"] = (ddl_tipo_licencia.SelectedValue == "32") ? 17 : 9;
        dr["mv_fecha_inicio"] = (txt_fecha_emision.Text != "") ? txt_fecha_emision.Text : "";
        dr["mv_fecha_inicio_licencia"] = (txt_fecha_inicio.Text != "") ? txt_fecha_inicio.Text : "";
        dr["mv_fecha_fin_licencia"] = (txt_fecha_fin.Text != "") ? txt_fecha_fin.Text : "";
        dr["mv_fecha_fin"] = "";
        dr["mv_texto_adicional_tenor"] = "";
        dr["mv_nro_memo_anterior"] = "";
        dr["mv_fecha_memo_anterior"] = "";
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
    private void guardarLicencia(DateTime? startDate = null, DateTime? endDate = null)
    {
        int per_id = (Request.QueryString["id"].ToString() != "") ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        _licencia = new cls_cp_licencia_justificada();
        _licencia.lj_per_id = per_id;
        _licencia.lj_tipo_licencia = Convert.ToInt32(ddl_tipo_licencia.SelectedValue);
        _licencia.lj_fecha_inicial = startDate;
        _licencia.lj_fecha_final = endDate;
        _licencia.lj_estado = "V";
        _licencia.Adicionar();
        var detalle_licencia = _licencia.ObtenerRegistroFun();
        int lj_id = (validarCampo(detalle_licencia.Tables[0].Rows[0]["lj_id"]) != "") ? Convert.ToInt32(validarCampo(detalle_licencia.Tables[0].Rows[0]["lj_id"])) : 0;
        guardarGlosa(lj_id, "lj_id", "tbl_cp_licencia_Justificada");
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
    private void limpiar()
    {
        ddl_tipo_licencia.SelectedValue = "0";
        txt_fecha_inicio.Text = "";
        txt_fecha_fin.Text = "";
        txt_fecha_emision.Text = "";
        chk_contar.Checked = false;
    }

    protected void chk_contar_CheckedChanged(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void btn_anular_licencia_Click(object sender, EventArgs e)
    {
        _licencia = new cls_cp_licencia_justificada();
        _licencia.lj_id = Convert.ToInt32(hf_lj_id.Value);
        _licencia.Eliminar();
        listarLicenciasAsignados();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Se anuló la licencia correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarLicencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void ddl_tipo_licencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        //if (ddl_tipo_licencia.SelectedValue == "32")
        if (ddl_tipo_licencia.SelectedValue == "2298" || ddl_tipo_licencia.SelectedValue == "9561")

        {
            txt_fecha_inicio.Enabled = true;
            txt_fecha_fin.Enabled = true;
            rf_txt_fecha_inicio.Enabled = true;
            rf_txt_fecha_fin.Enabled = true;
            chk_contar.Enabled = true;
        } else
        {
            txt_fecha_inicio.Enabled = false;
            txt_fecha_fin.Enabled = false;
            rf_txt_fecha_inicio.Enabled = false;
            rf_txt_fecha_fin.Enabled = false;
            chk_contar.Enabled = false;
            chk_contar.Checked = false;
        }
        SetScript("");
    }
}