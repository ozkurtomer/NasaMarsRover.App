using NasaMarsRover.Bussiness.Concrete;
using NasaMarsRover.Bussiness.Enums;
using System;
using System.Linq;

namespace NasaMarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxPoints = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            var startPositions = Console.ReadLine().Trim().Split(' ');

            Direction firstDirection = SetDirection(startPositions[2]);

            Ground firstGround = new Ground(maxPoints);
            MarsRover firstMarsRover = new MarsRover(firstGround, firstDirection,Convert.ToInt32(startPositions[0]), Convert.ToInt32(startPositions[1]));
            var firstMarsRoverRoad = Console.ReadLine().Trim().ToArray();
            firstMarsRover.Run(firstMarsRoverRoad);

        }

        public static Direction SetDirection(string item)
        {
            switch (item)
            {
                case "E":
                    return Direction.E;

                case "S":
                    return Direction.S;

                case "N":
                    return Direction.N;

                case "W":
                    return Direction.W;

                default:
                    return Direction.Empty;
            }
        }
    }
}
