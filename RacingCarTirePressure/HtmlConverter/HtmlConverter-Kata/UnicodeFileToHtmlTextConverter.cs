namespace HtmlConverterKata
{
    public class UnicodeFileToHtmlTextConverter
    {
        private readonly string fullFilenameWithPath;

        public UnicodeFileToHtmlTextConverter(string fullFilenameWithPath)
        {
            this.fullFilenameWithPath = fullFilenameWithPath;
        }

        public string GetFilename()
        {
            return this.fullFilenameWithPath;
        }

        public string ConvertToHtml()
        {
            using TextReader unicodeFileStream =
                File.OpenText(this.fullFilenameWithPath);
            string html = string.Empty;

            string line = unicodeFileStream.ReadLine();
            while (line != null)
            {
                html += HttpUtility.HtmlEncode(line);
                html += "<br />";
                line = unicodeFileStream.ReadLine();
            }

            return html;
        }
    }
}
