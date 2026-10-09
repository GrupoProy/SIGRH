<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="MigrarEscalaPuesto.aspx.cs" Inherits="Configuraciones_MigrarEscalaPuesto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <asp:UpdatePanel runat="server">
                    <ContentTemplate>
                        <div class="row align-items-center py-4">
                            <div class="col-lg-6 col-7">
                                <h6 class="h2 text-light d-inline-block mb-0">Migrar Escala Puesto
                                    <asp:Literal ID="ltl_gestion" runat="server" /></h6>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <div class="row justify-content-center">
            <div class="col-lg-8">
                <div class="card">
                    <div class="card-header d-flex align-items-center">
                        <div class="d-flex align-items-center">
                            <div class="text-dark font-weight-600 text-sm">
                                <h3 class="mb-0">Migración de Datos</h3>
                            </div>
                        </div>
                    </div>
                    <div class="card-body">
                        <asp:UpdatePanel runat="server">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-sm-6 col-md-12">
                                        <div class="form-group">
                                            <label class="form-control-label" for="example4cols2Input">&nbsp</label>
                                            <asp:LinkButton ID="btn_migrar_escala" Text="<i class='fas fa-save mr-2'></i>MIGRAR DATOS" ValidationGroup="addExaPreo" CssClass="btn btn-success btn-block" OnClick="btn_migrar_escala_Click" OnClientClick="MostrarMascara(true)" runat="server" />
                                        </div>
                                    </div>
                                </div>
                                <div id="no_existe_ep" class="row" runat="server">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-danger">La migración se realizó anteriormente.</p>
                                    </div>
                                </div>
                                <div id="existe_ep" class="row" runat="server">
                                    <div class="col-md-12">
                                        <p class="text-sm grid-notify-success">La migración de datos está disponible.</p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

