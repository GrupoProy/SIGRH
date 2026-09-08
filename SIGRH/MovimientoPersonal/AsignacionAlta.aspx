<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AsignacionAlta.aspx.cs" Inherits="MovimientoPersonal_frmAsignacion_Alta" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Asignación</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-6">
                <!-- Formulario de búsqueda de item -->
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Búsqueda de Item</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_search" runat="server">
                        <ContentTemplate>
                            <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">
                                <div class="row">
                                    <!-- hv_item -->
                                    <div class="form-group col-lg-3">
                                        <label class="form-control-label pb-3">¿Tiene nro. ítem?</label>
                                        <div>
                                            <label class="custom-toggle custom-toggle-warning">
                                                <asp:CheckBox ID="Chk_hv_item" AutoPostBack="true" OnCheckedChanged="Chk_hv_item_CheckedChanged" runat="server" />
                                                <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                            </label>
                                        </div>
                                    </div>
                                    <!-- dg_item -->
                                    <asp:Panel ID="P_dg_item" CssClass="form-group col-lg-3" Visible="false" runat="server">
                                        <label class="form-control-label" for="Txt_dg_item">Número de ítem</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_dg_item" CssClass="form-control numero" TextMode="Number" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_dg_item" ValidationGroup="search" Display="Dynamic" runat="server" />
                                    </asp:Panel>
                                    <div></div>
                                    <!-- BtnBuscar -->
                                    <div class="form-group col-lg-4">
                                        <label class="form-control-label" for="BtnBuscar"></label>
                                        <div class="input-group input-group-merge">
                                            <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search mr-2'></i> Buscar" ValidationGroup="search" OnClick="BtnBuscar_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="BtnBuscar" EventName="Click" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
        <!--Result Record Starts here -->
    <asp:UpdatePanel runat="server" ID="PanelGrid">
        <ContentTemplate>
                <asp:Panel ID="P_result" CssClass="card" Visible="false" runat="server">
                    <div class="card-header border-bottom">
                        <h3 class="mb-0">Resultado Búsqueda</h3>
                    </div>
                    <div class="card-body">
                        <!-- Placing GridView in UpdatePanel -->
                        <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="ca_id" OnPreRender="GvLista_PreRender"  OnRowCommand="GvLista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="ca_ti_item" HeaderText="Tipo" />
                                <asp:BoundField DataField="ca_num_item" HeaderText="Número Item" />
                                <asp:BoundField DataField="ca_basico_calculado" HeaderText="Haber Básico" />
                                <asp:BoundField DataField="es_descripcion" HeaderText="Cargo" />
                                <asp:BoundField DataField="eo_descripcion" HeaderText="Unidad Organizacional" />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnSeleccionarItem" CommandName="GetItem" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-user-plus'></i></span>" data-toggle='tooltip' data-placement='top' title='Asignar Item' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="GvLista" EventName="RowCommand" />
        </Triggers>
    </asp:UpdatePanel>
        <!--Result Record Ends here -->
                <div class="card">
                    <div class="card-header border-top">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Datos Requeridos</h3>
                            <p class="text-sm mb-0">Datos que deben ser llenados de forma obligatoria para realizar la nueva asignación.</p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_a" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <asp:HiddenField ID="Hf_ca_id" runat="server" />
                                <asp:HiddenField ID="Hf_ti_tipo" runat="server" />
                                <asp:HiddenField ID="Hf_ti_tipo_item_gral" runat="server" />
                                <div class="row">
                                    <!-- as_tipo_mov -->
                                    <div class="form-group col-lg-6">
                                        <label class="form-control-label" for="Ddl_as_tipo_mov">Tipo de Alta</label>
                                        <asp:DropDownList ID="Ddl_as_tipo_mov" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_as_tipo_mov" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                    <asp:Panel runat="server" ID="panelEscalafonDocentes" Visible="false">
                                    <div class="col-lg-9" >
                                        <label class="form-control-label" for="ddlDocente">Escalafón (Solo Docentes)</label>
                                        <asp:DropDownList runat="server" ID="ddlDocente" CssClass="form-control"> </asp:DropDownList>
