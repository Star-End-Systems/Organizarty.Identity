using Organizarty.Identity.Application.App.ThirdParties.Entities;

namespace Organizarty.Identity.UI.Controllers.ThirdParties;

public record SecureThirdPartyResponse(string Id, string Email, string Name, string? Description, string PhoneNumber, string CNPJ, string? ContactEmail, string? ContactPhone)
{
    public static SecureThirdPartyResponse From(ThirdParty x)
    => new(x.Id, x.Email, x.Name, x.Description ?? "", x.PhoneNumber, x.CNPJ, x.ContactEmail, x.ContactPhone);
}

public record LoginThirdPartyResponse(SecureThirdPartyResponse data, string token);
