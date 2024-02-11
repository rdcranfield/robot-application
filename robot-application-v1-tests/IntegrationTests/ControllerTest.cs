using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;using robot_application_v1;
using Xunit;

namespace robot_application_v1_tests.IntegrationTests;

public abstract class ControllerTest : IClassFixture<WebApplicationFactory<Startup>>, IClassFixture<RobotExecutionSeedFixture>, IDisposable
{
    protected readonly WebApplicationFactory<Startup> _factory;
    private readonly IConfiguration _configuration;
    private readonly RobotExecutionSeedFixture _fixture;

    protected ControllerTest(WebApplicationFactory<Startup> factory, RobotExecutionSeedFixture fixture)
    {
        _fixture = fixture;
        _configuration = InitConfiguration(); 
        var dbConnection = _configuration.GetConnectionString("DatabaseNames:RobotContext");

        _factory = factory.WithWebHostBuilder(builder =>
        {
            // replace the actual services with the mocked ones
            /*builder.ConfigureTestServices(
                services =>
                {
                    services.AddDbContext<RobotExecutionContext>(o => o.UseInMemoryDatabase(databaseName: dbConnection!));
                });*/
        });
    }
    
    
    private static IConfiguration InitConfiguration()
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.Development.json")
            .AddEnvironmentVariables() 
            .Build();
        return config;
    }
    
    public void Dispose()
    {
        _fixture.ExecutionRecordContext.Database.EnsureDeleted();
    }
}