using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace robot_application_v1.DomainModelLayer.Contracts;

public interface IRepository<T> where T : class
{
    IQueryable<T?> FindAll();
    IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression); 
    Task<EntityEntry<T>> CreateAsync(T entity); 
    void Update(T entity); 
    void Delete(T entity);
}