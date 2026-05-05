using System.Net;

namespace StarlinkEnterprise.ApiClient.Tests.TestDoubles;

internal sealed class CaptureHandler : HttpMessageHandler
{
    public HttpRequestMessage? LastRequest { get; private set; }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        LastRequest = request;

        var response = new HttpResponseMessage(HttpStatusCode.OK)
        {
            RequestMessage = request,
            Content = new StringContent(string.Empty)
        };

        return Task.FromResult(response);
    }
}
