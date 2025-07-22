namespace NSE.Shared.Models.Common.Validations;

public interface IValidationIntegrityModel
{
    /// <summary>
    /// Build Response Result for process endpoint data
    /// </summary>
    /// <param name="result">Data added in result data property</param>
    /// <param name="isClearErrorMessages">Clear error message list after finish build responde result</param>
    /// <returns></returns>
    ResponseResult BuildResponseResult(object? result = null, bool isClearErrorMessages = false);

    void AddErrors(string[] errorMessages);

    void AddError(string errorMessage);
}
