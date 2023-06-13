using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(ApiDbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Tarefa> Tarefa { get; set; }
    }
}