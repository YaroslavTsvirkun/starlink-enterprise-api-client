using Refit;
using StarlinkEnterprise.ApiClient.Models;

namespace StarlinkEnterprise.ApiClient.Endpoints;

internal interface IAddressApi
{
    [Get("/public/v1/account/{accountNumber}/addresses")]
    Task<ServiceResponse<PagedResult<Address>>> GetAddressesAsync(
        string accountNumber,
        [Query(CollectionFormat.Multi)] IEnumerable<Guid>? addressIds = default,
        [Query] string? metadata = default,
        [Query] int? limit = 50,
        [Query] int? page = 0,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/addresses")]
    Task<ServiceResponse<Address>> CreateAddressAsync(
        string accountNumber,
        [Body] CreateAddressRequest? request = default,
        CancellationToken cancellationToken = default);

    [Put("/public/v1/account/{accountNumber}/addresses")]
    Task<ServiceResponse<Address>> UpdateAddressAsync(
        string accountNumber,
        [Body] UpdateAddressRequest? request = default,
        CancellationToken cancellationToken = default);

    [Get("/public/v1/account/{accountNumber}/addresses/{addressReferenceId}")]
    Task<ServiceResponse<Address>> GetAddressAsync(
        string accountNumber,
        Guid addressReferenceId,
        CancellationToken cancellationToken = default);

    [Post("/public/v1/account/{accountNumber}/addresses/check-capacity")]
    Task<ServiceResponse<CapacityCheckResult>> CheckCapacityAsync(
        string accountNumber,
        [Body] CapacityCheckRequest? request = default,
        CancellationToken cancellationToken = default);
}
