<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroFeriados.aspx.cs" Inherits="Kardex_RegistroFeriados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro Feriados</h6>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="col-lg-6 col-5 text-right">
                                <asp:LinkButton ID="btn_nuevo_feriado" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-calendar-alt'></i>" data-toggle="tooltip" data-original-title="Añadir Nuevo Feriado" OnClick="btn_nuevo_feriado_Click" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--7">
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="card">
                            <div class="card-header">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Listado de los Feriados</h3>
                                    <p class="text-sm mb-0">
                                        Detalle de los feriados regitrados anteriormente.
                                    </p>
                                </div>
                            </div>
                            <div class="table-responsive py-4">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gv_feriados" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_feriados_PreRender" OnRowCommand="gv_feriados_RowCommand" DataKeyNames="fe_id" runat="server">
                                            <Columns>
                                                <asp:BoundField DataField="fe_fecha" HeaderText="Fecha Feriado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:BoundField DataField="fe_descripcion" HeaderText="Descripción del Feriado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                    <ItemTemplate>
                                                        <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar' runat="server" />
                                                        <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:HiddenField ID="aux_fe_id" runat="server" />
                                        <asp:HiddenField ID="aux_accion" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>

                            <%-- Modal Registro Nuevo y Edición de Feriados --%>
                            <div class="modal fade" id="modalNuevoFeriado" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                                <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                    <div class="modal-content">
                                        <div class="modal-body p-0">
                                            <div class="card bg-secondary border-0 mb-0">
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="card-header">
                                                            <div class="text-muted text-center mt-2 mb-3">
                                                                <h4 class="header-modal">
                                                                    <asp:Literal ID="ltl_titulo" runat="server" /></h4>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="card-body px-lg-5 py-lg-5">
                                                            <div class="pb-5 text-center">
                                                                <a href="javascript:;">
                                                                    <img src="../Content/img/theme/calendar.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                                </a>
                                                            </div>
                                                            <div class="row">
                                                                <div class="col-sm-6 col-md-5">
                                                                    <div class="form-group">
                                                                        <label class="form-control-label" for="example4cols2Input">Fecha Feriado</label>
                                                                        <div class="input-group input-group-merge">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                            </div>
                                                                            <asp:TextBox ID="txt_fecha_feriado" class="form-control datepickerDefault" runat="server" />
                                                                        </div>
                                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_fecha_feriado" ValidationGroup="feriadosAdd" runat="server" />
                                                                    </div>
                                                                </div>
                                                                <div class="col-sm-6 col-md-7">
                                                                    <div class="form-group">
                                                                        <label class="form-control-label">Descripción del Feriado</label>
                                                                        <div class="input-group input-group-merge">
                                                                            <div class="input-group-prepend">
                                                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                            </div>
                                                                            <asp:TextBox ID="txt_descripcion_feriado" class="form-control" runat="server" />
                                                                        </div>
                                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ControlToValidate="txt_descripcion_feriado" ValidationGroup="feriadosAdd" runat="server" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="form-group text-center">
                                                            <asp:LinkButton ID="btn_adicionar_nuevoFeriado" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="feriadosAdd" CssClass="btn btn-success" OnClick="btn_adicionar_nuevoFeriado_Click" runat="server" />
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

                        <%-- Eliminar Registro Feriados --%>
                        <div class="modal fade" id="modalEliminarFeriado" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                            <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                                <div class="modal-content bg-gradient-dark6">
                                    <div class="modal-header">
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="modal-body">
                                                <div class="py-3 text-center">
                                                    <i class="ni ni-fat-remove ni-3x"></i>
                                                    <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar el feriado?</h4>
                                                </div>
                                            </div>
                                            <div class="form-group text-center">
                                                <asp:LinkButton ID="btn_eliminar_feriado" OnClick="btn_eliminar_feriado_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
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
    </div>
</asp:Content>

