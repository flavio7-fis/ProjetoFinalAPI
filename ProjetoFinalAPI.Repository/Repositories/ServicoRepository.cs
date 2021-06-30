using ProjetoFinalAPI.Domain.Entities;
using ProjetoFinalAPI.Repository.Context;
using ProjetoFinalAPI.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjetoFinalAPI.Repository.Repositories
{
    public class ServicoRepository : BaseRepository<Servico, Guid>, IServicoRepository
    {
        private readonly SqlServerContext _context;
        //construtor para inicialização do atributo
        public ServicoRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
        public Servico GetByNome(string nome)
        {
            return _context.Servico.FirstOrDefault(s => s.Nome.Equals(nome));
        }
    }
}
