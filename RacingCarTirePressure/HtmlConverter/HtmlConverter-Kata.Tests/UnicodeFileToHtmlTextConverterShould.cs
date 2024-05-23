using FluentAssertions;

namespace HtmlConverterKata
{
    public class UnicodeFileToHtmlTextConverterShould
    {
        [Fact]
        public void Foobar()
        {
            var converter = new UnicodeFileToHtmlTextConverter("foobar.txt");
            converter.GetFilename().Should().Be("foobar.txt");
        }

        [Fact]
        public void NotContainUnicode()
        {
            var converter = new UnicodeFileToHtmlTextConverter("foobar.txt");
            converter.ConvertToHtml().Should().NotContain(@"""");

            File.ReadAllText("foobar.txt").Should().Contain("\n");
            converter.ConvertToHtml().Should().NotContain("\n");
        }
    }
}
