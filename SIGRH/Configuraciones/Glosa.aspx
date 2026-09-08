<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Glosa.aspx.cs" Inherits="Mantenimiento_Glosa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Glosa</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <asp:UpdatePanel ID="Up_glosa_lista" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_glosa_lista" class="card" Visible="false" runat="server">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Lista de Tipos de Ítem</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="Gv_glosa_lista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="gl_id" OnPreRender="Gv_glosa_lista_PreRender" OnRowCommand="Gv_glosa_lista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="gl_id" HeaderText="Código" />
                                <asp:BoundField DataField="gl_valor_pk" HeaderText="Valor Id" />
                                <asp:BoundField DataField="gl_nombre_pk" HeaderText="Nombre Campo Id" />
                                <asp:BoundField DataField="gl_tabla" HeaderText="Nombre Tabla" />
                                <asp:BoundField DataField="cat_descripcion_tm" HeaderText="Tipo Movimiento" />
                                <asp:BoundField DataField="cat_descripcion_td" HeaderText="Tipo Documento" />
                                <asp:BoundField DataField="gl_glosa" HeaderText="Glosa" />
                                <asp:BoundField DataField="gl_numero_doc" HeaderText="Número Documento" />
                                <asp:BoundField DataField="gl_fecha_doc" HeaderText="Fecha Documento" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="BtnEditar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-pen'></i></span>" data-toggle="tooltip" data-original-title="Editar" runat="server" />
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
                                    <asp:HiddenField ID="Hf_gl_id" runat="server" />
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <!-- gl_valor_pk -->
                                                    <div class="content-text-label">Valor Id</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="LT_gl_valor_pk" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <!-- gl_nombre_pk -->
                                                    <div class="content-text-label">Campo Id</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="Lt_gl_nombre_pk" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <!-- gl_tabla -->
                                                    <div class="content-text-label">Tabla</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="Lt_gl_tabla" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="my-3" />
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <!-- gl_tipo_mov -->
                                                    <div class="content-text-label">Tipo Movimiento</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="Lt_gl_tipo_mov" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <!-- gl_numero_doc -->
                                                    <div class="content-text-label">Número Documento</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="Lt_gl_numero_doc" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-4">
                                                    <!-- gl_estado -->
                                                    <div class="content-text-label">Estado</div>
                                                    <div class="h5 font-weight-400 content-text">
                                                        <asp:Literal ID="Lt_gl_estado" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <hr class="my-3" />
                                        </div>
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
                                    <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save mr-2'></i> Guardar" ValidationGroup="glosa" OnClick="BtnGuardar_Click" runat="server" />
                                    <asp:LinkButton ID="BtnCancelar" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i> Cancelar" OnClick="BtnCancelar_Click" runat="server" />
                                </div>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
    <!-- Glosa Record Modal Ends here -->

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_glosa_lista" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
