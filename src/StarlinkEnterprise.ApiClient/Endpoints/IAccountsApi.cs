using Refit;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Endpoints;

internal interface IAccountsApi
{
    [Get("/public/v1/accounts")]
    Task<ServiceResponse<PagedResult<Account>>> GetAccountsAsync(
        [Query(CollectionFormat.Multi)] IEnumerable<string>? regionCode = default,
        [Query] int? limit = 50,
        [Query] int? page = 0,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/accounts/{accountNumber}/update-default-router-config")]
    Task<ServiceResponse> UpdateDefaultRouterConfigAsync(
        string accountNumber,
        [Body] UpdateDefaultRouterConfigRequest? request = default,
        CancellationToken cancellationToken = default);

    [Multipart]
    [Post("/public/v1/accounts/{accountNumber}/router-local-content")]
    Task<ServiceResponse> UploadRouterLocalContentAsync(
        string accountNumber,
        [AliasAs("File")] StreamPart file,
        CancellationToken cancellationToken = default);

    [Get("/public/v1/accounts/{accountNumber}/router-local-content")]
    Task<ServiceResponse<List<RouterLocalContentFile>>> GetRouterLocalContentAsync(
        string accountNumber,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/accounts/{accountNumber}/billing-cycles/query")]
    Task<ServiceResponse<PagedResult<ServiceLineBillingCycleUsage>>> QueryBillingCyclesAsync(
        string accountNumber,
        [Body] QueryBillingCyclesRequest? request = default,
        CancellationToken cancellationToken = default);
}
