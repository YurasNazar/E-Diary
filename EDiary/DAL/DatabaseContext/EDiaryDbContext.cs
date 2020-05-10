using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.DatabaseContext
{
    public class EDiaryDbContext : DbContext
    {
        public EDiaryDbContext(DbContextOptions<EDiaryDbContext> options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1
                },
                new User 
                {
                    Id = 2
                },
                new User 
                {
                    Id = 3
                });
        }
    }
}
