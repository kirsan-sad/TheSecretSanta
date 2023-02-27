using System.Linq.Expressions;
using TheSecretSanta.Domain.Interfaces;
using TheSecretSanta.Infrastructure.Data;

namespace TheSecretSanta.Infrastructure.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    private readonly InMemoryDbContext _context;

    public BaseRepository(InMemoryDbContext context)
    {
        _context = context;
    }

    public void Create(T entity) =>
        _context.Set<T>().Add(entity);

    public void Delete(T entity) =>
        _context.Set<T>().Remove(entity);

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
        _context.Set<T>().Where(expression);
    public void Update(T entity) =>
    _context.Set<T>().Update(entity);

    public async Task SaveAsync() =>
        await _context.SaveChangesAsync();
}
