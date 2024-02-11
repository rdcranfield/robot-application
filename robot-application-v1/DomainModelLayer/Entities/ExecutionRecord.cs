using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using robot_application_v1.DomainModelLayer.Contracts;

namespace robot_application_v1.DomainModelLayer.Entities
{
    [Table("executions")] 
    [PrimaryKey(nameof(Id))]
    public class ExecutionRecord : IEntity
    {
        [JsonInclude][JsonPropertyName("ID")] 
        public int Id { get; set;} 
    
        [JsonInclude][JsonPropertyName("Timestamp")] 
        public DateTime Timestamp { get; set; } 
    
        [JsonInclude][JsonPropertyName("Commands")] 
        public int Commands { get; set; } 
    
        [JsonInclude][JsonPropertyName("Result")] 
        public int Result { get; set; } 
    
        [JsonInclude][JsonPropertyName("Duration")] 
        public TimeSpan Duration { get; set; } 
    }
}

