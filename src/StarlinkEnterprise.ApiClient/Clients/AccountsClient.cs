using Refit;
using StarlinkEnterprise.ApiClient.Endpoints;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Clients;

public interface IAccountsClient
{
    Task<ServiceResponse<PagedResult<Account>>> GetAccountsAsync(
        IEnumerable<string>? regionCodes = default,
        int? limit = 50,
        int? page = 0,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> UpdateDefaultRouterConfigAsync(
        string accountNumber,
        UpdateDefaultRouterConfigRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> UploadRouterLocalContentAsync(
        string accountNumber,
        StreamPart file,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<List<RouterLocalContentFile>>> GetRouterLocalContentAsync(
        string accountNumber,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<PagedResult<ServiceLineBillingCycleUsage>>> QueryBillingCyclesAsync(
        string accountNumber,
        QueryBillingCyclesRequest? request = default,
        CancellationToken cancellationToken = default);
}

internal sealed class AccountsClient(IAccountsApi api) : IAccountsClient
{
    public Task<ServiceResponse<PagedResult<Account>>> GetAccountsAsync(
        IEnumerable<string>? regionCodes = default,
        int? limit = 50,
        int? page = 0,
        CancellationToken cancellationToken = default)
        => api.GetAccountsAsync(regionCodes, limit, page, cancellationToken);

    public Task<ServiceResponse> UpdateDefaultRouterConfigAsync(
        string accountNumber,
        UpdateDefaultRouterConfigRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.UpdateDefaultRouterConfigAsync(accountNumber, request, cancellationToken);

    public Task<ServiceResponse> UploadRouterLocalContentAsync(
        string accountNumber,
        StreamPart file,
        CancellationToken cancellationToken = default)
        => api.UploadRouterLocalContentAsync(accountNumber, file, cancellationToken);

    public Task<ServiceResponse<List<RouterLocalContentFile>>> GetRouterLocalContentAsync(
        string accountNumber,
        CancellationToken cancellationToken = default)
        => api.GetRouterLocalContentAsync(accountNumber, cancellationToken);

    public Task<ServiceResponse<PagedResult<ServiceLineBillingCycleUsage>>> QueryBillingCyclesAsync(
        string accountNumber,
        QueryBillingCyclesRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.QueryBillingCyclesAsync(accountNumber, request, cancellationToken);
}
