<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageRector.master" AutoEventWireup="true" CodeFile="BuscadorFuncionarioConsulta.aspx.cs" Inherits="Menu_BuscadorFuncionarioConsulta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    

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
                                <asp:GridView ID="gv_items"  CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_items_PreRender" OnRowCommand="gv_items_RowCommand" DataKeyNames="per_id, per_num_doc, as_id" runat="server">
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
</asp:Content>