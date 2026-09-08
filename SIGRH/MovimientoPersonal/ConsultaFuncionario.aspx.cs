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
using Solution_Framework_Kardex.BussinessLogicLayer;


public partial class MovimientoPersonal_ConsultaFuncionario : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_pla_factor factor = null;
    private cls_bs_asignacion_beneficio familiar = null;
    private cls_kd_asignacion_vacaciones asig_vacaciones = null;
    private cls_kd_respuesta_combo respuesta = null;
    private cls_persona_familiares pfamiliar = null;

    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
            informacionSeguro(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
            listar_historicoAsignaciones();
            listar_filiacion();
            listar_familiares();
            listar_asignacionBeneficio();
            listar_diasVacacionDisp();
            listar_historicoVacaciones();
            listar_formacion();
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
                ltl_num_doc.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_fecha_nac.Text = validarCampo(funcionario["fecha_nac"]);
                ltl_estado_civil.Text = validarCampo(funcionario["per_estado_civil"]);
                ltl_genero.Text = validarCampo(funcionario["per_sexo_desc"]);
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
                ltl_pais.Text = validarCampo(funcionario["per_procedencia"]);
                ltl_localidad.Text = validarCampo(funcionario["perd_cuidad_residencia"]);
                ltl_zona.Text = validarCampo(funcionario["perd_zona"]);
                ltl_nombre_via.Text = validarCampo(funcionario["perd_descripcion_via"]);
                ltl_numero.Text = validarCampo(funcionario["perd_numero"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
                string haberBasico = validarCampo(funcionario["haber_basico"]);
                decimal haberBasico2 = Convert.ToDecimal(haberBasico);
                haberBasico2 = Math.Round(haberBasico2, 2);
                ltl_haber_basico.Text = Convert.ToString(haberBasico2);
                ltl_jornada.Text= validarCampo(funcionario["ca_tipo_jornada_lit"]);
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

    private void informacionSeguro(int per_id = 0, int as_id = 0)
    {
        familiar = new cls_bs_asignacion_beneficio();
        familiar.pf_per_id = per_id;
        familiar.as_id = as_id;
        var detalleAfiliacion = familiar.ObtenerAfiliacionX();
        if (detalleAfiliacion.Tables.Count > 0)
        {
            if (detalleAfiliacion.Tables[0].Rows.Count > 0)
            {
                var afiliacionX = detalleAfiliacion.Tables[0].Rows[0];
                ltl_caja_afiliado.Text = validarCampo(afiliacionX["egs_descripcion"]);
                ltl_fecha_afiliacion.Text = validarCampo(afiliacionX["ae_fecha_form"]);
                ltl_policlinico.Text = validarCampo(afiliacionX["policlinico_desc"]);
                ltl_numero_afiliado.Text = validarCampo(afiliacionX["matricula_cns"]);
                ltl_estado_afiliacion.Text = validarCampo(afiliacionX["ae_estado"]);
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

    protected void gv_historicoAsig_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_historicoAsig.Rows.Count > 0)
        {
            if (gv_historicoAsig.HeaderRow != null)
            {
                gv_historicoAsig.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_historicoAsig.FooterRow != null)
            {
                gv_historicoAsig.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void listar_historicoAsignaciones()
    {
        int id_fun = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = id_fun;
            var grillaHistorico = asig_vacaciones.OBTENERGRIDASGINACIONES(1);
            int tam = grillaHistorico.Tables[0].Rows.Count;
            block_HisAsignaciones.Visible = (tam > 0) ? false : true;
            gv_historicoAsig.DataSource = grillaHistorico;
            gv_historicoAsig.DataBind();

            var grillaHistorico2 = asig_vacaciones.OBTENERGRIDASGINACIONES(2);
            int tam2 = grillaHistorico2.Tables[0].Rows.Count;
            bloque_doc.Visible = (tam2 > 0) ? false : true;
            gv_doc.DataSource = grillaHistorico2;
            gv_doc.DataBind();

            var grillaHistorico3 = asig_vacaciones.OBTENERGRIDASGINACIONES(3);
            int tam3 = grillaHistorico3.Tables[0].Rows.Count;
            bloque_cons.Visible = (tam3 > 0) ? false : true;
            gv_cons.DataSource = grillaHistorico3;
            gv_cons.DataBind();

            int totalFilas = gv_historicoAsig.Rows.Count;
            litTotalFilas.Text = totalFilas.ToString();

            int totalFilas2 = gv_doc.Rows.Count;
            litfilasD.Text = totalFilas2.ToString();

            int totalFilas3 = gv_cons.Rows.Count;
            litfilasCon.Text = totalFilas3.ToString();

            //if (totalFilas > 0)
            //{
            //    Tab1.Attributes["class"] = "nav-link mb-sm-3 mb-md-0 active";
            //    Tab2.Attributes["class"] = "nav-link mb-sm-3 mb-md-0";
            //    Tab3.Attributes["class"] = "nav-link mb-sm-3 mb-md-0";

            //    Tab1.Attributes["aria-selected"] = "true";
            //    Tab2.Attributes["aria-selected"] = "false";
            //    Tab3.Attributes["aria-selected"] = "false";

            //    tabs1.Attributes["class"] = "tab-pane fade show active";
            //    tabs2.Attributes["class"] = "tab-pane fade";
            //    tabs3.Attributes["class"] = "tab-pane fade";
            //}
            //else
            //{
            //    if (totalFilas2 > 0)
            //    {
            //        Tab1.Attributes["class"] = "nav-link mb-sm-3 mb-md-0";
            //        Tab2.Attributes["class"] = "nav-link mb-sm-3 mb-md-0 active";
            //        Tab3.Attributes["class"] = "nav-link mb-sm-3 mb-md-0";

            //        Tab1.Attributes["aria-selected"] = "false";
            //        Tab2.Attributes["aria-selected"] = "true";
            //        Tab3.Attributes["aria-selected"] = "false";

            //        tabs1.Attributes["class"] = "tab-pane fade";
            //        tabs2.Attributes["class"] = "tab-pane fade show active";
            //        tabs3.Attributes["class"] = "tab-pane fade";
            //    }
            //    else
            //    {
            //        Tab1.Attributes["class"] = "nav-link mb-sm-3 mb-md-0";
            //        Tab2.Attributes["class"] = "nav-link mb-sm-3 mb-md-0";
            //        Tab3.Attributes["class"] = "nav-link mb-sm-3 mb-md-0 active";

            //        Tab1.Attributes["aria-selected"] = "false";
            //        Tab2.Attributes["aria-selected"] = "false";
            //        Tab3.Attributes["aria-selected"] = "true";

            //        tabs1.Attributes["class"] = "tab-pane fade";
            //        tabs2.Attributes["class"] = "tab-pane fade";
            //        tabs3.Attributes["class"] = "tab-pane fade show active";
            //    }
            //}
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void gv_filiacion_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_filiacion.Rows.Count > 0)
        {
            if (gv_filiacion.HeaderRow != null)
            {
                gv_filiacion.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_filiacion.FooterRow != null)
            {
                gv_filiacion.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void listar_filiacion()
    {
        int id_fun = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            respuesta = new cls_kd_respuesta_combo();
            respuesta.rp_valor_pk = Convert.ToInt32(id_fun);
            respuesta.rp_nombre_pk = "per_id";
            var grillaFiliacion = respuesta.RequisitosPresentadosFun();
            if (grillaFiliacion.Tables[0].Rows.Count > 0)
            {
                gv_filiacion.DataSource = grillaFiliacion;
                gv_filiacion.DataBind();
            }
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
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

    protected void listar_familiares()
    {
        int id_fun = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            pfamiliar = new cls_persona_familiares();
            pfamiliar.pf_per_id = Convert.ToInt32(id_fun);
            var familiaresX = pfamiliar.ObtenerGrillaFamiliares();
            int tam = familiaresX.Tables[0].Rows.Count;
            block_familia.Visible = (tam > 0) ? false : true;
            gv_familiares.DataSource = familiaresX;
            gv_familiares.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
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

    private void listar_asignacionBeneficio()
    {
        int per_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            familiar = new cls_bs_asignacion_beneficio();
            familiar.pf_per_id = per_id;
            var beneficiarios = familiar.ListarFamiliaresBeneficiarios();
            int tam = beneficiarios.Tables[0].Rows.Count;
            block_beneficios.Visible = (tam > 0) ? false : true;
            gv_asignacion_beneficios.DataSource = beneficiarios;
            gv_asignacion_beneficios.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_dias_vacacion_disp_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_dias_vacacion_disp.Rows.Count > 0)
        {
            if (gv_dias_vacacion_disp.HeaderRow != null)
            {
                gv_dias_vacacion_disp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_dias_vacacion_disp.FooterRow != null)
            {
                gv_dias_vacacion_disp.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void listar_diasVacacionDisp()
    {
        int id_fun = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = Convert.ToInt32(id_fun);
            var grillaAsignacionV = asig_vacaciones.obtenerHistoricoAsigVacaciones();
            int tam = grillaAsignacionV.Tables[0].Rows.Count;
            block_asigVacaciones.Visible = (tam > 0) ? false : true;
            gv_dias_vacacion_disp.DataSource = grillaAsignacionV;
            gv_dias_vacacion_disp.DataBind();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void gv_Hvacaciones_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_Hvacaciones.Rows.Count > 0)
        {
            if (gv_Hvacaciones.HeaderRow != null)
            {
                gv_Hvacaciones.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_Hvacaciones.FooterRow != null)
            {
                gv_Hvacaciones.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void listar_historicoVacaciones()
    {
        int id_fun = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = Convert.ToInt32(id_fun);
            var grillaHvacaciones = asig_vacaciones.obtenerGrillaHistoricoVacaciones();
            int tam = grillaHvacaciones.Tables[0].Rows.Count;
            block_vacacionAnual.Visible = (tam > 0) ? false : true;
            gv_Hvacaciones.DataSource = grillaHvacaciones;
            gv_Hvacaciones.DataBind();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void gv_educacion_formal_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_educacion_formal.Rows.Count > 0)
        {
            if (gv_educacion_formal.HeaderRow != null)
            {
                gv_educacion_formal.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_educacion_formal.FooterRow != null)
            {
                gv_educacion_formal.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    private void listar_formacion()
    {
        int id_fun = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        try
        {
            respuesta = new cls_kd_respuesta_combo();
            respuesta.rp_valor_pk = Convert.ToInt32(id_fun);
            var eduacion_formal = respuesta.ObtenerGrillaEducFormal();
            int tam = eduacion_formal.Tables[0].Rows.Count;
            block_formacion.Visible = (tam > 0) ? false : true;
            gv_educacion_formal.DataSource = eduacion_formal;
            gv_educacion_formal.DataBind();
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }

    protected void gv_doc_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_doc.Rows.Count > 0)
        {
            if (gv_doc.HeaderRow != null)
            {
                gv_doc.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_doc.FooterRow != null)
            {
                gv_doc.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_cons_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_cons.Rows.Count > 0)
        {
            if (gv_cons.HeaderRow != null)
            {
                gv_cons.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_cons.FooterRow != null)
            {
                gv_cons.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}