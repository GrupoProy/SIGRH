using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_Precontratacion.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Newtonsoft.Json;
public partial class Precontratacion_Frecuencia : System.Web.UI.Page
{
    private cls_pc_frecuencia frecuencia = null;
    private cls_mp_cargo cargo = null;
    private cls_historico historico = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
                int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
                informacionCategoria(cp_id);
                listarFrecuencias(cp_id, pr_id);
                listarResumenFrecuencias(cp_id, pr_id);
                listarResumenPresup(cp_id);
                listaFiltradoCargo(pr_id);
                listaFiltradoPuesto();
                SetScriptInicio("$('.table').DataTable().destroy(); ");
            }
        }
        else
        {
            Response.Redirect("../index");
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

    private void listarFrecuencias(int cp_id = 0, int pr_id = 0, int fr_es_id = 0, decimal fr_tiempo = -1, string fr_estado = "")
    {
        try
        {
            frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id, fr_pr_id = pr_id, fr_es_id = fr_es_id, fr_tiempo = fr_tiempo, fr_estado = fr_estado };
            gv_frecuencias.DataSource = frecuencia.ObtenerFrecuenciasCategorias();
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

            listaFiltradoFrec(cp_id, pr_id, fr_es_id, fr_tiempo, fr_estado, "C22", "ddl_gv_frec_cargo", "es_id", "es_descripcion", "ES.es_descripcion, ES.es_id");
            listaFiltradoFrec(cp_id, pr_id, fr_es_id, fr_tiempo, fr_estado, "C22", "ddl_gv_frec_tiempo", "fr_tiempo", "fr_tiempo", "F.fr_tiempo");
            listaFiltradoFrec(cp_id, pr_id, fr_es_id, fr_tiempo, fr_estado, "C22", "ddl_gv_frec_estado", "fr_estado", "fr_estado", "F.fr_estado ");
            //listaFiltradoFrec(cp_id, pr_id, fr_es_id, fr_tiempo, fr_estado, "C22", "ddl_gv_frec_estado", "fr_estado", "fr_estado", "F.fr_estado, CASE WHEN F.fr_estado = ''L'' THEN ''LIBRE'' WHEN F.fr_estado = ''H'' THEN ''HISTÓRICO'' WHEN F.fr_estado = ''O'' THEN ''OCUPADO'' END ");
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaFiltradoFrec(int cp_id = 0, int pr_id = 0, int fr_es_id = 0, decimal fr_tiempo = -1, string fr_estado = "", string accion = "", string ddl_id = "", string ddl_value = "", string ddl_desc = "", string q = "")
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cp_id = cp_id;
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
            ddl.DataSource = frecuencia.ObtenerListaFiltradoFrecuencia(q);
            ddl.DataBind();
            

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void ddl_gv_frec_cargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        int cp_ip = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        DropDownList ddl_gv_frec_cargo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;
        DropDownList ddl_gv_frec_tiempo = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_tiempo") as DropDownList;
        DropDownList ddl_gv_frec_estado = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_estado") as DropDownList;

        int fr_es_id = (ddl_gv_frec_cargo.SelectedValue != "-1") ? Convert.ToInt32(ddl_gv_frec_cargo.SelectedValue) : 0;
        decimal fr_tiempo = (ddl_gv_frec_tiempo.SelectedValue != "-1") ? Convert.ToDecimal(ddl_gv_frec_tiempo.SelectedValue) : -1;
        string fr_estado = (ddl_gv_frec_estado.SelectedValue != "-1") ? ddl_gv_frec_estado.SelectedValue : "";

        string fr_es_id_v = (ddl_gv_frec_cargo.SelectedValue != "-1") ? ddl_gv_frec_cargo.SelectedValue : "-1";
        string fr_tiempo_v = (ddl_gv_frec_tiempo.SelectedValue != "-1") ? ddl_gv_frec_tiempo.SelectedValue : "-1";
        string fr_estado_v = (ddl_gv_frec_estado.SelectedValue != "-1") ? ddl_gv_frec_estado.SelectedValue : "-1";

        listarFrecuencias(cp_ip, pr_id, fr_es_id, fr_tiempo, fr_estado);

        DropDownList ddl_gv_frec_cargo_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_cargo") as DropDownList;
        DropDownList ddl_gv_frec_tiempo_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_tiempo") as DropDownList;
        DropDownList ddl_gv_frec_estado_after = gv_frecuencias.HeaderRow.FindControl("ddl_gv_frec_estado") as DropDownList;
        ddl_gv_frec_cargo_after.SelectedValue = fr_es_id_v;
        ddl_gv_frec_tiempo_after.SelectedValue = fr_tiempo_v;
        ddl_gv_frec_estado_after.SelectedValue = fr_estado_v;
        SetScript("");
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
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 });");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");
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
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false, 'stateSave': true, 'stateDuration': 60 * 10 });");

        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable().destroy(); ");
        sb.Append("$('#ContentPlaceHolder1_gv_frecuencias').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 });");

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
    private void listarResumenFrecuencias(int cp_id = 0, int pr_id = 0)
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cp_id = cp_id;
            frecuencia.fr_pr_id = pr_id;
            gv_fracuencias_resumen.DataSource = frecuencia.ObtenerResumenFrecuenciasCategorias();
            gv_fracuencias_resumen.DataBind();

            d_gv_fracuencias_resumen.Visible = (gv_frecuencias.Rows.Count > 0) ? false : true;
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_fracuencias_resumen_RowCommand(object sender, GridViewCommandEventArgs e)
    {

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
    private void listarResumenPresup(int cp_id = 0)
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_cp_id = cp_id;
            gv_resumen_presup.DataSource = frecuencia.ObtenerResumenPresup();
            gv_resumen_presup.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_resumen_presup_RowCommand(object sender, GridViewCommandEventArgs e)
    {

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
                ltl_prog.Text = validarCampo(categoria["cp_programa"]);
                ltl_proy.Text = validarCampo(categoria["cp_proyecto"]);
                ltl_act.Text = validarCampo(categoria["cp_actividad"]);
                ltl_desc.Text = validarCampo(categoria["cp_descripcion"]);
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

    protected void btn_nueva_frecuencia_Click(object sender, EventArgs e)
    {
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        listaFiltradoCargo(pr_id);

        ddl_puesto.Items.Clear();
        ddl_puesto.DataBind();

        txt_fecha_inicio.Enabled = true;
        txt_fecha_fin.Enabled = true;
        ddl_tipo_jornada.Enabled = true;

        hf_editar_fr.Value = "0";
        txt_cantidad.Enabled = true;
        sc = "MostrarMascara(false); $('#modalNuevaFrec').modal('show');";
        SetScript(sc);
    }
    private void listaFiltradoCargo(int gestionFiltrar = 0)
    {
        try
        {
            cargo = new cls_mp_cargo();
            cargo.gestion_selec = Convert.ToString(gestionFiltrar);

            ddl_cargo.Items.Clear();
            ddl_cargo.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_cargo.DataValueField = "es_id";
            ddl_cargo.DataTextField = "es_descripcion";
            ddl_cargo.DataSource = cargo.ObtenerFiltradoCargoUO();
            ddl_cargo.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaFiltradoCargoNS(int gestionFiltrar = 0)
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_pr_id = gestionFiltrar;
            frecuencia.ns_id = Convert.ToInt32(hf_ns_id.Value);

            ddl_cargo.Items.Clear();
            ddl_cargo.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_cargo.DataValueField = "es_id";
            ddl_cargo.DataTextField = "es_descripcion";
            ddl_cargo.DataSource = frecuencia.ObtenerEscalafonNS();
            ddl_cargo.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaFiltradoPuesto()
    {
        try
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"]) : 0;
            frecuencia.fr_es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
            var puestos = frecuencia.ObtenerListaFiltradoPuesto();

            ddl_puesto.Items.Clear();
            ddl_puesto.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_puesto.DataValueField = "pu_id";
            ddl_puesto.DataTextField = "pu_descripcion";
            ddl_puesto.DataSource = puestos;
            ddl_puesto.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void btn_cancelar_frecuencia_Click(object sender, EventArgs e)
    {
        txt_cantidad.Enabled = true;
        limpiar();
        sc = " $('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false);";
        SetScript(sc);
    }
    protected void ddl_cargo_SelectedIndexChanged(object sender, EventArgs e)
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
        var detallehaberBasico = frecuencia.ObtenerHaberBasico();
        if (detallehaberBasico.Tables.Count > 0)
        {
            if (detallehaberBasico.Tables[0].Rows.Count > 0)
            {
                var hb = detallehaberBasico.Tables[0].Rows[0];
                decimal haberBasicoAsignarVista = Convert.ToDecimal(validarCampo(hb["ns_haber_basico"]));
                haberBasicoAsignarVista = Math.Round(haberBasicoAsignarVista, 2);
                ltl_haber_basico.Text = Convert.ToString(haberBasicoAsignarVista);
                hf_haber_basico.Value = Convert.ToString(haberBasicoAsignarVista);
            }
        }
        listaFiltradoPuesto();
        ddl_tipo_jornada.Focus();
        calcularHB();
        SetScript("");
    }

    protected void ddl_tipo_jornada_SelectedIndexChanged(object sender, EventArgs e)
    {
        calcularHB();
        txt_fecha_inicio.Focus();
        SetScript("");
    }
    protected void calcularHB()
    {
        if (hf_haber_basico.Value != "")
        {
            decimal hb = Convert.ToDecimal(hf_haber_basico.Value);
            if (ddl_tipo_jornada.SelectedValue == "MT")
            {
                hb = Math.Round(hb / 2, 0);
                string hb_round = String.Format("{0:0.00}", hb);
                ltl_haber_basico.Text = Convert.ToString(hb_round);
            }
            else
            {
                ltl_haber_basico.Text = Convert.ToString(hb);
            }
        }
    }

    protected void txt_fecha_inicio_TextChanged(object sender, EventArgs e)
    {
        DateTime startDate;
        DateTime endDate;

        if ((DateTime.TryParse(txt_fecha_inicio.Text, out startDate)) && (DateTime.TryParse(txt_fecha_fin.Text, out endDate)))
        {
            startDate = Convert.ToDateTime(txt_fecha_inicio.Text);
            endDate = Convert.ToDateTime(txt_fecha_fin.Text);
            double diferencia = (endDate - startDate).TotalDays;
            if (diferencia >= 0)
            {
                ltl_tiempo_estimado.Text = calcularTiempoMeses();
            }
            else
            {
                ltl_tiempo_estimado.Text = "";
            }
        }
        txt_fecha_fin.Focus();
        SetScript("");
    }

    protected void txt_fecha_fin_TextChanged(object sender, EventArgs e)
    {
        DateTime startDate;
        DateTime endDate;

        if ((DateTime.TryParse(txt_fecha_inicio.Text, out startDate)) && (DateTime.TryParse(txt_fecha_fin.Text, out endDate)))
        {
            startDate = Convert.ToDateTime(txt_fecha_inicio.Text);
            endDate = Convert.ToDateTime(txt_fecha_fin.Text);
            double diferencia = (endDate - startDate).TotalDays;
            if (diferencia >= 0)
            {
                ltl_tiempo_estimado.Text = calcularTiempoMeses();
            }
            else
            {
                ltl_tiempo_estimado.Text = "";
            }
        }
        txt_cantidad.Focus();
        SetScript("");
    }
    protected string calcularTiempoMeses()
    {
        string tiempo = "";
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_fecha_inicio = txt_fecha_inicio.Text;
        frecuencia.fr_fecha_fin = txt_fecha_fin.Text;

        var detalleTiempoMes = frecuencia.ObtenerTiempoMeses();
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
    protected void btn_adicionar_frecuencia_Click(object sender, EventArgs e)
    {
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int cod_poa = (Request.QueryString["id3"] != null) ? Convert.ToInt32(Request.QueryString["id3"].ToString()) : 0;
        string tiempo = calcularTiempoMeses();

        if (hf_editar_fr.Value == "0")
        {
            int cantidad = Convert.ToInt32(txt_cantidad.Text);
            if (cantidad > 0)
            {
                sc = (montoValido(cp_id, cantidad, hf_haber_basico.Value, ddl_tipo_jornada.SelectedValue, tiempo)) ? "" : "$.notify({ icon: 'fa fa-exclamation', message: 'Se adiciono las frecuencias con sobregiro.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); ";
                for (int i = 0; i < cantidad; i++)
                {
                    frecuencia = new cls_pc_frecuencia();
                    frecuencia.fr_cp_id = cp_id;
                    frecuencia.fr_cod_poa = cod_poa;
                    frecuencia.fr_es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
                    frecuencia.fr_tipo_jornada = ddl_tipo_jornada.SelectedValue;
                    frecuencia.fr_fecha_inicio = txt_fecha_inicio.Text;
                    frecuencia.fr_fecha_fin = txt_fecha_fin.Text;
                    frecuencia.fr_tiempo = (tiempo != "") ? Convert.ToDecimal(tiempo) : 0;
                    frecuencia.fr_descrip_puesto = ddl_puesto.SelectedItem.Text;
                    frecuencia.fr_obj_puesto = txt_objetivo.Text.Trim().ToUpper();
                    frecuencia.fr_estado = "L";
                    frecuencia.fr_observaciones = txt_observaciones.Text.Trim().ToUpper();

                    var detalleFrecuencia = frecuencia.Adicionar();
                    var frecuenciaX = detalleFrecuencia.Tables[0].Rows[0];
                    string fr_id_x = validarCampo(frecuenciaX["fr_id"]);
                    string json = JsonConvert.SerializeObject(detalleFrecuencia.Tables[0]);
                    AdicionarHistorico("A", "tbl_pc_frecuencias", "fr_id", Convert.ToString(fr_id_x), json);

                }
                listarFrecuencias(cp_id, pr_id);
                listarResumenFrecuencias(cp_id, pr_id);
                listarResumenPresup(cp_id);
                limpiar();

                sc = sc + "$.notify({ icon: 'fa fa-check', message: 'Frecuencia(s) creada(s) correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false); ";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-exclamation', message: 'La cantidad no es valida.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); MostrarMascara(false);";
                SetScript(sc);
            }
        }
        else
        {
            frecuencia = new cls_pc_frecuencia();
            frecuencia.fr_id = Convert.ToInt32(hf_fr_id.Value);
            var detalle_tiempo_uso = frecuencia.ObtenerTiempoUso();
            if (detalle_tiempo_uso.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToDouble(tiempo) >= Convert.ToDouble(validarCampo(detalle_tiempo_uso.Tables[0].Rows[0]["tiempo_uso"])))
                {
                    sc = (montoValidoEditar(cp_id, 1, hf_haber_basico.Value, ddl_tipo_jornada.SelectedValue, tiempo)) ? "" : "$.notify({ icon: 'fa fa-exclamation', message: 'Se adiciono las frecuencias con sobregiro.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} }); ";
                    frecuencia = new cls_pc_frecuencia();
                    frecuencia.fr_id = Convert.ToInt32(hf_fr_id.Value);
                    frecuencia.fr_cp_id = cp_id;
                    frecuencia.fr_cod_poa = cod_poa;
                    frecuencia.fr_es_id = Convert.ToInt32(ddl_cargo.SelectedValue);
                    frecuencia.fr_tipo_jornada = ddl_tipo_jornada.SelectedValue;
                    frecuencia.fr_fecha_inicio = txt_fecha_inicio.Text;
                    frecuencia.fr_fecha_fin = txt_fecha_fin.Text;
                    frecuencia.fr_tiempo = (tiempo != "") ? Convert.ToDecimal(tiempo) : 0;
                    frecuencia.fr_descrip_puesto = ddl_puesto.SelectedItem.Text.Trim().ToUpper();
                    frecuencia.fr_obj_puesto = txt_objetivo.Text;
                    frecuencia.fr_observaciones = txt_observaciones.Text.ToUpper().Trim();
                    frecuencia.fr_estado = (hf_estado.Value == "OCUPADO") ? "O" : "L";

                    var detalleFrecuencia = frecuencia.Actualizar();
                    var frecuenciaX = detalleFrecuencia.Tables[0].Rows[0];
                    string fr_id_x = validarCampo(frecuenciaX["fr_id"]);
                    string json = JsonConvert.SerializeObject(detalleFrecuencia.Tables[0]);
                    AdicionarHistorico("A", "tbl_pc_frecuencias", "fr_id", Convert.ToString(fr_id_x), json);

                    listarFrecuencias(cp_id, pr_id);
                    listarResumenFrecuencias(cp_id, pr_id);
                    listarResumenPresup(cp_id);
                    limpiar();
                    sc = sc + "$.notify({ icon: 'fa fa-check', message: 'Frecuencia modificada correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#modalNuevaFrec').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false);";
                    SetScript(sc);
                } else
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'El tiempo de la frecuencia no debe ser menor al tiempo usado.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); MostrarMascara(false);";
                    SetScript(sc);
                }

            }
        }
    }
    protected void gv_frecuencias_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        int index = Convert.ToInt32(e.CommandArgument);
        hf_fr_id.Value = gv_frecuencias.DataKeys[index].Values[0].ToString();
        hf_ns_id.Value = gv_frecuencias.DataKeys[index].Values[1].ToString();
        var row = gv_frecuencias.Rows[index];
        Label aux = (Label)row.FindControl("lbl_gv_frec_estado");
        string fr_estado = aux.Text;
        hf_estado.Value = fr_estado;

        switch (e.CommandName)
        {
            case "GetDelete":
                if (fr_estado != "OCUPADO")
                {
                    sc = "$('#eliminarFrecuencia').modal('show');";
                }
                else
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción, la frecuencia está siendo usada.'},{ type: 'danger', placement: { from: 'bottom', align: 'right'} });";
                }
                SetScript(sc);
                break;
            case "GetEdit":
                if (fr_estado != "OCUPADO")
                {
                    listaFiltradoCargo(pr_id);
                    hf_editar_fr.Value = "1";
                    obtenerFrecuenciaX();
                    //txt_fecha_inicio.Enabled = true;
                    //txt_fecha_fin.Enabled = true;
                    //ddl_tipo_jornada.Enabled = true;
                } else
                {
                    listaFiltradoCargoNS(pr_id);
                    hf_editar_fr.Value = "1";
                    obtenerFrecuenciaX();
                    //txt_fecha_inicio.Enabled = false;
                    //txt_fecha_fin.Enabled = false;
                    //ddl_tipo_jornada.Enabled = false;
                }

                break;
            default:
                break;
        }
    }

    protected void btn_eilminar_frec_Click(object sender, EventArgs e)
    {
        int cp_id = (Request.QueryString["id"] != null) ? Convert.ToInt32(Request.QueryString["id"].ToString()) : 0;
        int pr_id = (Request.QueryString["id2"] != null) ? Convert.ToInt32(Request.QueryString["id2"].ToString()) : 0;
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_id = Convert.ToInt32(hf_fr_id.Value);
        frecuencia.fr_observaciones = txt_fr_observaciones.Text.Trim().ToUpper();
        frecuencia.Eliminar();

        listarFrecuencias(cp_id, pr_id);
        listarResumenFrecuencias(cp_id, pr_id);
        listarResumenPresup(cp_id);
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Frecuencia eliminada correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarFrecuencia').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    protected void obtenerFrecuenciaX()
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_id = Convert.ToInt32(hf_fr_id.Value);
        var detalleFrecuencia = frecuencia.ObtenerFrecuenciaX();
        if (detalleFrecuencia.Tables.Count > 0)
        {
            if (detalleFrecuencia.Tables[0].Rows.Count > 0)
            {
                var frecuencia = detalleFrecuencia.Tables[0].Rows[0];
                string tipo_jor = validarCampo(frecuencia["fr_tipo_jornada"]);

                decimal hb = Convert.ToDecimal(validarCampo(frecuencia["haber_basico"]));
                hb = Math.Round(hb, 0);
                decimal hb_pr = (tipo_jor == "MT") ? Math.Round((hb / 2), 0) : hb;
                string hb_round = String.Format("{0:0.00}", hb_pr);
                ltl_haber_basico.Text = Convert.ToString(hb_round);
                hf_haber_basico.Value = Convert.ToString(String.Format("{0:0.00}", hb));

                ddl_cargo.SelectedValue = validarCampo(frecuencia["es_id"]);
                ddl_tipo_jornada.SelectedValue = (ddl_tipo_jornada.Items.FindByValue(tipo_jor) != null) ? tipo_jor : "TC";
                txt_fecha_inicio.Text = validarCampo(frecuencia["fr_fecha_inicio"]);
                txt_fecha_fin.Text = validarCampo(frecuencia["fr_fecha_fin"]);
                ltl_tiempo_estimado.Text = validarCampo(frecuencia["fr_tiempo"]);

                listaFiltradoPuesto();
                var puesto = ddl_puesto.Items.FindByText(validarCampo(frecuencia["pu_id"]));
                ddl_puesto.SelectedValue = (puesto != null) ? puesto.Value : "0";

                txt_objetivo.Text = validarCampo(frecuencia["fr_obj_puesto"]);
                txt_observaciones.Text = validarCampo(frecuencia["fr_observaciones"]);

                txt_cantidad.Text = "1";
                txt_cantidad.Enabled = false;
                txt_cantidad.CssClass = "form-control numero";

                hf_tipo_jornada_edit.Value = tipo_jor;
                hf_tiempo_edit.Value = validarCampo(frecuencia["fr_tiempo"]);
                hf_hb_edit.Value = Convert.ToString(hb_round);
            }
        }
        SetScript("$('#modalNuevaFrec').modal('show');");
    }
    protected void limpiar()
    {
        ddl_cargo.SelectedValue = "0";
        ddl_tipo_jornada.SelectedValue = "TC";
        ltl_haber_basico.Text = "";
        txt_fecha_inicio.Text = "";
        txt_fecha_fin.Text = "";
        ltl_tiempo_estimado.Text = "";
        txt_cantidad.Text = "";
        ddl_puesto.SelectedValue = "0";
        txt_objetivo.Text = "";
        txt_observaciones.Text = "";
        hf_haber_basico.Value = "";

        hf_tipo_jornada_edit.Value = "";
        hf_tiempo_edit.Value = "";
        hf_hb_edit.Value = "";
    }
    protected bool montoValido(int cp_id = 0, int cantidad_x = 0, string haber_basico = "", string tipo_jornada = "", string tiempo = "")
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_cp_id = cp_id;
        var detallePresup = frecuencia.ObtenerResumenPresup();
        int cantidad = cantidad_x;
        decimal haber_basico_x = Convert.ToDecimal(haber_basico);
        haber_basico_x = (tipo_jornada != "MT") ? haber_basico_x : (haber_basico_x / 2);
        decimal tiempo_estimado = Convert.ToDecimal(tiempo);
        decimal comprometido = (tiempo_estimado * haber_basico_x) * cantidad;

        bool sw = true;
        if (detallePresup.Tables.Count > 0)
        {
            if (detallePresup.Tables[0].Rows.Count > 0)
            {
                var presup = detallePresup.Tables[0].Rows;
                for (int i = 0; i < presup.Count; i++)
                {
                    decimal saldo_part_presup = (validarCampo(presup[i]["saldo"]) != "") ? Convert.ToDecimal(validarCampo(presup[i]["saldo"])) : 0;
                    switch (i)
                    {
                        case 0:
                            saldo_part_presup = saldo_part_presup - (comprometido + ((comprometido) * Convert.ToDecimal(0.0833333)));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        case 1:
                            saldo_part_presup = saldo_part_presup - (comprometido * Convert.ToDecimal(0.1));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        case 2:
                            saldo_part_presup = saldo_part_presup - (comprometido * Convert.ToDecimal(0.0171));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        case 3:
                            saldo_part_presup = saldo_part_presup - (comprometido * Convert.ToDecimal(0.03));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        case 4:
                            saldo_part_presup = saldo_part_presup - (comprometido * Convert.ToDecimal(0.02));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        default:
                            break;
                    }
                    if (!sw)
                    {
                        break;
                    }
                }
            }
        }
        return sw;
    }
    protected bool montoValidoEditar(int cp_id = 0, int cantidad_x = 0, string haber_basico = "", string tipo_jornada = "", string tiempo = "")
    {
        frecuencia = new cls_pc_frecuencia();
        frecuencia.fr_cp_id = cp_id;
        var detallePresup = frecuencia.ObtenerResumenPresup();
        int cantidad = cantidad_x;
        decimal haber_basico_x = Convert.ToDecimal(haber_basico);
        haber_basico_x = (tipo_jornada != "MT") ? haber_basico_x : (haber_basico_x / 2);
        decimal tiempo_estimado = Convert.ToDecimal(tiempo);
        decimal comprometido = (tiempo_estimado * haber_basico_x) * cantidad;

        decimal hb_edit_ant = Convert.ToDecimal(hf_hb_edit.Value);
        decimal tiempo_estimado_ant = Convert.ToDecimal(hf_tiempo_edit.Value);
        decimal comprometido_ant = tiempo_estimado_ant * hb_edit_ant;

        bool sw = true;
        if (detallePresup.Tables.Count > 0)
        {
            if (detallePresup.Tables[0].Rows.Count > 0)
            {
                var presup = detallePresup.Tables[0].Rows;
                for (int i = 0; i < presup.Count; i++)
                {
                    decimal saldo_part_presup = (validarCampo(presup[i]["saldo"]) != "") ? Convert.ToDecimal(validarCampo(presup[i]["saldo"])) : 0;
                    switch (i)
                    {
                        case 0:
                            saldo_part_presup = saldo_part_presup + (comprometido_ant + ((comprometido_ant) * Convert.ToDecimal(0.0833333)));
                            saldo_part_presup = saldo_part_presup - (comprometido + ((comprometido) * Convert.ToDecimal(0.0833333)));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        case 1:
                            saldo_part_presup = saldo_part_presup + (comprometido_ant * Convert.ToDecimal(0.1));
                            saldo_part_presup = saldo_part_presup - (comprometido * Convert.ToDecimal(0.1));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        case 2:
                            saldo_part_presup = saldo_part_presup + (comprometido_ant * Convert.ToDecimal(0.0171));
                            saldo_part_presup = saldo_part_presup - (comprometido * Convert.ToDecimal(0.0171));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        case 3:
                            saldo_part_presup = saldo_part_presup + (comprometido_ant * Convert.ToDecimal(0.03));
                            saldo_part_presup = saldo_part_presup - (comprometido * Convert.ToDecimal(0.03));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        case 4:
                            saldo_part_presup = saldo_part_presup + (comprometido_ant * Convert.ToDecimal(0.02));
                            saldo_part_presup = saldo_part_presup - (comprometido * Convert.ToDecimal(0.02));
                            sw = (saldo_part_presup >= 0) ? true : false;
                            break;
                        default:
                            break;
                    }
                    if (!sw)
                    {
                        break;
                    }
                }
            }
        }
        return sw;
    }
    private void AdicionarHistorico(string abm = "", string tabla = "", string nom_pk = "", string val_pk = "", string campos = "")
    {
        historico = new cls_historico
        {
            his_tipo_abm = abm,
            his_nom_tabla = tabla,
            his_nom_pk = nom_pk,
            his_valor_pk = val_pk,
            his_campos = campos,
            his_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString())
        };
        historico.Adicionar();
    }
}