using Microsoft.EntityFrameworkCore.ChangeTracking;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1.DomainModelLayer.Contracts;

public interface IExecutionRepository
{
    Task<IEnumerable<ExecutionRecord?>> GetAllExecutionRecordsAsync();
    Task<ExecutionRecord?> GetExecutionRecordByIdAsync(int id);
    Task<EntityEntry<ExecutionRecord>> CreateExecutionRecord(ExecutionRecord record);
    void UpdateExecutionRecord(ExecutionRecord record);
    void DeleteExecutionRecord(ExecutionRecord record);
    
}