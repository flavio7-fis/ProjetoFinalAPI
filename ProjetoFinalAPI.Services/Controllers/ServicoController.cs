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
    public class ServicoController : ControllerBase
    {
        [HttpPost] //cadastro
        public IActionResult Post(ServicoPostModel model)
        {
            return Ok();
        }

        [HttpPut] //atualização
        public IActionResult Put(ServicoPutModel model)
        {
            return Ok();
        }

        [HttpDelete("{idServico}")]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet] //consultar todos os serviços
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{idServico}")] //consultar o serviço por id
        public IActionResult GetById(Guid idServico)
        {
            return Ok();
        }
    }
}
