namespace GerritWebApi;


public sealed class Gerrit : JsonService
{
    public Gerrit(string storeKey, string appName) : base(storeKey, appName, SourceGenerationContext.Default)
    { }

    public Gerrit(Uri host, IAuthenticator? authenticator, string appName) : base(host, authenticator, appName, SourceGenerationContext.Default)
    { }

    /// <summary>
    /// Configures the provided <see cref="HttpClient"/> instance with specific default headers required for API requests.
    /// This includes setting the User-Agent, Accept, and API version headers.
    /// </summary>
    /// <param name="client">The <see cref="HttpClient"/> to configure for GitHub API usage.</param>
    /// <param name="appName">The name of the application, used as the User-Agent header value.</param>
    protected override void InitializeClient(HttpClient client, string appName)
    {
        client.DefaultRequestHeaders.Add("User-Agent", appName);
        client.DefaultRequestHeaders.Add("Accept", "application/json");
    }

    protected override string? AuthenticationTestUrl => "a/config/server/version"; //"/access/api/v1/system/ping";


    public override async Task<string?> GetVersionStringAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetStringAsync("a/config/server/version", cancellationToken);
        res = res?.Trim(')', ']', '}', '\n', '"', '\'');
        return res;
    }

}
