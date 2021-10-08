using NasaMarsRover.Bussiness.Concrete;
using NasaMarsRover.Bussiness.Enums;
using System.Collections.Generic;
using System.Reflection;
using Xunit;

namespace NasaMarsNasaMarsRoverApp.UnitTest
{
    public class Tests
    {

        #region Static Test Member Data
        public static List<object[]> NasaMarsRoverAtTheTopNorthData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Direction.N, 3, 3, false },
            new object[] { new List<int> { 4, 4 }, Direction.N, 4, 4, false },
            new object[] { new List<int> { 5, 5 }, Direction.N, 5, 5, false },
            new object[] { new List<int> { 5, 5 }, Direction.N, 4, 3, true },
            new object[] { new List<int> { 5, 5 }, Direction.N, 1, 2, true }};

        public static List<object[]> NasaMarsRoverAtTheBottomSouthData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Direction.S, 0, 0, false },
            new object[] { new List<int> { 4, 4 }, Direction.S, 1, 0, false },
            new object[] { new List<int> { 5, 5 }, Direction.S, 5, 0, false },
            new object[] { new List<int> { 5, 5 }, Direction.S, 4, 1, true },
            new object[] { new List<int> { 5, 5 }, Direction.S, 5, 2, true }};


        public static List<object[]> NasaMarsRoverAtTheEndEastData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Direction.E, 3, 3, false },
            new object[] { new List<int> { 4, 4 }, Direction.E, 4, 4, false },
            new object[] { new List<int> { 5, 5 }, Direction.E, 5, 2, false },
            new object[] { new List<int> { 5, 5 }, Direction.E, 4, 1, true },
            new object[] { new List<int> { 5, 5 }, Direction.E, 3, 3, true }};

        public static List<object[]> NasaMarsRoverAtTheEndWestData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Direction.W, 0, 3, false },
            new object[] { new List<int> { 4, 4 }, Direction.W, 0, 4, false },
            new object[] { new List<int> { 5, 5 }, Direction.W, 0, 2, false },
            new object[] { new List<int> { 5, 5 }, Direction.W, 1, 1, true },
            new object[] { new List<int> { 5, 5 }, Direction.W, 3, 3, true }};

        public static List<object[]> TurnLeftData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Direction.W, 1, 3, Direction.S },
            new object[] { new List<int> { 4, 4 }, Direction.S, 3, 4, Direction.E },
            new object[] { new List<int> { 5, 5 }, Direction.E, 2, 2, Direction.N },
            new object[] { new List<int> { 6, 6 }, Direction.N, 1, 1, Direction.W},
            new object[] { new List<int> { 7, 7 }, Direction.W, 3, 3, Direction.S}};

        public static List<object[]> TurnRightData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Direction.W, 1, 3, Direction.N },
            new object[] { new List<int> { 4, 4 }, Direction.S, 3, 4, Direction.W },
            new object[] { new List<int> { 5, 5 }, Direction.E, 2, 2, Direction.S },
            new object[] { new List<int> { 6, 6 }, Direction.N, 1, 1, Direction.E},
            new object[] { new List<int> { 7, 7 }, Direction.W, 3, 3, Direction.N}};

        public static List<object[]> MoveData => new List<object[]>{
            new object[] { new List<int> { 3, 3 }, Direction.W, 1, 3,  new List<int> { 0, 3 } },
            new object[] { new List<int> { 4, 4 }, Direction.S, 3, 4,  new List<int> { 3, 3 } },
            new object[] { new List<int> { 5, 5 }, Direction.E, 2, 2,  new List<int> { 3, 2 } },
            new object[] { new List<int> { 6, 6 }, Direction.N, 1, 1,  new List<int> { 1, 2 }},
            new object[] { new List<int> { 7, 7 }, Direction.W, 3, 3,  new List<int> { 2, 3 }}};

        public static List<object[]> RunData => new List<object[]>{
        new object[] { new List<int> { 5, 5 }, Direction.N, 1, 2,"LMLMLMLMM",  "1 3 N"},
            new object[] { new List<int> { 5, 5 }, Direction.E, 3, 3, "MMRMMRMRRM", "5 1 E" }};



        #endregion

        [Theory]
        [MemberData(nameof(NasaMarsRoverAtTheTopNorthData))]
        public void DoesIsMoveable_ShouldNotMove_NasaMarsRoverAtTheTopNorth(int[] maxRange, Direction targetDirection, int xCoordinate, int yCoordinate, bool expected)
        {
            Ground ground = new Ground(maxRange);
            var result = typeof(MarsRover).GetMethod("IsInside", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new MarsRover(ground, targetDirection, xCoordinate, yCoordinate), null);
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(NasaMarsRoverAtTheBottomSouthData))]
        public void DoesIsMoveable_ShouldNotMove_NasaMarsRoverAtTheBottomSouth(int[] maxRange, Direction targetDirection, int xCoordinate, int yCoordinate, bool expected)
        {
            Ground ground = new Ground(maxRange);
            var result = typeof(MarsRover).GetMethod("IsInside", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new MarsRover(ground, targetDirection, xCoordinate, yCoordinate), null);
            Assert.Equal(result, expected);
        }


        [Theory]
        [MemberData(nameof(NasaMarsRoverAtTheEndEastData))]
        public void DoesIsMoveable_ShouldNotMove_NasaMarsRoverAtTheEndEast(int[] maxRange, Direction targetDirection, int xCoordinate, int yCoordinate, bool expected)
        {
            Ground ground = new Ground(maxRange);
            var result = typeof(MarsRover).GetMethod("IsInside", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new MarsRover(ground, targetDirection, xCoordinate, yCoordinate), null);
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(NasaMarsRoverAtTheEndWestData))]
        public void DoesIsMoveable_ShouldNotMove_NasaMarsRoverAtTheEndWest(int[] maxRange, Direction targetDirection, int xCoordinate, int yCoordinate, bool expected)
        {
            Ground ground = new Ground(maxRange);
            var result = typeof(MarsRover).GetMethod("IsInside", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(new MarsRover(ground, targetDirection, xCoordinate, yCoordinate), null);
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(TurnLeftData))]
        public void DoesTurnLeft_ShouldTurnLeft_Direction(int[] maxRange, Direction targetDirection, int xCoordinate, int yCoordinate, Direction expected)
        {
            Ground ground = new Ground(maxRange);
            MarsRover rover = new MarsRover(ground, targetDirection, xCoordinate, yCoordinate);
            typeof(MarsRover).GetMethod("Turn", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(rover, null);
            var result = rover.Target;
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(TurnRightData))]
        public void DoesTurnRight_ShouldTurnRight_Direction(int[] maxRange, Direction targetDirection, int xCoordinate, int yCoordinate, Direction expected)
        {
            Ground ground = new Ground(maxRange);
            MarsRover rover = new MarsRover(ground, targetDirection, xCoordinate, yCoordinate);
            typeof(MarsRover).GetMethod("Turn", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(rover, null);
            var result = rover.Target;
            Assert.Equal(result, expected);
        }


        [Theory]
        [MemberData(nameof(MoveData))]
        public void DoesMove_ShouldMove_GroundLocationCoordinatesData(int[] maxRange, Direction targetDirection, int xCoordinate, int yCoordinate, List<int> expected)
        {
            Ground ground = new Ground(maxRange);
            MarsRover rover = new MarsRover(ground, targetDirection, xCoordinate, yCoordinate);
            typeof(MarsRover).GetMethod("Move", BindingFlags.NonPublic | BindingFlags.Instance).Invoke(rover, null);
            var result = new List<int> { rover.X, rover.Y };
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(RunData))]
        public void DoesStartEngine_ShouldMoveRightPositionAndDirection_GroundLocationCoordinatesData(int[] maxRange, Direction targetDirection, int xCoordinate, int yCoordinate, char[] moves, string expected)
        {
            Ground ground = new Ground(maxRange);
            MarsRover rover = new MarsRover(ground, targetDirection, xCoordinate, yCoordinate);
            rover.Run(moves);
            var result = $"{rover.X}{rover.Y}{rover.Target}";
            Assert.Equal(result, expected);
        }
    }
}