using Microsoft.EntityFrameworkCore;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1_tests.UnitTests.DbTests.Extensions;

public class RobotExecutionInMemoryContext : RobotExecutionContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        // DB path
        optionsBuilder.UseInMemoryDatabase("executionsDb");
    }
}