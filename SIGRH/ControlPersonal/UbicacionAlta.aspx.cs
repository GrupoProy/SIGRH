using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_Ubicacion : System.Web.UI.Page
{
    private cls_catalogo _catalogo = null;
    private cls_mp_asignacion _asignacion = null;
    private cls_cp_ubicacion_fisica _ubicacion_fisica = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                var id = Request.QueryString["id"].ToString();
                CargaDatosFuncionario(id);
                CargaDDLEdificio();
                CargaGVUbicacion(id);

                if (Gv_lt_u.Rows.Count > 0) { P_lt_u.Visible = true; }
                else { P_lt_u.Visible = false; }
            }
        }
        else { Response.Redirect("../Index"); }
    }

    // Carga Los Datos Del Funcionario
    private void CargaDatosFuncionario(string par_per_id)
    {
        _asignacion = new cls_mp_asignacion();
        var var_datos_as_c = _asignacion.ObtenerTablaGrillaC("", par_per_id, "", "", "", "", "", "", "", "", "", "", "", "").Tables[0];

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
            Lt_eo_prog.Text = ValidarCampo(var_datos_as_c.Rows[0]["eo_prog"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_sprog"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_proy"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_obract"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["eo_unidad"]);
            Lt_cp_descripcion.Text = ValidarCampo(var_datos_as_c.Rows[0]["cp_descripcion"]);
            Lt_cp_da.Text = ValidarCampo(var_datos_as_c.Rows[0]["cp_da"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_ue"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_programa"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_proyecto"]) + " - " + ValidarCampo(var_datos_as_c.Rows[0]["cp_actividad"]);

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

    // Carga Datos En El DropDownList (Ddl_uf_edificio)
    private void CargaDDLEdificio()
    {
        _catalogo = new cls_catalogo();
        Ddl_uf_edificio.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_uf_edificio.DataSource = _catalogo.ObtenerTablaGrilla("", "Edificio_Institucional", "", "", "", "", "", "", "", "V");
        Ddl_uf_edificio.DataValueField = "cat_secuencial";
        Ddl_uf_edificio.DataTextField = "cat_descripcion";
        Ddl_uf_edificio.DataBind();
    }

    // Carga Datos En El GridView (Gv_lt_u)
    private void CargaGVUbicacion(string par_per_id)
    {
        try
        {
            _ubicacion_fisica = new cls_cp_ubicacion_fisica();
            Gv_lt_u.DataSource = _ubicacion_fisica.ObtenerTablaGrillaC("", par_per_id, "", "", "", "", "", "", "", "", "");
            Gv_lt_u.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    // Diseño Del GridView (Gv_lt_u)
    protected void Gv_lt_u_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (Gv_lt_u.Rows.Count > 0)
        {
            if (Gv_lt_u.HeaderRow != null) { Gv_lt_u.HeaderRow.TableSection = TableRowSection.TableHeader; }
            if (Gv_lt_u.FooterRow != null) { Gv_lt_u.FooterRow.TableSection = TableRowSection.TableFooter; }
        }
    }

    // Alta De Los Datos De Ubicación (Parcial)
    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString["id"].ToString();
        int? var_tel_ofi = null; int? var_tel_int = null;
        _ubicacion_fisica = new cls_cp_ubicacion_fisica();
        var var_dt_u = _ubicacion_fisica.ObtenerTablaGrilla("", id, "", "", "", "", "", "", "", "", "V").Tables[0];

        if (var_dt_u.Rows.Count > 0)
        {
            _ubicacion_fisica = new cls_cp_ubicacion_fisica
            {
                uf_id = Convert.ToInt32(var_dt_u.Rows[0]["uf_id"]),
                uf_fecha_inicio = Convert.ToDateTime(Txt_uf_fecha_inicio.Text.Trim())
            };
            _ubicacion_fisica.Eliminar();
        }
        _ubicacion_fisica = new cls_cp_ubicacion_fisica
        {
            uf_per_id = Convert.ToInt32(id),
            uf_edificio = Convert.ToInt32(Ddl_uf_edificio.SelectedValue),
            uf_bloque = Txt_uf_bloque.Text.ToUpper().Trim(),
            uf_piso = Txt_uf_piso.Text.ToUpper().Trim(),
            uf_telefono_oficina = (string.IsNullOrEmpty(Txt_uf_telefono_oficina.Text)) ? var_tel_ofi : Convert.ToInt32(Txt_uf_telefono_oficina.Text.Trim()),
            uf_telefono_interno = (string.IsNullOrEmpty(Txt_uf_telefono_interno.Text)) ? var_tel_int : Convert.ToInt32(Txt_uf_telefono_interno.Text.Trim()),
            uf_nombre_oficina = Txt_uf_nombre_oficina.Text.ToUpper().Trim(),
            uf_fecha_inicio = Convert.ToDateTime(Txt_uf_fecha_inicio.Text.Trim())
        };
        _ubicacion_fisica.Adicionar();
        CargaGVUbicacion(id);

        if (Gv_lt_u.Rows.Count > 0) { P_lt_u.Visible = true; }
        else { P_lt_u.Visible = false; }
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro añadido correctamente...!!' }, { type: 'success' });";
        Limpiar("frm_u_cl");
        SetScript(sc, "");
    }

    // Valida Los Campos
    private string ValidarCampo(object p_campo)
    {
        string campo = "";

        if (!string.IsNullOrEmpty(p_campo.ToString())) { campo = p_campo.ToString().Trim(); }
        return campo;
    }

    // Ejecuta Scripts
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
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
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

    // Limpia Los Campos De Los Formularios
    private void Limpiar(string val)
    {
        if (val.Equals("frm_u_cl"))
        {
            Ddl_uf_edificio.SelectedValue = "0";
            Txt_uf_bloque.Text = string.Empty;
            Txt_uf_piso.Text = string.Empty;
            Txt_uf_telefono_oficina.Text = string.Empty;
            Txt_uf_telefono_interno.Text = string.Empty;
            Txt_uf_nombre_oficina.Text = string.Empty;
            Txt_uf_fecha_inicio.Text = string.Empty;
        }
    }
}