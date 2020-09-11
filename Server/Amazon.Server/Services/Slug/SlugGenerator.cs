namespace Amazon.Server.Services.Slug
{
    using System.Text.RegularExpressions;

    public class SlugGenerator : ISlugGenerator
    {
        public string GenerateSlug(string str)
        {
            str = str
                .Trim()
                .ToLower();

            str = str
                .Replace(" ", "-")
                .Replace("--", "-")
                .Replace("--", "-");

            str = Regex.Replace(
                str,
                "[^a-zA-Z0-9_-]+",
                string.Empty,
                RegexOptions.Compiled);

            return str.Trim('-');
        }
    }
}
