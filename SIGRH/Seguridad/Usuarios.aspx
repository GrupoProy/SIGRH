<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Usuarios.aspx.cs" Inherits="Seguridad_Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Usuarios</h6>
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
                    <h3 class="mb-0">Lista de Usuarios</h3>
                    <p class="text-sm mb-0">En la siguiente lista puede eliminar, modificar o crear nuevos usuarios.</p>
                </div>
            </div>
            <asp:UpdatePanel ID="Up_list" runat="server">
                <ContentTemplate>
                    <div class="card-body">
                        <asp:GridView ID="GvLista" CssClass="table table-bordered table-striped table-hover" AutoGenerateColumns="false" DataKeyNames="us_id" OnPreRender="GvLista_PreRender" OnRowCommand="GvLista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="us_id" HeaderText="Código" />
                                <asp:BoundField DataField="us_usuario" HeaderText="Usuario" />
                                <asp:BoundField DataField="us_correo_interno" HeaderText="Correo Interno" />
                                <asp:BoundField DataField="us_nombre_equipo" HeaderText="Nombre Equipo" />
                                <asp:BoundField DataField="us_estado" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-pen'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar' runat="server" />
                                        <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                        <asp:LinkButton CommandName="GetUsuarioRol" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-primary btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-unlock-alt'></i></span>" data-toggle='tooltip' data-placement='top' title='Permisos' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- Diseño para el button nuevo registro -->
        <div class="col-lg-6 col-5 text-right">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Nuevo Registro" OnClick="BtnNuevo_Click" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <!-- Modal component -->

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
                            <asp:HiddenField ID="Hf_us_id_m" runat="server" />
                            <!-- Txt_us_per_id -->
                            <div class="progress-info">
                                <div class="tag-label">
                                    <span>Nombre Completo:
                                        <span class="tag-label-content">
                                            <asp:Literal ID="Txt_us_per_id_m" runat="server" />
                                        </span>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer border-top">
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
                            <asp:HiddenField ID="Hf_us_id_b" runat="server" />
                            <p>¿Seguro(a) qué quiere eliminar el registro?</p>
                            <!-- Txt_us_per_id -->
                            <div class="progress-info">
                                <div class="tag-label">
                                    <span>Nombre Completo:
                                        <span class="tag-label-content">
                                            <asp:Literal ID="Txt_us_per_id_b" runat="server" />
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

    <!-- Delete UsuarioRol Record Modal Starts here -->
    <div id="deleteUsuarioRolModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="deleteUsuarioRolTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="deleteUsuarioRolTitle" class="modal-title">Eliminar Registro</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                <asp:UpdatePanel ID="Up_form_ru" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <asp:HiddenField ID="Hf_usrol_rol_id" runat="server" />
                            <p>¿Seguro(a) qué quiere eliminar el registro?</p>
                            <!-- Txt_us_per_id -->
                            <div class="progress-info">
                                <div class="tag-label">
                                    <span>Nombre Completo:
                                        <span class="tag-label-content">
                                            <asp:Literal ID="Txt_rol_descripcion" runat="server" />
                                        </span>
                                    </span>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnGuardarBUR" CssClass="btn btn-success" Text="<i class='fas fa-check'></i> Si" OnClick="BtnGuardarBUR_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelarBUR" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> No" OnClick="BtnCancelarBUR_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Delete UsuarioRol Record Modal Ends here -->

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_list" runat="server">
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
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_ru" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
