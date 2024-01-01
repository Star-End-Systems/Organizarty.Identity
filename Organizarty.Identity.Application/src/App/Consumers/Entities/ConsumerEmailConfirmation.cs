namespace Organizarty.Identity.Application.App.Consumers.Entities;

public class ConsumerEmailConfirmation
{
    public string Id { get; set; } = default!;

    public string UserEmail { get; set; } = default!;

    public string Code { get; set; } = default!;

    public DateTime ValidTill { get; set; } = DateTime.UtcNow;

    public DateTime GeneratedAt { get; set; } = DateTime.UtcNow;
}
