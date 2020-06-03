namespace DAL.Entities
{
    public class TaskSubjectMapping : BaseEntity
    {
        public Task Task { get; set; }
        public Subject Subject { get; set; }
    }
}
