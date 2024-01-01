using Organizarty.Domain.Exceptions;
using Organizarty.Identity.Application.App.Consumers.Data;
using Organizarty.Identity.Application.App.Consumers.Entities;

namespace Organizarty.Identity.Application.App.Consumers.UseCases;

public class ConfirmConsumerCodeUseCase
{
    private readonly IConsumerRepository _consumerRepository;
    private readonly IConsumerEmailConfirmationRepository _confirmationRepository;

    public record ConfirmEmail(string code, string targetEmail);

    public ConfirmConsumerCodeUseCase(IConsumerRepository consumerRepository, IConsumerEmailConfirmationRepository confirmationRepository)
    {
        _consumerRepository = consumerRepository;
        _confirmationRepository = confirmationRepository;
    }

    public async Task Execute(ConfirmEmail dto)
    {
        var confirmation = await _confirmationRepository.FindByCode(dto.code, dto.targetEmail) ?? throw new NotFoundException("Invalid code");

        AssertValidEmaiCode(confirmation);

        var user = await _consumerRepository.FindByEmail(dto.targetEmail) ?? throw new NotFoundException("Invalid code");

        user.EmailConfirmed = true;

        await _consumerRepository.Update(user);

        await _confirmationRepository.DeleteFromUserEmail(dto.targetEmail);
    }

    private void AssertValidEmaiCode(ConsumerEmailConfirmation confirmation)
    {
        if (confirmation.ValidTill <= DateTime.UtcNow)
        {
            // FIX: Change the exception type.
            throw new NotFoundException("Code expires");
        }
    }
}
