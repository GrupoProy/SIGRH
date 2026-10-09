<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="LicenciaJustificada.aspx.cs" Inherits="ControlPersonal_LicenciaJustificada" %>

<%-- Punto IV definitivo: fechas para todos; horas para permisos/tolerancias. --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    
    <!-- ESTILOS -->
    <style>
        .select2-container .select2-selection--single {
            height: 38px !important; padding: 6px 12px; font-size: 0.9rem;
            border: 1px solid #d2d6da; border-radius: 4px; background-color: #fff; box-shadow: none;
        }
        .select2-container .select2-selection--single .select2-selection__arrow { height: 36px; right: 10px; }
        .select2-container--default .select2-selection--single .select2-selection__rendered { line-height: 26px; color: #32325d; }
        .select2-dropdown { border: 1px solid #d2d6da; border-radius: 4px; box-shadow: 0 4px 8px rgba(0,0,0,0.1); }
        .select2-results__option { padding: 8px 12px; font-size: 0.9rem; }
        .select2-results__option--highlighted { background-color: #5e72e4; color: #fff; }
        .input-group-text { background-color: #f6f9fc; border: 1px solid #d2d6da; color: #8898aa; }
        .info-pill { background-color: #f6f9fc; border-radius: 20px; padding: 5px 10px; display: inline-block; margin-bottom: 4px; font-size: 0.8rem; border: 1px solid #e9ecef; }
        .info-pill strong { color: #32325d; margin-right: 5px; }
        .info-pill span { color: #8898aa; font-weight: 600; }
        .section-title { font-weight: 700; color: #32325d; font-size: 0.85rem; margin-bottom: 10px; text-transform: uppercase; letter-spacing: 0.5px; }
        .modal-lg-custom { max-width: 750px; }
        .form-check-inline { margin-right: 1.5rem !important; }
        .form-check-input { margin-top: 0.3rem !important; }
        .form-check-label { font-weight: 500; color: #32325d; }
    </style>

    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:75%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Licencias</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <!-- Lista -->
    <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header border-bottom">
                <h3 class="mb-0">Lista de Licencias Justificadas</h3>
            </div>
            <div class="card-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GvLista" OnRowDataBound="GvLista_RowDataBound" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="lj_id" OnPreRender="GvLista_PreRender" OnRowCommand="GvLista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="cat_descripcion" HeaderText="Tipo Licencia" />
                                <asp:BoundField DataField="lj_fecha_licencia" HeaderText="Fecha Licencia" />
                                <asp:BoundField DataField="lj_hora_licencia" HeaderText="Hora Licencia" />
                                <asp:BoundField DataField="lj_motivo" HeaderText="Motivo" />
                                <asp:BoundField DataField="lj_lugar" HeaderText="Lugar" />
                                <asp:BoundField DataField="lj_estado" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="GetPrint" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-print'></i> Imprimir</span>" runat="server" />
                                        <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label CssClass="titulo" ID="aviso" Visible="false" Text="Las Boletas de Comisión solo pueden ser generadas por personal ADMINISTRATIVO" runat="server" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>

        <div class="col-lg-6 col-5 text-right">
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" OnClick="BtnNuevo_Click" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <!-- MODAL -->
    <div id="addModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="addTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-lg-custom" role="document">
            <div class="modal-content">
                <div class="modal-header border-bottom">
                    <h5 class="modal-title">Nueva Licencia Justificada</h5>
                </div>
                
                <asp:UpdatePanel ID="UpdatePanelLicencia" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-body p-3">
                            
                            <!-- Datos del Funcionario -->
                            <div class="mb-3">
                                <h6 class="section-title"><i class="fas fa-user mr-2"></i> Datos del Funcionario</h6>
                                <div class="d-flex flex-wrap">
                                    <span class="info-pill mr-2 mb-1"><strong>Nombre:</strong> <asp:Literal ID="Lt_per_id" runat="server" /></span>
                                    <span class="info-pill mr-2 mb-1"><strong>C.I.:</strong> <asp:Literal ID="Lt_per_num_doc" runat="server" /></span>
                                    <span class="info-pill mr-2 mb-1"><strong>Ítem:</strong> <asp:Literal ID="Lt_ca_num_item" runat="server" /></span>
                                    <span class="info-pill mr-2 mb-1"><strong>Escalafón:</strong> <asp:Literal ID="Lt_es_descripcion" runat="server" /></span>
                                </div>
                                <div class="d-flex flex-wrap mt-1">
                                    <span class="info-pill mr-2 mb-1"><strong>Fecha Asignación:</strong> <asp:Literal ID="Lt_as_fecha_inicio" runat="server" /></span>
                                    <span class="info-pill mr-2 mb-1"><strong>Fecha Baja:</strong> <asp:Literal ID="Lt_as_fecha_fin" runat="server" /></span>
                                </div>
                            </div>

                            <hr class="my-2" />

                            <!-- Tipo de Solicitud -->
                            <div class="mb-3">
                                <h6 class="section-title"><i class="fas fa-clipboard-list mr-2"></i> Tipo de Solicitud</h6>
                                <div class="row">
                                    <div class="col-md-6">
                                        <label class="form-control-label">Tipo de Solicitud</label>
                                        <asp:DropDownList ID="Ddl_lj_tipo_solicitud" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_lj_tipo_solicitud_SelectedIndexChanged" runat="server" />
                                    </div>
                                    <div class="col-md-6">
                                        <label class="form-control-label">Tipo de Licencia</label>
                                        <asp:DropDownList ID="Ddl_lj_tipo_licencia" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_lj_tipo_licencia_SelectedIndexChanged" runat="server" />
                                        <asp:Label ID="lblSaldoDisponible" runat="server" CssClass="form-text text-muted"></asp:Label>
                                    </div>
                                </div>
                            </div>

                            <!-- Tiempo -->
                            <div class="mb-3">
                                <h6 class="section-title"><i class="fas fa-clock mr-2"></i> Tiempo del Permiso / Licencia</h6>
                                <asp:Panel ID="pnlSeleccioneTipo" runat="server" CssClass="alert alert-info py-2 mb-2">
                                    Seleccione un tipo de licencia para habilitar la captura del tiempo.
                                </asp:Panel>
                                <asp:Label ID="lblConfiguracionTiempo" runat="server" Visible="false" />
                                <%-- Las fechas se muestran para todos los tipos de licencia. --%>
                                <asp:Panel ID="pnlModoDias" runat="server" Visible="false">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label class="form-control-label">Fecha Desde</label>
                                            <div class="input-group input-group-sm">
                                                <div class="input-group-prepend"><span class="input-group-text"><i class="fas fa-calendar-alt"></i></span></div>
                                                <asp:TextBox ID="Txt_lj_fecha_inicio_rango" CssClass="form-control datepickerD" MaxLength="10" placeholder="dd/mm/aaaa" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label class="form-control-label">Fecha Hasta</label>
                                            <div class="input-group input-group-sm">
                                                <div class="input-group-prepend"><span class="input-group-text"><i class="fas fa-calendar-alt"></i></span></div>
                                                <asp:TextBox ID="Txt_lj_fecha_final" CssClass="form-control datepickerD" MaxLength="10" placeholder="dd/mm/aaaa" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>

                                <%-- Las horas sólo se agregan cuando cat_adicional.modo = H. --%>
                                <asp:Panel ID="pnlModoHoras" runat="server" Visible="false" CssClass="mt-2">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <label class="form-control-label">Hora Salida</label>
                                            <div class="input-group input-group-sm">
                                                <div class="input-group-prepend"><span class="input-group-text"><i class="fas fa-clock"></i></span></div>
                                                <asp:TextBox ID="Txt_lj_hora_salida" CssClass="form-control timepickerD" MaxLength="5" placeholder="HH:mm" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <label class="form-control-label">Hora Retorno</label>
                                            <div class="input-group input-group-sm">
                                                <div class="input-group-prepend"><span class="input-group-text"><i class="fas fa-clock"></i></span></div>
                                                <asp:TextBox ID="Txt_lj_hora_retorno" CssClass="form-control timepickerD" MaxLength="5" placeholder="HH:mm" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>

                            <!-- Motivo -->
                            <div class="mb-3">
                                <h6 class="section-title"><i class="fas fa-edit mr-2"></i> Motivo y Justificación</h6>
                                <div class="row">
                                    <div class="col-md-12">
                                        <label class="form-control-label d-block">Motivo</label>
                                        <div class="d-flex flex-wrap align-items-center" style="gap: 20px;">
                                            <div class="form-check form-check-inline">
                                                <asp:RadioButton ID="rbInstitucional" runat="server" GroupName="Motivo" CssClass="form-check-input" />
                                                <label class="form-check-label" for="rbInstitucional">INSTITUCIONAL</label>
                                            </div>
                                            <div class="form-check form-check-inline">
                                                <asp:RadioButton ID="rbPersonal" runat="server" GroupName="Motivo" CssClass="form-check-input" />
                                                <label class="form-check-label" for="rbPersonal">PERSONAL</label>
                                            </div>
                                            <div class="form-check form-check-inline">
                                                <asp:RadioButton ID="rbSalud" runat="server" GroupName="Motivo" CssClass="form-check-input" />
                                                <label class="form-check-label" for="rbSalud">SALUD</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="row mt-2">
                                    <div class="col-md-12">
                                        <label class="form-control-label">Justificación</label>
                                        <asp:TextBox ID="Txt_lj_justificacion" CssClass="form-control" TextMode="MultiLine" Rows="2" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_justificacion" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                                <div class="row mt-2">
                                    <div class="col-md-12">
                                        <label class="form-control-label">Lugar</label>
                                        <asp:TextBox ID="Txt_lj_lugar" CssClass="form-control" MaxLength="250" placeholder="Indique el lugar relacionado con la solicitud" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_lugar" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                            </div>

                            <!-- Autorización -->
                            <div class="mb-3">
                                <h6 class="section-title"><i class="fas fa-user-check mr-2"></i> Autorización</h6>
                                <div class="row">
                                    <div class="col-md-12">
                                        <label class="form-control-label">Inmediato Superior</label>
                                        <asp:DropDownList ID="Ddl_lj_per_id_autoriza" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                            <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="BtnCancelar_Click" runat="server" />
                        </div>
                    </ContentTemplate>
                    <Triggers>
                        <asp:AsyncPostBackTrigger ControlID="Ddl_lj_tipo_solicitud" EventName="SelectedIndexChanged" />
                        <asp:AsyncPostBackTrigger ControlID="Ddl_lj_tipo_licencia" EventName="SelectedIndexChanged" />
                    </Triggers>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function initControls() {
            $('.select2').select2({ placeholder: "Seleccione...", width: '100%', dropdownParent: $('#addModal') });
            $('.datepickerD').datepicker({ format: 'dd/mm/yyyy', autoclose: true, language: 'es' });
            $('.timepickerD').mask('99:99');
        }
        $(document).ready(function () { initControls(); });
        if (typeof Sys !== 'undefined' && Sys.WebForms && Sys.WebForms.PageRequestManager) {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_pageLoaded(function (sender, args) { initControls(); });
        }
    </script>
</asp:Content>
