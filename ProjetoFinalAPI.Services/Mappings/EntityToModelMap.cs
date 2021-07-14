using AutoMapper;
using ProjetoFinalAPI.Domain.Entities;
using ProjetoFinalAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Services.Mappings
{
    public class EntityToModelMap : Profile
    {
        public EntityToModelMap()
        {
            CreateMap<Profissional, ProfissionalGetModel>();
            CreateMap<Servico, ServicoGetModel>();
        }
    }
}
