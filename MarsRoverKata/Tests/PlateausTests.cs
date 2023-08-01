using FluentAssertions;
using System;
using Xunit;

namespace MarsRoverKata.Tests
{
	public class PlateausTests
	{
		[Fact]
		public void PlateauIs10x10()
		{
			var sut = new Plateau();

			sut.x.Should().Be(10);
			sut.y.Should().Be(10);
		}

		[Fact]
		public void LandRover_OnPlateauPosition()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);

			rover.LandAt(0, 0);

			rover.Position.Item1.Should().Be(0);
			rover.Position.Item2.Should().Be(0);
		}

		[Fact]
		public void MoveRover_Forward()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);

			rover.LandAt(0, 0);
			rover.MoveForward();

			rover.Position.Item1.Should().Be(0);
			rover.Position.Item2.Should().Be(1);
		}

		[Fact]
		public void CheckRoverOrientation()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);

			rover.LandAt(0, 0);

			rover.Orientation.Should().Be(CardinalPoint.North);
		}

        [Fact]
        public void RotateRight()
        {
            var plateau = new Plateau();
            var rover = new Rover(plateau);
            rover.LandAt(0, 0);

            rover.RotateRight();
            
            rover.Orientation.Should().Be(CardinalPoint.East);
        }
        
        [Fact]
        public void RotateLeft()
        {
            var plateau = new Plateau();
            var rover = new Rover(plateau);
            rover.LandAt(0, 0);

            rover.RotateLeft();
            
            rover.Orientation.Should().Be(CardinalPoint.West);
        }
        
        [Fact]
        public void TurnAround()
        {
            var plateau = new Plateau();
            var rover = new Rover(plateau);
            rover.LandAt(0, 0);

            rover.RotateLeft();
            rover.RotateLeft();

            rover.Orientation.Should().Be(CardinalPoint.South);
        }
	}

	public class Rover
	{
		public CardinalPoint Orientation { get; set; }
		public Tuple<int, int> Position;
		private readonly Plateau plateau;

		public Rover(Plateau plateau)
		{
			this.plateau = plateau;
		}

		public void LandAt(int i, int i1)
		{
			Position = new Tuple<int, int>(i, i1);
		}

		public void MoveForward()
		{
			Position = new Tuple<int, int>(Position.Item1, Position.Item2 + 1);
		}

        public void RotateRight()
        {
            Orientation = CardinalPoint.East;
        }

        public void RotateLeft()
        {
            switch(Orientation)
            {
                case CardinalPoint.North:
                    Orientation = CardinalPoint.West;
                    break;
                case CardinalPoint.West:
                    Orientation = CardinalPoint.South;
                    break;
            }
        }
    }

	public class Plateau
	{
		public readonly int x;
		public readonly int y;

		public Plateau()
		{
			x = 10;
			y = 10;
		}
	}

	public enum CardinalPoint
	{
		North,
        East,
        West,
        South
    }
}