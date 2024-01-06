using FluentValidation;
using Organizarty.Domain.Exceptions;
using Organizarty.Identity.Adapters.Cryptographies;
using Organizarty.Identity.Application.App.ThirdParties.Data;
using Organizarty.Identity.Application.App.ThirdParties.Entities;
using Organizarty.Utils.Validations.Extensions;

namespace Organizarty.Identity.Application.App.ThirdParties.UseCases;

public class RegisterThirdPartyUseCase
{
    private readonly ICryptographys _cryptograph;
    private readonly IThirdPartyRepository _thirdPartyRepository;
    private readonly IValidator<ThirdParty> _thirdPartyValidator;

    public record SimpleRegister(string Email, string Password);

    public RegisterThirdPartyUseCase(IThirdPartyRepository thirdPartyRepository, IValidator<ThirdParty> thirdPartyValidator, ICryptographys cryptograph)
    {
        _thirdPartyRepository = thirdPartyRepository;
        _thirdPartyValidator = thirdPartyValidator;
        _cryptograph = cryptograph;
    }

    public async Task<ThirdParty> Execute(SimpleRegister userDto)
    {
        var thirdParty = ToModel(userDto);

        _thirdPartyValidator.Check(thirdParty, "Fail while validating Third Party");

        await AssertUniqueEmail(userDto.Email);

        var (password, salt) = _cryptograph.HashPassword(thirdParty.HashedPassword);

        thirdParty.HashedPassword = password;
        thirdParty.Salt = salt;

        // await _sendEmailConfirmation.Execute(userDto.Email);

        var u = await _thirdPartyRepository.Save(thirdParty);

        return u;
    }

    private ThirdParty ToModel(SimpleRegister x)
      => new()
      {
          Email = x.Email,
          HashedPassword = x.Password,
      };

    private async Task AssertUniqueEmail(string email)
    {
        var thirdParty = await _thirdPartyRepository.FindByEmail(email);

        if (thirdParty is not null)
        {
            throw new EntityExistsException($"User with email {email} already exists.");
        }
    }
}
