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
            var Tarefas = await _tarefaServico.GetAllTarefasAsync();
            return Ok(Tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefaById(int id)
        {
            var Tarefa = await _tarefaServico.GetTarefaByIdAsync(id);
            if (Tarefa == null)
                return NotFound();

            return Ok(Tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> AddTarefa(Tarefa tarefa)
        {
            await _tarefaServico.AddTarefa(tarefa);
            return Ok(tarefa);
        }

        [HttpPut]
        public IActionResult UpdateTarefa(Tarefa Tarefa)
        {
            _tarefaServico.UpdateTarefa(Tarefa);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaAsync(int id)
        {
            var Tarefa = await _tarefaServico.GetTarefaByIdAsync(id);
            if (Tarefa == null)
                return NotFound();

            _tarefaServico.DeleteTarefa(Tarefa);
            return Ok();
        }

        
    }
}
