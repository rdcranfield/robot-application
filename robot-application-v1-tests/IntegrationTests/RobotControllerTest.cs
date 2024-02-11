using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using robot_application_v1;
using robot_application_v1_definitions.EndpointJson;
using robot_application_v1_definitions.Grid;
using Xunit;
using Assert = Xunit.Assert;

namespace robot_application_v1_tests.IntegrationTests;

public class RobotControllerTest : ControllerTest
{
    public RobotControllerTest(WebApplicationFactory<Startup> factory, RobotExecutionSeedFixture fixture) : base(factory, fixture)
    {
    }

    [Xunit.Theory]
    [InlineData("/tibber-developer-test/enter-path")] 
    public async Task Post_EndpointsReturnSuccessAndCorrectContentType(string endpoint)
    {
        var client = _factory.CreateClient();

        var instructions = new Instructions
        {
            Start = new Coordinate(10, 22),
            Commands = new List<Command>
            {
                new()
                {
                    Direction = "east",
                    Steps = 2
                },
                new()
                {
                    Direction = "north",
                    Steps = 1
                },
                new()
                {
                    Direction = "east",
                    Steps = 2
                },
                new()
                {
                    Direction = "north",
                    Steps = 2
                }
            }
        };
        
        var response = await client.PostAsJsonAsync(endpoint,
            instructions);

        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();

        Assert.NotNull(response.Content.Headers.ContentType);
        Assert.Equal("application/json; charset=utf-8",
            response.Content.Headers.ContentType.ToString());
        Assert.Contains("{\"ID\":1,\"Timestamp\":\"0001-01-01T00:00:00\",\"Commands\":4,\"Result\":8,", 
            responseContent );
    }
}