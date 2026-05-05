using StarlinkEnterprise.ApiClient.Clients;

namespace StarlinkEnterprise.ApiClient;

public interface IStarlinkEnterpriseApiClient
{
    IAccountsClient Accounts { get; }

    IAddressClient Addresses { get; }

    IRouterClient Routers { get; }

    IServiceLineClient ServiceLines { get; }

    IUserTerminalClient UserTerminals { get; }
}
