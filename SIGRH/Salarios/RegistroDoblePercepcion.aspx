<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroDoblePercepcion.aspx.cs" Inherits="Salarios_RegistroDoblePercepcion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Doble Percepción</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Datos de la Transacción</h3>
                            <p class="text-sm mb-0">Ingrese la información solicitada</p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <div class="nav-wrapper" style="padding: 0 0 1rem 0;"  runat="server" visible="false">
                                    <ul class="nav nav-pills nav-fill flex-column flex-md-row row">
                                        <li class="nav-item col-lg-6">
                                            <asp:LinkButton ID="BtnTabPU" CssClass="nav-link mb-sm-3 mb-md-0 active" Text="<i class='fas fa-money-bill-alt mr-2'></i>Monto Único" ClientIDMode="Static" OnClick="BtnTabPU_Click" runat="server" />
                                        </li>
                                        <li class="nav-item col-lg-6">
                                            <asp:LinkButton ID="BtnTabPC" CssClass="nav-link mb-sm-3 mb-md-0" Text="<i class='fas fa-coins mr-2'></i>Monto por Cuotas" ClientIDMode="Static" OnClick="BtnTabPC_Click" runat="server" />
                                        </li>
                                    </ul>
                                </div>
                                <div class="card-body shadow">
                                    <asp:HiddenField ID="Hf_tc_cuota_resto" runat="server" />
                                    <div class="row">
                                        <!-- tr_fa_id -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Ddl_tr_fa_id">Tipo de Transacción</label>
                                            <asp:DropDownList ID="Ddl_tr_fa_id" CssClass="form-control select2" data-minimum-results-for-search="Infinity" AppendDataBoundItems="true" OnSelectedIndexChanged="Ddl_tr_fa_id_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_tr_fa_id" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- tr_monto -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_tr_monto">Monto  percibido en la institución externa</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_tr_monto" CssClass="form-control" TextMode="Number" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_tr_monto" ValidationGroup="add" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                    <asp:Panel ID="P_cuotas" Visible="false" runat="server">
                                        <div class="row">
                                            <!-- tc_cant_cuotas -->
                                            <div class="form-group col-md-6">
                                                <label class="form-control-label" for="Txt_tc_cant_cuotas">Total de Cuotas</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">
                                                            <i class="fas fa-edit"></i>
                                                        </span>
                                                    </div>
                                                    <asp:TextBox ID="Txt_tc_cant_cuotas" CssClass="form-control numero" TextMode="Number" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_tc_cant_cuotas" ValidationGroup="add" Display="Dynamic" runat="server" />
                                            </div>
                                            <!-- tc_monto -->
                                            <div class="form-group col-md-6">
                                                <label class="form-control-label" for="Txt_tc_monto">Monto de la Cuota</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text">
                                                            <i class="fas fa-edit"></i>
                                                        </span>
                                                    </div>
                                                    <asp:TextBox ID="Txt_tc_monto" CssClass="form-control" TextMode="Number" Enabled="false" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="row mt-3">
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
                        <asp:Panel ID="P_list" CssClass="card" Visible="false" runat="server">
                            <div class="card-header">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Transacciones del Funcionario Vigentes</h3>
                                    <p class="text-sm mb-0"></p>
                                </div>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="tr_id" OnPreRender="GvLista_PreRender" OnRowCommand="GvLista_RowCommand" OnRowDataBound="GvLista_RowDataBound" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="fa_descripcion" HeaderText="Tipo Transacción" />
                                        <asp:BoundField DataField="tr_monto" HeaderText="Monto" DataFormatString="{0:N}" />
                                        <asp:BoundField DataField="tr_fecha_inicio" HeaderText="Fecha Registro" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="BtnCuota" CommandName="GetCuota" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-primary btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-dollar-sign'></i></span>" data-toggle="tooltip" data-original-title="Cuotas" runat="server" />
                                                <asp:LinkButton CommandName="GetGlosa" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>" data-toggle="tooltip" data-original-title="Glosa" runat="server" />
                                                <%--<asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle="tooltip" data-original-title="Eliminar" runat="server" />--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="col-lg-6">
                <asp:UpdatePanel ID="Up_info" runat="server">
                    <ContentTemplate>
                        <div class="card card-profile text-uppercase">
                            <div class="row justify-content-center">
                                <div class="col-lg-3 order-lg-2">
                                    <div class="card-profile-image">
                                        <!-- fp_foto -->
                                        <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
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
                                    <strong class="h5">ITEM:</strong>
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
                                <%--<hr class="my-3">--%>
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
                                <asp:Panel ID="P_acreedor" Visible="false" runat="server">
                                    <hr class="my-3" />
                                    <div style="background-color: #D2EEE0; border-radius: .375rem; padding: 0px 17px;">
                                        <h6 class="heading-small text-muted">Beneficiario</h6>
                                        <div class="row">
                                            <asp:HiddenField ID="Hf_acr_id" runat="server" />
                                            <asp:HiddenField ID="Hf_acr_tipo_entidad" runat="server" />
                                            <div class="col-lg-3">
                                                <!-- acr_tipo_entidad -->
                                                <div class="content-text-label">Tipo Entidad</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_acr_tipo_entidad" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <!-- acr_descripcion -->
                                                <div class="content-text-label">Descripción</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_acr_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <!-- acr_documento -->
                                                <div class="content-text-label">Documento</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_acr_documento" runat="server" />
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
    <!-- Cuotas Record Modal Starts here -->
    <div id="cuotaModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="cuotaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_form_c" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>PLAN DE CUOTAS</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <h6 class="heading-small text-muted">Transacción</h6>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <!-- tr_fa_id -->
                                            <div class="content-text-label">Tipo Transacción</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_tr_fa_id" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <!-- tr_monto -->
                                            <div class="content-text-label">Monto</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_tr_monto" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <!-- tr_fecha_inicio -->
                                            <div class="content-text-label">Fecha Inicio</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_tr_fecha_inicio" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-3">
                                    <asp:GridView ID="GvCuota" CssClass="table table-bordered table-striped table-hover table-gv-cuota" AutoGenerateColumns="false" DataKeyNames="tc_id" OnPreRender="GvCuota_PreRender" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="tc_cant_cuotas" HeaderText="Nº Cuota" />
                                            <asp:BoundField DataField="tc_monto" HeaderText="Monto" DataFormatString="{0:N}" />
                                            <asp:BoundField DataField="tc_estado" HeaderText="Estado" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnCancelarPC" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarPC_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Cuotas Record Modal Ends here -->

    <!-- Delete Record Modal Starts here -->
    <div id="deleteModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="deleteTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_form_d" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>ELIMINAR REGISTRO</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <asp:HiddenField ID="Hf_tr_id_b" runat="server" />
                                    <h6 class="heading-small text-muted">Transacción</h6>
                                    <div class="row">
                                        <div class="col-lg-6">
                                            <!-- tr_fa_id -->
                                            <div class="content-text-label">Tipo Transacción</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_tr_fa_id_b" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <!-- tr_monto -->
                                            <div class="content-text-label">Monto</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_tr_monto_b" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <!-- tr_fecha_inicio -->
                                            <div class="content-text-label">Fecha Inicio</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="Lt_tr_fecha_inicio_b" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <hr class="my-3">
                                    <p>¿Seguro(a) qué quiere eliminar el registro?</p>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarB" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Si" OnClick="BtnGuardarB_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarB" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> No" OnClick="BtnCancelarB_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Delete Record Modal Ends here -->

    <!-- Acreedor Record Modal Starts here -->
    <div id="acreedorModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="acreedorTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_form_a" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>BENEFICIARIO</small></div>
                                </div>
                                <div class="card-body px-lg-5 py-lg-5">
                                    <div class="row">
                                        <!-- ac_tipo -->
                                        <div class="form-group col-md-3">
                                            <label class="form-control-label" for="Ddl_acr_tipo_entidad">Tipo Beneficiario</label>
                                            <asp:DropDownList ID="Ddl_acr_tipo_entidad" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" OnSelectedIndexChanged="Ddl_acr_tipo_entidad_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_acr_tipo_entidad" ValidationGroup="add_a" InitialValue="0" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- ac_descripcion -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_acr_descripcion">Descripción</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_acr_descripcion" CssClass="form-control" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_acr_descripcion" ValidationGroup="add_a" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- ac_documento -->
                                        <div class="form-group col-md-3">
                                            <label class="form-control-label" for="Txt_acr_documento">Documento</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_acr_documento" CssClass="form-control" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator ID="Rfv_acr_documento" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_acr_documento" ValidationGroup="add_a" Display="Dynamic" Enabled="false" runat="server" />
                                        </div>
                                    </div>
                                    <asp:Panel ID="P_list_acreedor" Visible="false" runat="server">
                                        <div class="card">
                                            <div class="card-header">
                                                <div class="ct-page-title">
                                                    <h3 class="mb-0">Lista de Beneficiarios Asignados</h3>
                                                    <p class="text-sm mb-0"></p>
                                                </div>
                                            </div>
                                            <div class="card-body">
                                                <asp:GridView ID="GvAcreedor" CssClass="table table-bordered table-striped table-hover" AutoGenerateColumns="false" DataKeyNames="acr_id" OnPreRender="GvAcreedor_PreRender" OnRowCommand="GvAcreedor_RowCommand" runat="server">
                                                    <Columns>
                                                        <asp:BoundField DataField="cat_descripcion" HeaderText="Tipo Beneficiario" />
                                                        <asp:BoundField DataField="acr_descripcion" HeaderText="Descripción" />
                                                        <asp:BoundField DataField="acr_documento" HeaderText="Documento" />
                                                        <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                            <ItemTemplate>
                                                                <asp:LinkButton CommandName="GetSelect" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-chevron-right'></i></span>" data-toggle="tooltip" data-original-title="Seleccionar" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarA" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="add_a" OnClick="BtnGuardarA_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarA" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelarA_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Acreedor Record Modal Ends here -->

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
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_c" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_d" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_a" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_glosa" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <script>
        function GetKeyUpE() {
            var var_monto = $("#<%=Txt_tr_monto.ClientID%>").val();
            var var_cantc = $("#<%=Txt_tc_cant_cuotas.ClientID%>").val();
            var var_divm; var var_divr;

            if (var_monto != "" && var_cantc != "") {
                var_divm = parseInt(var_monto / var_cantc);
                var_divr = var_monto % var_cantc;
                $("#<%=Txt_tc_monto.ClientID%>").val(var_divm);
                $("#<%=Hf_tc_cuota_resto.ClientID%>").val(var_divm + var_divr);
            }
        }

        function GetKeyUpD() {
            var var_monto = $("#<%=Txt_tr_monto.ClientID%>").val();
            var var_cantc = $("#<%=Txt_tc_cant_cuotas.ClientID%>").val();
            var var_divm; var var_divr;

            if (var_monto != "" && var_cantc != "") { $("#<%=Txt_tc_monto.ClientID%>").val(var_monto / var_cantc); }
        }
    </script>
</asp:Content>

