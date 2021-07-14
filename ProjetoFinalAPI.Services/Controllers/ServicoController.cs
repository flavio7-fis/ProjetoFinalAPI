using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoFinalAPI.Domain.Entities;
using ProjetoFinalAPI.Repository.Interfaces;
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
        public IActionResult Post(ServicoPostModel model, 
            [FromServices] IServicoRepository servicoRepository,
            [FromServices] IProfissionalRepository profissionalRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                if (servicoRepository.GetByNome(model.Nome) != null)
                {
                    return UnprocessableEntity("Nome já cadastrado"); //422
                }
                if (profissionalRepository.GetById(model.IdProfissional) == null)
                {
                    return UnprocessableEntity("Profissional não encontrado.");
                }

                var servico = mapper.Map<Servico>(model);
                servicoRepository.Create(servico);

                return Ok("Serviço cadastrado com sucesso.");
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpPut] //atualização
        public IActionResult Put(ServicoPutModel model,
            [FromServices] IServicoRepository servicoRepository,
            [FromServices] IProfissionalRepository profissionalRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                var servico = servicoRepository.GetByNome(model.Nome);
                if (servico == null)
                    return UnprocessableEntity("Serviço não encontrado.");
                if (profissionalRepository.GetById(model.IdProfissional) == null)
                    return UnprocessableEntity("Profissional não encontrado.");

                servico = mapper.Map<Servico>(model);
                servicoRepository.Update(servico);
                return Ok("Serviço cadastrado com sucesso");
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpDelete("{idServico}")]
        public IActionResult Delete(string nome, 
            [FromServices] IServicoRepository servicoRepository)
        {
            try
            {

                var servico = servicoRepository.GetByNome(nome);
                if (servico == null)
                    return UnprocessableEntity
                    ("Serviço não encontrado.");

                servicoRepository.Delete(servico);
                return Ok("Serviço excluído com sucesso.");
            }
            catch(Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet] //consultar todos os serviços
        public IActionResult GetAll(
            [FromServices] IServicoRepository servicoRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //consultar todos os funcionarios no repositorio
                var servicos = servicoRepository.GetAll();
                //verificar se algum registro foi obtido..
                if (servicos != null && servicos.Count > 0)
                {
                    //transferir os dados dos funcionarios
                    //para a classe model atraves do automapper

                    var model = mapper.Map

                    <List<ServicoGetModel>>(servicos);
                    //retornar os dados
                    return Ok(model);
                }
                else
                {
                    return NoContent(); //HTTP 204 (vazio)
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet("{idServico}")] //consultar o serviço por id
        public IActionResult GetById(Guid idServico,
            [FromServices] IServicoRepository servicoRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //buscar 1 funcionario no banco de dados baseado no id..
                var funcionario = servicoRepository.GetById(idServico);
                //verificar se algum funcionario foi encontrado
                if (funcionario != null)
                {
                    //converter os dados do funcionario
                    //para o objeto model, atraves do automapper

                    var model = mapper.Map<ServicoGetModel>(funcionario);
                    //retornar os dados
                    return Ok(model);

                }
                else
                {
                    return NoContent(); //HTTP 204 (vazio)
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}
