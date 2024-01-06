using Microsoft.AspNetCore.Mvc;
using Organizarty.Identity.Application.App.ThirdParties.UseCases;

namespace Organizarty.Identity.UI.Controllers.ThirdParties;

public partial class ThirdPartyController
{
    [HttpPost("register")]
    public async Task<IActionResult> RegisterThirdParty(RegisterThirdPartyUseCase.RegisterThirdParty registerDto)
    {
        var thirdParty = await _registerThirdParty.Execute(registerDto);

        return Ok(SecureThirdPartyResponse.From(thirdParty));
    }
}
