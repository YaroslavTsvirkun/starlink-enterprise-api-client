using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using Refit;
using StarlinkEnterprise.ApiClient.Clients;
using StarlinkEnterprise.ApiClient.Configuration;
using StarlinkEnterprise.ApiClient.Endpoints;
using StarlinkEnterprise.ApiClient.Http;

namespace Microsoft.Extensions.DependencyInjection;

public static class StarlinkEnterpriseApiClientServiceCollectionExtensions
{
    public static IServiceCollection AddStarlinkEnterpriseApiClient(
        this IServiceCollection services,
        Action<StarlinkEnterpriseApiClientOptions>? configureOptions = null,
        Action<IHttpClientBuilder>? configureHttpClientBuilder = null,
        RefitSettings? refitSettings = null)
    {
        ArgumentNullException.ThrowIfNull(services);

        refitSettings ??= CreateDefaultRefitSettings();

        services
            .AddOptions<StarlinkEnterpriseApiClientOptions>()
            .Configure(options => configureOptions?.Invoke(options))
            .Validate(
                static options => options.BaseUri.IsAbsoluteUri,
                $"{nameof(StarlinkEnterpriseApiClientOptions.BaseUri)} must be an absolute URI.")
            .Validate(
                static options => options.Timeout == Timeout.InfiniteTimeSpan || options.Timeout > TimeSpan.Zero,
                $"{nameof(StarlinkEnterpriseApiClientOptions.Timeout)} must be greater than zero or Timeout.InfiniteTimeSpan.")
            .ValidateOnStart();

        services.TryAddTransient<StarlinkEnterpriseAuthenticationHandler>();
        services.TryAddTransient<StarlinkEnterprise.ApiClient.IStarlinkEnterpriseApiClient, StarlinkEnterprise.ApiClient.StarlinkEnterpriseApiClient>();
        services.TryAddTransient<IAccountsClient, AccountsClient>();
        services.TryAddTransient<IAddressClient, AddressClient>();
        services.TryAddTransient<IRouterClient, RouterClient>();
        services.TryAddTransient<IServiceLineClient, ServiceLineClient>();
        services.TryAddTransient<IUserTerminalClient, UserTerminalClient>();

        RegisterClient<IAccountsApi>(services, refitSettings, configureHttpClientBuilder);
        RegisterClient<IAddressApi>(services, refitSettings, configureHttpClientBuilder);
        RegisterClient<IRouterApi>(services, refitSettings, configureHttpClientBuilder);
        RegisterClient<IServiceLineApi>(services, refitSettings, configureHttpClientBuilder);
        RegisterClient<IUserTerminalApi>(services, refitSettings, configureHttpClientBuilder);

        return services;
    }

    private static void RegisterClient<TClient>(
        IServiceCollection services,
        RefitSettings refitSettings,
        Action<IHttpClientBuilder>? configureHttpClientBuilder)
        where TClient : class
    {
        var builder = services
            .AddRefitClient<TClient>(refitSettings)
            .ConfigureHttpClient((serviceProvider, client) =>
            {
                var options = serviceProvider
                    .GetRequiredService<IOptions<StarlinkEnterpriseApiClientOptions>>()
                    .Value;

                client.BaseAddress = options.BaseUri;
                client.Timeout = options.Timeout;
            })
            .AddHttpMessageHandler<StarlinkEnterpriseAuthenticationHandler>();

        configureHttpClientBuilder?.Invoke(builder);
    }

    private static RefitSettings CreateDefaultRefitSettings()
    {
        var serializerOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        serializerOptions.Converters.Add(new JsonStringEnumConverter());
        return new RefitSettings(new SystemTextJsonContentSerializer(serializerOptions));
    }
}
