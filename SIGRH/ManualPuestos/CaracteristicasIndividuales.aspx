<%@ Page Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="CaracteristicasIndividuales.aspx.cs" Inherits="tbl_mdp_caracter_individual" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Created by JQC -->
    <div class="header bg-org2 pb-6">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h4 class="h2 text-white d-inline-block mb-0"><i class="fas fa-table mr-3"></i>Caracter&iacute;sticas Individuales</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header border-0">
                <div class="row">
                    <!-- Modal Nuevo-->
                    <div class="col-md-12 text-right">
                        <div class="form-group text-right">
                            <span data-toggle="modal" data-target="#RegistrarCaracteristicas">
                                <a href="#" class="btn btn-sm btn-twitter btn-round btn-icon" data-toggle="tooltip" data-original-title="Nuevo">
                                    <span class="btn-inner--icon"><i class="fas fa-plus-square"></i></span>
                                    <span class="btn-inner--text">Nuevo</span>
                                </a>
                            </span>

                            <div class="modal fade" id="RegistrarCaracteristicas" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                                <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                    <div class="modal-content">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="modal-body p-0">
                                                    <div class="card bg-secondary border-0 mb-0">
                                                        <div class="card-header">
                                                            <div class="text-muted text-center mt-2 mb-3"><small>NUEVO REGISTRO</small></div>
                                                        </div>
                                                        <div class="card-body px-lg-5 py-lg-5">
                                                            <div class="row">
                                                                <div class="col-md-6 text-left">
                                                                    <div class="form-group">
                                                                        <label class="form-control-label" for="example3cols1Input">N&uacute;mero de Orden</label>
                                                                        <div class="input-group input-group-merge">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                            </div>
                                                                            <asp:TextBox class="form-control" ID="txt_ci_orden_n" placeholder="Insertar N&uacute;mero de Orden" TextMode="Number" runat="server" />
                                                                        </div>
                                                                        <asp:RequiredFieldValidator ID="val_txt_ci_orden_n" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ci_orden_n" Display="Dynamic" ValidationGroup="add" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-6 text-left">
                                                                    <div class="form-group">
                                                                        <label class="form-control-label" for="example3cols1Input">Puntaje</label>
                                                                        <div class="input-group input-group-merge">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                            </div>
                                                                            <asp:TextBox class="form-control" ID="txt_ci_puntaje_n" placeholder="Insertar Puntaje" TextMode="Number" runat="server" />
                                                                        </div>
                                                                        <asp:RequiredFieldValidator ID="val_txt_ci_puntaje_n" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ci_puntaje_n" Display="Dynamic" ValidationGroup="add" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-md-12 text-left">
                                                                    <div class="form-group">
                                                                        <label class="form-control-label" for="example3cols1Input">Factor</label>
                                                                        <div class="input-group input-group-merge">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                            </div>
                                                                            <asp:TextBox class="form-control" ID="txt_ci_factor_n" placeholder="Insertar Factor" runat="server" />
                                                                        </div>
                                                                        <asp:RequiredFieldValidator ID="val_txt_ci_factor_n" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ci_factor_n" Display="Dynamic" ValidationGroup="add" runat="server" />
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="form-control-label" for="example3cols1Input">Descripci&oacute;n</label>
                                                                        <div class="input-group input-group-merge">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                            </div>
                                                                            <asp:TextBox class="form-control" ID="txt_ci_descripcion_n" placeholder="Insertar Descripci&oacute;n" TextMode="MultiLine" Rows="3" runat="server" />
                                                                        </div>
                                                                        <asp:RequiredFieldValidator ID="val_txt_ci_descripcion_n" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ci_descripcion_n" Display="Dynamic" ValidationGroup="add" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="form-group text-center">
                                                                <asp:LinkButton ID="btnRegistrarCaracteriticas" Text="<i class='fas fa-check mr-2'></i>Guardar" CssClass="btn btn-success" OnClick="btnRegistrarCaracteriticas_Click" runat="server" ValidationGroup="add" />
                                                                <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- End Modal Nuevo-->

                    <!-- Light table -->
                    <div class="table-responsive">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_caracterIn" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_caracterIn_PreRender" OnRowCommand="gv_caracterIn_RowCommand" DataKeyNames="ci_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="ci_orden" HeaderText="N&uacute;mero de Orden" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center"/>
                                        <asp:BoundField DataField="ci_factor" HeaderText="Factor"  HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left grid-bold"/>
                                        <asp:BoundField DataField="ci_descripcion" HeaderText="Descripci&oacute;n"  HeaderStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="ci_puntaje" HeaderText="Puntaje"  HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-right"/>
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetEdit" CssClass="table-action" data-toggle='tooltip' data-original-title='Editar' Text=" <i class='fas fa-edit'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                                                <asp:LinkButton CommandName="GetDelete" CssClass="table-action table-action-delete" data-toggle='tooltip' data-original-title='Eliminar' Text=" <i class='fas fa-trash'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                    <!-- End Light table -->

                    <!-- Modal Editar Caracteristicas -->
                    <div class="modal fade" id="EditarCaracteristicas" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                            <div class="modal-content">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body p-0">
                                            <div class="card bg-secondary border-0 mb-0">
                                                <div class="card-header">
                                                    <div class="text-muted text-center mt-2 mb-3"><small>EDITAR REGISTRO</small></div>
                                                </div>
                                                <div class="card-body px-lg-5 py-lg-5">
                                                    <div class="row">
                                                        <div class="col-md-6 text-left">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">N&uacute;mero de Orden</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox class="form-control" ID="txt_ci_orden" TextMode="Number" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="val_txt_ci_orden" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ci_orden" Display="Dynamic" ValidationGroup="edit" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6 text-left">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Puntaje</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox class="form-control" ID="txt_ci_puntaje" TextMode="Number" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="val_txt_ci_puntaje" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ci_puntaje" Display="Dynamic" ValidationGroup="edit" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-12 text-left">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Factor</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox class="form-control" ID="txt_ci_factor" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="val_txt_ci_factor" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ci_factor" Display="Dynamic" ValidationGroup="edit" runat="server" />
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="example3cols1Input">Descripci&oacute;n</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox class="form-control" ID="txt_ci_descripcion" TextMode="MultiLine" Rows="3"  runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="val_txt_ci_descripcion" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ci_descripcion" Display="Dynamic" ValidationGroup="edit" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="form-group text-center">
                                                        <asp:LinkButton ID="btnEditarCaracterInd" Text="<i class='fas fa-check mr-2'></i>Guardar" CssClass="btn btn-success" OnClick="btnEditarCaracterInd_Click" runat="server" ValidationGroup="edit" />
                                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <!-- End Modal Editar Caracteristicas -->

                    <!-- Modal Eliminar Caracteristicas -->
                    <div class="modal fade" id="EliminarCaracteristicas" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-danger">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">×</span>
                                    </button>
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading mt-4">¿Esta seguro de eliminar?</h4>
                                                <asp:HiddenField ID="p_ci_id" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btnEliminarCaracterInd" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnEliminarCaracterInd_Click" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <!-- End Modal Eliminar Caracteristicas -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>





