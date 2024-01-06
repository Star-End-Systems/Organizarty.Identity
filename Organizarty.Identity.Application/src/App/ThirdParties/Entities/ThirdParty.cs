using Organizarty.Domain.Entities.Accounts;

namespace Organizarty.Identity.Application.App.ThirdParties.Entities;

public class ThirdParty : Account
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string CNPJ { get; set; } = default!;

    public AuthorizationStatus AuthorizationStatus { get; set; } = default!;

    public string? ContactEmail { get; set; }
    public string? ContactPhone { get; set; }

    public bool PhoneConfirmed { get; set; }
}
