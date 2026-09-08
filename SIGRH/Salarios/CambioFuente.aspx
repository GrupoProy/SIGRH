<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="CambioFuente.aspx.cs" Inherits="Salarios_CambioFuente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top: -4em; margin-left: 3em; width: 81%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Cambio de Fuente de Financiamiento</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="UpdateFuente">
        <ContentTemplate>
            <div class="container-fluid">

                <div class="row justify-content-center" style="margin-top: -5em">
                    <div class="col-lg-6 card" runat="server" id="PanelTotales" visible="true">
                        <div class="card-header">
                            <div class=" ct-page-title">
                                <h3 class="mb-0">TOTALES</h3>
                            </div>
                        </div>
                        <div class="card-body" style="margin-top: -1em">
                            <asp:GridView ID="gvTotales" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="FUENTE_ORG" HeaderText="FUENTE" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                    <asp:BoundField DataField="T_INGRESOS" HeaderText="INGRESOS" HeaderStyle-CssClass="text-center" DataFormatString="{0:N2}" />
                                    <asp:BoundField DataField="T_DESCUENTO" HeaderText="DESCUENTOS" HeaderStyle-CssClass="text-center" DataFormatString="{0:N2}" />
                                    <asp:BoundField DataField="LIQUIDO" HeaderText="LIQUIDO" HeaderStyle-CssClass="text-center" DataFormatString="{0:N2}" />
                                </Columns>
                            </asp:GridView>
                            <asp:LinkButton ID="btnAjustar" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-check'></i> Finalizar" OnClick="btnAjustar_Click" Visible="true" runat="server" />
                        </div>
                    </div>

                    <div class="col-lg-6 card-wrapper" runat="server" id="PanelBusqueda" visible="true">
                        <div class="card">
                            <div class="card-header ">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Búsqueda Item</h3>
                                    <p class="text-sm mb-0">
                                        El item a buscar debe ser el número de item de Contrato
                                    </p>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-6 col-md-5">
                                        <div class="form-group" style="margin-top: -1.5em">
                                            <label class="form-control-label">Ítem</label>
                                            <div class="input-group input-group-merge">
                                                <div class="input-group-prepend">
                                                    <span class="input-group-text border-default-2"><i class="fas fa-edit"></i></span>
                                                </div>
                                                <asp:TextBox ID="txt_item" class="form-control border-default-2 numero" placeholder="1" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="pl-lg-4" style="margin-top: -1.5em">
                                        <div class="form-group text-right">
                                            <label class="form-control-label">&nbsp</label>
                                            <asp:LinkButton ID="btnFiltrar" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="btnFiltrar_Click1" runat="server" />
                                        </div>
                                    </div>

                                </div>

                                <div id="grillaItems" visible="false" runat="server" style="margin-top: -1em">
                                    <!-- Card header -->
                                    <div class="card-header d-flex align-items-center">
                                        <div class="d-flex align-items-center">
                                            <div class="text-dark font-weight-600 text-sm">
                                                <h3 class="mb-0">Seleccione el item para ver las unidades similares</h3>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <div class="table-responsive py-4" style="margin-top: -2em">
                                            <asp:GridView ID="gvItems" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnRowCommand="gvItems_RowCommand" DataKeyNames="ca_id" runat="server">
                                                <Columns>
                                                    <asp:BoundField DataField="detalle_item" HeaderText="ITEM" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                                    <asp:BoundField DataField="unidad" HeaderText="UNIDAD" HeaderStyle-CssClass="text-center" />
                                                    <asp:TemplateField HeaderText="Detalle" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                        <ItemTemplate>
                                                            <asp:LinkButton CommandName="GetDetail" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-vimeo btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-plus fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Detalle Item' runat="server" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </div>
                                </div>
                                <div id="grillaUnidades" visible="false" runat="server" style="margin-top: -3.5em">
                                    <!-- Card header -->
                                    <div class="card-header d-flex align-items-center">

                                        <div class="d-flex align-items-center">
                                            <div class="text-dark font-weight-600 text-sm">
                                                <h3 class="mb-0">Elegir donde se moverá el item</h3>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:GridView ID="gvUnidades" OnRowCommand="gvUnidades_RowCommand" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gvUnidades_PreRender" DataKeyNames="eo_id, ca_id" runat="server">
                                        <Columns>
                                            <asp:BoundField DataField="eo_descripcion" HeaderText="UNIDAD SIMILAR" HeaderStyle-CssClass="text-center" ItemStyle-HorizontalAlign="Center" />
                                            <asp:BoundField DataField="cp_fuente" HeaderText="FUENTE" HeaderStyle-CssClass="text-center" />
                                            <asp:BoundField DataField="cp_organismo" HeaderText="ORGANISMO" HeaderStyle-CssClass="text-center" />
                                            <asp:TemplateField HeaderText="MOVER" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                                <ItemTemplate>
                                                    <asp:LinkButton CommandName="GetDetail" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-location-arrow fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Mover' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>


                            </div>
                        </div>
                    </div>


                </div>


            </div>

            <div id="ConfirmacionProceso" class="modal fade" tabindex="-1" role="dialog" aria-labelledby="glosaTitle" aria-hidden="true" data-backdrop="static" data-keyboard="false">
                <div class="modal-dialog modal-dialog-centered" role="document">
                    <div class="modal-content">
                        <div class="modal-header border-bottom">
                            <div class="ct-page-title">
                                <h5 class="modal-title">Proceso de Planillas Completado</h5>
                                <p class="text-sm mb-0">Está seguro de finalizar el proceso de planillas y proseguir a la generación de Líquidos Pagables? Una vez confirmado este paso, no será posible volver a procesar.</p>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4 ml-7">
                                <asp:LinkButton ID="btnVerificarCi" CssClass="btn btn-success" Text="<i class='fas fa-check'></i> Confirmar" OnClick="btnVerificarCi_Click" runat="server" />
                            </div>
                            <div class="col-4">
                                <asp:LinkButton ID="btnCancelarVerificacionCI" CssClass="btn btn-google-plus" Text="<i class='fas fa-times'></i> Cancelar" OnClick="btnCancelarVerificacionCI_Click" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="UpdateFuente" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

