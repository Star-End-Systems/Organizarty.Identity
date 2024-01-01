using Microsoft.Extensions.Logging;
using Organizarty.Identity.Adapters.EmailSenders;

namespace Organizarty.Identity.Infra.Providers.EmailSenders;

public class LocalEmailSender : IEmailSender
{
    private readonly ILogger<LocalEmailSender> _logger;

    public LocalEmailSender(ILogger<LocalEmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendEmailVerificationCode(string code, string targetEmail)
    {
        var msg = $"{targetEmail} code is => {code} <=";

        _logger.LogInformation(msg);

        return Task.CompletedTask;
    }
}
