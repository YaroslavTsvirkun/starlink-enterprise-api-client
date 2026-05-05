using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using StarlinkEnterprise.ApiClient.Authentication;
using StarlinkEnterprise.ApiClient.Clients;
using StarlinkEnterprise.ApiClient.Configuration;
using StarlinkEnterprise.ApiClient.Endpoints;
using StarlinkEnterprise.ApiClient.Tests.TestDoubles;

namespace StarlinkEnterprise.ApiClient.Tests.DependencyInjection;

public sealed class StarlinkEnterpriseApiClientServiceCollectionExtensionsTests
{
    [Fact]
    public void AddStarlinkEnterpriseApiClient_RegistersCompositeAndEndpointClients()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IStarlinkAccessTokenProvider>(new StubAccessTokenProvider("test-token"));

        services.AddStarlinkEnterpriseApiClient(options =>
        {
            options.BaseUri = new Uri("https://unit.test/api/", UriKind.Absolute);
            options.Timeout = TimeSpan.FromSeconds(42);
        });

        using var serviceProvider = services.BuildServiceProvider();

        var compositeClient = serviceProvider.GetRequiredService<IStarlinkEnterpriseApiClient>();
        var options = serviceProvider.GetRequiredService<IOptions<StarlinkEnterpriseApiClientOptions>>().Value;

        Assert.NotNull(compositeClient);
        Assert.NotNull(compositeClient.Accounts);
        Assert.NotNull(compositeClient.Addresses);
        Assert.NotNull(compositeClient.Routers);
        Assert.NotNull(compositeClient.ServiceLines);
        Assert.NotNull(compositeClient.UserTerminals);
        Assert.NotNull(serviceProvider.GetRequiredService<IAccountsApi>());
        Assert.NotNull(serviceProvider.GetRequiredService<IAddressApi>());
        Assert.NotNull(serviceProvider.GetRequiredService<IRouterApi>());
        Assert.NotNull(serviceProvider.GetRequiredService<IServiceLineApi>());
        Assert.NotNull(serviceProvider.GetRequiredService<IUserTerminalApi>());
        Assert.NotNull(serviceProvider.GetRequiredService<IAccountsClient>());
        Assert.NotNull(serviceProvider.GetRequiredService<IAddressClient>());
        Assert.NotNull(serviceProvider.GetRequiredService<IRouterClient>());
        Assert.NotNull(serviceProvider.GetRequiredService<IServiceLineClient>());
        Assert.NotNull(serviceProvider.GetRequiredService<IUserTerminalClient>());
        Assert.Equal(new Uri("https://unit.test/api/"), options.BaseUri);
        Assert.Equal(TimeSpan.FromSeconds(42), options.Timeout);
    }

    [Fact]
    public void AddStarlinkEnterpriseApiClient_InvalidBaseUri_ThrowsOptionsValidationException()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IStarlinkAccessTokenProvider>(new StubAccessTokenProvider("test-token"));

        services.AddStarlinkEnterpriseApiClient(options => options.BaseUri = new Uri("/relative-uri", UriKind.Relative));

        using var serviceProvider = services.BuildServiceProvider();

        var exception = Assert.Throws<OptionsValidationException>(() =>
            _ = serviceProvider.GetRequiredService<IOptions<StarlinkEnterpriseApiClientOptions>>().Value);

        Assert.Contains(nameof(StarlinkEnterpriseApiClientOptions.BaseUri), exception.Message, StringComparison.Ordinal);
    }
}
