using FluentAssertions;
using Xunit;
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
            new Fitter().WithConfigurationOf(WardrobeElements().Of(sizeInCm)).FittingIn(250).Should().Be($"{numberOfElements} of {sizeInCm}cm");
        }
    }
}