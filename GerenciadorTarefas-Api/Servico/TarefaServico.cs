using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidade;
using Microsoft.AspNetCore.Mvc;
using Repositorio;
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

        public async Task<IEnumerable<Tarefa>> GetAllTarefasAsync()
        {
            return await _tarefaRepositorio.GetAllAsync();
        }


        public async Task<Tarefa> GetTarefaByIdAsync(int id)
        {
            return await _tarefaRepositorio.GetByIdAsync(id);
        }

        public async Task AddTarefa([FromBody] Tarefa tarefa)
        {
            await _tarefaRepositorio.AddAsync(tarefa);
            await _tarefaRepositorio.SaveChangesAsync();
        }

        public async Task UpdateTarefa([FromBody] Tarefa tarefa)
        {
            var tarefaExistente = await _tarefaRepositorio.GetByIdAsync(tarefa.Id);

            if (tarefaExistente == null)
            {
                throw new InvalidOperationException("Tarefa não encontrada");
            }

            tarefaExistente.Titulo = tarefa.Titulo;
            tarefaExistente.Descricao = tarefa.Descricao;
            await _tarefaRepositorio.Update(tarefaExistente);
            await _tarefaRepositorio.SaveChangesAsync();
        }

        public async Task DeleteTarefa(Tarefa Tarefa)
        {
            _tarefaRepositorio.Delete(Tarefa);
            await _tarefaRepositorio.SaveChangesAsync();
        }
    }
}
