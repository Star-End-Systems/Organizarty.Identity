using Organizarty.Identity.Application.App.Consumers.Entities;

namespace Organizarty.Identity.UI.Controllers;

public record LoginUserResponse(Consumer consumer, string token);
