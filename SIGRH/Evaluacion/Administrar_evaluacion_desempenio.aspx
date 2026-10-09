<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Administrar_evaluacion_desempenio.aspx.cs" Inherits="Evaluacion_Administrar_evaluacion_desempenio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <link href="css/StyleSheet.css" rel="stylesheet" />
    <%--<asp:ScriptManager ID="ScriptManager" AsyncPostBackTimeout="36000" runat="server"></asp:ScriptManager>--%>
    <%-- colocar AsyncPostBackTimeout="36000" en el scriptmanager de la página maestra --%>
    <div class="header bg-secondary pb-2">
        <div class="container-fluid">
                    <!-- Card header -->
                    <div class="card-header">
                        <div class=" ct-page-title" style="text-align:center">
                            <div class="badge badge-success" style="text-align:center">
							<h2 class="mb-0"><asp:Label ID="lblEvaluacion" runat="server" Text=""></asp:Label></h2>
						    </div>
                        </div>
                    </div>
    </div>
    <div class="container-fluid">
        <asp:UpdatePanel ID="PanelEvaluacionDesempenio" runat="server">
            <ContentTemplate>
                <div class="card text-center">
                    <div class="card-header border-bottom" >
                        <asp:ImageButton ID="ImgBtn_1" runat="server" OnClick="ImgBtn_1_Click" Visible="true" ImageUrl="~/Evaluacion/imagenes/admin_eva_1.png"/>
                    </div>
                    <div class="card-header border-bottom">
                        <asp:ImageButton ID="ImgBtn_2" runat="server" OnClick="ImgBtn_2_Click" Visible="true" ImageUrl="~/Evaluacion/imagenes/admin_eva_2.png"  />
                    </div>
                    <div class="card-header border-bottom">
                        <asp:ImageButton ID="ImgBtn_3" runat="server" OnClick="ImgBtn_3_Click" Visible="true" ImageUrl="~/Evaluacion/imagenes/admin_eva_3.png" />
                    </div>
                    <div class="card-header border-bottom">
                        <asp:ImageButton ID="ImgBtn_4" runat="server" OnClick="ImgBtn_4_Click" Visible="true" ImageUrl="~/Evaluacion/imagenes/admin_eva_4.png" />
                    </div>

                </div>
            </ContentTemplate>

       </asp:UpdatePanel>
    </div>




</asp:Content>

