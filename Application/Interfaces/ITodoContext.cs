using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ITodoContext
    {
        DbSet<Users> Users { get; set; }
        DbSet<Todos> Todos { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
