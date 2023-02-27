using System.Linq.Expressions;

namespace TheSecretSanta.Domain.Interfaces;

public interface IBaseRepository<T>
{
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveAsync();
}
