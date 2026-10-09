<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="TipoItem.aspx.cs" Inherits="Mantenimiento_TipoItem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Tipo Ítem</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <asp:UpdatePanel ID="Up_tipo_item_lista" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_tipo_item_lista" class="card" Visible="false" runat="server">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Lista de Tipos de Ítem</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="Gv_tipo_item_lista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="ti_item" OnPreRender="Gv_tipo_item_lista_PreRender" OnRowCommand="Gv_tipo_item_lista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="ti_item" HeaderText="Ítem" />
                                <asp:BoundField DataField="ti_descripcion" HeaderText="Descripción" />
                                <asp:BoundField DataField="ti_tipo" HeaderText="Tipo Ítem" />
                                <asp:BoundField DataField="ti_item_suplencia" HeaderText="Ítem Suplencia" />
                                <asp:BoundField DataField="ti_tipo_item_gral" HeaderText="Tipo Ítem General" />
                                <asp:BoundField DataField="ti_tipo_pago" HeaderText="Pago" />
                                <asp:BoundField DataField="ti_orden" HeaderText="Orden" />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="BtnGlosa" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>" data-toggle="tooltip" data-original-title="Glosa" runat="server" />
                                        <%--<asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-original-title='Anular' runat="server" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- Diseño para el botón nuevo registro -->
        <div class="col-lg-6 col-5 text-right">
            <asp:UpdatePanel ID="Up_nuevo" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Nuevo Registro" OnClick="BtnNuevo_Click" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <!-- Modal component -->
    <!-- Tipo Ítem Record Modal Starts here -->
    <div id="tipoItemModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="tipoItemTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_tipo_item_form" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>TIPO ÍTEM</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <div class="row">
                                        <!-- ti_item -->
                                        <div class="form-group col-md-4">
                                            <label class="form-control-label" for="Txt_ti_item">Ítem</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_ti_item" CssClass="form-control" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ti_item" ValidationGroup="add" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- ti_descripcion -->
                                        <div class="form-group col-md-8">
                                            <label class="form-control-label" for="Txt_ti_descripcion">Descripción</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_ti_descripcion" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ti_descripcion" ValidationGroup="add" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- ti_tipo -->
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="form-group col-md-12">
                                                    <label class="form-control-label" for="Ddl_ti_tipo">Tipo Ítem</label>
                                                    <asp:DropDownList ID="Ddl_ti_tipo" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="Ddl_ti_tipo_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_ti_tipo" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                                </div>
                                                <asp:Panel ID="P_ti_tipo" class="form-group col-md-12" Visible="false" runat="server">
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="fas fa-edit"></i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_ti_tipo" CssClass="form-control" ValidationGroup="add" placeholder="Ej.: FC, FE, FD, FP" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ti_tipo" ValidationGroup="add" Display="Dynamic" runat="server" />
                                                </asp:Panel>
                                            </div>
                                        </div>
                                        <!-- ti_item_suplencia -->
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="form-group col-md-12">
                                                    <label class="form-control-label" for="Ddl_ti_item_suplencia">Ítem Suplencia</label>
                                                    <asp:DropDownList ID="Ddl_ti_item_suplencia" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="Ddl_ti_item_suplencia_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                                </div>
                                                <asp:Panel ID="P_ti_item_suplencia" class="form-group col-md-12" Visible="false" runat="server">
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="fas fa-edit"></i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_ti_item_suplencia" CssClass="form-control" ValidationGroup="add" placeholder="Ej.: S, BVS, CMS, DFS" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ti_item_suplencia" ValidationGroup="add" Display="Dynamic" runat="server" />
                                                </asp:Panel>
                                            </div>
                                        </div>
                                        <!-- ti_tipo_item_gral -->
                                        <div class="col-md-6">
                                            <div class="row">
                                                <div class="form-group col-md-12">
                                                    <label class="form-control-label" for="Ddl_ti_tipo_item_gral">Tipo Ítem General</label>
                                                    <asp:DropDownList ID="Ddl_ti_tipo_item_gral" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="Ddl_ti_tipo_item_gral_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_ti_tipo_item_gral" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                                </div>
                                                <asp:Panel ID="P_ti_tipo_item_gral" class="form-group col-md-12" Visible="false" runat="server">
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text">
                                                                <i class="fas fa-edit"></i>
                                                            </span>
                                                        </div>
                                                        <asp:TextBox ID="Txt_ti_tipo_item_gral" CssClass="form-control" ValidationGroup="add" placeholder="Ej.: P, C" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_ti_tipo_item_gral" ValidationGroup="add" Display="Dynamic" runat="server" />
                                                </asp:Panel>
                                            </div>
                                        </div>
                                        <!-- ti_tipo_pago -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label pb-3" for="Chk_ti_tipo_pago">Pago</label>
                                            <div>
                                                <label class="custom-toggle custom-toggle-warning">
                                                    <asp:CheckBox ID="Chk_ti_tipo_pago" runat="server" />
                                                    <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                                </label>
                                            </div>
                                        </div>
                                        <!-- ti_orden -->
                                        <!-- ti_control -->
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelar_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Tipo Ítem Record Modal Ends here -->

    <!-- Glosa Record Modal Starts here -->
    <div id="glosaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_glosa" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>GLOSA</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <div class="row">
                                        <!-- gl_tipo_doc -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Ddl_tipo_doc">Tipo Documento</label>
                                            <asp:DropDownList ID="Ddl_gl_tipo_doc" CssClass="form-control select2" AppendDataBoundItems="true" ClientIDMode="Static" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_gl_tipo_doc" ValidationGroup="glosa" InitialValue="0" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- gl_fecha_doc -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_gl_fecha_doc">Fecha Documento</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-calendar-alt"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_gl_fecha_doc" class="form-control datepickerDefault" ClientIDMode="Static" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_gl_fecha_doc" ValidationGroup="glosa" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- gl_glosa -->
                                        <div class="form-group col-md-12">
                                            <label class="form-control-label" for="Txt_gl_glosa">Descripción</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_gl_glosa" CssClass="form-control" TextMode="multiline" Rows="4" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_gl_glosa" ValidationGroup="glosa" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarG" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="glosa" OnClick="BtnGuardarG_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarG" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarG_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Glosa Record Modal Ends here -->

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_tipo_item_lista" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_tipo_item_form" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
