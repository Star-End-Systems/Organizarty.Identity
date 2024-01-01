using Microsoft.AspNetCore.Mvc;
using Organizarty.Identity.Application.App.Consumers.UseCases;

namespace Organizarty.Identity.UI.Controllers;

public partial class ConsumerController
{
    [HttpPost]
    public async Task<IActionResult> RegisterConsumer(RegisterConsumerUseCase.SimpleRegister registerDto)
    {
        return Ok(await _registerConsumer.Execute(registerDto));
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginUserResponse>> LoginConsumer(LoginConsumerUseCase.SimpleLogin registerDto)
    {
        var user = await _loginConsumer.Execute(registerDto);

        var token = _tokenProvider.GenerateToken(user.Id, user.Fullname, "Consumer");

        var response = new LoginUserResponse(SecureConsumerResponse.FromEntity(user), token);

        return Ok(response);
    }
}
