using Refit;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Endpoints;

internal interface IUserTerminalApi
{
    [Get("/public/v1/account/{accountNumber}/user-terminals")]
    Task<ServiceResponse<PagedResult<UserTerminal>>> GetUserTerminalsAsync(
        string accountNumber,
        [Query(CollectionFormat.Multi)] IEnumerable<string>? serviceLineNumbers = default,
        [Query(CollectionFormat.Multi)] IEnumerable<string>? userTerminalIds = default,
        [Query] bool? hasServiceLine = default,
        [Query] bool? active = default,
        [Query] string? searchString = default,
        [Query] int? limit = 50,
        [Query] int? page = 0,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/user-terminals/{deviceId}")]
    Task<ServiceResponse> AddToAccountAsync(
        string accountNumber,
        string deviceId,
        CancellationToken cancellationToken = default);

    [Delete("/public/v1/account/{accountNumber}/user-terminals/{deviceId}")]
    Task<ServiceResponse> RemoveFromAccountAsync(
        string accountNumber,
        string deviceId,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/user-terminals/{userTerminalId}/{serviceLineNumber}")]
    Task<ServiceResponse> AddToServiceLineAsync(
        string accountNumber,
        string userTerminalId,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    [Delete("/public/v1/account/{accountNumber}/user-terminals/{userTerminalId}/{serviceLineNumber}")]
    Task<ServiceResponse> RemoveFromServiceLineAsync(
        string accountNumber,
        string userTerminalId,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/user-terminals/{deviceId}/reboot")]
    Task<ServiceResponse> RebootAsync(
        string accountNumber,
        string deviceId,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/user-terminals/batch-config")]
    Task<ServiceResponse> SetBatchConfigAssignmentAsync(
        string accountNumber,
        [Body] UpdateBatchDeviceConfigRequest? request = default,
        CancellationToken cancellationToken = default);
}
