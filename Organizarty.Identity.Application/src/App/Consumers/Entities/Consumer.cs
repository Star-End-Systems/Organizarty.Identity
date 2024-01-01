using Organizarty.Identity.Application.App.Users.Entities;

namespace Organizarty.Identity.Application.App.Consumers.Entities;

public class Consumer : Account
{
    public string Id { get; set; } = default!;

    public string Fullname { get; set; } = default!;

    public string? CPF { get; set; }

    public DateTime BirthDate { get; set; }
}
