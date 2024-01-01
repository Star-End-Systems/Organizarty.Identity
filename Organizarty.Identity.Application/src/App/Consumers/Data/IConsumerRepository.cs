using Organizarty.Identity.Application.App.Consumers.Entities;

namespace Organizarty.Identity.Application.App.Consumers.Data;

public interface IConsumerRepository
{
    Task<Consumer> Save(Consumer consumer);
    Task<Consumer> Update(Consumer consumer);

    Task<Consumer?> FindByEmail(string email);
    Task<Consumer?> FindById(string id);
}

