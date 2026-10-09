<%@ Page Title="Manual de Puestos" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="frmReportesPDF.aspx.cs" Inherits="ManualPuestos_frmPuestos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header bg-light pb-6">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h4 class="h2 text-white d-inline-block mb-0"><i class="fas fa-table mr-3"></i>Visor PDF</h4>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <div class="card mb-4">
            <!-- Card header -->
            <div class="card-header">
                <h3 class="mb-0">Búsqueda </h3>
                <p class="text-sm mb-0">
                    (Opcional) Puede usar los filtros mostrados en la parte inferior para ver el reporte de su selección.
                </p>
            </div>
            <!-- Card body -->
            <asp:Panel runat="server" DefaultButton="btnFiltrar">

                <div class="card-body">
                    <div class="row align-items-center">
                        <div class="col">
                            <h3 class="mb-0">&nbsp</h3>
                        </div>
                        <div class="col-2 pull-right">
                            <label class="form-control-label" for="exampleFormControlSelect1">Gestión</label>
                            <asp:DropDownList ID="ddl_gestion" CssClass="form-control" OnSelectedIndexChanged="ddl_gestion_SelectedIndexChanged" AutoPostBack="true" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="form-control-label" for="example3cols1Input">Ítem</label>
                                <asp:TextBox ID="txt_item" CssClass="form-control" TextMode="Number" placeholder="Item" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <div class="form-group">
                                    <label class="form-control-label" for="exampleFormControlSelect1">Cargo</label>
                                    <asp:DropDownList ID="ddl_cargo" AppendDataBoundItems="true" CssClass="form-control" data-toggle="select" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-5">
                            <div class="form-group">
                                <div class="form-group">
                                    <label class="form-control-label" for="exampleFormControlSelect1">Unidad Organizacional</label>
                                    <asp:DropDownList ID="ddl_unidad_organizacional" AppendDataBoundItems="true" CssClass="form-control" data-toggle="select" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="form-group">
                                    <label class="form-control-label" for="exampleFormControlSelect1">Dirección Administrativa</label>
                                    <asp:DropDownList ID="ddl_direccion_administrativa" AppendDataBoundItems="true" CssClass="form-control" data-toggle="select" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="form-group">
                                <div class="form-group">
                                    <label class="form-control-label" for="exampleFormControlSelect1">Unidad Ejecutora</label>
                                    <asp:DropDownList ID="ddl_unidad_ejecutiva" AppendDataBoundItems="true" CssClass="form-control" data-toggle="select" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-8">
                            <div class="form-group text-right">
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group text-right">
                                <asp:LinkButton ID="btnLimpiar" CssClass="btn btn-warning btn-block" Text="<i class='fas fa-eraser'></i> Limpiar" OnClick="btnLimpiar_Click" runat="server" />
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group text-right">
                                <asp:UpdatePanel runat="server">
                                    <ContentTemplate>
                                        <asp:LinkButton ID="btnFiltrar" CssClass="btn btn-vimeo btn-block" Text="<i class='fas fa-search'></i> Filtrar" OnClick="btnFiltrar_Click" runat="server" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </div>

        <div class="card">
            <!-- Card header -->
            <div class="card-header">
                <div class="row">
                    <div class="col-6">
                        <h3 class="mb-0">Resultados de la Búsqueda</h3>
                    </div>
                </div>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:UpdatePanel runat="server">
                        <ContentTemplate>
                            <asp:GridView ID="gvPuesto" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gvPuesto_PreRender" OnRowCommand="gvPuesto_RowCommand" DataKeyNames="idFicha" runat="server">
                                <Columns>
                                    <asp:BoundField DataField="itemC" HeaderText="Ítem" />
                                    <asp:BoundField DataField="puesto" HeaderText="Puesto" />
                                    <asp:BoundField DataField="cargo" HeaderText="Cargo" />
                                    <asp:BoundField DataField="est_org" HeaderText="Unidad Organizacional" />
                                    <asp:BoundField DataField="item_anterior" HeaderText="Ítem Anterior" />
                                    <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="GetDetailReport" CssClass="table-action" data-toggle='tooltip' data-original-title='Ver Reporte PDF' Text=" <i class='fas fa-print'></i>" CommandArgument="<%# Container.DataItemIndex %>" runat="server" />
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

</asp:Content>

