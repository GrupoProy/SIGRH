<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReporteViatico.aspx.cs" Inherits="ControlPersonal_ReporteViatico" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Planilla de Viaticos</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="panelPlanillas">
        <ContentTemplate>

    <div class="container-fluid mt--6"  >
        <div class="row justify-content-center">
            <div class="col-lg-4 card-wrapper">
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
        <%--                    <h3 class="mb-0">Planilla de Haberes</h3>--%>
                            <h3 class="mb-0">Seleccione el nro de planilla:</h3>
                            <asp:DropDownList ID="ddl_nro_planilla" OnSelectedIndexChanged="ddl_nro_planilla_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" AutoPostBack="true"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%"  ZoomMode="Percent" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
            </rsweb:ReportViewer>    


        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

