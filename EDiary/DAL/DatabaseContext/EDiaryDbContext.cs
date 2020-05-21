using DAL.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAL.DatabaseContext
{
    public class EDiaryDbContext : IdentityDbContext<ApplicationUser>
    {
        public EDiaryDbContext(DbContextOptions<EDiaryDbContext> options)
            : base(options)
        {

        }

        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
