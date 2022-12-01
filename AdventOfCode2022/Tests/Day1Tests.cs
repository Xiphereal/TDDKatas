using AdventOfCode2022.Day1;
using FluentAssertions;
using Xunit;

namespace AdventOfCode2022.Tests
{
    public class Day1Tests
    {
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

            HighestCaloriesFinder.Find(highestCarrier, other).Should().Be(highestCarrier);
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

            HighestCaloriesFinder.Find(highestCarrier, other).Should().Be(highestCarrier);
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

            HighestCaloriesFinder.Find(firstElf, secondElf).Should().Be(firstElf);
        }
    }
}