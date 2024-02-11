using Moq;
using robot_application_v1_tests.UnitTests.DbTests.Extensions;
using robot_application_v1.DomainModelLayer.Contracts;
using robot_application_v1.DomainModelLayer.Entities;
using robot_application_v1.InfrastructureLayer.BusinessLogic.Repository;

namespace robot_application_v1_tests.UnitTests.DbTests.Mocks;

internal abstract class MockIUnitOfWork
{
    public static Mock<IUnitOfWork> GetMock()
    {
        var mock = new Mock<IUnitOfWork>();
        var repoMock = MockIExecutionRepository.GetMock();

        
        mock.Setup(m => m.ExecutionRepository).Returns(() => repoMock!.Object);

        mock.Setup(m => m.CommitAsync()).Callback(() => { return; });

        return mock;
    }
}