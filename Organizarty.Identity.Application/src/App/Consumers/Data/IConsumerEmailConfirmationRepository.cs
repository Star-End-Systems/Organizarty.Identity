using Organizarty.Identity.Application.App.Consumers.Entities;

namespace Organizarty.Identity.Application.App.Consumers.Data;

public interface IConsumerEmailConfirmationRepository
{
    Task<ConsumerEmailConfirmation> Save(ConsumerEmailConfirmation confirmation);

    Task<ConsumerEmailConfirmation?> FindByCode(string code, string email);

    Task DeleteFromUserEmail(string userEmail);

}
