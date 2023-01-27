using FluentAssertions;
using Xunit;
using static ConfigureYourOwnWardrobe.Fitter;
using static ConfigureYourOwnWardrobe.WardrobeElementsBuilder;

namespace ConfigureYourOwnWardrobe.Tests
{
    public class Tests
    {
        [InlineData(50, 5)]
        [InlineData(75, 3)]
        [InlineData(100, 2)]
        [InlineData(120, 2)]
        [Theory]
        public void Single_size_wardrobe_elements_fill_the_wall(int sizeInCm, int numberOfElements)
        {
            WithAnSpaceOf(250).AndAConfigurationOf(WardrobeElements().Of(sizeInCm))
                .HowManyWouldFit()
                .Should().Be($"{numberOfElements} of {sizeInCm}cm");
        }
    }
}