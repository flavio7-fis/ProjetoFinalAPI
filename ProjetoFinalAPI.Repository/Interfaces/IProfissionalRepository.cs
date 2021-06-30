using ProjetoFinalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinalAPI.Repository.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository<Profissional, Guid>
    {
        Profissional GetByCpf(string cpf);
    }
}
