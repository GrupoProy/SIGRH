<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRector.master" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Menu_Consulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    

    <div class="container-fluid">
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="card-body">
                <div class="media align-items-center">
                    <div class="media-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <h6 class="heading-small text-muted">DATOS PERSONALES</h6>
                                <div class="row">
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Nombre funcionario: </div>
                                        <div class="h5 font-weight-400 content-text content-text">
                                            <asp:Literal ID="ltl_nombre" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">CI: </div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_ci" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-4">
                                        <div class="content-text-label">Cargo: </div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_cargo" runat="server" />
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="content-text-label">Puesto: </div>
                                        <div class="h5 font-weight-400 content-text">
                                            <asp:Literal ID="ltl_puesto" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>

            <div class="tab-content">
                <div id="nav-pills-tabs-component" class="tab-pane tab-example-result fade active show" role="tabpanel" aria-labelledby="nav-pills-tabs-component-tab">
                    <div class="nav-wrapper">
                        <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#tabs-icons-text-1" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true"><i class="fas fa-address-card mr-2"></i>DATOS PERSONALES </a>
                            </li>
                        </ul>
                    </div>
                    <div class="card shadow">
                        <div class="card-body">
                            <div class="tab-content" id="myTabContent">
                                <div class="tab-pane fade show active" id="tabs-icons-text-1" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-body" style="padding-top: unset;">
                                                <!-- Form groups used in grid -->
                                                <asp:UpdatePanel ID="up_guardar_per_dom" runat="server">
                                                    <ContentTemplate>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="form-inline">
                                                                    <i class="fas fa-money-bill-wave"></i>
                                                                    &nbsp<div class="content-text-label">Haber Basico (Bs): </div>
                                                                </div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_hb" runat="server" />
                                                                </div>
                                                            </div>
                                                            <br>
                                                            <div class="col-sm-4">
                                                               <div class="form-inline">
                                                                    <i class="fas fa-coins"></i>
                                                                    &nbsp<div class="content-text-label">Bono frontera: </div>
                                                                </div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_bono_f" runat="server" />
                                                                </div>
                                                            </div>
                                                            <br>
                                                            <div class="col-sm-4">
                                                                <div class="form-inline">
                                                                    <i class="fas fa-user-clock"></i>
                                                                    &nbsp<div class="content-text-label">Bono antiguedad: </div>
                                                                </div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_bono_a" runat="server" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <br>
                                                        <div class="row">
                                                            <div class="col-sm-4">
                                                                <div class="form-inline">
                                                                    <i class="fas fa-money-check-alt"></i>
                                                                    &nbsp<div class="content-text-label">Total ganado: </div>
                                                                </div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_total_g" runat="server" />
                                                                </div>
                                                            </div>
                                                            <br>
                                                            <div class="col-sm-4">
                                                               <div class="form-inline">
                                                                    <i class="fas fa-hand-holding-usd"></i>
                                                                    &nbsp<div class="content-text-label">Descuento AFP: </div>
                                                                </div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_afp" runat="server" />
                                                                </div>
                                                            </div>
                                                            <br>
                                                            <div class="col-sm-4">
                                                                <div class="form-inline">
                                                                    <i class="fas fa-money-bill-alt"></i>
                                                                    &nbsp<div class="content-text-label">Liquido pagable: </div>
                                                                </div>
                                                                <div class="h5 font-weight-400 content-text">
                                                                    <asp:Literal ID="ltl_liquido" runat="server" />
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

