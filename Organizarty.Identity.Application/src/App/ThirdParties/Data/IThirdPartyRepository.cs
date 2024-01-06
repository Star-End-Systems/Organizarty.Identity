using Organizarty.Identity.Application.App.ThirdParties.Entities;

namespace Organizarty.Identity.Application.App.ThirdParties.Data;

public interface IThirdPartyRepository
{
    Task<ThirdParty> Save(ThirdParty consumer);
    Task<ThirdParty> Update(ThirdParty consumer);

    Task<ThirdParty?> FindByEmail(string email);
    Task<ThirdParty?> FindById(string id);
}

