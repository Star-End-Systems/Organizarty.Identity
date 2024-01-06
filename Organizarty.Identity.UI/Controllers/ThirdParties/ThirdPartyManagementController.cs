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

    [HttpPost("login")]
    public async Task<IActionResult> LoginThirdParty(LoginThirdPartyUseCase.LoginThirdParty loginDto)
    {
        var thirdParty = await _loginThirdParty.Execute(loginDto);

        var token = _tokenProvider.GenerateToken(thirdParty.Id, thirdParty.UserName, "ThirdParty");

        var response = new LoginThirdPartyResponse(SecureThirdPartyResponse.From(thirdParty), token);

        return Ok(response);
    }
}
