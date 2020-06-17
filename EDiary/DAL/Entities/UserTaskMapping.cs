namespace DAL.Entities
{
    public class UserTaskMapping : BaseEntity
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
