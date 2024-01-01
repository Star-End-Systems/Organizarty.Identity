using FluentValidation;
using Organizarty.Identity.Application.App.Consumers.Entities;

namespace Organizarty.Application.App.Users.Entities;

public class ConsumerValidator : AbstractValidator<Consumer>
{
    public ConsumerValidator()
    {
        RuleFor(x => x.Email).EmailAddress().NotNull();
        RuleFor(x => x.UserName).Length(5, 50).NotNull();
        RuleFor(x => x.Fullname).Length(5, 80).NotNull();
        RuleFor(x => x.HashedPassword).MinimumLength(8).NotNull();

        RuleFor(x => x.CPF).Length(11).When(x => !string.IsNullOrWhiteSpace(x.CPF));
    }
}
