using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace robot_application_v1_definitions.EndpointJson
{
    public class Command
    {
        [JsonInclude][JsonPropertyName("direction")] 
        public string? Direction { get; set; } 
    
        [Range(1,100000)]
        [JsonInclude][JsonPropertyName("steps")] 
        public int Steps { get; set; } 
    }
}

