<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReporteCurriculum.aspx.cs" Inherits="Kardex_ReporteCurriculum" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Reporte Curriculum</h6>
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
<%--                    <h3 class="mb-0">Planilla de Haberes</h3>--%>
                    <p class="text-sm mb-0">Grado Académico:</p>
                    <asp:DropDownList ID="ddlGradoAcademico" AutoPostBack="true" OnSelectedIndexChanged="ddlGradoAcademico_SelectedIndexChanged" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlGradoAcademico" ValidationGroup="planilla" InitialValue="0" Display="Dynamic" runat="server" />
                </div>
            </div>
        </div>

        </div>
        <div class="col-lg-4">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Carreras:</h3>
                    <asp:UpdatePanel runat="server" ID="panel1">
                        <ContentTemplate>
                    <asp:DropDownList ID="ddlCarreras" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  >
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlCarreras" ValidationGroup="planilla" InitialValue="0" Display="Dynamic" runat="server" />
                        </ContentTemplate>
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlGradoAcademico" EventName="SelectedIndexChanged" />
                        </Triggers>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        </div>
        <div class="card-body text-left top--4">
           <asp:LinkButton ID="BtnGuardar" CssClass="btn btn-success" Text="<i class='fas fa-save'></i> Ver Reporte" ValidationGroup="planilla"  OnClick="BtnGuardar_Click" runat="server" />
        </div>

        </div>

    </div>
    <hr />
        <asp:UpdatePanel runat="server" ID="panel2">
        <ContentTemplate>
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ShowParameterPrompts="False" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
    </rsweb:ReportViewer>  
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="panel1" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdateProgress AssociatedUpdatePanelID="panel2" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

