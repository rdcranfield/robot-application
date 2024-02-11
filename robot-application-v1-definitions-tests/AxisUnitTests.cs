

using robot_application_v1_definitions.Grid;

namespace robot_application_v1_definitions_tests;

public class AxisUnitTests
{
    private AxisModel? _axis;

    [SetUp]
    public void Setup()
    {
        _axis = new AxisModel();
    }

    [Test]
    public void TestUniqueEntry()
    {
        // ensures we count only newly encountered vertices
        _axis!.AddVertex(1);
        _axis!.AddVertex(1);
        Assert.That(_axis.Axis.Count,  Is.EqualTo(1));
        
        _axis!.AddVertex(2);
        _axis!.AddEdge(1, 2);
        // test is directed
        Assert.That(_axis.Axis.Count(pair => pair.Value.Any()),  Is.EqualTo(1));

        // test is undirected
        const bool isDirected = false;
        _axis = new AxisModel(isDirected);
        _axis!.AddVertex(1);
        _axis!.AddVertex(2);
        _axis!.AddEdge(1, 2);
        Assert.That(_axis.Axis.Count(pair => pair.Value.Any()),  Is.Not.EqualTo(1));
    }
}