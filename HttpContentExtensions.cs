using Energetic.Http;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace System.Net.Http
{
    public static class HttpContentExtensions
    {
        public static async Task<TDestination> DeserializeFromJsonAsync<TDestination>(this HttpContent content)
            where TDestination : class
        {
            if (content is null)
                throw new ArgumentNullException(nameof(content));

            string contentString = await content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<TDestination>(contentString);

            return result ?? throw new DeserializationException<TDestination>(contentString);
        }
    }
}