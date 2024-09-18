namespace LinkedinScrapper.Helpers
{
    public class StringUtils
    {
        // if text containes other than * and space, return the text or else return empty string
        public static string ExtractJobTitle(string text)
        {
            return text.Replace("*", "").Replace(" ", "").Trim() == "" ? "" : text;
        }
    }
}