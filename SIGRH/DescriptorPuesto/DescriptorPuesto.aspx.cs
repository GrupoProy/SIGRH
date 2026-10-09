using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_ManualPuestos.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

public partial class DescriptorPuesto_DescriptorPuesto : System.Web.UI.Page
{
    //private cls_kd_finiquito poai = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_mp_descriptor_puestos descriptor_puestos = null;


    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            var id = Convert.ToString(Session["per_id"]);


            if (!Page.IsPostBack)
            {
                int id_per = Convert.ToInt32(Session["per_id"]);
                descriptor_puestos = new cls_mp_descriptor_puestos();
                int per = descriptor_puestos.Verificar_ca_id(id_per);
                Session["per"] = per;

                int uwu = descriptor_puestos.devuelver_ca_id(id_per);

                int ne_id = descriptor_puestos.ne_id(uwu);
               
                if (ne_id <=5) 
                {
                    Btn_ir_TareasEspecificas.Visible = true;
                    Btn_ir_TareasRecurrentes.Visible = true;
                    //Btn_ir_TareasEspecificas
                }
                if (ne_id == 6)
                {
                    Btn_ir_TareasRecurrentes.Visible = true;
                }
                if (per >= 1)
                {
                    Btn_ir_TareasEspecificas.Enabled = true;
                    Btn_ir_TareasRecurrentes.Enabled = true;
                    descriptor_puestos = new cls_mp_descriptor_puestos();
                    var llenarDescripPu = descriptor_puestos.ObtenerRegistro_DescriptorPuesto(per);
                    if (llenarDescripPu.Tables[0].Rows.Count > 0)
                    {
                        var tablaDp = llenarDescripPu.Tables[0].Rows[0];
                        List_Supervisores.SelectedValue = tablaDp["superv_id"].ToString();
                        //List_Supervisores.Enabled = false;
                        Txt_descrip_pu_objetivo.Text = tablaDp["descrip_pu_objetivo"].ToString();
                        //Txt_descrip_pu_objetivo.Enabled = false;
                    }
                }
                else
                {
                    BtnGuardar_poai.Enabled = true;
                }

                h_per_id.Value = id;

                Llenar_List_Supervisores();
                // Llenar_List_Gestion();
                //Llenar_List_Caracteristicas();
                //Llenar_List_Supervisores2();
                Bind_Form(id);
            }
        }
        else Response.Redirect("../Index");
    }


    private void Llenar_List_Supervisores()
    {
        descriptor_puestos = new cls_mp_descriptor_puestos();

        List_Supervisores.Items.Clear();
        List_Supervisores.Items.Add("Seleccione...");
        List_Supervisores.DataSource = descriptor_puestos.Listar_Supervisores();
        List_Supervisores.DataValueField = "superv_id";

        List_Supervisores.DataTextField = "descripcion";
        List_Supervisores.DataBind();
    }
    protected void Btn_guardar_descrip_p_Click(object sender, EventArgs e)
    {
        var id = Convert.ToString(Session["per_id"]);
        descriptor_puestos = new cls_mp_descriptor_puestos();

        descriptor_puestos.Add_descriptor_puestos(Convert.ToInt32(id),
        Convert.ToInt32(List_Supervisores.SelectedValue),
        Txt_descrip_pu_objetivo.Text);

        int id_per = Convert.ToInt32(Session["per_id"]);
        int per = descriptor_puestos.Verificar_ca_id(id_per);

        if (per >= 1)
        {
            var llenarDescripPu = descriptor_puestos.ObtenerRegistro_DescriptorPuesto(per);
            Btn_ir_TareasEspecificas.Enabled = true;
            Btn_ir_TareasRecurrentes.Enabled = true;
            if (llenarDescripPu.Tables[0].Rows.Count > 0)
            {
                var tablaDp = llenarDescripPu.Tables[0].Rows[0];
                List_Supervisores.SelectedValue = tablaDp["superv_id"].ToString();
                //List_Supervisores.Enabled = false;
                Txt_descrip_pu_objetivo.Text = tablaDp["descrip_pu_objetivo"].ToString();
                //Txt_descrip_pu_objetivo.Enabled = false;
            }
        }
    }

    //private void Llenar_List_Caracteristicas()
    //{
    //    poai = new cls_kd_finiquito();

    //    List_CaracteristicasI.Items.Clear();
    //    List_CaracteristicasI.Items.Add("Seleccione...");
    //    List_CaracteristicasI.DataSource = poai.Listar_Caracteristicas();
    //    List_CaracteristicasI.DataValueField = "cua_tipo";
    //    List_CaracteristicasI.DataTextField = "Nom_tipo";
    //    List_CaracteristicasI.DataBind();
    //}


    /*
    private void Llenar_List_Gestion()
    {
        poai = new cls_kd_finiquito();
        DropDownList_Gestion.Items.Clear();
        DropDownList_Gestion.Items.Add("Seleccione...");
        DropDownList_Gestion.DataSource = poai.List_Gestion();
        DropDownList_Gestion.DataValueField = "pr_id";
        DropDownList_Gestion.DataTextField = "pr_gestion";
        DropDownList_Gestion.DataBind();
    }
    */

    private void Bind_Form(string per_id)
    {
        descriptor_puestos = new cls_mp_descriptor_puestos();
        var var_datos_as_c = descriptor_puestos.ObtenerTablaGrillaC__mp_asignacion(per_id).Tables[0];

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

    /*
    private void CargarItem(DataSet item)
    {
        var x = item.Tables[0];

        if (x.Rows.Count > 0)
        {
            Txt_r_nombrePuesto.Text = ValidarCampo(x.Rows[0]["p_descripcion"]);
            Txt_r_numeroPuesto.Text = ValidarCampo(x.Rows[0]["ca_ti_item"] + " - " + ValidarCampo(x.Rows[0]["ca_num_item"]));
            h_ca_id.Value = ValidarCampo(x.Rows[0]["ca_id"]);
            h_pref_text.Value = ValidarCampo(x.Rows[0]["ca_ti_item"]);
            h_nombreC_text.Value = ValidarCampo(x.Rows[0]["p_descripcion"]);
            h_numP_int.Value = ValidarCampo(x.Rows[0]["ca_num_item"]);




        }
    }
    */



    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    protected void Btn_ir_TareasEspecificas_Click(object sender, EventArgs e)
    {
        Response.Redirect("RegistrarTareasEspecificas");
    }

    protected void Btn_ir_TareasRecurrentes_Click(object sender, EventArgs e)
    {

        Response.Redirect("RegistrarTareasRecurrentes");
    }
    
    protected void Btn_imprimirEva_Click(object sender, EventArgs e)
    {
        int per = (int)Session["per"];
        string sc = "window.open('../DescriptorPuesto/ReporteDescriptorPuesto.aspx?id=" + per + "', 'width=500,height=500', '_blank');";
        SetScript(sc,"");
        // Response.Redirect("RegistrarTareasRecurrentes");
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

    /*
    
    protected void Btn_Registrar_Poai(object sender, EventArgs e)
    {
        poai = new cls_kd_finiquito();
        int id = Convert.ToInt32(h_ca_id.Value);
        int x = poai.Devolver_tipo_Poai(id);
        int tipo_poai = Convert.ToInt32(x);
        string inter = Txt_r_interinstitucional.Text;
        string intra = Txt_r_intrainstitucional.Text;
        int super_id = Convert.ToInt32(List_Supervisores.SelectedValue);
        int nro_puesto = Convert.ToInt32(h_numP_int.Value);
        string pu_nombre = Txt_r_nombrePuesto.Text;
        int ca_id = Convert.ToInt32(h_ca_id.Value);
        string pu_pref = h_pref_text.Value;
        string pu_objetivo = Txt_r_objetivoPuesto.Text;


        int id_poai = poai.Adicionar_Poai(id, tipo_poai, inter, intra, ca_id, super_id, nro_puesto, pu_nombre, pu_pref, pu_objetivo);
        h_poai_id2.Value = Convert.ToString(id_poai);
        int tpoai = poai.Devolver_tipo_Poai(Convert.ToInt32(h_per_id.Value));

        if (tpoai == 1)
        {
            //Response.Redirect("../ManualDePuestos/RegistrarTareasRecurrentes?id_poai=" + id_poai);
            Response.Redirect("../ManualDePuestos/Administrar_Identificacion?id_poai=" + id_poai);
        }
        else
        {
            if (tpoai == 2)
            {
                //Response.Redirect("../ManualDePuestos/RegistrarTareasEspecificas?id_poai=" + id_poai);
                Response.Redirect("../ManualDePuestos/Administrar_Identificacion?id_poai=" + id_poai);
            }
        }





        //int per_id, int p_tipo, string inter, string intra, int ca_id, int super_id, string nro_puesto, string pu_nombre , string pu_pref, string pu_objetivo

    }*/

    protected void Btn_next(object sender, EventArgs e)
    {

        //Response.Redirect("../ManualDePuestos/RegistrarTareasEspecificas?id_poai = " + h_opai_id.Value);

    }

    /*
    protected void DropDownList_Gestion_SelectedIndexChanged(object sender, EventArgs e)
    {
        poai = new cls_kd_finiquito();

        int gestion = Convert.ToInt32(DropDownList_Gestion.SelectedValue);
        int id = Convert.ToInt32(Session["per_id"]);


        CargarItem(poai.DevolverGestionPerId(id, gestion));


    }
    */
}