using robot_application_v1.DomainModelLayer.Contracts;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1.ApplicationLayer.Services;

public class StoreService(IUnitOfWork unitOfWork)
{
    public async Task<int> AddRecord(ExecutionRecord record)
    {
        var id = await unitOfWork.ExecutionRepository.CreateExecutionRecord(record);
        await unitOfWork.CommitAsync();
        return id.Entity.Id;
    }
    
    public async Task<ExecutionRecord?> GetRecordById(int id)
    {
        return await unitOfWork.ExecutionRepository.GetExecutionRecordByIdAsync(id);
    }
}