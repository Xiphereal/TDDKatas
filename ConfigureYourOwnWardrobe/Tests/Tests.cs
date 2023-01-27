using FluentAssertions;
using Xunit;

namespace ConfigureYourOwnWardrobe.Tests
{
    public class Tests
    {
        [Fact]
        public void Five_wardrobe_elements_of_50cm_fill_the_wall()
        {
            new Fitter().WithSizes(50).FittingIn(250).Should().Be("5 of 50cm");
        }
    }
}