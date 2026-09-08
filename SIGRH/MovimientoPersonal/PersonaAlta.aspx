<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="PersonaAlta.aspx.cs" Inherits="MovimientoPersonal_PersonaAlta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro Nuevo Funcionario</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:UpdatePanel runat="server" ID="altaPersonaPanel">
        <ContentTemplate>
            <!-- Page content -->
            <div class="container-fluid mt--6">
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Datos Personales</h3>
                            <p class="text-sm mb-0">En el siguiente formulario puede ingresar los datos del nuevo personal.</p>
                        </div>
                    </div>
                    <div class="card-body">
                        <!-- per_id -->
                        <div class="progress-info">
                            <div class="tag-label">
                                <span>Código de Funcionario:
                                    <span class="tag-label-content">
                                        <asp:Literal ID="Lt_per_id" runat="server" />
                                    </span>
                                </span>
                            </div>
                        </div>
                        <div class="row">
                            <!-- per_nombres -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_nombres">Nombre(s)</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_nombres" CssClass="form-control letras" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_per_nombres" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_ap_paterno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_paterno">Apellido Paterno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_paterno" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_ap_materno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_materno">Apellido Materno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_materno" CssClass="form-control letras" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_per_ap_materno" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_ap_casada -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_casada">Apellido del Esposo</label>
                                <small>(Si corresponde)</small>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_casada" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <!-- per_sexo -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Rbl_per_sexo">Sexo / Género</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="Rbl_per_sexo" CssClass="radios" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="Rbl_per_sexo_SelectedIndexChanged" runat="server">
                                        <asp:ListItem Value="F" Text="Femenino" />
                                        <asp:ListItem Value="M" Text="Masculino" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Rbl_per_sexo" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_tipo_doc -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Ddl_per_tipo_doc">Tipo de Documento</label>
                                <asp:DropDownList ID="Ddl_per_tipo_doc" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_tipo_doc" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_num_doc -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_num_doc">Número de Documento</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="far fa-id-card"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_num_doc" CssClass="form-control" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_per_num_doc" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_lugar_exp -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Ddl_per_lugar_exp">Lugar Expedido</label>
                                <asp:DropDownList ID="Ddl_per_lugar_exp" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_lugar_exp" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <!-- per_estado_civil -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Ddl_per_estado_civil">Estado Civil</label>
                                <asp:DropDownList ID="Ddl_per_estado_civil" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_estado_civil" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>

                            <!-- per_fecha_nac -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_fecha_nac">Fecha de Nacimiento</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="far fa-calendar-alt"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_fecha_nac" CssClass="form-control datepickerD" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_per_fecha_nac" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_procedencia -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Ddl_per_procedencia">Nacionalidad</label>
                                <asp:DropDownList ID="Ddl_per_procedencia" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_per_procedencia_SelectedIndexChanged" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_procedencia" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_lugar_nac -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Ddl_per_lugar_nac">Lugar de Nacimiento</label>
                                <asp:DropDownList ID="Ddl_per_lugar_nac" CssClass="form-control select2" AppendDataBoundItems="true" Enabled="false" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_lugar_nac" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <!-- afp_previsora -->
<div class="form-group col-md-3">
    <label class="form-control-label" for="Rbl_afp_previsora">AFP</label>
    <div class="custom-control custom-radio">
        <asp:RadioButtonList ID="Rbl_afp_previsora" CssClass="radios" RepeatDirection="Vertical" runat="server">
            <asp:ListItem Value="AP" Text="BBVA Prevision" />
            <asp:ListItem Value="AF" Text="Futuro de Bolivia S.A." />
            <asp:ListItem Value="GP" Text="Gestora Publica" Selected="True" />
        </asp:RadioButtonList>
    </div>
    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Rbl_afp_previsora" ValidationGroup="add" Display="Dynamic" runat="server" />
