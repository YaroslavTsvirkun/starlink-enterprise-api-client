using System.Text.Json.Serialization;

namespace StarlinkEnterprise.ApiClient.Models;

public sealed class AviationMetadata
{
    [JsonPropertyName("tailNumber")]
    public string? TailNumber { get; init; }

    [JsonPropertyName("seatCount")]
    public int? SeatCount { get; init; }

    [JsonPropertyName("airlineIataCode")]
    public string? AirlineIataCode { get; init; }

    [JsonPropertyName("aircraftIataCode")]
    public string? AircraftIataCode { get; init; }

    [JsonPropertyName("airlineIcaoCode")]
    public string? AirlineIcaoCode { get; init; }

    [JsonPropertyName("aircraftIcaoCode")]
    public string? AircraftIcaoCode { get; init; }

    [JsonPropertyName("stcNumber")]
    public string? StcNumber { get; init; }
}

public sealed class DataBlockSummary
{
    [JsonPropertyName("productId")]
    public string? ProductId { get; init; }

    [JsonPropertyName("startDate")]
    public DateTimeOffset? StartDate { get; init; }

    [JsonPropertyName("expirationDate")]
    public DateTimeOffset? ExpirationDate { get; init; }

    [JsonPropertyName("count")]
    public int? Count { get; init; }

    [JsonPropertyName("dataAmount")]
    public double? DataAmount { get; init; }

    [JsonPropertyName("dataUnitType")]
    public string? DataUnitType { get; init; }
}

public sealed class ServiceLineDataBlocksSummary
{
    [JsonPropertyName("recurringBlocksCurrentBillingCycle")]
    public List<DataBlockSummary> RecurringBlocksCurrentBillingCycle { get; init; } = [];

    [JsonPropertyName("recurringBlocksNextBillingCycle")]
    public List<DataBlockSummary> RecurringBlocksNextBillingCycle { get; init; } = [];

    [JsonPropertyName("delayedProductRecurringBlocksNextCycle")]
    public List<DataBlockSummary> DelayedProductRecurringBlocksNextCycle { get; init; } = [];

    [JsonPropertyName("topUpBlocksOptInPurchase")]
    public List<DataBlockSummary> TopUpBlocksOptInPurchase { get; init; } = [];

    [JsonPropertyName("topUpBlocksOneTimePurchase")]
    public List<DataBlockSummary> TopUpBlocksOneTimePurchase { get; init; } = [];
}

public sealed class ServiceLine
{
    [JsonPropertyName("addressReferenceId")]
    public Guid? AddressReferenceId { get; init; }

    [JsonPropertyName("serviceLineNumber")]
    public string? ServiceLineNumber { get; init; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("productReferenceId")]
    public string? ProductReferenceId { get; init; }

    [JsonPropertyName("delayedProductId")]
    public string? DelayedProductId { get; init; }

    [JsonPropertyName("optInProductId")]
    public string? OptInProductId { get; init; }

    [JsonPropertyName("startDate")]
    public DateTimeOffset? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTimeOffset? EndDate { get; init; }

    [JsonPropertyName("publicIp")]
    public bool? PublicIp { get; init; }

    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    [JsonPropertyName("aviationMetadata")]
    public AviationMetadata? AviationMetadata { get; init; }

    [JsonPropertyName("dataBlocks")]
    public ServiceLineDataBlocksSummary? DataBlocks { get; init; }
}

public sealed class CreateServiceLineRequest
{
    [JsonPropertyName("addressReferenceId")]
    public Guid AddressReferenceId { get; init; }

    [JsonPropertyName("productReferenceId")]
    public string ProductReferenceId { get; init; } = string.Empty;

    [JsonPropertyName("dataBlockProducts")]
    public SetRecurringDataBlocksRequest? DataBlockProducts { get; init; }
}

public sealed class AddDataBlockRequest
{
    [JsonPropertyName("productId")]
    public string ProductId { get; init; } = string.Empty;

    [JsonPropertyName("count")]
    public int Count { get; init; }
}

