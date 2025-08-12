namespace NSE.Shared.Exceptions;

public sealed class JsonResponseDeserializeException(Type responseResultType) 
    : Exception($"Error when trying deserialize in type {responseResultType.Name}")
{
}
