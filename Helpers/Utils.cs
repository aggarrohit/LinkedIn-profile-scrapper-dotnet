namespace LinkedinScrapper.Helpers
{
    public class StringUtils
    {
        public static string ExtractJobTitle(string text)
        {
            // if text containes other than * and space, return the text or else return empty string
            return text.Replace("*", "").Replace(" ", "").Trim() == "" ? "" : text;
        }
    }
}