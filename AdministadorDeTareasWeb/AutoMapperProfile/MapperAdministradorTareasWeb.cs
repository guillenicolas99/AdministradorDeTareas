using AutoMapper;
using CapaDato.Models;
using CapaDto.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AdministadorDeTareasWeb.AutoMapperProfile
{
    public class MapperAdministradorTareasWeb: Profile
    {
        public MapperAdministradorTareasWeb()
        {

            CreateMap<Tarea, TareaDto>()
                            .ForMember(dest => dest.Categorias, opts => opts.MapFrom(src => src.Categoria.Nombre))
                            .ForMember(dest => dest.Prioridades, opts => opts.MapFrom(src => src.Prioridad.Nombre))
                            .ForMember(dest => dest.Estados, opts => opts.MapFrom(src => src.Estado.Nombre))
                            .ForMember(dest => dest.UsuarioCreador, opts => opts.MapFrom(src => src.UsuarioPropietario.Nombre))
                            .ForMember(dest => dest.UsuarioAsignado, opts => opts.MapFrom(src => src.UsuarioAsignado.Nombre))
                            ;
            ;

        }
    }
}