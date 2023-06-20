using Microsoft.EntityFrameworkCore;
using Repositorio.DataContext;
using Repositorio.Interfaces;

namespace Repositorio
{
    public class TarefaRepositorio<TEntity> : ITarefaRepositorio<TEntity> where TEntity : class
    {
        private readonly GerenciadorTarefasContext _context;

        public TarefaRepositorio(GerenciadorTarefasContext context)
        {
            _context = context;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}