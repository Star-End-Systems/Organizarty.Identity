using Microsoft.AspNetCore.Mvc;
using Organizarty.Identity.Application.App.Consumers.UseCases;
using Organizarty.Identity.Adapters.Tokens;

namespace Organizarty.Identity.UI.Controllers.Consumers;

[ApiController]
[Route("[controller]")]
public partial class ConsumerController : ControllerBase
{
    private readonly ILogger<ConsumerController> _logger;

    private readonly IWebTokenProvider _tokenProvider;

    private readonly RegisterConsumerUseCase _registerConsumer;
    private readonly LoginConsumerUseCase _loginConsumer;
    private readonly SelectConsumerUseCase _selectConsumer;
    private readonly ConfirmConsumerCodeUseCase _confirmConsumer;

    public ConsumerController(ILogger<ConsumerController> logger, RegisterConsumerUseCase registerConsumer, IWebTokenProvider tokenProvider, LoginConsumerUseCase loginConsumer, SelectConsumerUseCase selectConsumer, ConfirmConsumerCodeUseCase confirmConsumer)
    {
        _logger = logger;
        _registerConsumer = registerConsumer;
        _tokenProvider = tokenProvider;
        _loginConsumer = loginConsumer;
        _selectConsumer = selectConsumer;
        _confirmConsumer = confirmConsumer;
    }
}
