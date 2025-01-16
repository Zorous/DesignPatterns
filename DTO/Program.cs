// Entity (in the database layer)
public class User
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; } // Sensitive data
    public DateTime CreatedAt { get; set; }
}

// DTO (for the API layer)
public class UserDTO
{
    public string Name { get; set; }
    public string Email { get; set; }
}
