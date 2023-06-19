using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidade;

namespace Servico.Interfaces
{
    public interface ITarefaServico
    {
        Task<Tarefa> GetTarefaByIdAsync(int id);
        Task<IEnumerable<Tarefa>> GetAllTarefasAsync();
        Task AddTarefa(Tarefa entity);
        Task UpdateTarefa(Tarefa entity);
        Task DeleteTarefa(Tarefa entity);

    }
}





