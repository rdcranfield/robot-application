using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using robot_application_v1.DomainModelLayer.Contracts;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1.InfrastructureLayer.BusinessLogic.Repository;

public class Repository<T>(RobotExecutionContext context) : IRepository<T>, IDisposable
    where T : class, IEntity
{
    public IQueryable<T?>  FindAll() => context.Set<T>();

    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
        context.Set<T>().Where(expression).AsNoTracking();

    public async Task<EntityEntry<T>> CreateAsync(T entity)
    {      
        return await context.Set<T>().AddAsync(entity);
    }

    public void Update(T entity) => context.Set<T>().Update(entity);

    public void Delete(T entity) => context.Set<T>().Remove(entity);

    public void Dispose() => context.Dispose();
}