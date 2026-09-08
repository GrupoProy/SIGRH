<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Menu.aspx.cs" Inherits="Seguridad_Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración del Menú</h6>
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
                    <h3 class="mb-0">Menú</h3>
                    <p class="text-sm mb-0">En la siguiente lista puede eliminar, modificar o crear nuevos items de menú.</p>
                </div>
            </div>
            <div class="card-body">
                <asp:UpdatePanel ID="Up_form" runat="server">
                    <ContentTemplate>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:TreeView ID="TvMenu" CssClass="treeView" ImageSet="Arrows" OnTreeNodeExpanded="TvMenu_TreeNodeExpanded" OnTreeNodeCollapsed="TvMenu_TreeNodeCollapsed" OnSelectedNodeChanged="TvMenu_SelectedNodeChanged" runat="server">
                                    <NodeStyle Font-Size=".875em" ForeColor="#525f7f" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                    <SelectedNodeStyle CssClass="SelectedNodeTreeView" />
                                    <HoverNodeStyle CssClass="HoverTreeView" />
                                </asp:TreeView>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Modal component -->
    <!-- Add Record Modal Starts here -->
    <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="addTitle" class="modal-title">Nuevo Registro</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                <asp:UpdatePanel ID="Up_add" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <asp:HiddenField ID="Hf_me_id" runat="server" />
                            <asp:HiddenField ID="Hf_me_icono" runat="server" />
                            <asp:HiddenField ID="Hf_me_id_padre" runat="server" />
                            <!-- me_descripcion -->
                            <div class="form-group">
                                <label class="form-control-label" for="Txt_me_descripcion">Descripción</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_me_descripcion" CssClass="form-control" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_me_descripcion" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!-- me_url -->
                            <div class="form-group">
                                <label class="form-control-label" for="Txt_me_url">Url / Dirección Web</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_me_url" CssClass="form-control" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_me_url" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                            <!--me_vista -->
                            <div class="form-group">
                                <label class="form-control-label" for="Rbl_me_vista">Desplegar / Mostrar en el menú</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="Rbl_me_vista" CssClass="radios" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="1" Text="SI" />
                                        <asp:ListItem Value="0" Text="NO" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Rbl_me_vista" ValidationGroup="add" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="BtnCancelar_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Add Record Modal Ends here -->

    <!-- Edit Modal Starts here -->
    <div id="editModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="editTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="editTitle" class="modal-title">Editar Registro</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                <asp:UpdatePanel ID="Up_edit" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <asp:HiddenField ID="Hf_me_id_m" runat="server" />
                            <asp:HiddenField ID="Hf_me_icono_m" runat="server" />
                            <asp:HiddenField ID="Hf_me_id_padre_m" runat="server" />
                            <!-- me_descripcion -->
                            <div class="form-group">
                                <label class="form-control-label" for="Txt_me_descripcion_m">Descripción</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_me_descripcion_m" CssClass="form-control" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_me_descripcion_m" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                            <!-- me_url -->
                            <div class="form-group">
                                <label class="form-control-label" for="Txt_me_url_m">Url / Dirección Web</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_me_url_m" CssClass="form-control" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_me_url_m" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                            <!-- me_vista -->
                            <div class="form-group">
                                <label class="form-control-label" for="Rbl_me_vista_m">Desplegar / Mostrar en el menú</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="Rbl_me_vista_m" CssClass="radios" RepeatDirection="Horizontal" runat="server">
                                        <asp:ListItem Value="1" Text="SI" />
                                        <asp:ListItem Value="0" Text="NO" />
                                    </asp:RadioButtonList>
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Rbl_me_vista_m" ValidationGroup="edit" Display="Dynamic" runat="server" />
                            </div>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-sm bg-gradient-inst text-white" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Nuevo Registro" OnClick="BtnNuevo_Click" runat="server" />
                            <asp:LinkButton ID="BtnEliminar" CssClass="btn btn-danger btn-sm" Text="<i class='fas fa-trash'></i>" data-toggle="tooltip" data-original-title="Eliminar Registro" OnClick="BtnEliminar_Click" runat="server" />
                            <asp:LinkButton ID="BtnGuardarM" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="edit" OnClick="BtnGuardarM_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelarM" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="BtnCancelarM_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Edit Modal Ends here -->

    <!-- Delete Record Modal Starts here -->
    <div id="deleteModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="deleteTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="deleteTitle" class="modal-title">Eliminar Registro</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                <asp:UpdatePanel ID="Up_delete" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <asp:HiddenField ID="Hf_me_id_b" runat="server" />
                            <p>¿Seguro(a) qué quiere eliminar el registro?</p>
                            <!-- me_descripcion -->
                            <div class="progress-info">
                                <div class="tag-label">
                                    <span>Descripción:
                                        <span class="tag-label-content">
                                            <asp:Literal ID="Txt_me_descripcion_b" runat="server" />
                                        </span>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnGuardarB" CssClass="btn btn-success" Text="<i class='fas fa-check'></i> Si" OnClick="BtnGuardarB_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelarB" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> No" OnClick="BtnCancelarB_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Delete Record Modal Ends here -->

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_add" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_edit" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_delete" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