<%--                                        <asp:DropDownList ID="ddlDocente" CssClass="form-control select"   runat="server" />--%>
<%--                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlDocente" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />--%>
                                    </div>

                                    </asp:Panel>

                                    <!-- p_descripcion -->
                                    <asp:Panel ID="P_p_descripcion" CssClass="form-group col-md-6" Visible="false" runat="server">
                                        <label class="form-control-label" for="Txt_p_descripcion">Puesto</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_p_descripcion" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator ID="Rfv_pu_descripcion" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_p_descripcion" ValidationGroup="add" Display="Dynamic" Enabled="false" runat="server" />
                                    </asp:Panel>
                                    <!-- as_fecha_inicio -->
                                    <div class="form-group col-lg-4">
                                        <label class="form-control-label" for="Txt_as_fecha_inicio">Fecha de Asignación</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="far fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_as_fecha_inicio" CssClass="form-control datepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_as_fecha_inicio" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- as_fecha_fin -->
                                    <asp:Panel ID="P_as_fecha_fin" CssClass="form-group col-lg-4" Visible="false" runat="server">
                                        <label class="form-control-label" for="Txt_as_fecha_fin">Fecha de Baja</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="far fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_as_fecha_fin" CssClass="form-control datepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_as_fecha_fin" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </asp:Panel>
                                    <!-- BtnGuardar -->
                                    <div class="form-group col-lg-4">
                                        <label class="form-control-label" for="BtnRegistrar"></label>
                                        <div class="input-group input-group-merge">
                                            <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
            <div class="col-lg-6">
                <asp:UpdatePanel ID="Up_info" runat="server">
                    <ContentTemplate>
                        <div class="card card-profile text-uppercase">
                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                        <!-- fp_foto -->
                                        <a href="#">
                                            <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
                                        </a>
                                    </div>
                                </div>
                            </div>
                            <!-- jornada de trabajo -->
                            <div class="col-4">
                                    <span><strong class="h5">TIPO JORNADA: </strong><h6><asp:Literal ID="ltl_jornada" runat="server"/></h6></span>
                            </div>
                            <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                <!-- as_estado -->
                                <asp:Label ID="Lbl_as_estado" CssClass="btn btn-sm btn-info float-right" runat="server" />

                            </div>
                            <div class="card-body pt-0">
                                <h5 class="h3 text-center">
                                    <!-- per_nombres -->
                                    <asp:Literal ID="Lt_per_nombres" runat="server" />
                                </h5>
                                <div class="h5 font-weight-400 text-center">
                                    <!-- per_num_doc -->
                                    <strong class="h5">CI:</strong>
                                    <asp:Literal ID="Lt_per_num_doc" runat="server" />
                                    <!-- per_id -->
                                    <strong class="h5">CÓDIGO:</strong>
                                    <asp:Literal ID="Lt_per_id" runat="server" />
                                    <!-- ca_num_item -->
                                    <strong class="h5">ÍTEM:</strong>
                                    <asp:Literal ID="Lt_ca_num_item" runat="server" />
                                </div>
                                <asp:Panel ID="P_datos" Visible="false" runat="server">
                                    <hr class="my-3" />
                                    <div style="background-color: #D2EEE0; border-radius: .375rem; padding: 0px 17px;">
                                        <h6 class="heading-small text-muted">Escalafón</h6>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <!-- es_descripcion -->
                                                <div class="content-text-label">Cargo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_es_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- p_descripcion -->
                                                <div class="content-text-label">Puesto</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_p_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- ca_basico_calculado -->
                                                <div class="content-text-label">Haber Básico (Bs)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ca_basico_calculado" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- es_escalafon -->
                                                <div class="content-text-label">Código Escalafón</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_es_escalafon" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- ns_clase -->
                                                <div class="content-text-label">Clase</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ns_clase" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- ns_nivel -->
                                                <div class="content-text-label">Nivel Salarial</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ns_nivel" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-3">
                                    <div style="background-color: #D2EEE0; border-radius: .375rem; padding: 0px 17px;">
                                        <h6 class="heading-small text-muted">Categoría Administrativa</h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <!-- eo_descripcion -->
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_eo_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- eo_prog -->
                                                <div class="content-text-label">Categoría</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_eo_prog" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-3">
                                    <div style="background-color: #D2EEE0; border-radius: .375rem; padding: 0px 17px;">
                                        <h6 class="heading-small text-muted">Categoría Programática</h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <!-- cp_descripcion -->
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_cp_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- cp_da -->
                                                <div class="content-text-label">Categoría</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_cp_da" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Modal component -->
    <!--Item Record Modal Starts here -->
    <div id="itemModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="itemTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_list" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
<%--                                    <div class="text-muted text-center mt-2 mb-3"><small>ITEM</small></div>--%>
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">

                            <h3 class="mb-0">Asignación de Item</h3>
                            <p class="text-sm mb-0">Seleccione la dependencia para encontrar un item acéfalo</p>
                            </div>
                        </div>
                                </div>
                            </div>
                            <div class="card-body px-lg-5 py-lg-5">
                                <div class="row">
                                    <!-- Treeview -->
                                    <asp:TreeView ID="Tv_nivelOrg" ImageSet="Arrows" CssClass="treeView" AutoGenerateDataBindings="true" OnSelectedNodeChanged="tv_nivelOrg_SelectedNodeChanged" runat="server">
                                        <NodeStyle Font-Size=".875em" ForeColor="#525f7f" HorizontalPadding="2px" NodeSpacing="0px" VerticalPadding="2px"></NodeStyle>
                                        <SelectedNodeStyle CssClass="SelectedNodeTreeView" />
                                        <HoverNodeStyle CssClass="HoverTreeView" />
                                    </asp:TreeView>
                                </div>
                            </div>
                            <div class="form-group text-center">
                                <asp:LinkButton ID="BtnCancelarI" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarI_Click" runat="server" />
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!--Item Record Modal Ends here -->

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
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Ddl_tipo_doc">Tipo Documento</label>
                                            <asp:DropDownList ID="Ddl_gl_tipo_doc" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_gl_tipo_doc" ValidationGroup="glosa" InitialValue="0" Display="Dynamic" runat="server" />
                                        </div>
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
                                    </div>
                                    <div class="row">
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
    <!-- Glosa Record Modal Ends here -->

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_search" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_a" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_info" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_list" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_glosa" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="PanelGrid" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
