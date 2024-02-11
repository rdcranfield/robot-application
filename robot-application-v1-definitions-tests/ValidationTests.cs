using System.ComponentModel.DataAnnotations;
using robot_application_v1_definitions.EndpointJson;
using robot_application_v1_definitions.Grid;
using Xunit;
using Assert = Xunit.Assert;

namespace robot_application_v1_definitions_tests
{
    public class ValidationTests
    {
        [Xunit.Theory]
        [InlineData("east", 10000)]
        [InlineData("north", 100000)]
        [InlineData("east", 10000000, false)]
        public void Test_Steps_ReturnValidation(string? direction, int steps, bool isValid = true)
        {
            var command = new Command()
            {
                Direction = direction,
                Steps = steps
            };
            
            Assert.Equal(isValid, ValidateModel(command));
        }
        
        [Xunit.Theory]
        [InlineData(10000, 10000)]
        [InlineData(100000, 100000)]
        [InlineData(10000000, 10000000, false)]
        public void Test_Coordinates_ReturnValidation(int x, int y, bool isValid = true)
        {
            var coordinate = new Coordinate(x, y);
            
            Assert.Equal(isValid, ValidateModel(coordinate));
        }
    
        private bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }
    }
}

