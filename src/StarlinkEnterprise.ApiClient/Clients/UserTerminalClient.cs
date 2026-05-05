using StarlinkEnterprise.ApiClient.Endpoints;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Clients;

public interface IUserTerminalClient
{
    Task<ServiceResponse<PagedResult<UserTerminal>>> GetUserTerminalsAsync(
        string accountNumber,
        IEnumerable<string>? serviceLineNumbers = default,
        IEnumerable<string>? userTerminalIds = default,
        bool? hasServiceLine = default,
        bool? active = default,
        string? searchString = default,
        int? limit = 50,
        int? page = 0,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> AddToAccountAsync(
        string accountNumber,
        string deviceId,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> RemoveFromAccountAsync(
        string accountNumber,
        string deviceId,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> AddToServiceLineAsync(
        string accountNumber,
        string userTerminalId,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> RemoveFromServiceLineAsync(
        string accountNumber,
        string userTerminalId,
        string serviceLineNumber,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> RebootAsync(
        string accountNumber,
        string deviceId,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse> SetBatchConfigAssignmentAsync(
        string accountNumber,
        UpdateBatchDeviceConfigRequest? request = default,
        CancellationToken cancellationToken = default);
}

internal sealed class UserTerminalClient(IUserTerminalApi api) : IUserTerminalClient
{
    public Task<ServiceResponse<PagedResult<UserTerminal>>> GetUserTerminalsAsync(
        string accountNumber,
        IEnumerable<string>? serviceLineNumbers = default,
        IEnumerable<string>? userTerminalIds = default,
        bool? hasServiceLine = default,
        bool? active = default,
        string? searchString = default,
        int? limit = 50,
        int? page = 0,
        CancellationToken cancellationToken = default)
        => api.GetUserTerminalsAsync(accountNumber, serviceLineNumbers, userTerminalIds, hasServiceLine, active, searchString, limit, page, cancellationToken);

    public Task<ServiceResponse> AddToAccountAsync(
        string accountNumber,
        string deviceId,
        CancellationToken cancellationToken = default)
        => api.AddToAccountAsync(accountNumber, deviceId, cancellationToken);

    public Task<ServiceResponse> RemoveFromAccountAsync(
        string accountNumber,
        string deviceId,
        CancellationToken cancellationToken = default)
        => api.RemoveFromAccountAsync(accountNumber, deviceId, cancellationToken);

    public Task<ServiceResponse> AddToServiceLineAsync(
        string accountNumber,
        string userTerminalId,
        string serviceLineNumber,
        CancellationToken cancellationToken = default)
        => api.AddToServiceLineAsync(accountNumber, userTerminalId, serviceLineNumber, cancellationToken);

    public Task<ServiceResponse> RemoveFromServiceLineAsync(
        string accountNumber,
        string userTerminalId,
        string serviceLineNumber,
        CancellationToken cancellationToken = default)
        => api.RemoveFromServiceLineAsync(accountNumber, userTerminalId, serviceLineNumber, cancellationToken);

    public Task<ServiceResponse> RebootAsync(
        string accountNumber,
        string deviceId,
        CancellationToken cancellationToken = default)
        => api.RebootAsync(accountNumber, deviceId, cancellationToken);

    public Task<ServiceResponse> SetBatchConfigAssignmentAsync(
        string accountNumber,
        UpdateBatchDeviceConfigRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.SetBatchConfigAssignmentAsync(accountNumber, request, cancellationToken);
}
