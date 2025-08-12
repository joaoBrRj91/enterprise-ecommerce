namespace NSE.Shared.Models.Auths;

public record UserLoginResponse
{
    public required string AccessToken { get; init; }
    public required double ExpiresIn { get; init; }
    public required UserToken UserToken { get; init; }
}

