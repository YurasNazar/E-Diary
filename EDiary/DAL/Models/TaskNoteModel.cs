using System;

namespace DAL.Models
{
    public class TaskNoteModel
    {
        public string CreatedBy { get; set; }
        public string Note { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
