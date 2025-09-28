using NSE.Shared.Exceptions;
using System.Text.Json;

namespace NSE.API.Provider.Json;

public class JsonResponseService : IJsonResponseService
{
    private readonly JsonSerializerOptions _serializerOptions;
    public JsonResponseService()
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
            throw new JsonResponseDeserializeException(typeof(TResponse));
        }

        //TODO: When create a type TResponse error return this object
        return default!;
    }
}

