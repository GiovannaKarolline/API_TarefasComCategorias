using TarefasComCategorias.DTOs;
using TarefasComCategorias.Models;
using TarefasComCategorias.Repositories.Interfaces;
using TarefasComCategorias.Services.Interfaces;

namespace TarefasComCategorias.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            _categoriaRepository = categoriaRepository;
        }

        public async Task<CategoriaDto?> AtualizarCategoriaAsync(Guid id, CategoriaDto categoria)
        {
            Categoria? categoriaRegistrada = await _categoriaRepository.GetCategoriaByIdAsync(id);

            Categoria? resultadoAtualizar = null;

            if (categoriaRegistrada is not null)
            {
                categoriaRegistrada.Titulo = categoria.Titulo;

                resultadoAtualizar = await _categoriaRepository.AtualizarCategoriaAsync(categoriaRegistrada);
            }

            if (resultadoAtualizar is null)
            {
                return null;
            }

            return categoria;
        }

        public async Task<CategoriaDto?> CriarCategoriaAsync(CategoriaDto categoria)
        {
            Categoria novaCategoria = new Categoria()
            {
                Titulo = categoria.Titulo
            };

            if (novaCategoria is null)
            {
                return null;
            }

            if((await _categoriaRepository.GetCategoriasAsync()).Any(categoriaRegistrada => categoriaRegistrada.Titulo == novaCategoria.Titulo))
            {
                return null;
            }
            
            await _categoriaRepository.CriarCategoriaAsync(novaCategoria);

            return categoria;
        }

        public async Task<IEnumerable<CategoriaDto>> GetCategoriasAsync()
        {
            IEnumerable<CategoriaDto> categorias = (await _categoriaRepository
                .GetCategoriasAsync())
                .Select(categoria =>
                    new CategoriaDto()
                    {
                        Titulo = categoria.Titulo
                    })
            .ToList();

            if (categorias is null)
            {
                return new List<CategoriaDto>();
            }

            return categorias;
        }

        public async Task<CategoriaDto?> GetCategoriaByIdAsync(Guid id)
        {
            Categoria? categoria = await _categoriaRepository.GetCategoriaByIdAsync(id);

            if (categoria is null)
            {
                return null;
            }

            CategoriaDto categoriaDto = new CategoriaDto()
            {
                Titulo = categoria.Titulo
            };

            return categoriaDto;
        }
    }
}
