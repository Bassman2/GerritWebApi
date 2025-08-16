using WebServiceClient;

namespace GerritWebApi.Service;


// https://gerrit-review.googlesource.com/Documentation/rest-api.html

/*
The Gerrit API is available at the https://<fqdn>/r/ endpoint for non authenticated requests and for authenticated requests it is https://<fqdn>/r/a/.

To use the authenticated endpoint you have to create HTTP credentials in Gerrit’s user settings page, which can be found at https://<fqdn>/r/settings/#HTTPCredentials once you are authenticated.

For example, here is how to use cURL to list open changes:

curl "https://fqdn/r/changes/?q=status:open"
And to access restricted resources with cURL, type the following:

curl -u username:<http_credentials> https://fqdn/r/a/accounts/self/password.http
  
*/

//https://shm-gerrit.elektrobit.com/Documentation/rest-api-config.html



internal class GerritService(Uri host, IAuthenticator? authenticator, string appName)
    : JsonService(host, authenticator, appName, SourceGenerationContext.Default)
{
   
    // application/json (application/vnd.org.jfrog.artifactory.storage.ItemCreated+json)

    protected override string? AuthenticationTestUrl => "a/config/server/version"; //"/access/api/v1/system/ping";

    //protected override async Task ErrorHandlingAsync(HttpResponseMessage response, string memberName, CancellationToken cancellationToken)
    //{
    //    JsonTypeInfo<ErrorsModel> jsonTypeInfoOut = (JsonTypeInfo<ErrorsModel>)context.GetTypeInfo(typeof(ErrorsModel))!;
    //    var error = await response.Content.ReadFromJsonAsync<ErrorsModel>(jsonTypeInfoOut, cancellationToken);

    //    //var error = await ReadFromJsonAsync<ErrorsModel>(response, cancellationToken);
    //    throw new WebServiceException(error?.ToString(), response.RequestMessage?.RequestUri, response.StatusCode, response.ReasonPhrase, memberName);
    //}

    public async Task<string?> GetVersionAsync(CancellationToken cancellationToken)
    {
        var res = await GetStringAsync("a/config/server/version", cancellationToken);
        return res;
    }
}
