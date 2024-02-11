using System.Diagnostics;
using robot_application_v1_definitions;
using robot_application_v1_definitions.EndpointJson;
using robot_application_v1_definitions.Grid;
using robot_application_v1.DomainModelLayer.Entities;

namespace robot_application_v1.ApplicationLayer.Services
{
    public class RobotService
    {
        internal static ExecutionRecord ProcessInstructions(Instructions instructions)
        { 
            var grid = new Grid();
            var robotStartPosition = instructions.Start;
            var robot = new Robot(robotStartPosition!.X, robotStartPosition.Y);

            grid.AttachRobot(robot.GetX(), robot.GetY());
            
            var sw = Stopwatch.StartNew();
            
            foreach (var command in instructions.Commands!)
            {
                switch (command.Direction)
                {
                    case "east":
                    {
                        for (var i = 0; i< command.Steps; i++)
                        {
                            robot.IncrementX(1);
                            grid.ApplyMovement("X", robot.GetX(), -1);
                        }

                        break;
                    }
                    case "west":
                    {
                        for (var i = 0; i< command.Steps; i++)
                        {
                            robot.DecrementX(1);
                            grid.ApplyMovement("X", robot.GetX(), 1);
                        }

                        break;
                    }
                    case "north":
                    {
                        for (var i = 0; i< command.Steps; i++)
                        {
                            robot.IncrementY(1);
                            grid.ApplyMovement("Y", robot.GetY(), -1);
                        }

                        break;
                    }
                    case "south":
                    {
                        for (var i = 0; i< command.Steps; i++)
                        {
                            robot.DecrementY(1);
                            grid.ApplyMovement("Y", robot.GetY(), 1);
                        }

                        break;
                    }
                }
            }

            var cleanedVertices = grid.CalculateUniqueMovement();
            
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            
            return new ExecutionRecord
            {
                Commands = instructions.Commands!.Count,
                Result = cleanedVertices,
                Duration = sw.Elapsed
            };
        }
    }
}

