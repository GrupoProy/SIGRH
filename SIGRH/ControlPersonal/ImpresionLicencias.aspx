<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ImpresionLicencias.aspx.cs" Inherits="ControlPersonal_ImpresionLicencias" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Impresión de Licencias</title>
    <style type="text/css">
        html, body, form {
            width: 100%;
            height: 100%;
            margin: 0;
            padding: 0;
            overflow: auto;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>

        <div style="width: 100%; height: 100%;">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Height="100%" Width="100%" 
                AsyncRendering="false" SizeToReportContent="true"
                ShowParameterPrompts="False" ShowBackButton="True" ShowPrintButton="True" ShowExportControls="True">
            </rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
