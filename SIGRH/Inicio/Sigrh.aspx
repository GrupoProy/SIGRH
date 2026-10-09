<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Sigrh.aspx.cs" Inherits="MovimientoPersonal_Sigrh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <div class="header pb-6 d-flex align-items-center" style="min-height: 90vh; background-image: url(../Content/12.jpg);background-size:contain; background-position: center top; opacity:0.1">--%>
        <!-- Mask -->
    <div class="header pb-6 d-flex align-items-center" style="min-height: 90vh">
        <span class="mask bg-gradient-dark2 opacity-3"></span>
        <!-- Header container -->
        <%--        <div class="container-fluid d-flex align-items-center">
            <div class="row">
                <div class="col-lg-7 col-md-10">
                    <h1 class="display-2 text-white">Bienvenido
                        <asp:Literal ID="ltl_only_name" runat="server" />

                    </h1>
                    <p class="text-white mt-0 mb-5">This is your profile page. You can see the progress you've made with your work and manage your projects or assigned tasks</p>
                </div>
            </div>
        </div>--%>

        <div class="container-fluid shape-container d-flex align-items-center py-lg ">
            <div class="col px-0">
                <div class="row align-items-center ">
                    <div class="col-lg-6 ">
                        <h1 class="display-2 text-white">Bienvenid@
                            <asp:Literal ID="ltl_only_name" runat="server" />
                        </h1>
<%--                        <p class="lead text-white">
                            <asp:Literal ID="ltl_rol" runat="server" /></p>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
<%--                        <div class="card border-0" style="top:-4em;background-color: darkcyan">
                            <!-- Card body -->
                            <div class="card-body">
                                <div class="row">
                                    <div class="col text-center text-white">
                                        <asp:Literal ID="ltl_rol" runat="server" />
                                    </div>
                                    <div class="col-auto">
                                        <div class="icon icon-shape bg-white text-dark rounded-circle shadow">
                                            <i class="ni ni-world-2"></i>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>--%>
    <div class="container-fluid mt--6" style="margin-top:-3em">
        <div class="row">
            <div class="col-xl-8 order-xl-1">
                <div class="row">
                    <div class="col-lg-6">
                    </div>
                    <div class="col-lg-6">

                    </div>
                </div>
            </div>
        </div>
    </div>
   
</asp:Content>

