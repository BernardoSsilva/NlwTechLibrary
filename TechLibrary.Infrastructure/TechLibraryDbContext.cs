
using Microsoft.EntityFrameworkCore;
using TechLibrary.Domain.entities;

namespace TechLibrary.Infrastructure
{
    public class TechLibraryDbContext:DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=inserir depois");
        }
    }
}
