namespace NSE.WebApp.MVC.Providers.Integration
{
    public interface IHttpClientIntegrationProvider
    {
        /// <summary>
        /// Method for abstract creation and handling of the post request to the service
        /// </summary>
        /// <typeparam name="TRequest"></typeparam>
        /// <param name="request"></param>
        /// <param name="endpontService"></param>
        /// <returns></returns>
        Task<HttpResponseMessage> PostAsync<TRequest>(TRequest request, string endpontService, string routeResource) where TRequest : class;
    }
}
