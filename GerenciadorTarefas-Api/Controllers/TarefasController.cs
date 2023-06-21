using Microsoft.AspNetCore.Mvc;
using Repositorio.DTOS;
using Servico.Interfaces;
using System;
using System.Threading.Tasks;

namespace GerenciadorTarefas_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaServico _tarefaServico;

        public TarefasController(ITarefaServico tarefaServico)
        {
            _tarefaServico = tarefaServico;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTarefaById(int id)
        {
            var tarefa = await _tarefaServico.GetTarefaByIdAsync(id);

            return Ok(tarefa);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTarefas()
        {
            var tarefas = await _tarefaServico.GetAllTarefasAsync();
            return Ok(tarefas);
        }

        [HttpPost]
        public async Task<IActionResult> AddTarefa(TarefaDTO tarefaDTO)
        {
            await _tarefaServico.AddTarefa(tarefaDTO);
            return Ok(tarefaDTO);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateTarefa(int id, TarefaDTO tarefaDTO)
        {
            await _tarefaServico.UpdateTarefa(tarefaDTO);
            return Ok(tarefaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTarefa(int id)
        {
            var tarefaDTO = await _tarefaServico.GetTarefaByIdAsync(id);
            {
                await _tarefaServico.DeleteTarefa(tarefaDTO);
                return Ok(tarefaDTO);
            }
        }
    }
}
