namespace DAL.Entities
{
    public class TaskFileMapping : BaseEntity
    {
        public int FileId { get; set; }
        public File File { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
