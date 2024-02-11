using Microsoft.EntityFrameworkCore;
using robot_application_v1.DomainModelLayer.Contracts;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1.InfrastructureLayer.BusinessLogic.Repository;


public class UnitOfWork(RobotExecutionContext context, IExecutionRepository executionRepository)
    : IUnitOfWork
{
    ~UnitOfWork()
    {
        Dispose(false);
    }
    
    private readonly Dictionary<Type, object> _repositories = new();

    public void Commit()
        => context.SaveChanges();
    
    public async Task CommitAsync()
        => await context.SaveChangesAsync();

    public void Rollback()
    {
         foreach (var entry in context.ChangeTracker.Entries())
         {
             entry.State = entry.State switch
             {
                 EntityState.Added => EntityState.Detached,
                 _ => entry.State
             };
         }
    }

    public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity
    {
        if (_repositories.ContainsKey(typeof(TEntity)))
        {
            return (IRepository<TEntity>)_repositories[typeof(TEntity)];
        }

        var repository = new Repository<TEntity>(context);
        _repositories.Add(typeof(TEntity), repository);
        return repository;
    }

    public IExecutionRepository ExecutionRepository { get; } = executionRepository;

    private bool _disposed;

    private void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                context.Dispose();
            }
        }
        _disposed = true;
    }
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}