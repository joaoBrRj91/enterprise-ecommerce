namespace NSE.WebApp.MVC.Configurations.Integration;

public record IntegrationSettings
{
    public required IdentityEndpoint IdentityEndpoint { get; set; }
}

public record BaseEndpoint
{
    public required string BaseUri { get; set; }
    public required string[] Routes { get; set; }
}

public record IdentityEndpoint: BaseEndpoint;