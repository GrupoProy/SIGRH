<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="Cumpleaños.aspx.cs" Inherits="ControlPersonal_Cumpleaños" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Reporte Cumpleañeros</h6>
                    </div>
                    <div class="col-lg-6 col-5 text-right">
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="container-fluid mt--6">
        <asp:UpdatePanel runat="server">
            <ContentTemplate>
                <div class="col-lg-4 card-wrapper">
                    <div class="card">
                        <div class="card-header border-bottom">
                            <div class="ct-page-title">
                                <h3 class="mb-0">Seleccione el mes:</h3>
                                <asp:DropDownList ID="ddl_mes" OnSelectedIndexChanged="ddl_mes_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" AutoPostBack="true" />
                                <asp:LinkButton ID="btn_generar" OnClick="btn_generar_Click" CssClass="btn btn-success btn-block" Text="<i class='fas fa-save'></i> Generar Reporte" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ddl_mes" EventName="SelectedIndexChanged" />
            </Triggers>
        </asp:UpdatePanel>
    </div>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ShowParameterPrompts="False" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
    </rsweb:ReportViewer> 
</asp:Content>

