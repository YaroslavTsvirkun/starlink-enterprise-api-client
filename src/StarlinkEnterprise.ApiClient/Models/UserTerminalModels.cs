using System.Text.Json.Serialization;

namespace StarlinkEnterprise.ApiClient.Models;

public sealed class UserTerminal
{
    [JsonPropertyName("userTerminalId")]
    public string? UserTerminalId { get; init; }

    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }

    [JsonPropertyName("kitSerialNumber")]
    public string? KitSerialNumber { get; init; }

    [JsonPropertyName("dishSerialNumber")]
    public string? DishSerialNumber { get; init; }

    [JsonPropertyName("serviceLineNumber")]
    public string? ServiceLineNumber { get; init; }

    [JsonPropertyName("active")]
    public bool? Active { get; init; }

    [JsonPropertyName("routers")]
    public List<Router> Routers { get; init; } = [];
}
