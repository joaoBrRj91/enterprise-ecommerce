namespace NSE.Shared.Models.Auth;

public class UserLoginResponse
{
    public required string AccessToken { get; set; }
    public required double ExpiresIn { get; set; }
    public required UserToken UserToken { get; set; }
}

