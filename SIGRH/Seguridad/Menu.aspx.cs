using Solution_Framework_Seguridad.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Seguridad_Menu : System.Web.UI.Page
{
    private static cls_seg_menu _menu = null;
    private cls_seg_rol_menu _rol_menu = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                sc = "CopiarCortarPegar(true);";
                SetScript(sc);
                BindTreeView();
            }
        }
        else Response.Redirect("../Index");
    }

    // Cargar TreeView
    private void BindTreeView()
    {
        _menu = new cls_seg_menu();
        var data = _menu.ObtenerTablaGrilla("", "", "", "", "0", "V");
        TvMenu.Nodes.Clear();
        TreeNode tnRaiz = new TreeNode
        {
            Text = "<div class='d-flex align-items-center' data-toggle='tooltip' data-placement='top' title='Click para ver más opciones'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>SIGRH</h6></div></div>",
            Value = "GAMLP",
            Expanded = true
        };
        tnRaiz.SelectAction = TreeNodeSelectAction.Select;
        TvMenu.Nodes.Add(tnRaiz);
        TvMenu.ExpandDepth = 0;
        BindTreeNode(tnRaiz, data);
    }

    // Cargar Nodos TreeView
    private void BindTreeNode(TreeNode tn_padre, DataSet ds_menu)
    {
        foreach (DataRow item in ds_menu.Tables[0].Rows)
        {
            TreeNode tn_item = new TreeNode
            {
                Text = (item["me_id_padre"].ToString().Equals("0")) ? "<div class='d-flex align-items-center' data-toggle='tooltip' data-placement='top' title='Click para ver más opciones'><div><div class='badge badge-circle icon-treeview mr-2'><i class='" + item["me_icono"].ToString() + "'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + item["me_descripcion"].ToString() + "</h6></div></div>" :
                "<div class='d-flex align-items-center' data-toggle='tooltip' data-placement='top' title='Click para ver más opciones'><div><div class='badge badge-circle icon-child-treeview mr-2'><i class='" + item["me_icono"].ToString() + "'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + item["me_descripcion"].ToString() + "</h6></div></div>",
                Value = item["me_id"].ToString(),
                PopulateOnDemand = true
            };

            if (tn_padre == null) tn_padre.ChildNodes.Add(tn_item);
            else tn_padre.ChildNodes.Add(tn_item);
        }
    }

    // Agregar Nodos
    protected void TvMenu_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
        var id_val = e.Node.Value;
        var tn_sel = e.Node;
        _menu = new cls_seg_menu();

        if (id_val.Equals("GAMLP")) BindTreeView();
        else
        {
            var data = _menu.ObtenerTablaGrilla("", "", "", "", id_val, "V");

            if (data.Tables[0].Rows.Count > 0) BindTreeNode(tn_sel, data);
            else sc = "$.notify({ icon: 'fas fa-info', message: 'No existen más registros...!!' }, { type: 'info' });";
        }
        SetScript(sc);
    }

    // Quitar Nodos
    protected void TvMenu_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
    {
        var id_val = e.Node;
        id_val.ChildNodes.Clear();
        id_val.PopulateOnDemand = true;
        SetScript("");
    }

    // Seleccionar Nodo
    protected void TvMenu_SelectedNodeChanged(object sender, EventArgs e)
    {
        if (TvMenu.SelectedNode.Value.Equals("GAMLP"))
        {
            Txt_me_url.Text = "#";
            Hf_me_icono.Value = "far fa-circle";
            Hf_me_id_padre.Value = "0";
            Txt_me_url.Enabled = false;
            sc = "$('#addModal').modal('show');";
        }
        else
        {
            _menu = new cls_seg_menu();
            var data = _menu.ObtenerRegistro(Convert.ToInt32(TvMenu.SelectedNode.Value)).Tables[0];
            Hf_me_id_m.Value = data.Rows[0]["me_id"].ToString();
            Txt_me_descripcion_m.Text = data.Rows[0]["me_descripcion"].ToString();
            Txt_me_url_m.Text = data.Rows[0]["me_url"].ToString();
            Hf_me_icono_m.Value = data.Rows[0]["me_icono"].ToString();
            Hf_me_id_padre_m.Value = data.Rows[0]["me_id_padre"].ToString();
            Txt_me_url_m.Enabled = (data.Rows[0]["me_url"].ToString().Equals("#")) ? false : true;
            Rbl_me_vista_m.SelectedValue = (Convert.ToBoolean(data.Rows[0]["me_vista"].ToString())) ? "1" : "0";
            sc = "$('#editModal').modal('show');";
        }
        TvMenu.SelectedNode.Selected = false;
        SetScript(sc);
    }

    // Nuevo Registro
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        Txt_me_url.Text = "#";
        Hf_me_icono.Value = "fas fa-genderless";
        Hf_me_id_padre.Value = Hf_me_id_m.Value;
        Txt_me_url.Enabled = true;
        sc = "$('#addModal').modal('show'); $('#editModal').modal('hide');";
        SetScript(sc);
    }

    // Guardar Alta
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        _menu = new cls_seg_menu
        {
            me_descripcion = Txt_me_descripcion.Text.ToUpper().Trim(),
            me_url = Txt_me_url.Text.Trim(),
            me_icono = Hf_me_icono.Value,
            me_id_padre = Convert.ToInt32(Hf_me_id_padre.Value),
            me_usuario_creacion = Session["per_id"].ToString(),
            me_vista = (Rbl_me_vista.SelectedValue.Equals("1")) ? true : false
        };
        _menu.Adicionar();
        Limpiar("frm_add_cl");
        BindTreeView();
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#addModal').modal('hide');";
        SetScript(sc);
    }

    // Cancelar Alta
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar("frm_add_cl");
        sc = "$('#addModal').modal('hide');";
        SetScript(sc);
    }

    // Guardar Modificación
    protected void BtnGuardarM_Click(object sender, EventArgs e)
    {
        _menu = new cls_seg_menu();
        var data = _menu.ObtenerTablaGrilla(Hf_me_id_m.Value, Txt_me_descripcion_m.Text.ToUpper().Trim(), Txt_me_url_m.Text.Trim(), Hf_me_icono_m.Value, Hf_me_id_padre_m.Value, "V").Tables[0];

        if (data.Rows.Count > 0) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no se puede actualizar, aún mantiene los mismos parámetros...!!' }, { type: 'warning' });";
        else
        {
            _menu = new cls_seg_menu
            {
                me_id = Convert.ToInt32(Hf_me_id_m.Value),
                me_descripcion = Txt_me_descripcion_m.Text.ToUpper().Trim(),
                me_url = Txt_me_url_m.Text.Trim(),
                me_icono = Hf_me_icono_m.Value,
                me_id_padre = Convert.ToInt32(Hf_me_id_padre_m.Value),
                me_usuario_creacion = Session["per_id"].ToString(),
                me_vista = (Rbl_me_vista_m.SelectedValue.Equals("1")) ? true : false
            };
            _menu.Actualizar();
            var id = _menu.Adicionar();
            _menu = new cls_seg_menu();

            foreach (DataRow itemM in _menu.ObtenerTablaGrilla("", "", "", "", Hf_me_id_m.Value, "V").Tables[0].Rows)
            {
                _menu = new cls_seg_menu
                {
                    me_id = Convert.ToInt32(itemM["me_id"].ToString()),
                    me_id_padre = id
                };
                _menu.ActualizarNodo();
            }
            _rol_menu = new cls_seg_rol_menu();
            Limpiar("frm_edit_cl");
            BindTreeView();
            sc = "$.notify({ icon: 'fas fa-check', message: 'Registro actualizado correctamente...!!' }, { type: 'success' }); $('#editModal').modal('hide');";
        }
        SetScript(sc);
    }

    // Cancelar Modificación
    protected void BtnCancelarM_Click(object sender, EventArgs e)
    {
        Limpiar("frm_edit_cl");
        sc = "$('#editModal').modal('hide');";
        SetScript(sc);
    }

    // Eliminar Registro
    protected void BtnEliminar_Click(object sender, EventArgs e)
    {
        _menu = new cls_seg_menu();
        var data = _menu.ObtenerRegistro(Convert.ToInt32(Hf_me_id_m.Value)).Tables[0];
        Hf_me_id_b.Value = data.Rows[0]["me_id"].ToString();
        Txt_me_descripcion_b.Text = data.Rows[0]["me_descripcion"].ToString();
        sc = "$('#editModal').modal('hide'); $('#deleteModal').modal('show');";
        SetScript(sc);
    }

    // Guardar Baja
    protected void BtnGuardarB_Click(object sender, EventArgs e)
    {
        _rol_menu = new cls_seg_rol_menu();
        var data = _rol_menu.ObtenerTablaGrilla("", "", Hf_me_id_b.Value, "V").Tables[0];

        if (data.Rows.Count > 0) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no se puede eliminar, está siendo utilizado...!!' }, { type: 'warning' });";
        else
        {
            _menu = new cls_seg_menu { me_id = Convert.ToInt32(Hf_me_id_b.Value) };
            _menu.Eliminar();

            foreach (DataRow item in _menu.ObtenerTablaGrilla("", "", "", "", Hf_me_id_b.Value, "V").Tables[0].Rows)
            {
                _menu = new cls_seg_menu { me_id = Convert.ToInt32(item["me_id"].ToString()) };
                _menu.Eliminar();
            }
            BindTreeView();
            sc = "$.notify({ icon: 'fas fa-check', message: 'Registro eliminado correctamente...!!' }, { type: 'success' }); $('#deleteModal').modal('hide');";
        }
        SetScript(sc);
    }

    // cancelar Baja
    protected void BtnCancelarB_Click(object sender, EventArgs e)
    {
        sc = "$('#deleteModal').modal('hide');";
        SetScript(sc);
    }

    // Ejecutar ScriptManager
    private void SetScript(string data)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Limpiar
    private void Limpiar(string val)
    {
        if (val.Equals("frm_add_cl"))
        {
            Txt_me_descripcion.Text = string.Empty;
            Txt_me_url.Text = string.Empty;
            Rbl_me_vista.ClearSelection();
        }
        else if (val.Equals("frm_edit_cl"))
        {
            Txt_me_descripcion_m.Text = string.Empty;
            Txt_me_url_m.Text = string.Empty;
            Rbl_me_vista_m.ClearSelection();
        }
    }
}