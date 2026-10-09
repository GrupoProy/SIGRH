<%@ Page Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Formaciones.aspx.cs" Inherits="tbl_mdp_formacion" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <!-- Created by JQC -->
    <div class="header bg-org2 pb-6" style="min-height: 170px; background-image: url(../Content/img/fondo_uap1.png); background-size: cover; background-position: center top;">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h4 class="h2 text-bluedark d-inline-block mb-0"><i class="fas fa-table mr-3"></i>Formaci&oacute;n</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6" >
        <div class="card">
            <div class="card-header border-0">
                <div class="row">
                    <!-- Modal Nuevo-->
                    <div class="col-md-12 text-right">
                        <div class="form-group text-right">
                            <span data-toggle="modal" data-target="#RegistrarFormacion">
                                <a href="#" class="btn btn-sm btn-twitter btn-round btn-icon " data-toggle="tooltip" data-original-title="Nuevo">
                                    <span class="btn-inner--icon"><i class="fas fa-plus-square"></i></span>
                                    <span class="btn-inner--text">Nuevo</span>
                                </a>
                            </span>

                            <div class="modal fade" id="RegistrarFormacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
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
                                                                <div class="col-md-12 text-left">
                                                                    <div class="form-group">
                                                                        <label class="form-control-label">Descripci&oacute;n</label>
                                                                        <div class="input-group input-group-merge">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                            </div>
                                                                            <asp:TextBox class="form-control" ID="txt_fo_descripcion_n" placeholder="Insertar descripci&oacute;n" runat="server" />
                                                                        </div>
                                                                        <asp:RequiredFieldValidator ID="val_txt_fo_descripcion_n" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fo_descripcion_n" Display="Dynamic" ValidationGroup="add" runat="server" />
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <%--<label class="form-control-label">Tipo</label>--%>
                                                                        <div class="input-group input-group-merge">
                                                                          <div class="form-group">
                                                                        <label class="form-control-label" for="exampleFormControlSelect1">Tipo de Formacion</label>
                                                                        <asp:DropDownList ID="ddl_formacion" AutoPostBack="True"  AppendDataBoundItems="true" runat="server"><%--CssClass="form-control select2"  runat="server">--%>
                                                                             <asp:ListItem  Value="FO" >Formacion Obligatoria</asp:ListItem>
                                                                             <asp:ListItem  Value="FC">Formacion Complementaria</asp:ListItem>
                                                                        </asp:DropDownList>

                                                                         </div>
                                                                        <%--  <div class="input-group-prepend">
                                                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                            </div>
                                                                            <asp:TextBox class="form-control" ID="txt_fo_tipo_n" placeholder="Insertar tipo" runat="server" />--%>
                                                                        </div>
<%--                                                                        <asp:RequiredFieldValidator ID="val_txt_fo_tipo_n" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fo_tipo_n" Display="Dynamic" ValidationGroup="add" runat="server" />--%>
<%--                                                                        <asp:RequiredFieldValidator ID="val_ddl_formacion" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_formacion" Display="Dynamic" ValidationGroup="add" runat="server" />--%>

                                                                       </div>
                                                                </div>
                                                            </div>
                                                            <br />
                                                            <div class="form-group text-center">
                                                                <asp:LinkButton ID="btnRegistrarFormacion" Text="<i class='fas fa-check mr-2'></i>Guardar" CssClass="btn btn-success" OnClick="btnRegistrarFormacion_Click" runat="server" ValidationGroup="add" />
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
                                <asp:GridView ID="gv_formacion" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_formacion_PreRender" OnRowCommand="gv_formacion_RowCommand" DataKeyNames="fo_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="fo_descripcion" HeaderText="Descripci&oacute;n" />
                                        <asp:BoundField DataField="fo_tipo" HeaderText="Tipo formacion" />
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="100px">
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

                    <!-- Modal Editar Formación -->
                    <div class="modal fade" id="EditarFormacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
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
                                                        <div class="col-md-12 text-left">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Descripci&oacute;n</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox class="form-control" ID="txt_fo_descripcion" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator ID="val_txt_fo_descripcion" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fo_descripcion" Display="Dynamic" ValidationGroup="edit" runat="server" />
                                                            </div>
                                                            <div class="form-group">
                                                                <%--<label class="form-control-label" for="example3cols1Input">Tipo</label>--%>
                                                                <div class="input-group input-group-merge">
                                                                       <div class="form-group">
                                                                        <label class="form-control-label" for="exampleFormControlSelect1">Tipo de Formacion</label>
                                                                        <asp:DropDownList ID="dll_formacion_e"  AutoPostBack="True" AppendDataBoundItems="true"  runat="server"> <%--CssClass="form-control select2"  runat="server">--%>
                                                                             
                                                                             <asp:ListItem Value="FO" >Formacion Obligatoria</asp:ListItem>
                                                                             <asp:ListItem  Value="FC">Formacion Complementaria</asp:ListItem>
                                                                            
                                                                        </asp:DropDownList>

                                                                         </div>
<%--                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                    </div>
                                                                    <asp:TextBox class="form-control" ID="txt_fo_tipo" runat="server" />--%>
                                                                </div>
<%--                                                                <asp:RequiredFieldValidator ID="val_txt_fo_tipo" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fo_tipo" Display="Dynamic" ValidationGroup="edit" runat="server" />--%>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="form-group text-center">
                                                        <asp:LinkButton ID="btnEditarFormacion" Text="<i class='fas fa-check mr-2'></i>Guardar" CssClass="btn btn-success" OnClick="btnEditarFormacion_Click" runat="server" ValidationGroup="edit" />
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
                    <!-- End Modal Editar Formación -->

                    <!-- Modal Eliminar Formación -->
                    <div class="modal fade" id="EliminarFormacion" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
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
                                                <asp:HiddenField ID="p_fo_id" runat="server" />
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btnEliminarFormacion" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnEliminarFormacion_Click" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                    <!-- End Modal Eliminar Formación -->
                </div>
            </div>
        </div>
    </div>
</asp:Content>




