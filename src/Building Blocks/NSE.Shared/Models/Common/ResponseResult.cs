namespace NSE.Shared.Models.Common;

public record ResponseResult(object? Data, bool IsSuccess, string[]? Errors = default);