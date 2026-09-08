using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using Solution_Framework_General.BussinessLogicLayer;//***
using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using System.Text;

public partial class tbl_mdp_resultados_especificos : System.Web.UI.Page
{
    private cls_mdp_resultados_especificos poai_id = null;
    private string sc = "";
    private cls_catalogo _catalogo = null;//****//
    private cls_glosa _glosa = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (HttpContext.Current.Session["us_id"] != null)
            {

                poai_id = new cls_mdp_resultados_especificos();
                var id = Request.QueryString["id"].ToString();

                informacionItem(id);
                listarSupervisionEjercida(id);
                listarResultadosEsp(id);
                listarTareas(id);
                listarConocimientosComp(id);
                //listarDisposiciones(id);
                listarResponsabilidades(id);
                // listarm formaciones
                listaFiltradoFormacionO(id);
                listaFiltradoFormacionC(id);
                //listarFiltradoFormacionRequerida3C(id);
                //listarFiltradoAreaFormacion3C(id);

                ////listarCaracterIndividual(id);
                listarTiempoExperiencia(id);
                listaFiltradoConcocimiento(id);
                //// listaFiltradoDisposicion(id);
                ////listaFiltradoCaracterIndividual(id);

                
                var editar = HttpContext.Current.Session["editarGestion"];
                bool edit = Convert.ToBoolean(editar);
                if (edit)
                {
                    sc = "console.log('mostrarInputs', this, window.$); $('#exp_municipios').css('display', 'none'); ";
                    SetScript(sc);
                }
                else
                {
                    sc = "console.log('mostrarInputs', this, window.$); $('#exp_municipios').css('display', 'block'); ";
                    SetScript(sc);
                }

                visualizarBoton();
            }
            else
            {
                Response.Redirect("../index");
            }
        }
    }
    // Para verificar sumatoria de puntaje
    //protected void sumatoria()
    //{
    //    int total_ptje = 0;
    //    foreach (GridViewRow row in gvResultadosEsp.Rows)
    //    {
    //        for (int i = 0; i < gvResultadosEsp.Columns.Count; i++)
    //        {
    //            if (i == 2)
    //            {
    //                int ptje = Convert.ToInt32(row.Cells[i].Text);
    //                total_ptje = total_ptje + ptje;
    //            }

    //        }
    //    }
    //    txtsuma.Text = "PUNTAJE TOTAL:  "+ total_ptje.ToString();
    //    if (total_ptje < 70)
    //    {
    //        sc = "$.notify({ icon: 'fas fa-times-circle', message: 'La suma de los puntajes registrados debe ser igual a 70.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
    //        SetScript(sc);
    //        txtsuma.ForeColor = System.Drawing.Color.Red;
    //    }
    //    else
    //    {
    //        txtsuma.ForeColor = System.Drawing.Color.Black;
    //    }

    //}
    private void informacionItem(string id)
    {
        poai_id.ObtenerFicha(id);
        string nivel_escala = poai_id.ne_categoria + " Nivel: " + poai_id.ne_nivel_interno;

        spn_cargo.Attributes.Add("data-toggle", "tooltip");
        spn_cargo.Attributes.Add("data-original-title", nivel_escala);

        spn_cargo2.Attributes.Add("data-toggle", "tooltip");
        spn_cargo2.Attributes.Add("data-original-title", nivel_escala);

        spn_cargo3.Attributes.Add("data-toggle", "tooltip");
        spn_cargo3.Attributes.Add("data-original-title", nivel_escala);

        ltl_tab1_item.Text = poai_id.prefijo + " - " + poai_id.item;
        lvl_tab1_item_anterior.Text = poai_id.item_anterior;
        ltl_tab1_cargo.Text = poai_id.cargo;
        ltl_tab1_uo.Text = poai_id.est_org;

        txt_nom_puesto_edit.Text = poai_id.puesto;
        txt_objetivo_edit.Text = poai_id.objetivo;

        p_pu_id.Value = poai_id.pu_id.ToString();
        p_pu_poai_id.Value = id;
        p_pu_nro_puesto.Value = poai_id.pu_nro_puesto.ToString();
        p_pu_pref_puesto.Value = poai_id.pu_pref_puesto;
        p_pu_id_puesto_anterior.Value = poai_id.pu_id_puesto_anterior.ToString();

        var editar = HttpContext.Current.Session["editarGestion"];
        bool edit = Convert.ToBoolean(editar);
        ModalGuardarItem.Visible = edit;

        ltl_tab2_item.Text = poai_id.prefijo + " - " + poai_id.item;
        ltl_tab2_cargo.Text = poai_id.cargo;
        ltl_tab2_uo.Text = poai_id.est_org;

        ltl_tab3_item.Text = poai_id.prefijo + " - " + poai_id.item;
        ltl_tab3_cargo.Text = poai_id.cargo;
        ltl_tab3_uo.Text = poai_id.est_org;

        ltl_tab1_gestion.Text = poai_id.gestion;
        ltl_tab2_gestion.Text = poai_id.gestion;
        ltl_tab3_gestion.Text = poai_id.gestion;

        ltl_tab2_puesto.Text = poai_id.puesto;
        ltl_tab3_puesto.Text = poai_id.puesto;

        if (poai_id.ne_nivel_interno >4) //**Preguntamos si el nivel de la escala salarial es mayor al NIVEL PROFESIONAL(4)**//
            //** EL NIVEL SE ENCUENTRA EN LA TABLA TBL_MP_NIVEL_ESCALA***//
            {
            panel_nuevo_resultado.Visible = false;
            panel_nuevo_resultado.Visible = false;
            ///txtsuma.Visible = false;
            ///btn_validar_ptje_final.Visible = false;
            ModalAddResultado.Enabled = false;
            btnNuevoResultado.Visible = false;
            no_corresponde_resultados.Visible = true;
            no_corresponde_resultados.Text = "**** No corresponde ****";
        }
      else
        {
            panel_nuevo_resultado.Visible = true;
            panel_nuevo_resultado.Visible = true;
            ///txtsuma.Visible = true;
            ///btn_validar_ptje_final.Visible = true;
            ModalAddResultado.Enabled = true;
            btnNuevoResultado.Visible = true;
            //lblpuntaje.visible = false;
            //sumatoria();
            no_corresponde_resultados.Visible = true;
            no_corresponde_resultados.Text = "";
        }
        ///btn_validar_ptje_final.Visible = false;
       // poai_id = new cls_mdp_resultados_especificos();
        //if (poai_id. > 2023)
        //{ lvl_tab1_item_anterior.Visible = true; }
        //else
        //{
        //    lvl_tab1_item_anterior.Visible = false;
        //}

    }

    private void listarResultadosEsp(string id)
    {
        try
        {
            poai_id = new cls_mdp_resultados_especificos();
            gvResultadosEsp.DataSource = poai_id.ObtenerGrillaResultados(id);

            var editar = HttpContext.Current.Session["editarGestion"];
            bool edit = Convert.ToBoolean(editar);
            gvResultadosEsp.Columns[3].Visible = edit;
            ModalAddResultado.Visible = edit;

            gvResultadosEsp.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
        //int total_ptje = 0;
        //foreach (GridViewRow row in gvResultadosEsp.Rows)
        //{
        //    for (int i = 0; i < gvResultadosEsp.Columns.Count; i++)
        //    {
        //        if (i == 2)
        //        {
        //            int ptje = Convert.ToInt32(row.Cells[i].Text);
        //            total_ptje = total_ptje + ptje;
        //        }

        //    }
        //}
    }

    protected void gvResultadosEsp_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvResultadosEsp.Rows.Count > 0)
        {
            if (gvResultadosEsp.HeaderRow != null)
            {
                gvResultadosEsp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvResultadosEsp.FooterRow != null)
            {
                gvResultadosEsp.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    private void listarTareas(string id)
    {
        try
        {
            poai_id = new cls_mdp_resultados_especificos();
            gvTareas.DataSource = poai_id.ObtenerGrillaTareas(id);

            var editar = HttpContext.Current.Session["editarGestion"];
            bool edit = Convert.ToBoolean(editar);
            gvTareas.Columns[1].Visible = edit;
            ModalAddTarea.Visible = edit;

            gvTareas.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void bloquearTareGeneral()
    {
        string desc_tarea = "";
        foreach (GridViewRow row in gvTareas.Rows)
        {
            for (int i = 0; i < gvTareas.Columns.Count; i++)
            {
                desc_tarea = row.Cells[0].Text;
                if (desc_tarea.Trim() == "Y OTRAS TAREAS ASIGNADAS POR LA AUTORIDAD SUPERIOR")
                {
                    row.Cells[1].Visible = false;
                }
            }
        }
        gvTareas.DataBind();
    }
    protected void gvTareas_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvTareas.Rows.Count > 0)
        {
            if (gvTareas.HeaderRow != null)
            {
                gvTareas.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvTareas.FooterRow != null)
            {
                gvTareas.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    private void listarConocimientosComp(string id)
    {
        try
        {
            poai_id = new cls_mdp_resultados_especificos();
            gvConocimientosCom.DataSource = poai_id.ObtenerGrillaConocimiento(id);

            var editar = HttpContext.Current.Session["editarGestion"];
            bool edit = Convert.ToBoolean(editar);
            gvConocimientosCom.Columns[1].Visible = edit;
            ModalAddConocimiento.Visible = edit;

            gvConocimientosCom.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gvConocimientosCom_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvConocimientosCom.Rows.Count > 0)
        {
            if (gvConocimientosCom.HeaderRow != null)
            {
                gvConocimientosCom.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvConocimientosCom.FooterRow != null)
            {
                gvConocimientosCom.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    //private void listarDisposiciones(string id)
    //{
    //    try
    //    {
    //        poai_id = new cls_mdp_resultados_especificos();
    //        gvDisposicion.DataSource = poai_id.ObtenerGrillaDisposicion(id);

    //        var editar = HttpContext.Current.Session["editarGestion"];
    //        bool edit = Convert.ToBoolean(editar);
    //        gvDisposicion.Columns[1].Visible = edit;
    //        ModalAddDisposicion.Visible = edit;

    //        gvDisposicion.DataBind();

    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}

    //protected void gvDisposicion_PreRender(object sender, EventArgs e)
    //{
    //    base.OnPreRender(e);
    //    if (gvDisposicion.Rows.Count > 0)
    //    {
    //        if (gvDisposicion.HeaderRow != null)
    //        {
    //            gvDisposicion.HeaderRow.TableSection = TableRowSection.TableHeader;
    //        }
    //        if (gvDisposicion.FooterRow != null)
    //        {
    //            gvDisposicion.FooterRow.TableSection = TableRowSection.TableFooter;
    //        }
    //    }
    //}

    private void listarResponsabilidades(string id)
    {
        try
        {
            // armar checkbox dinamicos
            poai_id = new cls_mdp_resultados_especificos();
            cbl_responsabilidad.DataValueField = "cat_id";
            cbl_responsabilidad.DataTextField = "descripcion";
            cbl_responsabilidad.DataSource = poai_id.ObtenerListaRespons();
            cbl_responsabilidad.DataBind();

            // editar checks
            var respons = poai_id.ObtenerResponsItem(id);

            for (int i = 0; i < cbl_responsabilidad.Items.Count; i++)
            {

                foreach (DataRow row in respons.Tables[0].Rows)
                {
                    if (cbl_responsabilidad.Items[i].Value == Convert.ToString(row["irespons_cat_id"]))
                    {
                        cbl_responsabilidad.Items[i].Selected = true;
                        break;
                    }
                }
            }

            var editar = HttpContext.Current.Session["editarGestion"];
            bool edit = Convert.ToBoolean(editar);
            ModalGuardarRespons.Visible = edit;
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoFormacionO(string id)
    {
        try
        {
            poai_id = new cls_mdp_resultados_especificos();

            ddl_formacion_obli.DataValueField = "fo_id";
            ddl_formacion_obli.DataTextField = "descripcion";
            ddl_formacion_obli.DataSource = poai_id.ObtenerListaFiltradoFormO();
            ddl_formacion_obli.DataBind();

            var respons = poai_id.ObtenerFormOItem(id);

            if (respons.Tables[0].Rows[0]["ifo_fo_id"] != DBNull.Value && respons.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim() != "")
            {
                ddl_formacion_obli.SelectedValue = respons.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim();
            }
            else
            {
                ddl_formacion_obli.Items.Insert(0, new ListItem("Seleccione...", "NA"));
            }

            var editar = HttpContext.Current.Session["editarGestion"];
            bool edit = Convert.ToBoolean(editar);
            ModalGuardarRequisito.Visible = edit;

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoFormacionC(string id)
    {
        try
        {
            poai_id = new cls_mdp_resultados_especificos();

            ddl_formacion_comp.DataValueField = "fo_id";
            ddl_formacion_comp.DataTextField = "descripcion";
            ddl_formacion_comp.DataSource = poai_id.ObtenerListaFiltradoFormC();
            ddl_formacion_comp.DataBind();

            var respons = poai_id.ObtenerFormCItem(id);

            if (respons.Tables[0].Rows[0]["ifo_fo_id"] != DBNull.Value && respons.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim() != "")
            {
                ddl_formacion_comp.SelectedValue = respons.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim();
            }
            else
            {
                ddl_formacion_comp.Items.Insert(0, new ListItem("Seleccione...", "NA"));
            }

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    //private void listarFiltradoFormacionRequerida3C(string id)
    //{
    //    try
    //    {
    //        poai_id = new cls_mdp_resultados_especificos();

    //        ddl_formacion_req.DataValueField = "rf_id";
    //        ddl_formacion_req.DataTextField = "rf_formacion";
    //        ddl_formacion_req.DataSource = poai_id.ObtenerListaFiltradoFormRequerida();
    //        ddl_formacion_req.DataBind();

    //        var formRequerida = poai_id.ObtenerFormRequeridaItem(id);

    //        if (formRequerida.Tables[0].Rows[0]["es_rf_id"] != DBNull.Value && formRequerida.Tables[0].Rows[0]["es_rf_id"].ToString().Trim() != "")
    //        {
    //            ddl_formacion_req.SelectedValue = formRequerida.Tables[0].Rows[0]["es_rf_id"].ToString().Trim();
    //        }
    //        else
    //        {
    //            ddl_formacion_req.Items.Insert(0, new ListItem("Seleccione...", "NA"));
    //        }

    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}

    //private void listarFiltradoAreaFormacion3C(string id)
    //{
    //    try
    //    {
    //        poai_id = new cls_mdp_resultados_especificos();

    //        ddl_area_formacion.DataValueField = "af_id";
    //        ddl_area_formacion.DataTextField = "af_nombre";
    //        ddl_area_formacion.DataSource = poai_id.ObtenerListaFiltradoAreaFormacion();
    //        ddl_area_formacion.DataBind();
    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}

    private void listaFiltradoConcocimiento(string id)
    {
        try
        {
            poai_id = new cls_mdp_resultados_especificos();

            ddl_conocimineto_add.Items.Clear();
            ddl_conocimineto_add.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_conocimineto_add.DataValueField = "co_id";
            ddl_conocimineto_add.DataTextField = "co_descripcion";
            ddl_conocimineto_add.DataSource = poai_id.ObtenerFiltradoConcocimiento(id);
            ddl_conocimineto_add.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    //private void listaFiltradoDisposicion(string id)
    //{
    //    try
    //    {
    //        poai_id = new cls_mdp_resultados_especificos();

    //        ddl_disposicion_juridica.Items.Clear();
    //        ddl_disposicion_juridica.Items.Insert(0, new ListItem("Seleccione...", "0"));
    //        ddl_disposicion_juridica.DataValueField = "dj_id";
    //        ddl_disposicion_juridica.DataTextField = "dj_descripcion";
    //        ddl_disposicion_juridica.DataSource = poai_id.ObtenerFiltradoDisposicion(id);
    //        ddl_disposicion_juridica.DataBind();

    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}

    //private void listaFiltradoCaracterIndividual(string id)
    //{
    //    try
    //    {
    //        poai_id = new cls_mdp_resultados_especificos();

    //        ddl_caracter_individual.Items.Clear();
    //        ddl_caracter_individual.Items.Insert(0, new ListItem("Seleccione...", "0"));
    //        ddl_caracter_individual.DataValueField = "ci_id";
    //        ddl_caracter_individual.DataTextField = "ci_factor";
    //        ddl_caracter_individual.DataSource = poai_id.ObtenerFiltradoCaracterIndividual(id);
    //        ddl_caracter_individual.DataBind();

    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}

    //private void listarCaracterIndividual(string id)
    //{
    //    try
    //    {
    //        poai_id = new cls_mdp_resultados_especificos();
    //        int anio = (ltl_tab1_gestion.Text != "") ? Convert.ToInt32(ltl_tab1_gestion.Text) : 0;
    //        poai_id.p_Accion = (anio >= 2020) ? "C28" : "C14";
    //        var CaracterInd = poai_id.ObtenerGrillaCaracterI(id);
    //        gv_caracterIndividual.DataSource = CaracterInd;

    //        var editar = HttpContext.Current.Session["editarGestion"];
    //        bool edit = Convert.ToBoolean(editar);
    //        gv_caracterIndividual.Columns[1].Visible = edit;
    //        ModalAddCaracteristica.Visible = edit;

    //        gv_caracterIndividual.DataBind();

    //        var cat = CaracterInd.Tables[0].Rows[0]["abrev"];

    //        switch (cat.ToString().Trim())
    //        {
    //            case "A":
    //                ddl_categoria.SelectedValue = "0";
    //                break;
    //            case "B":
    //                ddl_categoria.SelectedValue = "1";
    //                break;
    //            case "C":
    //                ddl_categoria.SelectedValue = "2";
    //                break;
    //            case "D":
    //                ddl_categoria.SelectedValue = "3";
    //                break;
    //            case "E":
    //                ddl_categoria.SelectedValue = "4";
    //                break;
    //            case "F":
    //                ddl_categoria.SelectedValue = "5";
    //                break;
    //            case "G":
    //                ddl_categoria.SelectedValue = "6";
    //                break;
    //            case "H":
    //                ddl_categoria.SelectedValue = "7";
    //                break;
    //            default:
    //                break;
    //        }

    //    }
    //    catch (Exception e)
    //    {
    //        Console.Error.Write(e.Message);
    //    }
    //}

    //protected void gv_caracterIndividual_PreRender(object sender, EventArgs e)
    //{
    //    base.OnPreRender(e);
    //    if (gv_caracterIndividual.Rows.Count > 0)
    //    {
    //        if (gv_caracterIndividual.HeaderRow != null)
    //        {
    //            gv_caracterIndividual.HeaderRow.TableSection = TableRowSection.TableHeader;
    //        }
    //        if (gv_caracterIndividual.FooterRow != null)
    //        {
    //            gv_caracterIndividual.FooterRow.TableSection = TableRowSection.TableFooter;
    //        }
    //    }
    //}

    private void listarTiempoExperiencia(string id)
    {
        try
        {
            poai_id = new cls_mdp_resultados_especificos();
            int anio = (ltl_tab1_gestion.Text != "") ? Convert.ToInt32(ltl_tab1_gestion.Text) : 0;
            poai_id.p_Accion = (anio >= 2023) ? "C27" : "C15";
            poai_id.ObtenerTiempoExperiencia(id);

            txt_exp_gral.Text = poai_id.exp_general;
            txt_exp_esp.Text = poai_id.exp_especifica;
            txt_exp_gral_mun.Text = poai_id.exp_general_mun;
            txt_exp_esp_mun.Text = poai_id.exp_especifica_mun; 

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gvResultadosEsp_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        p_res_id.Value = gvResultadosEsp.DataKeys[index].Values[0].ToString();
        p_res_poai_id.Value = gvResultadosEsp.DataKeys[index].Values[1].ToString();

        switch (e.CommandName)
        {
            case "GetDelete":

                sc = "$('#EliminarResultado').modal('show');";
                SetScript(sc);
                break;
            case "GetEdit":
                poai_id = new cls_mdp_resultados_especificos();

                poai_id.ObtenerResultadoP(p_res_id.Value, p_res_poai_id.Value);

                txt_descripcion_resultado.Text = poai_id.res_descripcion.ToString();
                txt_indicador.Text = poai_id.res_indicador.ToString();
                txt_puntaje.Text = poai_id.res_puntaje.ToString();

                sc = "$('#EditarResultado').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    private void SetScript(string data)
    {
        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
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
            "'sNext': '›'," +
            "'sPrevious': '‹'" +
        "}," +
        "'oAria': {" +
                "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
            "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
        "}" +
        "}," +

  "'responsive': true });");

        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        //sb.Append("$('#ContentPlaceHolder1_ddl_caracter_individual').select2({ dropdownParent: $('#NuevaCaracter'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_conocimineto_add').select2({ dropdownParent: $('#NuevaConocimiento'), placeholder: { id: '0', text: 'Seleccione...' } });");
       // sb.Append("$('#ContentPlaceHolder1_ddl_disposicion_juridica').select2({ dropdownParent: $('#NuevaDisposicion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    protected void btnEliminarResultado_Click1(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        poai_id.res_id = Convert.ToInt32(p_res_id.Value);
        poai_id.res_poai_id = Convert.ToInt32(p_res_poai_id.Value);
        string id = p_res_poai_id.Value;

        poai_id.EliminarResultado();
        listarResultadosEsp(id);
        

        sc = "$.notify({ icon: 'fa fa-trash-alt', message:'Resultado eliminado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EliminarResultado').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btnEditarResultado_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        var id = Request.QueryString["id"].ToString();

        poai_id.res_poai_id = Convert.ToInt32(id);
        poai_id.res_id = Convert.ToInt32(p_res_id.Value);

        ////var sumaPuntaje = poai_id.ObtenerSumaPuntajeEditar();

        ////int puntajeTotal = 0;

        ////if (sumaPuntaje.Tables[0].Rows[0]["puntajeTotal"].ToString() != "")
        ////{
        ////    puntajeTotal = Convert.ToInt32(sumaPuntaje.Tables[0].Rows[0]["puntajeTotal"]);
        ////}

        ////int puntajeN = Convert.ToInt32(txt_puntaje.Text);
        ////int puntajeDifUso = 70 - puntajeTotal;
        ////if (puntajeN <= puntajeDifUso)
        ////{
            poai_id.res_id = Convert.ToInt32(p_res_id.Value);
            poai_id.res_poai_id = Convert.ToInt32(p_res_poai_id.Value);

            poai_id.res_descripcion = txt_descripcion_resultado.Text.ToUpper();
            poai_id.res_indicador = txt_indicador.Text.ToUpper();
            poai_id.res_puntaje = Convert.ToInt32(txt_puntaje.Text);
            if (poai_id.Actualizar()) poai_id.Adicionar();

            string id1 = p_res_poai_id.Value;
            listarResultadosEsp(id1);
            sc = "$.notify({ icon: 'fa fa-edit', message: 'Resultado especifico actualizado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#EditarResultado').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc);
        ////}
        ////else
        ////{
        ////    sc = "$.notify({ icon: 'fas fa-times-circle', message: 'El puntaje del resultado es mayor al máximo ponderado.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
        ////    SetScript(sc);
        ////}
        //***//
        ////int total_ptje = 0;
        ////foreach (GridViewRow row in gvResultadosEsp.Rows)
        ////{
        ////    for (int i = 0; i < gvResultadosEsp.Columns.Count; i++)
        ////    {
        ////        if (i == 2)
        ////        {
        ////            int ptje = Convert.ToInt32(row.Cells[i].Text);
        ////            total_ptje = total_ptje + ptje;
        ////        }

        ////    }
        ////}
        ////txtsuma.Text = "PUNTAJE TOTAL:  " + total_ptje.ToString();
        ////if (total_ptje < 70)
        ////{
        ////    sc = "$.notify({ icon: 'fas fa-times-circle', message: 'La suma de los puntajes registrados debe ser igual a 70.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
        ////    SetScript(sc);
        ////    txtsuma.ForeColor = System.Drawing.Color.Red;
        ////}
        ////else
        ////{
        ////    txtsuma.ForeColor = System.Drawing.Color.Black;
        ////}
    }

    protected void gvTareas_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        p_tar_id.Value = gvTareas.DataKeys[index].Values[0].ToString();
        p_tar_poai_id.Value = gvTareas.DataKeys[index].Values[1].ToString();

        switch (e.CommandName)
        {
            case "GetDelete":

                sc = "$('#EliminarTarea').modal('show');";
                SetScript(sc);
                break;
            case "GetEdit":

                poai_id = new cls_mdp_resultados_especificos();

                poai_id.ObteneTareaP(p_tar_id.Value, p_tar_poai_id.Value);

                txt_descripcion_tarea.Text = poai_id.tar_descripcion.ToString();

                sc = "$('#EditarTarea').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    protected void btmEliminarTarea_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        poai_id.tar_id = Convert.ToInt32(p_tar_id.Value);
        poai_id.tar_poai_id = Convert.ToInt32(p_tar_poai_id.Value);
        string id = p_tar_poai_id.Value;

        poai_id.EliminarTarea();
        listarTareas(id);
        sc = "$.notify({ icon: 'fa fa-trash-alt', message:'Tarea recurrente eliminada correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EliminarTarea').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);

    }

    protected void btnEditarTarea_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        poai_id.tar_id = Convert.ToInt32(p_tar_id.Value);
        poai_id.tar_poai_id = Convert.ToInt32(p_tar_poai_id.Value);

        poai_id.tar_descripcion = txt_descripcion_tarea.Text.ToUpper();

        if (poai_id.ActualizarTarea()) poai_id.AdicionarTarea();

        string id = p_tar_poai_id.Value;
        listarTareas(id);
        sc = "$.notify({ icon: 'fa fa-edit', message: 'Tarea recurrente actualizada correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });   $('#EditarTarea').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }



    protected void gvConocimientosCom_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        p_ico_co_id.Value = gvConocimientosCom.DataKeys[index].Values[0].ToString();
        p_ico_poai_id.Value = gvConocimientosCom.DataKeys[index].Values[1].ToString();


        if (e.CommandName.Equals("GetDelete"))
        {
            sc = "$('#EliminarCon').modal('show');";
            SetScript(sc);
        }

    }

    protected void btnEliminarConocimientoC_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        poai_id.ico_co_id = Convert.ToInt32(p_ico_co_id.Value);
        poai_id.ico_poai_id = Convert.ToInt32(p_ico_poai_id.Value);
        string id = p_ico_poai_id.Value;

        poai_id.EliminarConocimiento();
        listarConocimientosComp(id);
        listaFiltradoConcocimiento(id);

        sc = "$.notify({ icon: 'fa fa-trash-alt', message:'Conocimiento Complementario eliminado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EliminarCon').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    //protected void gvDisposicion_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    int index = Convert.ToInt32(e.CommandArgument);
    //    p_idj_dj_id.Value = gvDisposicion.DataKeys[index].Values[0].ToString();
    //    p_idj_poai_id.Value = gvDisposicion.DataKeys[index].Values[1].ToString();

    //    if (e.CommandName.Equals("GetDelete"))
    //    {
    //        sc = "$('#EliminarDispocision').modal('show');";
    //        SetScript(sc);
    //    }
    //}

    //protected void btnEliminarDisposicion_Click(object sender, EventArgs e)
    //{
    //    poai_id = new cls_mdp_resultados_especificos();
    //    poai_id.idj_dj_id = Convert.ToInt32(p_idj_dj_id.Value);
    //    poai_id.idj_poai_id = Convert.ToInt32(p_idj_poai_id.Value);
    //    string id = p_idj_poai_id.Value;

    //    poai_id.EliminarDisposicion();
    //    listarDisposiciones(id);
    //    listaFiltradoDisposicion(id);

    //    sc = "$.notify({ icon: 'fa fa-trash-alt', message:'Disposición Jurídica eliminada correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EliminarDispocision').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    //    SetScript(sc);
    //}


    protected void btnGuardarFormacion_Click(object sender, EventArgs e)
    {

        poai_id = new cls_mdp_resultados_especificos();
        var id = Request.QueryString["id"].ToString();
        poai_id.ifo_poai_id = Convert.ToInt32(id);


        var FormObliI = poai_id.ObtenerFormOItem(id);
        poai_id.ifo_fo_id = Convert.ToInt32(ddl_formacion_obli.SelectedValue);


        if (FormObliI.Tables[0].Rows.Count > 0)
        {
            if (FormObliI.Tables[0].Rows[0]["ifo_fo_id"] != DBNull.Value && FormObliI.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim() != "")
            {
                if (FormObliI.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim() != ddl_formacion_obli.SelectedValue)
                {
                    poai_id.ifo_fo_id_before = Convert.ToInt32(FormObliI.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim());
                    if (poai_id.ActualizarFormacionO()) poai_id.AdicionarFormacionO();
                }
            }
        }
        else
        {
            poai_id.AdicionarFormacionO();
        }

        var FormCompI = poai_id.ObtenerFormCItem(id);
        poai_id.ifo_fo_comp_id = Convert.ToInt32(ddl_formacion_comp.SelectedValue);


        if (FormCompI.Tables[0].Rows.Count > 0)
        {
            if (FormCompI.Tables[0].Rows[0]["ifo_fo_id"] != DBNull.Value && FormCompI.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim() != "")
            {
                if (FormCompI.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim() != ddl_formacion_comp.SelectedValue)
                {
                    poai_id.ifo_fo_comp_id_before = Convert.ToInt32(FormCompI.Tables[0].Rows[0]["ifo_fo_id"].ToString().Trim());
                    if (poai_id.ActualizarFormacionC()) poai_id.AdicionarFormacionC();
                }
            }
        }
        else
        {
            poai_id.AdicionarFormacionC();
        }


        listaFiltradoFormacionO(id);
        listaFiltradoFormacionC(id);

        sc = "$.notify({ icon: 'fa fa-edit', message: 'Registro actualizado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#GuardarFormacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btnGuardarResponsabilidades_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        var id = Request.QueryString["id"].ToString();
        poai_id.irespons_poai_id = Convert.ToInt32(id);

        foreach (ListItem item in cbl_responsabilidad.Items)
        {
            if (item.Selected)
            {
                poai_id.ActualizarResponsabilidad();
                break;
            }
        }

        foreach (ListItem item in cbl_responsabilidad.Items)
        {
            if (item.Selected)
            {
                poai_id.irespons_cat_id = Convert.ToInt32(item.Value);
                poai_id.AdicionarResponsabilidad();

            }
        }
        listarResponsabilidades(id);

        sc = "$.notify({ icon: 'fa fa-check', message: 'Responsabilidad añadido correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#GuardarResponsabilidades').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    //protected void gv_caracterIndividual_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    int index = Convert.ToInt32(e.CommandArgument);
    //    p_ici_poai_id.Value = gv_caracterIndividual.DataKeys[index].Values[0].ToString();
    //    p_ici_ci_id.Value = gv_caracterIndividual.DataKeys[index].Values[1].ToString();

    //    if (e.CommandName.Equals("GetDelete"))
    //    {
    //        sc = "$('#EliminarCaracterI').modal('show');";
    //        SetScript(sc);
    //    }
    //}

    //protected void btnEliminarCaracterI_Click(object sender, EventArgs e)
    //{
    //    poai_id = new cls_mdp_resultados_especificos();
    //    poai_id.ici_ci_id = Convert.ToInt32(p_ici_ci_id.Value);
    //    poai_id.ici_poai_id = Convert.ToInt32(p_ici_poai_id.Value);
    //    string id = p_ici_poai_id.Value;

    //    poai_id.EliminarCaracterI();
    //    listarCaracterIndividual(id);
    //    listaFiltradoCaracterIndividual(id);
    //    sc = "$.notify({ icon: 'fa fa-trash-alt', message:'Carácter Individual eliminado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#EliminarCaracterI').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    //    SetScript(sc);
    //}

    protected void btnGuardarItem_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();

        poai_id.pu_id = Convert.ToInt32(p_pu_id.Value);
        poai_id.pu_poai_id = Convert.ToInt32(p_pu_poai_id.Value);
        poai_id.pu_nro_puesto = Convert.ToInt32(p_pu_nro_puesto.Value);
        poai_id.puesto = txt_nom_puesto_edit.Text.ToUpper();
        poai_id.pu_pref_puesto = p_pu_pref_puesto.Value;

        poai_id.objetivo = txt_objetivo_edit.Text.ToUpper();
        poai_id.pu_id_puesto_anterior = Convert.ToInt32(p_pu_id_puesto_anterior.Value);

        string id = p_pu_poai_id.Value;

        if (poai_id.ActualizarItem()) poai_id.AdicionarItem();
        informacionItem(id);
        sc = "$.notify({ icon: 'fa fa-edit', message: 'Registro actualizado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#GuardarItem').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

        SetScript(sc);
    }

    protected void btnNuevaTarea_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        var id = Request.QueryString["id"].ToString();

        poai_id.tar_poai_id = Convert.ToInt32(id);
        poai_id.tar_descripcion = txt_descripcion_tarea_add.Text.ToUpper();
        poai_id.AdicionarTarea();

        listarTareas(id);
        LimpiarTarea();
        sc = "$.notify({ icon: 'fa fa-check', message: 'Registro añadido correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#NuevaTarea').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

        SetScript(sc);
    }

    private void LimpiarTarea()
    {
        txt_descripcion_tarea_add.Text = string.Empty;
    }

    protected void btnNuevoResultado_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        var id = Request.QueryString["id"].ToString();

        poai_id.res_poai_id = Convert.ToInt32(id);
        var sumaPuntaje = poai_id.ObtenerSumaPuntaje();
        ////int puntajeTotal = 0;

        ////if (sumaPuntaje.Tables[0].Rows[0]["puntajeTotal"].ToString() != "")
        ////{
        ////    puntajeTotal = Convert.ToInt32(sumaPuntaje.Tables[0].Rows[0]["puntajeTotal"]);
        ////}

        ////int puntajeDifUso = 70 - puntajeTotal;
        ////int puntajeN = Convert.ToInt32(txt_puntaje_add.Text);
        ////if (puntajeN <= puntajeDifUso)
        ////{
            poai_id.res_poai_id = Convert.ToInt32(id);
        poai_id.res_descripcion =  txt_descripcion_add.Text.ToUpper();
        poai_id.res_indicador = "0";// txt_indicador_add.Text.ToUpper();
        poai_id.res_puntaje = 0;// Convert.ToInt32(txt_puntaje_add.Text);

            poai_id.Adicionar();

            LimpiarResultados();
            listarResultadosEsp(id);
            sc = "$.notify({ icon: 'fas fa-check-circle', message: 'Registro Exitoso'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#NuevoResultado').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc);
        ////}
        ////else
        ////{
        ////    sc = "$.notify({ icon: 'fas fa-times-circle', message: 'El puntaje del resultado es mayor al máximo ponderado.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
        ////    SetScript(sc);
        ////}
        //**//
        ////int total_ptje = 0;
        ////foreach (GridViewRow row in gvResultadosEsp.Rows)
        ////{
        ////    for (int i = 0; i < gvResultadosEsp.Columns.Count; i++)
        ////    {
        ////        if (i == 2)
        ////        {
        ////            int ptje = Convert.ToInt32(row.Cells[i].Text);
        ////            total_ptje = total_ptje + ptje;
        ////        }

        ////    }
        ////}

        ////txtsuma.Text = "PUNTAJE TOTAL:  " + total_ptje.ToString();
        ////if (total_ptje < 70)
        ////{
        ////    sc = "$.notify({ icon: 'fas fa-times-circle', message: 'La suma de los puntajes registrados debe ser igual a 70.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
        ////    SetScript(sc);
        ////    txtsuma.ForeColor = System.Drawing.Color.Red;
        ////}
        ////else
        ////{
        ////    txtsuma.ForeColor = System.Drawing.Color.Black;
        ////}

    }

    private void LimpiarResultados()
    {
        txt_descripcion_add.Text = string.Empty;
        txt_indicador_add.Text = string.Empty;
        txt_puntaje_add.Text = string.Empty;
    }

    //protected void btnNuevaDisposicionJuridica_Click(object sender, EventArgs e)
    //{
    //    poai_id = new cls_mdp_resultados_especificos();
    //    var id = Request.QueryString["id"].ToString();

    //    poai_id.idj_poai_id = Convert.ToInt32(id);
    //    poai_id.idj_dj_id = Convert.ToInt32(ddl_disposicion_juridica.SelectedValue);

    //    poai_id.AdicionarDisposicion();

    //    listarDisposiciones(id);
    //    listaFiltradoDisposicion(id);

    //    sc = "$.notify({ icon: 'fa fa-check', message: 'Disposición Jurídica añadida correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#NuevaDisposicion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    //    SetScript(sc);
    //}

    protected void btnNuevoConocimiento_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        var id = Request.QueryString["id"].ToString();

        poai_id.ico_poai_id = Convert.ToInt32(id);
        poai_id.ico_co_id = Convert.ToInt32(ddl_conocimineto_add.SelectedValue);

        poai_id.AdicionarConocimiento();

        listarConocimientosComp(id);
        listaFiltradoConcocimiento(id);

        sc = "$.notify({ icon: 'fa fa-check', message: 'Conocimiento Complementario añadido correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#NuevaConocimiento').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }


    //protected void btnGuardarCaracterInvAdd_Click(object sender, EventArgs e)
    //{
    //    poai_id = new cls_mdp_resultados_especificos();
    //    var id = Request.QueryString["id"].ToString();

    //    poai_id.ici_poai_id = Convert.ToInt32(id);
    //    poai_id.ici_ci_id = Convert.ToInt32(ddl_caracter_individual.SelectedValue);
    //    switch (ddl_categoria.SelectedValue)
    //    {
    //        case "0":
    //            poai_id.ici_cat_abreviacion = "A";
    //            break;
    //        case "1":
    //            poai_id.ici_cat_abreviacion = "B";
    //            break;
    //        case "2":
    //            poai_id.ici_cat_abreviacion = "C";
    //            break;
    //        case "3":
    //            poai_id.ici_cat_abreviacion = "D";
    //            break;
    //        case "4":
    //            poai_id.ici_cat_abreviacion = "E";
    //            break;
    //        case "5":
    //            poai_id.ici_cat_abreviacion = "F";
    //            break;
    //        case "6":
    //            poai_id.ici_cat_abreviacion = "G";
    //            break;
    //        case "7":
    //            poai_id.ici_cat_abreviacion = "H";
    //            break;
    //        default:
    //            break;
    //    }

    //    poai_id.AdicionarCaracterIndividual();

    //    listarCaracterIndividual(id);
    //    listaFiltradoCaracterIndividual(id);

    //    sc = "$.notify({ icon: 'fas fa-check-circle', message: 'Registro Exitoso'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#NuevaCaracter').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";

    //    SetScript(sc);
    //}

    protected void ModalGuardarItem_Click(object sender, EventArgs e)
    {
        sc = "$('#GuardarItem').modal('show');";
        SetScript(sc);
    }

    protected void ModalGuardarRespons_Click(object sender, EventArgs e)
    {
        sc = "$('#GuardarResponsabilidades').modal('show');";
        SetScript(sc);
    }

    protected void ModalGuardarRequisito_Click(object sender, EventArgs e)
    {
        sc = "$('#GuardarFormacion').modal('show');";
        SetScript(sc);
    }

    protected void ModalAddTarea_Click(object sender, EventArgs e)
    {
        sc = "$('#NuevaTarea').modal('show');";
        SetScript(sc);
    }

    protected void ModalAddResultado_Click(object sender, EventArgs e)
    {
        poai_id = new cls_mdp_resultados_especificos();
        var id = Request.QueryString["id"].ToString();
        poai_id.res_poai_id = Convert.ToInt32(id);
        ////var sumaPuntaje = poai_id.ObtenerSumaPuntaje();

        ////int puntajeTotal = 0;

        ////if (sumaPuntaje.Tables[0].Rows[0]["puntajeTotal"].ToString().Trim() != null && sumaPuntaje.Tables[0].Rows[0]["puntajeTotal"].ToString().Trim() != "")
        ////{
        ////    puntajeTotal = Convert.ToInt32(sumaPuntaje.Tables[0].Rows[0]["puntajeTotal"]);
        ////}

        ////if (puntajeTotal < 70)
        ////{
           sc = "$('#NuevoResultado').modal('show');";
           SetScript(sc);
        ////}
        ////else
        ////{
        ////    sc = "$.notify({ icon: 'fas fa-times-circle', message: 'No puede asignar nuevos resultados, la suma máxima ponderada es de 70 puntos.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
        ////    SetScript(sc);
        ////}
    }

    protected void ModalAddCaracteristica_Click(object sender, EventArgs e)
    {
        sc = "$('#NuevaCaracter').modal('show');";
        SetScript(sc);
    }

    protected void ModalAddConocimiento_Click(object sender, EventArgs e)
    {
        sc = "$('#NuevaConocimiento').modal('show');";
        SetScript(sc);
    }

    protected void ModalAddDisposicion_Click(object sender, EventArgs e)
    {
        sc = "$('#NuevaDisposicion').modal('show');";
        SetScript(sc);
    }

    private void listarSupervisionEjercida(string id)
    {
        try
        {
            poai_id = new cls_mdp_resultados_especificos();
            gv_supervision_ejer.DataSource = poai_id.ObtenerGrillaSupervision(id);
            gv_supervision_ejer.DataBind();

            if (gv_supervision_ejer.Rows.Count == 0)
            {
                sc = "document.onreadystatechange = function () { setTimeout(function() { document.getElementById('load').style.display = 'none'; $('#supervision').css('display', 'none'); }, 0);};";
                SetScript(sc);
            }



        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_supervision_ejer_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_supervision_ejer.Rows.Count > 0)
        {
            if (gv_supervision_ejer.HeaderRow != null)
            {
                gv_supervision_ejer.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_supervision_ejer.FooterRow != null)
            {
                gv_supervision_ejer.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void btn_reporte_Click(object sender, EventArgs e)
    {
        sc = "$('#load').css('display', 'block'); console.log('VerMascarReporte');";
        SetScript(sc);
        Session["idFicha"] = Request.QueryString["id"].ToString();
        Response.Redirect("Reportes/Reporte_POAI.aspx");
    }

    ////protected void btn_validar_ptje_final_Click(object sender, EventArgs e)
    ////{
    ////    int total_ptje = 0;
    ////    foreach (GridViewRow row in gvResultadosEsp.Rows)
    ////    {
    ////        for (int i = 0; i < gvResultadosEsp.Columns.Count; i++)
    ////        {
    ////            if (i == 2)
    ////            {
    ////                int ptje = Convert.ToInt32(row.Cells[i].Text);
    ////                total_ptje = total_ptje + ptje;
    ////            }

    ////        }
    ////    }

    ////    if (total_ptje < 70)
    ////    {
    ////        sc = "$.notify({ icon: 'fas fa-times-circle', message: 'La suma de los puntajes registrados debe ser igual a 70.'},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
    ////        SetScript(sc);
    ////    } else
    ////    {
    ////        sc = "$.notify({ icon: 'fa fa-check', message: 'La suma de los resultados específicos ha sido validado correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#EditarResultado').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    ////        SetScript(sc);
    ////    }

    ////}

    protected void btn_cerrar_Click(object sender, EventArgs e)
    {
        //sc = "window.close();";
        //SetScript(sc);
        Response.Redirect("frmpuestos.aspx");
    }

    protected void btn_siguiente_item_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        poai_id = new cls_mdp_resultados_especificos();
        poai_id.res_poai_id = Convert.ToInt32(id); 
        var poai = poai_id.ObtenerSiguienteItem();

        string poai_id_sig = "";
        if (poai.Tables[0].Rows.Count > 0)
        {
            if (poai.Tables[0].Rows[0]["poai_id"] != DBNull.Value && poai.Tables[0].Rows[0]["poai_id"].ToString().Trim() != "") { poai_id_sig = Convert.ToString(poai.Tables[0].Rows[0]["poai_id"]); }
        }
        if (poai_id_sig != "")
        {
            Response.Redirect("ItemDetalle?id=" + poai_id_sig);
        } else
        {
            sc = "$.notify({ icon: 'fas fa-times-circle', message: 'No existe el siguiente ítem. '},{type: 'danger', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

    }

    protected void btn_new_search_Click(object sender, EventArgs e)
    {
        sc = "$('#load').css('display', 'block'); console.log('VerMascarReporte');";
        SetScript(sc);
        Session["idFicha"] = Request.QueryString["id"].ToString();
        Response.Redirect("ItemBusqueda");
    }
    private void visualizarBoton()
    {
        var intervalo = HttpContext.Current.Session["intervalo"];
        bool siguiente = Convert.ToBoolean(intervalo);
        if (siguiente)
        {
            block_siguiente.Visible = true;
            block_finalizar.Visible = false;// false;
        } else
        {
            block_siguiente.Visible = false;
            block_finalizar.Visible = true;
        }
        //btn_new_search.Visible = true;
    }

    protected void ModalGuardarNomPuesto_Click(object sender, EventArgs e)
    {
        //poai_id = new cls_mdp_resultados_especificos();

        //poai_id.pu_id = Convert.ToInt32(p_pu_id.Value);
        //poai_id.pu_poai_id = Convert.ToInt32(p_pu_poai_id.Value);
        //poai_id.pu_nro_puesto = Convert.ToInt32(p_pu_nro_puesto.Value);
        //poai_id.puesto = txt_nom_puesto_edit.Text.ToUpper();
        //poai_id.pu_pref_puesto = p_pu_pref_puesto.Value;

        //poai_id.objetivo = txt_objetivo_edit.Text.ToUpper();
        //poai_id.pu_id_puesto_anterior = Convert.ToInt32(p_pu_id_puesto_anterior.Value);
        

        //string id = p_pu_poai_id.Value;

        //if (poai_id.ActualizarItem()) poai_id.AdicionarItem();
        //informacionItem(id);
        //sc = "$.notify({ icon: 'fa fa-edit', message: 'Registro actualizado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#GuardarItem').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        //SetScript(sc);
        // sc = "$('#Ddl_gl_tipo_doc').removeClass('select2'); $('#glosaModal').modal('show');";
        // SetScript(sc, ", dropdownParent: $('#glosaModal')");
        BindDDLTipoDocumentoImpreso();
        //Ddl_gl_tipo_doc.SelectedValue = "1914";
        Ddl_gl_tipo_doc.Enabled = true;
        sc = "$('#Txt_gl_fecha_doc').addClass('form-control'); $('#Ddl_gl_tipo_doc').removeClass('select2'); $('#glosaModal').modal('show');";
        SetScript(sc);
    }
    // alta glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        //poai_id = new cls_mdp_resultados_especificos();
        //var id = Request.QueryString["id"].ToString();
        //poai_id.ObtenerFicha(id);
        poai_id = new cls_mdp_resultados_especificos();

        poai_id.pu_id = Convert.ToInt32(p_pu_id.Value);
        poai_id.pu_poai_id = Convert.ToInt32(p_pu_poai_id.Value);
        poai_id.pu_nro_puesto = Convert.ToInt32(p_pu_nro_puesto.Value);
        poai_id.puesto = txt_nom_puesto_edit.Text.ToUpper();
        poai_id.pu_pref_puesto = p_pu_pref_puesto.Value;

        poai_id.objetivo = txt_objetivo_edit.Text.ToUpper();
        poai_id.pu_id_puesto_anterior = Convert.ToInt32(p_pu_id_puesto_anterior.Value);
        


        string id = p_pu_poai_id.Value;

        if (poai_id.BusquedaPuestoMP())//.ActualizarItem()) poai_id.AdicionarItem();
        informacionItem(id);

        //if (poai_id.ActualizarItem()) poai_id.AdicionarItem();
        //informacionItem(id);

        _glosa = new cls_glosa
        {
            gl_valor_pk = Convert.ToString(poai_id.pu_id), //_cs_id.ToString(),
            gl_nombre_pk = "pu_id",
            gl_tabla = "tbl_mdp_puestos",
            gl_tipo_mov = 815,//////813,
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
        };
        _glosa.Adicionar();

        Limpiar("frm_glosa_cl");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
        SetScript(sc);
    }
    // cargar gl_tipo_doc
    private void BindDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_id";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }
    private void Limpiar(string val)
    {
        if (val.Equals("frm_glosa_cl"))
        { 
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        BindDDLTipoDocumentoImpreso();
        }

    }
    // cancelar alta glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        txt_nom_puesto_edit.Text = "";

        poai_id = new cls_mdp_resultados_especificos();
        var id = Request.QueryString["id"].ToString();
        poai_id.ObtenerFicha(id);
        txt_nom_puesto_edit.Text = poai_id.puesto.ToString();
        //        txt_nom_puesto_edit.Text = poai_id.puesto.ToString();
        //sc = "$('#glosaModal').modal('hide');";
        // sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');"; //"$.notify( $('#glosaModal').modal('hide');";
        SetScript(sc);
        /**/

    }
}
