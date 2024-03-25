namespace users.ApiContracts
{
    public record UpdateUserRequest(
        string Email,
        string FirstName,
        string LastName
    );
}
