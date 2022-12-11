using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day2Tests
    {
        [Theory]
        [InlineData(Shape.Rock, 1)]
        [InlineData(Shape.Paper, 2)]
        [InlineData(Shape.Scissors, 3)]
        public void Play_score_varies_depending_on_shape(Shape shape, int score)
        {
            var sut = new PlayScoreCalculator
            {
                Play = shape
            };

            sut.Score.Should().Be(score);
        }

        [Theory]
        [InlineData(Outcome.Loss, 0)]
        [InlineData(Outcome.Draw, 3)]
        [InlineData(Outcome.Win, 6)]
        public void Round_score_varies_depending_on_outcome(Outcome outcome, int score)
        {
            var sut = new RoundScoreCalculator
            {
                Outcome = outcome
            };

            sut.Score.Should().Be(score);
        }

        [Theory]
        [InlineData(Shape.Rock, Shape.Paper)]
        [InlineData(Shape.Paper, Shape.Scissors)]
        [InlineData(Shape.Scissors, Shape.Rock)]
        public void Always_choose_winner_play(Shape opponent, Shape winner)
        {
            var sut = new PlaySelector
            {
                Opponent = opponent
            };

            sut.ShouldPlay.Should().Be(winner);
        }
    }
}