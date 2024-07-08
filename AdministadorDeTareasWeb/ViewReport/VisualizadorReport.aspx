<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VisualizadorReport.aspx.cs" Inherits="AdministadorDeTareasWeb.ViewReport.VisualizadorReport" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h1 style="text-align: center; background-color: green; color: white;">Visualizador de Reportes</h1>
        <div>
            <rsweb:ReportViewer ID="ReportView" runat="server" Height="100%" Width="100%"></rsweb:ReportViewer>
        </div>
    </form>
</body>
</html>
