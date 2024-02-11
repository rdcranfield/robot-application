using Microsoft.AspNetCore.Mvc;
using robot_application_v1_definitions.EndpointJson;
using robot_application_v1.ApplicationLayer.Services;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1.ApplicationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController(ILogger<RobotController> logger, StoreService? storeService)
        : ControllerBase
    {
        [HttpPost]
        [Route("/tibber-developer-test/enter-path")]
        public async Task<ExecutionRecord?> EnterPath([FromBody] Instructions instructions)
        {
            if (instructions.Commands == null || instructions.Start == null) return new ExecutionRecord();
            
            var robotTask = RobotService.ProcessInstructions(instructions);
            
            var id = await storeService!.AddRecord(robotTask);
            var result = await storeService.GetRecordById(id);
            
            logger.LogInformation("result {result}", result!.ToString());
            
            return result;
        }
    }
}

