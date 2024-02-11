namespace robot_application_v1.DomainModelLayer.Contracts;

public interface IUnitOfWork : IDisposable
{
    void Commit();
    Task CommitAsync();
    void Rollback();
    IRepository<TEntity> GetRepository<TEntity>() where TEntity : class, IEntity;
    
    IExecutionRepository ExecutionRepository { get; }
}