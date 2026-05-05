# Starlink Enterprise API Client

Typed `.NET 10` клієнт для Starlink Enterprise API на базі `Refit`.

Репозиторій містить:

- ручні DTO без code generation;
- ручні `Refit` endpoint-контракти;
- верхній шар клієнтів з читабельними методами;
- DI-реєстрацію через `IServiceCollection`;
- окремий тестовий проект.

## Можливості

- `Accounts`: акаунти, router local content, запити по billing cycles.
- `Address`: список адрес, створення, оновлення, capacity check.
- `Router`: конфіги, batch assignment, sandbox, reboot.
- `ServiceLine`: створення, зміна продукту, recurring/top-up data, usage, opt-in/opt-out.
- `UserTerminal`: прив’язка до акаунта, прив’язка до service line, batch config, reboot.

## Архітектура

- `src/StarlinkEnterprise.ApiClient/Models` — ручні request/response моделі.
- `src/StarlinkEnterprise.ApiClient/Endpoints` — ручні `Refit`-контракти.
- `src/StarlinkEnterprise.ApiClient/Clients` — публічні клієнти з методами по доменах.
- `src/StarlinkEnterprise.ApiClient/Authentication` — abstraction для access token.
- `src/StarlinkEnterprise.ApiClient/Configuration` — опції клієнта.
- `tests/StarlinkEnterprise.ApiClient.Tests` — unit-тести DI, endpoint-контрактів і auth handler.

## Підключення

```csharp
using Microsoft.Extensions.DependencyInjection;
using StarlinkEnterprise.ApiClient;
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

var serviceProvider = services.BuildServiceProvider();
var client = serviceProvider.GetRequiredService<IStarlinkEnterpriseApiClient>();

var accounts = await client.Accounts.GetAccountsAsync();
var serviceLines = await client.ServiceLines.GetServiceLinesAsync("ACC-123");
```

```csharp
using StarlinkEnterprise.ApiClient.Authentication;

public sealed class MyTokenProvider : IStarlinkAccessTokenProvider
{
    public ValueTask<string> GetAccessTokenAsync(CancellationToken cancellationToken = default)
        => ValueTask.FromResult("<access-token>");
}
```

## Публічний API

Фасад `IStarlinkEnterpriseApiClient` групує п’ять доменних клієнтів:

- `IAccountsClient`
- `IAddressClient`
- `IRouterClient`
- `IServiceLineClient`
- `IUserTerminalClient`

Це дозволяє не працювати напряму з низькорівневими `Refit`-контрактами.

## Вимоги

- `.NET SDK 10`
- access token для Starlink Enterprise API

## Локальна перевірка

```powershell
dotnet build StarlinkEnterprise.ApiClient.slnx
dotnet test StarlinkEnterprise.ApiClient.slnx
```

Поточний стан репозиторію:

- `dotnet build` — успішно
- `dotnet test` — успішно (`9/9`)

## Джерело контракту

Файл `swagger.json` збережений у репозиторії як reference snapshot офіційного Starlink Enterprise OpenAPI. Ручні моделі та endpoint-контракти синхронізовані з цим snapshot.

## Ліцензія

Проєкт ліцензований під `MIT`. Текст ліцензії: [LICENSE](https://github.com/YaroslavTsvirkun/starlink-enterprise-api-client/blob/main/LICENSE).
