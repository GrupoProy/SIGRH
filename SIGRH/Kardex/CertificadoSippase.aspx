<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="CertificadoSippase.aspx.cs" Inherits="Kardex_Sippase" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Certificado SIPPASE</h6>
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
                        </div>
                        <div class="row">
                            <%--<!-- per_ap_casada -->
                            <div class="form-group col-md-3">
                                <label class="form-control-label" for="Txt_per_ap_casada_b">Apellido del Esposo</label>
                                <div class="input-group input-group-merge">
                                    <div class="input-group-prepend">
                                        <span class="input-group-text">
                                            <i class="fas fa-edit"></i>
                                        </span>
                                    </div>
                                    <asp:TextBox ID="Txt_per_ap_casada_b" CssClass="form-control letras" runat="server" />
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
                                    <asp:TextBox ID="Txt_per_num_doc_b" CssClass="form-control" runat="server" />
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
                            <!-- BtnBuscar -->
                            <div class="form-group offset-md-3 col-md-3 align-self-end">
                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="BtnBuscar_Click" runat="server" />
                            </div>
                        </div>
                    </asp:Panel>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>

        <asp:UpdatePanel ID="Up_busqueda_lista" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_busqueda_lista" CssClass="card" Visible="false" runat="server">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Lista de Personal</h3>
                            <p class="text-sm mb-0">Lista con los resultados de la búsqueda.</p>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="Gv_busqueda_lista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="per_id" OnPreRender="Gv_busqueda_lista_PreRender" OnRowCommand="Gv_busqueda_lista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="per_id" HeaderText="Código" />
                                <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" />
                                <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" />
                                <asp:BoundField DataField="per_nombres" HeaderText="Nombre(s)" />
                                <asp:BoundField DataField="per_ap_casada" HeaderText="Apellido Casada" />
                                <asp:BoundField DataField="per_num_doc" HeaderText="C.I." />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="Btn_nuevo_registro" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-plus'></i></span>" data-toggle="tooltip" data-placement="top" title="Nuevo Registro" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <!-- Modal component -->
    <!-- Parentesco Record Modal Starts here -->
    <div id="sippaseModal" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="sippaseTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false" style="overflow-y: auto;">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="margin-top: 50px;">
                <asp:UpdatePanel ID="Up_form_sippase" runat="server">
                    <ContentTemplate>
                        <div class="modal-body p-0">
                            <asp:HiddenField ID="Hf_sip_per_id" runat="server" />
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
                                        <%--<!-- ca_num_item -->
                                        <strong class="h5">ÍTEM:</strong>
                                        <asp:Literal ID="Lt_ca_num_item" runat="server" />--%>
                                    </div>
                                    <%--<hr class="my-3" />
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
                                    <hr class="my-3" />
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
                                    </div>--%>
                                    <hr class="my-3" />
                                    <div class="row">
                                        <!-- sip_descripcion_cert -->
                                        <div class="form-group col-lg-12">
                                            <label class="form-control-label" for="Txt_sip_descripcion_cert">Descripcion Certificado</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-edit"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_sip_descripcion_cert" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_sip_descripcion_cert" ValidationGroup="add" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- sip_fecha_cert -->
                                        <div class="form-group col-lg-6">
                                            <label class="form-control-label" for="Txt_sip_fecha_cert">Fecha Certificado</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-calendar-alt"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_sip_fecha_cert" CssClass="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_sip_fecha_cert" ValidationGroup="add" Display="Dynamic" runat="server" />
                                        </div>
                                        <!-- sip_fecha_pres -->
                                        <div class="form-group col-md-6">
                                            <label class="form-control-label" for="Txt_sip_fecha_pres">Fecha Presentado</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text">
                                                        <i class="fas fa-calendar-alt"></i>
                                                    </span>
                                                </div>
                                                <asp:TextBox ID="Txt_sip_fecha_pres" CssClass="form-control datepickerDefault" runat="server" />
                                            </div>
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_sip_fecha_pres" ValidationGroup="add" Display="Dynamic" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group text-center">
                                    <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-check mr-2'></i> Guardar" ValidationGroup="add" OnClick="BtnGuardar_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelar_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Parentesco Record Modal Ends here -->

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
                                                <asp:TextBox ID="Txt_gl_fecha_doc" class="form-control datepickerDefault" runat="server" />
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

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_busqueda" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_busqueda_lista" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="Up_form_sippase" runat="server">
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
