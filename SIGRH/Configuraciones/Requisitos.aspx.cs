using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_Kardex.BussinessLogicLayer;
public partial class Configuraciones_Requisitos : System.Web.UI.Page
{
    private cls_kd_respuesta_combo requisito = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            listarRequisitos();
            
        }
    }

    protected void gv_requisitos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        hf_rq_id.Value = gv_requisitos.DataKeys[index].Values[0].ToString();
        switch (e.CommandName)
        {
            case "GetAssign":
                sc = "$('#modalAdicionarResp').modal('show');";
                SetScript(sc);
                break;
            case "GetEdit":
                listaFiltradoCategoria();
                datosRequisito();
                sc = "$('#modalAdicionarReq').modal('show');";
                SetScript(sc);
                break;
            case "GetDelete":
                listaFiltradoCategoria();
                datosRequisito();
                sc = "$('#eliminarRequisito').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }
    private void datosRequisito ()
    {
        requisito = new cls_kd_respuesta_combo{ rq_id = Convert.ToInt32(hf_rq_id.Value) };
        var detalleRequisito = requisito.ObtenerRequisitoX();

        if (detalleRequisito.Tables.Count > 0)
        {
            if (detalleRequisito.Tables[0].Rows.Count > 0)
            {
                var requisitoX = detalleRequisito.Tables[0].Rows[0];
                txt_descripcion.Text = validarCampo(requisitoX["rq_descripcion"]);
                ddl_categoria.SelectedValue = validarCampo(requisitoX["rq_categoria"]);
                nuevo_cat.Visible = (validarCampo(requisitoX["rq_categoria"]) == "1");
                rf_desc_categoria.Enabled = (validarCampo(requisitoX["rq_categoria"]) == "1");
            }
        }
    }
    protected void gv_requisitos_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_requisitos.Rows.Count > 0)
        {
            if (gv_requisitos.HeaderRow != null)
            {
                gv_requisitos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_requisitos.FooterRow != null)
            {
                gv_requisitos.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
    private void listarRequisitos()
    {
        try
        {
            requisito = new cls_kd_respuesta_combo();
            gv_requisitos.DataSource = requisito.ObtenerGrillaRequisitos();
            gv_requisitos.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void btn_nuevo_requisito_Click(object sender, EventArgs e)
    {
        hf_rq_id.Value = "0";
        txt_descripcion.Text = string.Empty;
        txt_desc_categoria.Text = string.Empty;
        nuevo_cat.Visible = false;
        listaFiltradoCategoria();
        sc = "$('#modalAdicionarReq').modal('show');";
        SetScript(sc);
    }

    protected void gv_resp_requisitos_PreRender(object sender, EventArgs e)
    {

    }

    protected void gv_resp_requisitos_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    private void listaFiltradoCategoria()
    {
        try
        {
            requisito = new cls_kd_respuesta_combo();

            ddl_categoria.Items.Clear();
            ddl_categoria.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_categoria.DataValueField = "rq_categoria";
            ddl_categoria.DataTextField = "rq_categoria";
            ddl_categoria.DataSource = requisito.ObtenerFiltradoCategoria();
            ddl_categoria.Items.Insert(1, new ListItem("**** ADICIONAR NUEVO ****", "1"));
            ddl_categoria.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
 
    protected void ddl_categoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        nuevo_cat.Visible = (ddl_categoria.SelectedValue == "1");
        rf_desc_categoria.Enabled = (ddl_categoria.SelectedValue == "1");
        SetScript("");
    }

    protected void btn_adicionar_requisito_Click(object sender, EventArgs e)
    {
        if (hf_rq_id.Value != "0")
        {
            //(ddl_categoria.Items.FindByValue(txt_desc_categoria.Text) != null) ? txt_desc_categoria.Text : "TC";
            requisito = new cls_kd_respuesta_combo
            {
                rq_id = Convert.ToInt32(hf_rq_id.Value),
                rq_descripcion = txt_descripcion.Text.ToUpper().Trim(),
                rq_categoria = (ddl_categoria.SelectedValue != "1") ? ddl_categoria.SelectedValue : txt_desc_categoria.Text.ToUpper().Trim(),
                rq_estado = "V",
                rq_usuario_creacion = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0
            };
            requisito.ActualizarRequisito();
        } else
        {
            requisito = new cls_kd_respuesta_combo
            {
                rq_descripcion = txt_descripcion.Text.ToUpper().Trim(),
                rq_categoria = (ddl_categoria.SelectedValue != "1") ? ddl_categoria.SelectedValue : txt_desc_categoria.Text.ToUpper().Trim(),
                rq_estado = "V",
                rq_usuario_creacion = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0
            };
            requisito.AdicionarRequisito();
        }
        listarRequisitos();
        sc = "Swal.fire({ icon: 'success', title: 'Requisito registrado exitosamente.', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#modalAdicionarReq').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }

    protected void btn_cerrar_Click(object sender, EventArgs e)
    {
        hf_rq_id.Value = "0";
        SetScript("$('#modalAdicionarReq').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();");
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
        sb.Append("$('.fecha').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.letras').on('input', function () { this.value = this.value.replace(/[^A-Z ]+$/i, ''); });");

        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_categoria').select2({ dropdownParent: $('#modalAdicionarReq'), placeholder: { id: '0', text: 'Seleccione...' } });");
        //sb.Append("$('#ContentPlaceHolder1_ddl_situacion_persona').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");

        sb.Append(" $('.table').DataTable({" +
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
                    "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'stateSave': true, 'stateDuration': 60 * 10 }); ");

        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
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

    protected void btn_eilminar_req_Click(object sender, EventArgs e)
    {
        requisito = new cls_kd_respuesta_combo
        {
            rq_id = Convert.ToInt32(hf_rq_id.Value),
            rq_descripcion = txt_descripcion.Text.ToUpper().Trim(),
            rq_categoria = (ddl_categoria.SelectedValue != "1") ? ddl_categoria.SelectedValue : txt_desc_categoria.Text.ToUpper().Trim(),
            rq_estado = "V",
            rq_usuario_creacion = (Session["us_id"] != null) ? Convert.ToInt32(Session["us_id"].ToString()) : 0
        };
        requisito.EliminarRequisito();
        listarRequisitos();
        sc = "Swal.fire({ icon: 'success', title: 'Requisito eliminado exitosamente.', text: 'Registro exitoso', timer: 1700, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarRequisito').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }
}