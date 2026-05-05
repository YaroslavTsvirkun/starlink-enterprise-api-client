using Refit;
using StarlinkEnterprise.ApiClient.Endpoints;

namespace StarlinkEnterprise.ApiClient.Tests.Contracts;

public sealed class EndpointContractTests
{
    [Theory]
    [InlineData(typeof(IAccountsApi), 5)]
    [InlineData(typeof(IAddressApi), 5)]
    [InlineData(typeof(IRouterApi), 13)]
    [InlineData(typeof(IServiceLineApi), 15)]
    [InlineData(typeof(IUserTerminalApi), 7)]
    public void EndpointInterfaces_ContainExpectedNumberOfEndpoints(Type clientType, int expectedEndpoints)
    {
        var endpointCount = clientType
            .GetMethods()
            .Count(static method => method.GetCustomAttributes(inherit: true).OfType<HttpMethodAttribute>().Any());

        Assert.Equal(expectedEndpoints, endpointCount);
    }
}
