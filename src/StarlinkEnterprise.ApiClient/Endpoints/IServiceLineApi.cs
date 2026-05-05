using Refit;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Endpoints;

internal interface IServiceLineApi
{
    [Get("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}")]
    Task<ServiceResponse<ServiceLine>> GetServiceLineAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    [Delete("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}")]
    Task<ServiceResponse> DeactivateServiceLineAsync(
        string accountNumber,
        string serviceLineNumber,
        [Query] string? reasonForCancellation = default,
        [Query] bool? endNow = false,
        CancellationToken cancellationToken = default);

    [Get("/public/v1/account/{accountNumber}/service-lines")]
    Task<ServiceResponse<PagedResult<ServiceLine>>> GetServiceLinesAsync(
        string accountNumber,
        [Query] Guid? addressReferenceId = default,
        [Query] string? searchString = default,
        [Query] int? limit = 50,
        [Query] int? page = 0,
        [Query] bool? orderByCreatedDateDescending = true,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/service-lines")]
    Task<ServiceResponse<ServiceLine>> CreateServiceLineAsync(
        string accountNumber,
        [Body] CreateServiceLineRequest? request = default,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/recurring-data")]
    Task<ServiceResponse> SetRecurringDataBlocksAsync(
        string accountNumber,
        string serviceLineNumber,
        [Body] SetRecurringDataBlocksRequest? request = default,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/top-up-data")]
    Task<ServiceResponse> AddTopUpDataAsync(
        string accountNumber,
        string serviceLineNumber,
        [Body] AddDataBlockRequest? request = default,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/nickname")]
    Task<ServiceResponse<ServiceLine>> UpdateNicknameAsync(
        string accountNumber,
        string serviceLineNumber,
        [Body] UpdateServiceLineNicknameRequest? request = default,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/product/{productReferenceId}")]
    Task<ServiceResponse> UpdateProductAsync(
        string accountNumber,
        string serviceLineNumber,
        string productReferenceId,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/product/{productReferenceId}")]
    Task<ServiceResponse<ServiceLine>> UpdateProductWithRecurringDataAsync(
        string accountNumber,
        string serviceLineNumber,
        string productReferenceId,
        [Body] SetRecurringDataBlocksRequest? request = default,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/public-ip")]
    Task<ServiceResponse> SetPublicIpAsync(
        string accountNumber,
        string serviceLineNumber,
        [Body] SetServiceLinePublicIpRequest? request = default,
        CancellationToken cancellationToken = default);

    [Get("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/billing-cycle/all")]
    Task<ServiceResponse<ServiceLineDataUsage>> GetDataUsageAsync(
        string accountNumber,
        string serviceLineNumber,
        [Query] bool? includeUnknownDataBin = false,
        CancellationToken cancellationToken = default);

    [Get("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/billing-cycle/partial-periods")]
    Task<ServiceResponse<List<PartialPeriod>>> GetPartialPeriodsAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/opt-in")]
    Task<ServiceResponse<OptInPeriod>> OptInAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    [Delete("/public/v1/account/{accountNumber}/service-lines/{serviceLineNumber}/opt-out")]
    Task<ServiceResponse<OptInPeriod>> OptOutAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    [Get("/public/v1/account/{accountNumber}/service-lines/available-products")]
    Task<ServiceResponse<PagedResult<SubscriptionProduct>>> GetAvailableProductsAsync(
        string accountNumber,
        [Query] int? limit = 50,
        [Query] int? page = 0,
        CancellationToken cancellationToken = default);
}
