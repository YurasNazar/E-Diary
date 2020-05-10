using DAL.Entities;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IUserService
    {
        IList<User> GetUsers();
    }
}
