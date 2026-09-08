<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ContratacionResolucion.aspx.cs" Inherits="Precontrataciones_ContratacionResolucion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanelResolucion" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%">
                <div class="container-fluid">
                    <div class="header-body">
                        <div class="row align-items-center py-4">
                            <div class="col-lg-12">
                                <h6 class="h2 text-light d-inline-block mb-0">Resolución de Contrato</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid mt--6">
                <!-- ============================================================ -->
                <!--                      DATOS PERSONALES                        -->
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
                    </div>
                </div>

                <!-- ============================================================ -->
                <!-- NOTA RRHH 03 - SOLICITUD DE RESOLUCIÓN DE CONTRATO -->
                <!-- ============================================================ -->
                <div class="card">
                    <div class="card-header bg-danger text-white">
                        <h4 class="mb-0"><i class="fas fa-times-circle mr-2"></i> NOTA RRHH 03 - Solicitud de Resolución de Contrato</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="form-control-label">Lugar y Fecha</label>
                                    <asp:TextBox ID="txtLugarFecha" CssClass="form-control" runat="server" />
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

                        <!-- Destinatario -->
                        <div class="row">
                            <div class="col-12">
                                <p><strong>Señor:</strong></p>
                                <p><strong>OFICIAL MAYOR</strong></p>
                                <p><strong>CÁMARA DE SENADORES</strong></p>
                                <p><strong>Presente.-</strong></p>
                            </div>
                        </div>

                        <!-- Cuerpo de la nota -->
                        <div class="row">
                            <div class="col-12">
                                <p><strong>De mi consideración:</strong></p>
                                <p>En el marco de la normativa legal e institucional vigente, se tiene a bien solicitar la resolución del contrato del siguiente personal:</p>
                            </div>
                        </div>

                        <!-- ============================================================ -->
                        <!-- INFORMACIÓN DEL CONTRATO VIGENTE -->
                        <!-- ============================================================ -->
                        <div class="row mt-3 mb-3">
                            <div class="col-12">
                                <div class="card">
                                    <div class="card-header bg-primary text-white">
                                        <h5 class="mb-0">
                                            <i class="fas fa-file-contract mr-2"></i> INFORMACIÓN DEL CONTRATO VIGENTE
                                        </h5>
                                    </div>
                                    <div class="card-body p-0">
                                        <div class="table-responsive">
                                            <table class="table table-bordered table-hover mb-0">
                                                <thead class="thead-light">
                                                    <tr>
                                                        <th style="width:20%; text-align: center; vertical-align: middle;">CARGO</th>
                                                        <th style="width:25%; text-align: center; vertical-align: middle;">SUELDO MENSUAL BS.-</th>
                                                        <th style="width:23%; text-align: center; vertical-align: middle;">FECHA DE INICIO</th>
                                                        <th style="width:32%; text-align: center; vertical-align: middle;">FECHA DE CONCLUSIÓN</th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td style="text-align: center; vertical-align: middle; padding: 10px 12px;">
                                                            <asp:TextBox ID="txtVigenteCargo" runat="server"
                                                                style="font-weight: 500; border: none; background: transparent; width: 100%; text-align: center; padding: 0; font-size: 0.95rem;"
                                                                ReadOnly="true" />
                                                        </td>
                                                        <td style="text-align: center; vertical-align: middle; padding: 10px 12px;">
                                                            <asp:TextBox ID="txtVigenteSueldo" runat="server"
                                                                style="font-weight: 500; border: none; background: transparent; width: 100%; text-align: center; padding: 0; font-size: 0.95rem;"
                                                                ReadOnly="true" />
                                                        </td>
                                                        <td style="text-align: center; vertical-align: middle; padding: 10px 12px;">
                                                            <asp:TextBox ID="txtVigenteFechaInicio" runat="server"
                                                                style="font-weight: 500; border: none; background: transparent; width: 100%; text-align: center; padding: 0; font-size: 0.95rem;"
                                                                ReadOnly="true" />
                                                        </td>
                                                        <td style="text-align: center; vertical-align: middle; padding: 10px 12px;">
                                                            <asp:TextBox ID="txtVigenteFechaFin" runat="server"
                                                                style="font-weight: 500; border: none; background: transparent; width: 100%; text-align: center; padding: 0; font-size: 0.95rem;"
                                                                ReadOnly="true" />
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                        <div style="padding: 10px 15px; background-color: #f8f9fa; border-top: 2px solid #dee2e6;">
                                            <span style="font-weight: 700; color: #495057; font-size: 0.9rem;">UNIDAD ORGANIZACIONAL (ACTUAL):</span>
                                            <asp:TextBox ID="txtVigenteUnidad" runat="server"
                                                style="font-weight: 500; border: none; background: transparent; padding: 0; word-wrap: break-word; white-space: normal; font-size: 0.95rem; width: 100%;"
                                                ReadOnly="true" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <!-- ============================================================ -->
                        <!-- TABLA DE DATOS DE MODIFICACIÓN (RESOLUCIÓN) -->
                        <!-- ============================================================ -->
                        <div class="row mt-3 mb-3">
                            <div class="col-12">
                                <div class="card">
                                    <div class="card-header bg-warning text-dark d-flex align-items-center justify-content-between">
                                        <h5 class="mb-0">
                                            <i class="fas fa-edit mr-2"></i> DATOS DE LA RESOLUCIÓN
                                        </h5>
                                        <span class="badge badge-danger badge-pill" style="font-size: 0.85rem; padding: 5px 15px;">
                                            <i class="fas fa-info-circle mr-1"></i> Tipo de Baja
                                        </span>
                                    </div>
                                    <div class="card-body p-0">
                                        <div class="table-responsive">
                                            <table class="table table-bordered table-hover mb-0">
                                                <thead class="thead-light">
                                                    <tr>
                                                        <th style="width:25%; text-align: center; vertical-align: middle;">
                                                            <i class="fas fa-exchange-alt mr-1"></i> TIPO DE MOVIMIENTO <span class="text-danger">*</span>
                                                        </th>
                                                        <th style="width:35%; text-align: center; vertical-align: middle;">
                                                            <i class="fas fa-calendar-plus mr-1"></i> FECHA DE SOLICITUD <span class="text-danger">*</span>
                                                        </th>
                                                        <th style="width:40%; text-align: center; vertical-align: middle;">
                                                            <i class="fas fa-calendar-times mr-1"></i> FECHA DE CONCLUSION <span class="text-danger">*</span>
                                                        </th>
                                                    </tr>
                                                </thead>
                                                <tbody>
                                                    <tr>
                                                        <td style="vertical-align: middle; padding: 8px 10px;">
                                                            <asp:DropDownList ID="Ddl_as_tipo_baja" CssClass="form-control select2" runat="server">
                                                                <asp:ListItem Value="0" Text="Seleccione..." />
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td style="vertical-align: middle; padding: 8px 10px;">
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="background-color: #e9ecef;">
                                                                        <i class="fas fa-calendar-day text-primary"></i>
                                                                    </span>
                                                                </div>
                                                                <asp:TextBox ID="txtNuevoFechaInicio" TextMode="Date" CssClass="form-control" runat="server" />
                                                            </div>
                                                        </td>
                                                        <td style="vertical-align: middle; padding: 8px 10px;">
                                                            <div class="input-group">
                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text" style="background-color: #e9ecef;">
                                                                        <i class="fas fa-calendar-check text-success"></i>
                                                                    </span>
                                                                </div>
                                                                <asp:TextBox ID="txtNuevoFechaFin" TextMode="Date" CssClass="form-control" runat="server" />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                       

                        <!-- NOTA IMPORTANTE -->
                        <div class="row">
                            <div class="col-12">
                                <div class="alert alert-warning">
                                    <i class="fas fa-exclamation-triangle"></i>
                                    <strong>Nota:</strong> La Resolución del contrato será efectiva tres días posteriores a la fecha de recepción de la presente solicitud.
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <!-- ============================================================ -->
    <!-- BOTONES - FUERA DEL UPDATEPANEL -->
    <!-- ============================================================ -->
    <div class="container-fluid">
        <div class="card">
            <div class="card-body text-right">
                <a href="ListaSolicitudes.aspx" class="btn btn-default btn-lg">
                    <i class="fas fa-times"></i> Cancelar
                </a>
                <asp:LinkButton ID="btnGuardar" CssClass="btn btn-danger btn-lg"
                    Text="<i class='fas fa-save'></i> Guardar Baja"
                    OnClick="btnGuardar_Click" runat="server" />
            </div>
        </div>
    </div>

    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelResolucion" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

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
            border-bottom: 1px solid rgba(0, 0, 0, 0.125);
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
        .table td {
            vertical-align: middle;
        }
        #<%= txtVigenteUnidad.ClientID %> {
            word-wrap: break-word !important;
            white-space: normal !important;
        }
        .table-bordered td {
            border: 1px solid #dee2e6 !important;
        }

        /* Estilos para los campos requeridos */
        .required-field::after {
            content: " *";
            color: #dc3545;
            font-weight: bold;
        }

        /* Estilos para el campo de número de documento */
        #divNumeroDoc input {
            text-transform: uppercase;
        }

        /* Estilos para la glosa */
        #Txt_gl_glosa {
            resize: vertical;
        }

        /* Estilos para select2 dentro de modales */
        .select2-container--default .select2-selection--single {
            border-radius: 0.25rem;
            border-color: #d2d6de;
            height: calc(2.25rem + 2px);
            padding: 0.375rem 0.75rem;
        }

        .select2-container--default .select2-selection--single .select2-selection__rendered {
            line-height: 1.5;
            color: #495057;
            padding-left: 0;
        }

        .select2-container--default .select2-selection--single .select2-selection__arrow {
            height: calc(2.25rem + 2px);
        }

        /* Estilos para las fechas */
        input[type="date"] {
            height: calc(2.25rem + 2px);
        }

        /* Estilos para el texto de ejemplo */
        .form-text.text-muted {
            font-size: 0.8rem;
            margin-top: 0.25rem;
        }

        /* Estilos para los botones */
        .btn-lg {
            padding: 0.5rem 1.5rem;
            font-size: 1rem;
        }

        /* Estilos para la tarjeta de glosa */
        .card-header.bg-success {
            background-color: #28a745 !important;
        }

        /* Estilos para el contenedor de la resolución */
        #ContentPlaceHolder1_txtLugarFecha {
            background-color: #f8f9fa;
        }
    </style>

    <script type="text/javascript">
        $(document).ready(function () {
            // Inicializar Select2
            $('.select2').select2({
                placeholder: { id: '0', text: 'Seleccione...' },
                allowClear: false,
                width: '100%'
            });

            // Configurar mayúsculas en el CITE
            $('#<%= txtCITE.ClientID %>').on('input', function () {
            this.value = this.value.toUpperCase();
        });

        // Validación de fechas
        function validarFechas() {
            var fechaInicio = $('#<%= txtNuevoFechaInicio.ClientID %>').val();
            var fechaFin = $('#<%= txtNuevoFechaFin.ClientID %>').val();

            if (fechaInicio && fechaFin) {
                var inicio = new Date(fechaInicio);
                var fin = new Date(fechaFin);

                if (fin <= inicio) {
                    $('#<%= txtNuevoFechaFin.ClientID %>').addClass('is-invalid');
                    return false;
                } else {
                    $('#<%= txtNuevoFechaFin.ClientID %>').removeClass('is-invalid');
                    return true;
                }
            }
            return true;
        }

        // Evento para validar fechas
        $('#<%= txtNuevoFechaInicio.ClientID %>, #<%= txtNuevoFechaFin.ClientID %>').on('change', function () {
            validarFechas();
        });

        console.log('✅ ContratacionResolucion - Frontend configurado correctamente');
    });

        // Función para reinicializar Select2 después de un PostBack
        function reinitSelect2() {
            $('.select2').select2({
                placeholder: { id: '0', text: 'Seleccione...' },
                allowClear: false,
                width: '100%'
            });
        }

        window.reinitSelect2 = reinitSelect2;
    </script>
</asp:Content>