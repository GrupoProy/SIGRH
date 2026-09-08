using Newtonsoft.Json;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_BolsaTrabajo.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class Administración_Categorias : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null)
        {
            if (HttpContext.Current.Session["per_id"].ToString() != "")
            {

                if (!Page.IsPostBack)
                {
                    listarNivelOrg();
                    listarCategorias();
                }
            }
            else
            {
                Response.Redirect("../index");
            }
        }
        else
        {
            Response.Redirect("../index");
        }

    }

    private void listarCategorias() {
        ddlCategorias.Items.Clear();
        cls_mp_categoria_programatica categorias = new cls_mp_categoria_programatica();
        categorias.cp_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        DataSet ds= categorias.ObtenerTablaComboUE();
        ddlCategorias.Items.Add("Seleccione la Categoría...");
        ddlCategorias.DataSource = categorias.ObtenerTablaComboUE();
        ddlCategorias.DataValueField = "cp_ue";
        ddlCategorias.DataTextField = "cp_descripcion";
        ddlCategorias.DataBind();
        ddlCategorias.Enabled = false;

 
    }
    private void listarNivelOrg()
    {
        //string gestionFiltrar = obtenerGestion();
        tv_nivelOrg.Nodes.Clear();
        try
        {
            cargo = new cls_mp_cargo();
            cargo.eo_id = 0;
            cargo.gestion_selec = Session["pr_id"].ToString();
            var nivelOrg = cargo.ObtenerNivelOrg();

            foreach (DataRow level1DataRow in nivelOrg.Tables[0].Rows)
            {
                string eo_id = level1DataRow["eo_id"].ToString();
                if (eo_id != "")
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Value = level1DataRow["eo_id"].ToString();

                    treeNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + level1DataRow["eo_descripcion"].ToString() + "</h6></div></div>";
                    tv_nivelOrg.Nodes.Add(treeNode);
                }
            }
            tv_nivelOrg.ExpandAll();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void BtnGuardarF_Click(object sender, EventArgs e)
    {
        cls_mp_estructura_organizacional estructura = new cls_mp_estructura_organizacional();
        estructura.eo_id = 0;
        estructura.eo_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        estructura.eo_cp_id = 0;
        estructura.eo_prog = 0;
        estructura.eo_proy = 0;
        estructura.eo_obract = 0;
        estructura.eo_unidad = 0;
        estructura.eo_descripcion = txt_nodo_descripcion.Text;
        estructura.eo_estado = "V";

        if (lblNodo.Text=="")
            estructura.eo_cod_superior = 0;
        else
            estructura.eo_cod_superior = Convert.ToInt32(tv_nivelOrg.SelectedValue);
        if (estructura.Adicionar())
        {
            //sc = "javascript: window.alert('Se registró correctamente la estructura...');";
            sc = "$.notify({ icon: 'fa fa-check', message: 'Se registró correctamente la estructura...'},{type: 'success', placement: { from: 'bottom', align: 'right'} });";

            txt_nodo_descripcion.Text = "";
            listarNivelOrg();
            listarCategorias();
            SetScript(sc, "");
        }
    }
    private void validarNodo(TreeNode parentNode, TreeNode childNode)
    {
        if (parentNode.ChildNodes.Count > 0)
        {
            bool sw = false;
            foreach (TreeNode childNodesParent in parentNode.ChildNodes)
            {
                if (childNodesParent.Value != childNode.Value)
                {
                    //tv_nivelOrg.SelectedNode.ChildNodes.Add(childNode);
                    sw = true;
                }
                else
                {
                    sw = false;
                    break;
                }
            }
            if (sw)
            {
                tv_nivelOrg.SelectedNode.ChildNodes.Add(childNode);
            }
        }
        else
        {
            tv_nivelOrg.SelectedNode.ChildNodes.Add(childNode);
        }
    }
    protected void tv_nivelOrg_SelectedNodeChanged(object sender, EventArgs e)
    {
        btnEditar.Enabled = true;
        cls_mp_estructura_organizacional estructura = new cls_mp_estructura_organizacional();
        
        lblNodo.Text = tv_nivelOrg.SelectedNode.Text;
        lblNodo.Visible = true;
        int eo_id = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);

        string gestionFiltrar = Session["pr_id"].ToString();
        cargo = new cls_mp_cargo();
        cargo.eo_id = eo_id;
        cargo.gestion_selec = gestionFiltrar;
        var nivelOrg = cargo.ObtenerNivelOrg();
        var desc_est = cargo.ObtenerDescripcionNivelOrg();
        var nivelOrgItems = cargo.ObtenerNivelOrgItems();
        var detalleItem = cargo.ObtenerDetalleitem();

        estructura.eo_id = eo_id;
        string cp_id = estructura.ObtenerCpId().Tables[0].Rows[0][0].ToString();
        if (cp_id!="" && cp_id!="0")
            ddlCategorias.SelectedValue = cp_id;
        else
        {
            listarCategorias();
            ddlCategorias.SelectedIndex = 0;
        }
        //DataRow[] level2DataRows = level1DataRow.GetChildRows("ChildRows");
        if (desc_est.Tables[0].Rows.Count > 0)
        {

        }
        if (nivelOrg.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow lvlNDataRow in nivelOrg.Tables[0].Rows)
            {
                TreeNode childNode = new TreeNode();
                childNode.Value = lvlNDataRow["eo_id"].ToString();

                childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0 desc-treeview'>" + lvlNDataRow["eo_descripcion"].ToString() +
                " <small class='ls-1 mb-1 text-muted'>" + lvlNDataRow["cp_da"].ToString() + " - " + lvlNDataRow["cp_ue"].ToString() + " - " + lvlNDataRow["cp_programa"].ToString() + " - " + lvlNDataRow["cp_proyecto"].ToString() + " - " + lvlNDataRow["cp_actividad"].ToString() +
                " (" + lvlNDataRow["cp_fuente"].ToString() + " - " + lvlNDataRow["cp_organismo"].ToString().Trim() + ")</small></h6></div></div>";

                TreeNode parentNode = tv_nivelOrg.SelectedNode;
                validarNodo(parentNode, childNode);


            }
        }
        else
        {
            sc = "$.notify({ icon: 'ni ni-bell-55', message: 'No existe subniveles para la Unidad Organizacional seleccionada.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc,"");
        }

        foreach (DataRow lvlNDataRow in nivelOrgItems.Tables[0].Rows)
        {
            TreeNode childNode = new TreeNode();

            if (lvlNDataRow["per_id"] != null && lvlNDataRow["per_id"].ToString() != "")
            {
                childNode.Value = lvlNDataRow["ca_id"].ToString();
                childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-child-treeview mr-2'><i class='fas fa-user'></i></div></div><div>" + lvlNDataRow["ca_ti_item"].ToString() + " - " + lvlNDataRow["ca_num_item"].ToString() + " CI: " + lvlNDataRow["per_num_doc"].ToString() + " " + lvlNDataRow["nombreFun"].ToString() + "</div></div>";

                TreeNode parentNode = tv_nivelOrg.SelectedNode;
                validarNodo(parentNode, childNode);
            }
            else
            {
                if (lvlNDataRow["ca_estado"] != null && lvlNDataRow["ca_estado"].ToString() != "" && lvlNDataRow["ca_estado"].ToString() == "L")
                {
                    childNode.Value = lvlNDataRow["ca_id"].ToString();
                    childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-child2-treeview mr-2'><i class='fas fa-user'></i></div></div><div>" + lvlNDataRow["ca_ti_item"].ToString() + " - " + lvlNDataRow["ca_num_item"].ToString() + " ACEFALIA" + "</div></div>";

                    TreeNode parentNode = tv_nivelOrg.SelectedNode;
                    validarNodo(parentNode, childNode);
                }
            }

        }
        ddlCategorias.Enabled = true;
        tv_nivelOrg.SelectedNode.Expand();

        tv_nivelOrg.SelectedNode.Checked = true;
    }

        protected void BtnCancelarF_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNodo').modal('hide');";
        SetScript(sc, "");
    }
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
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
                        "'sNext': '<i class=\"fas fa-angle-right\"></i>'," +
                        "'sPrevious': '<i class=\"fas fa-angle-left\"></i>'" +
                    "}," +
                    "'oAria': {" +
                        "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                        "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                "}," +
                "'ordering': false," +
                "'searching': true," +
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true" +
            "});");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
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


    protected void btnNuevoNodo_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNodo').modal('show');";
        SetScript(sc, ", dropdownParent: $('#modalNodo')");
    }

    protected void btnNuevaCategoria_Click(object sender, EventArgs e)
    {
        sc = "$('#modalCategorias').modal('show');";
        SetScript(sc, ", dropdownParent: $('#modalNodo')");

    }

    protected void btnCancelarCategoria_Click(object sender, EventArgs e)
    {
        sc = "$('#modalCategorias').modal('hide');";
        SetScript(sc, "");
    }

    protected void btnRegstrarCategoria_Click(object sender, EventArgs e)
    {
        cls_mp_categoria_programatica categorias = new cls_mp_categoria_programatica();
        categorias.cp_id = 0;
        categorias.cp_da = Convert.ToInt32(txtDA.Text);
        categorias.cp_da_descripcion = txtDaDescripcion.Text;
        categorias.cp_ue = Convert.ToInt32( txtUE.Text);
        categorias.cp_ue_descripcion = txtUEDescripcion.Text;
        categorias.cp_programa = Convert.ToInt32(txtProg.Text);
        categorias.cp_proyecto = txtProy.Text;
        categorias.cp_actividad = Convert.ToInt32(txtAct.Text);
        categorias.cp_cod_poa = 0;
        categorias.cp_descripcion = txtCategoria.Text;
        categorias.cp_estado = "V";
        categorias.cp_tipo_gasto = ddlTipoGasto.SelectedValue;
        categorias.cp_fuente = Convert.ToInt32(txtFuenteFinanciamiento.Text);
        categorias.cp_organismo = Convert.ToInt32(txtOrganismo.Text);
        categorias.cp_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        categorias.cp_fecha_modificacion = DateTime.Now;
        if(categorias.Adicionar())
        {
            sc = "$.notify({ icon: 'fa fa-check', message: 'Se registró correctamente la categoría...'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#modalCategorias').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false);";
            //sc = "javascript: window.alert('Se registró correctamente la categoría...'); $('#modalCategorias').modal('hide');";
        }
        listarNivelOrg();
        listarCategorias();
        SetScript(sc, "");
    }

    protected void ddlCategorias_SelectedIndexChanged(object sender, EventArgs e)
    {
        cls_mp_estructura_organizacional estructura = new cls_mp_estructura_organizacional();
        estructura.eo_cp_id = Convert.ToInt32( ddlCategorias.SelectedValue);
        estructura.eo_id = Convert.ToInt32(tv_nivelOrg.SelectedValue);
        if(estructura.Actualizar())
        {
            sc = "$.notify({ icon: 'fa fa-check', message: 'Se relacionó la unidad organizacional con la categoría programática...'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); ";

            SetScript(sc, "");
        }
        listarNivelOrg();
        listarCategorias();

    }

    protected void btnCancelarDependencia_Click(object sender, EventArgs e)
    {
        txt_nodo_descripcion.Text = "";
    }

    protected void btnRegistrarNuevoNodo_Click(object sender, EventArgs e)
    {
        cls_mp_estructura_organizacional estructura = new cls_mp_estructura_organizacional();
        estructura.eo_id = 0;
        estructura.eo_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        estructura.eo_cp_id = 0;
        estructura.eo_prog = 0;
        estructura.eo_proy = 0;
        estructura.eo_obract = 0;
        estructura.eo_unidad = 0;
        estructura.eo_descripcion = txtNuevoNodo.Text;
        estructura.eo_estado = "V";

            estructura.eo_cod_superior = 0;
        if (estructura.Adicionar())
        {
//            sc = "javascript: window.alert('Se registró correctamente la estructura...'); $('#modalNodo').modal('hide');";
            sc = "$.notify({ icon: 'fa fa-check', message: 'Se registró correctamente la estructura...'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#modalNodo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false);";

        }
        txt_nodo_descripcion.Text = "";
        listarNivelOrg();
        listarCategorias();
        SetScript(sc, "");

    }

    protected void btnEliminar_Click(object sender, EventArgs e)
    {

    }

    protected void btnEditar_Click(object sender, EventArgs e)
    {
        lblModificar.Text = tv_nivelOrg.SelectedNode.Text;
        sc = "$('#modalEditarEstructura').modal('show');";
        SetScript(sc, "");
    }


    protected void btnRegistrarUnidad_Click(object sender, EventArgs e)
    {
        cls_mp_estructura_organizacional estructura = new cls_mp_estructura_organizacional();
        int eo_id = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);


        estructura.eo_id = eo_id;
        string cp_id = estructura.ObtenerCpId().Tables[0].Rows[0][0].ToString();
        estructura.eo_cp_id = Convert.ToInt32(cp_id);
        estructura.eo_descripcion = txtNuevoNombreUnidad.Text;
        if (estructura.Actualizar())
        {
            tv_nivelOrg.SelectedNode.Expand();

            tv_nivelOrg.SelectedNode.Checked = true;

            sc = "$.notify({ icon: 'fa fa-check', message: 'Se modificó exitosamente el nombre de la Unidad Organizacional'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); $('#modalEditarEstructura').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); MostrarMascara(false);";

            SetScript(sc, "");
            txtNuevoNombreUnidad.Text = "";
            btnEditar.Enabled = false;
            listarNivelOrg();

        }
    }

    protected void btnCancelarUnidad_Click(object sender, EventArgs e)
    {
        sc = "$('#modalEditarEstructura').modal('hide'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }


}