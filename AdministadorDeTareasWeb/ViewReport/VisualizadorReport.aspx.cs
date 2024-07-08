using AutoMapper;
using CapaDato.Models;
using CapaDto.DTO;
using CapaOperaciones;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdministadorDeTareasWeb.ViewReport
{
    public partial class VisualizadorReport : System.Web.UI.Page
    {
        private readonly AppDbContextContainer _context;
        private readonly TareaService _tareaService;
        private readonly CategoriaService _categoriaService;
        private readonly PrioridadService _prioridadService;


        public VisualizadorReport()
        {
            _context = new AppDbContextContainer();
            _tareaService = new TareaService(_context);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)return;

            CargarReporte();
        }

        private void CargarReporte()
        {
            //Reporte = "RptTareas.rdlc" - Ejemplo
            string urlReport = "~/Informes/" + Request.QueryString["Reporte"];
            ReportView.ProcessingMode = ProcessingMode.Local;
            ReportView.LocalReport.DataSources.Clear();
            ReportView.LocalReport.ReportPath = Server.MapPath(urlReport);

            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("Fecha Actual", DateTime.Now.ToString("dd-MM-yyyy")));
           
            
            
            //Lista de Reportes
            switch (Request.QueryString["Reporte"])
            {   
                //Primer Reporte
                case "RptTarea.rdlc":
                    {
                        var tareas = Mapper.Map <ICollection <TareaDto>>(_tareaService.GetAll());
                        //Nota: El elemento "Data" tiene que ser el mismo que esta en Carpeta Informes
                        //Pestaña de Conjunto de Datos, si lo tienes con otro nombre pues esa ese nombre aquí.
                        var conjuntoDatos = new ReportDataSource("Data", tareas);
                        ReportView.LocalReport.DataSources.Add(conjuntoDatos); 
                    }break;
                //Segundo Reporte
                case "RptCategoria":
                    {
                        var categorias = Mapper.Map<ICollection<CategoriaDto>>(_categoriaService.GetAll());
                        var conjuntoDatos = new ReportDataSource("Data", categorias);
                    }break;

                case "RptPrioridad":
                    {
                        var prioridades = Mapper.Map<ICollection<PrioridadDto>>(_prioridadService.GetAll());
                        var conjuntoDatos = new ReportDataSource("Data", prioridades);
                    }
                    break;
                default:
                    break;
                    
            }
            ReportView.LocalReport.SetParameters(parameters);
            //TareaReport.LocalReport.Refresh();
        }
    }
}