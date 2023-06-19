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

        public TarefaServico(ITarefaRepositorio<Tarefa> TarefaRepositorio)
        {
            _tarefaRepositorio = TarefaRepositorio;
        }

        public async Task<IEnumerable<Tarefa>> GetAllTarefasAsync()
        {
            return await _tarefaRepositorio.GetAllAsync();
        }


        public async Task<Tarefa> GetTarefaByIdAsync(int id)
        {
            return await _tarefaRepositorio.GetByIdAsync(id);
        }


        public async Task<Tarefa> AddTarefa(Tarefa tarefa)
        {
            try
            {
                _tarefaRepositorio.AddAsync(tarefa);
                await _tarefaRepositorio.SaveChangesAsync();

                return tarefa;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocorreu um erro ao adicionar a tarefa.", ex);
            }
        }


        public async Task UpdateTarefa(Tarefa Tarefa)
        {
            _tarefaRepositorio.Update(Tarefa);
            await _tarefaRepositorio.SaveChangesAsync();
        }

        public async Task DeleteTarefa(Tarefa Tarefa)
        {
            _tarefaRepositorio.Delete(Tarefa);
           await _tarefaRepositorio.SaveChangesAsync();
        }

        Task ITarefaServico.AddTarefa(Tarefa entity)
        {
            throw new NotImplementedException();
        }
    }

}
