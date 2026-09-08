using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Precontratacion.BussinessLogicLayer;

using Newtonsoft.Json.Linq;

public partial class MovimientoPersonal_ReprobacionMovimientos : System.Web.UI.Page
{
    private cls_mp_asignacion asignacion = null;
    private cls_mp_seguimiento_memorandum seg_memo = null;
    private cls_pc_precontratado precontratado = null;

    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null)
        {
            if (HttpContext.Current.Session["us_id"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {
                    listaFiltradoTipoMovimiento();
                    Txt_per_id_b.Focus();
                }
            }
            else
            {
                Response.Redirect("../index");

            }
        }
        else
        {
            Response.Redirect("../index");
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

        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
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
            "'sNext': '<i class=" + '"' + "fas fa-angle-right" + '"' + "></i>'," +
            "'sPrevious': '<i class=" + '"' + "fas fa-angle-left" + '"' + "></i>'" +
            "}," +
            "'oAria': {" +
            "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
            "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
            "}" +
            "}," +
            "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 100, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append("$('.checks label').addClass('custom-control-label mb-3'); $('.checks input[type =" + '"' + "checkbox" + '"' + "]').addClass('custom-control-input mb-3');");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    private void listaFiltradoTipoMovimiento()
    {
        try
        {
            DataTable lista_ = new DataTable();
            lista_.Columns.Add("cat_secuencial");
            lista_.Columns.Add("cat_descripcion");
            DataRow dr = null;

            asignacion = new cls_mp_asignacion();
            var detalle = asignacion.ListaFiltradoTipoMovimiento();
            if (detalle.Tables[0].Rows.Count > 0)
            {
                var detalle_cat = detalle.Tables[0];
                for (int i = 0; i < detalle_cat.Rows.Count; i++)
                {
                    string source = "";
                    source = validarCampo(detalle_cat.Rows[i]["cat_descripcion"]);
                    string toRemove = "VALIDACIÓN ";
                    string result = "";
                    int j = source.IndexOf(toRemove);
                    if (j >= 0)
                    {
                        result = source.Remove(j, toRemove.Length);
                    }

                    dr = lista_.NewRow();
                    dr["cat_secuencial"] = validarCampo(detalle_cat.Rows[i]["cat_secuencial"]);
                    dr["cat_descripcion"] = result;
                    lista_.Rows.Add(dr);
                }
            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btnFiltrar_Click(object sender, EventArgs e)
    {

        SetScript("MostrarMascara(false);");
        BindGridView(Txt_per_id_b.Text.Trim(), Txt_per_num_doc_b.Text.Trim(), Txt_per_ap_paterno_b.Text.Trim(), Txt_per_ap_materno_b.Text.Trim(), Txt_per_nombres_b.Text.Trim());
        Limpiar("sch_cl");

        if (gv_reprobar_mov.Rows.Count > 0) sc = "$('#grillaMov').css('display', 'block');";
        else sc = "$.notify({ icon: 'fas fa-exclamation', message: 'No se ha encontrado el registro, revise los parámetros...!!' }, { type: 'warning' }); $('#dResult').css('display', 'none');";
        SetScript(sc);
    }
    private void Limpiar(string val)
    {
        if (val.Equals("sch_cl"))
        {
            Txt_per_num_doc_b.Text = string.Empty;
            Txt_per_ap_paterno_b.Text = string.Empty;
            Txt_per_ap_materno_b.Text = string.Empty;
            Txt_per_nombres_b.Text = string.Empty;
            Txt_per_id_b.Text = string.Empty;
        }
    }
        private void BindGridView(string varId, string varCed, string varPat, string varMat, string varNom)
    {
        try
        {
            cls_persona persona = new cls_persona();
            string ci = Txt_per_num_doc_b.Text;
            int per_id = Convert.ToInt32(persona.ObtenerTablaGrilla(Txt_per_id_b.Text, "", ci, "", Txt_per_ap_paterno_b.Text, Txt_per_ap_materno_b.Text, Txt_per_nombres_b.Text, "", "", "", "", "", "", "").Tables[0].Rows[0]["per_id"].ToString());
            cls_mp_seguimiento_memorandum memo = new cls_mp_seguimiento_memorandum();
            DataSet ds = memo.ObtenerInformacionValidar(per_id);
            var detalleFuncionario = memo.ObtenerInformacionValidar(per_id);
            gv_reprobar_mov.DataSource = detalleFuncionario;
            gv_reprobar_mov.DataBind();
            no_existe_mov.Visible = !(gv_reprobar_mov.Rows.Count > 0);

        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }


    protected void gv_reprobar_mov_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_reprobar_mov.Rows.Count > 0)
        {
            if (gv_reprobar_mov.HeaderRow != null)
            {
                gv_reprobar_mov.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_reprobar_mov.FooterRow != null)
            {
                gv_reprobar_mov.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_reprobar_mov_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_as_id.Value = gv_reprobar_mov.DataKeys[index].Values[0].ToString();
        hf_per_id.Value = gv_reprobar_mov.DataKeys[index].Values[1].ToString();
        hf_ca_id.Value = gv_reprobar_mov.DataKeys[index].Values[2].ToString();
        GridViewRow row = gv_reprobar_mov.Rows[0];
        ObtenerDetalle();

        sc = "$('#modalDetalleMovimiento').modal('show');";
                SetScript(sc);

        SetScript("MostrarMascara(false);");
    }
    private void ObtenerDetalle() {
        asignacion = new cls_mp_asignacion();
        asignacion.as_id = Convert.ToInt32(hf_as_id.Value);
        asignacion.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        var detalleFuncionario = asignacion.ObtenerDatosInformacionAlta();
        armarEstructura(detalleFuncionario);
    }

    private void armarEstructura(DataSet p_funcionario)
    {
        var funcionarioDataset = p_funcionario;
        var funcionario = funcionarioDataset.Tables[0].Rows[0];
        ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
        ltl_ci.Text = validarCampo(funcionario["ci"]);
        ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
        ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
        ltl_programatica.Text = validarCampo(funcionario["cod_prog"]);
        ltl_cod_esc.Text = validarCampo(funcionario["es_escalafon"]);
        ltl_clase.Text = validarCampo(funcionario["ns_clase"]);
        ltl_nivel_salarial.Text = validarCampo(funcionario["ns_nivel"]);
        ltl_haber_basico.Text = validarCampo(funcionario["haber_basico"]);
        ltl_item.Text = validarCampo(funcionario["item"]);
        ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
        ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
        ltl_cat_ubicacion.Text = validarCampo(funcionario["cp_descripcion"]);
        ltl_cat_programatica.Text = validarCampo(funcionario["cat_prog"]);
        ltl_cargo.Text = validarCampo(funcionario["cargo"]);
        ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
        txt_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);

        if (ltl_clase.Text == "P" || ltl_clase.Text == "E")
            txt_fecha_fin.Enabled = false;
        else
            txt_fecha_fin.Enabled = true;
        txt_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);
        hf_ti_item.Value = validarCampo(funcionario["ti_item"]);
        hf_ti_tipo.Value = validarCampo(funcionario["ti_tipo"]);
        hf_as_tipo_mov.Value = validarCampo(funcionario["as_tipo_mov"]);
        hf_as_tipo_reg.Value = validarCampo(funcionario["as_tipo_reg"]);
        if (validarCampo(funcionario["as_estado"]) == "V")
        {
            btn_estado.Text = "Vigente";
            btn_estado.CssClass = "btn btn-sm btn-info float-right";
        }
        else
        {
            btn_estado.Text = "Pasivo";
            btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
        }

        if (validarCampo(funcionario["fp_foto"]) != "")
        {
            imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])funcionarioDataset.Tables[0].Rows[0]["fp_foto"]);
        }
        else
        {
            if (validarCampo(funcionario["per_sexo"]) == "M")
            {
                imgFun.ImageUrl = "../Content/img/theme/user3.jpg";
            }
            else
            {
                imgFun.ImageUrl = "../Content/img/theme/user4.jpg";
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

    protected void btn_estado_Click(object sender, EventArgs e)
    {

    }

    protected void btn_reprobar_mov_Click(object sender, EventArgs e)
    {
        asignacion = new cls_mp_asignacion();
        asignacion.as_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        asignacion.as_id = Convert.ToInt32(hf_as_id.Value);
        asignacion.as_per_id = Convert.ToInt32(hf_per_id.Value);
        asignacion.as_ca_id = Convert.ToInt32(hf_ca_id.Value);
        asignacion.ti_item = hf_ti_item.Value;
        asignacion.ti_tipo = hf_ti_tipo.Value;

                asignacion.ReprobarAlta();
                Limpiar();
                sc = "Swal.fire({ icon: 'success', title: 'Registro reprobado', text: 'Registro reprobado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  $('#modalDetalleMovimiento').modal('hide'); $('#reprobarMov').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#grillaMov').css('display', 'none'); }});";


        SetScript(sc);
    }

    protected void btn_reprobar_Click(object sender, EventArgs e) 
    {
        sc = "$('#reprobarMov').modal('show');";
        SetScript(sc);
    }

    protected void btn_modificar_mov_Click(object sender, EventArgs e)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        seg_memo.as_id = Convert.ToInt32(hf_as_id.Value);
        seg_memo.mh_per_id = Convert.ToInt32(hf_per_id.Value);
        if (txt_fecha_inicio.Text == ltl_fecha_inicio.Text)
        {
            seg_memo.as_fecha_inicio = ltl_fecha_inicio.Text;
        }
        else
        {
            seg_memo.as_fecha_inicio = txt_fecha_inicio.Text;
        }
        if (txt_fecha_fin.Text == ltl_fecha_fin.Text)
        {
            seg_memo.as_fecha_fin = (ltl_fecha_fin.Text == "") ? null : ltl_fecha_fin.Text;
        }
        else
        {
            seg_memo.as_fecha_fin = (txt_fecha_fin.Text == "") ? null : txt_fecha_fin.Text;
        }

        seg_memo.ModificarValidacionAlta();
        sc = "Swal.fire({ icon: 'success', title: 'Movimiento modificado', text: 'Movimiento modificado correctamente ', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalDetalleMovimiento').css('display', 'none'); $('#modificarMov').css('display', 'none');  $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#grillaMov').css('display', 'none'); }});";
        Limpiar();
      
        SetScript(sc);
    }

    protected void btn_modificar_Click(object sender, EventArgs e)
    {
        sc = "$('#modificarMov').modal('show');";
        SetScript(sc);
    }

    protected void Limpiar()
    {
        txt_fecha_inicio.Text = string.Empty;
        txt_fecha_fin.Text = string.Empty;
    }

    private bool gestionCorrecto(string fecha_valida = "")
    {
        int pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        bool sw = false;

        if (fecha_valida != null && fecha_valida != "")
        {
            precontratado = new cls_pc_precontratado { pr_id = pr_id };
            var detalle_gestion = precontratado.ObtenerGestion();
            string gestion_x = "";
            if (detalle_gestion.Tables.Count > 0)
            {
                if (detalle_gestion.Tables[0].Rows.Count > 0)
                {
                    var gestion = detalle_gestion.Tables[0].Rows[0];
                    gestion_x = validarCampo(gestion["pr_gestion"]);
                }
            }

            DateTime fecha_valida_x = Convert.ToDateTime(fecha_valida);

            if (fecha_valida_x.Year.ToString() == gestion_x)
            {
                sw = true;
            }
        }
        return sw;
    }

    protected void btn_ver_movRep_Click(object sender, EventArgs e)
    {
        listarGrillaReprobacionMov();
        sc = "MostrarMascara(false); $('#modalMovReprobados').modal('show');";
        SetScript(sc);
    }

    protected void gv_mov_rep_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_mov_rep.Rows.Count > 0)
        {
            if (gv_mov_rep.HeaderRow != null)
            {
                gv_mov_rep.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_mov_rep.FooterRow != null)
            {
                gv_mov_rep.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    private void listarGrillaReprobacionMov()
    {
        try
        {
            asignacion = new cls_mp_asignacion();
            int pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
            asignacion.as_pr_id = pr_id;
            var grillaMov = asignacion.ObtenerGrillaReprobacionMov();
            int num = grillaMov.Tables[0].Rows.Count;
            block_repMov.Visible = (num > 0) ? false : true;
            gv_mov_rep.DataSource = grillaMov;
            gv_mov_rep.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        //sc = "MostrarMascara(false); $('#modalMovReprobados').modal('show');";
        sc = "$('.modal-backdrop').remove(); $('#reprobarMov').modal('hide');";
        SetScript(sc);
    }

    protected void btn_cancelar_update_Click(object sender, EventArgs e)
    {
        sc = "$('.modal-backdrop').remove(); $('#modificarMov').modal('hide');";
        SetScript(sc);
    }
}