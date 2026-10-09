<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="UsuariosPermisos.aspx.cs" Inherits="Seguridad_UsuariosPermisos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <!-- ESTILO SOLO PARA EL DROPDOWN Y EL TREEVIEW (SIN TOCAR LA CABECERA) -->
    <style>
        /* Estilo del DropDownList (Select2) */
        .select2-container .select2-selection--single {
            height: 38px !important;
            padding: 6px 12px;
            font-size: 0.9rem;
            border: 1px solid #d2d6da;
            border-radius: 4px;
            background-color: #fff;
            box-shadow: none;
        }
        .select2-container .select2-selection--single .select2-selection__arrow {
            height: 36px;
            right: 10px;
        }
        .select2-container--default .select2-selection--single .select2-selection__rendered {
            line-height: 26px;
            color: #32325d;
        }
        .select2-dropdown {
            border: 1px solid #d2d6da;
            border-radius: 4px;
            box-shadow: 0 4px 8px rgba(0,0,0,0.1);
        }
        .select2-results__option {
            padding: 8px 12px;
            font-size: 0.9rem;
        }
        .select2-results__option--highlighted {
            background-color: #5e72e4;
            color: #fff;
        }

        /* Estilo del TreeView */
        .treeView {
            font-size: 0.9rem;
            padding: 5px;
        }
        .treeView td {
            white-space: normal; 
            word-break: break-word;
            vertical-align: middle;
        }
        .treeView .badge-circle {
            min-width: 20px;
            font-size: 0.7rem;
            padding: 4px;
        }
    </style>

    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Permisos</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Page content -->
    <div class="container-fluid mt--6">
        <asp:UpdatePanel ID="Up_info" runat="server">
            <ContentTemplate>
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <!-- COLUMNA IZQUIERDA: FOTO Y DATOS (ESTILO ORIGINAL) -->
                            <div class="col-lg-3 text-center">
                                <asp:Image ID="Img_fp_foto" CssClass="rounded-circle shadow mx-auto d-block" Style="width: 120px; height: 120px; object-fit: cover;" runat="server" />
                                <br />
                                <asp:Label ID="Lbl_as_estado" CssClass="btn btn-sm btn-info" runat="server" />
                                <h5 class="h3 mt-2">
                                    <asp:Literal ID="Lt_per_nombres" runat="server" />
                                </h5>
                                <div class="h5 font-weight-400 mt-3">
                                    <strong class="d-block">CI:</strong> <asp:Literal ID="Lt_per_num_doc" runat="server" />
                                    <strong class="d-block mt-2">CÓDIGO:</strong> <asp:Literal ID="Lt_per_id" runat="server" />
                                    <strong class="d-block mt-2">ÍTEM:</strong> <asp:Literal ID="Lt_ca_num_item" runat="server" />
                                </div>
                            </div>

                            <!-- COLUMNA DERECHA: DATOS LABORALES (ESTILO ORIGINAL) -->
                            <div class="col-lg-9">
                                <hr class="my-3" />
                                <div class="row">
                                    <div class="col-lg-6">
                                        <h6 class="heading-small text-muted">Escalafón</h6>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Cargo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_es_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Puesto</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_puesto" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Haber Básico (Bs)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ca_basico_calculado" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Código Escalafón</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_es_escalafon" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Clase</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ns_clase" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Nivel Salarial</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ns_nivel" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <h6 class="heading-small text-muted">Información Fecha Asignación</h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Fecha Alta</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_as_fecha_inicio" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Fecha Baja</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_as_fecha_fin" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <hr class="my-3" />
                                <div class="row">
                                    <div class="col-lg-6">
                                        <h6 class="heading-small text-muted">Categoría Administrativa</h6>
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_eo_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Categoría</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_eo_prog" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-6">
                                        <h6 class="heading-small text-muted">Categoría Programática</h6>
                                        <div class="row">
                                            <div class="col-lg-8">
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_cp_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Categoría</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_cp_da" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>

        <!-- SECCIÓN ASIGNAR ROLES (CON DROPDOWN ESTILIZADO) -->
        <div class="row">
            <div class="col-lg-5">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Asignar Roles</h3>
                            <p class="text-sm mb-0">Seleccione un rol, marque los permisos y guarde. Puede quitar roles ya asignados.</p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_r" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <div class="card-body">
                                <!-- Roles ya asignados -->
                                <div class="form-group">
                                    <label class="form-control-label font-weight-bold">Roles asignados actualmente</label>
                                    <asp:GridView ID="Gv_roles" CssClass="table table-sm table-bordered" AutoGenerateColumns="false"
                                        OnRowCommand="Gv_roles_RowCommand" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="rol_descripcion" HeaderText="Rol" />
                                            <asp:TemplateField HeaderText="" ItemStyle-Width="80px">
                                                <ItemTemplate>
                                                    <asp:LinkButton runat="server" CssClass="btn btn-sm btn-danger"
                                                        CommandName="Quitar"
                                                        CommandArgument='<%# Eval("usrol_id") %>'
                                                        OnClientClick="return confirm('¿Quitar este rol al usuario?');">
                                                        <i class="fas fa-times"></i>
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <EmptyDataTemplate>Sin roles asignados.</EmptyDataTemplate>
                                    </asp:GridView>
                                </div>

                                <hr class="my-3" />

                                <!-- Dropdown con estilo -->
                                <div class="form-group">
                                    <label class="form-control-label font-weight-bold" for="Ddl_rol_id">Agregar rol</label>
                                    <asp:DropDownList ID="Ddl_rol_id" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="Ddl_rol_id_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ControlToValidate="Ddl_rol_id" ErrorMessage="(*) Campo Obligatorio" InitialValue="0" ValidationGroup="add" Display="Dynamic" runat="server" />
                                </div>

                                <!-- TreeView -->
                                <div class="form-group">
                                    <asp:TreeView ID="TvMenuR" CssClass="treeView" ImageSet="Arrows" OnTreeNodeExpanded="TvMenuR_TreeNodeExpanded" OnTreeNodeCollapsed="TvMenuR_TreeNodeCollapsed" OnSelectedNodeChanged="TvMenuR_SelectedNodeChanged" runat="server">
                                        <NodeStyle Font-Size=".875em" ForeColor="#525f7f" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                        <SelectedNodeStyle CssClass="SelectedNodeTreeView" />
                                        <HoverNodeStyle CssClass="HoverTreeView" />
                                    </asp:TreeView>
                                </div>

                                <!-- Botones -->
                                <div class="row mt-3">
                                    <div class="col-6 pr-1">
                                        <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success btn-block" Text="<i class='fas fa-plus'></i> Agregar Rol" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                                    </div>
                                    <div class="col-6 pl-1">
                                        <asp:LinkButton ID="BtnGuardarCambios" CssClass="btn btn-primary btn-block" Text="<i class='fas fa-save'></i> Guardar Cambios" OnClick="BtnGuardarCambios_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BtnGuardar" EventName="Click" />
                            <asp:AsyncPostBackTrigger ControlID="Gv_roles" EventName="RowCommand" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div> 

            <!-- Columnas ocultas -->
            <div class="col-lg-4" runat="server" visible="false">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Menú</h3>
                            <p class="text-sm mb-0">En el siguiente formulario puede seleccionar y asignar un item de menú de manera individual.</p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_mu" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <asp:TreeView ID="TvMenuU" CssClass="treeView" ImageSet="Arrows" OnTreeNodeExpanded="TvMenuU_TreeNodeExpanded" OnTreeNodeCollapsed="TvMenuU_TreeNodeCollapsed" OnSelectedNodeChanged="TvMenuU_SelectedNodeChanged" runat="server">
                                    <NodeStyle Font-Size=".875em" ForeColor="#525f7f" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px" />
                                    <SelectedNodeStyle CssClass="SelectedNodeTreeView" />
                                    <HoverNodeStyle CssClass="HoverTreeView" />
                                </asp:TreeView>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-4" runat="server" visible="false">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Permisos</h3>
                            <p class="text-sm mb-0">En el siguiente formulario puede seleccionar y asignar un permiso para precontrataciones.</p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_cp" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <div class="form-group">
                                    <label class="form-control-label" for="Ddl_cp_ue">Unidad Ejecutora</label>
                                    <asp:DropDownList ID="Ddl_cp_ue" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                                <div class="form-group">
                                    <label class="form-control-label" for="Ddl_meper_tipo_permiso">Tipo Permiso</label>
                                    <asp:DropDownList ID="Ddl_meper_tipo_permiso" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>

    <!-- SCRIPT PARA QUE EL DROPDOWN SE VEA BIEN (SOLO JS, NO TOCA NADA MÁS) -->
    <script type="text/javascript">
        function initSelect2() {
            $('.select2').select2({
                placeholder: { id: '0', text: 'Seleccione...' },
                width: '100%'
            });
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