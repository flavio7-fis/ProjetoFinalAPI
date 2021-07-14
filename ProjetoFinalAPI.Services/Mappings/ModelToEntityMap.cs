using AutoMapper;
using ProjetoFinalAPI.Domain.Entities;
using ProjetoFinalAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Services.Mappings
{
    public class ModelToEntityMap : Profile
    {
        public ModelToEntityMap()
        {
            //Cadastro de Empresa
            CreateMap<ProfissionalPostModel, Profissional>()
            .AfterMap((src, dest) =>
            {
                dest.IdProfissional = Guid.NewGuid();
            });
            //Edição de Empresa
            CreateMap<ProfissionalPutModel, Profissional>();
            //Cadastro de Funcionario
            CreateMap<ServicoPostModel, Servico>()
            .AfterMap((src, dest) =>
            {
                dest.IdServico = Guid.NewGuid();
            });
            //Edição de Funcionario
            CreateMap<ServicoPutModel, Servico>();
        }
    }
}
