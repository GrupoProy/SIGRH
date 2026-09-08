<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageCheque.master" AutoEventWireup="true" CodeFile="BuscarProceso.aspx.cs" Inherits="Cheques_BuscarProceso" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Búsqueda de Cheques</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>
<div class="container-fluid mt--6">
    <div class="card mb-4">
        <!-- Card header -->
        <div class="card-header">
            <div class=" ct-page-title">
                <h3 class="mb-0">Especifique criterio de búsqueda </h3>
                <p class="text-sm mb-0">
                    Para su búsqueda,  puede usar los siguientes parámetros
                </p>
            </div>
        </div>
            <div class="card-body">
                <!-- Form groups used in grid -->
                <asp:UpdatePanel ID="panelFuncionarios" runat="server">
                    <ContentTemplate>
                        <asp:Panel CssClass="card-body" DefaultButton="BtnBuscar" runat="server">
                            <div class="row">
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols2Input">Nombre del Proceso</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtNomProceso" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols3Input">Preventivo</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtPreventivo" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols4Input">Beneficiario</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtBeneficiario" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols5Input">NIT/CI</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtNitCi" CssClass="form-control" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
                                        <label class="form-control-label" for="example4cols1Input">Número de Cheque</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>
                                            <asp:TextBox ID="txtNumeroCheque" CssClass="form-control" type="number" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-sm-6 col-md-3">
                                    <div class="form-group">
<%--                                        <label class="form-control-label" for="example4cols6Input">Gestion</label>
                                        <div class="input-group input-group-merge">
                                            <div class="input-group-prepend">
                                                <span class="input-group-text"><i class="fas fa-edit"></i></span>
                                            </div>--%>
                                              <label class="form-control-label" for="ddlCategoria">Gestión:</label>
                                              <asp:DropDownList ID="ddlGestion" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
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

        <div id="blockResultados" class="row" style="display: none">
            <div class="col">
                <div class="card">
                    <div class="card-header">
                        <div class=" ct-page-title">
                            <h3 class="mb-0">Lista de Cheque(s)</h3>
                            <p class="text-sm mb-0">
                                Detalle de los resultados de la búsqueda.
                            </p>
                        </div>
                    </div>
                    <div class="table-responsive py-4">
                        <asp:UpdatePanel ID="up_gv_items" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="GvLista" OnRowCommand="GvLista_RowCommand" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="proceso_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="preventivo" HeaderText="Preventivo" />
                                        <asp:BoundField DataField="compromiso" HeaderText="Compromiso" />
                                        <asp:BoundField DataField="devengado" HeaderText="devengado" />
                                        <asp:BoundField DataField="proceso_nombre" HeaderText="proceso nombre" />
                                        <asp:BoundField DataField="proceso_fecha_inicio" DataFormatString="{0:dd/MM/yyyy}" HeaderText="fecha inicio" />
                                        <asp:BoundField DataField="proceso_descripcion" HeaderText="descripcion" />
                                        <asp:BoundField DataField="proceso_estado" HeaderText="estado" />
                                        <asp:BoundField DataField="gestion" HeaderText="gestion" />
                                        <asp:TemplateField HeaderText="Escanear" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="BtnEscan" CommandName="GetEscan" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-success btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-user-plus'></i></span>" data-toggle='tooltip' data-placement='top' title='Escanear Cheque' runat="server" />
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
</div>
    <asp:UpdateProgress AssociatedUpdatePanelID="up_gv_items" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <asp:UpdateProgress AssociatedUpdatePanelID="panelFuncionarios" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

