using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entidade;
using Repositorio.DTOS;

namespace Servico.Interfaces
{
    public interface ITarefaServico
    {
        Task<TarefaDTO> GetTarefaByIdAsync(int id);
        Task<IEnumerable<TarefaDTO>> GetAllTarefasAsync();
        Task AddTarefa(TarefaDTO entity);
        Task UpdateTarefa(TarefaDTO entity);
        Task DeleteTarefa(TarefaDTO entity);
    }
}





