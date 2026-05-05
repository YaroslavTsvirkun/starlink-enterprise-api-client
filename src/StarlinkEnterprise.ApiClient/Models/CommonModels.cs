using System.Text.Json.Serialization;

namespace StarlinkEnterprise.ApiClient.Models;

public class ServiceResponse
{
    [JsonPropertyName("errors")]
    public List<ValidationIssue> Errors { get; init; } = [];

    [JsonPropertyName("warnings")]
    public List<ValidationIssue> Warnings { get; init; } = [];

    [JsonPropertyName("information")]
    public List<string> Information { get; init; } = [];

    [JsonPropertyName("isValid")]
    public bool IsValid { get; init; }
}

public sealed class ServiceResponse<T> : ServiceResponse
{
    [JsonPropertyName("content")]
    public T? Content { get; init; }
}

public sealed class PagedResult<T>
{
    [JsonPropertyName("pageIndex")]
    public int PageIndex { get; init; }

    [JsonPropertyName("limit")]
    public int Limit { get; init; }

    [JsonPropertyName("isLastPage")]
    public bool IsLastPage { get; init; }

    [JsonPropertyName("results")]
    public List<T> Results { get; init; } = [];

    [JsonPropertyName("totalCount")]
    public int TotalCount { get; init; }
}

public sealed class ValidationIssue
{
    [JsonPropertyName("memberNames")]
    public List<string> MemberNames { get; init; } = [];

    [JsonPropertyName("errorMessage")]
    public string? ErrorMessage { get; init; }
}

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum DataBlockType
{
    IncludedWithBaseSubscription,
    RecurringPerBillingCycle,
    Overage,
    OneTimePurchase
}

public enum DataBucketType
{
    Unknown = 0,
    MobileRestricted = 1,
    MobileUnrestricted = 2,
    FixedRestricted = 3,
    FixedUnrestricted = 4,
    NonBillable = 5,
    MobileDeprioritizedLimited = 6,
    FixedDeprioritizedLimited = 7,
    Residential = 8,
    ResidentialLite = 9,
    Roam = 10
}

public enum DataOverageType
{
    None = 0,
    PriorityPerGb = 1,
    DeprioritizedPerGb = 2,
    LimitWithNoOverageData = 3
}
