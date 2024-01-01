using FluentValidation;
using Organizarty.Domain.Exceptions;
using Organizarty.Identity.Adapters.Cryptographies;
using Organizarty.Identity.Application.App.Consumers.Data;
using Organizarty.Identity.Application.App.Consumers.Entities;

namespace Organizarty.Identity.Application.App.Consumers.UseCases;

public class LoginConsumerUseCase
{
    public record SimpleLogin(string Email, string Password);

    private readonly ICryptographys _cryptograph;
    private readonly IConsumerRepository _consumerRepository;
    private readonly IValidator<Consumer> _userValidator;

    public LoginConsumerUseCase(ICryptographys cryptograph, IConsumerRepository consumerRepository, IValidator<Consumer> userValidator)
    {
        _cryptograph = cryptograph;
        _consumerRepository = consumerRepository;
        _userValidator = userValidator;
    }

    public async Task<Consumer> Execute(SimpleLogin userDto)
    {
        var user = await _consumerRepository.FindByEmail(userDto.Email) ?? throw new NotFoundException($"User with email '{userDto.Email}' not found");

        var correctPassword = _cryptograph.VerifyPassword(userDto.Password, user.HashedPassword, user.Salt);

        if (!correctPassword)
        {
            throw new ValidationFailException("Email or password invalid.");
        }

        return user;
    }
}

