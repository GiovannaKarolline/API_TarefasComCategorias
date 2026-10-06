using Microsoft.AspNetCore.Mvc;
using TarefasComCategorias.DTOs;
using TarefasComCategorias.Services.Interfaces;

namespace TarefasComCategorias.Controllers
{
    [ApiController]
    [Route("api/tarefas")]
    public class TarefaController : Controller
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTarefas()
        {
            List<TarefaDto> tarefas = (await _tarefaService.GetTarefasAsync()).ToList();

            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> CriarTarefa(TarefaDto tarefa)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            TarefaDto resultadoCriacao = await _tarefaService.CriarTarefaAsync(tarefa);

            if (resultadoCriacao is null)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction("CriarTarefa", resultadoCriacao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarTarefa( [FromRoute] Guid id, TarefaDto tarefa)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest(ModelState);
            }

            if((await _tarefaService.GetTarefaByIdAsync(id)) is null)
            {
                return NotFound();
            }

            TarefaDto? resultadoAtualizacao = await _tarefaService.AtualizarTarefaAsync(id, tarefa);

            if(resultadoAtualizacao is null)
            {
                return BadRequest(ModelState);
            }

            return Ok(tarefa);
        }
    }
}
