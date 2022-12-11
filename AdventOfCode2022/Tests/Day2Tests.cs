using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day2Tests
    {
        [Fact]
        public void Rock_scores_1()
        {
            var sut = new ADSfasfd
            {
                Winner = Play.Rock
            };

            sut.Score.Should().Be(1);
        }

        [Fact]
        public void Paper_scores_2()
        {
            var sut = new ADSfasfd
            {
                Winner = Play.Paper
            };

            sut.Score.Should().Be(2);
        }

        [Fact]
        public void Scissors_scores_3()
        {
            var sut = new ADSfasfd
            {
                Winner = Play.Scissors
            };

            sut.Score.Should().Be(3);
        }
    }
}