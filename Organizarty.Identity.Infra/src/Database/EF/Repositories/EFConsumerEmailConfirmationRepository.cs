using Microsoft.EntityFrameworkCore;
using Organizarty.Domain.Identifiers;
using Organizarty.Identity.Application.App.Consumers.Data;
using Organizarty.Identity.Application.App.Consumers.Entities;
using Organizarty.Identity.Infra.Database.EF.Contexts;

namespace Organizarty.Identity.Infra.Database.EF.Repositories;

public class EFConsumerEmailConfirmationRepository : IConsumerEmailConfirmationRepository
{
    private readonly ApplicationDbContext _context;

    public EFConsumerEmailConfirmationRepository(ApplicationDbContext context)
      => _context = context;

    public async Task<ConsumerEmailConfirmation> Save(ConsumerEmailConfirmation confirmation)
    {
        confirmation.Id = IdGenerator.DefaultId();

        _context.ConsumerEmailConfirmations.Add(confirmation);

        await _context.SaveChangesAsync();

        return confirmation;
    }


    public async Task<ConsumerEmailConfirmation?> FindByCode(string code, string email)
    => await _context.ConsumerEmailConfirmations
                     .AsNoTrackingWithIdentityResolution()
                     .Where(x => x.Code == code)
                     .Where(x => x.UserEmail == email)
                     .FirstOrDefaultAsync();

    public async Task DeleteFromUserEmail(string userEmail)
    {
        _context.ConsumerEmailConfirmations.RemoveRange(_context.ConsumerEmailConfirmations.Where(x => x.UserEmail == userEmail));

        await _context.SaveChangesAsync();
    }
}
