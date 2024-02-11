using robot_application_v1_tests.IntegrationTests;
using robot_application_v1.DomainModelLayer.Contracts;
using robot_application_v1.InfrastructureLayer.BusinessLogic.Repository;
using Xunit;
using Assert = Xunit.Assert;

namespace robot_application_v1_tests.UnitTests.DbTests;

public class ExecutionRepositoryUnitTests(RobotExecutionSeedFixture? fixture) : IClassFixture<RobotExecutionSeedFixture>
{
    private IExecutionRepository? _repository;
    private RobotExecutionSeedFixture? Fixture { get; } = fixture;


    [Fact]
    public async Task GetAll_WhenCalled_ReturnsAllItems()
    {
        _repository = new ExecutionRepository(Fixture!.ExecutionRecordContext);

        var results = await _repository.GetAllExecutionRecordsAsync();

        Assert.Equal(3, results.Count());
        await Fixture!.ExecutionRecordContext.DisposeAsync();
    }
}