namespace robot_application_v1_definitions.Grid;

public class Grid
{
    // include starting position towards total unique movements
    private int _uniqueMoves = 0;

    public Dictionary<string, AxisModel> OfficeGrid { get; } = new()
    {
        { "X", new AxisModel() },
        { "Y", new AxisModel() }
    };

    public void AttachRobot(int x, int y)
    {
        OfficeGrid["X"].AddVertex(x);
        OfficeGrid["Y"].AddVertex(y);
        _uniqueMoves = 1;
    }

    public void ApplyMovement(string key, int currentPosition, int movement)
    {
        OfficeGrid[key].AddVertex(currentPosition);
        OfficeGrid[key].AddEdge(currentPosition + movement, currentPosition);
    }

    public int CalculateUniqueMovement()
    {
        var result = _uniqueMoves + OfficeGrid["X"].Axis.Count(pair => pair.Value.Any()) + OfficeGrid["Y"].Axis.Count(pair => pair.Value.Any());
        _uniqueMoves = 1;
        return result;
    }
}