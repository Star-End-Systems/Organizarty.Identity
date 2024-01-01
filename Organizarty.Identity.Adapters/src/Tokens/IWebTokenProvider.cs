namespace Organizarty.Identity.Adapters.EmailSenders;

public interface IWebTokenProvider
{
    string GenerateToken(string userId, string username, string role);
}
