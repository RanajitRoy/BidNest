namespace users.ApiContracts
{
    public record VerifyCredentialsRequest(
        string Email,
        string Password
    );
}
