<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Sanciones.aspx.cs" Inherits="Salarios_Sanciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Sanciones</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header">
                <div class="ct-page-title">
                    <h3 class="mb-0">Búsqueda de Categorías</h3>
                    <p class="text-sm mb-0">En el siguiente formulario puede buscar una categoría correspondiente a los parámetros ingresados.</p>
                </div>
            </div>
            <asp:UpdatePanel ID="Up_search" runat="server">
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
                        </div>
                        <div class="row">
                            <%--<!-- cp_da -->
                            <div class="form-group col-md-2">
                                <label class="form-control-label" for="Txt_cp_da">DA</label>
                                <small>(Dirección Administrativa)</small>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_cp_da" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- cp_ue -->
                            <div class="form-group col-md-2">
                                <label class="form-control-label" for="Txt_cp_ue">UE</label>
                                <small>(Unidad Ejecutora)</small>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_cp_ue" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- cp_programa -->
                            <div class="form-group col-md-2">
                                <label class="form-control-label" for="Txt_cp_programa">Prog</label>
                                <small>(Programa)</small>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_cp_programa" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- cp_proyecto -->
                            <div class="form-group col-md-2">
                                <label class="form-control-label" for="Txt_cp_proyecto">Proy</label>
                                <small>(Proyecto)</small>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_cp_proyecto" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- cp_actividad -->
                            <div class="form-group col-md-2">
                                <label class="form-control-label" for="Txt_cp_actividad">Act</label>
                                <small>(Actividad)</small>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_cp_actividad" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>--%>
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
                            <!-- ps_id -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_ps_id">N° Planilla</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_ps_id" CssClass="form-control numero" TextMode="Number" runat="server" />
                                </div>
                            </div>
                            <!-- BtnBuscar -->
                            <div class="form-group col-md-3 align-self-end">
                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="BtnBuscar_Click" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <!-- Result Record Starts here -->
        <asp:UpdatePanel ID="Up_list" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_result" CssClass="card" Visible="false" runat="server">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Lista de Sanciones</h3>
                            <p class="text-sm mb-0">Lista con los resultados de la búsqueda.</p>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:HiddenField ID="Hf_campos_b" runat="server" />
                        <asp:GridView ID="GvLista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="sa_id" OnPreRender="GvLista_PreRender" OnRowDataBound="GvLista_RowDataBound" OnRowCommand="GvLista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" />
                                <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" />
                                <asp:BoundField DataField="per_nombres" HeaderText="Nombre(s)" />
                                <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />
                                <asp:BoundField DataField="fa_descripcion" HeaderText="Tipo de Sanción" />
                                <asp:BoundField DataField="sa_fecha_inicio" HeaderText="Fecha Inicio" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="sa_fecha_fin" HeaderText="Fecha Fin" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField DataField="sa_tipo_sancion" HeaderText="Tipo de Registro" />
                                <asp:BoundField DataField="sa_estado" HeaderText="Estado" />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="BtnValidate" CommandName="GetValidate" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-check'></i></span>" data-toggle="tooltip" data-placement="top" title="Validar" runat="server" />
                                        <asp:LinkButton ID="BtnInvalidate" CommandName="GetInvalidate" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-times'></i></span>" data-toggle="tooltip" data-placement="top" title="Desvalidar" runat="server" />
                                        <%--<asp:LinkButton ID="BtnDelete" CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash'></i></span>" data-toggle="tooltip" data-placement="top" title="Eliminar" runat="server" />--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <!-- List Record Ends here -->

        <!-- Diseño para el button nuevo registro -->
        <div class="col-lg-6 col-5 text-right">
            <asp:UpdatePanel ID="Up_button" runat="server">
                <ContentTemplate>
                    <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Nuevo Registro" OnClick="BtnNuevo_Click" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <!-- Modal component -->
    <!-- Validate Record Modal Starts here -->
    <div id="validateModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="validateTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="overflow-y: auto;">
        <div class="modal-dialog modal-dialog-centered modal-lg" role="document">
            <div class="modal-content" style="margin-top: 50px;">
                <asp:UpdatePanel ID="Up_form_v" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <asp:HiddenField ID="Hf_sa_id" runat="server" />
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
                                        <h6 class="heading-small text-muted">Datos Sanción</h6>
                                        <div class="row">
                                            <div class="col-lg-4">
                                                <!-- fa_descripcion -->
                                                <div class="content-text-label">Tipo Sanción</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_fa_descripcion" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- sa_fecha_inicio, sa_fecha_fin -->
                                                <div class="content-text-label">Fecha Sanción</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_sa_fecha" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <!-- sa_dias_sancion -->
                                                <div class="content-text-label">Días de Sanción</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="Lt_sa_dias_sancion" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Validar" OnClick="BtnGuardar_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelar_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Validate Record Modal Ends here -->

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
                                    <asp:HiddenField ID="Hf_sa_id_g" runat="server" />
                                    <div class="row">
                                        <!-- gl_tipo_doc -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Ddl_tipo_doc">Tipo Documento</label>
                                            <asp:DropDownList ID="Ddl_gl_tipo_doc" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
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
    <!-- Glosa Record Modal Ends here -->

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_search" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_list" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_button" runat="server">
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
