<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ActualizacionInformacionPersonal.aspx.cs" Inherits="MovimientoPersonal_ActualizacionInformacionPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanelPersona" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Actualización de Datos Personales</h3>
                            <p class="text-sm mb-0">Complete por favor la información faltante</p>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="progress-info">
                            <div class="tag-label">
                                <span>Código Funcionario:
                                    <span class="tag-label-content">
                                        <asp:Literal ID="Txt_per_id" runat="server" />
                                    </span>
                                </span>
                            </div>
                        </div>

                        <div class="row">
                            <!-- per_nombres -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Txt_per_nombres">Nombre(s)</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_nombres" CssClass="form-control letras" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_per_nombres" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_ap_paterno -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Txt_per_ap_paterno">Apellido Paterno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_paterno" CssClass="form-control letras" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_per_ap_paterno" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_ap_materno -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Txt_per_ap_materno">Apellido Materno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_materno" CssClass="form-control letras" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_per_ap_materno" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <!-- per_ap_casada -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Txt_per_ap_casada">Apellido del Esposo</label>
                                <small>(Si corresponde)</small>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_casada" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_sexo -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Rbl_per_sexo">Sexo / Género</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="Rbl_per_sexo" CssClass="radios" RepeatDirection="Horizontal" AutoPostBack="true" runat="server">
                                        <asp:ListItem Value="F" Text="Femenino" />
                                        <asp:ListItem Value="M" Text="Masculino" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Rbl_per_sexo" ValidationGroup="edit" Display="Dynamic" runat="server" />
                                <asp:HiddenField ID="hf_sexo" runat="server" />
                            </div>
                            <!-- per_tipo_doc -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Ddl_per_tipo_doc">Tipo de Documento</label>
                                <asp:DropDownList ID="Ddl_per_tipo_doc" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_tipo_doc" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <!-- per_num_doc -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Txt_per_num_doc">Número de Documento</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="far fa-id-card"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_num_doc" CssClass="form-control numero" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_per_num_doc" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_lugar_exp -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Ddl_per_lugar_exp">Lugar Expedido</label>
                                <asp:DropDownList ID="Ddl_per_lugar_exp" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_lugar_exp" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_estado_civil -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Ddl_per_estado_civil">Estado Civil</label>
                                <asp:DropDownList ID="Ddl_per_estado_civil" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_estado_civil" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <!-- per_fecha_nac -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Txt_per_fecha_nac">Fecha de Nacimiento</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="far fa-calendar-alt"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_fecha_nac" CssClass="form-control datepickerD" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_per_fecha_nac" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_procedencia -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Ddl_per_procedencia">Nacionalidad</label>
                                <asp:DropDownList ID="Ddl_per_procedencia" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_per_procedencia_SelectedIndexChanged" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_procedencia" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                            <!-- per_lugar_nac -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Ddl_per_lugar_nac">Lugar de Nacimiento</label>
                                <asp:DropDownList ID="Ddl_per_lugar_nac" CssClass="form-control select2" AppendDataBoundItems="true" Enabled="false" runat="server" />
                            </div>
                        </div>
                        <div class="row">
                            <!-- afp -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Rbl_afp_previsora">AFP</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="Rbl_afp_previsora" CssClass="radios" RepeatDirection="Vertical" runat="server">
                                        <asp:ListItem Value="AP" Text="BBVA Prevision" />
                                        <asp:ListItem Value="AF" Text="Futuro de Bolivia S.A." />
                                        <asp:ListItem Value="GP" Text="Gestora Publica" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Rbl_afp_previsora" ValidationGroup="edit" Display="Dynamic" runat="server" />
                                <asp:HiddenField ID="hf_afp_previsora" runat="server" />
                            </div>
                            <!-- cua/nua -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="txtNuaCua">NUA/CUA</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtNuaCua" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtNuaCua" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                            <!-- FORMACIÓN ACADÉMICA -->
                            <div class="form-group col-md-5">
                                <label class="form-control-label" for="DdlFormacion">ÚLTIMO GRADO ACADÉMICO ADQUIRIDO</label>
                                <asp:DropDownList ID="DdlFormacion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="DdlFormacion" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <asp:HiddenField ID="hdf_nua" runat="server" />
                        <asp:HiddenField ID="hdf_ef_id" runat="server" />
                    </div>
                </div>
            </div>

            <!-- ============================================================ -->
            <!-- DOMICILIO Y DATOS ADICIONALES -->
            <!-- ============================================================ -->
            <div class="container-fluid">
                <div class="card">
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
                                    <!-- UBICACIÓN CON CASCADA (Departamento -> Provincia -> Ciudad) -->
                                    <!-- ============================================================ -->
                                    <asp:UpdatePanel ID="UpdatePanelUbicacion" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <div class="row">
                                                <!-- DEPARTAMENTO -->
                                                <div class="form-group col-md-6">
                                                    <label class="form-control-label" for="Ddl_per_departamento">Departamento</label>
                                                    <asp:DropDownList ID="Ddl_per_departamento" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_per_departamento_SelectedIndexChanged" runat="server">
                                                        <asp:ListItem Text="-- Seleccione --" Value="0" />
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_departamento" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                                                </div>
                                                <!-- PROVINCIA -->
                                                <div class="form-group col-md-6">
                                                    <label class="form-control-label" for="Ddl_per_provincia">Provincia</label>
                                                    <asp:DropDownList ID="Ddl_per_provincia" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_per_provincia_SelectedIndexChanged" runat="server">
                                                        <asp:ListItem Text="-- Seleccione --" Value="0" />
                                                    </asp:DropDownList>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_provincia" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                                                </div>
                                            </div>
                                            <div class="row">
                                                <!-- CIUDAD DE RESIDENCIA -->
                                                <div class="form-group col-md-12">
                                                    <label class="form-control-label" for="Ddl_perd_ciudad_residencia">Ciudad de Residencia</label>
                                                    <asp:DropDownList ID="Ddl_perd_ciudad_residencia" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_perd_ciudad_residencia" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="Ddl_per_departamento" EventName="SelectedIndexChanged" />
                                            <asp:AsyncPostBackTrigger ControlID="Ddl_per_provincia" EventName="SelectedIndexChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                    <!-- ZONA -->
                                    <div class="row">
                                        <div class="form-group col-md-12">
                                            <label class="form-control-label" for="Ddl_perd_zona">Zona</label>
                                            <div class="input-group">
                                                <asp:DropDownList ID="Ddl_perd_zona" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                <div class="input-group-append">
                                                    <asp:Button ID="btnNuevoCatalogo" runat="server" CssClass="btn btn-warning" Text="Nueva Zona" OnClick="btnNuevoCatalogo_Click" />
                                                </div>
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_perd_zona" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>

                                    <!-- DESCRIPCIÓN DE DOMICILIO -->
                                    <div class="row">
                                        <div class="form-group col-md-12">
                                            <label class="form-control-label">Descripción de Domicilio</label>
                                            <small>(Ejemplo: Calle/ Colombia)</small>
                                            <div class="row">
                                                <div class="col-md-5">
                                                    <asp:DropDownList ID="Ddl_perd_tipo_via" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_perd_tipo_via" ValidationGroup="edit" InitialValue="0" Display="Dynamic" runat="server" />
                                                </div>
                                                <div class="form-group col-md-7 top--4">
                                                    <label class="form-control-label" for="Txt_perd_descripcion_via"></label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_perd_descripcion_via" CssClass="form-control" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_perd_descripcion_via" ValidationGroup="edit" Display="Dynamic" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- NÚMERO DE DOMICILIO -->
                                    <div class="row">
                                        <div class="form-group col-md-5 top--4">
                                            <label class="form-control-label" for="Txt_perd_numero">Número de Domicilio</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-home"></i></span>
                                                </div>
                                                <asp:TextBox ID="Txt_perd_numero" CssClass="form-control" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_perd_numero" ValidationGroup="edit" Display="Dynamic" runat="server" />
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
                                        <h3 class="mb-0">Datos adicionales</h3>
                                        <p class="text-sm mb-0">Registre los datos adicionales.</p>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <div class="row">
                                        <!-- perd_telefono -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_perd_telefono">Número de Teléfono</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-phone"></i></span>
                                                </div>
                                                <asp:TextBox ID="Txt_perd_telefono" CssClass="form-control numero" TextMode="Number" runat="server" />
                                            </div>
                                        </div>
                                        <!-- perd_celular -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_perd_celular">Número de Celular</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="fas fa-mobile-alt"></i></span>
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
                                                        <span class="input-group-text"><i class="fas fa-at"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="Txt_perd_email" CssClass="form-control" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- LIBRETA MILITAR -->
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div id="d_slm" class="form-group" style="display: none;">
                                                <label class="form-control-label" for="Ddl_per_has">Nº Libreta de Serv. Militar</label>
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
                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="Txt_per_serie_libreta_militar" CssClass="form-control" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
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
                </div>
            </div>

            <!-- BOTÓN GUARDAR -->
            <div class="container-fluid">
                <div class="card">
                    <div class="card-body text-right">
                        <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Actualizar" OnClick="BtnGuardar_Click" ValidationGroup="edit" runat="server" />
                    </div>
                </div>
            </div>

            <!-- ============================================================ -->
            <!-- MODAL NUEVA ZONA -->
            <!-- ============================================================ -->
            <div id="modalCatalogo" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
                    <div class="modal-content">
                        <div class="modal-header border-bottom">
                            <div class="ct-page-title">
                                <h5 id="CatalogoTitle" class="modal-title">Nuevo Registro de Zona</h5>
                                <p class="text-sm mb-0"></p>
                            </div>
                        </div>
                        <div class="modal-body">
                            <div class="form-group col-md-12">
                                <label class="form-control-label" for="txt_cat_descripcion">Descripción</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txt_cat_descripcion" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnRegistrarCatalogo" OnClick="BtnRegistrarCatalogo_Click" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" runat="server" />
                            <asp:LinkButton ID="BotonCerrarCatalogo" OnClick="BotonCerrarCatalogo_Click" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnGuardar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="Ddl_per_departamento" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="Ddl_per_provincia" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="Ddl_per_procedencia" EventName="SelectedIndexChanged" />
            <asp:AsyncPostBackTrigger ControlID="btnNuevoCatalogo" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnRegistrarCatalogo" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelPersona" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>