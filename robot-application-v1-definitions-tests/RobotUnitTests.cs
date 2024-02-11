using robot_application_v1_definitions;
using robot_application_v1_definitions.Grid;
using Assert = Xunit.Assert;

namespace robot_application_v1_definitions_tests;

public class RobotUnitTests
{
    private Robot? _robot;
    [SetUp]
    public void Setup()
    {
        _robot = new Robot(10, 22);
    }

    [Test]
    public void Test_Methods_ReturnCorrectCoordinates()
    {
        _robot!.DecrementX(3);
        _robot!.DecrementY(1);

        Assert.Equal(7, _robot.GetX());
        Assert.Equal(21, _robot.GetY());

        _robot!.IncrementX(25);
        _robot!.IncrementY(1000);
        
        Assert.Equal(32, _robot.GetX());
        Assert.Equal(1021, _robot.GetY());
    }
}