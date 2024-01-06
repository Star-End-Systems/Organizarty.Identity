using FluentValidation;
using Organizarty.Domain.Exceptions;
using Organizarty.Identity.Adapters.Cryptographies;
using Organizarty.Identity.Application.App.ThirdParties.Data;
using Organizarty.Identity.Application.App.ThirdParties.Entities;

namespace Organizarty.Identity.Application.App.ThirdParties.UseCases;

public class LoginThirdPartyUseCase
{
    private readonly ICryptographys _cryptograph;
    private readonly IThirdPartyRepository _thirdPartyRepository;
    private readonly IValidator<ThirdParty> _thirdPartyValidator;

    public record LoginThirdParty(string Email, string Password);

    public LoginThirdPartyUseCase(IThirdPartyRepository thirdPartyRepository, IValidator<ThirdParty> thirdPartyValidator, ICryptographys cryptograph)
    {
        _thirdPartyRepository = thirdPartyRepository;
        _thirdPartyValidator = thirdPartyValidator;
        _cryptograph = cryptograph;
    }

    public async Task<ThirdParty> Execute(LoginThirdParty userDto)
    {
        var user = await _thirdPartyRepository.FindByEmail(userDto.Email) ?? throw new NotFoundException($"User with email '{userDto.Email}' not found");

        var correctPassword = _cryptograph.VerifyPassword(userDto.Password, user.HashedPassword, user.Salt);

        if (!correctPassword)
        {
            throw new ValidationFailException("Email or password invalid.");
        }

        return user;
    }
}
