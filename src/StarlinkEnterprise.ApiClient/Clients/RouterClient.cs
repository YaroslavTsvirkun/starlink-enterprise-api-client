using StarlinkEnterprise.ApiClient.Endpoints;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Clients;

public interface IRouterClient
{
    Task<ServiceResponse<Router>> GetRouterAsync(
        string accountNumber,
        string routerId,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> RemoveConfigAssignmentAsync(
        string accountNumber,
        string routerId,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> SetConfigAssignmentAsync(
        string accountNumber,
        string routerId,
        string? configId = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> SetBatchConfigAssignmentAsync(
        string accountNumber,
        UpdateBatchDeviceConfigRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<PagedResult<RouterConfig>>> GetRouterConfigsAsync(
        string accountNumber,
        int? page = 0,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<RouterConfig>> CreateRouterConfigAsync(
        string accountNumber,
        RouterConfigRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<RouterConfig>> GetRouterConfigAsync(
        string accountNumber,
        string configId,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<RouterConfig>> UpdateRouterConfigAsync(
        string accountNumber,
        string configId,
        RouterConfigRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> GetSandboxClientsAsync(
        string accountNumber,
        int? sandboxId = default,
        DateTimeOffset? expiryAfter = default,
        int? page = 0,
        int? limit = 100,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> UpdateSandboxClientsAsync(
        string accountNumber,
        IEnumerable<UpdateBatchSandboxClientRequest>? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> SendSandboxHeartbeatAsync(
        string accountNumber,
        SandboxHeartbeatRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<SandboxUpdateResult>> UpdateSandboxAsync(
        string accountNumber,
        int sandboxId,
        UpdateSandboxRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> RebootRouterAsync(
        string accountNumber,
        string routerId,
        CancellationToken cancellationToken = default);
}

internal sealed class RouterClient(IRouterApi api) : IRouterClient
{
    public Task<ServiceResponse<Router>> GetRouterAsync(
        string accountNumber,
        string routerId,
        CancellationToken cancellationToken = default)
        => api.GetRouterAsync(accountNumber, routerId, cancellationToken);

    public Task<ServiceResponse> RemoveConfigAssignmentAsync(
        string accountNumber,
        string routerId,
        CancellationToken cancellationToken = default)
        => api.RemoveConfigAssignmentAsync(accountNumber, routerId, cancellationToken);

    public Task<ServiceResponse> SetConfigAssignmentAsync(
        string accountNumber,
        string routerId,
        string? configId = default,
        CancellationToken cancellationToken = default)
        => api.SetConfigAssignmentAsync(accountNumber, routerId, configId, cancellationToken);

    public Task<ServiceResponse> SetBatchConfigAssignmentAsync(
        string accountNumber,
        UpdateBatchDeviceConfigRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.SetBatchConfigAssignmentAsync(accountNumber, request, cancellationToken);

    public Task<ServiceResponse<PagedResult<RouterConfig>>> GetRouterConfigsAsync(
        string accountNumber,
        int? page = 0,
        CancellationToken cancellationToken = default)
        => api.GetRouterConfigsAsync(accountNumber, page, cancellationToken);

    public Task<ServiceResponse<RouterConfig>> CreateRouterConfigAsync(
        string accountNumber,
        RouterConfigRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.CreateRouterConfigAsync(accountNumber, request, cancellationToken);

    public Task<ServiceResponse<RouterConfig>> GetRouterConfigAsync(
        string accountNumber,
        string configId,
        CancellationToken cancellationToken = default)
        => api.GetRouterConfigAsync(accountNumber, configId, cancellationToken);

    public Task<ServiceResponse<RouterConfig>> UpdateRouterConfigAsync(
        string accountNumber,
        string configId,
        RouterConfigRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.UpdateRouterConfigAsync(accountNumber, configId, request, cancellationToken);

    public Task<ServiceResponse> GetSandboxClientsAsync(
        string accountNumber,
        int? sandboxId = default,
        DateTimeOffset? expiryAfter = default,
        int? page = 0,
        int? limit = 100,
        CancellationToken cancellationToken = default)
        => api.GetSandboxClientsAsync(accountNumber, sandboxId, expiryAfter, page, limit, cancellationToken);

    public Task<ServiceResponse> UpdateSandboxClientsAsync(
        string accountNumber,
        IEnumerable<UpdateBatchSandboxClientRequest>? request = default,
        CancellationToken cancellationToken = default)
        => api.UpdateSandboxClientsAsync(accountNumber, request, cancellationToken);

    public Task<ServiceResponse> SendSandboxHeartbeatAsync(
        string accountNumber,
        SandboxHeartbeatRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.SendSandboxHeartbeatAsync(accountNumber, request, cancellationToken);

    public Task<ServiceResponse<SandboxUpdateResult>> UpdateSandboxAsync(
        string accountNumber,
        int sandboxId,
        UpdateSandboxRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.UpdateSandboxAsync(accountNumber, sandboxId, request, cancellationToken);

    public Task<ServiceResponse> RebootRouterAsync(
        string accountNumber,
        string routerId,
        CancellationToken cancellationToken = default)
        => api.RebootRouterAsync(accountNumber, routerId, cancellationToken);
}
