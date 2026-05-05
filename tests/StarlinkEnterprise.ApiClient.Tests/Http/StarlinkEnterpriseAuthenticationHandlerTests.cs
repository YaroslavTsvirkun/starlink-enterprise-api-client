using System.Net.Http.Headers;
using StarlinkEnterprise.ApiClient.Http;
using StarlinkEnterprise.ApiClient.Tests.TestDoubles;

namespace StarlinkEnterprise.ApiClient.Tests.Http;

public sealed class StarlinkEnterpriseAuthenticationHandlerTests
{
    [Fact]
    public async Task SendAsync_AddsBearerTokenWhenAuthorizationHeaderIsMissing()
    {
        var captureHandler = new CaptureHandler();
        using var handler = new StarlinkEnterpriseAuthenticationHandler(new StubAccessTokenProvider("abc-123"))
        {
            InnerHandler = captureHandler
        };
        using var invoker = new HttpMessageInvoker(handler);

        await invoker.SendAsync(new HttpRequestMessage(HttpMethod.Get, "https://unit.test/health"), CancellationToken.None);

        Assert.NotNull(captureHandler.LastRequest);
        Assert.NotNull(captureHandler.LastRequest!.Headers.Authorization);
        Assert.Equal("Bearer", captureHandler.LastRequest.Headers.Authorization!.Scheme);
        Assert.Equal("abc-123", captureHandler.LastRequest.Headers.Authorization.Parameter);
    }

    [Fact]
    public async Task SendAsync_DoesNotOverrideExistingAuthorizationHeader()
    {
        var captureHandler = new CaptureHandler();
        using var handler = new StarlinkEnterpriseAuthenticationHandler(new StubAccessTokenProvider("abc-123"))
        {
            InnerHandler = captureHandler
        };
        using var invoker = new HttpMessageInvoker(handler);
        using var request = new HttpRequestMessage(HttpMethod.Get, "https://unit.test/health");
        request.Headers.Authorization = new AuthenticationHeaderValue("Custom", "token");

        await invoker.SendAsync(request, CancellationToken.None);

        Assert.NotNull(captureHandler.LastRequest);
        Assert.NotNull(captureHandler.LastRequest!.Headers.Authorization);
        Assert.Equal("Custom", captureHandler.LastRequest.Headers.Authorization!.Scheme);
        Assert.Equal("token", captureHandler.LastRequest.Headers.Authorization.Parameter);
    }
}
