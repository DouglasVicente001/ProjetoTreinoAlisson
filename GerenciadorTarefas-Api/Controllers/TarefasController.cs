using System.Linq;
using Entidade;
using Microsoft.AspNetCore.Mvc;
using Repositorio.DataContext;
using static Servico.TarefaServico;

namespace GerenciadorTarefas_Api.Controllers
{

    [ApiController]
    [Route("api/tarefa")]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaService _TarefaService;

        public TarefaController(TarefaService TarefaService)
        {
            _TarefaService = TarefaService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTarefas()
        {
            var Tarefas = await _TarefaService.GetAllTarefasAsync();
            return Ok(Tarefas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefaById(int id)
        {
            var Tarefa = await _TarefaService.GetTarefaByIdAsync(id);
            if (Tarefa == null)
                return NotFound();

            return Ok(Tarefa);
        }

        [HttpPost]
        public async Task<IActionResult> AddTarefa(Tarefa Tarefa)
        {
            await _TarefaService.PostTarefaAsync(Tarefa);
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateTarefa(Tarefa Tarefa)
        {
            _TarefaService.UpdateTarefa(Tarefa);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefaAsync(int id)
        {
            var Tarefa = await _TarefaService.GetTarefaByIdAsync(id);
            if (Tarefa == null)
                return NotFound();

            _TarefaService.DeleteTarefa(Tarefa);
            return Ok();
        }

        
    }
}
