<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="BoletasDePagoAdicional.aspx.cs" Inherits="Administración_BoletasDePagoAdicional" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel runat="server" ID="PanelBoletas">
        <ContentTemplate>
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-cyan d-inline-block mb-0">Boletas de Pago Adicional</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6"  >
        <div class="row">
        <div class="col-lg-3">
            <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Seleccione el mes:</p>
                    <asp:DropDownList ID="ddlMesPlanilla" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  OnSelectedIndexChanged="ddlMesPlanilla_SelectedIndexChanged" AutoPostBack="true"/>
                </div>
            </div>
            </div>
        </div>
        <div class="col-lg-3" runat="server" visible="false" id="divAdicional">
            <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Adicional:</p>
                    <asp:DropDownList ID="ddlAdicional" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  OnSelectedIndexChanged="ddlAdicional_SelectedIndexChanged" AutoPostBack="true"/>
                </div>
            </div>
            </div>
        </div>
        <div class="col-lg-3" runat="server" visible="false" id="DivTipoPersonal">
            <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Tipo de personal</p>
                    <asp:DropDownList ID="ddlTipoPersonal" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  OnSelectedIndexChanged="ddlTipoPersonal_SelectedIndexChanged" AutoPostBack="true"/>
                </div>
            </div>
            </div>
        </div>
        <div class="col-lg-3"  runat="server" visible="false" id="DivTipoTrabajo">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Relación Laboral:</p>
                    <asp:DropDownList ID="ddlTipoTrabajo" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"   OnSelectedIndexChanged="ddlTipoTrabajo_SelectedIndexChanged" AutoPostBack="true"/>                    
                </div>
            </div>
        </div>
        </div>
    </div>
    <div class="card-body text-right top--5" runat="server" id="divBtn" visible="false">
       <asp:LinkButton ID="btnVerReporte" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Ver Reporte" ValidationGroup="planilla"    runat="server" OnClick="btnVerReporte_Click" />
    </div>

</div>
    <div id="divResultado" runat="server">
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="100%"  ZoomMode="Percent" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
    </rsweb:ReportViewer>    
    </div>
    </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnVerReporte" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="PanelBoletas" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

