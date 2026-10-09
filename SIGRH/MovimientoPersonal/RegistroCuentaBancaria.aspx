<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroCuentaBancaria.aspx.cs" Inherits="MovimientoPersonal_RegistroCuentaBancaria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro Cuenta Bancaria</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row">
            <div class="col-lg-6">
                <div class="card">
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Cuenta asociada al funcionario</h3>
                        </div>
                    </div>
                    <div class="table-responsive ">
                        <asp:UpdatePanel ID="up_gv_cuentas" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_cuentas" CssClass="table table-bordered table-hover" AutoGenerateColumns="false" OnPreRender="gv_cuentas_PreRender" OnRowCommand="gv_cuentas_RowCommand" DataKeyNames="cb_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="cb_tipo_abono" HeaderText="Tipo abono" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center grid-bold" />
                                        <asp:BoundField DataField="cb_cod_banco" HeaderText="Banco autorizado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cb_num_cuenta" HeaderText="Número cuenta" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cb_fecha_formulario" HeaderText="Fecha formulario" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="cb_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />

                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="40px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetAnular" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-outline-github btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-times fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Anular Cuenta' Visible='<%# Eval("cb_estado").ToString().Trim() == "V" ? true : false %>' runat="server" />
                                                <asp:LinkButton CommandName="GetBaja" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Baja Cuenta' Visible='<%# Eval("cb_estado").ToString().Trim() == "V" ? true : false %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>

                        </asp:UpdatePanel>
                    </div>
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <div id="no_existe_cuentas" class="card-body" runat="server">
                                <div class="row">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">No existen cuentas asociadas al funcionario. </p>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
                <div class="card">
                    <div class="card-header">
                        <div class="row align-items-center">
                            <div class="col-8">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Registro Cuenta Bancaria</h3>
                                    <p class="text-sm mb-0">
                                        En el siguiente formulario registre los datos de la cuenta bancaria (si corresponde).
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>

                                <div class="row">

                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label">Tipo abono</label>
                                            <asp:DropDownList ID="ddl_tipo_abono" CssClass="form-control select2 " AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" OnSelectedIndexChanged="ddl_tipo_abono_SelectedIndexChanged" AutoPostBack="true" runat="server" />
                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_abono" InitialValue="0" Display="Dynamic" ValidationGroup="addGuardar" runat="server" />
                                        </div>
                                    </div>

                                </div>
                                <div id="d_datos_cuenta" runat="server">
                                    <div class="row">
                                        <div class="col-sm-6 col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label">Banco autorizado</label>
                                                <asp:DropDownList ID="ddl_banco" CssClass="form-control select2 " AppendDataBoundItems="true" data-minimum-results-for-search="Infinity" runat="server" />
                                                <asp:RequiredFieldValidator ID="rv_ddl_banco" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_banco" InitialValue="0" Display="Dynamic" ValidationGroup="addGuardar" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label">Fecha formulario</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                    </div>
                                                    <asp:TextBox ID="txt_fecha_form" CssClass="form-control datepickerDefault" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rv_txt_fecha_form" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fecha_form" Display="Dynamic" ValidationGroup="addGuardar" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6 col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label">Número cuenta bancaria</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                    </div>
<%--                                                    <asp:TextBox ID="txt_nro_cuenta" CssClass="form-control accountBank" runat="server" />--%>
                                                    <asp:TextBox ID="txt_nro_cuenta" CssClass="form-control" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rv_txt_nro_cuenta" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_nro_cuenta" Display="Dynamic" ValidationGroup="addGuardar" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-sm-6 col-md-6">
                                            <div class="form-group">
                                                <label class="form-control-label">Confirmación Número cuenta bancaria</label>
                                                <div class="input-group input-group-merge">
                                                    <div class="input-group-prepend">
                                                        <span class="input-group-text"><i class="ni ni-check-bold"></i></span>
                                                    </div>
