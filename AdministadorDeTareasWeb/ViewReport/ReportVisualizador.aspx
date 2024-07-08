<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportVisualizador.aspx.cs" Inherits="AdministadorDeTareasWeb.ViewReport.ReportVisualizador" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <rsweb:ReportViewer ID="ReportView" runat="server" Width="100%"></rsweb:ReportViewer>
    </form>
</body>
</html>
