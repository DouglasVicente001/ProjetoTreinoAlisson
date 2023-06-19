using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Repositorio.DataContext;
using Repositorio.Interfaces;

namespace Repositorio
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly GerenciadorTarefasContext _dbContext;

    public BaseRepository(GerenciadorTarefasContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<TEntity> GetByIdAsync(int id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }
     public async Task<bool> SaveChangesAsync()
    {
        return (await _dbContext.SaveChangesAsync()) > 0;
    }
}

}