using ProjetoFinalAPI.Domain.Entities;
using ProjetoFinalAPI.Repository.Context;
using ProjetoFinalAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoFinalAPI.Repository.Repositories
{
    public class ProfissionalRepository : BaseRepository<Profissional, Guid>, IProfissionalRepository
    {
        private readonly SqlServerContext _context;
        public ProfissionalRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Profissional GetByCpf(string cpf)
        {
            return _context.Profissional.FirstOrDefault(s => s.Cpf.Equals(cpf));
        }
    }
}
