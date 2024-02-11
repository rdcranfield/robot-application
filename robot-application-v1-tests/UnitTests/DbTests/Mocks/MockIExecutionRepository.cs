using Moq;
using robot_application_v1.DomainModelLayer.Contracts;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1_tests.UnitTests.DbTests.Mocks;

internal abstract class MockIExecutionRepository
{
    public static Mock<IExecutionRepository>? GetMock()
    {
        var mock = new Mock<IExecutionRepository>();
        var records = new List<ExecutionRecord>()
        {
            new()
            {
                Id = 1234, 
                Timestamp = new DateTime(2018, 05, 12, 12, 45, 10),
                Commands = 2,
                Result = 4,
                Duration = new TimeSpan(0,0,0,0,0,123) 
            },
            new()
            {  
                Id = 1235, 
                Timestamp = new DateTime(2018, 05, 12, 12, 45, 10),
                Commands = 2,
                Result = 12,
                Duration = new TimeSpan(0,0,0,0,0,723)  
            },
            new()
            {  
                Id = 1236, 
                Timestamp = new DateTime(2018, 05, 12, 12, 45, 10),
                Commands = 52,
                Result = 140,
                Duration = new TimeSpan(0,0,0,0,1,123)
            }
        };
        mock.Setup(m => m.GetAllExecutionRecordsAsync().Result).Returns(() => records);

        mock.Setup(m => m.GetExecutionRecordByIdAsync(It.IsAny<int>()).Result)
            .Returns((int id) => records.FirstOrDefault(o => o.Id == id));

        mock.Setup(m => m.CreateExecutionRecord(It.IsAny<ExecutionRecord>()))
            .Callback(() => {return; });

        mock.Setup(m => m.UpdateExecutionRecord(It.IsAny<ExecutionRecord>()))
            .Callback(() => { });

        mock.Setup(m => m.DeleteExecutionRecord(It.IsAny<ExecutionRecord>()))
            .Callback(() => { });
        
        return mock;
    }
}