<%--                                                    <asp:TextBox ID="txt_confirm_nro_cuenta" CssClass="form-control accountBank" runat="server" />--%>
                                                    <asp:TextBox ID="txt_confirm_nro_cuenta" CssClass="form-control" runat="server" />
                                                </div>
                                                <asp:RequiredFieldValidator ID="rv_txt_confirm_nro_cuenta" CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_confirm_nro_cuenta" Display="Dynamic" ValidationGroup="addGuardar" runat="server" />
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                <div class="row">
                                    <div class="col-sm-6 col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label">&nbsp</label>
                                            <asp:LinkButton ID="btn_guardar_cuenta" ValidationGroup="addGuardar" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save'></i> Guardar" OnClick="btn_guardar_cuenta_Click" runat="server" />
                                        </div>
                                    </div>
                                </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>

                <div class="modal fade" id="anularCuenta" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                    <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                        <div class="modal-content bg-gradient-dark6">
                            <div class="modal-header">
                            </div>

                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:HiddenField ID="hf_cb_id" runat="server" />
                                    <div class="modal-body">
                                        <div class="py-3 text-center">
                                            <i class="ni ni-fat-remove ni-3x"></i>
                                            <h4 class="heading text-dark mt-4">¿Está seguro de anular la cuenta bancaria?</h4>
                                        </div>
                                    </div>
                                    <div class="form-group text-center">
                                        <asp:LinkButton ID="btn_anular_cuenta" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_anular_cuenta_Click" OnClientClick="MostrarMascara(true);" runat="server" />
                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="bajaCuenta" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                    <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                        <div class="modal-content bg-gradient-dark6">
                            <div class="modal-header">
                            </div>

                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <asp:HiddenField ID="HiddenField1" runat="server" />
                                    <div class="modal-body">
                                        <div class="py-3 text-center">
                                            <i class="ni ni-fat-remove ni-3x"></i>
                                            <h4 class="heading text-dark mt-4">¿Está seguro de cancelar la cuenta bancaria?</h4>
                                        </div>
                                    </div>
                                    <div class="form-group text-center">
                                        <asp:LinkButton ID="btn_baja_cuenta" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btn_baja_cuenta_Click" OnClientClick="MostrarMascara(true);" runat="server" />
                                        <button type="button" class="btn btn-outline-github" data-dismiss="modal"><i class="fas fa-times mr-2"></i>Cancelar</button>
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
                <div class="modal fade" id="modalGlosa" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true" data-backdrop="static">
                    <div class="modal-dialog modal- modal-dialog-centered modal-lg" role="document">
                        <div class="modal-content">

                            <div class="modal-body p-0">
                                <div class="card bg-secondary border-0 mb-0">
                                    <div class="card-header">
                                        <div class="text-muted text-center mt-2 mb-3"><small>GLOSA</small></div>
                                    </div>
                                    <asp:UpdatePanel runat="server">
                                        <ContentTemplate>
                                            <div class="card-body px-lg-5 py-lg-5">
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="form-control-label">Tipo Documento</label>
                                                            <asp:DropDownList ID="ddl_tipo_documento" AppendDataBoundItems="true" CssClass="form-control select2" runat="server"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_tipo_documento" ValidationGroup="addGlosa" InitialValue="0" runat="server" />

                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <label class="form-control-label">Fecha Documento</label>
                                                            <div class="input-group input-group-merge">

                                                                <div class="input-group-prepend">
                                                                    <span class="input-group-text"><i class="ni ni-calendar-grid-58"></i></span>
                                                                </div>
                                                                <asp:TextBox ID="txt_fechaMov" class="form-control datepickerDefault" runat="server" />
                                                            </div>
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_fechaMov" ValidationGroup="addGlosa" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label class="form-control-label">Descripción </label>

                                                            <asp:TextBox ID="txt_descripcion_add" CssClass="form-control" placeholder="Descripción" TextMode="multiline" Rows="4" runat="server" />
                                                            <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descripcion_add" Display="Dynamic" ValidationGroup="addGlosa" runat="server" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <div class="form-group text-center">
                                        <asp:UpdatePanel ID="panelGuardar" runat="server">
                                            <ContentTemplate>
                                                <asp:LinkButton ID="btn_guardar" Text="<i class='fas fa-check mr-2'></i>Guardar" ValidationGroup="addGlosa" CssClass="btn btn-success" OnClick="btn_guardar_Click" OnClientClick="if (Page_ClientValidate('addGlosa')) { MostrarMascara(true); }" runat="server" />
                                                <asp:LinkButton ID="btn_cancelar" CssClass="btn btn-outline-github" Text="<i class='fas fa-times mr-2'></i>Cancelar" OnClick="btn_cancelar_Click" runat="server" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-6">
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
                                        <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                    </h5>

                                    <div class="h5 font-weight-400  text-center">
                                        <strong class="h5">CI: </strong>
                                        <asp:Literal ID="ltl_ci" runat="server" />
                                        <strong class="h5">COD. FUN:</strong>
                                        <asp:Literal ID="ltl_cod_fun" runat="server" />
                                    </div>


                                    <hr class="my-3">
                                    <h6 class="heading-small text-muted">Estructura Programática </h6>


                                    <div class="row">
                                        <div class="col-lg-9">
                                            <div class="content-text-label">Ubicación</div>
                                            <div class="h5 font-weight-400 content-text content-text">
                                                <asp:Literal ID="ltl_ubicacion" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Categoría Programática</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_programatica" runat="server" />
                                            </div>
                                        </div>
                                    </div>

                                    <hr class="my-2">
                                    <h6 class="heading-small text-muted">Escalafón </h6>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Cargo</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_cargo" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Ítem</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_item" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Haber Básico (Bs)</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_haber_basico" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Código Escalafón</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_cod_esc" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Clase</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_clase" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                            <div class="content-text-label">Nivel Salarial</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_nivel_salarial" runat="server" />
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
</asp:Content>

