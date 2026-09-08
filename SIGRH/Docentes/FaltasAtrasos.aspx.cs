using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using static System.Net.Mime.MediaTypeNames;

public partial class Docentes_FaltasAtrasos : System.Web.UI.Page
{
    private string sc = "";
    bool noRegistrados = false;
    private cls_materia materia = null; //ojo
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (HttpContext.Current.Session["us_id"] != null) //ojo
            {

                ListarUnidades();

                materia = new cls_materia();

                string s = materia.btnValidar(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString()));


                if (materia.btnValidar(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString())) == "DIRECTOR DE CARRERA")
                {

                    btnAprobar.Visible = false;
                    btnDevalidar.Visible = false;

                }

                if (materia.btnValidar(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString())) == "DIRECTOR ACADÉMICO")
                {

                    btnValidar.Visible = false;

                }

                






                //if (ssda == "S")
                //{
                //((CheckBox)row.FindControl("chk_select")).Checked = true;
                //}
                //else
                //{
                //  ((CheckBox)row.FindControl("chk_select")).Checked = false;
                //}
                //}


            }
            else
            {
                Response.Redirect("../index");
            }
        }
        
    }
    private void ListarUnidades()
    {
        cls_materia materia = new cls_materia();
        ddlUnidades1.Items.Add("...Elegir...");
        if (Session["rol"].ToString() == "ADMINISTRADOR")
        {
            ddlUnidades1.Items.Add("MOSTRAR TODOS");
        }

        ddlUnidades1.DataSource = materia.ObtenerUnidadesOrganizacionales_filtrado_docentes(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString()));
        
        ddlUnidades1.DataTextField = "UNIDAD";
        ddlUnidades1.DataValueField = "unidad_id";
        ddlUnidades1.DataBind();
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

    protected void btnGuardarHorasDocentes_Click(object sender, EventArgs e)
    {
        string horasInicio = "";
        string horasModificar = "";
        string faltas = "";
        string atrasos = "";
        string faltasModificar = "";
        string atrasosModificar = "";
        int eo_id = 0;
        cls_materia materia = new cls_materia();
        int index = 0;
        foreach (GridViewRow item in gv_horas_docentes.Rows)
        {
            materia.mat_per_id = Convert.ToInt32(gv_horas_docentes.DataKeys[index]["as_per_id"].ToString());
            materia.mat_mc_id = Convert.ToInt32(gv_horas_docentes.DataKeys[index]["mc_id"].ToString());
            horasInicio = ((Label)item.FindControl("lblHoras")).Text;
            faltas = ((Label)item.FindControl("lblFaltas")).Text;
            atrasos = ((Label)item.FindControl("lblAtrasos")).Text;
            TextBox atraM = (TextBox)item.Cells[5].FindControl("txtAtrasos");
            TextBox faltM = (TextBox)item.Cells[6].FindControl("txtFaltas");
            faltasModificar = faltM.Text;
            atrasosModificar = atraM.Text;
            string nombre = gv_horas_docentes.Rows[index].Cells[0].Text;
            string x = "";

            if (atrasosModificar != "" || faltasModificar != "")
            {
                //if (Convert.ToInt32(faltas) != Convert.ToInt32(faltasModificar) || Convert.ToInt32(atrasos) != Convert.ToInt32(atrasosModificar) || Convert.ToInt32(horasInicio) != Convert.ToInt32(horasModificar))
                //{
                materia.ht_hrs_mes = Convert.ToInt32(horasInicio);
                materia.ht_faltas = Convert.ToInt32(faltasModificar);
                materia.ht_atrasos = Convert.ToInt32(atrasosModificar);
                materia.Docente_ModificarHorasFaltasAtrasos();
                //}
            }
            else
            {
                materia.ht_hrs_mes = Convert.ToInt32(horasInicio);
                materia.ht_faltas = Convert.ToInt32("0");
                materia.ht_atrasos = Convert.ToInt32("0");
                materia.Docente_ModificarHorasFaltasAtrasos();
                
            }
            index = index + 1;
            
        }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Se registraron solamente las horas diferentes a cero...!!' }, { type: 'info' });";
        SetScript(sc, "");
        //ListarDocentes();
        //Filtrar();
        Response.Redirect("../Docentes/FaltasAtrasos.aspx");

    }
    
    protected void OnChange_chk_select(Object sender, EventArgs e)
    {
        CheckBox chk = (CheckBox)sender;
        GridViewRow row = (GridViewRow)chk.NamingContainer;
        materia = new cls_materia();
        HiddenField1.Value = gv_horas_docentes.DataKeys[row.RowIndex].Values[2].ToString();
        int asig = Convert.ToInt32(HiddenField1.Value);
        if (gv_horas_docentes.DataKeys[row.RowIndex].Values[3].ToString() == "S")
        {
            //materia.CambiarEstadoAsig2(asig);
            materia.CambiarEstadoAsig(asig);
        }
        else
        {
            if (gv_horas_docentes.DataKeys[row.RowIndex].Values[3].ToString() == "P")
            {
                //materia.CambiarEstadoAsig(asig);
                materia.CambiarEstadoAsig2(asig);
            }

        }

        /*if (chk.Checked == true)
        {
            materia.CambiarEstadoAsig2(asig);
        }
        else {
            if (chk.Checked == false) {
                materia.CambiarEstadoAsig(asig);
            }
            
        }*/

        gv_horas_docentes.DataSource = materia.DOCENTES_ListarGrillaDocentesMesPorUnidad(Convert.ToInt32(f_h.Value));
        gv_horas_docentes.DataBind();
        SetScript(sc, "");

    }
    


    protected void gv_horas_docentes_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        TextBox txtHoras = e.Row.Cells[0].FindControl("txtHoras") as TextBox;
        Label lblHoras = e.Row.Cells[0].FindControl("lblHoras") as Label;
        TextBox txtFaltas = e.Row.Cells[0].FindControl("txtFaltas") as TextBox;
        Label lblFaltas = e.Row.Cells[0].FindControl("lblFaltas") as Label;
        TextBox txtAtrasos = e.Row.Cells[0].FindControl("txtAtrasos") as TextBox;
        Label lblAtrasos = e.Row.Cells[0].FindControl("lblAtrasos") as Label;
        TextBox txtEstado = e.Row.Cells[0].FindControl("txtEstado") as TextBox;
        Label lblEstado = e.Row.Cells[0].FindControl("lblEstado") as Label;
        Label lblchk_select = e.Row.Cells[0].FindControl("lblchk_select") as Label;
        CheckBox chk_select = e.Row.Cells[0].FindControl("chk_select") as CheckBox;
        //string o2 = Convert.ToString(e.Row.Cells[0].TemplateControl);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // Obtener el valor de la columna correspondiente a tu CheckBox en la fila actual
            
            string o = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "as_validacion"));
            string o2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ht_estado"));
            string cadenaSinEspacios = o2.Replace(" ", "");
            CheckBox chk = e.Row.FindControl("chk_select") as CheckBox;
            if (o == "P")
            {
                CheckBox checkBox = (CheckBox)e.Row.FindControl("chk_select");
                checkBox.Checked = false;
            }
            else {
                if (o == "S") {
                    CheckBox checkBox = (CheckBox)e.Row.FindControl("chk_select");
                    checkBox.Checked = true;
                }
            }
            materia = new cls_materia();
            if (materia.btnValidar(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString())) == "DIRECTOR DE CARRERA")
            {

                if (cadenaSinEspacios == "P" && o == "S")
                {
                    e.Row.Enabled = false;
                }
                if (cadenaSinEspacios == "D") {
                    e.Row.Enabled = true;
                }

            }
            else {
                if (materia.btnValidar(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString())) == "DIRECTOR ACADÉMICO") {
                    if (cadenaSinEspacios == "P")
                    {
                        e.Row.Enabled = true;
                    }
                }
            }
            


            //bool value = Convert.ToBoolean(DataBinder.Eval(e.Row.DataItem, "as_validacion"));

            // Obtener la referencia al CheckBox en la fila actual
            //CheckBox checkBox = (CheckBox)e.Row.FindControl("chk_select");

            // Establecer el estado del CheckBox según el valor de la base de datos
            //checkBox.Checked = value;
        }

        /*if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string o2 = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ht_estado"));
            string p = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ht_estado"));
            string s = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ht_estado"));
            if (o2 == p)
            {
                CheckBox checkBox = (CheckBox)e.Row.FindControl("chk_select");
                //checkBox.Enabled = false;
            }
            SetScript("", "");
        }*/

        if (lblAtrasos != null)
        {
            txtAtrasos.Text = lblAtrasos.Text;
            if (lblAtrasos.Text != "0")
            {
                e.Row.Visible = false;
            }
            else
            {
                e.Row.Visible = true;
            }
        }

        if (lblFaltas != null)
        {
            txtFaltas.Text = lblFaltas.Text;
            if (lblFaltas.Text != "0")
            {
                e.Row.Visible = false;
            }
            else
            {
                e.Row.Visible = true;
            }
        }

        if (lblHoras != null)
        {
            txtHoras.Text = lblHoras.Text;
            if (noRegistrados == true && lblHoras.Text != "0")
            {
                e.Row.Visible = false;
            }
            else
                e.Row.Visible = true;

            
            SetScript("", "");

        }

        
    }
    protected void lnkAsignacion1_Click(object sender, EventArgs e)
    { }
    protected void ddlUnidades_SelectedIndexChanged(object sender, EventArgs e)
    {
        string a = ddlUnidades1.SelectedValue;
        ltl_only_name.Text = a;
        f_h.Value = a;
        Filtrar();
        if (f_h.Value == "MOSTRAR TODOS")
        {
            guardarTH(0);
        }
        else
        {
            guardarTH(Convert.ToInt32(f_h.Value));
        }
        
        SetScript(sc, "");
    }

    protected void BtnValidar_Click(object sender, EventArgs e)
    {
        materia = new cls_materia();
        string a = f_h.Value;
        materia.CambiarEstadoHT(Convert.ToInt32(f_h.Value));
        gv_horas_docentes.DataSource = materia.DOCENTES_ListarGrillaDocentesMesPorUnidad(Convert.ToInt32(f_h.Value));
        gv_horas_docentes.DataBind();
        SetScript(sc, "");
        Response.Redirect("../Docentes/FaltasAtrasos.aspx");
    }
    protected void btnDevalidar_Click(object sender, EventArgs e)
    {
        materia = new cls_materia();
        string a = f_h.Value;
        materia.CambiarEstadoHT2(Convert.ToInt32(f_h.Value));
        gv_horas_docentes.DataSource = materia.DOCENTES_ListarGrillaDocentesMesPorUnidad(Convert.ToInt32(f_h.Value));
        gv_horas_docentes.DataBind();
        SetScript("", "");
        Response.Redirect("../Docentes/FaltasAtrasos.aspx");
    }
    protected void btnAprobar_Click(object sender, EventArgs e)
    {
        materia = new cls_materia();
        string a = f_h.Value;
        materia.CambiarEstadoHT3(Convert.ToInt32(f_h.Value));
        gv_horas_docentes.DataSource = materia.DOCENTES_ListarGrillaDocentesMesPorUnidad(Convert.ToInt32(f_h.Value));
        gv_horas_docentes.DataBind();
        SetScript("", "");
        Response.Redirect("../Docentes/FaltasAtrasos.aspx");
    }

    private void guardarTH(int a)
    {
        f_h.Value = a.ToString();
    }

        private void Filtrar()
        {
        cls_materia materia = new cls_materia();
        int eo_id = 0;
        if (ddlUnidades1.Text != "MOSTRAR TODOS")
        {
            eo_id = Convert.ToInt32(ddlUnidades1.SelectedValue);
            gv_horas_docentes.DataSource = materia.DOCENTES_ListarGrillaDocentesMesPorUnidad(eo_id);
            gv_horas_docentes.DataBind();
            SetScript("", "");

        }
        else
        {
            gv_horas_docentes.DataSource = materia.DOCENTES_ListarGrillaDocentesMesPorUnidad(eo_id);
            gv_horas_docentes.DataBind();
            SetScript("", "");

        }
        SetScript("", "");
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
        sb.Append("$('100').on('input', function (event) {" +
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


}