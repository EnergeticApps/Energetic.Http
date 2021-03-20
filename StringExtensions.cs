using Energetic.Text;
using System.Net.Http;
using System.Text;

namespace System
{
    public static class StringExtensions
    {
        /// <summary>
        /// Creates HttpContent from a JSON string
        /// </summary>
        /// <param name="json">The JSON string</param>
        /// <returns></returns>
        public static StringContent ConvertToJsonStringContent(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                throw new StringArgumentNullOrWhiteSpaceException(nameof(json));

            return new StringContent(json, Encoding.UTF8, "application/json");
        }
    }
}