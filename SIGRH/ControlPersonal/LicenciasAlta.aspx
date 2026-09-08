<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="LicenciasAlta.aspx.cs" Inherits="ControlPersonal_Licencias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Licencia Justificada</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-7">
                <div class="card">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Datos para el registro de la Licencia</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <asp:UpdatePanel ID="Up_form_l" runat="server">
                        <ContentTemplate>
                            <div class="card-body">
                                <asp:HiddenField ID="Hf_lj_id" runat="server" />
                                <asp:HiddenField ID="Hf_dia" runat="server" />
                                <div class="row">
                                    <!-- lj_tipo_licencia -->
                                    <div class="form-group col-md-12">
                                        <label class="form-control-label" for="Ddl_lj_tipo_licencia">Tipo Licencia</label>
                                        <asp:DropDownList ID="Ddl_lj_tipo_licencia" CssClass="form-control select2" AppendDataBoundItems="true" AutoPostBack="true" OnSelectedIndexChanged="Ddl_lj_tipo_licencia_SelectedIndexChanged" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_lj_tipo_licencia" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- lj_motivo -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_lj_motivo">Motivo</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_lj_motivo" CssClass="form-control" TextMode="MultiLine" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_motivo" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- lj_lugar -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_lj_lugar">Lugar</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_lj_lugar" CssClass="form-control" TextMode="MultiLine" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_lugar" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- lj_fecha_inicial -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_lj_fecha_inicial">Fecha Inicio</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_lj_fecha_inicial" CssClass="form-control datepickerDefault" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_fecha_inicial" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- lj_fecha_final -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_lj_fecha_final">Fecha Fin</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_lj_fecha_final" CssClass="form-control datepickerDefault" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator ID="Rfv_lj_fecha_final" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_fecha_final" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- lj_hora_salida -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_lj_hora_salida">Hora Inicio</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_lj_hora_salida" CssClass="form-control timepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_hora_salida" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- lj_hora_retorno -->
                                    <div class="form-group col-md-6">
                                        <label class="form-control-label" for="Txt_lj_hora_retorno">Hora Fin</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-calendar-alt"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_lj_hora_retorno" CssClass="form-control timepickerD" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_hora_retorno" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </div>
                                    <!-- habilitar_txt -->
                                    <asp:Panel ID="P_habilitar_txt" CssClass="form-group col-md-2" Visible="false" runat="server">
                                        <label class="form-control-label pb-3" for="Chk_habilitar_txt">¿Habilitar Texto?</label>
                                        <div>
                                            <label class="custom-toggle custom-toggle-warning">
                                                <asp:CheckBox ID="Chk_habilitar_txt" AutoPostBack="true" OnCheckedChanged="Chk_habilitar_txt_CheckedChanged" runat="server" />
                                                <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                            </label>
                                        </div>
                                    </asp:Panel>
                                    <!-- lj_per_id_autoriza -->
                                    <asp:Panel ID="P_ddl_lj_per_id_autoriza"  Visible="false" CssClass="form-group col-md-12" runat="server">
                                        <label class="form-control-label" for="Ddl_lj_per_id_autoriza">Autorizado Por</label>
                                        <asp:DropDownList ID="Ddl_lj_per_id_autoriza" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Ddl_lj_per_id_autoriza" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                    </asp:Panel>
                                    <!-- lj_per_id_autoriza -->
                                    <asp:Panel ID="P_txt_lj_per_id_autoriza" CssClass="form-group col-md-10" ClientIDMode="Static" Visible="false" runat="server">
                                        <label class="form-control-label" for="Txt_lj_per_id_autoriza">Autorizado Por</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text">
                                                    <i class="fas fa-edit"></i>
                                                </span>
                                            </div>
                                            <asp:TextBox ID="Txt_lj_per_id_autoriza" CssClass="form-control" runat="server" />
                                        </div>
                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_lj_per_id_autoriza" ValidationGroup="add" Display="Dynamic" runat="server" />
                                    </asp:Panel>
                                </div>
                                <div class="row">
                                    <div class="offset-lg-6 col-lg-6">
                                        <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>

                    <asp:UpdatePanel ID="Up_list" runat="server">
                    <ContentTemplate>
                        <asp:Panel ID="P_ListaL" CssClass="card" Visible="false" runat="server">
                            <div class="card-header">
                                <div class="ct-page-title">
                                    <h3 class="mb-0">Historial de Registros</h3>
                                    <p class="text-sm mb-0"></p>
                                </div>
                            </div>
                            <div class="card-body">
                                <asp:GridView ID="GvListaL" CssClass="table table-bordered table-hover table-striped table-responsive" AutoGenerateColumns="false" DataKeyNames="lj_id" OnPreRender="GvListaL_PreRender" OnRowCommand="GvListaL_RowCommand" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="cat_descripcion" HeaderText="Tipo Licencia" />
                                        <asp:BoundField DataField="lj_fecha_licencia" HeaderText="Fecha Licencia" />
                                        <asp:BoundField DataField="lj_hora_licencia" HeaderText="Hora Licencia" />
                                        <asp:BoundField DataField="lj_motivo" HeaderText="Motivo" />
                                        <asp:BoundField DataField="lj_lugar" HeaderText="Lugar" />
                                        <asp:BoundField DataField="lj_estado" HeaderText="Estado" />
                                        <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="BtnGlosa" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-info btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-eye'></i></span>" data-toggle="tooltip" data-original-title="Glosa" runat="server" />
                                                <asp:LinkButton CommandName="BtnEliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle='tooltip' data-original-title='Anular' runat="server" />
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
                                        <asp:Image ID="Img_fp_foto" CssClass="rounded-circle" runat="server" />
                                    </div>
                                </div>
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
                                <div id="diAcreedor" style="display: none;">
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
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>

    <!-- Modal component -->
    <!-- Question Glosa Record Modal Starts here -->
    <div id="questionGlModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="questionGlTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_question_gl" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>GLOSA</small></div>
                                </div>
                                <div class="card-body text-center px-lg-5 py-lg-5">
                                    <p>¿Es necesario registrar la glosa?</p>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarQG" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Si" OnClick="BtnGuardarQG_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarQG" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> No" OnClick="BtnCancelarQG_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Question Glosa Record Modal Ends here -->

    <!-- Question Glosa Record Modal Starts here -->
    <div id="questionElModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="questionElTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
        <div class="modal-dialog modal-dialog-centered modal-sm" role="document">
            <div class="modal-content">
                <asp:UpdatePanel ID="Up_question_el" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <div class="card bg-secondary border-0 mb-0">
                                <div class="card-header">
                                    <div class="text-muted text-center mt-2 mb-3"><small>ANULAR</small></div>
                                </div>
                                <div class="card-body text-center px-lg-5 py-lg-5">
                                    <p>¿Está seguro(a) de anular la licencia justificada?</p>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardarQE" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Si" OnClick="BtnGuardarQE_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelarQE" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> No" OnClick="BtnCancelarQE_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Question Glosa Record Modal Ends here -->

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

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_l" runat="server">
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
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_question_gl" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_question_el" runat="server">
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
