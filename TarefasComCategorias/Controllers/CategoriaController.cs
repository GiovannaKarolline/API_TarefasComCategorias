using Microsoft.AspNetCore.Mvc;
using TarefasComCategorias.DTOs;
using TarefasComCategorias.Services.Interfaces;

namespace TarefasComCategorias.Controllers
{
    [ApiController]
    [Route("api/categorias")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategorias()
        {
            return Ok(await _categoriaService.GetCategoriasAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CriarCategoria(CategoriaDto categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CategoriaDto? resultadoCriacao = await _categoriaService.CriarCategoriaAsync(categoria);

            if(resultadoCriacao is null)
            {
                return BadRequest(ModelState);
            }

            return CreatedAtAction("CriarCategoria", categoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarCategoria(Guid id, CategoriaDto categoria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if ((await _categoriaService.GetCategoriaByIdAsync(id)) is null)
            {
                return NotFound();
            }

            CategoriaDto? resultadoAtualizacao = await _categoriaService.AtualizarCategoriaAsync(id, categoria);

            if (resultadoAtualizacao is null)
            {
                return BadRequest(ModelState);
            }

            return Ok(categoria);
        }
    }
}
