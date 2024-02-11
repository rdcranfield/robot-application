using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using robot_application_v1.DomainModelLayer.Contracts;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1.InfrastructureLayer.BusinessLogic.Repository;

public class ExecutionRepository : Repository<ExecutionRecord>, IExecutionRepository
{
    public ExecutionRepository(RobotExecutionContext context) : base(context)
    {
    }
    public async Task<IEnumerable<ExecutionRecord?>> GetAllExecutionRecordsAsync()
    {
        return await FindAll()
            .OrderBy(record => record!.Id).ToListAsync();
    }
    public async Task<ExecutionRecord?> GetExecutionRecordByIdAsync(int id)
    {
        return await FindByCondition(record => record.Id!.Equals(id)).FirstOrDefaultAsync();
    }
    public async Task<EntityEntry<ExecutionRecord>> CreateExecutionRecord(ExecutionRecord record)
    {
        return await CreateAsync(record);
    }
    public void UpdateExecutionRecord(ExecutionRecord record) => Update(record);

    public void DeleteExecutionRecord(ExecutionRecord record) => Delete(record);
}