public sealed class SetRecurringDataBlocksRequest
{
    [JsonPropertyName("recurringDataBlocks")]
    public List<AddDataBlockRequest> RecurringDataBlocks { get; init; } = [];

    [JsonPropertyName("existingDataPoolId")]
    public string? ExistingDataPoolId { get; init; }

    [JsonPropertyName("applyToCurrentMonth")]
    public bool ApplyToCurrentMonth { get; init; }
}

public sealed class UpdateServiceLineNicknameRequest
{
    [JsonPropertyName("nickname")]
    public string Nickname { get; init; } = string.Empty;
}

public sealed class SetServiceLinePublicIpRequest
{
    [JsonPropertyName("publicIp")]
    public bool PublicIp { get; init; }
}

public sealed class DataProduct
{
    [JsonPropertyName("productId")]
    public string? ProductId { get; init; }

    [JsonPropertyName("price")]
    public double? Price { get; init; }

    [JsonPropertyName("isoCurrencyCode")]
    public string? IsoCurrencyCode { get; init; }

    [JsonPropertyName("dataAmount")]
    public double? DataAmount { get; init; }

    [JsonPropertyName("dataUnit")]
    public string? DataUnit { get; init; }
}

public sealed class DataProducts
{
    [JsonPropertyName("topUpProduct")]
    public DataProduct? TopUpProduct { get; init; }

    [JsonPropertyName("dataBlockProducts")]
    public List<DataProduct> DataBlockProducts { get; init; } = [];
}

public sealed class SubscriptionProduct
{
    [JsonPropertyName("productReferenceId")]
    public string? ProductReferenceId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("price")]
    public double? Price { get; init; }

    [JsonPropertyName("isoCurrencyCode")]
    public string? IsoCurrencyCode { get; init; }

    [JsonPropertyName("isSla")]
    public bool? IsSla { get; init; }

    [JsonPropertyName("maxNumberOfUserTerminals")]
    public int? MaxNumberOfUserTerminals { get; init; }

    [JsonPropertyName("dataProducts")]
    public DataProducts? DataProducts { get; init; }
}

public sealed class ServiceLineDataBlockUsage
{
    [JsonPropertyName("serviceLineNumber")]
    public string? ServiceLineNumber { get; init; }

    [JsonPropertyName("consumedAmountGB")]
    public double? ConsumedAmountGb { get; init; }
}

public sealed class MonthlyDataBlockUsage
{
    [JsonPropertyName("startDate")]
    public DateTimeOffset? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTimeOffset? EndDate { get; init; }

    [JsonPropertyName("serviceLineUsage")]
    public List<ServiceLineDataBlockUsage> ServiceLineUsage { get; init; } = [];
}

public sealed class DataBlockUsage
{
    [JsonPropertyName("dataBlockId")]
    public string? DataBlockId { get; init; }

    [JsonPropertyName("startDateUtc")]
    public DateTimeOffset? StartDateUtc { get; init; }

    [JsonPropertyName("expirationDateUtc")]
    public DateTimeOffset? ExpirationDateUtc { get; init; }

    [JsonPropertyName("totalAmountGB")]
    public double? TotalAmountGb { get; init; }

    [JsonPropertyName("consumedAmountGB")]
    public double? ConsumedAmountGb { get; init; }

    [JsonPropertyName("perBlockAmountGB")]
    public double? PerBlockAmountGb { get; init; }

    [JsonPropertyName("dataBlockType")]
    public DataBlockType? DataBlockType { get; init; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; init; }

    [JsonPropertyName("blocksCount")]
    public int? BlocksCount { get; init; }

    [JsonPropertyName("perBlockPrice")]
    public double? PerBlockPrice { get; init; }

    [JsonPropertyName("totalPrice")]
    public double? TotalPrice { get; init; }

    [JsonPropertyName("isoCurrencyCode")]
    public string? IsoCurrencyCode { get; init; }

    [JsonPropertyName("serviceLineUsage")]
    public List<ServiceLineDataBlockUsage> ServiceLineUsage { get; init; } = [];

