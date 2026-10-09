<%@ Page Title="UNIVERSIDAD AMAZONICA DE PANDO" Language="C#" MasterPageFile="~/Login.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page-header header-filter">
        <div class=" page-header-image" style="background-image: url('Content/img/11.png'); z-index: 0"></div>
        <div class="container">
            <div class="container-fluid">
                <div class="row" style="margin-top: -7em">
                    <div class="mx-auto text-center">
                        <asp:Image ImageUrl="Content/img/22.png" runat="server" />
                    </div>
                </div>
            </div>
            <%-- REALIZAR EL APOYO EN EL DESARROLLO, MANTENIMIENTO Y ACTUALIZACION DE LOS SISTEMAS DE RECURSOS HUMANOS --%>
            <div class="row justify-content-center mt-7">
                <div class="col-lg-12">
                    <div class="row">
                        <div class="col-lg-4">
                        </div>
                        <div class="col-lg-4 col-md-6">
                            <div class="card card-project" style="min-height: unset; background: inherit; box-shadow: inset 0 0 0 200px rgba(255,255,255,0.2);">
                                <a href="javascript:;">
                                    <div class="icon icon-lg icon-shape icon-shape-info shadow rounded-circle mx-auto" style="background-color: #495057; color: #fff;">
                                        <i class="fas fa-users"></i>
                                    </div>
                                </a>
                                <div class="card-body px-lg-5 pt-1 pb-5">
                                    <asp:UpdatePanel ID="up_ing" runat="server">
                                        <ContentTemplate>
                                            <asp:Login runat="server" ID="loginSigrh" CssClass="w-100" OnAuthenticate="loginSigrh_Authenticate">
                                                <LayoutTemplate>
                                                    <asp:Panel runat="server" DefaultButton="btn_login_sigrh">
                                                        <div class="row" style="padding-top: 40px;">
                                                            <div class="col-md-12">
                                                                <div class="form-group">
                                                                    <label class="form-control-label text-white">Usuario</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend  ">
                                                                            <span class="input-group-text"><i class="fas fa-user-alt"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="UserName" CssClass="form-control border-r" runat="server" />
                                                                        <asp:RequiredFieldValidator runat="server" CssClass="invalid-feedback" ControlToValidate="UserName" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ValidationGroup="login"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <div class="form-group">
                                                                    <label class="form-control-label text-white">Contraseña</label>
                                                                    <div class="input-group input-group-merge">
                                                                        <div class="input-group-prepend  ">
                                                                            <span class="input-group-text"><i class="ni ni-lock-circle-open"></i></span>
                                                                        </div>
                                                                        <asp:TextBox ID="Password" CssClass="form-control border-r" TextMode="Password" runat="server" />
                                                                        <asp:RequiredFieldValidator runat="server" CssClass="invalid-feedback" ControlToValidate="Password" ErrorMessage="(*) Campo Obligatorio" Display="Dynamic" ValidationGroup="login" />
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row mt-3">
                                                            <div class="col-md-12">
                                                                <asp:LinkButton ID="btn_login_sigrh" Text="<span class='btn-inner--icon'><i class='fas fa-sign-in-alt'></i></span><span class='btn-inner--text'>Ingresar</span>" CssClass="btn btn-block btn-icon text-white" BackColor="YellowGreen" CommandName="Login" ValidationGroup="login" runat="server" />
                                                            </div>
                                                        </div>
                                                    </asp:Panel>
                                                </LayoutTemplate>
                                            </asp:Login>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdateProgress ID="up" AssociatedUpdatePanelID="up_ing" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>