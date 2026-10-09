<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="AdminControlPersonal.aspx.cs" Inherits="ControlPersonal_AdminControlPersonal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración Control de Personal</h6>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div class="col-lg-6 col-5 text-right">
                                <asp:LinkButton ID="btn_nuevo_edificio" CssClass="btn btn-circle sticky-top-btn icon-prs icon-shape-prs bg-gradient-inst text-white rounded-circle shadow" Text="<i class='fas fa-plus'></i>" data-toggle="tooltip" data-placement='top' OnClick="btn_nuevo_edificio_Click" data-original-title="Asignar Edificio" runat="server" />
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-7">
                <div class="card-wrapper">
                    <div class="card">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">Datos de la Transacción</h3>
                                <p class="text-sm mb-0">
                                    Detalle de las horas extras que asignará al funcionario seleccionado.
                                </p>
                            </div>
                        </div>
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_asignacionEdificio" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_asignacionEdificio_PreRender" OnRowCommand="gv_asignacionEdificio_RowCommand" DataKeyNames="cp_id, cp_edificio" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="edificio" HeaderText="Edificio" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="cp_fecha_inicio" HeaderText="Fecha Alta" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="cp_fecha_final" HeaderText="Fecha Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="GetEdit" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar Registro' Visible='<%# Eval("cp_fecha_final").ToString() != "" ? false : true %>'  runat="server" />
                                                    <asp:LinkButton CommandName="GetBaja" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Baja Registro' Visible='<%# Eval("cp_fecha_final").ToString() != "" ? false : true %>' runat="server" />
                                                    <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-outline-github btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-times fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Anular Registro' Visible='<%# Eval("cp_fecha_final").ToString() != "" ? false : true %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:HiddenField ID="aux_accion" runat="server" />
                                    <asp:HiddenField ID="aux_cp_id" runat="server" />
                                    <asp:HiddenField ID="aux_per_id" runat="server" />
                                    <asp:HiddenField ID="aux_cp_edificio" runat="server" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="col-md-12">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div id="block_notificacion" runat="server">
                                            <span class="badge badge-pill badge-info">No existen registros.</span>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>

                    <%-- Modal Registro Nuevo y Edición de Asignación Edificios  --%>
                    <div class="modal fade" id="modalNuevoEdificio" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
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
                                                            <img src="../Content/img/theme/home.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;">
                                                        </a>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">Fecha Alta</label>
                                                                <div class="input-group input-group-merge">
                                                                    <div class="input-group-prepend">
                                                                        <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                    </div>
                                                                    <asp:TextBox ID="txt_fecha_alta" class="form-control datepickerDefault" runat="server" />
                                                                </div>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_alta" Display="Dynamic" ValidationGroup="addEdificio" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-8">
                                                            <div class="form-group">
                                                                <label class="form-control-label" for="exampleFormControlSelect1">Edificio</label>
                                                                <asp:DropDownList ID="ddl_tipo_edificio" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                                <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_edificio" ValidationGroup="addEdificio" InitialValue="0" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-group text-center">
                                                    <asp:LinkButton ID="btnGuardarEdificio" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="addEdificio" CssClass="btn btn-success" OnClick="btnGuardarEdificio_Click" runat="server" />
                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <%-- Asignar Fecha Fomulario Baja --%>
                        <div class="modal fade" id="modalBajaEdificio" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                            <div class="modal-dialog modal- modal-dialog-centered modal-" role="document">
                                <div class="modal-content">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="modal-header">
                                        </div>
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
                                                <div class="modal-body">
                                                    <div class="pb-3 text-center">
                                                        <a href="javascript:;">
                                                            <img src="../Content/img/theme/down.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;"><br />
                                                            <h4 class="heading text-dark mt-4">¿Está seguro de realizar la baja?</h4>
                                                        </a>
                                                    </div>
                                                </div>
                                                <div class="card-body px-lg-5 ">
                                                    <h6 class="heading-small text-muted">Datos del Registro Seleccionado</h6>
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class="content-text-label">Fecha Alta</div>
                                                            <div class="h5 font-weight-400 content-text content-text">
                                                                <asp:Literal ID="ltl_fecha_alta" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="content-text-label">Edificio</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_edificio" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="form-group text-center">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Fecha Baja</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_fecha_baja" class="form-control datepickerDefault" runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_baja" Display="Dynamic" ValidationGroup="BajaEdificio" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group text-center">
                                                    <asp:LinkButton ID="btn_asignarFechaBaja" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_asignarFechaBaja_Click" ValidationGroup="BajaEdificio" runat="server" />
                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>

                    <%-- Eliminar Asignación Edificios --%>
                    <div class="modal fade" id="modalEliminarEdificio" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <div class="modal-header">
                                </div>
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar el edificio asignado?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btn_eliminar_edificio" OnClick="btn_eliminar_edificio_Click" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" runat="server" />
                                            <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-5">
                <div class="card-wrapper">
                    <div class="card card-profile">
                        <div class="row justify-content-center">
                            <div class="col-lg-3 order-lg-2">
                                <div class="card-profile-image">
                                    <a href="#">
                                        <asp:Image ID="imgFun" class="rounded-circle" runat="server" />
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="card-header text-center border-0 pt-8 pt-md-4 pb-0 pb-md-4">
                            <asp:LinkButton ID="btn_estado" class="btn btn-sm btn-info float-right" runat="server" />
                        </div>
                        <div class="card-body pt-0">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div>
                                        <h5 class="h3 text-uppercase text-center">
                                            <asp:Literal ID="ltl_apellido_fun" runat="server" />
                                            <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                        </h5>
                                        <div class="h5 font-weight-400  text-center">
                                            <strong class="h5">CI: </strong>
                                            <asp:Literal ID="ltl_ci" runat="server" />
                                            <strong class="h5">COD. FUN:</strong>
                                            <asp:Literal ID="ltl_cod_fun" runat="server" />
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Información adicional </h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Ítem</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_item" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Cargo</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_cargo" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Fecha asignación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_fecha_inicio" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Fecha baja</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_fecha_fin" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <hr class="my-2">
                                        <h6 class="heading-small text-muted">Escalafón </h6>
                                        <div class="row">
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Puesto</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_puesto" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-6">
                                                <div class="content-text-label">Haber Básico (Bs)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_haber_basico" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <div class="content-text-label">Ubicación</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="ltl_ubicacion" runat="server" />
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
    </div>
</asp:Content>

