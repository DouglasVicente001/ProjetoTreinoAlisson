
using GerenciadorTarefas_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas_Api.Data
{
    public class GerenciadorTarefasContext : DbContext
    {
        public GerenciadorTarefasContext(DbContextOptions<GerenciadorTarefasContext> options) : base(options)
        {
            
        }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
