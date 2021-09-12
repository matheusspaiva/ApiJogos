using CatalogoJogos.InputModel;
using CatalogoJogos.Services;
using CatalogoJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogoJogos.Controllers.V1
{
    [Route("api/V1/[controller]")]
    [ApiController]
    public class JogoController : ControllerBase
    {
        private readonly IJogoService _IJogoService;
        
        public JogoController(IJogoService jogoService)
        {
            _IJogoService = jogoService;
        }
        [HttpGet]
        public async Task<ActionResult<List<JogoView>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina=1, [FromQuery, Range(1, 50)] int quantidade = 50)
        {

            var jogos = await _IJogoService.obter(pagina, quantidade);
            if (jogos.Count == 0)
                return NoContent();
            return Ok(jogos);
        }

        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogoView>> Obter([FromRoute]Guid idJogo)
        {
            var jogos = await _IJogoService.obter(idJogo);
            if (jogos == null)
                return NoContent();
            return Ok(jogos);
        }

        [HttpPost]
        public async Task<ActionResult<JogoView>> InserirJogo([FromBody] JogoInput jogo)
        {
            try
            {
                var result = await _IJogoService.Inserir(jogo);
                return Ok(result);
            }catch(Exception ex)
            {
                return UnprocessableEntity("Já existe uma produtora com esse nome");
            }
        }

        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute]Guid idJogo, [FromBody] JogoInput Jogo)
        {
            try
            {
                await _IJogoService.Atualizar(idJogo, Jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("não existe esse jogo");
            }
        }

        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizarJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _IJogoService.Atualizar(idJogo, preco);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Já existe uma produtora com esse nome");
            }
        }

        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> DeletarJogo([FromRoute]Guid idJogo)
        {
            try
            {
                await _IJogoService.Remover(idJogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound("Já existe uma produtora com esse nome");
            }
        }
    }

}
