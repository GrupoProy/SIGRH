<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Persona.aspx.cs" Inherits="MovimientoPersonal_frmPersona" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanelPersona">
        <ContentTemplate>
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro de Funcionarios</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Búsqueda de Personal</h3>
                    <p class="text-sm mb-0">Busque el funcionario para editar la información o cree un nuevo registro de funcionario</p>
                </div>
            </div>
                    <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">
                        <div class="row">
                            <!-- per_ap_paterno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_paterno_b">Apellido Paterno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_paterno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_ap_materno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_materno_b">Apellido Materno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_materno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_nombres -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_nombres_b">Nombre(s)</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_nombres_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <!-- per_num_doc -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_num_doc_b">Carnet de Identidad</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_num_doc_b" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- per_id -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_id_b">Código de Funcionario</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_id_b" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- BtnBuscar -->
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block top-4" Text="<i class='fas fa-search'></i> Buscar" OnClick="BtnBuscar_Click" runat="server" />
                            </div>
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-warning btn-block top-4" Text="<i class='fas fa-plus'>   Nuevo</i>" data-toggle="tooltip" data-original-title="Nuevo Registro" OnClick="BtnNuevo_Click" runat="server" />
                            </div>

                        </div>
                    </asp:Panel>
        </div>

        <!-- Result Record Starts here -->
        <div id="dResult" class="card" style="display: none;">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Resultado de Búsqueda</h3>
                    <p class="text-sm mb-0"></p>
                </div>
            </div>
            <div class="card-body">
                <!-- Placing GridView in UpdatePanel -->
                        <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="per_id" OnPreRender="GvLista_PreRender" OnRowCommand="GvLista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" />
                                <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" />
                                <asp:BoundField DataField="per_nombres" HeaderText="Nombre(s)" />
                                <asp:BoundField DataField="per_ap_casada" HeaderText="Apellido Casada" />
                                <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />
                                <asp:TemplateField HeaderText="Editar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-pen'></i></span>" data-toggle="tooltip" data-placement="top" title="Editar" runat="server" />
                                        <asp:LinkButton Visible="false" CommandName="GetAddFam" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-default btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-users'></i></span>" data-toggle="tooltip" data-placement="top" title="Familiares" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
            </div>
        </div>
        <!-- Result Record Ends here -->

        <!-- Diseño para el button nuevo registro -->
