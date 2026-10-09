using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using Solution_Framework_Precontratacion.BussinessLogicLayer;
public partial class Precontratacion_ListaFrecuenciaValidacion : System.Web.UI.Page
{
    private cls_pc_frecuencia frecuencia = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["us_id"] != null && HttpContext.Current.Session["us_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                listar_categorias();
            }
        }
        else
        {
            Response.Redirect("../index");
        }
    }
    protected void listar_categorias()
    {
        frecuencia = new cls_pc_frecuencia
        {
            perm_us_id = Convert.ToInt32(Session["us_id"].ToString()),
            fr_pr_id = Convert.ToInt32(Session["pr_id"].ToString()),
        };
        var detalle_persmiso = frecuencia.ObtenerPermisosUE();

        string param = "";
        if (detalle_persmiso.Tables[0].Rows.Count > 0)
        {
            var permisos = detalle_persmiso.Tables[0].Rows;

            for (int i = 0; i < permisos.Count; i++)
            {
                string pcp_ue = validarCampo(permisos[i]["pcp_ue"]);
                param = param + ", '" + pcp_ue + "'";
            }
            param = param.Substring(1, param.Length - 1);
        }

        var detalle_operaciones = new DataTable();
        if (param != "")
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CnxSimV2"].ConnectionString);
            string q = "SELECT desc_cod_da, nombre_da, desc_cod_ue, nombre_ue, cod_poa, cod_programa, cod_proyecto, cod_actividad, desc_poa, gestion, cod_ue, Expr1, descrip_estado, cod_estado " +
                "FROM[SIMv2].[dbo].[vw_sigrh_sim_operaciones] SO WHERE SO.gestion = @gestion AND SO.desc_cod_ue IN (" + param + ")";
            SqlCommand command = new SqlCommand(q, connection);

            command.Parameters.Add(new SqlParameter("@gestion", SqlDbType.VarChar, 40)).Value = Session["gestion"].ToString();
            connection.Open();
            DbDataReader reader = command.ExecuteReader();

            detalle_operaciones.Load(reader);

            for (int i = 0; i < detalle_operaciones.Rows.Count; i++)
            {
                if (validarCampo(detalle_operaciones.Rows[i]["cod_estado"]) == "4")
                {
                    frecuencia = new cls_pc_frecuencia();
                    frecuencia.fr_cod_poa = Convert.ToInt32(validarCampo(detalle_operaciones.Rows[i]["cod_poa"]));
                    frecuencia.fr_estado = "S";
                    frecuencia.ActualizarOperacion();
                }
            }
        }

        string json = JsonConvert.SerializeObject(detalle_operaciones);
        frecuencia = new cls_pc_frecuencia
        {
            json = json,
            cp_da = 0,
            cp_ue = 0,
        };
        var categoria = frecuencia.ListarOperaciones();
        int tam_cat = categoria.Tables[0].Rows.Count;
        ltl_total_reg.Text = Convert.ToString(tam_cat);
        no_existe_cat.Visible = (tam_cat > 0) ? false : true;
        lv_categorias.DataSource = categoria;
        lv_categorias.DataBind();
    }
    protected void ver_estado(int cp_id = 0)
    {
        frecuencia = new cls_pc_frecuencia { fr_cp_id = cp_id };
        var estados = frecuencia.VerEstadoCategoria();
        int tam_cat = estados.Tables[0].Rows.Count;
        no_existe_acciones.Visible = (tam_cat > 0) ? false : true;
        gv_estado.DataSource = estados;
        gv_estado.DataBind();
        sc = "$('#modalEstados').modal('show'); ";
        SetScript(sc);
    }
    protected void gv_estado_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_estado.Rows.Count > 0)
        {
            if (gv_estado.HeaderRow != null)
            {
                gv_estado.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_estado.FooterRow != null)
            {
                gv_estado.FooterRow.TableSection = TableRowSection.TableFooter;
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
          "'ordering': false, 'searching': false, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'paging': false, 'info': false });");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_gestion').select2({ dropdownParent: $('#modalPeriodo') });");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void lv_categorias_ItemCommand(object sender, ListViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string cp_id = lv_categorias.DataKeys[index].Values[0].ToString();
        string cod_poa = lv_categorias.DataKeys[index].Values[1].ToString();


        switch (e.CommandName)
        {
            case "GetAssign":
                Response.Redirect("FrecuenciaValidacion?id=" + cp_id + "&id2=" + Session["pr_id"].ToString() + "&id3=" + cod_poa);
                break;
            case "GetDetailCat":
                ver_estado(Convert.ToInt32(cod_poa));
                break;
            case "GetPrint":
                SetScript("");
                break;
            default:
                break;
        }

    }

    protected void btn_buscar_cat_Click(object sender, EventArgs e)
    {
        frecuencia = new cls_pc_frecuencia
        {
            perm_us_id = Convert.ToInt32(Session["us_id"].ToString()),
            fr_pr_id = Convert.ToInt32(Session["pr_id"].ToString()),
        };
        var detalle_persmiso = frecuencia.ObtenerPermisosUE();

        string param = "";
        if (detalle_persmiso.Tables[0].Rows.Count > 0)
        {
            var permisos = detalle_persmiso.Tables[0].Rows;

            for (int i = 0; i < permisos.Count; i++)
            {
                string pcp_ue = validarCampo(permisos[i]["pcp_ue"]);
                param = param + ", '" + pcp_ue + "'";
            }
            param = param.Substring(1, param.Length - 1);
        }

        SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["CnxSimV2"].ConnectionString);
        string q = "SELECT desc_cod_da, nombre_da, desc_cod_ue, nombre_ue, cod_poa, cod_programa, cod_proyecto, cod_actividad, desc_poa, gestion, cod_ue, Expr1, descrip_estado, cod_estado " +
            "FROM[SIMv2].[dbo].[vw_sigrh_sim_operaciones] SO WHERE SO.gestion = @gestion AND SO.desc_cod_da = 4 AND SO.desc_cod_ue IN (" + param + ")";
        SqlCommand command = new SqlCommand(q, connection);

        command.Parameters.Add(new SqlParameter("@gestion", SqlDbType.VarChar, 40)).Value = Session["gestion"].ToString();
        connection.Open();
        DbDataReader reader = command.ExecuteReader();
        var detalle_operaciones = new DataTable();
        detalle_operaciones.Load(reader);

        string json = JsonConvert.SerializeObject(detalle_operaciones);

        frecuencia = new cls_pc_frecuencia
        {
            json = json,
            cp_da = (txt_da.Text.Trim() != "") ? Convert.ToInt32(txt_da.Text) : 0,
            cp_ue = (txt_ue.Text.Trim() != "") ? Convert.ToInt32(txt_ue.Text) : 0
        };
        var categoria = frecuencia.ListarOperaciones();
        int tam_cat = categoria.Tables[0].Rows.Count;
        ltl_total_reg.Text = Convert.ToString(tam_cat);

        lv_categorias.DataSource = categoria;
        lv_categorias.DataBind();
        SetScript("");
    }

    protected void tr_lv_categorias_Tick(object sender, EventArgs e)
    {
        listar_categorias();
        SetScript("");
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
}