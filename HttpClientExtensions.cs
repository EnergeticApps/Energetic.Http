using System.IO;
using System.Text;
using System.Threading.Tasks;
using Energetic.Text;
using Microsoft.AspNetCore.JsonPatch;
using NewtonsoftJsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace System.Net.Http
{
    public static class HttpClientExtensions
    {
        public static async Task<HttpResponseMessage> PostAsJsonAsync<TData>(
            this HttpClient httpClient, string requestUri, TData data)
            where TData : class
        {
            if (httpClient is null)
                throw new ArgumentNullException(nameof(httpClient));

            if (string.IsNullOrEmpty(requestUri))
                throw new StringArgumentNullOrEmptyException(nameof(requestUri));

            if (data is null)
                throw new ArgumentNullException(nameof(data));

            var content = data.ConvertToJsonStringContent();
            return await httpClient.PostAsync(requestUri, content);
        }



        public static async Task<HttpResponseMessage> PatchAsync<T>(this HttpClient httpClient,
            string requestUri,
            T patch)
            where T : class
        {
            if (httpClient is null)
                throw new ArgumentNullException(nameof(httpClient));

            if (string.IsNullOrEmpty(requestUri))
                throw new StringArgumentNullOrEmptyException(nameof(requestUri));

            if (patch is null)
                throw new ArgumentNullException(nameof(patch));

            var content = patch.ConvertToJsonStringContent();
            return await httpClient.PatchAsync(requestUri, content);
        }

        public static async Task<HttpResponseMessage> PatchAsync<T>(this HttpClient client,
             string requestUri,
             JsonPatchDocument<T> patchDocument)
             where T : class
        {
            var writer = new StringWriter();
            var serializer = new NewtonsoftJsonSerializer();
            serializer.Serialize(writer, patchDocument);
            string json = writer.ToString();

            var content = new StringContent(json, Encoding.UTF8, "application/json-patch+json");
            return await client.PatchAsync(requestUri, content);
        }
    }
}