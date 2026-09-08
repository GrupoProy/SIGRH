using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;

public partial class MovimientoPersonal_DocenteAgre : System.Web.UI.Page
{
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }

    protected void cb1_CheckedChanged(object sender, EventArgs e)
    {
        cb2.Checked = false;
        cb3.Checked = false;
        cb4.Checked = false;
    }

    protected void cb2_CheckedChanged(object sender, EventArgs e)
    {
        cb1.Checked = false;
        cb3.Checked = false;
        cb4.Checked = false;
    }

    protected void cb3_CheckedChanged(object sender, EventArgs e)
    {
        cb2.Checked = false;
        cb1.Checked = false;
        cb4.Checked = false;
    }

    protected void cb4_CheckedChanged(object sender, EventArgs e)
    {
        cb2.Checked = false;
        cb3.Checked = false;
        cb1.Checked = false;
    }

    protected void BtnAsig_Click(object sender, EventArgs e)
    {
        Encuesta encu = new Encuesta();
        int nro = 0;
        int per_id = Convert.ToInt32(Session["per_id"]);
        if (cb1.Checked)
        {
            nro = 1;
            encu.EnviarEncuesta(per_id, nro, 0, 0, 0);
        }
        if (cb2.Checked)
        {
            nro = 1;
            encu.EnviarEncuesta(per_id, 0, nro, 0, 0);
        }
        if (cb3.Checked)
        {
            nro = 1;
            encu.EnviarEncuesta(per_id, 0,0,nro, 0);
        }
        if (cb4.Checked)
        {
            nro = 1;
            encu.EnviarEncuesta(per_id, 0, 0,0,nro);
        }
        sc = "Swal.fire({ icon: 'success', title: 'Registro exitoso', text: 'Respuesta registrada exitosamente', timer: 4200, showConfirmButton: false, allowOutsideClick: true, onAfterClose: () => { }});";
        SetScript(sc);
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
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'});");
        sb.Append("var me = $('.datepickerDefault'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
}