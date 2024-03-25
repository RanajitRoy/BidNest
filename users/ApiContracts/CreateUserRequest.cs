namespace users.ApiContracts
{
    public record CreateUserRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password
    );
}
