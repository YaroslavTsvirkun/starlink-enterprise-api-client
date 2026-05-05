using StarlinkEnterprise.ApiClient.Endpoints;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Clients;

public interface IAddressClient
{
    Task<ServiceResponse<PagedResult<Address>>> GetAddressesAsync(
        string accountNumber,
        IEnumerable<Guid>? addressIds = default,
        string? metadata = default,
        int? limit = 50,
        int? page = 0,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<Address>> CreateAddressAsync(
        string accountNumber,
        CreateAddressRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<Address>> UpdateAddressAsync(
        string accountNumber,
        UpdateAddressRequest? request = default,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<Address>> GetAddressAsync(
        string accountNumber,
        Guid addressReferenceId,
        CancellationToken cancellationToken = default);

    Task<ServiceResponse<CapacityCheckResult>> CheckCapacityAsync(
        string accountNumber,
        CapacityCheckRequest? request = default,
        CancellationToken cancellationToken = default);
}

internal sealed class AddressClient(IAddressApi api) : IAddressClient
{
    public Task<ServiceResponse<PagedResult<Address>>> GetAddressesAsync(
        string accountNumber,
        IEnumerable<Guid>? addressIds = default,
        string? metadata = default,
        int? limit = 50,
        int? page = 0,
        CancellationToken cancellationToken = default)
        => api.GetAddressesAsync(accountNumber, addressIds, metadata, limit, page, cancellationToken);

    public Task<ServiceResponse<Address>> CreateAddressAsync(
        string accountNumber,
        CreateAddressRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.CreateAddressAsync(accountNumber, request, cancellationToken);

    public Task<ServiceResponse<Address>> UpdateAddressAsync(
        string accountNumber,
        UpdateAddressRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.UpdateAddressAsync(accountNumber, request, cancellationToken);

    public Task<ServiceResponse<Address>> GetAddressAsync(
        string accountNumber,
        Guid addressReferenceId,
        CancellationToken cancellationToken = default)
        => api.GetAddressAsync(accountNumber, addressReferenceId, cancellationToken);

    public Task<ServiceResponse<CapacityCheckResult>> CheckCapacityAsync(
        string accountNumber,
        CapacityCheckRequest? request = default,
        CancellationToken cancellationToken = default)
        => api.CheckCapacityAsync(accountNumber, request, cancellationToken);
}
