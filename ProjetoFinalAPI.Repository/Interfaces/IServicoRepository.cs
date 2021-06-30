using ProjetoFinalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinalAPI.Repository.Interfaces
{
    public interface IServicoRepository : IBaseRepository<Servico, Guid>
    {
        Servico GetByNome(string nome);
    }
}
