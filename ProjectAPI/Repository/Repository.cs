using Microsoft.EntityFrameworkCore;
using ProjectAPI.Interfaces;
using ProjectAPI.Models;

namespace ProjectAPI.Repository;

public class Repository<T> : IRepository<T> where T : class
{
    private RepositoryPatternContext _dbContext { get; set; }
    DbSet<T> _dbSet;
    public Repository(RepositoryPatternContext dbContext)
    {
        _dbSet = dbContext.Set<T>();
        _dbContext = dbContext;
    }
    public void Add(T entity)
    {
        _dbSet.Add(entity);
        _dbContext.SaveChanges();
    }
    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
        _dbContext.SaveChanges();
    }
    public void Update(T entity)
    {
        _dbSet.Update(entity);
        _dbContext.SaveChanges();
    }
    public IEnumerable<T> GetAll() => _dbSet.ToList();
    public T GetById(int id) => _dbSet.Find(id);
}