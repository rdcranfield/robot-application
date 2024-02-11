using robot_application_v1_tests.UnitTests.DbTests.Extensions;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1_tests.UnitTests.DbTests
{
    public class SqlLiteContextUnitTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_ExecutionContext_ReturnStoredData()
        {
            using var context = new RobotExecutionSqlContext ();
            // clear and reset DB.
            context.Database.EnsureDeleted();

            // Create DB
            context.Database.EnsureCreated ();

            // Add execution records
            // Id auto-increments
            context.Add (new ExecutionRecord() {
                Timestamp = new DateTime(2018, 05, 12, 12, 45, 10),
                Commands = 2,
                Result = 4,
                Duration = new TimeSpan(0,0,0,0,0,123)
            });
                
            var aRecord = new ExecutionRecord
            {
                Timestamp = new DateTime(2018, 05, 12, 12, 45, 10),
                Commands = 12,
                Result = 4,
                Duration = new TimeSpan(0,0,0,0,0,153)
            };
            context.Executions!.Add (aRecord);
        
            //Commit changes
            context.SaveChanges();

            Assert.That(context.Executions!.ToList().Count, Is.EqualTo(2));

            // test remove
            var recordsByCondition = from v in context.Executions where v.Commands > 5
                select v;
            context.Executions.RemoveRange (recordsByCondition);
            context.SaveChanges ();
        
            Assert.That(context.Executions!.ToList().Count, Is.EqualTo(1));
            Assert.That(context.Executions!.Count(pair => pair.Commands>=5), Is.EqualTo(0));

            context.Dispose();
        }
    }
}