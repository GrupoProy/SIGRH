<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ListaTenor.aspx.cs" Inherits="MovimientoPersonal_ListaTenor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Creación  de Tenores </h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                        <asp:LinkButton ID="btn_nuevo_tenor" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Crear Tenor" OnClick="btn_nuevo_tenor_Click" runat="server" />

                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row justify-content-center">
            <div class="col-lg-8 card-wrapper ct-example">
                <!-- Styles -->
                <div class="card">
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Lista Tenor</h3>
                            <p class="text-sm mb-0">
                                En la siguiente lista puede modificar o crear nuevos tenores.
                            </p>
                        </div>
                    </div>
                    <div class="table-responsive py-4">
                        <asp:UpdatePanel ID="up_gv_items" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_tenor" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_tenor_PreRender" OnRowCommand="gv_tenor_RowCommand" DataKeyNames="te_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="te_id" HeaderText="Código" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="te_descripcion" HeaderText="Descripción Tenor" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cat_descripcion" HeaderText="Tipo Movimiento" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="te_fecha_modificacion" HeaderText="Fecha Creación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetEdit" CssClass="table-action table-action-warning" data-toggle='tooltip' data-original-title='Editar' Text=" <i class='fas fa-edit'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                                                <asp:LinkButton CommandName="GetDelete" CssClass="table-action table-action-delete" data-toggle='tooltip' data-original-title='Eliminar' Text=" <i class='fas fa-trash'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                    <%--              <div class="modal fade" id="EditarItem" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
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
                                                    <div id="detalleitem">
                                                        <div class="row">
                                                            <div class="progress-info" style="padding-left: 15px; padding-right: 15px;">
                                                                <div class="tag-label">
                                                                    <span>Código Escalafón:<span class="tag-label-content"><asp:Literal ID="ltl_codigo" Text="" runat="server" /></span></span>
                                                                    <span>Clase:<span class="tag-label-content"><asp:Literal ID="ltl_clase" Text="" runat="server" /></span></span>
                                                                    <span>Nivel Salarial:<span class="tag-label-content"><asp:Literal ID="ltl_nivel_salarial" Text="" runat="server" /></span></span>
                                                                    <span>Haber Básico (Bs):<span class="tag-label-content"><asp:Literal ID="ltl_haber_basico" Text="" runat="server" /></span></span>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Tipo Ítem</label>
                                                        <asp:DropDownList ID="ddl_tipo_item" AppendDataBoundItems="true" CssClass="form-control" data-toggle="select" runat="server"></asp:DropDownList>
                                                        <div style="display: none">
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_item" ValidationGroup="addItem" runat="server" />
                                                        </div>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Cargo</label>
                                                        <asp:DropDownList ID="ddl_cargo" AppendDataBoundItems="true" CssClass="form-control" OnSelectedIndexChanged="ddl_cargo_SelectedIndexChanged" AutoPostBack="true" data-toggle="select" runat="server"></asp:DropDownList>
                                                        <div style="display: none">
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_cargo" ValidationGroup="addItem" InitialValue="0" runat="server" />

                                                        </div>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Tipo Jornada</label>
                                                        <asp:DropDownList ID="ddl_tipo_jornada" AppendDataBoundItems="true" CssClass="form-control" data-toggle="select" runat="server">
                                                            <asp:ListItem Text="Tiempo Completo" Value="TC" />
                                                            <asp:ListItem Text="Medio Tiempo" Value="MT" />

                                                        </asp:DropDownList>

                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_jornada" ValidationGroup="addItem" runat="server" />

                                                    <div class="row">
                                                        <div class="col-md-8">
                                                            <div class="form-group text-right">
                                                            </div>
                                                        </div>

                                                        <div class="col-md-4">
                                                            <div class="form-group text-right">
                                                                <asp:UpdatePanel runat="server">
                                                                    <ContentTemplate>
                                                                        <div>
                                                                            <asp:LinkButton ID="btnModificarItem" OnClick="btnModificarItem_Click" CssClass="btn btn-vimeo btn-block" ValidationGroup="addItem" Text="<i class='fas fa-save'></i> Modificar" runat="server" />

                                                                        </div>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:HiddenField ID="p_ca_id" runat="server" />
                                                    <asp:HiddenField ID="p_ca_es_id" runat="server" />
                                                    <asp:HiddenField ID="p_ca_eo_id" runat="server" />
                                                    <asp:HiddenField ID="p_ca_num_item" runat="server" />
                                                    <asp:HiddenField ID="p_ca_id_anterior" runat="server" />
                                                    <asp:HiddenField ID="p_ca_haber_basico" runat="server" />

                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>--%>


                    <!-- Modal Eliminar Resultado -->
                    <div class="modal fade" id="eliminarTenor" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-danger">
                                <div class="modal-header">
                                </div>

                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:HiddenField ID="hf_te_cod_tenor" runat="server" />
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading mt-4">¿Esta seguro de eliminar el tenor?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btnEliminarTenor" OnClick="btnEliminarTenor_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
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
</asp:Content>

