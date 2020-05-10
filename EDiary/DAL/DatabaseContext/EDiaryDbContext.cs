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
    }
}
