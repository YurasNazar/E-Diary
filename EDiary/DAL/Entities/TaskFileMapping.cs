namespace DAL.Entities
{
    public class TaskFileMapping : BaseEntity
    {
        public Task Task { get; set; }
        public File File { get; set; }
    }
}
