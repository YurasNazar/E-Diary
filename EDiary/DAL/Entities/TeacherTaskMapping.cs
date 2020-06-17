using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class TeacherTaskMapping : BaseEntity
    {
        public string TeacherId { get; set; }
        public ApplicationUser Teacher { get; set; }
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
