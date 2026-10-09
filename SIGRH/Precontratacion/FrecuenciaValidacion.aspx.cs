using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_Precontratacion.BussinessLogicLayer;
using System.Text;
using System.Data;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;

public partial class Precontratacion_FrecuenciaValidacion : System.Web.UI.Page
{
    private cls_pc_frecuencia frecuencia = null;
    private cls_pc_precontratado precontratado = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
                int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
                int cod_pa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
                informacionCategoria(cp_id);
                listarFrecuencias(cod_pa, pr_id);
                listarResumenFrecuencias(cod_pa, pr_id);
                listarResumenPresup(cod_pa);
                listarResumenPresupGral();
                ver_estado(cod_pa);
                SetScriptInicio("$('.table').DataTable().destroy(); ");
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }
    protected void ver_estado(int cp_id = 0)
    {
        frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id };
        var detalleEstado = frecuencia.VerEstadoCategoria();

        btn_reprobar.Visible = false;
        btn_aprobar.Visible = false;
        btn_reprobar.Enabled = false;
        btn_aprobar.Enabled = false;
        string estado_fr = "";
        if (detalleEstado.Tables.Count > 0)
        {
            if (detalleEstado.Tables[0].Rows.Count > 0)
            {
                var estado = detalleEstado.Tables[0].Rows[0];
                estado_fr = validarCampo(estado["seg_accion"]);
            }
        }
        if (estado_fr != "")
        {
            if (estado_fr == "ENVIADO")
            {
                btn_reprobar.CssClass = "btn btn-google-plus btn-round btn-icon";
                btn_reprobar.Visible = true;
                btn_reprobar.Enabled = true;
                btn_aprobar.CssClass = "btn btn-slack btn-round btn-icon";
                btn_aprobar.Visible = true;
                btn_aprobar.Enabled = true;
            }
            if (estado_fr == "VALIDADO")
            {
                btn_reprobar.Visible = false;
                btn_aprobar.Enabled = false;
                btn_aprobar.CssClass = "btn btn-slack btn-round btn-icon disabled";
                btn_aprobar.Text = "<span class='btn-inner--icon'><i class='fas fa-check'></i></span><span class='btn-inner--text'>Validado</span>";
                btn_aprobar.Visible = true;
            }
            if (estado_fr == "OBSERVADO")
            {
                btn_aprobar.Visible = false;
                btn_reprobar.Enabled = false;
                btn_reprobar.CssClass = "btn btn-google-plus btn-round btn-icon disabled";
                btn_reprobar.Text = "<span class='btn-inner--icon'><i class='fas fa-eye'></i></span><span class='btn-inner--text'>Observado</span>";
                btn_reprobar.Visible = true;
            }
        }
        else
        {
            btn_reprobar.Visible = false;
            btn_aprobar.Visible = false;
        }
    }
    protected void gv_frecuencias_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_frecuencias.Rows.Count > 0)
        {
            if (gv_frecuencias.HeaderRow != null)
            {
                gv_frecuencias.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_frecuencias.FooterRow != null)
            {
                gv_frecuencias.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    private void listarFrecuencias(int cod_pa = 0, int pr_id = 0, int fr_es_id = 0, decimal fr_tiempo = -1, string fr_estado = "L")
    {
        try
        {
            frecuencia = new cls_pc_frecuencia { fr_cod_poa = cod_pa, fr_pr_id = pr_id, fr_es_id = fr_es_id, fr_tiempo = fr_tiempo, fr_estado = fr_estado };
            gv_frecuencias.DataSource = frecuencia.ObtenerFrecuenciasOperacion();
            gv_frecuencias.DataBind();

            d_gv_frecuencias.Visible = (gv_frecuencias.Rows.Count > 0) ? false : true;

            foreach (GridViewRow row in gv_frecuencias.Rows)
            {
                Label lblName = (Label)row.FindControl("lbl_gv_frec_estado");
                string estado = lblName.Text;
                if (estado != "LIBRE" && estado != "OCUPADO")
                {
                    row.CssClass = "grid-row-disabled";
                }
            }

            listaFiltradoFrec(cod_pa, pr_id, fr_es_id, fr_tiempo, "L", "C37", "ddl_gv_frec_cargo", "es_id", "es_descripcion", "ES.es_descripcion, ES.es_id");
            listaFiltradoFrec(cod_pa, pr_id, fr_es_id, fr_tiempo, "L", "C37", "ddl_gv_frec_tiempo", "fr_tiempo", "fr_tiempo", "F.fr_tiempo");
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaFiltradoFrec(int cod_pa = 0, int pr_id = 0, int fr_es_id = 0, decimal fr_tiempo = -1, string fr_estado = "L", string accion = "", string ddl_id = "", string ddl_value = "", string ddl_desc = "", string q = "")
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cod_poa = cod_pa;
            frecuencia.fr_pr_id = pr_id;
            frecuencia.fr_es_id = fr_es_id;
            frecuencia.fr_tiempo = fr_tiempo;
            frecuencia.fr_estado = fr_estado;
            frecuencia.accion = accion;

            DropDownList ddl = gv_frecuencias.HeaderRow.FindControl(ddl_id) as DropDownList;
            ddl.Items.Clear();
            ddl.Items.Insert(0, new ListItem("TODOS", "-1"));
            ddl.DataValueField = ddl_value;
            ddl.DataTextField = ddl_desc;
            ddl.DataSource = frecuencia.ObtenerListaFiltradoFrecuenciaOperacion(q);
            ddl.DataBind();

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
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': true, 'info': true });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_jornada').select2({ dropdownParent: $('#modalNuevaFrec') });");
        sb.Append("$('#ContentPlaceHolder1_ddl_cargo').select2({ dropdownParent: $('#modalNuevaFrec'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto').select2({ dropdownParent: $('#modalNuevaFrec'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
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
        sb.Append("$('.table').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });");

        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': true, 'info': true });");

        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_jornada').select2({ dropdownParent: $('#modalNuevaFrec') });");
        sb.Append("$('#ContentPlaceHolder1_ddl_cargo').select2({ dropdownParent: $('#modalNuevaFrec'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_puesto').select2({ dropdownParent: $('#modalNuevaFrec'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_usuarios').select2({ dropdownParent: $('#modalEnviar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
    private void listarResumenFrecuencias(int cod_pa = 0, int pr_id = 0)
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cod_poa = cod_pa;
            frecuencia.fr_pr_id = pr_id;
            var frecuencias_resumen = frecuencia.ObtenerResumenFrecuenciasOperacion();
            gv_fracuencias_resumen.DataSource = frecuencias_resumen;
            gv_fracuencias_resumen.DataBind();

            d_gv_fracuencias_resumen.Visible = (frecuencias_resumen.Tables[0].Rows.Count > 0) ? false : true;
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void gv_fracuencias_resumen_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_fracuencias_resumen.Rows.Count > 0)
        {
            if (gv_fracuencias_resumen.HeaderRow != null)
            {
                gv_fracuencias_resumen.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_fracuencias_resumen.FooterRow != null)
            {
                gv_fracuencias_resumen.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_resumen_presup_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_resumen_presup.Rows.Count > 0)
        {
            if (gv_resumen_presup.HeaderRow != null)
            {
                gv_resumen_presup.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_resumen_presup.FooterRow != null)
            {
                gv_resumen_presup.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    private void listarResumenPresup(int cod_pa = 0)
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cod_poa = cod_pa;
            gv_resumen_presup.DataSource = frecuencia.ObtenerComprometidoPorOperacion();
            gv_resumen_presup.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private DataTable construirResumenGralPost()
    {
        DataTable resumen_gral = null;
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;

        frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id, fr_pr_id = pr_id };
        var detalle_categorias = frecuencia.ObtenerCategoriasPresup();
        if (detalle_categorias.Tables[0].Rows.Count > 0)
        {
            var categoria = detalle_categorias.Tables[0].Rows;
            DataTable presup_operaciones_total = new DataTable();
            presup_operaciones_total.Columns.Add("pp_cp_id");
            presup_operaciones_total.Columns.Add("pp_partida");
            presup_operaciones_total.Columns.Add("monto");
            presup_operaciones_total.Columns.Add("comprometido");
            presup_operaciones_total.Columns.Add("saldo");
            DataRow dr = null;

            for (int i = 0; i < categoria.Count; i++)
            {
                frecuencia.fr_cp_id = Convert.ToInt32(validarCampo(categoria[i]["cp_id"]));
                var detalle_presupuesto_operacion = frecuencia.ObtenerResumenPresup();
                if (detalle_presupuesto_operacion.Tables[0].Rows.Count > 0)
                {
                    var presupuesto_operacion = detalle_presupuesto_operacion.Tables[0].Rows;
                    string json = JsonConvert.SerializeObject(detalle_presupuesto_operacion);

                    for (int j = 0; j < presupuesto_operacion.Count; j++)
                    {
                        dr = presup_operaciones_total.NewRow();
                        dr["pp_cp_id"] = presupuesto_operacion[j]["pp_cp_id"];
                        dr["pp_partida"] = presupuesto_operacion[j]["pp_partida"];
                        dr["monto"] = presupuesto_operacion[j]["monto"];
                        dr["comprometido"] = presupuesto_operacion[j]["comprometido"];
                        dr["saldo"] = presupuesto_operacion[j]["saldo"];
                        presup_operaciones_total.Rows.Add(dr);
                    }
                }
            }
            resumen_gral = operacionesResumenPost(presup_operaciones_total);
        }
        return resumen_gral;
    }
    protected DataTable operacionesResumenPost(DataTable pDato = null)
    {
        DataTable presup_gral = new DataTable();
        presup_gral.Columns.Add("pp_partida");
        presup_gral.Columns.Add("monto");
        presup_gral.Columns.Add("comprometido");
        presup_gral.Columns.Add("saldo");
        DataRow dr = null;

        for (int i = 0; i < 5; i++)
        {
            int partida_x = Convert.ToInt32(validarCampo(pDato.Rows[i]["pp_partida"]));
            double sum_monto = 0;
            int sum_comprometido = 0;
            for (int j = 0; j < pDato.Rows.Count; j++)
            {
                int partida = Convert.ToInt32(validarCampo(pDato.Rows[j]["pp_partida"]));
                double monto = Convert.ToDouble(validarCampo(pDato.Rows[j]["monto"]));
                int comprometido = Convert.ToInt32(validarCampo(pDato.Rows[j]["comprometido"]));

                if (partida_x == partida)
                {
                    sum_monto = sum_monto + monto;
                    sum_comprometido = sum_comprometido + comprometido;
                }
            }
            dr = presup_gral.NewRow();
            dr["pp_partida"] = partida_x + "";
            dr["monto"] = sum_monto;
            dr["comprometido"] = sum_comprometido;
            dr["saldo"] = sum_monto - sum_comprometido;
            presup_gral.Rows.Add(dr);
        }
        double monto_total = 0;
        int comprometido_total = 0;
        double saldo_total = 0;
        for (int i = 0; i < presup_gral.Rows.Count; i++)
        {
            double monto = Convert.ToDouble(validarCampo(presup_gral.Rows[i]["monto"]));
            int comprometido = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["comprometido"]));
            double saldo = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["saldo"]));
            monto_total = monto_total + monto;
            comprometido_total = comprometido_total + comprometido;
            saldo_total = saldo_total + saldo;
        }
        dr = presup_gral.NewRow();
        dr["pp_partida"] = "TOTAL";
        dr["monto"] = monto_total;
        dr["comprometido"] = comprometido_total;
        dr["saldo"] = saldo_total;
        presup_gral.Rows.Add(dr);
        return presup_gral;
    }

    private void listarResumenPresupGral()
    {
        try
        {
            gv_resumen_presup_gral.DataSource = construirResumenGral();
            gv_resumen_presup_gral.DataBind();

            foreach (GridViewRow row in gv_resumen_presup_gral.Rows)
            {
                for (int i = 0; i < gv_resumen_presup_gral.Columns.Count; i++)
                {
                    if (i == 0)
                    {
                        string partida = row.Cells[i].Text;
                        if (partida == "COMPROMETIDO" || partida == "PRESUPUESTO" || partida == "SALDO")
                        {
                            row.CssClass = "grid-row-water ";
                        }
                        break;
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected DataTable construirResumenGral()
    {
        DataTable resumen_gral = null;
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;

        frecuencia = new cls_pc_frecuencia
        {
            fr_cp_id = cp_id
        };
        resumen_gral = frecuencia.ObtenerResumenGral().Tables[0];

        return resumen_gral;
    }
    protected DataTable operacionesResumen(DataTable pDato = null, DataTable presupuesto = null)
    {
        DataTable presup_gral = new DataTable();
        presup_gral.Columns.Add("pp_partida");
        presup_gral.Columns.Add("monto");
        presup_gral.Columns.Add("comprometido");
        presup_gral.Columns.Add("saldo");
        DataRow dr = null;

        for (int i = 0; i < presupuesto.Rows.Count; i++)
        {
            int partida_x = Convert.ToInt32(validarCampo(presupuesto.Rows[i]["pp_partida"]));
            double monto = Convert.ToDouble(validarCampo(presupuesto.Rows[i]["pp_monto"]));
            double sum_comprometido = 0;
            for (int j = 0; j < pDato.Rows.Count; j++)
            {
                int partida = Convert.ToInt32(validarCampo(pDato.Rows[j]["partida"]));
                double comprometido = Convert.ToInt32(validarCampo(pDato.Rows[j]["comprometido"]));

                if (partida_x == partida)
                {
                    sum_comprometido = sum_comprometido + comprometido;
                }
            }
            dr = presup_gral.NewRow();
            dr["pp_partida"] = partida_x + "";
            dr["monto"] = monto;
            dr["comprometido"] = sum_comprometido;
            dr["saldo"] = monto - sum_comprometido;
            presup_gral.Rows.Add(dr);
        }
        double monto_total = 0;
        int comprometido_total = 0;
        double saldo_total = 0;
        for (int i = 0; i < presup_gral.Rows.Count; i++)
        {
            double monto = Convert.ToDouble(validarCampo(presup_gral.Rows[i]["monto"]));
            int comprometido = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["comprometido"]));
            double saldo = Convert.ToInt32(validarCampo(presup_gral.Rows[i]["saldo"]));
            monto_total = monto_total + monto;
            comprometido_total = comprometido_total + comprometido;
            saldo_total = saldo_total + saldo;
        }
        dr = presup_gral.NewRow();
        dr["pp_partida"] = "TOTAL";
        dr["monto"] = monto_total;
        dr["comprometido"] = comprometido_total;
        dr["saldo"] = saldo_total;
        presup_gral.Rows.Add(dr);

        return presup_gral;
    }
    protected DataTable formatearTabla(DataTable pDato = null)
    {
        DataTable presup_gral = new DataTable();
        presup_gral.Columns.Add("pp_partida");
        presup_gral.Columns.Add("monto");
        presup_gral.Columns.Add("comprometido");
        presup_gral.Columns.Add("saldo");
        DataRow dr_partida_copia = null;

        foreach (DataRow dr_partida in pDato.Rows)
        {
            dr_partida_copia = presup_gral.NewRow();
            double monto_final = Convert.ToDouble(validarCampo(dr_partida["monto"]));
            double comprometido_final = Convert.ToDouble(validarCampo(dr_partida["comprometido"]));
            double saldo_final = Convert.ToDouble(validarCampo(dr_partida["saldo"]));
            dr_partida_copia["pp_partida"] = dr_partida["pp_partida"];
            dr_partida_copia["monto"] = String.Format("{0:N2}", monto_final);
            dr_partida_copia["comprometido"] = String.Format("{0:N2}", comprometido_final);
            dr_partida_copia["saldo"] = String.Format("{0:N2}", saldo_final);
            presup_gral.Rows.Add(dr_partida_copia);
        }
        return presup_gral;
    }

    private void informacionCategoria(int cp_id = 0)
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_cp_id = cp_id;
        var detalleCategoria = frecuencia.ObtenerInformacionCategoria();
        if (detalleCategoria.Tables.Count > 0)
        {
            if (detalleCategoria.Tables[0].Rows.Count > 0)
            {
                var categoria = detalleCategoria.Tables[0].Rows[0];
                ltl_da.Text = validarCampo(categoria["cp_da"]);
                ltl_ue.Text = validarCampo(categoria["cp_ue"]);

                ltl_fuente.Text = validarCampo(categoria["cp_fuente"]);
                ltl_org.Text = validarCampo(categoria["cp_organismo"]);
                ltl_desc.Text = validarCampo(listarOperaciones().Rows[0]["desc_poa"]);
            }
        }
    }
    protected DataTable listarOperaciones()
    {
        int cod_pa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        frecuencia = new cls_pc_frecuencia
        {
            perm_us_id = Convert.ToInt32(Session["us_id"].ToString()),
            fr_pr_id = Convert.ToInt32(Session["pr_id"].ToString()),
        };
        var detalle_persmiso = frecuencia.ObtenerPermisosUE();

        string param = "";
        if (detalle_persmiso.Tables[0].Rows.Count > 0)
        {
            var permisos = detalle_persmiso.Tables[0].Rows;

            for (int i = 0; i < permisos.Count; i++)
            {
                string pcp_ue = validarCampo(permisos[i]["pcp_ue"]);
                param = param + ", '" + pcp_ue + "'";
            }
            param = param.Substring(1, param.Length - 1);
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CnxSimV2"].ConnectionString);
        string q = "SELECT TOP 1 desc_cod_da, nombre_da, desc_cod_ue, nombre_ue, cod_poa, cod_programa, cod_proyecto, cod_actividad, desc_poa, gestion, cod_ue, Expr1, descrip_estado, cod_estado " +
        "FROM[SIMv2].[dbo].[vw_sigrh_sim_operaciones] SO WHERE SO.gestion = @gestion AND SO.cod_poa = @cod_poa";
        SqlCommand command = new SqlCommand(q, connection);

        command.Parameters.Add(new SqlParameter("@gestion", SqlDbType.VarChar, 40)).Value = Session["gestion"].ToString();
        command.Parameters.Add(new SqlParameter("@cod_poa", SqlDbType.VarChar, 40)).Value = cod_pa;
        connection.Open();

        DbDataReader reader = command.ExecuteReader();
        var detalle_operaciones = new DataTable();
        detalle_operaciones.Load(reader);

        return detalle_operaciones;
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

    protected void ddl_gv_frec_cargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cp_ip = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        DropDownList ddl_gv_frec_cargo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;
        DropDownList ddl_gv_frec_tiempo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_tiempo") as DropDownList;

        int fr_es_id = (ddl_gv_frec_cargo.SelectedValue != "-1") ? Convert.ToInt32(ddl_gv_frec_cargo.SelectedValue) : 0;
        decimal fr_tiempo = (ddl_gv_frec_tiempo.SelectedValue != "-1") ? Convert.ToDecimal(ddl_gv_frec_tiempo.SelectedValue) : -1;

        string fr_es_id_v = (ddl_gv_frec_cargo.SelectedValue != "-1") ? ddl_gv_frec_cargo.SelectedValue : "-1";
        string fr_tiempo_v = (ddl_gv_frec_tiempo.SelectedValue != "-1") ? ddl_gv_frec_tiempo.SelectedValue : "-1";

        listarFrecuencias(cod_poa, pr_id, fr_es_id, fr_tiempo, "L");

        DropDownList ddl_gv_frec_cargo_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;
        DropDownList ddl_gv_frec_tiempo_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_tiempo") as DropDownList;
        ddl_gv_frec_cargo_after.SelectedValue = fr_es_id_v;
        ddl_gv_frec_tiempo_after.SelectedValue = fr_tiempo_v;
        SetScript("");
    }

    protected void btn_cancelar_envio_Click(object sender, EventArgs e)
    {
        sc = "$('#modalEnviar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_imprimir_Click(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void btn_aprobar_Click(object sender, EventArgs e)
    {
        if (gv_frecuencias.Rows.Count > 0)
        {
            sc = "$('#modalConfirmacionA').modal('show');";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }
    protected void btn_confirmar_aprob_Click(object sender, EventArgs e)
    {
        if (gv_frecuencias.Rows.Count > 0)
        {
            int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
            int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
            int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
            string correo_remitente = (Session["correo"] != null) ? Session["correo"].ToString() : "";
            string usuario_remitente = (Session["per_nombres"] != null) ? Session["per_nombres"].ToString() : "";

            string usuario_recepcion = "";
            string correo_recepcion = "";
            int us_id_recep = 0;

            frecuencia = new cls_pc_frecuencia { fr_cp_id = cod_poa };
            var estados = frecuencia.VerEstadoCategoria();

            if (estados.Tables.Count > 0)
            {
                if (estados.Tables[0].Rows.Count > 0)
                {
                    var seguimiento = estados.Tables[0].Rows;
                    if (validarCampo(seguimiento[0]["seg_accion"]) == "ENVIADO")
                    {
                        us_id_recep = (validarCampo(seguimiento[0]["seg_us_id_remitente"]) != "") ? Convert.ToInt32(validarCampo(seguimiento[0]["seg_us_id_remitente"])) : 0;
                        usuario_recepcion = validarCampo(seguimiento[0]["remitente"]);
                        correo_recepcion = validarCampo(seguimiento[0]["correo_remitente"]);
                    }
                }
            }
            if (us_id_recep != 0)
            {
                precontratado = new cls_pc_precontratado();

                precontratado.seg_pk_id = cod_poa;
                precontratado.seg_us_id_remitente = us_id;
                precontratado.seg_us_id_recepcion = 0;
                precontratado.seg_accion = "VALIDADO";
                precontratado.seg_observaciones = null;
                precontratado.seg_tabla = "tbl_pc_frecuencias";
                precontratado.AdicionarSeguimiento();

                string asunto = "LAS FRECUENCIAS DE LA OPERACIÓN CON CÓDIGO DE POA  " + cod_poa + " FUERON VALIDADAS";
                string contenido = "<p>Se le comunica que las frecuencias de <strong>DA: " + ltl_da.Text + ", UE: " + ltl_ue.Text + ", COD. POA:" + cod_poa + "</strong> fueron validadas con éxito.</p>";
                enviarCorreo(correo_remitente, correo_recepcion, usuario_remitente, usuario_recepcion, contenido, asunto);

                Session["texto_notificacion"] = "Frecuencias validadas correctamente.";
                Response.Redirect("ListaFrecuenciaValidacion");
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }
    protected void btn_reprobar_Click(object sender, EventArgs e)
    {
        txt_observaciones.Text = string.Empty;

        if (gv_frecuencias.Rows.Count > 0)
        {
            sc = "$('#modalConformarR').modal('show');";
            SetScript(sc);
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    protected void btn_confirmar_rep_Click(object sender, EventArgs e)
    {
        if (gv_frecuencias.Rows.Count > 0)
        {
            int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
            int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
            int us_id = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0;
            string correo_remitente = (Session["correo"] != null) ? Session["correo"].ToString() : "";
            string usuario_remitente = (Session["per_nombres"] != null) ? Session["per_nombres"].ToString() : "";

            string usuario_recepcion = "";
            string correo_recepcion = "";
            int us_id_recep = 0;

            frecuencia = new cls_pc_frecuencia { fr_cp_id = cod_poa };
            var estados = frecuencia.VerEstadoCategoria();

            if (estados.Tables.Count > 0)
            {
                if (estados.Tables[0].Rows.Count > 0)
                {
                    var seguimiento = estados.Tables[0].Rows;
                    if (validarCampo(seguimiento[0]["seg_accion"]) == "ENVIADO")
                    {
                        us_id_recep = (validarCampo(seguimiento[0]["seg_us_id_remitente"]) != "") ? Convert.ToInt32(validarCampo(seguimiento[0]["seg_us_id_remitente"])) : 0;
                        usuario_recepcion = validarCampo(seguimiento[0]["remitente"]);
                        correo_recepcion = validarCampo(seguimiento[0]["correo_remitente"]);
                    }
                }
            }

            if (us_id_recep != 0)
            {
                precontratado = new cls_pc_precontratado();

                precontratado.seg_pk_id = cod_poa;
                precontratado.seg_us_id_remitente = us_id;
                precontratado.seg_us_id_recepcion = Convert.ToInt32(us_id_recep);
                precontratado.seg_accion = "OBSERVADO";
                precontratado.seg_observaciones = txt_observaciones.Text.Trim();
                precontratado.seg_tabla = "tbl_pc_frecuencias";
                precontratado.AdicionarSeguimiento();

                string asunto = "SOLICITUD DE REVISIÓN DE FRECUENCIAS DEL CÓDIGO POA:  " + cod_poa;
                string contenido = "<p>Se le comunica que se observó las frecuencias del <strong>Código POA " + cod_poa + "</strong>, por el usuario <strong>" + usuario_remitente + "</strong> para su corrección con las siguientes observaciones:</p><p>" + txt_observaciones.Text.ToUpper().Trim() + "</p>";
                enviarCorreo(correo_remitente, correo_recepcion, usuario_remitente, usuario_recepcion, contenido, asunto);

                Session["texto_notificacion"] = "Las frecuencias han sido observadas";
                Response.Redirect("ListaFrecuenciaValidacion");
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }
    private void enviarCorreo(string correo_remitente = "", string correo_recepcion = "", string usuario_remitente = "", string usuario_recepcion = "", string contenido = "", string asunto = "")
    {
        string h = "http://gmlpsr00001/sigrh3/";
        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();
        correo.From = new System.Net.Mail.MailAddress(correo_remitente);
        correo.To.Add(correo_recepcion);
        correo.Subject = asunto;
        string html;

        html = "  <!doctype html><html> <body><div style='font: 20px Calibri, arial; margin-bottom: 30px; border: 0; box-shadow: 0 0 32px 0 rgba(136, 152, 170, .15); '>";
        html += "<div style='margin-bottom: 16px; padding-top: 20px; padding-bottom: 20px; background-color: #fff;' align='right'>";
        html += "<img src='cid:imagen' style='width: 70; display: block; margin-left: auto; border-radius: 7% !important;' /> ";
        html += "</div>";
        html += "<div class='card-body' style='min-height: 1px; padding: 24px; flex: 1 1 auto; text-align: justify;' >";
        html += "<div style='padding-bottom: 20px; margin-bottom: 32px' align='center'>";
        html += "<img src='cid:imagen2' style='width: 70; display: block; margin-right: auto; margin-left: auto; border-radius: 50% !important;'  /> ";
        html += "</div>";
        html += "Estimado usuario: <strong>" + usuario_recepcion + "</strong>";
        html += contenido;
        html += "<p>Por lo que se le solicita hacer clic en el siguiente enlace.</p>";
        html += "<div style='text-align: center;'>";
        html += "<a href= '" + h + "' target='_blank'><img src='cid:imagen3' style='width: 70; display: block; margin-right: auto; margin-left: auto; border-radius: 50% !important;'  /> </a> ";
        html += "<p style='margin-top: 32px; font-size: 14px; text-align: right;'> Este mensaje es generado automáticamente por el SISTEMA INTEGRADO DE GESTIÓN DE RECURSOS HUMANOS </p> ";
        html += "<p style='margin-top: 8px; font-size: 14px; text-align: right; color: #adb5bd;'> DIRECCIÓN DE GESTIÓN DE RECURSOS HUMANOS</p> ";
        html += "</div></div></div>  </body></html>";
        System.Net.Mail.AlternateView htmlView = System.Net.Mail.AlternateView.CreateAlternateViewFromString(html, System.Text.Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Html);
        System.Net.Mail.LinkedResource img = new System.Net.Mail.LinkedResource(Server.MapPath("../Content/img/brand/logo_lp2.png"));
        System.Net.Mail.LinkedResource img2 = new System.Net.Mail.LinkedResource(Server.MapPath("../Content/img/brand/correo5.png"));
        System.Net.Mail.LinkedResource img3 = new System.Net.Mail.LinkedResource(Server.MapPath("../Content/img/brand/correo7.png"));
        img.ContentId = "imagen";
        img2.ContentId = "imagen2";
        img3.ContentId = "imagen3";
        htmlView.LinkedResources.Add(img);
        htmlView.LinkedResources.Add(img2);
        htmlView.LinkedResources.Add(img3);
        correo.AlternateViews.Add(htmlView);
        correo.Priority = System.Net.Mail.MailPriority.Normal;

        System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
        smtp.Host = "legado";
        try
        {
            smtp.Send(correo);
        }
        catch (Exception ex)
        {
            Console.Write(ex);
        }

    }
    protected void gv_resumen_presup_gral_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_resumen_presup_gral.Rows.Count > 0)
        {
            if (gv_resumen_presup_gral.HeaderRow != null)
            {
                gv_resumen_presup_gral.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_resumen_presup_gral.FooterRow != null)
            {
                gv_resumen_presup_gral.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}