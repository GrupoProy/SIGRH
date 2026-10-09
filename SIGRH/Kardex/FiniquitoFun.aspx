<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="FiniquitoFun.aspx.cs" Inherits="Kardex_FiniquitoFun" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Finiquito</h6>
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
                        Para su búsqueda,  puede usar las siguientes opciones mostrados en la parte inferior.
                    </p>
                </div>
            </div>
            <!-- Card body -->
            <div class="card-body">
                <!-- Form groups used in grid -->
                <asp:UpdatePanel runat="server">
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
                                <div class="col-sm-6 col-md-3">
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
                            <h3 class="mb-0">Listado de Ítem(s)</h3>
                            <p class="text-sm mb-0">
                                Detalle de los resultados de la búsqueda.
                            </p>
                        </div>
                    </div>
                    <div class="table-responsive py-4">
                        <asp:UpdatePanel ID="up_gv_items" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gv_items" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" OnPreRender="gv_items_PreRender" OnRowCommand="gv_items_RowCommand" DataKeyNames="as_per_id, as_id" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="as_per_id" HeaderText="Código" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_ap_paterno" HeaderText="Apellido Paterno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_ap_materno" HeaderText="Apellido Materno" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_nombres" HeaderText="Nombre (s)" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_ap_casada" HeaderText="Apellido de Casada " HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="per_num_doc" HeaderText="C.I." HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:BoundField DataField="as_fecha_fin" HeaderText="Fecha Baja" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" />
                                        <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center" HeaderStyle-Width="130px">
                                            <ItemTemplate>
                                                <asp:LinkButton CommandName="GetAssign" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn bg-gradient-inst text-white btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-plus fa-lg'></i></span>" data-toggle='tooltip' data-placement='top' title='Procesar Finiquito' runat="server" />
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
</asp:Content>

