using System.Text.Json;

namespace Blog.Mcp.Helpers;

public static class HttpClientExtensions
{
    public static async Task<HttpResponseMessage> PostAsync(this HttpClient httpClient, string? requestUri, object content)
    {
        return await httpClient.PostAsync(requestUri, new StringContent(JsonSerializer.Serialize(content), System.Text.Encoding.UTF8, "application/json"));
    }
}
