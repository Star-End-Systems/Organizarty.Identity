using Organizarty.Domain.Entities.Consumers;

namespace Organizarty.Identity.UI.Controllers;

public record SecureConsumerResponse(string Id, string Fullname, DateTime BirthDate, string Email, DateTime CreatedAt)
{
    public static SecureConsumerResponse FromEntity(Consumer x)
      => new(x.Id, x.Fullname, x.BirthDate, x.Email, x.CreatedAt);
}

public record LoginUserResponse(SecureConsumerResponse consumer, string token);
