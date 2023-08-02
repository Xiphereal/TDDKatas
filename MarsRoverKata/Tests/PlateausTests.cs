using FluentAssertions;
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

			rover.Position.x.Should().Be(0);
			rover.Position.y.Should().Be(0);
		}

		[Fact]
		public void MoveRover_Forward()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);

			rover.LandAt(0, 0);
			rover.MoveForward();

			rover.Position.x.Should().Be(0);
			rover.Position.y.Should().Be(1);
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

		[Fact]
		public void RotateRightThenMoveForwards()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);
			rover.LandAt(0, 0);

			rover.RotateRight();
			rover.MoveForward();

			rover.Position.x.Should().Be(1);
			rover.Position.y.Should().Be(0);
		}

		[Fact]
		public void TurnAroundAndMoveForward()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);
			rover.LandAt(5, 5);

			rover.RotateRight();
			rover.RotateRight();
			rover.MoveForward();

			rover.Position.y.Should().Be(4);
			rover.Position.x.Should().Be(5);
		}

		[Fact]
		public void MoveForwardTwice()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);
			rover.LandAt(0, 0);

			rover.MoveForward();
			rover.MoveForward();

			rover.Position.Should().Be((0, 2));
		}

		[Fact]
		public void RotateWest_ThenMoveForwards()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);
			rover.LandAt(1, 1);

			rover.RotateLeft();
			rover.MoveForward();

			rover.Position.Should().Be((0, 1));
		}

        [Fact]
        public void Land_MoveLeft_ShouldBeOn()
        {
            var plateau = new Plateau();
            var rover = new Rover(plateau);
            rover.LandAt(0,0);

            rover.RotateLeft();
            rover.MoveForward();

            rover.Position.Should().Be((9, 0));
        }

		[Fact]
		public void PreviewPosition()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);
			rover.LandAt(0, 0);

			plateau.PreviewPosition((-1, 0)).Should().Be((9, 0));
		}

		[Fact]
		public void PreviewPosition2()
		{
			var plateau = new Plateau();
			var rover = new Rover(plateau);
			rover.LandAt(0, 0);

			plateau.PreviewPosition((0, -1)).Should().Be((0, 9));
		}
	}
}