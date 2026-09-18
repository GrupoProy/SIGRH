<%@ Page Title="Declaración Jurada del Funcionario"
    Language="C#"
    MasterPageFile="~/MasterPageSIGRH.master"
    AutoEventWireup="true"
    CodeFile="FiliacionUpdate.aspx.cs"
    Inherits="Kardex_FiliacionUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <asp:UpdatePanel runat="server" ID="panelFiliacionUpdate">
        <ContentTemplate>

            <div class="container-fluid px-4">

                <!-- ═══════════════════════════════════════════════════════════
                     CARD PRINCIPAL
                     ═══════════════════════════════════════════════════════════ -->
                <div class="card shadow-lg border-0 rounded-3">

                    <!-- HEADER -->
                    <div class="card-header bg-gradient-primary text-white rounded-top-3 py-3">
                        <h3 class="mb-0 fw-bold">
                            <i class="fas fa-file-signature me-2"></i>DECLARACIÓN JURADA DEL FUNCIONARIO
                        </h3>
                        <p class="text-light-50 mb-0 small" runat="server" id="leyenda">
                            <i class="fas fa-info-circle me-1"></i>Actualice su información personal y profesional
                        </p>
                    </div>

                    <!-- BOTONES DE ACCIÓN PRINCIPAL -->
                    <div class="card-body bg-light">
                        <div class="row g-3">
                            <div class="col-md-6">
                                <asp:Button ID="LinkButton1"
                                    OnClick="LinkButton1_Click"
                                    CssClass="btn btn-success w-100 py-3 rounded-pill shadow-sm fw-bold fs-6"
                                    Text="COMENZAR"
                                    runat="server" />
                            </div>
                            <div class="col-md-6">
                                <asp:Button ID="Button1"
                                    OnClick="Button1_Click"
                                    CssClass="btn btn-danger w-100 py-3 rounded-pill shadow-sm fw-bold fs-6"
                                    Text="CANCELAR"
                                    runat="server" />
                            </div>
                        </div>
                    </div>

                    <!-- ═══════════════════════════════════════════════════════════
                         CONTENIDO PRINCIPAL
                         ═══════════════════════════════════════════════════════════ -->
                    <div class="card-body" runat="server" id="divCV" visible="false">

                        <!-- DATOS PERSONALES -->
                        <div runat="server" id="ViewDatosPersonales" class="mb-4">
                            <div class="card shadow-sm border-0">
                                <div class="card-header bg-gradient-primary text-white py-3">
                                    <h4 class="mb-0 fw-bold">
                                        <i class="fas fa-id-card me-2"></i>DATOS PERSONALES
                                    </h4>
                                </div>
                                <div class="card-body bg-white">
                                    <div class="row g-4">
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Nombre Completo</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Fecha Nacimiento</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_fecha_nac" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label">CI</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_num_doc" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row g-4 mt-1">
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Género</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_genero" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Procedencia</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_pais" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Estado Civil</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_estado_civil" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row mt-3">
                                        <div class="col-lg-6">
                                            <div class="alert alert-info mb-0" role="alert">
                                                <i class="fas fa-file-signature me-2"></i>
                                                <strong>Declaración Jurada N°:</strong>
                                                <asp:Literal ID="ltl_dj_id" runat="server" Text="-" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="alert alert-success mb-0" role="alert">
                                                <i class="fas fa-calendar-alt me-2"></i>
                                                <strong>Fecha de Inicio:</strong>
                                                <asp:Literal ID="ltl_fecha_inicio" runat="server" Text="--/--/----" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- NAVEGACIÓN POR PESTAÑAS -->
                        <div class="mt-4 mb-4">
                            <ul class="nav nav-tabs nav-justified fw-bold fs-6" role="tablist">
                                <li class="nav-item">
                                    <asp:LinkButton ID="btnTab1" runat="server" OnClick="btnTab1_Click"
                                        CssClass="nav-link active">
                                        <i class="fas fa-folder me-2"></i>Dirección y Contacto
                                    </asp:LinkButton>
                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="btnTab2" runat="server" OnClick="btnTab2_Click"
                                        CssClass="nav-link">
                                        <i class="fas fa-tasks me-2"></i>Educación Formal
                                    </asp:LinkButton>
                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="btnTab3" runat="server" OnClick="btnTab3_Click"
                                        CssClass="nav-link">
                                        <i class="fas fa-file-alt me-2"></i>Datos Familiares
                                    </asp:LinkButton>
                                </li>
                                <li class="nav-item">
                                    <asp:LinkButton ID="btnTab4" runat="server" OnClick="btnTab4_Click"
                                        CssClass="nav-link">
                                        <i class="fas fa-sliders-h me-2"></i>Doble Percepción
                                    </asp:LinkButton>
                                </li>
                            </ul>

                            <!-- CONTENEDOR DE VISTAS -->
                            <div class="border border-top-0 rounded-bottom p-4 bg-white shadow-sm">
                                <asp:MultiView ID="mvOpciones" runat="server" ActiveViewIndex="0">

                                    <!-- ═══════════════════════════════════════════════════════
                                         VISTA 1: DIRECCIÓN Y CONTACTO
                                         ═══════════════════════════════════════════════════════ -->
                                    <asp:View ID="viewOpcion1" runat="server">
                                        <div class="card border-0">
                                            <div class="card-body p-4">
                                                <div class="d-flex align-items-center justify-content-between border-bottom pb-3 mb-4">
                                                    <h5 class="fw-bold text-primary mb-0">
                                                        <i class="fas fa-home fs-4 me-2"></i>DIRECCIÓN, CONTACTO Y EMERGENCIA
                                                    </h5>
                                                </div>

                                                <asp:UpdatePanel ID="upDatosDomicilio" runat="server">
                                                    <ContentTemplate>

                                                        <asp:HiddenField ID="hf_perd_id" runat="server" ClientIDMode="Static" />
                                                        <asp:HiddenField ID="hf_coordenadas" runat="server" ClientIDMode="Static" />

                                                        <!-- SECCIÓN A: UBICACIÓN GEOGRÁFICA -->
                                                        <h6 class="text-muted text-uppercase mb-3">
                                                            <i class="fas fa-map-marked-alt me-1"></i>Ubicación Geográfica
                                                        </h6>

                                                        <div class="row g-3 mb-3">
                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_perd_departamento" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-map me-1 text-primary"></i>Departamento
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_perd_departamento" runat="server"
                                                                    CssClass="form-control form-select select2"
                                                                    AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddl_perd_departamento_SelectedIndexChanged">
                                                                    <asp:ListItem Text="-- Seleccione --" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_perd_provincia" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-map-pin me-1 text-primary"></i>Provincia
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_perd_provincia" runat="server"
                                                                    CssClass="form-control form-select select2"
                                                                    AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddl_perd_provincia_SelectedIndexChanged">
                                                                    <asp:ListItem Text="-- Seleccione --" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_perd_ciudad_residencia" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-city me-1 text-primary"></i>Ciudad/Localidad
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_perd_ciudad_residencia" runat="server"
                                                                    CssClass="form-control form-select select2"
                                                                    AutoPostBack="true"
                                                                    OnSelectedIndexChanged="ddl_perd_ciudad_residencia_SelectedIndexChanged">
                                                                    <asp:ListItem Text="" Value="" />
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_perd_zona" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-map-marker-alt me-1 text-primary"></i>Zona/Barrio
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_perd_zona" runat="server"
                                                                    CssClass="form-control form-select select2">
                                                                    <asp:ListItem Text="" Value="" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <!-- SECCIÓN B: DIRECCIÓN EXACTA -->
                                                        <h6 class="text-muted text-uppercase mb-3 mt-4">
                                                            <i class="fas fa-road me-1"></i>Dirección Exacta
                                                        </h6>

                                                        <div class="row g-3 mb-3">
                                                            <div class="col-lg-2 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_perd_tipo_via" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-road me-1 text-primary"></i>Tipo Vía
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_perd_tipo_via" runat="server"
                                                                    CssClass="form-control form-select select2">
                                                                    <asp:ListItem Text="" Value="" />
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-8 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_nombre_via" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-signature me-1 text-primary"></i>Nombre de la Vía
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_nombre_via" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. 16 de Julio" />
                                                            </div>

                                                            <div class="col-lg-2 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_numero_casa" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-hashtag me-1 text-primary"></i>Número
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_numero_casa" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. 1234" />
                                                            </div>
                                                        </div>

                                                        <div class="row g-3 mb-3">
                                                            <div class="col-lg-4 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_edificio" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-building me-1 text-primary"></i>Edificio <small class="text-muted">(opcional)</small>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_edificio" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. Torre Illimani" />
                                                            </div>

                                                            <div class="col-lg-2 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_bloque" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-cubes me-1 text-primary"></i>Bloque
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_bloque" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. A" />
                                                            </div>

                                                            <div class="col-lg-2 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_piso" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-layer-group me-1 text-primary"></i>Piso
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_piso" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. 5" />
                                                            </div>

                                                            <div class="col-lg-2 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_departamento" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-door-closed me-1 text-primary"></i>Depto.
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_departamento" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. 5B" />
                                                            </div>
                                                        </div>

                                                        <!-- SECCIÓN C: CONTACTO -->
                                                        <h6 class="text-muted text-uppercase mb-3 mt-4">
                                                            <i class="fas fa-address-book me-1"></i>Datos de Contacto
                                                        </h6>

                                                        <div class="row g-3 mb-3">
                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_telefono" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-phone me-1 text-primary"></i>Teléfono
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_telefono" runat="server"
                                                                    CssClass="form-control"
                                                                    MaxLength="8"
                                                                    Placeholder="Ej. 22445566"
                                                                    oninput="soloNumerosInput(this, 8);"
                                                                    onkeypress="return soloNumerosKey(event);" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_celular" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-mobile-alt me-1 text-primary"></i>Celular
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_celular" runat="server"
                                                                    CssClass="form-control"
                                                                    MaxLength="8"
                                                                    Placeholder="Ej. 71234567"
                                                                    oninput="soloNumerosInput(this, 8);"
                                                                    onkeypress="return soloNumerosKey(event);" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_email_personal" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-envelope me-1 text-primary"></i>Email Personal
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_email_personal" runat="server"
                                                                    TextMode="Email"
                                                                    CssClass="form-control"
                                                                    Placeholder="ejemplo@gmail.com" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_email_trabajo" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-envelope-open-text me-1 text-primary"></i>Email Institucional
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_email_trabajo" runat="server"
                                                                    TextMode="Email"
                                                                    CssClass="form-control"
                                                                    Placeholder="ejemplo@institucion.gob.bo" />
                                                            </div>
                                                        </div>

                                                        <!-- SECCIÓN D: CONTACTO DE EMERGENCIA -->
                                                        <h6 class="text-muted text-uppercase mb-3 mt-4 text-danger">
                                                            <i class="fas fa-user-shield me-1"></i>Contacto de Emergencia
                                                        </h6>

                                                        <div class="row g-3 mb-4">
                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_en_caso_emer" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-user me-1 text-danger"></i>Nombre del Contacto
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_en_caso_emer" runat="server"
                                                                    CssClass="form-control border-danger"
                                                                    Placeholder="Ej. Juan Pérez" />
                                                            </div>

                                                            <div class="col-lg-6 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_direccion_emer" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-map-marked me-1 text-danger"></i>Dirección de Emergencia
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_direccion_emer" runat="server"
                                                                    CssClass="form-control border-danger"
                                                                    Placeholder="Dirección del contacto" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_telf_emer" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-phone-slash me-1 text-danger"></i>Teléfono
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_telf_emer" runat="server"
                                                                    CssClass="form-control numero"
                                                                    MaxLength="8"
                                                                    Placeholder="Ej. 71234567" />
                                                            </div>
                                                        </div>

                                                        <!-- SECCIÓN E: INFORMACIÓN ADICIONAL -->
                                                        <h6 class="text-muted text-uppercase mb-3 mt-4">
                                                            <i class="fas fa-id-card me-1"></i>Información Adicional
                                                        </h6>

                                                        <div class="row g-3 mb-4">
                                                            <div class="col-lg-4 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_nro_lib" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-shield-alt me-1 text-primary"></i>Nº Libreta de Servicio Militar
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_nro_lib" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. L-987654" />
                                                            </div>
                                                            <div class="col-lg-4 col-md-6" style="display: none;">
                                                                <asp:Label AssociatedControlID="txt_codigo_file" runat="server"
                                                                    CssClass="form-label text-dark fw-bold mb-1">
                                                                Código File
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_codigo_file" runat="server"
                                                                    CssClass="form-control"
                                                                    Text="1" />
                                                            </div>
                                                        </div>

                                                        <!-- BOTÓN GUARDAR -->
                                                        <div class="d-flex justify-content-between align-items-center border-top pt-3 bg-light p-3 rounded-3 mt-4">
                                                            <span class="text-muted small">
                                                                <i class="fas fa-info-circle me-1"></i>Verifique que todos los datos estén correctos antes de guardar.
                                                            </span>
                                                            <asp:Button ID="btnFinalizar1" OnClick="btnFinalizar_Click" runat="server"
                                                                CssClass="btn btn-success px-4 py-2 rounded-pill fw-bold shadow-sm"
                                                                Text="💾 GUARDAR DATOS" />
                                                        </div>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </asp:View>

                                    <!-- ═══════════════════════════════════════════════════════
                                         VISTA 2: EDUCACIÓN FORMAL
                                         ═══════════════════════════════════════════════════════ -->
                                    <asp:View ID="viewOpcion2" runat="server">
                                        <div class="card border-0">
                                            <div class="card-body p-4">
                                                <div class="d-flex align-items-center justify-content-between border-bottom pb-3 mb-4">
                                                    <h5 class="fw-bold text-primary mb-0">
                                                        <i class="fas fa-tasks fs-4 me-2"></i>EDUCACIÓN FORMAL
                                                    </h5>
                                                </div>

                                                <asp:UpdatePanel ID="upEducacionFormal" runat="server">
                                                    <ContentTemplate>

                                                        <asp:HiddenField ID="hf_ef_id" runat="server" />

                                                        <h6 class="text-muted text-uppercase mb-3">
                                                            <i class="fas fa-graduation-cap me-1"></i>Datos de Formación Académica
                                                        </h6>

                                                        <div class="row g-3 mb-3">
                                                            <div class="col-lg-4 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_ef_nivel_instruccion" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-layer-group me-1 text-primary"></i>Nivel de Instrucción <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_ef_nivel_instruccion" runat="server"
                                                                    CssClass="form-control form-select select2">
                                                                    <asp:ListItem Text="" Value="" />
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-4 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_ef_centro_form" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-university me-1 text-primary"></i>Centro de Formación <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_ef_centro_form" runat="server"
                                                                    CssClass="form-control form-select select2">
                                                                    <asp:ListItem Text="" Value="" />
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-4 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_ef_carrera_especialidad" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-book me-1 text-primary"></i>Carrera/Especialidad <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_ef_carrera_especialidad" runat="server"
                                                                    CssClass="form-control form-select select2">
                                                                    <asp:ListItem Text="" Value="" />
                                                                </asp:DropDownList>
                                                            </div>
                                                        </div>

                                                        <div class="row g-3 mb-3">
                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_ef_fecha_ini" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                <i class="fas fa-calendar me-1 text-primary"></i>Fecha Inicio <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_ef_fecha_ini" runat="server"
                                                                    TextMode="Date"
                                                                    CssClass="form-control" onchange="validarFechaInicioObligatoria(this);" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_ef_fecha_fin" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-calendar-alt me-1 text-primary"></i>Fecha Fin <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_ef_fecha_fin" runat="server"
                                                                    TextMode="Date"
                                                                    CssClass="form-control" onchange="validarFechaInicioObligatoria(this);" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_ef_anios_estudio" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-clock me-1 text-primary"></i>Años Estudio
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_ef_anios_estudio" runat="server"
                                                                    CssClass="form-control"
                                                                    MaxLength="2"
                                                                    Placeholder="Ej. 5"
                                                                    oninput="soloNumerosInput(this, 2);"
                                                                    onkeypress="return soloNumerosKey(event);" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_ef_fecha_titulo_obtenido" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-calendar-alt me-1 text-primary"></i>Fecha Título
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_ef_fecha_titulo_obtenido" runat="server"
                                                                    TextMode="Date"
                                                                    CssClass="form-control"
                                                                    onchange="toggleNroTitulo(this);" />
                                                            </div>
                                                        </div>

                                                        <div class="row g-3 mb-4">
                                                            <div class="col-lg-4 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_ef_nro_titulo" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                <i class="fas fa-hashtag me-1 text-primary"></i>Nº Título <span class="text-danger" id="lbl_ef_nro_titulo_obligatorio" style="display:none;">*</span>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_ef_nro_titulo" runat="server"
                                                                    CssClass="form-control"
                                                                    MaxLength="50"
                                                                    Placeholder="Ej. 123456" />
                                                            </div>

                                                            <div class="col-lg-8 col-md-12">
                                                                <asp:Label AssociatedControlID="txt_ef_descripcion" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-comment me-1 text-primary"></i>Descripción Formación <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_ef_descripcion" runat="server"
                                                                    TextMode="MultiLine"
                                                                    Rows="2"
                                                                    MaxLength="250"
                                                                    CssClass="form-control"
                                                                    Placeholder="Describa brevemente la formación (obligatorio)" />
                                                            </div>
                                                        </div>

                                                        <div class="d-flex justify-content-end gap-2 mb-4">
                                                            <asp:Button ID="btn_ef_cancelar" runat="server"
                                                                OnClick="btn_ef_cancelar_Click"
                                                                CssClass="btn btn-outline-secondary px-4 rounded-pill"
                                                                Text="🗑️ Cancelar Edición"
                                                                Visible="false" />

                                                            <asp:Button ID="btn_ef_registrar" runat="server"
                                                                OnClick="btn_ef_registrar_Click"
                                                                CssClass="btn btn-success px-4 rounded-pill fw-bold shadow-sm"
                                                                Text="💾 REGISTRAR FORMACIÓN" />
                                                        </div>

                                                        <hr />

                                                        <h6 class="text-muted text-uppercase mb-3">
                                                            <i class="fas fa-list me-1"></i>Formaciones Registradas
                                                        </h6>

                                                        <div class="table-responsive">
                                                            <asp:GridView ID="gvEducacionFormalKardex" runat="server"
                                                                CssClass="table table-bordered table-hover table-striped"
                                                                AutoGenerateColumns="false"
                                                                DataKeyNames="ef_id"
                                                                OnRowCommand="gvEducacionFormalKardex_RowCommand"
                                                                OnPageIndexChanging="gvEducacionFormalKardex_PageIndexChanging"
                                                                AllowPaging="true"
                                                                PageSize="5"
                                                                EmptyDataText="No existen formaciones registradas aún.">
                                                                <Columns>
                                                                    <asp:BoundField DataField="nivel_instruccion" HeaderText="Nivel Instrucción"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:BoundField DataField="centro_form_nombre" HeaderText="Centro de Formación"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-start" />

                                                                    <asp:BoundField DataField="carrera_especialidad_nombre" HeaderText="Carrera/Especialidad"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-start" />

                                                                    <asp:BoundField DataField="ef_fecha_ini" HeaderText="Desde" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:BoundField DataField="ef_fecha_fin" HeaderText="Hasta" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:BoundField DataField="ef_fecha_titulo_obtenido" HeaderText="Fecha Título" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="false"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:BoundField DataField="ef_anios_estudio" HeaderText="Años"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:BoundField DataField="ef_descripcion" HeaderText="Descripción"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:TemplateField HeaderText="Opciones"
                                                                        HeaderStyle-CssClass="text-center"
                                                                        ItemStyle-CssClass="text-center"
                                                                        HeaderStyle-Width="130px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server"
                                                                                CommandName="GetEdit"
                                                                                CommandArgument='<%# Eval("ef_id") %>'
                                                                                CssClass="btn btn-warning btn-sm"
                                                                                Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>"
                                                                                data-toggle='tooltip' data-placement='top' title='Editar' />

                                                                            <asp:LinkButton runat="server"
                                                                                CommandName="GetDelete"
                                                                                CommandArgument='<%# Eval("ef_id") %>'
                                                                                CssClass="btn btn-danger btn-sm"
                                                                                Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>"
                                                                                data-toggle='tooltip' data-placement='top' title='Eliminar' />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>

                                                        <div class="d-flex justify-content-between align-items-center mt-2">
                                                            <asp:Literal ID="ltlInfoPaginacionEducacion" runat="server" />
                                                        </div>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <!-- MODAL ELIMINACIÓN EDUCACIÓN -->
                                                <div class="modal fade" id="modalEliminarEducacionKardex" tabindex="-1"
                                                    role="dialog" aria-hidden="true" data-backdrop="static">
                                                    <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
                                                        <div class="modal-content border-0 shadow-lg">
                                                            <div class="modal-body text-center py-4 px-3">
                                                                <i class="fas fa-trash-alt text-danger mb-3" style="font-size: 2.5rem;"></i>
                                                                <h6 class="mb-2 fw-bold text-dark">¿Eliminar formación?</h6>
                                                                <p class="small text-muted mb-0">
                                                                    <asp:Literal ID="ltlFormacionEliminar" runat="server" />
                                                                </p>
                                                                <p class="small text-muted mb-0">
                                                                    <i class="fas fa-exclamation-triangle text-warning me-1"></i>
                                                                    Esta acción no se puede deshacer
                                                                </p>
                                                            </div>
                                                            <div class="modal-footer border-0 justify-content-center pt-0 pb-3 gap-2">
                                                                <button type="button" class="btn btn-sm btn-light px-3" data-dismiss="modal">
                                                                    Cancelar
                                                                </button>
                                                                <asp:Button ID="btnConfirmarEliminarEducacion" runat="server"
                                                                    OnClick="btnConfirmarEliminarEducacion_Click"
                                                                    CssClass="btn btn-sm btn-danger px-3"
                                                                    Text="Eliminar" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!--
                                                <div class="d-flex justify-content-end border-top pt-3 mt-4">
                                                    <asp:Button ID="btnFinalizar2" OnClick="btnFinalizar_Click" runat="server"
                                                        CssClass="btn btn-primary px-4 py-2 rounded-pill fw-bold shadow-sm"
                                                        Text="FINALIZAR OPCIÓN 2" />
                                                </div>
                                                    -->
                                            </div>
                                        </div>
                                    </asp:View>

                                    <!-- ═══════════════════════════════════════════════════════
                                         VISTA 3: DATOS FAMILIARES
                                         ═══════════════════════════════════════════════════════ -->
                                    <asp:View ID="viewOpcion3" runat="server">
                                        <div class="card border-0">
                                            <div class="card-body p-4">

                                                <div class="alert alert-light border-start border-4 border-success" role="alert">
                                                    <h5 class="alert-heading">
                                                        <i class="fas fa-info-circle me-2"></i>Declaración de Parentesco
                                                    </h5>
                                                    <p class="mb-2 small">
                                                        De acuerdo a lo señalado en el parágrafo III del artículo 236 de la Constitución Política del Estado,
                                                        el Reglamento Interno de Personal de la Cámara de Senadores vigente establece la <strong>prohibición</strong>
                                                        de ejercer la función pública cuando las servidoras o los servidores públicos tengan parentesco hasta
                                                        el <strong>cuarto grado de consanguinidad</strong> y <strong>segundo de afinidad</strong> con otro(a)
                                                        servidor(a) de la Institución.
                                                    </p>
                                                    <div class="row g-2 mt-2">
                                                        <div class="col-md-6">
                                                            <span class="badge bg-danger w-100 text-start p-2">
                                                                <strong>4to grado por Consanguinidad:</strong><br />
                                                                <small>Abuelo(a) / Padre / Madre / Hermano(a) / Nieto(a) / Tío(a) / Sobrino(a) / Primo(a)</small>
                                                            </span>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <span class="badge bg-warning w-100 text-start p-2">
                                                                <strong>2do grado por Afinidad:</strong><br />
                                                                <small>Suegro(a) / Consuegro(a) / Nuera / Yerno / Cuñado(a)</small>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <p class="mb-0 small mt-2"><i class="fas fa-hand-point-right me-1"></i>En el siguiente formulario registre los datos requeridos.</p>
                                                </div>

                                                <asp:UpdatePanel ID="upFamiliaresKardex" runat="server">
                                                    <ContentTemplate>

                                                        <asp:HiddenField ID="hf_pf_id" runat="server" />

                                                        <h6 class="text-muted text-uppercase mb-3">
                                                            <i class="fas fa-user-plus me-1"></i>Datos del Familiar
                                                        </h6>

                                                        <div class="row g-3 mb-3">
                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_pf_paterno" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-pen me-1 text-primary"></i>Primer Apellido <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_pf_paterno" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. Pérez" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_pf_materno" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-pen me-1 text-primary"></i>Segundo Apellido <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_pf_materno" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. García" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_pf_nombres" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-user me-1 text-primary"></i>Nombres <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_pf_nombres" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. Juan Carlos" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_pf_ap_esposo" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-user-friends me-1 text-primary"></i>Ape. Esposo(a) <small class="text-muted">(op)</small>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_pf_ap_esposo" runat="server"
                                                                    CssClass="form-control"
                                                                    Placeholder="Ej. López" />
                                                            </div>
                                                        </div>

                                                        <div class="row g-3 mb-3">
                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_pf_fecha_nac" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-calendar me-1 text-primary"></i>Fecha Nacimiento
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_pf_fecha_nac" runat="server"
                                                                    TextMode="Date"
                                                                    CssClass="form-control"
                                                                    onchange="validarFechaNacimiento(this);" />
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_pf_tipo_parentesco" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-sitemap me-1 text-primary"></i>Tipo de Parentesco <span class="text-danger">*</span>
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_pf_tipo_parentesco" runat="server"
                                                                    CssClass="form-control form-select select2">
                                                                    <asp:ListItem Text="" Value="" />
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="ddl_pf_sexo" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-venus-mars me-1 text-primary"></i>Genero
                                                                </asp:Label>
                                                                <asp:DropDownList ID="ddl_pf_sexo" runat="server"
                                                                    CssClass="form-control form-select select2">
                                                                    <asp:ListItem Text="-- Seleccione --" Value="0" />
                                                                </asp:DropDownList>
                                                            </div>

                                                            <div class="col-lg-3 col-md-6">
                                                                <asp:Label AssociatedControlID="txt_pf_ci" runat="server" CssClass="form-label text-dark fw-bold mb-1">
                                                                    <i class="fas fa-id-card me-1 text-primary"></i>CI <small class="text-muted">(solo números, máx. 10)</small>
                                                                </asp:Label>
                                                                <asp:TextBox ID="txt_pf_ci" runat="server"
                                                                    CssClass="form-control"
                                                                    MaxLength="10"
                                                                    Placeholder="Ej. 1234567"
                                                                    oninput="validarCI(this);"
                                                                    onkeypress="return soloNumeros(event);" />
                                                            </div>
                                                        </div>

                                                        <div class="d-flex justify-content-end gap-2 mb-4">
                                                            <asp:Button ID="btn_pf_cancelar" runat="server"
                                                                OnClick="btn_pf_cancelar_Click"
                                                                CssClass="btn btn-outline-secondary px-4 rounded-pill"
                                                                Text="🗑️ Cancelar Edición"
                                                                Visible="false" />

                                                            <asp:Button ID="btn_pf_registrar" runat="server"
                                                                OnClick="btn_pf_registrar_Click"
                                                                OnClientClick="return validarFormularioFamiliar();"
                                                                CssClass="btn btn-success px-4 rounded-pill fw-bold shadow-sm"
                                                                Text="💾 REGISTRAR FAMILIAR" />
                                                        </div>

                                                        <hr />

                                                        <h6 class="text-muted text-uppercase mb-3">
                                                            <i class="fas fa-list me-1"></i>Familiares Registrados
                                                        </h6>

                                                        <div class="table-responsive">
                                                            <asp:GridView ID="gvFamiliaresKardex" runat="server"
                                                                CssClass="table table-bordered table-hover table-striped"
                                                                AutoGenerateColumns="false"
                                                                DataKeyNames="pf_id"
                                                                OnRowCommand="gvFamiliaresKardex_RowCommand"
                                                                OnPageIndexChanging="gvFamiliaresKardex_PageIndexChanging"
                                                                AllowPaging="true"
                                                                PageSize="5"
                                                                EmptyDataText="No existen familiares registrados aún.">
                                                                <Columns>
                                                                    <asp:BoundField DataField="nombre_completo" HeaderText="Nombre Completo" />
                                                                    <asp:BoundField DataField="pf_fecha_nac_formato" HeaderText="Fecha Nacimiento" />
                                                                    <asp:BoundField DataField="pf_nom_parentesco" HeaderText="Grado de Parentesco" />

                                                                    <asp:TemplateField HeaderText="Opciones"
                                                                        HeaderStyle-CssClass="text-center"
                                                                        ItemStyle-CssClass="text-center"
                                                                        HeaderStyle-Width="130px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server"
                                                                                CommandName="GetEdit"
                                                                                CommandArgument='<%# Eval("pf_id") %>'
                                                                                CssClass="btn btn-warning btn-sm"
                                                                                Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" />

                                                                            <asp:LinkButton runat="server"
                                                                                CommandName="GetDelete"
                                                                                CommandArgument='<%# Eval("pf_id") %>'
                                                                                CssClass="btn btn-danger btn-sm"
                                                                                Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>

                                                        <div class="d-flex justify-content-between align-items-center mt-2">
                                                            <asp:Literal ID="ltlInfoPaginacionFamiliares" runat="server" />
                                                        </div>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <!-- MODAL ELIMINACIÓN FAMILIAR -->
                                                <div class="modal fade" id="modalEliminarFamiliarKardex" tabindex="-1"
                                                    role="dialog" aria-labelledby="modalEliminarFamiliarLabel"
                                                    aria-hidden="true" data-backdrop="static">
                                                    <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
                                                        <div class="modal-content border-0 shadow-lg">
                                                            <div class="modal-body text-center py-4 px-3">
                                                                <i class="fas fa-trash-alt text-danger mb-3" style="font-size: 2.5rem;"></i>
                                                                <h6 class="mb-2 fw-bold text-dark">¿Está seguro de ELIMINAR al familiar registrado?
                                                                </h6>
                                                                <p class="small text-muted mb-2">
                                                                    <asp:Literal ID="ltlFamiliarEliminar" runat="server" />
                                                                </p>
                                                                <p class="small text-muted mb-0">
                                                                    <i class="fas fa-exclamation-triangle text-warning me-1"></i>
                                                                    Esta acción no se puede deshacer
                                                                </p>
                                                            </div>
                                                            <div class="modal-footer border-0 justify-content-center pt-0 pb-3 gap-2">
                                                                <button type="button" class="btn btn-sm btn-light px-3" data-dismiss="modal">
                                                                    Cancelar
                                                                </button>
                                                                <asp:Button ID="btnConfirmarEliminarFamiliar" runat="server"
                                                                    OnClick="btnConfirmarEliminarFamiliar_Click"
                                                                    CssClass="btn btn-sm btn-danger px-3"
                                                                    Text="Eliminar" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!--
                                                <div class="d-flex justify-content-end border-top pt-3 mt-4">
                                                    <asp:Button ID="btnFinalizar3" OnClick="btnFinalizar_Click" runat="server"
                                                        CssClass="btn btn-primary px-4 py-2 rounded-pill fw-bold shadow-sm"
                                                        Text="FINALIZAR OPCIÓN 3" />
                                                </div>
                                                    -->
                                            </div>
                                        </div>
                                    </asp:View>

                                    <!-- ═══════════════════════════════════════════════════════
                                         VISTA 4: DOBLE PERCEPCIÓN
                                         ═══════════════════════════════════════════════════════ -->
                                    <asp:View ID="viewOpcion4" runat="server">
                                        <div class="card border-0">
                                            <div class="card-body p-4">

                                                <div class="d-flex align-items-center justify-content-between border-bottom pb-3 mb-4">
                                                    <h5 class="fw-bold text-primary mb-0">
                                                        <i class="fas fa-sliders-h fs-4 me-2"></i>DOBLE PERCEPCIÓN
                                                    </h5>
                                                </div>

                                                <div class="alert alert-light border-start border-4 border-info" role="alert">
                                                    <h5 class="alert-heading">
                                                        <i class="fas fa-file-signature me-2"></i>DECLARACIÓN DE INGRESOS PERCIBIDOS
                                                    </h5>
                                                    <p class="mb-2">
                                                        De conformidad a la normativa vigente referida a la Doble Percepción, en honor a la verdad declaro que:
                                                    </p>
                                                    <p class="mb-0 small text-muted">
                                                        <i class="fas fa-info-circle me-1"></i>
                                                        Complete la información a continuación y haga clic en "REGISTRAR" para guardar la declaración.
                                                    </p>
                                                </div>

                                                <asp:UpdatePanel ID="upDoblePercepcion" runat="server">
                                                    <ContentTemplate>

                                                        <asp:HiddenField ID="hf_dp_id" runat="server" />

                                                        <div class="card bg-light border-0 mb-4">
                                                            <div class="card-body">
                                                                <div class="card bg-light border-0 shadow-sm mb-3">
                                                                    <div class="card-body p-1">
                                                                        <div class="d-flex align-items-start">
                                                                            <div class="me-3 mt-1">
                                                                                <i class="fas fa-question-circle text-primary fs-4"></i>
                                                                            </div>
                                                                            <div>
                                                                                <h6 class="fw-bold text-dark lh-base mb-1">¿Percibe usted más de una remuneración por concepto de ingresos como servidor público, rentas del Sistema de Reparto o compensación de cotizaciones mensual, dietas u otros pagos por prestación de servicios con cargo a recursos públicos?
                                                                                </h6>
                                                                                <small class="text-muted d-block mt-1">
                                                                                    <i class="fas fa-info-circle me-1"></i>
                                                                                    Marque la opción correspondiente según lo estipulado por la normativa de Doble Percepción.
                                                                                </small>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="row">
                                                                    <div class="col-md-6">
                                                                        <asp:DropDownList ID="ddl_dp_tiene_docencia" runat="server"
                                                                            CssClass="form-control form-select select2"
                                                                            AutoPostBack="true"
                                                                            OnSelectedIndexChanged="ddl_dp_tiene_docencia_SelectedIndexChanged">
                                                                            <asp:ListItem Text="" Value="" />
                                                                            <asp:ListItem Text="Sí" Value="1" />
                                                                            <asp:ListItem Text="No" Value="0" />
                                                                        </asp:DropDownList>
                                                                    </div>
                                                                    <div class="col-md-6">
                                                                        <span class="text-muted small">
                                                                            <i class="fas fa-info-circle me-1"></i>
                                                                            Si selecciona "Sí", debe completar los datos de docencia.
                                                                        </span>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <asp:Panel ID="pnlDatosDocencia" runat="server" Visible="false">

                                                            <h6 class="text-muted text-uppercase mb-3">
                                                                <i class="fas fa-graduation-cap me-1"></i>Datos de Docencia
                                                            </h6>

                                                            <div class="row">
                                                                <div class="col-lg-6 col-md-6">
                                                                    <asp:Label AssociatedControlID="txt_dp_universidad" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-university me-1 text-primary"></i>Entidad Pública
                                                                    </asp:Label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text">
                                                                                <i class="fas fa-university"></i>
                                                                            </span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_dp_universidad" runat="server"
                                                                            CssClass="form-control"
                                                                            Placeholder="Ej. Universidad Mayor de San Andrés"
                                                                            MaxLength="200" />
                                                                    </div>
                                                                </div>

                                                                <div class="col-lg-3 col-md-6">
                                                                    <asp:Label AssociatedControlID="txt_dp_total_ganado_mes" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-money-bill me-1 text-primary"></i>Total Ganado Mes (Bs) <span class="text-danger">*</span>
                                                                    </asp:Label>
                                                                    <asp:TextBox ID="txt_dp_total_ganado_mes" runat="server"
                                                                        CssClass="form-control"
                                                                        Placeholder="0.00"
                                                                        oninput="soloDecimalesInput(this, 2, 6);"
                                                                        onkeypress="return soloDecimalesKey(event);"
                                                                        MaxLength="9" />
                                                                </div>

                                                                <div class="col-lg-3 col-md-6">
                                                                    <asp:Label AssociatedControlID="txt_dp_aguinaldo" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-coins me-1 text-primary"></i>Aguinaldo (Bs)
                                                                    </asp:Label>
                                                                    <asp:TextBox ID="txt_dp_aguinaldo" runat="server"
                                                                        CssClass="form-control"
                                                                        Placeholder="0.00"
                                                                        oninput="soloDecimalesInput(this, 2, 6);"
                                                                        onkeypress="return soloDecimalesKey(event);"
                                                                        MaxLength="9" />
                                                                </div>
                                                            </div>

                                                            <div class="row g-3 mb-3">
                                                                <div class="col-lg-3 col-md-6" runat="server" visible="false">
                                                                    <asp:Label AssociatedControlID="txt_dp_otros_ingresos" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-wallet me-1 text-primary"></i>Otros Ingresos (Bs)
                                                                    </asp:Label>
                                                                    <asp:TextBox ID="txt_dp_otros_ingresos" runat="server"
                                                                        CssClass="form-control"
                                                                        Placeholder="0.00"
                                                                        oninput="soloDecimalesInput(this, 2, 6);"
                                                                        onkeypress="return soloDecimalesKey(event);"
                                                                        MaxLength="9" />
                                                                </div>

                                                                <div class="col-lg-3 col-md-6">
                                                                    <asp:Label AssociatedControlID="txt_dp_total_horas" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-clock me-1 text-primary"></i>Total Horas <span class="text-danger">*</span>
                                                                    </asp:Label>
                                                                    <asp:TextBox ID="txt_dp_total_horas" runat="server"
                                                                        CssClass="form-control"
                                                                        Placeholder="0"
                                                                        oninput="soloEnterosInput(this, 3);"
                                                                        onkeypress="return soloNumerosKey(event);" />
                                                                </div>

                                                                <div class="col-lg-3 col-md-6">
                                                                    <asp:Label AssociatedControlID="txt_dp_numero_materias" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-book me-1 text-primary"></i>Nº de Materias <span class="text-danger">*</span>
                                                                    </asp:Label>
                                                                    <asp:TextBox ID="txt_dp_numero_materias" runat="server"
                                                                        CssClass="form-control"
                                                                        Placeholder="0"
                                                                        oninput="soloEnterosInput(this, 2);"
                                                                        onkeypress="return soloNumerosKey(event);" />
                                                                </div>

                                                                <div class="col-lg-3 col-md-6">
                                                                    <asp:Label AssociatedControlID="ddl_dp_tipo_jornada" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-sun me-1 text-primary"></i>Tipo Jornada <span class="text-danger">*</span>
                                                                    </asp:Label>
                                                                    <asp:DropDownList ID="ddl_dp_tipo_jornada" runat="server"
                                                                        CssClass="form-control form-select">
                                                                        <asp:ListItem Text="" Value="" />
                                                                        <asp:ListItem Text="Mañana" Value="1" />
                                                                        <asp:ListItem Text="Tarde" Value="2" />
                                                                        <asp:ListItem Text="Noche" Value="3" />
                                                                    </asp:DropDownList>
                                                                </div>
                                                            </div>

                                                            <div class="row g-3 mb-3">
                                                                <div class="col-lg-3 col-md-6">
                                                                    <asp:Label AssociatedControlID="txt_dp_fecha_ini" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-calendar me-1 text-primary"></i>Fecha Inicio <span class="text-danger">*</span>
                                                                    </asp:Label>
                                                                    <asp:TextBox ID="txt_dp_fecha_ini" runat="server"
                                                                        TextMode="Date"
                                                                        CssClass="form-control" />
                                                                </div>

                                                                <div class="col-lg-3 col-md-6">
                                                                    <asp:Label AssociatedControlID="txt_dp_fecha_fin" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-calendar-alt me-1 text-primary"></i>Fecha Fin
                                                                    </asp:Label>
                                                                    <asp:TextBox ID="txt_dp_fecha_fin" runat="server"
                                                                        TextMode="Date"
                                                                        CssClass="form-control" />
                                                                </div>
                                                            </div>

                                                            <div class="row g-3 mb-4">
                                                                <div class="col-lg-6 col-md-6">
                                                                    <asp:Label AssociatedControlID="txt_dp_horario" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-clock me-1 text-primary"></i>Horario <span class="text-danger">*</span>
                                                                    </asp:Label>
                                                                    <asp:TextBox ID="txt_dp_horario" runat="server"
                                                                        TextMode="MultiLine"
                                                                        Rows="2"
                                                                        CssClass="form-control"
                                                                        Placeholder="Ej. Lunes y Miércoles 19:00 - 21:00" />
                                                                </div>

                                                                <div class="col-lg-6 col-md-6">
                                                                    <asp:Label AssociatedControlID="txt_dp_materias" runat="server"
                                                                        CssClass="form-label text-dark fw-bold mb-1">
                                                                        <i class="fas fa-book-open me-1 text-primary"></i>Materias
                                                                    </asp:Label>
                                                                    <asp:TextBox ID="txt_dp_materias" runat="server"
                                                                        TextMode="MultiLine"
                                                                        Rows="2"
                                                                        CssClass="form-control"
                                                                        Placeholder="Ej. Programación I, Base de Datos" />
                                                                </div>
                                                            </div>

                                                        </asp:Panel>

                                                        <div class="d-flex justify-content-end gap-2 mb-4">
                                                            <asp:Button ID="btn_dp_cancelar" runat="server"
                                                                OnClick="btn_dp_cancelar_Click"
                                                                CssClass="btn btn-outline-secondary px-4 rounded-pill"
                                                                Text="🗑️ Cancelar Edición"
                                                                Visible="false" />

                                                            <asp:Button ID="btn_dp_registrar" runat="server"
                                                                OnClick="btn_dp_registrar_Click"
                                                                CssClass="btn btn-success px-4 rounded-pill fw-bold shadow-sm"
                                                                Text="💾 REGISTRAR DECLARACIÓN" />
                                                        </div>

                                                        <hr />

                                                        <h6 class="text-muted text-uppercase mb-3">
                                                            <i class="fas fa-list me-1"></i>Declaraciones Registradas
                                                        </h6>

                                                        <div class="table-responsive">
                                                            <asp:GridView ID="gvDoblePercepcion" runat="server"
                                                                CssClass="table table-bordered table-hover table-striped"
                                                                AutoGenerateColumns="false"
                                                                DataKeyNames="dp_id"
                                                                OnRowCommand="gvDoblePercepcion_RowCommand"
                                                                OnPageIndexChanging="gvDoblePercepcion_PageIndexChanging"
                                                                AllowPaging="true"
                                                                PageSize="5"
                                                                EmptyDataText="No existen declaraciones registradas aún.">
                                                                <Columns>
                                                                    <asp:BoundField DataField="dp_docente_lit" HeaderText="¿Docencia?"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:BoundField DataField="dp_universidad" HeaderText="Universidad"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-start" />

                                                                    <asp:BoundField DataField="dp_total_ganado_mes" HeaderText="Total Ganado"
                                                                        DataFormatString="{0:C}"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:BoundField DataField="dp_total_horas" HeaderText="Horas"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:BoundField DataField="dp_fecha_ini_formato" HeaderText="Inicio"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:BoundField DataField="dp_fecha_fin_formato" HeaderText="Fin"
                                                                        HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                                                    <asp:TemplateField HeaderText="Opciones"
                                                                        HeaderStyle-CssClass="text-center"
                                                                        ItemStyle-CssClass="text-center"
                                                                        HeaderStyle-Width="130px">
                                                                        <ItemTemplate>
                                                                            <asp:LinkButton runat="server"
                                                                                CommandName="GetEdit"
                                                                                CommandArgument='<%# Eval("dp_id") %>'
                                                                                CssClass="btn btn-warning btn-sm"
                                                                                Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" />

                                                                            <asp:LinkButton runat="server"
                                                                                CommandName="GetDelete"
                                                                                CommandArgument='<%# Eval("dp_id") %>'
                                                                                CssClass="btn btn-danger btn-sm"
                                                                                Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" />
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>

                                                        <div class="d-flex justify-content-between align-items-center mt-2">
                                                            <asp:Literal ID="ltlInfoPaginacionDoblePercepcion" runat="server" />
                                                        </div>

                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <!-- MODAL ELIMINACIÓN DOBLE PERCEPCIÓN -->
                                                <div class="modal fade" id="modalEliminarDoblePercepcion" tabindex="-1"
                                                    role="dialog" aria-hidden="true" data-backdrop="static">
                                                    <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
                                                        <div class="modal-content border-0 shadow-lg">
                                                            <div class="modal-body text-center py-4 px-3">
                                                                <i class="fas fa-trash-alt text-danger mb-3" style="font-size: 2.5rem;"></i>
                                                                <h6 class="mb-2 fw-bold text-dark">¿Eliminar declaración?</h6>
                                                                <p class="small text-muted mb-0">
                                                                    <asp:Literal ID="ltlDoblePercepcionEliminar" runat="server" />
                                                                </p>
                                                                <p class="small text-muted mb-0">
                                                                    <i class="fas fa-exclamation-triangle text-warning me-1"></i>
                                                                    Esta acción no se puede deshacer
                                                                </p>
                                                            </div>
                                                            <div class="modal-footer border-0 justify-content-center pt-0 pb-3 gap-2">
                                                                <button type="button" class="btn btn-sm btn-light px-3" data-dismiss="modal">
                                                                    Cancelar
                                                                </button>
                                                                <asp:Button ID="btnConfirmarEliminarDoblePercepcion" runat="server"
                                                                    OnClick="btnConfirmarEliminarDoblePercepcion_Click"
                                                                    CssClass="btn btn-sm btn-danger px-3"
                                                                    Text="Eliminar" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="d-flex justify-content-end border-top pt-3 mt-4">
                                                    <!--
                                                        <asp:Button ID="btnFinalizar4_1" OnClick="btnFinalizar_Click" runat="server"
                                                        CssClass="btn btn-outline-primary px-4 py-2 rounded-pill fw-bold shadow-sm"
                                                        Text="FINALIZAR PARCIAL" />
                                                        -->

                                                    <asp:Button ID="btnFinalizar4_2" runat="server"
                                                        OnClick="btnFinalizar_Click"
                                                        ClientIDMode="Static"
                                                        CssClass="btn btn-primary px-4 py-2 rounded-pill fw-bold shadow-sm ms-2 btn-finalizar-ddjj"
                                                        Text="🔒 FINALIZAR DECLARACIÓN JURADA" />
                                                </div>

                                            </div>
                                        </div>
                                    </asp:View>

                                </asp:MultiView>
                            </div>
                        </div>
                    </div>

                    <!-- BOTÓN IMPRIMIR -->
                    <div class="card-footer bg-light mt-3" runat="server" id="DivImprimirDDJJ" visible="false">
                        <asp:Button ID="btnImprimirDDJJ"
                            OnClick="btnImprimirDDJJ_Click"
                            CssClass="btn btn-success btn-lg rounded-pill w-100 py-3 fw-bold shadow-sm"
                            Text="🖨️ IMPRIMIR DECLARACIÓN JURADA"
                            runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <!-- PROGRESO -->
    <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelFiliacionUpdate" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <!-- ═══════════════════════════════════════════════════════════
         SCRIPTS: Select2 + Validaciones
         ═══════════════════════════════════════════════════════════ -->
    <script type="text/javascript">

        // ─── INICIALIZACIÓN DE SELECT2 ───
        (function () {
            'use strict';

            var SELECT2_CONFIG = {
                placeholder: { id: '', text: '🔍 Buscar...' },
                allowClear: false,
                width: '100%',
                minimumResultsForSearch: 0,
                language: {
                    noResults: function () { return 'No se encontraron resultados'; },
                    searching: function () { return 'Buscando...'; },
                    inputTooShort: function () { return 'Ingrese al menos 1 carácter'; }
                }
            };

            function initSelect2() {
                if (typeof jQuery === 'undefined' || typeof jQuery.fn.select2 === 'undefined') {
                    setTimeout(initSelect2, 200);
                    return;
                }

                var combos = jQuery('.select2');
                var inicializados = 0;

                combos.each(function () {
                    var combo = jQuery(this);

                    if (combo.hasClass('select2-hidden-accessible') || combo.data('select2')) {
                        try { combo.select2('destroy'); } catch (e) { }
                    }

                    if (combo.find('option').length === 0) return;

                    try {
                        combo.select2(SELECT2_CONFIG);
                        inicializados++;
                    } catch (e) {
                        console.error('❌ Error inicializando combo:', e);
                    }
                });
            }

            if (typeof jQuery !== 'undefined') {
                jQuery(document).ready(function () {
                    initSelect2();
                    setTimeout(initSelect2, 300);
                    setTimeout(initSelect2, 800);
                });
            } else {
                setTimeout(initSelect2, 200);
            }

            if (typeof Sys !== 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager) {
                Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                    setTimeout(initSelect2, 100);
                    setTimeout(initSelect2, 500);
                });
            }

            window.initSelect2 = initSelect2;
        })();

        // ─── VALIDACIONES NUMÉRICAS ───
        function soloDecimalesInput(input, maxDecimales, maxEnteros) {
            var valor = input.value.replace(/[^0-9.]/g, '');
            var partes = valor.split('.');

            if (partes.length > 2) valor = partes[0] + '.' + partes.slice(1).join('');

            partes = valor.split('.');
            if (maxEnteros && partes[0].length > maxEnteros) partes[0] = partes[0].substring(0, maxEnteros);
            if (partes.length === 2) partes[1] = partes[1].substring(0, maxDecimales || 2);

            valor = partes.join('.');
            if (input.value !== valor) input.value = valor;
        }

        function soloEnterosInput(input, maxDigitos) {
            var valor = input.value.replace(/[^0-9]/g, '');
            if (maxDigitos && valor.length > maxDigitos) valor = valor.substring(0, maxDigitos);
            if (input.value !== valor) input.value = valor;
        }

        function soloDecimalesKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode >= 48 && charCode <= 57) return true;
            if (charCode === 46 || charCode === 44) return true;
            if (charCode === 8 || charCode === 9 || charCode === 13 || charCode === 27 || charCode === 46) return true;
            if (charCode >= 35 && charCode <= 40) return true;
            if (evt.ctrlKey) return true;
            return false;
        }

        // ─── CONFIRMACIÓN FINALIZAR DDJJ ───
        // ─── CONFIRMACIÓN FINALIZAR DDJJ ───
        $(document).on('click', '.btn-finalizar-ddjj', function (e) {
            e.preventDefault();
            e.stopImmediatePropagation();

            var $btn = $(this);
            var uniqueID = $('#hf_uniqueid_finalizar').val();

            console.log('[DDJJ] uniqueID =', uniqueID);

            if (!uniqueID) {
                Swal.fire('Error', 'No se pudo identificar el botón.', 'error');
                return false;
            }

            Swal.fire({
                title: '¿Finalizar Declaración Jurada?',
                html: 'Su <b>Declaración Jurada</b> será finalizada y <b>no podrá ser editada</b>.<br><br>¿Desea finalizar?',
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#d33',
                cancelButtonColor: '#6c757d',
                confirmButtonText: '<i class="fas fa-check"></i> Sí, finalizar',
                cancelButtonText: '<i class="fas fa-times"></i> No, cancelar',
                reverseButtons: true,
                allowOutsideClick: false,
                allowEscapeKey: false,
                focusCancel: true
            }).then((result) => {
                console.log('[DDJJ] result =', result);

                // ✅ Compatibilidad SweetAlert 1.x y 2.x
                var confirmado = result.isConfirmed === true || result.value === true;

                if (confirmado) {
                    console.log('[DDJJ] ✅ Confirmado. Ejecutando __doPostBack con:', uniqueID);
                    __doPostBack(uniqueID, '');
                } else {
                    console.log('[DDJJ] ❌ Cancelado.');
                }
            });

            return false;
        });

        // Validar fechas de Educación Formal al cambiar
        $('#<%= txt_ef_fecha_ini.ClientID %>').on('change', validarFechasEducacion);
        $('#<%= txt_ef_fecha_fin.ClientID %>').on('change', validarFechasEducacion);
        $('#<%= txt_ef_fecha_titulo_obtenido.ClientID %>').on('change', validarFechasEducacion);

        function validarFechasEducacion() {
            var fIni = $('#<%= txt_ef_fecha_ini.ClientID %>').val();
            var fFin = $('#<%= txt_ef_fecha_fin.ClientID %>').val();
            var fTit = $('#<%= txt_ef_fecha_titulo_obtenido.ClientID %>').val();

            if (fIni && fFin && fIni > fFin) {
                Swal.fire('Atención', 'La Fecha Inicio no puede ser mayor que la Fecha Fin.', 'warning');
                $('#<%= txt_ef_fecha_fin.ClientID %>').val('');
                return false;
            }

            if (fTit && fFin && fTit < fFin) {
                Swal.fire('Atención', 'La Fecha Título no puede ser menor que la Fecha Fin.', 'warning');
                $('#<%= txt_ef_fecha_titulo_obtenido.ClientID %>').val('');
                return false;
            }
        }
        $('#<%= txt_dp_fecha_ini.ClientID %>').on('change', validarFechasDoblePercepcion);
        $('#<%= txt_dp_fecha_fin.ClientID %>').on('change', validarFechasDoblePercepcion);

        function validarFechasDoblePercepcion() {
            var fIni = $('#<%= txt_dp_fecha_ini.ClientID %>').val();
            var fFin = $('#<%= txt_dp_fecha_fin.ClientID %>').val();

            if (fIni && fFin && fIni > fFin) {
                Swal.fire('Atención', 'La Fecha Inicio no puede ser mayor que la Fecha Fin.', 'warning');
                $('#<%= txt_dp_fecha_fin.ClientID %>').val('');
                return false;
            }
        }
        function toggleNroTitulo(inputFecha) {
            var $fechaTitulo = $(inputFecha);
            var $nroTitulo = $('[id$="txt_ef_nro_titulo"]');
            var $asterisco = $('#lbl_ef_nro_titulo_obligatorio');
            var $label = $nroTitulo.closest('.col-lg-4').find('label');

            var tieneFecha = $fechaTitulo.val() !== '' && $fechaTitulo.val() !== null;

            if (tieneFecha) {
                $nroTitulo.prop('disabled', false);
                $nroTitulo.attr('placeholder', 'Ej. 123456 *');
                $asterisco.show();
                $label.css('color', '#dc3545');
            } else {
                $nroTitulo.val('');
                $nroTitulo.prop('disabled', true);
                $nroTitulo.attr('placeholder', 'Se habilita al ingresar Fecha Título');
                $asterisco.hide();
                $label.css('color', '');
            }
        }
    </script>
    <asp:HiddenField ID="hf_uniqueid_finalizar" runat="server" ClientIDMode="Static" />
</asp:Content>
