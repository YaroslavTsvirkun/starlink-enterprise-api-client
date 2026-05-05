# Starlink Enterprise API Client

Typed `Refit` client for the Starlink Enterprise API on `.NET 10` with manual DTOs and manual endpoint contracts.

## Structure

- `src/StarlinkEnterprise.ApiClient` - API client library
- `tests/StarlinkEnterprise.ApiClient.Tests` - unit tests
- `swagger.json` - OpenAPI snapshot used to model the manual contracts

## Registered clients

The library exposes:

- High-level endpoint clients with explicit method names:
- `IAccountsClient`
- `IAddressClient`
- `IRouterClient`
- `IServiceLineClient`
- `IUserTerminalClient`
- `IStarlinkEnterpriseApiClient` as a grouped facade over the high-level clients

## Usage

```csharp
using Microsoft.Extensions.DependencyInjection;
using StarlinkEnterprise.ApiClient.Authentication;

var services = new ServiceCollection();

services.AddSingleton<IStarlinkAccessTokenProvider, MyTokenProvider>();
services.AddStarlinkEnterpriseApiClient(options =>
{
    options.BaseUri = new Uri("https://web-api.starlink.com/api/");
    options.Timeout = TimeSpan.FromSeconds(100);
});
```

```csharp
using StarlinkEnterprise.ApiClient;

var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IStarlinkEnterpriseApiClient>();

var accounts = await client.Accounts.GetAccountsAsync();
var serviceLines = await client.ServiceLines.GetServiceLinesAsync("ACC-123");
```

```csharp
using StarlinkEnterprise.ApiClient;

public sealed class MyTokenProvider : IStarlinkAccessTokenProvider
{
    public ValueTask<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        => ValueTask.FromResult("<access-token>");
}
```

## Notes

- DTOs and endpoint contracts are written manually.
- The multipart upload endpoint is modeled explicitly for `Refit` compatibility.
