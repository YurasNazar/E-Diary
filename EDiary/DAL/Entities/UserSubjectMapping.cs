namespace DAL.Entities
{
    public class UserSubjectMapping : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
