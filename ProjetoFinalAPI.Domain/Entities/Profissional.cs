using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinalAPI.Domain.Entities
{
    public class Profissional
    {
        public Guid IdProfissional { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public List<Servico> Servicos { get; set; }
    }
}
