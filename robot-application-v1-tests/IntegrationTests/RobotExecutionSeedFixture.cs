using robot_application_v1_tests.UnitTests.DbTests.Extensions;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1_tests.IntegrationTests;

[TestFixture]
public class RobotExecutionSeedFixture: IDisposable
{
    internal RobotExecutionInMemoryContext ExecutionRecordContext { get; set; } = new();
    
    public RobotExecutionSeedFixture()
    {
        ExecutionRecordContext.Executions!.Add(new ExecutionRecord 
            {
                Id = 1234, 
                Timestamp = new DateTime(2018, 05, 12, 12, 45, 10),
                Commands = 2,
                Result = 4,
                Duration = new TimeSpan(0,0,0,0,0,123) 
            });
        ExecutionRecordContext.Executions.Add(new ExecutionRecord 
            {  
                Id = 1235, 
                Timestamp = new DateTime(2018, 05, 12, 12, 45, 10),
                Commands = 2,
                Result = 12,
                Duration = new TimeSpan(0,0,0,0,0,723)  
            });
        ExecutionRecordContext.Executions.Add(new ExecutionRecord 
            {  Id = 1236, 
                Timestamp = new DateTime(2018, 05, 12, 12, 45, 10),
                Commands = 52,
                Result = 140,
                Duration = new TimeSpan(0,0,0,0,1,123)
            });
        ExecutionRecordContext.SaveChanges();
    }

    public void Dispose()
    {
        ExecutionRecordContext.Dispose();
    }
}