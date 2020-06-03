namespace DAL.Entities
{
    public class UserScheculeEventMapping : BaseEntity
    {
        public ApplicationUser User { get; set; }
        public ScheduleEvent ScheduleEvent { get; set; }
    }
}
