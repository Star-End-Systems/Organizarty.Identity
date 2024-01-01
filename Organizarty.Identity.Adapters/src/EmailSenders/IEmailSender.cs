namespace Organizarty.Identity.Adapters.EmailSenders;

public interface IEmailSender
{
    Task SendEmailVerificationCode(string code, string targetEmail);
}
