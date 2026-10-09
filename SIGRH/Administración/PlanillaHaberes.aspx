<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="PlanillaHaberes.aspx.cs" Inherits="AdministracionDePersonal_PlanillaHaberes" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Planilla de Haberes</h6>
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
                            <h3 class="mb-0">Seleccione el mes:</h3>
                            <asp:DropDownList ID="ddlMesPlanilla" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  OnSelectedIndexChanged="ddlMesPlanilla_SelectedIndexChanged" AutoPostBack="true"/>
                        </div>
                    </div>
                </div>
            </div>
        <div class="col-lg-4 card-wrapper" runat="server" visible="false" id="DivTipoPersonal">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Elegir el tipo de personal</h3>
<%--                    <p class="text-sm mb-0">Seleccione el mes:</p>--%>
                    <asp:DropDownList ID="ddlTipoPersonal" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  OnSelectedIndexChanged="ddlTipoPersonal_SelectedIndexChanged" AutoPostBack="true"/>
                    
                </div>
            </div>
        </div>
        </div>
            <div id="divAporte" class="col-sm-4" visible="false" runat="server">
                <div class="row">
                    <asp:LinkButton ID="btnAporte" OnClick="btnAporte_Click" CssClass="btn btn-info" Text="<i class='fas fa-info'>   </i> Aporte Patronal" data-toggle="tooltip" data-original-title="Generar Reporte" runat="server" />
                </div>
                <div class="row">
                    <asp:LinkButton ID="btn_Acreedores" OnClick="btn_Acreedores_Click" CssClass="btn btn-success" Text="<i class='fas fa-coins'>   </i> Otros Acreedores" data-toggle="tooltip" data-original-title="Ver Reporte" runat="server" />
                </div>
            </div>
            <div class="col-lg-2 card-wrapper" runat="server" visible="false" id="divExcel">
                <asp:CheckBox Text=".Excel" CssClass="form-check" ForeColor="Green" Font-Bold="true" Font-Size="Large"  ID="chkExcel"  OnCheckedChanged="chkExcel_CheckedChanged" AutoPostBack="true" runat="server" />
            </div>
        </div>
    </div>
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%"  ZoomMode="Percent" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
            </rsweb:ReportViewer>    


        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="panelPlanillas" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

