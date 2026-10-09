<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroAdminHorasExtras.aspx.cs" Inherits="Configuraciones_RegistroAdminHorasExtras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Horas Extras</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Listado Asignación Horas Extras</h3>
                                <p class="text-sm mb-0">
                                    Detalle de las Horas Extras asignados según Escalafón.
                                </p>
                            </div>
                        </div>
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel ID="panelGvHoras" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_horas_extras" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_horas_extras_PreRender" OnRowCommand="gv_horas_extras_RowCommand" DataKeyNames="lhx_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="es_descripcion" HeaderText="Escalafón" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="cat_descripcion" HeaderText="Nro. Horas Extras" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="lhx_fecha_asignacion" HeaderText="Fecha Registro" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:HiddenField ID="aux_lhx_id" runat="server" />
                                    <div class="col-lg-6 col-5 text-right">
                                        <asp:LinkButton ID="btn_nuevo_horasExtras" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-original-title="Asignar Horas Extras" OnClick="btn_nuevo_horasExtras_Click" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <%-- Modal Registro Nuevo Horas Extras --%>
                    <div class="modal fade" id="modalNuevoHorasExtras" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                        <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                            <div class="modal-content">
                                <div class="modal-body p-0">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="card-header">
                                            <div class="text-muted text-center mt-2 mb-3">
                                                <h4 class="header-modal">REGISTRO HORAS EXTRAS</h4>
                                            </div>
                                        </div>
                                        <asp:UpdatePanel ID="panelRegistroHoras" runat="server">
                                            <ContentTemplate>
                                                <div class="card-body px-lg-5 py-lg-5">
                                                    <div class="pb-5 text-center">
                                                        <a href="javascript:;">
                                                            <img src="../Content/img/theme/clock.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                        </a>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-sm-6 col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Escalafón</label>
                                                                <asp:DropDownList ID="ddl_tipo_escalafon" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_escalafon" Display="Dynamic" ValidationGroup="AddHoras" InitialValue="0" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-sm-6 col-md-6">
                                                            <div class="form-group">
                                                                <label class="form-control-label">Horas Extras</label>
                                                                <asp:DropDownList ID="ddl_tipo_horas_extras" CssClass="form-control select2" AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_horas_extras" Display="Dynamic" ValidationGroup="AddHoras" InitialValue="0" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <div class="form-group text-center">
                                            <asp:UpdatePanel ID="panelBtnRegistroHoras" runat="server">
                                                <ContentTemplate>
                                                    <asp:LinkButton ID="btn_guardar_horasExtras" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="AddHoras" CssClass="btn btn-success" OnClick="btn_guardar_horasExtras_Click" runat="server" />
                                                    <asp:LinkButton ID="btn_cancelar_horasExtras" class="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_horasExtras_Click" runat="server" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- Eliminar Horas Extras --%>
                    <div class="modal fade" id="eliminarHorasExtras" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">
                                </div>
                                <asp:UpdatePanel ID="panelEliminarHoras" runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar el registro?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btn_eliminar_horasExtras" OnClick="btn_eliminar_horasExtras_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
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
    <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelGvHoras" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up2" AssociatedUpdatePanelID="panelRegistroHoras" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up3" AssociatedUpdatePanelID="panelBtnRegistroHoras" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress ID="up4" AssociatedUpdatePanelID="panelEliminarHoras" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

