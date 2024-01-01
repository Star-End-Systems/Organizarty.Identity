using FluentValidation;
using Organizarty.Identity.Adapters.Cryptographies;
using Organizarty.Identity.Application.App.Consumers.Data;
using Organizarty.Identity.Application.App.Consumers.Entities;
using Organizarty.Utils.Extensions;

namespace Organizarty.Identity.Application.App.Consumers.UseCases;

public class RegisterConsumerUseCase
{
    public record SimpleRegister(string Email, string Password, string Username, string Fullname, DateTime BirthDate);

    private readonly ICryptographys _cryptograph;
    private readonly IConsumerRepository _consumerRepository;
    private readonly IValidator<Consumer> _userValidator;
    private readonly SendEmailConfirmationUseCase _sendEmailConfirmation;

    public RegisterConsumerUseCase(ICryptographys cryptograph, IConsumerRepository consumerRepository, IValidator<Consumer> userValidator, SendEmailConfirmationUseCase sendEmailConfirmation)
    {
        _cryptograph = cryptograph;
        _consumerRepository = consumerRepository;
        _userValidator = userValidator;
        _sendEmailConfirmation = sendEmailConfirmation;
    }

    public async Task<Consumer> Execute(SimpleRegister userDto)
    {
        var consumer = ToModel(userDto);

        _userValidator.Check(consumer, "Fail while validating Consumer");

        var (password, salt) = _cryptograph.HashPassword(consumer.HashedPassword);

        consumer.HashedPassword = password;
        consumer.Salt = salt;

        var u = await _consumerRepository.Save(consumer);

        await _sendEmailConfirmation.Execute(userDto.Email);

        return u;
    }

    private Consumer ToModel(SimpleRegister x)
      => new()
      {
          Email = x.Email,
          UserName = x.Username,
          Fullname = x.Fullname,
          HashedPassword = x.Password,
          BirthDate = x.BirthDate,
      };
}

