using System.Linq;
using Entidade;
using Microsoft.AspNetCore.Mvc;
using Repositorio.DataContext;
using Servico;
using Servico.Interfaces;
using static Servico.TarefaServico;

namespace GerenciadorTarefas_Api.Controllers
{

    [ApiController]
    [Route("api/tarefa")]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaServico _tarefaServico;

        public TarefaController(ITarefaServico tarefaServico)
        {
            _tarefaServico = tarefaServico;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTarefas()
        {
            var tarefas = await _tarefaServico.GetAllTarefasAsync();
            return Ok(tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefaById(int id)
        {
            var tarefa = await _tarefaServico.GetTarefaByIdAsync(id);
            if (tarefa == null)
                return NotFound();

            return Ok(tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> AddTarefa(Tarefa tarefa)
        {
            await _tarefaServico.AddTarefa(tarefa);
            return Ok(tarefa);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateTarefa(Tarefa tarefa)
        {
            await _tarefaServico.UpdateTarefa(tarefa);
            return Ok(tarefa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaAsync(int id)
        {
            var tarefa = await _tarefaServico.GetTarefaByIdAsync(id);
            if (tarefa == null)
                return NotFound();

            await _tarefaServico.DeleteTarefa(tarefa);
            return Ok(tarefa);
        }
    }
}
