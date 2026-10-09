using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_Horarios : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_cp_asignacion_horario _asignacion_horario = null;
    private cls_glosa _glosa = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                CargaDatosFuncionario(id);
                CargaGVHorario(id);

                if (GvListaH.Rows.Count > 0) { P_lista.Visible = true; }
                else { P_lista.Visible = false; }
            }
        }
        else { Response.Redirect("../Index"); }
    }

    // Cargar Datos
    private void CargaDatosFuncionario(string per_id)
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

    // Cargar GridView
    private void CargaGVHorario(string per_id)
    {
        try
        {
            _asignacion_horario = new cls_cp_asignacion_horario();
            GvListaH.DataSource = _asignacion_horario.ObtenerTablaGrillaC("", per_id, "", "", "", "V");
            GvListaH.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Carga Datos En El GridView (Gv_calendario)
    private void CargaGVCalendario(string per_id, string fec_ini, string fec_fin)
    {
        try
        {
            _asignacion_horario = new cls_cp_asignacion_horario();
            Gv_calendario.DataSource = _asignacion_horario.ObtenerTablaGrillaCH(per_id, fec_ini, fec_fin);
            Gv_calendario.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Cargar DropDownList
    private void CargaDDLTipoHorario()
    {
        _catalogo = new cls_catalogo();
        Ddl_ah_tipo_horario.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_ah_tipo_horario.DataSource = _catalogo.ObtenerTablaGrilla("", "Tipo_Horario", "", "", "", "", "", "", "", "V");
        Ddl_ah_tipo_horario.DataValueField = "cat_secuencial";
        Ddl_ah_tipo_horario.DataTextField = "cat_descripcion";
        Ddl_ah_tipo_horario.DataBind();
    }

    // Cargar DropDownList
    private void CargaDDLTipoDocumentoImpreso()
    {
        _catalogo = new cls_catalogo();
        Ddl_gl_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_gl_tipo_doc.DataSource = _catalogo.ObtenerTablaGrilla("", "tipo_documento_impreso", "", "", "", "", "", "", "", "V");
        Ddl_gl_tipo_doc.DataValueField = "cat_secuencial";
        Ddl_gl_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_gl_tipo_doc.DataBind();
    }

    // Diseño GridView
    protected void GvListaH_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvListaH.Rows.Count > 0)
        {
            if (GvListaH.HeaderRow != null) { GvListaH.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvListaH.FooterRow != null) { GvListaH.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Diseño Del GridView (Gv_calendario)
    protected void Gv_calendario_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType != DataControlRowType.DataRow) { return; }

        var id = Request.QueryString["id"].ToString();
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

    // Evento GridView
    protected void GvListaH_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvListaH.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("BtnVerHorario"))
        {
            _asignacion_horario = new cls_cp_asignacion_horario();
            var var_tip_hor = GvListaH.Rows[index].Cells[0].Text;
            var fecha_ini = Convert.ToDateTime(GvListaH.Rows[index].Cells[1].Text);
            var fecha_fin = Convert.ToDateTime(GvListaH.Rows[index].Cells[2].Text);
            Lt_ah_tipo_horario.Text = var_tip_hor;
            Lt_ah_fecha_inicial.Text = fecha_ini.ToString("dd/MM/yyyy");
            Lt_ah_fecha_final.Text = fecha_fin.ToString("dd/MM/yyyy");
            _asignacion_horario.ObtenerTablaGrillaVM(id, fecha_ini.ToString("dd/MM/yyyy"), fecha_fin.ToString("dd/MM/yyyy"));
            CargaGVCalendario(id, fecha_ini.ToString("dd/MM/yyyy"), fecha_fin.ToString("dd/MM/yyyy"));
            P_datos_horario.Visible = false;
            BtnVerHorario.Visible = false;
            BtnNuevo.Visible = false;
            BtnGuardar.Visible = false;
            Des_HabilitarDiasGrilla(false);
            P_lista.Visible = false;
            P_calendario.Visible = true;
            Limpiar("gv_cl");
        }
        else if (e.CommandName.Equals("BtnGlosa"))
        {
            CargaDDLTipoDocumentoImpreso();
            Ddl_gl_tipo_doc.Enabled = false;
            Txt_gl_numero_doc.Enabled = false;
            Txt_gl_fecha_doc.Enabled = false;
            Txt_gl_glosa.Enabled = false;
            BtnGuardarG.Visible = false;
            _glosa = new cls_glosa();
            var data = _glosa.ObtenerTablaGrilla("", code, "ah_id", "tbl_cp_asignacion_horario", "", "", "", "", "", "V").Tables[0];

            if (data.Rows.Count > 0)
            {
                Ddl_gl_tipo_doc.SelectedValue = data.Rows[0]["gl_tipo_doc"].ToString().Trim();
                Txt_gl_numero_doc.Text = data.Rows[0]["gl_numero_doc"].ToString().Trim();
                Txt_gl_fecha_doc.Text = Convert.ToDateTime(data.Rows[0]["gl_fecha_doc"]).ToString("dd/MM/yyyy").Trim();
                Txt_gl_glosa.Text = data.Rows[0]["gl_glosa"].ToString().Trim();

                if (data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("2") || data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("3") || data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("6") || data.Rows[0]["gl_tipo_doc"].ToString().Trim().Equals("8"))
                {
                    P_gl_numero_doc.Visible = true;
                    sc = "$('#D_gl_tipo_doc').removeClass('col-md-6'); $('#D_gl_tipo_doc').addClass('col-md-4'); $('#D_gl_fecha_doc').removeClass('col-md-6'); $('#D_gl_fecha_doc').addClass('col-md-4');";
                }
                else
                {
                    P_gl_numero_doc.Visible = false;
                    sc = "$('#D_gl_tipo_doc').removeClass('col-md-4'); $('#D_gl_tipo_doc').addClass('col-md-6'); $('#D_gl_fecha_doc').removeClass('col-md-4'); $('#D_gl_fecha_doc').addClass('col-md-6');";
                }
                sc += "$('#Txt_gl_fecha_doc').addClass('form-control'); $('#glosaModal').modal('show');";
            }
            else { sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no tinene glosa...!!' }, { type: 'warning' });"; }
        }
        else if (e.CommandName.Equals("GetDelete"))
        {
            CargaGVHorario(id);
            sc = "$.notify({ icon: 'fas fa-check', message: 'Registro anulado correctamente...!!' }, { type: 'success' });";
        }
        SetScript(sc, ", dropdownParent: $('#addModal')");
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
            //var id = Request.QueryString["id"].ToString();
            //CargaGVCalendario(id, Txt_ah_fecha_inicial.Text.Trim(), Txt_ah_fecha_final.Text.Trim());
        }
        //SetScript("", "");
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

    // Ver El Horario
    protected void BtnVerHorario_Click(object sender, EventArgs e)
    {
        P_ah_tipo_horario.Visible = false;
        BtnVerHorario.Visible = false;
        BtnNuevo.Visible = false;
        BtnGuardar.Visible = false;
        sc = "$('#fechaHorarioModal').modal('show');";
        SetScript(sc, "");
    }

    // Nuevo Horario
    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        CargaDDLTipoHorario();
        P_ah_tipo_horario.Visible = true;
        BtnVerHorario.Visible = false;
        BtnNuevo.Visible = false;
        sc = "$('#fechaHorarioModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#fechaHorarioModal')");
    }

    // Mostrar Formulario De Horarios
    protected void BtnGuardarN_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        var fecha_ini = Convert.ToDateTime(Txt_ah_fecha_inicial.Text.Trim());
        var fecha_fin = Convert.ToDateTime(Txt_ah_fecha_final.Text.Trim());

        if (fecha_ini > fecha_fin)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (FECHA INICIO) no puede ser mayor al campo (FECHA FIN)...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        if (P_ah_tipo_horario.Visible)
        {
            Hf_ah_tipo_horario.Value = Ddl_ah_tipo_horario.SelectedValue;
            Lt_ah_tipo_horario.Text = Ddl_ah_tipo_horario.SelectedItem.Text;
            Lt_ah_fecha_inicial.Text = fecha_ini.ToString("dd/MM/yyyy");
            Lt_ah_fecha_final.Text = fecha_fin.ToString("dd/MM/yyyy");
            P_datos_horario.Visible = true;
            BtnGuardar.Visible = false;
            LimpiarHorario(id);
            CargaGVCalendario(id, fecha_ini.ToString("dd/MM/yyyy"), fecha_fin.ToString("dd/MM/yyyy"));
            sc = "$('#fechaHorarioModal').modal('hide');";
        }
        else
        {
            _asignacion_horario = new cls_cp_asignacion_horario();
            var var_dataFH = _asignacion_horario.ObtenerTablaGrillaFH(id, fecha_ini.ToString("dd/MM/yyyy"), fecha_fin.ToString("dd/MM/yyyy")).Tables[0];

            if (var_dataFH.Rows.Count > 0)
            {
                Lt_ah_fecha_inicial.Text = fecha_ini.ToString("dd/MM/yyyy");
                Lt_ah_fecha_final.Text = fecha_fin.ToString("dd/MM/yyyy");
                _asignacion_horario.ObtenerTablaGrillaVM(id, fecha_ini.ToString("dd/MM/yyyy"), fecha_fin.ToString("dd/MM/yyyy"));
                CargaGVCalendario(id, fecha_ini.ToString("dd/MM/yyyy"), fecha_fin.ToString("dd/MM/yyyy"));
                P_datos_horario.Visible = false;
                Des_HabilitarDiasGrilla(false);
                sc = "$('#fechaHorarioModal').modal('hide');";
            }
            else
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No existe ningún horario en el rango de fechas...!!' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }
        P_lista.Visible = false;
        P_calendario.Visible = true;
        Limpiar("frm_h_cl");
        Limpiar("gv_cl");
        SetScript(sc, "");
    }

    // Cancela Mostrar Formulario De Horarios
    protected void BtnCancelarN_Click(object sender, EventArgs e)
    {
        BtnVerHorario.Visible = true;
        BtnNuevo.Visible = true;
        Limpiar("frm_h_cl");
        sc = "$('#fechaHorarioModal').modal('hide');";
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

        if (var_marc_tolr[0].ToString().Equals("2"))
        {
            P_is_2.Visible = false;
        }
        else { P_is_2.Visible = true; }

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
        var id = Request.QueryString["id"].ToString();
        var fecha_ini = Lt_ah_fecha_inicial.Text.Trim();
        var fecha_fin = Lt_ah_fecha_final.Text.Trim();
        Chk_habilitar_c.Checked = false;
        BtnGuardar.Visible = false;
        LimpiarHorario(id);
        CargaGVCalendario(id, fecha_ini, fecha_fin);
        SetScript("", "");
    }

    // Alta Horario (Parcial)
    protected void BtnGuardarH_Click(object sender, EventArgs e)
    {
        _asignacion_horario = new cls_cp_asignacion_horario();
        var id = Request.QueryString["id"].ToString();
        var fecha_ini = Lt_ah_fecha_inicial.Text;
        var fecha_fin = Lt_ah_fecha_final.Text;
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
        Limpiar("frm_dh_cl");
        CargaGVCalendario(id, fecha_ini, fecha_fin);
        sc = "$('#horarioModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancelar Alta Horario (Parcial)
    protected void BtnCancelarH_Click(object sender, EventArgs e)
    {
        //var id = Request.QueryString["id"].ToString();
        //var fecha_ini = Lt_ah_fecha_inicial.Text;
        //var fecha_fin = Lt_ah_fecha_final.Text;
        Hf_modal_hd.Value = string.Empty;
        BtnGuardar.Visible = (BtnGuardar.Visible) ? true : false;
        //CargaGVCalendario(id, fecha_ini, fecha_fin);

        if (Chk_habilitar_c.Checked) { HabilitarCheckBoxGrilla(true); }
        else { HabilitarCheckBoxGrilla(false); }
        Limpiar("frm_dh_cl");
        sc = "$('#horarioModal').modal('hide');";
        SetScript(sc, "");
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

        if (var_marc_tolr[0].ToString().Equals("2"))
        {
            P_is_2.Visible = false;
        }
        else { P_is_2.Visible = true; }
        sc = "$('#horarioModal').modal('show');";
        SetScript(sc, "");
    }

    // Alta Horario
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        CargaDDLTipoDocumentoImpreso();
        sc = "$('#glosaModal').modal('show');";
        SetScript(sc, ", dropdownParent: $('#glosaModal')");
    }

    // Cancelar Alta Horario
    protected void BtnCancelar_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        P_calendario.Visible = false;
        BtnVerHorario.Visible = true;
        BtnNuevo.Visible = true;
        LimpiarCalendario(id);
        LimpiarHorario(id);
        Limpiar("frm_h_cl");
        Limpiar("frm_dh_cl");
        CargaGVHorario(id);

        if (GvListaH.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }
        SetScript("", "");
    }

    // Alta Glosa
    protected void BtnGuardarG_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        _asignacion_horario = new cls_cp_asignacion_horario
        {
            ah_per_id = Convert.ToInt32(id),
            ah_tipo_horario = Convert.ToInt32(Hf_ah_tipo_horario.Value),
            ah_fecha_inicial = Convert.ToDateTime(Lt_ah_fecha_inicial.Text.Trim()),
            ah_fecha_final = Convert.ToDateTime(Lt_ah_fecha_final.Text.Trim()),
            gl_tipo_doc = Convert.ToInt32(Ddl_gl_tipo_doc.SelectedValue),
            gl_numero_doc = Txt_gl_numero_doc.Text.ToUpper().Trim(),
            gl_fecha_doc = Convert.ToDateTime(Txt_gl_fecha_doc.Text.Trim()),
            gl_glosa = Txt_gl_glosa.Text.ToUpper().Trim(),
            gl_usuario = Convert.ToInt32(Session["per_id"])
        };
        _asignacion_horario.AdicionarHC();
        Limpiar("frm_h_cl");
        Limpiar("frm_glosa_cl");
        P_calendario.Visible = false;
        BtnVerHorario.Visible = true;
        BtnNuevo.Visible = true;
        CargaGVHorario(id);

        if (GvListaH.Rows.Count > 0) { P_lista.Visible = true; }
        else { P_lista.Visible = false; }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' }); $('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Cancelar Alta Glosa
    protected void BtnCancelarG_Click(object sender, EventArgs e)
    {
        P_gl_numero_doc.Visible = false;
        Ddl_gl_tipo_doc.Enabled = true;
        Txt_gl_numero_doc.Enabled = true;
        Txt_gl_fecha_doc.Enabled = true;
        Txt_gl_glosa.Enabled = true;
        BtnGuardarG.Visible = true;
        Limpiar("frm_glosa_cl");
        sc = "$('#Txt_gl_fecha_doc').addClass('datepickerDefault'); $('#glosaModal').modal('hide');";
        SetScript(sc, "");
    }

    // Validar Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    // Limpiar Datos Calendario
    private void LimpiarCalendario(string per_id)
    {
        _asignacion_horario = new cls_cp_asignacion_horario { ah_per_id = Convert.ToInt32(per_id) };
        _asignacion_horario.EliminarCH();
    }

    // Limpiar Datos Horario (Parcial)
    private void LimpiarHorario(string per_id)
    {
        _asignacion_horario = new cls_cp_asignacion_horario { ah_per_id = Convert.ToInt32(per_id) };
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
            Panel P_chk_lun = (Panel)item.FindControl("P_Chk_tds_lun");
            Panel P_chk_mar = (Panel)item.FindControl("P_Chk_tds_mar");
            Panel P_chk_mie = (Panel)item.FindControl("P_Chk_tds_mie");
            Panel P_chk_jue = (Panel)item.FindControl("P_Chk_tds_jue");
            Panel P_chk_vie = (Panel)item.FindControl("P_Chk_tds_vie");
            Panel P_chk_sab = (Panel)item.FindControl("P_Chk_tds_sab");
            Panel P_chk_dom = (Panel)item.FindControl("P_Chk_tds_dom");
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

    // Habilitar / Deshabilitar Los Días Del Calendario
    private void Des_HabilitarDiasGrilla(bool par_val)
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

            if (Lnk_lun.Text != "") { Lnk_lun.Enabled = par_val; }
            if (Lnk_mar.Text != "") { Lnk_mar.Enabled = par_val; }
            if (Lnk_mie.Text != "") { Lnk_mie.Enabled = par_val; }
            if (Lnk_jue.Text != "") { Lnk_jue.Enabled = par_val; }
            if (Lnk_vie.Text != "") { Lnk_vie.Enabled = par_val; }
            if (Lnk_sab.Text != "") { Lnk_sab.Enabled = par_val; }
            if (Lnk_dom.Text != "") { Lnk_dom.Enabled = par_val; }
        }
    }

    // Ejecutar ScriptManager
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
        if (val.Equals("frm_h_cl"))
        {
            Ddl_ah_tipo_horario.Items.Clear();
            Txt_ah_fecha_inicial.Text = string.Empty;
            Txt_ah_fecha_final.Text = string.Empty;
        }
        else if (val.Equals("gv_cl"))
        {
            GvListaH.DataSource = null;
            GvListaH.DataBind();
        }
        else if (val.Equals("frm_dh_cl"))
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
            Rbl_th_tipo_dia.SelectedValue = "1";
            Chk_th_presencial.Checked = true;
            P_tipo_sem.Visible = true;
            P_tipo_dia_sem.Visible = true;
            P_tipo_dia.Visible = false;
        }
        else if (val.Equals("frm_glosa_cl"))
        {
            Ddl_gl_tipo_doc.Items.Clear();
            Txt_gl_numero_doc.Text = string.Empty;
            Txt_gl_fecha_doc.Text = string.Empty;
            Txt_gl_glosa.Text = string.Empty;
        }
    }
}