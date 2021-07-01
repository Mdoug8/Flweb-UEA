using Flweb.Business.Interface;
using Flweb.Data.VO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Flweb.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Authorize("Bearer")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class AtualizacaoController : Controller
    {
        private readonly ILogger<AtualizacaoController> _logger;

        //declaracao do servico utilizado
        private IAtualizacaoBusiness _atualizacaoBusiness;

        public AtualizacaoController(ILogger<AtualizacaoController> logger, IAtualizacaoBusiness atualizacaoBusiness)
        {
            _logger = logger;
            _atualizacaoBusiness = atualizacaoBusiness;
        }


        [HttpGet]
        [ProducesResponseType((200), Type = typeof(List<AtualizacaoVO>))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindAll()
        {
            return Ok(_atualizacaoBusiness.FindAll());
        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(AtualizacaoVO))]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult FindById(long id)
        {
            var atualizacao = _atualizacaoBusiness.FindById(id);
            if (atualizacao == null) return NotFound();

            return Ok(atualizacao);
        }

        [HttpPost("salvar_atualizacao")]
        [ProducesResponseType((200), Type = typeof(AtualizacaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult salvarAtualizacao([FromBody] AtualizacaoVO atualizacao)
        {
            if (atualizacao == null)
            {
                return BadRequest();
            }
            return Ok(_atualizacaoBusiness.Create(atualizacao));
        }

        [HttpPut("alterar_atualizacao")]
        [ProducesResponseType((200), Type = typeof(AtualizacaoVO))]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult alterarAtualizacao([FromBody] AtualizacaoVO atualizacao)
        {
            if (atualizacao == null)
            {
                return BadRequest();
            }
            return Ok(_atualizacaoBusiness.Update(atualizacao));
        }

        [HttpDelete("delete/{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        public IActionResult Delete(long id)
        {
            if (_atualizacaoBusiness.FindById(id) != null)
            {
                _atualizacaoBusiness.Delete(id);
                return NoContent();
            }

            return NotFound();
            
        }
    }
}
