using FluentAssertions;
using Xunit;
using static ConfigureYourOwnWardrobe.Fitter;
using static ConfigureYourOwnWardrobe.WardrobeElementsBuilder;

namespace ConfigureYourOwnWardrobe.Tests
{
    public class Tests
    {
        private const int AvailableSpaceInCm = 250;

        [Fact]
        public void Only_wardrobe_elements_of_50cm_alone_exactly_fill_the_wall()
        {
            WithAnSpaceOf(AvailableSpaceInCm).AndAConfigurationOf(WardrobeElements().Of(50))
                .HowManyCombinationsWouldFitExactly()
                .Should().BeEquivalentTo($"{5} of {50}cm");
        }

        [Fact]
        public void Combinations_of_mix_of_an_element_with_another_one_exactly_fill_the_wall()
        {
            WithAnSpaceOf(AvailableSpaceInCm).AndAConfigurationOf(WardrobeElements().Of(50, 75))
                .HowManyCombinationsWouldFitExactly()
                .Should().BeEquivalentTo(new[]
                {
                    "5 of 50cm",
                    "2 of 75cm and 2 of 50cm",
                });
        }
    }
}