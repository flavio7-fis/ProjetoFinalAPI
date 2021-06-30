using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Services.Models
{
    public class ProfissionalPostModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do profissional")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email do profissional")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o CPF do profissional")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone do profissional")]
        public string Telefone { get; set; }
    }
}
