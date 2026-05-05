using StarlinkEnterprise.ApiClient.Authentication;

namespace StarlinkEnterprise.ApiClient.Tests.TestDoubles;

internal sealed class StubAccessTokenProvider(string accessToken) : IStarlinkAccessTokenProvider
{
    public ValueTask<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        => ValueTask.FromResult(accessToken);
}
