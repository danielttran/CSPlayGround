using System.Text.Json;

namespace PostmanCloneLibrary;

public class ApiAccess : IApiAccess
{
    private readonly HttpClient client = new();
    public async Task<string> CallApiAsync(string url,
                                           HttpContent content = null,
                                           bool formatOutput = true,
                                           HttpAction action = HttpAction.GET)
    {
        HttpResponseMessage responseMessage = action switch
        {
            HttpAction.GET => await client.GetAsync(url),
            HttpAction.POST => await client.PostAsync(url, content),
            HttpAction.PUT => await client.PutAsync(url, content),
            HttpAction.DELETE => await client.DeleteAsync(url),
            _ => throw new ArgumentOutOfRangeException(nameof(action), action, null),
        };

        if (responseMessage.IsSuccessStatusCode)
        {
            string json = await responseMessage.Content.ReadAsStringAsync();

            if (formatOutput)
            {
                var jsonElement = JsonSerializer.Deserialize<JsonElement>(json);
                json = JsonSerializer.Serialize(jsonElement,
                        new JsonSerializerOptions { WriteIndented = true });
            }
            return json;
        }
        else
        {
            throw new HttpRequestException($"Error: {responseMessage.StatusCode}");
        }
    }

    public bool IsValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url))
        {
            return false;
        }

        bool isValid = Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
            && (uriResult.Scheme == Uri.UriSchemeHttps);

        return isValid;
    }
}
