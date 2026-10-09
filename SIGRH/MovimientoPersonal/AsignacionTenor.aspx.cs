using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.IO;
using System.Drawing;
using MessagingToolkit.QRCode.Codec;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Newtonsoft.Json.Linq;
using System.Linq;

public partial class MovimientoPersonal_AsignacionTenor : System.Web.UI.Page
{
    private cls_mp_cargo tenor = null;
    private cls_mp_seguimiento_memorandum memo_historico = null;
    private string sc = "";

    // <-- CAMBIO: Forzar codificación UTF-8 en toda la página (también se puede hacer en Page_Load)
    protected void Page_PreInit(object sender, EventArgs e)
    {
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.Charset = "UTF-8";
        Response.ContentType = "text/html; charset=utf-8";
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        // <-- CAMBIO: Refuerzo de codificación (por si PreInit no se ejecuta)
        Response.ContentEncoding = System.Text.Encoding.UTF8;
        Response.Charset = "UTF-8";
        Response.ContentType = "text/html; charset=utf-8";

        if (HttpContext.Current.Session["us_id"] != null)
        {
            if (HttpContext.Current.Session["us_id"].ToString() != "")
            {
                if (!Page.IsPostBack)
                {
                    listaFiltradoTipoItem();
                    listaFiltradoTipoMov();
                    ddl_tenor.Enabled = false;

                    //if (Session["us_id"] != null)
                    //{
                    //    procesarSancion();
                    //}
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

    private void procesarSancion()
    {
        ddl_tipo_movimiento_gral.SelectedValue = "S";
        ddl_tipo_movimiento_gral.Enabled = false;
        listaFiltradoTenor("S");
        btnFiltrar_Click();
    }

    private void listaFiltradoTipoMov()
    {
        try
        {
            tenor = new cls_mp_cargo();

            ddl_tipo_movimiento_gral.Items.Clear();
            ddl_tipo_movimiento_gral.Items.Insert(0, new ListItem("Seleccione...", "0"));
            ddl_tipo_movimiento_gral.DataValueField = "cat_abreviacion";
            ddl_tipo_movimiento_gral.DataTextField = "cat_descripcion";
            ddl_tipo_movimiento_gral.DataSource = tenor.ObtenerFiltradoTipoMov();
            ddl_tipo_movimiento_gral.DataBind();

            //ListItem itemToRemove = ddl_tipo_movimiento_gral.Items.FindByValue("M");
            //if (itemToRemove != null)
            //{
            //    ddl_tipo_movimiento_gral.Items.Remove(itemToRemove);
            //}
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void listaFiltradoTipoItem()
    {
        try
        {
            tenor = new cls_mp_cargo();

            ddl_tipo_item.Items.Clear();
            ddl_tipo_item.Items.Insert(0, new ListItem("TODOS", "-1"));
            ddl_tipo_item.DataValueField = "ti_item";
            ddl_tipo_item.DataTextField = "ti_descripcion";
            ddl_tipo_item.DataSource = tenor.ObtenerFiltradoTipoItem();
            ddl_tipo_item.DataBind();
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    private void SetScriptInicio(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();
        sb.Append(data);
        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), uuid, sb.ToString(), true);
    }

    private void SetScript(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("quill.enable(false); ");
        sb.Append("$('.ql-editor').css('border', 'none');$('.ql-editor').css('width', '100%'); $('.ql-editor').css('margin-left', '0'); $('.ql-container.ql-snow').css('border', 'none'); $('.ql-editor').css('padding', '0rem .75rem');");
        sb.Append(data);

        sb.Append("if (!$.fn.dataTable.isDataTable('.table')) { $('.table').DataTable({" +
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
            "'ordering': false, 'searching': true, 'autoWidth': false, 'orderCellsTop': true, 'fixedHeader': true, 'iDisplayLength': 100, 'stateSave': true, 'stateDuration': 60 * 10 }); }");
        sb.Append("$('.tooltip').css('display','none'); $('[data-toggle=" + '"' + "tooltip" + '"' + "]').tooltip({trigger: 'hover'}); ");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' } }); ");
        sb.Append("$('.checks label').addClass('custom-control-label mb-3'); $('.checks input[type =" + '"' + "checkbox" + '"' + "]').addClass('custom-control-input mb-3');");
        sb.Append("quill.enable(); ");

        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    private void SetScriptMasivo(string data)
    {
        Guid g;
        g = Guid.NewGuid();
        string uuid = g.ToString();

        StringBuilder sb = new StringBuilder();

        sb.Append(@"<script type='text/javascript'>");
        sb.Append("$('.ql-editor').css('border', 'none'); $('.ql-container.ql-snow').css('border', 'none');  $('.ql-editor').css('padding', '0rem .75rem');");
        sb.Append(data);
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), uuid, sb.ToString(), false);
    }

    private void listaFiltradoTenor(string te_tipo_reg = "")
    {
        try
        {
            tenor = new cls_mp_cargo();
            tenor.te_tipo_reg = te_tipo_reg;
            var tiposTenor = tenor.ObtenerFiltradoTenor();
            if (tiposTenor.Tables[0].Rows.Count > 0)
            {
                SetScript("");
                ddl_tenor.Items.Clear();
                ddl_tenor.Items.Insert(0, new ListItem("Seleccione...", "0"));
                ddl_tenor.DataValueField = "te_id";
                ddl_tenor.DataTextField = "te_descripcion";
                ddl_tenor.DataSource = tiposTenor;
                ddl_tenor.DataBind();
                ddl_tenor.Enabled = true;
            }
            else
            {
                ddl_tenor.Items.Clear();
                ddl_tenor.Enabled = false;
                SetScript("$.notify({ icon: 'fa fa-info', message:'No existen tenores para el tipo de movimiento seleccionado'},{type: 'darker', placement: { from: 'bottom', align: 'right'} }); ");
            }
        }
        catch (Exception e)
        {
            Console.Error.Write(e.Message);
        }
    }

    protected void ddl_tipo_movimiento_gral_SelectedIndexChanged(object sender, EventArgs e)
    {
        string te_tipo_reg = ddl_tipo_movimiento_gral.SelectedValue;
        listaFiltradoTenor(te_tipo_reg);
    }

    protected void gvFuncionario_PreRender(object sender, EventArgs e)
    {
        base.OnPreRender(e);
        if (gvFuncionario.Rows.Count > 0)
        {
            if (gvFuncionario.HeaderRow != null)
            {
                gvFuncionario.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
            if (gvFuncionario.FooterRow != null)
            {
                gvFuncionario.FooterRow.TableSection = TableRowSection.TableFooter;
            }
        }
    }

    protected void gvFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int index = Convert.ToInt32(e.CommandArgument);
        string p_cod_fun = gvFuncionario.DataKeys[index].Values[0].ToString();
        string p_as_id = gvFuncionario.DataKeys[index].Values[1].ToString();
        hf_cod_tenor.Value = ddl_tenor.SelectedValue;
        int gestion = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;

        switch (e.CommandName)
        {
            case "GetDetail":
                if (ddl_tenor.SelectedValue != "0")
                {
                    Response.Redirect("TenorFuncionario?id=" + p_cod_fun + "&id2=" + hf_cod_tenor.Value + "&id3=" + ddl_tipo_movimiento_gral.SelectedValue + "&id4=" + gestion);
                }
                else
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Debe escoger un Tenor para imprimir.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                    SetScript(sc);
                }
                break;
            case "GetPrint":
                if (ddl_tenor.SelectedValue != "0")
                {
                    int cod_tenor = (ddl_tenor.SelectedValue != "") ? Convert.ToInt32(ddl_tenor.SelectedValue) : 0;
                    var detalleTenor = obtenerTenor(cod_tenor);
                    string containerQuill = ImprimirMemo(Convert.ToInt32(p_cod_fun), cod_tenor, detalleTenor, Convert.ToInt32(p_as_id));

                    if (containerQuill != "")
                    {
                        hf_containerQuill.Value = containerQuill;
                        sc = "armarQuill();";
                    }
                    else
                    {
                        sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                    }
                    SetScript(sc);
                }
                else
                {
                    sc = "$.notify({ icon: 'fa fa-exclamation', message: 'Debe escoger un Tenor para imprimir.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
                    SetScript(sc);
                }
                break;
            default:
                break;
        }
    }

    protected void btnFiltrar_Click(object sender = null, EventArgs e = null)
    {
        int gestion = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;
        if (ddl_tipo_movimiento_gral.SelectedValue != "" && ddl_tipo_movimiento_gral.SelectedValue != "0")
        {
            LimpiarGrilla();
            tenor = new cls_mp_cargo();
            int bat_per_id = gestion;
            tenor.bat_per_id = bat_per_id;

            string tipo_movimiento = ddl_tipo_movimiento_gral.SelectedValue;
            switch (tipo_movimiento)
            {
                case "A": armarConsulta("V", "P1"); break;
                case "B": armarConsulta("B", "P2"); break;
                case "T": armarConsulta("T", "P3"); break;
                case "P": armarConsulta("P", "P4"); break;
                case "X": armarConsulta("V", "P5"); break;
                case "Y": armarConsulta("B", "P6"); break;
                case "V": armarConsulta("V", "P7"); break;
                case "W": armarConsulta("B", "P8"); break;
                case "M": armarConsulta("M", "P9"); break;
                case "H": armarConsulta("T", "P10"); break;
                case "S": armarConsulta("V", "P11"); break;
                default: break;
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message:'Por favor seleccione un Tipo de Movimiento.'},{type: 'info', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    protected void armarConsulta(string tipoMov = "", string num_consulta = "")
    {
        tenor = new cls_mp_cargo();
        tenor.as_estado = tipoMov;
        tenor.ca_ti_item = (ddl_tipo_item.SelectedValue != "" && ddl_tipo_item.SelectedValue != "-1") ? ddl_tipo_item.SelectedValue : null;
        tenor.ca_num_item = (txt_desde_item.Text.Trim() != "") ? Convert.ToInt32(txt_desde_item.Text.Trim()) : 0;
        tenor.ca_num_item_actual = (txt_hasta_item.Text.Trim() != "") ? Convert.ToInt32(txt_hasta_item.Text.Trim()) : 0;
        tenor.ca_pr_id = (Session["pr_id"] != null) ? Session["pr_id"].ToString() : "0";
        tenor.ca_num_consulta = num_consulta;
        tenor.fu_paterno = Txt_per_ap_paterno.Text;
        tenor.gl_numero_doc = Txt_per_num_doc.Text;
        var grillaFunc = tenor.ObtenerInfoParaTenorMemorandums();

        gvFuncionario.DataSource = grillaFunc;
        gvFuncionario.DataBind();
        sc = (grillaFunc.Tables[0].Rows.Count > 0) ? "$('#grillaFunc').css('display', 'block');" : "$('#grillaFunc').css('display', 'none'); $.notify({ icon: 'fa fa-info', message:'No existen funcionarios con los filtro(s) seleccionado(s)'},{type: 'info', placement: { from: 'bottom', align: 'right'} });";

        if (ddl_tipo_movimiento_gral.SelectedValue == "S")
        {
            SetScriptInicio(sc);
        }
        else
        {
            SetScript(sc);
        }
        ddl_tenor.Enabled = true;
    }

    protected void LimpiarGrilla()
    {
        gvFuncionario.DataSource = null;
        gvFuncionario.DataBind();
    }

    protected void chk_print_memo_CheckedChanged(object sender, EventArgs e) { }

    protected void btnLimpiar_Click(object sender, EventArgs e) { }

    protected void btn_imprimir_masivo_Click(object sender, EventArgs e)
    {
        if (ddl_tenor.SelectedValue != "0" && ddl_tenor.SelectedValue != null)
        {
            bool swFuncionario = true;
            for (int i = 0; i < gvFuncionario.Rows.Count; i++)
            {
                GridViewRow row = gvFuncionario.Rows[i];
                bool isChecked = ((CheckBox)row.FindControl("chk_print_memo")).Checked;
                if (isChecked)
                {
                    swFuncionario = true;
                    break;
                }
                else
                {
                    swFuncionario = false;
                }
            }

            if (swFuncionario)
            {
                DataTable quillContainers = new DataTable();
                quillContainers.Columns.Add("resultado");
                DataRow dr_resultado = null;

                DataTable listaQr = new DataTable();
                listaQr.Columns.Add("qr_id");
                DataRow dr = null;

                int cod_tenor = (ddl_tenor.SelectedValue != "") ? Convert.ToInt32(ddl_tenor.SelectedValue) : 0;
                var detalleTenor = obtenerTenor(cod_tenor);

                for (int i = 0; i < gvFuncionario.Rows.Count; i++)
                {
                    GridViewRow row = gvFuncionario.Rows[i];
                    bool isChecked = ((CheckBox)row.FindControl("chk_print_memo")).Checked;

                    if (isChecked)
                    {
                        int per_id = (int)Convert.ToInt32(gvFuncionario.DataKeys[i].Values[0].ToString());
                        int as_id = (int)Convert.ToInt32(gvFuncionario.DataKeys[i].Values[1].ToString());
                        dr_resultado = quillContainers.NewRow();
                        dr_resultado["resultado"] = ImprimirMemo(per_id, cod_tenor, detalleTenor, as_id);
                        quillContainers.Rows.Add(dr_resultado);

                        dr = listaQr.NewRow();
                        dr["qr_id"] = hf_qr_value.Value;
                        listaQr.Rows.Add(dr);
                    }
                }

                // <-- CAMBIO: Configurar serialización JSON para preservar caracteres Unicode
                JsonSerializerSettings jsonSettings = new JsonSerializerSettings
                {
                    StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
                };

                hf_containerQuill.Value = JsonConvert.SerializeObject(quillContainers, jsonSettings);
                hf_respMasivaQR.Value = JsonConvert.SerializeObject(listaQr, jsonSettings);
                sc = "armarRespMasiva();";
                SetScript(sc);
            }
            else
            {
                sc = "$.notify({ icon: 'fa fa-info', message:'Seleccione a los funcionarios a asignar.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
                SetScript(sc);
            }
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-info', message:'Seleccione el Tenor a asignar al funcionario(s).'},{type: 'warning', placement: { from: 'bottom', align: 'right'} });";
            SetScript(sc);
        }
    }

    public static string GetFirstWord(string text)
    {
        string firstWord = String.Empty;
        if (String.IsNullOrEmpty(text))
            return string.Empty;

        firstWord = text.Split(' ').FirstOrDefault();
        if (String.IsNullOrEmpty(firstWord))
            return string.Empty;

        return firstWord;
    }

    protected string ImprimirMemo(int per_id = 0, int cod_tenor = 0, DataSet detalleTenor = null, int as_id = 0)
    {
        string containerQuill = "";
        int existe = verificarMemorandum(cod_tenor);
        var detalleFuncionario = obtenerFuncionario(per_id, existe, as_id);
        string arrayVars = hf_var.Value;

        if (detalleTenor.Tables[0].Rows.Count > 0 && detalleFuncionario.Tables[0].Rows.Count > 0 && arrayVars != "")
        {
            containerQuill = construirReporte(arrayVars, detalleFuncionario, detalleTenor);

            // Generación del código QR
            DataTable listaQr = new DataTable();
            listaQr.Columns.Add("qr_id");

            Guid g = Guid.NewGuid();
            string uuid = "CAMARA DE SENADORES - " + GetFirstWord(detalleTenor.Tables[0].Rows[0]["te_descripcion"].ToString().Trim()) + " " + detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"].ToString().Trim() + "/" + detalleFuncionario.Tables[0].Rows[0]["PRD"].ToString().Trim() + " - " + detalleFuncionario.Tables[0].Rows[0]["NOMBRE_DEL_FUNCIONARIO"].ToString().Trim() + " - CI:" + detalleFuncionario.Tables[0].Rows[0]["CARNET_DE_IDENTIDAD"].ToString().Trim();

            QRCodeEncoder encoder = new QRCodeEncoder();
            Bitmap img = encoder.Encode(uuid);
            System.Drawing.Image QR = (System.Drawing.Image)img;

            cls_persona foto = new cls_persona();
            DataSet ds = foto.FileVirtual(0, null, 0, "", "", 266, "266", "V", "C1");

            using (MemoryStream ms = new MemoryStream())
            {
                QR.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] imageBytes = ms.ToArray();
                string qrDataUrl = "data:image/gif;base64," + Convert.ToBase64String(imageBytes);

                // Se asigna la imagen en Base64 al HiddenField
                hf_qr_value.Value = qrDataUrl;

                // Se añade la fila única a la lista
                DataRow dr = listaQr.NewRow();
                dr["qr_id"] = qrDataUrl;
                listaQr.Rows.Add(dr);
            }

            // Serializar con configuración UTF-8
            JsonSerializerSettings jsonSettings = new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            };
            hf_respMasivaQR.Value = JsonConvert.SerializeObject(listaQr, jsonSettings);

            AdicionarHistoricoMemo(uuid, per_id, cod_tenor, containerQuill, validarCampo(detalleFuncionario.Tables[0].Rows[0]["NRO_MEMO"]));
        }
        else
        {
            sc = "$.notify({ icon: 'fa fa-exclamation', message: 'No se puede realizar la acción.'},{type: 'warning', placement: { from: 'bottom', align: 'right'} }); ";
            SetScript(sc);
        }
        return containerQuill;
    }


    private string construirReporte(string arrayVars = "", DataSet detalleFuncionario = null, DataSet detalleTenor = null)
    {
        string cadena = "";
        var funcionario = detalleFuncionario.Tables[0].Rows[0];
        var tenor = detalleTenor.Tables[0].Rows[0];

        var variablesReporte = JArray.Parse(arrayVars);
        for (int i = 0; i < variablesReporte.Count; i++)
        {
            var codigo = validarCampo(variablesReporte[i]["codigo"]);
            if (codigo != "")
            {
                foreach (DataColumn column in detalleFuncionario.Tables[0].Columns)
                {
                    string cn = column.ColumnName;
                    if (codigo == cn)
                    {
                        variablesReporte[i]["contenido"] = validarCampo(funcionario[cn]);
                        break;
                    }
                }
            }
        }

        cadena = JsonConvert.SerializeObject(variablesReporte);

        string te_contenido = validarCampo(tenor["te_contenido"]);
        for (int i = 0; i < variablesReporte.Count; i++)
        {
            var nombreVariable = validarCampo(variablesReporte[i]["nombreVariable"]);
            var contenido = validarCampo(variablesReporte[i]["contenido"]);
            te_contenido = te_contenido.Replace(nombreVariable, contenido);
        }

        // Limpiar espacios y saltos de línea excesivos
        te_contenido = System.Text.RegularExpressions.Regex.Replace(te_contenido, @"\s+", " ");
        te_contenido = te_contenido.Replace("\r\n", "\n").Replace("\r", "\n");
        te_contenido = System.Text.RegularExpressions.Regex.Replace(te_contenido, @"\n{2,}", "\n");

        cadena = te_contenido;
        return cadena;
    }

    private DataSet obtenerTenor(int cod_tenor = 0)
    {
        tenor = new cls_mp_cargo();
        tenor.te_cod_tenor = cod_tenor;
        var detalleTenor = tenor.ObtenerDetalleTenor();
        return detalleTenor;
    }

    private DataSet obtenerFuncionario(int cod_fun = 0, int existe = 0, int as_id = 0)
    {
        int pr_id = (Session["pr_id"] != null) ? Convert.ToInt32(Session["pr_id"].ToString()) : 0;

        tenor = new cls_mp_cargo();
        tenor.p_per_id = cod_fun;
        tenor.as_id = as_id;
        tenor.gestion_selec = pr_id + "";
        tenor.p_aux = existe;

        DataSet detalleFuncionario = null;
        string tipo_movimiento = ddl_tipo_movimiento_gral.SelectedValue;
        switch (tipo_movimiento)
        {
            case "A": detalleFuncionario = tenor.ObtenerDetalleFuncionario(); break;
            case "B": detalleFuncionario = tenor.ObtenerDetalleFuncionarioBajas(); break;
            case "T": detalleFuncionario = tenor.ObtenerDetalleFuncionarioPRTCargos(); break;
            case "P": detalleFuncionario = tenor.ObtenerDetalleFuncionarioPRTAcefalias(); break;
            case "X": detalleFuncionario = tenor.ObtenerDetalleFuncionarioAComInt(); break;
            case "Y": detalleFuncionario = tenor.ObtenerDetalleFuncionarioBComInt(); break;
            case "V": detalleFuncionario = tenor.ObtenerDetalleFuncionarioADispPersonal(); break;
            case "W": detalleFuncionario = tenor.ObtenerDetalleFuncionarioBDispPersonal(); break;
            case "M": detalleFuncionario = tenor.ObtenerDetalleFuncionarioMemosVarios(); break;
            case "H": detalleFuncionario = tenor.ObtenerDetalleFuncionarioTransicion(); break;
            case "S": detalleFuncionario = tenor.ObtenerDetalleFuncionarioSancion(); break;
            default: break;
        }
        actualizarNroMemo(as_id, detalleFuncionario);
        return detalleFuncionario;
    }

    protected void chk_print_memo_all_CheckedChanged(object sender, EventArgs e)
    {
        for (int i = 0; i < gvFuncionario.Rows.Count; i++)
        {
            GridViewRow row = gvFuncionario.Rows[i];
            bool isChecked = ((CheckBox)gvFuncionario.HeaderRow.FindControl("chk_print_memo_all")).Checked;
            if (isChecked)
                ((CheckBox)row.FindControl("chk_print_memo")).Checked = true;
            else
                ((CheckBox)row.FindControl("chk_print_memo")).Checked = false;
        }
        SetScript("");
    }

    protected void ddl_tenor_SelectedIndexChanged(object sender, EventArgs e)
    {
        SetScript("");
    }

    protected void AdicionarHistoricoMemo(string mh_qr = "", int mh_per_id = 0, int mh_te_id = 0, string tf_contenido = "", string mh_nro_memo = "")
    {
        memo_historico = new cls_mp_seguimiento_memorandum();
        memo_historico.mh_qr = mh_qr;
        memo_historico.mh_per_id = mh_per_id;
        memo_historico.mh_te_id = mh_te_id;
        memo_historico.mh_nro_memo = Convert.ToInt32(mh_nro_memo);
        memo_historico.mh_contenido = tf_contenido;
        memo_historico.mh_usuario_creacion = Convert.ToInt32(Session["us_id"].ToString());
        memo_historico.mh_pr_id = Convert.ToInt32(Session["pr_id"].ToString());
        memo_historico.Adicionar();
    }

    private int verificarMemorandum(int te_cod_tenor = 0)
    {
        int existe = 0;
        tenor = new cls_mp_cargo();
        tenor.te_cod_tenor = te_cod_tenor;
        var tenorX = tenor.VerificarMemorandum();

        if (tenorX.Tables[0].Rows.Count > 0)
        {
            var detalle_tenor = tenorX.Tables[0].Rows[0];
            existe = Convert.ToInt32(validarCampo(detalle_tenor["existe"]));
        }
        return existe;
    }

    private string validarCampo(object p_campo)
    {
        string campo = "";
        if (p_campo != DBNull.Value && p_campo.ToString().Trim() != "")
            campo = p_campo.ToString().Trim();
        return campo;
    }

    private void actualizarNroMemo(int as_id = 0, DataSet detalleFuncionario = null)
    {
        if (detalleFuncionario.Tables[0].Rows.Count > 0)
        {
            var funcionario = detalleFuncionario.Tables[0].Rows[0];
            tenor = new cls_mp_cargo();
            tenor.p_nro_memo = (validarCampo(funcionario["NRO_MEMO"]) != "") ? Convert.ToInt32(validarCampo(funcionario["NRO_MEMO"])) : 0;
            tenor.as_id_actual = as_id;
            tenor.as_tipo_mov = ddl_tipo_movimiento_gral.SelectedValue;
            tenor.ActualizarMemoAsignacion();
        }
    }
}