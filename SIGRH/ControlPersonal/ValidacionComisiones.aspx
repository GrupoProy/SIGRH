<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ValidacionComisiones.aspx.cs" Inherits="ControlPersonal_ValidacionComisiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Validación de Comisiones</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="card" runat="server" visible="false">
            <div class="card-header">
                <div class="ct-page-title">
                    <h3 class="mb-0">Búsqueda de Personal</h3>
                    <p class="text-sm mb-0">En el siguiente formulario puede buscar un registro correspondiente a los parámetros ingresados.</p>
                </div>
            </div>
            <asp:UpdatePanel ID="Up_busqueda" runat="server">
                <ContentTemplate>
                    <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">
                        <div class="row">
                            <!-- per_ap_paterno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_paterno_b">Apellido Paterno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_paterno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_ap_materno -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_materno_b">Apellido Materno</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_materno_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <!-- per_nombres -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_nombres_b">Nombre(s)</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_nombres_b" CssClass="form-control letras" runat="server" />
                                </div>
                            </div>
                            <%--<!-- lj_ped_val -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Rbl_lj_ped_val">Licencia</label>
                                <div class="custom-control custom-radio">
                                    <asp:RadioButtonList ID="Rbl_lj_ped_val" CssClass="radios" RepeatDirection="Horizontal" AutoPostBack="true" OnSelectedIndexChanged="Rbl_lj_ped_val_SelectedIndexChanged" runat="server">
                                        <asp:ListItem Value="P" Text="Pendiente" />
                                        <asp:ListItem Value="V" Text="Validado" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>--%>
                        </div>
                        <div class="row">
                            <!-- per_num_doc -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_num_doc_b">Carnet de Identidad</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_num_doc_b" CssClass="form-control" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- per_id -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_id_b">Código de Funcionario</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_id_b" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- lj_id -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_lj_id">Nº Papeleta</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_lj_id" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- BtnBuscar -->
                            <div class="form-group col-md-3 align-self-end">
                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar"  runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- Result Record Starts here -->
        <asp:UpdatePanel ID="Up_lista_lj" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_lista_lj_p" CssClass="card" Visible="false" runat="server">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Lista de Comisiones Pendientes</h3>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="Gv_lista_lj_p" EmptyDataText="No existen comisiones por validar" CssClass="table table-bordered table-hover table-striped" OnRowDataBound="Gv_lista_lj_p_RowDataBound" AutoGenerateColumns="false" DataKeyNames="lj_id" OnPreRender="Gv_lista_lj_p_PreRender" OnRowCommand="Gv_lista_lj_p_RowCommand" runat="server">
                            <Columns>
                                <%--<asp:BoundField DataField="lj_id" HeaderText="Nº Papeleta" />--%>
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="per_funcionario" HeaderText="Funcionario(a)" />
                                <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />
                                <%--<asp:BoundField DataField="cat_descripcion" HeaderText="Tipo Licencia" />--%>
                                <asp:BoundField DataField="lj_fecha_licencia" HeaderText="Fecha Licencia" />
                                <asp:BoundField DataField="lj_hora_licencia" HeaderText="Hora Licencia" />
                                <%--<asp:BoundField DataField="lj_estado" HeaderText="Estado" />--%>
                                <asp:TemplateField HeaderText="Validar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="BtnValidar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span>" data-toggle="tooltip" data-placement="top" title="Validar" runat="server" />
