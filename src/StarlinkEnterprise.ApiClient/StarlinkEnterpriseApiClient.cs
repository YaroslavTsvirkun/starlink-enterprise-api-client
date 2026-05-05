using StarlinkEnterprise.ApiClient.Clients;

namespace StarlinkEnterprise.ApiClient;

internal sealed class StarlinkEnterpriseApiClient : IStarlinkEnterpriseApiClient
{
    public StarlinkEnterpriseApiClient(
        IAccountsClient accounts,
        IAddressClient addresses,
        IRouterClient routers,
        IServiceLineClient serviceLines,
        IUserTerminalClient userTerminals)
    {
        Accounts = accounts ?? throw new ArgumentNullException(nameof(accounts));
        Addresses = addresses ?? throw new ArgumentNullException(nameof(addresses));
        Routers = routers ?? throw new ArgumentNullException(nameof(routers));
        ServiceLines = serviceLines ?? throw new ArgumentNullException(nameof(serviceLines));
        UserTerminals = userTerminals ?? throw new ArgumentNullException(nameof(userTerminals));
    }

    public IAccountsClient Accounts { get; }

    public IAddressClient Addresses { get; }

    public IRouterClient Routers { get; }

    public IServiceLineClient ServiceLines { get; }

    public IUserTerminalClient UserTerminals { get; }
}