<%--        <div class="col-lg-6 col-5 text-right">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>--%>
<%--                    <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Nuevo Registro" OnClick="BtnNuevo_Click" runat="server" />--%>
<%--                </ContentTemplate>
            </asp:UpdatePanel>
        </div>--%>
    </div>

    <!-- Modal component -->
    <!-- Edit Record Modal Starts here -->
    <div id="editModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="editTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="editTitle" class="modal-title">Modificar Datos Personales</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                        <div class="modal-body">
                            <!-- per_id -->
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
                                            <span class="input-group-text">
                                                <i class="fas fa-edit"></i>
                                            </span>
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
                                            <span class="input-group-text">
                                                <i class="fas fa-edit"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="Txt_per_ap_paterno" CssClass="form-control letras" runat="server" />
                                    </div>
                                </div>
                                <!-- per_ap_materno -->
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Txt_per_ap_materno">Apellido Materno</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-edit"></i>
                                            </span>
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
                                            <span class="input-group-text">
                                                <i class="fas fa-edit"></i>
                                            </span>
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
                                </div>
                                <!-- per_tipo_doc -->
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Ddl_per_tipo_doc">Tipo de Documento</label>
                                    <asp:DropDownList ID="Ddl_per_tipo_doc" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_per_tipo_doc" ValidationGroup="add_persona" InitialValue="0" Display="Dynamic" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <!-- per_num_doc -->
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Txt_per_num_doc">Número de Documento</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="far fa-id-card"></i>
                                            </span>
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
                                            <span class="input-group-text">
                                                <i class="far fa-calendar-alt"></i>
                                            </span>
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
                                <!-- cua/nua -->
                            <div class="form-group col-md-4">
                                <label class="form-control-label" for="Txt_per_ap_materno">NUA/CUA</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="txtNuaCua" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtNuaCua" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                            <!-- FORMACIÓN ACADÉMICA -->
                            <div class="form-group col-md-5">
                                <label class="form-control-label" for="DdlFormacion">ÚLTIMO GRADO ACADÉMICO ADQUIRIDO</label>
                                <asp:DropDownList ID="DdlFormacion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="DdlFormacion" ValidationGroup="aeditdd" InitialValue="0" Display="Dynamic" runat="server" />
                            </div>

                            </div>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnGuardarM" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" OnClick="BtnGuardarM_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelarM" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="BtnCancelarM_Click" runat="server" />
                        </div>
        <asp:HiddenField ID="hdf_nua" runat="server" /> <asp:HiddenField ID="hdf_ef_id" runat="server" />

            </div>
        </div>
    </div>

    <!-- Edit Record Modal Ends here -->

    <!-- Family Record Modal Starts here -->
    <div id="familyModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="familyTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="familyTitle" class="modal-title">Familiares</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <asp:HiddenField ID="Hf_per_id_f" runat="server" />
                            <div class="row">
                                <!-- Diseño para el dropdownlist de tipo parentesco -->
                                <div class="form-group col-md-4">
                                    <label class="form-control-label" for="Ddl_pf_tipo_parentesco">Tipo Parentesco</label>
                                    <asp:DropDownList ID="Ddl_pf_tipo_parentesco" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_pf_tipo_parentesco" ValidationGroup="family" InitialValue="0" Display="Dynamic" runat="server" />
                                </div>
                                <!-- Diseño para el textbox de nombre(s) -->
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
                                <!-- Diseño para el textbox de apellido paterno -->
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
                                <!-- Diseño para el textbox de apellido materno -->
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
                                <!-- Diseño para el textbox de apellido del esposo -->
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
                            <asp:LinkButton ID="BtnGuardarF" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="family" OnClick="BtnGuardarF_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelarF" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="BtnCancelarF_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Family Record Modal Ends here -->

    <!-- Glosa Record Modal Starts here -->
    <div id="glosaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="glosaTitle" class="modal-title">Registro Glosa</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="form-group col-md-6">
                                    <label class="form-control-label" for="Ddl_tipo_doc">Tipo Documento</label>
                                    <asp:DropDownList ID="Ddl_gl_tipo_doc" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_gl_tipo_doc" ValidationGroup="glosa" InitialValue="0" Display="Dynamic" runat="server" />
                                </div>
                                <div class="form-group col-md-6">
                                    <label class="form-control-label" for="txt_gl_fecha_doc">Fecha Documento</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-calendar-alt"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="txt_gl_fecha_doc" class="form-control datepicker" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_gl_fecha_doc" ValidationGroup="glosa" Display="Dynamic" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label class="form-control-label" for="txt_gl_glosa">Descripción</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-edit"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="txt_gl_glosa" CssClass="form-control" TextMode="multiline" Rows="4" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_gl_glosa" ValidationGroup="glosa" Display="Dynamic" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnGuardarG" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="glosa" OnClick="BtnGuardarG_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelarG" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="BtnCancelarG_Click" runat="server" />
                        </div>
            </div>
        </div>
    </div>
    <!-- Glosa Record Modal Ends here -->

    <!-- Verificación de CI antes de insertar nuevo -->
    <div id="ciVerificacionModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5  class="modal-title">Nuevo Registro de Funcionario</h5>
                        <p class="text-sm mb-0">Ingrese el número completo de CI (con complemento si tiene) para verificación</p>
                    </div>
                </div>
                <div class="modal-body">
                   <div class="row">
                        <asp:TextBox ID="txtCIVerificacion" class="form-control"  runat="server" />

                   </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="btnVerificarCi" CssClass="btn btn-success" Text="<i class='fas fa-check'></i> Verificar" OnClick="btnVerificarCi_Click"  runat="server" />
                            <asp:LinkButton ID="btnCancelarVerificacionCI" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar"  OnClick="btnCancelarVerificacionCI_Click" runat="server" />
                        </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Verificación de CI antes de insertar nuevo -->
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger  ControlID="btnVerificarCi" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnCancelarVerificacionCI" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnCancelarM" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnGuardarM" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelPersona" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

