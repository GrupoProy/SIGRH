using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;

public partial class ManualPuestos_EstructuraOrganizacional : System.Web.UI.Page
{
    private cls_mp_estructura_organizacional estructura_organizacional = null;
    private cls_mp_cargo cargo = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                listarNivelOrg();
                listarEstructuraOrg();
               // btn_imprimir.Visible = false;
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }
    private void listarEstructuraOrg()
    {
        estructura_organizacional = new cls_mp_estructura_organizacional { eo_pr_id = Convert.ToInt32(Session["pr_id"].ToString()) };
        ddl_est_org.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_est_org.DataSource = estructura_organizacional.ObtenerListaFiltradoEstOrgMP();//GRIDVIEW INIT
        ddl_est_org.DataValueField = "eo_id";
        ddl_est_org.DataTextField = "eo_descripcion";
        ddl_est_org.DataBind();
    }
    private void listarNivelOrg()
    {
        try
        {
            cargo = new cls_mp_cargo();
            cargo.eo_id = 0;
            cargo.gestion_selec = Session["pr_id"].ToString();
            var nivelOrg = cargo.ObtenerNivelOrgMP();

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
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void buscar(int p_eo_id = 0)
    {
        tv_nivelOrg.Nodes.Clear();
        try
        {
            estructura_organizacional = new cls_mp_estructura_organizacional { eo_id = p_eo_id };
            var detalle_descendencia = estructura_organizacional.ObtenerDescendencia();
            if (detalle_descendencia.Tables[0].Rows.Count > 0)
            {
                var descendencia = detalle_descendencia.Tables[0].Rows;
                for (int i = descendencia.Count - 1; i >= 0; i--)
                {
                    if (i == (descendencia.Count - 1))
                    {
                        cargo = new cls_mp_cargo();
                        cargo.eo_id = Convert.ToInt32(validarCampo(descendencia[i]["eo_cod_superior"]));
                        cargo.gestion_selec = Session["pr_id"].ToString();
                        var nivelOrg = cargo.ObtenerNivelOrgMP();
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
                    }
                    else
                    {
                        if (tv_nivelOrg.FindNode(validarCampo(descendencia[i]["eo_cod_superior"])) != null)
                        {
                            tv_nivelOrg.FindNode(validarCampo(descendencia[i]["eo_cod_superior"])).Select();
                            tv_nivelOrg.SelectedNode.Expand();
                        }
                        else
                        {
                            TreeNode parentNodeO = tv_nivelOrg.SelectedNode;
                            foreach (TreeNode childNodesParent in parentNodeO.ChildNodes)
                            {
                                if (childNodesParent.Value == validarCampo(descendencia[i]["eo_cod_superior"]))
                                {
                                    childNodesParent.Select();
                                    break;
                                }
                            }
                            tv_nivelOrg.SelectedNode.Expand();
                        }

                        int eo_id = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);

                        cargo = new cls_mp_cargo();
                        cargo.eo_id = eo_id;
                        cargo.gestion_selec = Session["pr_id"].ToString();
                        var sub_nivel_org = cargo.ObtenerNivelOrgMP();

                        if (sub_nivel_org.Tables[0].Rows.Count > 0)
                        {
                            foreach (DataRow lvlNDataRow in sub_nivel_org.Tables[0].Rows)
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
                            SetScript(sc);
                        }
                    }

                }

                TreeNode parentNodeLast = tv_nivelOrg.SelectedNode;
                foreach (TreeNode childNodesParent in parentNodeLast.ChildNodes)
                {
                    if (childNodesParent.Value == validarCampo(descendencia[0]["eo_id"]))
                    {
                        childNodesParent.Select();
                        break;
                    }
                }
                tv_nivelOrg.SelectedNode.Expand();

                estructura_organizacional = new cls_mp_estructura_organizacional();
                estructura_organizacional.eo_id = Convert.ToInt32(validarCampo(descendencia[0]["eo_id"]));
                estructura_organizacional.eo_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
                var nivelOrgItems = estructura_organizacional.ObtenerItemsLibres();

                foreach (DataRow lvlNDataRow in nivelOrgItems.Tables[0].Rows)
                {
                    TreeNode childNode = new TreeNode();

                    childNode.Value = lvlNDataRow["ca_id"].ToString();
                    childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-child-treeview mr-2'><i class='fas fa-briefcase'></i></div></div><div class=''><strong>" + lvlNDataRow["ca_ti_item"].ToString() + " - " + lvlNDataRow["ca_num_item"].ToString() + "</strong> " + lvlNDataRow["es_descripcion"].ToString() + "</div></div>";
                    childNode.ToolTip = "PUESTO: "+lvlNDataRow["p_descripcion"].ToString();
                    TreeNode parentNode = tv_nivelOrg.SelectedNode;
                    validarNodo(parentNode, childNode);
                }
            }

            if (hf_ca_id.Value != "")
            {
                string ca_id = hf_ca_id.Value;
                TreeNode parentNodeLast = tv_nivelOrg.SelectedNode;
                foreach (TreeNode childNodesParent in parentNodeLast.ChildNodes)
                {
                    if (childNodesParent.Value == ca_id)
                    {
                        childNodesParent.Select();
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
    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }
    protected void tv_nivelOrg_SelectedNodeChanged(object sender, EventArgs e)
    {
        int eo_id = Convert.ToInt32(tv_nivelOrg.SelectedNode.Value);

        string gestionFiltrar = Session["pr_id"].ToString();
        cargo = new cls_mp_cargo();
        cargo.eo_id = eo_id;
        cargo.gestion_selec = gestionFiltrar;
        var nivelOrg = cargo.ObtenerNivelOrgMP();

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

                //Session["idFicha"] = childNode.Text.ToString();// gvPuesto.DataKeys[index].Value.ToString();
                ////Response.Redirect("Reportes/Reporte_POAI.aspx");
                //SetScript(sc + "window.open('Reportes/Reporte_POAI.aspx','_blank');");
            }
        }
        else
        {
            sc = "$.notify({ icon: 'ni ni-bell-55', message: 'No existe subniveles para la Unidad Organizacional seleccionada.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

        estructura_organizacional = new cls_mp_estructura_organizacional();
        estructura_organizacional.eo_id = eo_id;
        estructura_organizacional.eo_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var nivelOrgItems = estructura_organizacional.ObtenerItemsLibres();
        foreach (DataRow lvlNDataRow in nivelOrgItems.Tables[0].Rows)
        {
            TreeNode childNode = new TreeNode();

            childNode.Value = lvlNDataRow["ca_id"].ToString();
            childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-child-treeview mr-2'><i class='fas fa-briefcase'></i></div></div><div class=''>" + lvlNDataRow["ca_ti_item"].ToString() + " - " + lvlNDataRow["ca_num_item"].ToString() + " " + lvlNDataRow["es_descripcion"].ToString() + "</div></div>";
            childNode.ToolTip = "PUESTO: " + lvlNDataRow["p_descripcion"].ToString();
            TreeNode parentNode = tv_nivelOrg.SelectedNode;
            validarNodo(parentNode, childNode);

        }
        tv_nivelOrg.SelectedNode.Expand();
        tv_nivelOrg.SelectedNode.Checked = true;
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
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_buscar_est_org_Click(object sender, EventArgs e)
    {
        //btn_imprimir.Visible = true;
        int eo_id = 0;
        if (txt_numero_item.Text.Trim() != "")
        {
            ddl_est_org.SelectedValue = "0";
            estructura_organizacional = new cls_mp_estructura_organizacional();
            estructura_organizacional.ca_num_item = Convert.ToInt32(txt_numero_item.Text);
            estructura_organizacional.eo_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            var item = estructura_organizacional.BuscarItemUO();

            if (item.Tables[0].Rows.Count > 0)
            {
                eo_id = Convert.ToInt32(validarCampo(item.Tables[0].Rows[0]["ca_eo_id"]));
                hf_ca_id.Value = validarCampo(item.Tables[0].Rows[0]["ca_id"]);

            }
        } else
        {
            eo_id = Convert.ToInt32(ddl_est_org.SelectedValue);
        }
        buscar(eo_id);
        SetScript("");
    }

    protected void ddl_est_org_SelectedIndexChanged(object sender, EventArgs e)
    {
        //btn_imprimir.Visible = true;
        txt_numero_item.Text = "";
    }
    protected void btn_imprimir_Click(object sender, EventArgs e)
    {
        estructura_organizacional = new cls_mp_estructura_organizacional();
        estructura_organizacional.ca_id = Convert.ToInt32(tv_nivelOrg.SelectedValue);
        estructura_organizacional.eo_pr_id = Convert.ToInt32(Session["pr_id"].ToString()); //25;// Convert.ToInt32(Session["pr_id"].ToString());
        var poai = estructura_organizacional.ObtenerPOAI();

        if (poai.Tables[0].Rows.Count > 0)
        {
            Session["idFicha"] = validarCampo(poai.Tables[0].Rows[0]["poai_id"]);
            SetScript(sc + "window.open('ManualPuestos/Reportes/Reporte_POAI.aspx','_blank');");
        }
        else
        {
            Session["idFicha"] = tv_nivelOrg.SelectedValue;
            SetScript(sc + "window.open('ManualPuestos/Reportes/ReportePOAIEO.aspx','_blank');");
        }
    }
}