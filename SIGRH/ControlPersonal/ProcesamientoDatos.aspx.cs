using Newtonsoft.Json.Linq;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_ProcesamientoDatos : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_permiso_categoria_programatica _permiso_cp = null;
    private cls_mp_cargo _cargo = null;
    private cls_persona _persona = null;
    private cls_mp_tipo_item _tipo_item = null;
    private cls_cp_asignacion_horario _asignacion_horario = null;
    private cls_cp_licencia_justificada _licencia = null;
    private cls_cp_ubicacion_fisica _ubicacion_fisica = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack) { CargaDatosPermisos(); BindDDLTipoProceso(); }
        }
        else { Response.Redirect("../Index"); }
    }

    // Carga Los Datos De Permisos Para El Usuario
    private void CargaDatosPermisos()
    {
        _permiso_cp = new cls_permiso_categoria_programatica();
        var var_cp_ue = "";
        var var_us_id = Session["us_id"].ToString();
        var var_pr_id = Session["pr_id"].ToString();
        var var_dt_pcp = _permiso_cp.ObtenerTablaGrilla("", "", "", "", "V", var_us_id, var_pr_id).Tables[0];

        foreach (DataRow item in var_dt_pcp.Rows) { var_cp_ue = (string.IsNullOrEmpty(var_cp_ue)) ? item["cp_ue"].ToString() : var_cp_ue + ", " + item["cp_ue"].ToString(); }
        Hf_cp_ue.Value = var_cp_ue;
    }

    // Carga Datos En El DropDownList (Ddl_tipo_proc)
    private void BindDDLTipoProceso()
    {
        Ddl_tipo_proc.Items.Insert(0, new ListItem("Selleccione...", "0"));
        Ddl_tipo_proc.Items.Insert(1, new ListItem("ASISTENCIA", "1"));
        Ddl_tipo_proc.Items.Insert(2, new ListItem("HORARIOS ESPECIALES", "2"));
        Ddl_tipo_proc.Items.Insert(3, new ListItem("HORARIOS MASIVOS", "3"));
        Ddl_tipo_proc.Items.Insert(4, new ListItem("LICENCIAS", "4"));
        Ddl_tipo_proc.DataBind();
    }

    // Carga Datos En El DropDownList (Ddl_cat_descripcion_ei)
    private void BindDDLUbicacion()
    {
        _catalogo = new cls_catalogo();
        Ddl_cat_descripcion_ei.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_cat_descripcion_ei.DataSource = _catalogo.ObtenerTablaGrilla("", "Edificio_Institucional", "", "", "", "", "", "", "", "V");
        Ddl_cat_descripcion_ei.DataValueField = "cat_secuencial";
        Ddl_cat_descripcion_ei.DataTextField = "cat_descripcion";
        Ddl_cat_descripcion_ei.DataBind();
    }

    // Carga Datos En El DropDownList (Ddl_cat_descripcion_ti)
    private void BindDDLTipoItem()
    {
        _tipo_item = new cls_mp_tipo_item();
        Ddl_cat_descripcion_ti.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_cat_descripcion_ti.DataSource = _tipo_item.ObtenerTablaGrilla("", "", "V", "", "", "", "", "", "");
        Ddl_cat_descripcion_ti.DataValueField = "ti_item";
        Ddl_cat_descripcion_ti.DataTextField = "ti_item_descripcion";
        Ddl_cat_descripcion_ti.DataBind();
    }

    // Carga Datos En Los GridView (Gv_lista_u, Gv_lista_f, Gv_lista_i)
    private void BindGridViewUFI(GridView par_lista, string par_tipo)
    {
        try
        {
            _asignacion_horario = new cls_cp_asignacion_horario { prma_usuario = Convert.ToInt32(Session["per_id"]) };

            if (par_tipo.Equals("ITEM")) { par_lista.DataSource = _asignacion_horario.LLenarTI(); }
            else { par_lista.DataSource = _asignacion_horario.ObtenerTablaGrillaUFI("", par_tipo, "", "", "", Session["per_id"].ToString()); }
            par_lista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Carga Datos En El GridView (Gv_lista_p)
    private void BindGridViewP(string par_per_id, string par_num_doc, string par_ap_pat, string par_ap_mat, string par_nom)
    {
        try
        {
            _persona = new cls_persona();
            Gv_lista_p.DataSource = _persona.ObtenerTablaGrillaHM(par_per_id, par_num_doc, par_ap_pat, par_ap_mat, par_nom, Session["pr_id"].ToString(), "", Hf_cp_ue.Value, "", "");
            Gv_lista_p.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Carga Datos En El TreeView (Tv_nivelOrg)
    private void ListarNivelOrg()
    {
        string gestionFiltrar = Session["pr_id"].ToString();

        try
        {
            _cargo = new cls_mp_cargo
            {
                eo_id = 11860,
                gestion_selec = gestionFiltrar
            };
            var nivelOrg = _cargo.ObtenerNivelOrg();
            //_cargo = new cls_mp_cargo
            //{
            //    cp_ue = 148,
            //    gestion_selec = gestionFiltrar
            //};
            //var nivelOrg = _cargo.ObtenerNivelOrgUE();

            foreach (DataRow level1DataRow in nivelOrg.Tables[0].Rows)
            {
                string eo_id = level1DataRow["eo_id"].ToString();
                //string eo_id = level1DataRow["cp_ue"].ToString();

                if (eo_id != "")
                {
                    TreeNode treeNode = new TreeNode();
                    treeNode.Value = level1DataRow["eo_id"].ToString();
                    //treeNode.Value = level1DataRow["cp_ue"].ToString();
                    treeNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0'>" + level1DataRow["eo_descripcion"].ToString() + "</h6></div></div>";
                    Tv_nivelOrg.Nodes.Add(treeNode);
                }
            }
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Evento Del DropDownList (Ddl_tipo_proc) Para Seleccionar El Tipo De Proceso
    protected void Ddl_tipo_proc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_ah_fecha_inicial.Text) || string.IsNullOrEmpty(Txt_ah_fecha_final.Text))
        {
            Limpiar("frm_ddl_cl");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los campos (FECHA INICIO) y/o (FECHA FIN) no pueden estar vacíos...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()) > Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()))
        {
            Limpiar("frm_ddl_cl");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (!(Gv_lista_u.Rows.Count > 0))
        {
            Limpiar("frm_ddl_cl");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar, al menos, una ubicación...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (!(Gv_lista_f.Rows.Count > 0))
        {
            Limpiar("frm_ddl_cl");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar, al menos, un funcionario(a)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        var dp = "";

        switch (Ddl_tipo_proc.SelectedValue)
        {
            case "1":
                break;
            case "2":
                if (Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()) != Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()))
                {
                    Limpiar("frm_ddl_cl");
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los campos (FECHA INICIO) y (FECHA FIN) no pueden ser mayores a 1 día...!!' }, { type: 'warning' });";
                    SetScript(sc, "");
                    return;
                }
                CargaDDLTipoHorario();
                BtnGuardarN.Text = "<i class='fas fa-plus mr-2'></i> Nuevo Horario";
                sc = "$('#fechaHorarioModal').modal('show');";
                dp = ", dropdownParent: $('#fechaHorarioModal')";
                break;
            case "3":
                CargaDDLTipoHorario();
                BtnGuardarN.Text = "<i class='fas fa-plus mr-2'></i> Generar Calendario";
                sc = "$('#fechaHorarioModal').modal('show');";
                dp = ", dropdownParent: $('#fechaHorarioModal')";
                break;
            case "4":
                CargaDDLTipoLicencia();
                CargaDatosProcesamiento("Licencia Justificada", "Tipo Proceso", Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()), Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()));
                Des_HabilitarComp("frm_if_cl", false);
                Des_HabilitarComp("frm_lj_cl", true);
                break;
            default:
                break;
        }
        Des_HabilitarComp("frm_ddl_cl", false);
        SetScript(sc, dp);
    }

    // Evento Del CheckBox (Chk_ei_todos) Para Adicionar Todas Las Ubicaciones
    protected void Chk_ei_todos_CheckedChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_ah_fecha_inicial.Text) || string.IsNullOrEmpty(Txt_ah_fecha_final.Text))
        {
            Chk_ei_todos.Checked = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los campos (FECHA INICIO) y/o (FECHA FIN) no pueden estar vacíos...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()) > Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()))
        {
            Limpiar("frm_ddl_cl");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        LimpiarEIDFTI("", "EDIFICIO", "", "");

        if (Chk_ei_todos.Checked)
        {
            LlenarEdificios();
            sc = "$.notify({ icon: 'fas fa-info', message: 'Registros añadidos correctamente...!!' }, { type: 'info' });";
        }
        else
        {
            Chk_df_todos.Checked = false;
            Chk_ti_todos.Checked = false;
            LimpiarEIDFTI("", "FUNCIONARIO", "", "");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Registros eliminados correctamente...!!' }, { type: 'warning' });";
        }
        CargaMuestraGVListas();
        SetScript(sc, "");
    }

    // Evento Del DropDownList (Ddl_cat_descripcion_ei) Para Adicionar Una Ubicación
    protected void Ddl_cat_descripcion_ei_SelectedIndexChanged(object sender, EventArgs e)
    {
        var var_fecha_ini = Txt_ah_fecha_inicial.Text.Trim();
        var var_fecha_fin = Txt_ah_fecha_final.Text.Trim();
        var ei_id = Convert.ToInt32(Ddl_cat_descripcion_ei.SelectedValue);
        var ei_descripcion = Ddl_cat_descripcion_ei.SelectedItem.Text.Trim();
        _asignacion_horario = new cls_cp_asignacion_horario
        {
            prma_id = ei_id,
            prma_tipo = "EDIFICIO",
            prma_descripcion = ei_descripcion,
            prma_ei_id = ei_id,
            ah_fecha_inicial = Convert.ToDateTime(var_fecha_ini),
            ah_fecha_final = Convert.ToDateTime(var_fecha_fin),
            prma_usuario = Convert.ToInt32(Session["per_id"])
        };
        _asignacion_horario.AdicionarEI();
        _asignacion_horario.AdicionarEDF();
        CargaMuestraGVListas();
        Limpiar("frm_ufi_cl");
        sc = "$.notify({ icon: 'fas fa-info', message: 'Registro añadido correctamente...!!' }, { type: 'info' }); $('#ubicacionModal').modal('hide');";
        SetScript(sc, "");
    }

    // Diseño Del GridView (Gv_lista_u)
    protected void Gv_lista_u_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_lista_u.Rows.Count > 0)
        {
            if (Gv_lista_u.HeaderRow != null) { Gv_lista_u.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_lista_u.FooterRow != null) { Gv_lista_u.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del GridView (Gv_lista_u)
    protected void Gv_lista_u_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = Gv_lista_u.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("BtnEliminar"))
        {
            LimpiarEIDFTI("", "FUNCIONARIO", code, "");
            LimpiarEIDFTI(code, "EDIFICIO", "", "");
            CargaMuestraGVListas();
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Registro eliminado correctamente...!!' }, { type: 'warning' });";
        }
        SetScript(sc, "");
    }

    // Evento Del CheckBox (Chk_df_todos) Para Adicionar Todas Los Funcionarios Según La Ubicación
    protected void Chk_df_todos_CheckedChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_ah_fecha_inicial.Text) || string.IsNullOrEmpty(Txt_ah_fecha_final.Text))
        {
            Chk_df_todos.Checked = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los campos (FECHA INICIO) y/o (FECHA FIN) no pueden estar vacíos...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()) > Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()))
        {
            Limpiar("frm_ddl_cl");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (!(Gv_lista_u.Rows.Count > 0))
        {
            Chk_df_todos.Checked = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar, al menos, una ubicación...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        var var_fecha_ini = Txt_ah_fecha_inicial.Text.Trim();
        var var_fecha_fin = Txt_ah_fecha_final.Text.Trim();
        LimpiarEIDFTI("", "FUNCIONARIO", "", "");

        if (Chk_df_todos.Checked)
        {
            Chk_ti_todos.Checked = true;
            LlenarFuncionarios(var_fecha_ini, var_fecha_fin);
            sc = "$.notify({ icon: 'fas fa-info', message: 'Registros añadidos correctamente...!!' }, { type: 'info' });";
        }
        else
        {
            Chk_ti_todos.Checked = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Registros eliminados correctamente...!!' }, { type: 'warning' });";
        }
        CargaMuestraGVListas();
        SetScript(sc, "");
    }

    // Diseño Del GridView (Gv_lista_p)
    protected void Gv_lista_p_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_lista_p.Rows.Count > 0)
        {
            if (Gv_lista_p.HeaderRow != null) { Gv_lista_p.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_lista_p.FooterRow != null) { Gv_lista_p.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del GridView (Gv_lista_p)
    protected void Gv_lista_p_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = Gv_lista_p.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("BtnSeleccionar"))
        {
            _ubicacion_fisica = new cls_cp_ubicacion_fisica();
            var var_fecha_ini = Txt_ah_fecha_inicial.Text.Trim();
            var var_fecha_fin = Txt_ah_fecha_final.Text.Trim();
            var var_dt_uf = _ubicacion_fisica.ObtenerTablaGrillaC("", code, "", "", "", "", "", "", "", "", "V").Tables[0];
            var var_ei_id = Convert.ToInt32(var_dt_uf.Rows[0]["uf_edificio"]);
            var var_ei_desc = var_dt_uf.Rows[0]["cat_descripcion"].ToString().ToUpper().Trim();
            _asignacion_horario = new cls_cp_asignacion_horario
            {
                prma_id = var_ei_id,
                prma_tipo = "EDIFICIO",
                prma_descripcion = var_ei_desc,
                prma_usuario = Convert.ToInt32(Session["per_id"])
            };
            var dataEI = _asignacion_horario.ObtenerTablaGrillaUFI(var_ei_id.ToString(), "EDIFICIO", "", "", "", Session["per_id"].ToString()).Tables[0];

            if (!(dataEI.Rows.Count > 0))
            {
                _asignacion_horario.AdicionarEI();
                sc = "$.notify({ icon: 'fas fa-info', message: 'Registro añadido correctamente...!!' }, { type: 'info' });";
            }
            _asignacion_horario = new cls_cp_asignacion_horario
            {
                ah_per_id = Convert.ToInt32(code),
                ah_fecha_inicial = Convert.ToDateTime(var_fecha_ini),
                ah_fecha_final = Convert.ToDateTime(var_fecha_fin),
                prma_usuario = Convert.ToInt32(Session["per_id"])
            };
            var dataDF = _asignacion_horario.ObtenerTablaGrillaUFI(code, "FUNCIONARIO", "", "", "", Session["per_id"].ToString()).Tables[0];

            if (dataDF.Rows.Count > 0) { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro ya fue añadido...!!' }, { type: 'warning' });"; }
            else { _asignacion_horario.AdicionarDF(); sc = "$.notify({ icon: 'fas fa-info', message: 'Registro añadido correctamente...!!' }, { type: 'info' });"; }
            CargaMuestraGVListas();
        }
        Limpiar("sch_cl");
        Limpiar("gv_cl");
        SetScript(sc, "");
    }

    // Evento TreeView
    protected void Tv_nivelOrg_SelectedNodeChanged(object sender, EventArgs e)
    {
        int _eo_id = Convert.ToInt32(Tv_nivelOrg.SelectedNode.Value);
        string gestionFiltrar = Session["pr_id"].ToString();
        _cargo = new cls_mp_cargo
        {
            ca_num_item = _eo_id,
            eo_id = _eo_id,
            gestion_selec = gestionFiltrar
        };
        var nivelOrg = _cargo.ObtenerNivelOrg();
        //_cargo = new cls_mp_cargo
        //{
        //    ca_num_item = _eo_id,
        //    cp_ue = _eo_id,
        //    gestion_selec = gestionFiltrar
        //};
        //var nivelOrg = _cargo.ObtenerNivelOrgUE();

        if (nivelOrg.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow lvlNDataRow in nivelOrg.Tables[0].Rows)
            {
                TreeNode childNode = new TreeNode();
                childNode.Value = lvlNDataRow["eo_id"].ToString();
                //childNode.Value = lvlNDataRow["cp_ue"].ToString();
                childNode.Text = "<div class='d-flex align-items-center'><div><div class='badge badge-circle icon-treeview mr-2'><i class='fas fa-layer-group'></i></div></div><div><h6 class='text-sm mt-1 mb-0 desc-treeview'>" + lvlNDataRow["eo_descripcion"].ToString().Trim() + " <small class='ls-1 mb-1 text-muted'>" + lvlNDataRow["cp_da"].ToString().Trim() + " - " + lvlNDataRow["cp_ue"].ToString().Trim() + " - " + lvlNDataRow["cp_programa"].ToString().Trim() + " - " + lvlNDataRow["cp_proyecto"].ToString().Trim() + " - " + lvlNDataRow["cp_actividad"].ToString().Trim() + " (" + lvlNDataRow["cp_fuente"].ToString().Trim() + " - " + lvlNDataRow["cp_organismo"].ToString().Trim().Trim() + ")</small></h6></div></div>";
                TreeNode parentNode = Tv_nivelOrg.SelectedNode;
                validarNodo(parentNode, childNode);
            }
        }
        else { sc = "$.notify({ icon: 'ni ni-bell-55', message: 'No existe subniveles para la Unidad Organizacional seleccionada...!!' }, { type: 'info', placement: { from: 'bottom', align: 'right'} });"; }
        Tv_nivelOrg.SelectedNode.Expand();
        SetScript(sc, "");
    }

    // Diseño Del GridView (Gv_lista_f)
    protected void Gv_lista_f_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_lista_f.Rows.Count > 0)
        {
            if (Gv_lista_f.HeaderRow != null) { Gv_lista_f.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_lista_f.FooterRow != null) { Gv_lista_f.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del GridView (Gv_lista_f)
    protected void Gv_lista_f_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = Gv_lista_f.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("BtnEliminar"))
        {
            LimpiarEIDFTI(code, "FUNCIONARIO", "", "");
            CargaMuestraGVListas();
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Registro eliminado correctamente...!!' }, { type: 'warning' });";
        }
        SetScript(sc, "");
    }

    // Evento Del CheckBox (Chk_ti_todos) Para Adicionar Todas Los Tipos De Ítem
    protected void Chk_ti_todos_CheckedChanged(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_ah_fecha_inicial.Text) || string.IsNullOrEmpty(Txt_ah_fecha_final.Text))
        {
            Chk_ti_todos.Checked = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Los campos (FECHA INICIO) y/o (FECHA FIN) no pueden estar vacíos...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()) > Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()))
        {
            Limpiar("frm_ddl_cl");
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (!(Gv_lista_u.Rows.Count > 0))
        {
            Chk_ti_todos.Checked = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe seleccionar, al menos, una ubicación...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        var var_fecha_ini = Txt_ah_fecha_inicial.Text.Trim();
        var var_fecha_fin = Txt_ah_fecha_final.Text.Trim();
        LimpiarEIDFTI("", "FUNCIONARIO", "", "");

        if (Chk_ti_todos.Checked)
        {
            Chk_df_todos.Checked = true;
            LlenarFuncionarios(var_fecha_ini, var_fecha_fin);
            sc = "$.notify({ icon: 'fas fa-info', message: 'Registros añadidos correctamente...!!' }, { type: 'info' });";
        }
        else
        {
            Chk_df_todos.Checked = false;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Registros eliminados correctamente...!!' }, { type: 'warning' });";
        }
        CargaMuestraGVListas();
        SetScript(sc, "");
    }

    // Evento Del DropDownList (Ddl_cat_descripcion_ti) Para Adicionar Un Tipo De Ítem
    protected void Ddl_cat_descripcion_ti_SelectedIndexChanged(object sender, EventArgs e)
    {
        var ti_id = Ddl_cat_descripcion_ti.SelectedValue;
        _asignacion_horario = new cls_cp_asignacion_horario
        {
            ah_fecha_inicial = Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()),
            ah_fecha_final = Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()),
            prma_ti_id = ti_id,
            prma_usuario = Convert.ToInt32(Session["per_id"])
        };
        _asignacion_horario.AdicionarIEI();
        _asignacion_horario.AdicionarTI();
        CargaMuestraGVListas();
        Limpiar("frm_ufi_cl");
        sc = "$.notify({ icon: 'fas fa-info', message: 'Registro añadido correctamente...!!' }, { type: 'info' }); $('#tipoItemModal').modal('hide');";
        SetScript(sc, "");
    }

    // Diseño Del GridView (Gv_lista_i)
    protected void Gv_lista_i_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_lista_i.Rows.Count > 0)
        {
            if (Gv_lista_i.HeaderRow != null) { Gv_lista_i.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_lista_i.FooterRow != null) { Gv_lista_i.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del GridView (Gv_lista_i)
    protected void Gv_lista_i_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = Gv_lista_i.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("BtnEliminar"))
        {
            LimpiarEIDFTI("", "FUNCIONARIO", "", code);
            CargaMuestraGVListas();
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Registro eliminado correctamente...!!' }, { type: 'warning' });";
        }
        SetScript(sc, "");
    }

    // Muestra El Modal Para Adicionar Una Ubicación
    protected void BtnAdicionarU_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()) > Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()))
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        BindDDLUbicacion();
        sc = "$('#ubicacionModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#ubicacionModal')");
    }

    // Cancela El Modal Para Adicionar Una Ubicación
    protected void BtnCancelarU_Click(object sender, EventArgs e)
    {
        Limpiar("frm_ufi_cl");
        sc = "$('#ubicacionModal').modal('hide');";
        SetScript(sc, "");
    }

    // Limpia Los Datos Del GridView (Gv_lista_u)
    protected void BtnLimpiarU_Click(object sender, EventArgs e)
    {
        Chk_ei_todos.Checked = false;
        Chk_df_todos.Checked = false;
        Chk_ti_todos.Checked = false;
        LimpiarEIDFTI("", "EDIFICIO", "", "");
        LimpiarEIDFTI("", "FUNCIONARIO", "", "");
        Limpiar("frm_ddl_cl");
        Des_HabilitarComp("frm_if_cl", true);
        Des_HabilitarComp("frm_ddl_cl", true);
        // Limpiar Horarios Especiales
        Limpiar("frm_he_cl");
        Des_HabilitarComp("frm_he_cl", false);
        // Limpiar Horarios Masivos
        LimpiarCalendario();
        LimpiarHorario();
        Limpiar("frm_th_cl");
        Limpiar("frm_hm_cl");
        Des_HabilitarComp("frm_hm_cl", false);
        // Limpiar Licencias Justificadas
        Limpiar("frm_lj_cl");
        Des_HabilitarComp("frm_lj_cl", false);
        Des_HabilitarComp("frm_hbt_h", true);
        //////////////////////////////////////////////////
        CargaMuestraGVListas();
        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Registros eliminados correctamente...!!' }, { type: 'warning' });";
        SetScript(sc, "");
    }

    // Muestra El Modal Para Adicionar Un Funcionario
    protected void BtnAdicionarP_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()) > Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()))
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        sc = "$('#busquedaModal').modal('show');";
        SetScript(sc, "");
    }

    // Busca Los Datos Del Funcionario Según Los Parámetros
    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(Txt_per_num_doc_b.Text) && string.IsNullOrEmpty(Txt_per_ap_paterno_b.Text) && string.IsNullOrEmpty(Txt_per_ap_materno_b.Text) && string.IsNullOrEmpty(Txt_per_nombres_b.Text) && string.IsNullOrEmpty(Txt_per_id_b.Text)) { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar algún parámetro de búsqueda...!!' }, { type: 'warning' });"; }
        else
        {
            BindGridViewP(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());
            Limpiar("sch_cl");

            if (Gv_lista_p.Rows.Count > 0) { P_result.Visible = true; }
            else
            {
                P_result.Visible = false;
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' });";
            }
        }
        SetScript(sc, "");
    }

    // Cancela El Modal Para Adicionar Un Funcionario
    protected void BtnCancelarP_Click(object sender, EventArgs e)
    {
        Limpiar("sch_cl");
        Limpiar("gv_cl");
        sc = "$('#busquedaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Muestra El Modal Para Adicionar Una Unidad Organizacional
    protected void BtnAdicionarUE_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()) > Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()))
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        ListarNivelOrg();
        sc = "$('#unidadOrganizacionalModal').modal('show');";
        SetScript(sc, "");
    }

    // Cancela El Modal Para Adicionar Una Unidad Organizacional
    protected void BtnCancelarUE_Click(object sender, EventArgs e)
    {
        Limpiar("frm_il_cl");
        sc = "$('#unidadOrganizacionalModal').modal('hide');";
        SetScript(sc, "");
    }

    // Limpia Los Datos Del GridView (Gv_lista_f)
    protected void BtnLimpiarF_Click(object sender, EventArgs e)
    {
        Chk_df_todos.Checked = false;
        Chk_ti_todos.Checked = false;
        LimpiarEIDFTI("", "FUNCIONARIO", "", "");
        Limpiar("frm_ddl_cl");
        Des_HabilitarComp("frm_if_cl", true);
        Des_HabilitarComp("frm_ddl_cl", true);
        Des_HabilitarComp("frm_he_cl", false);
        Des_HabilitarComp("frm_hm_cl", false);
        Des_HabilitarComp("frm_lj_cl", false);
        Des_HabilitarComp("frm_hbt_h", true);
        CargaMuestraGVListas();
        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Registros eliminados correctamente...!!' }, { type: 'warning' });";
        SetScript(sc, "");
    }

    // Muestra El Modal Para Adicionar Un Tipo Ítem
    protected void BtnAdicionarI_Click(object sender, EventArgs e)
    {
        if (Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()) > Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()))
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }
        BindDDLTipoItem();
        sc = "$('#tipoItemModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#tipoItemModal')");
    }

    // Cancela El Modal Para Adicionar Un Tipo Ítem
    protected void BtnCancelarI_Click(object sender, EventArgs e)
    {
        Limpiar("frm_ufi_cl");
        sc = "$('#tipoItemModal').modal('hide');";
        SetScript(sc, "");
    }

    // Limpia Los Datos Del GridView (Gv_lista_i)
    protected void BtnLimpiarI_Click(object sender, EventArgs e)
    {
        Chk_df_todos.Checked = false;
        Chk_ti_todos.Checked = false;
        LimpiarEIDFTI("", "FUNCIONARIO", "", "");
        Limpiar("frm_ddl_cl");
        Des_HabilitarComp("frm_if_cl", true);
        Des_HabilitarComp("frm_ddl_cl", true);
        Des_HabilitarComp("frm_he_cl", false);
        Des_HabilitarComp("frm_hm_cl", false);
        Des_HabilitarComp("frm_lj_cl", false);
        Des_HabilitarComp("frm_hbt_h", true);
        CargaMuestraGVListas();
        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Registros eliminados correctamente...!!' }, { type: 'warning' });";
        SetScript(sc, "");
    }

    // Mostrar Formulario De Horarios 
    protected void BtnGuardarN_Click(object sender, EventArgs e)
    {
        var var_fecha_ini = Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim());
        var var_fecha_fin = Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim());
        Des_HabilitarComp("frm_if_cl", false);

        if (var_fecha_ini > var_fecha_fin)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        switch (Ddl_tipo_proc.SelectedValue)
        {
            case "2":
                var var_marc_tolr = Hf_marc_tolr.Value.Split(',');

                if (var_marc_tolr[0].ToString().Equals("2")) { P_he_is_2.Visible = false; }
                else { P_he_is_2.Visible = true; }
                Des_HabilitarComp("frm_he_cl", true);
                CargaDatosProcesamiento("Horario Especial", "Tipo Horario", var_fecha_ini, var_fecha_fin);
                sc = "$('#fechaHorarioModal').modal('hide');";
                break;
            case "3":
                Des_HabilitarComp("frm_hm_cl", true);
                CargaDatosProcesamiento("Horario Masivo", "Tipo Horario", var_fecha_ini, var_fecha_fin);
                BtnGuardar.Visible = false;
                LimpiarHorario();
                CargaGVCalendario(var_fecha_ini.ToString("dd/MM/yyyy"), var_fecha_fin.ToString("dd/MM/yyyy"));
                sc = "$('#fechaHorarioModal').modal('hide');";
                break;
            default:
                break;
        }
        Limpiar("frm_th_cl");
        SetScript(sc, "");
    }

    // Cancela Mostrar Formulario De Horarios
    protected void BtnCancelarN_Click(object sender, EventArgs e)
    {
        Limpiar("frm_ddl_cl");
        Limpiar("frm_th_cl");
        Des_HabilitarComp("frm_ddl_cl", true);
        sc = "$('#fechaHorarioModal').modal('hide');";
        SetScript(sc, "");
    }

    /**********************************************************************/
    /********************** MÉTODOS HORARIO ESPECIAL **********************/
    /**********************************************************************/
    // Carga Datos En El DropDownList (Ddl_ah_tipo_horario)
    private void CargaDDLTipoHorario()
    {
        _catalogo = new cls_catalogo();
        Ddl_ah_tipo_horario.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_ah_tipo_horario.DataSource = _catalogo.ObtenerTablaGrilla("", "Tipo_Horario", "", "", "", "", "", "", "", "V");
        Ddl_ah_tipo_horario.DataValueField = "cat_secuencial";
        Ddl_ah_tipo_horario.DataTextField = "cat_descripcion";
        Ddl_ah_tipo_horario.DataBind();
    }

    // Alta Horario Especial
    protected void BtnGuardarHE_Click(object sender, EventArgs e)
    {
        BindDDLTipoDocumentoImpreso();
        sc = "$('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Cancela Alta Horario Especial
    protected void BtnCancelarHE_Click(object sender, EventArgs e)
    {
        Limpiar("frm_ddl_cl");
        Limpiar("frm_he_cl");
        Des_HabilitarComp("frm_if_cl", true);
        Des_HabilitarComp("frm_ddl_cl", true);
        Des_HabilitarComp("frm_he_cl", false);
        SetScript("", "");
    }

    /****************************************************************/
    /******************** MÉTODOS HORARIO MASIVO ********************/
    /****************************************************************/
    // Carga Datos En El GridView (Gv_calendario)
    private void CargaGVCalendario(string par_fec_ini, string par_fec_fin)
    {
        try
        {
            _asignacion_horario = new cls_cp_asignacion_horario();
            Gv_calendario.DataSource = _asignacion_horario.ObtenerTablaGrillaCH(Session["per_id"].ToString(), par_fec_ini, par_fec_fin);
            Gv_calendario.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Evento Del RadioButtonList (Rbl_th_tipo)
    protected void Rbl_th_tipo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Rbl_th_tipo.SelectedValue.Equals("1"))
        {
            P_tipo_sem.Visible = true;
            P_tipo_dia_sem.Visible = true;
            P_tipo_dia.Visible = false;
        }
        else
        {
            P_tipo_sem.Visible = false;
            P_tipo_dia_sem.Visible = false;
            P_tipo_dia.Visible = true;
        }
        SetScript("", "");
    }

    // Evento Del DropDownList (Ddl_ah_tipo_horario)
    protected void Ddl_ah_tipo_horario_SelectedIndexChanged(object sender, EventArgs e)
    {
        _catalogo = new cls_catalogo();
        var var_dat_tiphor = _catalogo.ObtenerTablaGrilla("", "Tipo_Horario", Ddl_ah_tipo_horario.SelectedValue, "", "", "", "", "", "", "V").Tables[0];

        if (var_dat_tiphor.Rows.Count > 0)
        {
            var var_ary = JArray.Parse(var_dat_tiphor.Rows[0]["cat_adicional"].ToString());
            var var_obj = JObject.Parse(var_ary[0].ToString());
            var marca = var_obj["marca"].ToString();
            var toler = var_obj["toler"].ToString();
            Hf_marc_tolr.Value = marca + ',' + toler;
        }
        SetScript("", ", dropdownParent: $('#fechaHorarioModal')");
    }

    // Evento Del CheckBox (Chk_habilitar_c) Para Habilitar Casillas
    protected void Chk_habilitar_c_CheckedChanged(object sender, EventArgs e)
    {
        if (Chk_habilitar_c.Checked) { HabilitarCheckBoxGrilla(true); }
        else
        {
            HabilitarCheckBoxGrilla(false);
            //var id = Session["per_id"].ToString();
            //CargaGVCalendario(id, Txt_ah_fecha_inicial.Text.Trim(), Txt_ah_fecha_final.Text.Trim());
        }
        //SetScript("", "");
    }

    // Diseño Del GridView (Gv_calendario)
    protected void Gv_calendario_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) { return; }

        var id = Session["per_id"].ToString();
        _asignacion_horario = new cls_cp_asignacion_horario();
        LinkButton Lnk_sem = (LinkButton)e.Row.FindControl("Lnk_tds_sem");
        LinkButton Lnk_lun = (LinkButton)e.Row.FindControl("Lnk_tds_lun");
        LinkButton Lnk_mar = (LinkButton)e.Row.FindControl("Lnk_tds_mar");
        LinkButton Lnk_mie = (LinkButton)e.Row.FindControl("Lnk_tds_mie");
        LinkButton Lnk_jue = (LinkButton)e.Row.FindControl("Lnk_tds_jue");
        LinkButton Lnk_vie = (LinkButton)e.Row.FindControl("Lnk_tds_vie");
        LinkButton Lnk_sab = (LinkButton)e.Row.FindControl("Lnk_tds_sab");
        LinkButton Lnk_dom = (LinkButton)e.Row.FindControl("Lnk_tds_dom");
        Panel P_gv_lun = (Panel)e.Row.FindControl("P_gv_tds_lun");
        Panel P_gv_mar = (Panel)e.Row.FindControl("P_gv_tds_mar");
        Panel P_gv_mie = (Panel)e.Row.FindControl("P_gv_tds_mie");
        Panel P_gv_jue = (Panel)e.Row.FindControl("P_gv_tds_jue");
        Panel P_gv_vie = (Panel)e.Row.FindControl("P_gv_tds_vie");
        Panel P_gv_sab = (Panel)e.Row.FindControl("P_gv_tds_sab");
        Panel P_gv_dom = (Panel)e.Row.FindControl("P_gv_tds_dom");
        GridView Gv_lun = (GridView)e.Row.FindControl("Gv_tds_lun");
        GridView Gv_mar = (GridView)e.Row.FindControl("Gv_tds_mar");
        GridView Gv_mie = (GridView)e.Row.FindControl("Gv_tds_mie");
        GridView Gv_jue = (GridView)e.Row.FindControl("Gv_tds_jue");
        GridView Gv_vie = (GridView)e.Row.FindControl("Gv_tds_vie");
        GridView Gv_sab = (GridView)e.Row.FindControl("Gv_tds_sab");
        GridView Gv_dom = (GridView)e.Row.FindControl("Gv_tds_dom");
        string bgc_p = "rgba(255, 0, 52, .65)", bgc_t = "rgba(255, 50, 0, .5)";

        if (Lnk_lun.Text != "")
        {
            var dataHC = _asignacion_horario.ObtenerTablaGrillaHC(id, Lnk_sem.CommandArgument.Trim(), Lnk_lun.Text.Trim()).Tables[0];

            if (dataHC.Rows.Count > 0)
            {
                P_gv_lun.Visible = true;
                Gv_lun.DataSource = dataHC;
                Gv_lun.DataBind();

                if (!(string.IsNullOrEmpty(dataHC.Rows[0]["th_json"].ToString())))
                {
                    var ary = JArray.Parse(dataHC.Rows[0]["th_json"].ToString());
                    var obj = JObject.Parse(ary[0].ToString());

                    if (obj["tipo"].ToString().Equals("NP"))
                    {
                        Gv_lun.Rows[0].Cells[0].BackColor = Color.FromName(bgc_p);
                        Gv_lun.Rows[0].Cells[1].BackColor = Color.FromName(bgc_p);

                        if (obj["ing2"] != null)
                        {
                            Gv_lun.Rows[1].Cells[0].BackColor = Color.FromName(bgc_p);
                            Gv_lun.Rows[1].Cells[1].BackColor = Color.FromName(bgc_p);
                        }
                    }
                    else
                    {
                        if (obj["ing1"].ToString().Equals("N")) { Gv_lun.Rows[0].Cells[0].BackColor = Color.FromName(bgc_t); }
                        if (obj["ing2"] != null) { if (obj["ing2"].ToString().Equals("N")) { Gv_lun.Rows[1].Cells[0].BackColor = Color.FromName(bgc_t); } }
                    }
                }
            }
        }

        if (Lnk_mar.Text != "")
        {
            var dataHC = _asignacion_horario.ObtenerTablaGrillaHC(id, Lnk_sem.CommandArgument.Trim(), Lnk_mar.Text.Trim()).Tables[0];

            if (dataHC.Rows.Count > 0)
            {
                P_gv_mar.Visible = true;
                Gv_mar.DataSource = dataHC;
                Gv_mar.DataBind();

                if (!(string.IsNullOrEmpty(dataHC.Rows[0]["th_json"].ToString())))
                {
                    var ary = JArray.Parse(dataHC.Rows[0]["th_json"].ToString());
                    var obj = JObject.Parse(ary[0].ToString());

                    if (obj["tipo"].ToString().Equals("NP"))
                    {
                        Gv_mar.Rows[0].Cells[0].BackColor = Color.FromName(bgc_p);
                        Gv_mar.Rows[0].Cells[1].BackColor = Color.FromName(bgc_p);

                        if (obj["ing2"] != null)
                        {
                            Gv_mar.Rows[1].Cells[0].BackColor = Color.FromName(bgc_p);
                            Gv_mar.Rows[1].Cells[1].BackColor = Color.FromName(bgc_p);
                        }
                    }
                    else
                    {
                        if (obj["ing1"].ToString().Equals("N")) { Gv_mar.Rows[0].Cells[0].BackColor = Color.FromName(bgc_t); }
                        if (obj["ing2"] != null) { if (obj["ing2"].ToString().Equals("N")) { Gv_mar.Rows[1].Cells[0].BackColor = Color.FromName(bgc_t); } }
                    }
                }
            }
        }

        if (Lnk_mie.Text != "")
        {
            var dataHC = _asignacion_horario.ObtenerTablaGrillaHC(id, Lnk_sem.CommandArgument.Trim(), Lnk_mie.Text.Trim()).Tables[0];

            if (dataHC.Rows.Count > 0)
            {
                P_gv_mie.Visible = true;
                Gv_mie.DataSource = dataHC;
                Gv_mie.DataBind();

                if (!(string.IsNullOrEmpty(dataHC.Rows[0]["th_json"].ToString())))
                {
                    var ary = JArray.Parse(dataHC.Rows[0]["th_json"].ToString());
                    var obj = JObject.Parse(ary[0].ToString());

                    if (obj["tipo"].ToString().Equals("NP"))
                    {
                        Gv_mie.Rows[0].Cells[0].BackColor = Color.FromName(bgc_p);
                        Gv_mie.Rows[0].Cells[1].BackColor = Color.FromName(bgc_p);

                        if (obj["ing2"] != null)
                        {
                            Gv_mie.Rows[1].Cells[0].BackColor = Color.FromName(bgc_p);
                            Gv_mie.Rows[1].Cells[1].BackColor = Color.FromName(bgc_p);
                        }
                    }
                    else
                    {
                        if (obj["ing1"].ToString().Equals("N")) { Gv_mie.Rows[0].Cells[0].BackColor = Color.FromName(bgc_t); }
                        if (obj["ing2"] != null) { if (obj["ing2"].ToString().Equals("N")) { Gv_mie.Rows[1].Cells[0].BackColor = Color.FromName(bgc_t); } }
                    }
                }
            }
        }

        if (Lnk_jue.Text != "")
        {
            var dataHC = _asignacion_horario.ObtenerTablaGrillaHC(id, Lnk_sem.CommandArgument.Trim(), Lnk_jue.Text.Trim()).Tables[0];

            if (dataHC.Rows.Count > 0)
            {
                P_gv_jue.Visible = true;
                Gv_jue.DataSource = dataHC;
                Gv_jue.DataBind();

                if (!(string.IsNullOrEmpty(dataHC.Rows[0]["th_json"].ToString())))
                {
                    var ary = JArray.Parse(dataHC.Rows[0]["th_json"].ToString());
                    var obj = JObject.Parse(ary[0].ToString());

                    if (obj["tipo"].ToString().Equals("NP"))
                    {
                        Gv_jue.Rows[0].Cells[0].BackColor = Color.FromName(bgc_p);
                        Gv_jue.Rows[0].Cells[1].BackColor = Color.FromName(bgc_p);

                        if (obj["ing2"] != null)
                        {
                            Gv_jue.Rows[1].Cells[0].BackColor = Color.FromName(bgc_p);
                            Gv_jue.Rows[1].Cells[1].BackColor = Color.FromName(bgc_p);
                        }
                    }
                    else
                    {
                        if (obj["ing1"].ToString().Equals("N")) { Gv_jue.Rows[0].Cells[0].BackColor = Color.FromName(bgc_t); }
                        if (obj["ing2"] != null) { if (obj["ing2"].ToString().Equals("N")) { Gv_jue.Rows[1].Cells[0].BackColor = Color.FromName(bgc_t); } }
                    }
                }
            }
        }

        if (Lnk_vie.Text != "")
        {
            var dataHC = _asignacion_horario.ObtenerTablaGrillaHC(id, Lnk_sem.CommandArgument.Trim(), Lnk_vie.Text.Trim()).Tables[0];

            if (dataHC.Rows.Count > 0)
            {
                P_gv_vie.Visible = true;
                Gv_vie.DataSource = dataHC;
                Gv_vie.DataBind();

                if (!(string.IsNullOrEmpty(dataHC.Rows[0]["th_json"].ToString())))
                {
                    var ary = JArray.Parse(dataHC.Rows[0]["th_json"].ToString());
                    var obj = JObject.Parse(ary[0].ToString());

                    if (obj["tipo"].ToString().Equals("NP"))
                    {
                        Gv_vie.Rows[0].Cells[0].BackColor = Color.FromName(bgc_p);
                        Gv_vie.Rows[0].Cells[1].BackColor = Color.FromName(bgc_p);

                        if (obj["ing2"] != null)
                        {
                            Gv_vie.Rows[1].Cells[0].BackColor = Color.FromName(bgc_p);
                            Gv_vie.Rows[1].Cells[1].BackColor = Color.FromName(bgc_p);
                        }
                    }
                    else
                    {
                        if (obj["ing1"].ToString().Equals("N")) { Gv_vie.Rows[0].Cells[0].BackColor = Color.FromName(bgc_t); }
                        if (obj["ing2"] != null) { if (obj["ing2"].ToString().Equals("N")) { Gv_vie.Rows[1].Cells[0].BackColor = Color.FromName(bgc_t); } }
                    }
                }
            }
        }

        if (Lnk_sab.Text != "")
        {
            var dataHC = _asignacion_horario.ObtenerTablaGrillaHC(id, Lnk_sem.CommandArgument.Trim(), Lnk_sab.Text.Trim()).Tables[0];

            if (dataHC.Rows.Count > 0)
            {
                P_gv_sab.Visible = true;
                Gv_sab.DataSource = dataHC;
                Gv_sab.DataBind();

                if (!(string.IsNullOrEmpty(dataHC.Rows[0]["th_json"].ToString())))
                {
                    var ary = JArray.Parse(dataHC.Rows[0]["th_json"].ToString());
                    var obj = JObject.Parse(ary[0].ToString());

                    if (obj["tipo"].ToString().Equals("NP"))
                    {
                        Gv_sab.Rows[0].Cells[0].BackColor = Color.FromName(bgc_p);
                        Gv_sab.Rows[0].Cells[1].BackColor = Color.FromName(bgc_p);

                        if (obj["ing2"] != null)
                        {
                            Gv_sab.Rows[1].Cells[0].BackColor = Color.FromName(bgc_p);
                            Gv_sab.Rows[1].Cells[1].BackColor = Color.FromName(bgc_p);
                        }
                    }
                    else
                    {
                        if (obj["ing1"].ToString().Equals("N")) { Gv_sab.Rows[0].Cells[0].BackColor = Color.FromName(bgc_t); }
                        if (obj["ing2"] != null) { if (obj["ing2"].ToString().Equals("N")) { Gv_sab.Rows[1].Cells[0].BackColor = Color.FromName(bgc_t); } }
                    }
                }
            }
        }

        if (Lnk_dom.Text != "")
        {
            var dataHC = _asignacion_horario.ObtenerTablaGrillaHC(id, Lnk_sem.CommandArgument.Trim(), Lnk_dom.Text.Trim()).Tables[0];

            if (dataHC.Rows.Count > 0)
            {
                P_gv_dom.Visible = true;
                Gv_dom.DataSource = dataHC;
                Gv_dom.DataBind();

                if (!(string.IsNullOrEmpty(dataHC.Rows[0]["th_json"].ToString())))
                {
                    var ary = JArray.Parse(dataHC.Rows[0]["th_json"].ToString());
                    var obj = JObject.Parse(ary[0].ToString());

                    if (obj["tipo"].ToString().Equals("NP"))
                    {
                        Gv_dom.Rows[0].Cells[0].BackColor = Color.FromName(bgc_p);
                        Gv_dom.Rows[0].Cells[1].BackColor = Color.FromName(bgc_p);

                        if (obj["ing2"] != null)
                        {
                            Gv_dom.Rows[1].Cells[0].BackColor = Color.FromName(bgc_p);
                            Gv_dom.Rows[1].Cells[1].BackColor = Color.FromName(bgc_p);
                        }
                    }
                    else
                    {
                        if (obj["ing1"].ToString().Equals("N")) { Gv_dom.Rows[0].Cells[0].BackColor = Color.FromName(bgc_t); }
                        if (obj["ing2"] != null) { if (obj["ing2"].ToString().Equals("N")) { Gv_dom.Rows[1].Cells[0].BackColor = Color.FromName(bgc_t); } }
                    }
                }
            }
        }
    }

    // Alta Horario (Parcial)
    protected void BtnGuardarH_Click(object sender, EventArgs e)
    {
        _asignacion_horario = new cls_cp_asignacion_horario();
        var id = Session["per_id"].ToString();
        var fecha_ini = Lt_pd_fecha_inicial.Text;
        var fecha_fin = Lt_pd_fecha_final.Text;
        string tipo_p = "", tipo_t1 = "", tipo_t2 = "";

        if (!Chk_th_presencial.Checked || !Chk_th_tolr_ing1.Checked || !Chk_th_tolr_ing2.Checked)
        {
            if (Chk_th_presencial.Checked)
            {
                tipo_p = "P";

                if (Chk_th_tolr_ing1.Checked) { tipo_t1 = "S"; }
                else { tipo_t1 = "N"; }

                if (!string.IsNullOrEmpty(Txt_th_ing2.Text) && !string.IsNullOrEmpty(Txt_th_sal2.Text))
                {
                    if (Chk_th_tolr_ing2.Checked) { tipo_t2 = "S"; }
                    else { tipo_t2 = "N"; }
                }
            }
            else
            {
                tipo_p = "NP";

                if (Chk_th_tolr_ing1.Checked) { tipo_t1 = "S"; }
                else { tipo_t1 = "N"; }

                if (!string.IsNullOrEmpty(Txt_th_ing2.Text) && !string.IsNullOrEmpty(Txt_th_sal2.Text))
                {
                    if (Chk_th_tolr_ing2.Checked) { tipo_t2 = "S"; }
                    else { tipo_t2 = "N"; }
                }
            }
        }

        if (Chk_habilitar_c.Checked)
        {
            foreach (GridViewRow item in Gv_calendario.Rows)
            {
                CheckBox Chk_lun = (CheckBox)item.FindControl("Chk_tds_lun");
                CheckBox Chk_mar = (CheckBox)item.FindControl("Chk_tds_mar");
                CheckBox Chk_mie = (CheckBox)item.FindControl("Chk_tds_mie");
                CheckBox Chk_jue = (CheckBox)item.FindControl("Chk_tds_jue");
                CheckBox Chk_vie = (CheckBox)item.FindControl("Chk_tds_vie");
                CheckBox Chk_sab = (CheckBox)item.FindControl("Chk_tds_sab");
                CheckBox Chk_dom = (CheckBox)item.FindControl("Chk_tds_dom");

                if (Chk_lun.Checked)
                {
                    LinkButton Lnk_lun = (LinkButton)item.FindControl("Lnk_tds_lun");
                    _asignacion_horario.ModificarHC(id, Lnk_lun.CommandArgument, Lnk_lun.Text.Trim(), Txt_th_ing1.Text.Trim(), Txt_th_sal1.Text.Trim(), Txt_th_ing2.Text.Trim(), Txt_th_sal2.Text.Trim(), tipo_p, tipo_t1, tipo_t2);
                }
                if (Chk_mar.Checked)
                {
                    LinkButton Lnk_mar = (LinkButton)item.FindControl("Lnk_tds_mar");
                    _asignacion_horario.ModificarHC(id, Lnk_mar.CommandArgument, Lnk_mar.Text.Trim(), Txt_th_ing1.Text.Trim(), Txt_th_sal1.Text.Trim(), Txt_th_ing2.Text.Trim(), Txt_th_sal2.Text.Trim(), tipo_p, tipo_t1, tipo_t2);
                }
                if (Chk_mie.Checked)
                {
                    LinkButton Lnk_mie = (LinkButton)item.FindControl("Lnk_tds_mie");
                    _asignacion_horario.ModificarHC(id, Lnk_mie.CommandArgument, Lnk_mie.Text.Trim(), Txt_th_ing1.Text.Trim(), Txt_th_sal1.Text.Trim(), Txt_th_ing2.Text.Trim(), Txt_th_sal2.Text.Trim(), tipo_p, tipo_t1, tipo_t2);
                }
                if (Chk_jue.Checked)
                {
                    LinkButton Lnk_jue = (LinkButton)item.FindControl("Lnk_tds_jue");
                    _asignacion_horario.ModificarHC(id, Lnk_jue.CommandArgument, Lnk_jue.Text.Trim(), Txt_th_ing1.Text.Trim(), Txt_th_sal1.Text.Trim(), Txt_th_ing2.Text.Trim(), Txt_th_sal2.Text.Trim(), tipo_p, tipo_t1, tipo_t2);
                }
                if (Chk_vie.Checked)
                {
                    LinkButton Lnk_vie = (LinkButton)item.FindControl("Lnk_tds_vie");
                    _asignacion_horario.ModificarHC(id, Lnk_vie.CommandArgument, Lnk_vie.Text.Trim(), Txt_th_ing1.Text.Trim(), Txt_th_sal1.Text.Trim(), Txt_th_ing2.Text.Trim(), Txt_th_sal2.Text.Trim(), tipo_p, tipo_t1, tipo_t2);
                }
                if (Chk_sab.Checked)
                {
                    LinkButton Lnk_sab = (LinkButton)item.FindControl("Lnk_tds_sab");
                    _asignacion_horario.ModificarHC(id, Lnk_sab.CommandArgument, Lnk_sab.Text.Trim(), Txt_th_ing1.Text.Trim(), Txt_th_sal1.Text.Trim(), Txt_th_ing2.Text.Trim(), Txt_th_sal2.Text.Trim(), tipo_p, tipo_t1, tipo_t2);
                }
                if (Chk_dom.Checked)
                {
                    LinkButton Lnk_dom = (LinkButton)item.FindControl("Lnk_tds_dom");
                    _asignacion_horario.ModificarHC(id, Lnk_dom.CommandArgument, Lnk_dom.Text.Trim(), Txt_th_ing1.Text.Trim(), Txt_th_sal1.Text.Trim(), Txt_th_ing2.Text.Trim(), Txt_th_sal2.Text.Trim(), tipo_p, tipo_t1, tipo_t2);
                }
            }
            Chk_habilitar_c.Checked = false;
        }
        else if (Hf_modal_hd.Value.Equals("MHD")) { _asignacion_horario.ModificarHC(id, Hf_modal_hd_sem.Value, Hf_modal_hd_dia.Value, Txt_th_ing1.Text.Trim(), Txt_th_sal1.Text.Trim(), Txt_th_ing2.Text.Trim(), Txt_th_sal2.Text.Trim(), tipo_p, tipo_t1, tipo_t2); }
        else
        {
            _asignacion_horario.GenerarHorario(id, Txt_th_ing1.Text.Trim(), Txt_th_sal1.Text.Trim(), Txt_th_ing2.Text.Trim(), Txt_th_sal2.Text.Trim(), Rbl_th_tipo.SelectedValue, Rbl_th_semana.SelectedValue, Rbl_th_tipo_dia.SelectedValue, Cbl_th_dia.Items[0].Selected.ToString(), Cbl_th_dia.Items[1].Selected.ToString(), Cbl_th_dia.Items[2].Selected.ToString(), Cbl_th_dia.Items[3].Selected.ToString(), Cbl_th_dia.Items[4].Selected.ToString(), Cbl_th_dia.Items[5].Selected.ToString(), Cbl_th_dia.Items[6].Selected.ToString(), tipo_p, tipo_t1, tipo_t2);
        }
        Hf_modal_hd.Value = string.Empty;
        BtnGuardar.Visible = true;
        Limpiar("frm_hm_cl");
        CargaGVCalendario(fecha_ini, fecha_fin);
        sc = "$('#horarioModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancela Alta Horario (Parcial)
    protected void BtnCancelarH_Click(object sender, EventArgs e)
    {
        //var id = Session["per_id"].ToString();
        //var var_fecha_ini = Lt_pd_fecha_inicial.Text;
        //var var_fecha_fin = Lt_pd_fecha_final.Text;
        Hf_modal_hd.Value = string.Empty;
        BtnGuardar.Visible = (BtnGuardar.Visible) ? true : false;
        //CargaGVCalendario(var_fecha_ini, var_fecha_fin);

        if (Chk_habilitar_c.Checked) { HabilitarCheckBoxGrilla(true); }
        else { HabilitarCheckBoxGrilla(false); }
        Limpiar("frm_hm_cl");
        sc = "$('#horarioModal').modal('hide');";
        SetScript(sc, "");
    }

    // Llenar Horario
    protected void BtnLlenarH_Click(object sender, EventArgs e)
    {
        var var_marc_tolr = Hf_marc_tolr.Value.Split(',');

        if (var_marc_tolr[1].ToString().Equals("S"))
        {
            P_tol1.Visible = false;
            P_tol2.Visible = false;
        }
        else
        {
            P_tol1.Visible = true;
            P_tol2.Visible = true;
        }

        if (var_marc_tolr[0].ToString().Equals("2")) { P_hm_is_2.Visible = false; }
        else { P_hm_is_2.Visible = true; }

        if (Chk_habilitar_c.Checked)
        {
            var cont = 0;
            P_grupo_sd.Visible = false;

            foreach (GridViewRow item in Gv_calendario.Rows)
            {
                CheckBox Chk_lun = (CheckBox)item.FindControl("Chk_tds_lun");
                CheckBox Chk_mar = (CheckBox)item.FindControl("Chk_tds_mar");
                CheckBox Chk_mie = (CheckBox)item.FindControl("Chk_tds_mie");
                CheckBox Chk_jue = (CheckBox)item.FindControl("Chk_tds_jue");
                CheckBox Chk_vie = (CheckBox)item.FindControl("Chk_tds_vie");
                CheckBox Chk_sab = (CheckBox)item.FindControl("Chk_tds_sab");
                CheckBox Chk_dom = (CheckBox)item.FindControl("Chk_tds_dom");

                if (Chk_lun.Checked) { cont++; }
                if (Chk_mar.Checked) { cont++; }
                if (Chk_mie.Checked) { cont++; }
                if (Chk_jue.Checked) { cont++; }
                if (Chk_vie.Checked) { cont++; }
                if (Chk_sab.Checked) { cont++; }
                if (Chk_dom.Checked) { cont++; }
            }

            if (cont > 0) { sc = "$('#horarioModal').modal('show');"; }
            else { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe marcar al menos una fecha para llenar el horario...!!' }, { type: 'warning' });"; }
            HabilitarCheckBoxGrilla(true);
        }
        else { sc = "$('#horarioModal').modal('show');"; P_grupo_sd.Visible = true; }
        SetScript(sc, "");
    }

    // Limpia Horario
    protected void BtnLimpiarH_Click(object sender, EventArgs e)
    {
        var var_fecha_ini = Lt_pd_fecha_inicial.Text.Trim();
        var var_fecha_fin = Lt_pd_fecha_final.Text.Trim();
        Chk_habilitar_c.Checked = false;
        BtnGuardar.Visible = false;
        LimpiarHorario();
        CargaGVCalendario(var_fecha_ini, var_fecha_fin);
        SetScript("", "");
    }

    // Alta Horario
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        BindDDLTipoDocumentoImpreso();
        sc = "$('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Cancela Alta Horario
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        LimpiarCalendario();
        LimpiarHorario();
        Limpiar("frm_ddl_cl");
        Limpiar("frm_th_cl");
        Limpiar("frm_hm_cl");
        Des_HabilitarComp("frm_ddl_cl", true);
        Des_HabilitarComp("frm_if_cl", true);
        Des_HabilitarComp("frm_hm_cl", false);
        SetScript("", "");
    }

    // Alta Horario Por Fecha (Parcial)
    protected void HorarioModal_Click(object sender, EventArgs e)
    {
        Hf_modal_hd.Value = "MHD";
        Hf_modal_hd_sem.Value = ((LinkButton)sender).CommandArgument;
        Hf_modal_hd_dia.Value = ((LinkButton)sender).Text;
        P_grupo_sd.Visible = false;
        var var_marc_tolr = Hf_marc_tolr.Value.Split(',');

        if (var_marc_tolr[1].ToString().Equals("S"))
        {
            P_tol1.Visible = false;
            P_tol2.Visible = false;
        }
        else
        {
            P_tol1.Visible = true;
            P_tol2.Visible = true;
        }

        if (var_marc_tolr[0].ToString().Equals("2")) { P_hm_is_2.Visible = false; }
        else { P_hm_is_2.Visible = true; }
        sc = "$('#horarioModal').modal('show');";
        SetScript(sc, "");
    }

    /**********************************************************************/
    /******************** MÉTODOS LICENCIA JUSTIFICADA ********************/
    /**********************************************************************/
    // Carga Datos En El Gridview (Gv_lista_l)
    private void CargaGVLicencias(DataTable par_dt_lj)
    {
        try
        {
            Gv_lista_l.DataSource = par_dt_lj;
            Gv_lista_l.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Carga Datos En El DropDownList (Ddl_lj_tipo_licencia)
    private void CargaDDLTipoLicencia()
    {
        _catalogo = new cls_catalogo();
        Ddl_lj_tipo_licencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_lj_tipo_licencia.DataSource = _catalogo.ObtenerTablaGrilla("", "Tipo_Licencia", "", "2, 14, 32, 34, 41", "", "MEDICA", "", "", "\"A\"", "V");
        Ddl_lj_tipo_licencia.DataValueField = "cat_secuencial";
        Ddl_lj_tipo_licencia.DataTextField = "cat_descripcion";
        Ddl_lj_tipo_licencia.DataBind();
    }

    // Diseño Del GridView (Gv_lista_l)
    protected void Gv_lista_l_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_lista_l.Rows.Count > 0)
        {
            if (Gv_lista_l.HeaderRow != null) { Gv_lista_l.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_lista_l.FooterRow != null) { Gv_lista_l.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Evento Del DropDownList (Ddl_lj_tipo_licencia)
    protected void Ddl_lj_tipo_licencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        _catalogo = new cls_catalogo();
        Limpiar("frm_l_cl");
        Limpiar("frm_l_txt");
        var var_dat_tiplic = _catalogo.ObtenerTablaGrilla("", "Tipo_Licencia", Ddl_lj_tipo_licencia.SelectedValue, "", "", "", "", "", "", "V").Tables[0];

        if (var_dat_tiplic.Rows.Count > 0)
        {
            var var_ary = JArray.Parse(var_dat_tiplic.Rows[0]["cat_adicional"].ToString());
            var var_obj = JObject.Parse(var_ary[0].ToString());
            Hf_dia.Value = string.Empty;

            if (!var_obj["dia"].ToString().Equals("A"))
            {
                if (!var_obj["dia"].ToString().Equals("I")) { Hf_dia.Value = var_obj["dia"].ToString(); }
            }

            if (var_obj["tipo"].ToString().Equals("T")) { Des_HabilitarComp("frm_hbt_h", false); }
            else { Des_HabilitarComp("frm_hbt_h", true); }
        }
        SetScript(sc, "");
    }

    // Evento Del CheckBox (Chk_lj_dia)
    protected void Chk_lj_dia_CheckedChanged(object sender, EventArgs e)
    {
        if (Chk_lj_dia.Checked) { Des_HabilitarComp("frm_hbt_h", false); }
        else { Des_HabilitarComp("frm_hbt_h", true); }
        SetScript("", "");
    }

    // Alta Licencia Justificada
    protected void BtnGuardarLJ_Click(object sender, EventArgs e)
    {
        BindDDLTipoDocumentoImpreso();
        sc = "$('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Cancela Alta Licencia Justificada
    protected void BtnCancelarLJ_Click(object sender, EventArgs e)
    {
        Limpiar("frm_ddl_cl");
        Limpiar("frm_lj_cl");
        Des_HabilitarComp("frm_ddl_cl", true);
        Des_HabilitarComp("frm_if_cl", true);
        Des_HabilitarComp("frm_lj_cl", false);
        Des_HabilitarComp("frm_hbt_h", true);
        SetScript("", "");
    }

    // Cancela Lista Funcionarios Licencia Justificada
    protected void BtnCancelarLLJ_Click(object sender, EventArgs e)
    {
        LimpiarEIDFTI("", "LICENCIA", "", "");
        Limpiar("frm_llj_cl");
        sc = "$('#licenciaModal').modal('hide');";
        SetScript(sc, "");
    }

    /****************************************************************************************/
    /**************************** MÉTODOS PARA REGISTRAR LA GLOSA ***************************/
    /****************************************************************************************/
    // Carga Datos En El DropDownList (Ddl_gl_tipo_doc)
    private void BindDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo();
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaGrilla("", "tipo_documento_impreso", "", "", "", "", "", "", "", "V");
        Ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Evento Del DropDownList (Ddl_gl_tipo_doc)
    protected void Ddl_gl_tipo_doc_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_gl_tipo_doc.SelectedValue.Equals("2") || Ddl_gl_tipo_doc.SelectedValue.Equals("3") || Ddl_gl_tipo_doc.SelectedValue.Equals("6") || Ddl_gl_tipo_doc.SelectedValue.Equals("8"))
        {
            P_gl_numero_doc.Visible = true;
            sc = "$('#D_gl_tipo_doc').removeClass('col-md-6'); $('#D_gl_tipo_doc').addClass('col-md-4'); $('#D_gl_fecha_doc').removeClass('col-md-6'); $('#D_gl_fecha_doc').addClass('col-md-4');";
        }
        else
        {
            P_gl_numero_doc.Visible = false;
            sc = "$('#D_gl_tipo_doc').removeClass('col-md-4'); $('#D_gl_tipo_doc').addClass('col-md-6'); $('#D_gl_fecha_doc').removeClass('col-md-4'); $('#D_gl_fecha_doc').addClass('col-md-6');";
        }
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Alta Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        switch (Ddl_tipo_proc.SelectedValue)
        {
            case "1":
                break;
            case "2":
                _asignacion_horario = new cls_cp_asignacion_horario
                {
                    prma_usuario = Convert.ToInt32(Session["per_id"]),
                    ah_tipo_horario = Convert.ToInt32(Hf_pd_tipo_horario.Value),
                    ah_fecha_inicial = Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()),
                    ah_fecha_final = Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()),
                    he_tipo_marc = Rbl_he_tipo_marc.SelectedValue,
                    he_ing1 = (string.IsNullOrEmpty(Txt_he_ing1.Text)) ? Convert.ToDateTime("00:00:00") : Convert.ToDateTime(Txt_he_ing1.Text.Trim()),
                    he_sal1 = (string.IsNullOrEmpty(Txt_he_sal1.Text)) ? Convert.ToDateTime("00:00:00") : Convert.ToDateTime(Txt_he_sal1.Text.Trim()),
                    he_ing2 = (string.IsNullOrEmpty(Txt_he_ing2.Text)) ? Convert.ToDateTime("00:00:00") : Convert.ToDateTime(Txt_he_ing2.Text.Trim()),
                    he_sal2 = (string.IsNullOrEmpty(Txt_he_sal2.Text)) ? Convert.ToDateTime("00:00:00") : Convert.ToDateTime(Txt_he_sal2.Text.Trim()),
                    he_autoriza = Txt_hl_autoriza.Text.ToUpper().Trim(),
                    gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
                    gl_numero_doc = Txt_gl_numero_doc.Text.ToUpper().Trim(),
                    gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
                    gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
                    gl_usuario = Convert.ToInt32(Session["per_id"])
                };
                _asignacion_horario.AdicionarHEM();
                Limpiar("frm_th_cl");
                Limpiar("frm_he_cl");
                Des_HabilitarComp("frm_he_cl", false);
                sc = "$.notify({ icon: 'fas fa-check', message: 'Registro(s) añadido(s) correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
                break;
            case "3":
                _asignacion_horario = new cls_cp_asignacion_horario
                {
                    prma_usuario = Convert.ToInt32(Session["per_id"]),
                    ah_tipo_horario = Convert.ToInt32(Hf_pd_tipo_horario.Value),
                    ah_fecha_inicial = Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()),
                    ah_fecha_final = Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()),
                    ah_autorizado = Txt_hl_autoriza.Text.ToUpper().Trim(),
                    gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
                    gl_numero_doc = Txt_gl_numero_doc.Text.ToUpper().Trim(),
                    gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
                    gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
                    gl_usuario = Convert.ToInt32(Session["per_id"])
                };
                _asignacion_horario.AdicionarHCM();
                LimpiarHorario();
                LimpiarCalendario();
                Limpiar("frm_th_cl");
                Des_HabilitarComp("frm_hm_cl", false);
                sc = "$.notify({ icon: 'fas fa-check', message: 'Registro(s) añadido(s) correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
                break;
            case "4":
                _asignacion_horario = new cls_cp_asignacion_horario
                {
                    prma_usuario = Convert.ToInt32(Session["per_id"]),
                    lj_tipo_licencia = Convert.ToInt32(Ddl_lj_tipo_licencia.SelectedValue),
                    lj_tipo_funcionario = Rbl_lj_tipo_funcionario.SelectedValue,
                    ah_fecha_inicial = Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim()),
                    ah_fecha_final = Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim()),
                    lj_hora_salida = Convert.ToDateTime(Txt_lj_hora_salida.Text.Trim()),
                    lj_hora_retorno = Convert.ToDateTime(Txt_lj_hora_retorno.Text.Trim()),
                    lj_motivo = Txt_lj_motivo.Text.ToUpper().Trim(),
                    lj_lugar = Txt_lj_lugar.Text.ToUpper().Trim(),
                    lj_per_id_autoriza = Txt_hl_autoriza.Text.ToUpper().Trim(),
                    gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
                    gl_numero_doc = Txt_gl_numero_doc.Text.ToUpper().Trim(),
                    gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
                    gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
                    gl_usuario = Convert.ToInt32(Session["per_id"])
                };
                var var_dt_lj = _asignacion_horario.AdicionarLJM().Tables[0];
                CargaGVLicencias(var_dt_lj);
                Limpiar("frm_lj_cl");
                Des_HabilitarComp("frm_lj_cl", false);
                Des_HabilitarComp("frm_hbt_h", true);

                if (Gv_lista_l.Rows.Count > 0) { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Existen registros que no se pudieron añadir...!!' }, { type: 'warning' }); $('#licenciaModal').modal('show');"; }
                else { Limpiar("frm_llj_cl"); }
                sc += "$.notify({ icon: 'fas fa-check', message: 'Registro(s) añadido(s) correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
                break;
            default:
                break;
        }
        LimpiarEIDFTI("", "FUNCIONARIO", "", "");
        LimpiarEIDFTI("", "EDIFICIO", "", "");
        Limpiar("frm_if_cl");
        Limpiar("frm_ddl_cl");
        Limpiar("frm_ufi_cl");
        Limpiar("frm_glosa_cl");
        Des_HabilitarComp("frm_if_cl", true);
        Des_HabilitarComp("frm_ddl_cl", true);
        Des_HabilitarComp("gv_lt_u", false);
        Des_HabilitarComp("gv_lt_f", false);
        Des_HabilitarComp("gv_lt_i", false);
        SetScript(sc, "");
    }

    // Cancelar Alta Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        P_gl_numero_doc.Visible = false;
        BtnGuardarG.Visible = true;
        Limpiar("frm_glosa_cl");
        sc = "$('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Carga Los Nodos Del TreeView (Tv_nivelOrg)
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

    // Carga Y Muestra Datos En Los GridViews (Gv_lista_u, Gv_lista_f, Gv_lista_i)
    private void CargaMuestraGVListas()
    {
        BindGridViewUFI(Gv_lista_u, "EDIFICIO");
        BindGridViewUFI(Gv_lista_f, "FUNCIONARIO");
        BindGridViewUFI(Gv_lista_i, "ITEM");

        if (Gv_lista_u.Rows.Count > 0) { Des_HabilitarComp("gv_lt_u", true); }
        else { Des_HabilitarComp("gv_lt_u", false); }

        if (Gv_lista_f.Rows.Count > 0) { Des_HabilitarComp("gv_lt_f", true); }
        else { Des_HabilitarComp("gv_lt_f", false); }

        if (Gv_lista_i.Rows.Count > 0) { Des_HabilitarComp("gv_lt_i", true); }
        else { Des_HabilitarComp("gv_lt_i", false); }
    }

    // Llenar Datos Edificios
    private void LlenarEdificios()
    {
        _asignacion_horario = new cls_cp_asignacion_horario { prma_usuario = Convert.ToInt32(Session["per_id"]) };
        _asignacion_horario.LLenarEI();
    }

    // Eliminar datos del edificio, funcionario o tipo ítem (seleccionado o todos)
    private void LimpiarEIDFTI(string par_id, string par_tipo, string par_ei_id, string par_ti_id)
    {
        _asignacion_horario = new cls_cp_asignacion_horario();
        _asignacion_horario.EliminarEIDFTI(par_id, par_tipo, par_ei_id, par_ti_id, Session["per_id"].ToString());
    }

    // Llenar Datos Funcionarios
    private void LlenarFuncionarios(string par_fecha_ini, string par_fecha_fin)
    {
        _asignacion_horario = new cls_cp_asignacion_horario
        {
            prma_usuario = Convert.ToInt32(Session["per_id"]),
            ah_fecha_inicial = Convert.ToDateTime(par_fecha_ini),
            ah_fecha_final = Convert.ToDateTime(par_fecha_fin)
        };
        _asignacion_horario.LLenarDF();
    }

    // Carga Datos Procesamiento
    private void CargaDatosProcesamiento(string par_titulo, string par_titulo_hl, DateTime par_fec_ini, DateTime par_fec_fin)
    {
        Hf_pd_tipo_horario.Value = Ddl_ah_tipo_horario.SelectedValue;
        Lt_pd_titulo.Text = par_titulo;
        Lt_pd_titulo_hl.Text = par_titulo_hl;
        Lt_pd_tipo_hl.Text = (Ddl_tipo_proc.SelectedValue.Equals("4")) ? Ddl_tipo_proc.SelectedItem.Text : Ddl_ah_tipo_horario.SelectedItem.Text;
        Lt_pd_fecha_inicial.Text = par_fec_ini.ToString("dd/MM/yyyy");
        Lt_pd_fecha_final.Text = par_fec_fin.ToString("dd/MM/yyyy");
    }

    // Limpiar Datos Calendario
    private void LimpiarCalendario()
    {
        _asignacion_horario = new cls_cp_asignacion_horario { ah_per_id = Convert.ToInt32(Session["per_id"]) };
        _asignacion_horario.EliminarCH();
    }

    // Limpiar Datos Horario (Parcial)
    private void LimpiarHorario()
    {
        _asignacion_horario = new cls_cp_asignacion_horario { ah_per_id = Convert.ToInt32(Session["per_id"]) };
        _asignacion_horario.EliminarHC();
    }

    // Habilita Las Casillas Del Calendario

    private void HabilitarCheckBoxGrilla(bool val)
    {
        foreach (GridViewRow item in Gv_calendario.Rows)
        {
            LinkButton Lnk_lun = (LinkButton)item.FindControl("Lnk_tds_lun");
            LinkButton Lnk_mar = (LinkButton)item.FindControl("Lnk_tds_mar");
            LinkButton Lnk_mie = (LinkButton)item.FindControl("Lnk_tds_mie");
            LinkButton Lnk_jue = (LinkButton)item.FindControl("Lnk_tds_jue");
            LinkButton Lnk_vie = (LinkButton)item.FindControl("Lnk_tds_vie");
            LinkButton Lnk_sab = (LinkButton)item.FindControl("Lnk_tds_sab");
            LinkButton Lnk_dom = (LinkButton)item.FindControl("Lnk_tds_dom");
            Panel P_chk_lun = (Panel)item.FindControl("P_chk_tds_lun");
            Panel P_chk_mar = (Panel)item.FindControl("P_chk_tds_mar");
            Panel P_chk_mie = (Panel)item.FindControl("P_chk_tds_mie");
            Panel P_chk_jue = (Panel)item.FindControl("P_chk_tds_jue");
            Panel P_chk_vie = (Panel)item.FindControl("P_chk_tds_vie");
            Panel P_chk_sab = (Panel)item.FindControl("P_chk_tds_sab");
            Panel P_chk_dom = (Panel)item.FindControl("P_chk_tds_dom");
            CheckBox Chk_lun = (CheckBox)item.FindControl("Chk_tds_lun");
            CheckBox Chk_mar = (CheckBox)item.FindControl("Chk_tds_mar");
            CheckBox Chk_mie = (CheckBox)item.FindControl("Chk_tds_mie");
            CheckBox Chk_jue = (CheckBox)item.FindControl("Chk_tds_jue");
            CheckBox Chk_vie = (CheckBox)item.FindControl("Chk_tds_vie");
            CheckBox Chk_sab = (CheckBox)item.FindControl("Chk_tds_sab");
            CheckBox Chk_dom = (CheckBox)item.FindControl("Chk_tds_dom");

            if (Lnk_lun.Text != "") { Lnk_lun.Enabled = !val; P_chk_lun.Visible = val; }
            if (Lnk_mar.Text != "") { Lnk_mar.Enabled = !val; P_chk_mar.Visible = val; }
            if (Lnk_mie.Text != "") { Lnk_mie.Enabled = !val; P_chk_mie.Visible = val; }
            if (Lnk_jue.Text != "") { Lnk_jue.Enabled = !val; P_chk_jue.Visible = val; }
            if (Lnk_vie.Text != "") { Lnk_vie.Enabled = !val; P_chk_vie.Visible = val; }
            if (Lnk_sab.Text != "") { Lnk_sab.Enabled = !val; P_chk_sab.Visible = val; }
            if (Lnk_dom.Text != "") { Lnk_dom.Enabled = !val; P_chk_dom.Visible = val; }
            if (!val)
            {
                if (Lnk_lun.Text != "") { Chk_lun.Checked = false; }
                if (Lnk_mar.Text != "") { Chk_mar.Checked = false; }
                if (Lnk_mie.Text != "") { Chk_mie.Checked = false; }
                if (Lnk_jue.Text != "") { Chk_jue.Checked = false; }
                if (Lnk_vie.Text != "") { Chk_vie.Checked = false; }
                if (Lnk_sab.Text != "") { Chk_sab.Checked = false; }
                if (Lnk_dom.Text != "") { Chk_dom.Checked = false; }
            }
        }
    }

    // Ejecuta Los Scripts
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.table').DataTable({" +
                "'language': {" +
                    "'sProcessing': 'Procesando...'," +
                    "'sLengthMenu': 'Mostrar _MENU_ Registros'," +
                    "'sZeroRecords': 'No se encontraron resultados'," +
                    "'sEmptyTable': 'Ningún dato disponible en esta tabla'," +
                    "'sInfo': 'Mostrando Registros del _START_ al _END_ de un total de _TOTAL_ Registros'," +
                    "'sInfoEmpty': 'Mostrando Registros del 0 al 0 de un total de 0 Registros'," +
                    "'sInfoFiltered': '(filtrado de un total de _MAX_ Registros)'," +
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
                "'searching': true," + // Muestra/Oculta el campo de búsqueda
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true," +
                "'paging': true," +
                "'info': true" + // Muestra/Oculta el campo información
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".checks label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".checks input[type='checkbox']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerDefault\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: \"es\"" +
                    "});" +
                "});" +
                "var me = $(\".datepickerDefault\");" +
                "me.mask(\"99/99/9999\");" +
            "});");
        sb.Append("$(function () {" +
                "var me = $(\".timepickerD\");" +
                    "me.mask(\"99:99\");" +
                "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    // Limpia Los Campos De Los Formularios
    private void Limpiar(string val)
    {
        if (val.Equals("frm_if_cl"))
        {
            Txt_ah_fecha_inicial.Text = string.Empty;
            Txt_ah_fecha_final.Text = string.Empty;
        }
        else if (val.Equals("frm_ddl_cl"))
        {
            Ddl_tipo_proc.SelectedValue = "0";
        }
        else if (val.Equals("frm_ufi_cl"))
        {
            Ddl_cat_descripcion_ei.Items.Clear();
            Ddl_cat_descripcion_ti.Items.Clear();
        }
        else if (val.Equals("sch_cl"))
        {
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
        }
        else if (val.Equals("gv_cl"))
        {
            Gv_lista_p.DataSource = null;
            Gv_lista_p.DataBind();
        }
        else if (val.Equals("frm_il_cl"))
        {
            Tv_nivelOrg.Nodes.Clear();
        }
        else if (val.Equals("frm_he_cl"))
        {
            Rbl_he_tipo_marc.SelectedValue = "T";
            Txt_he_ing1.Text = string.Empty;
            Txt_he_sal1.Text = string.Empty;
            Txt_he_ing2.Text = string.Empty;
            Txt_he_sal2.Text = string.Empty;
        }
        else if (val.Equals("frm_th_cl"))
        {
            Ddl_ah_tipo_horario.Items.Clear();
        }
        else if (val.Equals("frm_hm_cl"))
        {
            Chk_th_tolr_ing1.Checked = true;
            Chk_th_tolr_ing2.Checked = true;
            Txt_th_ing1.Text = string.Empty;
            Txt_th_sal1.Text = string.Empty;
            Txt_th_ing2.Text = string.Empty;
            Txt_th_sal2.Text = string.Empty;
            Rbl_th_tipo.SelectedValue = "1";
            Rbl_th_semana.SelectedValue = "3";
            Cbl_th_dia.Items[0].Selected = true;
            Cbl_th_dia.Items[1].Selected = true;
            Cbl_th_dia.Items[2].Selected = true;
            Cbl_th_dia.Items[3].Selected = true;
            Cbl_th_dia.Items[4].Selected = true;
            Chk_th_presencial.Checked = true;
        }
        else if (val.Equals("frm_lj_cl"))
        {
            Ddl_lj_tipo_licencia.Items.Clear();
            Rbl_lj_tipo_funcionario.SelectedValue = "T";
            Txt_lj_hora_salida.Text = string.Empty;
            Txt_lj_hora_retorno.Text = string.Empty;
            Chk_lj_dia.Checked = false;
            Txt_lj_motivo.Text = string.Empty;
            Txt_lj_lugar.Text = string.Empty;
        }
        else if (val.Equals("frm_llj_cl"))
        {
            Gv_lista_l.DataSource = null;
            Gv_lista_l.DataBind();
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_numero_doc.Text = string.Empty;
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_hl_autoriza.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }

    // Deshabilitar / Habilitar Formularios Y Campos
    private void Des_HabilitarComp(string par_val, bool par_est)
    {
        if (par_val.Equals("frm_if_cl"))
        {
            Txt_ah_fecha_inicial.Enabled = par_est;
            Txt_ah_fecha_final.Enabled = par_est;
        }
        else if (par_val.Equals("frm_ddl_cl")) { Ddl_tipo_proc.Enabled = par_est; }
        else if (par_val.Equals("gv_lt_u")) { P_gv_lista_u.Visible = par_est; }
        else if (par_val.Equals("gv_lt_f")) { P_gv_lista_f.Visible = par_est; }
        else if (par_val.Equals("gv_lt_i")) { P_gv_lista_i.Visible = par_est; }
        else if (par_val.Equals("frm_he_cl"))
        {
            P_procesamiento_datos.Visible = par_est;
            P_horario_especial.Visible = par_est;
        }
        else if (par_val.Equals("frm_hm_cl"))
        {
            P_procesamiento_datos.Visible = par_est;
            P_horario_masivo.Visible = par_est;
        }
        else if (par_val.Equals("frm_lj_cl"))
        {
            P_procesamiento_datos.Visible = par_est;
            P_licencia_justificada.Visible = par_est;
        }
        else if (par_val.Equals("frm_hbt_h"))
        {
            Txt_lj_hora_salida.Text = (par_est) ? string.Empty : "00:01";
            Txt_lj_hora_retorno.Text = (par_est) ? string.Empty : "23:59";
            Txt_lj_hora_salida.Enabled = par_est;
            Txt_lj_hora_retorno.Enabled = par_est;
        }
    }
}