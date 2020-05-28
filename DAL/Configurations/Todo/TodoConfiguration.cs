using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations.Todo
{
    public class TodoConfiguration : IEntityTypeConfiguration<Todos>
    {
        public void Configure(EntityTypeBuilder<Todos> builder)
        {
            builder.HasKey(s => s.ID);
            builder.HasOne(d => d.User)
                .WithMany(p => p.Todos)
                .HasForeignKey(d => d.UserID)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
