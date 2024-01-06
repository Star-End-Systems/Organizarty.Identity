using Organizarty.Domain.Exceptions;

namespace Organizarty.Identity.UI.Helpers;

public class AuthorizationHelper
{
    public static string? GetToken(HttpRequest request)
    {
        string? authHeader = request.Headers["Authorization"];

        return authHeader?.Substring("Bearer ".Length).Trim();
    }
}

public static class RequestUtils
{
    public static string? JwtToken(this HttpRequest request)
      => AuthorizationHelper.GetToken(request);

    public static string GetJwtToken(this HttpRequest request)
      => AuthorizationHelper.GetToken(request) ?? throw new ValidationFailException("Authorization Token not found");
}
