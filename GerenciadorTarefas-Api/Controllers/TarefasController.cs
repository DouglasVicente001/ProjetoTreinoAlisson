using System.Linq;
using Entidade;
using Microsoft.AspNetCore.Mvc;
using Repositorio.DataContext;

namespace GerenciadorTarefas_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefasController : ControllerBase 
    {

        private readonly GerenciadorTarefasContext database;

        public TarefasController(GerenciadorTarefasContext database)
        {
            this.database = database;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var items = database.Tarefa.ToList();
            return Ok(items);
        }  

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var item = database.Tarefa.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return Ok(item);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Tarefa tarefa)
        {    
            
            tarefa.Descricao = tarefa.Descricao;
            tarefa.Titulo = tarefa.Titulo;
            tarefa.Status = tarefa.Status;

            database.Add(tarefa);
            database.SaveChanges();
            Response.StatusCode = 200;
            return new ObjectResult(tarefa);
            // return Ok(tarefa);
            // return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] Tarefa tarefa)
        {
            var itens = database.Tarefa.First(x => x.Id == tarefa.Id);
            itens.Id = tarefa.Id;
            itens.Titulo = tarefa.Titulo;
            itens.Descricao = tarefa.Descricao;
            itens.Status = tarefa.Status;
            database.SaveChanges();

            return Ok(itens);
            // return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var tarefa = database.Tarefa.FirstOrDefault(x => x.Id == id);

            if (tarefa == null)
                return NotFound();

            database.Tarefa.Remove(tarefa);
            database.SaveChanges();
            Response.StatusCode = 200;
            return Ok(tarefa);


        }
    }
}
