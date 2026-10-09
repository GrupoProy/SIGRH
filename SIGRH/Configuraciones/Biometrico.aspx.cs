using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ControlPersonal_Biometrico : System.Web.UI.Page
{
    private cls_cp_dispositivo dispo = new cls_cp_dispositivo();
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Session["di_id"] = null;
            cargarGrid();
            cargarEdificios();
        }
    }

    private void cargarEdificios()
    {
        ddl_edificio.Items.Clear();
        ddl_edificio.DataSource = dispo.MostrarEdificios();
        ddl_edificio.DataTextField = "cat_descripcion";
        ddl_edificio.DataValueField = "cat_secuencial";
        ddl_edificio.DataBind();
    }

    private void cargarGrid()
    {
        gv_dispositivos.DataSource = dispo.ListarDispositivos();
        gv_dispositivos.DataBind();
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        Session["di_id"] = null;
        BtnCrear.Text = "<i class='fas fa-save'></i> Registrar";
        BtnCrear.CssClass = "btn btn-success";
        result.Visible = true;
        adicionar.Visible = false;
        SetScript("", "");
    }

    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        Session["di_id"] = null;
        BtnCrear.Text = "<i class='fas fa-save'></i> Registrar";
        BtnCrear.CssClass = "btn btn-success";
        adicionar.Visible = true;
        result.Visible = false;
        SetScript("", "");
    }

    protected void gv_dispositivos_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_dispositivos.Rows.Count > 0)
        {
            if (gv_dispositivos.HeaderRow != null)
            {
                gv_dispositivos.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_dispositivos.FooterRow != null)
            {
                gv_dispositivos.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void BtnCrear_Click(object sender, EventArgs e)
    {
        if (Session["di_id"] == null)
        {
            int x = dispo.AdicionarDispositivo(txt_descri.Text, txt_ip.Text, Convert.ToInt32(ddl_edificio.SelectedValue));
            if (x > 0)
            {
                cargarGrid();
                sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Dispositivo registrado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            }
            else
            {
                sc = "Swal.fire({ icon: 'warning', title: 'No Registrado', text: 'El dispositivo no se pudo agregar', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            }
        }
        else
        {
            int edit = dispo.EditarDispositivo(txt_descri.Text, Convert.ToInt32(ddl_edificio.SelectedValue), txt_ip.Text, Convert.ToInt32(Session["di_id"]));
            if (edit > 0)
            {
                cargarGrid();
                sc = "Swal.fire({ icon: 'success', title: 'Editado correcto', text: 'Dispositivo editado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            }
            else
            {
                sc = "Swal.fire({ icon: 'warning', title: 'No editado', text: 'El dispositivo no se pudo editar', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            }
        }
        Limpiar();
        Session["di_id"] = null;
        BtnCrear.Text = "<i class='fas fa-save'></i> Registrar";
        BtnCrear.CssClass = "btn btn-success";
        adicionar.Visible = false;
        result.Visible = true;
        SetScript(sc, "");
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

    protected void gv_dispositivos_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index;
        string di_id;
        int elimi;
        if (e.CommandName == "Eliminar")
        {
            index = Convert.ToInt32(e.CommandArgument);
            di_id = gv_dispositivos.DataKeys[index].Values[0].ToString();
            elimi = dispo.EliminarDispositivo(Convert.ToInt32(di_id));
            if (elimi > 0)
            {
                sc = "Swal.fire({ icon: 'success', title: 'Dispositivo eliminado', text: 'Dispositivo eliminado correctamente', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            }
            else
            {
                sc = "Swal.fire({ icon: 'warning', title: 'No eliminado', text: 'El dispositivo no se pudo eliminar', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => {  }});";
            }
            cargarGrid();
        }

        if (e.CommandName == "Editar")
        {
            index = Convert.ToInt32(e.CommandArgument);
            Session["di_id"] = gv_dispositivos.DataKeys[index].Values[0].ToString();
            BtnCrear.Text = "<i class='fas fa-save'></i> Editar";
            BtnCrear.CssClass = "btn btn-facebook";
            adicionar.Visible = true;
            result.Visible = false;
        }
        SetScript(sc, "");
    }

    private void Limpiar()
    {
        txt_descri.Text = "";
        txt_ip.Text = "";
    }

    protected void ddl_edificio_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScript("", "");
    }
}