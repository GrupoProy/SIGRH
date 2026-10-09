<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReporteAcreedores.aspx.cs" Inherits="Administración_ReporteAcreedores" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Planilla de Aportes</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="panelPlanillas">
        <ContentTemplate>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%"  ZoomMode="Percent" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
            </rsweb:ReportViewer>    


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>