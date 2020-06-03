using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class UserSubjectMapping : BaseEntity
    {
        public ApplicationUser User { get; set; }
        public Subject Subject { get; set; }
    }
}
