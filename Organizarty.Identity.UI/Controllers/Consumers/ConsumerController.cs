using Microsoft.AspNetCore.Mvc;
using Organizarty.Identity.Application.App.Consumers.UseCases;
using Organizarty.Identity.Adapters.EmailSenders;

namespace Organizarty.Identity.UI.Controllers;

[ApiController]
[Route("[controller]")]
public partial class ConsumerController : ControllerBase
{
    private readonly ILogger<ConsumerController> _logger;

    private readonly IWebTokenProvider _tokenProvider;

    private readonly RegisterConsumerUseCase _registerConsumer;
    private readonly LoginConsumerUseCase _loginConsumer;

    public ConsumerController(ILogger<ConsumerController> logger, RegisterConsumerUseCase registerConsumer, IWebTokenProvider tokenProvider, LoginConsumerUseCase loginConsumer)
    {
        _logger = logger;
        _registerConsumer = registerConsumer;
        _tokenProvider = tokenProvider;
        _loginConsumer = loginConsumer;
    }
}
