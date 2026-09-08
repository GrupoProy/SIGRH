<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ContratacionDescriptor.aspx.cs" Inherits="Precontrataciones_ContratacionDescriptor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <!-- SweetAlert2 -->
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
  
    <asp:UpdatePanel runat="server" ID="UpdatePanelContratacion">
        <ContentTemplate>
            <div class="header pb-6" style="margin-top:-4em; margin-left:3em; width:81%"> 
                <div class="container-fluid">
                    <div class="header-body">
                        <div class="row align-items-center py-4">
                            <div class="col-lg-12">
                                <h6 class="h2 text-light d-inline-block mb-0">Solicitud de Contratación</h6>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div class="container-fluid mt--6">
                <!-- DATOS PERSONALES -->
                <div class="card">
                    <div class="card-header bg-info text-white">
                        <h4 class="mb-0"><i class="fas fa-id-card-alt mr-2"></i> Datos Personales</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Nombre Completo</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlNombreCompleto" runat="server" Text="Cargando..." /></div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Fecha de Nacimiento</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlFechaNac" runat="server" Text="Cargando..." /></div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Carnet de Identidad</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlCarnet" runat="server" Text="Cargando..." /></div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label font-weight-bold">Sexo</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlSexo" runat="server" Text="Cargando..." /></div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Correo Electrónico</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlEmail" runat="server" Text="Cargando..." /></div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Teléfono</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlTelefono" runat="server" Text="Cargando..." /></div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Celular</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlCelular" runat="server" Text="Cargando..." /></div>
                            </div>
                            <div class="col-lg-2">
                                <div class="content-text-label font-weight-bold">Estado Civil</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlEstadoCivil" runat="server" Text="Cargando..." /></div>
                            </div>
                        </div>
                        <div class="row mt-3">
                            <div class="col-lg-4">
                                <div class="content-text-label font-weight-bold">Ciudad de Residencia</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlCiudad" runat="server" Text="Cargando..." /></div>
                            </div>
                            <div class="col-lg-3">
                                <div class="content-text-label font-weight-bold">Procedencia</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlNacionalidad" runat="server" Text="Cargando..." /></div>
                            </div>
                            <div class="col-lg-5">
                                <div class="content-text-label font-weight-bold">Dirección</div>
                                <div class="h5 font-weight-400 content-text"><asp:Literal ID="ltlDireccion" runat="server" Text="Cargando..." /></div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- NOTA RRHH 01 -->
                <div class="card">
                    <div class="card-header bg-primary text-white">
                        <h4 class="mb-0"><i class="fas fa-file-signature mr-2"></i> NOTA RRHH 01 - Solicitud de Contratación</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="form-control-label">Lugar y Fecha</label>
                                    <asp:TextBox ID="txtLugarFecha" CssClass="form-control" Text="La Paz, 20/07/2026" runat="server" />
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
                                <p><strong>Señor:</strong><br />
                                <strong>OFICIAL MAYOR</strong><br />
                                <strong>CÁMARA DE SENADORES</strong><br />
                                <strong>Presente.-</strong></p>
                                <p>En el marco de la normativa legal e institucional vigente, se tiene a bien solicitar la contratación según el formulario de descripción de Cargo y Funciones adjunto:</p>
                            </div>
                        </div>

                        <div class="table-responsive">
                            <table class="table table-bordered">
                                <thead class="thead-light">
                                    <tr>
                                        <th style="width:40%">CARGO (según cuadro de equivalencias)</th>
                                        <th style="width:20%">SUELDO MENSUAL Bs.-</th>
                                        <th style="width:20%">FECHA DE INICIO</th>
                                        <th style="width:20%">FECHA DE CONCLUSIÓN</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>
                                            <asp:DropDownList ID="ddlCargo" CssClass="form-control select2" AutoPostBack="true" OnSelectedIndexChanged="ddlCargo_SelectedIndexChanged" runat="server">
                                                <asp:ListItem Value="0">Seleccione Cargo...</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtSueldo" CssClass="form-control" placeholder="0.00" ReadOnly="true" style="background-color: #f5f5f5;" runat="server" />
                                        </td>
                                        <td><asp:TextBox ID="txtFechaInicio" TextMode="Date" CssClass="form-control" runat="server" /></td>
                                        <td><asp:TextBox ID="txtFechaFin" TextMode="Date" CssClass="form-control" runat="server" /></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label class="form-control-label"><strong>Para desempeñar funciones en:</strong></label>
                                    <asp:DropDownList ID="ddlFunciones" CssClass="form-control select2" runat="server">
                                        <asp:ListItem Text="Seleccione..." Value="0" />
                                    </asp:DropDownList>
                                    <small class="text-muted">(Identificar a: Presidencia, Vicepresidencia, Secretaría, Comisión, Comité, Brigada o Bancada en que el personal requerido desempeñará funciones).</small>
                                </div>
                            </div>
                        </div>

                        <div class="alert alert-info">
                            <i class="fas fa-info-circle"></i> El inicio del contrato deberá sujetarse al plazo máximo de 5 días hábiles...
                        </div>
                    </div>
                </div>

                <!-- FORM. CPE-01 -->
                <div class="card">
                    <div class="card-header bg-success text-white">
                        <h4 class="mb-0"><i class="fas fa-clipboard-list mr-2"></i> FORM. CPE-01 - Formulario Descriptor de Puesto</h4>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="form-control-label">Nivel Salarial</label>
                                    <asp:TextBox ID="txtNivelSalarial" CssClass="form-control" ReadOnly="true" style="background-color: #f5f5f5;" runat="server" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label class="form-control-label">Clase</label>
                                    <asp:TextBox ID="txtClase" CssClass="form-control" ReadOnly="true" style="background-color: #f5f5f5;" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label class="form-control-label">Descripción del Puesto</label>
                                    <asp:TextBox ID="txtDescripcionPuesto" CssClass="form-control" placeholder="Ingrese la descripción del puesto..." runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label class="form-control-label">Objetivo o Justificación de la Contratación</label>
                                    <asp:TextBox ID="txtObjetivo" CssClass="form-control" placeholder="Ingrese el objetivo o justificación..." runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <div class="form-group">
                                    <label class="form-control-label">Funciones</label>
                                    <asp:TextBox ID="txtFunciones" TextMode="MultiLine" Rows="5" CssClass="form-control" placeholder="1. ...&#10;2. ...&#10;3. ..." runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- BOTONES -->
                <div class="card">
                    <div class="card-body text-right">
                        <a href="ListaSolicitudes.aspx" class="btn btn-default"><i class="fas fa-times"></i> Cancelar</a>
                        <asp:LinkButton ID="btnGuardar" CssClass="btn btn-success" OnClick="btnGuardar_Click" runat="server">
                            <i class="fas fa-save"></i> Guardar
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelContratacion" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <!-- ESTILOS PARA CORREGIR EL Z-INDEX DE SELECT2 -->
    <style type="text/css">
        .table-responsive {
            overflow: visible !important;
        }

        .select2-container--open {
            z-index: 99999 !important;
        }

        .select2-dropdown {
            z-index: 99999 !important;
        }

        .select2-container--default .select2-selection--single .select2-selection__clear {
            margin-right: 18px !important;
            float: right !important;
        }
    </style>

     <script type="text/javascript">
         function initSelect2() {
             var $ddl = $('#<%= ddlCargo.ClientID %>');

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
                     __doPostBack('<%= ddlCargo.UniqueID %>', '');
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