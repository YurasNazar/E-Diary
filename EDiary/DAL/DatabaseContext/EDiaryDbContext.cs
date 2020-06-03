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

        public DbSet<Task> Tasks { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<UserTaskMapping> UserTasksMapping { get; set; }
        public DbSet<UserSubjectMapping> UserSubjectsMapping { get; set; }
        public DbSet<ScheduleEvent> ScheduleEvents { get; set; }
        public DbSet<SubjectPost> SubjectPosts { get; set; }
        public DbSet<TaskSubjectMapping> TaskSubjectMapping { get; set; }
        public DbSet<UserScheculeEventMapping> UserScheculeEventsMapping { get; set; }
    }
}
