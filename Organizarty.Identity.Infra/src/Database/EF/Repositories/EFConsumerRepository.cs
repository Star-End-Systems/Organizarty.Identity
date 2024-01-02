using Microsoft.EntityFrameworkCore;
using Organizarty.Domain.Identifiers;
using Organizarty.Identity.Application.App.Consumers.Data;
using Organizarty.Domain.Entities.Consumers;
using Organizarty.Identity.Infra.Database.EF.Contexts;

namespace Organizarty.Identity.Infra.Database.EF.Repositories;

public class EFConsumerRepository : IConsumerRepository
{
    private readonly ApplicationDbContext _context;

    public EFConsumerRepository(ApplicationDbContext context)
      => _context = context;

    public async Task<Consumer?> FindByEmail(string email)
    => await _context.Consumers
               .AsNoTrackingWithIdentityResolution()
               .Where(x => x.Email == email)
               .FirstOrDefaultAsync();

    public async Task<Consumer?> FindById(string id)
    => await _context.Consumers
               .AsNoTrackingWithIdentityResolution()
               .Where(x => x.Id == id)
               .FirstOrDefaultAsync();

    public async Task<Consumer> Save(Consumer consumer)
    {
        consumer.Id = IdGenerator.DefaultId();

        var createdUser = _context.Consumers.Add(consumer);

        await _context.SaveChangesAsync();

        return createdUser.Entity;
    }

    public async Task<Consumer> Update(Consumer consumer)
    {
        var updatedUser = _context.Consumers.Update(consumer);

        await _context.SaveChangesAsync();

        return updatedUser.Entity;
    }
}
