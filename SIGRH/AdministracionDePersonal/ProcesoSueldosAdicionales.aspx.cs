using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class AdministracionDePersonal_ProcesoSueldosAdicionales : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_pla_proceso_salarios pla_proceso = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                inforamcionSalarioMinimo();
                hf_pc.Value = HttpContext.Current.Session["cod_proceso_adicional"].ToString();
            }
        }
        else Response.Redirect("../Index");
    }    //private void inforamcionUFV()
    //{
    //    int gestion = obtenerGestion();

    //    pla_proceso = new cls_pla_proceso_salarios();
    //    pla_proceso.pc_pr_id = gestion;
    //    var detalleFuncionario = pla_proceso.ObtenerUFVAnterior();
    //    if (detalleFuncionario.Tables.Count > 0)
    //    {
    //        if (detalleFuncionario.Tables[0].Rows.Count > 0)
    //        {
    //            var funcionario = detalleFuncionario.Tables[0].Rows[0];
    //            ltl_ufv_anterior.Text = validarCampo(funcionario["pc_ufv"]);
    //            ltl_fecha_ufv_anterior.Text = validarCampo(funcionario["pc_ufv_fecha"]);
    //            ltl_periodo_anterior.Text = validarCampo(funcionario["pc_titulo"]);
    //        }
    //    }
    //}
    private void inforamcionSalarioMinimo()
    {
        int gestion = obtenerGestion();
        pla_proceso = new cls_pla_proceso_salarios();
        pla_proceso.pc_id = Convert.ToInt32(HttpContext.Current.Session["cod_proceso_adicional"].ToString());
        var detalleFuncionario = pla_proceso.ObtenerSalarioMinimoAdicional();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                txt_pc_id.Text = validarCampo(funcionario["pc_id"]);

                cls_mp_cargo cargo = new cls_mp_cargo();
                if (cargo.ConsultaSiPlanillaEstaEjecutada_adicional(txt_pc_id.Text, Obtenersecuencial().ToString()).Tables[0].Rows[0][0].ToString() == "0")
                {
                    lblMes.Text = "Proceso ADICIONAL Actual: " + validarCampo(funcionario["pc_titulo"]);
                    string salario_minimo = validarCampo(funcionario["sm_importe"]);
                    double haberBasico = Convert.ToDouble(salario_minimo);
                    haberBasico = Math.Round(haberBasico);

                    txt_salario_minimo.Text = Convert.ToString(haberBasico);

                    hf_pc_id.Value = validarCampo(funcionario["pc_id"]);
                    hf_sm_id.Value = validarCampo(funcionario["sm_id"]);
                    hf_sm_importe.Value = validarCampo(funcionario["sm_importe"]);
                    hf_sm_operacion.Value = validarCampo(funcionario["sm_operacion"]);
                    hf_sm_fecha_vigencia.Value = validarCampo(funcionario["sm_fecha_vigencia"]);
                    hf_sm_porcentaje_incremento.Value = validarCampo(funcionario["sm_porcentaje_incremento"]);
                    hf_sm_estado.Value = validarCampo(funcionario["sm_estado"]);
                }
                else
                {
                    sc = "$.notify({ icon: 'fas fa-exclamation', message: 'La planilla ya fue procesada y finalizada' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#confimarGuardarSM').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
                    SetScript(sc);
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
    private int obtenerGestion()
    {
        cargo = new cls_mp_cargo();
        string anio = DateTime.Now.ToString("yyyy");
        cargo.gestion = anio;
        var gestionActual = cargo.ObtenerGestion();

        int gestionFiltrar = 0;
        if (gestionActual.Tables[0].Rows[0]["pr_id"] != DBNull.Value && gestionActual.Tables[0].Rows[0]["pr_id"].ToString().Trim() != "")
        {
            gestionFiltrar = Convert.ToInt32(gestionActual.Tables[0].Rows[0]["pr_id"]);
        }

        return gestionFiltrar;
    }

    protected void btn_guardar_ufv_Click(object sender, EventArgs e)
    {
        //DateTime fecha_ufv = Convert.ToDateTime(txt_fecha_ufv.Text);
        //string dia = fecha_ufv.ToString("dddd");
        //if (dia == "sábado" || dia == "domingo")
        //{
        //    sc = "$.notify({ icon: 'fa fa-info', message: 'La fecha seleccionada no es un día hábil.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
        //    SetScript(sc);
        //}

        //sc = "$('#coonfimarGuardarUFV').modal('show');";
        //SetScript(sc);
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
        sb.Append("$('.decimal').on('input', function (event) { this.value = this.value.replace(/[^0-9,]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    //protected void btn_confirm_guardar_ufv_Click(object sender, EventArgs e)
    //{
    //int gestion = obtenerGestion();
    //pla_proceso = new cls_pla_proceso_salarios();
    //pla_proceso.pc_pr_id = gestion;
    //var detalleFuncionario = pla_proceso.ObtenerUFVActual();
    //if (detalleFuncionario.Tables.Count > 0)
    //{
    //    if (detalleFuncionario.Tables[0].Rows.Count > 0)
    //    {
    //        var funcionario = detalleFuncionario.Tables[0].Rows[0];
    //        if (validarCampo(funcionario["pc_ufv"]) != "")
    //        {
    //            sc = "$.notify({ icon: 'fa fa-info', message: 'El UFV fue registrado anteriormente.'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); $('#coonfimarGuardarUFV').modal('hide');  $('#confirm_edit_item').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
    //            SetScript(sc);
    //        } else
    //        {
    //            int pc_id = Convert.ToInt32(validarCampo(funcionario["pc_id"]));
    //            pla_proceso.pc_ufv = Convert.ToDouble(txt_ufv.Text);
    //            pla_proceso.pc_ufv_fecha = txt_fecha_ufv.Text;
    //            pla_proceso.pc_id = pc_id;
    //            pla_proceso.Actualizar();
    //            sc = "$.notify({ icon: 'fa fa-check', message: 'El UFV fue registrado correctamente.'},{type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#coonfimarGuardarUFV').modal('hide');  $('#confirm_edit_item').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); ";
    //            SetScript(sc);
    //        }

    //    }
    //}
    //txt_ufv.Text = string.Empty;
    //txt_fecha_ufv.Text = string.Empty;

    //}

    protected void btn_guardar_mn_Click(object sender, EventArgs e)
    {
        sc = "$('#confimarGuardarSM').modal('show');";
        SetScript(sc);
    }

    protected void btn_confirm_guardar_sm_Click(object sender, EventArgs e)
    {
        if (chkFntub.Checked == true)
        {
            cls_pla_factor factor = new cls_pla_factor();
            string estado = ""; double valor = 0;
            if (chkFntub.Checked == true) estado = "V"; else estado = "C";
            if (chkFntub.Checked == true) valor = Convert.ToDouble(txtValorFntub.Text); else valor = 0;
            if (txtValorFntub.Text == "") valor = 0;
            factor.ActivarDesactivarFNTUB(estado, valor, 999);
        }

        pla_proceso = new cls_pla_proceso_salarios();
        pla_proceso.sm_id = Convert.ToInt32(hf_sm_id.Value);

        pla_proceso.sm_importe = Convert.ToDouble(txt_salario_minimo.Text);
        pla_proceso.sm_operacion = "P";
        pla_proceso.sm_fecha_vigencia = hf_sm_fecha_vigencia.Value;
        pla_proceso.sm_porcentaje_incremento = Convert.ToDouble(hf_sm_porcentaje_incremento.Value);

        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se actualizó correctamente los datos' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#confimarGuardarSM').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
    }
    private int Obtenersecuencial()
    {
        return Convert.ToInt32(HttpContext.Current.Session["secuencial_adicional"].ToString());
    }
    protected void btnProceso0_Click(object sender, EventArgs e)
    {   //pre proceso
        sc = "window.open('../Administración/PreProceso.aspx', 'width=300,height=300', '_blank');";
        SetScript(sc);
        divProceso2.Visible = true;
        btnProceso1.Enabled = false;
        DivPanelActualizacion.Visible = false;
    }
    protected void btnProceso1_Click(object sender, EventArgs e)
    {   //Proceso inicial
        cls_pla_proceso_salarios proceso1 = new cls_pla_proceso_salarios();
        proceso1.EjecutarProceso1_adicional(Convert.ToInt32(txt_pc_id.Text), Obtenersecuencial());
        divProceso3.Visible = true;
        btnProceso2.Enabled = false;
        DivPanelActualizacion.Visible = false;
    }

    protected void btnProceso2_Click(object sender, EventArgs e)
    {   //Cotizables
        cls_pla_proceso_salarios proceso2 = new cls_pla_proceso_salarios();
        proceso2.EjecutarProceso2_adicional(Convert.ToInt32(txt_pc_id.Text), Obtenersecuencial());

        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();

        //DataSet ds= proceso.VerificarCasosDoblePercepcion(0, "C1");
        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    GvLista.DataSource = proceso.VerificarCasosDoblePercepcion(0, "C1");
        //    GvLista.DataBind();
        //    divProceso3_1.Visible = true;
        //    DivPanelActualizacion.Visible = false;
        //}
        //else
        //{
        //    divProceso4.Visible = true;
        //    btnProceso3.Enabled = false;
        //    DivPanelActualizacion.Visible = false;
        //}



        DataSet dss = proceso2.VerificarCasosDoblePercepcion_adicional(Convert.ToInt32(txt_pc_id.Text), "C1", Obtenersecuencial().ToString());
        if (dss.Tables[0].Rows.Count > 0)
        {
            GvLista.DataSource = proceso.VerificarCasosDoblePercepcion_adicional(Convert.ToInt32(txt_pc_id.Text), "C1", Obtenersecuencial().ToString());
            GvLista.DataBind();
            divProceso3_1.Visible = true;
            btnProceso3.Enabled = false;
            divSanciones.Visible = false;
            divProceso5.Visible = false;
            DivDoblePercepcion.Visible = true;
            DivAjuste.Visible = true;
            sc = "$.notify({ icon: 'fas fa-check', message: 'No es posible continuar al siguiente paso si existen casos de Doble Percepción...' }, { type: 'warning' }); window.open('../Administración/DoblePercepcion.aspx', 'width=300,height=300', '_blank');";
            SetScript(sc);

        }
        else
        {
            divProceso3_1.Visible = false;
            divProceso3_1_fake.Visible = true;
            btDPfake.Enabled = false;
            divSanciones.Visible = true;
            btnProceso3.Enabled = false;
            DivPanelActualizacion.Visible = false;
        }


        //divProceso3_1.Visible = true;
        //btnProceso3.Enabled = false;


    }


    protected void btnProceso3_1_Click(object sender, EventArgs e)
    {   //Doble Percepcion
        sc = "window.open('../Administración/DoblePercepcion.aspx', 'width=300,height=300', '_blank');";
        SetScript(sc);
        divSanciones.Visible = true;
        //btnProceso3_1.Enabled = false;
        DivPanelActualizacion.Visible = false;
    }
    protected void btnProceso3_Click(object sender, EventArgs e)
    {   //Afp
        cls_pla_proceso_salarios proceso3 = new cls_pla_proceso_salarios();
        proceso3.EjecutarProceso3_adicional(Convert.ToInt32(txt_pc_id.Text), Obtenersecuencial());
        divProceso5.Visible = true;
        btnProceso4.Enabled = false;
        DivPanelActualizacion.Visible = false;
    }

    protected void btnProceso4_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso3 = new cls_pla_proceso_salarios();
        proceso3.EjecutarProceso4_adicional(Convert.ToInt32(txt_pc_id.Text), Obtenersecuencial());
        btnProceso5.Enabled = false;
        DivPanelActualizacion.Visible = false;

        sc = "Swal.fire({ icon: 'success', title: 'Proceso de Planillas Completado', text: 'Revise las planillas físicas, luego de pulsar el botón FINALIZAR, se procederá a la generación de Líquidos Pagables. Una vez confirmado este paso, no será posible volver a procesar.', showConfirmButton: true, allowOutsideClick: false, onAfterClose: () => {  }});";
        btnAjustar.Visible = true;
        //Response.Redirect("../Salarios/CambioFuente.aspx");
        //sc = "$('#ConfirmacionProceso').modal('show');";
        //SetScript(sc, "");
        //sc = "$.notify({ icon: 'fas fa-check', message: 'Se ejecutaron los procesos de sueldos con éxito' }, { type: 'success' });";
        SetScript(sc, "");

    }
    protected void btnVerificarCi_Click(object sender, EventArgs e)
    {
        Response.Redirect("../Administración/PlanillaLiquidosPagables.aspx");
    }
    protected void btnProceso5_Click(object sender, EventArgs e)
    {

    }

    protected void btnProceso6_Click(object sender, EventArgs e)
    {

    }

    protected void btnProceso7_Click(object sender, EventArgs e)
    {

    }
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




    protected void chkFntub_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFntub.Checked == true)
        {
            txtValorFntub.Visible = true;
            lblFNTUB.Visible = true;
        }
        else
        {
            txtValorFntub.Visible = false; ;
            lblFNTUB.Visible = false;
        }
    }
    private DataSet AjusteDoblePercepcion(string ti_tipo, int cbh_id, int horas, double ganado, double esc_por, double esc, double bono_a, double bono_f)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        return proceso.AjusteDoblePercepcion_adicional(ti_tipo, cbh_id, horas, ganado, esc_por, esc, bono_a, bono_f);
    }
    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string per_id = GvLista.DataKeys[index].Values["CBH_per_id"].ToString();
        ltl_cod_fun.Text = GvLista.DataKeys[index].Values["nombres_completo"].ToString();
        if (e.CommandName.Equals("AjustarDPercepcion"))
        {
            DivDoblePercepcion.Visible = true;
            cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
            gvDoblePercepcion.DataSource = proceso.VerificarCasosDoblePercepcion_adicional(Convert.ToInt32(per_id), "C2", Obtenersecuencial().ToString());
            gvDoblePercepcion.DataBind();
            //lblTotalDoblePercepcion.Text = "Total Cotizable: Bs" + Totalizar(gvDoblePercepcion, 4).ToString();
            lblTotalDoblePercepcion.Text = "Total Cotizable: Bs " + string.Format("{0:n2}", Double.Parse(Totalizar(gvDoblePercepcion, 4).ToString()));
            //sc = "$('#modalDoblePercepcion').modal('show');";
            //SetScript(sc);
        }
    }
    private double Totalizar(GridView gv, int index)
    {
        double total = 0;
        foreach (GridViewRow item in gv.Rows)
        {
            total = Convert.ToDouble(item.Cells[index].Text) + total;
        }
        return total;
    }
    protected void gvDoblePercepcion_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        DataSet DPAjuste = AjusteDoblePercepcion(gvDoblePercepcion.DataKeys[index].Values["ti_tipo"].ToString(), Convert.ToInt32(gvDoblePercepcion.DataKeys[index].Values["cbh_id"].ToString()), Convert.ToInt32(gvDoblePercepcion.DataKeys[index].Values["horas"].ToString()), Convert.ToDouble(gvDoblePercepcion.DataKeys[index].Values["hganado"].ToString()), Convert.ToDouble(gvDoblePercepcion.DataKeys[index].Values["esc_por"].ToString()), Convert.ToDouble(gvDoblePercepcion.DataKeys[index].Values["escalafon"].ToString()), Convert.ToDouble(gvDoblePercepcion.DataKeys[index].Values["bono"].ToString()), Convert.ToDouble(gvDoblePercepcion.DataKeys[index].Values["bono_frontera"].ToString()));
        if (DPAjuste.Tables[0].Rows.Count > 0)
        {
            hdf_ti_tipo.Value = gvDoblePercepcion.DataKeys[index].Values["ti_tipo"].ToString();
            hdf_cbh_id.Value = gvDoblePercepcion.DataKeys[index].Values["cbh_id"].ToString();
            hdf_horas.Value = gvDoblePercepcion.DataKeys[index].Values["horas"].ToString();
            hdf_ganado.Value = gvDoblePercepcion.DataKeys[index].Values["hganado"].ToString();
            hdf_esc_por.Value = gvDoblePercepcion.DataKeys[index].Values["esc_por"].ToString();
            hdf_esc.Value = gvDoblePercepcion.DataKeys[index].Values["escalafon"].ToString();
            hdf_bono_a.Value = gvDoblePercepcion.DataKeys[index].Values["bono"].ToString();
            hdf_bono_f.Value = gvDoblePercepcion.DataKeys[index].Values["bono_frontera"].ToString();

            gvAjusteDoblePercepcion.DataSource = DPAjuste;
            gvAjusteDoblePercepcion.DataBind();
            DivAjuste.Visible = true;
            lblConceptoAjuste.Text = DPAjuste.Tables[0].Rows[0]["HORAS"].ToString();
            //lblAjusteDoblePercepcion.Text = "Total Cotizable Ajustado: Bs" + Totalizar(gvAjusteDoblePercepcion, 3).ToString();
            lblAjusteDoblePercepcion.Text = "Total Cotizable Ajustado: Bs " + string.Format("{0:n2}", Double.Parse(Totalizar(gvAjusteDoblePercepcion, 3).ToString()));

            //sc = "$('#modalDoblePercepcion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();$('#modalDoblePercepcion').modal('show');";
            //SetScript(sc);
        }

    }
    private void VerificarDoblePercepcion_()
    {
        cls_pla_proceso_salarios proceso2 = new cls_pla_proceso_salarios();

        DataSet dss = proceso2.VerificarCasosDoblePercepcion_adicional(Convert.ToInt32(txt_pc_id.Text), "C1", Obtenersecuencial().ToString());
        if (dss.Tables[0].Rows.Count > 0)
        {
            GvLista.DataSource = proceso2.VerificarCasosDoblePercepcion_adicional(Convert.ToInt32(txt_pc_id.Text), "C1", Obtenersecuencial().ToString());
            GvLista.DataBind();
            divProceso3_1.Visible = true;
            btnProceso3.Enabled = false;
            divSanciones.Visible = false;
            divProceso5.Visible = false;
            DivDoblePercepcion.Visible = true;
            DivAjuste.Visible = true;
            sc = "$.notify({ icon: 'fas fa-check', message: 'No es posible continuar al siguiente paso si existen casos de Doble Percepción...' }, { type: 'warning' }); window.open('../Administración/DoblePercepcion.aspx', 'width=300,height=300', '_blank');";
            SetScript(sc);

        }
        else
        {
            divProceso3_1.Visible = false;
            divProceso3_1_fake.Visible = true;
            btDPfake.Enabled = false;
            divSanciones.Visible = true;
            btnProceso3.Enabled = false;
            DivPanelActualizacion.Visible = false;
        }
    }
    protected void btnAplicarAjusteDPercepcion_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        if (proceso.AplicarAjusteDoblePercepcion_adicional(hdf_ti_tipo.Value, Convert.ToInt32(hdf_cbh_id.Value), Convert.ToInt32(hdf_horas.Value), Convert.ToDouble(hdf_ganado.Value), Convert.ToDouble(hdf_esc_por.Value), Convert.ToDouble(hdf_esc.Value), Convert.ToDouble(hdf_bono_a.Value), Convert.ToDouble(hdf_bono_f.Value)))
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se aplicó el ajuste de la Doble Percepción correctamente' }, { type: 'success' }); $('#dResult').css('display', 'none');";
        else
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se pudo realizar el ajuste, consulte al Administrador del Sistema' }, { type: 'danger' }); $('#dResult').css('display', 'none');";
        SetScript(sc);

        DivDoblePercepcion.Visible = false;
        DivAjuste.Visible = false;
        //btnProceso2_Click(null, null);
        VerificarDoblePercepcion_();
    }

    protected void gvAjusteDoblePercepcion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Cells[4].Visible = false;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[4].Visible = false;
            if (Convert.ToInt32(e.Row.Cells[4].Text) == Convert.ToInt32(hdf_cbh_id.Value))
            {
                e.Row.BackColor = System.Drawing.Color.LightGreen;
            }
        }
    }

    protected void gvDoblePercepcion_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[1].Text == "ADMINISTRATIVO")
            {
                LinkButton btn = e.Row.FindControl("btnCheck") as LinkButton;
                btn.Visible = false;
            }

        }
    }



    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) { GvLista.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (GvLista.FooterRow != null) { GvLista.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }
    protected void btnCancelarVerificacionCI_Click(object sender, EventArgs e)
    {
        sc = "$('#ConfirmacionProceso').modal('hide'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }

    protected void btnAjustar_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        if (proceso.FinalizarProcesoPlanilla(Convert.ToInt32(txt_pc_id.Text).ToString(), Obtenersecuencial().ToString()) == true)
        {
            sc = "Swal.fire({ icon: 'success', title: 'Se modificó la fuente de financiamiento satisfactoriamente', text: 'Asignación exitosa', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            SetScript(sc);
            Response.Redirect("../Administración/PlanillaHaberes.aspx");
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message:'No se pudo finalizar la planilla, consulte con el Administrador'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }

    }

    protected void btnSanciones_Click(object sender, EventArgs e)
    {
        cls_pla_proceso_salarios proceso = new cls_pla_proceso_salarios();
        proceso.Procesar_Sanciones_Adicional(Obtenersecuencial(),Convert.ToInt32(hf_pc.Value),1);
        divProceso4.Visible = true;
        btnSanciones.Enabled = false;
        DivPanelActualizacion.Visible = false;
    }
}