<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReportesAdicionales.aspx.cs" Inherits="Administración_ReportesAdicionales" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="header pb-6" style="margin-top:-4em; margin-left:3em;width:81%"> 
        <div class="container-fluid">
            <div class="header-body">
                <div class="row align-items-center py-4">
                    <div class="col-lg-6 col-7">
                        <h6 class="h2 text-light d-inline-block mb-0">Reportes Adicionales</h6>
                    </div>
                </div>
            </div>
        </div>
    </div>
<%--                <asp:UpdatePanel runat="server" ID="PLANILLA">
                    <ContentTemplate>--%>
    <div class="container-fluid mt--6"  >
        <div class="row">
            <div class="col-6">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Seleccione el mes:</p>
                    <asp:DropDownList ID="ddlMesPlanilla" AutoPostBack="true" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  OnSelectedIndexChanged="ddlMesPlanilla_SelectedIndexChanged"/>
                </div>
            </div>
        </div>
            </div>
            <div class="col-6">

            <div class="card" id="divPlanilla" runat="server" visible="false">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">N° Planilla:</p>
                    <asp:DropDownList ID="ddlNroPlanilla" CssClass="form-control" AppendDataBoundItems="true" runat="server" />
                </div>
            </div>
        </div>


            </div>
        </div>
    <div class="row">
        <div class="col-4">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Ministerio de Economía</p>
                    <div runat="server" id="DivMinisterioVer" >
                        <asp:Button ID="btnMinEco_GenC31" CssClass="btn btn-info" Text="Generar Carpetas C-31"  OnClick="btnVerMinisterioEco_Click" runat="server"/>
                    <hr />
                    <p class="text-sm mb-0">Tipo de Planilla:</p>
                    <asp:DropDownList ID="ddlC31_1" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  />
                    <hr />
                    <p class="text-sm mb-0">Archivos:</p>
                    <asp:DropDownList ID="ddlC31_2" CssClass="form-control select2" AppendDataBoundItems="true" runat="server"  />
                    <hr />
                        <div class="row">
                            <div class="col-12">
                            <asp:Button ID="btnMinTrabajo_Generar" OnClick="btnMinTrabajo_Generar_Click" CssClass="btn btn-info btn-block" Text="Ver"  runat="server"/>                        
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <div class="col-4">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Ministerio de Trabajo</p>
                    <div runat="server" id="DivTrabajoVer">
                        <asp:Button ID="btnVerMinTrabajo" OnClick="btnVerMinTrabajo_Click" CssClass="btn btn-info" Text="Ver"  runat="server"/>
                    </div>
                </div>
            </div>
        </div>
        </div>
        <div class="col-4">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <p class="text-sm mb-0">Afp</p>
                    <div runat="server" id="DivAfpVer" visible="true">
                        <asp:Button ID="btnFPC_FS_Futuro" OnClick="btnFPC_FS_Futuro_Click" CssClass="btn bg-gradient-red" Text="FPC Fondo Solidario FUTURO"  runat="server"/>
                        <asp:Button ID="btnFPC_Futuro" OnClick="btnFPC_Futuro_Click" CssClass="btn bg-gradient-red" Text="FPC FUTURO"  runat="server"/>
                    </div>
                    <div runat="server" id="DivAfpGenerar" visible="true">
                        <asp:Button ID="btnFPC_FS_Prevision"  OnClick="btnFPC_FS_Prevision_Click" CssClass="btn bg-blue" Text="FPC Fondo Solidario PREVISIÓN"  runat="server"/>
                        <asp:Button ID="btnFPC_Prevision"  OnClick="btnFPC_Prevision_Click" CssClass="btn bg-blue" Text="FPC PREVISIÓN"  runat="server"/>
                        <asp:Button ID="BtnConta" OnClick="BtnConta_Click" CssClass="btn bg-cyan" Text="REPORTE CONTABILIDAD"  runat="server"/>
                        <asp:Button ID="btnGesto" OnClick="btnGesto_Click" CssClass="btn bg-gradient-yellow" Text="FPC GESTORA PUBLICA" runat="server"/>
                    </div>
                </div>
            </div>
        </div>
        </div>
    </div>
    </div>
<%--                        </ContentTemplate>
                </asp:UpdatePanel>
    <asp:UpdateProgress AssociatedUpdatePanelID="PLANILLA" runat="server">
        <ProgressTemplate>
            <div class="load"></div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
</asp:Content>

