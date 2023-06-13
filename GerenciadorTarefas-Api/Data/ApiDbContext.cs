using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorTarefas_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorTarefas_Api.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}
