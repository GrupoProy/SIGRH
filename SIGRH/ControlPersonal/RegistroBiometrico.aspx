<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="RegistroBiometrico.aspx.cs" Inherits="ControlPersonal_RegistroBiometrico" %>

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
                    <asp:LinkButton ID="BtnBuscar"  CssClass="btn btn-info btn-block top-4" data-toggle="tooltip" data-original-title="Listar Dispositivos" Text="<i class='fas fa-list'></i> Listar" runat="server" />
                </div>
                <div class="form-group col-md-3">
                    <asp:LinkButton ID="BtnNuevo" CssClass="btn btn-warning btn-block top-4" Text="<i class='fas fa-plus'>  Nuevo Dispositivo </i>" data-toggle="tooltip" data-original-title="Nuevo Dispositivo" runat="server" />
                </div>
            </div>
        </asp:Panel>
    </div>

    <!-- Registrar Plan -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel ID="plan_adicionar" CssClass="card" Visible="false" runat="server" BackColor="Transparent">
                <div class="col-md-6">
                    <div class="card">
                        <div class="card-header border-bottom">
                            <div class="ct-page-title">
                                <h3 class="mb-0">Plan de estudio</h3>
                                <p class="text-sm mb-0">En el siguiente formulario puede ingresar los datos de la malla curricular.</p>
                            </div>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <!-- Carrera -->
                                <div class="form-group col-md-8">
                                    <label class="form-control-label">Carrera</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-book-alt"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="txtRegCarrera" CssClass="form-control" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtRegCarrera" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                </div>
                                <!-- Año -->
                                <div class="form-group col-md-2">
                                    <label class="form-control-label">Año</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="far fa-calendar-alt"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="Txt_plan_año" CssClass="form-control numero" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="Txt_plan_año" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                </div>
                            </div>
                            <div class="row">
                                <!-- Area -->
                                <div class="form-group col-md-8">
                                    <label class="form-control-label">Area</label>
                                    <div class="input-group input-group-merge">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text">
                                                <i class="fas fa-book-alt"></i>
                                            </span>
                                        </div>
                                        <asp:TextBox ID="txtRegArea" CssClass="form-control" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtRegArea" ValidationGroup="add" InitialValue="0" Display="Dynamic" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="card-body text-right">
                            <asp:LinkButton ID="BtnCrear" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Crear" ValidationGroup="add" runat="server" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <!-- End Registro -->


    <!-- Mostrar plan -->
    <asp:UpdatePanel runat="server">
        <ContentTemplate>
            <asp:Panel ID="plan_result" CssClass="card" Visible="false" runat="server">
                <div class="card-header border-bottom">
                    <h3 class="mb-0">Resultado Búsqueda</h3>
                </div>
                <div class="card-body">
                    <asp:GridView ID="gv_dispositivos" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="false" DataKeyNames="di_id" runat="server">
                        <Columns>
                            <asp:BoundField DataField="plan_gestion" HeaderText="Año" />
                            <asp:BoundField DataField="plan_estado" HeaderText="Estado" />
                            <asp:BoundField DataField="plan_carrera_nombre" HeaderText="Carrera" />
                            <asp:BoundField DataField="plan_area" HeaderText="Area" />
                            <asp:TemplateField HeaderText="Cambiar Estado" HeaderStyle-CssClass="text-center" ItemStyle-CssClass="text-center">
                                <ItemTemplate>
                                    <asp:LinkButton ID="BtnModificar" CommandName="GetId" CommandArgument="<%# Container.DataItemIndex %>" CssClass="btn btn-danger btn-sm" Text="<span class='btn-inner--icon'><i class='fas fa-ban'></i></span>" data-toggle='tooltip' data-placement='top' title='Cambiar Estado' runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>