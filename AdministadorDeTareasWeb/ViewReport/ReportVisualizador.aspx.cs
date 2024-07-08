using CapaDato.Models;
using CapaOperaciones;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdministadorDeTareasWeb.ViewReport
{
    public partial class ReportVisualizador : System.Web.UI.Page
    {
        //private readonly AppDbContextContainer _context;
        //private readonly TareaService _tareaService;

        //public ReportVisualizador()
        //{
        //    _context = new AppDbContextContainer();
        //    _tareaService = new TareaService(_context);
        //}
        //protected void Page_Load(object sender, EventArgs e)
        //{
        //    if (IsPostBack) return;

        //    cargarReporte();
        //}

        //private void cargarReporte()
        //{
        //    string urlRerport = $"/Informes/{Request.QueryString["Reporte"]}";
        //    ReportView.ProcessingMode = ProcessingMode.Local;
        //    ReportView.LocalReport.DataSources.Clear();
        //    ReportView.LocalReport.ReportPath = Server.MapPath(urlRerport);

        //    List <ReportParameter> parameters = new List<ReportParameter>();
        //    parameters.Add(new ReportParameter("FechaActual", DateTime.Now.ToString()));

        //    switch (Request.QueryString["Reporte"])
        //    {
        //        case "RptTareas.rdlc":
        //            {
        //                var tareas = _tareaService.GetAll();
        //                var dataSrc = new ReportDataSource("Data", tareas);
        //                ReportView.LocalReport.DataSources.Add(dataSrc);
        //            }
        //            break;

        //        default: break;
        //    }

        //    ReportView.LocalReport.SetParameters(parameters);
        //}
    }
}