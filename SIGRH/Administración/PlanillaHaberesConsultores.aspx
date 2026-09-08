<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="PlanillaHaberesConsultores.aspx.cs" Inherits="Administración_PlanillaHaberesConsultores" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-blue d-inline-block mb-0">Planilla de Haberes Consultores</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:UpdatePanel runat="server" ID="panelPlanillas">
        <ContentTemplate>

    <div class="container-fluid mt--6"  >
        <div class="row justify-content-center">
            <div class="col-lg-5 card-wrapper">
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
        <%--                    <h3 class="mb-0">Planilla de Haberes</h3>--%>
                            <h3 class="mb-0">Seleccione el mes:</h3>
                            <asp:DropDownList ID="ddlMesPlanilla" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  OnSelectedIndexChanged="ddlMesPlanilla_SelectedIndexChanged" AutoPostBack="true"/>
                        </div>
                    </div>
                </div>
            </div>
        <div class="col-lg-5 card-wrapper" runat="server" visible="false" id="DivTipoPersonal">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Número de Planilla</h3>
<%--                    <p class="text-sm mb-0">Seleccione el mes:</p>--%>
                    <asp:DropDownList ID="ddlAdicional" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  OnSelectedIndexChanged="ddlAdicional_SelectedIndexChanged" AutoPostBack="true"/>
                    
                </div>
            </div>
        </div>
        </div>
            <div class="col-lg-2 card-wrapper" runat="server" visible="false" id="divMembrete">
                <asp:CheckBox Text="Membrete" Checked="true" CssClass="form-check" ForeColor="Red" Font-Bold="true" Font-Size="Large"  ID="chkMembrete"  OnCheckedChanged="chkMembrete_CheckedChanged" AutoPostBack="true" runat="server" />
            </div>

        </div>
    </div>

        <div runat="server" id="divReporte">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%"  ZoomMode="Percent" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
            </rsweb:ReportViewer>    
        </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="panelPlanillas" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>