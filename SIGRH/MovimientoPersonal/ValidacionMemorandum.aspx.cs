using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class MovimientoPersonal_ValidacionMemorandum : System.Web.UI.Page
{
    private cls_mp_seguimiento_memorandum seg_memo = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null)
        {
            if (HttpContext.Current.Session["per_id"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {

                }
            }
            else
            {
                Response.Redirect("../index");
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }

    protected void btn_validar_Click(object sender, EventArgs e)
    {
        seg_memo = new cls_mp_seguimiento_memorandum();
        string id_qr = validarTexto(txt_qr.Text);
        seg_memo.mh_qr = id_qr;
        var tf = seg_memo.ObtenerTenorFuncionario();

        if (tf.Tables[0].Rows.Count > 0)
        {
            //Adicionando Seguimiento de Memorandum
            var tenorFuncionario = tf.Tables[0].Rows[0];
            txt_funcionario.Text = tenorFuncionario["nombreFun"].ToString();
            txt_tenor_asignado.Text = tenorFuncionario["tenor"].ToString();

            seg_memo.sm_qr = id_qr;
            seg_memo.sm_validado_por = 5;
            seg_memo.sm_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString());
            var sm = seg_memo.ObtenerSeguimientoMemorandum();

            int nroReg = sm.Tables[0].Rows.Count;
            if (sm.Tables[0].Rows.Count == 0)
            {
                seg_memo.AdicionarSeguimientoMemorandum();
                sc = "$.notify({ icon: 'fa fa-check', message: 'Memorándum validado correctamente'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); ";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-check', message: 'Memorándum validado anteriormente'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }

            //Grilla Seguimiento de Memorandum
            listarSeguimientoMemorandum();
            sc = "$('#ContentPlaceHolder1_gv_seguimiento_filter').css({ display: 'none' });";
            SetScriptSingle(sc);
        } else
        {
            sc = "$.notify({ icon: 'fa fa-check', message: 'No existe memorándums con el código insertado'},{type: 'info', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
    }
    private void listarSeguimientoMemorandum()
    {
        try
        {
            seg_memo = new cls_mp_seguimiento_memorandum();
            seg_memo.sm_qr = txt_qr.Text;

            gv_seguimiento.DataSource = seg_memo.ObtenerGrillaSM();
            gv_seguimiento.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_seguimiento_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_seguimiento.Rows.Count > 0)
        {
            if (gv_seguimiento.HeaderRow != null)
            {
                gv_seguimiento.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_seguimiento.FooterRow != null)
            {
                gv_seguimiento.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

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
                    "'sNext': '<i class=" + '"' + "fas fa-angle-right" + '"' + "></i>'," +
                    "'sPrevious': '<i class=" + '"' + "fas fa-angle-left" + '"' + "></i>'" +
                    "}," +
                    "'oAria': {" +
                    "'sSortAscending': ': Activar para ordenar la columna de manera ascendente'," +
                    "'sSortDescending': ': Activar para ordenar la columna de manera descendente'" +
                    "}" +
                    "}," +
                    "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true });");

        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
    private void SetScriptSingle(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected string validarTexto (string qr = "")
    {
        string pValor = qr.Replace("'", "-");
        return pValor;
    }
}