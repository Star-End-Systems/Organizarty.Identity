using Organizarty.Identity.Application.App.Users.Entities;

namespace Organizarty.Identity.Application.App.Consumers.Entities;

public class ThirdParty : Account
{
    public string Id { get; set; } = default!;

    public string Name { get; set; } = default!;

    public string Description { get; set; } = default!;

    public string PhoneNumber { get; set; } = default!;

    public string CNPJ { get; set; } = default!;
}
