using NasaMarsRover.Bussiness.Concrete;
using NasaMarsRover.Bussiness.Enums;
using NasaMarsRover.Bussiness.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NasaMarsRover.App
{
    class Program
    {
        #region Static Method
        static void Main(string[] args)
        {
            Console.WriteLine("asdasdasd");
            Console.WriteLine("How many Mars Rover? (e.g 3, default 1)");
            var count = Console.ReadLine().TryToInt();
            var marsRoverCount = count > 1 ? count : 1;

            List<char[]> roads = new List<char[]>();
            List<MarsRover> roverList = new List<MarsRover>();

            Console.WriteLine("Ground size (e.g '5 5') : ");
            var maxPoints = Console.ReadLine().Trim().Split(' ').Select(int.Parse).ToArray();
            Ground ground = new Ground(maxPoints);

            for (int i = 0; i < marsRoverCount; i++)
            {
                Console.WriteLine($"{i + 1} Mars Rover Start position (e.g '1 2 N') : ");
                var startPositions = Console.ReadLine().Trim().Split(' ');
                Direction direction = SetDirection(startPositions[2]);
                roverList.Add(new MarsRover(ground, direction, Convert.ToInt32(startPositions[0]), Convert.ToInt32(startPositions[1])));

                Console.Write($"{i + 1} Mars Rover Road (e.g 'LMLMLMLMM') : ");
                roads.Add(Console.ReadLine().Trim().ToArray());
            }

            for (int i = 0; i < roverList.Count; i++)
            {
                roverList[i].Run(roads[i]);
            }

        }
        #endregion

        #region Methods
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
        #endregion
    }
}
