using System.Collections.Generic;

namespace robot_application_v1_definitions.Grid
{
    public class AxisModel
    {
        private readonly bool _isDirected;
        public Dictionary<int, List<int>> Axis { get; } = new();

        public AxisModel(bool isDirected = true)
        {
            _isDirected = isDirected;
        }

        public void AddVertex(int vertex)
        {
            Axis[vertex] = new List<int>();
        }

        public void AddEdge(int source, int destination)
        {
            Axis[source].Add(destination);
            if(!_isDirected)
                Axis[destination].Add(source);
        }
    }
}