    [JsonPropertyName("monthlyUsage")]
    public List<MonthlyDataBlockUsage> MonthlyUsage { get; init; } = [];
}

public sealed class DataPoolUsage
{
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; init; }

    [JsonPropertyName("dataPoolId")]
    public string? DataPoolId { get; init; }

    [JsonPropertyName("lastUpdated")]
    public DateTimeOffset? LastUpdated { get; init; }

    [JsonPropertyName("dataBlocks")]
    public List<DataBlockUsage> DataBlocks { get; init; } = [];
}

public sealed class DataUsageBin
{
    [JsonPropertyName("dataBucket")]
    public DataBucketType? DataBucket { get; init; }

    [JsonPropertyName("totalGB")]
    public double? TotalGb { get; init; }
}

public sealed class DailyDataUsage
{
    [JsonPropertyName("date")]
    public DateTimeOffset? Date { get; init; }

    [JsonPropertyName("dataUsageBins")]
    public List<DataUsageBin> DataUsageBins { get; init; } = [];
}

public sealed class DailyUsageSummary
{
    [JsonPropertyName("date")]
    public DateTimeOffset? Date { get; init; }

    [JsonPropertyName("priorityGB")]
    public double? PriorityGb { get; init; }

    [JsonPropertyName("optInPriorityGB")]
    public double? OptInPriorityGb { get; init; }

    [JsonPropertyName("standardGB")]
    public double? StandardGb { get; init; }

    [JsonPropertyName("nonBillableGB")]
    public double? NonBillableGb { get; init; }
}

public sealed class DataOverageLine
{
    [JsonPropertyName("restricted")]
    public DataBucketType? Restricted { get; init; }

    [JsonPropertyName("unrestricted")]
    public DataBucketType? Unrestricted { get; init; }

    [JsonPropertyName("pricePerGB")]
    public double? PricePerGb { get; init; }

    [JsonPropertyName("usageLimitGB")]
    public double? UsageLimitGb { get; init; }

    [JsonPropertyName("overageAmountGB")]
    public double? OverageAmountGb { get; init; }

    [JsonPropertyName("consumedAmountGB")]
    public double? ConsumedAmountGb { get; init; }

    [JsonPropertyName("overagePrice")]
    public double? OveragePrice { get; init; }

    [JsonPropertyName("productId")]
    public string? ProductId { get; init; }

    [JsonPropertyName("dataOverageType")]
    public DataOverageType? DataOverageType { get; init; }

    [JsonPropertyName("activeFrom")]
    public DateTimeOffset? ActiveFrom { get; init; }
}

public sealed class ServicePlanDetails
{
    [JsonPropertyName("isoCurrencyCode")]
    public string? IsoCurrencyCode { get; init; }

    [JsonPropertyName("isMobilePlan")]
    public bool IsMobilePlan { get; init; }

    [JsonPropertyName("activeFrom")]
    public DateTimeOffset? ActiveFrom { get; init; }

    [JsonPropertyName("subscriptionActiveFrom")]
    public DateTimeOffset? SubscriptionActiveFrom { get; init; }

    [JsonPropertyName("subscriptionEndDate")]
    public DateTimeOffset? SubscriptionEndDate { get; init; }

    [JsonPropertyName("overageName")]
    public string? OverageName { get; init; }

    [JsonPropertyName("overageDescription")]
    public string? OverageDescription { get; init; }

    [JsonPropertyName("isOptedIntoOverage")]
    public bool IsOptedIntoOverage { get; init; }

    [JsonPropertyName("overageLineDeactivatedDate")]
    public DateTimeOffset? OverageLineDeactivatedDate { get; init; }

    [JsonPropertyName("overageLine")]
    public DataOverageLine? OverageLine { get; init; }

    [JsonPropertyName("dataPoolUsage")]
    public DataPoolUsage? DataPoolUsage { get; init; }

    [JsonPropertyName("productId")]
    public string ProductId { get; init; } = string.Empty;

    [JsonPropertyName("usageLimitGB")]
    public double UsageLimitGb { get; init; }

