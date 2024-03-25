namespace users.ApiContracts
{
    public record UserResponse(
        string FirstName,
        string LastName,
        string Email
    );
}
