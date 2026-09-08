<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ContratacionModificacion.aspx.cs" Inherits="Precontrataciones_ContratacionModificacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanelModificacion">
        <ContentTemplate>
            <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%">
                <div class="container-fluid">
                    <div class="header-body">
                        <div class="row align-items-center py-4">
                            <div class="col-lg-12">
                                <h6 class="h2 text-light d-inline-block mb-0">Modificación de Contrato</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid mt--6">
                <!-- ============================================================ -->
                <!-- DATOS PERSONALES -->
                <!-- ============================================================ -->
                <div class="card">
                    <div class="card-header bg-info text-white">
                        <h4 class="mb-0"><i class="fas fa-id-card-alt mr-2"></i> Datos Personales</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Nombre Completo</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlNombreCompleto" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Fecha de Nacimiento</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlFechaNac" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Carnet de Identidad</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlCarnet" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label font-weight-bold">Sexo</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlSexo" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Correo Electrónico</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlEmail" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Teléfono</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlTelefono" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Celular</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlCelular" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label font-weight-bold">Estado Civil</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlEstadoCivil" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Ciudad de Residencia</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlCiudad" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Procedencia</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlNacionalidad" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                            <div class="col-lg-5">
                                <div class="content-text-label font-weight-bold">Dirección</div>
                                <div class="h5 font-weight-400 content-text">
                                    <asp:Literal ID="ltlDireccion" runat="server" Text="Cargando..." />
                                </div>
                            </div>
                        </div>
                        <asp:HiddenField ID="hfPerId" runat="server" />
                        <asp:HiddenField ID="hfCaId" runat="server" />
                    </div>
                </div>

                <!-- ============================================================ -->
                <!-- NOTA RRHH 02 - SOLICITUD DE MODIFICACIÓN DE CONTRATO -->
                <!-- ============================================================ -->
                <div class="card">
                    <div class="card-header bg-warning text-white">
                        <h4 class="mb-0"><i class="fas fa-edit mr-2"></i> NOTA RRHH 02 - Solicitud de Modificación de Contrato</h4>
                    </div>
                    <div class="card-body">
                        <!-- INFORMACIÓN -->
                        <div class="row">
                            <div class="col-12">
                                <div class="alert alert-info">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <i class="fas fa-info-circle mr-2"></i>
                                            <strong>Información:</strong> Complete los datos para realizar la modificación del contrato.
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="form-control-label">Lugar y Fecha</label>
                                    <asp:TextBox ID="txtLugarFecha" CssClass="form-control" Text="La Paz, " runat="server" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="form-control-label">
                                        <i class="fas fa-hashtag mr-1"></i> CITE / Número de Documento
                                        <span class="text-danger">*</span>
                                    </label>
                                    <asp:TextBox ID="txtCITE" CssClass="form-control" 
                                        placeholder="Ej: RRHH-001/2026" runat="server" />
                                    <small class="form-text text-muted">
                                        <i class="fas fa-info-circle"></i> 
                                        Este número se registrará como Número de Documento en la glosa
                                    </small>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <p><strong>Señor:</strong></p>
                                <p><strong>OFICIAL MAYOR</strong></p>
                                <p><strong>CÁMARA DE SENADORES</strong></p>
                                <p><strong>Presente.-</strong></p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-12">
                                <p><strong>De mi consideración:</strong></p>
                                <p>
                                    Mediante el presente, solicito a usted la Modificación al contrato No.
                                </p>
                            </div>
                        </div>

                        <!-- ============================================================ -->
                        <!-- INFORMACION DEL PUESTO ACTUAL -->
                        <!-- ============================================================ -->
                        <div class="row mt-3 mb-3">
                            <div class="col-12">
                                <div class="card">
                                    <div class="card-header bg-primary text-white">
                                        <h5 class="mb-0">
                                            <i class="fas fa-file-contract mr-2"></i> INFORMACIÓN DEL PUESTO ACTUAL
                                        </h5>
                                    </div>
                                    <div class="card-body p-0">
                                        <table class="table table-bordered table-hover mb-0 tabla-normal">
                                            <thead class="thead-light">
                                                <tr>
                                                    <th style="width:15%" class="text-center">Ítem</th>
                                                    <th style="width:25%">Puesto</th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr>
                                                    <td class="text-center align-middle">
                                                        <strong><asp:Literal ID="ltl_item" runat="server"></asp:Literal></strong>
                                                    </td>
                                                    <td class="align-middle">
                                                        <asp:Literal ID="ltl_puesto" runat="server"></asp:Literal>
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- ============================================================ -->
                        <!-- COPIA DEL CONTRATO VIGENTE -->
                        <!-- ============================================================ -->
                        <div class="card mt-3" style="border: 2px solid #dc3545;">
                            <div class="card-header bg-light" style="border-bottom: 2px solid #dc3545;">
                                <h5 class="text-danger font-weight-bold mb-0">
                                    <i class="fas fa-copy mr-2"></i> CONTRATO VIGENTE
                                    <span class="badge badge-danger ml-2">SOLO LECTURA - COPIA DE RESPALDO</span>
                                </h5>
                            </div>
                            <div class="card-body">
                                <!-- TABLA DE CARGO Y FECHAS -->
                                <div class="table-responsive">
                                    <table class="table table-bordered table-hover mb-0 tabla-normal">
                                        <thead class="thead-light">
                                            <tr>
                                                <th style="width:40%">CARGO</th>
                                                <th style="width:20%">SUELDO MENSUAL Bs.-</th>
                                                <th style="width:20%">FECHA DE INICIO</th>
                                                <th style="width:20%">FECHA DE CONCLUSIÓN</th>
                                            </tr>
                                        </thead>
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <asp:TextBox ID="txtVigenteCargo" CssClass="form-control" placeholder="Cargo Actual" readonly style="background-color: #f5f5f5;" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVigenteSueldo" CssClass="form-control" placeholder="0.00" readonly style="background-color: #f5f5f5;" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVigenteFechaInicio" TextMode="Date" CssClass="form-control" readonly style="background-color: #f5f5f5;" runat="server" />
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtVigenteFechaFin" TextMode="Date" CssClass="form-control" readonly style="background-color: #f5f5f5;" runat="server" />
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>

                                <!-- UNIDAD ORGANIZACIONAL VIGENTE -->
                                <div class="row">
                                    <div class="col-12">
                                        <div class="form-group">
                                            <label class="form-control-label"><strong>Unidad Organizacional (Actual):</strong></label>
                                            <asp:TextBox ID="txtVigenteUnidad" CssClass="form-control" placeholder="Unidad" readonly style="background-color: #f5f5f5;" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <!-- NIVEL SALARIAL Y CLASE -->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-control-label">Nivel Salarial Actual</label>
                                            <asp:TextBox ID="txtVigenteNivel" CssClass="form-control" placeholder="Nivel" readonly style="background-color: #f5f5f5;" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-control-label">Clase Actual</label>
                                            <asp:TextBox ID="txtVigenteClase" CssClass="form-control" placeholder="Clase" readonly style="background-color: #f5f5f5;" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <!-- ============================================================ -->
                                <!-- FORM. CPE-01 - DESCRIPTOR DE PUESTO (VIGENTE - SOLO LECTURA) -->
                                <!-- ============================================================ -->
                                <div class="card mt-3" style="border-left: 4px solid #dc3545;">
                                    <div class="card-header bg-light">
                                        <h6 class="text-danger font-weight-bold mb-0">
                                            <i class="fas fa-clipboard-list mr-2"></i> FORM. CPE-01 - Descriptor de Puesto (Vigente)
                                            <span class="badge badge-secondary ml-2">SOLO LECTURA</span>
                                        </h6>
                                    </div>
                                    <div class="card-body">
                                        <!-- DESCRIPCIÓN DEL PUESTO VIGENTE -->
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label class="form-control-label">Descripción del Puesto</label>
                                                    <asp:TextBox ID="txtVigenteDescripcionPuesto" CssClass="form-control" placeholder="Descripción del puesto..." readonly style="background-color: #f5f5f5;" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <!-- OBJETIVO O JUSTIFICACIÓN VIGENTE -->
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label class="form-control-label">Objetivo o Justificación de la Contratación</label>
                                                    <asp:TextBox ID="txtVigenteObjetivo" CssClass="form-control" placeholder="Objetivo o justificación..." readonly style="background-color: #f5f5f5;" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <!-- FUNCIONES VIGENTES -->
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="form-group">
                                                    <label class="form-control-label">Funciones</label>
                                                    <asp:TextBox ID="txtVigenteFunciones" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="Funciones..." readonly style="background-color: #f5f5f5;" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!-- ALERTA -->
                                <div class="row mt-3">
                                    <div class="col-12">
                                        <div class="alert alert-secondary">
                                            <i class="fas fa-info-circle"></i>
                                            <strong>Nota:</strong> Esta es la copia exacta del contrato actual. Todos los campos están en modo solo lectura.
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <hr class="my-4" style="border-top: 3px dashed #ffc107;" />

                        <!-- ============================================================ -->
                        <!-- FORMULARIO DE MODIFICACIÓN -->
                        <!-- ============================================================ -->
                        <asp:UpdatePanel ID="updFormularioModificacion" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="card" style="border: 2px solid #28a745;">
                                    <div class="card-header bg-light" style="border-bottom: 2px solid #28a745;">
                                        <h5 class="text-success font-weight-bold mb-0">
                                            <i class="fas fa-edit mr-2"></i> FORMULARIO DE MODIFICACIÓN
                                            <span class="badge badge-success ml-2">EDITABLE</span>
                                        </h5>
                                    </div>
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <table class="table table-bordered">
                                                <thead class="thead-light">
                                                    <tr>
                                                        <th style="width:40%">NUEVO CARGO <span class="text-danger">*</span></th>
                                                        <th style="width:20%">NUEVO SUELDO Bs.-</th>
                                                        <th style="width:20%">NUEVA FECHA INICIO <span class="text-danger">*</span></th>
                                                        <th style="width:20%">NUEVA FECHA FIN <span class="text-danger">*</span></th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td>
                                                            <asp:DropDownList ID="ddlNuevoCargo" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="ddlNuevoCargo_SelectedIndexChanged" runat="server">
                                                                <asp:ListItem Value="0">Seleccione Cargo...</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNuevoSueldo" CssClass="form-control" placeholder="0.00" ReadOnly="true" style="background-color: #f5f5f5;" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNuevoFechaInicio" TextMode="Date" CssClass="form-control" runat="server" />
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtNuevoFechaFin" TextMode="Date" CssClass="form-control" runat="server" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>

                                        <!-- NIVEL SALARIAL Y CLASE MODIFICACIÓN -->
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nuevo Nivel Salarial</label>
                                                    <asp:TextBox ID="txtNuevoNivel" CssClass="form-control" placeholder="Nivel" ReadOnly="true" style="background-color: #f5f5f5;" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label">Nueva Clase</label>
                                                    <asp:TextBox ID="txtNuevoClase" CssClass="form-control" placeholder="Clase" ReadOnly="true" style="background-color: #f5f5f5;" runat="server" />
                                                </div>
                                            </div>
                                        </div>

                                        <!-- ============================================================ -->
                                        <!-- FORM. CPE-01 - DESCRIPTOR DE PUESTO (MODIFICACIÓN - EDITABLE) -->
                                        <!-- ============================================================ -->
                                        <div class="card mt-3" style="border-left: 4px solid #28a745;">
                                            <div class="card-header bg-light">
                                                <h6 class="text-success font-weight-bold mb-0">
                                                    <i class="fas fa-clipboard-list mr-2"></i> FORM. CPE-01 - Descriptor de Puesto (Modificación)
                                                    <span class="badge badge-success ml-2">EDITABLE</span>
                                                </h6>
                                            </div>
                                            <div class="card-body">
                                                <!-- DESCRIPCIÓN DEL PUESTO -->
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="form-group">
                                                            <label class="form-control-label">Descripción del Puesto</label>
                                                            <asp:TextBox ID="txtDescripcionPuesto" CssClass="form-control" placeholder="Ingrese la descripción del puesto..." runat="server" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- OBJETIVO O JUSTIFICACIÓN -->
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="form-group">
                                                            <label class="form-control-label">Objetivo o Justificación de la Contratación</label>
                                                            <asp:TextBox ID="txtObjetivo" CssClass="form-control" placeholder="Ingrese el objetivo o justificación..." runat="server" />
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- FUNCIONES -->
                                                <div class="row">
                                                    <div class="col-12">
                                                        <div class="form-group">
                                                            <label class="form-control-label">Funciones</label>
                                                            <asp:TextBox ID="txtFunciones" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="1. ...&#10;2. ...&#10;3. ...&#10;4. ..." runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                        <!-- ALERTA -->
                                        <div class="row">
                                            <div class="col-12">
                                                <div class="alert alert-info">
                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            <i class="fas fa-info-circle mr-2"></i>
                                                            <strong>Nota:</strong> La modificación actualizará los datos del contrato.
                                                            <br />
                                                            <small>Se creará automáticamente un <strong>backup</strong> del contrato actual antes de guardar.</small>
                                                        </div>
                                                        <div class="col-md-4 text-right">
                                                            <span class="badge badge-success" style="font-size: 13px; padding: 6px 12px;">
                                                                <i class="fas fa-check-circle mr-1"></i> Backup automático
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <!-- ============================================================ -->
                <!-- BOTONES (SOLO UNA VEZ) -->
                <!-- ============================================================ -->
                <div class="card">
                    <div class="card-body text-right">
                        <a href="ListaSolicitudes.aspx" class="btn btn-default btn-lg"><i class="fas fa-times"></i> Cancelar</a>
                        <asp:LinkButton ID="btnGuardar" CssClass="btn btn-success btn-lg" Text="<i class='fas fa-save'></i> Guardar Modificación" OnClick="btnGuardar_Click" ValidationGroup="add" runat="server" />
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelModificacion" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />
    <style>
        .badge-warning {
            background-color: #ffc107;
            color: #212529;
        }
        .badge-success {
            background-color: #28a745;
            color: #fff;
        }
        .badge-info {
            background-color: #17a2b8;
            color: #fff;
        }
        .badge-danger {
            background-color: #dc3545;
            color: #fff;
        }
        .badge-secondary {
            background-color: #6c757d;
            color: #fff;
        }
        .alert-secondary {
            background-color: #e9ecef;
            border-color: #ced4da;
            color: #495057;
        }
        .card {
            border-radius: 0.25rem;
        }
        .card-header {
            border-bottom: 1px solid rgba(0,0,0,0.125);
        }
        .text-danger {
            color: #dc3545 !important;
        }
        .text-success {
            color: #28a745 !important;
        }
        .text-primary {
            color: #007bff !important;
        }
        .font-weight-bold {
            font-weight: 700 !important;
        }
        .content-text-label {
            font-weight: 600;
            color: #6c757d;
            font-size: 0.875rem;
        }
        .content-text {
            margin-top: 2px;
        }
        .text-right {
            text-align: right !important;
        }
        .align-middle {
            vertical-align: middle !important;
        }
        .text-center {
            text-align: center !important;
        }
        .select2-container {
            width: 100% !important;
            display: block !important;
        }
        .select2-container--default .select2-selection--single {
            height: 38px !important;
            border: 1px solid #ced4da !important;
            border-radius: 0.25rem !important;
            padding: 4px 8px !important;
            background-color: #fff !important;
        }
        .select2-container--default .select2-selection--single .select2-selection__rendered {
            line-height: 28px !important;
            color: #333 !important;
            padding-left: 4px !important;
        }
        .select2-container--default .select2-selection--single .select2-selection__arrow {
            height: 36px !important;
            position: absolute !important;
            top: 1px !important;
            right: 8px !important;
        }
        .select2-container--default .select2-selection--single .select2-selection__clear {
            position: absolute !important;
            right: 26px !important;
            top: 50% !important;
            transform: translateY(-50%) !important;
            margin-right: 0 !important;
            font-weight: bold !important;
            color: #000 !important;
            cursor: pointer !important;
        }
        .select2-dropdown {
            border: 1px solid #ced4da !important;
            border-radius: 0.25rem !important;
            box-shadow: 0 4px 10px rgba(0,0,0,0.12) !important;
            z-index: 9999 !important;
        }
        .select2-search--dropdown .select2-search__field {
            border: 1px solid #80bdff !important;
            border-radius: 0.25rem !important;
            padding: 6px 12px !important;
            outline: none !important;
            box-shadow: 0 0 0 0.2rem rgba(0,123,255,.25) !important;
        }
        .select2-container--default .select2-results__option--highlighted[aria-selected] {
            background-color: #d0e7f9 !important;
            color: #1b3a57 !important;
        }
        .table-responsive {
            overflow: visible !important;
        }
    </style>

    <script type="text/javascript">
        function initSelect2() {
            var $ddl = $('#<%= ddlNuevoCargo.ClientID %>');

            if ($ddl.length > 0) {
                if ($ddl.hasClass("select2-hidden-accessible")) {
                    $ddl.select2('destroy');
                }
                $ddl.next('.select2-container').remove();

                $ddl.select2({
                    placeholder: "Seleccione Cargo...",
                    allowClear: true,
                    width: '100%',
                    language: {
                        noResults: function () {
                            return "No se encontraron resultados";
                        }
                    }
                });
                $ddl.off('select2:select select2:unselect').on('select2:select select2:unselect', function (e) {
                    if (typeof __doPostBack === 'function') {
                        __doPostBack('<%= ddlNuevoCargo.UniqueID %>', '');
                    }
                });
            }
        }
        $(document).ready(function () {
            initSelect2();
        });
        if (typeof Sys !== 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_pageLoaded(function (sender, args) {
                initSelect2();
            });
        }
    </script>
</asp:Content>