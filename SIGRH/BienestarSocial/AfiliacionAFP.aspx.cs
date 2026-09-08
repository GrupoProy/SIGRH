using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
public partial class BienestarSocial_AfiliacionAFP : System.Web.UI.Page
{
    private cls_bs_afp afp = null;
    private cls_catalogo _catalogo = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            int as_id = Convert.ToInt32(Request.QueryString["id2"].ToString());
            listarAFP();
            listarCarnetRegistro();
            validarEdicion(per_id);
            informacionFuncionario(per_id, as_id);
            listarAfpAsginados(per_id);

            SetScriptInicio("$('.table').DataTable().destroy(); ");
        }
    }
    private void listarAFP()
    {
        _catalogo = new cls_catalogo { cat_tabla = "previsora" };
        ddl_afp.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_afp.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_afp.DataValueField = "cat_abreviacion";
        ddl_afp.DataTextField = "cat_descripcion";
        ddl_afp.DataBind();
    }
    private void listarCarnetRegistro()
    {
        _catalogo = new cls_catalogo { cat_tabla = "carnet_registro" };
        ddl_carnet_registro.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_carnet_registro.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_carnet_registro.DataValueField = "cat_abreviacion";
        ddl_carnet_registro.DataTextField = "cat_descripcion";
        ddl_carnet_registro.DataBind();
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

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append("var me = $('.accountBank'); me.mask('201-99999999-9-99'); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append(data);
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
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
            "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
    private void listarAfpAsginados(int per_id = 0)
    {
        try
        {
            afp = new cls_bs_afp();
            afp.afp_per_id = per_id;
            var detalle_afp = afp.ObtenerGrillaAFP();
            gv_afp.DataSource = detalle_afp;
            gv_afp.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void validarEdicion(int per_id = 0)
    {
        afp = new cls_bs_afp();
        afp.afp_per_id = per_id;
        var detalleRegistro= afp.ObtenerRegistro();
        d_motivo.Visible = false;

        if (detalleRegistro.Tables[0].Rows.Count > 0)
        {
            if (validarCampo(detalleRegistro.Tables[0].Rows[0]["afp_nua"]) != "")
            {
                hf_editar.Value = "2";
                d_motivo.Visible = true;
            } 
            else
            {
                hf_editar.Value = "1";
            }
        }
        else
        {
            hf_editar.Value = "0";
        }
    }
    private void informacionFuncionario(int per_id = 0, int as_id = 0)
    {
        afp = new cls_bs_afp();
        afp.afp_per_id = per_id;
        afp.as_id = as_id;
        var detalleFuncionario = afp.ObtenerDetalleFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_estado_civil.Text = validarCampo(funcionario["per_estado_civil"]);
                ltl_sexo.Text = validarCampo(funcionario["per_sexo"]);
                ltl_fecha_nac.Text = validarCampo(funcionario["per_fecha_nac"]);
                ltl_edad.Text = validarCampo(funcionario["edad"]);
                ltl_pais.Text = validarCampo(funcionario["per_procedencia"]);
                ltl_departamento.Text = validarCampo(funcionario["departamento"]);
                ltl_zona.Text = validarCampo(funcionario["perd_zona"]);
                ltl_tipo_via.Text = validarCampo(funcionario["perd_tipo_via"]);
                ltl_nombre_via.Text = validarCampo(funcionario["perd_descripcion_via"]);
                ltl_dom_nro.Text = validarCampo(funcionario["perd_numero"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_cargo.Text = validarCampo(funcionario["es_descripcion"]);
                ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
                ltl_unidad_org.Text = validarCampo(funcionario["eo_descripcion"]);
                var det_afp = ddl_afp.Items.FindByValue(validarCampo(funcionario["afp_previsora"]));
                ddl_afp.SelectedValue = (det_afp != null) ? det_afp.Value : "0";
                txt_nua.Text = validarCampo(funcionario["afp_nua"]);
                txt_fecha_filiacion.Text = (hf_editar.Value == "1") ? "" : validarCampo(funcionario["afp_fecha_filiacion"]);
                var det_carnet = ddl_carnet_registro.Items.FindByValue(validarCampo(funcionario["afp_estado_carnet"]));
                ddl_carnet_registro.SelectedValue = (det_carnet != null) ? det_carnet.Value : "0";
                hf_afp_id.Value = validarCampo(funcionario["afp_id"]);


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

    protected void gv_afp_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_afp.Rows.Count > 0)
        {
            if (gv_afp.HeaderRow != null)
            {
                gv_afp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_afp.FooterRow != null)
            {
                gv_afp.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    protected void btn_guardar_afp_Click(object sender, EventArgs e)
    {
        sc = "$('#modalAfiliacion').modal('show');";
        SetScript(sc);
    }
    private void insertarAFP()
    {
        DateTime? afp_fecha_modificacion_aux = null;
        if (hf_editar.Value == "2") 
        {
            afp_fecha_modificacion_aux = Convert.ToDateTime(DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"));
        } 
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        afp = new cls_bs_afp();
        afp.afp_per_id = per_id;
        afp.afp_previsora = ddl_afp.SelectedValue;
        afp.afp_nua = txt_nua.Text;
        afp.afp_fecha_filiacion = Convert.ToDateTime(txt_fecha_filiacion.Text);
        afp.afp_fecha_modificacion = afp_fecha_modificacion_aux;
        afp.afp_motivo_modificacion = (hf_editar.Value == "2") ? txt_motivo.Text.Trim().ToUpper() : null;
        afp.afp_estado_carnet = ddl_carnet_registro.SelectedValue;
        afp.afp_fecha_carnet = null;
        afp.afp_usuario = Convert.ToInt32(Session["us_id"]);
        afp.Adicionar();
    }
    private void actualizarAFP()
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        afp = new cls_bs_afp();
        afp.afp_id = Convert.ToInt32(hf_afp_id.Value);
        afp.afp_per_id = per_id;
        afp.afp_previsora = ddl_afp.SelectedValue;
        afp.afp_nua = txt_nua.Text;
        afp.afp_fecha_filiacion = Convert.ToDateTime(txt_fecha_filiacion.Text);
        afp.afp_fecha_modificacion = null;
        afp.afp_motivo_modificacion = null;
        afp.afp_estado_carnet = ddl_carnet_registro.SelectedValue;
        afp.afp_fecha_carnet = null;
        afp.afp_usuario = Convert.ToInt32(Session["us_id"]);
        afp.CompletarDatosAFP();
    }
    private void actualizarEstadoAFP()
    {
        afp = new cls_bs_afp();
        afp.afp_id = Convert.ToInt32(hf_afp_id.Value);
        afp.ActualizarEstadoAFP();
    }
    private void Limpiar()
    {
        ddl_afp.SelectedValue = "0";
        txt_nua.Text = "";
        txt_fecha_filiacion.Text = "";
        ddl_carnet_registro.SelectedValue = "0";
        txt_motivo.Text = "";
    }

    protected void btn_estado_Click(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void btn_confirmar_guardar_Click(object sender, EventArgs e)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        int as_id = Convert.ToInt32(Request.QueryString["id2"].ToString());
        switch (hf_editar.Value)
        {
            case "0":
                insertarAFP();
                break;
            case "1":
                actualizarAFP();
                sc = "Swal.fire({ icon: 'success', title: 'AFP modificado correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalAfiliacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false); }});";
                break;
            case "2":
                actualizarEstadoAFP();
                insertarAFP();
                sc = "Swal.fire({ icon: 'success', title: 'AFP modificado correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalAfiliacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false); }});";
                break;
            default:
                SetScript("");
                break;
        }
        Limpiar();
        validarEdicion(per_id);
        informacionFuncionario(per_id, as_id);
        listarAfpAsginados(per_id);
        SetScript(sc);
    }
}