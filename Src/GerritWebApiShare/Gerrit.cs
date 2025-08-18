using System.Globalization;
using System.Xml.Linq;

namespace GerritWebApi;


public sealed class Gerrit : IDisposable
{
    private GerritService? service;

    /// <summary>
    /// Initializes a new instance of the <see cref="Gerrit"/> class using a store key and application name.
    /// </summary>
    /// <param name="storeKey">The key to retrieve the host and token from the key store.</param>
    /// <param name="appName">The name of the application.</param>
    public Gerrit(string storeKey, string appName)
        : this(new Uri(KeyStore.Key(storeKey)?.Host!), KeyStore.Key(storeKey)!.Login!, KeyStore.Key(storeKey)!.Password!, appName)
    { }

    /// <summary>
    /// Initializes a new instance of the <see cref="Gerrit"/> class with the specified host, token, and application name.
    /// </summary>
    /// <param name="host">The base URI of the Gerrit server.</param>
    /// <param name="token">The authentication token for accessing the Gerrit API.</param>
    /// <param name="appName">The name of the application.</param>
    public Gerrit(Uri host, string token, string appName)
    {
        service = new(host, new BearerAuthenticator(token), appName);
    }

    public Gerrit(Uri host, string login, string password, string appName)
    {
        service = new(host, new BasicAuthenticator(login, password), appName);
    }

    /// <summary>
    /// Releases the resources used by the <see cref="Artifactory"/> instance.
    /// </summary>
    public void Dispose()
    {
        if (this.service != null)
        {
            this.service.Dispose();
            this.service = null;
        }
    }

    public async Task<string?> GetVersionAsync(CancellationToken cancellationToken = default)
    {
        WebServiceException.ThrowIfNullOrNotConnected(service);

        var res = await service.GetVersionAsync(cancellationToken);
        res = res?.Trim(')', ']', '}', '\n', '"', '\'');
        return res;
    }

}
