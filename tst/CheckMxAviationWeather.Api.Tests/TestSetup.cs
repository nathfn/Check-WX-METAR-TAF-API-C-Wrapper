using System.IO;

namespace CheckMxAviationWeather.Api.Tests
{
    public static class TestSetup
    {
        public static string GetTestApiKey()
        {
            // Replace with own!
            return File.ReadAllText(@"C:\checkwx-test-api-key.txt").Trim();
        }
    }
}
