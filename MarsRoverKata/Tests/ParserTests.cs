using FluentAssertions;
using Xunit;

namespace MarsRoverKata.Tests;

public class ParserTests
{
	[Fact]
	public void alksjdf()
	{
		var otroDocmás = new Plateau(); 
		var doc = new Rover(otroDocmás);

		var sut = new MissionControl(doc);
		sut.Order("M");

		doc.Position.Should().Be((0, 1));
	}
}