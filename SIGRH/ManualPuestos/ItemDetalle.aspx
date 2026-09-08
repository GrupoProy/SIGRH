<%@ Page Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ItemDetalle.aspx.cs" Inherits="tbl_mdp_resultados_especificos" EnableEventValidation="false" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header bg-org2 pb-3" style="min-height: 170px; background-image: url(../Content/img/fondo_uap1.png); background-size: cover; background-position: center top;">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-bluedark d-inline-block mb-0">&nbsp</h6>

                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:LinkButton ID="btn_reporte"         CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-green text-white rounded-circle shadow" Text="<i class='fas fa-print'></i>" data-toggle="tooltip" data-original-title="Imprimir Reporte" OnClick="btn_reporte_Click" OnClientClick="document.forms[0].target = '_blank';" runat="server" />
                    </div>

                    <asp:UpdatePanel ID="panel_boton_flotantes" runat="server">
                        <ContentTemplate>
                            <div ID="block_finalizar" class="col-lg-5 col-5 text-right" runat="server">
                                <asp:LinkButton ID="btn_cerrar"         CssClass="btn btn-circle sticky-top-btn-close icon-prs-close icon-shape-prs-close bg-gradient-close text-white rounded-circle shadow" Text="<i class='fas fa-check'></i>" data-toggle="tooltip" data-original-title="Finalizar Revisión" OnClick="btn_cerrar_Click" runat="server" Height="5px" Width="5px" />
                            </div>
                             
                            <div ID="block_siguiente" class="col-lg-7 col-5 text-right" runat="server">
                                <asp:LinkButton ID="btn_siguiente_item" CssClass="btn btn-circle sticky-top-btn-close icon-prs-close icon-shape-prs-close bg-gradient-close text-white rounded-circle shadow" Text="<i class='fas fa-arrow-right'></i>" data-toggle="tooltip" data-original-title="Ir Siguiente Ítem" OnClick="btn_siguiente_item_Click" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="ct-example">
            <div class="card-header">
                <h3 class="h2 text d-inline-block mb-0"><i class="fas fa-edit mr-2"></i>Detalle POAI</h3>
            </div>
            <div class="tab-content">
                <div id="nav-pills-tabs-component" class="tab-pane tab-example-result fade active show" role="tabpanel" aria-labelledby="nav-pills-tabs-component-tab">
                    <div class="nav-wrapper" style="position: sticky; z-index: 1020; top: 77px !important; background-color: #cfd8dc;">
                        <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#tabs-icons-text-1" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true"><i class="fas fa-address-card mr-2"></i>1. IDENTIFICACIÓN</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-2-tab" data-toggle="tab" href="#tabs-icons-text-2" role="tab" aria-controls="tabs-icons-text-2" aria-selected="false"><i class="fas fa-book mr-2"></i>2. DESCRIPCIÓN</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-3-tab" data-toggle="tab" href="#tabs-icons-text-3" role="tab" aria-controls="tabs-icons-text-3" aria-selected="false"><i class="fas fa-file mr-2"></i>3. REQUISITOS DEL PUESTO</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card shadow">
                        <div class="card-body">
                            <div class="tab-content" id="myTabContent">
                                <div class="tab-pane fade show active" id="tabs-icons-text-1" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">
                                    <div class="row" style="position: sticky; z-index: 1020; top: 147px !important;">
                                        <div class="col-xl-12">
                                            <div class="card" style="background-color: #e0f2f1;">
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-lg-1">
                                                            <div class="content-text-label">Ítem</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab1_item" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-20 hidden="hidden">
                                                            <div class="content-text-label">Ítem Anterior</div>
                                                            <div class="h5 font-weight-400 content-text hiidden-true" aria-hidden="true">
                                                            <asp:Literal ID="lvl_tab1_item_anterior" runat="server"/>
                                                         </div>
                                                        </div>
                                                        <div class="col-lg-3" id="spn_cargo" runat="server">
                                                            <div class="content-text-label">Cargo</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab1_cargo" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-5">
                                                            <div class="content-text-label text-green2">Unidad Organizacional</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab1_uo" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-1">
                                                            <div class="content-text-label">Gestión</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab1_gestion" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card">
                                                <div class="card-body">
                                                    <!-- Form groups used in grid -->
                                                    <div class="row">
                                                        <div class="col-md-9"><!-- <div class="col-md-12">-->
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Puesto</label>
                                                                <asp:TextBox class="form-control" placeholder="Nombre Puesto" ID="txt_nom_puesto_edit" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_nom_puesto_edit" Display="Dynamic" ValidationGroup="val_guardar_item" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">&nbsp</label>
                                                                   <asp:UpdatePanel ID="panel_guardar_nom_puesto" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="ModalGuardarNomPuesto" CssClass="btn btn-success" ValidationGroup="val_guardar_item" Text="<i class='fas fa-save mr-1'></i>Guardar cambio" OnClick="ModalGuardarNomPuesto_Click" runat="server" />
                                                                          <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_nom_puesto_edit" Display="Dynamic" ValidationGroup="val_guardar_item" runat="server" />

                                                                         </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Objetivo.  <small class="text-sm mb-0" style="text-transform: none; font-size: .785rem !important;">La redacción debe iniciar con un verbo infinitivo (Ej.: Elaborar)</small></label>
                                                                <asp:TextBox class="form-control" placeholder="Objetivo" ID="txt_objetivo_edit" TextMode="multiline" Rows="7" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_objetivo_edit" Display="Dynamic" ValidationGroup="val_guardar_item" runat="server" />
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12">
                                                            <div class="form-group text-right">
                                                                <asp:UpdatePanel ID="panel_guardar_puesto" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="ModalGuardarItem" CssClass="btn btn-success" ValidationGroup="val_guardar_item" Text="<i class='fas fa-save mr-2'></i>Guardar" OnClick="ModalGuardarItem_Click" runat="server" />
                                                                        <div class="modal fade" id="GuardarItem" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                                            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                                                                <div class="modal-content bg-gradient-warning">
                                                                                    <div class="modal-header">

                                                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                            <span aria-hidden="true">×</span>
                                                                                        </button>
                                                                                    </div>

                                                                                    <div class="modal-body">
                                                                                        <div class="py-3 text-center">
                                                                                            <i class="ni ni-single-copy-04 ni-3x"></i>
                                                                                            <h4 class="heading mt-4">¿Desea guardar los cambios?</h4>
                                                                                            <asp:HiddenField ID="p_pu_poai_id" runat="server" />
                                                                                            <asp:HiddenField ID="p_pu_nro_puesto" runat="server" />
                                                                                            <asp:HiddenField ID="p_pu_pref_puesto" runat="server" />
                                                                                            <asp:HiddenField ID="p_pu_id_puesto_anterior" runat="server" />
                                                                                            <asp:HiddenField ID="p_pu_id" runat="server" />

                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group text-center">
                                                                                        <asp:LinkButton ID="btnGuardarItem" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnGuardarItem_Click" runat="server" />

                                                                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                                    </div>

                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>

                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="supervision">
                                        <div class="col-xl-12">
                                            <div class="card">
                                                <div class="card-header border-0 ">
                                                    <div class="row align-items-center">
                                                        <div class="col">
                                                            <h3 class="mb-0">Supervisión Ejercida</h3>
                                                            <p class="text-sm mb-0">
                                                                Detalle de los ítems de los cuales están bajo su supervisión.
                                                            </p>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="card-body">
                                                    <div class="table-responsive">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>

                                                                <asp:GridView ID="gv_supervision_ejer" CssClass="table table-bordered table-hover table-striped" OnPreRender="gv_supervision_ejer_PreRender" AutoGenerateColumns="false" Width="100%" runat="server">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="itemC" HeaderText="Ítem" />
                                                                        <asp:BoundField DataField="puesto" HeaderText="Puesto" />
                                                                        <asp:BoundField DataField="cargo" HeaderText="Cargo" />
                                                                    </Columns>
                                                                </asp:GridView>

                                                            </ContentTemplate>

                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-2" role="tabpanel" aria-labelledby="tabs-icons-text-2-tab">
                                    <div class="row" style="position: sticky; z-index: 1020; top: 147px !important;">
                                        <div class="col-xl-12">
                                            <div class="card" style="background-color: #e0f2f1;">

                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-lg-1">
                                                            <div class="content-text-label">Ítem</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab2_item" runat="server" />
                                                            </div>
                                                        </div>
                                                            <div class="col-lg-3">
                                                            <div class="content-text-label">Puesto</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab2_puesto" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3" id="spn_cargo2" runat="server">
                                                            <div class="content-text-label">Cargo</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab2_cargo" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="content-text-label text-green2">Unidad Organizacional</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab2_uo" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-1">
                                                            <div class="content-text-label ">Gestión</div>
                                                            <div class="h6 font-weight-390 content-text">
                                                                <asp:Literal ID="ltl_tab2_gestion" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row" id="2_1">
                                        <div class="col-xl-12">
                                            <div class="card">

                                                <div class="card-header d-flex align-items-center">
                                                    <div class="d-flex align-items-center">
                                                        <div class="text-dark font-weight-600 text-sm">
                                                            <h3 class="mb-0">2.1 Resultados Específicos</h3>
                                                        </div>
                                                    </div>
                                                    <div class="text-right ml-auto">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton ID="ModalAddResultado" CssClass="btn btn-sm btn-twitter btn-round btn-icon" data-toggle="tooltip" data-original-title="Adicionar resultado" Text="<span class='btn-inner--icon'><i class='fas fa-plus-square'></i></span><span class='btn-inner--text'>Nuevo</span>" OnClick="ModalAddResultado_Click" runat="server" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <div class="modal fade" id="NuevoResultado" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                                            <div class="modal-content">
                                                                <asp:UpdatePanel ID="panel_nuevo_resultado" runat="server">
                                                                    <ContentTemplate>
                                                                        <div class="modal-body p-0">
                                                                            <div class="card bg-secondary border-0 mb-0">
                                                                                <div class="card-header">
                                                                                    <div class="text-muted text-center mt-2 mb-3"><small>NUEVO REGISTRO</small></div>
                                                                                </div>
                                                                                <div class="card-body px-lg-5 py-lg-5">
                         
                                                                                    <div class="row">
                                                                                        <div class="col-md-12">
                                                                                            <div class="form-group">
                                                                                                <label class="form-control-label" for="example3cols1Input">Descripción <small class="text-sm mb-0" style="text-transform: none; font-size: .785rem !important;">(La redacción debe iniciar con un verbo infinitivo.)</small> </label>

                                                                                                <asp:TextBox ID="txt_descripcion_add" CssClass="form-control" placeholder="Ej.: ELABORAR LAS PLANILLAS DE PAGO DE HABERES Y SU CORRESPONDIENTE EJECUCIÓN " TextMode="multiline" Rows="4" runat="server" />
                                                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_add" Display="Dynamic" ValidationGroup="val_add_resultados" runat="server" />
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>

                                                                                    <div class="row" aria-hidden="false">
                                                                                        <div class="col-md-9">
                                                                                            <div class="form-group">
                                                                                                <%--<label class="form-control-label" for="example2cols1Input" visible="false" >Indicador</label>--%>

                                                                                                <asp:TextBox ID="txt_indicador_add" visible="false" CssClass="form-control" placeholder="Ej.: 100% DE PLANILLAS PAGADAS Y CONTROLADAS" TextMode="multiline" Rows="4" runat="server" />
                                                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_indicador_add" Display="Dynamic" ValidationGroup="val_add_resultados" runat="server" />
                                                                                            </div>
                                                                                        </div>
                                                                                        <div class="col-md-3" >
                                                                                            <div class="form-group">
                                                                                                <%--<label class="form-control-label" for="example2cols2Input" visible="false">Puntaje</label>--%>
                                                                                                <asp:TextBox ID="txt_puntaje_add" visible="false" CssClass="form-control" placeholder="Ej.: 15" TextMode="Number" runat="server" />
                                                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_puntaje_add" Display="Dynamic" ValidationGroup="val_add_resultados" runat="server" />
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="form-group text-center">
                                                                                    <asp:LinkButton ID="btnNuevoResultado" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="val_add_resultados" CssClass="btn btn-success" OnClick="btnNuevoResultado_Click" runat="server" />

                                                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="card-body">
                                                    <div class="table-responsive">
                                                        <asp:UpdatePanel ID="panel_gvResultadosEsp" runat="server">
                                                            <ContentTemplate>

                                                                <asp:GridView ID="gvResultadosEsp" CssClass="table table-bordered table-hover table-striped" OnPreRender="gvResultadosEsp_PreRender" OnRowCommand="gvResultadosEsp_RowCommand" AutoGenerateColumns="false" Width="100%" DataKeyNames="res_id, res_poai_id" runat="server">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                                                                        <asp:BoundField DataField="indicador" HeaderText="Indicador"  Visible="false"/>
                                                                        <asp:BoundField DataField="puntaje" HeaderText="Puntaje" Visible="false" />

                                                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="70px" >
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton CommandName="GetEdit" CssClass="table-action" data-toggle='tooltip' data-original-title='Editar resultado' Text=" <i class='fas fa-edit'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                                                                                <asp:LinkButton CommandName="GetDelete" CssClass="table-action table-action-delete" data-toggle='tooltip' data-original-title='Eliminar resultado' Text=" <i class='fas fa-trash'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>

                                                            </ContentTemplate>

                                                        </asp:UpdatePanel>
                                                    </div>

                                                    <div class="col-md-12 mt-2" dir="rtl" aria-hidden="true">
                                                                <div class="form-group" >
                                                                <%--<asp:TextBox class="form-control" placeholder="0 pts" ID="txtsuma"  runat="server" width="250px" Enabled="False" Visible="False" />--%>
                                                                                                                          
                                                                <asp:Label runat="server" Text="NO_CORRESPONDE" Id="no_corresponde_resultados">x</asp:Label>
                                                                                   
                                                            </div>

                                                        <div class="form-group text-right" aria-hidden="true">
                                                            
                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
