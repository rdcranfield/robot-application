using Microsoft.EntityFrameworkCore;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1_tests.UnitTests.DbTests.Extensions;

public class RobotExecutionSqlContext : RobotExecutionContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
        // DB path
        optionsBuilder.UseSqlite("Filename=./executionsDb.sqlite");
    }
}