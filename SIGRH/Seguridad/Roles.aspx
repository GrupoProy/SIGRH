<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Roles.aspx.cs" Inherits="Seguridad_Roles" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Roles</h6>
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
                    <h3 class="mb-0">Lista de Roles</h3>
                    <p class="text-sm mb-0">En la siguiente lista puede eliminar, modificar o crear nuevos roles.</p>
                </div>
            </div>
            <asp:UpdatePanel ID="Up_list" runat="server">
                <ContentTemplate>
                    <div class="card-body">
                        <asp:GridView ID="GvLista" CssClass="table table-bordered table-striped table-hover" AutoGenerateColumns="false" DataKeyNames="rol_id" OnPreRender="GvLista_PreRender" OnRowCommand="GvLista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="rol_id" HeaderText="Código" />
                                <asp:BoundField DataField="rol_descripcion" HeaderText="Descripción" />
                                <asp:BoundField DataField="rol_estado" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-pen'></i></span>" data-toggle='tooltip' data-original-title='Editar' runat="server" />
                                        <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-original-title='Eliminar' runat="server" />
                                        <asp:LinkButton CommandName="GetRolMenu" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-primary btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-unlock-alt'></i></span>" data-toggle='tooltip' data-original-title='Permisos' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- BtnNuevo -->
        <div class="col-lg-6 col-5 text-right">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Nuevo Registro" OnClick="BtnNuevo_Click" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
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
                            <!-- rol_descripcion -->
                            <div class="form-group">
                                <label class="form-control-label" for="Txt_rol_descripcion">Descripción</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_rol_descripcion" CssClass="form-control" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_rol_descripcion" ValidationGroup="add" Display="Dynamic" runat="server" />
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
                            <asp:HiddenField ID="Hf_rol_id_m" runat="server" />
                            <!-- rol_descripcion -->
                            <div class="form-group">
                                <label class="form-control-label" for="Txt_rol_descripcion_m">Descripción</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_rol_descripcion_m" CssClass="form-control" runat="server" />
                                </div>
                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_rol_descripcion_m" ValidationGroup="edit" Display="Dynamic" runat="server" />
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
                            <asp:HiddenField ID="Hf_rol_id_b" runat="server" />
                            <p>¿Seguro(a) qué quiere eliminar el registro?</p>
                            <!-- rol_descripcion -->
                            <div class="progress-info">
                                <div class="tag-label">
                                    <span>Descripción:
                                        <span class="tag-label-content">
                                            <asp:Literal ID="Txt_rol_descripcion_b" runat="server" />
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

    <!-- RolMenu Record Modal Starts here -->
    <div id="rolMenuModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="rolMenuTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <div class="ct-page-title">
                        <h5 id="rolMenuTitle" class="modal-title">Asignar Menú</h5>
                        <p class="text-sm mb-0"></p>
                    </div>
                </div>
                <asp:UpdatePanel ID="Up_form_rm" runat="server">
                    <ContentTemplate>
                        <div class="modal-body">
                            <asp:HiddenField ID="Hf_rol_id_rm" runat="server" />
                            <!-- rol_descripcion -->
                            <div class="progress-info">
                                <div class="tag-label">
                                    <span>Descripción:
                                        <span class="tag-label-content">
                                            <asp:Literal ID="Txt_rolme_me_id" runat="server" />
                                        </span>
                                    </span>
                                </div>
                            </div>
                            <asp:TreeView ID="TvMenu" CssClass="treeView" ImageSet="Arrows" OnTreeNodeExpanded="TvMenu_TreeNodeExpanded" OnTreeNodeCollapsed="TvMenu_TreeNodeCollapsed" OnSelectedNodeChanged="TvMenu_SelectedNodeChanged" runat="server">
                                <NodeStyle Font-Size=".875em" ForeColor="#525f7f" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                    <SelectedNodeStyle CssClass="SelectedNodeTreeView" />
                                    <HoverNodeStyle CssClass="HoverTreeView" />
                            </asp:TreeView>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnGuardarRM" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" OnClick="BtnGuardarRM_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelarRM" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="BtnCancelarRM_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- RolMenu Record Modal Ends here -->

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_list" runat="server">
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
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_rm" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <script>
        function OnTreeClick(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target
            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox")

            if (isChkBoxClick) {
                var parentTable = GetParentByTagName("table", src)
                var nxtSibling = parentTable.nextSibling

                if (nxtSibling && nxtSibling.nodeType == 1)
                    if (nxtSibling.tagName.toLowerCase() == "div") CheckUncheckChildren(parentTable.nextSibling, src.checked)
                CheckUncheckParents(src, src.checked)
            }
        }

        function CheckUncheckChildren(childContainer, check) {
            var childChkBoxes = childContainer.getElementsByTagName("input")
            var childChkBoxCount = childChkBoxes.length

            for (var i = 0; i < childChkBoxCount; i++) { childChkBoxes[i].checked = check }
        }

        function CheckUncheckParents(srcChild, check) {
            var parentDiv = GetParentByTagName("div", srcChild)
            var parentNodeTable = parentDiv.previousSibling

            if (parentNodeTable) {
                var checkUncheckSwitch

                if (check) checkUncheckSwitch = true
                else {
                    var isAllSiblingsUnChecked = AreAllSiblingsUnChecked(srcChild)

                    if (!isAllSiblingsUnChecked) checkUncheckSwitch = true
                    else checkUncheckSwitch = false
                }
                var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input")

                if (inpElemsInParentTable.length > 0) {
                    var parentNodeChkBox = inpElemsInParentTable[0]
                    parentNodeChkBox.checked = checkUncheckSwitch
                    CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch)
                }
            }
        }

        function AreAllSiblingsUnChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox)
            var childCount = parentDiv.childNodes.length

            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) {
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0]

                        if (prevChkBox.checked) return false
                    }
                }
            }
            return true
        }

        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode

            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase()) { parent = parent.parentNode }
            return parent
        }
    </script>
</asp:Content>
