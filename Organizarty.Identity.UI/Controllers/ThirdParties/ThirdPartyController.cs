using Microsoft.AspNetCore.Mvc;
using Organizarty.Identity.Application.App.ThirdParties.UseCases;
using Organizarty.Identity.Adapters.Tokens;

namespace Organizarty.Identity.UI.Controllers.ThirdParties;

[ApiController]
[Route("[controller]")]
public partial class ThirdPartyController : ControllerBase
{
    private readonly ILogger<ThirdPartyController> _logger;

    private readonly IWebTokenProvider _tokenProvider;
    private readonly RegisterThirdPartyUseCase _registerThirdParty;

    public ThirdPartyController(ILogger<ThirdPartyController> logger, IWebTokenProvider tokenProvider, RegisterThirdPartyUseCase registerThirdParty)
    {
        _logger = logger;
        _tokenProvider = tokenProvider;
        _registerThirdParty = registerThirdParty;
    }
}
