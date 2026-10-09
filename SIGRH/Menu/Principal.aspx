<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRector.master" AutoEventWireup="true" CodeFile="Principal.aspx.cs" Inherits="Menu_Principal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="row">
        <div class="col-lg-12">
            <div class="card">
                <div class="tab-content">
                    <div id="nav-pills-tabs-component" class="tab-pane tab-example-result fade active show" role="tabpanel" aria-labelledby="nav-pills-tabs-component-tab">
                        <div class="nav-wrapper">
                            <ul class="nav nav-pills nav-fill flex-column flex-md-row" id="tabs-icons-text" role="tablist">
                                <li class="nav-item">
                                    <a class="nav-link mb-sm-3 mb-md-0 active" id="tabs-icons-text-1-tab" data-toggle="tab" href="#tabs-icons-text-1" role="tab" aria-controls="tabs-icons-text-1" aria-selected="true"><i class="fas fa-address-card mr-2"></i>ESCALA SALARIAL</a>
                                </li>
                                <li class="nav-item">
                                    <a class="nav-link mb-sm-3 mb-md-0" id="tabs-icons-text-2-tab" data-toggle="tab" href="#tabs-icons-text-2" role="tab" aria-controls="tabs-icons-text-2" aria-selected="false"><i class="fas fa-user-tag mr-2"></i>CONSULTA FUNCIONARIO</a>
                                </li>
                            </ul>
                        </div>
                        <div class="card shadow">
                            <div class="card-body">
                                <%-- ESCALA SALARIAL --%>
                                <div class="tab-content" id="myTabContent">
                                    <div class="tab-pane fade show active" id="tabs-icons-text-1" role="tabpanel" aria-labelledby="tabs-icons-text-1-tab">
                                        <asp:UpdatePanel runat="server">
                                            <ContentTemplate>
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
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:AsyncPostBackTrigger ControlID="ddl_escala" EventName="SelectedIndexChanged" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>

                                    <%-- CONSULTA  FUNCIONARIO --%>
                                    <div class="tab-pane fade" id="tabs-icons-text-2" role="tabpanel" aria-labelledby="tabs-icons-text-2-tab">
                                        <div class="row">
                                            <div class="container-fluid">
                                                <div class="card mb-4">
                                                    <!-- Card header -->
                                                    <div class="card-header">
                                                        <div class="ct-page-title">
                                                            <h3 class="mb-0">Especifique criterio de búsqueda </h3>
                                                            <p class="text-sm mb-0">
                                                                Para su búsqueda,  puede usar las siguientes opciones mostrados en la parte inferior.
                                                            </p>
                                                        </div>
                                                    </div>
                                                    <!-- Card body -->
                                                    <div class="card-body">
                                                        <!-- Form groups used in grid -->
                                                        <asp:UpdatePanel ID="panelFuncionarios" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">
                                                                    <div class="row">
                                                                        <div class="col-sm-6 col-md-3">
                                                                            <div class="form-group">
                                                                                <label class="form-control-label" for="example4cols2Input">Apellido Paterno</label>
                                                                                <div class="input-group input-group-merge">
                                                                                    <div class="input-group-prepend">
                                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                                    </div>
                                                                                    <asp:TextBox ID="Txt_per_ap_paterno_b" CssClass="form-control" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-6 col-md-3">
                                                                            <div class="form-group">
                                                                                <label class="form-control-label" for="example4cols3Input">Apellido Materno</label>
                                                                                <div class="input-group input-group-merge">
                                                                                    <div class="input-group-prepend">
                                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                                    </div>
                                                                                    <asp:TextBox ID="Txt_per_ap_materno_b" CssClass="form-control" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-6 col-md-3">
                                                                            <div class="form-group">
                                                                                <label class="form-control-label" for="example4cols4Input">Nombre (s)</label>
                                                                                <div class="input-group input-group-merge">
                                                                                    <div class="input-group-prepend">
                                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                                    </div>
                                                                                    <asp:TextBox ID="Txt_per_nombres_b" CssClass="form-control" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                    <div class="row">
                                                                        <div class="col-sm-6 col-md-3">
                                                                            <div class="form-group">
                                                                                <label class="form-control-label" for="example4cols5Input">Apellido del Esposo</label>
                                                                                <div class="input-group input-group-merge">
                                                                                    <div class="input-group-prepend">
                                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                                    </div>
                                                                                    <asp:TextBox ID="Txt_per_ap_casada_b" CssClass="form-control" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-6 col-md-3">
                                                                            <div class="form-group">
                                                                                <label class="form-control-label" for="example4cols1Input">Carnet Identidad</label>
                                                                                <div class="input-group input-group-merge">
                                                                                    <div class="input-group-prepend">
                                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                                    </div>
                                                                                    <asp:TextBox ID="Txt_per_num_doc_b" CssClass="form-control" type="number" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-6 col-md-3">
                                                                            <div class="form-group">
                                                                                <label class="form-control-label" for="example4cols6Input">Código del Funcionario</label>
                                                                                <div class="input-group input-group-merge">
                                                                                    <div class="input-group-prepend">
                                                                                        <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                                                                    </div>
                                                                                    <asp:TextBox ID="Txt_per_id_b" CssClass="form-control numero" runat="server" />
                                                                                </div>
                                                                            </div>
                                                                        </div>
                                                                        <div class="col-sm-6 col-md-3">
                                                                            <div class="form-group">
                                                                                <label class="form-control-label" for="example4cols7Input">&nbsp</label>
                                                                                <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-info btn-block" Text="<i class='fas fa-search'></i> Buscar" OnClick="BtnBuscar_Click" runat="server" />
                                                                            </div>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>
                                                <div id="blockResultados" class="row" style="display: none">
                                                    <div class="col">
                                                        <div class="card">
                                                            <div class="card-header">
                                                                <div class=" ct-page-title">
                                                                    <h3 class="mb-0">Lista de Funcionario(s)</h3>
                                                                    <p class="text-sm mb-0">
                                                                        Detalle de los resultados de la búsqueda.
                                                                    </p>
                                                                </div>
                                                            </div>
                                                            <div class="table-responsive py-4">
                                                                <asp:UpdatePanel ID="up_gv_items" runat="server">
                                                                    <ContentTemplate>
                                                                        <asp:GridView ID="gv_items" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_items_PreRender" OnRowCommand="gv_items_RowCommand" DataKeyNames="per_id, per_num_doc, as_id" runat="server">
                                                                            <Columns>
                                                                                <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                                                                    <ItemTemplate>
                                                                                        <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'><i class='ni ni-curved-next'></i></span>" data-toggle='tooltip' data-placement='top' title='Ver Detalle' runat="server" />
                                                                                    </ItemTemplate>
                                                                                </asp:TemplateField>
                                                                                <asp:BoundField DataField="NOMBRE_COMPLETO" HeaderText="Nombre" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                                <asp:BoundField DataField="per_num_doc" HeaderText="C.I." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                                <asp:BoundField DataField="as_estado" HeaderText="Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                                <asp:BoundField DataField="per_ap_casada" HeaderText="Apellido de Casada " HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                                <asp:BoundField DataField="per_id" HeaderText="Código" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                                                            </Columns>
                                                                        </asp:GridView>
                                                                    </ContentTemplate>
                                                                </asp:UpdatePanel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:UpdateProgress ID="up1" AssociatedUpdatePanelID="panelFuncionarios" runat="server">
                                                    <ProgressTemplate>
                                                        <div class="load"></div>
                                                    </ProgressTemplate>
                                                </asp:UpdateProgress>
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