using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Docentes_AsignacionMateria : System.Web.UI.Page
{
    //sc = "$.notify({ icon: 'fas fa-check', message: 'Registrado correctamente...' }, { type: 'success' });";
    //sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Edificio asignado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
    
    private cls_materia materia = null;
    private cls_mp_cargo cargo = null;
    private int asig = 0;
    private string sc = "";
    private cls_mp_asignacion asignacion = new cls_mp_asignacion();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                cargarEscalafon();
                string code = Request.QueryString["id"].ToString();
                hf_per_id.Value = Request.QueryString["id"].ToString();
                CargarCargoDocente();
                ddl_escalafon.SelectedValue = materia.ObtenerEscalafon(Convert.ToInt32(code)).ToString();
                if (ddl_area.Items.Count < 2)
                {
                    CargarAreas();
                }
                BindFormEdit(code);
            }
        }
        else Response.Redirect("../Index");
    }

    private void cargarEscalafon()
    {
        ddl_escalafon.DataSource = asignacion.ObtenerEscalafonDocente();
        ddl_escalafon.DataTextField = "categoria";
        ddl_escalafon.DataValueField = "ed_id";
        ddl_escalafon.DataBind();
    }

    private void BindFormEdit(string code)
    {
        materia = new cls_materia();
        int as_id = materia.ObtenerTablaGrilla__Doc(code);
        informacionFuncionario(Convert.ToInt32(code), as_id, HttpContext.Current.Session["pr_id"].ToString());
    }

    private void informacionFuncionario(int codFun = 0, int as_id = 0, string pr_id = "")
    {
        cargo = new cls_mp_cargo();
        cargo.as_per_id = codFun;
        cargo.as_id_actual = as_id;
        var detalleFuncionario = cargo.ObtenerDatosDetalleFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                string haberBasico = validarCampo(funcionario["haber_basico"]);
                decimal haberBasico2 = Convert.ToDecimal(haberBasico);
                haberBasico2 = Math.Round(haberBasico2, 2);
                ltl_haber_basico.Text = Convert.ToString(haberBasico2);

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

                if (validarCampo(funcionario["fp_foto"]) != null && validarCampo(funcionario["fp_foto"]) != "")
                {
                    imgFun.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])detalleFuncionario.Tables[0].Rows[0]["fp_foto"]);
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
                //cls_mp_cargo cargo = new cls_mp_cargo();
                //cargo.eo_id = Convert.ToInt32(detalleFuncionario.Tables[0].Rows[0]["as_ca_id"].ToString());
                //cargo.gestion_selec = pr_id;
                //string ti_tipo = cargo.ObtenerDetalleitem().Tables[0].Rows[0]["ti_tipo"].ToString();
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

    private void CargarAreas()
    {
        materia = new cls_materia();
        ddl_area.Items.Clear();
        ddl_area.Items.Add("Seleccione un area...");
        ddl_area.DataSource = materia.ObtenerArea();
        ddl_area.DataTextField = "plan_area";
        ddl_area.DataBind();
    }

    private void CargarCarreras()
    {
        materia = new cls_materia();
        ddl_carrera.Items.Clear();
        ddl_carrera.Items.Add("Seleccione una carrera...");
        materia.area = ddl_area.SelectedItem.Text;
        ddl_carrera.DataSource = materia.ObtenerCarrera();
        ddl_carrera.DataTextField = "plan_carrera_nombre";
        ddl_carrera.DataBind();
    }

    private void CargarPlanes()
    {
        materia = new cls_materia();
        ddl_plan.Items.Clear();
        materia.area = ddl_area.SelectedItem.Text;
        materia.carrera = ddl_carrera.SelectedItem.Text;
        ddl_plan.Items.Add("Seleccione un plan...");
        ddl_plan.DataSource = materia.C_ObtenerPlan();
        ddl_plan.DataValueField = "plan_id";
        ddl_plan.DataTextField = "plan_gestion";
        ddl_plan.DataBind();
    }

    protected void ddl_area_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarCarreras();
        SetScript("","");
    }

    protected void ddl_carrera_SelectedIndexChanged(object sender, EventArgs e)
    {
        CargarPlanes();
        if (rdTitu.Checked)
        {
            asig = 0;
        }
        else
        {
            asig = 1;
        }
        CargarAsig();
        SetScript("", "");
    }

    protected void ddl_plan_SelectedIndexChanged(object sender, EventArgs e)
    {
        materia = new cls_materia();
        materia.p_id = Convert.ToInt32(ddl_plan.SelectedValue);
        materia.gestion = Convert.ToInt32(Session["pr_id"]);
        ddl_materia.Items.Clear();
        ddl_materia.DataSource = materia.BuscarMateria2();
        ddl_materia.DataValueField = "mat_id";
        ddl_materia.DataTextField = "mat_nombre";
        ddl_materia.DataBind();
        SetScript("", "");
    }

    protected void BtnAsig_Click(object sender, EventArgs e)
    {
        materia = new cls_materia();
        if (rdInvi.Checked)
        {
            materia.tipo_ing = "B";
        }
        else
        {
            if (rdConcu.Checked)
            {
                materia.tipo_ing = "C";
            }
        }
        if (rdEvent.Checked)
        {
            materia.tipo_doc = "E1";
        }
        else
        {
            if (rdTitu.Checked)
            {
                materia.tipo_doc = "E";
            }
        }
        if (rdMedio.Checked)
        {
            materia.jornada = "TH";
        }
        else
        {
            if (rdCompleto.Checked)
            {
                materia.jornada = "TC";
            }
        }
        if (ddl_docente.SelectedItem.Text.Equals("+ Nuevo Cargo"))
        {
            materia.ca_doc = 0;
        }
        else
        {
            materia.ca_doc = Convert.ToInt32(ddl_docente.SelectedValue);
        }
        materia.eo_id = Convert.ToInt32(ddl_eo.SelectedValue);
        materia.us_id = Convert.ToInt32(Session["per_id"]);
        
        materia.fecha_ini = Convert.ToDateTime(txt_fecha_inicio.Text);
        if (txt_fecha_fin.Text == "")
        {
            materia.fecha_fin = "";
        }
        else
        {
            materia.fecha_fin = txt_fecha_fin.Text;
        }
        
        materia.mat_per_id = Convert.ToInt32(ltl_cod_fun.Text);

        materia.mat_id = Convert.ToInt32(ddl_materia.SelectedValue);
        materia.hrs_asig = Convert.ToInt32(Txt_horas.Text);
        materia.aed_ed_id = Convert.ToInt32(ddl_escalafon.SelectedValue);
        string mensaje = materia.AdicionarAsignacion__();
        if (mensaje == "1194")
        {
            mensaje = "ASIGNACION EXITOSA";
        }
        Session["texto_notificacion"] = mensaje;
        Response.Redirect("AsignacionDocente.aspx");
        //sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Materia asignada exitosamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";

    }

    public void Limpiar()
    {
        ddl_carrera.Items.Clear();
        ddl_eo.Items.Clear();
        ddl_materia.Items.Clear();
        ddl_plan.Items.Clear();
    }

    private void CargarAsig()
    {
        materia = new cls_materia();
        ddl_eo.Items.Clear();
        ddl_eo.DataSource = materia.GetEstructura(asig, ddl_carrera.SelectedItem.Text);
        ddl_eo.DataTextField = "UNIDAD";
        ddl_eo.DataValueField = "eo_id";
        ddl_eo.DataBind();
    }

    protected void ddl_materia_SelectedIndexChanged(object sender, EventArgs e)
    {
        materia = new cls_materia();
        Txt_horas.Text = materia.horas_(Convert.ToInt32(ddl_materia.SelectedValue)).ToString();
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

    protected void rdTitu_CheckedChanged(object sender, EventArgs e)
    {
        if (rdTitu.Checked)
        {
            asig = 0;
        }
        else
        {
            if (rdEvent.Checked) asig = 1;
        }
        CargarAsig();
        SetScript("", "");
    }

    protected void rdEvent_CheckedChanged(object sender, EventArgs e)
    {
        if (rdEvent.Checked)
        {
            asig = 1;
        }
        else
        {
            if (rdTitu.Checked) asig = 0;
        }
        CargarAsig();
        SetScript("", "");
    }

    private void CargarCargoDocente()
    {
        materia = new cls_materia();
        materia.mat_per_id = Convert.ToInt32(hf_per_id.Value);
        ddl_docente.Items.Clear();
        ddl_docente.Items.Add("+ Nuevo Cargo");
        ddl_docente.DataSource = materia.ListarCargosDocente();
        ddl_docente.DataTextField = "Cargo_Titular";
        ddl_docente.DataValueField = "ca_id";
        ddl_docente.DataBind();
    }
}