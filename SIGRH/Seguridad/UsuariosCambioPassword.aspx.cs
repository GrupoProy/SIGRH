using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using Solution_Framework_Seguridad.BussinessLogicLayer;
public partial class Seguridad_UsuariosCambioPassword : System.Web.UI.Page
{
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                ChangePassword1.ChangePasswordTitleText = "Cambio de Contraseña";
            }
        }
        else Response.Redirect("../Index");
    }

    protected void ChangePassword1_ChangingPassword(object sender, LoginCancelEventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")

            if (!ChangePassword1.CurrentPassword.Equals(ChangePassword1.NewPassword, StringComparison.CurrentCultureIgnoreCase))
        {
            int rowsAffected = 0;
            cls_seg_usuario usuario = new cls_seg_usuario();
            usuario.us_usuario = HttpContext.Current.Session["usuario"].ToString();
            usuario.us_contrasena = ChangePassword1.NewPassword;
            usuario.us_per_id = Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString());
            rowsAffected = usuario.ActualizarPass();
                //lblMessage.ForeColor = Color.Green;
                //lblMessage.Text = "Se actualizó satisfactoriamente su contraseña";

                //Response.Redirect("../Index");
                sc = "Swal.fire({ icon: 'success', title: 'Se actualizó correctamente su contraseña...', text: 'Contraseña', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { window.open('../index.aspx', '_self'); }});";
            }
            else
        {
                lblMessage.ForeColor = Color.Red;
                lblMessage.Text = "La nueva contraseña no debe ser igual a la anterior";
                sc = "$.notify({ icon: 'fas fa-warning', message: 'La nueva contraseña no debe ser igual a la anterior...!!' }, { type: 'warning' });";

            }
        SetScript(sc, "");
        e.Cancel = true;
    }
    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
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
        sb.Append("$(function () {" +
                "var me = $(\".timepickerD\");" +
                "me.mask(\"99:99\");" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

}