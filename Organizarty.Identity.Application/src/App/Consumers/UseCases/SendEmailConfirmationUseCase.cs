using Organizarty.Identity.Adapters.EmailSenders;
using Organizarty.Identity.Application.App.Consumers.Data;
using NanoidDotNet;
using Organizarty.Identity.Application.App.Consumers.Entities;

namespace Organizarty.Identity.Application.App.Consumers.UseCases;

public class SendEmailConfirmationUseCase
{
    private readonly IConsumerEmailConfirmationRepository _confirmationRepository;
    private readonly IEmailSender _emailSender;

    private readonly TimeSpan CODE_MAX_AGE = TimeSpan.FromHours(24);
    public readonly int CODE_SIZE = 4;
    public readonly string ID_VALID_CHARACTERs = "1234567890";

    public SendEmailConfirmationUseCase(IEmailSender emailSender, IConsumerEmailConfirmationRepository confirmationRepository)
    {
        _emailSender = emailSender;
        _confirmationRepository = confirmationRepository;
    }

    public async Task<string> Execute(string targetEmail)
    {
        var code = GenCode();

        var confirmationCode = new ConsumerEmailConfirmation
        {
            UserEmail = targetEmail,
            Code = code,
            ValidTill = DateTime.UtcNow.Add(CODE_MAX_AGE),
        };

        await _confirmationRepository.Save(confirmationCode);

        await _emailSender.SendEmailVerificationCode(code, targetEmail);

        return code;
    }

    private string GenCode() => Nanoid.Generate(ID_VALID_CHARACTERs, size: CODE_SIZE);
}
