using AutoMapper;
using CapaDato.Models;
using CapaDto.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdministadorDeTareasWeb.AutoMapperProfile
{
    public class MapperAdministradorTareasWeb: Profile
    {
        public MapperAdministradorTareasWeb()
        {
            CreateMap<Tarea, TareaDto>();
        }
    }
}