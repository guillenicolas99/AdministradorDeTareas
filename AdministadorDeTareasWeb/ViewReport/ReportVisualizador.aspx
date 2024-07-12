<%@ Page Language="C#" Debug="true" AutoEventWireup="true" CodeBehind="ReportVisualizador.aspx.cs" Inherits="AdministadorDeTareasWeb.ViewReport.ReportVisualizador" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <title>Visor De Reporte</title>
    </head>
<body>
        <!--Encabezado del Visualizador-->
    <div class="row text-center">
        <div class="col-12">
            <h3 class="fw-bold">VISOR DE INFORMES</h3>
        </div>
    </div>

    <!--Boton Cerrar Ventana-->
    <div class="row mb-2 justify-content-center">
        <div class="col-2 d-grid">
            <button type="button" class="btn btn-danger" onclick="window.close()">
                Cerrar
            </button>
        </div>
    </div>

        <!--Visualizador De Reporte-->
    <form id="form1" runat="server" method="post" target="IframeReporte">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="ReportView"  runat="server" Width="100%" Font-Names="Verdana" Font-Size="8pt" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Height="900px"  ShowWaitControlCancelLink="False" SizeToReportContent="True"></rsweb:ReportViewer>
    </form>

    
<%--    <form id="form1" runat="server">
        <rsweb:ReportViewer ID="ReportView" runat="server" Width="100%"></rsweb:ReportViewer>
    </form>--%>
</body>
</html>
