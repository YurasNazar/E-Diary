using DAL.Entities;
using System.Collections.Generic;


namespace EDiary.ViewModels
{
    public class HomeIndexViewModel
    {
        public IList<User> Users { get; set; }
    }
}
