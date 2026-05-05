using StarlinkEnterprise.ApiClient.Endpoints;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Clients;

public interface IServiceLineClient
{
    Task<ServiceResponse<ServiceLine>> GetServiceLineAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> DeactivateServiceLineAsync(
        string accountNumber,
        string serviceLineNumber,
        string? reasonForCancellation = default,
        bool? endNow = false,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<PagedResult<ServiceLine>>> GetServiceLinesAsync(
        string accountNumber,
        Guid? addressReferenceId = default,
        string? searchString = default,
        int? limit = 50,
        int? page = 0,
        bool? orderByCreatedDateDescending = true,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<ServiceLine>> CreateServiceLineAsync(
        string accountNumber,
        CreateServiceLineRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> SetRecurringDataBlocksAsync(
        string accountNumber,
        string serviceLineNumber,
        SetRecurringDataBlocksRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> AddTopUpDataAsync(
        string accountNumber,
        string serviceLineNumber,
        AddDataBlockRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<ServiceLine>> UpdateNicknameAsync(
        string accountNumber,
        string serviceLineNumber,
        UpdateServiceLineNicknameRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> UpdateProductAsync(
        string accountNumber,
        string serviceLineNumber,
        string productReferenceId,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<ServiceLine>> UpdateProductWithRecurringDataAsync(
        string accountNumber,
        string serviceLineNumber,
        string productReferenceId,
        SetRecurringDataBlocksRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> SetPublicIpAsync(
        string accountNumber,
        string serviceLineNumber,
        SetServiceLinePublicIpRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<ServiceLineDataUsage>> GetDataUsageAsync(
        string accountNumber,
        string serviceLineNumber,
        bool? includeUnknownDataBin = false,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<List<PartialPeriod>>> GetPartialPeriodsAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<OptInPeriod>> OptInAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<OptInPeriod>> OptOutAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<PagedResult<SubscriptionProduct>>> GetAvailableProductsAsync(
        string accountNumber,
        int? limit = 50,
        int? page = 0,
        CancellationToken cancellationToken = default);
}

internal sealed class ServiceLineClient(IServiceLineApi api) : IServiceLineClient
{
    public Task<ServiceResponse<ServiceLine>> GetServiceLineAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default)
        => api.GetServiceLineAsync(accountNumber, serviceLineNumber, cancellationToken);

    public Task<ServiceResponse> DeactivateServiceLineAsync(
        string accountNumber,
        string serviceLineNumber,
        string? reasonForCancellation = default,
        bool? endNow = false,
        CancellationToken cancellationToken = default)
        => api.DeactivateServiceLineAsync(accountNumber, serviceLineNumber, reasonForCancellation, endNow, cancellationToken);

    public Task<ServiceResponse<PagedResult<ServiceLine>>> GetServiceLinesAsync(
        string accountNumber,
        Guid? addressReferenceId = default,
        string? searchString = default,
        int? limit = 50,
        int? page = 0,
        bool? orderByCreatedDateDescending = true,
        CancellationToken cancellationToken = default)
        => api.GetServiceLinesAsync(accountNumber, addressReferenceId, searchString, limit, page, orderByCreatedDateDescending, cancellationToken);

    public Task<ServiceResponse<ServiceLine>> CreateServiceLineAsync(
        string accountNumber,
        CreateServiceLineRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.CreateServiceLineAsync(accountNumber, request, cancellationToken);

    public Task<ServiceResponse> SetRecurringDataBlocksAsync(
        string accountNumber,
        string serviceLineNumber,
        SetRecurringDataBlocksRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.SetRecurringDataBlocksAsync(accountNumber, serviceLineNumber, request, cancellationToken);

    public Task<ServiceResponse> AddTopUpDataAsync(
        string accountNumber,
        string serviceLineNumber,
        AddDataBlockRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.AddTopUpDataAsync(accountNumber, serviceLineNumber, request, cancellationToken);

    public Task<ServiceResponse<ServiceLine>> UpdateNicknameAsync(
        string accountNumber,
        string serviceLineNumber,
        UpdateServiceLineNicknameRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.UpdateNicknameAsync(accountNumber, serviceLineNumber, request, cancellationToken);

    public Task<ServiceResponse> UpdateProductAsync(
        string accountNumber,
        string serviceLineNumber,
        string productReferenceId,
        CancellationToken cancellationToken = default)
        => api.UpdateProductAsync(accountNumber, serviceLineNumber, productReferenceId, cancellationToken);

    public Task<ServiceResponse<ServiceLine>> UpdateProductWithRecurringDataAsync(
        string accountNumber,
        string serviceLineNumber,
        string productReferenceId,
        SetRecurringDataBlocksRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.UpdateProductWithRecurringDataAsync(accountNumber, serviceLineNumber, productReferenceId, request, cancellationToken);

    public Task<ServiceResponse> SetPublicIpAsync(
        string accountNumber,
        string serviceLineNumber,
        SetServiceLinePublicIpRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.SetPublicIpAsync(accountNumber, serviceLineNumber, request, cancellationToken);

    public Task<ServiceResponse<ServiceLineDataUsage>> GetDataUsageAsync(
        string accountNumber,
        string serviceLineNumber,
        bool? includeUnknownDataBin = false,
        CancellationToken cancellationToken = default)
        => api.GetDataUsageAsync(accountNumber, serviceLineNumber, includeUnknownDataBin, cancellationToken);

    public Task<ServiceResponse<List<PartialPeriod>>> GetPartialPeriodsAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default)
        => api.GetPartialPeriodsAsync(accountNumber, serviceLineNumber, cancellationToken);

    public Task<ServiceResponse<OptInPeriod>> OptInAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default)
        => api.OptInAsync(accountNumber, serviceLineNumber, cancellationToken);

    public Task<ServiceResponse<OptInPeriod>> OptOutAsync(
        string accountNumber,
        string serviceLineNumber,
        CancellationToken cancellationToken = default)
        => api.OptOutAsync(accountNumber, serviceLineNumber, cancellationToken);

    public Task<ServiceResponse<PagedResult<SubscriptionProduct>>> GetAvailableProductsAsync(
        string accountNumber,
        int? limit = 50,
        int? page = 0,
        CancellationToken cancellationToken = default)
        => api.GetAvailableProductsAsync(accountNumber, limit, page, cancellationToken);
}
