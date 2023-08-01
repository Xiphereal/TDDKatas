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
	}

	public class Rover
	{
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
}