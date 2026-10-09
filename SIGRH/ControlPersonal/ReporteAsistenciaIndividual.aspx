<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageSIGRH.master" AutoEventWireup="true" CodeFile="ReporteAsistenciaIndividual.aspx.cs" Inherits="ControlPersonal_ReporteAsistenciaIndividual" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="header pb-6" style="margin-top:-4em; margin-left:3em; width:81%">
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

    <div class="container-fluid mt--6">
        <div class="row">

            <div class="col-lg-4">
                <div class="card">
                    <div class="card-header border-bottom">
                        <div class="ct-page-title">
                            <h3 class="mb-0">Fecha Inicial:</h3>
                            <asp:TextBox ID="txtFechaInicio" CssClass="form-control datepickerD" runat="server" />
                            <asp:RequiredFieldValidator CssClass="text-danger display-5"
                                ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFechaInicio"
                                ValidationGroup="planilla" Display="Dynamic" runat="server" />
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
                            <asp:RequiredFieldValidator CssClass="text-danger display-5"
                                ErrorMessage="(*) Campo Obligatorio" ControlToValidate="txtFechaFin"
                                ValidationGroup="planilla" Display="Dynamic" runat="server" />
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-lg-4">
                <div class="card-body text-left top--4">
                    <asp:LinkButton ID="BtnBuscar" CssClass="btn btn-primary"
                        Text="<i class='fas fa-search'></i> Ver Asistencia"
                        ValidationGroup="planilla" OnClick="BtnBuscar_Click" runat="server" />

                    <asp:LinkButton ID="BtnImprimir" CssClass="btn btn-success" Visible="false"
                        Text="<i class='fas fa-print'></i> Imprimir Reporte"
                        ValidationGroup="planilla" OnClick="BtnImprimir_Click" runat="server" />
                </div>
            </div>

        </div>

        <asp:Label ID="lblMensaje" CssClass="text-white font-weight-bold" runat="server" />

        <!-- GRILLA dentro de tarjeta blanca -->
        <asp:Panel ID="pnlGrilla" runat="server" Visible="false">
            <div class="card">
                <div class="card-header border-bottom">
                    <h3 class="mb-0">Detalle de asistencia</h3>
                </div>
                <div class="table-responsive">
                    <asp:GridView ID="gvAsistencia" runat="server"
                        CssClass="table table-striped table-hover align-items-center mb-0"
                        GridLines="None" AutoGenerateColumns="false"
                        HeaderStyle-CssClass="thead-light"
                        EmptyDataText="No hay registros en ese rango de fechas.">
                        <Columns>
                            <asp:BoundField DataField="att_fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="att_dia" HeaderText="Día" />
                            <asp:BoundField DataField="TIPO_HORARIO" HeaderText="Horario" />
                            <asp:BoundField DataField="ING1_TEXT" HeaderText="Ingreso 1" />
                            <asp:BoundField DataField="SAL1_TEXT" HeaderText="Salida 1" />
                            <asp:BoundField DataField="ING2_TEXT" HeaderText="Ingreso 2" />
                            <asp:BoundField DataField="SAL2_TEXT" HeaderText="Salida 2" />
                            <asp:BoundField DataField="TOTALMINATRASO" HeaderText="Min. atraso" ItemStyle-CssClass="text-center" HeaderStyle-CssClass="text-center" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </asp:Panel>

        <!-- REPORTE -->
        <asp:Panel ID="pnlReporte" runat="server" Visible="false">
            <div class="card">
                <div class="card-body">
                    <asp:LinkButton ID="BtnVolver" CssClass="btn btn-secondary mb-3"
                        Text="<i class='fas fa-arrow-left'></i> Volver a la grilla"
                        OnClick="BtnVolver_Click" CausesValidation="false" runat="server" />

                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" Height="800px"
                        AsyncRendering="false" SizeToReportContent="false"
                        ShowParameterPrompts="False" ShowBackButton="False"
                        ShowPrintButton="True" ShowExportControls="True" />
                </div>
            </div>
        </asp:Panel>

    </div>
</asp:Content>