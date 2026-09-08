using System;
using System.Collections.Generic;
using System.Data;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Salarios.BussinessLogicLayer;

public partial class Salarios_HorasDocentes : System.Web.UI.Page
{
    private cls_pla_factor factor = null;
    private string sc = "";
    bool noRegistrados = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                ListarUnidades();
                //ListarDocentes();
            }
        }
        else Response.Redirect("../Index");
    }

    private void ListarUnidades()
    {
        cls_pla_docente_horas horas = new cls_pla_docente_horas();
        ddlUnidades.Items.Add("...Elegir...");
        //ddlUnidades.DataSource = horas.ObtenerUnidadesOrganizacionales();
        ddlUnidades.DataSource = horas.ObtenerUnidadesOrganizacionales_filtrado(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString()));

        ddlUnidades.DataTextField = "UNIDAD";
        ddlUnidades.DataValueField = "unidad_id";
        ddlUnidades.DataBind();
    }

    protected void gv_horas_docentes_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_horas_docentes.Rows.Count > 0)
        {
            if (gv_horas_docentes.HeaderRow != null)
            {
                gv_horas_docentes.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_horas_docentes.FooterRow != null)
            {
                gv_horas_docentes.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }



    private void ListarDocentes()
    {
            cls_pla_docente_horas horasDocentes = new cls_pla_docente_horas();
            gv_horas_docentes.DataSource = horasDocentes.ListarGrillaDocentesMes();
            gv_horas_docentes.DataBind();
    }




    protected void Limpiar()
    {
    }


    protected void btnGuardarHorasDocentes_Click(object sender, EventArgs e)
    {
        string horasInicio = ""; 
        string horasModificar = "";
        cls_pla_docente_horas horasDocente = new cls_pla_docente_horas();
        int index = 0;
        foreach (GridViewRow item in gv_horas_docentes.Rows)
        {
            horasDocente.pdh_per_id = Convert.ToInt32(gv_horas_docentes.DataKeys[index]["as_per_id"].ToString());
            horasDocente.pdh_as_id = Convert.ToInt32(gv_horas_docentes.DataKeys[index]["as_id"].ToString());
            horasInicio = ((Label)item.FindControl("lblHoras")).Text;
            horasModificar = ((TextBox)gv_horas_docentes.Rows[index].Cells[0].FindControl("txtHoras")).Text;
            if (horasInicio == "0" && horasModificar != "")
            {
                if (Convert.ToInt32(horasModificar) > 0 && horasModificar!="0")
                {
                    horasDocente.pdh_horas = Convert.ToInt32(horasModificar);
                    horasDocente.AdicionarHorasDocentes(horasDocente);
                }
            }
            else
            if (horasModificar != "")
            {
                if (horasInicio != horasModificar && horasModificar != "0")
                {
                    horasDocente.pdh_horas = Convert.ToInt32(horasModificar);
                    horasDocente.pdh_id = Convert.ToInt32(gv_horas_docentes.DataKeys[index]["pdh_id"].ToString());
                    horasDocente.ModificarHorasDocentes(horasDocente);
                }
            }
            index = index + 1;
        }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Se registraron solamente las horas diferentes a cero...!!' }, { type: 'info' });";
        SetScript(sc, "");
        //ListarDocentes();
        Filtrar();

    }
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
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
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
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }


    protected void gv_horas_docentes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox txtHoras = e.Row.Cells[0].FindControl("txtHoras") as TextBox;
        Label lblHoras = e.Row.Cells[0].FindControl("lblHoras") as Label;
        if (lblHoras != null)
        {
            txtHoras.Text = lblHoras.Text;
            //chkFaltantes_CheckedChanged(null, null);
            if (noRegistrados == true && lblHoras.Text != "0")
            {
                e.Row.Visible = false;
            }
            else
                e.Row.Visible = true;

            //cls_mp_asignacion asignacion = new cls_mp_asignacion();
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    DataSet ds = asignacion.ObtenerTodasLasAsignacionesVigentes(Convert.ToInt32(gv_horas_docentes.DataKeys[e.Row.RowIndex].Value));
            //    if (ds.Tables[0].Rows.Count > 1)
            //    {
            //        int index = 1;
            //        foreach (DataRow item in ds.Tables[0].Rows)
            //        {
            //            LinkButton lnk = new LinkButton();
            //            lnk.ID = "lnkAsignacion" + index;
            //            lnk.CommandName = "GetAsignacion";
            //            lnk.CommandArgument = "<%# Container.DataItemIndex %>";
            //            lnk.CssClass = "btn btn-info btn-sm";
            //            lnk.Text = "<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>";
            //            e.Row.Cells[3].Controls.Add(lnk);
            //        }
            //    }
            //}
            SetScript("", "");

        }
    }
    protected void lnkAsignacion1_Click(object sender, EventArgs e)
    { }
    protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        Filtrar();
    }
    private void Filtrar()
    {
        cls_pla_docente_horas horas = new cls_pla_docente_horas();
        int eo_id = 0;
        if (ddlUnidades.SelectedValue != "TODAS")
            eo_id = Convert.ToInt32(ddlUnidades.SelectedValue);
        gv_horas_docentes.DataSource = horas.ListarGrillaDocentesMesPorUnidad(eo_id);
        gv_horas_docentes.DataBind();
        SetScript("","");
    }
    protected void chkFaltantes_CheckedChanged(object sender, EventArgs e)
    {
        if (chkFaltantes.Checked == true)
            noRegistrados = true;
        else
            noRegistrados = false;
        Filtrar();
    }
}