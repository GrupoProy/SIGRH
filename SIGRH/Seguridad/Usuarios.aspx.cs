using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Seguridad.BussinessLogicLayer;
using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Seguridad_Usuarios : System.Web.UI.Page
{
    private cls_seg_usuario _usuario = null;
    private cls_persona _persona = null;
    //private cls_seg_usuario_rol _usuario_rol = null;
    private string sc = "";

    // Carga los componentes al iniciar la página
    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                BindGridView();
                sc = "CopiarCortarPegar(true);";
                SetScript(sc);
            }
        }
        else Response.Redirect("../Index");
    }

    private void BindGridView()
    {
        try
        {
            _usuario = new cls_seg_usuario();
            GvLista.DataSource = _usuario.ObtenerTablaGrilla("", "", "", "", "", "", "", "", "", "", "", "", "V");
            GvLista.DataBind();
        }
        catch (Exception ex) { Console.Error.Write(ex.Message); }
    }

    //private void BindGridViewRol(int id_usuario)
    //{
    //    try
    //    {
    //        _usuario_rol = new cls_seg_usuario_rol();
    //        GvRol.DataSource = _usuario_rol.ObtenerTablaUsuarioRol(id_usuario);
    //        GvRol.DataBind();
    //    }
    //    catch (Exception ex) { Console.Error.Write(ex.Message); }
    //}

    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GvLista.Rows.Count > 0)
        {
            if (GvLista.HeaderRow != null) GvLista.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GvLista.FooterRow != null) GvLista.FooterRow.TableSection = TableRowSection.TableFooter;
        }
    }

    protected void GvLista_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string code = GvLista.DataKeys[index].Value.ToString();

        if (e.CommandName.Equals("GetEdit"))
        {
            _usuario = new cls_seg_usuario();
            _persona = new cls_persona();
            var data = _usuario.ObtenerRegistro(Convert.ToInt32(code)).Tables[0];
            var dataP = _persona.ObtenerRegistroX(Convert.ToInt32(data.Rows[0]["us_per_id"].ToString())).Tables[0];
            Hf_us_id_m.Value = data.Rows[0]["us_id"].ToString().Trim();
            Txt_us_per_id_m.Text = dataP.Rows[0]["per_nombres"].ToString().Trim() + " " + dataP.Rows[0]["per_ap_paterno"].ToString().Trim() + " " + dataP.Rows[0]["per_ap_materno"].ToString().Trim();
            sc = "$('#editModal').modal('show');";
        }
        else if (e.CommandName.Equals("GetDelete"))
        {
            _usuario = new cls_seg_usuario();
            _persona = new cls_persona();
            var data = _usuario.ObtenerRegistro(Convert.ToInt32(code)).Tables[0];
            var dataP = _persona.ObtenerRegistroX(Convert.ToInt32(data.Rows[0]["us_per_id"].ToString())).Tables[0];
            Hf_us_id_b.Value = data.Rows[0]["us_id"].ToString().Trim();
            Txt_us_per_id_b.Text = dataP.Rows[0]["per_nombres"].ToString().Trim() + " " + dataP.Rows[0]["per_ap_paterno"].ToString().Trim() + " " + dataP.Rows[0]["per_ap_materno"].ToString().Trim();
            sc = "$('#deleteModal').modal('show');";
        }
        else if (e.CommandName.Equals("GetUsuarioRol")) Response.Redirect("UsuariosPermisos?id=" + code);
        SetScript(sc);
    }

    //protected void GvRol_PreRender(object sender, EventArgs e)
    //{
    //    base.OnPreRender(e);

    //    if (GvRol.Rows.Count > 0)
    //    {
    //        if (GvRol.HeaderRow != null) GvRol.HeaderRow.TableSection = TableRowSection.TableHeader;
    //        if (GvRol.FooterRow != null) GvRol.FooterRow.TableSection = TableRowSection.TableFooter;
    //    }
    //}

    //protected void GvRol_RowCommand(object sender, GridViewCommandEventArgs e)
    //{
    //    int index = Convert.ToInt32(e.CommandArgument);
    //    string code = GvRol.DataKeys[index].Value.ToString();

    //    if (e.CommandName.Equals("GetDelete"))
    //    {
    //        sc = "$('#deletePermissionModal').modal('show');";
    //    }
    //    SetScript(sc);
    //}

    protected void BtnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("UsuariosBusqueda");
    }

    // Guardar Modificación
    protected void BtnGuardarM_Click(object sender, EventArgs e)
    {
        _usuario = new cls_seg_usuario();
        var data = _usuario.ObtenerTablaGrilla(Hf_us_id_m.Value, "", "", "", "", "", "", "", "", "", "", "", "V").Tables[0];

        if (data.Rows.Count > 0) sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El registro no se puede actualizar, aún mantiene los mismos parámetros...!!' }, { type: 'warning' });";
        else
        {
            _usuario = new cls_seg_usuario
            {
                us_id = Convert.ToInt32(Hf_us_id_m.Value.Trim()),
                us_usuario_creacion = "root"
            };
            _usuario.Actualizar();
            _usuario.Adicionar();
            sc = "$.notify({ icon: 'fas fa-check', message: 'Registro actualizado correctamente...!!' }, { type: 'success' }); $('#editModal').modal('hide');";
        }
        BindGridView();
        SetScript(sc);
    }

    // Cancelar Modificación
    protected void BtnCancelarM_Click(object sender, EventArgs e)
    {
        sc = "$('#editModal').modal('hide');";
        SetScript(sc);
    }

    // Guardar Baja
    protected void BtnGuardarB_Click(object sender, EventArgs e)
    {
        _usuario = new cls_seg_usuario { us_id = Convert.ToInt32(Hf_us_id_b.Value) };
        _usuario.Eliminar();
        BindGridView();
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro eliminado correctamente...!!' }, { type: 'success' }); $('#deleteModal').modal('hide');";
        SetScript(sc);
    }

    // Cancelar Baja
    protected void BtnCancelarB_Click(object sender, EventArgs e)
    {
        sc = "$('#deleteModal').modal('hide');";
        SetScript(sc);
    }

    protected void BtnGuardarUR_Click(object sender, EventArgs e)
    {
        //_usuario_rol = new cls_seg_usuario_rol
        //{
        //    usrol_us_id = Convert.ToInt32(Hf_us_id_ur.Value),
        //    usrol_rol_id = Convert.ToInt32(Ddl_rol_id.SelectedValue),
        //    usrol_usuario_creacion = Session["per_id"].ToString()
        //};
        //_usuario_rol.Adicionar();
        //BindGridViewRol(Convert.ToInt32(Hf_us_id_ur.Value));
        //Limpiar("perm_cl");
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro eliminado correctamente...!!' }, { type: 'success' });";
        SetScript(sc);
    }

    protected void BtnCancelarUR_Click(object sender, EventArgs e)
    {
        Limpiar("perm_cl");
        sc = "$('#usuarioRolModal').modal('hide');";
        SetScript(sc);
    }

    protected void BtnGuardarBUR_Click(object sender, EventArgs e)
    {
        sc = "$.notify({ icon: 'fas fa-check', message: 'Registro eliminado correctamente...!!' }, { type: 'success' }); $('#deleteUsuarioRolModal').modal('hide');";
        SetScript(sc);
    }

    protected void BtnCancelarBUR_Click(object sender, EventArgs e)
    {
        sc = "$('#deleteUsuarioRolModal').modal('hide');";
        SetScript(sc);
    }

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
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }, dropdownParent: $('#usuarioRolModal') });");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepicker\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: 'es'" +
                    "});" +
                "});" +
                "$('.datepicker').datepicker('setDate', 'today');" +
                "var me = $(\".datepicker\");" +
                "me.mask('99/99/9999');" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void Limpiar(string val)
    {
        
    }
}