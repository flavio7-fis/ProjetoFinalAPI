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
    public class ProfissionalController : ControllerBase
    {
        [HttpPost] //cadastro
        public IActionResult Post(ProfissionalPostModel model,
            [FromServices] IProfissionalRepository profissionalRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //verificando se o cnpj informado ja esta cadastrado no banco
                if (profissionalRepository.GetByCpf(model.Cpf) != null) 
                {
                    return UnprocessableEntity("O CPF já encontra-se cadastrado"); //442
                }
                var profissional = new Profissional();

                profissional = mapper.Map<Profissional>(model);
                profissionalRepository.Create(profissional);
                return Ok("Empresa cadastrada com sucesso");
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpPut] //atualização
        public IActionResult Put(ProfissionalPutModel model,
            [FromServices] IProfissionalRepository profissionalRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //buscando o profissional pelo id
                var profissional = profissionalRepository.GetById(model.IdProfissional);

                if (profissional == null)
                {
                    return UnprocessableEntity("Profissional não encontrado");
                }

                profissional = mapper.Map<Profissional>(model);
                profissionalRepository.Update(profissional);
                return Ok("Profissional atualziado com sucesso");
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpDelete("{idProfissional}")]
        public IActionResult Delete(Guid idProfissional, 
            [FromServices] IProfissionalRepository profissionalRepository)
        {
            try
            {
                var profissional = profissionalRepository.GetById(idProfissional);

                if (profissional == null)
                {
                    return UnprocessableEntity("Profissional não encontrado");
                }

                profissionalRepository.Delete(profissional);
                return Ok("Profissional excluído com sucesso");
            }
            catch (Exception e)
            {

                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet] //consultar todos profissionais
        public IActionResult GetAll(
            [FromServices] IProfissionalRepository profissionalRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //consultar todas as empresas no repositorio..
                var profissionais = profissionalRepository.GetAll();
                //verificar se algum registro foi encontrado..
                if (profissionais != null && profissionais.Count > 0)
                {
                    //utilizando o automapper para transferir
                    //os dados da entidade para a model..

                    var model = mapper.Map<List<ProfissionalGetModel>>(profissionais);

                    //retorno os dados
                    return Ok(model);

                }
                else
                {
                    //204 NoContent (Sucesso!)
                    return NoContent();

                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }

        [HttpGet("{idProfissional}")] //consultar o profissional por id
        public IActionResult GetById(Guid idProfissional,
            [FromServices] IProfissionalRepository profissionalRepository,
            [FromServices] IMapper mapper)
        {
            try
            {
                //consultar 1 empresa atraves do id..
                var profissional = profissionalRepository.GetById(idProfissional);
                //verificar se a empresa foi encontrada
                if (profissional != null)
                {
                    //transferir os dados da entidade empresa para a model
                    var model = mapper.Map<ProfissionalGetModel>(profissional);
                    //retorno os dados
                    return Ok(model);

                }
                else
                {
                    return NoContent(); //HTTP 204
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}
