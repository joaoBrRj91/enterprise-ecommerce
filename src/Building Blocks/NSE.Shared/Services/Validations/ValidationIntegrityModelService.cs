using NSE.Shared.Models.Common;

namespace NSE.Shared.Services.Validations;

public sealed class ValidationIntegrityModelService : IValidationIntegrityModelService
{
    private readonly ICollection<string> _errors = [];
    private const string ERROR_FIELD_DATA_PREFIX = "MessageError";

    public ResponseResult BuildResponseResult(object? result = null, bool isClearErrorMessages = true)
    {
        if (IsResponseValid())
        {
            return new ResponseResult(result, IsSuccess: true);
        }

        var responseResult =  new ResponseResult(Data: result, IsSuccess: false, Errors: [.. _errors]);

        if (isClearErrorMessages) _errors.Clear();

        return responseResult;
    }

    public void AddErrors(string[] errorMessages)
    {
        foreach (var errorMessage in errorMessages)
        {
            AddError(errorMessage);
        }
    }

    public void AddError(string errorMessage)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(errorMessage, nameof(errorMessage));

        var newCurrentErrorCounter = _errors.Count + 1;
        _errors.Add($"{ERROR_FIELD_DATA_PREFIX}_{newCurrentErrorCounter}_{errorMessage}");
    }

    private bool IsResponseValid() => _errors.Count == 0;

}
