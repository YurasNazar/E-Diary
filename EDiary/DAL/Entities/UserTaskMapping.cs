using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserTaskMapping : BaseEntity
    {
        public ApplicationUser User { get; set; }
        public Task Task { get; set; }
    }
}
