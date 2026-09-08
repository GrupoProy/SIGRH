using Solution_Framework_Seguridad.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Seguridad_Roles : System.Web.UI.Page
{
    private cls_seg_rol _rol = null;
    private cls_seg_menu _menu = null;
    private cls_seg_rol_menu _rol_menu = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                BindGrid();
                TvMenu.Attributes.Add("onclick", "OnTreeClick(event)");
                sc = "CopiarCortarPegar(true);";
                SetScript(sc);
            }
        }
        else Response.Redirect("../Index");
    }

    // Cargar GridView
    private void BindGrid()
    {
        try
        {
            _rol = new cls_seg_rol();
            GvLista.DataSource = _rol.ObtenerTablaGrilla("", "", "V");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Cargar TreeView
    private void BindTreeView()
    {
        _menu = new cls_seg_menu();
        var data = _menu.ObtenerTablaGrilla("", "", "", "", "0", "V");
        TvMenu.Nodes.Clear();
        TreeNode tnRaiz = new TreeNode
        {
            Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>SIGRH</h6></div></div>",
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
                Text = (item["me_id_padre"].ToString().Equals("0")) ? "<div class='d-flex align-items-center pr-3'><div><div class='badge badge-circle icon-treeview mr-2 ml-2'><i class='" + item["me_icono"].ToString() + "'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + item["me_descripcion"].ToString() + "</h6></div></div>" :
                "<div class='d-flex align-items-center pr-3'><div><div class='badge badge-circle icon-child-treeview mr-2 ml-2'><i class='" + item["me_icono"].ToString() + "'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + item["me_descripcion"].ToString() + "</h6></div></div>",
                Value = item["me_id"].ToString(),
                ShowCheckBox = true,
                Checked = CheckTreeNode(Hf_rol_id_rm.Value, item["me_id"].ToString()),
                PopulateOnDemand = true
            };

            if (tn_padre == null) tn_padre.ChildNodes.Add(tn_item);
            else tn_padre.ChildNodes.Add(tn_item);
        }
    }

    // Evento Agregar Nodos
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

    // Evento Quitar Nodos
    protected void TvMenu_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
    {
        var id_val = e.Node;
        id_val.ChildNodes.Clear();
        id_val.PopulateOnDemand = true;
        SetScript("");
    }

    // Evento Seleccionar Nodo
    protected void TvMenu_SelectedNodeChanged(object sender, EventArgs e)
    {
        SetScript("");
    }

    // Diseño GridView
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) GvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvLista.FooterRow != null) GvLista.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    // Seleccionar Fila
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("GetEdit"))
        {
            _rol = new cls_seg_rol();
            var data = _rol.ObtenerRegistro(Convert.ToInt32(code)).Tables[0];
            Hf_rol_id_m.Value = data.Rows[0]["rol_id"].ToString();
            Txt_rol_descripcion_m.Text = data.Rows[0]["rol_descripcion"].ToString();
            sc = "$('#editModal').modal('show');";
        }
        else if (e.CommandName.Equals("GetDelete"))
        {
            _rol = new cls_seg_rol();
            var data = _rol.ObtenerRegistro(Convert.ToInt32(code)).Tables[0];
            Hf_rol_id_b.Value = data.Rows[0]["rol_id"].ToString();
            Txt_rol_descripcion_b.Text = data.Rows[0]["rol_descripcion"].ToString();
            sc = "$('#deleteModal').modal('show');";
        }
        else if (e.CommandName.Equals("GetRolMenu"))
        {
            _rol = new cls_seg_rol();
            var data = _rol.ObtenerRegistro(Convert.ToInt32(code)).Tables[0];
            Hf_rol_id_rm.Value = data.Rows[0]["rol_id"].ToString();
            Txt_rolme_me_id.Text = data.Rows[0]["rol_descripcion"].ToString();
            BindTreeView();
            sc = "$('#rolMenuModal').modal('show');";
        }
        SetScript(sc);
    }

    // Nuevo Registro
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        sc = "$('#addModal').modal('show');";
        SetScript(sc);
    }

    // Guardar Alta
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        _rol = new cls_seg_rol
        {
            rol_descripcion = Txt_rol_descripcion.Text.ToUpper().Trim(),
            rol_usuario_creacion = Session["per_id"].ToString()
        };
        _rol.Adicionar();
        Limpiar("frm_rol_cl");
        BindGrid();
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#addModal').modal('hide');";
        SetScript(sc);
    }

    // Cancelar Alta
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        Limpiar("frm_rol_cl");
        sc = "$('#addModal').modal('hide');";
        SetScript(sc);
    }

    // Guardar Modificación
    protected void BtnGuardarM_Click(object sender, EventArgs e)
    {
        _rol = new cls_seg_rol();
        var data = _rol.ObtenerTablaGrilla(Hf_rol_id_m.Value, Txt_rol_descripcion_m.Text.ToUpper().Trim(), "V").Tables[0];

        if (data.Rows.Count > 0) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no se puede actualizar, aún mantiene los mismos parámetros...!!' }, { type: 'warning' });";
        else
        {
            _rol = new cls_seg_rol
            {
                rol_id = Convert.ToInt32(Hf_rol_id_m.Value),
                rol_descripcion = Txt_rol_descripcion_m.Text.ToUpper().Trim(),
                rol_usuario_creacion = Session["per_id"].ToString()
            };
            _rol.Actualizar();
            _rol.Adicionar();
            sc = "$.notify({ icon: 'fas fa-check', message: 'Registro actualizado correctamente...!!' }, { type: 'success' }); $('#editModal').modal('hide');";
        }
        BindGrid();
        SetScript(sc);
    }

    // Cancelar Modificación
    protected void BtnCancelarM_Click(object sender, EventArgs e)
    {
        Limpiar("frm_rol_cl");
        sc = "$('#editModal').modal('hide');";
        SetScript(sc);
    }

    // Guardar Baja
    protected void BtnGuardarB_Click(object sender, EventArgs e)
    {
        _rol = new cls_seg_rol { rol_id = Convert.ToInt32(Hf_rol_id_b.Value) };
        _rol.Eliminar();
        BindGrid();
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro eliminado correctamente...!!' }, { type: 'success' }); $('#deleteModal').modal('hide');";
        SetScript(sc);
    }

    // Cancelar Baja
    protected void BtnCancelarB_Click(object sender, EventArgs e)
    {
        Limpiar("frm_rol_cl");
        sc = "$('#deleteModal').modal('hide');";
        SetScript(sc);
    }

    // Guardar Menú Rol
    protected void BtnGuardarRM_Click(object sender, EventArgs e)
    {
        RecorrerTreeView();
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#rolMenuModal').modal('hide');";
        SetScript(sc);
    }

    // Cancelar Menú Rol
    protected void BtnCancelarRM_Click(object sender, EventArgs e)
    {
        Limpiar("frm_menu_cl");
        sc = "$('#rolMenuModal').modal('hide');";
        SetScript(sc);
    }

    // Comprobar Nodos TreeView
    private bool CheckTreeNode(string rol_id, string me_id)
    {
        _rol_menu = new cls_seg_rol_menu();
        var data = _rol_menu.ObtenerTablaGrilla("", rol_id, me_id, "V").Tables[0];

        if (data.Rows.Count > 0) return (data.Rows[0]["rolme_estado"].ToString().Equals("V")) ? true : false;
        else return false;
    }

    // Recorrer TreeView
    private void RecorrerTreeView()
    {
        TreeNodeCollection nodos = TvMenu.Nodes;

        foreach (TreeNode item in nodos) RecorrerNodos(item);
    }

    // Recorrer Nodos TreeView
    private void RecorrerNodos(TreeNode nodo)
    {
        foreach (TreeNode item in nodo.ChildNodes)
        {
            _rol_menu = new cls_seg_rol_menu();
            var data = _rol_menu.ObtenerTablaGrilla("", Hf_rol_id_rm.Value, item.Value, "V").Tables[0];

            if (data.Rows.Count > 0)
            {
                if (!item.Checked)
                {
                    _rol_menu = new cls_seg_rol_menu { rolme_id = Convert.ToInt32(data.Rows[0]["rolme_id"].ToString()) };
                    _rol_menu.Eliminar();
                }
            }
            else
            {
                if (item.Checked)
                {
                    _rol_menu = new cls_seg_rol_menu
                    {
                        rolme_rol_id = Convert.ToInt32(Hf_rol_id_rm.Value),
                        rolme_me_id = Convert.ToInt32(item.Value),
                        rolme_usuario_creacion = Session["per_id"].ToString()
                    };
                    _rol_menu.Adicionar();
                }
            }
            RecorrerNodos(item);
        }
    }

    // Ejecutar ScriptManager
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
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Limpiar
    private void Limpiar(string val)
    {
        if (val.Equals("frm_rol_cl")) Txt_rol_descripcion.Text = string.Empty;
        else if (val.Equals("frm_menu_cl")) TvMenu.Nodes.Clear();
    }
}