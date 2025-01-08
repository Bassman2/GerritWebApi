namespace GerritWebApiUnitTest;

public abstract class GerritBaseUnitTest
{
    protected static readonly CultureInfo culture = new("en-US");

    protected const string storeKey = "gerrit";

    protected static readonly string testHost = KeyStore.Key(storeKey)!.Host!;
    protected static readonly string testUserKey = KeyStore.Key(storeKey)!.Login!;
    protected static readonly string testUserDisplayName = KeyStore.Key(storeKey)!.User!;
    protected static readonly string testUserEmail = KeyStore.Key(storeKey)!.Email!;

}

