using System.Text.Json.Serialization;
using robot_application_v1_definitions.Grid;

namespace robot_application_v1_definitions.EndpointJson
{
    public class Instructions
    {
        [JsonInclude][JsonPropertyName("start")] 
        public Coordinate? Start { get; set; } 
    
        [JsonInclude][JsonPropertyName("commands")] 
        
        public List<Command>? Commands { get; set; } 
    }
}

