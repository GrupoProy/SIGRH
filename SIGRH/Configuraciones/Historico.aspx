<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Historico.aspx.cs" Inherits="MovimientoPersonal_Historico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Header -->
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Administración de Histórico</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <asp:UpdatePanel ID="Up_historico_lista" runat="server">
            <ContentTemplate>
                <asp:Panel ID="P_historico_lista" class="card" Visible="false" runat="server">
                    <div class="card-header">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Lista del Histórico</h3>
                            <p class="text-sm mb-0"></p>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:GridView ID="Gv_historico_lista" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="his_id" OnPreRender="Gv_historico_lista_PreRender" OnRowCommand="Gv_historico_lista_RowCommand" runat="server">
                            <Columns>
                                <asp:BoundField DataField="his_id" HeaderText="Código" />
                                <asp:BoundField DataField="his_tipo_abm" HeaderText="Valor Id" />
                                <asp:BoundField DataField="his_nom_tabla" HeaderText="Nombre Campo Id" />
                                <asp:BoundField DataField="his_nom_pk" HeaderText="Nombre Tabla" />
                                <asp:BoundField DataField="his_valor_pk" HeaderText="Tipo Movimiento" />
                                <asp:BoundField DataField="his_campos" HeaderText="Tipo Documento" />
                                <%--<asp:TemplateField HeaderText="Controles" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="BtnEditar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-warning btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-pen'></i></span>" data-toggle="tooltip" data-original-title="Editar" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>
                    </div>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <asp:UpdateProgress AssociatedUpdatePanelID="Up_historico_lista" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
