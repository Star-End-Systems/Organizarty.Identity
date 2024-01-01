using Microsoft.AspNetCore.Mvc;
using Organizarty.Identity.Application.App.Consumers.UseCases;

namespace Organizarty.Identity.UI.Controllers;

public partial class ConsumerController
{
    [HttpPost("confirm-code")]
    public async Task<ActionResult<LoginUserResponse>> ConfirmConsumeCode(ConfirmConsumerCodeUseCase.ConfirmEmail confirmDto)
    {
        await _confirmConsumer.Execute(confirmDto);

        return Ok("Account confirmed");
    }
}