</div>
                            <!-- NUA/CUA -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="txtNuaCua">NUA/CUA</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtNuaCua" CssClass="form-control numero" TextMode="Number" Text="0" runat="server" />
                                </div>
                            </div>
                            <!-- FORMACIÓN ACADÉMICA -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="DdlFormacion">ÚLTIMO GRADO ACADÉMICO ADQUIRIDO</label>
                                <asp:DropDownList ID="DdlFormacion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="DdlFormacion" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>

                <!-- ============================================================ -->
                <!-- DOMICILIO - VERSIÓN COMPLETA CON CASCADA -->
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
                                <!-- UBICACIÓN -->
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
                    <!-- DATOS ADICIONALES -->
                    <!-- ============================================================ -->
                    <div class="col-md-6">
                        <div class="card">
                            <div class="card-header border-bottom">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Datos Adicionales</h3>
                                    <p class="text-sm mb-0">En el siguiente formulario puede ingresar datos adicionales.</p>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <!-- perd_telefono -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_perd_telefono">Número de Teléfono</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-phone"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_perd_telefono" CssClass="form-control numero" TextMode="Number" runat="server" />
                                        </div>
                                    </div>
                                    <!-- perd_celular -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_perd_celular">Número de Celular</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-mobile-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_perd_celular" CssClass="form-control numero" TextMode="Number" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-12">
                                        <!-- perd_email -->
                                        <div class="form-group">
                                            <label class="form-control-label" for="Txt_perd_email">Correo Electrónico</label>
                                            <small>(Opcional)</small>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-at"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_perd_email" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <!-- per_has & per_serie_libreta_militar -->
                                        <div id="d_slm" class="form-group" style="display: none;">
                                            <label class="form-control-label" for="ddl_per_has">Nº Libreta de Serv. Militar</label>
                                            <small>(Si corresponde)</small>
                                            <asp:DropDownList ID="Ddl_per_has" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AutoPostBack="true" OnSelectedIndexChanged="Ddl_per_has_SelectedIndexChanged" runat="server">
                                                <asp:ListItem Value="0" Text="-- Seleccione --" />
                                                <asp:ListItem Value="1" Text="TIENE" />
                                                <asp:ListItem Value="2" Text="NO TIENE" />
                                            </asp:DropDownList>
                                        </div>
                                        <div id="d_txt_slm" class="form-group">
                                            <label class="form-control-label" for="Txt_per_serie_libreta_militar">Nº Libreta de Serv. Militar</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_per_serie_libreta_militar" CssClass="form-control" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <!-- img de ejemplo -->
                                        <div class="form-group">
                                            <small>Ejemplo: Imagen Nº de serie</small>
                                            <img class="img-thumbnail img-fluid" src="<%= ResolveUrl("../Content/img/num_serie_lsm.jpeg") %>" alt="Libreta de Servicio Militar" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- BOTONES -->
                <div class="card">
                    <div class="card-body text-right">
                        <asp:LinkButton ID="BtnNuevoF" Visible="false" CssClass="btn btn-default" Text="<i class='fas fa-users'></i> Familiares" ValidationGroup="add" OnClick="BtnNuevoF_Click" runat="server" />
                        <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
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

            <!-- ============================================================ -->
            <!-- FAMILY MODAL -->
            <!-- ============================================================ -->
            <div id="familyModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="familyTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header border-bottom">
                            <div class="ct-page-title">
                                <h5 id="familyTitle" class="modal-title">Familiares</h5>
                                <p class="text-sm mb-0"></p>
                            </div>
                        </div>
                        <div class="modal-body">
                            <asp:HiddenField ID="Hf_per_id_f" runat="server" />
                            <div class="row">
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Ddl_pf_tipo_parentesco">Tipo Parentesco</label>
                                    <asp:DropDownList ID="Ddl_pf_tipo_parentesco" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_pf_tipo_parentesco" ValidationGroup="family" InitialValue="0" Display="Dynamic" runat="server" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Txt_pf_nombres">Nombre(s)</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-edit"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="Txt_pf_nombres" CssClass="form-control letras" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_pf_nombres" ValidationGroup="family" Display="Dynamic" runat="server" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Txt_pf_paterno">Apellido Paterno</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-edit"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="Txt_pf_paterno" CssClass="form-control letras" runat="server" />
                                    </div>
                                </div>
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Txt_pf_materno">Apellido Materno</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-edit"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="Txt_pf_materno" CssClass="form-control letras" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_pf_materno" ValidationGroup="family" Display="Dynamic" runat="server" />
                                </div>
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Txt_pf_ap_esposo">Apellido del Esposo</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-edit"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="Txt_pf_ap_esposo" CssClass="form-control letras" runat="server" />
                                    </div>
                                </div>
                            </div>
                            <div id="accordionF" class="accordion" style="display: none;">
                                <div class="card">
                                    <div id="headingF" class="card-header border-bottom" data-toggle="collapse" data-target="#collapseF" aria-expanded="false" aria-controls="collapseF">
                                        <div class="ct-page-title">
                                            <h3 class="mb-0">Lista de Familiares</h3>
                                            <p class="text-sm mb-0"></p>
                                        </div>
                                    </div>
                                    <div id="collapseF" class="collapse" aria-labelledby="headingF" data-parent="#accordionF">
                                        <div class="card-body">
                                            <asp:GridView ID="GvListaFamily" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="pf_id" OnPreRender="GvListaFamily_PreRender" runat="server">
                                                <Columns>
                                                    <asp:BoundField DataField="pf_nom_parentesco" HeaderText="Tipo Parentesco" />
                                                    <asp:BoundField DataField="pf_paterno" HeaderText="Apellido Paterno" />
                                                    <asp:BoundField DataField="pf_materno" HeaderText="Apellido Materno" />
                                                    <asp:BoundField DataField="pf_nombres" HeaderText="Nombre(s)" />
                                                    <asp:BoundField DataField="pf_ap_esposo" HeaderText="Apellido Esposo" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnGuardarF" Visible="false" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="family" OnClick="BtnGuardarF_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelarF" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="BtnCancelarF_Click" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnNuevaZona" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRegistrarZona" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnNuevaCiudad" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnRegistrarCiudad" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnGuardar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="altaPersonaPanel" runat="server">
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