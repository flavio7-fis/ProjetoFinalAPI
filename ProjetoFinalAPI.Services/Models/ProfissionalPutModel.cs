using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Services.Models
{
    public class ProfissionalPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do profissional")]
        public Guid IdProfissional { get; set; }

        [Required(ErrorMessage = "Por favor, informe o email do profissional")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Por favor, informe o telefone do profissional")]
        public string Telefone { get; set; }
    }
}
