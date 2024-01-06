using Microsoft.AspNetCore.Mvc;
using Organizarty.Identity.UI.Helpers;
using Organizarty.Domain.Exceptions;

namespace Organizarty.Identity.UI.Controllers;

public partial class ConsumerController
{
    [HttpGet("me")]
    public async Task<IActionResult> ShowCurrentUser()
    {
        var token = Request.GetJwtToken();

        var userId = _tokenProvider.ReadIdFromToken(token) ?? throw new ValidationFailException("Authorization Token not found");

        var consumer = await _selectConsumer.FindById(userId) ?? throw new ValidationFailException("Invalid token");

        var response = SecureConsumerResponse.FromEntity(consumer);

        return Ok(response);
    }

}
