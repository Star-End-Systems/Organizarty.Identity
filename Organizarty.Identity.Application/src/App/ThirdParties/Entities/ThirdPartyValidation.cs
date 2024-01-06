using FluentValidation;
using Organizarty.Identity.Application.App.ThirdParties.Entities;
using Organizarty.Utils.Validations.CustomValidations;

namespace Organizarty.Application.App.Users.Entities;

public class ThirdPartyValidation : AbstractValidator<ThirdParty>
{
    public ThirdPartyValidation()
    {
        RuleFor(x => x.Email).EmailAddress().NotNull();
        RuleFor(x => x.UserName).Length(5, 50).NotNull();
        RuleFor(x => x.HashedPassword).Password();

        RuleFor(x => x.CNPJ).NotEmpty().Length(14);
    }
}
