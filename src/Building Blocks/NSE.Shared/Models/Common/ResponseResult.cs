
namespace NSE.Shared.Models.Common.Validations;

public record ResponseResult(object? Data, bool IsSuccess, string[]? Errors = default);