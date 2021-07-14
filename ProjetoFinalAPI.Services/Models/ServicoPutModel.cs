using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Services.Models
{
    public class ServicoPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do serviço")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição do serviço")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o valor do serviço")]
        public double Valor { get; set; }

        [Required(ErrorMessage = "Por favor, informe o profissional que presta este serviço")]
        public Guid IdProfissional { get; set; }
    }
}
