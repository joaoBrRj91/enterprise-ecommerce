namespace NSE.Shared.Models.Auths;

public record UserToken
{
    public string Id { get; init; }
    public string Email { get; init; }
    public IEnumerable<UserClaim> Claims { get; init; }
}

