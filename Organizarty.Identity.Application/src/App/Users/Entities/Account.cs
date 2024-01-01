namespace Organizarty.Identity.Application.App.Users.Entities;

public class Account
{
    public string UserName { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string HashedPassword { get; set; } = default!;
    public string Salt { get; set; } = default!;

    public bool EmailConfirmed { get; set; }

    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
}
