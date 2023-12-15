using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace webBanHang.Web.Helpers
{
    public static class HttpClientExtensions
    {
        public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Error calling the API: {response.ReasonPhrase}");
            }

            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            if (string.IsNullOrEmpty(dataAsString))
            {
                throw new ApplicationException("API response is empty or invalid JSON.");
            }

            try
            {
                var result = JsonSerializer.Deserialize<T>(
                    dataAsString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return result;
            }
            catch (JsonException ex)
            {
                throw new ApplicationException($"Error deserializing JSON: {ex.Message}", ex);
            }
        }
    }
}
