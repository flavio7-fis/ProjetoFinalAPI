using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Services.Models
{
    public class ServicoGetModel
    {
        public Guid IdServico { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public ProfissionalGetModel Profissional { get; set; }
    }
}
