<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="SolicitudContratacion.aspx.cs" Inherits="Precontratacion_SolicitudContratacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanelSolicitud">
        <ContentTemplate>
            <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%">
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
                <!-- ============================================================ -->
                <!-- DATOS PERSONALES -->
                <!-- ============================================================ -->
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Datos Personales</h3>
                            <p class="text-sm mb-0">En el siguiente formulario puede ingresar los datos del personal a contratar.</p>
                        </div>
                    </div>
                    <div class="card-body">
                        <!-- Código de Solicitud -->
                        <div class="progress-info">
                            <div class="tag-label">
                                <span>Código de Solicitud:
                                    <span class="tag-label-content">
                                        <asp:Literal ID="lblCodigoSolicitud" runat="server" Text="Nuevo" />
                                    </span>
                                </span>
                            </div>
                        </div>

                        <div class="row">
                            <!-- Nombres -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Nombre(s)</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtNombres" CssClass="form-control letras" placeholder="Ingrese Nombres" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtNombres" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Apellido Paterno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Apellido Paterno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtApPaterno" CssClass="form-control letras" placeholder="Ingrese Apellido Paterno" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtApPaterno" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Apellido Materno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Apellido Materno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtApMaterno" CssClass="form-control letras" placeholder="Ingrese Apellido Materno" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtApMaterno" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Apellido del Esposo -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Apellido del Esposo</label>
                                <small>(Si corresponde)</small>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtApEsposo" CssClass="form-control letras" placeholder="Ingrese Apellido del Esposo" runat="server" />
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <!-- Sexo -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Sexo / Género</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="ddlSexo" CssClass="radios" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="F" Text="Femenino" />
                                        <asp:ListItem Value="M" Text="Masculino" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlSexo" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Tipo de Documento -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Tipo de Documento</label>
                                <asp:DropDownList ID="ddlTipoDoc" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlTipoDoc" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Número de Documento -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Número de Documento</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="far fa-id-card"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtNumDoc" CssClass="form-control numero" placeholder="Ingrese Número de Documento" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtNumDoc" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Lugar Expedido -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Lugar Expedido</label>
                                <asp:DropDownList ID="ddlLugarExp" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlLugarExp" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                        </div>

                        <div class="row">
                            <!-- Estado Civil -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Estado Civil</label>
                                <asp:DropDownList ID="ddlEstadoCivil" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlEstadoCivil" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Fecha de Nacimiento -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Fecha de Nacimiento</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtFechaNac" CssClass="form-control datepickerD" placeholder="dd/mm/aaaa" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFechaNac" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Nacionalidad -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Nacionalidad</label>
                                <asp:DropDownList ID="ddlNacionalidad" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlNacionalidad_SelectedIndexChanged" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlNacionalidad" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Lugar de Nacimiento -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Lugar de Nacimiento</label>
                                <asp:DropDownList ID="ddlLugarNac" CssClass="form-control select2" AppendDataBoundItems="true" Enabled="false" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlLugarNac" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                        </div>

                        <!-- ============================================================ -->
                        <!-- AFP, NUA/CUA Y GRADO ACADÉMICO -->
                        <!-- ============================================================ -->
                        <div class="row">
                            <!-- AFP -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">AFP</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="rblAfpPrevisora" CssClass="radios" RepeatDirection="Vertical" runat="server">
                                        <asp:ListItem Value="AP" Text="BBVA Prevision" />
                                        <asp:ListItem Value="AF" Text="Futuro de Bolivia S.A." />
                                        <asp:ListItem Value="GP" Text="Gestora Publica" Selected="True" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="rblAfpPrevisora" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- NUA/CUA -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">NUA/CUA</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtNuaCua" CssClass="form-control numero" TextMode="Number" Text="0" runat="server" />
                                </div>
                            </div>
                            <!-- ÚLTIMO GRADO ACADÉMICO ADQUIRIDO -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">ÚLTIMO GRADO ACADÉMICO ADQUIRIDO</label>
                                <asp:DropDownList ID="DdlFormacion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Text="-- Seleccione --" Value="0" />
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="DdlFormacion" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <!-- Espacio vacío -->
                            <div class="form-group col-md-3">
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ============================================================ -->
                <!-- DOMICILIO Y DATOS ADICIONALES -->
                <!-- ============================================================ -->
                <div class="row">
                    <div class="col-md-6">
                        <div class="card">
                            <div class="card-header border-bottom">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Domicilio</h3>
                                    <p class="text-sm mb-0">En el siguiente formulario puede ingresar los datos de la dirección actual de residencia.</p>
                                </div>
                            </div>
                            <div class="card-body">
                                <!-- ============================================================ -->
                                <!-- UBICACIÓN -->
                                <!-- ============================================================ -->
                                <asp:UpdatePanel ID="UpdatePanelUbicacion" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <!-- DEPARTAMENTO -->
                                        <div class="row">
                                            <div class="form-group col-md-6">
                                                <label class="form-control-label">Departamento</label>
                                                <asp:DropDownList ID="ddlDepartamento" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged" runat="server">
                                                    <asp:ListItem Text="-- Seleccione --" Value="0" />
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlDepartamento" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                            </div>

                                            <!-- PROVINCIA -->
                                            <div class="form-group col-md-6">
                                                <label class="form-control-label">Provincia</label>
                                                <asp:DropDownList ID="ddlProvincia" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlProvincia_SelectedIndexChanged" runat="server">
                                                    <asp:ListItem Text="-- Seleccione --" Value="0" />
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlProvincia" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                            </div>
                                        </div>

                                        <!-- CIUDAD DE RESIDENCIA -->
                                        <div class="row">
                                            <div class="form-group col-md-12">
                                                <label class="form-control-label">Ciudad de Residencia</label>
                                                <div class="input-group">
                                                    <asp:DropDownList ID="ddlCiudad" CssClass="form-control select2" AppendDataBoundItems="true" Enabled="true" runat="server" style="width: 100%;">
                                                        <asp:ListItem Text="-- Seleccione --" Value="0" />
                                                    </asp:DropDownList>
                                                    <div class="input-group-append">
                                                        <asp:LinkButton ID="btnNuevaCiudad" CssClass="btn btn-warning" Text="<i class='fas fa-plus'></i>" OnClick="btnNuevaCiudad_Click" runat="server" />
                                                    </div>
                                                </div>
                                                <small class="text-muted">Haga clic en [+] para agregar una nueva ciudad</small>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlCiudad" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="ddlDepartamento" EventName="SelectedIndexChanged" />
                                        <asp:AsyncPostBackTrigger ControlID="ddlProvincia" EventName="SelectedIndexChanged" />
                                    </Triggers>
                                </asp:UpdatePanel>

                                <!-- ZONA + Botón Nueva Zona -->
                                <div class="row">
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label">Zona</label>
                                        <div class="input-group">
                                            <asp:DropDownList ID="ddlZona" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" style="width: 100%;">
                                                <asp:ListItem Text="-- Seleccione --" Value="0" />
                                            </asp:DropDownList>
                                            <div class="input-group-append">
                                                <asp:LinkButton ID="btnNuevaZona" CssClass="btn btn-warning" Text="<i class='fas fa-plus'></i>" OnClick="btnNuevaZona_Click" runat="server" />
                                            </div>
                                        </div>
                                        <small class="text-muted">Haga clic en [+] para agregar una nueva zona</small>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlZona" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                </div>

                                <!-- DESCRIPCIÓN DE DOMICILIO -->
                                <div class="row">
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label">Descripción de Domicilio</label>
                                        <small>(Ejemplo: Calle Colombia, Av. 6 de Agosto, Camino a Porvenir)</small>
                                        <div class="row">
                                            <div class="col-md-5">
                                                <asp:DropDownList ID="ddlTipoVia" CssClass="form-control select2" AppendDataBoundItems="true" runat="server">
                                                    <asp:ListItem Text="-- Seleccione --" Value="0" />
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlTipoVia" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                            </div>
                                            <div class="col-md-7">
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">
                                                            <i class="fas fa-edit"></i>
                                                        </span>
                                                    </div>
                                                    <asp:TextBox ID="txtDescDomicilio" CssClass="form-control" placeholder="Ingrese la dirección (Calle, Avenida, Camino)" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtDescDomicilio" ValidationGroup="add" Display="Dynamic" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!-- NÚMERO DE DOMICILIO -->
                                <div class="row">
                                    <div class="form-group col-md-5">
                                        <label class="form-control-label">Número de Domicilio</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-home"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="txtNumDomicilio" CssClass="form-control" placeholder="N°" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtNumDomicilio" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <!-- ============================================================ -->
                    <!-- DATOS ADICIONALES (LIBRETA MILITAR AQUÍ - SIN MODIFICAR) -->
                    <!-- ============================================================ -->
                    <div class="col-md-6">
                        <div class="card">
                            <div class="card-header border-bottom">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Datos Adicionales</h3>
                                    <p class="text-sm mb-0">Ingrese datos adicionales del funcionario.</p>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label">Número de Teléfono</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-phone"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtTelefono" CssClass="form-control numero" TextMode="Number" placeholder="N°" runat="server" />
                                        </div>
                                    </div>
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label">Número de Celular</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-mobile-alt"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtCelular" CssClass="form-control numero" TextMode="Number" placeholder="N°" runat="server" />
                                        </div>
                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label">Correo Electrónico</label>
                                            <small>(Opcional)</small>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-at"></i></span>
                                                </div>
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="ejemplo@correo.com" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <!-- ============================================================ -->
                                <!-- LIBRETA MILITAR (SE MANTIENE AQUÍ COMO ESTABA ORIGINALMENTE) -->
                                <!-- ============================================================ -->
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label class="form-control-label">Nº Libreta de Serv. Militar</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txtLibretaMilitar" CssClass="form-control" placeholder="N°" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <small>Ejemplo: Imagen Nº de serie</small>
                                            <img class="img-thumbnail img-fluid" src="../Content/img/num_serie_lsm.jpeg" alt="Libreta de Servicio Militar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ============================================================ -->
                <!-- BOTONES -->
                <!-- ============================================================ -->
                <div class="card">
                    <div class="card-body text-right">
                        <asp:LinkButton ID="btnCancelar" CssClass="btn btn-default" Text="<i class='fas fa-times'></i> Cancelar" OnClick="btnCancelar_Click" runat="server" />
                        <asp:LinkButton ID="btnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar y Siguiente" OnClick="btnGuardar_Click" ValidationGroup="add" runat="server" />
                    </div>
                </div>
            </div>

            <!-- ============================================================ -->
            <!-- MODAL NUEVA ZONA -->
            <!-- ============================================================ -->
            <div class="modal fade" id="modalNuevaZona" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Nuevo Registro de Zona</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="form-control-label">Descripción</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtNuevaZona" CssClass="form-control" placeholder="Ingrese el nombre de la zona" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnRegistrarZona" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> REGISTRAR" OnClick="btnRegistrarZona_Click" runat="server" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fas fa-times"></i> CANCELAR</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- ============================================================ -->
            <!-- MODAL NUEVA CIUDAD -->
            <!-- ============================================================ -->
            <div class="modal fade" id="modalNuevaCiudad" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header">
                            <h5 class="modal-title">Nuevo Registro de Ciudad</h5>
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">&times;</span>
                            </button>
                        </div>
                        <div class="modal-body">
                            <div class="form-group">
                                <label class="form-control-label">Departamento</label>
                                <asp:DropDownList ID="ddlCiudadDepartamento" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="ddlCiudadDepartamento_SelectedIndexChanged" runat="server">
                                    <asp:ListItem Text="-- Seleccione --" Value="0" />
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="form-control-label">Provincia</label>
                                <asp:DropDownList ID="ddlCiudadProvincia" CssClass="form-control select2" AppendDataBoundItems="true" runat="server">
                                    <asp:ListItem Text="-- Seleccione --" Value="0" />
                                </asp:DropDownList>
                            </div>
                            <div class="form-group">
                                <label class="form-control-label">Nombre de la Ciudad</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-city"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtNuevaCiudad" CssClass="form-control" placeholder="Ingrese el nombre de la ciudad" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="btnRegistrarCiudad" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> REGISTRAR" OnClick="btnRegistrarCiudad_Click" runat="server" />
                            <button type="button" class="btn btn-secondary" data-dismiss="modal"><i class="fas fa-times"></i> CANCELAR</button>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddlNacionalidad" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="ddlCiudadDepartamento" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnNuevaZona" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRegistrarZona" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNuevaCiudad" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRegistrarCiudad" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnGuardar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnCancelar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelSolicitud" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <!-- ============================================================ -->
    <!-- SCRIPTS -->
    <!-- ============================================================ -->
    <script type="text/javascript">
        function initSelect2() {
            $('.select2').each(function () {
                var $this = $(this);
                if ($this.hasClass("select2-hidden-accessible")) {
                    try {
                        $this.select2('destroy');
                    } catch (e) { }
                }
                $this.next('.select2-container').remove();
                $this.removeClass('select2-hidden-accessible');
                $this.select2({
                    placeholder: "Seleccione...",
                    allowClear: true,
                    width: '100%',
                    dropdownParent: $this.closest('.modal').length ? $this.closest('.modal') : $('body'),
                    language: {
                        noResults: function () {
                            return "No se encontraron resultados";
                        }
                    }
                });
            });
        }

        $(document).ready(function () {
            initSelect2();
            $('.datepickerD').datepicker({
                format: 'dd/mm/yyyy',
                autoclose: true,
                language: 'es'
            });

            $('#<%= ddlDepartamento.ClientID %>').on('select2:select', function (e) {
                var val = $(this).val();
                if (val && val !== '0') {
                    setTimeout(function () {
                        if (typeof __doPostBack === 'function') {
                            __doPostBack('<%= ddlDepartamento.UniqueID %>', '');
                        }
                    }, 200);
                }
            });

            $('#<%= ddlProvincia.ClientID %>').on('select2:select', function (e) {
                var val = $(this).val();
                if (val && val !== '0') {
                    setTimeout(function () {
                        if (typeof __doPostBack === 'function') {
                            __doPostBack('<%= ddlProvincia.UniqueID %>', '');
                        }
                    }, 200);
                }
            });
        });

        if (typeof Sys !== 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_pageLoaded(function (sender, args) {
                initSelect2();
            });
        }

        function refreshSelect2() {
            initSelect2();
            console.log('Select2 reinicializados correctamente');
        }
    </script>
</asp:Content>