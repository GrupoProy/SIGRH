<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Biometrico.aspx.cs" Inherits="ControlPersonal_Biometrico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">DISPOSITIVOS BIOMETRICOS</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Cabecera -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <div class="card">
                <div class="card-header border-bottom">
                    <div class="ct-page-title">
                        <h3 class="mb-0">Dispositivos</h3>
                        <p class="text-sm mb-0">Listado de dispositivos o adicionar un nuevo dispositivo</p>
                    </div>
                </div>
                <asp:Panel CssClass="card-body" runat="server">
                    <div class="row">
                        <!-- Boton Buscar -->
                        <div class="form-group col-md-3">
                            <asp:LinkButton ID="BtnBuscar" OnClick="BtnBuscar_Click" CssClass="btn btn-info btn-block top-4" data-toggle="tooltip" data-original-title="Listar Dispositivos" Text="<i class='fas fa-list'></i> Listar" runat="server" />
                        </div>
                        <div class="form-group col-md-3">
                            <asp:LinkButton ID="BtnNuevo" OnClick="BtnNuevo_Click" CssClass="btn btn-warning btn-block top-4" Text="<i class='fas fa-plus'>  Nuevo Dispositivo </i>" data-toggle="tooltip" data-original-title="Nuevo Dispositivo" runat="server" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnBuscar" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="BtnNuevo" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    

    <!-- Registrar Dispositivo -->
    <asp:UpdatePanel ID="panel_adi" runat="server">
        <ContentTemplate>
            <asp:Panel ID="adicionar" CssClass="card" Visible="false" runat="server" BackColor="Transparent">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header border-bottom">
                            <div class="ct-page-title">
                                <h3 class="mb-0">Dispositivo Biometrico</h3>
                                <p class="text-sm mb-0">En el siguiente formulario puede ingresar los datos del dispositivo biometrico.</p>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <!-- Descripcion -->
                                <div class="form-group col-md-8">
                                    <label class="form-control-label">Descripcion</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="ni ni-caps-small"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="txt_descri" AutoCompleteType="Disabled" CssClass="form-control" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_descri" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                </div>
                                <!-- IP -->
                                <div class="form-group col-md-3">
                                    <label class="form-control-label">IP</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="ni ni-key-25"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="txt_ip" CssClass="form-control" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txt_ip" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <!-- Edificio -->
                                <div class="form-group col-md-6">
                                    <label class="form-control-label">Edificio</label>
                                    <asp:DropDownList ID="ddl_edificio" AutoPostBack="true" OnSelectedIndexChanged="ddl_edificio_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddl_edificio" ValidationGroup="add" Display="Dynamic" runat="server" />
                                </div>
                                <div class="form-group col-md-4">
                                    <div class="card-body text-right">
                                        <asp:LinkButton ID="BtnCrear" OnClick="BtnCrear_Click" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Registrar" ValidationGroup="add" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="ddl_edificio" EventName="SelectedIndexChanged" />
        </Triggers>
    </asp:UpdatePanel>
    <!-- End Registro -->


    <!-- Mostrar plan -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel ID="result" CssClass="card" Visible="false" runat="server">
                <div class="card-header border-bottom">
                    <h3 class="mb-0">Resultado Búsqueda</h3>
                </div>
                <div class="card-body">
                    <asp:GridView ID="gv_dispositivos" OnRowCommand="gv_dispositivos_RowCommand" OnPreRender="gv_dispositivos_PreRender" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="di_id" runat="server">
                        <Columns>
                            <asp:BoundField DataField="DISPOSITIVO" HeaderText="Descripcion" />
                            <asp:BoundField DataField="IP" HeaderText="IP" />
                            <asp:BoundField DataField="di_edificio" HeaderText="Nro Edificio" />
                            <asp:BoundField DataField="EDIFICIO" HeaderText="Edificio" />
                            <asp:TemplateField HeaderText="Opciones" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEditar" CommandName="Editar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-facebook btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-edit'></i></span>" data-toggle='tooltip' data-placement='top' title='Editar' runat="server" />
                                    <asp:LinkButton ID="BtnModificar" CommandName="Eliminar" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-ban'></i></span>" data-toggle='tooltip' data-placement='top' title='Eliminar' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

