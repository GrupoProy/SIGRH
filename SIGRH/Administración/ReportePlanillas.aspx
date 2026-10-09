<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReportePlanillas.aspx.cs" Inherits="Administración_ReportePlanillas" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

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
    <div class="container-fluid mt--6">
        <div class="card">
            <div class="card-header border-bottom">
                <div class="ct-page-title">
                    <h3 class="mb-0">Planilla de Haberes</h3>
                    <p class="text-sm mb-0">Seleccione el mes:</p>
                    <asp:DropDownList ID="ddlMesPlanilla" CssClass="form-control select2" AppendDataBoundItems="true" runat="server" />
                    <asp:RequiredFieldValidator CssClass="text-danger display-5" ErrorMessage="(*) Campo Obligatorio" ControlToValidate="ddlMesPlanilla" ValidationGroup="Baja_as" InitialValue="0" Display="Dynamic" runat="server" />
                </div>
            </div>
        </div>
    </div>

    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="100%" ShowParameterPrompts="False" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" ProcessingMode="Remote" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226">
        <ServerReport ReportPath="/ReportesUAP/Reporte_UAP_V3" ReportServerUrl="http://anthracis-desk/reportserver" />
    </rsweb:ReportViewer>    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server"></asp:ObjectDataSource>

        </div>
    </form>
</body>
</html>
