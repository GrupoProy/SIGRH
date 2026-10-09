using System;
using System.Collections.Generic;
 
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
public partial class MovimientoPersonal_TipoFuncionario : System.Web.UI.Page
{
    private cls_mp_cargo cargo = null;
    private cls_situacion_persona situacion_per = null;
    private string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();
            informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
            listaGrillaSituacionPersona(Convert.ToInt32(codFun));
            listaFiltradoSituacionPersona();
            listaFiltradoTipoDoc();
            ddl_situacion_persona.Enabled = false;

        }


    }
    private void listaFiltradoTipoDoc()
    {
        try
        {
            cargo = new cls_mp_cargo();

            ddl_tipo_documento.Items.Clear();
            ddl_tipo_documento.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_documento.DataValueField = "cat_id";
            ddl_tipo_documento.DataTextField = "cat_descripcion";
            ddl_tipo_documento.DataSource = cargo.ObtenerFiltradoTipoDoc();
            ddl_tipo_documento.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void listaGrillaSituacionPersona(int codFun = 0)
    {
        try
        {
            situacion_per = new cls_situacion_persona();
            situacion_per.st_per_id = codFun;
            gv_situacion_fun.DataSource = situacion_per.ObtenerTablaGrilla();
            gv_situacion_fun.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }
    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        cargo = new cls_mp_cargo();
        cargo.as_per_id = codFun;
        cargo.as_id_actual = as_id;
        var detalleFuncionario = cargo.ObtenerDatosDetalleFuncionario();
        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_ci.Text = validarCampo(funcionario["ci"]);
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_ubicacion.Text = validarCampo(funcionario["ubicacion"]);
                ltl_programatica.Text = validarCampo(funcionario["cod_prog"]);
                ltl_cargo.Text = validarCampo(funcionario["cargo"]);
                ltl_cod_esc.Text = validarCampo(funcionario["es_escalafon"]);
                ltl_clase.Text = validarCampo(funcionario["ns_clase"]);
                ltl_nivel_salarial.Text = validarCampo(funcionario["ns_nivel"]);
                ltl_haber_basico.Text = validarCampo(funcionario["haber_basico"]);
                ltl_item.Text = validarCampo(funcionario["item"]);
                ltl_puesto.Text = validarCampo(funcionario["pu_descripcion"]);
                ltl_fecha_inicio.Text = validarCampo(funcionario["as_fecha_inicio"]);
                ltl_fecha_fin.Text = validarCampo(funcionario["as_fecha_fin"]);

                if (validarCampo(funcionario["as_estado"]) == "V")
                {
                    btn_estado.Text = "Vigente";
                    btn_estado.CssClass = "btn btn-sm btn-info float-right";
                }
                else
                {
                    btn_estado.Text = "Pasivo";
                    btn_estado.CssClass = "btn btn-sm btn-secondary float-right";
                }

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
    private string validarCampo(object p_campo)
    {
        string campo = "";

        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
        {
            campo = p_campo.ToString().Trim();
        }
        return campo;
    }
    private void listaFiltradoSituacionPersona()
    {
        try
        {
            situacion_per = new cls_situacion_persona();

            ddl_situacion_persona.Items.Clear();
            //ddl_situacion_persona.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_situacion_persona.DataValueField = "cat_abreviacion";
            ddl_situacion_persona.DataTextField = "cat_descripcion";
            var tipoItem = situacion_per.ObtenerListaSituacionPer();
            ddl_situacion_persona.DataSource = tipoItem;

            ddl_situacion_persona.DataBind();

        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void gv_situacion_fun_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gv_situacion_fun.Rows.Count > 0)
        {
            if (gv_situacion_fun.HeaderRow != null)
            {
                gv_situacion_fun.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gv_situacion_fun.FooterRow != null)
            {
                gv_situacion_fun.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gv_situacion_fun_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string st_id = gv_situacion_fun.DataKeys[index].Values[0].ToString();
        hf_st_id.Value = st_id;
        switch (e.CommandName)
        {
            case "GetDelete":
                sc = "$('#eliminarAsignacion').modal('show');";
                SetScript(sc);
                break;
            default:
                break;
        }
    }

    protected void btnAsignar_Click(object sender, EventArgs e)
    {
        situacion_per = new cls_situacion_persona();
        situacion_per.st_per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        var situacion_persona = situacion_per.ValidarSituacion();

        if (situacion_persona.Tables.Count > 0)
        {
            if (situacion_persona.Tables[0].Rows.Count > 0)
            {
                sc = "$.notify({ icon: 'fa fa-times', message: 'Ya existe un registro vigente de total bloqueo del funcionario.'},{ type: 'danger', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            } else
            {
                sc = "$('#modalGlosa').modal('show');";
                SetScript(sc);
            }
        }
    }

    protected void btnGuardaritem_Click(object sender, EventArgs e)
    {
        situacion_per = new cls_situacion_persona();
        situacion_per.st_per_id = Convert.ToInt32(Request.QueryString["id"].ToString());
        situacion_per.st_tipo_situacion = ddl_situacion_persona.SelectedValue;
        situacion_per.st_fecha_inicio = (txt_fecha_inicio.Text != "") ? txt_fecha_inicio.Text : null;
        situacion_per.st_fecha_fin = (txt_fecha_fin.Text != "") ? txt_fecha_fin.Text : null;
        situacion_per.st_estado = "V";
        situacion_per.st_usuario_creacion = Convert.ToInt32(Session["per_id"].ToString());
        var situacion_persona = situacion_per.Adicionar();
        int st_id = 0;
        if (situacion_persona.Tables.Count > 0)
        {
            if (situacion_persona.Tables[0].Rows.Count > 0)
            {
                st_id = Convert.ToInt32(situacion_persona.Tables[0].Rows[0]["st_id"].ToString());
                guardarGlosa(st_id);
                Session["texto_notificacion"] = "¡Tipo funcionario asignado exitosamente!";
                Response.Redirect("AsignacionTipoFuncionario");
            }
        }
    }

    protected void btn_cancelar_Click(object sender, EventArgs e)
    {
        sc = "$('#modalGlosa').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove(); $('#botonGuardar').css('display', 'block');";
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
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('#ContentPlaceHolder1_ddl_tipo_documento').select2({ dropdownParent: $('#modalGlosa'), placeholder: { id: '0', text: 'Seleccione...' } });");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }
    private void guardarGlosa(int st_id = 0)
    {
        string hora = DateTime.Now.ToString("HH:mm:ss");
        string fechaMov = txt_fechaMov.Text + " " + hora;
        cargo = new cls_mp_cargo();
        cargo.gl_valor_pk = st_id;
        cargo.gl_nombre_pk = "st_id";
        cargo.gl_tabla = "tbl_situacion_persona";
        cargo.gl_tipo_mov = 813;
        cargo.gl_fecha_doc = fechaMov;
        cargo.gl_tipo_doc = Convert.ToInt32(ddl_tipo_documento.SelectedValue);
        cargo.gl_glosa = txt_descripcion_add.Text;
        cargo.gl_estado = "V";
        cargo.gl_usuario = Convert.ToInt32(Session["per_id"].ToString());
        cargo.AdicionarGlosa();
    }

    protected void btnEliminarAsig_Click(object sender, EventArgs e)
    {
        situacion_per = new cls_situacion_persona();
        situacion_per.st_id = Convert.ToInt32(hf_st_id.Value);
        situacion_per.Eliminar();

        sc = "$.notify({ icon: 'fa fa-trash-alt', message: '¡Asignación anulada correctamente!'},{ type: 'success', placement: { from: 'bottom', align: 'right'} });  $('#eliminarAsignacion').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);

        string codFun = Request.QueryString["id"].ToString();
        listaGrillaSituacionPersona(Convert.ToInt32(codFun));
    }
}