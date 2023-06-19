using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidade;
using Microsoft.AspNetCore.Mvc;
using Repositorio.Interfaces;

namespace Servico
{
    public class TarefaServico
    {
        public class TarefaService
        {
            private readonly IBaseRepository<Tarefa> _TarefaRepository;

            public TarefaService(IBaseRepository<Tarefa> TarefaRepository)
            {
                _TarefaRepository = TarefaRepository;
            }

            public async Task<IEnumerable<Tarefa>> GetAllTarefasAsync()
            {
                return await _TarefaRepository.GetAllAsync();
            }



            public async Task<Tarefa> GetTarefaByIdAsync(int id)
            {
                return await _TarefaRepository.GetByIdAsync(id);
            }


            public async Task<Tarefa> PostTarefaAsync([FromBody] Tarefa tarefa)
            {
                try
                {
                    tarefa.Descricao = tarefa.Descricao;
                    tarefa.Titulo = tarefa.Titulo;
                    tarefa.Status = tarefa.Status;

                    await _TarefaRepository.AddAsync(tarefa);
                    await _TarefaRepository.SaveChangesAsync();

                    return tarefa;
                }
                catch (Exception ex)
                {
                    throw new Exception("Ocorreu um erro ao adicionar a tarefa.", ex);
                }
            }


            public void UpdateTarefa(Tarefa Tarefa)
            {
                _TarefaRepository.Update(Tarefa);
            }

            public void DeleteTarefa(Tarefa Tarefa)
            {
                _TarefaRepository.Delete(Tarefa);
            }
        }

    }
}