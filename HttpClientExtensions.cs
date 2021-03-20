using System.Threading.Tasks;

namespace System.Net.Http
{
    public static class HttpClientExtensions
    {
        public static Task<HttpResponseMessage> PostAsJsonAsync<T>(
            this HttpClient httpClient, string url, T data)
            where T : class
        {
            var content = data.ConvertToJsonStringContent();
            return httpClient.PostAsync(url, content);
        }

        public static async Task<HttpResponseMessage> PatchAsync<T>(this HttpClient client,
            string requestUri,
            T patchDocument)
            where T : class
        {
            var content = patchDocument.ConvertToJsonStringContent();
            return await client.PatchAsync(requestUri, content);
        }

        public static async Task<HttpResponseMessage> GetAsync(this HttpClient client,
            string requestUri,
            HttpContent content)
        {
            HttpRequestMessage message = CreateHttpRequestMessage(requestUri, HttpMethod.Get, content);
            return await client.SendAsync(message);
        }

        private static HttpRequestMessage CreateHttpRequestMessage(string uri, HttpMethod method, HttpContent? content = null)
        {
            var message = new HttpRequestMessage(method, uri);

            if (content is { })
            {
                message.Content = content;
            }

            return message;
        }
    }
}