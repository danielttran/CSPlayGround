using System.Text.Json;

namespace PostmanCloneLibrary;

public class ApiAccess : IApiAccess
{
    private readonly HttpClient client = new();
    public async Task<string> CallApiAsync(string url,
                                           bool formatOutput = true,
                                           HttpAction action = HttpAction.GET)
    {
        using var response = await client.GetAsync(url);

        if (response.IsSuccessStatusCode)
        {
            string json = await response.Content.ReadAsStringAsync();

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
            throw new HttpRequestException($"Error: {response.StatusCode}");
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
