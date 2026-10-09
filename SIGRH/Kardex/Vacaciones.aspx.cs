using System;
using System.Collections.Generic;

using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Solution_Framework_Kardex.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_ControlPersonal.BussinessLogicLayer;
using System.Data;

public partial class Kardex_Vacaciones : System.Web.UI.Page
{
    private cls_kd_asignacion_vacaciones asig_vacaciones = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                string codFun = HttpContext.Current.Session["per_id"].ToString();
                informacionFuncionario(codFun);
                listar_dias_vacacion_disp();
            }
        }
        else Response.Redirect("../Index");
    }
    protected void gv_dias_vacacion_disp_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_dias_vacacion_disp.Rows.Count > 0)
        {
            if (gv_dias_vacacion_disp.HeaderRow != null)
            {
                gv_dias_vacacion_disp.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_dias_vacacion_disp.FooterRow != null)
            {
                gv_dias_vacacion_disp.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void listar_dias_vacacion_disp()
    {
        string id_fun = HttpContext.Current.Session["per_id"].ToString();
        try
        {
            asig_vacaciones = new cls_kd_asignacion_vacaciones();
            asig_vacaciones.va_per_id = Convert.ToInt32(id_fun);
            var grillaAsignacionV = asig_vacaciones.obtenerGrillaAsigVacaciones();
            gv_dias_vacacion_disp.DataSource = grillaAsignacionV;
            gv_dias_vacacion_disp.DataBind();
            //txt_total_dias_vacacion.Text = Convert.ToString(ObtenerTotalDiasVacacion()) + " DÍAS";
        }
        catch (Exception ex)
        {
            Console.Error.Write(ex.Message);
        }
    }
    private int ObtenerTotalDiasVacacion()
    {
        int dias_vacacion = 0;
        foreach (GridViewRow row in gv_dias_vacacion_disp.Rows)
        {
            for (int i = 0; i < gv_dias_vacacion_disp.Columns.Count; i++)
            {
                if (i == 2)
                {
                    int dias = Convert.ToInt32(row.Cells[i].Text);
                    dias_vacacion = dias_vacacion + dias;
                }
            }
        }
        return dias_vacacion;
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
    private void informacionFuncionario(string id = "")
    {
        asig_vacaciones = new cls_kd_asignacion_vacaciones();
        string per_id = id;
        asig_vacaciones.va_per_id = Convert.ToInt32(per_id);
        asig_vacaciones.gestion_selec = Session["pr_id"].ToString();
        var detalleFuncionario = asig_vacaciones.ObtenerDatosFuncionarioP();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);

                if (validarCampo(funcionario["fp_foto"]) != "")
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
            }
        }
    }

}