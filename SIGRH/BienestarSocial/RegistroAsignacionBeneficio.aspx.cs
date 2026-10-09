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

public partial class BienestarSocial_RegistroAsignacionBeneficio : System.Web.UI.Page
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
            int codFun = (Request.QueryString["id"].ToString() != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
            int as_id = (Request.QueryString["id2"].ToString() != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
            informacionFuncionario(codFun, as_id);
            listaFiltradoTipoBeneficio();
            listaFiltradoTipoMes();
            listaFiltradoTipoParentesco();
            listaFiltradoTipoGenero();
            listaFiltradoTipoEstadoVivo();
            listaFiltradoTipoDoc();
            listarGrillaAsignacionBeneficio();
            listarTipoParentescoAdd();
            listarTipoGeneroAdd();
            llenarDatosAfiliacion(codFun, as_id);
            listarGrillaAfiliacionFamiliares();
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
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
                aux_per_sexo.Value = validarCampo(funcionario["per_sexo"]);
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

    private void listaFiltradoTipoBeneficio()
    {
        try
        {
            beneficio = new cls_bs_asignacion_beneficio();

            ddl_tipo_beneficio.Items.Clear();
            ddl_tipo_beneficio.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_beneficio.DataValueField = "fa_id";
            ddl_tipo_beneficio.DataTextField = "fa_descripcion";
            ddl_tipo_beneficio.DataSource = beneficio.listaFiltradoTipoBeneficio();
            ddl_tipo_beneficio.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoTipoMes()
    {
        try
        {
            beneficio = new cls_bs_asignacion_beneficio();

            ddl_tipo_mesAsignado.Items.Clear();
            ddl_tipo_mesAsignado.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_mesAsignado.DataValueField = "cat_secuencial";
            ddl_tipo_mesAsignado.DataTextField = "cat_descripcion";
            ddl_tipo_mesAsignado.DataSource = beneficio.listaFiltradoTipoMes();
            ddl_tipo_mesAsignado.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
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
        sb.Append("$('#ContentPlaceHolder1_ddl_pf_tipo_parentesco').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_genero').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_estado_vivo').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
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
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_pf_tipo_parentesco').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_genero').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_estado_vivo').select2({ dropdownParent: $('#modalEditarFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
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
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void ddl_tipo_beneficio_SelectedIndexChanged(object sender, EventArgs e)
    {
        beneficio = new cls_bs_asignacion_beneficio();
        string per_sexo = Convert.ToString(aux_per_sexo.Value);
        if (per_sexo == "M")
        {
            switch (ddl_tipo_beneficio.SelectedValue)
            {
                case "39":
                    sc = "$('#block_mesAsignado').css('display', 'block'); $('#block_asigFamiliares').css('display', 'block');$('#block_gvFamiliares').css('display', 'none');";

                    break;
                case "40":
                    sc = "$('#block_mesAsignado').css('display', 'block'); $('#block_asigFamiliares').css('display', 'block');$('#block_gvFamiliares').css('display', 'none');";

                    break;
                default:
                    break;
            }
        }
        else
        {
            switch (ddl_tipo_beneficio.SelectedValue)
            {
                case "39":
                    sc = "$('#block_mesAsignado').css('display', 'block'); $('#block_asigFamiliares').css('display', 'block');$('#block_gvFamiliares').css('display', 'none');";

                    break;
                case "40":
                    sc = "$('#block_mesAsignado').css('display', 'block'); $('#block_asigFamiliares').css('display', 'block');$('#block_gvFamiliares').css('display', 'none');";

                    break;
                default:
                    break;
            }
        }
        txt_a_partir.Text = string.Empty;
        txt_hasta.Text = string.Empty;
        ddl_tipo_mesAsignado.SelectedValue = "0";
        aux_pf_id.Value = "";
        SetScript(sc);
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
            case "GetAsig":
                seleccionarBeneficiario(Convert.ToInt32(pf_id));
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
        sc = "$('#modalEditarFamiliar').modal('show');";
        if (txt_fecha_defuncion.Text != "")
        {
            sc = sc + "$('#block_fechaDefuncion').css('display', 'block');" + habilitar();
        }
        else
        {
            sc = sc + "$('#block_fechaDefuncion').css('display', 'none');" + habilitar();
        }
        SetScript(sc);
    }

    protected void seleccionarBeneficiario(int pf_id = 0)
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        beneficio = new cls_bs_asignacion_beneficio();
        beneficio.pf_id = pf_id;
        beneficio.pf_per_id = per_id;
        var detalleFamiliar = beneficio.ObtenerFamiliar();
        var familiarX = detalleFamiliar.Tables[0].Rows[0];
        txt_nombre_beneficiarioS.Text = validarCampo(familiarX["pf_paterno"]) + " " + validarCampo(familiarX["pf_materno"]) + " " + validarCampo(familiarX["pf_nombres"]);
        aux_pf_estado_vivo.Value = validarCampo(familiarX["pf_estado_vivo"]);
        txt_nombre_beneficiarioS.Enabled = false;
        if (ddl_tipo_beneficio.SelectedValue == "72" || ddl_tipo_beneficio.SelectedValue == "73")
        {
            sc = "$('#block_datosBeneficiario').css('display', 'block');$('#block_mesAsignado').css('display', 'none'); $('#block_asigFamiliares').css('display', 'block');";
        }
        else
        {
            if (ddl_tipo_beneficio.SelectedValue == "40")
            {
                sc = "$('#block_datosBeneficiario').css('display', 'block');$('#block_mesAsignado').css('display', 'block'); $('#block_asigFamiliares').css('display', 'block');";

            }
            else
            {
                sc = "$('#block_datosBeneficiario').css('display', 'block');$('#block_mesAsignado').css('display', 'block'); $('#block_asigFamiliares').css('display', 'block');";
            }
        }
        SetScript(sc);
    }

    protected void btn_asigFamiliares_Click(object sender, EventArgs e)
    {
        if (ddl_tipo_beneficio.SelectedValue == "72" && aux_per_sexo.Value == "M")
        {
            sc = listarGrillaFamiliaresEsposa();
            SetScript(sc);
        }
        else
        {
            if (ddl_tipo_beneficio.SelectedValue == "40")
            {
                sc = sc + listarGrillaFamiliares();
            }
            else
            {
                sc = listarGrillaFamiliares();
            }
            SetScript(sc);
        }
    }

    private string habilitar()
    {
        string cadena = "";
        if (ddl_tipo_beneficio.SelectedValue == "72" || ddl_tipo_beneficio.SelectedValue == "73")
        {
            cadena = "$('#block_mesAsignado').css('display', 'none');$('#block_asigFamiliares').css('display', 'block');";
        }
        else
        {
            cadena = "$('#block_mesAsignado').css('display', 'block');$('#block_asigFamiliares').css('display', 'block');";
        }
        if (aux_pf_id.Value != "")
        {
            cadena = cadena + "$('#block_datosBeneficiario').css('display', 'block');";
        }
        else
        {
            if (ddl_tipo_beneficio.SelectedValue == "72" && aux_per_sexo.Value == "F")
            {
                cadena = "$('#block_datosBeneficiario').css('display', 'block');";
            }
            else
            {
                cadena = cadena + "$('#block_datosBeneficiario').css('display', 'none');";
            }
        }
        return cadena;
    }

    private string listarGrillaFamiliares()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            familiar = new cls_bs_asignacion_beneficio();
            familiar.pf_per_id = per_id;
            var familiaresX = familiar.ListarFamiliares();
            gv_familiares.DataKeyNames = new string[] { "pf_id" };
            gv_familiares.DataSource = familiaresX;
            gv_familiares.DataBind();

            if (familiaresX.Tables[0].Rows.Count > 0)
            {
                sc = "$('#block_gvFamiliares').css('display', 'block');";
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-check', message: 'El funcionario no tiene familiares registrados.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#block_gvFamiliares').css('display', 'none');";
            }
            sc = sc + habilitar();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
        return sc;
    }

    private string listarGrillaFamiliaresEsposa()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            familiar = new cls_bs_asignacion_beneficio();
            familiar.pf_per_id = per_id;
            var familiaresX = familiar.ListarFamiliarEsposa();
            gv_familiares.DataKeyNames = new string[] { "pf_id" };

            gv_familiares.DataSource = familiaresX;
            gv_familiares.DataBind();

            if (familiaresX.Tables[0].Rows.Count > 0)
            {
                sc = "$('#block_gvFamiliares').css('display', 'block');$('#block_mesAsignado').css('display', 'none');$('#block_asigFamiliares').css('display', 'block');";
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-check', message: 'El funcionario no tiene familiares registrados.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#block_gvFamiliares').css('display', 'none');";
            }

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
        return sc;
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
        if (ddl_tipo_beneficio.SelectedValue == "72")
        {
            sc = sc + listarGrillaFamiliaresEsposa();
        }
        else
        {
            if (ddl_tipo_beneficio.SelectedValue == "40")
            {
                sc = sc + listarGrillaFamiliares();
            }
            else
            {
                sc = sc + listarGrillaFamiliares();
            }
        }
        aux_pf_id.Value = "";
        sc = sc + habilitar();
        SetScript(sc);
    }

    protected void btn_cancelar_familiar_Click(object sender, EventArgs e)
    {
        sc = " $('#modalEditarFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        aux_pf_id.Value = "";
        if (ddl_tipo_beneficio.SelectedValue == "40")
        {
            sc = sc + habilitar();
        }
        else
        {
            sc = sc + habilitar();
        }
        SetScript(sc);
    }

    protected void ddl_estado_vivo_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (ddl_estado_vivo.SelectedValue)
        {
            case "V":
                sc = "$('#block_fechaDefuncion').css('display', 'none');";
                txt_fecha_defuncion.Text = string.Empty;
                SetScript(sc);
                break;
            case "D":
                sc = "$('#block_fechaDefuncion').css('display', 'block');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    protected string calcularTiempoMeses()
    {
        string tiempo = "";
        beneficio = new cls_bs_asignacion_beneficio
        {
            ab_fecha_inicio = txt_a_partir.Text,
            ab_fecha_fin = txt_hasta.Text
        };

        var detalleTiempoMes = beneficio.ObtenerTiempoMeses();
        if (detalleTiempoMes.Tables.Count > 0)
        {
            if (detalleTiempoMes.Tables[0].Rows.Count > 0)
            {
                var tiempoMes = detalleTiempoMes.Tables[0].Rows[0];
                tiempo = validarCampo(tiempoMes["meses"]);
            }
        }
        return tiempo;
    }

    protected void btn_asignar_beneficio_Click(object sender, EventArgs e)
    {
        string nroMeses = "";
        double nro = 0;
        beneficio = new cls_bs_asignacion_beneficio();
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pf_id = (aux_pf_id.Value != "") ? Convert.ToInt32(aux_pf_id.Value) : 0;
        string pf_estado_vivo = (ddl_tipo_beneficio.SelectedValue == "72" && aux_per_sexo.Value == "F") ? "V" : aux_pf_estado_vivo.Value;
        string fecha_inicio = txt_a_partir.Text;
        string fecha_fin = txt_hasta.Text;
        DateTime startDate = Convert.ToDateTime(txt_a_partir.Text);
        DateTime endDate = Convert.ToDateTime(txt_hasta.Text);
        double diferencia = (endDate - startDate).TotalDays + 1;
        if (diferencia > 0)
        {
            switch (ddl_tipo_beneficio.SelectedValue)
            {
                case "39":
                    if (pf_estado_vivo == "D")
                    {
                        var verificaSubsidioMes = beneficio.VerificarSubsidioenMes(Convert.ToString(pf_id), ddl_tipo_beneficio.SelectedValue, fecha_inicio, fecha_fin);
                        if (verificaSubsidioMes.Tables[0].Rows.Count > 0)
                        {
                            Limpiar();
                            sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar la acción, se realizó un registro anteriormente.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                            SetScript(sc);
                        }
                        else
                        {
                            aux_ab_aeb_id.Value = Convert.ToString(pf_id);
                            aux_ab_tipo_beneficiario.Value = "1";
                            sc = "$('#modalGlosa').modal('show');";
                            SetScript(sc);
                        }
                    }
                    else
                    {
                        Limpiar();
                        sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar esta acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                        SetScript(sc);
                    }
                    break;
                case "40":
                    if (pf_estado_vivo == "V")
                    {
                        var verificaSubsidioMes = beneficio.VerificarSubsidioenMes(Convert.ToString(pf_id), ddl_tipo_beneficio.SelectedValue, fecha_inicio, fecha_fin);
                        if (verificaSubsidioMes.Tables[0].Rows.Count > 0)
                        {
                            Limpiar();
                            sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar la acción, se realizó un registro anteriormente.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                            SetScript(sc);
                        }
                        else
                        {
                            aux_ab_aeb_id.Value = Convert.ToString(pf_id);
                            aux_ab_tipo_beneficiario.Value = "1";
                            sc = "$('#modalGlosa').modal('show');";
                            SetScript(sc);
                        }
                    }
                    else
                    {
                        Limpiar();
                        sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar esta acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                        SetScript(sc);
                    }
                    break;
                case "72":
                    nroMeses = (calcularTiempoMeses());
                    nro = (nroMeses != "") ? Convert.ToDouble(nroMeses) : 0;
                    if (nro <= 5)
                    {
                        if (pf_estado_vivo == "V")
                        {
                            if (aux_per_sexo.Value == "M")
                            {
                                var verificaSubsidioMes = beneficio.VerificarSubsidioenMes(Convert.ToString(pf_id), ddl_tipo_beneficio.SelectedValue, fecha_inicio, fecha_fin);
                                if (verificaSubsidioMes.Tables[0].Rows.Count > 0)
                                {
                                    Limpiar();
                                    sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar la acción, se realizó un registro anteriormente.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                                    SetScript(sc);
                                }
                                else
                                {
                                    aux_ab_aeb_id.Value = Convert.ToString(pf_id);
                                    aux_ab_tipo_beneficiario.Value = "1";
                                    sc = "$('#modalGlosa').modal('show');";
                                    SetScript(sc);
                                }
                            }
                            else
                            {
                                var verificaSubsidioMes = beneficio.VerificarSubsidioenMes(Convert.ToString(pf_id), ddl_tipo_beneficio.SelectedValue, fecha_inicio, fecha_fin);
                                if (verificaSubsidioMes.Tables[0].Rows.Count > 0)
                                {
                                    Limpiar();
                                    sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar la acción, se realizó un registro anteriormente.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                                    SetScript(sc);
                                }
                                else
                                {
                                    aux_ab_aeb_id.Value = Convert.ToString(per_id);
                                    aux_ab_tipo_beneficiario.Value = "2";
                                    sc = "$('#modalGlosa').modal('show');";
                                    SetScript(sc);
                                }
                            }
                        }
                        else
                        {
                            Limpiar();
                            sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar esta acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                            SetScript(sc);
                        }
                    }
                    else
                    {
                        Limpiar();
                        sc = "$.notify({ icon: 'fa fa-check', message: 'El número máximo de meses permitidos debe ser igual a 5.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                        SetScript(sc);
                    }
                    break;
                case "73":
                    nroMeses = (calcularTiempoMeses());
                    nro = (nroMeses != "") ? Convert.ToDouble(nroMeses) : 0;
                    if (nro <= 12)
                    {
                        if (pf_estado_vivo == "V")
                        {
                            var verificaSubsidioMes = beneficio.VerificarSubsidioenMes(Convert.ToString(pf_id), ddl_tipo_beneficio.SelectedValue, fecha_inicio, fecha_fin);
                            if (verificaSubsidioMes.Tables[0].Rows.Count > 0)
                            {
                                Limpiar();
                                sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar la acción, se realizó un registro anteriormente.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                                SetScript(sc);
                            }
                            else
                            {
                                aux_ab_aeb_id.Value = Convert.ToString(pf_id);
                                aux_ab_tipo_beneficiario.Value = "1";
                                sc = "$('#modalGlosa').modal('show');";
                                SetScript(sc);
                            }
                        }
                        else
                        {
                            Limpiar();
                            sc = "$.notify({ icon: 'fa fa-check', message: 'No se puede realizar esta acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                            SetScript(sc);
                        }
                    }
                    else
                    {
                        Limpiar();
                        sc = "$.notify({ icon: 'fa fa-check', message: 'El número máximo de meses permitidos debe ser igual a 12.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');";
                        SetScript(sc);
                    }
                    break;
                default:
                    break;
            }
        }
        else
        {
            Limpiar();
            sc = "$.notify({ icon: 'fa fa-check', message: 'El rango de fechas es incorrecto.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });$('#block_gvFamiliares').css('display', 'none');";
            SetScript(sc);
        }
    }

    protected void gv_asignacion_beneficios_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_asignacion_beneficios.Rows.Count > 0)
        {
            if (gv_asignacion_beneficios.HeaderRow != null)
            {
                gv_asignacion_beneficios.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_asignacion_beneficios.FooterRow != null)
            {
                gv_asignacion_beneficios.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_asignacion_beneficios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string ab_id = gv_asignacion_beneficios.DataKeys[index].Values[0].ToString();
        aux_ab_id.Value = ab_id;
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarAsignacionBeneficio').modal('show');";
                SetScript(sc);

                break;
            case "GetActiv":
                aux_accion.Value = "1";
                ltl_estado_ben.Text = "¿Está seguro de activar el subsidio? ";
                ObtenerBeneficio(Convert.ToInt32(ab_id));
                sc = "$('#cancelarSubsidio').modal('show');";
                SetScript(sc);

                break;
            case "GetCancel":
                aux_accion.Value = "0";
                ltl_estado_ben.Text = "¿Está seguro de cancelar el subsidio? ";
                ObtenerBeneficio(Convert.ToInt32(ab_id));
                sc = "$('#cancelarSubsidio').modal('show');";
                SetScript(sc);

                break;
            default:
                break;
        }
    }
    protected void ObtenerBeneficio(int ab_id = 0)
    {
        beneficio = new cls_bs_asignacion_beneficio();
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        beneficio.ab_id = ab_id;
        beneficio.pf_per_id = per_id;
        var detalleBeneficio = beneficio.ObtenerSubsidio();
        var beneficioX = detalleBeneficio.Tables[0].Rows[0];
        ltl_nombre_familiar.Text = validarCampo(beneficioX["pf_paterno"]) + " " + validarCampo(beneficioX["pf_materno"]) + " " + validarCampo(beneficioX["pf_nombres"]);
        ltl_parentesco.Text = validarCampo(beneficioX["pf_tipo_parentesco"]);
        ltl_nombre_beneficio.Text = validarCampo(beneficioX["fa_descripcion"]);
        ltl_a_partir.Text = validarCampo(beneficioX["ab_fecha_inicio"]);
        ltl_hasta.Text = validarCampo(beneficioX["ab_fecha_fin"]);
    }
    private void listarGrillaAsignacionBeneficio()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            familiar = new cls_bs_asignacion_beneficio();
            familiar.pf_per_id = per_id;
            var beneficiarios = familiar.ListarFamiliaresBeneficiarios();
            if (beneficiarios.Tables[0].Rows.Count > 0)
            {
                gv_asignacion_beneficios.DataSource = beneficiarios;
                this.block_familia.Visible = false;
            }
            else
            {
                this.block_familia.Visible = true;
            }
            gv_asignacion_beneficios.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void GuardarAsignacionBeneficiario()
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            ab_aeb_id = Convert.ToInt32(aux_ab_aeb_id.Value),
            ab_fa_id = Convert.ToInt32(ddl_tipo_beneficio.SelectedValue),
            ab_fecha_inicio = txt_a_partir.Text,
            ab_fecha_fin = txt_hasta.Text,
            ab_tipo_beneficiario = aux_ab_tipo_beneficiario.Value
        };
        beneficio.Adicionar();
    }

    protected void ddl_tipo_mesAsignado_SelectedIndexChanged(object sender, EventArgs e)
    {
        DateTime today = DateTime.Today;
        DateTime firstDayOfMonth = new DateTime(today.Year, Convert.ToInt32(ddl_tipo_mesAsignado.SelectedValue), 1);
        DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
        txt_a_partir.Text = firstDayOfMonth.ToString("dd/MM/yyyy");
        txt_hasta.Text = lastDayOfMonth.ToString("dd/MM/yyyy");
        if (ddl_tipo_beneficio.SelectedValue == "40")
        {
            sc = habilitar();
        }
        else
        {
            sc = habilitar();
        }
        SetScript(sc);
    }

    private void guardarGlosaAsignacion()
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;
        int idBeneficio = obtenerIdBeneficio();
        cargo = new cls_mp_cargo();
        cargo.gl_valor_pk = idBeneficio;
        cargo.gl_nombre_pk = "ab_id";
        cargo.gl_tabla = "tbl_bs_asignacion_beneficio";
        cargo.gl_tipo_mov = 813;
        cargo.gl_fecha_doc = fechaMov;
        cargo.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        cargo.gl_glosa = txt_descripcion_add.Text;
        cargo.gl_numero_doc = txt_num_doc.Text;
        cargo.gl_estado = "V";
        cargo.gl_usuario = Convert.ToInt32(Session["per_id"].ToString());
        cargo.AdicionarGlosa();
    }

    private int obtenerIdBeneficio()
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            ab_aeb_id = Convert.ToInt32(aux_ab_aeb_id.Value),
            ab_fa_id = Convert.ToInt32(ddl_tipo_beneficio.SelectedValue),
            ab_fecha_inicio = txt_a_partir.Text,
            ab_fecha_fin = txt_hasta.Text
        };

        var obtBeneficio = beneficio.obtenerIdBeneficio();

        int id_beneficio = 0;
        if (obtBeneficio.Tables[0].Rows[0]["ab_id"] != DBNull.Value && obtBeneficio.Tables[0].Rows[0]["ab_id"].ToString().Trim() != "")
        {
            id_beneficio = Convert.ToInt32(obtBeneficio.Tables[0].Rows[0]["ab_id"]);
        }
        return id_beneficio;
    }

    protected void Limpiar()
    {
        ddl_tipo_beneficio.SelectedValue = "0";
        ddl_tipo_mesAsignado.SelectedValue = "0";
        txt_a_partir.Text = string.Empty;
        txt_hasta.Text = string.Empty;
        txt_nombre_beneficiarioS.Text = string.Empty;
        aux_ab_aeb_id.Value = "";
        aux_ab_tipo_beneficiario.Value = "";
        aux_pf_id.Value = "";
        aux_pf_estado_vivo.Value = "";
        ddl_tipo_documento.SelectedValue = "0";
        txt_descripcion_add.Text = string.Empty;
    }

    protected void LimpiarFamiliar()
    {
        txt_paterno_add.Text = string.Empty;
        txt_materno_add.Text = string.Empty;
        txt_nombre_add.Text = string.Empty;
        txt_fecha_nac_add.Text = string.Empty;
        ddl_tipo_genero_add.SelectedValue = "0";
    }

    protected void btn_eliminar_asignacion_beneficio_Click(object sender, EventArgs e)
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            ab_id = Convert.ToInt32(aux_ab_id.Value)
        };
        beneficio.Eliminar();
        Limpiar();
        listarGrillaAsignacionBeneficio();
        gv_familiares.DataSource = null;
        gv_familiares.DataBind();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarAsignacionBeneficio').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#block_gvFamiliares').css('display', 'none');";
        SetScript(sc);
    }

    protected void btn_nuevo_familiar_Click(object sender, EventArgs e)
    {
        restablecerGlosa();
        sc = "$('#modalNuevoFamiliar').modal('show');";
        SetScript(sc);
    }

    protected void btn_adicionar_nuevoFamiliar_Click(object sender, EventArgs e)
    {
        if (((txt_paterno_add.Text.Trim() != null && txt_paterno_add.Text.Trim() != "" && txt_nombre_add.Text.Trim() != null && txt_nombre_add.Text.Trim() != "") || (txt_materno_add.Text.Trim() != null && txt_materno_add.Text.Trim() != "" && txt_nombre_add.Text.Trim() != null && txt_nombre_add.Text.Trim() != "")))
        {
            GuardarNuevoFamiliar();
            Limpiar();
            LimpiarFamiliar();
            sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Familiar añadido correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_mesAsignado').css('display', 'none'); $('#block_asigFamiliares').css('display', 'none'); $('#block_gvFamiliares').css('display', 'none'); $('#modalNuevoFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
            //sc = sc + listarGrillaFamiliares();
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
        sc = sc + habilitar();
        SetScript(sc);
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

    protected void llenarDatosAfiliacion(int per_id = 0, int as_id = 0)
    {
        beneficio = new cls_bs_asignacion_beneficio
        {
            as_id = as_id,
            pf_per_id = per_id
        };
        var detalleAfiliacion = beneficio.ObtenerAfiliacionX();
        var afiliacionX = detalleAfiliacion.Tables[0].Rows[0];
        ltl_nombre_egs.Text = validarCampo(afiliacionX["egs_descripcion"]);
        ltl_fecha_afiliacion.Text = validarCampo(afiliacionX["ae_fecha_form"]);
        ltl_estado_afiliacion.Text = validarCampo(afiliacionX["ae_estado"]);
        //txt_nr
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
                this.block_afiliacion.Visible = false;
            }
            else
            {
                this.block_afiliacion.Visible = true;
            }
            gv_afiliacion_familiares.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_cancelarSubsidio_Click(object sender, EventArgs e)
    {
        beneficio = new cls_bs_asignacion_beneficio();
        beneficio.ab_id = Convert.ToInt32(aux_ab_id.Value);
        if (aux_accion.Value == "1")
        {
            beneficio.ab_estado = "V";
            beneficio.CancelarSubsidio();
            sc = "Swal.fire({ icon: 'success', title: 'Activación exitosa', text: 'Subsidio activado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#cancelarSubsidio').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        }
        else
        {
            beneficio.ab_estado = "C";
            beneficio.CancelarSubsidio();
            sc = "Swal.fire({ icon: 'success', title: 'Cancelación exitosa', text: 'Subsidio cancelado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#cancelarSubsidio').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        }
        listarGrillaAsignacionBeneficio();
        SetScript(sc);
    }

    protected void btn_adicionar_glosa_Click(object sender, EventArgs e)
    {
        GuardarAsignacionBeneficiario();
        guardarGlosaAsignacion();
        Limpiar();
        listarGrillaAsignacionBeneficio();
        gv_familiares.DataSource = null;
        gv_familiares.DataBind();
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Asignación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#block_mesAsignado').css('display', 'none');$('#block_mesAsignado').css('display', 'none');$('#block_gvFamiliares').css('display', 'none');$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_cancelar_glosa_Click(object sender, EventArgs e)
    {
        sc = " $('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#block_gvFamiliares').css('display', 'none');";
        Limpiar();
        sc = sc + habilitar();
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
}