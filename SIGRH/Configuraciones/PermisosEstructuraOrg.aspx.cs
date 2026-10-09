using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_Seguridad.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;

public partial class Configuraciones_PermisosEstructuraOrg : System.Web.UI.Page
{
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["per_id"] == null || Session["per_id"].ToString() == "")
        {
            Response.Redirect("../Index");
            return;
        }

        if (!Page.IsPostBack)
            CargarUsuarios();

        TvEstructura.Attributes.Add("onclick", "OnTreeClick(event)");
    }

    // ============================================================
    //  USUARIOS
    // ============================================================
    private void CargarUsuarios()
    {
        try
        {
            cls_seg_usuario usu = new cls_seg_usuario();
            DataSet ds = usu.ObtenerTablaGrilla(
                "", "", "", "", "", "", "", "", "", "", "", "", "V");
            GvUsuarios.DataSource = ds;
            GvUsuarios.DataBind();
        }
        catch (Exception ex)
        {
            Notificar("Error al cargar usuarios: " + ex.Message, "danger");
        }
    }

    protected void GvUsuarios_PreRender(object sender, EventArgs e)
    {
        if (GvUsuarios.Rows.Count > 0 && GvUsuarios.HeaderRow != null)
            GvUsuarios.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void GvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "GetPermisos")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            int usId = Convert.ToInt32(GvUsuarios.DataKeys[index].Value);
            string usuario = GvUsuarios.Rows[index].Cells[1].Text;

            Hf_per_id.Value = usId.ToString();
            ltlUsuario.Text = HttpUtility.HtmlEncode(usuario.Trim());

            CargarArbolEstructura(usId);

            // 👇 ESTA ES LA LÍNEA NUEVA (refresca el modal)
            Up_permisos.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "showModal",
                "$('#permisosModal').modal('show');", true);
        }
    }

    // ============================================================
    //  ÁRBOL - Carga inicial (solo primer nivel)
    // ============================================================
    private void CargarArbolEstructura(int usId)
    {
        TvEstructura.Nodes.Clear();

        try
        {
            // 1) Permisos ya asignados al usuario
            HashSet<int> permitidos = new HashSet<int>();
            cls_permiso_categoria_programatica pcp = new cls_permiso_categoria_programatica();
            pcp.pcp_us_id = usId;
            DataSet dsPerm = pcp.ObtenerTablaCombo();

            if (dsPerm != null && dsPerm.Tables.Count > 0
                && dsPerm.Tables[0].Columns.Contains("eo_id"))
            {
                foreach (DataRow r in dsPerm.Tables[0].Rows)
                    if (r["eo_id"] != DBNull.Value)
                        permitidos.Add(Convert.ToInt32(r["eo_id"]));
            }

            // 2) Obtener raíces (eo_id = 0 → primer nivel)
            cls_mp_cargo cargo = new cls_mp_cargo();
            cargo.eo_id = 0;
            cargo.gestion_selec = Session["pr_id"] != null ? Session["pr_id"].ToString() : "";
            DataSet dsRaices = cargo.ObtenerNivelOrg();

            // 3) Agregar los nodos raíz directo al TreeView
            if (dsRaices != null && dsRaices.Tables.Count > 0)
            {
                foreach (DataRow row in dsRaices.Tables[0].Rows)
                {
                    int eoId = Convert.ToInt32(row["eo_id"]);
                    string desc = row["eo_descripcion"].ToString();

                    TreeNode tn = new TreeNode
                    {
                        Text = "<div class='d-flex align-items-center pr-3'><div><div class='badge badge-circle icon-child-treeview mr-2 ml-2'><i class='fas fa-sitemap'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + HttpUtility.HtmlEncode(desc) + "</h6></div></div>",
                        Value = eoId.ToString(),
                        ShowCheckBox = true,
                        Checked = permitidos.Contains(eoId),
                        PopulateOnDemand = true,   // 👈 Clave: se expande al hacer clic
                        Expanded = false
                    };
                    TvEstructura.Nodes.Add(tn);
                }
            }
        }
        catch (Exception ex)
        {
            Notificar("Error al cargar estructura: " + ex.Message, "danger");
        }
    }

    // ============================================================
    //  ÁRBOL - Expandir un nodo → cargar hijos
    // ============================================================
    protected void TvEstructura_TreeNodePopulate(object sender, TreeNodeEventArgs e)
    {
        try
        {
            int usId = Convert.ToInt32(Hf_per_id.Value);
            int eoIdPadre = Convert.ToInt32(e.Node.Value);

            // 1) Permisos ya asignados al usuario (para marcar los hijos)
            HashSet<int> permitidos = new HashSet<int>();
            cls_permiso_categoria_programatica pcp = new cls_permiso_categoria_programatica();
            pcp.pcp_us_id = usId;
            DataSet dsPerm = pcp.ObtenerTablaCombo();
            if (dsPerm != null && dsPerm.Tables.Count > 0
                && dsPerm.Tables[0].Columns.Contains("eo_id"))
            {
                foreach (DataRow r in dsPerm.Tables[0].Rows)
                    if (r["eo_id"] != DBNull.Value)
                        permitidos.Add(Convert.ToInt32(r["eo_id"]));
            }

            // 2) Pedir los hijos de este nodo
            cls_mp_cargo cargo = new cls_mp_cargo();
            cargo.eo_id = eoIdPadre;
            cargo.gestion_selec = Session["pr_id"] != null ? Session["pr_id"].ToString() : "";
            DataSet dsHijos = cargo.ObtenerNivelOrg();

            if (dsHijos != null && dsHijos.Tables.Count > 0 && dsHijos.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in dsHijos.Tables[0].Rows)
                {
                    int eoId = Convert.ToInt32(row["eo_id"]);
                    string desc = row["eo_descripcion"].ToString();

                    TreeNode tn = new TreeNode
                    {
                        Text = "<div class='d-flex align-items-center pr-3'><div><div class='badge badge-circle icon-child-treeview mr-2 ml-2'><i class='fas fa-sitemap'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + HttpUtility.HtmlEncode(desc) + "</h6></div></div>",
                        Value = eoId.ToString(),
                        ShowCheckBox = true,
                        Checked = permitidos.Contains(eoId),
                        PopulateOnDemand = true,   // 👈 permite seguir expandiendo
                        Expanded = false
                    };
                    e.Node.ChildNodes.Add(tn);
                }
            }
        }
        catch (Exception ex)
        {
            Notificar("Error al expandir: " + ex.Message, "danger");
        }
    }

    // ============================================================
    //  GUARDAR
    // ============================================================
    protected void BtnGuardarPermisos_Click(object sender, EventArgs e)
    {
        try
        {
            int usId = Convert.ToInt32(Hf_per_id.Value);
            int prId = Session["pr_id"] != null ? Convert.ToInt32(Session["pr_id"]) : 1;

            // 1) Limpiar previos
            cls_permiso_categoria_programatica pcpClear = new cls_permiso_categoria_programatica
            {
                pcp_us_id = usId
            };
            pcpClear.EliminarPorUsuario();

            // 2) Insertar los marcados
            //    ⚠️ Como el árbol es on-demand, solo insertamos
            //    los que ya están visibles/marcados en el TreeView
            foreach (TreeNode raiz in TvEstructura.Nodes)
                InsertarMarcados(raiz, usId, prId);

            Notificar("Permisos guardados correctamente", "success");
            ScriptManager.RegisterStartupScript(this, this.GetType(), "hide",
                "$('#permisosModal').modal('hide');", true);
        }
        catch (Exception ex)
        {
            Notificar("Error al guardar: " + ex.Message, "danger");
        }
    }

    private void InsertarMarcados(TreeNode nodo, int usId, int prId)
    {
        foreach (TreeNode hijo in nodo.ChildNodes)
        {
            if (hijo.Checked)
            {
                cls_permiso_categoria_programatica pcp = new cls_permiso_categoria_programatica
                {
                    pcp_us_id = usId,
                    pcp_ue = Convert.ToInt32(hijo.Value),
                    pcp_cp_id = Convert.ToInt32(hijo.Value),
                    pcp_pr_id = prId,
                    pcp_rol = 1,
                    pcp_estado = "V"
                };
                pcp.Adicionar();
            }
            InsertarMarcados(hijo, usId, prId);
        }
    }

    protected void BtnCancelarPermisos_Click(object sender, EventArgs e)
    {
        TvEstructura.Nodes.Clear();
        ScriptManager.RegisterStartupScript(this, this.GetType(), "close",
            "$('#permisosModal').modal('hide');", true);
    }

    // ============================================================
    //  Helpers
    // ============================================================
    private void Notificar(string mensaje, string tipo)
    {
        string icono = tipo == "success" ? "fas fa-check"
                     : tipo == "warning" ? "fas fa-exclamation-triangle"
                     : "fas fa-exclamation";
        string msg = (mensaje ?? "").Replace("\\", "\\\\").Replace("'", "\\'")
                                    .Replace("\r", " ").Replace("\n", " ");
        sc = "$.notify({ icon: '" + icono + "', message: '" + msg + "' }, { type: '" + tipo + "' });";
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "nt", "<script>" + sc + "</script>", false);
    }

    protected void btnBuscar_Click(object sender, EventArgs e) { /* placeholder */ }
}