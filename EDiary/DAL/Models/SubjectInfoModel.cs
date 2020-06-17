using System.Collections.Generic;

namespace DAL.Models
{
    public class SubjectInfoModel
    {
        public List<Post> SubjectPosts { get; set; }
        public List<Person> SubjectPeople { get; set; }
        public List<Person> SubjectTeachers { get; set; }
    }
}
