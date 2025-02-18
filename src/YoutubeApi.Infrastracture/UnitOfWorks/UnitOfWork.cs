using Microsoft.EntityFrameworkCore;
using YoutubeApi.Domain.Abstraction;
using YoutubeApi.Infrastracture.Repositories;

namespace YoutubeApi.Infrastracture.UnitOfWorks
{
    public class UnitOfWork(
        AppDbContext context) : IUnitOfWork
    {
        private readonly AppDbContext _context = context;

        public async Task<string> CommitAsync(CancellationToken cancellationToken = default, bool checkForConcurrency = false)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException) when (checkForConcurrency)
            {
                return "A concurrency conflict occured while saving changes";
            }

            return string.Empty;
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        => new GenericRepository<TEntity>(_context);
    }
}
