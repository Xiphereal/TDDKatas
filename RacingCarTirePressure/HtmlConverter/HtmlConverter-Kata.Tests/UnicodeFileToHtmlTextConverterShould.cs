using FluentAssertions;
using FluentAssertions.Execution;

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
            using var asd = new AssertionScope();
            var converter = new UnicodeFileToHtmlTextConverter("foobar.txt");
            converter.ConvertToHtml().Should().NotContain(@"""");

            File.ReadAllText("foobar.txt").Should().Contain("\n");
            converter.ConvertToHtml().Should().NotContain("\n")
                .And.Contain("<br />");
            converter.ConvertToHtml().Should().NotContain(" & ")
                .And.Contain(" &amp; ");
            converter.ConvertToHtml().Should().NotContain("<this has brackets>")
                .And.Contain("&amp;lt;this has brackets&amp;gt;");
            //converter.converttohtml().should().beempty();
            //file.readalltext("foobar.txt").should().beempty();
        }
    }
}
