<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReporteItems.aspx.cs" Inherits="Administración_ReporteItems" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Reporte de Items</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="container-fluid mt--6"  >
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Seleccione el estado de item:</p>
                    <asp:DropDownList ID="ddlMesPlanilla" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"   OnSelectedIndexChanged="ddlMesPlanilla_SelectedIndexChanged" AutoPostBack="true"/>                  
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlMesPlanilla" ValidationGroup="Baja_as" InitialValue="0" Display="Dynamic" runat="server" />
                </div>
            </div>
        </div>
    </div>


    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ShowParameterPrompts="False" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
    </rsweb:ReportViewer>  
</asp:Content>

