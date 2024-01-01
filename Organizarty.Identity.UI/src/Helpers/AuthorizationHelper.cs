namespace Organizarty.Identity.UI.Helpers;

public class AuthorizationHelper
{
    public static string? GetToken(HttpRequest request)
    {
        string? authHeader = request.Headers["Authorization"];

        return authHeader?.Substring("Bearer ".Length).Trim();
    }

}
