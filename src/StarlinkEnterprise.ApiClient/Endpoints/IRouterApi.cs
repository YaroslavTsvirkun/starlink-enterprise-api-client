using Refit;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Endpoints;

internal interface IRouterApi
{
    [Get("/public/v1/account/{accountNumber}/routers/{routerId}")]
    Task<ServiceResponse<Router>> GetRouterAsync(
        string accountNumber,
        string routerId,
        CancellationToken cancellationToken = default);

    [Delete("/public/v1/account/{accountNumber}/routers/{routerId}/config")]
    Task<ServiceResponse> RemoveConfigAssignmentAsync(
        string accountNumber,
        string routerId,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/routers/{routerId}/config")]
    Task<ServiceResponse> SetConfigAssignmentAsync(
        string accountNumber,
        string routerId,
        [Body] string? configId = default,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/routers/batch-config")]
    Task<ServiceResponse> SetBatchConfigAssignmentAsync(
        string accountNumber,
        [Body] UpdateBatchDeviceConfigRequest? request = default,
        CancellationToken cancellationToken = default);

    [Get("/public/v1/account/{accountNumber}/routers/configs")]
    Task<ServiceResponse<PagedResult<RouterConfig>>> GetRouterConfigsAsync(
        string accountNumber,
        [Query] int? page = 0,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/routers/configs")]
    Task<ServiceResponse<RouterConfig>> CreateRouterConfigAsync(
        string accountNumber,
        [Body] RouterConfigRequest? request = default,
        CancellationToken cancellationToken = default);

    [Get("/public/v1/account/{accountNumber}/routers/configs/{configId}")]
    Task<ServiceResponse<RouterConfig>> GetRouterConfigAsync(
        string accountNumber,
        string configId,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/routers/configs/{configId}")]
    Task<ServiceResponse<RouterConfig>> UpdateRouterConfigAsync(
        string accountNumber,
        string configId,
        [Body] RouterConfigRequest? request = default,
        CancellationToken cancellationToken = default);

    [Get("/public/v1/account/{accountNumber}/routers/sandbox/clients")]
    Task<ServiceResponse> GetSandboxClientsAsync(
        string accountNumber,
        [Query] int? sandboxId = default,
        [Query] DateTimeOffset? expiryAfter = default,
        [Query] int? page = 0,
        [Query] int? limit = 100,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/routers/sandbox/clients")]
    Task<ServiceResponse> UpdateSandboxClientsAsync(
        string accountNumber,
        [Body] IEnumerable<UpdateBatchSandboxClientRequest>? request = default,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/routers/sandbox/heartbeat")]
    Task<ServiceResponse> SendSandboxHeartbeatAsync(
        string accountNumber,
        [Body] SandboxHeartbeatRequest? request = default,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/routers/sandbox/{sandboxId}")]
    Task<ServiceResponse<SandboxUpdateResult>> UpdateSandboxAsync(
        string accountNumber,
        int sandboxId,
        [Body] UpdateSandboxRequest? request = default,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/routers/{routerId}/reboot")]
    Task<ServiceResponse> RebootRouterAsync(
        string accountNumber,
        string routerId,
        CancellationToken cancellationToken = default);
}
