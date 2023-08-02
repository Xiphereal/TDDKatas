﻿using FluentAssertions;
using Xunit;

namespace MarsRoverKata.Tests;

public class ParserTests
{
	[Fact]
	public void alksjdf()
	{
		var otroDocmás = new Plateau(); 
		var doc = new Rover(otroDocmás);

		var sut = new Antenna(doc);
		sut.Receive('M');

		doc.Position.Should().Be((0, 1));
	}

    [Fact]
    public void asdfa()
    {
        var plateau = new Plateau();
        var rover = new Rover(plateau);

        var sut = new Antenna(rover);
        sut.Receive("RM");
        
        rover.Position.Should().Be((1,0));
    }
}