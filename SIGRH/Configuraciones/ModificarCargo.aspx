<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ModificarCargo.aspx.cs" Inherits="Configuraciones_ModificarCargo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Modificación Cargo y/o Puesto ítem</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row justify-content-center">
            <div class="col-lg-7 card-wrapper ct-example">
                <!-- Styles -->
                <div class="card">
                    <div class="card-header">
                        <h3 class="mb-0">Búsqueda de ítem</h3>
                    </div>

                    <div class="card-body" style="padding-bottom: unset">
                        <div class="row">
                            <div class="col-sm-6 col-md-6">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="form-group">
                                            <label class="form-control-label">Item</label>
                                            <asp:DropDownList ID="ddl_item" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_item_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                            <%--  <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_item" Display="Dynamic" ValidationGroup="addFrecuencia" InitialValue="0" runat="server" />--%>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div id="desc_puesto" class="col-sm-6 col-md-6" style="display: none;">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="content-text-label pt-3">Puesto</div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_puesto" runat="server" />
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <div id="datos_historico" style="display: none;">
                        <h4 class="pt-2 pl-3">Histórico ítem</h4>
                        <div class="table-responsive pt-1 pb-1">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_items" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_items_PreRender" OnRowCommand="gv_items_RowCommand" DataKeyNames="ca_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="item_p" HeaderText="Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="es_descripcion" HeaderText="Cargo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="p_descripcion" HeaderText="Puesto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="eo_descripcion" HeaderText="Unidad organizacional" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="ca_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <div class="card-body">
                        <div id="datos_modificar" style="display: none;">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <hr class="mt-0 mb-4" />
                                    <h4 class="pt-2">Datos para Modificar</h4>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-4">
                                            <div class="form-group">
                                                <label class="form-control-label">Tipo de ítem</label>
                                                <asp:DropDownList ID="ddl_tipo_item" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-4">
                                            <div class="form-group">
                                                <label class="form-control-label">Cargo</label>
                                                <asp:DropDownList ID="ddl_cargo" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-4">
                                            <div class="form-group">
                                                <label class="form-control-label">Puesto</label>
                                                <asp:DropDownList ID="ddl_puesto" CssClass="form-control select2" AppendDataBoundItems="true" OnSelectedIndexChanged="ddl_puesto_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div id="nuevo_puesto" class="row" style="display: none;">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="col-sm-6 col-md-12">
                                            <div class="form-group">
                                                <label class="form-control-label">Descripción Puesto</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend  ">
                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_desc_puesto" class="form-control" runat="server" />
                                                </div>
                                                <%--<asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_objetivo" Display="Dynamic" ValidationGroup="addFrecuencia" runat="server" />--%>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="row">
                                <div class="col-sm-12 col-md-12">
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="form-group">
                                                <label class="form-control-label">&nbsp</label>
                                                <asp:LinkButton ID="btn_regitrar_puesto" CssClass="btn btn-block btn-success btn-round btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-save'></i></span><span class='btn-inner--text'>Guardar</span>" OnClick="btn_regitrar_puesto_Click" runat="server" />
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
    <div class="modal fade" id="modalGlosa" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
            <div class="modal-content">
                <asp:UpdatePanel runat="server">
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
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>

