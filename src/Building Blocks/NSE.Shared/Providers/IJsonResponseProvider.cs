namespace NSE.Shared.Providers;
public interface IJsonResponseProvider
{
    /// <summary>
    /// Deserializer  <see cref="HttpResponseMessage"/> in a type of class  <see cref="TResponse"/>
    /// </summary>
    /// <typeparam name="TResponse"></typeparam>
    /// <param name="httpResponse"></param>
    /// <param name="thowingExceptionBadRequest"></param>
    /// <returns></returns>
    Task<TResponse> DeserializeResponse<TResponse>(HttpResponseMessage httpResponse, bool thowingExceptionBadRequest = true) where TResponse : class;
}