<%--                                        <asp:LinkButton CommandName="BtnGlosa" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>" data-toggle="tooltip" data-original-title="Glosa" runat="server" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
                <div class="row" runat="server" Visible="false" ID="leyenda">
                    <div class="col-12 text-center card">
                        <hr />
                        <asp:Label CssClass="text-center text-green titulo"  Text="No existen Comisiones por Validar" runat="server" />
                        <hr />
                    </div>
                </div>
                <%--<asp:Panel ID="P_lista_lj_v" CssClass="card" Visible="false" runat="server">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Lista de Licencias Justificadas</h3>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="Gv_lista_lj_v" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="lj_id" OnPreRender="Gv_lista_lj_v_PreRender" OnRowCommand="Gv_lista_lj_v_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="lj_id" HeaderText="Nº Papeleta" />
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="per_funcionario" HeaderText="Funcionario(a)" />
                                <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />
                                <asp:BoundField DataField="cat_descripcion" HeaderText="Tipo Licencia" />
                                <asp:BoundField DataField="lj_fecha_licencia" HeaderText="Fecha Licencia" />
                                <asp:BoundField DataField="lj_hora_licencia" HeaderText="Hora Licencia" />
                                <asp:BoundField DataField="lj_estado" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="BtnDesvalidar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-times'></i></span>" data-toggle="tooltip" data-placement="top" title="Desvalidar" runat="server" />
                                        <asp:LinkButton CommandName="BtnGlosa" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>" data-toggle="tooltip" data-original-title="Glosa" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>--%>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="Gv_lista_lj_p" />
            </Triggers>
        </asp:UpdatePanel>
        <!-- List Record Ends here -->
    </div>

    <!-- Modal component -->
    <!-- Validar Record Modal Starts here -->
    <div id="validarModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="validarTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content" style="margin-top: 50px;">
                <asp:UpdatePanel ID="Up_form_v" runat="server">
                    <ContentTemplate>
                        <asp:Panel CssClass="modal-body p-0" DefaultButton="BtnGuardarV" runat="server">
                            <asp:HiddenField ID="Hf_lj_id" runat="server" />
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="row justify-content-center">
                                    <div class="col-lg-3 order-lg-2">
                                        <div class="card-profile-image">
                                            <!-- fp_foto -->
                                            <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                                    <!-- as_estado -->
                                    <asp:Label ID="Lbl_as_estado" CssClass="btn btn-sm btn-info float-right" runat="server" />
                                </div>
                                <div class="card-body px-lg-5 py-lg-3">
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
                                    <hr class="my-2">
                                    <h6 class="heading-small text-muted">Información Fecha Asignación</h6>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <!-- as_fecha_inicio -->
                                            <div class="content-text-label">Fecha Alta</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_as_fecha_inicio" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <!-- as_fecha_fin -->
                                            <div class="content-text-label">Fecha Baja</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_as_fecha_fin" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-3">
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <h6 class="heading-small text-muted">Categoría Administrativa</h6>
                                            <!-- eo_descripcion -->
                                            <div class="content-text-label">Ubicación</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_eo_descripcion" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <h6 class="heading-small text-muted">Categoría Programática</h6>
                                            <!-- cp_descripcion -->
                                            <div class="content-text-label">Ubicación</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_cp_descripcion" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-3" />
                                    <div style="background-color: #D2EEE0; border-radius: .375rem; padding: 0px 17px;">
                                        <h6 class="heading-small text-muted">Datos Licencia Justificada</h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <!-- lj_tipo_licencia -->
                                                <div class="content-text-label">Tipo Licencia</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_tipo_licencia" runat="server" />
                                                </div>
                                            </div>
<%--                                            <div class="col-lg-6">
                                                <!-- lj_per_id_autoriza -->
                                                <div class="content-text-label">Autorizado Por</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_per_id_autoriza" runat="server" />
                                                </div>
                                            </div>--%>
                                            <div class="col-lg-6">
                                                <!-- lj_fecha_licencia -->
                                                <div class="content-text-label">Fecha Licencia</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_fecha_licencia" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- lj_hora_licencia -->
                                                <div class="content-text-label">Hora Licencia</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_hora_licencia" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- lj_motivo -->
                                                <div class="content-text-label">Motivo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_motivo" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- lj_lugar -->
                                                <div class="content-text-label">Lugar</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_lj_lugar" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarV" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Validar" OnClick="BtnGuardarV_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarV" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarV_Click" runat="server" />
                                </div>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Validar Record Modal Ends here -->

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
                                    <%--<asp:HiddenField ID="Hf_lj_id_g" runat="server" />--%>
                                    <div class="row">
                                        <!-- gl_tipo_doc -->
                                        <div id="D_gl_tipo_doc" class="form-group col-md-6">
                                            <label class="form-control-label" for="Ddl_gl_tipo_doc">Tipo Documento</label>
                                            <asp:DropDownList ID="Ddl_gl_tipo_doc" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_gl_tipo_doc_SelectedIndexChanged" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_gl_tipo_doc" ValidationGroup="glosa" InitialValue="0" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- gl_numero_doc -->
                                        <asp:Panel ID="P_gl_numero_doc" CssClass="form-group col-md-4" Visible="false" runat="server">
                                            <label class="form-control-label" for="Txt_gl_numero_doc">Número Documento</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_gl_numero_doc" CssClass="form-control" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_gl_numero_doc" ValidationGroup="glosa" Display="Dynamic" runat="server" />
                                        </asp:Panel>
                                        <!-- gl_fecha_doc -->
                                        <div id="D_gl_fecha_doc" class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_gl_fecha_doc">Fecha Documento</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-calendar-alt"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_gl_fecha_doc" class="form-control datepickerDefault" ClientIDMode="Static" runat="server" />
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
                                    <%--<asp:LinkButton ID="BtnGuardarG" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="glosa" OnClick="BtnGuardarG_Click" runat="server" />--%>
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

    <%--<asp:UpdateProgress AssociatedUpdatePanelID="Up_busqueda" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_lista_lj" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_v" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_glosa" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
