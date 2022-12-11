using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day2Tests
    {
        [Fact]
        public void Rock_scores_1()
        {
            var sut = new Scorer
            {
                Winner = Play.Rock
            };

            sut.Score.Should().Be(1);
        }

        [Fact]
        public void Paper_scores_2()
        {
            var sut = new Scorer
            {
                Winner = Play.Paper
            };

            sut.Score.Should().Be(2);
        }

        [Fact]
        public void Scissors_scores_3()
        {
            var sut = new Scorer
            {
                Winner = Play.Scissors
            };

            sut.Score.Should().Be(3);
        }

        [Theory]
        [InlineData(Play.Rock, Play.Paper)]
        [InlineData(Play.Paper, Play.Scissors)]
        [InlineData(Play.Scissors, Play.Rock)]
        public void Always_choose_winner_play(Play opponent, Play winner)
        {
            var sut = new PlaySelector
            {
                Opponent = opponent
            };

            sut.Me.Should().Be(winner);
        }
    }
}