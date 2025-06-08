using Microsoft.Extensions.Options;
using NSE.WebApp.MVC.Configurations.Integration;
using System.Text.Json;
using System.Text;

namespace NSE.WebApp.MVC.Providers.Integration
{
    public class HttpClientIntegrationProvider(HttpClient httpClient, IOptions<IntegrationSettings> integrationSettings) : IHttpClientIntegrationProvider
    {
        public async Task<HttpResponseMessage> PostAsync<TRequest>(TRequest request, string endpointService, string routeResource) where TRequest : class
        {
            var (baseUri, route) = IntegrationServiceSettingsFactory(endpointService, routeResource);

            var content = new StringContent(
                        content: JsonSerializer.Serialize(request),
                        encoding: Encoding.UTF8,
                        mediaType: "application/json");

            return await httpClient.PostAsync(requestUri: $"{baseUri}/{route}", content);
        }

        public (string baseUri, string routeResource) IntegrationServiceSettingsFactory(string endpointService, string routeResource)
        {
            return endpointService switch
            {
                "IdentityEndpoint" => 
                (integrationSettings.Value.IdentityEndpoint.BaseUri, integrationSettings.Value.IdentityEndpoint.Routes.First(r => r == routeResource)),
                _ => throw new InvalidOperationException(),
            };
        }
    }
}
