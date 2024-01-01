using Organizarty.Identity.Adapters.EmailSenders;

namespace Organizarty.Identity.Infra.Providers.EmailSenders;

public class OrganizartyEmailSender : IEmailSender
{
    public Task SendEmailVerificationCode(string code, string targetEmail)
    {
        throw new NotImplementedException();
    }
}
