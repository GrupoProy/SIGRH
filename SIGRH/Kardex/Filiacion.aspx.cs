using System;
using System.Collections.Generic;
 
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_Kardex.BussinessLogicLayer;
using System.Data;
using System.Text;
using Newtonsoft.Json;

public partial class Kardex_Filiacion : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_catalogo _catalogo = null;
    private cls_persona_familiares familiar = null;
    private cls_persona_domicilio _domicilio = null;
    private cls_kd_respuesta_combo resp_combo = null;
    private cls_kd_respuesta_combo formacion = null;
    string sc = "";
    private DropDownList control;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            construirFormularioD();
            if (!Page.IsPostBack)
            {
                string codFun =  Request.QueryString["id"].ToString();
                string as_id =  Request.QueryString["id2"].ToString();
                informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));

                informacionDatosPersonales(Convert.ToInt32(codFun));
                informacionFamiliares(Convert.ToInt32(codFun));
                informacionRequisitosPresentados(Convert.ToInt32(codFun));
                informacion_educacion_formal(Convert.ToInt32(codFun));
                SetScriptInicio("$('.table').DataTable().destroy(); ");
            }
        }
    }
    private void construirFormularioD()
    {
        resp_combo = new cls_kd_respuesta_combo();
        resp_combo.rq_categoria = "KARDEX";
        var requisitos = resp_combo.ListaRequisitos();
        var combo_resp = resp_combo.ComboRequisitos();
        DataTable combos = combo_resp.Tables[0];

        int nro_requisito = 0;
        if (requisitos.Tables.Count > 0)
        {
            if (requisitos.Tables[0].Rows.Count > 0)
            {
                nro_requisito = requisitos.Tables[0].Rows.Count;
                hf_nro_requisitos.Value = Convert.ToString(nro_requisito);
                DataRow requisito_x = null;

                TextBox txt = null;

                for (int i = 0; i < nro_requisito; i++)
                {
                    requisito_x = requisitos.Tables[0].Rows[i];

                    Literal lit = new Literal();
                    lit.Text = "<div class='row'>";
                    pnlDinamico.Controls.Add(lit);

                    //hf
                    HiddenField hf = new HiddenField();
                    hf.ID = "hf_" + i;
                    hf.Value = validarCampo(requisito_x["rq_id"]);
                    pnlDinamico.Controls.Add(hf);

                    //col1
                    construirInicioColumna("text-right");

                    Label lbl = new Label();
                    lbl.Text = validarCampo(requisito_x["rq_descripcion"]);
                    lbl.CssClass = "form-control-label";
                    pnlDinamico.Controls.Add(lbl);

                    construirFinColumna();

                    //col2
                    construirInicioColumna();
                    var lista_respuesta = construirCombo(validarCampo(requisito_x["rq_id"]), combo_resp);

                    DropDownList ddl = new DropDownList();
                    ddl.ID = "ddl_rq_" + i;

                    ddl.Items.Clear();
                    ddl.DataValueField = "rc_id";
                    ddl.DataTextField = "rc_desc";
                    ddl.DataSource = lista_respuesta;
                    //ddl.AppendDataBoundItems = true;
                    //ddl.AutoPostBack = true;
                    ddl.DataBind();

                    ddl.CssClass = "form-control select2";
                    ddl.Attributes.Add("data-minimum-results-for-search", "Infinity");
                    pnlDinamico.Controls.Add(ddl);

                    construirFinColumna();

                    //col3
                    construirInicioColumna();

                    txt = new TextBox();
                    txt.ID = "txt_rq_" + i;
                    //txt.Text = "mytxt" + i;
                    txt.CssClass = "form-control datepickerDefault";
                    pnlDinamico.Controls.Add(txt);

                    construirFinColumna();

                    //fincols
                    Literal lit2 = new Literal();
                    lit2.Text = "</div>";
                    pnlDinamico.Controls.Add(lit2);

                    /*Obtener Valores o setear valores*/
                    //string test = "txt_rq_" + i;
                    //TextBox text = (TextBox)pnlDinamico.FindControl(test);
                    //text.Text = "testingTextBox";
                }
            }
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
    private void construirColumnas(int numCol = 0, string componente = "", string componente1 = "", string componente2 = "")
    {
        //int tamanioCol = (12 / numCol);
        //Literal lit4 = new Literal();
        //lit4.Text = "<div class='col-md-" + tamanioCol + "'>";
        //pnlDinamico.Controls.Add(lit4);

        //Literal lit6 = new Literal();
        //lit6.Text = "<div class='form-group'>";
        //pnlDinamico.Controls.Add(lit6);

        //Label lbl = new Label();
        //lbl.Text = "lbl" + i;
        //lbl.CssClass = "form-control-label";
        //pnlDinamico.Controls.Add(lbl);

        //Literal lit7 = new Literal();
        //lit7.Text = "</div>";
        //pnlDinamico.Controls.Add(lit7);

        //Literal lit5 = new Literal();
        //lit5.Text = "</div>";
        //pnlDinamico.Controls.Add(lit5);

    }

    private void construirInicioColumna(string alinear = "")
    {
        Literal lit = new Literal();
        lit.Text = "<div class='col-md-4 " + alinear + "'>";
        pnlDinamico.Controls.Add(lit);

        Literal lit1 = new Literal();
        lit1.Text = "<div class='form-group'>";
        pnlDinamico.Controls.Add(lit1);
    }

    private void construirFinColumna()
    {
        Literal lit = new Literal();
        lit.Text = "</div>";
        pnlDinamico.Controls.Add(lit);

        Literal lit2 = new Literal();
        lit2.Text = "</div>";
        pnlDinamico.Controls.Add(lit2);
    }
    private string generarUUID()
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        return uuid;
    }
    private DataTable construirCombo(string nro_requisito = "", DataSet combo_resp = null)
    {
        DataTable lista_respuesta = new DataTable();
        lista_respuesta.Columns.Add("rc_id");
        lista_respuesta.Columns.Add("rc_desc");
        DataRow dr = null;

        if (combo_resp.Tables.Count > 0)
        {
            if (combo_resp.Tables[0].Rows.Count > 0)
            {
                int nroRespuestas = combo_resp.Tables[0].Rows.Count;
                for (int i = 0; i < nroRespuestas; i++)
                {
                    var respuesta = combo_resp.Tables[0].Rows[i];
                    string rc_rq_id = validarCampo(respuesta["rc_rq_id"]);
                    if (nro_requisito == rc_rq_id)
                    {
                        dr = lista_respuesta.NewRow();
                        dr["rc_id"] = validarCampo(respuesta["rc_id"]);
                        dr["rc_desc"] = validarCampo(respuesta["rc_desc"]);
                        lista_respuesta.Rows.Add(dr);
                    }
                }
            }
        }
        return lista_respuesta;
    }
    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        resp_combo = new cls_kd_respuesta_combo();
        resp_combo.p_per_id = codFun;
        var detalleFuncionario = resp_combo.ObtenerDatosFuncioanrio();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_estado_civil.Text = validarCampo(funcionario["estado_civil"]);
                ltl_genero.Text = validarCampo(funcionario["genero"]);
                txt_nro_lib.Text = validarCampo(funcionario["nro_lib_mil"]);
                ltl_num_doc.Text = validarCampo(funcionario["num_doc"]) + " " + validarCampo(funcionario["lugar_exp"]);
                ltl_fecha_nac.Text = validarCampo(funcionario["fecha_nac"]);
                ltl_pais.Text = validarCampo(funcionario["pais"]);
                ltl_departamento.Text = validarCampo(funcionario["departamento"]);
                ltl_provincia.Text = validarCampo(funcionario["provincia"]);
                ltl_localidad.Text = validarCampo(funcionario["localidad"]);

                if (validarCampo(funcionario["fp_foto"]) != "")
                {
                    imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
                }
                else
                {
                    if (validarCampo(funcionario["genero"]) == "M")
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
                    }
                    else
                    {
                        imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
                    }
                }

            }
        }
    }

    protected void btn_nuevo_familiar_Click(object sender, EventArgs e)
    {
        limpiarDatosPersonales();
        hf_pf_id.Value = string.Empty;
        sc = "$('#modalNuevoFamiliar').modal('show');";
        SetScript(sc);
    }
    private void SetScriptInicio(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(data);
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z ]+$/i, ''); });");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_pf_tipo_parentesco').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_nivel_instruccion').select2({ dropdownParent: $('#modalNuevoFormacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_carrera').select2({ dropdownParent: $('#modalNuevoFormacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_titulos').select2({ dropdownParent: $('#modalNuevoFormacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_centro_form').select2({ dropdownParent: $('#modalNuevoFormacion'), placeholder: { id: '0', text: 'Seleccione...' } });");

        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
    }
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z ]+$/i, ''); });");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append(data);
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_pf_tipo_parentesco').select2({ dropdownParent: $('#modalNuevoFamiliar'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_nivel_instruccion').select2({ dropdownParent: $('#modalNuevoFormacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_carrera').select2({ dropdownParent: $('#modalNuevoFormacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_titulos').select2({ dropdownParent: $('#modalNuevoFormacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("$('#ContentPlaceHolder1_ddl_centro_form').select2({ dropdownParent: $('#modalNuevoFormacion'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void btn_nuevo_foramcion_Click(object sender, EventArgs e)
    {
        limpiarFormacion();
        sc = "$('#modalNuevoFormacion').modal('show');";
        SetScript(sc);
    }

    private void listarCiudadResidencia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "ciudad_localidad", cat_id_superior = 29 };
        ddl_perd_ciudad_residencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_perd_ciudad_residencia.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_perd_ciudad_residencia.DataValueField = "cat_id";
        ddl_perd_ciudad_residencia.DataTextField = "cat_descripcion";
        ddl_perd_ciudad_residencia.DataBind();
    }

    private void listarZona()
    {
        _catalogo = new cls_catalogo { cat_tabla = "zona" };
        ddl_perd_zona.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_perd_zona.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_perd_zona.DataValueField = "cat_id";
        ddl_perd_zona.DataTextField = "cat_descripcion";
        ddl_perd_zona.DataBind();
    }

    private void listarTipoVia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_via" };
        ddl_perd_tipo_via.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_perd_tipo_via.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_perd_tipo_via.DataValueField = "cat_id";
        ddl_perd_tipo_via.DataTextField = "cat_descripcion";
        ddl_perd_tipo_via.DataBind();
    }
    private void listarTipoParentesco()
    {
        _catalogo = new cls_catalogo { cat_tabla = "parentesco" };
        ddl_pf_tipo_parentesco.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_pf_tipo_parentesco.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_pf_tipo_parentesco.DataValueField = "cat_secuencial";
        ddl_pf_tipo_parentesco.DataTextField = "cat_descripcion";
        ddl_pf_tipo_parentesco.DataBind();
        SetScript("");
    }
    private void informacionDatosPersonales(int codFun = 0)
    {
        listarCiudadResidencia();
        listarZona();
        listarTipoVia();
        resp_combo = new cls_kd_respuesta_combo();
        resp_combo.p_per_id = codFun;
        var detalleFuncionario = resp_combo.ObtenerDatosPersonales();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                txt_codigo_file.Text = validarCampo(funcionario["file_id_cod"]);
                txt_codigo_file.Enabled = !(validarCampo(funcionario["file_id_cod"]) != "");
                ddl_perd_ciudad_residencia.SelectedValue = validarCampo(funcionario["perd_ciudad_residencia"]);
                ddl_perd_zona.SelectedValue = funcionario["perd_zona"].ToString();// validarCampo(funcionario["perd_zona"]);
                ddl_perd_tipo_via.SelectedValue = validarCampo(funcionario["perd_tipo_via"]);
                txt_nombre_via.Text = validarCampo(funcionario["perd_descripcion_via"]);
                txt_numero_casa.Text = validarCampo(funcionario["perd_numero"]);
                txt_edificio.Text = validarCampo(funcionario["perd_edificio"]);
                txt_bloque.Text = validarCampo(funcionario["perd_bloque"]);
                txt_piso.Text = validarCampo(funcionario["perd_piso"]);
                txt_departamento.Text = validarCampo(funcionario["perd_dpto"]);
                txt_telefono.Text = validarCampo(funcionario["perd_telefono"]);
                txt_celular.Text = validarCampo(funcionario["perd_celular"]);
                txt_email_trabajo.Text = validarCampo(funcionario["perd_email_trabajo"]);
                txt_email_personal.Text = validarCampo(funcionario["perd_email_personal"]);
                //txt_fecha_gamlp.Text = validarCampo(funcionario["perd_tipo_via"]);
                txt_en_caso_emer.Text = validarCampo(funcionario["perd_fam_emergencia"]);
                txt_direccion_emer.Text = validarCampo(funcionario["perd_dir_emergencia"]);
                txt_telf_emer.Text = validarCampo(funcionario["perd_tel_emergencia"]);
                hf_perd_id.Value = validarCampo(funcionario["perd_id"]);
                hf_coordenadas.Value = validarCampo(funcionario["perd_coordenadas"]);
                //txt_codigo_file.Text = validarCampo(funcionario["perd_tipo_via"]);



            }
        }
    }
    private void armarGrillaFamiliares()
    {
        gv_familiares.DataSource = null;
        familiar = new cls_persona_familiares();
        string codFun = Request.QueryString["id"].ToString();
        familiar.pf_per_id = Convert.ToInt32(codFun);
        var familiaresX = familiar.ObtenerGrillaFamiliares();
        if (familiaresX.Tables[0].Rows.Count > 0)
        {
            gv_familiares.DataSource = familiaresX;
            this.block_familia.Visible = false;
        }
        else
        {
            this.block_familia.Visible = true;
        }
        gv_familiares.DataBind();
    }
    private void informacionFamiliares(int codFun = 0)
    {
        listarTipoParentesco();
        armarGrillaFamiliares();
    }

    protected void btn_adicionar_familiar_Click(object sender, EventArgs e)
    {
        familiar = new cls_persona_familiares();
        string codFun = Request.QueryString["id"].ToString();
        familiar.pf_per_id = Convert.ToInt32(codFun);
        familiar.pf_tipo_parentesco = ddl_pf_tipo_parentesco.SelectedValue;
        familiar.pf_paterno = txt_ap_paterno_fam.Text.ToUpper().Trim();
        familiar.pf_materno = txt_ap_materno_fam.Text.ToUpper().Trim();
        familiar.pf_nombres = txt_nombres_fam.Text.ToUpper().Trim();
        familiar.pf_ap_esposo = txt_ap_esposo_fam.Text.ToUpper().Trim();
        familiar.pf_fecha_nac = (txt_fecha_nac_fam.Text != "") ? txt_fecha_nac_fam.Text : null;

        string pf_id = hf_pf_id.Value;
        if (pf_id != "")
        {
            familiar.pf_id = Convert.ToInt32(pf_id);
            familiar.ActualizarEstadoFam();
            familiar.Adicionar();
            sc = "Swal.fire({ icon: 'success', title: 'Familiar editado correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevoFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        }
        else
        {
            familiar.Adicionar();
            sc = "Swal.fire({ icon: 'success', title: 'Familiar adicionado exitosamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevoFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        }

        SetScript(sc);
        armarGrillaFamiliares();
    }

    protected void gv_familiares_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_familiares.Rows.Count > 0)
        {
            if (gv_familiares.HeaderRow != null)
            {
                gv_familiares.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_familiares.FooterRow != null)
            {
                gv_familiares.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_familiares_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string pf_id = gv_familiares.DataKeys[index].Values[0].ToString();
        hf_pf_id.Value = pf_id;
        switch (e.CommandName)
        {
            case "GetEdit":
                llenarDatosFamiliar(Convert.ToInt32(pf_id));
                sc = "$('#modalNuevoFamiliar').modal('show');";
                SetScript(sc);
                break;
            case "GetDelete":
                sc = "$('#eliminarFamiliar').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    protected void llenarDatosFamiliar(int pf_id = 0)
    {
        familiar = new cls_persona_familiares();
        familiar.pf_id = pf_id;
        var detalleFamiliar = familiar.ObtenerFamilarX();
        var familiarX = detalleFamiliar.Tables[0].Rows[0];
        txt_ap_paterno_fam.Text = validarCampo(familiarX["pf_paterno"]);
        txt_ap_materno_fam.Text = validarCampo(familiarX["pf_materno"]);
        txt_nombres_fam.Text = validarCampo(familiarX["pf_nombres"]);
        txt_ap_esposo_fam.Text = validarCampo(familiarX["pf_ap_esposo"]);
        txt_fecha_nac_fam.Text = validarCampo(familiarX["pf_fecha_nac"]);
        ddl_pf_tipo_parentesco.SelectedValue = validarCampo(familiarX["pf_tipo_parentesco"]);
        SetScript("");

    }

    protected void limpiarDatosPersonales()
    {
        txt_ap_paterno_fam.Text = string.Empty;
        txt_ap_materno_fam.Text = string.Empty;
        txt_nombres_fam.Text = string.Empty;
        txt_ap_esposo_fam.Text = string.Empty;
        txt_fecha_nac_fam.Text = string.Empty;
        ddl_pf_tipo_parentesco.SelectedValue = "0";
    }

    protected void btn_guardar_requisitos_Click(object sender, EventArgs e)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        resp_combo = new cls_kd_respuesta_combo { rq_categoria = "KARDEX" };
        var requisitos = resp_combo.ListaRequisitos();

        if (requisitos.Tables[0].Rows.Count > 0)
        {
            DataTable lista_respuesta = new DataTable();
            lista_respuesta.Columns.Add("rp_rq_id");
            lista_respuesta.Columns.Add("rp_rc_id");
            lista_respuesta.Columns.Add("rp_fecha_presentado");
            DataRow dr = null;
            for (int i = 0; i < requisitos.Tables[0].Rows.Count; i++)
            {
                string id_text = "txt_rq_" + i;
                TextBox text_d = (TextBox)pnlDinamico.FindControl(id_text);
                string id_ddl = "ddl_rq_" + i;
                DropDownList ddl = (DropDownList)pnlDinamico.FindControl(id_ddl);

                dr = lista_respuesta.NewRow();
                dr["rp_rq_id"] = Convert.ToInt32(validarCampo(requisitos.Tables[0].Rows[i]["rq_id"]));
                dr["rp_rc_id"] = ddl.SelectedValue;
                dr["rp_fecha_presentado"] = text_d.Text;
                lista_respuesta.Rows.Add(dr);
            }
            string json = JsonConvert.SerializeObject(lista_respuesta);
            resp_combo.rp_nombre_pk = "per_id";
            resp_combo.rp_valor_pk = per_id;
            resp_combo.rp_respuesta = json;
            resp_combo.rp_rq_id = 0;
            resp_combo.rp_rc_id = 0;
            resp_combo.rp_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());
            resp_combo.GuardarRequisitosPresentadosUDEP();
        }
        sc = "Swal.fire({ icon: 'success', title: 'Requisitos guardados correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
        SetScript(sc);
    }

    private void informacionRequisitosPresentados(int codFun = 0)
    {
        resp_combo = new cls_kd_respuesta_combo();
        resp_combo.rp_valor_pk = codFun;
        resp_combo.rp_nombre_pk = "per_id";
        var requisitos_presentados = resp_combo.RequisitosPresentadosFun();


        if (requisitos_presentados.Tables[0].Rows.Count > 0)
        {
            for (int i = 0; i < requisitos_presentados.Tables[0].Rows.Count; i++)
            {
                var funcionario = requisitos_presentados.Tables[0].Rows[i];

                int j = obtenerIndice((validarCampo(funcionario["rp_rq_id"]) != "") ? Convert.ToInt32(validarCampo(funcionario["rp_rq_id"])) : 0);

                if (j != -1)
                {
                    string id_ddl = "ddl_rq_" + j;
                    DropDownList ddl = (DropDownList)pnlDinamico.FindControl(id_ddl);
                    string id_text = "txt_rq_" + j;
                    TextBox text_d = (TextBox)pnlDinamico.FindControl(id_text);

                    ddl.SelectedValue = validarCampo(funcionario["rp_rc_id"]);
                    text_d.Text = validarCampo(funcionario["rp_fecha_presentado"]);
                }
            }
        }


    }
    private int obtenerIndice(int rq_id = 0)
    {
        int nro_requisito = Convert.ToInt32(hf_nro_requisitos.Value);
        int j = -1;

        for (int i = 0; i < nro_requisito; i++)
        {
            string id_hf = "hf_" + i;
            HiddenField hf_ = (HiddenField)pnlDinamico.FindControl(id_hf);
            if (Convert.ToInt32(hf_.Value) == rq_id)
            {
                j = i;
                break;
            }
        }
        return j;
    }

    protected void btn_guardar_datos_personales_Click(object sender, EventArgs e)
    {
        int codFun = Convert.ToInt32(Request.QueryString["id"].ToString());
        int file_id_cod = (txt_codigo_file.Text.Trim() != "") ? Convert.ToInt32(txt_codigo_file.Text.Trim()) : 0;
        _domicilio = new cls_persona_domicilio();
        _domicilio.perd_per_id = codFun;
        var detalleFile = _domicilio.ObtenerDatosFile();

        int cod_file = 0;
        if (detalleFile.Tables.Count > 0 && detalleFile.Tables[0].Rows.Count > 0)
        {
            cod_file = (validarCampo(detalleFile.Tables[0].Rows[0]["file_id_cod"]) != "") ? Convert.ToInt32(validarCampo(detalleFile.Tables[0].Rows[0]["file_id_cod"])) : 0;
            if (cod_file != 0)
            {
                registrarDatosFuncionario(codFun, file_id_cod);
            }
        }
        else
        {
            var file = _domicilio.VerificarExisteFile(file_id_cod);
            if (file.Tables[0].Rows.Count > 0)
            {
                cod_file = (validarCampo(file.Tables[0].Rows[0]["file_id_cod"]) != "") ? Convert.ToInt32(validarCampo(file.Tables[0].Rows[0]["file_id_cod"])) : 0;
                if (cod_file != 0)
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'El CÓDIGO DE FILE registrado ya fue anteriormente asignado, ingrese uno nuevo.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                    SetScript(sc);
                }
            }
            else
            {
                registrarDatosFuncionario(codFun, file_id_cod);
            }

        }
    }
    private void registrarDatosFuncionario(int per_id = 0, int file_id_cod = 0)
    {
        _domicilio = new cls_persona_domicilio();
        _domicilio.perd_id = (hf_perd_id.Value != "") ? Convert.ToInt32(hf_perd_id.Value) : 0;
        _domicilio.Actualizar();

        _domicilio.perd_per_id = Convert.ToInt32(per_id);

        _domicilio.perd_ciudad_residencia = Convert.ToInt32(ddl_perd_ciudad_residencia.SelectedValue);
        _domicilio.perd_zona = Convert.ToInt32(ddl_perd_zona.SelectedValue);
        _domicilio.perd_tipo_via = Convert.ToInt32(ddl_perd_tipo_via.SelectedValue);
        _domicilio.perd_descripcion_via = txt_nombre_via.Text.ToUpper().Trim();
        _domicilio.perd_numero = txt_numero_casa.Text.ToUpper().Trim();

        _domicilio.perd_edificio = txt_edificio.Text.Trim();
        _domicilio.perd_bloque = txt_bloque.Text.Trim();
        _domicilio.perd_piso = txt_piso.Text.Trim();
        _domicilio.perd_dpto = txt_departamento.Text.Trim();

        _domicilio.perd_telefono = txt_telefono.Text.Trim();
        _domicilio.perd_celular = txt_celular.Text.Trim();
        _domicilio.perd_email = txt_email_personal.Text.Trim();
        _domicilio.perd_email_trabajo = txt_email_trabajo.Text.Trim();

        _domicilio.perd_fam_emergencia = txt_en_caso_emer.Text.Trim();
        _domicilio.perd_dir_emergencia = txt_direccion_emer.Text.Trim();
        _domicilio.perd_tel_emergencia = txt_telf_emer.Text.Trim();
        _domicilio.perd_coordenadas = hf_coordenadas.Value;
        _domicilio.perd_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());

        _domicilio.AdicionarDomicilioKardex(file_id_cod, txt_nro_lib.Text.ToUpper().Trim());

        informacionDatosPersonales(Convert.ToInt32(per_id));
        sc = "MostrarMascara(false); Swal.fire({ icon: 'success', title: 'Datos guardados exitosamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { console.log('end'); }});";
        SetScript(sc);
    }
    protected void btn_cancelar_familiar_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevoFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }

    protected void btn_eliminar_familiar_Click(object sender, EventArgs e)
    {
        familiar = new cls_persona_familiares();
        string pf_id = hf_pf_id.Value;
        familiar.pf_id = Convert.ToInt32(pf_id);
        familiar.Eliminar();
        sc = "$.notify({ icon: 'fa fa-trash-alt', message: 'Familiar eliminado correctamente.'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarFamiliar').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
        armarGrillaFamiliares();
    }

    private void informacion_educacion_formal(int codFun = 0)
    {
        listar_nivel_instruccion();
        listar_carrera();
        listar_titulos();
        listar_centro_formacion();
        armarGrillaFormacion();
    }

    private void listar_nivel_instruccion()
    {
        //_catalogo = new cls_catalogo { cat_tabla = "nivel_instruccion" };
        cls_grado_academico grado_academico = new cls_grado_academico();

        ddl_nivel_instruccion.Items.Insert(0, new ListItem("Seleccione...", "0"));
        //ddl_nivel_instruccion.DataSource = _catalogo.ObtenerTablaCombo();
        //ddl_nivel_instruccion.DataValueField = "cat_secuencial";
        //ddl_nivel_instruccion.DataTextField = "cat_descripcion";
        ddl_nivel_instruccion.DataSource = grado_academico.ObtenerGradoAcademico();
        ddl_nivel_instruccion.DataValueField = "ga_id";
        ddl_nivel_instruccion.DataTextField = "ga_nombre";
        ddl_nivel_instruccion.DataBind();
    }
    private void listar_carrera()
    {
        //_catalogo = new cls_catalogo { cat_tabla = "carrera" };
        cls_grado_academico formacion = new cls_grado_academico();

        ddl_carrera.Items.Insert(0, new ListItem("Seleccione...", "0"));
        //ddl_carrera.DataSource = _catalogo.ObtenerTablaCombo();
        //ddl_carrera.DataValueField = "cat_secuencial";
        //ddl_carrera.DataTextField = "cat_descripcion";
        ddl_carrera.DataSource = formacion.ComboFormacionCarreras("C2");
        ddl_carrera.DataTextField = "carr_nombre";
        ddl_carrera.DataValueField = "carr_id";
        ddl_carrera.DataBind();
    }
    private void listar_titulos()
    {
        _catalogo = new cls_catalogo { cat_tabla = "titulos" };
        ddl_titulos.Items.Insert(0, new ListItem("Seleccione...", "0"));
        ddl_titulos.DataSource = _catalogo.ObtenerTablaCombo();
        ddl_titulos.DataValueField = "cat_secuencial";
        ddl_titulos.DataTextField = "cat_descripcion";
        ddl_titulos.DataBind();
    }
    private void listar_centro_formacion()
    {
        //_catalogo = new cls_catalogo { cat_tabla = "centro_formacion_kd" };
        cls_grado_academico formacion = new cls_grado_academico();

        ddl_centro_form.Items.Insert(0, new ListItem("Seleccione...", "0"));
        //ddl_centro_form.DataSource = _catalogo.ObtenerTablaCombo();
        //ddl_centro_form.DataValueField = "cat_secuencial";
        //ddl_centro_form.DataTextField = "cat_descripcion";
        ddl_centro_form.DataSource = formacion.ComboFormacion("C2");
        ddl_centro_form.DataTextField = "it_nombre";
        ddl_centro_form.DataValueField = "it_id";
        ddl_centro_form.DataBind();
    }
    private void armarGrillaFormacion()
    {
        gv_educacion_formal.DataSource = null;
        resp_combo = new cls_kd_respuesta_combo();
        string codFun = Request.QueryString["id"].ToString();
        resp_combo.rp_valor_pk = Convert.ToInt32(codFun);

        var eduacion_formal = resp_combo.ObtenerGrillaEducFormal();
        if (eduacion_formal.Tables[0].Rows.Count > 0)
        {
            gv_educacion_formal.DataSource = eduacion_formal;
            this.block_formacion.Visible = false;
        }
        else
        {
            this.block_formacion.Visible = true;
        }
        gv_educacion_formal.DataBind();
    }

    protected void gv_educacion_formal_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_educacion_formal.Rows.Count > 0)
        {
            if (gv_educacion_formal.HeaderRow != null)
            {
                gv_educacion_formal.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_educacion_formal.FooterRow != null)
            {
                gv_educacion_formal.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_educacion_formal_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_ef_id.Value = gv_educacion_formal.DataKeys[index].Values[0].ToString();
        switch (e.CommandName)
        {
            case "GetEdit":
                llenarDatosFormacion();
                sc = "$('#modalNuevoFormacion').modal('show');";
                SetScript(sc);
                break;
            case "GetDelete":
                sc = "$('#eliminarFormacion').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }
    protected void llenarDatosFormacion()
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());

        formacion = new cls_kd_respuesta_combo();
        formacion.ef_id = Convert.ToInt32(hf_ef_id.Value);
        formacion.ef_per_id = per_id;

        var detalleFormacion = formacion.ObtenerFormacionX();
        var formacionX = detalleFormacion.Tables[0].Rows[0];
        ddl_nivel_instruccion.SelectedValue = validarCampo(formacionX["ef_nivel_instruccion"]);
        ddl_centro_form.SelectedValue = validarCampo(formacionX["ef_centro_form"]);
        ddl_carrera.SelectedValue = validarCampo(formacionX["ef_carrera_especialidad"]);
        ddl_titulos.SelectedValue = validarCampo(formacionX["ef_titulo_obtenido"]);
        txt_nro_titulo.Text = validarCampo(formacionX["ef_nro_titulo"]);
        txt_fecha_titulo.Text = validarCampo(formacionX["ef_fecha_titulo_obtenido"]);
        txt_fecha_inicio.Text = validarCampo(formacionX["ef_fecha_ini"]);
        txt_fecha_fin.Text = validarCampo(formacionX["ef_fecha_fin"]);
        txt_anios_estudio.Text = validarCampo(formacionX["ef_anios_estudio"]);


    }
    protected void btn_adicionar_formacion_Click(object sender, EventArgs e)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        formacion = new cls_kd_respuesta_combo();

        if (hf_ef_id.Value != "")
        {
            formacion.ef_id = Convert.ToInt32(hf_ef_id.Value);
            formacion.ActualizarFormacion();
        }

        formacion.ef_per_id = per_id;
        formacion.ef_nivel_instruccion = Convert.ToInt32(ddl_nivel_instruccion.SelectedValue);
        formacion.ef_centro_form = Convert.ToInt32(ddl_centro_form.SelectedValue);
        formacion.ef_carrera_especialidad = Convert.ToInt32(ddl_carrera.SelectedValue);
        formacion.ef_fecha_ini = (txt_fecha_inicio.Text != "") ? txt_fecha_inicio.Text : null;
        formacion.ef_fecha_fin = (txt_fecha_fin.Text != "") ? txt_fecha_fin.Text : null;
        formacion.ef_anios_estudio = (txt_anios_estudio.Text.Trim() != "") ? Convert.ToInt32(txt_anios_estudio.Text) : 0;
        formacion.ef_titulo_obtenido = Convert.ToInt32(ddl_titulos.SelectedValue);
        formacion.ef_fecha_titulo_obtenido = (txt_fecha_titulo.Text != "") ? txt_fecha_titulo.Text : null;
        formacion.ef_nro_titulo = txt_nro_titulo.Text;
        formacion.RegistrarFormacion();

        limpiarFormacion();
        armarGrillaFormacion();
        sc = "Swal.fire({ icon: 'success', title: 'Formación guardada exitosamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalNuevoFormacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_cancelar_formacion_Click(object sender, EventArgs e)
    {
        sc = "$('#modalNuevoFormacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    private void limpiarFormacion()
    {
        hf_ef_id.Value = "";
        ddl_nivel_instruccion.SelectedValue = "0";
        ddl_centro_form.SelectedValue = "0";
        ddl_carrera.SelectedValue = "0";
        ddl_titulos.SelectedValue = "0";
        txt_nro_titulo.Text = "";
        txt_fecha_titulo.Text = "";
        txt_fecha_inicio.Text = "";
        txt_fecha_fin.Text = "";
        txt_anios_estudio.Text = "";
    }

    protected void btn_eliminar_formacion_Click(object sender, EventArgs e)
    {
        int per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        formacion = new cls_kd_respuesta_combo();
        formacion.ef_id = Convert.ToInt32(hf_ef_id.Value);
        formacion.ActualizarFormacion();

        limpiarFormacion();
        armarGrillaFormacion();
        sc = "Swal.fire({ icon: 'success', title: 'Formación eliminada correctamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarFormacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_estado_Click(object sender, EventArgs e)
    {
        string codFun = Request.QueryString["id"].ToString();
        string as_id = Request.QueryString["id2"].ToString();
        Response.Redirect("FileVirtualPdf?id=" + codFun + "&id2=" + as_id);
    }
}