namespace NSE.Shared.Models.Auths;

public class UserLoginResponse
{
    public required string AccessToken { get; set; }
    public required double ExpiresIn { get; set; }
    public required UserToken UserToken { get; set; }
}

