<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="TipoAportanteAlta.aspx.cs" Inherits="Salarios_TipoAportanteAlta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Tipo Aportante</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page Content -->
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-7">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Selección Tipo Aportante</h3>
                            <p class="text-sm mb-0">Seleccione en la lista desplegable, el tipo de aportante correspondiente.</p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <div class="row">
                                    <!-- at_aportar -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Rbl_at_aportar">¿Quiere Aportar?</label>
                                        <div class="custom-control custom-radio">
                                            <asp:RadioButtonList ID="Rbl_at_aportar" CssClass="radios" RepeatDirection="Horizontal" runat="server">
                                                <asp:ListItem Text="SI" />
                                                <asp:ListItem Text="NO" />
                                            </asp:RadioButtonList>
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Rbl_at_aportar" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- at_jubilado -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Rbl_at_jubilado">¿Es Jubilado?</label>
                                        <div class="custom-control custom-radio">
                                            <asp:RadioButtonList ID="Rbl_at_jubilado" CssClass="radios" RepeatDirection="Horizontal" OnSelectedIndexChanged="Rbl_at_jubilado_SelectedIndexChanged" AutoPostBack="true" runat="server">
                                                <asp:ListItem Value="true" Text="SI" />
                                                <asp:ListItem Value="false" Text="NO" />
                                            </asp:RadioButtonList>
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Rbl_at_jubilado" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- at_ta_id -->
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label" for="Ddl_at_ta_id">Tipo Aportante</label>
                                        <asp:DropDownList ID="Ddl_at_ta_id" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" Enabled="false" OnSelectedIndexChanged="Ddl_at_ta_id_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_at_ta_id" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                </div>
                                <asp:Panel ID="P_info" CssClass="row" Visible="false" runat="server">
                                    <div class="col-md-6">
                                        <hr class="my-3" />
                                        <h6 class="heading-small text-muted">Aporte Laboral</h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <!-- ta_lab_cotizacion_mensual -->
                                                <div class="content-text-label">Cotización Mensual SSO</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ta_lab_cotizacion_mensual" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- ta_lab_prima_riesgo_comun -->
                                                <div class="content-text-label">Prima Riesgo Común</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ta_lab_prima_riesgo_comun" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- ta_lab_comision_afp -->
                                                <div class="content-text-label">Comisión AFP</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ta_lab_comision_afp" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- ta_lab_solidario -->
                                                <div class="content-text-label">Aporte Solidario</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ta_lab_solidario" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-3" />
                                    </div>
                                    <div class="col-md-6">
                                        <hr class="my-3" />
                                        <h6 class="heading-small text-muted">Aporte Patronal</h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <!-- ta_pat_prima_riesgo_prof -->
                                                <div class="content-text-label">Prima de Riesgo Profesional</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ta_pat_prima_riesgo_prof" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- ta_pat_caja -->
                                                <div class="content-text-label">Cajas</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ta_pat_caja" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- ta_pat_provivienda -->
                                                <div class="content-text-label">Provivienda</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ta_pat_provivienda" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- ta_pat_solidario -->
                                                <div class="content-text-label">Aporte Solidario</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_ta_pat_solidario" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-3" />
                                    </div>
                                </asp:Panel>
                                <div class="row">
                                    <div class="offset-lg-6 col-lg-6">
                                        <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <asp:UpdatePanel ID="Up_list" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="P_lista" CssClass="card" Visible="false" runat="server">
                            <div class="card-header border-bottom">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Lista Tipo de Aportante</h3>
                                    <p class="text-sm mb-0"></p>
                                </div>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="at_id" OnPreRender="GvLista_PreRender" OnRowDataBound="GvLista_RowDataBound" OnRowCommand="GvLista_RowCommand" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="ta_descripcion" HeaderText="Tipo Aportante" />
                                        <asp:BoundField DataField="at_estado" HeaderText="Estado" />
                                        <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetGlosa" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>" data-toggle="tooltip" data-original-title="Glosa" runat="server" />
                                                <%--<asp:LinkButton ID="BtnEdit" CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-pen'></i></span>" data-toggle="tooltip" data-placement="top" title="Editar" runat="server" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-5">
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
                                <hr class="my-3" />
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
                                <hr class="my-3">
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
                                <hr class="my-3">
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
                                <hr class="my-3" />
                                <div style="background-color: #D2EEE0; border-radius: .375rem; padding: 0px 17px;">
                                    <h6 class="heading-small text-muted">Fecha Nacimiento Y Edad</h6>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <!-- per_fecha_nac -->
                                            <div class="content-text-label">Fecha Nacimiento</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_per_fecha_nac" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-6">
                                            <!-- per_edad -->
                                            <div class="content-text-label">Edad</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_per_edad" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
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
                                                <asp:TextBox ID="Txt_gl_fecha_doc" class="form-control datepickerD" ClientIDMode="Static" runat="server" />
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
    <!-- Glosa Record Modal Ends here -->

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_list" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_info" runat="server">
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
