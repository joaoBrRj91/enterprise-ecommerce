using System.Text.Json;

namespace NSE.WebApp.MVC.Providers.Utils
{
    public class JsonProvider : IJsonProvider
    {
        private readonly JsonSerializerOptions _serializerOptions;
        public JsonProvider()
        {
            _serializerOptions = new()
            {
                PropertyNameCaseInsensitive = true
            };
        }

        public async Task<TResponse> DeserializeResponse<TResponse>(HttpResponseMessage httpResponse, bool thowingExceptionBadRequest = true) 
            where TResponse : class
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                return JsonSerializer.Deserialize<TResponse>(await httpResponse.Content.ReadAsStringAsync(), _serializerOptions)!;
            }

            if (thowingExceptionBadRequest)
            {
                //TODO: Return custom object
                throw new BadHttpRequestException("An Generic Error Ocurred In Integration Identity Api Service");
            }

            //TODO: When create a type TResponse error return this object
            return default!;
        }
    }
}
