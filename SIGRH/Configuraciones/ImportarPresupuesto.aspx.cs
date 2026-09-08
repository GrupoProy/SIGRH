using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Globalization;

public partial class Configuraciones_ImportarPresupuesto : System.Web.UI.Page
{
    private cls_mp_categoria_programatica cat_prog = null;
    private cls_mp_presupuesto presupuesto = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //decimal decimalVal;
        //string stringVal = "1905500.13";
        //string aux = String.Format("{0:0.00}", stringVal);
        //decimal value = decimal.Parse(aux, CultureInfo.InvariantCulture);
        //Console.WriteLine("String converted to decimal = {0} ", value);
    }

    protected void btn_importar_grilla_Click(object sender, EventArgs e)
    {
        string str = hf_data.Value;
        gv_presup.DataSource = JsonConvert.DeserializeObject<DataTable>(str);
        gv_presup.DataBind();
        //SetScript("");
        int count = 0;

        DataTable lista_respuesta = new DataTable();
        lista_respuesta.Columns.Add("DA");
        lista_respuesta.Columns.Add("UE");
        lista_respuesta.Columns.Add("PROGRAMA");
        lista_respuesta.Columns.Add("PROYECTO");
        lista_respuesta.Columns.Add("ACTIVIDAD");
        lista_respuesta.Columns.Add("DESC_CAT_PRG");
        lista_respuesta.Columns.Add("FUENTE");
        lista_respuesta.Columns.Add("ORGANISMO");
        lista_respuesta.Columns.Add("PARTIDA");
        lista_respuesta.Columns.Add("ET");
        lista_respuesta.Columns.Add("MONTO");
        lista_respuesta.Columns.Add("SALDO");
        DataRow dr = null;


        for (int i = 0; i < gv_presup.Rows.Count; i++)
        {
            string da = gv_presup.Rows[i].Cells[0].Text.Trim();
            string ue = gv_presup.Rows[i].Cells[1].Text.Trim();
            string programa = gv_presup.Rows[i].Cells[2].Text.Trim();
            string proyecto = gv_presup.Rows[i].Cells[3].Text.Trim();
            string actividad = gv_presup.Rows[i].Cells[4].Text.Trim();
            string fuente = gv_presup.Rows[i].Cells[6].Text.Trim();
            string organismo = gv_presup.Rows[i].Cells[7].Text.Trim();

            string desc = gv_presup.Rows[i].Cells[5].Text.Trim();
            string partida = gv_presup.Rows[i].Cells[8].Text.Trim();
            string et = gv_presup.Rows[i].Cells[9].Text.Trim();
            string monto = gv_presup.Rows[i].Cells[10].Text.Trim();
            string saldo = gv_presup.Rows[i].Cells[11].Text.Trim();

            int cp_id = buscarCP(da, ue, programa, proyecto, actividad, fuente, organismo);
            if (cp_id != 0)
            {
                //count++;
                adicionarPresupuesto(cp_id, partida, et, monto, saldo);

            } else
            {
                dr = lista_respuesta.NewRow();
                dr["DA"] = da;
                dr["UE"] = ue;
                dr["PROGRAMA"] = programa;
                dr["PROYECTO"] = proyecto;
                dr["ACTIVIDAD"] = actividad;
                dr["DESC_CAT_PRG"] = desc;
                dr["FUENTE"] = fuente;
                dr["ORGANISMO"] = organismo;
                dr["PARTIDA"] = partida;
                dr["ET"] = et;
                dr["MONTO"] = monto;
                dr["SALDO"] = saldo;
                lista_respuesta.Rows.Add(dr);
            }
            //else
            //{
            //    string aux = "";
            //}
        }
        //string aux1 = "";
        listarPresupuesto(lista_respuesta);
        sc = "Swal.fire({ icon: 'success', title: 'Importación exitosa', text: 'Registro exitoso', timer: 2200, showConfirmButton: false, allowOutsideClick: false, onAfterClose: () => { $('#eliminarPrecontrato').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); }});";
        SetScript(sc);
    }
    private int buscarCP(string cp_da = "", string cp_ue = "", string cp_programa = "", string cp_proyecto = "", string cp_actividad = "", string cp_fuente = "", string cp_organismo = "")
    {
        int cp_id = 0;

        int cp_da_out = 0;
        int cp_ue_out = 0;
        int cp_programa_out = 0;
        int cp_proyecto_out = 0;
        int cp_actividad_out = 0;
        int cp_fuente_out = 0;
        int cp_organismo_out = 0;

        //bool test = (int.TryParse(cp_da, out cp_da_out) && int.TryParse(cp_ue, out cp_ue_out) && int.TryParse(cp_programa, out cp_programa_out) && int.TryParse(cp_proyecto, out cp_proyecto_out) && int.TryParse(cp_actividad, out cp_actividad_out) && int.TryParse(cp_fuente, out cp_fuente_out) && int.TryParse(cp_organismo, out cp_organismo_out));

        if (int.TryParse(cp_da, out cp_da_out) && int.TryParse(cp_ue, out cp_ue_out) && int.TryParse(cp_programa, out cp_programa_out) && int.TryParse(cp_proyecto, out cp_proyecto_out) && int.TryParse(cp_actividad, out cp_actividad_out) && int.TryParse(cp_fuente, out cp_fuente_out) && int.TryParse(cp_organismo, out cp_organismo_out))
        {
            cat_prog = new cls_mp_categoria_programatica();
            cat_prog.cp_da = Convert.ToInt32(cp_da);
            cat_prog.cp_ue = Convert.ToInt32(cp_ue);
            cat_prog.cp_programa = Convert.ToInt32(cp_programa);
            cat_prog.cp_proyecto = cp_proyecto;
            cat_prog.cp_actividad = Convert.ToInt32(cp_actividad);
            cat_prog.cp_fuente = Convert.ToInt32(cp_fuente);
            cat_prog.cp_organismo = Convert.ToInt32(cp_organismo);
            cat_prog.cp_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            var detalle_cat_prog = cat_prog.ObtenerRegistro();
            if (detalle_cat_prog.Tables.Count > 0)
            {
                if (detalle_cat_prog.Tables[0].Rows.Count > 0)
                {
                    var cat_prog_x = detalle_cat_prog.Tables[0].Rows[0];
                    cp_id = Convert.ToInt32(validarCampo(cat_prog_x["cp_id"]));
                }
            }

        }

        return cp_id;
    }

    private void adicionarPresupuesto(int cp_id = 0, string partida = "", string et = "", string monto = "", string saldo = "") 
    {
        int partida_out = 0;
        int et_out = 0;

        double p_monto, p_saldo;
        string aux = String.Format("{0:0.00}", monto);
        string aux1 = String.Format("{0:0.00}", saldo);

        p_monto = double.Parse(aux, CultureInfo.InvariantCulture);
        p_saldo = double.Parse(aux1, CultureInfo.InvariantCulture);

        if (int.TryParse(partida, out partida_out) && int.TryParse(et, out et_out))
        {
            presupuesto = new cls_mp_presupuesto();
            presupuesto.pp_cp_id = cp_id;
            presupuesto.pp_partida = Convert.ToInt32(partida);
            presupuesto.pp_entidad_trans = Convert.ToInt32(et);
            presupuesto.pp_monto = p_monto;
            presupuesto.pp_saldo = p_saldo;
            presupuesto.Adicionar();
        }

    }
    private void listarPresupuesto(DataTable errorPresupuesto = null)
    {
        try
        {
            //presupuesto = new cls_mp_presupuesto();
            //presupuesto.cp_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
            //gv_presupuesto.DataSource = presupuesto.ObtenerTablaGrilla();
            gv_presupuesto.DataSource = errorPresupuesto;
            gv_presupuesto.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    protected void gv_presup_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_presup.Rows.Count > 0)
        {
            if (gv_presup.HeaderRow != null)
            {
                gv_presup.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_presup.FooterRow != null)
            {
                gv_presup.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_presup_RowCommand(object sender, GridViewCommandEventArgs e)
    {

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
    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        string l = " {" +
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
            "},";

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
          "'language': " + l +
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 100, 'paging': true, 'info': true, 'stateSave': true, 'stateDuration': 60 * 10 }); }");

        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void gv_presupuesto_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_presupuesto.Rows.Count > 0)
        {
            if (gv_presupuesto.HeaderRow != null)
            {
                gv_presupuesto.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_presupuesto.FooterRow != null)
            {
                gv_presupuesto.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }
}