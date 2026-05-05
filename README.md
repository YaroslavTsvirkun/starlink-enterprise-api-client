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

## Цифровий підпис NuGet-пакета

Для `nuget.org` релевантний саме авторський підпис пакета (`author signing`) сертифікатом `Code Signing`.

Важливо:

- `Strong Name` не заміняє підпис `NuGet`-пакета і не вирішує довіру до пакета на `nuget.org`.
- `nuget.org` не приймає self-signed сертифікати для авторського підпису.
- опубліковану версію `0.1.0` замінити підписаним пакетом не можна, тому перший підписаний реліз має виходити новою версією, наприклад `0.1.1`.

У репозиторії вже підготовлено локальний і CI workflow для підпису:

- локальний скрипт: `build/Publish-NuGet.ps1`
- GitHub Actions: `.github/workflows/publish-nuget.yml`

### Локальний підпис і публікація

Потрібні змінні середовища:

- `NUGET_API_KEY`
- `NUGET_SIGN_CERT_PATH` або `NUGET_SIGN_CERT_FINGERPRINT` або `NUGET_SIGN_CERT_SUBJECT_NAME`
- `NUGET_SIGN_CERT_PASSWORD` якщо сертифікат захищений паролем
- `NUGET_SIGN_TIMESTAMP_URL`

Приклад:

```powershell
$env:NUGET_API_KEY = "<nuget-api-key>"
$env:NUGET_SIGN_CERT_PATH = "C:\certs\nuget-signing.pfx"
$env:NUGET_SIGN_CERT_PASSWORD = "<pfx-password>"
$env:NUGET_SIGN_TIMESTAMP_URL = "https://<your-rfc3161-timestamp-server>"

./build/Publish-NuGet.ps1 -Version 0.1.1
```

### GitHub Actions secrets

Для CI потрібно додати secrets:

- `NUGET_API_KEY`
- `NUGET_SIGN_CERT_BASE64`
- `NUGET_SIGN_CERT_PASSWORD`
- `NUGET_SIGN_TIMESTAMP_URL`

`NUGET_SIGN_CERT_BASE64` — це вміст `.pfx`, закодований у Base64.

### Реєстрація сертифіката в NuGet.org

Перед публікацією signed package потрібно:

1. Експортувати публічну частину сертифіката у `.cer` (DER).
2. Зареєструвати цей сертифікат у `NuGet.org` → `Account settings` → `Certificates`.
3. Публікувати нові версії вже підписаними тим самим сертифікатом.

## Code signing policy

Для підготовки до `SignPath Foundation` у репозиторії додано формальні policy-документи:

Free code signing provided by SignPath.io, certificate by SignPath Foundation.

- [Code signing policy](./CODE_SIGNING_POLICY.md)
- [Privacy policy](./PRIVACY.md)
- [Contributing guide](./CONTRIBUTING.md)
- [SignPath Foundation readiness checklist](./docs/SIGNPATH_FOUNDATION_READINESS.md)

## Джерело контракту

Файл `swagger.json` збережений у репозиторії як reference snapshot офіційного Starlink Enterprise OpenAPI. Ручні моделі та endpoint-контракти синхронізовані з цим snapshot.

## Ліцензія

Проєкт ліцензований під `MIT`. Текст ліцензії: [LICENSE](https://github.com/YaroslavTsvirkun/starlink-enterprise-api-client/blob/main/LICENSE).
