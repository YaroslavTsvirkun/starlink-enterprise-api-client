using System.Text.Json.Serialization;

namespace StarlinkEnterprise.ApiClient.Models;

public sealed class Router
{
    [JsonPropertyName("routerId")]
    public string? RouterId { get; init; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; init; }

    [JsonPropertyName("userTerminalId")]
    public string? UserTerminalId { get; init; }

    [JsonPropertyName("configId")]
    public string? ConfigId { get; init; }

    [JsonPropertyName("directLinkToDish")]
    public bool? DirectLinkToDish { get; init; }

    [JsonPropertyName("hardwareVersion")]
    public string? HardwareVersion { get; init; }

    [JsonPropertyName("lastBonded")]
    public DateTimeOffset? LastBonded { get; init; }
}

public sealed class RouterConfig
{
    [JsonPropertyName("accountNumber")]
    public string? AccountNumber { get; init; }

    [JsonPropertyName("configId")]
    public string? ConfigId { get; init; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("routerConfigJson")]
    public string? RouterConfigJson { get; init; }
}

public sealed class RouterConfigRequest
{
    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("routerConfigJson")]
    public string RouterConfigJson { get; init; } = string.Empty;
}

public sealed class RouterLocalContentFile
{
    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("uploadDate")]
    public DateTimeOffset? UploadDate { get; init; }

    [JsonPropertyName("fileContentId")]
    public string? FileContentId { get; init; }

    [JsonPropertyName("fileMD5Hash")]
    public string? FileMd5Hash { get; init; }
}

public sealed class UpdateBatchDeviceConfigRequest
{
    [JsonPropertyName("configId")]
    public string? ConfigId { get; init; }

    [JsonPropertyName("deviceIds")]
    public List<string> DeviceIds { get; init; } = [];
}

public sealed class UpdateBatchSandboxClientRequest
{
    [JsonPropertyName("clientId")]
    public string ClientId { get; init; } = string.Empty;

    [JsonPropertyName("sandboxId")]
    public int SandboxId { get; init; }

    [JsonPropertyName("expiry")]
    public DateTimeOffset Expiry { get; init; }
}

public sealed class SandboxHeartbeatRequest
{
    [JsonPropertyName("healthy")]
    public bool Healthy { get; init; }
}

public sealed class UpdateSandboxRequest
{
    [JsonPropertyName("enabled")]
    public bool Enabled { get; init; }
}

public sealed class SandboxUpdateResult
{
    [JsonPropertyName("configIds")]
    public List<string> ConfigIds { get; init; } = [];
}
