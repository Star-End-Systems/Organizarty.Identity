using Microsoft.AspNetCore.Mvc;
using Organizarty.Identity.UI.Helpers;
using Organizarty.Domain.Exceptions;

namespace Organizarty.Identity.UI.Controllers;

public partial class ConsumerController
{
    [HttpGet("me")]
    public async Task<IActionResult> ShowCurrentUser()
    {
        var token = AuthorizationHelper.GetToken(Request) ?? throw new ValidationFailException("Authorization Token not found");

        var userId = _tokenProvider.ReadIdFromToken(token) ?? throw new ValidationFailException("Authorization Token not found");

        var consumer = await _selectConsumer.FindById(userId) ?? throw new ValidationFailException("Authorization Token not found");

        var response = SecureConsumerResponse.FromEntity(consumer);

        return Ok(response);
    }

}
