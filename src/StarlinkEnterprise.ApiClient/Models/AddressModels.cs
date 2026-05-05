using System.Text.Json.Serialization;

namespace StarlinkEnterprise.ApiClient.Models;

public sealed class Address
{
    [JsonPropertyName("addressReferenceId")]
    public Guid? AddressReferenceId { get; init; }

    [JsonPropertyName("addressLines")]
    public List<string> AddressLines { get; init; } = [];

    [JsonPropertyName("locality")]
    public string? Locality { get; init; }

    [JsonPropertyName("administrativeArea")]
    public string? AdministrativeArea { get; init; }

    [JsonPropertyName("administrativeAreaCode")]
    public string? AdministrativeAreaCode { get; init; }

    [JsonPropertyName("region")]
    public string? Region { get; init; }

    [JsonPropertyName("regionCode")]
    public string? RegionCode { get; init; }

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; init; }

    [JsonPropertyName("metadata")]
    public string? Metadata { get; init; }

    [JsonPropertyName("formattedAddress")]
    public string? FormattedAddress { get; init; }

    [JsonPropertyName("latitude")]
    public double? Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public double? Longitude { get; init; }
}

public sealed class CreateAddressRequest
{
    [JsonPropertyName("addressLines")]
    public List<string> AddressLines { get; init; } = [];

    [JsonPropertyName("locality")]
    public string? Locality { get; init; }

    [JsonPropertyName("administrativeArea")]
    public string? AdministrativeArea { get; init; }

    [JsonPropertyName("administrativeAreaCode")]
    public string AdministrativeAreaCode { get; init; } = string.Empty;

    [JsonPropertyName("region")]
    public string? Region { get; init; }

    [JsonPropertyName("regionCode")]
    public string RegionCode { get; init; } = string.Empty;

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; init; }

    [JsonPropertyName("metadata")]
    public string? Metadata { get; init; }

    [JsonPropertyName("formattedAddress")]
    public string FormattedAddress { get; init; } = string.Empty;

    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }
}

public sealed class UpdateAddressRequest
{
    [JsonPropertyName("addressLines")]
    public List<string> AddressLines { get; init; } = [];

    [JsonPropertyName("locality")]
    public string? Locality { get; init; }

    [JsonPropertyName("administrativeArea")]
    public string? AdministrativeArea { get; init; }

    [JsonPropertyName("administrativeAreaCode")]
    public string AdministrativeAreaCode { get; init; } = string.Empty;

    [JsonPropertyName("region")]
    public string? Region { get; init; }

    [JsonPropertyName("regionCode")]
    public string RegionCode { get; init; } = string.Empty;

    [JsonPropertyName("postalCode")]
    public string? PostalCode { get; init; }

    [JsonPropertyName("metadata")]
    public string? Metadata { get; init; }

    [JsonPropertyName("formattedAddress")]
    public string FormattedAddress { get; init; } = string.Empty;

    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }

    [JsonPropertyName("addressReferenceId")]
    public Guid AddressReferenceId { get; init; }
}

public sealed class CapacityCheckRequest
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }
}

public sealed class CapacityCheckResult
{
    [JsonPropertyName("availableCapacity")]
    public int? AvailableCapacity { get; init; }
}
