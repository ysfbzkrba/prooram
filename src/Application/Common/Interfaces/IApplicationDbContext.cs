using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;


namespace prooram.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Domain.Entities.Category> Categories { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
