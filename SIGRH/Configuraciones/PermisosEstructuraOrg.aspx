<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" 
    AutoEventWireup="true" 
    CodeFile="PermisosEstructuraOrg.aspx.cs" 
    Inherits="Configuraciones_PermisosEstructuraOrg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-12">
                        <h6 class="h2 text-light d-inline-block mb-0">Permisos por Estructura Organizacional</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Contenido -->
    <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Lista de Usuarios</h3>
                    <p class="text-sm mb-0">
                        Seleccione un usuario para asignarle las unidades organizacionales a las que tendrá acceso.
                    </p>
                </div>
            </div>

            <asp:UpdatePanel ID="Up_list" runat="server">
                <ContentTemplate>
                    <div class="card-body">

                        <!-- Buscador -->
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-search"></i></span>
                                    </div>
                                    <asp:TextBox ID="TxtBuscar" CssClass="form-control"
                                                 placeholder="Buscar por usuario"
                                                 runat="server" />
                                </div>
                            </div>
                            <div class="col-md-3">
                                <asp:LinkButton ID="btnBuscar" CssClass="btn btn-primary"
                                                Text="<i class='fas fa-search'></i> Buscar"
                                                runat="server" />
                            </div>
                        </div>

                        <!-- Grilla de usuarios -->
                        <asp:GridView ID="GvUsuarios"
                                      CssClass="table table-bordered table-striped table-hover"
                                      AutoGenerateColumns="false"
                                      DataKeyNames="us_id"
                                      OnPreRender="GvUsuarios_PreRender"
                                      OnRowCommand="GvUsuarios_RowCommand"
                                      runat="server">

                            <EmptyDataTemplate>
                                <div class="text-center text-muted py-4">
                                    <i class="fas fa-info-circle mr-1"></i>
                                    No existen usuarios registrados
                                </div>
                            </EmptyDataTemplate>

                            <Columns>
                                <asp:BoundField DataField="us_id"              HeaderText="Código" />
                                <asp:BoundField DataField="us_usuario"         HeaderText="Usuario" />
                                <asp:BoundField DataField="us_correo_interno"  HeaderText="Correo Interno" />
                                <asp:BoundField DataField="us_nombre_equipo"   HeaderText="Equipo" />
                                <asp:BoundField DataField="us_estado"          HeaderText="Estado" />

                                <asp:TemplateField HeaderText="Estructura Organizacional"
                                                   HeaderStyle-CssClass="text-center"
                                                   ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="GetPermisos"
                                                        CommandArgument="<%# Container.DataItemIndex %>"
                                                        CssClass="btn btn-primary btn-sm"
                                                        Text="<i class='fas fa-unlock-alt'></i> Asignar"
                                                        runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <!-- ============================================================ -->
    <!-- MODAL: Asignar Estructura Organizacional                    -->
    <!-- ============================================================ -->
    <div id="permisosModal" class="modal fade" tabindex="-1" role="dialog"
         aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">

                <asp:UpdatePanel ID="Up_permisos" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>

                        <!-- 👇 modal-header DENTRO del UpdatePanel -->
                        <div class="modal-header border-bottom">
                            <div class="ct-page-title">
                                <h5 class="modal-title">Asignar Estructura Organizacional</h5>
                                <p class="text-sm mb-0">
                                    Usuario: <b><asp:Literal ID="ltlUsuario" runat="server" /></b>
                                </p>
                            </div>
                        </div>

                        <div class="modal-body" style="max-height:500px; overflow-y:auto;">
                            <asp:HiddenField ID="Hf_per_id" runat="server" />

                            <p class="text-muted text-sm mb-3">
                                <i class="fas fa-info-circle mr-1"></i>
                                Marque las unidades organizacionales a las que tendrá acceso este usuario.
                            </p>

                            <asp:TreeView ID="TvEstructura"
                                          CssClass="treeView"
                                          ImageSet="Arrows"
                                          OnTreeNodePopulate="TvEstructura_TreeNodePopulate"
                                          runat="server">
                                <NodeStyle Font-Size=".875em" ForeColor="#525f7f"
                                           HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                <SelectedNodeStyle CssClass="SelectedNodeTreeView" />
                                <HoverNodeStyle CssClass="HoverTreeView" />
                            </asp:TreeView>
                        </div>

                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="BtnGuardarPermisos" CssClass="btn btn-success"
                                            Text="<i class='fas fa-save'></i> Guardar"
                                            OnClick="BtnGuardarPermisos_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelarPermisos" CssClass="btn btn-google-plus"
                                            Text="<i class='fas fa-times'></i> Cancelar"
                                            OnClick="BtnCancelarPermisos_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="BtnGuardarPermisos" EventName="Click" />
                        <asp:AsyncPostBackTrigger ControlID="BtnCancelarPermisos" EventName="Click" />
                    </Triggers>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_list" runat="server">
        <ProgressTemplate><div class="load"></div></ProgressTemplate>
    </asp:UpdateProgress>

    <!-- JS: checkboxes jerárquicos del TreeView -->
    <script>
        function OnTreeClick(evt) {
            var src = window.event != window.undefined ? window.event.srcElement : evt.target;
            var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox");
            if (isChkBoxClick) {
                var parentTable = GetParentByTagName("table", src);
                var nxtSibling = parentTable.nextSibling;
                if (nxtSibling && nxtSibling.nodeType == 1)
                    if (nxtSibling.tagName.toLowerCase() == "div")
                        CheckUncheckChildren(parentTable.nextSibling, src.checked);
                CheckUncheckParents(src, src.checked);
            }
        }
        function CheckUncheckChildren(childContainer, check) {
            var boxes = childContainer.getElementsByTagName("input");
            for (var i = 0; i < boxes.length; i++) boxes[i].checked = check;
        }
        function CheckUncheckParents(srcChild, check) {
            var parentDiv = GetParentByTagName("div", srcChild);
            var parentNodeTable = parentDiv.previousSibling;
            if (parentNodeTable) {
                var sw;
                if (check) sw = true;
                else sw = !AreAllSiblingsUnChecked(srcChild);
                var inp = parentNodeTable.getElementsByTagName("input");
                if (inp.length > 0) {
                    inp[0].checked = sw;
                    CheckUncheckParents(inp[0], sw);
                }
            }
        }
        function AreAllSiblingsUnChecked(chkBox) {
            var parentDiv = GetParentByTagName("div", chkBox);
            var childCount = parentDiv.childNodes.length;
            for (var i = 0; i < childCount; i++) {
                if (parentDiv.childNodes[i].nodeType == 1) {
                    if (parentDiv.childNodes[i].tagName.toLowerCase() == "table") {
                        var prev = parentDiv.childNodes[i].getElementsByTagName("input")[0];
                        if (prev.checked) return false;
                    }
                }
            }
            return true;
        }
        function GetParentByTagName(parentTagName, childElementObj) {
            var parent = childElementObj.parentNode;
            while (parent.tagName.toLowerCase() != parentTagName.toLowerCase())
                parent = parent.parentNode;
            return parent;
        }
    </script>
</asp:Content>