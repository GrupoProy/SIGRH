using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;


public partial class BienestarSocial_RegistroAfiliacionEGS : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_pla_factor factor = null;
    private cls_bs_asignacion_beneficio beneficio = null;
    private cls_bs_asignacion_beneficio familiar = null;
    private cls_catalogo _catalogo = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            string fa_id = Request.QueryString["id3"].ToString();
            informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
            listaFiltradoPoliclinico();
            listarCiudadResidencia();
            listarZona();
            listarTipoVia();
            llenarDatosDomicilio();
            listaFiltradoTipoParentesco();
            listaFiltradoTipoGenero();
            listaFiltradoTipoEstadoVivo();
            listaFiltradoTipoAvc();
            llenarDatosAfiliacionX(Convert.ToInt32(codFun));
            listarGrillaAfiliacionFamiliares();
            listarTipoParentescoAdd();
            listarTipoGeneroAdd();
            SetScriptInicio("$('.table').DataTable().destroy();");
        }
    }

    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        familiar = new cls_bs_asignacion_beneficio();
        familiar.pf_per_id = codFun;
        familiar.as_id = as_id;
        var detalleFuncionario = familiar.ObtenerDatosDetalleFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_fecha_nac.Text = validarCampo(funcionario["fecha_nac"]);
                ltl_estado_civil.Text = validarCampo(funcionario["per_estado_civil"]);
                ltl_sexo.Text = validarCampo(funcionario["per_sexo_desc"]);
                ltl_telefono.Text = validarCampo(funcionario["perd_telefono"]);
                ltl_celular.Text = validarCampo(funcionario["perd_celular"]);
                ltl_pais.Text = validarCampo(funcionario["per_procedencia"]);
                ltl_cuidad_localidad.Text = validarCampo(funcionario["perd_cuidad_residencia"]);
                ltl_zona.Text = validarCampo(funcionario["perd_zona"]);
                ltl_tipo_via.Text = validarCampo(funcionario["perd_tipo_via"]);
                ltl_nombre_via.Text = validarCampo(funcionario["perd_descripcion_via"]);
                ltl_numero.Text = validarCampo(funcionario["perd_numero"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
                aux_per_id.Value = validarCampo(funcionario["per_id"]);
                aux_as_id.Value = validarCampo(funcionario["as_id"]);
                aux_ae_empleador.Value = Convert.ToString(obtenerIdEmpleador());
                string haberBasico = validarCampo(funcionario["haber_basico"]);
                decimal haberBasico2 = Convert.ToDecimal(haberBasico);
                haberBasico2 = Math.Round(haberBasico2, 2);
                ltl_haber_basico.Text = Convert.ToString(haberBasico2);

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

                if (validarCampo(funcionario["fp_foto"]) != null && validarCampo(funcionario["fp_foto"]) != "")
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

    private void listaFiltradoPoliclinico()
    {
        try
        {
            familiar = new cls_bs_asignacion_beneficio();

            ddl_tipo_policlinico.Items.Clear();
            ddl_tipo_policlinico.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_policlinico.DataValueField = "cat_secuencial";
            ddl_tipo_policlinico.DataTextField = "cat_descripcion";
            ddl_tipo_policlinico.DataSource = familiar.listaFiltradoPoliclinico();
            ddl_tipo_policlinico.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listarCiudadResidencia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "ciudad_localidad", cat_id_superior = 29 };
        ddl_perd_ciudad_residencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_perd_ciudad_residencia.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_perd_ciudad_residencia.DataValueField = "cat_secuencial";
        ddl_perd_ciudad_residencia.DataTextField = "cat_descripcion";
        ddl_perd_ciudad_residencia.DataBind();
    }

    private void listarZona()
    {
        _catalogo = new cls_catalogo { cat_tabla = "zona" };
        ddl_perd_zona.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_perd_zona.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_perd_zona.DataValueField = "cat_secuencial";
        ddl_perd_zona.DataTextField = "cat_descripcion";
        ddl_perd_zona.DataBind();
    }

    private void listarTipoVia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_via" };
        ddl_perd_tipo_via.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_perd_tipo_via.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_perd_tipo_via.DataValueField = "cat_secuencial";
        ddl_perd_tipo_via.DataTextField = "cat_descripcion";
        ddl_perd_tipo_via.DataBind();
    }

    private void listaFiltradoTipoParentesco()
    {
        try
        {
            beneficio = new cls_bs_asignacion_beneficio();

            ddl_pf_tipo_parentesco.Items.Clear();
            ddl_pf_tipo_parentesco.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_pf_tipo_parentesco.DataValueField = "cat_secuencial";
            ddl_pf_tipo_parentesco.DataTextField = "cat_descripcion";
            ddl_pf_tipo_parentesco.DataSource = beneficio.listaFiltradoTipoParentesco();
            ddl_pf_tipo_parentesco.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaFiltradoTipoGenero()
    {
        try
        {
            beneficio = new cls_bs_asignacion_beneficio();

            ddl_tipo_genero.Items.Clear();
            ddl_tipo_genero.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_genero.DataValueField = "cat_abreviacion";
            ddl_tipo_genero.DataTextField = "cat_descripcion";
            ddl_tipo_genero.DataSource = beneficio.listaFiltradoTipoGenero();
            ddl_tipo_genero.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoTipoEstadoVivo()
    {
        try
        {
            beneficio = new cls_bs_asignacion_beneficio();

            ddl_estado_vivo.Items.Clear();
            ddl_estado_vivo.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_estado_vivo.DataValueField = "cat_abreviacion";
            ddl_estado_vivo.DataTextField = "cat_descripcion";
            ddl_estado_vivo.DataSource = beneficio.listaFiltradoEstadoVivo();
            ddl_estado_vivo.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoTipoAvc()
    {
        try
        {
            beneficio = new cls_bs_asignacion_beneficio();

            ddl_tipo_avc.Items.Clear();
            ddl_tipo_avc.DataValueField = "cat_secuencial";
            ddl_tipo_avc.DataTextField = "cat_descripcion";
            ddl_tipo_avc.DataSource = beneficio.listaFiltradoTipoAvc();
            ddl_tipo_avc.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void SetScriptInicio(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_aporte').select2({ placeholder: { id: '-1', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_parentesco_add').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_genero_add').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
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
                    "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });}");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
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
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_policlinico').select2({ placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_avc').select2({ placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_perd_ciudad_residencia').select2({ dropdownParent: $('#modalEditarDomicilio'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_perd_zona').select2({ dropdownParent: $('#modalEditarDomicilio'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_perd_tipo_via').select2({ dropdownParent: $('#modalEditarDomicilio'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_pf_tipo_parentesco').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_genero').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_estado_vivo').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_parentesco_add').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_genero_add').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
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
                    "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gv_familiares_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_familiares.Rows.Count > 0)
        {
            if (gv_familiares.HeaderRow != null)
            {
                gv_familiares.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_familiares.FooterRow != null)
            {
                gv_familiares.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_familiares_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string pf_id = gv_familiares.DataKeys[index].Values[0].ToString();
        aux_pf_id.Value = pf_id;
        switch (e.CommandName)
        {
            case "GetEdit":
                llenarDatosFamiliar(Convert.ToInt32(pf_id));
                break;
            default:
                break;
        }
    }

    protected void llenarDatosFamiliar(int pf_id = 0)
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        beneficio = new cls_bs_asignacion_beneficio();
        beneficio.pf_id = pf_id;
        beneficio.pf_per_id = per_id;
        var detalleFamiliar = beneficio.ObtenerFamiliar();
        var familiarX = detalleFamiliar.Tables[0].Rows[0];
        txt_ap_paterno_fam.Text = validarCampo(familiarX["pf_paterno"]);
        txt_ap_materno_fam.Text = validarCampo(familiarX["pf_materno"]);
        txt_nombres_fam.Text = validarCampo(familiarX["pf_nombres"]);
        txt_ap_esposo_fam.Text = validarCampo(familiarX["pf_ap_esposo"]);
        ddl_pf_tipo_parentesco.SelectedValue = validarCampo(familiarX["pf_tipo_parentesco"]);
        txt_fecha_nac_fam.Text = validarCampo(familiarX["pf_fecha_nac"]);
        ddl_tipo_genero.SelectedValue = (validarCampo(familiarX["pf_sexo"]) != "") ? validarCampo(familiarX["pf_sexo"]) : "0";
        ddl_estado_vivo.SelectedValue = (validarCampo(familiarX["pf_estado_vivo"]) != "") ? validarCampo(familiarX["pf_estado_vivo"]) : "0";
        txt_fecha_defuncion.Text = validarCampo(familiarX["pf_fecha_defuncion"]);
        txt_ap_paterno_fam.Enabled = false;
        txt_ap_materno_fam.Enabled = false;
        txt_nombres_fam.Enabled = false;
        txt_ap_esposo_fam.Enabled = false;
        ddl_pf_tipo_parentesco.Enabled = false;
        sc = "$('#modalEditarFamiliar').modal('show');$('#block_tipo_avc').css('display', 'block');";
        if (txt_fecha_defuncion.Text != "")
        {
            sc = sc + "$('#block_fechaDefuncion').css('display', 'block');";
        }
        else
        {
            sc = sc + "$('#block_fechaDefuncion').css('display', 'none');";
        }
        SetScript(sc);
    }

    private string listarGrillaFamiliares()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            familiar = new cls_bs_asignacion_beneficio();
            familiar.pf_per_id = per_id;
            var familiaresX = familiar.ListarFamiliaresAfiliados();
            gv_familiares.DataSource = familiaresX;
            gv_familiares.DataBind();

            if (familiaresX.Tables[0].Rows.Count > 0)
            {
                sc = "$('#block_gvFamiliares').css('display', 'block');$('#block_tipo_avc').css('display', 'block');";
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-check', message: 'El funcionario no tiene familiares registrados.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#block_gvFamiliares').css('display', 'none');$('#block_tipo_avc').css('display', 'none');";
            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
        return sc;
    }

    protected void btn_asigFamiliares_Click(object sender, EventArgs e)
    {
        sc = listarGrillaFamiliares();
        SetScript(sc);
    }

    protected void llenarDatosAfiliacionX(int per_id = 0)
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            as_id = Convert.ToInt32(aux_as_id.Value),
            pf_per_id = per_id
        };
        var detalleAfiliacion = beneficio.ObtenerAfiliacionX();
        var afiliacionX = detalleAfiliacion.Tables[0].Rows[0];
        txt_nombre_caja_afiliado.Text = validarCampo(afiliacionX["egs_descripcion"]);
        txt_fecha_afiliado.Text = validarCampo(afiliacionX["ae_fecha_form"]);
        ddl_tipo_policlinico.SelectedValue = (validarCampo(afiliacionX["ae_policlinico"]) != "") ? validarCampo(afiliacionX["ae_policlinico"]) : "0";
        txt_nro_afiliado.Text = validarCampo(afiliacionX["matricula_cns"]);
        aux_ae_id.Value = validarCampo(afiliacionX["ae_id"]);
        aux_fa_id.Value = validarCampo(afiliacionX["ae_egs_id"]);
        txt_nombre_caja_afiliado.Enabled = false;
        txt_fecha_afiliado.Enabled = false;
        txt_nro_afiliado.Enabled = false;
        block_policlinico.Visible = (aux_fa_id.Value != "37") ? false : true;
        ddl_tipo_avc.SelectedValue = (aux_fa_id.Value != "37") ? "3" : ddl_tipo_avc.SelectedValue;
        ddl_tipo_avc.Enabled = (aux_fa_id.Value != "37") ? false : true;
    }

    private void GuardarPoliclinico()
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            as_id = Convert.ToInt32(aux_as_id.Value),
            pf_per_id = Convert.ToInt32(aux_per_id.Value),
            ae_policlinico = Convert.ToInt32(ddl_tipo_policlinico.SelectedValue),
            ae_em_id = Convert.ToInt32(aux_ae_empleador.Value)
        };
        beneficio.AdicionarPoliclinico();
    }

    private int obtenerIdEmpleador()
    {
        beneficio = new cls_bs_asignacion_beneficio();
        var obtEmpleador = beneficio.obtenerIdEmpleador();
        int id_empleador = 0;
        if (obtEmpleador.Tables[0].Rows[0]["em_id"] != DBNull.Value && obtEmpleador.Tables[0].Rows[0]["em_id"].ToString().Trim() != "")
        {
            id_empleador = Convert.ToInt32(obtEmpleador.Tables[0].Rows[0]["em_id"]);
        }
        return id_empleador;
    }

    protected string calculaEdad(int pf_id = 0)
    {
        familiar = new cls_bs_asignacion_beneficio();
        familiar.pf_id = pf_id;
        var detalleFamiliar = familiar.ObtenerFechaNacFamiliar();
        var familiarX = detalleFamiliar.Tables[0].Rows[0];
        aux_pf_fecha_nac.Value = validarCampo(familiarX["pf_fecha_nac"]);
        aux_pf_tipo_parentesco.Value = validarCampo(familiarX["pf_tipo_parentesco"]);
        DateTime fecha = Convert.ToDateTime(aux_pf_fecha_nac.Value);
        DateTime now = DateTime.Today;
        int edad = now.Year - fecha.Year;
        return edad.ToString();
    }

    protected void btn_guardar_afiliacion_Click(object sender, EventArgs e)
    {
        int egs_id = Convert.ToInt32(aux_fa_id.Value);
        int edad = 0;
        cls_bs_afiliacion_egs afili = new cls_bs_afiliacion_egs();
        beneficio = new cls_bs_asignacion_beneficio();
        afili.ae_as_id = Convert.ToInt32(aux_as_id.Value);
        afili.ae_matricula = txt_nro_afiliado.Text;
        afili.CambiarMatricula();
        if (egs_id == 37)
        {
            if (ddl_tipo_policlinico.SelectedValue != "0" && ddl_tipo_policlinico.SelectedValue != null)
            {
                GuardarPoliclinico();
                sc = "$.notify({ icon: 'fa fa-check', message: 'Policlinico guardado correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });";
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-check', message: 'Debe asignar un Policlinico al funcionario seleccionado.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            }
        }

        for (int i = 0; i < gv_familiares.Rows.Count; i++)
        {
            GridViewRow row = gv_familiares.Rows[i];
            bool isChecked = ((CheckBox)row.FindControl("chk_familiar")).Checked;
            if (isChecked)
            {
                int masiv_pf_id = (int)gv_familiares.DataKeys[i].Value;

                beneficio.aeb_ae_id = Convert.ToInt32(aux_ae_id.Value);
                beneficio.pf_id = masiv_pf_id;
                var verificaAfiliacion = beneficio.VerificarAfiliacion();
                if (verificaAfiliacion.Tables[0].Rows.Count > 0)
                {
                    sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar la acción, se realizó un registro anteriormente.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#block_gvFamiliares').css('display', 'none');$('#block_tipo_avc').css('display', 'none');";
                }
                else
                {
                    edad = Convert.ToInt32(calculaEdad(masiv_pf_id));
                    if (edad >= 25 && aux_pf_tipo_parentesco.Value == "3")
                    {
                        sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar la acción, el beneficiario es mayor de edad.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#block_gvFamiliares').css('display', 'none');$('#block_tipo_avc').css('display', 'none');";
                    }
                    else
                    {
                        GuardarAfiliacionFamiliares(masiv_pf_id);
                        sc = "Swal.fire({ icon: 'success', title: 'Afiliación exitosa', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_gvFamiliares').css('display', 'none');$('#block_tipo_avc').css('display', 'none'); }});";
                    }
                }
            }
        }
        ddl_tipo_avc.SelectedValue = "1";
        gv_familiares.DataSource = null;
        gv_familiares.DataBind();
        listarGrillaAfiliacionFamiliares();
        SetScript(sc);
    }

    private void GuardarAfiliacionFamiliares(int pf_id = 0)
    {
        familiar = new cls_bs_asignacion_beneficio
        {
            aeb_ae_id = Convert.ToInt32(aux_ae_id.Value),
            pf_id = pf_id,
            aeb_afi_por = ddl_tipo_avc.SelectedValue
        };
        familiar.AdicionarAfiliacionFamiliar();
    }

    protected void btn_editar_domicilio_Click(object sender, EventArgs e)
    {
        sc = "$('#modalEditarDomicilio').modal('show');";
        SetScript(sc);
    }

    protected void llenarDatosDomicilio()
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            as_id = Convert.ToInt32(aux_as_id.Value),
            pf_per_id = Convert.ToInt32(aux_per_id.Value)
        };
        var detalleDomicilio = beneficio.ObtenerDomicilio();
        var domicilioX = detalleDomicilio.Tables[0].Rows[0];
        ddl_perd_ciudad_residencia.SelectedValue = validarCampo(domicilioX["perd_cuidad_id"]);
        ddl_perd_zona.SelectedValue = validarCampo(domicilioX["perd_zona_id"]);
        ddl_perd_tipo_via.SelectedValue = validarCampo(domicilioX["perd_tipo_via_id"]);
        txt_nombre_via.Text = validarCampo(domicilioX["perd_descripcion_via"]);
        txt_numero_casa.Text = validarCampo(domicilioX["perd_numero"]);
    }

    protected void gv_afiliacion_familiares_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_afiliacion_familiares.Rows.Count > 0)
        {
            if (gv_afiliacion_familiares.HeaderRow != null)
            {
                gv_afiliacion_familiares.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_afiliacion_familiares.FooterRow != null)
            {
                gv_afiliacion_familiares.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_afiliacion_familiares_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string aeb_id = gv_afiliacion_familiares.DataKeys[index].Values[0].ToString();
        aux_aeb_id.Value = aeb_id;
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarAfiliacionFamiliar').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    private void listarGrillaAfiliacionFamiliares()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            familiar = new cls_bs_asignacion_beneficio();
            familiar.pf_per_id = per_id;
            var familiares = familiar.ListarFamiliaresAfiliadosEGS();
            int tam = familiares.Tables[0].Rows.Count;
            if (familiares.Tables[0].Rows.Count > 0)
            {
                gv_afiliacion_familiares.DataSource = familiares;
                this.block_familia.Visible = false;
            }
            else
            {
                this.block_familia.Visible = true;
            }
            gv_afiliacion_familiares.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_eliminar_afiliacion_familiar_Click(object sender, EventArgs e)
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            aeb_id = Convert.ToInt32(aux_aeb_id.Value)
        };
        beneficio.EliminarAfiliacionFamiliar();
        listarGrillaAfiliacionFamiliares();
        ddl_tipo_avc.SelectedValue = "1";
        gv_familiares.DataSource = null;
        gv_familiares.DataBind();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarAfiliacionFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_gvFamiliares').css('display', 'none');$('#block_tipo_avc').css('display', 'none');";
        SetScript(sc);
    }

    protected void ddl_estado_vivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddl_estado_vivo.SelectedValue)
        {
            case "V":
                sc = "$('#block_fechaDefuncion').css('display', 'none');$('#block_tipo_avc').css('display', 'block');";
                txt_fecha_defuncion.Text = string.Empty;
                SetScript(sc);
                break;
            case "D":
                sc = "$('#block_fechaDefuncion').css('display', 'block');$('#block_tipo_avc').css('display', 'block');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    protected void actualizarDatosFamiliares()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        familiar = new cls_bs_asignacion_beneficio();
        familiar.pf_id = Convert.ToInt32(aux_pf_id.Value);
        familiar.pf_per_id = per_id;
        familiar.pf_fecha_nac = (txt_fecha_nac_fam.Text != "") ? txt_fecha_nac_fam.Text : null;
        familiar.pf_estado_vivo = ddl_estado_vivo.SelectedValue;
        familiar.pf_fecha_defuncion = (txt_fecha_defuncion.Text != "") ? txt_fecha_defuncion.Text : null;
        familiar.pf_sexo = ddl_tipo_genero.SelectedValue;
        familiar.ActualizarDatosFamiliar();
    }

    protected void btn_guardar_familiar_Click(object sender, EventArgs e)
    {
        actualizarDatosFamiliares();
        sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-check', message: 'Familiar editado correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });$('#modalEditarFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        sc = sc + listarGrillaFamiliares();
        aux_pf_id.Value = "";
        SetScript(sc);
    }

    protected void btn_cancelar_familiar_Click(object sender, EventArgs e)
    {
        sc = " $('#modalEditarFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_tipo_avc').css('display', 'block');";
        aux_pf_id.Value = "";
        SetScript(sc);
    }

    protected void ddl_tipo_policlinico_SelectedIndexChanged(object sender, EventArgs e)
    {
        sc = "$('#block_gvFamiliares').css('display', 'none');$('#block_tipo_avc').css('display', 'none');";
        SetScript(sc);
    }

    protected void actualizarDomicilio()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        beneficio = new cls_bs_asignacion_beneficio
        {
            pf_per_id = per_id,
            perd_ciudad_residencia = Convert.ToInt32(ddl_perd_ciudad_residencia.SelectedValue),
            perd_zona = Convert.ToInt32(ddl_perd_zona.SelectedValue),
            perd_tipo_via = Convert.ToInt32(ddl_perd_tipo_via.SelectedValue),
            perd_descripcion_via = txt_nombre_via.Text,
            perd_numero = txt_numero_casa.Text
        };
        beneficio.ActualizarDatosDomicilio();
    }

    protected void btn_guardar_domicilio_Click(object sender, EventArgs e)
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int as_id = Convert.ToInt32(aux_as_id.Value);
        actualizarDomicilio();
        informacionFuncionario(per_id, as_id);
        sc = "MostrarMascara(false); $.notify({ icon: 'fa fa-check', message: 'Domicilio editado correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });$('#modalEditarDomicilio').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_cancelar_domicilio_Click(object sender, EventArgs e)
    {
        sc = " $('#modalEditarDomicilio').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    // Añadir nuevo familiar
    private void listarTipoParentescoAdd()
    {
        beneficio = new cls_bs_asignacion_beneficio();
        ddl_tipo_parentesco_add.DataSource = beneficio.listaFiltradoFamiliarBeneficio();
        ddl_tipo_parentesco_add.DataValueField = "cat_secuencial";
        ddl_tipo_parentesco_add.DataTextField = "cat_descripcion";
        ddl_tipo_parentesco_add.DataBind();
    }

    private void listarTipoGeneroAdd()
    {
        beneficio = new cls_bs_asignacion_beneficio();
        ddl_tipo_genero_add.Items.Clear();
        ddl_tipo_genero_add.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_tipo_genero_add.DataValueField = "cat_abreviacion";
        ddl_tipo_genero_add.DataTextField = "cat_descripcion";
        ddl_tipo_genero_add.DataSource = beneficio.listaFiltradoTipoGenero();
        ddl_tipo_genero_add.DataBind();
    }

    private void GuardarNuevoFamiliar()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        familiar = new cls_bs_asignacion_beneficio
        {
            pf_per_id = per_id,
            pf_tipo_parentesco = ddl_tipo_parentesco_add.SelectedValue,
            pf_paterno = txt_paterno_add.Text.ToUpper().Trim(),
            pf_materno = txt_materno_add.Text.ToUpper().Trim(),
            pf_nombres = txt_nombre_add.Text.ToUpper().Trim(),
            pf_fecha_nac = txt_fecha_nac_add.Text,
            pf_sexo = ddl_tipo_genero_add.SelectedValue
        };
        familiar.AdicionarFamiliar();
    }

    protected void btn_nuevo_familiar_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevoFamiliar').modal('show');";
        SetScript(sc);
    }

    protected void btn_adicionar_nuevoFamiliar_Click(object sender, EventArgs e)
    {
        if (((txt_paterno_add.Text.Trim() != null && txt_paterno_add.Text.Trim() != "" && txt_nombre_add.Text.Trim() != null && txt_nombre_add.Text.Trim() != "") || (txt_materno_add.Text.Trim() != null && txt_materno_add.Text.Trim() != "" && txt_nombre_add.Text.Trim() != null && txt_nombre_add.Text.Trim() != "")))
        {
            GuardarNuevoFamiliar();
            LimpiarFamiliar();
            sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Familiar añadido correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_mesAsignado').css('display', 'none'); $('#block_asigFamiliares').css('display', 'none'); $('#block_gvFamiliares').css('display', 'none'); $('#modalNuevoFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-check', message: 'El familiar debe tener por lo menos un apellido. .'},{type: 'success', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

    }

    protected void btn_cancelar_nuevoFamiliar_Click(object sender, EventArgs e)
    {
        LimpiarFamiliar();
        sc = " $('#modalNuevoFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_nuevo_familiar').css('display', 'block');$('#block_mesAsignado').css('display', 'none');$('#block_asigFamiliares').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
        aux_pf_id.Value = "";
        SetScript(sc);
    }

    protected void LimpiarFamiliar()
    {
        txt_paterno_add.Text = string.Empty;
        txt_materno_add.Text = string.Empty;
        txt_nombre_add.Text = string.Empty;
        txt_fecha_nac_add.Text = string.Empty;
        ddl_tipo_genero_add.SelectedValue = "0";
    }
}