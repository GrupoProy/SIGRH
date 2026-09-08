<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroBajaEGS.aspx.cs" Inherits="BienestarSocial_RegistroBajaEGS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Baja a Ente Gestor de Salud</h6>
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
                        <div class="card-header d-flex align-items-center">
                            <div class=" ct-page-title">
                                <h3 class="mb-0 text-org2">Listado de Baja(s) a Ente Gestor de Salud</h3>
                                <p class="text-sm mb-0">
                                    Detalle de las bajas procesadas mediante el sistema.
                                </p>
                            </div>
                            <div class="text-right ml-auto">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btn_bajas_masiv" CssClass="btn btn-warning btn-round btn-icon" data-toggle="tooltip" data-original-title="Generar Formulario Masivamente" Text="<span class='btn-inner--icon'><i class='fas fa-print fa-lg'></i></span>" OnClick="btn_bajas_masiv_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_bajas" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_bajas_PreRender" OnRowCommand="gv_bajas_RowCommand" DataKeyNames="as_id, as_per_id, ae_id" runat="server">
                                        <Columns>
                                            <asp:TemplateField ItemStyle-CssClass="text-center" HeaderStyle-Width="50px">
                                                <HeaderTemplate>
                                                    <span class="badge badge-lg badge-darkerw">Todos</span>
                                                    <label class="custom-toggle custom-toggle-dark">
                                                        <asp:CheckBox ID="chk_bajas_all" OnCheckedChanged="chk_bajas_all_CheckedChanged" AutoPostBack="true" runat="server" />
                                                        <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                                    </label>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <label class="custom-toggle custom-toggle-yout">
                                                        <asp:CheckBox ID="chk_bajas" runat="server" />
                                                        <span class="custom-toggle-slider rounded-circle" data-label-off="No" data-label-on="Si"></span>
                                                    </label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="as_per_id" HeaderText="Cod. Fun." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="item" HeaderText="Ítem" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                            <asp:BoundField DataField="nombre_fun" HeaderText="Nombre Funcionario" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-left" />
                                            <asp:BoundField DataField="per_num_doc" HeaderText="C.I." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="as_fecha_fin" HeaderText="Fecha Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="motivo_baja" HeaderText="Motivo" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fa_descripcion" HeaderText="Caja Aseguradora" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="fecha_limite" HeaderText="Fecha Limite Presentación" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center display-5 dt-sub-title" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="GetAssig" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-print fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Generar Formulario de Baja' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <div class="col-md-12">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div id="block_notificacion" runat="server">
                                            <span class="badge badge-pill badge-info">No existen registros.</span>
                                        </div>
                                        <asp:HiddenField ID="aux_as_id" runat="server" />
                                        <asp:HiddenField ID="aux_per_id" runat="server" />
                                        <asp:HiddenField ID="aux_motivo" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>

                        <%-- Asignar Fecha Fomulario Baja --%>
                        <div class="modal fade" id="asignarFechaFormulario" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                            <div class="modal-dialog modal- modal-dialog-centered modal-" role="document">
                                <div class="modal-content">
                                    <div class="card bg-secondary border-0 mb-0">
                                        <div class="modal-header">
                                        </div>
                                        <asp:UpdatePanel ID="panelFechaFormBaja" runat="server">
                                            <ContentTemplate>
                                                <div class="modal-body">
                                                    <div class="pb-3 text-center">
                                                        <a href="javascript:;">
                                                            <img src="../Content/img/theme/down.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;"><br />
                                                            <h4 class="heading text-dark mt-4">¿Está seguro en realizar el proceso de baja?</h4>
                                                        </a>
                                                    </div>
                                                </div>
                                                <div class="card-body px-lg-5 ">
                                                    <h6 class="heading-small text-muted">Datos Funcionario Seleccionado</h6>
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class="content-text-label">Nombre funcionario</div>
                                                            <div class="h5 font-weight-400 content-text content-text">
                                                                <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="content-text-label">Fecha Baja</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_fecha_baja" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-lg-6">
                                                            <div class="content-text-label">Motivo</div>
                                                            <div class="h5 font-weight-400 content-text content-text">
                                                                <asp:Literal ID="ltl_motivo" runat="server" />
                                                            </div>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <div class="content-text-label">Caja Aseguradora</div>
                                                            <div class="h5 font-weight-400 content-text">
                                                                <asp:Literal ID="ltl_egs" runat="server" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <div class="form-group text-center">
                                                        <label class="form-control-label" for="exampleFormControlSelect1">Fecha Baja Impresión</label>
                                                        <div class="input-group input-group-merge">
                                                            <div class="input-group-prepend">
                                                                <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                            </div>
                                                            <asp:TextBox ID="txt_fecha_impresion" class="form-control datepickerDefault" runat="server" />
                                                        </div>
                                                        <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_impresion" Display="Dynamic" ValidationGroup="BajaFormulario" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="form-group text-center">
                                                    <asp:LinkButton ID="btn_asignarFechaBaja" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_asignarFechaBaja_Click" ValidationGroup="BajaFormulario" runat="server" />
                                                    <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <%-- Asignar Fecha Fomulario Baja Masivamente --%>
                        <div class="modal fade" id="asignarFechaFormularioMasiv" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                            <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                                <div class="modal-content">
                                    <div class="modal-body p-0">
                                        <div class="card bg-secondary border-0 mb-0">
                                            <div class="modal-header"></div>
                                            <div class="pb-3 text-center">
                                                <a href="javascript:;">
                                                    <img src="../Content/img/theme/down.png" alt="Circle image" class="img-fluid rounded-circle shadow" style="width: 100px;"><br />
                                                    <h4 class="heading text-dark mt-4">¿Está seguro en realizar el proceso de baja?</h4>
                                                </a>
                                            </div>
                                            <div class="card-body px-lg- py-lg-">
                                                <div class="table-responsive py-2">
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:GridView ID="gv_nro_egs" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_nro_egs_PreRender" DataKeyNames="ae_egs_id" runat="server">
                                                                <Columns>
                                                                    <asp:BoundField DataField="fa_descripcion" HeaderText="Caja Aseguradora" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                    <asp:BoundField DataField="nro_cantidad_caja" HeaderText="Nro. Casos" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                                <br />
                                                <asp:UpdatePanel runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                                            <div class="col-md-3"></div>
                                                            <div class="col-sm-6 col-md-6">
                                                                <div class="form-group text-center">
                                                                    <label class="form-control-label" for="exampleFormControlSelect1">Fecha Baja Impresión</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend">
                                                                            <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="txt_fecha_baja_masiv" class="form-control datepickerDefault" runat="server" />
                                                                    </div>
                                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_baja_masiv" Display="Dynamic" ValidationGroup="BajaFormularioMasiv" runat="server" />
                                                                </div>
                                                            </div>
                                                            <div class="col-md-3"></div>
                                                        </div>
                                                        <div class="form-group text-center">
                                                            <asp:LinkButton ID="btn_baja_masiv" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_baja_masiv_Click" ValidationGroup="BajaFormularioMasiv" runat="server" />
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
            </div>
        </div>
    </div>
</asp:Content>

