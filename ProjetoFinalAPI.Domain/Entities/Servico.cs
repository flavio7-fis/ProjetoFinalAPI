using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetoFinalAPI.Domain.Entities
{
    public class Servico
    {
        public Guid IdServico { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public Guid IdProfissional { get; set; }
        #region Empresa

        public Profissional Profissional { get; set; }

        #endregion
    }
}
