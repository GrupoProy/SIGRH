using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Seguridad.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Seguridad_UsuarioAlta : System.Web.UI.Page
{
    //private cls_persona _persona = null;
    private cls_seg_usuario _usuario = null;
    private cls_mp_asignacion _asignacion = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                BindForm(id);
                sc = "CopiarCortarPegar(true);";
                SetScript(sc);
            }
        }
        else Response.Redirect("../Index");
    }

    // Cargar Datos
    private void BindForm(string per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var data = _asignacion.ObtenerTablaGrillaC("", per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

        if (data.Rows.Count > 0)
        {
            Lt_per_nombres.Text = ValidarCampo(data.Rows[0]["per_nombres"]) + " " + ValidarCampo(data.Rows[0]["per_ap_paterno"]) + " " + ValidarCampo(data.Rows[0]["per_ap_materno"]);
            Lt_per_num_doc.Text = ValidarCampo(data.Rows[0]["per_num_doc"]) + " " + ValidarCampo(data.Rows[0]["cat_abreviacion"]);
            Lt_per_id.Text = ValidarCampo(data.Rows[0]["per_id"]);
            Lt_ca_num_item.Text = ValidarCampo(data.Rows[0]["ca_ti_item"]) + " - " + ValidarCampo(data.Rows[0]["ca_num_item"]);
            Lt_ca_basico_calculado.Text = (ValidarCampo(data.Rows[0]["ca_basico_calculado"]).Equals("")) ? "" : Convert.ToDouble(ValidarCampo(data.Rows[0]["ca_basico_calculado"])).ToString("N");
            Lt_es_escalafon.Text = ValidarCampo(data.Rows[0]["es_escalafon"]);
            Lt_ns_clase.Text = ValidarCampo(data.Rows[0]["ns_clase"]);
            Lt_ns_nivel.Text = ValidarCampo(data.Rows[0]["ns_nivel"]);
            Lt_as_fecha_inicio.Text = (ValidarCampo(data.Rows[0]["as_fecha_inicio"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(data.Rows[0]["as_fecha_inicio"])).ToString("dd/MM/yyyy");
            Lt_as_fecha_fin.Text = (ValidarCampo(data.Rows[0]["as_fecha_fin"]).Equals("")) ? "" : Convert.ToDateTime(ValidarCampo(data.Rows[0]["as_fecha_fin"])).ToString("dd/MM/yyyy");
            Lt_es_descripcion.Text = ValidarCampo(data.Rows[0]["es_descripcion"]);
            Lt_eo_descripcion.Text = ValidarCampo(data.Rows[0]["eo_descripcion"]);
            Lt_eo_prog.Text = ValidarCampo(data.Rows[0]["eo_prog"]) + " - " + ValidarCampo(data.Rows[0]["eo_sprog"]) + " - " + ValidarCampo(data.Rows[0]["eo_proy"]) + " - " + ValidarCampo(data.Rows[0]["eo_obract"]) + " - " + ValidarCampo(data.Rows[0]["eo_unidad"]);
            Lt_cp_descripcion.Text = ValidarCampo(data.Rows[0]["cp_descripcion"]);
            Lt_cp_da.Text = ValidarCampo(data.Rows[0]["cp_da"]) + " - " + ValidarCampo(data.Rows[0]["cp_ue"]) + " - " + ValidarCampo(data.Rows[0]["cp_programa"]) + " - " + ValidarCampo(data.Rows[0]["cp_proyecto"]) + " - " + ValidarCampo(data.Rows[0]["cp_actividad"]);

            if (ValidarCampo(data.Rows[0]["as_estado"]).Equals("V"))
            {
                Lbl_as_estado.Text = "Vigente";
                Lbl_as_estado.CssClass = "btn btn-sm btn-info float-right";
            }
            else
            {
                Lbl_as_estado.Text = "Pasivo";
                Lbl_as_estado.CssClass = "btn btn-sm btn-secondary float-right";
            }

            if (ValidarCampo(data.Rows[0]["fp_foto"]) != "") Img_fp_foto.ImageUrl = "data:image/jpg;base64," + Convert.ToBase64String((byte[])data.Rows[0]["fp_foto"]);
            else if (ValidarCampo(data.Rows[0]["per_sexo"]).Equals("M")) Img_fp_foto.ImageUrl = "../Content/img/theme/user3.jpg";
            else Img_fp_foto.ImageUrl = "../Content/img/theme/user4.jpg";
        }
    }

    // Alta Usuario
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        _usuario = new cls_seg_usuario
        {
            us_usuario = Txt_us_usuario.Text.Trim(),
            us_contrasena = Txt_us_contrasena.Text.Trim(),
            us_per_id = Convert.ToInt32(id),
            us_correo_interno = Txt_us_correo_interno.Text.Trim(),
            us_nombre_equipo = Txt_us_nombre_equipo.Text.ToUpper().Trim(),
            us_usuario_creacion = Session["per_id"].ToString()
        };
        _usuario.Adicionar();
        //sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' });";
        //SetScript(sc);
        Session["texto_notificacion"] = "Registro añadido correctamente...!!";
        Response.Redirect("Usuarios");
    }

    // Validar Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) campo = p_campo.ToString().Trim();
        return campo;
    }

    // Ejecutar ScriptManager
    private void SetScript(string data)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
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
                        "'sNext': '<i class=\"fas fa-angle-right\"></i>'," +
                        "'sPrevious': '<i class=\"fas fa-angle-left\"></i>'" +
                    "}," +
                    "'oAria': {" +
                        "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                        "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                "}," +
                "'ordering': false," +
                "'searching': true," +
                "'autoWidth': false," +
                "'orderCellsTop': true," +
                "'fixedHeader': true" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } });");
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

    // Limpiar
    private void Limpiar(string val)
    {
        if (val.Equals("user"))
        {
            Txt_us_usuario.Text = string.Empty;
            Txt_us_contrasena.Text = string.Empty;
            Txt_us_correo_interno.Text = string.Empty;
            Txt_us_nombre_equipo.Text = string.Empty;
            Txt_us_fecha_inicio.Text = string.Empty;
            Txt_us_fecha_fin.Text = string.Empty;
            Txt_us_id_usuario_sim.Text = string.Empty;
        }
    }
}