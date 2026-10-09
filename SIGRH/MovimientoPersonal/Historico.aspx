<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Historico.aspx.cs" Inherits="MovimientoPersonal_Historico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!-- Header -->
    <div class="header bg-org pb-6">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0"><%= Page.Title %></h6>
                        <nav aria-label="breadcrumb" class="d-none d-md-inline-block ml-md-4">
                            <ol class="breadcrumb breadcrumb-links breadcrumb-dark">
                                <li class="breadcrumb-item text-white"><small>SIGRH</small></li>
                            </ol>
                        </nav>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Page content -->
    <div class="container-fluid mt--6">
        <!--Result Record Starts here -->
        <div class="card">
            <div class="card-header border-bottom">
                <h3 class="mb-0">Lista de Personal</h3>
            </div>
            <div class="card-body">
                <!-- Placing GridView in UpdatePanel -->
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <asp:GridView ID="GvLista" CssClass="table table-bordered table-responsive" DataKeyNames="his_id" AutoGenerateColumns="false" OnPreRender="GvLista_PreRender" runat="server">
                            <Columns>
                                <asp:BoundField HeaderText="Código" DataField="his_id" />
                                <asp:BoundField HeaderText="Tipo ABM" DataField="his_tipo_abm" />
                                <asp:BoundField HeaderText="Tabla" DataField="his_nom_tabla" />
                                <asp:BoundField HeaderText="Campo" DataField="his_nom_pk" />
                                <asp:BoundField HeaderText="Valor" DataField="his_valor_pk" />
                                <asp:BoundField HeaderText="Datos" DataField="his_campos" />
                                <asp:BoundField HeaderText="Fecha Creación" DataField="his_fecha_creacion" />
                                <asp:BoundField HeaderText="Usuario" DataField="his_usuario_creacion" />
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <!--Result Record Ends here -->
    </div>
</asp:Content>
