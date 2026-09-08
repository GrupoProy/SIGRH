using Newtonsoft.Json;
using Solution_Framework_BienestarSocial.BussinessLogicLayer;
using Solution_Framework_BolsaTrabajo.BussinessLogicLayer;
using Solution_Framework_General.BussinessLogicLayer;
using Solution_Framework_MovimientoPersonal.BussinessLogicLayer;
using Solution_Framework_Kardex.BussinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MovimientoPersonal_ActualizacionInformacionPersonal : System.Web.UI.Page
{
    private cls_historico _historico = null;
    private cls_catalogo _catalogo = null;
    private cls_bt_postulante _postulante = null;
    private cls_persona _persona = null;
    private cls_persona_domicilio _domicilio = null;
    private cls_persona_familiares _familiar = null;
    private cls_bs_afp _afp = null;
    private string sc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (HttpContext.Current.Session["per_id"] != null && HttpContext.Current.Session["per_id"].ToString() != "")
        {
            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.Session["per_id_edit"] != null && HttpContext.Current.Session["per_id_edit"].ToString() != "")
                {
                    // Cargar combos principales y datos del formulario
                    CargarCombos();
                    BindForm(HttpContext.Current.Session["per_id_edit"].ToString());
                }
                else
                    Response.Redirect("Persona");
            }
        }
        else Response.Redirect("../Index");
    }

    #region "Carga de Combos y Métodos Auxiliares"

    private void CargarCombos()
    {
        BindDDLDepartamento();
        BindDDLProvincia(0);
        BindDDLCiudadResidencia(0);
        BindDDLZona();
        BindDDLTipoVia();
        BindDDLTipoDocumentoPersonal();
        BindDDLLugarExpedido();
        BindDDLEstadoCivil();
        BindDDLProcedencia();
        BindDDLLugarNacimiento();
        BindGradoAcademico();
    }

    private void BindDDLDepartamento()
    {
        _catalogo = new cls_catalogo { cat_tabla = "departamento" };
        Ddl_per_departamento.Items.Clear();
        Ddl_per_departamento.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_departamento.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_departamento.DataValueField = "cat_id";
        Ddl_per_departamento.DataTextField = "cat_descripcion";
        Ddl_per_departamento.DataBind();
    }

    private void BindDDLProvincia(int idDepartamento)
    {
        _catalogo = new cls_catalogo { cat_tabla = "provincia", cat_id_superior = idDepartamento };
        Ddl_per_provincia.Items.Clear();
        Ddl_per_provincia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_provincia.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_provincia.DataValueField = "cat_id";
        Ddl_per_provincia.DataTextField = "cat_descripcion";
        Ddl_per_provincia.DataBind();
    }

    private void BindDDLCiudadResidencia(int idProvincia)
    {
        _catalogo = new cls_catalogo { cat_tabla = "ciudad_localidad", cat_id_superior = idProvincia };
        Ddl_perd_ciudad_residencia.Items.Clear();
        Ddl_perd_ciudad_residencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_perd_ciudad_residencia.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_perd_ciudad_residencia.DataValueField = "cat_id";
        Ddl_perd_ciudad_residencia.DataTextField = "cat_descripcion";
        Ddl_perd_ciudad_residencia.DataBind();
    }

    private void BindDDLZona()
    {
        // Importante: usar cat_secuencial como ValueField, igual que en SolicitudContratacion
        _catalogo = new cls_catalogo { cat_tabla = "zona", cat_id_superior = 0 };
        Ddl_perd_zona.Items.Clear();
        Ddl_perd_zona.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_perd_zona.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_perd_zona.DataValueField = "cat_secuencial"; // Coincide con SolicitudContratacion
        Ddl_perd_zona.DataTextField = "cat_descripcion";
        Ddl_perd_zona.DataBind();
    }

    private void BindDDLTipoVia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_via" };
        Ddl_perd_tipo_via.Items.Clear();
        Ddl_perd_tipo_via.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_perd_tipo_via.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_perd_tipo_via.DataValueField = "cat_id";
        Ddl_perd_tipo_via.DataTextField = "cat_descripcion";
        Ddl_perd_tipo_via.DataBind();
    }

    private void BindDDLTipoDocumentoPersonal()
    {
        _catalogo = new cls_catalogo { cat_tabla = "tipo_documento_personal" };
        Ddl_per_tipo_doc.Items.Clear();
        Ddl_per_tipo_doc.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_tipo_doc.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_tipo_doc.DataValueField = "cat_id";
        Ddl_per_tipo_doc.DataTextField = "cat_descripcion";
        Ddl_per_tipo_doc.DataBind();
    }

    private void BindDDLLugarExpedido()
    {
        _catalogo = new cls_catalogo { cat_tabla = "departamento" };
        Ddl_per_lugar_exp.Items.Clear();
        Ddl_per_lugar_exp.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_lugar_exp.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_lugar_exp.DataValueField = "cat_id";
        Ddl_per_lugar_exp.DataTextField = "cat_descripcion";
        Ddl_per_lugar_exp.DataBind();
    }

    private void BindDDLEstadoCivil()
    {
        _catalogo = new cls_catalogo { cat_tabla = "estado_civil" };
        Ddl_per_estado_civil.Items.Clear();
        Ddl_per_estado_civil.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_estado_civil.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_estado_civil.DataValueField = "cat_id";
        Ddl_per_estado_civil.DataTextField = "cat_descripcion";
        Ddl_per_estado_civil.DataBind();
    }

    private void BindDDLProcedencia()
    {
        _catalogo = new cls_catalogo { cat_tabla = "pais" };
        Ddl_per_procedencia.Items.Clear();
        Ddl_per_procedencia.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_procedencia.DataSource = _catalogo.ObtenerTablaCombo();
        Ddl_per_procedencia.DataValueField = "cat_id";
        Ddl_per_procedencia.DataTextField = "cat_descripcion";
        Ddl_per_procedencia.DataBind();
    }

    private void BindDDLLugarNacimiento()
    {
        _catalogo = new cls_catalogo();
        Ddl_per_lugar_nac.Items.Clear();
        Ddl_per_lugar_nac.Items.Insert(0, new ListItem("Seleccione...", "0"));
        Ddl_per_lugar_nac.DataSource = _catalogo.ObtenerLugarNacimiento();
        Ddl_per_lugar_nac.DataValueField = "id_ciudad";
        Ddl_per_lugar_nac.DataTextField = "lugar_nac";
        Ddl_per_lugar_nac.DataBind();
    }

    private void BindGradoAcademico()
    {
        cls_grado_academico grado_academico = new cls_grado_academico();
        DdlFormacion.Items.Clear();
        DdlFormacion.Items.Insert(0, new ListItem("Seleccione...", "0"));
        DdlFormacion.DataSource = grado_academico.ObtenerGradoAcademico();
        DdlFormacion.DataValueField = "ga_id";
        DdlFormacion.DataTextField = "ga_nombre";
        DdlFormacion.DataBind();
    }

    private void BindGradoAcademicoEditar(int per_id)
    {
        cls_kd_respuesta_combo grado_academico = new cls_kd_respuesta_combo();
        grado_academico.ef_per_id = per_id;
        DataSet nivelFormacion = grado_academico.ObtenerNivelInstruccion(grado_academico);
        if (nivelFormacion.Tables[0].Rows.Count == 0)
            DdlFormacion.SelectedIndex = 0;
        else
        {
            DdlFormacion.SelectedValue = nivelFormacion.Tables[0].Rows[0]["ef_nivel_instruccion"].ToString();
            hdf_ef_id.Value = nivelFormacion.Tables[0].Rows[0]["ef_id"].ToString();
        }
    }

    private void BindCuaNua(int per_id)
    {
        cls_bs_afp afp = new cls_bs_afp();
        afp.afp_per_id = per_id;
        DataSet ds = afp.ObtenerRegistro();
        if (ds.Tables[0].Rows.Count > 0)
        {
            txtNuaCua.Text = ds.Tables[0].Rows[0]["afp_nua"].ToString();
            hdf_nua.Value = txtNuaCua.Text;
            Rbl_afp_previsora.SelectedValue = ds.Tables[0].Rows[0]["afp_previsora"].ToString();
        }
    }

    #endregion

    #region "Eventos de Cascada (Departamento -> Provincia -> Ciudad)"

    protected void Ddl_per_departamento_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idDepartamento = Convert.ToInt32(Ddl_per_departamento.SelectedValue);
        BindDDLProvincia(idDepartamento);
        BindDDLCiudadResidencia(0); // Limpiar ciudades al cambiar departamento
        Ddl_per_provincia.SelectedValue = "0";
        Ddl_perd_ciudad_residencia.SelectedValue = "0";
        UpdatePanelUbicacion.Update();
    }

    protected void Ddl_per_provincia_SelectedIndexChanged(object sender, EventArgs e)
    {
        int idProvincia = Convert.ToInt32(Ddl_per_provincia.SelectedValue);
        BindDDLCiudadResidencia(idProvincia);
        Ddl_perd_ciudad_residencia.SelectedValue = "0";
        UpdatePanelUbicacion.Update();
    }

    #endregion

    #region "Carga Principal del Formulario (BindForm)"

    private void BindForm(string id)
    {
        int perId = Convert.ToInt32(id);
        _persona = new cls_persona();
        var data = _persona.ObtenerRegistroX(perId).Tables[0];

        if (data.Rows.Count > 0)
        {
            // --- Datos Personales ---
            Txt_per_id.Text = data.Rows[0]["per_id"].ToString().Trim();
            Ddl_per_tipo_doc.SelectedValue = data.Rows[0]["per_tipo_doc"].ToString().Trim();
            Txt_per_num_doc.Text = data.Rows[0]["per_num_doc"].ToString().Trim();
            Ddl_per_lugar_exp.SelectedValue = data.Rows[0]["per_lugar_exp"].ToString().Trim();
            Txt_per_ap_paterno.Text = data.Rows[0]["per_ap_paterno"].ToString().Trim();
            Txt_per_ap_materno.Text = data.Rows[0]["per_ap_materno"].ToString().Trim();
            Txt_per_nombres.Text = data.Rows[0]["per_nombres"].ToString().Trim();
            Txt_per_ap_casada.Text = data.Rows[0]["per_ap_casada"].ToString().Trim();
            Rbl_per_sexo.SelectedValue = data.Rows[0]["per_sexo"].ToString().Trim();
            Txt_per_fecha_nac.Text = Convert.ToDateTime(data.Rows[0]["per_fecha_nac"]).ToString("dd/MM/yyyy").Trim();

            if (data.Rows[0]["per_procedencia"].ToString().Trim().Equals("1"))
                Ddl_per_lugar_nac.Enabled = true;
            Ddl_per_procedencia.SelectedValue = data.Rows[0]["per_procedencia"].ToString().Trim();
            Ddl_per_lugar_nac.SelectedValue = data.Rows[0]["per_lugar_nac"].ToString().Trim();
            Ddl_per_estado_civil.SelectedValue = data.Rows[0]["per_estado_civil"].ToString().Trim();

            // --- Libreta Militar ---
            string libreta = data.Rows[0]["per_serie_libreta_militar"].ToString().Trim();
            Txt_per_serie_libreta_militar.Text = libreta;

            // Lógica para mostrar/ocultar el combo de "TIENE/NO TIENE"
            if (!string.IsNullOrEmpty(libreta))
            {
                // Si tiene un número (o "PENDIENTE"), mostramos el textbox y ocultamos el combo
                Ddl_per_has.SelectedValue = "1"; // TIENE
                sc = "$('#d_slm').css('display', 'block'); $('#d_txt_slm').css('display', 'block');";
                SetScript(sc, "");
            }
            else
            {
                // Si está vacío, mostramos el combo para que el usuario decida
                Ddl_per_has.SelectedValue = "0";
                sc = "$('#d_slm').css('display', 'block'); $('#d_txt_slm').css('display', 'none');";
                SetScript(sc, "");
            }

            // --- Grado Académico, AFP, NUA ---
            BindGradoAcademicoEditar(perId);
            BindCuaNua(perId);

            // --- Domicilio ---
            cls_persona_domicilio domicilio = new cls_persona_domicilio();
            DataSet ds = domicilio.ObtenerTablaGrilla("", id, "", "", "", "", "", "", "", "", "");
            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow rowDom = ds.Tables[0].Rows[0];

                // 1. Obtener la Ciudad guardada
                int ciudadId = Convert.ToInt32(rowDom["perd_ciudad_residencia"]);

                // 2. Buscar a qué Provincia y Departamento pertenece
                int provinciaId = 0;
                int departamentoId = 0;
                if (ciudadId > 0)
                {
                    _catalogo = new cls_catalogo { cat_tabla = "ciudad_localidad", cat_id_superior = 0 };
                    DataSet dsCiudad = _catalogo.ObtenerTablaCombo();
                    DataRow[] rowsCiudad = dsCiudad.Tables[0].Select("cat_id = " + ciudadId);
                    if (rowsCiudad.Length > 0)
                    {
                        provinciaId = Convert.ToInt32(rowsCiudad[0]["cat_id_superior"]);

                        // Obtener Departamento de la Provincia
                        _catalogo = new cls_catalogo { cat_tabla = "provincia", cat_id_superior = 0 };
                        DataSet dsProv = _catalogo.ObtenerTablaCombo();
                        DataRow[] rowsProv = dsProv.Tables[0].Select("cat_id = " + provinciaId);
                        if (rowsProv.Length > 0)
                        {
                            departamentoId = Convert.ToInt32(rowsProv[0]["cat_id_superior"]);
                        }
                    }
                }

                // 3. Cargar cascada y seleccionar valores
                BindDDLDepartamento();
                if (departamentoId > 0)
                {
                    Ddl_per_departamento.SelectedValue = departamentoId.ToString();
                    BindDDLProvincia(departamentoId);
                    if (provinciaId > 0)
                    {
                        Ddl_per_provincia.SelectedValue = provinciaId.ToString();
                        BindDDLCiudadResidencia(provinciaId);
                        Ddl_perd_ciudad_residencia.SelectedValue = ciudadId.ToString();
                    }
                }

                // 4. Zona (usando cat_secuencial)
                string zonaId = rowDom["perd_zona"].ToString();
                if (!string.IsNullOrEmpty(zonaId) && zonaId != "0")
                {
                    Ddl_perd_zona.SelectedValue = zonaId;
                }

                // 5. Tipo de Vía, Descripción, Número
                Ddl_perd_tipo_via.SelectedValue = rowDom["perd_tipo_via"].ToString();
                Txt_perd_descripcion_via.Text = rowDom["perd_descripcion_via"].ToString();
                Txt_perd_numero.Text = rowDom["perd_numero"].ToString();

                // 6. Teléfonos y Email
                Txt_perd_telefono.Text = rowDom["perd_telefono"].ToString().Trim();
                Txt_perd_celular.Text = rowDom["perd_celular"].ToString().Trim();
                Txt_perd_email.Text = rowDom["perd_email_personal"].ToString().Trim();
            }
        }
    }

    #endregion

    #region "Eventos de Controles (Libreta Militar, Zona, etc.)"

    protected void Ddl_per_procedencia_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_per_procedencia.SelectedValue.Equals("1"))
        {
            Ddl_per_lugar_nac.SelectedValue = "0";
            Ddl_per_lugar_nac.Enabled = true;
        }
        else
        {
            Ddl_per_lugar_nac.SelectedValue = "1822";
            Ddl_per_lugar_nac.Enabled = false;
        }
        SetScript("", ", dropdownParent: $('#editModal')");
    }

    protected void Ddl_per_has_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (Ddl_per_has.SelectedValue.Equals("1"))
        {
            sc = "$('#d_slm').css('display', 'block'); $('#d_txt_slm').css('display', 'block');";
            Txt_per_serie_libreta_militar.Text = ""; // Limpiar para que ingrese el número
        }
        else
        {
            sc = "$('#d_slm').css('display', 'block'); $('#d_txt_slm').css('display', 'none');";
            Txt_per_serie_libreta_militar.Text = ""; // Si no tiene, guardamos vacío
        }
        SetScript(sc, "");
    }

    protected void btnNuevoCatalogo_Click(object sender, EventArgs e)
    {
        txt_cat_descripcion.Text = "";
        sc = "$('#modalCatalogo').modal('show');";
        SetScript(sc, "");
    }

    protected void BotonCerrarCatalogo_Click(object sender, EventArgs e)
    {
        sc = "$('#modalCatalogo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
        SetScript(sc, "");
    }

    protected void BtnRegistrarCatalogo_Click(object sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(txt_cat_descripcion.Text))
        {
            cls_catalogo catalogo = new cls_catalogo();
            catalogo.Adicionar("zona", txt_cat_descripcion.Text.ToUpper().Trim(), "", "0");
            BindDDLZona();
            // Seleccionar la nueva zona (la última agregada)
            Ddl_perd_zona.SelectedIndex = Ddl_perd_zona.Items.Count - 1;
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Se adicionó correctamente la zona' }, { type: 'success' }); $('#modalCatalogo').modal('hide'); $('body').removeClass('modal-open'); $('.modal-backdrop').remove();";
            SetScript(sc, "");
        }
        else
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar una descripción' }, { type: 'warning' });";
            SetScript(sc, "");
        }
    }

    #endregion

    #region "Guardar / Actualizar"

    protected void BtnGuardar_Click(object sender, EventArgs e)
    {
        // Validar Lugar de Nacimiento si es Boliviano
        if (Ddl_per_procedencia.SelectedValue.Equals("1") && Ddl_per_lugar_nac.SelectedValue.Equals("0"))
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Lugar de Nacimiento) es obligatorio...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        // Validar Libreta Militar
        if (Rbl_per_sexo.SelectedValue.Equals("F"))
        {
            // Femenino: se maneja con el combo
            if (Ddl_per_has.SelectedValue.Equals("1") && string.IsNullOrEmpty(Txt_per_serie_libreta_militar.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'Debe ingresar el Nº de Libreta de Serv. Militar o seleccionar NO TIENE' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }
        else
        {
            // Masculino: obligatorio llenar el número
            if (string.IsNullOrEmpty(Txt_per_serie_libreta_militar.Text))
            {
                sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Nº Libreta de Serv. Militar) es obligatorio' }, { type: 'warning' });";
                SetScript(sc, "");
                return;
            }
        }

        // Validar Fecha de Nacimiento (Edad)
        var edad = DateTime.Now.Year - Convert.ToDateTime(Txt_per_fecha_nac.Text.Trim()).Year;
        if (edad <= 0)
        {
            sc = "$.notify({ icon: 'fas fa-exclamation', message: 'El campo (Fecha de Nacimiento), no tiene una fecha válida...!!' }, { type: 'warning' });";
            SetScript(sc, "");
            return;
        }

        // Actualizar Persona
        _persona = new cls_persona
        {
            per_id = Convert.ToInt32(Txt_per_id.Text.Trim()),
            per_tipo_doc = Convert.ToInt32(Ddl_per_tipo_doc.SelectedValue),
            per_num_doc = Txt_per_num_doc.Text.ToUpper().Trim(),
            per_lugar_exp = Convert.ToInt32(Ddl_per_lugar_exp.SelectedValue),
            per_ap_paterno = Txt_per_ap_paterno.Text.ToUpper().Trim(),
            per_ap_materno = Txt_per_ap_materno.Text.ToUpper().Trim(),
            per_nombres = Txt_per_nombres.Text.ToUpper().Trim(),
            per_ap_casada = Txt_per_ap_casada.Text.ToUpper().Trim(),
            per_sexo = Rbl_per_sexo.SelectedValue,
            per_fecha_nac = Convert.ToDateTime(Txt_per_fecha_nac.Text.Trim()),
            per_procedencia = Convert.ToInt32(Ddl_per_procedencia.SelectedValue),
            per_serie_libreta_militar = Txt_per_serie_libreta_militar.Text.ToUpper().Trim(),
            per_lugar_nac = Convert.ToInt32(Ddl_per_lugar_nac.SelectedValue),
            per_estado_civil = Convert.ToInt32(Ddl_per_estado_civil.SelectedValue)
        };
        _persona.Actualizar__personaConLibreta();

        // Actualizar Domicilio
        _domicilio = new cls_persona_domicilio
        {
            perd_per_id = Convert.ToInt32(Txt_per_id.Text.Trim()),
            perd_ciudad_residencia = Convert.ToInt32(Ddl_perd_ciudad_residencia.SelectedValue),
            perd_zona = Convert.ToInt32(Ddl_perd_zona.SelectedValue),
            perd_tipo_via = Convert.ToInt32(Ddl_perd_tipo_via.SelectedValue),
            perd_descripcion_via = Txt_perd_descripcion_via.Text.ToUpper().Trim(),
            perd_numero = Txt_perd_numero.Text.ToUpper().Trim(),
            perd_telefono = Txt_perd_telefono.Text.Trim(),
            perd_celular = Txt_perd_celular.Text.Trim(),
            perd_email = Txt_perd_email.Text.Trim()
        };
        _domicilio.Actualizar__Informacion_persona_domicilio();

        // Actualizar AFP y NUA/CUA
        _afp = new cls_bs_afp
        {
            afp_per_id = Convert.ToInt32(Txt_per_id.Text.Trim()),
            afp_previsora = Rbl_afp_previsora.SelectedValue,
            afp_fecha_filiacion = DateTime.Now,
            afp_fecha_modificacion = null,
            afp_fecha_carnet = DateTime.Now,
            afp_estado_carnet = "V",
            afp_usuario = Convert.ToInt32(Session["per_id"].ToString()),
            afp_nua = string.IsNullOrEmpty(txtNuaCua.Text) ? "0" : txtNuaCua.Text
        };
        _afp.ActualizarCuaNua(_afp);
        _afp.ActualizarAfp(_afp);

        // Actualizar Grado Académico
        cls_kd_respuesta_combo gradoAcademico = new cls_kd_respuesta_combo();
        gradoAcademico.ef_nivel_instruccion = Convert.ToInt32(DdlFormacion.SelectedValue);
        gradoAcademico.ef_per_id = Convert.ToInt32(Txt_per_id.Text.Trim());
        gradoAcademico.ef_id = string.IsNullOrEmpty(hdf_ef_id.Value) ? 0 : Convert.ToInt32(hdf_ef_id.Value);
        gradoAcademico.ActualizarNivelInstruccion(gradoAcademico);

        // Notificar y redirigir
        Session["texto_notificacion"] = "Registro ACTUALIZADO correctamente...!!";
        Response.Redirect("Persona");
    }

    #endregion

    #region "Scripts y Utilidades"

    private void SetScript(string val, string valS)
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type='text/javascript'>");
        sb.Append(val);
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
        sb.Append("$('.numero').on('input', function (event) {" +
                "this.value = this.value.replace(/[^0-9]/g, '');" +
            "});");
        sb.Append("$('.letras').on('input', function () {" +
                "this.value = this.value.replace(/[^A-Z\u00F1\u00D1 ]+$/i, '');" +
            "});");
        sb.Append("$('.tooltip').css('display', 'none');" +
            "$('[data-toggle=\"tooltip\"]').tooltip({ trigger: 'hover' });");
        sb.Append("$('.select2').select2({ placeholder: { id: '0', text: 'Seleccione...' }" + valS + " });");
        sb.Append("$(\".radios label\").addClass(\"custom-control-label mb-3\");" +
            "$(\".radios input[type='radio']\").addClass(\"custom-control-input mb-3\");");
        sb.Append("$(function () {" +
                "$(\"body\").delegate(\".datepickerD\", \"focusin\", function () {" +
                    "$(this).datepicker({" +
                        "format: \"dd/mm/yyyy\"," +
                        "autoclose: true," +
                        "language: 'es'" +
                    "});" +
                "});" +
                "var me = $(\".datepickerD\");" +
                "me.mask('99/99/9999');" +
            "});");
        sb.Append(@"</script>");
        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "SIGRHScript", sb.ToString(), false);
    }

    private void SetScript(string val)
    {
        SetScript(val, "");
    }

    #endregion
}