using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Drawing;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using System.Text;
using System.Web.UI;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Solution_Framework_Kardex.BussinessLogicLayer;

public partial class Kardex_FileVirtualNuevoPdf : System.Web.UI.Page
{
    private cls_persona persona_foto = null;
    private cls_mp_cargo cargo = null;
    string sc = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string codFun = Request.QueryString["id"].ToString();
            string as_id = Request.QueryString["id2"].ToString();

            informacionFuncionario(Convert.ToInt32(codFun), Convert.ToInt32(as_id));
            CargarCategoriasKardex();
            BindGrid();
        }
    }
    private void informacionFuncionario(int codFun = 0, int as_id = 0)
    {
        cls_kd_respuesta_combo resp_combo = new cls_kd_respuesta_combo();
        resp_combo.p_per_id = codFun;
        var detalleFuncionario = resp_combo.ObtenerDatosFuncioanrio();

        if (detalleFuncionario.Tables.Count > 0)
        {
            if (detalleFuncionario.Tables[0].Rows.Count > 0)
            {
                var funcionario = detalleFuncionario.Tables[0].Rows[0];
                ltl_cod_fun.Text = validarCampo(funcionario["per_id"]);
                ltl_nombre_fun.Text = validarCampo(funcionario["nombre_fun"]);
                ltl_estado_civil.Text = validarCampo(funcionario["estado_civil"]);
                //ltl_genero.Text = validarCampo(funcionario["genero"]);
                //txt_nro_lib.Text = validarCampo(funcionario["nro_lib_mil"]);
                ltl_num_doc.Text = validarCampo(funcionario["num_doc"]) + " " + validarCampo(funcionario["lugar_exp"]);
                ltl_fecha_nac.Text = validarCampo(funcionario["fecha_nac"]);
                //ltl_pais.Text = validarCampo(funcionario["pais"]);
                //ltl_departamento.Text = validarCampo(funcionario["departamento"]);
                //ltl_provincia.Text = validarCampo(funcionario["provincia"]);
                //ltl_localidad.Text = validarCampo(funcionario["localidad"]);
            }
        }
    }

    private void CargarCategoriasKardex()
    {
        cls_persona kardex = new cls_persona();
        ddlCategoria.Items.Clear();
        ddlCategoria.Items.Add("Seleccione..");
        ddlCategoria.DataSource = kardex.FileVirtual(0, null, 0, "", "", 0, "", "", "C2");
        ddlCategoria.DataTextField = "categoria";
        ddlCategoria.DataValueField = "categoria";
        ddlCategoria.DataBind();

        if (HttpContext.Current.Session["Categoria_index"] != null && HttpContext.Current.Session["Categoria_index"].ToString() != "")
        {
            ddlCategoria.SelectedIndex = Convert.ToInt32(HttpContext.Current.Session["Categoria_index"].ToString());
            ddlCategoria_SelectedIndexChanged(null, null);
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


    private void guardarFoto(int fp_id = 0, int fp_per_id = 0, byte[] fp_foto = null, string fp_estado = "")
    {
        cls_persona imagen_documento = new cls_persona();
        imagen_documento.FileVirtual(0, fp_foto, Convert.ToInt32(ddlDocumento.SelectedItem.Value), txt_fecha_doc.Text, DateTime.Now.ToString(), Convert.ToInt32(Request.QueryString["id"].ToString()), txtObservaciones.Text, "V", "A2");
        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente el documento' }, { type: 'warning', placement: { from: 'bottom', align: 'right'} }); $('#blockResultados').css('display', 'none'); $('#modalCatalogo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc);
        string codFun = Request.QueryString["id"].ToString();
        string as_id = Request.QueryString["id2"].ToString();
        Response.Redirect("FileVirtualPdf?id=" + codFun + "&id2=" + as_id);

    }

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append(data);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }});");
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
        sb.Append(@"</script>");

        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScript("");
        cls_persona kardex = new cls_persona();
        ddlDocumento.Items.Clear();
        ddlDocumento.Items.Add("Seleccione..");
        ddlDocumento.DataSource = kardex.FileVirtual(0, null, 0, "", "", 0, ddlCategoria.SelectedItem.Text, "", "C3");
        ddlDocumento.DataTextField = "rq_descripcion";
        ddlDocumento.DataValueField = "rq_id";
        ddlDocumento.DataBind();

        Session["Categoria_index"] = ddlCategoria.SelectedIndex;

        if (HttpContext.Current.Session["Documento_index"] != null && HttpContext.Current.Session["Documento_index"].ToString() != "")
        {
            ddlDocumento.SelectedIndex = Convert.ToInt32(HttpContext.Current.Session["Documento_index"].ToString());
        }

        BindGrid();
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        int codFun = Convert.ToInt32(Request.QueryString["id"].ToString());
        string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        string filename2 = filename.Substring(0, filename.Length - 4);
        string contentType = FileUpload1.PostedFile.ContentType;
        cls_persona kardex = new cls_persona();
        int insertado = 0;
        using (Stream fs = FileUpload1.PostedFile.InputStream)
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                byte[] bytes = br.ReadBytes((Int32)fs.Length);
                insertado = kardex.AdicionarFileVirtualPDF(0, bytes, Convert.ToInt32(ddlDocumento.SelectedItem.Value), txt_fecha_doc.Text, DateTime.Now.ToShortDateString(), codFun, txtObservaciones.Text, "V", filename, "A2");
            }
        }
        if (insertado > 0)
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Se registró correctamente el documento'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); ";
        else
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se pudo almacenar el archivos, consulte al administrador del sistema o vuelva a intentarlo'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";

        //Response.Redirect(Request.Url.AbsoluteUri);
        SetScript(sc);
        Session["Documento_index"] = ddlDocumento.SelectedIndex;
        txt_fecha_doc.Text = "";
        txtObservaciones.Text = "";
        ddlCategoria_SelectedIndexChanged(null, null);
    }
    protected void GvLista_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);

        if (GridView1.Rows.Count > 0)
        {
            if (GridView1.HeaderRow != null) GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
            if (GridView1.FooterRow != null) GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
        }

    }
    private void BindGrid()
    {
        cls_persona PDF = new cls_persona();
        DataSet ds = PDF.MostrarFileVirtualPDF(Convert.ToInt32(Request.QueryString["id"].ToString()), ddlCategoria.SelectedItem.Text);
        //ds = (DataSet)ViewState["ds"];
        //DataTable dt = ds.Tables[0];
        if (ds.Tables[0].Rows.Count > 0)
            GridView1.DataSource =  ds; 
        else
            GridView1.DataSource = "";
        GridView1.DataBind();
        if (GridView1.Rows.Count > 0)
            resultado.Visible = true;

        //string constr = ConfigurationManager.ConnectionStrings["CnxSigrh3"].ConnectionString;
        //using (SqlConnection con = new SqlConnection(constr))
        //{
        //    using (SqlCommand cmd = new SqlCommand())
        //    {
        //        cmd.CommandText = "select * from tbl_kd_file_virtualPDF";
        //        cmd.Connection = con;
        //        con.Open();
        //        GridView1.DataSource = cmd.ExecuteReader();
        //        GridView1.DataBind();
        //        con.Close();
        //    }
        //}
    }


    protected void GridView1_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
    {
        var index = Convert.ToInt32(e.CommandArgument);
        cls_persona pdf = new cls_persona();

        if (e.CommandName.Equals("pdf"))
        {


            string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"100%\" height=\"1000px\">";
            //            embed += "Si no es posible ver el archivo, you can download from <a href = \"{0}{1}&download=1\">here</a>";
            embed += "Si no es posible ver el archivo, por favor";
            embed += " descargue Adobe Reader del siguiente enlace <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> para ver los archivos con extensión pdf";
            embed += "</object>";
            ltEmbed.Text = string.Format(embed, ResolveUrl("FileCS.ashx?Id="), GridView1.DataKeys[index].Values["pdf_id"].ToString());
            btnActualizar.Visible = false;
            btnUpload.Visible = true;
            txtObservaciones.Text = "";
            txt_fecha_doc.Text = "";
        }
        if (e.CommandName.Equals("eliminar"))
        {
            sc = "$('#guardarCambios').modal('show');";
            Session["pdf_id_eliminar"] = GridView1.DataKeys[index].Values["pdf_id"].ToString();
            SetScript2(sc, "");          
        }
        if (e.CommandName.Equals("editar"))
        {


            string embed = "<object data=\"{0}{1}\" type=\"application/pdf\" width=\"100%\" height=\"1000px\">";
            //            embed += "Si no es posible ver el archivo, you can download from <a href = \"{0}{1}&download=1\">here</a>";
            embed += "Si no es posible ver el archivo, por favor";
            embed += " descargue Adobe Reader del siguiente enlace <a target = \"_blank\" href = \"http://get.adobe.com/reader/\">Adobe PDF Reader</a> para ver los archivos con extensión pdf";
            embed += "</object>";
            ltEmbed.Text = string.Format(embed, ResolveUrl("FileCS.ashx?Id="), GridView1.DataKeys[index].Values["pdf_id"].ToString());
            DataSet ds = pdf.MostrarFileVirtualPDF_PorPdf_id(Convert.ToInt32(Request.QueryString["id"].ToString()), Convert.ToInt32(GridView1.DataKeys[index].Values["pdf_id"].ToString()));
            ddlDocumento.SelectedValue= ds.Tables[0].Rows[0]["pdf_rq_id"].ToString();
            txt_fecha_doc.Text= Convert.ToDateTime(ds.Tables[0].Rows[0]["pdf_fecha_doc"].ToString()).ToShortDateString();
            txtObservaciones.Text= ds.Tables[0].Rows[0]["pdf_observacion"].ToString();
            btnUpload.Visible = false;
            FileUpload1.Visible = false;
            btnActualizar.Visible = true;
            Session["pdf_id_actualizar"] = GridView1.DataKeys[index].Values["pdf_id"].ToString();
        }
        SetScript(sc);
    }
    private void SetScript2(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        //sb.Append("$('#ddlDocs').select2({ dropdownParent: $('#modalNuevaVacacion')});");

        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }
    protected void btnAtras_Click(object sender, EventArgs e)
    {
        string codFun = Request.QueryString["id"].ToString();
        string as_id = Request.QueryString["id2"].ToString();

        Response.Redirect("FileVirtualPdf?id=" + codFun + "&id2=" + as_id);
    }

    protected void btnActualizar_Click(object sender, EventArgs e)
    {
        cls_persona pdf = new cls_persona();
        if (HttpContext.Current.Session["pdf_id_actualizar"] != null && HttpContext.Current.Session["pdf_id_actualizar"].ToString() != "")
        {
            if (pdf.ActualizarFileVirtualPDF(Convert.ToDateTime(txt_fecha_doc.Text), txtObservaciones.Text, Convert.ToInt32(HttpContext.Current.Session["pdf_id_actualizar"].ToString())))
            {
                sc = "$.notify({ icon: 'fa fa-check', message: 'Documento Actualizado...'},{type: 'success', placement: { from: 'bottom', align: 'right'} }); ";
                BindGrid();
                btnActualizar.Visible = false;
                btnUpload.Visible = true;
                FileUpload1.Visible = true;
                txt_fecha_doc.Text = "";
                txtObservaciones.Text = "";
            }
        }
        SetScript(sc);
    }


    protected void btn_guardar_cambios_Click(object sender, EventArgs e)
    {
        cls_persona pdf = new cls_persona();
        pdf.EliminarFileVirtualPDF(Convert.ToInt32(Session["pdf_id_eliminar"].ToString()));
        sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se eliminó el documento digital correctamente' }, { type: 'warning' });$('#guardarCambios').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        btnActualizar.Visible = false;
        btnUpload.Visible = true;
        txtObservaciones.Text = "";
        txt_fecha_doc.Text = ""; BindGrid();
        SetScript(sc);
    }
}