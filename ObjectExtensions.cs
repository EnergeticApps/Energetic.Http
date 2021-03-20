using Energetic.Text;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace System
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Creates HttpContent from a JSON string
        /// </summary>
        /// <param name="json">The JSON string</param>
        /// <returns></returns>
        public static StringContent ConvertToJsonStringContent<T>(this T value)
            where T : class
        {
            if (value is null)
                throw new ArgumentNullException(nameof(value));

            string json = JsonSerializer.Serialize(value);

            return json.ConvertToJsonStringContent();
        }
    }
}
