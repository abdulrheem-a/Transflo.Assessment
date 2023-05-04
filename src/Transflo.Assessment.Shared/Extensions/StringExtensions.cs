namespace Transflo.Assessment.Shared.Extensions
{
    public static class StringExtensions
    {
        public static string GetAlphabetizedString(this string value)
        {
            return new string(value.OrderBy(c => c).ToArray());
        }
    }
}
