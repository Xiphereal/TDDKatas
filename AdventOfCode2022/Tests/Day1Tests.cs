using AdventOfCode2022.Day1;
using AdventOfCode2022.Day1.Model;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day1Tests
    {
        public void Output_problem_solution_as_test_error()
        {
            Problem.Solve().Should().Be(0);
        }

        [Fact]
        public void Total_number_of_calories_can_be_obtained()
        {
            Elf elf = new()
            {
                CarriedFood = new[] { 1 }
            };

            Expedition sut = new(elf);

            sut.SumOfCaloriesOfHighestCarrier.Should().Be(1);
        }

        [Fact]
        public void Elf_with_highest_caloric_food_is_selected()
        {
            Elf highestCarrier = new()
            {
                CarriedFood = new[] { 2 }
            };

            Elf other = new()
            {
                CarriedFood = new[] { 1 }
            };

            Expedition sut = new(highestCarrier, other);

            sut.SumOfCaloriesOfHighestCarrier.Should().Be(2);
        }

        [Fact]
        public void Sum_of_calories_is_taken_into_account()
        {
            Elf highestCarrier = new()
            {
                CarriedFood = new[] { 1, 1, 1 }
            };

            Elf other = new()
            {
                CarriedFood = new[] { 2 }
            };

            Expedition sut = new(highestCarrier, other);

            sut.SumOfCaloriesOfHighestCarrier.Should().Be(highestCarrier.CarriedFood.Sum());
        }

        [Fact]
        public void Given_equal_calories_the_first_elf_is_considered_the_highest_carrier()
        {
            Elf firstElf = new()
            {
                CarriedFood = new[] { 1 }
            };

            Elf secondElf = new()
            {
                CarriedFood = new[] { 1 }
            };

            Expedition sut = new(firstElf, secondElf);

            sut.SumOfCaloriesOfHighestCarrier.Should().Be(1);
        }

        [Fact]
        public void Convert_calories_grouped_by_elf_to_Elfs()
        {
            List<string> lines = new()
            {
                "1",
                "",
                "2",
                " ",
                "3"
            };

            new LinesToElfs(lines).Elfs.Should().BeEquivalentTo(new[]
            {
                new Elf(1),
                new Elf(2),
                new Elf(3)
            });
        }

        [Fact]
        public void Several_food_are_taken_into_account()
        {
            List<string> lines = new()
            {
                "1",
                "1",
                "",
                "2",
                " ",
                "3"
            };

            new LinesToElfs(lines).Elfs.Should().BeEquivalentTo(new[]
            {
                new Elf(1, 1),
                new Elf(2),
                new Elf(3)
            });
        }
    }
}