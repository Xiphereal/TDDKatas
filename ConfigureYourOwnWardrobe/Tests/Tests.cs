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
                .Should().BeEquivalentTo(new[]
                {
                    Combination.Of
                    (
                        new Part()
                        {
                             Element = new WardrobeElement(sizeInCm: 50),
                             Quantity = 5,
                        }
                    )
                });
        }

        [Fact]
        public void Combinations_of_mix_of_an_element_with_another_one_exactly_fill_the_wall()
        {
            WithAnSpaceOf(AvailableSpaceInCm).AndAConfigurationOf(WardrobeElements().Of(50, 75))
                .HowManyCombinationsWouldFitExactly()
                .Should().BeEquivalentTo(new[]
                {
                    Combination.Of
                    (
                        new Part()
                        {
                             Element = new WardrobeElement(sizeInCm: 50),
                             Quantity = 5,
                        }
                    ),
                    Combination.Of
                    (
                        new Part()
                        {
                             Element = new WardrobeElement(sizeInCm: 50),
                             Quantity = 2,
                        },
                        new Part()
                        {
                             Element = new WardrobeElement(sizeInCm: 75),
                             Quantity = 2,
                        }
                    )
                });
        }
    }
}