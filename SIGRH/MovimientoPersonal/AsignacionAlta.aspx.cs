using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovimientoPersonal_frmAsignacion_Alta : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_glosa _glosa = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_mp_cargo _cargo = null;
    private cls_puestos _puesto = null;
    private cls_mp_cargo_puesto _cargo_puesto = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                // ============================================================
                // MODIFICACIÓN: P_p_descripcion SIEMPRE OCULTO
                // ============================================================
                P_p_descripcion.Visible = false;
                P_datos.Visible = false;
                Lt_p_descripcion.Text = "";
                Txt_p_descripcion.Text = "";

                var id = Request.QueryString["id"].ToString();
                BindDDLTipoMovimiento();
                BindForm(id);
            }
        }
        else { Response.Redirect("../Index"); }
    }

    // ============================================================
    // Carga Datos Funcionario
    // ============================================================
    private void BindForm(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (var_datos_as_c.Rows.Count > 0)
        {
            Lt_per_id.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_id"]);
            Lt_per_nombres.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_nombres"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(var_datos_as_c.Rows[0]["per_num_doc"]) + " " + ValidarCampo(var_datos_as_c.Rows[0]["cat_abreviacion"]);

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

            if (ValidarCampo(var_datos_as_c.Rows[0]["fp_foto"]) != "") { Img_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])var_datos_as_c.Rows[0]["fp_foto"]); }
            else if (ValidarCampo(var_datos_as_c.Rows[0]["per_sexo"]).Equals("M")) { Img_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg"; }
            else { Img_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg"; }
        }
        Ddl_as_tipo_mov.Enabled = false;
        Ddl_as_tipo_mov.SelectedValue = "B";
    }

    // ============================================================
    // Carga Los Datos Del Item Seleccionado
    // ============================================================
    private void BindItem(DataTable _data)
    {
        BindAsignacion(_data);
        BindPuesto();

        P_datos.Visible = true;
        P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO

        if (Hf_ti_tipo_item_gral.Value.Equals("C")) { P_as_fecha_fin.Visible = true; }
        else { P_as_fecha_fin.Visible = false; }

        switch (Hf_ti_tipo.Value)
        {
            case "FC":
                if (Hf_ti_tipo_item_gral.Value.Equals("P")) { Rfv_pu_descripcion.Enabled = false; }
                break;
            case "FE":
                if (Hf_ti_tipo_item_gral.Value.Equals("C")) { Rfv_pu_descripcion.Enabled = true; }
                else { Rfv_pu_descripcion.Enabled = false; }
                break;
            case "FD":
                if (Hf_ti_tipo_item_gral.Value.Equals("C")) { Rfv_pu_descripcion.Enabled = true; }
                else { Rfv_pu_descripcion.Enabled = false; }
                break;
            case "FP":
                if (Hf_ti_tipo_item_gral.Value.Equals("C")) { Rfv_pu_descripcion.Enabled = true; }
                break;
            default:
                break;
        }
    }

    // ============================================================
    // Carga Datos Nueva Asignación
    // ============================================================
    private void BindAsignacion(DataTable par_datos_as_c)
    {
        Hf_ca_id.Value = par_datos_as_c.Rows[0]["ca_id"].ToString().Trim();
        Hf_ti_tipo.Value = par_datos_as_c.Rows[0]["ti_tipo"].ToString().Trim();
        Hf_ti_tipo_item_gral.Value = par_datos_as_c.Rows[0]["ti_tipo_item_gral"].ToString().Trim();
        Lt_ca_num_item.Text = ValidarCampo(par_datos_as_c.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(par_datos_as_c.Rows[0]["ca_num_item"]);
        Lt_ca_basico_calculado.Text = Convert.ToDouble(ValidarCampo(par_datos_as_c.Rows[0]["ca_basico_calculado"])).ToString("N");
        Lt_es_escalafon.Text = ValidarCampo(par_datos_as_c.Rows[0]["es_escalafon"]);
        Lt_ns_clase.Text = ValidarCampo(par_datos_as_c.Rows[0]["ns_clase"]);
        Lt_ns_nivel.Text = ValidarCampo(par_datos_as_c.Rows[0]["ns_nivel"]);
        Lt_es_descripcion.Text = ValidarCampo(par_datos_as_c.Rows[0]["es_descripcion"]);
        Lt_eo_descripcion.Text = ValidarCampo(par_datos_as_c.Rows[0]["eo_descripcion"]);
        Lt_eo_prog.Text = ValidarCampo(par_datos_as_c.Rows[0]["eo_prog"]) + " - " + ValidarCampo(par_datos_as_c.Rows[0]["eo_sprog"]) + " - " + ValidarCampo(par_datos_as_c.Rows[0]["eo_proy"]) + " - " + ValidarCampo(par_datos_as_c.Rows[0]["eo_obract"]) + " - " + ValidarCampo(par_datos_as_c.Rows[0]["eo_unidad"]);
        Lt_cp_descripcion.Text = ValidarCampo(par_datos_as_c.Rows[0]["cp_descripcion"]);
        Lt_cp_da.Text = ValidarCampo(par_datos_as_c.Rows[0]["cp_da"]) + " - " + ValidarCampo(par_datos_as_c.Rows[0]["cp_ue"]) + " - " + ValidarCampo(par_datos_as_c.Rows[0]["cp_programa"]) + " - " + ValidarCampo(par_datos_as_c.Rows[0]["cp_proyecto"]) + " - " + ValidarCampo(par_datos_as_c.Rows[0]["cp_actividad"]);
        ltl_jornada.Text = par_datos_as_c.Rows[0]["ca_tipo_jornada_lit"].ToString().Trim();
        Ddl_as_tipo_mov.Enabled = false;
        Ddl_as_tipo_mov.SelectedValue = "B";

        if (!string.IsNullOrEmpty(Lt_es_descripcion.Text))
        {
            P_datos.Visible = true;
        }

        if (Hf_ti_tipo.Value == "DOC")
        {
            cls_mp_asignacion asignacion = new cls_mp_asignacion();
            if (asignacion.VerificarAsignacionEscalafon(Convert.ToInt32(Lt_per_id.Text)).Tables[0].Rows.Count == 0)
            {
                ddlDocente.DataSource = asignacion.ObtenerEscalafonDocente();
                ddlDocente.DataTextField = "categoria";
                ddlDocente.DataValueField = "ed_id";
                ddlDocente.DataBind();
                panelEscalafonDocentes.Visible = true;
            }
        }
        else
            panelEscalafonDocentes.Visible = false;
    }

    // ============================================================
    // Carga Datos Puesto
    // ============================================================
    private void BindPuesto()
    {
        var aux = "";
        Lt_p_descripcion.Text = string.Empty;
        Txt_p_descripcion.Text = string.Empty;
        Txt_as_fecha_inicio.Enabled = true;
        Txt_as_fecha_fin.Enabled = true;

        switch (Hf_ti_tipo.Value)
        {
            case "FC":
                if (Hf_ti_tipo_item_gral.Value.Equals("P")) { aux = "LM"; }
                break;
            case "FE":
                if (Hf_ti_tipo_item_gral.Value.Equals("P")) { aux = "EP"; }
                else if (Hf_ti_tipo_item_gral.Value.Equals("C")) { aux = "EC"; }
                break;
            case "FD":
                if (Hf_ti_tipo_item_gral.Value.Equals("P")) { aux = "DP"; }
                else if (Hf_ti_tipo_item_gral.Value.Equals("C")) { aux = "DC"; }
                break;
            case "FP":
                if (Hf_ti_tipo_item_gral.Value.Equals("C")) { aux = "PC"; }
                break;
            default:
                break;
        }

        if (!string.IsNullOrEmpty(Hf_ca_id.Value))
        {
            _cargo_puesto = new cls_mp_cargo_puesto();
            var dataCP = _cargo_puesto.ObtenerTablaGrilla(Hf_ca_id.Value, "", "V", "").Tables[0];

            if (dataCP.Rows.Count > 0)
            {
                _puesto = new cls_puestos();
                var dataP = _puesto.ObtenerTablaGrilla(dataCP.Rows[0]["cap_p_id"].ToString().Trim(), "", "V").Tables[0];

                Lt_p_descripcion.Text = ValidarCampo(dataP.Rows[0]["p_descripcion"]);
                Txt_p_descripcion.Text = ValidarCampo(dataP.Rows[0]["p_descripcion"]);
                P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
                return;
            }
        }

        if (aux.Equals("EP") || aux.Equals("DP"))
        {
            _cargo_puesto = new cls_mp_cargo_puesto();
            var dataCP = _cargo_puesto.ObtenerTablaGrilla(Hf_ca_id.Value, "", "V", "").Tables[0];

            if (dataCP.Rows.Count > 0)
            {
                _puesto = new cls_puestos();
                var dataP = _puesto.ObtenerTablaGrilla(dataCP.Rows[0]["cap_p_id"].ToString().Trim(), "", "V").Tables[0];
                Txt_p_descripcion.Text = ValidarCampo(dataP.Rows[0]["p_descripcion"]);
                Lt_p_descripcion.Text = ValidarCampo(dataP.Rows[0]["p_descripcion"]);
                Txt_p_descripcion.Enabled = false;
                P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
            }
        }
        else if (aux.Equals("EC") || aux.Equals("DC") || aux.Equals("PC"))
        {
            var id = Request.QueryString["id"].ToString();
            _asignacion = new cls_mp_asignacion { as_per_id = Convert.ToInt32(id) };
            var dataPRE = _asignacion.ObtenerPuestoPreContrato().Tables[0];

            if (dataPRE.Rows.Count > 0)
            {
                if (string.IsNullOrEmpty(dataPRE.Rows[0]["rap_as_id"].ToString()) && string.IsNullOrEmpty(dataPRE.Rows[0]["rap_pre_id"].ToString()))
                {
                    _puesto = new cls_puestos();
                    var dataP = _puesto.ObtenerTablaGrilla(dataPRE.Rows[0]["pre_p_id"].ToString(), "", "V").Tables[0];
                    Txt_p_descripcion.Text = ValidarCampo(dataP.Rows[0]["p_descripcion"]);
                    Lt_p_descripcion.Text = ValidarCampo(dataP.Rows[0]["p_descripcion"]);
                    Txt_p_descripcion.Enabled = false;
                    P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
                }
                Txt_as_fecha_inicio.Enabled = false;
                Txt_as_fecha_fin.Enabled = false;
                Txt_as_fecha_inicio.Text = Convert.ToDateTime(ValidarCampo(dataPRE.Rows[0]["pre_fecha_inicio"])).ToString("dd/MM/yyyy");
                Txt_as_fecha_fin.Text = Convert.ToDateTime(ValidarCampo(dataPRE.Rows[0]["pre_fecha_fin"])).ToString("dd/MM/yyyy");
            }
        }
        else if (aux.Equals("LM"))
        {
            Txt_p_descripcion.Enabled = true;
            P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
        }
    }

    // ============================================================
    // Carga Datos TipoMovimiento
    // ============================================================
    private void BindDDLTipoMovimiento()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_mov_alta_ingreso" };
        Ddl_as_tipo_mov.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_as_tipo_mov.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_as_tipo_mov.DataValueField = "cat_abreviacion";
        Ddl_as_tipo_mov.DataTextField = "cat_descripcion";
        Ddl_as_tipo_mov.DataBind();
    }

    // ============================================================
    // Carga Datos TipoDocumentoImpreso
    // ============================================================
    private void BindDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_impreso" };
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_gl_tipo_doc.DataValueField = "cat_id";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // ============================================================
    // Lista Nivel Organizacional
    // ============================================================
    private void ListarNivelOrg()
    {
        string gestionFiltrar = Session["pr_id"].ToString();

        try
        {
            _cargo = new cls_mp_cargo
            {
                eo_id = 0,
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

    // ============================================================
    // Evento Tiene Número Item
    // ============================================================
    protected void Chk_hv_item_CheckedChanged(object sender, EventArgs e)
    {
        if (Chk_hv_item.Checked) { P_dg_item.Visible = true; }
        else { P_dg_item.Visible = false; }

        if (Hf_ti_tipo_item_gral.Value.Equals("C")) { P_as_fecha_fin.Visible = true; }
        else { P_as_fecha_fin.Visible = false; }

        if (string.IsNullOrEmpty(Lt_es_descripcion.Text) && string.IsNullOrEmpty(Lt_ns_nivel.Text) && string.IsNullOrEmpty(Lt_ca_basico_calculado.Text) && string.IsNullOrEmpty(Lt_cp_descripcion.Text) && string.IsNullOrEmpty(Lt_eo_descripcion.Text))
        {
            P_p_descripcion.Visible = false;
            P_datos.Visible = false;
        }
        else
        {
            P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
            P_datos.Visible = true;
        }
        Limpiar("frm_busq_cl");
        SetScript("", "");
    }

    // ============================================================
    // Busca Datos Item
    // ============================================================
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (Chk_hv_item.Checked)
        {
            P_dg_item.Visible = true;

            if (string.IsNullOrEmpty(Txt_dg_item.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar un número de ítem...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            int _val_id = Convert.ToInt32(Txt_dg_item.Text.Trim());
            string gestionFiltrar = Session["pr_id"].ToString();
            _cargo = new cls_mp_cargo
            {
                num_item = _val_id.ToString(),
                gestion_selec = gestionFiltrar
            };
            var dataDI = _cargo.ObtenerDetalleItemCP_num_item().Tables[0];

            if (dataDI.Rows.Count > 0)
            {
                P_result.Visible = true;
                GvLista.DataSource = dataDI;
                GvLista.DataBind();
                sc = "$.notify({ icon: 'fas fa-check', message: 'Se encontraron ítems...!!' }, { type: 'success' });";
                SetScript(sc, "");
            }
            else
            {
                P_result.Visible = false;
                P_p_descripcion.Visible = false;
                P_datos.Visible = false;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El ítem no se ha encontrado...!!' }, { type: 'warning' });";
                SetScript(sc, "");
            }
        }
        else
        {
            if (Hf_ti_tipo_item_gral.Value.Equals("C")) { P_as_fecha_fin.Visible = true; }
            else { P_as_fecha_fin.Visible = false; }

            if (string.IsNullOrEmpty(Lt_es_descripcion.Text) && string.IsNullOrEmpty(Lt_ns_nivel.Text) && string.IsNullOrEmpty(Lt_ca_basico_calculado.Text) && string.IsNullOrEmpty(Lt_cp_descripcion.Text) && string.IsNullOrEmpty(Lt_eo_descripcion.Text))
            {
                P_p_descripcion.Visible = false;
                P_datos.Visible = false;
            }
            else
            {
                P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
                P_datos.Visible = true;
            }
            ListarNivelOrg();
            sc = "$('#itemModal').modal('show');";
        }
        Limpiar("frm_busq_cl");
        Chk_hv_item.Checked = false;
        P_dg_item.Visible = false;
        SetScript(sc, "");
    }

    // ============================================================
    // Evento RowCommand del GridView
    // ============================================================
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        try
        {
            if (e.CommandName == "GetItem")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                if (index >= 0 && index < GvLista.Rows.Count)
                {
                    string ca_id = GvLista.DataKeys[index].Value.ToString();
                    if (!string.IsNullOrEmpty(ca_id))
                    {
                        Limpiar("frm_bj_cl");
                        Limpiar("frm_glosa_cl");
                        _cargo = new cls_mp_cargo
                        {
                            ca_id = Convert.ToInt32(ca_id),
                            gestion_selec = Session["pr_id"].ToString()
                        };
                        var dataDI = _cargo.ObtenerDetalleItemCP().Tables[0];
                        if (dataDI.Rows.Count > 0)
                        {
                            cls_mp_asignacion asignacion = new cls_mp_asignacion();
                            var dtVerif = asignacion.VerificarItemAdministrativo(Convert.ToInt32(dataDI.Rows[0]["ca_id"].ToString()), Convert.ToInt32(Lt_per_id.Text)).Tables[0];

                            if (dtVerif.Rows.Count == 0)
                            {
                                BindItem(dataDI);
                                P_result.Visible = false;
                                sc = "$.notify({ icon: 'fas fa-check', message: 'El ítem fue encontrado y seleccionado correctamente...!!' }, { type: 'success' }); $('#itemModal').modal('hide');";
                                SetScript(sc, "");
                            }
                            else
                            {
                                P_datos.Visible = false;
                                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Asignación denegada, No es posible asignar dos items administrativos...!!' }, { type: 'danger' });";
                                SetScript(sc, "");
                            }
                        }
                        else
                        {
                            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se encontraron datos del ítem...!!' }, { type: 'warning' });";
                            SetScript(sc, "");
                        }
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al obtener el ID del ítem...!!' }, { type: 'danger' });";
                        SetScript(sc, "");
                    }
                }
                else
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Índice de ítem no válido...!!' }, { type: 'danger' });";
                    SetScript(sc, "");
                }
            }
        }
        catch (Exception ex)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Error al seleccionar el ítem: " + ex.Message.Replace("'", "\\'") + "' }, { type: 'danger' });";
            SetScript(sc, "");
        }
    }

    // ============================================================
    // PreRender del GridView
    // ============================================================
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) { GvLista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvLista.FooterRow != null) { GvLista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // ============================================================
    // Carga Datos Nivel Organizacional
    // ============================================================
    protected void tv_nivelOrg_SelectedNodeChanged(object sender, EventArgs e)
    {
        int _val_id = Convert.ToInt32(Tv_nivelOrg.SelectedNode.Value);
        string gestionFiltrar = Session["pr_id"].ToString();
        _cargo = new cls_mp_cargo
        {
            ca_id = _val_id,
            eo_id = _val_id,
            gestion_selec = gestionFiltrar
        };
        var nivelOrg = _cargo.ObtenerNivelOrg().Tables[0];
        var dataIC = _cargo.ObtenerGrillaItemsCP().Tables[0];
        var dataDI = _cargo.ObtenerDetalleItemCP().Tables[0];

        if (nivelOrg.Rows.Count > 0)
        {
            foreach (DataRow lvlNDataRow in nivelOrg.Rows)
            {
                TreeNode childNode = new TreeNode();
                childNode.Value = lvlNDataRow["eo_id"].ToString();
                childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0 desc-treeview'>" + lvlNDataRow["eo_descripcion"].ToString().Trim() + " <small class='ls-1 mb-1 text-muted'>" + lvlNDataRow["cp_da"].ToString().Trim() + " - " + lvlNDataRow["cp_ue"].ToString().Trim() + " - " + lvlNDataRow["cp_programa"].ToString().Trim() + " - " + lvlNDataRow["cp_proyecto"].ToString().Trim() + " - " + lvlNDataRow["cp_actividad"].ToString().Trim() + " (" + lvlNDataRow["cp_fuente"].ToString().Trim() + " - " + lvlNDataRow["cp_organismo"].ToString().Trim().Trim() + ")</small></h6></div></div>";
                TreeNode parentNode = Tv_nivelOrg.SelectedNode;
                validarNodo(parentNode, childNode);
            }
        }
        else { sc = "$.notify({ icon: 'ni ni-bell-55', message: 'No existe subniveles para la Unidad Organizacional seleccionada...!!' }, { type: 'info', placement: { from: 'bottom', align: 'right'} });"; }

        if (dataIC.Rows.Count > 0)
        {
            foreach (DataRow lvlNDataRow in dataIC.Rows)
            {
                TreeNode childNode = new TreeNode();
                childNode.Value = lvlNDataRow["ca_id"].ToString();
                childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-child-treeview mr-2'><i class='fas fa-briefcase'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + lvlNDataRow["ca_ti_item"].ToString().Trim() + "-" + lvlNDataRow["ca_num_item"].ToString().Trim() + " (" + lvlNDataRow["es_descripcion"].ToString().Trim() + ")" + " - " + lvlNDataRow["ca_tipo_jornada"].ToString().Trim() + "</h6></div></div>";
                TreeNode parentNode = Tv_nivelOrg.SelectedNode;
                validarNodo(parentNode, childNode);
            }
        }
        Tv_nivelOrg.SelectedNode.Expand();

        if (dataDI.Rows.Count > 0)
        {
            var id = Request.QueryString["id"].ToString();
            _asignacion = new cls_mp_asignacion { as_per_id = Convert.ToInt32(id) };

            BindItem(dataDI);
            Limpiar("frm_item");
            sc = "$.notify({ icon: 'fas fa-check', message: 'El ítem fue seleccionado correctamente...!!' }, { type: 'success' }); $('#itemModal').modal('hide');";
        }
        SetScript(sc, "");
    }

    // ============================================================
    // Valida Nodos Lista Nivel Organizacional
    // ============================================================
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

    // ============================================================
    // Cierra Modal Nivel Organizacional
    // ============================================================
    protected void BtnCancelarI_Click(object sender, EventArgs e)
    {
        if (Hf_ti_tipo_item_gral.Value.Equals("C")) { P_as_fecha_fin.Visible = true; }
        else { P_as_fecha_fin.Visible = false; }

        if (string.IsNullOrEmpty(Lt_es_descripcion.Text) && string.IsNullOrEmpty(Lt_ns_nivel.Text) && string.IsNullOrEmpty(Lt_ca_basico_calculado.Text) && string.IsNullOrEmpty(Lt_cp_descripcion.Text) && string.IsNullOrEmpty(Lt_eo_descripcion.Text))
        {
            P_p_descripcion.Visible = false;
            P_datos.Visible = false;
        }
        else
        {
            P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
            P_datos.Visible = true;
        }
        Limpiar("frm_item");
        sc = "$('#itemModal').modal('hide');";
        SetScript(sc, "");
    }

    // ============================================================
    // Valida Datos Nueva Asignación Y Carga Modal Glosa
    // ============================================================
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Lt_es_descripcion.Text) && string.IsNullOrEmpty(Lt_ns_nivel.Text) && string.IsNullOrEmpty(Lt_ca_basico_calculado.Text) && string.IsNullOrEmpty(Lt_cp_descripcion.Text) && string.IsNullOrEmpty(Lt_eo_descripcion.Text))
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los datos de asignación están vacíos, debe seleccionar un item...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        // ============================================================
        // MODIFICACIÓN: Validar que el ítem esté realmente cargado
        // ============================================================
        if (string.IsNullOrEmpty(Hf_ca_id.Value) || Hf_ca_id.Value == "0")
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar un ítem válido...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        var fec_ac = DateTime.Now;
        var fec_in = Convert.ToDateTime(Txt_as_fecha_inicio.Text.Trim());
        var fec_fi = (string.IsNullOrEmpty(Txt_as_fecha_fin.Text)) ? DateTime.Now : Convert.ToDateTime(Txt_as_fecha_fin.Text.Trim());

        if (Hf_ti_tipo_item_gral.Value.Equals("P"))
        {
            if (fec_ac.Year > fec_in.Year)
            {
                P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
                P_datos.Visible = true;
                P_as_fecha_fin.Visible = false;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha de Asignación) debe encontrarse en el año vigente...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }
        else if (Hf_ti_tipo_item_gral.Value.Equals("C"))
        {
            if (fec_ac.Year > fec_in.Year)
            {
                P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
                P_datos.Visible = true;
                P_as_fecha_fin.Visible = true;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha de Asignación) debe encontrarse en el año vigente...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            if (fec_ac.Year > fec_fi.Year)
            {
                P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
                P_datos.Visible = true;
                P_as_fecha_fin.Visible = true;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha de Baja) debe encontrarse en el año vigente...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }

            if (fec_in >= fec_fi)
            {
                P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
                P_datos.Visible = true;
                P_as_fecha_fin.Visible = true;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha de Baja) debe ser mayor al campo (Fecha de Asignación)...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }

        if (Chk_hv_item.Checked) { P_dg_item.Visible = true; }
        else { P_dg_item.Visible = false; }

        if (Hf_ti_tipo_item_gral.Value.Equals("P")) { P_as_fecha_fin.Visible = false; }
        else if (Hf_ti_tipo_item_gral.Value.Equals("C")) { P_as_fecha_fin.Visible = true; }

        if (string.IsNullOrEmpty(Lt_es_descripcion.Text) && string.IsNullOrEmpty(Lt_ns_nivel.Text) && string.IsNullOrEmpty(Lt_ca_basico_calculado.Text) && string.IsNullOrEmpty(Lt_cp_descripcion.Text) && string.IsNullOrEmpty(Lt_eo_descripcion.Text))
        {
            P_p_descripcion.Visible = false;
            P_datos.Visible = false;
        }
        else
        {
            P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
            P_datos.Visible = true;
        }
        BindDDLTipoDocumentoImpreso();
        sc = "$('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // ============================================================
    // Guarda Datos Nueva Asignación Y Datos Glosa
    // ============================================================
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        DateTime? fec_baja = null;
        _asignacion = new cls_mp_asignacion();
        _puesto = new cls_puestos();
        _puesto.ObtenerId();
        var code = _puesto.p_id;
        var gestionFiltrar = Session["pr_id"].ToString();
        var tipo_reg = "I";
        var data = _asignacion.ObtenerTablaGrilla("", Lt_per_id.Text.Trim(), "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];
        var aux = false;

        if (data.Rows.Count > 0) { tipo_reg = "R"; }
        if (!string.IsNullOrEmpty(Txt_as_fecha_fin.Text)) { fec_baja = Convert.ToDateTime(Txt_as_fecha_fin.Text.Trim()); }

        _asignacion = new cls_mp_asignacion
        {
            as_per_id = Convert.ToInt32(id),
            as_ca_id = Convert.ToInt32(Hf_ca_id.Value),
            as_fecha_inicio = Convert.ToDateTime(Txt_as_fecha_inicio.Text.Trim()),
            as_fecha_fin = fec_baja,
            as_tipo_reg = tipo_reg,
            as_tipo_mov = Ddl_as_tipo_mov.SelectedValue,
            as_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString()),
            as_pr_id = Convert.ToInt32(gestionFiltrar),
        };
        var idAs = _asignacion.Adicionar();
        if (Convert.ToInt32(idAs) != 0)
        {
            _cargo = new cls_mp_cargo
            {
                ca_id_actual = Convert.ToInt32(Hf_ca_id.Value),
                ca_estado_actual = "O"
            };
            _cargo.ActualizarCargoActual();

            bool puestoYaExiste = false;
            _cargo_puesto = new cls_mp_cargo_puesto();
            var dataCP = _cargo_puesto.ObtenerTablaGrilla(Hf_ca_id.Value, "", "V", "").Tables[0];

            if (dataCP.Rows.Count > 0)
            {
                puestoYaExiste = true;
                code = Convert.ToInt32(dataCP.Rows[0]["cap_p_id"]);
            }

            if (!puestoYaExiste)
            {
                _puesto = new cls_puestos
                {
                    p_id = code,
                    p_descripcion = Txt_p_descripcion.Text.ToUpper().Trim()
                };
                _puesto.Adicionar();

                _cargo_puesto = new cls_mp_cargo_puesto
                {
                    cap_ca_id = Convert.ToInt32(Hf_ca_id.Value),
                    cap_p_id = code
                };
                _cargo_puesto.Adicionar();
            }

            _glosa = new cls_glosa
            {
                gl_valor_pk = idAs.ToString(),
                gl_nombre_pk = "as_id",
                gl_tabla = "tbl_mp_asignacion",
                gl_tipo_mov = 813,
                gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
                gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
                gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
                gl_usuario = Convert.ToInt32(Session["per_id"].ToString())
            };
            _glosa.Adicionar();

            if (ddlDocente.Visible == true)
                _asignacion.InsertarEscalafonDocente(Convert.ToInt32(ddlDocente.SelectedValue), Convert.ToInt32(_asignacion.as_per_id), "A");

            Limpiar("frm_asig_cl");
            Limpiar("frm_glosa_cl");
            Session["texto_notificacion"] = "Registro añadido correctamente...!!";
            sc = "$('#glosaModal').modal('hide');";
            SetScript(sc, "");
            Response.Redirect("Asignacion");
        }
        else
        {
            Limpiar("frm_asig_cl");
            Limpiar("frm_glosa_cl");
            Session["texto_notificacion_error"] = "La persona ya esta asignada con contrato";
            sc = "$('#glosaModal').modal('hide');";
            SetScript(sc, "");
            Response.Redirect("Asignacion");
        }
    }

    // ============================================================
    // Cierra Modal Glosa
    // ============================================================
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        Limpiar("frm_glosa_cl");

        if (Chk_hv_item.Checked) { P_dg_item.Visible = true; }
        else { P_dg_item.Visible = false; }

        if (Hf_ti_tipo_item_gral.Value.Equals("P")) { P_as_fecha_fin.Visible = false; }
        else if (Hf_ti_tipo_item_gral.Value.Equals("C")) { P_as_fecha_fin.Visible = true; }

        if (string.IsNullOrEmpty(Lt_es_descripcion.Text) && string.IsNullOrEmpty(Lt_ns_nivel.Text) && string.IsNullOrEmpty(Lt_ca_basico_calculado.Text) && string.IsNullOrEmpty(Lt_cp_descripcion.Text) && string.IsNullOrEmpty(Lt_eo_descripcion.Text))
        {
            P_p_descripcion.Visible = false;
            P_datos.Visible = false;
        }
        else
        {
            P_p_descripcion.Visible = false;  // ✅ SIEMPRE OCULTO
            P_datos.Visible = true;
        }
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // ============================================================
    // Validar Campos
    // ============================================================
    private string ValidarCampo(object p_campo)
    {
        string campo = "";
        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    // ============================================================
    // Ejecuta Scripts
    // ============================================================
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

    // ============================================================
    // Limpia Campos
    // ============================================================
    private void Limpiar(string val)
    {
        if (val.Equals("frm_asig_cl"))
        {
            Ddl_as_tipo_mov.Items.Clear();
            Txt_p_descripcion.Text = string.Empty;
            Txt_as_fecha_inicio.Text = string.Empty;
            Txt_as_fecha_fin.Text = string.Empty;
        }
        else if (val.Equals("frm_busq_cl"))
        {
            Txt_dg_item.Text = string.Empty;
        }
        else if (val.Equals("frm_item"))
        {
            Tv_nivelOrg.Nodes.Clear();
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}