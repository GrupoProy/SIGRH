<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Reporte_POAI.aspx.cs" Title="Reporte POAI" Inherits="ManualPuestos_Reportes_Default" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="icon" href="../../Content/MDP/img/brand/favicon1.png" type="image/png" />
    <title>Reporte POAI</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <div>
        </div>
        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="800px"  Width="100%" ShowParameterPrompts="False" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
        </rsweb:ReportViewer>
    </form>
</body>
</html>
