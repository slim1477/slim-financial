

using Microsoft.EntityFrameworkCore;
using SlimFinancial.Application.IRepository;

namespace SlimFinancial.Infrastructure.Data.Repository.Common;

/// <summary>
/// Represents the blueprint for the application repository
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="context"></param>
/// <param name="dbset"></param>
public class SlimFinancialRepo<T>(DbContext context,DbSet<T> dbset) : IRepository<T> where T : class
{
    private readonly DbContext _context = context;
    private readonly DbSet<T> _dbSet = dbset;
    public void Create(T entity)
    {
       _dbSet.Add(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public IEnumerable<T> GetAll()
    {
       return  _dbSet.ToList();
    }

    public T GetById(int id)
    {
        return _dbSet.Find(id);
    }

    public void Update(T entity)
    {
       _context.Entry(entity).State = EntityState.Modified;
    }
}

