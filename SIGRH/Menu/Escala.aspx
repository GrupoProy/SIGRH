<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRector.master" AutoEventWireup="true" CodeFile="Escala.aspx.cs" Inherits="Menu_Escala" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
   

    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row justify-content-center" style="margin-top: 3em">
                    <div class="col-lg-10 card-wrapper" runat="server" id="PanelBusqueda" visible="true">
                        <div class="card">
                            <div class="card-header" style="margin-top: -2em">
                                <div class=" ct-page-title">
                                    <h3 class="mb-0">Consulta de datos de la escala salarial: </h3>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-sm-5 col-md-4">
                                        <div class="form-group">
                                            <label class="form-control-label">Escala Salarial: </label>
                                            <asp:DropDownList ID="ddl_escala" OnSelectedIndexChanged="ddl_escala_SelectedIndexChanged" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="content-text-label">Haber Basico (Bs): </div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_hb" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="content-text-label">Bono Frontera: </div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_frontera" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="content-text-label">Total Ganado: </div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_total" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-4">
                                        <div class="content-text-label">Descuento AFP: </div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_afp" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-md-5">
                                        <div class="content-text-label">Liquido pagable: </div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_liquido" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddl_escala" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>

