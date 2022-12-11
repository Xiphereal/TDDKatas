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
        public void Outcome_score_varies_depending_on_outcome(Outcome outcome, int score)
        {
            var sut = new OutcomeScoreCalculator
            {
                Outcome = outcome
            };

            sut.Score.Should().Be(score);
        }

        [Theory]
        [InlineData(Outcome.Loss, Shape.Rock, 1)]
        [InlineData(Outcome.Loss, Shape.Paper, 2)]
        [InlineData(Outcome.Loss, Shape.Scissors, 3)]
        [InlineData(Outcome.Draw, Shape.Rock, 4)]
        [InlineData(Outcome.Draw, Shape.Paper, 5)]
        [InlineData(Outcome.Draw, Shape.Scissors, 6)]
        [InlineData(Outcome.Win, Shape.Rock, 7)]
        [InlineData(Outcome.Win, Shape.Paper, 8)]
        [InlineData(Outcome.Win, Shape.Scissors, 9)]
        public void Round_score_is_the_score_of_the_shape_plus_the_round_outcome(Outcome outcome, Shape play, int score)
        {
            var sut = new RoundScoreCalculator
            {
                Outcome = outcome,
                Play = play,
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

        [Theory]
        [InlineData("A", Shape.Rock)]
        [InlineData("B", Shape.Paper)]
        [InlineData("C", Shape.Scissors)]
        public void Letter_to_shape_mapper(string letter, Shape shape)
        {
            new Letter(letter).ToShape().Should().Be(shape);
        }
    }
}