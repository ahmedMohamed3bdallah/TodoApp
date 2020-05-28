using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace DAL
{
    public class TodoContext: DbContext, ITodoContext
    {
        public TodoContext(DbContextOptions<TodoContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TodoContext).Assembly);
        }

        public DbSet<Users> Users { get; set ; }
        public DbSet<Todos> Todos { get ; set ; }
    }
}
