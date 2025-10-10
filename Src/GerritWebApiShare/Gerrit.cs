namespace GerritWebApi;


public sealed class Gerrit : JsonService
{
    public Gerrit(string storeKey, string appName) : base(storeKey, appName, SourceGenerationContext.Default)
    { }

    public Gerrit(Uri host, IAuthenticator? authenticator, string appName) : base(host, authenticator, appName, SourceGenerationContext.Default)
    { }

    protected override string? AuthenticationTestUrl => "a/config/server/version"; //"/access/api/v1/system/ping";


    public override async Task<string?> GetVersionStringAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNotConnected(client);

        var res = await GetStringAsync("a/config/server/version", cancellationToken);
        res = res?.Trim(')', ']', '}', '\n', '"', '\'');
        return res;
    }

}
