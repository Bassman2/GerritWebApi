namespace GerritWebApi;

public sealed class Gerrit : JsonBaseClient
{
    private readonly GerritService? service;

    /// <summary>
    /// Initializes a new instance of the <see cref="Gerrit"/> class using a store key and application name.
    /// </summary>
    /// <param name="storeKey">The key to retrieve the host and token from the key store.</param>
    /// <param name="appName">The name of the application.</param>
    public Gerrit(string storeKey, string appName)
        //        : this(new Uri(KeyStore.Key(storeKey)?.Host!), KeyStore.Key(storeKey)!.Token!, appName)
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
        service = DefineService(new GerritService(host, new BearerAuthenticator(token), appName));
    }

    public Gerrit(Uri host, string login, string password, string appName)
    {
        service = DefineService(new GerritService(host, new BasicAuthenticator("Authorization", login, password), appName));
    }
}
