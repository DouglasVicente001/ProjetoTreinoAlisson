


using Entidade;
using Microsoft.EntityFrameworkCore;

namespace Repositorio.DataContext
{
    public class GerenciadorTarefasContext : DbContext
    {
        public GerenciadorTarefasContext(DbContextOptions<GerenciadorTarefasContext> options) : base(options)
        {
            
        }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
