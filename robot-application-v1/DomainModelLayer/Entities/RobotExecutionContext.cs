using Microsoft.EntityFrameworkCore;

namespace robot_application_v1.DomainModelLayer.Entities;

public class RobotExecutionContext : DbContext
{
    public RobotExecutionContext()
    { 
    }
    public RobotExecutionContext(DbContextOptions options) 
        : base(options) 
    { 
    }
    public DbSet<ExecutionRecord>? Executions { get; set; }
        
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExecutionRecord>()
            .HasKey(b => b.Id).HasName("PrimaryKey_Id");
    }
}