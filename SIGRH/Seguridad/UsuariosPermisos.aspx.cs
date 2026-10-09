using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Seguridad.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Seguridad_UsuariosPermisos : System.Web.UI.Page
{
    private cls_periodo _periodo = null;
    private cls_mp_categoria_programatica _cat_prog = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_seg_usuario _usuario = null;
    private cls_seg_rol _rol = null;
    private cls_seg_menu _menu = null;
    private cls_seg_usuario_rol _usuario_rol = null;
    private cls_seg_rol_menu _rol_menu = null;
    private cls_seg_menu_usuario _menu_usuario = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] == null || HttpContext.Current.Session["per_id"].ToString() == "")
        {
            Response.Redirect("../Index");
            return;
        }

        if (!Page.IsPostBack)
        {
            var id = Request.QueryString["id"].ToString();
            SearchFunc(id);
            BindDDLRol();
            BindDDLUnidadEjecutora();
            BindDDLTipoPermiso();

            _usuario_rol = new cls_seg_usuario_rol();
            var rolActual = _usuario_rol.ObtenerTablaGrilla("", id, "", "V").Tables[0];
            if (rolActual.Rows.Count > 0)
            {
                string columnaRol = rolActual.Columns.Contains("usrol_rol_id") ? "usrol_rol_id" : "rol_id";
                string rolId = rolActual.Rows[0][columnaRol].ToString();
                if (Ddl_rol_id.Items.FindByValue(rolId) != null)
                {
                    Ddl_rol_id.SelectedValue = rolId;
                }
            }

            BindGridRoles(id);
            BindTreeViewR();
            BindTreeViewU();

            TvMenuU.Attributes.Add("onclick", "OnTreeClick(event)");
            sc += "CopiarCortarPegar(true);";
            SetScript(sc);
        }
    }

    private void BindDDLRol()
    {
        _rol = new cls_seg_rol();
        Ddl_rol_id.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_rol_id.DataSource = _rol.ObtenerTablaCombo();
        Ddl_rol_id.DataValueField = "rol_id";
        Ddl_rol_id.DataTextField = "rol_descripcion";
        Ddl_rol_id.DataBind();
    }

    private void BindDDLUnidadEjecutora()
    {
        _cat_prog = new cls_mp_categoria_programatica { cp_pr_id = Periodo() };
        Ddl_cp_ue.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_cp_ue.DataSource = _cat_prog.ObtenerTablaComboUE();
        Ddl_cp_ue.DataValueField = "cp_ue";
        Ddl_cp_ue.DataTextField = "cp_descripcion";
        Ddl_cp_ue.DataBind();
    }

    private void BindDDLTipoPermiso()
    {
        Ddl_meper_tipo_permiso.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_meper_tipo_permiso.Items.Insert(1, new ListItem("CREADOR", "1"));
        Ddl_meper_tipo_permiso.Items.Insert(2, new ListItem("APROBADOR", "2"));
        Ddl_meper_tipo_permiso.Items.Insert(3, new ListItem("VALIDADOR", "3"));
        Ddl_meper_tipo_permiso.DataBind();
    }

    private void SearchFunc(string us_id)
    {
        _usuario = new cls_seg_usuario();
        var data = _usuario.ObtenerTablaGrilla(us_id, "", "", "", "", "", "", "", "", "", "", "", "V").Tables[0];
        if (data.Rows.Count > 0) BindForm(data.Rows[0]["us_per_id"].ToString());
    }

    private void BindForm(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var data = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (data.Rows.Count > 0)
        {
            Lt_per_nombres.Text = ValidarCampo(data.Rows[0]["per_nombres"]) + " " + ValidarCampo(data.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(data.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(data.Rows[0]["per_num_doc"]) + " " + ValidarCampo(data.Rows[0]["cat_abreviacion"]);
            Lt_per_id.Text = ValidarCampo(data.Rows[0]["per_id"]);
            Lt_ca_num_item.Text = ValidarCampo(data.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(data.Rows[0]["ca_num_item"]);
            Lt_ca_basico_calculado.Text = (ValidarCampo(data.Rows[0]["ca_basico_calculado"]).Equals("")) ? "" : Convert.ToDouble(ValidarCampo(data.Rows[0]["ca_basico_calculado"])).ToString("N");
            Lt_es_escalafon.Text = ValidarCampo(data.Rows[0]["es_escalafon"]);
            Lt_ns_clase.Text = ValidarCampo(data.Rows[0]["ns_clase"]);
            Lt_ns_nivel.Text = ValidarCampo(data.Rows[0]["ns_nivel"]);
            Lt_as_fecha_inicio.Text = (ValidarCampo(data.Rows[0]["as_fecha_inicio"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(data.Rows[0]["as_fecha_inicio"])).ToString("dd/MM/yyyy");
            Lt_as_fecha_fin.Text = (ValidarCampo(data.Rows[0]["as_fecha_fin"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(data.Rows[0]["as_fecha_fin"])).ToString("dd/MM/yyyy");
            Lt_es_descripcion.Text = ValidarCampo(data.Rows[0]["es_descripcion"]);
            Lt_puesto.Text = ValidarCampo(data.Rows[0]["es_descripcion"]); // Asignamos el mismo valor que cargo

            Lt_eo_descripcion.Text = ValidarCampo(data.Rows[0]["eo_descripcion"]);
            Lt_eo_prog.Text = ValidarCampo(data.Rows[0]["eo_prog"]) + " - " + ValidarCampo(data.Rows[0]["eo_sprog"]) + " - " + ValidarCampo(data.Rows[0]["eo_proy"]) + " - " + ValidarCampo(data.Rows[0]["eo_obract"]) + " - " + ValidarCampo(data.Rows[0]["eo_unidad"]);
            Lt_cp_descripcion.Text = ValidarCampo(data.Rows[0]["cp_descripcion"]);
            Lt_cp_da.Text = ValidarCampo(data.Rows[0]["cp_da"]) + " - " + ValidarCampo(data.Rows[0]["cp_ue"]) + " - " + ValidarCampo(data.Rows[0]["cp_programa"]) + " - " + ValidarCampo(data.Rows[0]["cp_proyecto"]) + " - " + ValidarCampo(data.Rows[0]["cp_actividad"]);

            if (ValidarCampo(data.Rows[0]["as_estado"]).Equals("V"))
            {
                Lbl_as_estado.Text = "Vigente";
                Lbl_as_estado.CssClass = "btn btn-sm btn-info";
            }
            else
            {
                Lbl_as_estado.Text = "Pasivo";
                Lbl_as_estado.CssClass = "btn btn-sm btn-secondary";
            }

            if (ValidarCampo(data.Rows[0]["fp_foto"]) != "") Img_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])data.Rows[0]["fp_foto"]);
            else if (ValidarCampo(data.Rows[0]["per_sexo"]).Equals("M")) Img_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg";
            else Img_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg";
        }
    }

    private void BindGridRoles(string us_id)
    {
        _usuario_rol = new cls_seg_usuario_rol();
        var rolesUsuario = _usuario_rol.ObtenerTablaGrilla("", us_id, "", "V").Tables[0];

        _rol = new cls_seg_rol();
        var todosRoles = _rol.ObtenerTablaCombo().Tables[0];

        DataTable dtResultado = new DataTable();
        dtResultado.Columns.Add("usrol_id", typeof(int));
        dtResultado.Columns.Add("rol_descripcion", typeof(string));

        string columnaRol = rolesUsuario.Columns.Contains("usrol_rol_id") ? "usrol_rol_id" : "rol_id";
        string columnaUsrolId = rolesUsuario.Columns.Contains("usrol_id") ? "usrol_id" :
                                 (rolesUsuario.Columns.Contains("id") ? "id" : "usrol_id");

        foreach (DataRow row in rolesUsuario.Rows)
        {
            var rolId = row[columnaRol].ToString();
            var rolFilas = todosRoles.Select("rol_id = " + rolId);
            string descripcion = rolFilas.Length > 0 ? rolFilas[0]["rol_descripcion"].ToString() : "(Rol " + rolId + ")";

            DataRow nuevaFila = dtResultado.NewRow();
            nuevaFila["usrol_id"] = Convert.ToInt32(row[columnaUsrolId]);
            nuevaFila["rol_descripcion"] = descripcion;
            dtResultado.Rows.Add(nuevaFila);
        }

        Gv_roles.DataSource = dtResultado;
        Gv_roles.DataBind();
    }

    protected void Gv_roles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "Quitar")
        {
            try
            {
                if (e.CommandArgument == null || e.CommandArgument.ToString() == "")
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation-triangle', message: 'Error: no se pudo identificar el registro a quitar.' }, { type: 'danger' });";
                    SetScript(sc);
                    return;
                }

                int usrolId = Convert.ToInt32(e.CommandArgument);
                _usuario_rol = new cls_seg_usuario_rol { usrol_id = usrolId };
                _usuario_rol.Eliminar();

                string id = Request.QueryString["id"].ToString();
                BindGridRoles(id);
                Up_form_r.Update();

                sc = "$.notify({ icon: 'fas fa-check', message: 'Rol quitado correctamente.' }, { type: 'success' });";
            }
            catch (Exception ex)
            {
                sc = "$.notify({ icon: 'fas fa-times', message: 'Error al quitar: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            }
            SetScript(sc);
        }
    }

    private void BindTreeViewR()
    {
        _menu = new cls_seg_menu();
        var data = _menu.ObtenerTablaGrilla("", "", "", "", "0", "V");
        TvMenuR.Nodes.Clear();
        TreeNode tnRaiz = new TreeNode
        {
            Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>SIGRH</h6></div></div>",
            Value = "GAMLP",
            Expanded = true
        };
        tnRaiz.SelectAction = TreeNodeSelectAction.Select;
        TvMenuR.Nodes.Add(tnRaiz);
        TvMenuR.ExpandDepth = 0;
        BindTreeNodeR(tnRaiz, data);
    }

    private void BindTreeNodeR(TreeNode tn_padre, DataSet ds_menu)
    {
        foreach (DataRow item in ds_menu.Tables[0].Rows)
        {
            TreeNode tn_item = new TreeNode
            {
                Text = (item["me_id_padre"].ToString().Equals("0")) ? "<div class='d-flex align-items-center pr-3'><div><div class='badge badge-circle icon-treeview mr-2 ml-2'><i class='" + item["me_icono"].ToString() + "'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + item["me_descripcion"].ToString() + "</h6></div></div>" :
                "<div class='d-flex align-items-center pr-3'><div><div class='badge badge-circle icon-child-treeview mr-2 ml-2'><i class='" + item["me_icono"].ToString() + "'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + item["me_descripcion"].ToString() + "</h6></div></div>",
                Value = item["me_id"].ToString(),
                ShowCheckBox = true,
                Checked = CheckTreeNodeR(Ddl_rol_id.SelectedValue, item["me_id"].ToString()),
                PopulateOnDemand = true
            };

            if (tn_padre == null) tn_padre.ChildNodes.Add(tn_item);
            else tn_padre.ChildNodes.Add(tn_item);
        }
    }

    private void BindTreeViewU()
    {
        _menu = new cls_seg_menu();
        var data = _menu.ObtenerTablaGrilla("", "", "", "", "0", "V");
        TvMenuU.Nodes.Clear();
        TreeNode tnRaiz = new TreeNode
        {
            Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>SIGRH</h6></div></div>",
            Value = "GAMLP",
            Expanded = true
        };
        tnRaiz.SelectAction = TreeNodeSelectAction.Select;
        TvMenuU.Nodes.Add(tnRaiz);
        TvMenuU.ExpandDepth = 0;
        BindTreeNodeU(tnRaiz, data);
    }

    private void BindTreeNodeU(TreeNode tn_padre, DataSet ds_menu)
    {
        var id = Request.QueryString["id"].ToString();

        foreach (DataRow item in ds_menu.Tables[0].Rows)
        {
            TreeNode tn_item = new TreeNode
            {
                Text = (item["me_id_padre"].ToString().Equals("0")) ? "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='" + item["me_icono"].ToString() + "'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + item["me_descripcion"].ToString() + "</h6></div></div>" :
                "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-child-treeview mr-2'><i class='" + item["me_icono"].ToString() + "'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + item["me_descripcion"].ToString() + "</h6></div></div>",
                Value = item["me_id"].ToString(),
                ShowCheckBox = true,
                Checked = CheckTreeNodeU(item["me_id"].ToString(), id),
                PopulateOnDemand = true
            };

            if (tn_padre == null) tn_padre.ChildNodes.Add(tn_item);
            else tn_padre.ChildNodes.Add(tn_item);
        }
    }

    protected void Ddl_rol_id_SelectedIndexChanged(object sender, EventArgs e)
    {
        BindTreeViewR();
        BindTreeViewU();
        SetScript("");
    }

    protected void TvMenuR_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
        var id_val = e.Node.Value;
        var tn_sel = e.Node;
        _menu = new cls_seg_menu();

        if (id_val.Equals("GAMLP")) BindTreeViewR();
        else
        {
            var data = _menu.ObtenerTablaGrilla("", "", "", "", id_val, "V");
            if (data.Tables[0].Rows.Count > 0) BindTreeNodeR(tn_sel, data);
            else sc = "$.notify({ icon: 'fas fa-info', message: 'No existen más registros...!!' }, { type: 'info' });";
        }
        SetScript(sc);
    }

    protected void TvMenuR_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
    {
        var id_val = e.Node;
        id_val.ChildNodes.Clear();
        id_val.PopulateOnDemand = true;
        SetScript("");
    }

    protected void TvMenuR_SelectedNodeChanged(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void TvMenuU_TreeNodeExpanded(object sender, TreeNodeEventArgs e)
    {
        var id_val = e.Node.Value;
        var tn_sel = e.Node;
        _menu = new cls_seg_menu();

        if (id_val.Equals("GAMLP")) BindTreeViewU();
        else
        {
            var data = _menu.ObtenerTablaGrilla("", "", "", "", id_val, "V");
            if (data.Tables[0].Rows.Count > 0) BindTreeNodeU(tn_sel, data);
            else sc = "$.notify({ icon: 'fas fa-info', message: 'No existen más registros...!!' }, { type: 'info' });";
        }
        SetScript(sc);
    }

    protected void TvMenuU_TreeNodeCollapsed(object sender, TreeNodeEventArgs e)
    {
        var id_val = e.Node;
        id_val.ChildNodes.Clear();
        id_val.PopulateOnDemand = true;
        SetScript("");
    }

    protected void TvMenuU_SelectedNodeChanged(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        try
        {
            var id = Request.QueryString["id"].ToString();

            if (Ddl_rol_id.SelectedValue == "0")
            {
                sc = "$.notify({ icon: 'fas fa-exclamation-triangle', message: 'Seleccione un rol...!!' }, { type: 'warning' });";
                SetScript(sc);
                return;
            }

            _usuario_rol = new cls_seg_usuario_rol();
            var data = _usuario_rol.ObtenerTablaGrilla("", id, Ddl_rol_id.SelectedValue, "V").Tables[0];

            if (data.Rows.Count == 0)
            {
                _usuario_rol = new cls_seg_usuario_rol
                {
                    usrol_us_id = Convert.ToInt32(id),
                    usrol_rol_id = Convert.ToInt32(Ddl_rol_id.SelectedValue),
                    usrol_usuario_creacion = Session["per_id"].ToString()
                };
                _usuario_rol.Adicionar();
                sc = "$.notify({ icon: 'fas fa-check', message: 'Rol agregado correctamente...!!' }, { type: 'success' });";
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-info', message: 'El usuario ya tiene este rol asignado...!!' }, { type: 'info' });";
            }

            BindGridRoles(id);
            Up_form_r.Update();
            SetScript(sc);
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-times', message: 'Error al agregar: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc);
        }
    }

    protected void BtnGuardarCambios_Click(object sender, EventArgs e)
    {
        try
        {
            var id = Request.QueryString["id"].ToString();

            if (Ddl_rol_id.SelectedValue == "0")
            {
                sc = "$.notify({ icon: 'fas fa-exclamation-triangle', message: 'Seleccione un rol...!!' }, { type: 'warning' });";
                SetScript(sc);
                return;
            }

            _usuario_rol = new cls_seg_usuario_rol();
            var data = _usuario_rol.ObtenerTablaGrilla("", id, Ddl_rol_id.SelectedValue, "V").Tables[0];

            if (data.Rows.Count == 0)
            {
                sc = "$.notify({ icon: 'fas fa-exclamation-triangle', message: 'Primero debe agregar el rol al usuario...!!' }, { type: 'warning' });";
                SetScript(sc);
                return;
            }

            RecorrerTreeViewR();
            RecorrerTreeViewU();

            sc = "$.notify({ icon: 'fas fa-check', message: 'Permisos del rol actualizados correctamente...!!' }, { type: 'success' });";
            SetScript(sc);
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-times', message: 'Error al guardar: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc);
        }
    }

    private int Periodo()
    {
        _periodo = new cls_periodo();
        var year = DateTime.Now.Year - 1;
        var data = _periodo.ObtenerTablaGrilla("", year.ToString(), "", "V").Tables[0];
        if (data.Rows.Count > 0) return Convert.ToInt32(data.Rows[0]["pr_id"]);
        else return 0;
    }

    private string ValidarCampo(object p_campo)
    {
        string campo = "";
        if (!string.IsNullOrEmpty(p_campo.ToString())) campo = p_campo.ToString().Trim();
        return campo;
    }

    private bool CheckTreeNodeR(string rol_id, string me_id)
    {
        _rol_menu = new cls_seg_rol_menu();
        var data = _rol_menu.ObtenerTablaGrilla("", rol_id, me_id, "V").Tables[0];
        if (data.Rows.Count > 0) return (data.Rows[0]["rolme_estado"].ToString().Equals("V")) ? true : false;
        else return false;
    }

    private bool CheckTreeNodeU(string me_id, string us_id)
    {
        _menu_usuario = new cls_seg_menu_usuario();
        var data = _menu_usuario.ObtenerTablaGrilla("", me_id, us_id, "V", "", "").Tables[0];
        if (data.Rows.Count > 0) return (data.Rows[0]["meus_estado"].ToString().Equals("V")) ? true : false;
        else return false;
    }

    private void RecorrerTreeViewR()
    {
        TreeNodeCollection nodos = TvMenuR.Nodes;
        foreach (TreeNode item in nodos) RecorrerNodosR(item);
    }

    private void RecorrerNodosR(TreeNode nodo)
    {
        foreach (TreeNode item in nodo.ChildNodes)
        {
            _rol_menu = new cls_seg_rol_menu();
            var data = _rol_menu.ObtenerTablaGrilla("", Ddl_rol_id.SelectedValue, item.Value, "V").Tables[0];

            if (data.Rows.Count > 0)
            {
                if (!item.Checked)
                {
                    _rol_menu = new cls_seg_rol_menu { rolme_id = Convert.ToInt32(data.Rows[0]["rolme_id"]) };
                    _rol_menu.Eliminar();
                }
            }
            else
            {
                if (item.Checked)
                {
                    _rol_menu = new cls_seg_rol_menu
                    {
                        rolme_rol_id = Convert.ToInt32(Ddl_rol_id.SelectedValue),
                        rolme_me_id = Convert.ToInt32(item.Value),
                        rolme_usuario_creacion = Session["per_id"].ToString()
                    };
                    _rol_menu.Adicionar();
                }
            }
            RecorrerNodosR(item);
        }
    }

    private void RecorrerTreeViewU()
    {
        TreeNodeCollection nodos = TvMenuU.Nodes;
        foreach (TreeNode item in nodos) RecorrerNodosU(item);
    }

    private void RecorrerNodosU(TreeNode nodo)
    {
        var id = Request.QueryString["id"].ToString();

        foreach (TreeNode item in nodo.ChildNodes)
        {
            _menu_usuario = new cls_seg_menu_usuario();
            var data = _menu_usuario.ObtenerTablaGrilla("", item.Value, id, "V", "", "").Tables[0];

            if (data.Rows.Count > 0)
            {
                if (!item.Checked)
                {
                    _menu_usuario = new cls_seg_menu_usuario { meus_id = Convert.ToInt32(data.Rows[0]["meus_id"]) };
                    _menu_usuario.Eliminar();
                }
            }
            else
            {
                if (item.Checked)
                {
                    _menu_usuario = new cls_seg_menu_usuario
                    {
                        meus_me_id = Convert.ToInt32(item.Value),
                        meus_us_id = Convert.ToInt32(id),
                        meus_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString())
                    };
                    _menu_usuario.Adicionar();
                }
            }
            RecorrerNodosU(item);
        }
    }

    private void SetScript(string val)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        // Inicializar DataTable
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
        // Tooltips
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        // Inicializar select2 para todos los .select2
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } });");
        // Datepicker
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: \"es\"" +
                    "});" +
                "});" +
                "var me = $(\".datepickerD\");" +
                "me.mask(\"99/99/9999\");" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void Limpiar(string val)
    {
        if (val.Equals("frm_perm_cl"))
        {
            Ddl_rol_id.Items.Clear();
            Ddl_cp_ue.Items.Clear();
            Ddl_meper_tipo_permiso.Items.Clear();
            TvMenuR.Nodes.Clear();
            TvMenuU.Nodes.Clear();
        }
    }
}