    [JsonPropertyName("dataCategoryMapping")]
    public Dictionary<string, DataBucketType> DataCategoryMapping { get; init; } = [];
}

public sealed class BillingCycleDataUsage
{
    [JsonPropertyName("startDate")]
    public DateTimeOffset? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTimeOffset? EndDate { get; init; }

    [JsonPropertyName("dataUsage")]
    public List<DataUsageBin> DataUsage { get; init; } = [];

    [JsonPropertyName("dailyDataUsages")]
    public List<DailyDataUsage> DailyDataUsages { get; init; } = [];

    [JsonPropertyName("overageLines")]
    public List<DataOverageLine> OverageLines { get; init; } = [];
}

public sealed class BillingCycleUsageSummary
{
    [JsonPropertyName("startDate")]
    public DateTimeOffset? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTimeOffset? EndDate { get; init; }

    [JsonPropertyName("dailyDataUsage")]
    public List<DailyUsageSummary> DailyDataUsage { get; init; } = [];

    [JsonPropertyName("overageLines")]
    public List<DataOverageLine> OverageLines { get; init; } = [];

    [JsonPropertyName("dataPoolUsage")]
    public List<DataPoolUsage> DataPoolUsage { get; init; } = [];

    [JsonPropertyName("totalPriorityGB")]
    public double? TotalPriorityGb { get; init; }

    [JsonPropertyName("totalStandardGB")]
    public double? TotalStandardGb { get; init; }

    [JsonPropertyName("totalOptInPriorityGB")]
    public double? TotalOptInPriorityGb { get; init; }

    [JsonPropertyName("totalNonBillableGB")]
    public double? TotalNonBillableGb { get; init; }
}

public sealed class ServiceLineDataUsage
{
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; init; }

    [JsonPropertyName("assetNumber")]
    public string? AssetNumber { get; init; }

    [JsonPropertyName("startDate")]
    public DateTimeOffset? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTimeOffset? EndDate { get; init; }

    [JsonPropertyName("billingCycles")]
    public List<BillingCycleDataUsage> BillingCycles { get; init; } = [];

    [JsonPropertyName("servicePlan")]
    public ServicePlanDetails? ServicePlan { get; init; }

    [JsonPropertyName("lastUpdatedAt")]
    public DateTimeOffset? LastUpdatedAt { get; init; }
}

public sealed class ServiceLineBillingCycleUsage
{
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; init; }

    [JsonPropertyName("serviceLineNumber")]
    public string? ServiceLineNumber { get; init; }

    [JsonPropertyName("startDate")]
    public DateTimeOffset? StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTimeOffset? EndDate { get; init; }

    [JsonPropertyName("billingCycles")]
    public List<BillingCycleUsageSummary> BillingCycles { get; init; } = [];

    [JsonPropertyName("servicePlan")]
    public ServicePlanDetails? ServicePlan { get; init; }

    [JsonPropertyName("lastUpdated")]
    public DateTimeOffset? LastUpdated { get; init; }
}

public sealed class OptInPeriod
{
    [JsonPropertyName("productId")]
    public string? ProductId { get; init; }

    [JsonPropertyName("activatedBySubjectId")]
    public string? ActivatedBySubjectId { get; init; }

    [JsonPropertyName("activatedDate")]
    public DateTimeOffset? ActivatedDate { get; init; }

    [JsonPropertyName("deactivatedBySubjectId")]
    public string? DeactivatedBySubjectId { get; init; }

    [JsonPropertyName("deactivatedDate")]
    public DateTimeOffset? DeactivatedDate { get; init; }

    [JsonPropertyName("isCoolDown")]
    public bool IsCoolDown { get; init; }
}

public sealed class PartialPeriod
{
    [JsonPropertyName("productReferenceId")]
    public string? ProductReferenceId { get; init; }

    [JsonPropertyName("periodStart")]
    public DateTimeOffset? PeriodStart { get; init; }

    [JsonPropertyName("periodEnd")]
    public DateTimeOffset? PeriodEnd { get; init; }
}
