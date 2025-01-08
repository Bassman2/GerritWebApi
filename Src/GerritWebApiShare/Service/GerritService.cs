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
internal class GerritService
{
}
