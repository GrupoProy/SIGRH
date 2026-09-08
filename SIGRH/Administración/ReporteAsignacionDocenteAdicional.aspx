<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReporteAsignacionDocenteAdicional.aspx.cs" Inherits="Administración_ReporteAsignacionDocenteAdicional" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=15.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:-1em;width:75%">
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Planillas de Cursos de Temporada o Examenes de Mesa</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="card top--7" runat="server" id="DivReporte" visible="true"  >
        <div class="row">
        <div class="col-lg-4"><h3 class="mb-0">Generar Reporte</h3>
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Tipo de Planilla:</p>
                    <asp:DropDownList ID="ddlMesPlanilla" CssClass="form-control select2" OnSelectedIndexChanged="ddlMesPlanilla_SelectedIndexChanged" AppendDataBoundItems="true" runat="server"  >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlMesPlanilla" ValidationGroup="planilla" InitialValue="0" Display="Dynamic" runat="server" />
                </div>
            </div>
        </div>

        </div> 
        <div class="col-lg-4"><br />
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                  <h3 class="mb-0"> </h3>
                    <p class="text-sm mb-0">Periodo:</p>
                    <asp:DropDownList ID="ddlTipoPersonal" OnSelectedIndexChanged="ddlTipoPersonal_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlMesPlanilla" ValidationGroup="planilla" InitialValue="0" Display="Dynamic" runat="server" />
                </div>
            </div>
        </div>
        </div>
            <div class="card-body text-left">
                <asp:LinkButton ID="btnGene" OnClick="btnGene_Click" CssClass="btn btn-success" Text="<i class='fas fa-cogs'></i> Generar Reporte" runat="server" />
            </div>
        </div>
    </div>




    <rsweb:ReportViewer ID="ReportViewer1" ZoomMode="FullPage" runat="server" Width="100%" ShowParameterPrompts="False" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
    </rsweb:ReportViewer>  
</asp:Content>

