namespace StarlinkEnterprise.ApiClient.Configuration;

public sealed class StarlinkEnterpriseApiClientOptions
{
    public static readonly Uri DefaultBaseUri = new("https://web-api.starlink.com/api/", UriKind.Absolute);

    public Uri BaseUri { get; set; } = DefaultBaseUri;

    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(100);
}
