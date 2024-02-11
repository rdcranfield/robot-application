using robot_application_v1_definitions;
using robot_application_v1_definitions.Grid;
using Assert = Xunit.Assert;

namespace robot_application_v1_definitions_tests;

public class GridUnitTests
{
    private Grid? _grid;
    [SetUp]
    public void Setup()
    {
        _grid = new Grid();
    }

    [Test]
    public void Test_GridMovement_ReturnUniqueEncounters()
    {
        Assert.NotNull(_grid!.OfficeGrid);
        
        // test no movement without robot being attached
        Assert.Equal(0,  _grid.CalculateUniqueMovement());
        
        // ensure movement registered when robot attached
        _grid.AttachRobot(20, 21);
        Assert.Equal(1,  _grid.CalculateUniqueMovement());

        const int steps = 5;
        var currentPosition = 20;
        // ensure movement registered when robot attached
        for (var i = 0; i < steps; i++)
        {
            currentPosition += 1;
            _grid.ApplyMovement("X", currentPosition, -1);
        }
       
        Assert.Equal(6,  _grid.CalculateUniqueMovement());

        // ensure no extra movements counted when returning on previous movements
        for (var i = 0; i < steps; i++)
        {
            currentPosition -= 1;
            _grid.ApplyMovement("X", currentPosition, 1);
        }
        Assert.Equal(6,  _grid.CalculateUniqueMovement());
    }
}