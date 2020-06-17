using System;

namespace DAL.Models
{
    public class Post
    {
        public string CreatedByFullName { get; set; }
        public DateTime DateCreated { get; set; }
        public string Description { get; set; }
    }
}
