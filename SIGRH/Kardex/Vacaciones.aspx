<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Vacaciones.aspx.cs" Inherits="Kardex_Vacaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Vacaciones Disponibles</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--7">
        <div class="card">
            <div class="card-header">
                <h3 class="h2 text d-inline-block mb-0"><i class="fas fa-id-card-alt mr-2"></i>Datos funcionario</h3>
            </div>
            <div>
                <div class="card-body">
                    <div class="media align-items-center">
                        <asp:Image ID="imgFun" class="avatar-xll img-thumbnail mr-4" runat="server" />
                        <div class="card-body pt-0">
                            <asp:UpdatePanel runat="server">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <h5 class="h3 text-uppercase text-left">
                                                <asp:Literal ID="ltl_nombre_fun" runat="server" />
                                            </h5>
                                            <div class="h5 font-weight-400  text-left">
                                                <strong class="h5">CI: </strong>
                                                <asp:Literal ID="ltl_ci" runat="server" />
                                                <strong class="h5">COD. FUN:</strong>
                                                <asp:Literal ID="ltl_cod_fun" runat="server" />
                                                <strong class="h5">ÍTEM:</strong>
                                                <asp:Literal ID="ltl_item" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Cargo</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_cargo" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Puesto</div>
                                            <div class="h5 font-weight-400 content-text">
                                                <asp:Literal ID="ltl_puesto" runat="server" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="content-text-label">Ubicación</div>
                                            <div class="h5 font-weight-400 content-text content-text">
                                                <asp:Literal ID="ltl_ubicacion" runat="server" />
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

        <%-- TAB 2 --%>
        <div class="ct-example  card" style="padding-bottom: unset">
            <div class="tab-content">
                <div id="nav-pills-tabs-component2" class="tab-pane tab-example-result fade active show" role="tabpanel" aria-labelledby="nav-pills-tabs-component-tab">
                    <div class="nav-wrapper">
                        <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text2" role="tablist">
                            <li class="nav-item">
                                <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-5-tab" data-toggle="tab" href="#tabs-icons-text-5" role="tab" aria-controls="tabs-icons-text-5" aria-selected="true"><i class="fas fa-book mr-2"></i>DÍAS DE VACACIÓN DISPONIBLE</a>
                            </li>
                        </ul>
                    </div>
                    <div class="card shadow">
                        <div class="card-body">
                            <div class="tab-content" id="myTabContent2">
                                <div class="tab-pane fade show active" id="tabs-icons-text-5" role="tabpanel" aria-labelledby="tabs-icons-text-5-tab">
                                    <div class="row">
                                        <div class="col-xl-12">
                                            <div class="card-header">
                                                <div class=" ct-page-title">
                                                    <p class="text-sm mb-0">
                                                        Detalle de los días y horas disponibles para sacar una solicitud de vacación. 
                                                    </p>
                                                </div>
                                            </div>
                                            <div class="table-responsive py-4">
                                                <asp:UpdatePanel ID="panelGvVacacionDisponible" runat="server">
                                                    <ContentTemplate>
                                                        <asp:GridView ID="gv_dias_vacacion_disp" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_dias_vacacion_disp_PreRender" DataKeyNames="va_id, va_per_id" runat="server">
                                                            <Columns>
                                                                <asp:BoundField DataField="va_gestion" HeaderText="Gestión" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_dias_ley" HeaderText="Días ley" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_dias_restantes" HeaderText="Saldo en días" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center display-2 dt-sub-title" />
                                                                <asp:BoundField DataField="va_horas_restantes" Visible="false" HeaderText="Saldo en horas" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_fecha_ingreso" HeaderText="Fecha ingreso" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                <asp:BoundField DataField="va_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                            </Columns>
                                                        </asp:GridView>

                                                    <asp:Label CssClass="titulo" ID="aviso" Visible="false" Text="El plantel eventual no goza de vacaciones" runat="server" />

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
