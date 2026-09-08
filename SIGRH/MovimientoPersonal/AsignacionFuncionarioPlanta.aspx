<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AsignacionFuncionarioPlanta.aspx.cs" Inherits="MovimientoPersonal_Asignacion_Funcionario_Planta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Promoción / Remoción / Transferencia a Acefalia</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-6">
                <div class="card card-profile mt-5">
                    <div class="row justify-content-center">
                        <div class="col-lg-3 order-lg-2">
                            <div class="card-profile-image">
                                <a href="#">
                                    <asp:image id="imgFun" class="rounded-circle" runat="server" />
                                </a>
                            </div>
                        </div>
                    </div>
                    <!-- jornada de trabajo -->
                    <div class="col-4">
                            <span><strong class="h5">TIPO JORNADA: </strong><h6><asp:Literal ID="ltl_jornada" runat="server"/></h6></span>
                    </div>

                    <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                        <asp:linkbutton id="btn_estado" class="btn btn-sm btn-info float-right" runat="server" />
                    </div>
                    <div class="card-body pt-0">
                        <asp:updatepanel runat="server">
                            <ContentTemplate>
                                <div>
                                    <h5 class="h3 text-uppercase text-center">
                                        <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                    </h5>
                                        <div class="row">
                                        <div class="form-group col-md-12">
                                            <label class="form-control-label" for="ddl_asignacion">Asignaciones:</label>
                                            <asp:DropDownList ID="ddl_asignacion" AutoPostBack="true"  OnSelectedIndexChanged="ddl_asignacion_edit_SelectedIndexChanged" CssClass="form-control" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true"  runat="server" />
                                        </div>
                                        </div>
                                    <hr class="my-2">
                                    <h6 class="heading-small text-muted">Datos del Funcionario </h6>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="content-text-label">CI</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_ci" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <div class="content-text-label">CÓDIGO FUNCIONARIO</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_cod_fun" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-2">
                                    <h6 class="heading-small text-muted">Datos Asignación Actual </h6>
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <div class="content-text-label">Cargo</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_cargo" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label text-green2">Haber Básico (Bs)</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_hb"  runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Ítem</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_item" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <div class="content-text-label">PUESTO</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_puesto" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">CÓDIGO ESCALAFÓN</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_cod_esc" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="content-text-label">CLASE</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_clase" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="content-text-label">NIVEL SALARIAL</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_nivel_salarial" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <div class="content-text-label">Ubicación/ Unidad Organizacional</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_ubicacion" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Fecha Asignación</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_fecha_asig" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3" style="background-color: #D2E0EE; border-radius: .375rem; padding-left: 17px; padding-top: 11px;">
                                            <div class="content-text-label">Fecha Baja</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_fecha_baja" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:updatepanel>
                    </div>
                </div>
            </div>
            <div id="block_datos_fun" class="col-lg-6" style="display: none">
                <div class="card card-profile mt-5">
                    <div class="row justify-content-center">
                        <div class="col-lg-3 order-lg-2">
                            <div class="card-profile-image">
                                <a href="#">
                                    <asp:updatepanel runat="server">
                                        <ContentTemplate>
                                            <asp:Image ID="imgFun_int" class="rounded-circle" runat="server" />
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </a>
                            </div>
                        </div>
                    </div>
                    <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                        <asp:updatepanel runat="server">
                            <ContentTemplate>
                                <asp:LinkButton ID="btn_estado_int" class="btn btn-sm btn-info float-right" runat="server" />
                            </ContentTemplate>
                        </asp:updatepanel>
                    </div>
                    <div class="card-body pt-0">
                        <div style="background-color: #e1f5fe; padding-left: 17px;">
                            <div id="block_datos_fun_inter" style="display: none">
                                <asp:updatepanel id="panelFuncionarioNueva" runat="server">
                                    <ContentTemplate>
                                        <h5 class="h3 text-uppercase text-center">
                                            <asp:Literal ID="ltl_nombre_fun_inter" runat="server" />
                                        </h5>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Datos Nueva Asignación del Funcionario  </h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">CI</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_ci_inter" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">CÓDIGO FUNCIONARIO</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cod_fun_inter" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:updatepanel>
                            </div>
                            <asp:updatepanel id="panelDatosAsignacionNueva" runat="server">
                                <ContentTemplate>
                                    <hr class="my-2">
                                    <h6 class="heading-small text-muted">Datos Nueva Asignación </h6>
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <div class="content-text-label">Cargo</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_cargo_asig" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label text-green2">Haber Básico (Bs)</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_hb_asig" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Ítem</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_item_asig" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-5">
                                            <div class="content-text-label">PUESTO</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_puesto_asig" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">CÓDIGO ESCALAFÓN</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_cod_esc_asig" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="content-text-label">CLASE</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_clase_asig" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="content-text-label">NIVEL SALARIAL</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_nivel_salarial_asig" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="content-text-label">Ubicación/ unidad organizacional</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_unidad_asig" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:updatepanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-12">
                <div class="card mb-4">
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <h3 class="mb-0 text-org2">Datos Requeridos</h3>
                            <p class="text-sm mb-0">
                                Datos que deben ser llenados de forma obligatoria para realizar la nueva asignación.
                            </p>
                        </div>
                    </div>
                    <div class="card-body">
                        <div class="row">
                            <div class="col-sm-6 col-md-3">
                                <div class="form-group">
                                    <label class="form-control-label" for="example4cols1Input">Tipo Movimiento</label>
                                    <asp:updatepanel runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="ddl_tipoMovimiento" AppendDataBoundItems="true" CssClass="form-control select2" data-minimum-results-for-search="Infinity" disabled runat="server"></asp:DropDownList>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipoMovimiento" ValidationGroup="addGuardar" InitialValue="0" runat="server" />
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-2">
                                <div class="form-group">
                                    <label class="form-control-label" for="example4cols2Input">Fecha Asignación</label>
                                    <asp:updatepanel runat="server">
                                        <ContentTemplate>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_fechaAsig" AutoComplete="off" OnTextChanged="txt_fechaAsig_TextChanged" AutoPostBack="true" CssClass="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fechaAsig" ValidationGroup="addGuardar" runat="server" />
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </div>
                            </div>
                            <div class="col-sm-6 col-md-2">
                                <div class="form-group text-center">
                                    <label class="form-control-label pb-3">¿Tiene nro. ítem?</label>
                                    <asp:updatepanel id="panelNroItem" runat="server">
                                        <ContentTemplate>
                                            <label class="custom-toggle custom-toggle-warning">
                                                <asp:CheckBox ID="chk_tiene_item" AutoPostBack="true" OnCheckedChanged="chk_tiene_item_CheckedChanged" runat="server" />
                                                <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                            </label>
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </div>
                            </div>
                            <div id="block_digite_item" class="col-sm-6 col-md-3" style="display: none">
                                <asp:panel defaultbutton="btn_buscar" runat="server">
                                    <div class="row">
                                        <div class="col-sm-6 col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example3cols3Input">Digite Nro. ítem</label>
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <asp:TextBox ID="txt_digite_item" CssClass="form-control numero" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label" for="example4cols3Input">&nbsp</label>
                                                <asp:UpdatePanel ID="panelBuscar" runat="server">
                                                    <ContentTemplate>
                                                        <asp:LinkButton ID="btn_buscar" Text="<i class='fas fa-search mr-2'></i>Buscar" CssClass="btn btn-vimeo btn-block" OnClick="btn_buscar_Click" runat="server" />
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                            </div>
                                        </div>
                                    </div>
                                </asp:panel>
                            </div>
                            <div id="block_buscar_item" class="col-sm-6 col-md-3">
                                <div class="form-group">
                                    <label class="form-control-label" for="example4cols3Input">&nbsp</label>
                                    <asp:updatepanel id="panelBuscarItem" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btn_buscar_item" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Buscar Ítem" OnClick="btn_buscar_item_Click" runat="server" />
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </div>
                            </div>
                            <div id="block_guardar" class="col-sm-6 col-md-2" style="display: none">
                                <div class="form-group">
                                    <label class="form-control-label" for="example4cols3Input">&nbsp</label>
                                    <asp:updatepanel id="panelGuardarItem" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btn_guardar_item" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save'></i> Guardar" OnClick="btn_guardar_item_Click" ValidationGroup="addGuardar" runat="server" />
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </div>
                            </div>
                            <div id="block_intercambio" class="col-sm-6 col-md-2" style="display: none">
                                <div class="form-group">
                                    <label class="form-control-label">&nbsp</label>
                                    <asp:updatepanel id="panelIntercambio" runat="server">
                                        <ContentTemplate>
                                            <asp:LinkButton ID="btn_intercambio" CssClass="btn btn-success btn-block" Text="<i class='fas fa-sync-alt'></i> Intercambio" OnClick="btn_intercambio_Click" ValidationGroup="addGuardar" runat="server"></asp:LinkButton>
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </div>
                            </div>
                        </div>
                        <div class="modal fade" id="modalBuscarItems" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                <div class="modal-content">
                                    <asp:updatepanel id="panelUnidadOrg" runat="server">
                                        <ContentTemplate>
                                            <div class="modal-body p-0">
                                                <div class="card bg-secondary border-0 mb-0">
                                                    <div class="card-header">
                                                        <div class="text-muted text-center mt-2 mb-3"><small>UNIDAD ORGANIZACIONAL</small></div>
                                                    </div>
                                                    <div class="card-body px-lg-5 py-lg-5">
                                                        <div class="row">
                                                            <asp:TreeView runat="server" ID="tv_nivelOrg" ImageSet="Arrows" CssClass="treeView" AutoGenerateDataBindings="true" OnSelectedNodeChanged="tv_nivelOrg_SelectedNodeChanged" EnableClientScript="false">
                                                                <NodeStyle Font-Size=".875em" ForeColor="#525f7f" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
                                                                <SelectedNodeStyle CssClass="SelectedNodeTreeView" />
                                                                <HoverNodeStyle CssClass="HoverTreeView" />
                                                            </asp:TreeView>
                                                        </div>
                                                        <asp:HiddenField ID="aux_cat_id" runat="server" />
                                                        <asp:HiddenField ID="aux_cat_abreviacion" runat="server" />

                                                        <asp:HiddenField ID="aux_per_id" runat="server" />

                                                        <asp:HiddenField ID="aux_ca_id_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_es_id_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_eo_id_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_ti_item_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_num_item_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_estado_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_aplica_incremento_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_tipo_jornada_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_basico_calculado_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_fecha_modificacion_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_tipo_calculo_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_pr_id_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_basico_calculado_nuevo" runat="server" />

                                                        <asp:HiddenField ID="aux_as_id_actual" runat="server" />
                                                        <asp:HiddenField ID="aux_as_id_intercambio" runat="server" />

                                                        <asp:HiddenField ID="aux_ca_id" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_es_id" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_eo_id" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_ti_item" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_num_item" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_estado" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_aplica_incremento" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_tipo_jornada" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_basico_calculado" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_fecha_modificacion" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_tipo_calculo" runat="server" />
                                                        <asp:HiddenField ID="aux_ca_pr_id" runat="server" />
                                                        <asp:HiddenField ID="aux_validar_item" runat="server" />
                                                        <asp:HiddenField ID="aux_valida_acefalo_inter" runat="server" />
                                                        <asp:HiddenField ID="aux_verifica_acefalia" runat="server" />

                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-group text-right">
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group text-right">
                                                                    <asp:LinkButton ID="btn_seleccionar_item" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_seleccionar_item_Click" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3">
                                                                <div class="form-group text-right">
                                                                    <asp:LinkButton ID="btn_cancelar_buscar" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_buscar_Click" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </div>
                            </div>
                        </div>

                        <%-- Modal Glosa --%>
                        <div class="modal fade" id="modalGlosa" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                <div class="modal-content">
                                    <asp:updatepanel runat="server">
                                        <ContentTemplate>
                                            <div class="modal-body p-0">
                                                <div class="card bg-secondary border-0 mb-0">
                                                    <div class="card-header">
                                                        <div class="text-muted text-center mt-2 mb-3">
                                                            <h4 class="header-modal">GLOSA</h4>
                                                        </div>
                                                    </div>
                                                    <div class="card-body px-lg-5 py-lg-5">
                                                        <div class="row">
                                                            <div id="d_tipo_doc" class="col-md-6" runat="server">
                                                                <div class="form-group">
                                                                    <label class="form-control-label" for="exampleFormControlSelect1">Tipo Documento</label>
                                                                    <asp:DropDownList ID="ddl_tipo_documento" AppendDataBoundItems="true" CssClass="form-control select2" OnSelectedIndexChanged="ddl_tipo_documento_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_documento" Display="Dynamic" ValidationGroup="addGlosa" InitialValue="0" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div id="d_num_doc" class="col-md-4" visible="false" runat="server">
                                                                <div class="form-group">
                                                                    <label class="form-control-label" for="exampleFormControlSelect1">Número de documento</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_num_doc" class="form-control numero" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div id="d_fecha_doc" class="col-md-6" runat="server">
                                                                <div class="form-group">
                                                                    <label class="form-control-label" for="exampleFormControlSelect1">Fecha Documento</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_fechaMov" AutoComplete="off" class="form-control datepickerDefault" runat="server" />
                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fechaMov" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="form-group">
                                                                    <label class="form-control-label" for="example3cols1Input">Descripción </label>

                                                                    <asp:TextBox ID="txt_descripcion_add" CssClass="form-control" placeholder="Descripción" TextMode="multiline" Rows="4" runat="server" />
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_add" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row pt-3">
                                                            <div class="col-md-6">
                                                                <asp:LinkButton ID="btn_adicionar_glosa" Text="<i class='fas fa-check mr-2'></i>Guardar" OnClick="btn_adicionar_glosa_Click" OnClientClick="if (Page_ClientValidate('addGlosa')) { MostrarMascara(true); }" ValidationGroup="addGlosa" CssClass="btn btn-success btn-block" runat="server" />
                                                            </div>
                                                            <div class="col-md-6">
                                                                <asp:LinkButton ID="btn_cancelar_glosa" class="btn btn-outline-github btn-block" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_glosa_Click" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:updatepanel>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <asp:updateprogress id="up1" associatedupdatepanelid="panelNroItem" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:updateprogress>
        <asp:updateprogress id="up2" associatedupdatepanelid="panelBuscar" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:updateprogress>
        <asp:updateprogress id="up3" associatedupdatepanelid="panelBuscarItem" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:updateprogress>
        <asp:updateprogress id="up4" associatedupdatepanelid="panelIntercambio" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:updateprogress>
        <asp:updateprogress id="up5" associatedupdatepanelid="panelGuardarItem" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:updateprogress>
        <asp:updateprogress id="up6" associatedupdatepanelid="panelUnidadOrg" runat="server">
            <ProgressTemplate>
                <div class="load"></div>
            </ProgressTemplate>
        </asp:updateprogress>
    </div>
</asp:Content>

