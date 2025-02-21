
using Microsoft.EntityFrameworkCore;
using TechLibrary.Domain.entities;

namespace TechLibrary.Infrastructure
{
    public class TechLibraryDbContext:DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<BookEntity> Books { get; set; } 

        public DbSet<CheckoutEntity> Checkouts { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=inserir depois");
        }
    }
}
