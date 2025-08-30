namespace NSE.Catalog.API.Configurations;

public static class ConfigurationManagerExtensions
{
    public static void ConfigureAppSettingsEnvironment(this ConfigurationManager configuration, string contentRootPath)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? default;

        if (string.IsNullOrWhiteSpace(environment))
        {
            throw new InvalidOperationException("Environment is not defined. Define Development, Staging or Production for respective env");
        }

        configuration
            .SetBasePath(contentRootPath)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
    }
}
