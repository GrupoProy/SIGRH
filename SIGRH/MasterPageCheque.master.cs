using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;

public partial class MasterPageCheque : System.Web.UI.MasterPage
{
    private cls_pc_frecuencia frecuencia = null;
    private string sc = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //cls_periodo periodo = new cls_periodo();
            //CargarFoto(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString()));
            //listaFiltradoGestion();
            //DataSet ds = periodo.ObtenerPeriodoVigente();
            //string pr_id = ds.Tables[0].Rows[0]["pr_id"].ToString();
            //string gestion = ds.Tables[0].Rows[0]["pr_gestion"].ToString();
            //Session["pr_id"] = pr_id;
            //Session["gestion"] = gestion;
            //ltl_gestion.Text = (Session["gestion"] != null) ? "GESTIÓN " + Session["gestion"].ToString() : "";
            ////string pr_id = (Session["pr_id"] != null) ? Session["pr_id"].ToString().Trim() : "";
            ////sc = (pr_id != "") ? "" : "$('#modalPeriodo').modal('show'); $('#ddl_gestion').select2({ dropdownParent: $('#modalPeriodo') });";
            ////SetScriptInicio(sc);
        }


        int timeout = Session.Timeout;
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "seguridad", "verificaSS(" + timeout + ");console.log('pruebaMzaster');", true);

        //Mostrando Notificaciones
        if (HttpContext.Current.Session["texto_notificacion"] != null)
        {
            if (HttpContext.Current.Session["texto_notificacion"].ToString() != "")
            {
                string texto_notificacion = HttpContext.Current.Session["texto_notificacion"].ToString();
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "notificacion", "$.notify({ icon: 'fa fa-check', message: '" + texto_notificacion + "'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });", true);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "notificacion", "Swal.fire({ icon: 'success', title: '" + texto_notificacion + "', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false});", true);
                Session["texto_notificacion"] = "";
            }
        }
    }
    protected void CargarFoto(int per_id)
    {
        cls_mp_cargo cargo = new cls_mp_cargo();
        cargo.as_per_id = per_id;
        cls_persona persona = new cls_persona();
        DataSet ds = persona.ObtenerTablaGrilla__gamlp_vigente(per_id.ToString(), "", "", "", "", "", "", "", "", "", "", "", "", "", 0);

        if (ds.Tables[0].Rows.Count > 0 && (Session["rol"].ToString() == "VALIDACION_COMISIONES" || Session["rol"].ToString() == "INVITADO"))
        {
            cargo.as_id_actual = Convert.ToInt32(ds.Tables[0].Rows[0]["as_id"].ToString());
            var detalleFuncionario = cargo.ObtenerDatosDetalleFuncionario();
            if (detalleFuncionario.Tables.Count > 0)
            {
                if (detalleFuncionario.Tables[0].Rows.Count > 0)
                {
                    var funcionario = detalleFuncionario.Tables[0].Rows[0];
                    if (validarCampo(funcionario["fp_foto"]) != null && validarCampo(funcionario["fp_foto"]) != "")
                    {
                        imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
                    }
                    else
                    {
                        if (validarCampo(funcionario["per_sexo"]) == "M")
                        {
                            imgFun.ImageUrl = "~/Content/img/theme/user3.jpg";
                        }
                        else
                        {
                            imgFun.ImageUrl = "~/Content/img/theme/user4.jpg";
                        }
                    }
                }
            }
        }
        else
            imgFun.ImageUrl = "Content/img/theme/user3.jpg";

    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        sc = "goBack();";
        SetScript(sc);
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
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();
        StringBuilder sb = new StringBuilder();
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
                    "'sNext': '<i class=" + '"' + "fas fa-angle-right" + '"' + "></i>'," +
                    "'sPrevious': '<i class=" + '"' + "fas fa-angle-left" + '"' + "></i>'" +
                    "}," +
                    "'oAria': {" +
                    "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                    "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                    "}," +
                    "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ddl_gestion').select2({ dropdownParent: $('#modalPeriodo') });");
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
    }

    protected void btnSalir_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../index");
    }

    protected void btn_sesion_caducada_Click(object sender, EventArgs e)
    {
        Session.Abandon();
        Response.Redirect("../index");
    }

    protected void btn_cambiar_gestion_Click(object sender, EventArgs e)
    {
        string pr_id = (Session["pr_id"] != null) ? Session["pr_id"].ToString().Trim() : "";
        if (pr_id != "")
        {
            ddl_gestion.SelectedValue = pr_id;
        }
        sc = "$('#modalPeriodo').modal('show');";
        SetScript(sc);
    }
    protected void btn_gestion_Click(object sender, EventArgs e)
    {
        Session["pr_id"] = ddl_gestion.SelectedValue;
        Session["gestion"] = ddl_gestion.SelectedItem.Text;

        sc = "$('#modalPeriodo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); location.reload();";
        SetScript(sc);
    }
    private void listaFiltradoGestion()
    {
        try
        {
            cls_periodo periodo = new cls_periodo();
            ddl_gestion.Items.Clear();
            ddl_gestion.DataValueField = "pr_id";
            ddl_gestion.DataTextField = "pr_gestion";
            ddl_gestion.DataSource = periodo.ObtenerPeriodoVigente();
            ddl_gestion.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void SetScriptInicio(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        //ClientScript.RegisterStartupScript(this.GetType(), uuid, data, true);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, data, true);
    }
    protected void btn_cancelar_gestion_Click(object sender, EventArgs e)
    {
        sc = "$('#modalPeriodo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); location.reload();";
        SetScript(sc);
    }
}
