using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoFinalAPI.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfissionalController : ControllerBase
    {
        [HttpPost] //cadastro
        public IActionResult Post(ProfissionalPostModel model)
        {
            return Ok();
        }

        [HttpPut] //atualização
        public IActionResult Put(ProfissionalPutModel model)
        {
            return Ok();
        }

        [HttpDelete("{idProfissional}")]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet] //consultar todos profissionais
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{idProfissional}")] //consultar o profissional por id
        public IActionResult GetById(Guid idProfissional)
        {
            return Ok();
        }
    }
}
