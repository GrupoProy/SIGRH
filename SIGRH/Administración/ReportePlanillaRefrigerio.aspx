<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReportePlanillaRefrigerio.aspx.cs" Inherits="Administración_ReportePlanillaRefrigerio" %>
<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-cyan d-inline-block mb-0">Planilla de Haberes Adicional</h6>
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
        
                            <h3 class="mb-0">Seleccione el mes:</h3>
                            <asp:DropDownList ID="ddlMesPlanilla" OnSelectedIndexChanged="ddlMesPlanilla_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" AutoPostBack="true"/>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-2 card-wrapper" runat="server" id="divAdicional" visible="true">
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Planilla Nro:</h3>
                            <asp:DropDownList ID="ddlAdicional" OnSelectedIndexChanged="ddlAdicional_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-4 card-wrapper">
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <label class="form-control-label" for="Txt_per_ap_paterno_b">Cite: </label>
                            <div class="input-group input-group-merge">
                                <div class="input-group-prepend">
                                    <span class="input-group-text">
                                        <i class="fas fa-edit"></i>
                                    </span>
                                </div>
                                <asp:TextBox ID="txt_cite" CssClass="form-control" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-2 card-wrapper" runat="server" id="div1" visible="true">
                <asp:LinkButton ID="btnReporte" OnClick="btnReporte_Click" CssClass="btn btn-facebook btn-block top-3" Text="<i class='fas fa-chart-bar'></i> Mostrar Reporte" runat="server" />
            </div>
        </div>
    </div>

            <div runat="server" id="divReport" visible="true">
            <%--<rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%"  ZoomMode="Percent" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
            </rsweb:ReportViewer> --%>   
            </div>


        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="panelPlanillas" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

