<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReporteAsistenciaIndividual.aspx.cs" Inherits="ControlPersonal_ReporteAsistenciaIndividual" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:UpdatePanel runat="server" ID="PanelAltasBajas">
        <ContentTemplate>
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Reporte Individual de Asistencia</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6"  >
        <div class="row">
        <div class="col-lg-4">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Fecha Inicial:</h3>
                    <asp:TextBox ID="txtFechaInicio" CssClass="form-control datepickerD" runat="server" />
                    
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFechaInicio" ValidationGroup="planilla" InitialValue="0" Display="Dynamic" runat="server" />
                </div>
            </div>
        </div>

        </div>
        <div class="col-lg-4">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Fecha Final:</h3>
                    <asp:TextBox ID="txtFechaFin" CssClass="form-control datepickerD" runat="server" />
                    
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFechaFin" ValidationGroup="planilla" InitialValue="0" Display="Dynamic" runat="server" />
                </div>
            </div>
        </div>
        </div>
            <div class="col-lg-2">
                <div class="card-body text-left top--4">
                    <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Ver Reporte" ValidationGroup="planilla"  OnClick="BtnGuardar_Click" runat="server" />
                </div>
            </div>
        </div>

    </div>
    <hr />
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ShowParameterPrompts="False" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
    </rsweb:ReportViewer>  
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="BtnGuardar" EventName="Click" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="PanelAltasBajas" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

