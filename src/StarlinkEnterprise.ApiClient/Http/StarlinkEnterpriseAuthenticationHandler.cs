using System.Net.Http.Headers;
using StarlinkEnterprise.ApiClient.Authentication;

namespace StarlinkEnterprise.ApiClient.Http;

internal sealed class StarlinkEnterpriseAuthenticationHandler(
    IStarlinkAccessTokenProvider accessTokenProvider) : DelegatingHandler
{
    protected override async Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);

        if (request.Headers.Authorization is null)
        {
            var accessToken = await accessTokenProvider.GetAccessTokenAsync(cancellationToken);

            if (string.IsNullOrWhiteSpace(accessToken))
            {
                throw new InvalidOperationException(
                    $"{nameof(IStarlinkAccessTokenProvider)} returned an empty access token.");
            }

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Trim());
        }

        return await base.SendAsync(request, cancellationToken);
    }
}
