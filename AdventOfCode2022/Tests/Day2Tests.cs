using AdventOfCode2022.Day2;
using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day2Tests
    {
        public void Output_problem_solution_as_test_error()
        {
            Problem.Solve().Should().Be(0);
        }

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

        [Fact]
        public void Tournament_score_is_the_sum_of_all_rounds_scores()
        {
            var sut = new Tournament()
            {
                RoundsScores = new List<int>() { 1, 1 }
            };

            sut.Score.Should().Be(2);
        }

        [Theory]
        [InlineData("A", Shape.Rock)]
        [InlineData("B", Shape.Paper)]
        [InlineData("C", Shape.Scissors)]
        [InlineData("X", Shape.Rock)]
        [InlineData("Y", Shape.Paper)]
        [InlineData("Z", Shape.Scissors)]
        public void Letter_to_shape_mapper(string letter, Shape shape)
        {
            new Letter(letter).ToShape().Should().Be(shape);
        }

        [Fact]
        public void Example_input_for_strategy_guide()
        {
            var recommendations = new[]
            {
                "A Y",
                "B X",
                "C Z"
            };

            var sut = new StrategyGuide()
            {
                Recommendations = recommendations
            };

            sut.TournamentScore.Should().Be(15);
        }
    }
}