<%--                                                                    <asp:LinkButton ID="btn_validar_ptje_final" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i>Validar" OnClick="btn_validar_ptje_final_Click" runat="server" Visible="False" />--%>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Modal Editar Resultado -->
                                                <div class="modal fade" id="EditarResultado" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                    <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                                        <div class="modal-content">
                                                            <asp:UpdatePanel ID="panel_editar_resultado" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="modal-body p-0">
                                                                        <div class="card bg-secondary border-0 mb-0">
                                                                            <div class="card-header">
                                                                                <div class="text-muted text-center mt-2 mb-3"><small>EDITAR REGISTRO</small></div>
                                                                            </div>
                                                                            <div class="card-body px-lg-5 py-lg-5">

                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <div class="form-group">
                                                                                            <label class="form-control-label" for="example3cols1Input">Descripción <small class="text-sm mb-0" style="text-transform: none; font-size: .785rem !important;">(La redacción debe iniciar con un verbo infinitivo.)</small> </label>
                                                                                            <asp:TextBox ID="txt_descripcion_resultado" CssClass="form-control" placeholder="Descripción " TextMode="multiline" Rows="4" runat="server" />
                                                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_resultado" Display="Dynamic" ValidationGroup="val_edit_resultados" runat="server" />

                                                                                        </div>
                                                                                    </div>
                                                                                </div>

                                                                                <div class="row" hidden="hidden">
                                                                                    <div class="col-md-9">
                                                                                        <div class="form-group">
                                                                                            <label class="form-control-label" for="example2cols1Input">Indicador</label>
                                                                                            <asp:TextBox ID="txt_indicador" CssClass="form-control" placeholder="Indicador" TextMode="multiline" Rows="4" runat="server" />
                                                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_indicador" Display="Dynamic" ValidationGroup="val_edit_resultados" runat="server" />
                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="col-md-3">
                                                                                        <div class="form-group">
                                                                                            <label class="form-control-label" for="example2cols2Input">Puntaje</label>
                                                                                            <asp:TextBox ID="txt_puntaje" CssClass="form-control" TextMode="Number" placeholder="Puntaje" runat="server" />
                                                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_puntaje" Display="Dynamic" ValidationGroup="val_edit_resultados" runat="server" />
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group text-center">
                                                                                <asp:LinkButton ID="btnEditarResultado" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="val_edit_resultados" CssClass="btn btn-success" OnClick="btnEditarResultado_Click" runat="server" />

                                                                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>

                                                <!-- Modal Eliminar Resultado -->
                                                <div class="modal fade" id="EliminarResultado" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                    <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                                        <div class="modal-content bg-gradient-danger">
                                                            <div class="modal-header">

                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                    <span aria-hidden="true">×</span>
                                                                </button>
                                                            </div>

                                                            <asp:UpdatePanel ID="panel_eliminar_resultado" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="modal-body">
                                                                        <div class="py-3 text-center">
                                                                            <i class="ni ni-fat-remove ni-3x"></i>
                                                                            <h4 class="heading mt-4">¿Esta seguro de eliminar?</h4>

                                                                            <asp:HiddenField ID="p_res_id" runat="server" />
                                                                            <asp:HiddenField ID="p_res_poai_id" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group text-center">
                                                                        <asp:LinkButton ID="btnEliminarResultado" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnEliminarResultado_Click1" runat="server" />
                                                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card">
                                                <div class="card-header border-0 ">
                                                    <div class="row align-items-center">
                                                        <div class="col">
                                                            <h3 class="mb-0 ">2.2 Tareas Recurrentes</h3>
                                                        </div>
                                                        <div class="col-6 text-right">
                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
                                                                    <asp:LinkButton ID="ModalAddTarea" CssClass="btn btn-sm btn-twitter btn-round btn-icon" data-toggle="tooltip" data-original-title="Adionar nueva tarea" Text="<span class='btn-inner--icon'><i class='fas fa-plus-square'></i></span><span class='btn-inner--text'>Nuevo</span>" OnClick="ModalAddTarea_Click" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                            <div class="modal fade" id="NuevaTarea" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                                <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                                                    <div class="modal-content">
                                                                        <asp:UpdatePanel ID="panel_nueva_tarea" runat="server">
                                                                            <ContentTemplate>
                                                                                <div class="modal-body p-0">
                                                                                    <div class="card bg-secondary border-0 mb-0">
                                                                                        <div class="card-header">
                                                                                            <div class="text-muted text-center mt-2 mb-3"><small>NUEVO REGISTRO</small></div>
                                                                                        </div>
                                                                                        <div class="card-body px-lg-5 py-lg-5">
                                                                                            <!-- Form groups used in grid -->
                                                                                            <div class="row">
                                                                                                <div class="col-md-12 text-left">
                                                                                                    <div class="form-group">
                                                                                                        <label class="form-control-label" for="example3cols1Input">Descripci&oacute;n <small class="text-sm mb-0" style="text-transform: none; font-size: .785rem !important;">(La redacción debe iniciar con un verbo infinitivo.)</small></label>
                                                                                                        <asp:TextBox class="form-control" ID="txt_descripcion_tarea_add" placeholder="Ej.: EMITIR INFORMES DE TIEMPO DE SERVICIOS, ANTECEDENTES, CONDICIÓN DEL RÉGIMEN LABORAL Y OTROS." TextMode="multiline" Rows="4" runat="server" />
                                                                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_tarea_add" Display="Dynamic" ValidationGroup="val_add_tarea" runat="server" />

                                                                                                    </div>
                                                                                                </div>
                                                                                            </div>
                                                                                            <br />
                                                                                            <div class="form-group text-center">
                                                                                                <asp:LinkButton ID="btnNuevaTarea" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="val_add_tarea" CssClass="btn btn-success" OnClick="btnNuevaTarea_Click" runat="server" />
                                                                                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="card-body">
                                                    <div class="table-responsive">
                                                        <asp:UpdatePanel ID="panel_gvTareas" runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="gvTareas" CssClass="table table-bordered table-hover table-striped" OnPreRender="gvTareas_PreRender" AutoGenerateColumns="false" OnRowCommand="gvTareas_RowCommand" DataKeyNames="tar_id, tar_poai_id" runat="server">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />


                                                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="70px">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton CommandName="GetEdit" CssClass="table-action" data-toggle='tooltip' data-original-title='Editar tarea' Text=" <i class='fas fa-edit'></i>" CommandArgument="<%# Container.DataItemIndex %>" Visible='<%# Eval("descripcion").ToString() != "Y OTRAS TAREAS ASIGNADAS POR LA AUTORIDAD SUPERIOR" ? true : false %>' runat="server" />
                                                                                <asp:LinkButton CommandName="GetDelete" CssClass="table-action table-action-delete" data-toggle='tooltip' data-original-title='Eliminar tarea' Text=" <i class='fas fa-trash'></i>" CommandArgument="<%# Container.DataItemIndex %>" Visible='<%# Eval("descripcion").ToString() != "Y OTRAS TAREAS ASIGNADAS POR LA AUTORIDAD SUPERIOR" ? true : false %>' runat="server" />

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>

                                                <!-- Modal Editar Tarea -->
                                                <div class="modal fade" id="EditarTarea" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                    <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                                        <div class="modal-content">
                                                            <asp:UpdatePanel ID="panel_editar_tarea" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="modal-body p-0">
                                                                        <div class="card bg-secondary border-0 mb-0">
                                                                            <div class="card-header">
                                                                                <div class="text-muted text-center mt-2 mb-3"><small>EDITAR REGISTRO</small></div>
                                                                            </div>
                                                                            <div class="card-body px-lg-5 py-lg-5">

                                                                                <div class="row">
                                                                                    <div class="col-md-12">
                                                                                        <div class="form-group">
                                                                                            <label class="form-control-label" for="example3cols1Input">Descripción <small class="text-sm mb-0" style="text-transform: none; font-size: .785rem !important;">(La redacción debe iniciar con un verbo infinitivo.)</small> </label>
                                                                                            <asp:TextBox ID="txt_descripcion_tarea" CssClass="form-control" placeholder="Descripción" TextMode="multiline" Rows="4" runat="server" />
                                                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_tarea" Display="Dynamic" ValidationGroup="val_edit_tarea" runat="server" />

                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>

                                                                            <div class="form-group text-center">
                                                                                <asp:LinkButton ID="btnEditarTarea" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="val_edit_tarea" CssClass="btn btn-success" OnClick="btnEditarTarea_Click" runat="server" />

                                                                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>

                                                    </div>
                                                </div>


                                                <!-- Modal Eliminar Tarea -->
                                                <div class="modal fade" id="EliminarTarea" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                    <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                                        <div class="modal-content bg-gradient-danger">
                                                            <div class="modal-header">

                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                    <span aria-hidden="true">×</span>
                                                                </button>
                                                            </div>

                                                            <asp:UpdatePanel ID="panel_eliminar_tarea" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="modal-body">
                                                                        <div class="py-3 text-center">
                                                                            <i class="ni ni-fat-remove ni-3x"></i>
                                                                            <h4 class="heading mt-4">¿Esta seguro de eliminar?</h4>


                                                                            <asp:HiddenField ID="p_tar_id" runat="server" />
                                                                            <asp:HiddenField ID="p_tar_poai_id" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group text-center">
                                                                        <asp:LinkButton ID="btmEliminarTarea" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btmEliminarTarea_Click" runat="server" />
                                                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>



                                    <div class="row">
                                    <div class="col-xl-8">
                                      <%-- 
                                            <div class="accordion" id="accordionCI">

                                                <div class="card">
                                                    <div class="card-header" id="contCaracteristicaInd" data-toggle="collapse" data-target="#ACaracInd" aria-expanded="false" aria-controls="collapseTwo">
                                                        <h3 class="mb-0">2.3 Características Individuales</h3>
                                                    </div>

                                                    <div id="ACaracInd" class="collapse" aria-labelledby="contCaracteristicaInd" data-parent="#accordionCI">
                                                        <div class="card-body">

                                                            <div class="row align-items-center">
                                                                <div class="col-6 text-right">
                                                                    <div class="row align-items-center">
                                                                        <div class="col-1">
                                                                            <h3 class="mb-0">&nbsp</h3>
                                                                        </div>
                                                                        <label class="form-control-label" for="exampleFormControlSelect1">Categoría</label>
                                                                        <div class="col-3 pull-right">

                                                                            <asp:DropDownList ID="ddl_categoria" CssClass="form-control form-control-sm" Enabled="false" runat="server">
                                                                                <asp:ListItem Text="A" Value="0" />
                                                                                <asp:ListItem Text="B" Value="1" />
                                                                                <asp:ListItem Text="C" Value="2" />
                                                                                <asp:ListItem Text="D" Value="3" />
                                                                                <asp:ListItem Text="E" Value="4" />
                                                                                <asp:ListItem Text="F" Value="5" />
                                                                                <asp:ListItem Text="G" Value="6" />
                                                                                <asp:ListItem Text="H" Value="7" />

                                                                            </asp:DropDownList>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                                <div class="col-6 text-right" style="display: none">
                                                                    <asp:UpdatePanel runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="ModalAddCaracteristica" CssClass="btn btn-sm btn-twitter btn-round btn-icon" data-toggle="tooltip" data-original-title="Adicionar Carácter I." Text="<span class='btn-inner--icon'><i class='fas fa-plus-square'></i></span><span class='btn-inner--text'>Nuevo</span>" OnClick="ModalAddCaracteristica_Click" runat="server" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>


                                                                </div>
                                                                <div class="modal fade" id="NuevaCaracter" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                                    <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                                                        <div class="modal-content">
                                                                            <asp:UpdatePanel runat="server">
                                                                                <ContentTemplate>
                                                                                    <div class="modal-body p-0">
                                                                                        <div class="card bg-secondary border-0 mb-0">
                                                                                            <div class="card-header">
                                                                                                <div class="text-muted text-center mt-2 mb-3"><small>NUEVO REGISTRO</small></div>
                                                                                            </div>
                                                                                            <div class="card-body px-lg-5 py-lg-5">
                                                                                                <div class="row">
                                                                                                    <div class="col-md-12 text-left">
                                                                                                        <div class="form-group">
                                                                                                            <label class="form-control-label" for="exampleFormControlSelect1">Descripción </label>
                                                                                                            <asp:DropDownList ID="ddl_caracter_individual" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_caracter_individual" ValidationGroup="val_add_caracter" InitialValue="0" runat="server" />

                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <br />
                                                                                                <div class="form-group text-center">
                                                                                                    <asp:LinkButton ID="btnGuardarCaracterInvAdd" ValidationGroup="val_add_caracter" Text="<i class='fas fa-check mr-2'></i>Guardar" CssClass="btn btn-success" OnClick="btnGuardarCaracterInvAdd_Click" runat="server" />
                                                                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times-circle mr-2"></i>Cancelar</button>
                                                                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>
                                    
                                                            <div class="table-responsive">
                                                                <asp:UpdatePanel runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="gv_caracterIndividual" CssClass="table table-bordered table-hover table-striped" OnPreRender="gv_caracterIndividual_PreRender" OnRowCommand="gv_caracterIndividual_RowCommand" AutoGenerateColumns="false" DataKeyNames="poai_id, ci_id" runat="server">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="ci_factor" HeaderText="Factor" />
                                                                                <asp:BoundField DataField="ci_descripcion" HeaderText="Descripción" />
                                                                             <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="70px">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton CommandName="GetDelete" CssClass="table-action table-action-delete" data-toggle='tooltip' data-original-title='Eliminar Carácter I.' Text=" <i class='fas fa-trash'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                            <!--EliminarCaracterI-->
                                                            <div class="modal fade" id="EliminarCaracterI" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                                <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                                                    <div class="modal-content bg-gradient-danger">
                                                                        <div class="modal-header">

                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                <span aria-hidden="true">×</span>
                                                                            </button>
                                                                        </div>

                                                                        <asp:UpdatePanel runat="server">
                                                                            <ContentTemplate>
                                                                                <div class="modal-body">
                                                                                    <div class="py-3 text-center">
                                                                                        <i class="ni ni-fat-remove ni-3x"></i>
                                                                                        <h4 class="heading mt-4">¿Esta seguro de eliminar?</h4>
                                                                                        <asp:HiddenField ID="p_ici_poai_id" runat="server" />
                                                                                        <asp:HiddenField ID="p_ici_ci_id" runat="server" />
                                                                                    </div>
                                                                                </div>
                                                                            <div class="form-group text-center">
                                                                                </div>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                            </div>--%>
                                        </div>


                                        <div class="col-xl-8">
                                            <div class="card">
                                                <!-- Card header -->
                                                <div class="card-header">
                                                    <h3 class="mb-0 ">2.3 Responsabilidad</h3>
                                                </div>
                                                <!-- Card body -->
                                                <div class="card-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="custom-control custom-checkbox mb-3">
                                                                <asp:CheckBoxList CssClass="checks" ID="cbl_responsabilidad" runat="server">
                                                                </asp:CheckBoxList>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-12">
                                                            <div class="form-group text-right">
                                                                <asp:UpdatePanel ID="panel_guardar_responsabilidades" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:LinkButton ID="ModalGuardarRespons" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i>Guardar" OnClick="ModalGuardarRespons_Click" runat="server" />
                                                                        <div class="modal fade" id="GuardarResponsabilidades" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                                            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                                                                <div class="modal-content bg-gradient-warning">
                                                                                    <div class="modal-header">

                                                                                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                            <span aria-hidden="true">×</span>
                                                                                        </button>
                                                                                    </div>


                                                                                    <div class="modal-body">
                                                                                        <div class="py-3 text-center">
                                                                                            <i class="ni ni-single-copy-04 ni-3x"></i>
                                                                                            <h4 class="heading mt-4">¿Desea guardar los cambios?</h4>


                                                                                        </div>
                                                                                    </div>
                                                                                    <div class="form-group text-center">
                                                                                        <asp:LinkButton ID="btnGuardarResponsabilidades" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnGuardarResponsabilidades_Click" runat="server" />

                                                                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>
                                </div>
                                <div class="tab-pane fade" id="tabs-icons-text-3" role="tabpanel" aria-labelledby="tabs-icons-text-3-tab">
                                    <div class="row" style="position: sticky; z-index: 1020; top: 147px !important;">
                                        <div class="col-xl-12">
                                            <div class="card" style="background-color: #e0f2f1;">

                                                <div class="card-body">

                                                    <div class="row">
                                                        <div class="col-lg-1">
                                                            <div class="content-text-label">Ítem</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab3_item" runat="server" />
                                                            </div>
                                                        </div>
                                                                     <div class="col-lg-3">
                                                            <div class="content-text-label">Puesto</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab3_puesto" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-3" id="spn_cargo3" runat="server">
                                                            <div class="content-text-label">Cargo</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab3_cargo" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-4">
                                                            <div class="content-text-label text-green2">Unidad Organizacional</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab3_uo" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-1">
                                                            <div class="content-text-label">Gestión</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_tab3_gestion" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row"> <!--Requisitos-->
                                        <div class="col-xl-12">
                                            <div class="card">
                                                <!-- Card header -->
                                                <div class="card-header">
                                                    <h3 class="mb-0">3.1 Requisitos del Puesto</h3>
                                                </div>
                                                <!-- Card body -->
                                                <div class="card-body">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Formación Obligatoria</label>
                                                    <asp:DropDownList ID="ddl_formacion_obli" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                </div>

                                                <div class="card-body">
                                                    <label class="form-control-label" for="exampleFormControlSelect1">Formación Complementaria</label>
                                                    <asp:DropDownList ID="ddl_formacion_comp" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                </div>

                                                <div class="col-md-12">
                                                    <div class="form-group text-right">
                                                        <asp:UpdatePanel ID="panel_guardar_formacion" runat="server">
                                                            <ContentTemplate>
                                                                <asp:LinkButton ID="ModalGuardarRequisito" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i>Guardar" OnClick="ModalGuardarRequisito_Click" runat="server" />
                                                                <div class="modal fade" id="GuardarFormacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                                    <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                                                        <div class="modal-content bg-gradient-warning">
                                                                            <div class="modal-header">

                                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                    <span aria-hidden="true">×</span>
                                                                                </button>
                                                                            </div>

                                                                            <div class="modal-body">
                                                                                <div class="py-3 text-center">
                                                                                    <i class="ni ni-single-copy-04 ni-3x"></i>
                                                                                    <h4 class="heading mt-4">¿Desea guardar los cambios?</h4>
                                                                                </div>
                                                                            </div>
                                                                            <div class="form-group text-center">
                                                                                <asp:LinkButton ID="btnGuardarFormacion" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnGuardarFormacion_Click" runat="server" />

                                                                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                            </div>

                                                                        </div>
                                                                    </div>
                                                                </div>

                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>

                                    </div>

                                    <div class="row"><!--CONOCIMIENTO -->
                                        <div class="col-xl-12">
                                            <div class="card">
                                                <div class="card-header border-0">
                                                    <div class="row align-items-center">
                                                        <div class="col">
                                                            <h3 class="mb-0">3.2 Conocimientos Complementarios</h3>
                                                        </div>

                                                        <div class="col-6 text-right">
                                                            <asp:UpdatePanel runat="server">
                                                                <ContentTemplate>
                                                                    <asp:LinkButton ID="ModalAddConocimiento" CssClass="btn btn-sm btn-twitter btn-round btn-icon" data-toggle="tooltip" data-original-title="Adicionar Conocimiento" Text="<span class='btn-inner--icon'><i class='fas fa-plus-square'></i></span><span class='btn-inner--text'>Nuevo</span>" OnClick="ModalAddConocimiento_Click" runat="server" />
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>


                                                        </div>
                                                        <div class="modal fade" id="NuevaConocimiento" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                                                <div class="modal-content">
                                                                    <asp:UpdatePanel ID="panel_nuevo_conocimiento" runat="server">
                                                                        <ContentTemplate>
                                                                            <div class="modal-body p-0">
                                                                                <div class="card bg-secondary border-0 mb-0">
                                                                                    <div class="card-header">
                                                                                        <div class="text-muted text-center mt-2 mb-3"><small>NUEVO REGISTRO</small></div>
                                                                                    </div>
                                                                                    <div class="card-body px-lg-5 py-lg-5">
                                                                                        <!-- Form groups used in grid -->
                                                                                        <div class="row">
                                                                                            <div class="col-md-12 text-left">
                                                                                                <div class="form-group">
                                                                                                    <label class="form-control-label" for="exampleFormControlSelect1">Conocimientos complementarios </label>
                                                                                                    <asp:DropDownList ID="ddl_conocimineto_add" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_conocimineto_add" ValidationGroup="val_add_conocimiento" InitialValue="0" runat="server" />
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                        <br />
                                                                                        <div class="form-group text-center">
                                                                                            <asp:LinkButton ID="btnNuevoConocimiento" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="val_add_conocimiento" CssClass="btn btn-success" OnClick="btnNuevoConocimiento_Click" runat="server" />

                                                                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                                        </div>
                                                                                    </div>
                                                                                </div>
                                                                            </div>
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                            </div>
                                                        </div>

                                                    </div>
                                                </div>
                                                <div class="card-body">
                                                    <div class="table-responsive">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <asp:GridView ID="gvConocimientosCom" CssClass="table table-bordered table-hover table-striped" OnPreRender="gvConocimientosCom_PreRender" AutoGenerateColumns="false" OnRowCommand="gvConocimientosCom_RowCommand" DataKeyNames="ico_co_id, ico_poai_id" runat="server">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />

                                                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="70px">
                                                                            <ItemTemplate>
                                                                                <asp:LinkButton CommandName="GetDelete" CssClass="table-action table-action-delete" data-toggle='tooltip' data-original-title='Eliminar conocimiento' Text=" <i class='fas fa-trash'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />

                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>

                                                <!-- Modal Eliminar Conocimiento Complementario -->
                                                <div class="modal fade" id="EliminarCon" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                    <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                                        <div class="modal-content bg-gradient-danger">
                                                            <div class="modal-header">

                                                                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                    <span aria-hidden="true">×</span>
                                                                </button>
                                                            </div>

                                                            <asp:UpdatePanel ID="panel_eliminar_con" runat="server">
                                                                <ContentTemplate>
                                                                    <div class="modal-body">
                                                                        <div class="py-3 text-center">
                                                                            <i class="ni ni-fat-remove ni-3x"></i>
                                                                            <h4 class="heading mt-4">¿Esta seguro de eliminar?</h4>


                                                                            <asp:HiddenField ID="p_ico_poai_id" runat="server" />
                                                                            <asp:HiddenField ID="p_ico_co_id" runat="server" />
                                                                        </div>
                                                                    </div>
                                                                    <div class="form-group text-center">
                                                                        <asp:LinkButton ID="btnEliminarConocimientoC" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnEliminarConocimientoC_Click" runat="server" />
                                                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                    </div>
                                                                </ContentTemplate>
                                                            </asp:UpdatePanel>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-xl-8">
                                            <div class="card">
                                                <!-- Card header EXPERIENCIA-->
                                                <div class="card-header">
                                                    <h3 class="mb-0">3.3 Experiencia Obligatoria</h3>
                                                </div>
                                                <!-- Card body -->
                                                <div class="card-body">

                                                    <div class="form-group row">
                                                        <label for="example-text-input" class="col-md-4 col-form-label form-control-label">Experiencia General</label>
                                                        <div class="col-md-8">

                                                            <asp:TextBox class="form-control" ID="txt_exp_gral" placeholder="Experiencia General" disabled="disabled" runat="server" />
                                                        </div>
                                                    </div>

                                                </div>

                                                <!-- Card header -->
                                                <div class="card-header">
                                                    <h3 class="mb-0">Experiencia Complementaria</h3>
                                                </div>
                                                <!-- Card body -->
                                                <div class="card-body">
                                                    <div class="form-group row">
                                                        <label for="example-text-input" class="col-md-4 col-form-label form-control-label">Experiencia Especifica Puesto</label>
                                                        <div class="col-md-8">
                                                            <asp:TextBox class="form-control" ID="txt_exp_esp" placeholder="Experiencia Específica Puesto" disabled="disabled" runat="server" />
                                                        </div>
                                                    </div>

                                                    <div id="exp_municipios" style="display: none">
                                                        <div class="form-group row">
                                                            <label for="example-text-input" class="col-md-4 col-form-label form-control-label">Experiencia General Municipios</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox class="form-control" ID="txt_exp_gral_mun" placeholder="Experiencia General Municipios" disabled="disabled" runat="server" />
                                                            </div>
                                                        </div>

                                                        <div class="form-group row">
                                                            <label for="example-text-input" class="col-md-4 col-form-label form-control-label">Experiencia Específica Municipios</label>
                                                            <div class="col-md-8">
                                                                <asp:TextBox class="form-control" ID="txt_exp_esp_mun" placeholder="Experiencia Especifica Municipios" disabled="disabled" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="card">
                                            </div>
                                        </div>
                                       <div class="col-xl-7">
                                            <%--<div class="accordion" id="accordionExample">

                                                <div class="card">
                                                    <div class="card-header" id="contDisposicionJ" data-toggle="collapse" data-target="#disposicionJuridica" aria-expanded="false" aria-controls="collapseTwo">
                                                        <h3 class="mb-0">3.4 Disposiciones Jurídicas</h3>
                                                    </div>

                                                    <div id="disposicionJuridica" class="collapse" aria-labelledby="contDisposicionJ" data-parent="#accordionExample">
                                                        <div class="card-body">
                                                            <!-Content Accordion--!>
                                                            <div class="row align-items-center">
                                                                <div class="col">
                                                                    <h3 class="mb-0">&nbsp</h3>
                                                                </div>
                                                                <div class="col-6 text-right">
                                                                    <asp:UpdatePanel runat="server">
                                                                        <ContentTemplate>
                                                                            <asp:LinkButton ID="ModalAddDisposicion" CssClass="btn btn-sm btn-twitter btn-round btn-icon" data-toggle="tooltip" data-original-title="Adicionar disposición" Text="<span class='btn-inner--icon'><i class='fas fa-plus-square'></i></span><span class='btn-inner--text'>Nuevo</span>" OnClick="ModalAddDisposicion_Click" runat="server" />
                                                                        </ContentTemplate>
                                                                    </asp:UpdatePanel>
                                                                </div>
                                                                <div class="modal fade" id="NuevaDisposicion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                                    <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                                                        <div class="modal-content">
                                                                            <asp:UpdatePanel ID="panel_nueva_disposicion" runat="server">
                                                                                <ContentTemplate>
                                                                                    <div class="modal-body p-0">
                                                                                        <div class="card bg-secondary border-0 mb-0">
                                                                                            <div class="card-header">
                                                                                                <div class="text-muted text-center mt-2 mb-3"><small>NUEVO REGISTRO</small></div>
                                                                                            </div>
                                                                                            <div class="card-body px-lg-5 py-lg-5">

                                                                                                <div class="row">
                                                                                                    <div class="col-md-12 text-left">
                                                                                                        <div class="form-group">
                                                                                                            <label class="form-control-label" for="exampleFormControlSelect1">Descripción </label>
                                                                                                            <asp:DropDownList ID="ddl_disposicion_juridica" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_disposicion_juridica" ValidationGroup="val_add_disposicion" InitialValue="0" runat="server" />
                                                                                                        </div>
                                                                                                    </div>
                                                                                                </div>
                                                                                                <br />
                                                                                                <div class="form-group text-center">
                                                                                                    <asp:LinkButton ID="btnNuevaDisposicionJuridica" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="val_add_disposicion" CssClass="btn btn-success" OnClick="btnNuevaDisposicionJuridica_Click" runat="server" />
                                                                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                                                </div>
                                                                                            </div>
                                                                                        </div>
                                                                                    </div>
                                                                                </ContentTemplate>
                                                                            </asp:UpdatePanel>
                                                                        </div>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="table-responsive">
                                                                <asp:UpdatePanel runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="gvDisposicion" CssClass="table table-bordered table-hover table-striped" OnPreRender="gvDisposicion_PreRender" AutoGenerateColumns="false" OnRowCommand="gvDisposicion_RowCommand" DataKeyNames="idj_dj_id, idj_poai_id" runat="server">
                                                                            <Columns>
                                                                                <asp:BoundField DataField="descripcion" HeaderText="Descripción" />

                                                                                <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="70px">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton CommandName="GetDelete" CssClass="table-action table-action-delete" data-toggle='tooltip' data-original-title='Eliminar disposición' Text=" <i class='fas fa-trash'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />

                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>

                                                            <div class="modal fade" id="EliminarDispocision" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                                                <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                                                    <div class="modal-content bg-gradient-danger">
                                                                        <div class="modal-header">

                                                                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                                                                <span aria-hidden="true">×</span>
                                                                            </button>
                                                                        </div>

                                                                        <asp:UpdatePanel ID="panel_eliminar_dispocision" runat="server">
                                                                            <ContentTemplate>
                                                                                <div class="modal-body">
                                                                                    <div class="py-3 text-center">
                                                                                        <i class="ni ni-fat-remove ni-3x"></i>
                                                                                        <h4 class="heading mt-4">¿Esta seguro de eliminar?</h4>


                                                                                        <asp:HiddenField ID="p_idj_dj_id" runat="server" />
                                                                                        <asp:HiddenField ID="p_idj_poai_id" runat="server" />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="form-group text-center">

                                                                                    <asp:LinkButton ID="btnEliminarDisposicion" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnEliminarDisposicion_Click" runat="server" />
                                                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                                                </div>
                                                                            </ContentTemplate>
                                                                        </asp:UpdatePanel>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
            <!-- Modal component -->
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
                                                <asp:TextBox ID="Txt_gl_fecha_doc" class="form-control datepickerD" runat="server" />
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
<%--                              <div ID="block_busqueda" class="col-lg-12  text-right" runat="server">
                            <asp:LinkButton ID="btn_new_search" style="position: sticky; z-index: 1050; bottom: 10px; right:5px; " CssClass="btn btn-circle  icon-prs-close bg-gradient-close text-white rounded-circle shadow" Text="<i class='fas fa-search'></i>" data-toggle="tooltip" data-original-title="Nueva Busqueda" OnClick="btn_new_search_Click" runat="server" />
                            </div>--%>
    <!-- Glosa Record Modal Ends here -->
        <asp:UpdateProgress ID="up1" runat="server" AssociatedUpdatePanelID="panel_guardar_puesto">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up2" runat="server" AssociatedUpdatePanelID="panel_nuevo_resultado">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up3" runat="server" AssociatedUpdatePanelID="panel_gvResultadosEsp">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdateProgress ID="up4" runat="server" AssociatedUpdatePanelID="panel_editar_resultado">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up5" runat="server" AssociatedUpdatePanelID="panel_eliminar_resultado">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up6" runat="server" AssociatedUpdatePanelID="panel_nueva_tarea">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdateProgress ID="up7" runat="server" AssociatedUpdatePanelID="panel_gvTareas">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>

        <asp:UpdateProgress ID="up8" runat="server" AssociatedUpdatePanelID="panel_editar_tarea">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up9" runat="server" AssociatedUpdatePanelID="panel_eliminar_tarea">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up10" runat="server" AssociatedUpdatePanelID="panel_guardar_responsabilidades">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up11" runat="server" AssociatedUpdatePanelID="panel_guardar_formacion">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up12" runat="server" AssociatedUpdatePanelID="panel_nuevo_conocimiento">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up13" runat="server" AssociatedUpdatePanelID="panel_eliminar_con">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
<%--        <asp:UpdateProgress ID="up14" runat="server" AssociatedUpdatePanelID="panel_nueva_disposicion">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdateProgress ID="up15" runat="server" AssociatedUpdatePanelID="panel_eliminar_dispocision">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
          <asp:UpdateProgress ID="up16" runat="server" AssociatedUpdatePanelID="panel_boton_flotantes">
            <ProgressTemplate>
                <div id="load"></div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>


</asp:Content>





