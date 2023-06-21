using System.Collections.Generic;
using System.Threading.Tasks;
using Repositorio.DTOS;
using System;
using System.Linq;
using System.Threading.Tasks;
using Entidade;
using Repositorio.DTOS;
using Repositorio.Interfaces;
using Servico.Interfaces;

namespace Servico
{
    public class TarefaServico : ITarefaServico
    {
        private readonly ITarefaRepositorio<Tarefa> _tarefaRepositorio;

        public TarefaServico(ITarefaRepositorio<Tarefa> tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        public async Task<IEnumerable<TarefaDTO>> GetAllTarefasAsync()
        {
            var tarefas = await _tarefaRepositorio.GetAllAsync();
            return tarefas.Select(TarefaDTO.ConvertToDTO);
        }

        public async Task<TarefaDTO> GetTarefaByIdAsync(int id)
        {
            var tarefa = await _tarefaRepositorio.GetByIdAsync(id);
            return TarefaDTO.ConvertToDTO(tarefa);
        }

        public async Task AddTarefa(TarefaDTO tarefaDTO)
        {
            var tarefa = TarefaDTO.ConvertToEntity(tarefaDTO);
            await _tarefaRepositorio.AddAsync(tarefa);
            await _tarefaRepositorio.SaveChangesAsync();
        }

        public async Task UpdateTarefa(TarefaDTO tarefaDTO)
        {
            var tarefaExistente = await _tarefaRepositorio.GetByIdAsync(tarefaDTO.Id);

            if (tarefaExistente == null)
            {
                throw new InvalidOperationException("Tarefa não encontrada");
            }

            tarefaExistente.Titulo = tarefaDTO.Titulo;
            tarefaExistente.Descricao = tarefaDTO.Descricao;

            await _tarefaRepositorio.SaveChangesAsync();
        }

        public async Task DeleteTarefa(TarefaDTO tarefaDTO)
        {
            var tarefa = await _tarefaRepositorio.GetByIdAsync(tarefaDTO.Id);

            if (tarefa == null)
            {
                throw new InvalidOperationException("Tarefa não encontrada");
            }

            await _tarefaRepositorio.Delete(tarefa);
            await _tarefaRepositorio.SaveChangesAsync();
        }
    }
}
