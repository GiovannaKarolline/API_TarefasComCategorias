using TarefasComCategorias.DTOs;
using TarefasComCategorias.Models;
using TarefasComCategorias.Repositories.Interfaces;
using TarefasComCategorias.Services.Interfaces;

namespace TarefasComCategorias.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<TarefaDto?> AtualizarTarefaAsync(Guid id, TarefaDto tarefa)
        {
            Tarefa? tarefaRegistrada = await _tarefaRepository.GetTarefaByIdAsync(id);

            Tarefa? resultadoAtualizar = null;

            if (tarefaRegistrada is not null)
            {
                tarefaRegistrada.CategoriaId = tarefa.CategoriaId;
                tarefaRegistrada.Concluida = tarefa.Concluida;
                tarefaRegistrada.Titulo = tarefa.Titulo;

                resultadoAtualizar = await _tarefaRepository.AtualizarTarefaAsync(tarefaRegistrada);
            }

            if(resultadoAtualizar is null)
            {
                return null;
            }

            return tarefa;
        }

        public async Task<TarefaDto?> CriarTarefaAsync(TarefaDto tarefa)
        {
            Tarefa novaTarefa = new Tarefa()
            {
                Titulo = tarefa.Titulo,
                CategoriaId = tarefa.CategoriaId,
                Concluida = tarefa.Concluida
            };

            if(novaTarefa is null)
            {
                return null;
            }
            
            await _tarefaRepository.CriarTarefaAsync(novaTarefa);

            return tarefa;
        }

        public async Task<IEnumerable<TarefaDto>> GetTarefasAsync()
        {
            IEnumerable<TarefaDto> tarefas = (await _tarefaRepository
                .GetTarefasAsync())
                .Select(tarefa =>
                    new TarefaDto()
                    {
                        CategoriaId = tarefa.CategoriaId,
                        Concluida = tarefa.Concluida,
                        Titulo = tarefa.Titulo
                    })
            .ToList();

            if (tarefas is null)
            {
                return new List<TarefaDto>();
            }

            return tarefas;
        }

        public async Task<TarefaDto?> GetTarefaByIdAsync(Guid id)
        {
            Tarefa? tarefa = await _tarefaRepository.GetTarefaByIdAsync(id);

            if(tarefa is null)
            {
                return null;
            }

            TarefaDto tarefaDto = new TarefaDto()
            {
                Titulo = tarefa.Titulo,
                CategoriaId = tarefa.CategoriaId,
                Concluida = tarefa.Concluida
            };

            return tarefaDto;
        }
    }
}
