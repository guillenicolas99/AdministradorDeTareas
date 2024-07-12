using AutoMapper;
using CapaDato.Models;
using CapaDto.DTO;
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
        private readonly AppDbContextContainer _context;
        private readonly TareaService _tareaService;
        private readonly CategoriaService _categoriaService;
        private readonly PrioridadService _prioridadService;
        private readonly EstadoService _estadoService;
        private readonly UsuarioService _usuarioService;

        public ReportVisualizador()
        {
            _context = new AppDbContextContainer();
            _tareaService = new TareaService(_context);
            _categoriaService = new CategoriaService(_context);
            _prioridadService = new PrioridadService(_context);
            _estadoService = new EstadoService(_context);
            _usuarioService = new UsuarioService(_context);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack) return;

            cargarReporte();
        }

        private void cargarReporte()
        {
            string urlRerport = $"~/Informes/{Request.QueryString["Reporte"]}";
            ReportView.ProcessingMode = ProcessingMode.Local;
            ReportView.LocalReport.DataSources.Clear();
            ReportView.LocalReport.ReportPath = Server.MapPath(urlRerport);

            List <ReportParameter> parameters = new List<ReportParameter>();

            switch (Request.QueryString["Reporte"])
            {
                case "RptTareas.rdlc":
                    {
                        var tareas = Mapper.Map<ICollection<TareaDto>>(_tareaService.GetAll());
                        var dataSrc = new ReportDataSource("Data", tareas);
                        ReportView.LocalReport.DataSources.Add(dataSrc);
                    }
                    break;

                case "RptCategorias.rdlc":
                    {
                        var categorias = Mapper.Map<ICollection<CategoriaDto>>(_categoriaService.GetAll());
                        var dataSrc = new ReportDataSource("Data", categorias);
                        ReportView.LocalReport.DataSources.Add(dataSrc);
                    }
                    break;

                case "RptPrioridades.rdlc":
                    {
                        var prioridades = _prioridadService.GetAll();
                        var dataSrc = new ReportDataSource("Data", prioridades);
                        ReportView.LocalReport.DataSources.Add(dataSrc);
                    }
                    break;

                case "RptEstados.rdlc":
                    {
                        var estados = _estadoService.GetAll();
                        var dataSrc = new ReportDataSource("Data", estados);
                        ReportView.LocalReport.DataSources.Add(dataSrc);
                    }
                    break;

                case "RptUsuarios.rdlc":
                    {
                        var usuarios = _usuarioService.GetAll();
                        var dataSrc = new ReportDataSource("Data", usuarios);
                        ReportView.LocalReport.DataSources.Add(dataSrc);
                    }
                    break;

                case "RptTareaEstado.rdlc":
                    {
                        var EstadoId = int.Parse(Request.Params["Tareas"]);
                        var tareasEstado = _tareaService.ObtenerTareasPorEstado(EstadoId);

                        var dataSrc = new ReportDataSource("Data", tareasEstado);
                        ReportView.LocalReport.DataSources.Add(dataSrc);
                    }break;

                case "RptTareaCategoria.rdlc":
                    {
                        var CategoriaId = int.Parse(Request.Params["Tareas"]);
                        var tareaCategoria = _tareaService.ObtenerTareasPorCategoria(CategoriaId);

                        var dataSrc = new ReportDataSource("Data", tareaCategoria);
                        ReportView.LocalReport.DataSources.Add(dataSrc);
                    }
                    break;

                case "RptTareaResponsable.rdlc":
                    {
                        var responsableId = int.Parse(Request.Params["Tareas"]);
                        var tareasResponsable = _tareaService.ObtenerTareasPorResponsable(responsableId);

                        var dataSrc = new ReportDataSource("Data", tareasResponsable);
                        ReportView.LocalReport.DataSources.Add(dataSrc);
                    }
                    break;

                default: break;
            }

                ReportView.LocalReport.SetParameters(parameters);
        }
    }
}