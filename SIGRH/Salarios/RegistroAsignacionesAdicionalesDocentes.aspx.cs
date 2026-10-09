using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Salarios_RegistroAsignacionesAdicionalesDocentes : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_pla_cas _cas = null;
    private cls_glosa _glosa = null;
    private string sc = "";
    private cls_mp_cargo _cargo = null;
    public string nodo_seleccionado = "";
    public double iue;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (HttpContext.Current.Session["per_id_asignacion_adicional_docentes"] != null && HttpContext.Current.Session["per_id_asignacion_adicional_docentes"].ToString() != "")
            {
                CargarIUE();
                if (!Page.IsPostBack)
                {
                    BindArbolAreasAcademicas();
                    BindForm(HttpContext.Current.Session["per_id_asignacion_adicional_docentes"].ToString());
                    BindGridView(HttpContext.Current.Session["per_id_asignacion_adicional_docentes"].ToString());
                    CargarInfo();
                    if (GvLista.Rows.Count > 0) { P_lista.Visible = true; }
                    else { P_lista.Visible = false; }
                }
            }
        }
        else Response.Redirect("../Index");
    }
    
    protected void CargarInfo() {
        cls_pla_docentes_adicional docentes = new cls_pla_docentes_adicional();
        ddlAsignacion.DataSource = docentes.ObtenerAsignacionAdicionalDocentes();
        ddlAsignacion.DataTextField = "cat_descripcion";
        ddlAsignacion.DataValueField = "cat_abreviacion";
        ddlAsignacion.DataBind();

        ddlPeriodo.DataSource = docentes.ObtenerPeriodoAsignacionesAdicionales();
        ddlPeriodo.DataTextField = "cat_descripcion";
        ddlPeriodo.DataBind();
    }
    protected void CargarIUE()
    {
        cls_pla_factor factor = new cls_pla_factor();
        DataSet ds = factor.ObtenerTablaGrilla("", "I.U.E.", "", "", "", "", "V");
        if (ds.Tables[0].Rows.Count > 0)
            iue = Convert.ToDouble(ds.Tables[0].Rows[0]["fa_valor"].ToString());
    }
    private void BindArbolAreasAcademicas() {
        ListarNivelOrg();
    }
    // Valida Nodos Lista Nivel Organizacional
    private void validarNodo(TreeNode parentNode, TreeNode childNode)
    {
        if (parentNode.ChildNodes.Count > 0)
        {
            bool sw = false;

            foreach (TreeNode childNodesParent in parentNode.ChildNodes)
            {
                if (childNodesParent.Value != childNode.Value) { sw = true; }
                else
                {
                    sw = false;
                    break;
                }
            }

            if (sw) { Tv_nivelOrg.SelectedNode.ChildNodes.Add(childNode); }
        }
        else { Tv_nivelOrg.SelectedNode.ChildNodes.Add(childNode); }
    }
    // Cierra Modal Nivel Organizacional
    protected void BtnCancelarI_Click(object sender, EventArgs e)
    {
        sc = "$('#itemModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#glosaModal').modal('show');";
        SetScript(sc, "");
    }
    // Carga Datos Nivel Organizacional
    protected void tv_nivelOrg_SelectedNodeChanged(object sender, EventArgs e)
    {
        int _val_id =  Convert.ToInt32(Tv_nivelOrg.SelectedNode.Value);
        string gestionFiltrar = Session["pr_id"].ToString();
        _cargo = new cls_mp_cargo
        {
            ca_id = _val_id,
            eo_id = _val_id,
            gestion_selec = gestionFiltrar
        };
        var nivelOrg = _cargo.ObtenerNivelOrg().Tables[0];
        var dataIC = _cargo.ObtenerGrillaItemsCP().Tables[0];

        //string ti_item = Hf_ca_id.Value;
        var dataDI = _cargo.ObtenerDetalleItemCP().Tables[0];

        if (nivelOrg.Rows.Count > 0)
        {
            foreach (DataRow lvlNDataRow in nivelOrg.Rows)
            {
                TreeNode childNode = new TreeNode();
                childNode.Value = lvlNDataRow["eo_id"].ToString();
                nodo_seleccionado = lvlNDataRow["eo_descripcion"].ToString();
                childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0 desc-treeview'>" + lvlNDataRow["eo_descripcion"].ToString().Trim() + " <small class='ls-1 mb-1 text-muted'>" + lvlNDataRow["cp_da"].ToString().Trim() + " - " + lvlNDataRow["cp_ue"].ToString().Trim() + " - " + lvlNDataRow["cp_programa"].ToString().Trim() + " - " + lvlNDataRow["cp_proyecto"].ToString().Trim() + " - " + lvlNDataRow["cp_actividad"].ToString().Trim() + " (" + lvlNDataRow["cp_fuente"].ToString().Trim() + " - " + lvlNDataRow["cp_organismo"].ToString().Trim().Trim() + ")</small></h6></div></div>";
                TreeNode parentNode = Tv_nivelOrg.SelectedNode;
                validarNodo(parentNode, childNode);
            }
        }
        else { sc = "$.notify({ icon: 'ni ni-bell-55', message: 'No existe subniveles para la Unidad Organizacional seleccionada...!!' }, { type: 'info', placement: { from: 'bottom', align: 'right'} });"; }

        //if (dataIC.Rows.Count > 0)
        //{
        //    foreach (DataRow lvlNDataRow in dataIC.Rows)
        //    {
        //        TreeNode childNode = new TreeNode();
        //        childNode.Value = lvlNDataRow["ca_id"].ToString();
        //        childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-child-treeview mr-2'><i class='fas fa-briefcase'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + lvlNDataRow["ca_ti_item"].ToString().Trim() + "-" + lvlNDataRow["ca_num_item"].ToString().Trim() + " (" + lvlNDataRow["es_descripcion"].ToString().Trim() + ")</h6></div></div>";
        //        TreeNode parentNode = Tv_nivelOrg.SelectedNode;
        //        validarNodo(parentNode, childNode);
        //    }
        //}
        Tv_nivelOrg.SelectedNode.Expand();

        if (dataDI.Rows.Count > 0)
        {
            var id = Request.QueryString["id"].ToString();
            var tipo_ig = dataDI.Rows[0]["ti_tipo_item_gral"].ToString();
            _asignacion = new cls_mp_asignacion { as_per_id = Convert.ToInt32(id) };
            var dataPRE = _asignacion.ObtenerPuestoPreContrato().Tables[0];
            //BindItem(dataDI);
            //Limpiar("frm_item");
            sc = "$.notify({ icon: 'fas fa-check', message: 'El ítem fue seleccionado correctamente...!!' }, { type: 'success' }); $('#itemModal').modal('hide');";


        }
        SetScript(sc, "");
    }
    // Ejecuta Scripts
    private void SetScript(string data, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: 'es'" +
                    "});" +
                "});" +
                "var me = $(\".datepickerD\");" +
                "me.mask('99/99/9999');" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Lista Nivel Organizacional
    private void ListarNivelOrg()
    {
        cls_pla_docentes_adicional docentes = new cls_pla_docentes_adicional();
        string gestionFiltrar = Session["pr_id"].ToString();

        try
        {
            _cargo = new cls_mp_cargo
            {
                eo_id = Convert.ToInt32(docentes.ObtenerIdEstructuraBaseParaAsignacionesadicionalesDocentes()),
                gestion_selec = gestionFiltrar
            };
            var nivelOrg = _cargo.ObtenerNivelOrg().Tables[0];

            foreach (DataRow level1DataRow in nivelOrg.Rows)
            {
                string eo_id = level1DataRow["eo_id"].ToString();

                if (eo_id != "")
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Value = level1DataRow["eo_id"].ToString();
                    treeNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + level1DataRow["eo_descripcion"].ToString() + "</h6></div></div>";
                    Tv_nivelOrg.Nodes.Add(treeNode);
                }
            }
        }
        catch (Exception e) { Console.Error.Write(e.Message); }
    }
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("GetDelete"))
        {
            hdf_td_id.Value = GvLista.DataKeys[Convert.ToInt32(e.CommandArgument)]["td_id"].ToString();
            sc = "$('#eliminarAsignacionAdicional').modal('show');";
            SetScript(sc, "");
        }
    }
    // Cargar GridView
    private void BindGridView(string per_id)
    {
        try
        {
            cls_pla_docentes_adicional adicional = new cls_pla_docentes_adicional();
            adicional.td_per_id = Convert.ToInt32(per_id);
            DataSet ds = adicional.ListarAsignacionesAdicionalesDocentes(adicional);
            if (ds.Tables[0].Rows.Count > 0)
            {
                P_lista.Visible = true;
                GvLista.DataSource = ds;
                GvLista.DataBind();
            }
            else P_lista.Visible = false;
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }
    private void BindForm(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (var_datos_as_c.Rows.Count > 0)
        {
            Lt_per_id.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_id"]);
            Lt_per_nombres.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_nombres"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_num_doc"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["cat_abreviacion"]);
            Lt_ca_num_item.Text = ValidarCampo(var_datos_as_c.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["ca_num_item"]);
            Lt_ca_basico_calculado.Text = Convert.ToDouble(ValidarCampo(var_datos_as_c.Rows[0]["ca_basico_calculado"])).ToString("N");
            Lt_es_escalafon.Text = ValidarCampo(var_datos_as_c.Rows[0]["es_escalafon"]);
            Lt_ns_clase.Text = ValidarCampo(var_datos_as_c.Rows[0]["ns_clase"]);
            Lt_ns_nivel.Text = ValidarCampo(var_datos_as_c.Rows[0]["ns_nivel"]);
            Lt_as_fecha_inicio.Text = Convert.ToDateTime(ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_inicio"])).ToString("dd/MM/yyyy");
            Lt_as_fecha_fin.Text = (ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_fin"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(var_datos_as_c.Rows[0]["as_fecha_fin"])).ToString("dd/MM/yyyy");
            Lt_es_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["es_descripcion"]);
            Lt_p_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["p_descripcion"]);
            Lt_eo_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["eo_descripcion"]);
            Lt_eo_prog.Text = ValidarCampo(var_datos_as_c.Rows[0]["eo_prog"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_sprog"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_proy"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_obract"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_unidad"]);
            Lt_cp_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["cp_descripcion"]);
            Lt_cp_da.Text = ValidarCampo(var_datos_as_c.Rows[0]["cp_da"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_ue"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_programa"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_proyecto"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_actividad"]);
            ltl_jornada.Text = ValidarCampo(var_datos_as_c.Rows[0]["ca_tipo_jornada_lit"]);

            if (ValidarCampo(var_datos_as_c.Rows[0]["as_estado"]).Equals("V"))
            {
                Lbl_as_estado.Text = "Vigente";
                Lbl_as_estado.CssClass = "btn btn-sm btn-info float-right";
            }
            else
            {
                Lbl_as_estado.Text = "Pasivo";
                Lbl_as_estado.CssClass = "btn btn-sm btn-secondary float-right";
            }

            if (ValidarCampo(var_datos_as_c.Rows[0]["fp_foto"]) != "") Img_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])var_datos_as_c.Rows[0]["fp_foto"]);
            else if (ValidarCampo(var_datos_as_c.Rows[0]["per_sexo"]).Equals("M")) Img_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg";
            else Img_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg";
        }
    }
    // Validar Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) campo = p_campo.ToString().Trim();
        return campo;
    }
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) GvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvLista.FooterRow != null) GvLista.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }
  
    protected void btnEscogerAreaAcademica_Click(object sender, EventArgs e)
    {
        cls_mp_estructura_organizacional estructura = new cls_mp_estructura_organizacional();
        DataSet ds = estructura.ObtenerRegistroX(Convert.ToInt32(Tv_nivelOrg.SelectedNode.Value));
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtAreaAcademica.Text = ds.Tables[0].Rows[0]["eo_descripcion"].ToString();
            hdf_eo_id.Value= ds.Tables[0].Rows[0]["eo_id"].ToString();
            sc = "$('#itemModal').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#glosaModal').modal('show');";
            SetScript(sc, "");
        }
    }

    protected void btnAbrirArbol_Click(object sender, EventArgs e)
    {
        sc = "$('#itemModal').modal('show');";
        SetScript(sc, "");
    }

    protected void txtTotalGanado_TextChanged(object sender, EventArgs e)
    {
        txtIUE.Text = Math.Round(iue * Convert.ToDouble(txtTotalGanado.Text), 2).ToString();
    }
    protected void Limpiar(){
        ddlAsignacion.SelectedIndex = -1;
        txtHoras.Text = "";
        txtTotalGanado.Text = "";
        txtFechaInicio.Text= "";
        txtFechaFin.Text = "";txtIUE.Text = "";
        txtDescuentosAsistencia.Text = "";
        txtOtrosDescuentos.Text = "";
        ddlPeriodo.SelectedIndex = -1;
        txtGlosa.Text = "";
        P_lista.Visible = false;
        DivInfo.Visible = false;
    }
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        cls_pla_docentes_adicional docentes = new cls_pla_docentes_adicional();
        docentes.td_per_id = Convert.ToInt32(HttpContext.Current.Session["per_id_asignacion_adicional_docentes"].ToString());
        if (ddlAsignacion.SelectedItem.Text == "EXAMEN DE MESA") docentes.td_tipo_docente = "MESA";
        if (ddlAsignacion.SelectedItem.Text == "CURSO DE TEMPORADA") docentes.td_tipo_docente = "CURSO";
        docentes.td_eo_id = Convert.ToInt32(hdf_eo_id.Value);
        docentes.td_carrera = txtAreaAcademica.Text;
        docentes.td_fecha_inicio = Convert.ToDateTime(txtFechaInicio.Text);
        docentes.td_fecha_fin = Convert.ToDateTime(txtFechaFin.Text);
        docentes.td_horas = Convert.ToInt32(txtHoras.Text);
        docentes.td_total_ganado = Convert.ToDouble(txtTotalGanado.Text);
        docentes.td_iue = Convert.ToDouble(txtIUE.Text);
        if (txtDescuentosAsistencia.Text == "") docentes.td_desc_asistencia = 0;
        if (txtOtrosDescuentos.Text == "") docentes.td_desc_otros = 0;
        docentes.td_periodo = ddlPeriodo.SelectedItem.Text; // txtPeriodo.Text;
        ////docentes.td_fecha_proceso = null;
        docentes.td_glosa = txtGlosa.Text;
        if (docentes.AdicionarAsignacionAdicionalDocentes(docentes))
        {
            sc = "$.notify({ icon: 'fas fa-check', message: 'Se asignó correctamente el registro...!!' }, { type: 'success' });";
            SetScript(sc,"");
            Limpiar();
        }

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
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_transaccion').select2({ placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_aporte').select2({ placeholder: { id: '-1', text: 'Seleccione...' } });");
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

    protected void btnEliminarAsignacionAdicional_Click(object sender, EventArgs e)
    {
        cls_pla_docentes_adicional adicional = new cls_pla_docentes_adicional();
        if (adicional.EliminarAsignacionAdicional(Convert.ToInt32(hdf_td_id.Value)))
        {
            BindGridView(HttpContext.Current.Session["per_id_asignacion_adicional_docentes"].ToString());
            sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Registro eliminado correctamente'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });$('#eliminarAsignacionAdicional').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc);
        }
    }
}