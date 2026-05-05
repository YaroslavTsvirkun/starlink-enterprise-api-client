namespace StarlinkEnterprise.ApiClient.Authentication;

public interface IStarlinkAccessTokenProvider
{
    ValueTask<string> GetAccessTokenAsync(CancellationToken cancellationToken = default);
}
