using Microsoft.Extensions.Logging;
using Moq;
using robot_application_v1_definitions.EndpointJson;
using robot_application_v1_definitions.Grid;
using robot_application_v1_tests.UnitTests.DbTests.Extensions;
using robot_application_v1_tests.UnitTests.DbTests.Mocks;
using robot_application_v1.ApplicationLayer.Controllers;
using robot_application_v1.ApplicationLayer.Services;
using robot_application_v1.DomainModelLayer.Contracts;
using robot_application_v1.DomainModelLayer.Entities;
using robot_application_v1.InfrastructureLayer.BusinessLogic.Repository;

namespace robot_application_v1_tests.UnitTests.ControllerTests;

public class RobotControllerTests
{
    private RobotController? _robotController;
    private StoreService? _store;

    [SetUp]
    public void Setup()
    {
        var unitOfWorkMock = MockIUnitOfWork.GetMock();
        var logger = new Mock<ILogger<RobotController>>().Object;
        _store = new StoreService(unitOfWorkMock.Object);
        _robotController = new RobotController(logger, _store);
    }
    [Test]
    public async Task ProcessInstructions_ControllerMethod_ReturnExecutionRecord1()
    {
        //test no instructions, ensure returns empty non null result 
        var result = await _robotController!.EnterPath(new Instructions());
        Assert.NotNull(result);
        Assert.IsInstanceOf(typeof(ExecutionRecord), result);
    }
}