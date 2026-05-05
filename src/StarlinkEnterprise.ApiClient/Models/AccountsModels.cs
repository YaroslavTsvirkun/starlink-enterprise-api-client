using System.Text.Json.Serialization;

namespace StarlinkEnterprise.ApiClient.Models;

public sealed class Account
{
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; init; }

    [JsonPropertyName("regionCode")]
    public string? RegionCode { get; init; }

    [JsonPropertyName("accountName")]
    public string? AccountName { get; init; }

    [JsonPropertyName("defaultRouterConfigId")]
    public string? DefaultRouterConfigId { get; init; }

    [JsonPropertyName("defaultRouterTlsDomain")]
    public string? DefaultRouterTlsDomain { get; init; }
}

public sealed class UpdateDefaultRouterConfigRequest
{
    [JsonPropertyName("configId")]
    public string ConfigId { get; init; } = string.Empty;
}

public sealed class QueryBillingCyclesRequest
{
    [JsonPropertyName("serviceLinesFilter")]
    public List<string> ServiceLinesFilter { get; init; } = [];

    [JsonPropertyName("previousBillingCycles")]
    public int? PreviousBillingCycles { get; init; }

    [JsonPropertyName("queryStartDateParam")]
    public DateTimeOffset? QueryStartDate { get; init; }

    [JsonPropertyName("pageIndex")]
    public int? PageIndex { get; init; }

    [JsonPropertyName("pageLimit")]
    public int? PageLimit { get; init; }

    [JsonPropertyName("activeServiceLinesOnly")]
    public bool? ActiveServiceLinesOnly { get; init; }

    [JsonPropertyName("queryByBillingAccount")]
    public bool? QueryByBillingAccount { get; init; }
}
