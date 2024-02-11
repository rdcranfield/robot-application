using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace robot_application_v1_definitions.Grid;

public class Coordinate(int x, int y)
{
    [Range(-100000,100000)]
    [JsonInclude][JsonPropertyName("x")] 
    public int X { get; set; } = x;

    [Range(-100000,100000, MinimumIsExclusive = true, MaximumIsExclusive = true)]
    [JsonInclude][JsonPropertyName("y")] 
    public int Y { get; set; } = y;
}