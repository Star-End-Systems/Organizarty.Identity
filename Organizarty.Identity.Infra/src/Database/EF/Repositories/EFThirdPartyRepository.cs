using Microsoft.EntityFrameworkCore;

using Organizarty.Domain.Identifiers;
using Organizarty.Identity.Application.App.ThirdParties.Entities;
using Organizarty.Identity.Application.App.ThirdParties.Data;
using Organizarty.Identity.Infra.Database.EF.Contexts;

namespace Organizarty.Identity.Infra.Database.EF.Repositories;

public class EFThirdPartyRepository : IThirdPartyRepository
{
    private readonly ApplicationDbContext _context;

    public EFThirdPartyRepository(ApplicationDbContext context)
      => _context = context;

    public async Task<ThirdParty> Save(ThirdParty thirdParty)
    {
        thirdParty.Id = IdGenerator.DefaultId();

        var createdUser = _context.ThirdParties.Add(thirdParty);

        await _context.SaveChangesAsync();

        return createdUser.Entity;
    }

    public async Task<ThirdParty> Update(ThirdParty thirdParty)
    {
        var updatedUser = _context.ThirdParties.Update(thirdParty);

        await _context.SaveChangesAsync();

        return updatedUser.Entity;
    }

    public async Task<ThirdParty?> FindByEmail(string email)
    => await _context.ThirdParties
               .AsNoTrackingWithIdentityResolution()
               .Where(x => x.Email == email)
               .FirstOrDefaultAsync();

    public async Task<ThirdParty?> FindById(string id)
    => await _context.ThirdParties
               .AsNoTrackingWithIdentityResolution()
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();
}
