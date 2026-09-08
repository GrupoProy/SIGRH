<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListaSolicitudes.aspx.cs" Inherits="Precontratacion_ListaSolicitudes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel runat="server" ID="UpdatePanelContrataciones">
        <ContentTemplate>
            <!-- Header -->
            <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
                <div class="container-fluid">
                    <div class="header-body">
                        <div class="row align-items-center py-4">
                            <div class="col-lg-12">
                                <h6 class="h2 text-light d-inline-block mb-0">Búsqueda de Contrataciones</h6>
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
                            <h3 class="mb-0">Búsqueda de Solicitudes</h3>
                            <p class="text-sm mb-0">Busque las solicitudes de contratación por diferentes criterios.</p>
                        </div>
                    </div>
                    <asp:Panel CssClass="card-body" DefaultButton="btnBuscar" runat="server">
                        <div class="row">
                            <!-- Apellido Paterno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Apellido Paterno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtApPaterno_b" CssClass="form-control letras" placeholder="" runat="server" />
                                </div>
                            </div>
                            <!-- Apellido Materno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Apellido Materno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtApMaterno_b" CssClass="form-control letras" placeholder="" runat="server" />
                                </div>
                            </div>
                            <!-- Nombre(s) -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Nombre(s)</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtNombres_b" CssClass="form-control letras" placeholder="" runat="server" />
                                </div>
                            </div>
                            <!-- Carnet -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Carnet de Identidad</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-id-card"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtCI_b" CssClass="form-control numero" placeholder="" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <!-- Código de Solicitud -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label">Código de Funcionario</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text"><i class="fas fa-hashtag"></i></span>
                                    </div>
                                    <asp:TextBox ID="txtCodigo_b" CssClass="form-control numero" placeholder="" runat="server" />
                                </div>
                            </div>
                            <div class="form-group col-md-3">
                                <!-- ESPACIO VACÍO -->
                            </div>
                            <!-- Botón Buscar -->
                            <div class="form-group col-md-3">
                                <asp:LinkButton ID="btnBuscar" CssClass="btn btn-info btn-block top-4" Text="<i class='fas fa-search'></i> Buscar" OnClick="btnBuscar_Click" runat="server" />
                            </div>
                            <!-- Botón Nuevo -->
                            <div class="form-group col-md-3">
                                <button type="button" class="btn btn-warning btn-block top-4" data-toggle="modal" data-target="#modalVerificarCI">
                                    <i class="fas fa-plus"></i> Nuevo
                                </button>
                            </div>
                        </div>
                    </asp:Panel>
                </div>

                <!-- Resultados -->
                <div id="dResult" class="card" style="display:none;">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Resultado de Búsqueda</h3>
                            <p class="text-sm mb-0">Lista de solicitudes de contratación registradas.</p>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="table-responsive">
                            <!-- SIN LA COLUMNA DE ESTADO. SOLO ACCIONES INTELIGENTES -->
                            <asp:GridView ID="gvResultados" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="per_id" OnPreRender="gvResultados_PreRender" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="per_id" HeaderText="Código" />
                                    <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" />
                                    <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" />
                                    <asp:BoundField DataField="per_nombres" HeaderText="Nombre(s)" />
                                    <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />
                                    
                                    <asp:TemplateField HeaderText="Acciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <!-- BOTÓN ALTA: Solo visible si el estado NO es 'V' -->
                                            <asp:LinkButton ID="lnkAlta" runat="server" 
                                                PostBackUrl='<%# "ContratacionDescriptor.aspx?id=" + Eval("per_id") %>'
                                                CssClass="btn btn-sm btn-primary" 
                                                data-toggle="tooltip" title="Alta / Contrato"
                                                Visible='<%# (Eval("as_estado") == null || Eval("as_estado").ToString() != "V") %>'>
                                                <i class="fas fa-file-contract"></i>
                                            </asp:LinkButton>

                                            <!-- BOTÓN MODIFICACIÓN: Solo visible si el estado es 'V' -->
                                            <asp:LinkButton ID="lnkModificar" runat="server" 
                                                PostBackUrl='<%# "ContratacionModificacion.aspx?id=" + Eval("per_id") %>'
                                                CssClass="btn btn-sm btn-warning" 
                                                data-toggle="tooltip" title="Modificación"
                                                Visible='<%# (Eval("as_estado") != null && Eval("as_estado").ToString() == "V") %>'>
                                                <i class="fas fa-edit"></i>
                                            </asp:LinkButton>

                                            <!-- BOTÓN BAJA: Solo visible si el estado es 'V' -->
                                            <asp:LinkButton ID="lnkBaja" runat="server" 
                                                PostBackUrl='<%# "ContratacionResolucion.aspx?id=" + Eval("per_id") %>'
                                                CssClass="btn btn-sm btn-danger" 
                                                data-toggle="tooltip" title="Baja / Resolver"
                                                Visible='<%# (Eval("as_estado") != null && Eval("as_estado").ToString() == "V") %>'>
                                                <i class="fas fa-times-circle"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <!-- ============================================================ -->
            <!-- MODAL VERIFICAR CI -->
            <!-- ============================================================ -->
            <div id="modalVerificarCI" class="modal fade" tabindex="-1" role="dialog" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header border-bottom">
                            <div class="ct-page-title">
                                <h5 class="modal-title">Nuevo Registro de Funcionario</h5>
                            </div>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="form-group col-md-12">
                                    <label class="form-control-label">Número de Carnet de Identidad</label>
                                    <asp:TextBox ID="txtCIVerificacion" CssClass="form-control" placeholder="Ej: 1234567" runat="server" />
                                </div>
                            </div>
                            <div id="divResultadoVerificacion" style="display: none;"></div>
                        </div>
                        <div class="modal-footer border-top">
                            <asp:LinkButton ID="btnVerificarCI" CssClass="btn btn-success" Text="VERIFICAR" OnClick="btnVerificarCI_Click" runat="server" />
                            <asp:LinkButton ID="btnCancelarVerificacionCI" CssClass="btn btn-danger" Text="CANCELAR" OnClick="btnCancelarVerificacionCI_Click" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnBuscar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnVerificarCI" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="btnCancelarVerificacionCI" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>

    <asp:UpdateProgress AssociatedUpdatePanelID="UpdatePanelContrataciones" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <script>
        $(document).ready(function () {
            $('.select2').select2({
                placeholder: { id: '0', text: 'Seleccione...' }
            });
        });
    </script>
</asp:Content>