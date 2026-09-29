<%@ Page Title="Administración de Declaración Jurada" Language="C#"
    MasterPageFile="~/MasterPageSIGRH.master"
    AutoEventWireup="true"
    CodeFile="AdmFiliacionUpdate.aspx.cs"
    Inherits="Kardex_AdmFiliacionUpdate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!-- Header -->
    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Declaración Jurada</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Page content -->
    <div class="container-fluid mt--6">

        <!-- ══════════════ PANEL DE BÚSQUEDA ══════════════ -->
        <div class="card">
            <div class="card-header">
                <div class="ct-page-title">
                    <h3 class="mb-0">Búsqueda de Personal</h3>
                    <p class="text-sm mb-0">Ingrese uno o más criterios para buscar.</p>
                </div>
            </div>

            <asp:UpdatePanel ID="Up_busqueda" runat="server">
                <ContentTemplate>
                    <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">

                        <!-- ═══════════════ FILA 1: Apellidos, Nombre y Botón Estadísticas ═══════════════ -->
                        <div class="row">
                            <!-- Apellido Paterno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_ap_paterno_b">Apellido Paterno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_ap_paterno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>

                            <!-- Apellido Materno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_ap_materno_b">Apellido Materno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_ap_materno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>

                            <!-- Nombres -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_nombres_b">Nombre(s)</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_nombres_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>

                            <!-- ✅ Botón Estadísticas (esquina superior derecha) -->
                            <div class="form-group col-md-3 align-self-end">
                                <asp:LinkButton ID="BtnEstadisticas" CssClass="btn btn-primary btn-block"
                                    Text="<i class='fas fa-chart-pie me-2'></i> Estadísticas"
                                    OnClick="BtnEstadisticas_Click" runat="server" />
                            </div>
                        </div>

                        <!-- ═══════════════ FILA 2: CI, Código y Botón Buscar ═══════════════ -->
                        <div class="row">
                            <!-- Carnet de Identidad -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_ci_b">Carnet de Identidad</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_ci_b" CssClass="form-control numero" runat="server" />
                                </div>
                            </div>

                            <!-- Código de Funcionario -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_id_b">Código de Funcionario</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_id_b" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>

                            <!-- Espacio vacío -->
                            <div class="form-group col-md-3"></div>

                            <!-- Botón Buscar (esquina inferior derecha) -->
                            <div class="form-group col-md-3 align-self-end">
                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block"
                                    Text="<i class='fas fa-search me-2'></i> Buscar"
                                    OnClick="BtnBuscar_Click" runat="server" />
                            </div>
                        </div>

                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- ══════════════ GRILLA DE RESULTADOS ══════════════ -->
        <asp:UpdatePanel ID="Up_busqueda_lista" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_busqueda_lista" CssClass="card mt-3" Visible="false" runat="server">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Resultados</h3>
                            <p class="text-sm mb-0">Lista con los resultados de la búsqueda.</p>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="Gv_busqueda_lista"
                            CssClass="table table-bordered table-hover table-striped"
                            AutoGenerateColumns="false"
                            DataKeyNames="dj_id"
                            OnPreRender="Gv_busqueda_lista_PreRender"
                            OnRowCommand="Gv_busqueda_lista_RowCommand"
                            OnRowDataBound="Gv_busqueda_lista_RowDataBound"
                            runat="server">
                            <Columns>
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="apellido_paterno" HeaderText="Apellido Paterno" />
                                <asp:BoundField DataField="apellido_materno" HeaderText="Apellido Materno" />
                                <asp:BoundField DataField="nombre" HeaderText="Nombre(s)" />
                                <asp:BoundField DataField="apellido_casada" HeaderText="Ap. Casada" />
                                <asp:BoundField DataField="ci" HeaderText="C.I." />
                                <asp:BoundField DataField="dj_gestion" HeaderText="Gestión" />

                                <%-- ✅ Nueva columna con el texto "Vigente" / "Finalizado" --%>
                                <asp:BoundField DataField="estado_descripcion" HeaderText="Estado"
                                    HeaderStyle-CssClass="text-center"
                                    ItemStyle-CssClass="text-center" />

                                <asp:TemplateField HeaderText="Acción"
                                    HeaderStyle-CssClass="text-center"
                                    ItemStyle-CssClass="text-center"
                                    HeaderStyle-Width="120px">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server"
                                            CommandName="EditarEstado"
                                            CommandArgument='<%# Container.DataItemIndex %>'
                                            CssClass="btn btn-warning btn-sm"
                                            Visible='<%# Eval("dj_estado").ToString() == "F" %>'
                                            Text="<i class='fas fa-edit'></i> Editar Estado"
                                            data-toggle='tooltip' data-placement='top' title='Editar Estado' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>

    </div>

    <!-- ══════════════ MODAL: EDITAR ESTADO DDJJ ══════════════ -->
    <div id="estadoModal" class="modal fade" tabindex="-1" role="dialog"
        aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_form_estado" runat="server">
                    <ContentTemplate>

                        <asp:HiddenField ID="Hf_dj_id" runat="server" />
                        <asp:HiddenField ID="Hf_per_id_estado" runat="server" />

                        <div class="modal-header bg-gradient-primary text-white">
                            <h5 class="modal-title">
                                <i class="fas fa-file-signature me-2"></i>Editar Estado de Declaración Jurada
                            </h5>
                        </div>

                        <div class="modal-body">
                            <div class="alert alert-success border-0 shadow-sm p-2 text-white" role="alert" style="font-size: 0.9rem;">
                                <i class="text-success"></i>
                                <strong>Funcionario:</strong>
                                <asp:Literal ID="Lt_nombre_estado" runat="server" /><br />
                                <strong>CI:</strong>
                                <asp:Literal ID="Lt_ci_estado" runat="server" /><br />
                                <strong>Código:</strong>
                                <asp:Literal ID="Lt_per_id_estado" runat="server" /><br />
                                <strong>Gestión:</strong>
                                <asp:Literal ID="Lt_gestion_estado" runat="server" />
                            </div>

                            <div class="form-group d-flex align-items-center gap-2">
                                <label class="form-control-label fw-bold mb-0">Estado actual:</label>
                                <span class="badge bg-danger fs-6" id="badge-estado-actual">
                                    <asp:Literal ID="Lt_estado_actual" runat="server" Text="Finalizado" />
                                </span>
                            </div>

                            <div class="form-group">
                                <label class="form-control-label" for="Ddl_nuevo_estado">
                                    Nuevo Estado <span class="text-danger">*</span>
                                </label>
                                <asp:DropDownList ID="Ddl_nuevo_estado" CssClass="form-control form-select" runat="server">
                                    <asp:ListItem Text="-- Seleccione --" Value="" />
                                    <asp:ListItem Text="Vigente (V) - Permite edición" Value="V" />

                                </asp:DropDownList>
                            </div>

                            <div class="alert alert-warning small mb-0">
                                <i class="fas fa-exclamation-triangle me-1"></i>
                                Al cambiar el estado a <strong>Vigente (V)</strong>, el funcionario podrá editar nuevamente su DDJJ.
                                Al cambiar a <strong>Finalizada (F)</strong>, no podrá editarla.
                            </div>

                        </div>

                        <div class="modal-footer">
                            <asp:LinkButton ID="BtnCancelarEstado" CssClass="btn btn-outline-secondary"
                                Text="<i class='fas fa-times mr-2'></i> Cancelar"
                                OnClick="BtnCancelarEstado_Click" runat="server" />

                            <asp:LinkButton ID="BtnGuardarEstado" CssClass="btn btn-success"
                                Text="<i class='fas fa-check mr-2'></i> Guardar"
                                OnClick="BtnGuardarEstado_Click" runat="server" />
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- UpdateProgress -->
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_busqueda" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_busqueda_lista" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_estado" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_estadisticas" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <!-- ══════════════ MODAL: ESTADÍSTICAS DDJJ ══════════════ -->
    <div id="estadisticasModal" class="modal fade" tabindex="-1" role="dialog"
        aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content border-0 shadow-lg">

                <div class="modal-header bg-gradient-primary text-white">
                    <h5 class="modal-title">
                        <i class="fas fa-chart-pie me-2"></i>Resumen de Declaraciones Juradas
                    </h5>
                </div>

                <asp:UpdatePanel ID="Up_estadisticas" runat="server">
                    <ContentTemplate>

                        <div class="modal-body p-3">

                            <!-- Fila con espaciado ajustado (g-2 reduce el espacio entre columnas) -->
                            <div class="row g-2 text-center">

                                <!-- Total Personas -->
                                <div class="col-6 col-lg-3">
                                    <div class="card border-0 shadow-sm h-100 py-2 px-1">
                                        <div class="card-body p-2">
                                            <div class="icon icon-shape bg-gradient-primary text-white rounded-circle shadow-sm mb-2 mx-auto">
                                                <i class="fas fa-users"></i>
                                            </div>
                                            <h6 class="text-muted text-uppercase small fw-semibold mb-1" style="font-size: 0.75rem;">Total Personas</h6>
                                            <h3 class="fw-bold mb-0">
                                                <asp:Literal ID="Lt_total_personas" runat="server" Text="0" />
                                            </h3>
                                        </div>
                                    </div>
                                </div>

                                <!-- Vigentes -->
                                <div class="col-6 col-lg-3">
                                    <div class="card border-0 shadow-sm h-100 py-2 px-1">
                                        <div class="card-body p-2">
                                            <div class="icon icon-shape bg-gradient-success text-white rounded-circle shadow-sm mb-2 mx-auto">
                                                <i class="fas fa-check-circle"></i>
                                            </div>
                                            <h6 class="text-muted text-uppercase small fw-semibold mb-1" style="font-size: 0.75rem;">Vigentes</h6>
                                            <h3 class="fw-bold text-success mb-0">
                                                <asp:Literal ID="Lt_total_vigentes" runat="server" Text="0" />
                                            </h3>
                                        </div>
                                    </div>
                                </div>

                                <!-- Finalizadas -->
                                <div class="col-6 col-lg-3">
                                    <div class="card border-0 shadow-sm h-100 py-2 px-1">
                                        <div class="card-body p-2">
                                            <div class="icon icon-shape bg-gradient-danger text-white rounded-circle shadow-sm mb-2 mx-auto">
                                                <i class="fas fa-lock"></i>
                                            </div>
                                            <h6 class="text-muted text-uppercase small fw-semibold mb-1" style="font-size: 0.75rem;">Finalizadas</h6>
                                            <h3 class="fw-bold text-danger mb-0">
                                                <asp:Literal ID="Lt_total_finalizadas" runat="server" Text="0" />
                                            </h3>
                                        </div>
                                    </div>
                                </div>

                                <!-- Sin Declaración -->
                                <div class="col-6 col-lg-3">
                                    <div class="card border-0 shadow-sm h-100 py-2 px-1">
                                        <div class="card-body p-2">
                                            <div class="icon icon-shape bg-gradient-warning text-white rounded-circle shadow-sm mb-2 mx-auto">
                                                <i class="fas fa-user-clock"></i>
                                            </div>
                                            <h6 class="text-muted text-uppercase small fw-semibold mb-1" style="font-size: 0.75rem;">Sin Declaración</h6>
                                            <h3 class="fw-bold text-warning mb-0">
                                                <asp:Literal ID="Lt_total_sin_declaracion" runat="server" Text="0" />
                                            </h3>
                                        </div>
                                    </div>
                                </div>

                            </div>

                            <!-- Alerta informativa compacta -->
                            <div class="alert alert-info border-0 shadow-sm mb-0 mt-2 p-2 small text-muted" style="font-size: 0.8rem;">
                                <i class="fas fa-info-circle me-1 text-info"></i>
                                Se considera la <strong>última declaración</strong> registrada por persona (por gestión más reciente). Las personas sin declaración son aquellas que nunca han iniciado su DDJJ en el sistema.
                            </div>

                        </div>

                        <div class="modal-footer py-2 px-3">
                            <asp:LinkButton ID="BtnCerrarEstadisticas" CssClass="btn btn-sm btn-outline-secondary px-3"
                                Text="<i class='fas fa-times me-1'></i> Cerrar"
                                OnClick="BtnCerrarEstadisticas_Click" runat="server" />
                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>
</asp:Content>
