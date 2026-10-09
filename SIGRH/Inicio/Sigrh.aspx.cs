using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_Seguridad.BussinessLogicLayer;

using System.Text;

public partial class MovimientoPersonal_Sigrh : System.Web.UI.Page
{
    private static cls_seg_menu _menu = null;

    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Cache.SetNoStore();
        //Response.Cache.SetExpires(DateTime.UtcNow.AddHours(-1));
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        if (HttpContext.Current.Session["per_id"] != null)
        {
            if (HttpContext.Current.Session["per_id"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {
                    ltl_only_name.Text = HttpContext.Current.Session["per_nom"].ToString();
                    //ltl_rol.Text = HttpContext.Current.Session["rol"].ToString();
                   
                   
                }
            }
            else Response.Redirect("../index");
        }
        else Response.Redirect("../index");
    }

    [WebMethod]
    public static List<cls_seg_menu> BindMenuAjax()
    {
        if (HttpContext.Current.Session["rol"].ToString() == "INVITADO")
        {
            //_menu = new cls_seg_menu();
            //List<cls_seg_menu> listMenu = new List<cls_seg_menu>();
            //_menu = new cls_seg_menu
            //{
            //    me_id = 1036,
            //    me_descripcion = "LICENCIA JUSTIFICADA",
            //    me_url = "../ControlPersonal/LicenciaJustificada",
            //    me_icono = "fas fa-pen",
            //    me_id_padre = 1021,
            //    me_vista = true
            //};
            //List<cls_seg_menu> listTree = GetMenuTree(listMenu, 0);
            //listMenu.Add(_menu);
            //_menu = new cls_seg_menu
            //{
            //    me_id = 5243,
            //    me_descripcion = "CURRICULUM",
            //    me_url = "../Kardex/CV",
            //    me_icono = "fas fa-copy",
            //    me_id_padre = 1027,
            //    me_vista = true
            //};
            //listMenu.Add(_menu);

            //listTree = listMenu;
            //return listTree;
            if (HttpContext.Current.Session["per_id"] != null)
            {
                _menu = new cls_seg_menu();
                List<cls_seg_menu> listMenu = new List<cls_seg_menu>();


                foreach (DataRow item in _menu.ObtenerMenuRolINVITADO(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString())).Tables[0].Rows)
                {
                    _menu = new cls_seg_menu
                    {
                        me_id = Convert.ToInt32(item["me_id"].ToString()),
                        me_descripcion = item["me_descripcion"].ToString(),
                        me_url = item["me_url"].ToString(),
                        me_icono = item["me_icono"].ToString(),
                        me_id_padre = Convert.ToInt32(item["me_id_padre"].ToString()),
                        me_vista = Convert.ToBoolean(item["me_vista"].ToString())
                    };
                    listMenu.Add(_menu);
                }
                List<cls_seg_menu> listTree = GetMenuTree(listMenu, 0);

                return listTree;
            }
            else return null;
        }
        else
        {
            if (HttpContext.Current.Session["per_id"] != null)
            {
                _menu = new cls_seg_menu();
                List<cls_seg_menu> listMenu = new List<cls_seg_menu>();


                foreach (DataRow item in _menu.ObtenerMenuRol(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString())).Tables[0].Rows)
                {
                    _menu = new cls_seg_menu
                    {
                        me_id = Convert.ToInt32(item["me_id"].ToString()),
                        me_descripcion = item["me_descripcion"].ToString(),
                        me_url = item["me_url"].ToString(),
                        me_icono = item["me_icono"].ToString(),
                        me_id_padre = Convert.ToInt32(item["me_id_padre"].ToString()),
                        me_vista = Convert.ToBoolean(item["me_vista"].ToString())
                    };
                    listMenu.Add(_menu);
                }
                List<cls_seg_menu> listTree = GetMenuTree(listMenu, 0);

                return listTree;
            }
            else return null;
        }
    }

    // Ayuda a generar los items de menú, en el orden que corresponde de forma recursiva
    public static List<cls_seg_menu> GetMenuTree(List<cls_seg_menu> list, int? parentId)
    {
        return list.Where(x => x.me_id_padre == parentId)
            .Select(x => new cls_seg_menu()
            {
                me_id = x.me_id,
                me_descripcion = x.me_descripcion,
                me_url = x.me_url,
                me_icono = x.me_icono,
                me_id_padre = x.me_id_padre,
                me_vista = x.me_vista,
                me_lista = GetMenuTree(list, x.me_id)
            }).ToList();
    }

    [WebMethod]
    public static List<cls_seg_menu> RoutesUser()
    {
        if (HttpContext.Current.Session["per_id"] != null)
        {
            _menu = new cls_seg_menu();
            List<cls_seg_menu> listMenu = new List<cls_seg_menu>();

            foreach (DataRow item in _menu.ObtenerMenuRol(Convert.ToInt32(HttpContext.Current.Session["per_id"].ToString())).Tables[0].Rows)
            {
                _menu = new cls_seg_menu
                {
                    me_id = Convert.ToInt32(item["me_id"].ToString()),
                    me_descripcion = item["me_descripcion"].ToString(),
                    me_url = item["me_url"].ToString(),
                    me_icono = item["me_icono"].ToString(),
                    me_id_padre = Convert.ToInt32(item["me_id_padre"].ToString())
                };
                listMenu.Add(_menu);
            }
            return listMenu;
        }
        else return null;
    }

    

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.numero').on('input', function (event) { this.value = this.value.replace(/[^0-9]/g, ''); });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_gestion').select2({ dropdownParent: $('#modalPeriodo') });");
        sb.Append("var me = $('.datepicker'); me.mask('99/99/9999'); ");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
}