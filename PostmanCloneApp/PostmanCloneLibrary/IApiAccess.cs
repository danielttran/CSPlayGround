
namespace PostmanCloneLibrary
{
    public interface IApiAccess
    {
        Task<string> CallApiAsync(string url,
                                  HttpContent content = null,
                                  bool formatOutput = true,
                                  HttpAction action = HttpAction.GET);
        bool IsValidUrl(string url);
    }
}