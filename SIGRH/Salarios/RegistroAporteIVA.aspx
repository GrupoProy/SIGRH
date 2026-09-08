<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroAporteIVA.aspx.cs" Inherits="Salarios_Registro_Aporte_IVA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Registro de Aportes IVA</h6>
                    </div>
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
                                    Detalle del aporte IVA del funcionario seleccionado.
                                </p>
                            </div>
                        </div>
                        <div class="card-body">
                            <asp:Panel DefaultButton="btn_guardar" runat="server">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="row" style="background-color: #D2EEE0; border-radius: .375rem; padding-left: 17px; padding-bottom: 10px; padding-top: 10px;">
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Crédito Fiscal IVA (13%)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="txt_credito_fiscal" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Crédito Fiscal IVA (Bs.)</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="txt_credito_fiscal_bs" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-lg-4">
                                                <div class="content-text-label">Tipo Transacción</div>
                                                <div class="h5 font-weight-400 content-text">
                                                    <asp:Literal ID="txt_tipo_transaccion" runat="server" />
                                                </div>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example4cols2Input">Valor en Bs.</label>
                                                    <div class="input-group input-group-merge">
                                                        <div class="input-group-prepend">
                                                            <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                        </div>
                                                        <asp:TextBox ID="txt_valor_Bs" CssClass="form-control" type="number" runat="server" />
                                                    </div>
                                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_valor_Bs" Display="Dynamic" ValidationGroup="addGuardar" runat="server" />
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label class="form-control-label" for="example3cols1Input">&nbsp</label>
                                                    <asp:UpdatePanel runat="server">
                                                        <ContentTemplate>
                                                            <asp:LinkButton ID="btn_guardar" CssClass="btn btn-success btn-block btn-icon" Text="<span class='btn-inner--icon'><i class='fas fa-save'></i></span><span class='btn-inner--text'>Guardar</span>" OnClick="btn_guardar_Click" ValidationGroup="addGuardar" OnClientClick="if (Page_ClientValidate('addGuardar')) { MostrarMascara(true); }" runat="server" />
                                                        </ContentTemplate>
                                                    </asp:UpdatePanel>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </asp:Panel>
                        </div>
                    </div>

                    <!-- Grilla Monto a Presentar -->
                    <div class="card" id="blockMontoPresentar">
                        <div class="table-responsive py-4">
                            <asp:UpdatePanel ID="panelGvMontoPresentar" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gv_monto_presentar" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_monto_presentar_PreRender" DataKeyNames="per_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="ca_basico_calculado" HeaderText="Haber básico" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:0.00}" />
                                            <asp:BoundField DataField="bono_antiguedad" HeaderText="Bono antigüedad" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:0.00}" />
                                            <asp:BoundField DataField="descuentos_ley" HeaderText="Descuentos de ley" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:0.00}" />
                                            <asp:BoundField DataField="sueldo_neto" HeaderText="Sueldo neto" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:0.00}" />
                                            <asp:BoundField DataField="salario_minimo" HeaderText="4 salarios mínimos" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" DataFormatString="{0:0.00}" />
                                            <asp:BoundField DataField="iva_presentar" HeaderText="Monto a presentar" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center display-1 dt-sub-title" DataFormatString="{0:0.00}" />
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>

                    <!-- Modal Eliminar Registro -->
                    <div class="modal fade" id="eliminarAporte" tabindex="-1" role="dialog" aria-labelledby="modal-notification" style="display: none;" aria-hidden="true">
                        <div class="modal-dialog modal-danger modal-dialog-centered modal-" role="document">
                            <div class="modal-content bg-gradient-dark6">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <div class="modal-body">
                                            <div class="py-3 text-center">
                                                <i class="ni ni-fat-remove ni-3x"></i>
                                                <h4 class="heading text-dark mt-4">¿Esta seguro de eliminar el registro?</h4>
                                            </div>
                                        </div>
                                        <div class="form-group text-center">
                                            <asp:LinkButton ID="btnEliminarResultado" Text="<i class='fas fa-check mr-2'></i>Aceptar" CssClass="btn btn-success" OnClick="btnEliminarResultado_Click" runat="server" />
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
                                    <div style="display: none">
                                        <asp:HiddenField ID="aux_per_id" runat="server" />
                                        <asp:HiddenField ID="aux_tipo_transaccion" runat="server" />
                                        <asp:HiddenField ID="aux_tr_id" runat="server" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <%-- Grilla del registro aporte IVA --%>
        <div id="block_gv_AporteIVA" class="row" style="display: none">
            <div class="col-md-12">
                <div class="card">
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Aporte IVA del Funcionario</h3>
                            <p class="text-sm mb-0">
                                Detalle de los aportes IVA del funcionario seleccionado.
                            </p>
                        </div>
                    </div>
                    <div class="table-responsive py-4">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_aportes_iva" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_aportes_iva_PreRender" OnRowCommand="gv_aportes_iva_RowCommand" DataKeyNames="tr_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="fa_descripcion" HeaderText="Descripción del factor" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="tr_monto" HeaderText="Valor en Bs." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="tr_fecha_creacion" HeaderText="Fecha Registro" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="tr_pc_id" HeaderText="Código proceso" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetDelete" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-google-plus btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-trash fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelGvMontoPresentar" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

