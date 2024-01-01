using Organizarty.Identity.Application.App.Consumers.Data;
using Organizarty.Identity.Application.App.Consumers.Entities;

namespace Organizarty.Identity.Application.App.Consumers.UseCases;

public class SelectConsumerUseCase
{
    private readonly IConsumerRepository _consumerRepository;

    public SelectConsumerUseCase(IConsumerRepository consumerRepository)
    {
        _consumerRepository = consumerRepository;
    }

    public Task<Consumer?> FindById(string id)
    => _consumerRepository.FindById(id);

    public Task<Consumer?> FindByEmail(string email)
    => _consumerRepository.FindByEmail(email);

}
